using System;
using UnityEditor;

public class MyEditorUtilityLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorUtilityLearnWindow")]
    private static void OpenMyEditorUtilityLearnWindow()
    {
        MyEditorUtilityLearnWindow win = EditorWindow.GetWindow<MyEditorUtilityLearnWindow>("EditorUtility知识学习");
        win.Show();
    }

    private void OnGUI()
    {

    }
}
