using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ �ع˿ͻ�����Ҫ��������
        //1.�����׽���Socket
        //2.��Connect��������������
        //3.��Send��Receive��ط����շ�����
        //4.��Shutdown�����ͷ�����
        //5.�ر��׽���
        #endregion

        #region ֪ʶ��� ʵ�ֿͻ��˻����߼�
        //1.�����׽���Socket
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //2.��Connect��������������
        //ȷ������˵�IP�Ͷ˿�
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        try
        {
            socket.Connect(ipPoint);
        }
        catch (SocketException e)
        {
            if (e.ErrorCode == 10061)
                print("�������ܾ�����");
            else
                print("���ӷ�����ʧ��" + e.ErrorCode);
            return;
        }
        //3.��Send��Receive��ط����շ�����

        //��������
        byte[] receiveBytes = new byte[1024];
        int receiveNum = socket.Receive(receiveBytes);

        //���Ƚ�����Ϣ��ID
        //ʹ���ֽ������е�ǰ�ĸ��ֽ� �õ�ID
        int msgID = BitConverter.ToInt32(receiveBytes, 0);
        switch (msgID)
        {
            case 1001:
                PlayerMsg msg = new PlayerMsg();
                msg.Reading(receiveBytes, 4);
                print(msg.playerID);
                print(msg.playerData.name);
                print(msg.playerData.atk);
                print(msg.playerData.lev);
                break;
        }

        print("�յ�����˷�������Ϣ��" + Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));

        //��������
        socket.Send(Encoding.UTF8.GetBytes("��ã���������ʨ�Ŀͻ���"));

        //4.��Shutdown�����ͷ�����
        socket.Shutdown(SocketShutdown.Both);
        //5.�ر��׽���
        socket.Close();
        #endregion

        #region �ܽ�
        //1.�ͻ������ӵ�����ÿ�ζ�����ͬ��
        //2.�ͻ��˵� Connect��Send��Receive�ǻ��������̵߳ģ�Ҫ�ȵ�ִ����ϲŻ����ִ�к��������
        //�׳����⣺
        //����ÿͻ��˵�Socket��Ӱ�����̣߳����ҿ�����ʱ�շ���Ϣ��
        //���ǻ���֮����ۺ���ϰ�⽲��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
