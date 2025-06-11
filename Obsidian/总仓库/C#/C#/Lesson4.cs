using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ �ع��Ͻڿ�֪ʶ�� ���ƶ�Ӧ����
        ILRuntimeMgr.Instance.StartILRuntime(() =>
        {
            //�������������� ���ڼ�������dll��pdb�ļ�������
            ILRuntime.Runtime.Enviorment.AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            object obj = ((ILType)type).Instantiate(new object[] { "234" });
            print(obj);

            //1.��ȡ������Ϣ
            //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���
            //  ����get_������ Ϊ��Ӧ���Ի�ȡ
            //        set_������ Ϊ��Ӧ���Եĸ�ֵ
            IMethod getStr = type.GetMethod("get_Str", 0);
            IMethod setStr = type.GetMethod("set_Str", 1);

            //2.���÷���
            //  �����ַ�ʽ
            //  2-1:ͨ��appdomain.Invoke�������������ö��󣬲���������
            //ȥ��ȡ����
            string str = appDomain.Invoke(getStr, obj).ToString();
            print(str);
            //ȥ��������
            appDomain.Invoke(setStr, obj, "666");
            str = appDomain.Invoke(getStr, obj).ToString();
            print(str);

            //  2-2:ͨ������Լ���ܵ���GC Alloc���������ֱ�ӻ��գ���ʽ����
            //    using (var method = appDomain.BeginInvoke(methodName))
            //    {
            //          method.PushObject(obj);//����ִ�и÷����Ķ���
            //          method.Push.....(1000);//����ָ�����Ͳ���
            //          method.Invoke();//ִ�з���
            //          method.Read....()//��ȡָ�����ͷ���ֵ
            //    }
            using(var method = appDomain.BeginInvoke(getStr))
            {
                method.PushObject(obj);//����ִ�и÷����Ķ���
                method.Invoke();//ִ�з���
                str = method.ReadValueType<string>();
                print(str);
            }
            using(var method = appDomain.BeginInvoke(setStr))
            {
                method.PushObject(obj);//����ִ�и÷����Ķ���
                string tempStr = "9999";
                method.PushValueType<string>(ref tempStr);
                method.Invoke();
            }

            using (var method = appDomain.BeginInvoke(getStr))
            {
                method.PushObject(obj);//����ִ�и÷����Ķ���
                method.Invoke();//ִ�з���
                str = method.ReadValueType<string>();
                print(str);
            }
        });
        #endregion

        #region ֪ʶ��� Unity�޷�����ֱ�ӻ�ȡ���޸�ILRuntime�г�Ա����
        //ILRuntime�в�û���ṩ��Unityֱ�ӻ�ȡ���޸ĳ�Ա�����ķ���
        //����ֻ��ͨ����ILRuntime�з�װ���Ե���ʽ���ﵽĿ��
        #endregion

        #region ֪ʶ���� ����ILRuntime�еĳ�Ա���Է���
        //1.��ȡ������Ϣ
        //  ͨ��IType�е�GetMethod���������Ʒ���һ���Ļ�ȡ��Ӧ���еķ���
        //  ����get_������ Ϊ��Ӧ���Ի�ȡ
        //        set_������ Ϊ��Ӧ���Եĸ�ֵ

        //2.���÷���
        //  �����ַ�ʽ
        //  2-1:ͨ��appdomain.Invoke�������������ö��󣬲���������

        //  2-2:ͨ������Լ���ܵ���GC Alloc���������ֱ�ӻ��գ���ʽ����
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.PushObject(obj);//����ִ�и÷����Ķ���
        //          method.Push.....(1000);//����ָ�����Ͳ���
        //          method.Invoke();//ִ�з���
        //          method.Read....()//��ȡָ�����ͷ���ֵ
        //    }

        //ע�⣺
        //ÿ���޸��ȸ����̺���룬һ��Ҫ��������
        #endregion

        #region �ܽ�
        //1.ILRuntime����ֱ�ӻ�ȡ���޸��ȸ������ж���ĳ�Ա��������Ҫ�ó�Ա���Է�װһ��
        //2.ILRuntime�л�ȡ���Ե�get��set��������Ϊ��get_��������set_������
        //3.�������Է��������ַ�ʽ
        //  1:ͨ��appdomain.Invoke�������������ö��󣬲���������
        //  2:ͨ������Լ���ܵ���GC Alloc���������ֱ�ӻ��գ���ʽ����
        //    using (var method = appDomain.BeginInvoke(methodName))
        //    {
        //          method.PushObject(obj);//����ִ�и÷����Ķ���
        //          method.Push.....(1000);//����ָ�����Ͳ���
        //          method.Invoke();//ִ�з���
        //          method.Read....()//��ȡָ�����ͷ���ֵ
        //    }
        //  ������Ȼ��ʽ��д�������ӣ����Ǹ��ӽ�Լ���ܣ��Ƽ�ʹ�ã����Գ��Խ��з�װ
        #endregion
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
