using System;
using UnityEditor;

public class MyEditorGUIUtilityLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEditorGUIUtilityLearnWindow")]
    private static void OpenMyEditorGUIUtilityLearnWindow()
    {
        MyEditorGUIUtilityLearnWindow win = EditorWindow.GetWindow<MyEditorGUIUtilityLearnWindow>("EditorGUIUtilityѧϰ���");
        //win.titleContent = new GUIContent("EditorGUIUtilityѧϰ���");
        win.Show();
    }

    private void OnGUI()
    {

    }
}
