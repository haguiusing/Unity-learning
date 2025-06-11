![[MyEventLearnWindow.cs]]

![[Lesson22_Event.cs]]

### 准备工作
自定义一个编辑器拓展窗口用于Event知识学习
```cs
public class MyEventLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEventLearnWindow")]
    private static void OpenMyEventLearnWindow()
    {
        MyEventLearnWindow win = EditorWindow.GetWindow<MyEventLearnWindow>("Event学习窗口");
        win.Show();
    }

    private void OnGUI()
    {

    }
}
```

### Event公共类是用来做什么的
它提供了许多属性和方法，允许你检查和处理用户输入，主要用于在Unity编辑器拓展开发中。因为Input相关内容需要在运行时才能监听输入，而Event专门提供给编辑模式下使用，可以帮助我们检测鼠标键盘输入等事件相关操作，在 OnGUI 和 OnSceneView 中都能使用。

### 重要API
```cs
private void OnGUI()
{
    // 获取当前事件
    Event eventCurrent = Event.current;

    // alt键是否按下
    if (eventCurrent.alt)
        Debug.Log("alt键按下了");

    // shift键是否按下
    if (eventCurrent.shift)
        Debug.Log("shift键按下了");

    // ctrl键是否按下
    if (eventCurrent.control)
        Debug.Log("control键按下了");

    // 是否是鼠标事件
    if (eventCurrent.isMouse)
    {
        Debug.Log("鼠标相关事件");

        // 判断鼠标左中右键
        Debug.Log(eventCurrent.button);

        // 鼠标位置
        Debug.Log("鼠标位置" + eventCurrent.mousePosition);
    }

    // 判断是否是键盘输入
    if (eventCurrent.isKey)
    {
        Debug.Log("键盘相关事件");

        // 获取键盘输入的字符
        Debug.Log(eventCurrent.character);

        // 获取键盘输入对应的KeyCode
        switch (eventCurrent.keyCode)
        {
            case KeyCode.Space:
                Debug.Log("空格键输入");
                break;
        }
    }

    // 判断输入类型
    // 一般会配合它 来判断 比如 键盘 鼠标的抬起按下相关的操作

    // 是否锁定大写 对应键盘上caps键是否开启
    if (eventCurrent.capsLock)
        Debug.Log("大小写锁定开启");
    else
        Debug.Log("大小写锁定关闭");

    // Windows键或Command键是否按下
    if (eventCurrent.command)
        Debug.Log("PC win键按下 或 Mac Command键按下");

    // 键盘事件 字符串
    // 可以用来判断是否触发了对应的键盘事件
    if (eventCurrent.commandName == "Copy")
    {
        Debug.Log("按下了ctrl + c");
    }

    if (eventCurrent.commandName == "Paste")
    {
        Debug.Log("按下了ctrl + v");
    }

    if (eventCurrent.commandName == "Cut")
    {
        Debug.Log("按下了ctrl + x");
    }

    // 鼠标间隔移动距离
    //Debug.Log(eve.delta);

    // 是否是功能键输入
    // 功能键指小键盘中的 方向键, page up, page down, backspace等等
    if (eventCurrent.functionKey)
        Debug.Log("有功能按键输入");

    // 小键盘是否开启
    if (eventCurrent.numeric)
        Debug.Log("小键盘是否开启");

    // 避免组合键冲突
    // 在处理完对应输入事件后，调用该方法，可以阻止事件继续派发，放置和Unity其他编辑器事件逻辑冲突
    eventCurrent.Use();
}
```

### 更多内容
官方文档 [Event](https://docs.unity3d.com/ScriptReference/Event.html)

