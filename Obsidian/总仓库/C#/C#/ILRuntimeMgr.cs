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
    //用于存储加载出来的 两个文件的内存流对象
    private MemoryStream dllStream;
    private MemoryStream pdbStream;

    private bool isStart = false;

    //是否要调试
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
    /// 用于启动ILRuntime初始化方法
    /// </summary>
    public void StartILRuntime( UnityAction callBack = null )
    {
        if(!isStart)
        {
            isStart = true;
            //如果我们要全局开启寄存器模式，那么他的模式一定是JITOnDemand 建议不要填写其他的模式了
            appDomain = new AppDomain(ILRuntimeJITFlags.JITOnDemand);
            StartCoroutine(LoadHotUpdateInfo(callBack));
        }
    }

    public void StopILRuntime()
    {
        //1.释放流
        if (dllStream != null)
            dllStream.Close();
        if (pdbStream != null)
            pdbStream.Close();
        dllStream = null;
        pdbStream = null;
        //2.清空appDomain
        appDomain = null;

        isStart = false;
    }

    /// <summary>
    /// 初始化ILRuntime相关的内容
    /// </summary>
    private unsafe void InitILRuntime()
    {
        //其他初始化
        //委托转换器注册（要把自定义委托转换为Action或者Func）
        //appDomain.DelegateManager.RegisterDelegateConvertor<MyUnityDel1>((act) =>
        //{
        //    return new MyUnityDel1(() =>
        //    {
        //        ((System.Action)act)();
        //    });
        //});

        //委托注册
        appDomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
        ////委托转换器注册（要把自定义委托转换为Action或者Func）
        //appDomain.DelegateManager.RegisterDelegateConvertor<MyUnityDel2>((act) =>
        //{
        //    return new MyUnityDel2((i, j) =>
        //    {
        //        return ((System.Func<System.Int32, System.Int32, System.Int32>)act)(i, j);
        //    });
        //});

        //注册跨域继承适配器
        appDomain.RegisterCrossBindingAdaptor(new Lesson11_TestAdapter());
        appDomain.RegisterCrossBindingAdaptor(new Lesson12_InterfaceAdapter());
        appDomain.RegisterCrossBindingAdaptor(new Lesson12_BaseClassAdapter());
        //注册 协同程序相关的 跨域继承适配器
        appDomain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
        appDomain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());

        //注册值类型绑定相关内容
        appDomain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
        appDomain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
        appDomain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());

        //CLR重定向内容 要写到CLR绑定之前
        //得到想要重定向类的Type
        System.Type debugType = typeof(Debug);
        //得到想要重定向方法的方法信息
        MethodInfo methodInfo = debugType.GetMethod("Log", new System.Type[] { typeof(object) });
        //进行CLR重定向
        appDomain.RegisterCLRMethodRedirection(methodInfo, MyLog);

        //注册 CLR绑定相关的信息
        ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);

        //注册LitJson相关的内容
        LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appDomain);

        //初始化ILRuntime相关信息（目前只需要告诉ILRuntime主线程的线程ID，主要目的是能够在Unity的Profiler剖析器窗口中分析问题）
        appDomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;

        //启动调试服务
        if(isDebug)
            appDomain.DebugService.StartDebugService(56000);
        //appDomain.Prewarm("命名空间名.类名");
    }

    private unsafe StackObject* MyLog(ILIntepreter __intp, StackObject* __esp, UncheckedList<object> __mStack, CLRMethod method, bool isNewObj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
        //移动到栈底 用于之后返回
        StackObject* __ret = ILIntepreter.Minus(__esp, 1);
        //获取参数值
        StackObject* ptr_of_this_method;
        ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
        //类型转换 将StackObject转换为Unity当中的类型
        System.Object @message = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (ILRuntime.CLR.Utils.Extensions.TypeFlags)0);
        //清理当前栈指针内存
        __intp.Free(ptr_of_this_method);
        //获取对应的 行号等等相关信息
        var stackTrace = __domain.DebugService.GetStackTrace(__intp);

        //重定向相关逻辑代码
        UnityEngine.Debug.Log(@message + "\n" + stackTrace);

        //返回
        return __ret;
    }


    /// <summary>
    /// 启动完毕并且初始化完毕后 想要执行的热更新的逻辑
    /// </summary>
    private void ILRuntimeLoadOverDoSomthing()
    {

    }

    /// <summary>
    /// 去异步加载我们的热更相关的dll和pdb文件
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadHotUpdateInfo(UnityAction callBack)
    {
        //这部分知识点在 Unity网络开发基础当中有讲解
        //加载本地的DLL文件
#if UNITY_ANDROID
        UnityWebRequest reqDll = UnityWebRequest.Get(Application.streamingAssetsPath + "/HotFix_Project.dll");
#else
        UnityWebRequest reqDll = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll");
#endif
        yield return reqDll.SendWebRequest();
        //如果失败了
        if (reqDll.result != UnityWebRequest.Result.Success)
            print("加载DLL文件失败" + reqDll.responseCode + reqDll.result);
        //读取加载的DLL数据
        byte[] dll = reqDll.downloadHandler.data;
        reqDll.Dispose();

#if UNITY_ANDROID
        UnityWebRequest reqPdb = UnityWebRequest.Get(Application.streamingAssetsPath + "/HotFix_Project.pdb");
#else
        UnityWebRequest reqPdb = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/HotFix_Project.pdb");
#endif
        yield return reqPdb.SendWebRequest();
        //如果失败了
        if (reqPdb.result != UnityWebRequest.Result.Success)
            print("加载Pdb文件失败" + reqPdb.responseCode + reqPdb.result);
        //读取加载的DLL数据
        byte[] pdb = reqPdb.downloadHandler.data;
        reqPdb.Dispose();

        //3.将加载的数据以流的形式(文件流或者内存流对象)传递给AppDomain对象中的LoadAssembly方法
        //注意 这里使用流 不要用完就关 一定要等到热更相关内容不使用了 再关闭
        dllStream = new MemoryStream(dll);
        pdbStream = new MemoryStream(pdb);
        //将我们两个文件的内存流用于初始化 appDomain 我们之后就可以通过该对象来执行我们对应的热更代码了
        appDomain.LoadAssembly(dllStream, pdbStream, new PdbReaderProvider());

        InitILRuntime();

        if(isDebug)
        {
            //如果想要调试我们的项目 那么就加一个协同程序去等待
            //等待调试器链接进入过后 再去执行我们后续的逻辑
            StartCoroutine(WaitDebugger(callBack));
        }
        else
        {
            ILRuntimeLoadOverDoSomthing();

            //当ILRuntime启动完毕 想要在外部执行的内容
            callBack?.Invoke();
        }
    }

    IEnumerator WaitDebugger(UnityAction callBack)
    {
        print("等待调试器的接入");
        //不停判断 是否有调试器接入 如果为false  就一直等待
        //知道为true 就代表有调试器接入了
        while (!appDomain.DebugService.IsDebuggerAttached)
            yield return null;
        print("调试器接入成功");
        yield return new WaitForSeconds(1f);

        ILRuntimeLoadOverDoSomthing();

        //当ILRuntime启动完毕 想要在外部执行的内容
        callBack?.Invoke();
    }
}
