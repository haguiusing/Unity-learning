![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson32_Scene窗口拓展_Handles_显示GUI.cs]]

### Scene中显示GUI
Handles.BeginGUI();  
GUI相关代码  
Handles.EndGUI();
```cs
private void OnSceneGUI()
{        
    Handles.BeginGUI();
    
    if(GUILayout.Button("测试按钮"))
    {
        Debug.Log("Scene中的按钮响应");
    }
    
    Handles.EndGUI();
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/32.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E6%98%BE%E7%A4%BAGUI/1.png)

### 获取Scene窗口大小
获取当前Scene窗口信息  
SceneView.currentDrawingSceneView  
它继承自EditorWindow，因此通过position就能得到它的大小
```cs
private void OnSceneGUI()
{      
    Handles.BeginGUI();
    
    // 获取当前Scene窗口信息
    // SceneView.currentDrawingSceneView
    // 它继承自EditorWindow，因此通过position就能得到它的大小
    
    // 得到宽高可以精确设置需要显示的控件在Scene窗口的哪里
    float w = SceneView.currentDrawingSceneView.position.width;
    float h = SceneView.currentDrawingSceneView.position.height;
    
    GUILayout.BeginArea(new Rect(w - 100, h - 100, 100, 100));
    GUILayout.Label("测试文本控件显示");
    
    if (GUILayout.Button("测试按钮"))
    {
        Debug.Log("Scene中的按钮响应");
    }
    
    GUILayout.EndArea();

    Handles.EndGUI();
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/32.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E6%98%BE%E7%A4%BAGUI/2.png)### Handles更多内容
官方文档：[Handles](https://docs.unity3d.com/ScriptReference/Handles.html)

