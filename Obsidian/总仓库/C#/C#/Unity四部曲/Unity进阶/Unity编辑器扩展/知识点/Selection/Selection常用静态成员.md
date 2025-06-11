![[Selection是什么#^f32bfc]]

![[Lesson20_Selection_常用静态成员.cs]]


### 获取当前选择的Object
获取当前在面板上选择的游戏物体Object  
未选择则返回Null  
选择多个则返回第一个选择的游戏物体  
Selection.activeObject
```cs
private StringBuilder str = new StringBuilder("没有选择");

private void OnGUI()
{
    // 获取当前选择的Object
    if (GUILayout.Button("获取当前选择的Object的名字"))
    {
        if (Selection.activeObject != null)
        {
            str.Clear();
            str.Append(Selection.activeObject.name);

            if (Selection.activeObject is GameObject)
                Debug.Log("它是游戏对象");
            else if (Selection.activeObject is Texture)
                Debug.Log("它是一张纹理");
            else if (Selection.activeObject is TextAsset)
                Debug.Log("它是一个文本");
            else
                Debug.Log("它是其他类型的资源");
        }
        else
        {
            str.Clear();
            str.Append("没有选择");
        }
    }

    EditorGUILayout.LabelField("当前选择的对象", str.ToString());
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/20.Selection-%E5%B8%B8%E7%94%A8%E9%9D%99%E6%80%81%E6%88%90%E5%91%98/1.png)

### 获取当前选择的GameObject
获取当前在面板上选择的游戏物体GameObject  
未选择或者选择的不是游戏对象则返回Null  
选择多个则返回第一个选择的游戏物体  
Selection.activeGameObject
```cs
private StringBuilder str2 = new StringBuilder("没有选择");

private void OnGUI()
{
    // 获取当前选择的GameObject
    if (GUILayout.Button("获取当前选择的GameObject的名字"))
    {
        if (Selection.activeGameObject != null)
        {
            str2.Clear();
            str2.Append(Selection.activeGameObject.name);
        }
        else
        {
            str2.Clear();
            str2.Append("没有选择");
        }
    }
    EditorGUILayout.LabelField("当前选择GameObject对象", str2.ToString());
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/20.Selection-%E5%B8%B8%E7%94%A8%E9%9D%99%E6%80%81%E6%88%90%E5%91%98/2.png)

### 获取当前选择的Transform
获取当前在面板上选择的游戏物体的Transform 只能获取Hierarchy窗口的对象  
未选择则返回Null  
选择多个则返回第一个选择的游戏物体  
Selection.activeTransform
```cs
private StringBuilder str3 = new StringBuilder("没有选择");

private void OnGUI()
{
    // 获取当前选择的Transform
    if (GUILayout.Button("获取当前选择的Transform的名字"))
    {
        if (Selection.activeTransform != null)
        {
            str3.Clear();
            str3.Append(Selection.activeTransform.name);
            Selection.activeTransform.position = new Vector3(10, 10, 10);
        }
        else
        {
            str3.Clear();
            str3.Append("没有选择");
        }
    }

    EditorGUILayout.LabelField("当前选择Transform对象", str3.ToString());
}
```

### 获取当前选择的所有Object
获取当前在面板上选择的物体数组  
未选择则返回Null  
Selection.objects
```cs
private StringBuilder str4 = new StringBuilder("没有选择");

private void OnGUI()
{
    // 获取当前选择的所有Object
    if (GUILayout.Button("获取当前选择的所有Object的名字"))
    {
        if (Selection.count != 0)
        {
            str4.Clear();
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                str4.Append(Selection.objects[i].name + "||");
            }
        }
        else
        {
            str4.Clear();
            str4.Append("没有选择");
        }
    }

    EditorGUILayout.LabelField("当前选择的所有Object对象", str4.ToString());
}
```

### 获取当前选择的所有GameObject
获取当前选择的所有GameObject  
未选择则返回Null  
Selection.gameObjects  
可以遍历获取所有信息

### 获取当前选择的所有Transform
获取当前选择的所有Transform  
未选择则返回Null  
Selection.transforms  
可以遍历获取所有信息

