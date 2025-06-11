[Slider](file://assets/Scripts/UGUI/Lesson13_Slider/Lesson13_Slider.cs)
# 滑动条 (Slider)
__滑动条__控件允许用户通过拖动鼠标从预定范围中选择数值。请注意，类似的[滚动条 (ScrollBar)](https://docs.unity3d.com/cn/2022.3/Manual/script-Scrollbar.html)控件用于滚动而不是选择数值。熟悉的示例包括游戏中的难度设置和图像编辑器中的亮度设置。

![滑动条。](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_SliderExample.png)
滑动条。

![](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_SliderInspector.png)

## 属性
![[Pasted image 20241203222915.png]]

|**_属性：_**|**_功能：_**|
|---|---|
|**Interactable**|此组件是否接受输入？请参阅 [Interactable](https://docs.unity3d.com/cn/2022.3/Manual/script-Selectable.html)。|
|**Transition**|确定控件以何种方式对用户操作进行可视化响应的属性。请参阅[过渡选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableTransition.html)。|
|**Navigation**|确定控件顺序的属性。请参阅[导航选项](https://docs.unity3d.com/cn/2022.3/Manual/script-SelectableNavigation.html)。|
|**Fill Rect**|用于控件填充区域的图形。|
|**Handle Rect**|用于控件滑动“控制柄”部分的图形|
|**Direction**|拖动控制柄时滑动条值增加的方向。选项包括 _Left To Right_、_Right To Left_、_Bottom To Top_ 和 _Top To Bottom_。|
|**Min Value**|控制柄处于极下端（由 _Direction_ 属性确定）时的滑动条值。|
|**Max Value**|控制柄处于极上端（由 _Direction_ 属性确定）时的滑动条值。|
|**Whole Numbers**|是否应该将滑动条约束为整数值？|
|**Value**|滑动条的当前数值。如果在 Inspector 中设置了该值，则该值将用作初始值，但是当值变化时，运行时的值也将变化。|

## 事件

|**_属性：_**|**_功能：_**|
|---|---|
|**On Value Changed**|滑动条的当前值已变化时调用的 [UnityEvent](https://docs.unity3d.com/cn/2022.3/Manual/UnityEvents.html)。该事件可将当前值作为 `float` 类型动态参数发送。无论是否已启用 _Whole Numbers_ 属性，该值都将作为 float 类型传递。|

## 详细信息

滑动条的值由控制柄沿其长度的位置确定。该值从 _Min Value_ 增加到 _Max Value_，与拖动控制柄的距离成比例。默认行为是滑动条从左向右增加，但也可以使用_ Direction_ 属性反转此行为。通过将 _Direction_ 属性设置为 _Bottom To Top_ 或 _Top To Bottom_，还可以将滑动条设置为垂直增加。

滑动条有一个名为 _On Value Changed_ 的事件，当用户拖动控制柄时会响应。滑动条的当前数值作为 `float` 参数传递给函数。典型用例包括：

- 选择游戏难度、光源亮度等。
- 设置距离、大小、时间或角度。