using GamePlayerTest;
using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lesson41 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ���л��洢Ϊ�����ļ�
        //��Ҫʹ��
        //1.���ɵ����е� WriteTo����
        //2.�ļ���FileStream����
        TestMsg msg = new TestMsg();
        msg.ListInt.Add(1);
        msg.TestBool = false;
        msg.TestD = 5.5;
        msg.TestInt32 = 99;
        msg.TestMap.Add(1, "����ʨ");
        msg.TestMsg2 = new TestMsg2();
        msg.TestMsg2.TestInt32 = 88;
        msg.TestMsg3 = new TestMsg.Types.TestMsg3();
        msg.TestMsg3.TestInt32 = 66;

        msg.TestHeart = new GameSystemTest.HeartMsg();
        msg.TestHeart.Time = 7777;

        print(Application.persistentDataPath);
        using (FileStream fs = File.Create(Application.persistentDataPath + "/TestMsg.tang"))
        {
            msg.WriteTo(fs);
        }
        #endregion

        #region ֪ʶ��� �����л������ļ�
        //��Ҫʹ��
        //1.���ɵ����е� Parser.ParseFrom����
        //2.�ļ���FileStream����
        using (FileStream fs = File.OpenRead(Application.persistentDataPath + "/TestMsg.tang"))
        {
            TestMsg msg2 = null;
            msg2 = TestMsg.Parser.ParseFrom(fs);
            print(msg2.TestMap[1]);
            print(msg2.ListInt[0]);
            print(msg2.TestD);
            print(msg2.TestMsg2.TestInt32);
            print(msg2.TestMsg3.TestInt32);
            print(msg2.TestHeart.Time);
        }
        #endregion

        #region ֪ʶ���� �õ����л�����ֽ�����
        //��Ҫʹ��
        //1.���ɵ����е� WriteTo����
        //2.�ڴ���MemoryStream����
        byte[] bytes = null;
        using (MemoryStream ms = new MemoryStream())
        {
            msg.WriteTo(ms);
            bytes = ms.ToArray();
            print("�ֽ����鳤��" + bytes.Length);
        }

        #endregion

        #region ֪ʶ���� ���ֽ����鷴���л�
        //��Ҫʹ��
        //1.���ɵ����е� Parser.ParseFrom����
        //2.�ڴ���MemoryStream����
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            print("�ڴ������з����л�������");
            TestMsg msg2 = TestMsg.Parser.ParseFrom(ms);
            print(msg2.TestMap[1]);
            print(msg2.ListInt[0]);
            print(msg2.TestD);
            print(msg2.TestMsg2.TestInt32);
            print(msg2.TestMsg3.TestInt32);
            print(msg2.TestHeart.Time);
        }

        #endregion

        #region �ܽ�
        //Protobuf�� ���л��ͷ����л���Ҫͨ��
        //�����������д���
        //����ǽ��б��ش洢 �����ʹ���ļ���
        //����ǽ������紫�� �����ʹ���ڴ�����ȡ�ֽ�����

        #endregion

        #region ��ϰ�����
        print("��ϰ���ӡ���");
        //��װ�� ���л����� 
        byte[] bytes2 = NetTool.GetProtoBytes(msg);
        //��װ�� �����л�����
        TestMsg msg3 = NetTool.GetProtoMsg<TestMsg>(bytes2);
        print(msg3.TestMap[1]);
        print(msg3.ListInt[0]);
        print(msg3.TestD);
        print(msg3.TestMsg2.TestInt32);
        print(msg3.TestMsg3.TestInt32);
        print(msg3.TestHeart.Time);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
