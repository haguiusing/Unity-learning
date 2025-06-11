![[EditorGUI是什么#^a82694]]
![[Lesson12_EditorGUI_动画曲线布局.cs]]

### 动画曲线控件
AnimationCurve变量 = EditorGUILayout.CurveField(“动画曲线：”, AnimationCurve变量);

```cs
AnimationCurve curve = new AnimationCurve();

private void OnGUI()
{
    // 动画曲线控件
    curve = EditorGUILayout.CurveField("曲线控件", curve);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.EditorGUI-%E5%8A%A8%E7%94%BB%E6%9B%B2%E7%BA%BF%E5%B8%83%E5%B1%80/1.png)

### 布局相关API
EditorGUILayout.BeginHorizontal(); //开始水平布局  
一大堆控件  
EditorGUILayout.EndHorizontal();//结束水平布局

EditorGUILayout.BeginVertical();//开始垂直布局  
一大堆控件  
EditorGUILayout.EndVertical();//结束垂直布局

Vector2布局 = EditorGUILayout.BeginScrollView(Vector2布局); //开启滚动视图  
一大堆控件  
EditorGUILayout.EndScrollView(); //结束滚动视图

```cs
// 开始水平布局
EditorGUILayout.BeginHorizontal();
EditorGUILayout.LabelField("123123");
EditorGUILayout.LabelField("123123");
EditorGUILayout.LabelField("123123");
// 结束水平布局
EditorGUILayout.EndHorizontal();

// 开始垂直布局
EditorGUILayout.BeginVertical();
EditorGUILayout.LabelField("456456");
EditorGUILayout.LabelField("456456");
EditorGUILayout.LabelField("456456");
// 结束垂直布局
EditorGUILayout.EndVertical();

// 开启滚动视图
vec2Pos = EditorGUILayout.BeginScrollView(vec2Pos);
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
EditorGUILayout.LabelField("789789");
// 结束滚动视图
EditorGUILayout.EndScrollView();
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.EditorGUI-%E5%8A%A8%E7%94%BB%E6%9B%B2%E7%BA%BF%E5%B8%83%E5%B1%80/2.png)

### 总结
EditorGUILayout中更多内容请查阅[官方文档](https://docs.unity.cn/cn/2022.3/ScriptReference/EditorGUILayout.html)。