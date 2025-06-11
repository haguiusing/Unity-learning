![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson31_Scene窗口拓展_Handles_自由移动自由旋转.cs]]

### 知识回顾
HandleUtility.GetHandleSize  
用于获取在 Scene 窗口中的一个单位距离所对应的屏幕空间大小  
这个方法主要用于根据物体的距离来动态调整控制手柄的大小  
使其在不同距离下能够在视图中显示合适的大小  
一般我们把对象位置传递进去，他会自动得到一个句柄大小

### Handles中的自由移动
自由移动指的是一个不受约束的移动控制柄  
这个把手可以在所有方向上自由移动  
Vector3 Handles.FreeMoveHandle(位置, 句柄大小, 移动步进值(按住ctrl键时会按该单位移动), 渲染控制手柄的回调函数);  
句柄大小一般配合HandleUtility.GetHandleSize函数使用

渲染控制手柄的常用回调函数:
- Handles.RectangleHandleCap: 一个矩形形状的控制手柄，通常用于表示一个平面的控制面
- Handles.CircleHandleCap: 一个圆形的控制手柄，通常用于表示一个球体的控制面
- Handles.ArrowHandleCap: 一个箭头形状的控制手柄，通常用于表示方向
```cs
private void OnSceneGUI()
{        

    // 自由移动
    // 会始终绘制一个矩形对着摄像机，鼠标按下在矩形范围内可以自由移动对象
    testSceneMono.transform.position = Handles.FreeMoveHandle(testSceneMono.transform.position, HandleUtility.GetHandleSize(testSceneMono.transform.position), Vector3.one * 5, Handles.RectangleHandleCap);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/31.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E8%87%AA%E7%94%B1%E7%A7%BB%E5%8A%A8%E8%87%AA%E7%94%B1%E6%97%8B%E8%BD%AC/1.png)

### Handles中的自由旋转
Quaternion Handles.FreeRotateHandle(角度, 位置, 句柄大小);
```cs
private void OnSceneGUI()
{        

    // 自由旋转
    // 会始终绘制一个写死在（0,0）位置的圆形对着摄像机，鼠标按下在圆形范围内可以自由旋转对象
    testSceneMono.transform.rotation = Handles.FreeRotateHandle(testSceneMono.transform.rotation, Vector3.zero, HandleUtility.GetHandleSize(Vector3.zero));
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/31.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E8%87%AA%E7%94%B1%E7%A7%BB%E5%8A%A8%E8%87%AA%E7%94%B1%E6%97%8B%E8%BD%AC/2.png)

