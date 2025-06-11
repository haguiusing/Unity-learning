using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorGUILearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorGUILearnWindow")]
    private static void OpenMyEditorGUILearnWindow()
    {
        MyEditorGUILearnWindow win = EditorWindow.GetWindow<MyEditorGUILearnWindow>("EditorGUI知识讲解窗口");
        //win.titleContent = new GUIContent("EditorGUI知识讲解窗口");
        win.Show();
    }

    private void OnGUI()
    {
        //窗口中的控件相关绘制 逻辑处理相关的内容
    }
}
