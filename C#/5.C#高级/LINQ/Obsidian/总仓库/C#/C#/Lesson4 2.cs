using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ �ֽ�����ת���ַ�������
        //�ؼ��ࣺBitConverter
        //���������ռ䣺System
        //��Ҫ���ã����ַ����������������ͺ��ֽ������໥ת��
        byte[] bytes = BitConverter.GetBytes(99);
        int i = BitConverter.ToInt32(bytes, 0);
        print(i);
        #endregion

        #region ֪ʶ��� �ֽ�����ת�ַ�������
        //�ؼ��ࣺEncoding
        //���������ռ䣺System.Text
        //��Ҫ���ã����ַ������ͺ��ֽ������໥ת�������Ҿ���ת��ʱʹ�õ��ַ��������ͣ�����ͨ��ʱ������ʹ��UTF-8����
        byte[] bytes2 = Encoding.UTF8.GetBytes("123123�ռ�����˷��䰢˹�����Ŵ�");
        string str = Encoding.UTF8.GetString(bytes2, 0, bytes2.Length);
        print(str);
        #endregion

        #region ֪ʶ���� ��ν�����������תΪһ�������
        //1.��ȡ����Ӧ���ֽ�����
        PlayerInfo info = new PlayerInfo();
        info.lev = 10;
        info.name = "����ʨ";
        info.atk = 88;
        info.sex = false;

        byte[] playerBytes = info.GetBytes();

        //2.���ֽ����鰴�����л�ʱ��˳����з����л�(����Ӧ�ֽڷ���ת��Ϊ��Ӧ���ͱ���)
        PlayerInfo info2 = new PlayerInfo();
        //�ȼ�
        int index = 0;
        info2.lev = BitConverter.ToInt32(playerBytes, index);
        index += 4;
        print(info2.lev);
        //�����ĳ���
        int length = BitConverter.ToInt32(playerBytes, index);
        index += 4;
        //�����ַ���
        info2.name = Encoding.UTF8.GetString(playerBytes, index, length);
        index += length;
        print(info2.name);
        //������
        info2.atk = BitConverter.ToInt16(playerBytes, index);
        index += 2;
        print(info2.atk);
        //�Ա�
        info2.sex = BitConverter.ToBoolean(playerBytes, index);
        index += 1;
        print(info2.sex);
        #endregion

        #region �ܽ�
        //���Ƕ�������2���Ʒ����л���Ҫ�õ���֪ʶ����
        //1.BitConverterת���ֽ�����Ϊ���ַ��������͵ı���
        //2.Encoding.UTF8ת���ֽ�����Ϊ�ַ������͵ı�����ע�⣺�ȶ����ȣ��ٶ��ַ�����

        //ת��������
        //1.��ȡ����Ӧ���ֽ�����
        //2.���ֽ����鰴�����л�ʱ��˳����з����л�(����Ӧ�ֽڷ���ת��Ϊ��Ӧ���ͱ���)
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public T Read<T>(byte[] bytes, ref int index) where T:struct
    {
        if(typeof(T) == typeof(int))
        {
            int value = BitConverter.ToInt32(bytes, index);
            index += 4;
            return GetValue<T>(value);
        }


        return default(T);
    }

    private T GetValue<T>(object value)
    {
        return (T)Convert.ChangeType(value, typeof(T));
    }
}
