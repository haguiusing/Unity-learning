![[EditorGUI是什么#^a82694]]
![[Lesson05_EditorGUI_文本层级标签颜色.cs]]


### EditorGUILayout中的文本控件
```cs
private void OnGUI()
{
    // 文本控件
    EditorGUILayout.LabelField("文本标题", "测试内容");
    EditorGUILayout.LabelField("文本内容");
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.EditorGUI-%E6%96%87%E6%9C%AC%E5%B1%82%E7%BA%A7%E6%A0%87%E7%AD%BE%E9%A2%9C%E8%89%B2/1.png)

### EditorGUILayout中的层级、标签选择
Layer:
```cs
int变量 = EditorGUILayout.LayerField("层级选择", int变量);
```

Tag:
```cs
string变量 = EditorGUILayout.TagField("标签选择", string变量);
```

示例代码：
```cs
int layer;
string tag;

private void OnGUI()
{
    // 层级标签控件
    layer = EditorGUILayout.LayerField("层级选择", layer);
    tag = EditorGUILayout.TagField("标签选择", tag);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.EditorGUI-%E6%96%87%E6%9C%AC%E5%B1%82%E7%BA%A7%E6%A0%87%E7%AD%BE%E9%A2%9C%E8%89%B2/2.png)

### EditorGUILayout中的颜色获取
```cs
color变量 = EditorGUILayout.ColorField(new GUIContent("标题"),
                                       color变量, 是否显示拾色器（右边是否有吸管吸颜色）, 是否显示透明度通道（设置透明度）, 是否支持HDR);
```

示例代码：
```cs
Color color;

private void OnGUI()
{
    // 颜色获取控件
    color = EditorGUILayout.ColorField(new GUIContent("自定义颜色获取"),
        color, true, true, true);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.EditorGUI-%E6%96%87%E6%9C%AC%E5%B1%82%E7%BA%A7%E6%A0%87%E7%AD%BE%E9%A2%9C%E8%89%B2/3.png)