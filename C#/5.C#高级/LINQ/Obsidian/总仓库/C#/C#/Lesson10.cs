using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MyUnityDel1();
public delegate int MyUnityDel2(int i, int j);

public class Lesson10 : MonoBehaviour
{
    public MyUnityDel1 fun;
    public MyUnityDel2 fun2;

    public Action funAction;
    public Func<int, int, int> funFunc;

    // Start is called before the first frame update
    void Start()
    {
        #region ����֮ǰ���ȸ�������ڵ���
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //ִ��ILRuntime���е�һ����̬����
            //��̬������ �����ȸ������Լ�������߼���
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region ֪ʶ��һ ��Unity���Զ���ί�к�ʹ��
        //1.ILRuntime��ί�г�Ա ����ILRuntime�����к���
        //ֱ�ӳ���ʹ�ü���
        //������ֱ���

        //2.Unity��ί�г�Ա ����ILRuntime�����к���
        //ֱ�ӹ�������ֱ���������漰��ί�г�Ա�Ŀ���
        //�൱��Unity�е�ί�г�Ա�д洢��ILRuntime�����еĺ���
        //�ʹ����˿������

        //������Ҫ�������´���
        //����ͨ��������Ϣ�е���ʾ
        //�ڽ��г�ʼ��ʱ���д�������
        //��Ҫ�������֣�
        //1.ע��ί��(��ҪĿ�ģ�����IL2CPP����ü�����)
        //2.ע��ί��ת��������ҪĿ�ģ�ILRuntime�ڲ����е�ί�ж�����Action��Fun���洢�ģ�

        //ע�⣺
        //1.ί�е�ע��������̱���������������ɣ���ILRuntime��û��
        //2.Ϊ�˱�������Զ���ί��ת����
        //  ������ʹ��ί��ʱ ����ʹ��System�����ռ��е�
        //  Action��Fun
        //  �����Ͳ���Ҫ����ע��ί��ת�����ˣ�ֻ��Ҫע�ἴ��
        #endregion

        #region ֪ʶ��� ��ILRuntime���Զ���ί�к�ʹ��
        //1.ILRuntime��ί�г�Ա ����ILRuntime�����к���

        //2.Unity��ί�г�Ա ����ILRuntime�����к���
        //һ�㲻����ֻ���������
        //ʹ�û��޷�Ԥ֪�Ŀɱ����
        //�������ǲ���Ҫ�����������
        #endregion

        #region �ܽ�
        //��ί�еĿ��������
        //�������Unity���Զ���ί�п������ILRuntime�к���
        //��Ҫ����
        //1.ע��ί��(��ҪĿ�ģ�����IL2CPP����ü�����)
        //2.ע��ί��ת��������ҪĿ�ģ�ILRuntime�ڲ����е�ί�ж�����Action��Fun���洢�ģ�
        //ע�⣺
        //1.ί�е�ע��������̱����������������
        //2.Ϊ�˱�������Զ���ί��ת����
        //  ������ʹ��ί��ʱ ����ʹ��System�����ռ��е�
        //  Action��Fun
        //  �����Ͳ���Ҫ����ע��ί��ת�����ˣ�ֻ��Ҫע�ἴ��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
