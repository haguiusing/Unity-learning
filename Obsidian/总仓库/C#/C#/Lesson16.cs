using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson16 : MonoBehaviour
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

        #region ֪ʶ��һ ��ILRuntime�ȸ�������ʹ��Эͬ����
        //ע�� Эͬ����� ����̳�������
        //������ʾ�������л�ȡ
        #endregion

        #region ֪ʶ��� ��ILRuntime�ȸ�������ʹ���첽����
        //ע�� �첽������ ����̳�������
        //���Ի�ȡ����д�õ��첽��������������
        //https://github.com/jumpst/jumpst.github.io/blob/abc112a1ad718910f39bdd34323ae2633551a650/IAsyncStateMachineClassInheritanceAdaptor
        //���޷����ʣ����������������ظ��ļ�
        #endregion

        #region �ܽ�
        //֮������Ҫע�����̳�������
        //����Ϊ��ILRuntime�е�Эͬ������첽����
        //�����������ͨ��״̬�����ö����״̬���ﵽ���첽
        //������Ķ�����õ��˿���̳�
        //����������Ҫע�����ǵĿ���̳������������ȸ��¹�������ʹ������
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
