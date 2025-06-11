using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class UdpNetMgr : MonoBehaviour
{
    private static UdpNetMgr instance;
    public static UdpNetMgr Instance => instance;

    private EndPoint serverIpPoint;

    private Socket socket;

    //�ͻ���socket�Ƿ�ر�
    private bool isClose = true;

    //�������� ����
    //���ܺͷ�����Ϣ�Ķ��� �ڶ��߳�������Բ���
    private Queue<BaseMsg> sendQueue = new Queue<BaseMsg>();
    private Queue<BaseMsg> receiveQueue = new Queue<BaseMsg>();

    private byte[] cacheBytes = new byte[512];

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(receiveQueue.Count > 0)
        {
            BaseMsg baseMsg = receiveQueue.Dequeue();
            switch (baseMsg)
            {
                case PlayerMsg msg:
                    print(msg.playerID);
                    print(msg.playerData.name);
                    print(msg.playerData.atk);
                    print(msg.playerData.lev);
                    break;
            }
        }
    }

    /// <summary>
    /// �����ͻ���socket��صķ���
    /// </summary>
    /// <param name="ip">Զ�˷�������IP</param>
    /// <param name="port">Զ�˷�������port</param>
    public void StartClient(string ip, int port)
    {
        //�����ǰ�ǿ���״̬ �Ͳ����ٿ���
        if (!isClose)
            return;

        //�ȼ�¼��������ַ��һ�ᷢ��Ϣʱ��ʹ�� 
        serverIpPoint = new IPEndPoint(IPAddress.Parse(ip), port);

        IPEndPoint clientIpPort = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(clientIpPort);
            isClose = false;
            print("�ͻ�����������");
            ThreadPool.QueueUserWorkItem(ReceiveMsg);
            ThreadPool.QueueUserWorkItem(SendMsg);
        }
        catch (System.Exception e)
        {
            print("����Socket������" + e.Message);
        }
    }

    private void ReceiveMsg(object obj)
    {
        EndPoint tempIpPoint = new IPEndPoint(IPAddress.Any, 0);
        int nowIndex;
        int msgID;
        int msgLength;
        while (!isClose)
        {
            if(socket != null && socket.Available > 0)
            {
                try
                {
                    socket.ReceiveFrom(cacheBytes, ref tempIpPoint);
                    //Ϊ�˱��⴦�� �Ƿ����������� ɧ����Ϣ
                    if(!tempIpPoint.Equals(serverIpPoint))
                        continue;//������� ����Ϣ����� ���Ƿ����� ��ô֤����ɧ����Ϣ �Ͳ��ô���

                    //�����������������Ϣ
                    nowIndex = 0;
                    //����ID
                    msgID = BitConverter.ToInt32(cacheBytes, nowIndex);
                    nowIndex += 4;
                    //��������
                    msgLength = BitConverter.ToInt32(cacheBytes, nowIndex);
                    nowIndex += 4;
                    //������Ϣ��
                    BaseMsg msg = null;
                    switch (msgID)
                    {
                        case 1001:
                            msg = new PlayerMsg();
                            //�����л���Ϣ��
                            msg.Reading(cacheBytes, nowIndex);
                            break;
                    }
                    if (msg != null)
                        receiveQueue.Enqueue(msg);
                }
                catch (SocketException s)
                {
                    print("������Ϣ������" + s.SocketErrorCode + s.Message);
                }
                catch (Exception e)
                {
                    print("������Ϣ������(����������)" + e.Message);
                }
            }
        }
    }

    private void SendMsg(object obj)
    {
        while (!isClose)
        {
            if (socket != null && sendQueue.Count > 0)
            {
                try
                {
                    socket.SendTo(sendQueue.Dequeue().Writing(), serverIpPoint);
                }
                catch (SocketException s)
                {
                    print("������Ϣ����" + s.SocketErrorCode + s.Message);
                }
            }
        }
    }

    //������Ϣ
    public void Send(BaseMsg msg)
    {
        sendQueue.Enqueue(msg);
    }

    //�ر�socket
    public void Close()
    {
        if(socket != null)
        {
            isClose = true;
            QuitMsg msg = new QuitMsg();
            //����һ���˳���Ϣ�������� �����Ƴ���¼
            socket.SendTo(msg.Writing(), serverIpPoint);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }
        
    }

    private void OnDestroy()
    {
        Close();
    }
}
