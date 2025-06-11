![[Lesson13_EditorGUIUtility_EditorGUIUtility是什么.cs]]

![[MyEditorGUIUtilityLearnWindow.cs]] ^ca5a49

### EditorGUIUtility公共类是用来做什么的
Utility是实用的意思，EditorGUIUtility 是 EditorGUI 中的一个实用工具类，提供了一些 EditorGUI 相关的其他辅助API。我们只需要学习其中的相对常用的内容。

官方文档：[EditorGUIUtility](https://docs.unity3d.com/ScriptReference/EditorGUIUtility.html)

### 准备工作
创建一个自定义编辑器窗口用于之后学习 EditorGUIUtility 相关的知识。
```cs
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
```

