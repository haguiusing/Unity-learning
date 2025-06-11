[GuiSkin](file:///D:/Obsidian%20Unity/Unity/UI%20System/Assets/Scripts/GUI/Lesson9_GUISkin.cs)
# GUI Skin（IMGUI 系统）

**GUISkin** 是可应用于 GUI 的 **GUIStyle** 的集合。每种__控件 (Control)__ 类型都有自己的样式定义。皮肤 (Skin) 的主要目的将样式应用于整个 UI，而不是应用于单独的控件本身。

![Inspector 中显示的 GUI Skin](https://docs.unity3d.com/cn/current/uploads/Main/Inspector-GUISkin.png)

Inspector 中显示的 GUI Skin

要创建 GUISkin，请从菜单栏中选择 **Assets > Create > GUI Skin**。

**Please Note**: This page refers to part of the [IMGUI](https://docs.unity3d.com/cn/current/Manual/GUIScriptingGuide.html) system, which is a _scripting-only_ UI system. Unity has a full GameObject-based UI system which you may prefer to use. It allows you to design and edit user interface elements as visible objects in the scene view. See the [UI System Manual](https://docs.unity3d.com/cn/current/Manual/com.unity.ugui.html) for more information.

## 属性

GUI Skin 中的所有属性都是单独的 [GUIStyle](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)。请阅读 [GUIStyle](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html) 页面了解有关样式 (Style) 用法的更多信息。

| **_属性：_**                             | **_功能：_**                                                                               |
| ------------------------------------- | --------------------------------------------------------------------------------------- |
| **Font**                              | 用于 GUI 中每个控件的全局字体                                                                       |
| **Box**                               | 用于所有框形的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)             |
| **Button**                            | 用于所有按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)             |
| **Toggle**                            | 用于所有开关的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)             |
| **Label**                             | 用于所有标签的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)             |
| **Text Field**                        | 用于所有文本字段的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)           |
| **Text Area**                         | 用于所有文本区域的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)           |
| **Window**                            | 用于所有窗口的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)             |
| **Horizontal Slider**                 | 用于所有水平滑动条的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)          |
| **Horizontal Slider Thumb**           | 用于所有水平滑动条 Thumb 按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html) |
| **Vertical Slider**                   | 用于所有垂直滑动条的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)          |
| **Vertical Slider Thumb**             | 用于所有垂直滑动条 Thumb 按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html) |
| **Horizontal Scrollbar**              | 用于所有水平滚动条的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)          |
| **Horizontal Scrollbar Thumb**        | 用于所有水平滚动条 Thumb 按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html) |
| **Horizontal Scrollbar Left Button**  | 用于所有水平滚动条向左滚动按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)    |
| **Horizontal Scrollbar Right Button** | 用于所有水平滚动条向右滚动按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)    |
| **Vertical Scrollbar**                | 用于所有垂直滚动条的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)          |
| **Vertical Scrollbar Thumb**          | 用于所有垂直滚动条 Thumb 按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html) |
| **Vertical Scrollbar Up Button**      | 用于所有垂直滚动条向上滚动按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)    |
| **Vertical Scrollbar Down Button**    | 用于所有垂直滚动条向下滚动按钮的[样式](https://docs.unity3d.com/cn/current/Manual/class-GUIStyle.html)    |
| **Custom 1–20**                       | 可应用于任何控件的其他自定义样式                                                                        |
| **Custom Styles**                     | 一组可应用于任何控件的其他自定义样式                                                                      |
| **Settings**                          | 整个 GUI 的其他设置                                                                            |
| **Double Click Selects Word**         | 如果启用此选项，则双击某个单词将选中该单词                                                                   |
| **Triple Click Selects Line**         | 如果启用此选项，则单击三次某个单词将选中该行                                                                  |
| **Cursor Color**                      | 键盘光标的颜色                                                                                 |
| **Cursor Flash Speed**                | 编辑文本控件时文本光标的闪烁速度                                                                        |
| **Selection Color**                   | 文本所选区域的颜色                                                                               |