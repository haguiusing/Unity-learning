using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lesson28E_Test : MonoBehaviour
{
    public RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        //ֻҪ��֤һ����ʱ ���и��ж� ���ж�̬����
        if(NetWWWMgr.Instance == null)
        {
            GameObject obj = new GameObject("WWW");
            obj.AddComponent<NetWWWMgr>();
        }

        //���κεط�ʹ��NetWWWMgr��û������

        //NetWWWMgr.Instance.LoadRes<Texture>("http://192.168.50.109:8000/Http_Server/ʵս��ҵ·��.jpg", (obj) =>
        //{
        //    //ʹ�ü��ؽ�������Դ
        //    image.texture = obj;
        //});

        //NetWWWMgr.Instance.LoadRes<byte[]>("http://192.168.50.109:8000/Http_Server/ʵս��ҵ·��.jpg", (obj) =>
        //{
        //    //ʹ�ü��ؽ�������Դ
        //    //�ѵõ����ֽ�����洢������
        //    print(Application.persistentDataPath);
        //    File.WriteAllBytes(Application.persistentDataPath + "/wwwͼƬ.jpg", obj);
        //});

        //NetWWWMgr.Instance.LoadRes<string>("http://192.168.50.109:8000/Http_Server/test.txt", (str) =>
        //{
        //    print(str);
        //});

        //NetWWWMgr.Instance.UploadFile("��ϰ���ϴ�.jpg", Application.streamingAssetsPath + "/test.png", (code) =>
        //{
        //    if (code == UnityWebRequest.Result.Success)
        //    {
        //        print("�ϴ��ɹ�");
        //    }
        //    else
        //        print("�ϴ�ʧ��" + code);
        //});

        //NetWWWMgr.Instance.UnityWebRequestLoad<Texture>("http://192.168.50.109:8000/Http_Server/ʵս��ҵ·��.jpg",
        //                                                (tex) =>
        //                                                {
        //                                                    image.texture = tex;
        //                                                });

        NetWWWMgr.Instance.UnityWebRequestLoad<byte[]>("http://192.168.50.109:8000/Http_Server/ʵս��ҵ·��.jpg",
                                                        (bytes) =>
                                                        {
                                                            print("ͼƬ�ֽ���" + bytes.Length);
                                                        });

        print(Application.persistentDataPath);
        NetWWWMgr.Instance.UnityWebRequestLoad<object>("http://192.168.50.109:8000/Http_Server/ʵս��ҵ·��.jpg",
                                                        (obj) =>
                                                        {
                                                            print("���汾�سɹ�");
                                                        }, Application.persistentDataPath + "/Lesson28E.jpg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
