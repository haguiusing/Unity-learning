using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ��������ָʲô��
        //�����ϴ������أ����ǿ��ܻ��FTP�������ϵ����ݽ�����������
        //���磺
        //1.ɾ���ļ�
        //2.��ȡ�ļ���С
        //3.�����ļ���
        //4.��ȡ�ļ��б�
        //�ȵ�
        #endregion

        #region ֪ʶ��� ������������
        //1.ɾ���ļ�
        //FtpMgr.Instance.DeleteFile("���Բ���.txt", (result) =>
        //{
        //    print(result ? "ɾ���ɹ�" : "ɾ��ʧ��");
        //});
        //2.��ȡ�ļ���С
        FtpMgr.Instance.GetFileSize("ʵս��ҵ·��.jpg", (size) =>
        {
            print("�ļ���СΪ��" + size);
        });
        //3.�����ļ���
        FtpMgr.Instance.CreateDirectory("����ʨ", (result) =>
        {
            print(result ? "�����ɹ�" : "����ʧ��");
        });
        //4.��ȡ�ļ��б�
        FtpMgr.Instance.GetFileList("123/", (list) =>
        {
            if(list == null)
            {
                print("��ȡ�ļ��б�ʧ��");
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                print(list[i]);
            }
        });
        #endregion

        #region �ܽ�
        //FTP�������ǵ�����
        //1.��Ϸ���е�һЩ�ϴ������ع���
        //2.ԭ��AB���ϴ�����
        //3.�ϴ�����һЩ��������

        //ֻҪ���ϴ�������صĹ��� ������ʹ��Ftp�����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
