using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson37 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ �������ݽṹ��Ĺ���

        #endregion

        #region ֪ʶ��� �����������ݽṹ�ಽ��
        //1.���ɳ�Ա��������
        //2.����GetBytesNum��ȡ�ֽ�������
        //3.����Writing���л�����
        //4.����Reading�����л�����
        #endregion

        #region ֪ʶ���� �������ɳ�Ա���������Ĺ���

        #endregion

        #region ���Թ������ɵ������Ƿ���ȷ
        GamePlayer.PlayerMsg msg = new GamePlayer.PlayerMsg();
        msg.playerID = 999;
        msg.data = new GamePlayer.PlayerData();
        msg.data.id = 888;
        msg.data.atk = 10;
        msg.data.sex = true;
        msg.data.lev = 77;
        msg.data.arrays = new int[] { 1, 2, 3, 4 };
        msg.data.list = new List<int>() { 4,3,2,1};
        msg.data.dic = new Dictionary<int, string>() {
            { 1, "123"},
            { 2, "����ʨ"},
            { 3, "�ú�ѧϰ"},
        };
        msg.data.heroType = GamePlayer.E_HERO_TYPE.MAIN;

        //���л�
        byte[] bytes = msg.Writing();
        int index = 0;
        int msgID = BitConverter.ToInt32(bytes, index);
        index += 4;
        int msgLength = BitConverter.ToInt32(bytes, index);
        index += 4;

        GamePlayer.PlayerMsg msgR = new GamePlayer.PlayerMsg();
        msgR.Reading(bytes, index);
        print(msgR.playerID);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
