using System;
using UnityEditor;
using UnityEngine;

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
        //1.获取当前事件
        //  Event.current
        Event eventCurrent = Event.current;

        //2.alt键是否按下
        //  Event.current.alt
        if (eventCurrent.alt)
            Debug.Log("alt键按下了");

        //3.shift键是否按下
        //  Event.current.shift
        if (eventCurrent.shift)
            Debug.Log("shift键按下了");

        //4.ctrl键是否按下
        //  Event.current.control
        if (eventCurrent.control)
            Debug.Log("control键按下了");

        //5.是否是鼠标事件
        //  Event.current.isMouse
        if (eventCurrent.isMouse)
        {
            Debug.Log("鼠标相关事件");

            //6.判断鼠标左中右键
            //  Event.current.button (0,1,2 分别代表 左,右,中 如果大于2可能是其他鼠标按键)
            Debug.Log(eventCurrent.button);

            //7.鼠标位置
            //  Event.current.mousePosition
            Debug.Log("鼠标位置" + eventCurrent.mousePosition);
        }

        //8.判断是否是键盘输入
        //  Event.current.isKey
        if (eventCurrent.isKey)
        {
            Debug.Log("键盘相关事件");

            //9.获取键盘输入的字符
            //  Event.current.character
            Debug.Log(eventCurrent.character);

            //10.获取键盘输入对应的KeyCode
            //  Event.current.keyCode
            //Debug.Log(eve.keyCode);
            switch (eventCurrent.keyCode)
            {
                case KeyCode.Space:
                    Debug.Log("空格键输入");
                    break;
            }
        }

        //11.判断输入类型
        //  Event.current.type
        //  EventType枚举和它比较即可
        //  EventType中有常用的 鼠标按下抬起拖拽，键盘按下抬起等等类型
        //  一般会配合它 来判断 比如 键盘 鼠标的抬起按下相关的操作

        //12.是否锁定大写 对应键盘上caps键是否开启
        //  Event.current.capsLock
        if (eventCurrent.capsLock)
            Debug.Log("大小写锁定开启");
        else
            Debug.Log("大小写锁定关闭");

        //13.Windows键或Command键是否按下
        //  Event.current.command
        if (eventCurrent.command)
            Debug.Log("PC win键按下 或 Mac Command键按下");

        //14.键盘事件 字符串
        //  Event.current.commandName
        //  可以用来判断是否触发了对应的键盘事件
        //  返回值：
        //  Copy:拷贝
        //  Paste:粘贴
        //  Cut:剪切
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

        //15.鼠标间隔移动距离
        //  Event.current.delta

        //Debug.Log(eve.delta);

        //16.是否是功能键输入
        //  Event.current.functionKey
        //  功能键指小键盘中的 方向键, page up, page down, backspace等等
        if (eventCurrent.functionKey)
            Debug.Log("有功能按键输入");

        //17.小键盘是否开启
        //  Event.current.numeric
        if (eventCurrent.numeric)
            Debug.Log("小键盘是否开启");

        //18.避免组合键冲突
        //  Event.current.Use()
        //  在处理完对应输入事件后，调用该方法，可以阻止事件继续派发，放置和Unity其他编辑器事件逻辑冲突
        eventCurrent.Use();
    }
}
