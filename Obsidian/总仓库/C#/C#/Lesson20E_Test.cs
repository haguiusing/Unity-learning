using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20E_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FtpMgr.Instance.UpLoadFile("MrTangPic.png", Application.streamingAssetsPath + "/test.png", () =>
        {
            print("�ϴ����� ����ί�к���");
        });

        print(Application.persistentDataPath);
        FtpMgr.Instance.DownLoadFile("ʵս��ҵ·��.jpg", Application.persistentDataPath + "/ʵս��ҵ·��.jpg", () =>
        {
            print("���ؽ��� ����ί�к���");
        });

        print("���Բ���");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
