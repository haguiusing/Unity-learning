using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lesson04_EditorGUI_EditorGUI是什么 : MonoBehaviour
{
    void Start()
    {
        #region GUILayout知识回顾 以及 EditorGUI编辑器窗口准备工作

        //1.知识回顾
        //GUILayout 是一个GUI自动布局的公共类
        //它其中的方法和GUI基本一模一样，都是用来绘制、响应各种UI控件的
        //只不过它在GUI的基础上加入了自动布局功能
        //我们无需过多的去关心UI控件的位置和大小

        //GUILayoutOption 布局选项
        //控件的固定宽高
        //GUILayout.Width(300);
        //GUILayout.Height(200);
        //允许控件的最小宽高
        //GUILayout.MinWidth(50);
        //GUILayout.MinHeight(50);
        //允许控件的最大宽高
        //GUILayout.MaxWidth(100);
        //GUILayout.MaxHeight(100);
        //允许或禁止水平拓展
        //GUILayout.ExpandWidth(true);//允许
        //GUILayout.ExpandHeight(false);//禁止
        //GUILayout.ExpandHeight(true);//允许
        //GUILayout.ExpandHeight(false);//禁止

        //2.准备工作
        //创建一个编辑器窗口 

        #endregion

        #region 知识点 EditorGUI是什么？

        //EditorGUI 类似 GUI
        //是一个主要用于绘制编辑器拓展 UI 的工具类
        //它提供了一些 GUI 中没有的API
        //主要是 编辑器功能中会用到的一些 特殊控件

        //而EditorGUILayout 类似于 GUILayout
        //是一个带有自动布局功能的 EditorGUI 绘制工具类

        //我们经常会将 EditorGUI 和 GUI 混合使用 来制作一些编辑器拓展功能
        //但是由于更多时候我们会用到自动布局功能
        //因此我们接下来着重讲解 EditorGUILayout 中的功能
        //EditorGUI和它的区别仅仅是需要自己设置位置而已

        //详细内容：https://docs.unity.cn/cn/2022.3/ScriptReference/EditorGUILayout.html

        #endregion
    }
}
