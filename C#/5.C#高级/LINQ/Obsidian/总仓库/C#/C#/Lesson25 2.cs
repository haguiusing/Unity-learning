using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Lesson25 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ �����Դ������
        try
        {
            //����Head�������ͣ���ȡ��Ϣ
            //1.����HTTPͨѶ�����Ӷ���HttpWebRequest����
            HttpWebRequest req = HttpWebRequest.Create(new Uri("http://192.168.50.49:8000/Http_Server/ʵս��ҵ·��.jpg")) as HttpWebRequest;
            //2.������������ �� ������ز���
            req.Method = WebRequestMethods.Http.Head;
            req.Timeout = 2000;
            //3.�������󣬻�ȡ��Ӧ���HttpWebResponse����
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                print("�ļ������ҿ���");
                print(res.ContentLength);
                print(res.ContentType);

                res.Close();
            }
            else
                print("�ļ�������" + res.StatusCode);
        }
        catch (WebException w)
        {
            print("��ȡ����" + w.Message + w.Status);
        }
        #endregion

        #region ֪ʶ��� ������Դ
        //����Get�������ͣ�������Դ
        try
        {
            //1.����HTTPͨѶ�����Ӷ���HttpWebRequest����
            HttpWebRequest req = HttpWebRequest.Create(new Uri("http://192.168.50.49:8000/Http_Server/ʵս��ҵ·��.jpg")) as HttpWebRequest;
            //2.������������ �� ������ز���
            req.Method = WebRequestMethods.Http.Get;
            req.Timeout = 3000;
            //3.�������󣬻�ȡ��Ӧ���HttpWebResponse����
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            //4.��ȡ��Ӧ��������д�뱾��·��
            if (res.StatusCode == HttpStatusCode.OK)
            {
                print(Application.persistentDataPath);
                using (FileStream fileStream = File.Create(Application.persistentDataPath + "/httpDownLoad.jpg"))
                {
                    Stream downLoadStream = res.GetResponseStream();
                    byte[] bytes = new byte[2048];
                    //��ȡ����
                    int contentLength = downLoadStream.Read(bytes, 0, bytes.Length);
                    //һ��һ���д�뱾��
                    while (contentLength != 0)
                    {
                        fileStream.Write(bytes, 0, contentLength);
                        contentLength = downLoadStream.Read(bytes, 0, bytes.Length);
                    }
                    fileStream.Close();
                    downLoadStream.Close();
                    res.Close();
                }
                print("���سɹ�");
            }
            else
                print("����ʧ��" + res.StatusCode);
        }
        catch (WebException w)
        {
            print("���س���" + w.Status + w.Message);
        }
        #endregion

        #region ֪ʶ���� Get��������Я��������Ϣ
        //�����ڽ���HTTPͨ��ʱ�������ڵ�ַ�����һЩ����������ݸ������
        //һ���ںͶ�������Ϸ������ͨѶʱ����ҪЯ��������Ϣ
        //������
        //http://www.aspxfans.com:8080/news/child/index.asp?boardID=5&ID=24618&page=1
        //������ӿ��Էֳɼ�����
        //1.Э�鲿�֣�ȡ���ڷ�������ʹ�õ�����Э��
        //http://  ���� ��ͨ��http���ı�����Э��
        //https:// ���� ���ܵĳ��ı�����Э��

        //2.�������֣�
        //www.aspxfans.com
        //Ҳ������д�������Ĺ���IP��ַ

        //3.�˿ڲ��֣�
        //8080
        //���Բ�д�������дĬ��Ϊ80

        //4.����Ŀ¼���֣�
        //news/child/
        //�������/��ʼ�������һ��/֮ǰ�Ĳ���

        //5.�ļ������֣�
        //index.asp
        //��֮ǰ�����һ��/��Ĳ���

        //6.�������֣�
        //boardID=5&ID=24618&page=1
        //��֮��Ĳ��־��ǲ������֣��������һ&�ָ���
        //��������������
        //boardID = 5
        //ID = 24618
        //page = 1

        //�����ںͷ���˽���ͨ��ʱ��ֻҪ�������ֹ����ʽ����ͨ�ţ��Ϳ��Դ��ݲ���������
        //��Ҫ�����ڣ�
        //1.web��վ������
        //2.��Ϸ�����ӷ�����
        //��
        #endregion

        #region �ܽ�
        //1.Head��������
        //��Ҫ���ڻ�ȡ�ļ���һЩ������Ϣ ��������ȷ���ļ��Ƿ����
        
        //2.Get�������� ��Ҫ���ڴ�����Ϣ�������������ڻ�ȡ������Ϣ
        //  ���������ص���Ϣ������ͨ��Response�е�������ȡ
        //  ��Get����ʱ��������������Я��һЩ�������(�����Ӻ������ ?������=����ֵ&������=����ֵ&������=����ֵ&��������)
        //  ������http������Ӧ�ó��򣬶���ȥ����Get����ʱ�����еĲ��������߼�������˳���Ĺ�����
        //  ������ҪҪ���յ�֪ʶ�㣺
        //  1.�����������ʽ��д
        //  2.ͨ��response�����е�������ȡ���ص����ݣ����ݵ����Ͷ��ֶ������������ļ����Զ�����Ϣ�ȵȣ����ǰ��չ���������ɣ�

        //3.�ں�http������ͨ��ʱ�����Ǿ�����ʹ�ö����������ʽ������Ϣ���ر����Ժ��һЩ��Ӫƽ̨�Խ�ʱ

        //4.�ļ����ع��ܺ�Ftp�ǳ����ƣ�ֻ������ʹ�õ��ࡢЭ�顢�������Ͳ�ͬ����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
