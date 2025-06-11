![[MyEditorUtilityLearnWindow 1.cs]] ^34c7f2

![[Lesson39_EditorUtility_EditorUtility是什么.cs]]

### 知识点回顾
我们目前已经学习了  
1.自定义菜单栏拓展  
2.自定义窗口拓展  
3.EditorGUI、EditorGUIUtility相关  
4.Selection公共类  
5.Event公共类  
6.Inspector窗口拓展  
7.Scene窗口拓展（Handles公共类、HandleUtility公共类、Gizmos公共类）

### EditorUtility公共类是用来做什么的
它是 Unity 编辑器中的一个实用工具类，提供了一系列用于编辑器脚本和自定义编辑器的实用功能。

### 在哪里使用EditorUtility公共类中的相关内容
在编辑器相关处都可以使用EditorUtility公共类中的相关内容。它主要提供的是一些辅助功能，可以在编辑器拓展开发的任意地方使用。但一定注意，它属于编辑器功能，无法被打包出去，只能在Unity编辑器中使用。

### 准备工作
EditorUtility可以在任何编辑器功能开发时使用  
但是为了之后的知识点讲解更方便  
我们通过一个自定义窗口来进行知识讲解
```cs
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
```