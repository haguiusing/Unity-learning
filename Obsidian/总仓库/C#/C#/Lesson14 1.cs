using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ʵ��UDP�ͻ���ͨ�� �շ��ַ���
        //1.�����׽���
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        
        //2.�󶨱�����ַ
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
        socket.Bind(ipPoint);

        //3.���͵�ָ��Ŀ��
        IPEndPoint remoteIpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        //ָ��Ҫ���͵��ֽ��� �� Զ�̼������ IP�Ͷ˿�
        socket.SendTo(Encoding.UTF8.GetBytes("����ʨ����"), remoteIpPoint);

        //4.������Ϣ
        byte[] bytes = new byte[512];
        //���������Ҫ��������¼ ˭������Ϣ���� ���뺯���� ���ڲ� ����������ǽ��и�ֵ
        EndPoint remoteIpPoint2 = new IPEndPoint(IPAddress.Any, 0);
        int length = socket.ReceiveFrom(bytes, ref remoteIpPoint2);
        print("IP:" + (remoteIpPoint2 as IPEndPoint).Address.ToString() +
            "port:" + (remoteIpPoint2 as IPEndPoint).Port +
            "������" +
            Encoding.UTF8.GetString(bytes, 0, length));

        //5.�ͷŹر�
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
