![[Lesson04_EditorGUI_EditorGUI是什么.cs]]

![[MyEditorGUILearnWindow.cs]] ^a82694

### GUILayout知识回顾 以及 EditorGUI编辑器窗口准备工作
#### 知识回顾
GUILayout 是一个GUI自动布局的公共类。它的方法和GUI基本一模一样，都是用来绘制、响应各种UI控件的，只不过它在GUI的基础上加入了自动布局功能。我们无需过多的去关心UI控件的位置和大小。
#### GUILayoutOption 布局选项
- 控件的固定宽高
```cs
	GUILayout.Width(300);
	GUILayout.Height(200);
```
    
- 允许控件的最小宽高
```cs
	GUILayout.MinWidth(50);
    GUILayout.MinHeight(50);
```
    
- 允许控件的最大宽高
```cs
    GUILayout.MaxWidth(100);
    GUILayout.MaxHeight(100);
```
    
- 允许或禁止水平拓展
```cs
    GUILayout.ExpandWidth(true); //允许
    GUILayout.ExpandHeight(false); //禁止
```

#### 准备工作
创建一个编辑器窗口
```cs
public class MyEditorGUILearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorGUILearnWindow")]
    private static void OpenMyEditorGUILearnWindow()
    {
        MyEditorGUILearnWindow win = EditorWindow.GetWindow<MyEditorGUILearnWindow>("EditorGUI知识讲解窗口");
        win.Show();
    }

    private void OnGUI()
    {
        //窗口中的控件相关绘制 逻辑处理相关的内容
    }
}
```

### EditorGUI是什么
EditorGUI 类似 GUI，是一个主要用于绘制编辑器拓展 UI 的工具类。它提供了一些 GUI 中没有的API，主要是编辑器功能中会用到的一些特殊控件。

EditorGUILayout 类似于 GUILayout，是一个带有自动布局功能的 EditorGUI 绘制工具类。

我们经常会将 EditorGUI 和 GUI 混合使用来制作一些编辑器拓展功能。但是由于更多时候我们会用到自动布局功能，因此我们接下来着重讲解 EditorGUILayout 中的功能。EditorGUI和它的区别仅仅是需要自己设置位置而已。

详细内容：[EditorGUILayout官方文档](https://docs.unity.cn/cn/2022.3/ScriptReference/EditorGUILayout.html)


### 请简述，GUI、GUILayout，EditorGUI、EditorGUILayout彼此之间的关系。
#### GUI 和 GUILayout：
- GUI 和 GUILayout 是用于绘制用户界面元素的类。它们都提供了一系列的静态方法，用于创建按钮、标签、文本框等UI元素。
- GUI 类提供了一种基于坐标的绘制方法，允许你指定元素的位置和大小。
- GUILayout 类则使用基于布局的方法，允许你创建自适应的UI元素，其位置和大小会根据屏幕大小和其他元素的变化而自动调整。

#### EditorGUI 和 EditorGUILayout：
- EditorGUI 和 EditorGUILayout 是专门用于在Unity编辑器中创建自定义编辑器界面的类。
- EditorGUI 提供了一组方法，允许你在编辑器中创建自定义的UI元素，例如字段、标签等。它提供了更高级的控制，适用于需要更灵活布局和样式的情况。
- EditorGUILayout 则提供了一组适用于编辑器界面的方法。它简化了创建编辑器窗口的过程，使得在编辑器中布局UI变得更加容易。

可以认为 EditorGUI 提供了相对 GUI 更多的控件绘制API，专门提供于编辑器拓展使用，我们一般会将他们配合使用来进行编辑器拓展开发，而后面加了Layout的两个公共类只是多了自动布局功能。
