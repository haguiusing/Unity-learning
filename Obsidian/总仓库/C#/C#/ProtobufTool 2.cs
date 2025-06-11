using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ProtobufTool
{
    //Э�������ļ�����·��
    private static string PROTO_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\proto";
    //Э�����ɿ�ִ���ļ���·��
    private static string PROTOC_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\protoc.exe";
    //C#�ļ����ɵ�·��
    private static string CSHARP_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\csharp";
    //C++�ļ����ɵ�·��
    private static string CPP_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\cpp";
    //Java�ļ����ɵ�·��
    private static string JAVA_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\java";


    [MenuItem("ProtobufTool/����C#����")]
    private static void GenerateCSharp()
    {
        Generate("csharp_out", CSHARP_PATH);
    }

    [MenuItem("ProtobufTool/����C++����")]
    private static void GenerateCPP()
    {
        Generate("cpp_out", CPP_PATH);
    }

    [MenuItem("ProtobufTool/����Java����")]
    private static void GenerateJava()
    {
        Generate("java_out", JAVA_PATH);
    }

    /// <summary>
    /// ���ɶ�Ӧ�ű��ķ���
    /// </summary>
    /// <param name="outCmd"> protoc.exe���������,�����ɽű������� </param>
    /// <param name="outPath"> ���ɽű���·�� </param>
    private static void Generate(string outCmd, string outPath)
    {
        //��һ����������ӦЭ�������ļ��� �õ����е������ļ� 
        DirectoryInfo directoryInfo = Directory.CreateDirectory(PROTO_PATH);
        //��ȡ��Ӧ�ļ����������ļ���Ϣ
        FileInfo[] files = directoryInfo.GetFiles();
        //�������е��ļ� Ϊ������Э��ű�
        for (int i = 0; i < files.Length; i++)
        {
            //��׺���ж� ֻ���� �����ļ�������������
            if (files[i].Extension == ".proto")
            {
                //�ڶ����������ļ����� �����ɶ�Ӧ��C#�ű� ����Ҫʹ��C#���е�Process�ࣩ
                Process cmd = new Process();
                //protoc.exe��·��
                cmd.StartInfo.FileName = PROTOC_PATH;
                //����
                cmd.StartInfo.Arguments = $"-I={PROTO_PATH} --{outCmd}={outPath} {files[i]}";
                //ִ��
                cmd.Start();
                //�����ⲿ ĳһ���ļ� ���ɽ���
                UnityEngine.Debug.Log(files[i] + "���ɽ���");
            }
        }
        UnityEngine.Debug.Log("�����������ɽ���");
    }
}
