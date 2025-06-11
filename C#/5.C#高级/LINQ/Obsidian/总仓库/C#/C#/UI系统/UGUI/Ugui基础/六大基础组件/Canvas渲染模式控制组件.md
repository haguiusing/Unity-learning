# 画布(Canvas)
**画布 (Canvas)** 是应该容纳所有 UI 元素的区域。画布是一种带有画布组件的游戏对象，所有 UI 元素都必须是此类画布的子项。

创建新的 UI 元素（如使用菜单 **GameObject > UI > Image** 创建图像）时，如果场景中还没有画布，则会自动创建画布。UI 元素将创建为此画布的子项。

画布区域在 Scene 视图中显示为矩形。这样可以轻松定位 UI 元素，而无需始终显示 Game 视图。

**画布** 使用 EventSystem 对象来协助消息系统。

## 绘制元素的顺序
画布中的 UI 元素按照它们在 Hierarchy 中显示的顺序绘制。首先绘制第一个子项，然后绘制第二个子项，依此类推。如果两个 UI 元素重叠，则后一个元素将显示在前一个元素之上。

要更改元素的显示顺序，只需在 Hierarchy 中拖动元素进行重新排序。也可以通过在变换组件上使用以下方法从脚本控制顺序：SetAsFirstSibling、SetAsLastSibling 和 SetSiblingIndex。

## 渲染模式
画布具有 渲染模式 (Render Mode) 设置，可用于在屏幕空间或世界空间中进行渲染。

### Screen Space - Overlay
此渲染模式将 UI 元素放置于在场景之上渲染的屏幕上。如果调整屏幕大小或更改分辨率，则画布将自动更改大小来适应此情况。
![Screen Space Overlay 画布中的 UI](https://docs.unity3d.com/cn/current/uploads/Main/GUI_Canvas_Screenspace_Overlay.jpg)
Screen Space Overlay 画布中的 UI
![[Pasted image 20240929163918.png]]

### Screen Space - Camera
此渲染模式类似于 __Screen Space - Overlay__，但在此模式下，画布放置在指定 摄像机 前面的给定距离处。UI 元素由此摄像机渲染，这意味着摄像机设置会影响 UI 的外观。如果摄像机设置为 正交视图 ，则 UI 元素将以透视图渲染，透视失真量可由摄像机__视野__控制。如果调整屏幕大小、更改分辨率或摄像机视锥体发生改变，则画布也将自动更改大小来适应此情况。
![Screen Space Camera 画布中的 UI](https://docs.unity3d.com/cn/current/uploads/Main/GUI_Canvas_Screenspace_Camera.jpg)
Screen Space Camera 画布中的 UI
![[Pasted image 20240929164121.png]]

### World Space
在此渲染模式下，画布的行为与场景中的所有其他对象相同。画布大小可用矩形变换进行手动设置，而 UI 元素将基于 3D 位置在场景中的其他对象前面或后面渲染。此模式对于要成为世界一部分的 UI 非常有用。这种界面也称为“叙事界面”。
![World Space 画布中的 UI](https://docs.unity3d.com/cn/current/uploads/Main/GUI_Canvas_Worldspace.jpg)
World Space 画布中的 UI
![[Pasted image 20240929164625.png]]

**画布 (Canvas)** 组件表示进行 UI 布局和渲染的抽象空间。所有 UI 元素都必须是附加了画布组件的游戏对象的子对象。从菜单 (**GameObject > Create UI**) 创建 UI 元素对象时，如果场景中没有画布 (Canvas) 对象，则会自动创建该对象。

![Screen Space - Overlay 设置](https://docs.unity3d.com/cn/current/uploads/Main/UI_CanvasInspector.png)
Screen Space - Overlay 设置

![Screen Space - Camera 设置](https://docs.unity3d.com/cn/current/uploads/Main/UI_CanvasScreenSpaceCameraInspector.png)
Screen Space - Camera 设置

![World Space 设置](https://docs.unity3d.com/cn/current/uploads/Main/UI_CanvasWorldSpaceInspector.png)
World Space 设置

## 属性

| **_属性：_**                                         | **_功能：_**                                                                                                |
| ------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| **Render Mode**                                   | UI 在屏幕上或作为 3D 空间对象进行渲染的方式（见下文）。提供的选项包括 _Screen Space - Overlay_、_Screen Space - Camera_ 和 _World Space_。 |
| **Pixel Perfect（仅限 _Screen Space_ 模式）**           | 是否应该无锯齿精确渲染 UI？                                                                                          |
| **Render Camera（仅限 _Screen Space - Camera_ 模式）**  | 应该将 UI 渲染到的摄像机（见下文）。                                                                                     |
| **Plane Distance（仅限 _Screen Space - Camera_ 模式）** | UI 平面在摄像机前方的距离。                                                                                          |
| **Event Camera（仅限 _World Space_ 模式）**             | 用于处理 UI 事件的摄像机。                                                                                          |
| **Receives Events**                               | 此画布是否处理 UI 事件？                                                                                           |
| Vertex Color Always In Gamma                      | 画布顶点颜色是否应始终位于伽马空间中，然后再传递到线性颜色空间工作流程中的 UI 着色器。                                                            |

## 详细信息
所有 UI 元素使用一个画布就足够了，但场景中可以有多个画布。此外，为了实现优化目的，还可以使用嵌套的画布，使一个画布作为另一个画布的子项。嵌套的画布使用与其父项相同的渲染模式。

传统上，渲染 UI 的效果就好像是直接在屏幕上绘制的简单图形设计。也就是说，没有摄像机观察 3D 空间的概念。Unity 便支持这种屏幕空间渲染方式，但也允许 UI 在场景中渲染为对象，具体取决于 _Render Mode_ 属性的值。可用的模式包括 **Screen Space - Overlay**、**Screen Space - Camera** 和 **World Space**。

### Screen Space - Overlay
在此模式下，画布会进行缩放来适应屏幕，然后直接渲染而不参考场景或摄像机（即使场景中根本没有摄像机，也会渲染 UI）。如果更改屏幕的大小或分辨率，则 UI 将自动重新缩放进行适应。UI 将绘制在所有其他图形（例如摄像机视图）上。
![Overlay UI 渲染在场景对象上](https://docs.unity3d.com/cn/current/uploads/Main/CanvasOverlay.png)
Overlay UI 渲染在场景对象上

注意：Screen Space - Overlay 画布需要存储在层级视图的顶级。如果未使用此设置，则 UI 可能会从视图中消失。这是一项内置的限制。请将 Screen Space - Overlay 画布保持在层级视图的顶级以便获得期望的结果。

### Screen Space - Camera
在此模式下，画布的渲染效果就好像是在摄像机前面一定距离的平面对象上绘制的效果。UI 在屏幕上的大小不随距离而变化，因为 UI 始终会重新缩放来准确适应[摄像机视锥体](https://docs.unity3d.com/cn/current/Manual/FrustumSizeAtDistance.html)。如果更改屏幕的大小或分辨率或更改摄像机视锥体，则 UI 将自动重新缩放进行适应。场景中比 UI 平面更靠近摄像机的所有 3D 对象都将在 UI 前面渲染，而平面后的对象将被遮挡。
![Camera 模式 UI 的前面有场景对象](https://docs.unity3d.com/cn/current/uploads/Main/CanvasCamera.png)
Camera 模式 UI 的前面有场景对象

### World Space
此模式将 UI 视为场景中的平面对象进行渲染。但是，与 _Screen Space - Camera_ 模式不同，该平面不需要面对摄像机，可以根据喜好任意定向。画布的大小可以使用矩形变换来设置，但画布在屏幕上的大小将取决于摄像机的视角和距离。其他场景对象可以位于画布后面、穿透画布或位于画布前面。
![World Space UI 与场景对象相交](https://docs.unity3d.com/cn/current/uploads/Main/CanvasWorldSpace.png)
World Space UI 与场景对象相交

## 提示
- 请在[创建 World Space UI](https://docs.unity3d.com/cn/current/Manual/HOWTO-UIWorldSpace.html) 页面上阅读有关设置世界空间画布 (World Space Canvas) 的更多信息。
- 如需了解如何使画布和 UI 缩放到不同的分辨率或宽高比，请参阅[设计用于多种分辨率的 UI](https://docs.unity3d.com/cn/current/Manual/HOWTO-UIMultiResolution.html) 页面以及[画布缩放器](https://docs.unity3d.com/cn/current/Manual/script-CanvasScaler.html)页面。