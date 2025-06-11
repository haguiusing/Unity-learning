![[EditorGUI是什么#^a82694]]


### 滑动条控件
float变量 = EditorGUILayout.Slider(“滑动条”, float变量, 最小值, 最大值);  
int变量 = EditorGUILayout.IntSlider(“整数值滑动条”, int变量, 最小值, 最大值);
```cs
private void OnGUI()
{
    // 滑动条
    fSlider = EditorGUILayout.Slider("滑动条", fSlider, 0, 10);
    iSlider = EditorGUILayout.IntSlider("整形滑动条", iSlider, 0, 10);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/10.EditorGUI-%E6%BB%91%E5%8A%A8%E6%9D%A1%E5%8F%8C%E6%BB%91%E5%9D%97%E6%BB%91%E5%8A%A8%E6%9D%A1/1.png)
