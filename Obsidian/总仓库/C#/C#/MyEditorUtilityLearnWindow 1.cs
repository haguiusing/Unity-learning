using System;
using UnityEditor;

public class MyEditorUtilityLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEditorUtilityLearnWindow")]
    private static void OpenMyEditorUtilityLearnWindow()
    {
        MyEditorUtilityLearnWindow win = EditorWindow.GetWindow<MyEditorUtilityLearnWindow>("EditorUtility֪ʶѧϰ");
        win.Show();
    }

    private void OnGUI()
    {

    }
}
