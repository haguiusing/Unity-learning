using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
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

        #region ֪ʶ��һ ׼��ILRuntime������ز��
        //1.ILRuntime 2.1.0���µİ汾 ��Ҫǰ��ILRuntime��Githubҳ���ȡ���
        //  ��ַ��https://github.com/Ourpalm/ILRuntime
        //  ��ҳ��󣬵���Ҳ��Releases���ڶ�Ӧ�汾�����ص��Բ��

        //2.ILRuntime 2.1.0�������ϵİ汾 
        //  ��VS�Ϸ���
        //  ��չ-������չ-����ILRuntime��װ
        #endregion

        #region ֪ʶ��� �ϵ���Եıر�����
        //1.�ڳ�ʼ���� ע����Է���
        //  appDomain.DebugService.StartDebugService(�˿ں�)

        //2.ͨ��Эͬ���򣬵ȴ����������ӣ����������޷���һ��ʼ���߼� ���жϵ㣩
        //  �жϵ��������ӵ�APIΪ appDomain.DebugService.IsDebuggerAttached

        //ע�⣺һ��ֻ���ڿ������� �Ż�����ȥ����
        //������շ����� �Ͳ����������ǵĵ��Է��� Ҳ����ȥͨ��Э���ӳ�ִ�к�����߼�
        #endregion

        #region ֪ʶ���� ���жϵ����
        //���ȸ����̵� ����ҳǩ�� ѡ�� Attach to ILRuntime
        //���ɿ�ʼ�ϵ����

        //ע�⣺
        //1.���ӵ�ILRuntime��
        //  ������������д������ΪIP��ַ�Ͷ˿ںţ���ζ�����ǿ��Ե��Ը����豸
        //  ֻҪ��֤IP��ַ�Ͷ˿ں���ȷ����

        //2.���ILRuntime��ص�dll��pdb�ļ�û�м��سɹ������Ի�ʧ��
        #endregion

        #region �ܽ�
        //1.����ILRuntime������Ҫ��װ���
        //2.��Ҫ���жϵ���ԣ�������Ҫע����Է���
        //  ��Ҫ��ʱ���ϵ㣬��ô�������Эͬ����ȴ�����������
        //3.��������IP�Ͷ˿ڵ����ص��������ƶ��豸
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
