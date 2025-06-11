![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson33_Scene窗口拓展_HandleUtility.cs]]

### 获取窗口上鼠标位置
```cs
Event.current.mousePosition
```

### HandleUtility公共类的主要作用
HandleUtility是 Unity 中的一个工具类，用于处理场景中的编辑器句柄（Handles）以及其他一些与编辑器交互相关的功能。它提供了一系列静态方法，用于处理编辑器中的鼠标交互、坐标转换以及其他与Handles相关的功能。

### HandleUtility类中的常用API
#### 1. GetHandleSize(Vector3 position)
我们之前已经使用过的API，获取在场景中给定位置的句柄的合适尺寸。这个方法通常用于根据场景中对象的距离来调整句柄的大小，以便在不同的缩放级别下保持合适的显示大小。
```cs
private void OnSceneGUI()
{
    // 1.GetHandleSize(Vector3 position)  之前学习过 所以不需要举例
}
```

#### 2. WorldToGUIPoint(Vector3 worldPosition)
将世界坐标转换为 GUI 坐标。这个方法通常用于将场景中的某个点的位置转换为屏幕上的像素坐标，以便在 GUI 中绘制相关的信息。
```cs
private void OnSceneGUI()
{
    // 2.WorldToGUIPoint(Vector3 worldPosition)
    Vector2 pos = HandleUtility.WorldToGUIPoint(testSceneMono.transform.position);
    Handles.BeginGUI();
    // 测试按钮可以一直跟着对象移动
    GUI.Button(new Rect(pos.x, pos.y, 50, 20), "测试按钮");
    Handles.EndGUI();
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/33.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-HandleUtility/1.png)

#### 3. GUIPointToWorldRay(Vector2 position)
将屏幕上的像素坐标转换为射线。这个方法通常用于从屏幕坐标中获取一条射线，用于检测场景中的物体或进行射线投射。
```cs
private void OnSceneGUI()
{
    // 3.GUIPointToWorldRay(Vector2 position)
    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    RaycastHit info;
    if (Physics.Raycast(ray, out info))
        Debug.Log(info.collider.name);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/33.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-HandleUtility/2.png)
#### 4. DistanceToLine(Vector3 lineStart, Vector3 lineEnd)
计算场景中一条线段与鼠标光标的最短距离。可以用来制作悬停变色等功能。
```cs
private void OnSceneGUI()
{
    // 4.DistanceToLine(Vector3 lineStart, Vector3 lineEnd)
    float dis = HandleUtility.DistanceToLine(Vector3.zero, Vector3.right);
    // Debug.Log("和向右的单位线段的距离"+ dis);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/33.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-HandleUtility/3.png)
#### 5. PickGameObject(Vector2 position, bool isSelecting)
在编辑器中进行对象的拾取。这个方法通常用于根据鼠标光标位置获取场景中的对象，以实现对象的选择或交互操作。
```cs
private void OnSceneGUI()
{
    // 5.PickGameObject(Vector2 position, bool isSelecting)
    GameObject testObj = HandleUtility.PickGameObject(Event.current.mousePosition, true);
    if (testObj != null)
        Debug.Log("选择对象的名字：" + testObj.name);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/33.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-HandleUtility/4.png)

### 更多内容
官方文档：[HandleUtility Class (Unity Documentation)](https://docs.unity3d.com/ScriptReference/HandleUtility.html)

