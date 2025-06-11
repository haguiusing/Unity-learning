using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ��ϰ ����ILRuntime
        ILRuntimeMgr.Instance.StartILRuntime(()=>{
            //���������ȸ�����ص�dll��pdb�� ��ȥִ���ȸ�����
            //��̬�������������ַ�ʽ
            //1.ֱ��ͨ��appdomain.Invoke("�����ռ�.����", "��̬������", null, �����б�)
            //  ���þ�̬����
            AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestStaticFun", null, null);

            int i = (int)appDomain.Invoke("HotFix_Project.Lesson3_Test", "TestStaticFun2", null, 99);
            print(i);

            //2.ͨ�����Ʒ����IMethod���÷���
            //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���
            //  2-1.ͨ��appdomain.Invoke��IMethod����, null, �����б�
            //��ȡ��Ӧ�� �� Itype
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            //��ȡ��Ӧ��������Ϣ
            IMethod method1 = type.GetMethod("TestStaticFun", 0);
            IMethod method2 = type.GetMethod("TestStaticFun2", 1);
            //ͨ��������Ϣ IMethod ���ö�Ӧ����
            appDomain.Invoke(method1, null, null);

            i = (int)appDomain.Invoke(method2, null, 88);
            print(i);

            //  2-2.ͨ������Լ���ܵ���GC Alloc��ʽ���������ֱ�ӻ��գ����ã������Ͻڿεĳ�Ա����
            //    using (var method = appDomain.BeginInvoke(methodName))
            //    {
            //          method.Push.....(1000);//����ָ�����Ͳ���
            //          method.Invoke();//ִ�з���
            //          method.Read....()//��ȡָ�����ͷ���ֵ
            //    }
            using(var method = appDomain.BeginInvoke(method1))
            {
                method.Invoke();
            }
            using (var method = appDomain.BeginInvoke(method2))
            {
                method.PushInteger(77);
                method.Invoke();
                i = method.ReadInteger();
                print(i);
            }
        });
        #endregion

        #region ֪ʶ�� ��̬��������
        //��̬�������������ַ�ʽ
        //1.ֱ��ͨ��appdomain.Invoke("�����ռ�.����", "��̬������", null, �����б�)
        //  ���þ�̬����

        //2.ͨ�����Ʒ����IMethod���÷���
        //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���
        //  2-1.ͨ��appdomain.Invoke��IMethod����, null, �����б�
        //  2-2.ͨ������Լ���ܵ���GC Alloc��ʽ���������ֱ�ӻ��գ����ã������Ͻڿεĳ�Ա����
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.Push.....(1000);//����ָ�����Ͳ���
        //          method.Invoke();//ִ�з���
        //          method.Read....()//��ȡָ�����ͷ���ֵ
        //    }
        #endregion

        #region �ܽ�
        //��̬�������õĹ���ͳ�Ա���Է������ù����������
        //���師����
        //1.appdomain.Invoke("�����ռ�.����", "��̬������", null, �����б�)
        //2.appdomain.Invoke��IMethod����, null, �����б�
        //3.��GC Alloc��ʽ using BeginInvoke push Invoke read -> ubpir��ʽ

        //ע�⣺
        //�����Ҷ�ʹ�����Ʒ����IMethod�����÷���
        //����ʹ�ø���Լ���ܵ���GC Alloc��ʽ������
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
