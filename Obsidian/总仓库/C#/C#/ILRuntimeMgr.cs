using ILRuntime.CLR.Method;
using ILRuntime.CLR.Utils;
using ILRuntime.Mono.Cecil.Pdb;
using ILRuntime.Other;
using ILRuntime.Runtime;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntimeAdapter;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ILRuntimeMgr : MonoBehaviour
{
    private static ILRuntimeMgr instance;

    public AppDomain appDomain;
    //���ڴ洢���س����� �����ļ����ڴ�������
    private MemoryStream dllStream;
    private MemoryStream pdbStream;

    private bool isStart = false;

    //�Ƿ�Ҫ����
    private bool isDebug = false;

    public static ILRuntimeMgr Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject obj = new GameObject("ILRuntimeMgr");
                instance = obj.AddComponent<ILRuntimeMgr>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }

    /// <summary>
    /// ��������ILRuntime��ʼ������
    /// </summary>
    public void StartILRuntime( UnityAction callBack = null )
    {
        if(!isStart)
        {
            isStart = true;
            //�������Ҫȫ�ֿ����Ĵ���ģʽ����ô����ģʽһ����JITOnDemand ���鲻Ҫ��д������ģʽ��
            appDomain = new AppDomain(ILRuntimeJITFlags.JITOnDemand);
            StartCoroutine(LoadHotUpdateInfo(callBack));
        }
    }

    public void StopILRuntime()
    {
        //1.�ͷ���
        if (dllStream != null)
            dllStream.Close();
        if (pdbStream != null)
            pdbStream.Close();
        dllStream = null;
        pdbStream = null;
        //2.���appDomain
        appDomain = null;

        isStart = false;
    }

    /// <summary>
    /// ��ʼ��ILRuntime��ص�����
    /// </summary>
    private unsafe void InitILRuntime()
    {
        //������ʼ��
        //ί��ת����ע�ᣨҪ���Զ���ί��ת��ΪAction����Func��
        //appDomain.DelegateManager.RegisterDelegateConvertor<MyUnityDel1>((act) =>
        //{
        //    return new MyUnityDel1(() =>
        //    {
        //        ((System.Action)act)();
        //    });
        //});

        //ί��ע��
        appDomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
        ////ί��ת����ע�ᣨҪ���Զ���ί��ת��ΪAction����Func��
        //appDomain.DelegateManager.RegisterDelegateConvertor<MyUnityDel2>((act) =>
        //{
        //    return new MyUnityDel2((i, j) =>
        //    {
        //        return ((System.Func<System.Int32, System.Int32, System.Int32>)act)(i, j);
        //    });
        //});

        //ע�����̳�������
        appDomain.RegisterCrossBindingAdaptor(new Lesson11_TestAdapter());
        appDomain.RegisterCrossBindingAdaptor(new Lesson12_InterfaceAdapter());
        appDomain.RegisterCrossBindingAdaptor(new Lesson12_BaseClassAdapter());
        //ע�� Эͬ������ص� ����̳�������
        appDomain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
        appDomain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());

        //ע��ֵ���Ͱ��������
        appDomain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
        appDomain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
        appDomain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());

        //CLR�ض������� Ҫд��CLR��֮ǰ
        //�õ���Ҫ�ض������Type
        System.Type debugType = typeof(Debug);
        //�õ���Ҫ�ض��򷽷��ķ�����Ϣ
        MethodInfo methodInfo = debugType.GetMethod("Log", new System.Type[] { typeof(object) });
        //����CLR�ض���
        appDomain.RegisterCLRMethodRedirection(methodInfo, MyLog);

        //ע�� CLR����ص���Ϣ
        ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);

        //ע��LitJson��ص�����
        LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appDomain);

        //��ʼ��ILRuntime�����Ϣ��Ŀǰֻ��Ҫ����ILRuntime���̵߳��߳�ID����ҪĿ�����ܹ���Unity��Profiler�����������з������⣩
        appDomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;

        //�������Է���
        if(isDebug)
            appDomain.DebugService.StartDebugService(56000);
        //appDomain.Prewarm("�����ռ���.����");
    }

    private unsafe StackObject* MyLog(ILIntepreter __intp, StackObject* __esp, UncheckedList<object> __mStack, CLRMethod method, bool isNewObj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
        //�ƶ���ջ�� ����֮�󷵻�
        StackObject* __ret = ILIntepreter.Minus(__esp, 1);
        //��ȡ����ֵ
        StackObject* ptr_of_this_method;
        ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
        //����ת�� ��StackObjectת��ΪUnity���е�����
        System.Object @message = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (ILRuntime.CLR.Utils.Extensions.TypeFlags)0);
        //����ǰջָ���ڴ�
        __intp.Free(ptr_of_this_method);
        //��ȡ��Ӧ�� �кŵȵ������Ϣ
        var stackTrace = __domain.DebugService.GetStackTrace(__intp);

        //�ض�������߼�����
        UnityEngine.Debug.Log(@message + "\n" + stackTrace);

        //����
        return __ret;
    }


    /// <summary>
    /// ������ϲ��ҳ�ʼ����Ϻ� ��Ҫִ�е��ȸ��µ��߼�
    /// </summary>
    private void ILRuntimeLoadOverDoSomthing()
    {

    }

    /// <summary>
    /// ȥ�첽�������ǵ��ȸ���ص�dll��pdb�ļ�
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadHotUpdateInfo(UnityAction callBack)
    {
        //�ⲿ��֪ʶ���� Unity���翪�����������н���
        //���ر��ص�DLL�ļ�
#if UNITY_ANDROID
        UnityWebRequest reqDll = UnityWebRequest.Get(Application.streamingAssetsPath + "/HotFix_Project.dll");
#else
        UnityWebRequest reqDll = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll");
#endif
        yield return reqDll.SendWebRequest();
        //���ʧ����
        if (reqDll.result != UnityWebRequest.Result.Success)
            print("����DLL�ļ�ʧ��" + reqDll.responseCode + reqDll.result);
        //��ȡ���ص�DLL����
        byte[] dll = reqDll.downloadHandler.data;
        reqDll.Dispose();

#if UNITY_ANDROID
        UnityWebRequest reqPdb = UnityWebRequest.Get(Application.streamingAssetsPath + "/HotFix_Project.pdb");
#else
        UnityWebRequest reqPdb = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/HotFix_Project.pdb");
#endif
        yield return reqPdb.SendWebRequest();
        //���ʧ����
        if (reqPdb.result != UnityWebRequest.Result.Success)
            print("����Pdb�ļ�ʧ��" + reqPdb.responseCode + reqPdb.result);
        //��ȡ���ص�DLL����
        byte[] pdb = reqPdb.downloadHandler.data;
        reqPdb.Dispose();

        //3.�����ص�������������ʽ(�ļ��������ڴ�������)���ݸ�AppDomain�����е�LoadAssembly����
        //ע�� ����ʹ���� ��Ҫ����͹� һ��Ҫ�ȵ��ȸ�������ݲ�ʹ���� �ٹر�
        dllStream = new MemoryStream(dll);
        pdbStream = new MemoryStream(pdb);
        //�����������ļ����ڴ������ڳ�ʼ�� appDomain ����֮��Ϳ���ͨ���ö�����ִ�����Ƕ�Ӧ���ȸ�������
        appDomain.LoadAssembly(dllStream, pdbStream, new PdbReaderProvider());

        InitILRuntime();

        if(isDebug)
        {
            //�����Ҫ�������ǵ���Ŀ ��ô�ͼ�һ��Эͬ����ȥ�ȴ�
            //�ȴ����������ӽ������ ��ȥִ�����Ǻ������߼�
            StartCoroutine(WaitDebugger(callBack));
        }
        else
        {
            ILRuntimeLoadOverDoSomthing();

            //��ILRuntime������� ��Ҫ���ⲿִ�е�����
            callBack?.Invoke();
        }
    }

    IEnumerator WaitDebugger(UnityAction callBack)
    {
        print("�ȴ��������Ľ���");
        //��ͣ�ж� �Ƿ��е��������� ���Ϊfalse  ��һֱ�ȴ�
        //֪��Ϊtrue �ʹ����е�����������
        while (!appDomain.DebugService.IsDebuggerAttached)
            yield return null;
        print("����������ɹ�");
        yield return new WaitForSeconds(1f);

        ILRuntimeLoadOverDoSomthing();

        //��ILRuntime������� ��Ҫ���ⲿִ�е�����
        callBack?.Invoke();
    }
}
