![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson29_Scene窗口拓展_Handles_弧线圆立方体几何体.cs]]

### Handles中的弧线(圆弧)
绘制线框弧线  
Handles.DrawWireArc(圆心, 法线, 绘制朝向, 角度, 半径);  
绘制填充弧线  
Handles.DrawSolidArc(圆心, 法线, 绘制朝向, 角度, 半径);
```cs
private void OnSceneGUI()
{       
    // 弧线（圆弧）
    Handles.color = Color.white;
    // 如果向圆弧跟着对象动，第二个参数传入本地坐标，例如testSceneMono.transform.up,
    Handles.DrawWireArc(testSceneMono.transform.position, Vector3.up, testSceneMono.transform.forward, 30, 5);
    // Handles.DrawSolidArc(testSceneMono.transform.position, Vector3.up, testSceneMono.transform.forward, 30, 4);
    // 向左旋转15度 这样以人物正前方为等分
    Handles.DrawSolidArc(testSceneMono.transform.position, testSceneMono.transform.up, Quaternion.Euler(0,-15,0)* testSceneMono.transform.forward, 30, 4);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/1.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/2.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/3.png)

### Handles中的圆
绘制填充圆  
Handles.DrawSolidDisc(圆心, 法线, 半径);  
绘制线框圆  
Handles.DrawWireDisc(圆心, 法线, 半径);
```cs
private void OnSceneGUI()
{        
    // 圆
    Handles.color = Color.gray;
    Handles.DrawSolidDisc(testSceneMono.transform.position, testSceneMono.transform.up, 2);
    Handles.DrawWireDisc(testSceneMono.transform.position, testSceneMono.transform.up, 3);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/4.png)

### Handles中的立方体线框
Handles.DrawWireCube(中心点, xyz大小);
```cs
private void OnSceneGUI()
{
    // 立方体
    Handles.color = Color.red;
    Handles.DrawWireCube(testSceneMono.transform.position, Vector3.one);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/5.png)

### Handles中的几何体
Handles.DrawAAConvexPolygon(几何体各顶点);
```
private void OnSceneGUI()
{
    // 几何体
    //(0,0,0)
    //(1,0,0)
    //(1,0,1)
    //(0,0,z)
    Handles.DrawAAConvexPolygon(Vector3.zero, Vector3.right, Vector3.right + Vector3.forward, Vector3.forward);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/29.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E5%BC%A7%E7%BA%BF%E5%9C%86%E7%AB%8B%E6%96%B9%E4%BD%93%E5%87%A0%E4%BD%95%E4%BD%93/6.png)

