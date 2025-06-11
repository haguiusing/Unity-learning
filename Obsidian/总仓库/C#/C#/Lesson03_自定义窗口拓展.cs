using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lesson03_自定义窗口拓展 : EditorWindow
{
    [MenuItem("编辑器拓展教程/Lesson03_自定义窗口拓展/显示Lesson03自定义窗口")]
    private static void ShowWindow()
    {
        Lesson03_自定义窗口拓展 win = EditorWindow.GetWindow<Lesson03_自定义窗口拓展>();
        win.titleContent = new GUIContent("我的窗口");
        win.Show();
    }


    void Start()
    {
        #region 知识点一 创建窗口类

        //命名空间：UnityEditor
        //类名：EditorWindow

        //当我们想要为Unity拓展一个自定义窗口时
        //我们只需要实现一个继承了EditorWindow的类即可
        //并且在该类的OnGUI函数中编写面板控件相关的逻辑

        #endregion

        #region 知识点二 显示窗口

        //用上节课学习的添加自定义页签的知识
        //添加一个自定义页签用于开启窗口
        //调用
        //EditorWindow.GetWindow

        //该方法有很多种重载
        //其中的主要参数一般有
        //Type或T：窗口类的类型
        //utility：为 true 可创建浮动实用程序窗口，设置为 false 可创建正常窗口。所谓浮动窗口就是可以自由拖动自由改变大小
        //title：窗口标题
        //focus：是否为窗口提供焦点（如果已存在）。（如果 GetWindow 创建新窗口，则将始终获得焦点）
        //desiredDockNextTo:窗口试图停靠到其上的 EditorWindow 类型的数组

        //创建窗口对象
        //之后调用对象的Show方法即可显示窗口

        #endregion

        #region 知识点三 窗口事件回调函数

        //继承EditorWindow的窗口类 自带一些事件回调函数
        //当触发对应事件时会自动进入
        //OnHierarchyChange():当场景中的层次结构（Hierarchy）发生变化时调用。
        //                    例如，当游戏对象被创建、删除或重命名时触发。
        //OnFocus():当窗口获得焦点时调用。
        //          在这个方法中，你可以执行一些在窗口获得焦点时需要进行的操作。
        //OnLostFocus():当窗口失去焦点时调用。
        //              通常在这个方法中执行一些在窗口失去焦点时需要进行的清理工作。
        //OnProjectChange():当项目资源发生变化时调用。
        //                  例如，当添加、删除或修改项目中的文件时触发。
        //OnInspectorUpdate():在检视器（Inspector）面板更新时调用。
        //                    可以在这个方法中执行需要在检视器面板刷新时进行的逻辑，比如更新显示的信息
        //OnSelectionChange():当选择的对象发生变化时调用。
        //                    在这个方法中，你可以执行与所选对象相关的操作，以确保编辑器窗口的内容与当前选择保持同步。

        #endregion

        #region 知识点四 窗口中常用的生命周期函数

        //OnEnable():
        //当窗口被激活时调用，通常在窗口创建时会调用一次。
        //在这个方法中，你可以进行一些初始化工作，例如注册事件监听器或设置初始变量。
        //OnGUI():
        //每帧都会调用此方法，用于绘制编辑器窗口的 GUI。
        //在这个方法中，你可以使用 GUILayout 或 EditorGUILayout 等类创建界面元素，以便用户与窗口进行交互。
        //OnDestroy():
        //当窗口被销毁时调用，通常在关闭编辑器或切换场景时触发。在这里进行最终的清理工作，确保没有未释放的资源。
        //Update():
        //在编辑器窗口每帧更新时调用。通常在这里执行一些需要在每帧进行的逻辑

        #endregion

        #region 知识点五 编辑器窗口类中的常用成员

        //Unity官方文档有关于编辑器窗口类的API说明
        //https://docs.unity.cn/cn/2022.3/ScriptReference/EditorWindow.html

        //静态变量
        //1.focusedWindow：当前已获得键盘焦点的 EditorWindow。（只读）
        //2.mouseOverWindow：当前在鼠标光标下的 EditorWindow。（只读）

        //静态函数
        //CreateWindow: 创建窗口，如果允许一个窗口有多个可以用该API创建窗口，这样创建的窗口不是单例唯一的
        //GetWindow: 通过它我们可以创建一个窗口对象，这样创建的窗口是单例唯一的
        //GetWindowWithRect：返回一个指定位置、大小的窗口
        //HasOpenInstances：检查编辑器窗口是否打开

        //成员变量
        //titleContent：窗口标题名
        //positon：窗口位置大小信息
        //wantsMouseEnterLeaveWindow:如果设置为 true，则每当鼠标进入或离开窗口时，该窗口都会收到一次 OnGUI 调用

        //成员函数
        //Show: 显示面板
        //Repaint：重绘窗口
        //Close: 关闭窗口

        #endregion

        #region 总结

        //编辑器拓展中想要实现自定义窗口
        //只需要继承EditorWindow类
        //主要在OnGUI中利用GUI相关API绘制控件处理功能逻辑
        //对应的事件回调函数，可以帮助我们监听到一些特殊情况用于处理对应逻辑

        #endregion
    }

    #region 知识点三 窗口事件回调函数

    private void OnHierarchyChange()
    {
        Debug.Log("当Hierarchy窗口内容发生变化时");
    }

    private void OnFocus()
    {
        Debug.Log("获取焦点");
    }

    private void OnLostFocus()
    {
        Debug.Log("失去焦点");
    }

    private void OnProjectChange()
    {
        Debug.Log("当Project窗口内容发生变化时");
    }

    private void OnInspectorUpdate()
    {
        Debug.Log("当Inspector窗口内容发生变化时");
    }

    private void OnSelectionChange()
    {
        Debug.Log("当选中对象发生变化时");
    }

    #endregion

    private void OnGUI()
    {
        GUILayout.Label("测试文本");
        if (GUILayout.Button("测试按钮"))
        {
            Debug.Log("Test");
        }
    }
}
