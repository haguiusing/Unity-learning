using GamePlayerTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson40 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ����protoc.exe���������ɽű��ļ�
        //1.��cmd����
        //2.����protoc.exe�����ļ��У�Ҳ����ֱ�ӽ�exe�ļ�����cmd�����У�
        //3.����ת��ָ��
        //protoc.exe -I=����·�� --csharp_out=���·�� �����ļ���

        //ע�⣺·����Ҫ�����ĺ�������ţ���������ʧ��
        #endregion

        #region ֪ʶ��� �������ɶ����Ƿ���ʹ��
        TestMsg msg = new TestMsg();
        msg.TestBool = true;
        //��Ӧ�ĺ�List�Լ�Dictionaryʹ�÷�ʽһ���� ������ֵ����
        msg.ListInt.Add(1);
        print(msg.ListInt[0]);
        msg.TestMap.Add(1, "����ʨ");
        print(msg.TestMap[1]);

        //ö��
        msg.TestEnum = TestEnum.Boss;
        //�ڲ�ö��
        msg.TestEnum2 = TestMsg.Types.TestEnum2.Boss;

        //���������
        msg.TestMsg2 = new TestMsg2();
        msg.TestMsg2.TestInt32 = 99;
        //�����ڲ������
        msg.TestMsg3 = new TestMsg.Types.TestMsg3();
        msg.TestMsg3.TestInt32 = 55;
        //����һ�����ɵĽű����е��� ��������ռ䲻ͬ ��Ҫ�����ռ�����ʹ��
        msg.TestHeart = new GameSystemTest.HeartMsg();
        #endregion

        #region �ܽ�
        //Protobuf ͨ���������ɽű��ļ�
        //��Ҫʹ�õľ��� protoc.exe��ִ���ļ�
        //������Ҫ��ס��Ӧ������ָ��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
