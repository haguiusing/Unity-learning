![[Pasted image 20241203215156.png]]
# 独立输入模块(Standalone Input Module)
![[Pasted image 20241203203821.png]]
根据设计，该模块与控制器/鼠标输入具有相同的功能。响应输入时会发送按钮按压、拖拽以及类似事件。

当鼠标/输入设备移动时，该模块将指针事件发送到组件，并使用[图形射线投射器 (Graphics Raycaster)](https://docs.unity3d.com/cn/2022.3/ScriptReference/UI.GraphicRaycaster.html)和[物理射线投射器 (Physics Raycaster)](https://docs.unity3d.com/cn/2022.3/ScriptReference/EventSystems.PhysicsRaycaster.html) 来计算给定指针设备当前指向的元素。您可以配置这些射线投射器来检测或忽略场景的某些部分，从而满足您的要求。

该模块会发送 Move 事件和 Submit/Cancel 事件来响应通过 [Input](https://docs.unity3d.com/cn/2022.3/Manual/class-InputManager.html) 窗口跟踪的输入。对于键盘和控制器输入均是如此。可在模块的检视面板中配置跟踪的轴和键。

## 属性

| **_属性：_**                    | **_功能：_**                                             |
| ---------------------------- | ----------------------------------------------------- |
| **Horizontal Axis**          | 为水平轴按钮输入所需的管理器名称。                                     |
| **Vertical Axis**            | 为垂直轴输入所需的管理器名称。                                       |
| **Submit Button**            | 为 Submit 按钮输入所需的管理器名称。                                |
| **Cancel Button**            | 为 Cancel 按钮输入所需的管理器名称。                                |
| **Input Actions Per Second** | 每秒允许的键盘/控制器输入数量。                                      |
| **Repeat Delay**             | 每秒输入操作重复率生效前的延迟秒数。                                    |
| **Force Module Active**      | 启用此属性可强制该__独立输入模块 (Standalone Input Module)__ 处于活动状态。 |

## 详细信息

该模块：

- 使用垂直/水平轴进行键盘和控制器导航
- 使用 Submit/Cancel 按钮发送提交和取消事件
- 在事件之间有一个超时值仅允许每秒的最大事件数。

该模块的流程如下

- 如果输入了 [Input](https://docs.unity3d.com/cn/2022.3/Manual/class-InputManager.html) 窗口中的有效轴，则向所选对象发送 Move 事件
- 如果按下了 Submit 或 Cancel 按钮，则向所选对象发送 Submit 或 Cancel 事件
- 处理鼠标输入
    - 如果这是新的按压操作
        - 发送 PointerEnter 事件（向上发送到层级视图中可对其进行处理的每个对象）
        - 发送 PointerPress 事件
        - 缓存拖动处理程序（层级视图中可对其进行处理的第一个元素）
        - 将 BeginDrag 事件发送到拖动处理程序
        - 在事件系统中将“Pressed”对象设置为 Selected
    - 如果这是持续按压操作
        - 处理移动
        - 将 DragEvent 发送到缓存的拖动处理程序
        - 如果触摸在对象之间移动，则处理 PointerEnter 和 PointerExit 事件
    - 如果这是释放操作
        - 将 PointerUp 事件发送到收到 PointerPress 的对象
        - 如果当前悬停对象与 PointerPress 对象相同，则发送 PointerClick 事件
        - 如果缓存了拖动处理程序，则发送 Drop 事件
        - 将 EndDrag 事件发送到缓存的拖动处理程序
    - 处理滚轮事件
# Touch Input Module  触摸输入模块
**注意：触摸输入模块 (TouchInputModule) 已弃用。现在触摸输入的处理在 [StandaloneInputModule](https://docs.unity3d.com/cn/2022.3/Manual/script-StandaloneInputModule.html) 中进行。**

该模块设计用于触摸设备，可发送触摸和拖动操作的指针事件来响应用户输入。该模块支持多点触控。

该模块使用场景配置的射线投射器来计算当前正在触摸的元素。每次当前触摸操作都将相应发出射线投射。

## 属性

|**_属性：_**|**_功能：_**|
|---|---|
|**Force Module Active**|强制激活此模块。|

## 详细信息

该模块的流程如下：
- 对于每个触摸事件
    - 如果这是新的按压操作
        - 发送 PointerEnter 事件（向上发送到层级视图中可对其进行处理的每个对象）
        - 发送 PointerPress 事件
        - 缓存拖动处理程序（层级视图中可对其进行处理的第一个元素）
        - 将 BeginDrag 事件发送到拖动处理程序
        - 在事件系统中将“Pressed”对象设置为 Selected
    - 如果这是持续按压操作
        - 处理移动
        - 将 DragEvent 发送到缓存的拖动处理程序
        - 如果触摸在对象之间移动，则处理 PointerEnter 和 PointerExit 事件
    - 如果这是释放操作
        - 将 PointerUp 事件发送到收到 PointerPress 的对象
        - 如果当前悬停对象与 PointerPress 对象相同，则发送 PointerClick 事件
        - 如果缓存了拖动处理程序，则发送 Drop 事件
        - 将 EndDrag 事件发送到缓存的拖动处理程序
