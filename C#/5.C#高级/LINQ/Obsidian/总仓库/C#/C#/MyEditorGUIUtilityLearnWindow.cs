using System;
using UnityEditor;

public class MyEditorGUIUtilityLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorGUIUtilityLearnWindow")]
    private static void OpenMyEditorGUIUtilityLearnWindow()
    {
        MyEditorGUIUtilityLearnWindow win = EditorWindow.GetWindow<MyEditorGUIUtilityLearnWindow>("EditorGUIUtility学习面板");
        //win.titleContent = new GUIContent("EditorGUIUtility学习面板");
        win.Show();
    }

    private void OnGUI()
    {

    }
}
