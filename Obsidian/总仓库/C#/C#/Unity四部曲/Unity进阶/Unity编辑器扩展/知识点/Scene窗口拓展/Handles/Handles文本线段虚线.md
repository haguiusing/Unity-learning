![[Handles是什么及响应函数#^2f9fa2]]

![[Lesson28_Scene窗口拓展_Handles_文本线段虚线.cs]]

### Editor中的target成员
在编辑器脚本中可以利用继承Editor基类中的target成员获取到拓展的组件对象。
```cs
[CustomEditor(typeof(TestSceneMono))]
public class TestSceneMonoEditor : Editor
{
    private TestSceneMono testSceneMono;

    private void OnEnable()
    {
        testSceneMono = target as TestSceneMono;
    }

    private void OnSceneGUI()
    {
        // 选中挂载TestSceneMono的对象会打印
        Debug.Log("Scene窗口拓展相关逻辑");
    }
}
```
### Handles中的颜色控制
再调用Handles中的绘制API之前，设置colors颜色属性。比如设置成绿色。  
Handles.color = new Color(0, 1, 1, 0.3f);
```cs
private void OnSceneGUI()
{
    // 颜色
    Handles.color = new Color(0, 1, 0, 1f);
}
```
### Handles中的文本控件
使用Handles.Label绘制文本，让文本跟着挂载脚本的游戏对象动，注意文本是不受绘制颜色控制的，要自己设置GUIstyle。
```cs
private void OnSceneGUI()
{    
    // 颜色
    Handles.color = new Color(0, 1, 0, 1f);
    
    // 文本
    Handles.Label(testSceneMono.transform.position, "测试文本显示");
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/28.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E6%96%87%E6%9C%AC%E7%BA%BF%E6%AE%B5%E8%99%9A%E7%BA%BF/1.png)

### Handles中的线段控件
使用Handles.DrawLine绘制线段，会受到设置颜色影响。
```cs
private void OnSceneGUI()
{  
    // 颜色
    Handles.color = new Color(0, 1, 0, 1f);
   
    // 线段
    Handles.DrawLine(testSceneMono.transform.position, testSceneMono.transform.position + testSceneMono.transform.right * 5, 5);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/28.Scene%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-Handles-%E6%96%87%E6%9C%AC%E7%BA%BF%E6%AE%B5%E8%99%9A%E7%BA%BF/2.png)

### Handles中的虚线控件
使用Handles.DrawDottedLine绘制虚线。
```cs
private void OnSceneGUI()
{
    // 虚线
    Handles.color = new Color(0, 0, 1, 1f);
    Handles.DrawDottedLine(testSceneMono.transform.position, testSceneMono.transform.position + testSceneMono.transform.forward * 5, 5);
}
```