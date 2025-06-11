![[EditorGUIUtility是什么#^ca5a49]]

![[Lesson14_EditorGUIUtility_资源加载.cs]]

### 准备工作
随便导入一张图片用于测试  
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.EditorGUIUtility-%E8%B5%84%E6%BA%90%E5%8A%A0%E8%BD%BD/1.png)

### Editor Default Resources文件夹
Editor Default Resources 也是Unity当中的一个特殊文件夹，它的主要作用是放置提供给 EditorGUIUtility 加载的资源。想要使用 EditorGUIUtility 公共类来加载资源，我们需要将资源放置在 Editor Default Resources 文件夹中。

### 加载资源（如果资源不存在返回null）
EditorGUIUtility.Load  
注意事项：

1. 只能加载<font color="#ffff00">Assets/Editor Default Resources/</font>文件夹下的资源
2. 加载资源时，需要填写资源后缀名，否则加载失败
```cs
private Texture img;
private void OnGUI()
{
    //加载资源（如果资源不存在返回null)
    if(GUILayout.Button("加载编辑器图片资源"))
        img = EditorGUIUtility.Load("head.png") as Texture;
    if (img != null)
        GUI.DrawTexture(new Rect(0, 50, 160, 90), img);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.EditorGUIUtility-%E8%B5%84%E6%BA%90%E5%8A%A0%E8%BD%BD/2.png)

### 加载资源（如果资源不存在会直接报错）
EditorGUIUtility.LoadRequired  
注意事项：

1. 只能加载<font color="#ffff00">Assets/Editor Default Resources/</font>文件夹下的资源
2. 加载资源时，需要填写资源后缀名
```cs
private Texture img2;
private void OnGUI()
{
    //加载资源（如果资源不存在会直接报错）
    if (GUILayout.Button("加载编辑器图片资源(如果资源不存在会直接报错）"))
        img2 = EditorGUIUtility.LoadRequired("head.png") as Texture;
    if (img2 != null)
        GUI.DrawTexture(new Rect(0, 150, 160, 90), img2);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.EditorGUIUtility-%E8%B5%84%E6%BA%90%E5%8A%A0%E8%BD%BD/3.png)

注意：除了到Editor Default Resources文件夹里找其实还会到编辑器内部图标文件夹中寻找
