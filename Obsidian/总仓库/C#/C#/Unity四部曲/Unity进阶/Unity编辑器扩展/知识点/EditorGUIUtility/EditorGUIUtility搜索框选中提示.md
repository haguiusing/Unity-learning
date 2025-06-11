![[EditorGUIUtility是什么#^ca5a49]]

![[Lesson15_EditorGUIUtility_搜索框查询对象选中提示.cs]]

### 搜索框查询
#### 主要作用
弹出一个搜索窗口，用于选择所需资源。

#### 主要API
```cs
EditorGUIUtility.ShowObjectPicker<资源类型>(默认被选中的对象, 是否允许查找场景对象, "查找对象名称过滤", 0);
```

参数：
1. 默认被选中的对象的引用
2. 是否允许查找场景对象
3. 查找对象名称过滤（默认搜索过滤，例如，”normal”表示文件名称中包含”normal”的对象会被搜索到）
4. controlID，默认写0

#### 获取选择对象
主要API：
```cs
EditorGUIUtility.GetObjectPickerObject()
```

#### 事件相关
弹出的搜索窗口会通过发送事件的形式通知开启它的窗口对象信息的变化。通过`Event`公共类可以获取其它窗口发送给自己的事件。
```cs
Event.current 获取当前事件
commandName 获取事件命令的名字
```

事件：
- `ObjectSelectorUpdated`：对象选择发生变化时发送
- `ObjectSelectorClosed`：对象选择窗口关闭时发送
```cs
if (Event.current.commandName == "ObjectSelectorUpdated")
{
   // 当选择发生更新时通知进入
}
else if (Event.current.commandName == "ObjectSelectorClosed")
{
   // 当选择窗口关闭时通知进入
}
```

#### 代码实践
```cs
private Texture img3;

private void OnGUI()
{
    // 搜索框查询
    if (GUILayout.Button("打开搜索框查询窗口"))
    {
        EditorGUIUtility.ShowObjectPicker<Texture>(null, true, "head", 0);
    }

    if (Event.current.commandName == "ObjectSelectorUpdated")
    {
        img3 = EditorGUIUtility.GetObjectPickerObject() as Texture;
        if (img3 != null)
            Debug.Log(img3.name);
    }
    else if (Event.current.commandName == "ObjectSelectorClosed")
    {
        img3 = EditorGUIUtility.GetObjectPickerObject() as Texture;
        if (img3 != null)
            Debug.Log("窗口关闭 - " + img3.name);
    }
}
```

![[Pasted image 20250608200726.png]]

### 对象选中提示
EditorGUIUtility.PingObject(想要提示选中的对象);
```cs
private void OnGUI()
{
    // 对象选中提示提示
    if(GUILayout.Button("高亮选中对象"))
    {
        if (img3 != null)
            EditorGUIUtility.PingObject(img3);
    }
}
```

先打开搜索框选择head，点击后可高亮显示选择的head资源
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/15.EditorGUIUtility-%E6%90%9C%E7%B4%A2%E6%A1%86%E6%9F%A5%E8%AF%A2%E5%AF%B9%E8%B1%A1%E9%80%89%E4%B8%AD%E6%8F%90%E7%A4%BA/2.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/15.EditorGUIUtility-%E6%90%9C%E7%B4%A2%E6%A1%86%E6%9F%A5%E8%AF%A2%E5%AF%B9%E8%B1%A1%E9%80%89%E4%B8%AD%E6%8F%90%E7%A4%BA/3.png)

