[Toggle](file://assets/Scripts/UGUI/Lesson11_Toggle/Lesson11_Toggle.cs)
# 开关 (Toggle)

开关控件是让用户打开或关闭某个选项的复选框。

![开关。](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_ToggleExample.png)

开关。
![[Pasted image 20241203203529.png]]

## 属性
![[Pasted image 20241203220040.png]]

|**_属性：_**|**_功能：_**|
|---|---|
|**Interactable**|此组件是否接受输入？请参阅 [Interactable](https://docs.unity3d.com/cn/2022.3/Manual/script-Selectable.html)。|
|**Transition**|确定控件以何种方式对用户操作进行可视化响应的属性。请参阅[过渡选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableTransition.html)。|
|**Navigation**|确定控件顺序的属性。请参阅[导航选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableNavigation.html)。|
|**Is On**|开关在开始时是否为打开状态？|
|**Toggle Transition**|开关在其值发生变化时以图形方式作出的反应。提供的选项为 _None_（即复选标记直接出现或消失）和_ Fade_（即复选标记淡入或淡出）。|
|**Graphic**|用于复选标记的图像。|
|**Group**|此开关所属的[开关组](https://docs.unity3d.com/cn/2022.3/Manual/script-ToggleGroup.html)（如果有）。|

## 事件

|**_属性：_**|**_功能：_**|
|---|---|
|**On Value Changed**|单击开关时调用的 [UnityEvent](https://docs.unity3d.com/cn/2022.3/Manual/UnityEvents.html)。该事件可将当前状态作为 `bool` 类型动态参数发送。|

## 详细信息
开关控件可让用户打开或关闭某个选项。如果一次只能打开一组选项中的一个选项，还可以将多个开关组合到一个[开关组](https://docs.unity3d.com/cn/2022.3/Manual/script-ToggleGroup.html)中。

开关有一个名为 _On Value Changed_ 的事件，当用户更改当前值时会响应。新值作为 `boolean` 参数传递给事件函数。开关的典型用例包括：
- 打开或关闭选项（例如，在游戏期间播放音乐）。
- 让用户确认他们已阅读法律免责声明。
- 以开关组形式使用时，选择一组选项中的一个选项（例如，一周中的某一天）。

请注意，__开关__是为子项提供可单击区域的父项。如果__开关__没有子项（或者子项被禁用），则不可单击开关。

# 开关组 (Toggle Group)
__开关组不是可见的 UI 控件，而是一种修改一组[开关](https://docs.unity3d.com/cn/2022.3/Manual/script-Toggle.html)的行为的方法。属于同一组的开关将受到约束，即一次只能打开其中一个开关：通过按下打开其中一个开关便会自动关闭其他开关。

![开关组](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_ToggleGroupExample.png)
开关组

![](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_ToggleGroupInspector.png)

## 属性

|**_属性：_**|**_功能：_**|
|---|---|
|**Allow Switch Off**|是否允许不打开任何开关？如果启用此设置，则按下当前打开的开关会将其关闭，因此没有任何开关处于打开状态。如果禁用此设置，则按下当前打开的开关将不改变该开关的状态。|

## 描述

通过将开关组对象拖动到组中每个开关的 _Group_ 属性即可设置开关组。

当用户必须从互斥的一组选项进行选择时，便可使用开关组。常见示例包括选择玩家角色类型、速度设置（慢速、中速、快速等）、预设颜色和一周中的日期。在场景中可以同时有多个开关组对象，因此可以根据需要创建多个单独的组。

与其他 UI 元素不同，具有开关组 (Toggle Group) 组件的对象不必是[画布](https://docs.unity3d.com/cn/2022.3/Manual/class-Canvas.html)对象的子项，但开关本身仍然是其子项。

请注意，如果在加载场景或实例化组时，开关组中的多个开关为打开状态，则开关组不会立即执行其约束。只有当新开关打开时，其他开关才会关闭。这意味着需要由您确保在开始时只打开一个开关。