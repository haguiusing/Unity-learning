using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
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

        #region ֪ʶ��һ ��ϰ����̳еĲ���
        //1.��Untiy������ʵ�ֻ���
        //2.��ILRuntime�����м̳л���
        //3.ͨ���������ɿ���̳�������
        //  ILRuntime\Assets\Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCrossBinding.cs
        //  �������е�ģ�壬��д�Լ�ҪΪ�ĸ������ɿ���̳�����������
        //4.�ڳ�ʼ��ʱ��ע�����̳�����������
        //  appDomain.RegisterCrossBindingAdaptor(new ����������());

        //�������Ǿ������ȸ���������������̳���
        #endregion

        #region ֪ʶ��� ����̳��е�ע������
        //����̳л���ԭ��
        //ILRuntime�еĿ���̳�ʵ���ϲ�����ֱ�Ӽ̳�Unity�еĻ���
        //���Ǽ̳е���������
        //            ���ࣨUnity�У�
        //             |
        //          �������ࣨUnity�����е�ʵ�����ͣ�
        //             |
        //            ���ࣨILRuntime�У�

        //ע�����
        //1.����̳�ʱ����֧�ֶ�̳У���ͬʱ�̳���ͽӿ�

        //2.�����Ŀ��������һ��Ҫ���ֶ�̳�
        //  ��ô�ڿ���̳�ʱ������������������һ����̳еĻ������ڿ���̳�

        //3.����̳��У������ڻ���Ĺ��캯���е��ø�����麯��
        #endregion

        #region �ܽ�
        //����̳�ʱ��ILRuntime���̼̳�Unity�������е��ࣩ
        //1.ILRuntime��֧�ֿ���ILRuntime�̳�Unity����̳�
        //2.���һ��Ҫ����ILRuntime�̳�Unity����̳У���������������һ���ཫ��̳й�ϵ����̳кã����ȸ������м̳и���
        //3.����̳��У������ڻ���Ĺ��캯���е��ø�����麯�����ᱨ��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
