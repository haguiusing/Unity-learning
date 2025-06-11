![[EditorUtility是什么#^34c7f2]]

![[Lesson42_EditorUtility_其他内容.cs]]

### 压缩纹理
void EditorUtility.CompressTexture(Texture2D texture, TextureFormat format, TextureCompressionQuality quality);  
可以将纹理显式压缩为指定的格式

该知识点会配合之后的资源导入相关知识点使用

### 查找对象依赖项
object[] EditorUtility.CollectDependencies(Object[] roots);  
返回对象所依赖的所有资源列表
```cs
private void OnGUI()
{        
    objTest1 = EditorGUILayout.ObjectField("想要查找关联资源的对象", objTest1, typeof(GameObject), true) as GameObject;
    if (GUILayout.Button("检索依赖资源"))
    {
        Object[] objs = EditorUtility.CollectDependencies(new Object[] { objTest1 });
        // 用Selection类选中所有依赖的资源
        Selection.objects = objs;
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/42.EditorUtility-%E5%85%B6%E4%BB%96%E5%86%85%E5%AE%B9/1.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/42.EditorUtility-%E5%85%B6%E4%BB%96%E5%86%85%E5%AE%B9/2.png)

### 更多内容
官方文档：[EditorUtility](https://docs.unity3d.com/ScriptReference/EditorUtility.html)

