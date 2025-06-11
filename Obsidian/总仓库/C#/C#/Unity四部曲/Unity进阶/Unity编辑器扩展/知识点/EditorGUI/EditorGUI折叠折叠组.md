![[EditorGUI是什么#^a82694]]

### 折叠控件
bool变量 = EditorGUILayout.Foldout(bool变量, “标题名”);
```
bool isHide;

private void OnGUI()
{
    isHide = EditorGUILayout.Foldout(isHide, "折叠控件", false);
    // 第二个参数为true代表点击整体都能展开收起折叠，为false只能点击前面箭头展开收起折叠

    if (isHide)
    {
        EditorGUILayout.LabelField("折叠文本内容");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/8.EditorGUI-%E6%8A%98%E5%8F%A0%E6%8A%98%E5%8F%A0%E7%BB%84/1.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/8.EditorGUI-%E6%8A%98%E5%8F%A0%E6%8A%98%E5%8F%A0%E7%BB%84/2.png)

### 折叠组控件
bool变量 = EditorGUILayout.BeginFoldoutHeaderGroup(bool变量, “标题名”);  
EditorGUILayout.EndFoldoutHeaderGroup();
```cs
bool isHideGroup;

private void OnGUI()
{
    // 折叠组
    isHideGroup = EditorGUILayout.BeginFoldoutHeaderGroup(isHideGroup, "折叠组控件");
    // 和折叠的主要区别是折叠组会高亮，且折叠组需要结束组

    if (isHideGroup)
    {
        EditorGUILayout.LabelField("折叠组文本内容");
    }

    EditorGUILayout.EndFoldoutHeaderGroup();
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/8.EditorGUI-%E6%8A%98%E5%8F%A0%E6%8A%98%E5%8F%A0%E7%BB%84/3.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/8.EditorGUI-%E6%8A%98%E5%8F%A0%E6%8A%98%E5%8F%A0%E7%BB%84/4.png)

