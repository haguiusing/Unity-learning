![[AssetDatabase是什么#^85deca]]

![[Lesson44_AssetDatabase_AssetDatabase常用API.cs]]

### AssetDatabase中的常用API
#### 创建资源
```cs
private void OnGUI()
{
    // 创建资源,我们可以通过代码动态创建一些资源
    // 路径从 Assets/...开始
    // AssetDatabase.CreateAsset(资源,路径);
    // 注意：
    // 不能在StreamingAssets中创建资源，
    // 不能创建预设体（预设体创建之后会讲），
    // 只能创建资源相关，例如材质球等
    // 路径需要写后缀
    if (GUILayout.Button("创建资源"))
    {
        Material mat = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(mat, "Assets/Resources/MyMaterial.mat");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/1.png)

#### 创建文件夹
```cs
private void OnGUI()
{
    // 创建文件夹，路径从 Assets/...开始
    // AssetDatabase.CreateFolder(父文件夹，新文件夹名)
    if (GUILayout.Button("创建文件夹"))
    {
        AssetDatabase.CreateFolder("Assets/Resources", "MyTestFolder");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/2.png)

#### 拷贝资源
```cs
private void OnGUI()
{
    // 拷贝资源，路径从 Assets/...开始
    // AssetDatabase.CopyAsset(源资源，目标路径)
    // 注意：
    // 需要写后缀名
    if (GUILayout.Button("拷贝资源"))
    {
        AssetDatabase.CopyAsset("Assets/Editor Default Resources/head.png",
            "Assets/Resources/MyTestFolder/head.png");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/3.png)

#### 移动资源
```cs
private void OnGUI()
{
    // 移动资源，路径从 Assets/...开始
    // AssetDatabase.MoveAsset(老路径, 新路径);
    if (GUILayout.Button("移动资源"))
    {
        AssetDatabase.MoveAsset("Assets/Resources/MyTestFolder/head.png",
            "Assets/Resources/head.png");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/4.png)

#### 删除资源
```cs
private void OnGUI()
{
    // 删除资源，路径从 Assets/...开始
    // AssetDatabase.DeleteAsset(资源路径)
    if (GUILayout.Button("删除资源"))
    {
        AssetDatabase.DeleteAsset("Assets/Resources/head.png");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/5.png)

#### 批量删除资源
```cs
private void OnGUI()
{
    // 批量删除资源，路径从 Assets/...开始
    // AssetDatabase.DeleteAssets(string[] 路径们, List<string> 用于存储删除失败的路径)
    if (GUILayout.Button("批量删除资源"))
    {
        List<string> failList = new List<string>();
        AssetDatabase.DeleteAssets(
            new string[] { "Assets/Resources/head.png", "Assets/Resources/head2.png" }, failList);
        for (int i = 0; i < failList.Count; i++)
        {
            Debug.Log(failList[i]);
        }
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/6.png)

#### 获取资源路径
```cs
private void OnGUI()
{
    // 获取资源路径 可以配合Selection选中资源一起使用
    // AssetDatabase.GetAssetPath(资源)
    if (GUILayout.Button("获取资源路径"))
    {
        Debug.Log(AssetDatabase.GetAssetPath(Selection.activeObject));
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/7.png)

#### 根据路径加载资源
```
private void OnGUI()
{
    // 根据路径加载资源，路径从Assets/开始
    // AssetDatabase.LoadAssetAtPath(资源路径) 
    // 编辑器下才会使用
    if (GUILayout.Button("加载资源"))
    {
        Texture txt = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Resources/head.png");
        Debug.Log(txt.name);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/8.png)

#### 刷新，当对资源进行移动、导入、删除等操作后，需要执行刷新
```cs
private void OnGUI()
{
    // 刷新，当对资源进行移动、导入、删除等操作后，需要执行刷新
    // AssetDatabase.Refresh()
    if (GUILayout.Button("测试刷新"))
    {
        // 创建文件时不使用Unity相关API的话就要调用刷新 才能在Project窗口中显示
        File.WriteAllText(Application.dataPath + "/Resources/test2.txt", "123123123");
        AssetDatabase.Refresh();
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/44.AssetDatabase-AssetDatabase%E5%B8%B8%E7%94%A8API/9.png)

#### 返回资源所属的AB包名
```cs
private void OnGUI()
{
    // 返回资源所属的AB包名，路径从Assets/开始
    // GetImplicitAssetBundleName（资源路径);
    if (GUILayout.Button(""))
    {

    }
}
```

### 更多内容
官方文档：[AssetDatabase](https://docs.unity3d.com/ScriptReference/AssetDatabase.html)

