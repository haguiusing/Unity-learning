using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Lesson32E : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator GetMsg()
    {
        UnityWebRequest req = new UnityWebRequest("web��������ַ", UnityWebRequest.kHttpVerbPOST);
        DownLoadHandlerMsg msgHandler = new DownLoadHandlerMsg();
        req.downloadHandler = msgHandler;

        yield return req.SendWebRequest();

        if( req.result== UnityWebRequest.Result.Success)
        {
            PlayerMsg msg = msgHandler.GetMsg<PlayerMsg>();
            //ʹ����Ϣ���� �������߼�����
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
