using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Lesson13 : MonoBehaviour
{
    public Button btn;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            PlayerMsg ms = new PlayerMsg();
            ms.playerID = 1111;
            ms.playerData = new PlayerData();
            ms.playerData.name = "����ʨ�ͻ��˷��͵���Ϣ";
            ms.playerData.atk = 22;
            ms.playerData.lev = 10;
            NetAsyncMgr.Instance.Send(ms);
        });

        //������
        btn1.onClick.AddListener(() =>
        {
            PlayerMsg msg = new PlayerMsg();
            msg.playerID = 1001;
            msg.playerData = new PlayerData();
            msg.playerData.name = "����ʨ1";
            msg.playerData.atk = 1;
            msg.playerData.lev = 1;

            PlayerMsg msg2 = new PlayerMsg();
            msg2.playerID = 1002;
            msg2.playerData = new PlayerData();
            msg2.playerData.name = "����ʨ2";
            msg2.playerData.atk = 2;
            msg2.playerData.lev = 2;
            //��
            byte[] bytes = new byte[msg.GetBytesNum() + msg2.GetBytesNum()];
            msg.Writing().CopyTo(bytes, 0);
            msg2.Writing().CopyTo(bytes, msg.GetBytesNum());
            NetAsyncMgr.Instance.SendTest(bytes);
        });
        //�ְ�����
        btn2.onClick.AddListener(async () =>
        {
            PlayerMsg msg = new PlayerMsg();
            msg.playerID = 1003;
            msg.playerData = new PlayerData();
            msg.playerData.name = "����ʨ1";
            msg.playerData.atk = 3;
            msg.playerData.lev = 3;

            byte[] bytes = msg.Writing();
            //�ְ�
            byte[] bytes1 = new byte[10];
            byte[] bytes2 = new byte[bytes.Length - 10];
            //�ֳɵ�һ����
            Array.Copy(bytes, 0, bytes1, 0, 10);
            //�ڶ�����
            Array.Copy(bytes, 10, bytes2, 0, bytes.Length - 10);

            NetAsyncMgr.Instance.SendTest(bytes1);
            await Task.Delay(500);
            NetAsyncMgr.Instance.SendTest(bytes2);
        });
        //�ְ���������
        btn3.onClick.AddListener(async () =>
        {
            PlayerMsg msg = new PlayerMsg();
            msg.playerID = 1001;
            msg.playerData = new PlayerData();
            msg.playerData.name = "����ʨ1";
            msg.playerData.atk = 1;
            msg.playerData.lev = 1;

            PlayerMsg msg2 = new PlayerMsg();
            msg2.playerID = 1002;
            msg2.playerData = new PlayerData();
            msg2.playerData.name = "����ʨ2";
            msg2.playerData.atk = 2;
            msg2.playerData.lev = 2;

            byte[] bytes1 = msg.Writing();//��ϢA
            byte[] bytes2 = msg2.Writing();//��ϢB

            byte[] bytes2_1 = new byte[10];
            byte[] bytes2_2 = new byte[bytes2.Length - 10];
            //�ֳɵ�һ����
            Array.Copy(bytes2, 0, bytes2_1, 0, 10);
            //�ڶ�����
            Array.Copy(bytes2, 10, bytes2_2, 0, bytes2.Length - 10);

            //��ϢA����ϢBǰһ�ε� ��
            byte[] bytes = new byte[bytes1.Length + bytes2_1.Length];
            bytes1.CopyTo(bytes, 0);
            bytes2_1.CopyTo(bytes, bytes1.Length);

            NetAsyncMgr.Instance.SendTest(bytes);
            await Task.Delay(500);
            NetAsyncMgr.Instance.SendTest(bytes2_2);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
