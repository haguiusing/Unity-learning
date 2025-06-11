using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerInfo
{
    public int lev;
    public string name;
    public short atk;
    public bool sex;

    public byte[] GetBytes()
    {
        int indexNum = sizeof(int) + //lev int����  4
                      sizeof(int) + //���� name�ַ���ת�����ֽ������ ����ĳ��� 4
                      Encoding.UTF8.GetBytes(name).Length + //�ַ��������ֽ�����ĳ���
                      sizeof(short) + //atk short���� 2
                      sizeof(bool); //sex bool���� 1

        byte[] playerBytes = new byte[indexNum];
        int index = 0;//�� playerBytes�����еĵڼ���λ��ȥ�洢����

        //�ȼ�
        BitConverter.GetBytes(lev).CopyTo(playerBytes, index);
        index += sizeof(int);

        //����
        byte[] strBytes = Encoding.UTF8.GetBytes(name);
        int num = strBytes.Length;
        //�洢��������ת�����ֽ������ �ֽ�����ĳ���
        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);
        //�洢�ַ������ֽ�����
        strBytes.CopyTo(playerBytes, index);
        index += num;

        //������
        BitConverter.GetBytes(atk).CopyTo(playerBytes, index);
        index += sizeof(short);
        //�Ա�
        BitConverter.GetBytes(sex).CopyTo(playerBytes, index);
        index += sizeof(bool);

        return playerBytes;
    }


    public void Write<T>( T t) where T:struct
    {
        byte[] bytes;
        switch (t)
        {
            case bool b:
                bytes = BitConverter.GetBytes(b);
                break;
            case int i:
                bytes = BitConverter.GetBytes(i);
                break;
        }
        
    }
}

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ���ַ�������ת�ֽ�����
        //�ؼ��ࣺBitConverter
        //���������ռ䣺System
        //��Ҫ���ã����ַ����������������ͺ��ֽ������໥ת��

        byte[] bytes = BitConverter.GetBytes(1);
        #endregion

        #region ֪ʶ��� �ַ�������ת�ֽ�����
        //�ؼ��ࣺEncoding
        //���������ռ䣺System.Text
        //��Ҫ���ã����ַ������ͺ��ֽ������໥ת�������Ҿ���ת��ʱʹ�õ��ַ��������ͣ�����ͨ��ʱ������ʹ��UTF-8����
        byte[] byte2 = Encoding.UTF8.GetBytes("�Ŀ�����������ʤ�۷忨�ӽǵĸ���ʻ��");
        #endregion

        #region ֪ʶ���� ��ν�һ�������ת��Ϊ������
        //ע�⣺����ͨ�������ǲ���ֱ��ʹ�����ݳ־û�2����֪ʶ���е�
        //BinaryFormatter 2���Ƹ�ʽ����
        //��Ϊ�ͻ��˺ͷ�����ʹ�õ����Կ��ܲ�һ����BinaryFormatter��C#�����л����򣬺���������֮��ļ����Բ���
        //���ʹ��������ô�������Կ����ķ������޷�������з����л�
        //������Ҫ�Լ�������������������л�Ϊ�ֽ�����

        //������ת��һ������Ϊ�ֽ�����ǳ��ļ�
        //����������ν�һ�������Я����������Ϣ���뵽һ���ֽ���������
        //������Ҫ�����¼���
        //1.��ȷ�ֽ������������ע�⣺��ȷ���ַ����ֽڳ���ʱҪ���ǽ���ʱ��δ���
        PlayerInfo info = new PlayerInfo();
        info.lev = 10;
        info.name = "����ʨ";
        info.atk = 88;
        info.sex = false;
        //�õ��� ���Info���� ���ת���� �ֽ����� ��ô�ֽ�����������Ҫ������
        int indexNum = sizeof(int) + //lev int����  4
                       sizeof(int) + //���� name�ַ���ת�����ֽ������ ����ĳ��� 4
                       Encoding.UTF8.GetBytes(info.name).Length + //�ַ��������ֽ�����ĳ���
                       sizeof(short) + //atk short���� 2
                       sizeof(bool); //sex bool���� 1

        //2.����һ��װ����Ϣ���ֽ���������
        byte[] playerBytes = new byte[indexNum];

        //3.�������е�������ϢתΪ�ֽ����鲢������������У��������������е�CopeTo����ת���ֽ����飩
        //CopyTo�����ĵڶ����������� �������ĵڼ���λ�ÿ�ʼ�洢
        int index = 0;//�� playerBytes�����еĵڼ���λ��ȥ�洢����

        //�ȼ�
        BitConverter.GetBytes(info.lev).CopyTo(playerBytes, index);
        index += sizeof(int);

        //����
        byte[] strBytes = Encoding.UTF8.GetBytes(info.name);
        int num = strBytes.Length;
        //�洢��������ת�����ֽ������ �ֽ�����ĳ���
        BitConverter.GetBytes(num).CopyTo(playerBytes, index);
        index += sizeof(int);
        //�洢�ַ������ֽ�����
        strBytes.CopyTo(playerBytes, index);
        index += num;

        //������
        BitConverter.GetBytes(info.atk).CopyTo(playerBytes, index);
        index += sizeof(short);
        //�Ա�
        BitConverter.GetBytes(info.sex).CopyTo(playerBytes, index);
        index += sizeof(bool);
        #endregion

        #region �ܽ�
        //���Ƕ�������2�������л���Ҫ�õ���֪ʶ����
        //1.BitConverterת�����ַ��������͵ı���Ϊ�ֽ�����
        //2.Encoding.UTF8ת���ַ������͵ı���Ϊ�ֽ����飨ע�⣺Ϊ�˿��Ƿ����л���������ת��2���ƣ����л��ַ���֮ǰ�������л��ַ����ֽ�����ĳ��ȣ�

        //ת��������
        //1.��ȷ�ֽ����������
        //2.����һ��װ����Ϣ���ֽ���������
        //3.�������е�������ϢתΪ�ֽ����鲢������������У����������е�CopeTo����ת���ֽ����飩
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
