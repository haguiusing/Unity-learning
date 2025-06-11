[Button](file://assets/Scripts/UGUI/Lesson10_Button/Lesson10_Button.cs)
# 按钮 (Button)

__按钮控件可响应用户的点击并用于启动或确认操作。熟悉的示例包括 Web 表单上使用的 Submit 和 _Cancel 按钮。

![按钮。](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_ButtonExample.png)

按钮。
![[Pasted image 20241203201630.png]]

![[Pasted image 20241203202041.png]]
![[Pasted image 20241203202513.png]]
## 属性

|**_属性：_**|**_功能：_**|
|---|---|
|**Interactable**|如果想要此按钮接受输入，请启用 **Interactable**。请参阅关于 [Interactable](https://docs.unity3d.com/cn/2022.3/Manual/script-Selectable.html) 的 API 文档以了解更多详细信息。|
|**Transition**|确定控件以何种方式对用户操作进行可视化响应的属性。请参阅[过渡选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableTransition.html)。|
|**Navigation**|确定控件顺序的属性。请参阅[导航选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableNavigation.html)。|

## 事件

|**_属性：_**|**_功能：_**|
|---|---|
|**On Click**|用户单击按钮再松开时 Unity 调用的 [UnityEvent](https://docs.unity3d.com/cn/2022.3/Manual/UnityEvents.html)。|

## 详细信息

按钮用于在用户单击再松开时启动某项操作。如果在松开单击之前将鼠标移开按钮控件，则不会执行操作。

按钮有一个名为 _On Click_ 的事件，当用户完成单击时会响应。典型用例包括：

- 确认某项决定（例如，开始游戏或保存游戏）
- 移动到 GUI 中的子菜单
- 取消正在进行的操作（例如，下载新场景）