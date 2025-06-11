![[EditorGUIUtility是什么#^ca5a49]]



### 绘制色板
在指定区域绘制一个色板矩形  
EditorGUIUtility.DrawColorSwatch(Rect 绘制色板的矩形, Color 颜色);

主要配合 EditorGUILayout.ColorField 颜色输入控件使用
```cs
private Color color;

private void OnGUI()
{
    // 绘制色板
    // 一般配合选取颜色控件使用
    color = EditorGUILayout.ColorField(new GUIContent("选取颜色"), color, true, true, true);
    // 默认颜色，方便选取颜色
    EditorGUIUtility.DrawColorSwatch(new Rect(180, 180, 30, 30), Color.blue);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.EditorGUIUtility-%E7%BB%98%E5%88%B6%E8%89%B2%E6%9D%BF%E7%BB%98%E5%88%B6%E6%9B%B2%E7%BA%BF/1.png)

### 绘制曲线
在指定区域绘制曲线  
EditorGUIUtility.DrawCurveSwatch(Rect 绘制曲线的范围,  
AnimationCurve 曲线,  
SerializedProperty 要绘制为SerializedProperty的曲线,  
Color 绘制曲线的颜色,  
Color 绘制背景的颜色);
```cs
private AnimationCurve curve = new AnimationCurve();

private void OnGUI()
{
    // 绘制曲线
    // 配合 EditorGUILayout.CurveField 曲线输入控件显示当前显示的曲线
    curve = EditorGUILayout.CurveField("曲线设置", curve);
    EditorGUIUtility.DrawCurveSwatch(new Rect(0, 300, 100, 80), curve, null, Color.red, Color.white);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.EditorGUIUtility-%E7%BB%98%E5%88%B6%E8%89%B2%E6%9D%BF%E7%BB%98%E5%88%B6%E6%9B%B2%E7%BA%BF/2.png)

### 更多API
官方文档：[EditorGUIUtility](https://docs.unity3d.com/ScriptReference/EditorGUIUtility.html)

