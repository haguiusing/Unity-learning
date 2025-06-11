using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Lesson20 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ʹ��FTP�ϴ��ļ��ؼ���
        //1.ͨ��ƾ֤
        //  ����Ftp���Ӳ���ʱ��Ҫ���˺�����
        //2.�������� WebRequestMethods.Ftp
        //  ��������Ҫ���е�Ftp����
        //3.�ļ������ FileStream �� Stream
        //  �ϴ�������ʱ����ʹ�õ��ļ���
        //4.��֤FTP�������Ѿ�����
        //  �����ܹ���������
        #endregion

        #region ֪ʶ��� FTP�ϴ�
        try
        {
            //1.����һ��Ftp����
            FtpWebRequest req = FtpWebRequest.Create(new Uri("ftp://192.168.50.49/pic.png")) as FtpWebRequest;
            //2.����ͨ��ƾ֤(�����֧������ �ͱ���������һ��)
            //�����������Ϣ�ÿ� ���� ������ͬʱ��http��ط��� ��ɳ�ͻ
            req.Proxy = null;
            NetworkCredential n = new NetworkCredential("MrTang", "MrTang123");
            req.Credentials = n;
            //������Ϻ� �Ƿ�رտ������ӣ������Ҫ�رգ���������Ϊfalse
            req.KeepAlive = false;
            //3.���ò�������
            req.Method = WebRequestMethods.Ftp.UploadFile;//�����������Ϊ �ϴ��ļ�
            //4.ָ����������
            req.UseBinary = true;
            //5.�õ������ϴ���������
            Stream upLoadStream = req.GetRequestStream();

            //6.��ʼ�ϴ�
            using (FileStream file = File.OpenRead(Application.streamingAssetsPath + "/test.png"))
            {
                //���ǿ���һ��һ��İ�����ļ��е��ֽ������ȡ���� Ȼ����뵽 �ϴ�����
                byte[] bytes = new byte[1024];

                //����ֵ ���������ļ��ж��˶��ٸ��ֽ�
                int contentLength = file.Read(bytes, 0, bytes.Length);
                //��ͣ��ȥ��ȡ�ļ��е��ֽ� ���Ƕ�ȡ����� ��Ȼһֱ�� ����д�뵽�ϴ�����
                while (contentLength != 0)
                {
                    //д���ϴ�����
                    upLoadStream.Write(bytes, 0, contentLength);
                    //д���˼�����
                    contentLength = file.Read(bytes, 0, bytes.Length);
                }
                //����ѭ����֤�� д���� 
                file.Close();
                upLoadStream.Close();
                //�ϴ����
                print("�ϴ�����");
            }
        }
        catch (Exception e)
        {
            print("�ϴ����� ʧ��" + e.Message);
        }
        #endregion

        #region �ܽ�
        //C#�Ѿ���Ftp��ز�����װ�ĺܺ���
        //����ֻ��Ҫ��ϤAPI��ֱ��ʹ�����ǽ���FTP�ϴ�����
        //������Ҫ���Ĳ�����
        //�ѱ����ļ��������ֽ�����д�뵽Ҫ�ϴ���FTP����

        //FTP�ϴ����APIҲ���첽����
        //ʹ���Ϻ���ǰ��TCP�������
        //���ﲻ׸��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
