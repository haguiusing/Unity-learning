using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ��ILRuntime��������һ�������
        //�����������ȸ��¹��ܵ���Ŀʱ
        //�������д������߼������ȸ���������ɵ�
        //�������ǻ����ȸ���������һ�������
        //�൱���ǰ��߼�����Ȩ�����ȸ����̵ĸо�

        //������Lua�ȸ����֪ʶ���н�����������

        ILRuntimeMgr.Instance.StartILRuntime(()=> {
            //ִ��ILRuntime���е�һ����̬����
            //��̬������ �����ȸ������Լ�������߼���
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });

        #endregion

        #region ֪ʶ��� ILRuntime����Unity
        //������Unity������ʹ��һ��
        //���������ռ��ֱ��ʹ�ü���
        //֮���������ܹ�ֱ��ʹ��
        //����Ϊ�ȸ������Ѿ�������Unity��Ӧ��Dll�ļ�

        //ע�⣺
        //�����ȸ������� ֻ���������˲���Unity���dll
        //�����Ҫʹ�ø���
        //ֻ��Ҫ�Ѷ�ӦUnity��Dll�ļ��������ȸ������е�UnityDlls�ļ����м���
        //�����ȸ�����������һ��dll�ļ�������
        #endregion

        #region �ܽ�
        //ILRuntime�������Unity���������
        //��Ը��򵥣���Unity������һ��ʹ�ü���

        //��Ҫע�����
        //ʹ��������޷�����ʹ��Unity������
        //������Ϊ�ȸ�����û�����ö�Ӧ��Unity���ģ���DLL�ļ�
        //����ֻ��Ҫ�ҵ���ӦDLL�ļ� ���Ƶ� �ȸ������е�UnityDlls�ļ�����
        //�������ȸ����������� ����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
