using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson22_Event : MonoBehaviour
{
    void Start()
    {
        #region 准备工作

        //自定义一个编辑器拓展窗口用于Event知识学习

        #endregion

        #region 知识点一 Event公共类是用来做什么的？

        //它提供了许多属性和方法，允许你检查和处理用户输入
        //主要用于在Unity编辑器拓展开发中

        //因为Input相关内容需要在运行时才能监听输入
        //而Event专门提供给编辑模式下使用，可以帮助我们检测鼠标键盘输入等事件相关操作
        //在 OnGUI 和 OnSceneView 中都能使用

        #endregion

        #region 知识点二 重要API

        //1.获取当前输入事件
        //  Event.current

        //2.alt键是否按下
        //  Event.current.alt

        //3.shift键是否按下
        //  Event.current.shift

        //4.ctrl键是否按下
        //  Event.current.control

        //5.是否是鼠标事件
        //  Event.current.isMouse

        //6.判断鼠标左中右键
        //  Evnet.current.button (0,1,2 分别代表 左,右,中 如果大于2可能是其他鼠标按键)

        //7.鼠标位置
        //  Event.curretn.mousePosition

        //8.判断是否是键盘输入
        //  Event.current.isKey

        //9.获取键盘输入的字符
        //  Event.current.character

        //10.获取键盘输入对应的KeyCode
        //  Event.current.keyCode

        //11.判断输入类型
        //  Event.current.type
        //  EventType枚举和它比较即可
        //  EventType中有常用的 鼠标按下抬起拖拽，键盘按下抬起等等类型

        //12.是否锁定大写 对应键盘上caps键是否开启
        //  Event.current.capsLock

        //13.Windows键或Command键是否按下
        //  Event.current.command

        //14.键盘事件 字符串
        //  Event.current.commandName
        //  可以用来判断是否触发了对应的键盘事件
        //  返回值：
        //  Copy:拷贝
        //  Paste:粘贴
        //  Cut:剪切

        //15.鼠标间隔移动距离
        //  Event.current.delta

        //16.是否是功能键输入
        //  Event.current.functionKey
        //  功能键指小键盘中的 方向键, page up, page down, backspace等等

        //17.小键盘是否开启
        //  Event.current.numeric

        //18.避免组合键冲突
        //  Event.current.Use()
        //  在处理完对应输入事件后，调用该方法，可以阻止事件继续派发，放置和Unity其他编辑器事件逻辑冲突

        #endregion

        #region 知识点三 更多内容

        //官方文档 https://docs.unity3d.com/ScriptReference/Event.html

        #endregion
    }
}
