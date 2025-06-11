![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson30_Scene窗口拓展_Handles_移动旋转缩放.cs]]

### Handles中的移动轴
Vector3 Handles.DoPositionHandle(位置, 角度);  
Vector3 Handles.PositionHandle(位置, 角度);
```cs
private void OnSceneGUI()
{
    // 移动
    // 可以在选择其他默认不显示移动坐标轴工具栏也显示移动轴，以下两个API作用一致
    // 注意：假如传入Vector.zero或者Quaternion.identity这种写死的全局值，移动轴是不会跟着对象动的
    testSceneMono.transform.position = Handles.DoPositionHandle(testSceneMono.transform.position, testSceneMono.transform.rotation);
    // testSceneMono.transform.position = Handles.PositionHandle(testSceneMono.transform.position, testSceneMono.transform.rotation);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/30.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E7%A7%BB%E5%8A%A8%E6%97%8B%E8%BD%AC%E7%BC%A9%E6%94%BE/1.png)

### Handles中的旋转轴
Quaternion Handles.DoRotationHandle(角度, 位置);  
Quaternion Handles.RotationHandle(角度, 位置);
```cs
private void OnSceneGUI()
{
    // 旋转
    testSceneMono.transform.rotation = Handles.DoRotationHandle(testSceneMono.transform.rotation, testSceneMono.transform.position);
    // testSceneMono.transform.rotation = Handles.RotationHandle(testSceneMono.transform.rotation, testSceneMono.transform.position);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/30.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E7%A7%BB%E5%8A%A8%E6%97%8B%E8%BD%AC%E7%BC%A9%E6%94%BE/2.png)

### Handles中的缩放轴
Vector3 Handles.DoScaleHandle(缩放, 位置, 角度, HandleUtility.GetHandleSize(位置));  
Vector3 Handles.ScaleHandle(缩放, 位置, 角度, HandleUtility.GetHandleSize(位置));

HandleUtility.GetHandleSize方法的作用是  
获取给定位置的操纵器控制柄的世界空间大小  
使用当前相机计算合适的大小  
它决定了控制柄的缩放大小
```cs
private void OnSceneGUI()
{
// 缩放
// 最后一个参数的括号中传入Vector3.zero的话，缩放轴不会变化，传入testSceneMono.transform.position缩放轴长短会随对象位置变化
testSceneMono.transform.localScale = Handles.DoScaleHandle(testSceneMono.transform.localScale, testSceneMono.transform.position, testSceneMono.transform.rotation,
    HandleUtility.GetHandleSize(testSceneMono.transform.position));

// testSceneMono.transform.localScale = Handles.ScaleHandle(testSceneMono.transform.localScale, testSceneMono.transform.position, testSceneMono.transform.rotation,
//                                             HandleUtility.GetHandleSize(Vector3.zero));
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/30.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E7%A7%BB%E5%8A%A8%E6%97%8B%E8%BD%AC%E7%BC%A9%E6%94%BE/3.png)

