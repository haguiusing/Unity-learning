using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ��ϰ ����ILRuntime ���������
        ILRuntimeMgr.Instance.StartILRuntime(()=>{
            AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            //�õ�IType ͨ����ʵ����һ��ָ�����ȸ��¹����е������ (Lesson3_Test)
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            object obj = ((ILType)type).Instantiate();

            //��Ա�������ú;�̬�������ü���һ��
            //���������Ҫ�ȴ������󣬽�������֮ǰΪnull�ĵط�
            //1.ֱ��ͨ��appdomain.Invoke("�����ռ�.����", "������", �����, �����б�)
            appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestFun", obj, null);

            int i = (int)appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestFun2", obj, 99);
            print(i);

            //2.ͨ�����Ʒ����IMethod���÷���
            //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���

            //�õ���Ӧ�����ķ�����Ϣ
            IMethod method1 = type.GetMethod("TestFun", 0);
            IMethod method2 = type.GetMethod("TestFun2", 1);

            //  2-1.ͨ��appdomain.Invoke��IMethod����, �����, �����б�
            appDomain.Invoke(method1, obj);

            i = (int)appDomain.Invoke(method2, obj, 88);
            print(i);

            //  2-2.ͨ������Լ���ܵ�GC Alloc��ʽ���������ֱ�ӻ��գ����ã������Ͻڿεĳ�Ա����
            using(var method = appDomain.BeginInvoke(method1))
            {
                method.PushObject(obj);
                method.Invoke();
            }

            using (var method = appDomain.BeginInvoke(method2))
            {
                method.PushObject(obj);
                method.PushInteger(77);
                method.Invoke();
                i = method.ReadInteger();
                print(i);
            }
        });
        #endregion

        #region ֪ʶ�� ��Ա��������
        //��Ա�������ú;�̬�������ü���һ��
        //���������Ҫ�ȴ������󣬽�������֮ǰΪnull�ĵط�
        //1.ֱ��ͨ��appdomain.Invoke("�����ռ�.����", "������", �����, �����б�)
        //2.ͨ�����Ʒ����IMethod���÷���
        //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���
        //  2-1.ͨ��appdomain.Invoke��IMethod����, �����, �����б�
        //  2-2.ͨ������Լ���ܵ�GC Alloc��ʽ���������ֱ�ӻ��գ����ã������Ͻڿεĳ�Ա����
        #endregion

        #region �ܽ�
        //���師���ã��;�̬��������������ǣ���Ҫָ�����÷����Ķ���
        //1.appdomain.Invoke("�����ռ�.����", "��̬������", ����, �����б�)
        //2.appdomain.Invoke��IMethod����, ����, �����б�
        //3.��GC Alloc��ʽ using BeginInvoke push Invoke read -> ubpir��ʽ
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
