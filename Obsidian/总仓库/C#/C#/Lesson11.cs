using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ����֮ǰ������ڵ���
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //ִ��ILRuntime���е�һ����̬����
            //��̬������ �����ȸ������Լ�������߼���
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region ֪ʶ��һ ʲô�ǿ���̳�
        //ILRuntime֧�����ȸ������м̳�Unity�������е���
        //����ǿ���̳�

        //ע�⣺
        //ILRuntime�еĿ���̳���Ҫָ�ȸ����̼̳�Unity�����е���
        //������Unity�̳�ILRuntime�е���һ˵
        //ֻ��Ҫ��ס��һ�㶼�ǿɱ�ģ��ȸ����̣�ʹ�ò���ģ�Unity���̣�����
        #endregion

        #region ֪ʶ��� ��ν��п���̳�
        //1.��Untiy������ʵ�ֻ���
        //2.��ILRuntime�����м̳л���
        //3.ͨ���������ɿ���̳�������
        //  ILRuntime\Assets\Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCrossBinding.cs
        //  �������е�ģ�壬��д�Լ�ҪΪ�ĸ������ɿ���̳�����������
        //4.�ڳ�ʼ��ʱ��ע�����̳�����������
        //  appDomain.RegisterCrossBindingAdaptor(new ����������());
        #endregion

        #region �ܽ� 
        //������������һЩ��Ϊ���ӵĻ���ʱ��������Ҫ���ǰ���ģ������дһЩ����
        //�����˵��Ϊ�鷳
        //���û���������������£��������¿���Ŀ
        //��������Ҫ���ֿ���̳�
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
