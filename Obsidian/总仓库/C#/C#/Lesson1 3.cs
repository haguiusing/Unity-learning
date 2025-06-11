using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ IP��Ͷ˿���������ʲô��
        //ͨ��֮ǰ������֪ʶѧϰ
        //����֪����Ҫ��������ͨ�ţ�������������
        //����������Ҫ�ҵ���Ӧ�豸��IP�Ͷ˿ں��Ƕ�λ�������豸�ز����ٵĹؼ�Ԫ��
        //C#���ṩ�˶�Ӧ��IP�Ͷ˿���ص��� ��������Ӧ��Ϣ
        //����֮�������ͨ���Ǳز����ٵ�����
        #endregion

        #region ֪ʶ��� IPAddress��
        //�����ռ䣺System.Net;
        //������IPAddress

        //��ʼ��IP��Ϣ�ķ�ʽ

        //1.��byte������г�ʼ��
        byte[] ipAddress = new byte[] { 118, 102, 111, 11 };
        IPAddress ip1 = new IPAddress(ipAddress);

        //2.��long�����ͽ��г�ʼ��
        //4�ֽڶ�Ӧ�ĳ����� һ�㲻������ʹ��
        IPAddress ip2 = new IPAddress(0x79666F0B);

        //3.�Ƽ�ʹ�õķ�ʽ ʹ���ַ���ת��
        IPAddress ip3 = IPAddress.Parse("118.102.111.11");

        //����IP��ַ
        //127.0.0.1��������ַ

        //һЩ��̬��Ա
        //��ȡ���õ�IPv6��ַ
        //IPAddress.IPv6Any

        #endregion

        #region ֪ʶ���� IPEndPoint��
        //�����ռ䣺System.Net;
        //������IPEndPoint
        //IPEndPoint�ཫ����˵��ʾΪIP��ַ�Ͷ˿ںţ�����ΪIP��ַ�Ͷ˿ںŵ����

        //��ʼ����ʽ
        IPEndPoint ipPoint = new IPEndPoint(0x79666F0B, 8080);

        IPEndPoint ipPoint2 = new IPEndPoint(IPAddress.Parse("118.102.111.11"), 8080);
        #endregion

        #region �ܽ�
        //�����ʾIP��Ϣ
        IPAddress ip = IPAddress.Parse("IPv4��ַ");
        //�����ʾͨ��Ŀ��
        IPEndPoint point = new IPEndPoint(ip, 8080);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
