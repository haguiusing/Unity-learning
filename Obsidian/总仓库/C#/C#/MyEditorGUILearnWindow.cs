using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorGUILearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEditorGUILearnWindow")]
    private static void OpenMyEditorGUILearnWindow()
    {
        MyEditorGUILearnWindow win = EditorWindow.GetWindow<MyEditorGUILearnWindow>("EditorGUI֪ʶ���ⴰ��");
        //win.titleContent = new GUIContent("EditorGUI֪ʶ���ⴰ��");
        win.Show();
    }

    private void OnGUI()
    {
        //�����еĿؼ���ػ��� �߼�������ص�����
    }
}
