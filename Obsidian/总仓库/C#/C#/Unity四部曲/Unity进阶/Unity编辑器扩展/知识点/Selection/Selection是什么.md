![[MySelectionLearnWindow.cs]] ^f32bfc

![[Lesson19_Selection_Selection是什么.cs]]

### Selection公共类是用来做什么的
主要用来获取当前在Unity编辑器中选择的对象，只能用于编辑器开发中。

### 准备工作
创建一个自定义编辑器窗口，用于之后学习Selection相关的知识。
```cs
public class MySelectionLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MySelectionLearnWindow")]
    private static void OpenMySelectionLearnWindow()
    {
        MySelectionLearnWindow win = EditorWindow.GetWindow<MySelectionLearnWindow>("Selection学习窗口");
        win.Show();
    }

    private void OnGUI()
    {
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/19.Selection-Selection%E6%98%AF%E4%BB%80%E4%B9%88/1.png)

