using ILRuntime.CLR.TypeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ����֮ǰ������ڵ���
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //ִ��ILRuntime���е�һ����̬����
            //��̬������ �����ȸ������Լ�������߼���
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);

            #region ֪ʶ��һ ���ȸ�������ʹ�÷���
            //���շ���Ĺ�������ʹ�ü���
            //��C#�з���û���κ�����
            #endregion

            #region ֪ʶ��� ��Unity�����з����ȸ�����������
            //��������Lesson3��������ʱ�Ӵ��� Unity���䴴��ILRuntime�еĶ���

            //���Ǿ�ʹ����ILRuntime�еķ���������ݽ��ж���Ĵ���
            //1.��ȡILRuntime��ӦIType����
            IType iType = ILRuntimeMgr.Instance.appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            //2.ͨ��IType��ȡ����Ӧ��Type
            Type type = iType.ReflectionType;
            //3.ͨ�������ȡ�������������е���
            //3-1���캯��
            object obj = type.GetConstructor(new Type[0]).Invoke(null);
            print(obj);
            //3-2��Ա����
            var testIInfo = type.GetField("testI");
            print(testIInfo.GetValue(obj));
            //3-3��Ա����
            var strInfo = type.GetProperty("Str");
            strInfo.SetValue(obj, "897654");
            print(strInfo.GetValue(obj));
            //3-4��Ա����
            var methodInfo = type.GetMethod("TestFun", new Type[0]);
            methodInfo.Invoke(obj, null);

            //ע�⣺
            //��Unity�з���ʹ���ȸ���������ʱ
            //���ǲ��ܹ�ʹ��
            //Activator.CreateInstance(type)
            //����ʽȥ��������
            //�����ᱨ��
            //��Ҫ���������д����ȸ������еĶ���
            //����ʹ������֮ǰ��ӹ������ַ�ʽ
            #endregion

            #region �ܽ�
            //Unity�з���ʹ��ILRuntime�ȸ�����������
            //1.IType type = appdomain.LoadedTypes["TypeName"];
            //  Type t = type.ReflectedType;
            //2.����ʹ��Activator.CreateInstance �� new T() ����ʵ��
            //  ֻ��ͨ��Lesson3�еķ��䷽ʽ����
            //  appdomain.Instantiate ����
            //  type.GetConstructor �� Invoke

            //ILRuntime�ȸ�������ʹ�÷���
            //��C#��ʹ�÷���һ��
            #endregion
        });
        #endregion
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
