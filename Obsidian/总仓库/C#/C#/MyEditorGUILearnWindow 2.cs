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

    #region Lesson05_EditorGUI_文本层级标签颜色

    int layer;
    string tag;
    Color color;

    #endregion

    private void OnGUI()
    {
        //窗口中的控件相关绘制 逻辑处理相关的内容
        //EditorGUI相关的控件 同样还是需要在OnGUI当中进行实现 才能被显示出来

        #region Lesson05_EditorGUI_文本层级标签颜色

        //文本控件
        EditorGUILayout.LabelField("文本标题", "测试内容");
        EditorGUILayout.LabelField("文本内容");

        //层级标签控件
        // layer = EditorGUILayout.LayerField(layer);//这样可能别人看不明白是选择什么的。建议加个字符串提示
        layer = EditorGUILayout.LayerField("层级选择", layer);
        // tag = EditorGUILayout.TagField(tag);//这样可能别人看不明白是选择什么的。建议加个字符串提示
        tag = EditorGUILayout.TagField("标签选择", tag);

        //颜色获取控件
        color = EditorGUILayout.ColorField(new GUIContent("自定义颜色获取"),
            color, true, true, true);

        #endregion
    }
}
