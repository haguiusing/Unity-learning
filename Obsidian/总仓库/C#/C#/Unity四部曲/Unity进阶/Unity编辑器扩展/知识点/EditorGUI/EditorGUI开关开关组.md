![[EditorGUI是什么#^a82694]]
![[Lesson09_EditorGUI_开关开关组.cs]]

### 开关控件
bool变量 = EditorGUILayout.Toggle(“普通开关”, bool变量);  
bool变量 = EditorGUILayout.ToggleLeft(“开关在左侧”, bool变量);
```cs
bool isTog;
bool isTogLeft;

private void OnGUI()
{
    // 开关控件
    isTog = EditorGUILayout.Toggle("开关控件", isTog);
    isTogLeft = EditorGUILayout.ToggleLeft("左侧开关", isTogLeft);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.EditorGUI-%E5%BC%80%E5%85%B3%E5%BC%80%E5%85%B3%E7%BB%84/1.png)

### 开关组控件
bool变量 = EditorGUILayout.BeginToggleGroup(“开关组”, bool变量);  
其他控件绘制  
EditorGUILayout.EndToggleGroup();
```cs
bool isTogGroup;

private void OnGUI()
{
    // 开关组控件
    isTogGroup = EditorGUILayout.BeginToggleGroup("开关组控件", isTogGroup);
    
    // 开关控件
    isTog = EditorGUILayout.Toggle("开关控件", isTog);
    isTogLeft = EditorGUILayout.ToggleLeft("左侧开关", isTogLeft);
    
    EditorGUILayout.EndToggleGroup();
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.EditorGUI-%E5%BC%80%E5%85%B3%E5%BC%80%E5%85%B3%E7%BB%84/2.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.EditorGUI-%E5%BC%80%E5%85%B3%E5%BC%80%E5%85%B3%E7%BB%84/3.png)

