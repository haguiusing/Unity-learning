using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class HttpMgr
{
    private static HttpMgr instance = new HttpMgr();

    public static HttpMgr Instance => instance;


    private string HTTP_PATH = "http://192.168.50.109:8000/Http_Server/";

    private string USER_NAME = "MrTang3";
    private string PASS_WORD = "123123";

    /// <summary>
    /// ����ָ���ļ�������ָ��·����
    /// </summary>
    /// <param name="fileName">Զ���ļ���</param>
    /// <param name="loacFilePath">����·��</param>
    /// <param name="action">���ؽ�����Ļص�����</param>
    public async void DownLoadFile(string fileName, string loacFilePath, UnityAction<HttpStatusCode> action)
    {
        HttpStatusCode result = HttpStatusCode.OK;
        await Task.Run(() =>
        {
            try
            {
                //�ж��ļ��Ƿ���� Head 
                //1.����HTTP���Ӷ���
                HttpWebRequest req = HttpWebRequest.Create(HTTP_PATH + fileName) as HttpWebRequest;
                //2.������������ �� ������ز���
                req.Method = WebRequestMethods.Http.Head;
                req.Timeout = 2000;
                //3.��������
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;

                //���ڲ�����
                if(res.StatusCode == HttpStatusCode.OK)
                {
                    res.Close();
                    //����
                    //1.����HTTP���Ӷ���
                    req = HttpWebRequest.Create(HTTP_PATH + fileName) as HttpWebRequest;
                    //2.������������ �� ������ز���
                    req.Method = WebRequestMethods.Http.Get;
                    req.Timeout = 2000;
                    //3.��������
                    res = req.GetResponse() as HttpWebResponse;
                    //4.�洢���ݵ�����
                    if(res.StatusCode == HttpStatusCode.OK)
                    {
                        //�洢����
                        using (FileStream fileStream = File.Create(loacFilePath))
                        {
                            Stream stream = res.GetResponseStream();
                            byte[] bytes = new byte[4096];
                            int contentLength = stream.Read(bytes, 0, bytes.Length);

                            while (contentLength != 0)
                            {
                                fileStream.Write(bytes, 0, contentLength);
                                contentLength = stream.Read(bytes, 0, bytes.Length);
                            }

                            fileStream.Close();
                            stream.Close();
                        }
                        result = HttpStatusCode.OK;
                    }
                    else
                    {
                        result = res.StatusCode;
                    }
                }
                else
                {
                    result = res.StatusCode;
                }

                res.Close();
            }
            catch (WebException w)
            {
                result = HttpStatusCode.InternalServerError;
                Debug.Log("���س���" + w.Message + w.Status);
            }
        });

        action?.Invoke(result);
    }


    /// <summary>
    /// �ϴ��ļ�
    /// </summary>
    /// <param name="fileName">����Զ�˷������ϵ��ļ���</param>
    /// <param name="loacalFilePath">���ص��ļ�·��</param>
    /// <param name="action">�ϴ�������Ļص�����</param>
    public async void UpLoadFile(string fileName, string loacalFilePath, UnityAction<HttpStatusCode> action)
    {
        HttpStatusCode result = HttpStatusCode.BadRequest;
        await Task.Run(() =>
        {
            try
            {
                HttpWebRequest req = HttpWebRequest.Create(HTTP_PATH) as HttpWebRequest;
                req.Method = WebRequestMethods.Http.Post;
                req.ContentType = "multipart/form-data;boundary=MrTang";
                req.Timeout = 500000;
                req.Credentials = new NetworkCredential(USER_NAME, PASS_WORD);
                req.PreAuthenticate = true;

                //ƴ���ַ��� ͷ��
                string head = "--MrTang\r\n" +
                "Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\n" +
                "Content-Type:application/octet-stream\r\n\r\n";
                //�滻�ļ���
                head = string.Format(head, fileName);
                byte[] headBytes = Encoding.UTF8.GetBytes(head);

                //β���ı߽��ַ���
                byte[] endBytes = Encoding.UTF8.GetBytes("\r\n--MrTang--\r\n");

                using (FileStream localStream = File.OpenRead(loacalFilePath))
                {
                    //���ó���
                    req.ContentLength = headBytes.Length + localStream.Length + endBytes.Length;
                    //д����
                    Stream upLoadStream = req.GetRequestStream();
                    //д��ͷ��
                    upLoadStream.Write(headBytes, 0, headBytes.Length);
                    //д���ϴ��ļ�
                    byte[] bytes = new byte[4096];
                    int contentLenght = localStream.Read(bytes, 0, bytes.Length);
                    while (contentLenght != 0)
                    {
                        upLoadStream.Write(bytes, 0, contentLenght);
                        contentLenght = localStream.Read(bytes, 0, bytes.Length);
                    }
                    //д��β��
                    upLoadStream.Write(endBytes, 0, endBytes.Length);

                    upLoadStream.Close();
                    loacalFilePath.Clone();
                }

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                //���ⲿȥ������ 
                result = res.StatusCode;
                res.Close();
            }
            catch (WebException w)
            {
                Debug.Log("�ϴ�����" + w.Status + w.Message);
            }
        });
        action?.Invoke(result);
    }
}
