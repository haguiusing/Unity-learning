using System;
using UnityEditor;
using UnityEngine;

public class MyEditorApplicationLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEditorApplicationLearnWindow")]
    private static void OpenMyEditorApplicationLearnWindow()
    {
        MyEditorApplicationLearnWindow win =
            EditorWindow.GetWindow<MyEditorApplicationLearnWindow>("EditorApplication֪ʶѧϰ");
        win.Show();
    }

    //1.�����༭���¼�
    //  EditorApplication.update��ÿ֡�����¼������������ڱ༭����ִ��һЩ�߼�
    //  EditorApplication.hierarchyChanged���㼶��ͼ�仯�¼����������еĶ������仯ʱ����
    //  EditorApplication.projectChanged����Ŀ�仯�¼�������Ŀ�е���Դ�����仯ʱ����
    //  EditorApplication.playModeStateChanged���༭������״̬�仯ʱ����
    //  EditorApplication.pauseStateChanged���༭����ͣ״̬�仯ʱ����
    private void OnEnable()
    {
        EditorApplication.update += MyUpdate;
    }

    private void OnDestroy()
    {
        EditorApplication.update -= MyUpdate;
    }

    void MyUpdate()
    {
        // Debug.Log("����");  

        //2.����༭�������������
        //  EditorApplication.isPlaying���жϵ�ǰ�Ƿ�����Ϸ����״̬��
        //  EditorApplication.isPaused���жϵ�ǰ��Ϸ�Ƿ�����ͣ״̬��
        //  EditorApplication.isCompiling���ж�Unity�༭���Ƿ����ڱ������
        //  EditorApplication.isUpdating���ж�Unity�༭���Ƿ�����ˢ��AssetDatabase
        if (EditorApplication.isPlaying)
        {
            Debug.Log("�������в���״̬");
        }
    }

    private void OnGUI()
    {
        //3.��ȡUnityӦ�ó���·�����
        //  EditorApplication.applicationContentsPath��Unity��װĿ¼Data·��
        //  EditorApplication.applicationPath��Unity��װĿ¼��ִ�г���·��
        if (GUILayout.Button("��ӡUnity��װ·��"))
        {
            Debug.Log(EditorApplication.applicationContentsPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Data
            Debug.Log(EditorApplication.applicationPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Unity.exe
        }


        //4.���÷���
        //  EditorApplication.Exit(0)���˳�Unity�༭��
        //  EditorApplication.ExitPlaymode()���˳�����ģʽ���л����༭ģʽ
        //  EditorApplication.EnterPlaymode()�����벥��ģʽ
        if (GUILayout.Button("���벥��ģʽ"))
        {
            EditorApplication.EnterPlaymode();
        }
        if (GUILayout.Button("�˳�����ģʽ"))
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
