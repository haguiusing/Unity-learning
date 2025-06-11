using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ��ILRuntime�ȸ��������½�һ����
        //ֻ��Ҫ��ILRuntime�Ĺ������½�һ���༴��
        //��Ϊ���������������캯������
        #endregion

        #region ֪ʶ��� ��Unity�п������ILRuntime�е���
        //��Ҫ��ILRuntime�����������µ�dll��pdb�ļ�
        
        ILRuntimeMgr.Instance.StartILRuntime(() =>
        {
            //�������������� ���ڼ�������dll��pdb�ļ�������
            ILRuntime.Runtime.Enviorment.AppDomain appDomain = ILRuntimeMgr.Instance.appDomain;
            //��ʽһ��appdomain�е�Instantiate����
            //       ����һ����������ռ�.����
            //       �������������б�
            object obj = appDomain.Instantiate("HotFix_Project.Lesson3_Test");
            print(obj);
            obj = appDomain.Instantiate("HotFix_Project.Lesson3_Test", new object[] { "123" });
            print(obj);

            //��ʽ����appdomain��LoadedTypes�ֵ��ȡIType���ͺ�ǿתΪILType�����Instantiate����
            //       �÷�ʽ���Ʒ���
            IType type = appDomain.LoadedTypes["HotFix_Project.Lesson3_Test"];
            obj = ((ILType)type).Instantiate();
            print(obj);

            obj = ((ILType)type).Instantiate(new object[] { "234" });
            print(obj);

            //��ʽ����ͨ����ʽ���еõ���IType������ȥ�õ����Ĺ��캯������ʵ����
            //       �÷�ʽ���Ʒ���
            ConstructorInfo info = type.ReflectionType.GetConstructor(new Type[0]);
            obj = info.Invoke(null);
            print(obj);

            info = type.ReflectionType.GetConstructor(new Type[] { typeof(string)});
            obj = info.Invoke(new object[] { "11111"});
            print(obj);


            //���Ƽ���ʽ2����Ϊ֮���ڵ��ö��󷽷�����ʱ��ͨ����ʽ2������
        });
        #endregion

        #region �ܽ�
        //Unity��ʵ����ILRuntime���������Ҫ�����ַ�ʽ
        //1.appdomain�е�Instantiate����
        //2.appdomain��LoadedTypes�ֵ��ȡIType���ͺ�, ǿתΪILType�����Instantiate����
        //3.appdomain��LoadedTypes�ֵ��ȡIType���ͺ�, ��ȥ��ȡ���Ĺ��캯����Ϣ����ʵ��������

        //�Ƽ�ʹ�÷�ʽ2����3����Ϊ���Ƕ���Ҫ�Ȼ�ȡIType��֮����ö����г�Աʱ������
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
