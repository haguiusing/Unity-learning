![[EditorGUIUtility是什么#^ca5a49]]

![[Lesson16_EditorGUIUtility_窗口事件传递坐标转换.cs]]

### 窗口事件传递
在某窗口发送事件  
Event e = EditorGUIUtility.CommandEvent(“事件名”);  
获取到另一个窗口win后，让该窗口调用win.SendEvent(e)

在另一个窗口中可以通过以下代码接受事件  
Event.current.type == EventType.ExecuteCommand 判断 是否有事件执行  
Event.current.commandName == “事件名”判断 执行的是哪个事件

在传递事件时 会自动将接受事件的窗口打开 不管对象是否有监听处理对应的内容 同时焦点也会移到接事件的窗口
```cs
public class MyEditorGUIUtilityLearnWindow : EditorWindow
{
    private void OnGUI()
    {
        //窗口事件传递
        if(GUILayout.Button("传递事件"))
        {
            //声明事件
            Event e = EditorGUIUtility.CommandEvent("韬老狮的事件");
            MyEditorGUILearnWindow win = EditorWindow.GetWindow<MyEditorGUILearnWindow>();
            win.SendEvent(e);
        }
    }
}

public class MyEditorGUILearnWindow : EditorWindow
{
    private void OnGUI()
    {
        if(Event.current.type == EventType.ExecuteCommand)
        {
            if(Event.current.commandName == "韬老狮的事件")
            {
                Debug.Log("收到韬老狮的事件");
            }
        }
    }
}
```

`EventType` 枚举，它列出了Unity中GUI事件的不同类型。这些事件类型用于确定当前发生的事件是鼠标点击、键盘按键、滚动等，并允许开发者在脚本中对这些事件做出相应的处理。下面是对这些事件类型的简要说明：
- **MouseDown (0)**：鼠标按钮被按下。
- **MouseUp (1)**：鼠标按钮被释放。
- **MouseMove (2)**：鼠标移动（仅编辑器视图）。
- **MouseDrag (3)**：鼠标被拖动。
- **KeyDown (4)**：键盘按键被按下。
- **KeyUp (5)**：键盘按键被释放。
- **ScrollWheel (6)**：滚动轮被移动。
- **Repaint (7)**：需要重绘事件。每帧都会发送一次。
- **Layout (8)**：布局事件。
- **DragUpdated (9)**：编辑器中拖放操作更新。
- **DragPerform (10)**：编辑器中执行拖放操作。
- **DragExited (15)**：编辑器中拖放操作退出。
- **Ignore (11)**：忽略事件。
- **Used (12)**：事件已被处理。
- **ValidateCommand (13)**：验证特殊命令（例如复制和粘贴）。
- **ExecuteCommand (14)**：执行特殊命令（例如复制和粘贴）。
- **ContextClick (16)**：用户右键点击（或在Mac上是Control点击）。
- **MouseEnterWindow (20)**：鼠标进入窗口（仅编辑器视图）。
- **MouseLeaveWindow (21)**：鼠标离开窗口（仅编辑器视图）。
- **TouchDown (30)**：触摸设备（手指、笔）触摸屏幕。
- **TouchUp (31)**：触摸设备离开屏幕。
- **TouchMove (32)**：触摸设备在屏幕上移动（拖动）。
- **TouchEnter (33)**：触摸设备进入窗口（拖动）。
- **TouchLeave (34)**：触摸设备离开窗口（拖动）。
- **TouchStationary (35)**：触摸设备静止事件（长时间触摸）。

![[Pasted image 20250608203259.png]]

### 坐标转换
屏幕坐标系：原点为屏幕左上角  
GUI坐标系：原点为当前窗口左上角

GUIToScreenPoint:将点从GUI位置转换为屏幕空间  
GUIToScreenRect:将rect从GUI位置转换为屏幕空间

ScreenToGUIPoint:将点从屏幕空间转换为GUI位置  
ScreenToGUIRect:将rect从屏幕空间转换为GUI位置
```cs
// 坐标转换测试按钮
if (GUILayout.Button("坐标转换测试"))
{
    // 创建一个Vector2对象，表示GUI坐标
    Vector2 v = new Vector2(10, 10);

    // 将GUI坐标转换为屏幕坐标
    Vector2 screenPos = EditorGUIUtility.GUIToScreenPoint(v);

    // 在GUI中创建一个矩形区域
    GUI.BeginGroup(new Rect(10, 10, 100, 100));

    // 在布局内部进行坐标转换
    // 注意：如果包裹在布局相关函数中，位置需要加上布局的偏移再进行转换
    Vector2 screenPos2 = EditorGUIUtility.GUIToScreenPoint(v);

    // 结束矩形区域
    GUI.EndGroup();

    // 打印坐标信息
    Debug.Log("GUI:" + v + " Screen:" + screenPos + " 布局内坐标：" + screenPos2);
}
```

多显示器也会参与计算  
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/16.EditorGUIUtility-%E7%AA%97%E5%8F%A3%E4%BA%8B%E4%BB%B6%E4%BC%A0%E9%80%92%E5%9D%90%E6%A0%87%E8%BD%AC%E6%8D%A2/2.png)

