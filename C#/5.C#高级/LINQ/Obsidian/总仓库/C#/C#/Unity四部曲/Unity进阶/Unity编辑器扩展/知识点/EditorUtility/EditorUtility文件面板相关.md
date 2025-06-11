![[EditorUtility是什么#^34c7f2]]

![[Lesson41_EditorUtility_文件面板相关.cs]]

### 显示 文件 存储面板
通常用于在编辑器中保存新创建的文件或选择文件的保存路径  
string path = EditorUtility.SaveFilePanel(“窗口标题”, “打开的目录”, “保存的文件的名称”, “文后缀格式”)
```cs
private void OnGUI()
{
    // 显示文件存储面板
    if (GUILayout.Button("打开文件存储面板"))
    {
        string str = EditorUtility.SaveFilePanel("保存我的文件", Application.dataPath, "Test", "txt");
        // 会得到带上文件名的存储路径，可以利用路径写入
        Debug.Log(str);
        if (str != "")
            File.WriteAllText(str, "123123123123123");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/1.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/2.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/3.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/4.png)

### 显示 文件 存储面板(默认指定在Asset文件夹中)
与 SaveFilePanel 类似，但是它将保存路径限制在项目目录中，只允许用户选择项目内的文件夹作为保存路径  
string path = EditorUtility.SaveFilePanelInProject(“窗口标题”, “保存的文件的名称”, “后缀格式”, “在对话框窗口中显示的文本摘要”);
```cs
private void OnGUI()
{       
    // 显示文件存储面板（默认为工程目录中）
    if (GUILayout.Button("打开文件存储面板（仅限工程文件夹下）"))
    {
        string str2 = EditorUtility.SaveFilePanelInProject("保存项目内的文件", "Test2", "png", "自定义文件");
        // 只会从Asset开始拼接路径
        Debug.Log(str2);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/5.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/6.png)

### 显示 文件夹 存储面板
通常用于在编辑器中选择文件夹作为保存路径，用于保存文件或执行其他与文件夹相关的操作  
string path = EditorUtility.SaveFolderPanel(“窗口标题”, “文件夹”, “默认名称”);
```cs
private void OnGUI()
{        
    // 显示文件夹存储面板
    if (GUILayout.Button("显示文件夹存储面板"))
    {
        string str3 = EditorUtility.SaveFolderPanel("得到一个存储路径（文件夹）", Application.dataPath, "");
        // 显示带上文件夹的完整路径，点击取消返回空字符串
        Debug.Log(str3);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/7.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/8.png)

### 显示打开 文件 面板
通常用于在编辑器中选择文件进行打开或执行其他与文件相关的操作  
string path = EditorUtility.OpenFilePanel(“窗口标题”, “文件路径”, “后缀格式”);
```cs
private void OnGUI()
{        
    // 显示打开文件面板
    if (GUILayout.Button("显示打开文件面板"))
    {
        string str4 = EditorUtility.OpenFilePanel("得到一个文件路径", Application.dataPath, "txt");
        // 会得到带上文件名的存储路径，可以利用路径读取资源
        Debug.Log(str4);
        if (str4 != "")
        {
            string txt = File.ReadAllText(str4);
            Debug.Log(txt);
        }
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/9.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/10.png)

### 显示打开 文件夹 面板
通常用于在编辑器中选择文件夹进行打开或执行其他与文件夹相关的操作  
string path = EditorUtility.OpenFolderPanel(“窗口标题”, “文件夹”, “默认名称”);
```cs
private void OnGUI()
{        
    // 显示打开文件夹面板
    if (GUILayout.Button("显示打开文件夹面板"))
    {
        string str4 = EditorUtility.OpenFolderPanel("得到一个文件路径", Application.dataPath, "");
        // 显示带上文件夹的完整路径，点击取消返回空字符串
        if (str4 != "")
        {
            Debug.Log(str4);
        }
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/11.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.EditorUtility-%E6%96%87%E4%BB%B6%E9%9D%A2%E6%9D%BF%E7%9B%B8%E5%85%B3/12.png)

