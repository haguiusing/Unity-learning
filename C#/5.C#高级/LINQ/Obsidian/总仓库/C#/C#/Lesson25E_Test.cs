using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lesson25E_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print(Application.persistentDataPath);
        //HttpMgr.Instance.DownLoadFile("ʵս��ҵ·��.jpg", Application.persistentDataPath + "/ʵս��ҵ·��http.jpg", (code) =>
        //{
        //    if (code == HttpStatusCode.OK)
        //        print("���سɹ�");
        //    else
        //        print("����ʧ��" + code);
        //});

        HttpMgr.Instance.UpLoadFile("��װ���ϴ�.png", Application.streamingAssetsPath + "/test.png", (code) =>
        {
            if (code == HttpStatusCode.OK)
                print("�ϴ�ָ��ɹ�");
            else
                print("�ϴ�ָ��ʧ��" + code);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
