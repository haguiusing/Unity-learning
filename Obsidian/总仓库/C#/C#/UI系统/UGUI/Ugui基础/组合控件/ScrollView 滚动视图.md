[ScrollView](file://assets/Scripts/UGUI/Lesson15_ScrollView/Lesson15_ScrollView.cs)
# 滚动矩形 (Scroll Rect)
当占用大量空间的内容需要在小区域中显示时，可使用滚动矩形。滚动矩形提供了滚动此内容的功能。

通常情况下，滚动矩形与[遮罩 (Mask)](https://docs.unity3d.com/cn/2023.2/Manual/script-Mask.html) 相结合来创建滚动视图，在产生的视图中只有滚动矩形内的可滚动内容为可见状态。此外，滚动矩形还可与一个或两个可拖动以便水平或垂直滚动的[滚动条 (Scrollbar)](https://docs.unity3d.com/cn/2023.2/Manual/script-Scrollbar.html) 组合使用。

![滚动矩形。](https://docs.unity3d.com/cn/2023.2/uploads/Main/UI_ScrollRectExample.png)
滚动矩形。

![[Pasted image 20241203224050.png]]

## 属性
![[Pasted image 20241203225021.png]]

|**_属性：_**|**_功能：_**|
|---|---|
|**Content**|这是对需要滚动的 UI 元素（例如大型图像）的矩形变换的引用。|
|**Horizontal**|启用水平滚动|
|**Vertical**|启用垂直滚动|
|**Movement Type**|Unrestricted、Elastic 或 Clamped。使用 Elastic 或 Clamped 可强制内容保持在滚动矩形的边界内。Elastic 模式在内容到达滚动矩形边缘时弹回内容|
|**Elasticity**|这是弹性模式中使用的反弹量。|
|**Inertia**|如果设置 Inertia，则拖动指针再松开时内容将继续移动。如果未设置 Inertia，则只有进行拖动时内容才移动。|
|**Deceleration Rate**|设置 Inertia 的情况下，减速率 (Deceleration Rate) 决定了内容停止移动的速度。速率为 0 将立即停止移动。值为 1 表示移动永不减速。|
|**Scroll Sensitivity**|对滚轮和触控板滚动事件的敏感性。|
|**Viewport**|对作为内容矩形变换父项的视口矩形变换的引用。|
|**Horizontal Scrollbar**|对水平滚动条元素的引用（可选）。|
|**Visibility**|滚动条是否应在不需要时自动隐藏以及（可选）是否还展开视口。|
|**Spacing**|滚动条与视口之间的空间。|
|**Vertical Scrollbar**|对垂直滚动条元素的引用（可选）。|
|**Visibility**|滚动条是否应在不需要时自动隐藏以及（可选）是否还展开视口。|
|**Spacing**|滚动条与视口之间的空间。|

## 事件

|**_属性：_**|**_功能：_**|
|---|---|
|**On Value Changed**|滚动矩形的滚动位置发生变化时调用的 [UnityEvent](https://docs.unity3d.com/cn/2023.2/Manual/UnityEvents.html)。该事件可将当前滚动位置作为 `Vector2` 类型动态参数发送。|

## 详细信息

滚动视图中的重要元素包括**视口**、滚动**内容**以及可选的一个或两个**滚动条**。
- 根游戏对象具有滚动矩形组件。
- 视口具有[遮罩](https://docs.unity3d.com/cn/2023.2/Manual/script-Mask.html)组件。视口可以是根游戏对象，也可以是作为根的子项的单独游戏对象。如果使用自动隐藏的滚动条，则视口必须是子项。需要在滚动矩形的 **Viewport** 属性中引用视口矩形变换。
- 所有滚动内容必须是作为视口子项的单个内容游戏对象的子项。需要在滚动矩形的 **Content** 属性中引用内容矩形变换。
- 滚动条（如果使用）是根游戏对象的子项。请参阅[滚动条](https://docs.unity3d.com/cn/2023.2/Manual/script-Scrollbar.html)页面了解有关滚动条设置的更多详细信息，并参阅下面的**滚动条设置**部分了解有关滚动视图的滚动条设置的信息。

下图显示了视口是滚动视图根节点的子项的设置。使用 GameObject > UI > Scroll View 菜单选项时，默认情况下会采用此设置。
![](https://docs.unity3d.com/cn/2023.2/uploads/Main/UI_ScrollRectHierarchy.png)
要滚动内容，必须从 ScrollRect 的边界内部而不是内容本身接收输入。

使用 Unrestricted 移动类型时要小心，因为可能会以无法挽回的方式失去对内容的控制。使用 Elastic 或 Constrained 移动类型时，最好调整内容位置以确保其在 ScrollRect 的边界内开始移动，否则当 RectTransform 尝试将内容恢复到其边界内时，可能会发生意外行为。

### 滚动条设置

可选择性地将滚动矩形链接到水平和/或垂直**滚动条**。这些控件通常作为视口的同级放置在层级视图中，并且当存在这些控件时，应分别拖动到滚动矩形的 **Horizontal Scrollbar** 和 **Vertical Scrollbar** 属性中。请注意，此类水平滚动条上的 **Direction** 属性应设置为 **Left To Right**，而垂直滚动条上应设置为 **Bottom To Top**。

如果由于滚动条大小不超过视口而不需要滚动内容，可选择让滚动条自动隐藏。请注意，自动隐藏仅在播放模式下发生。在编辑模式下，始终显示滚动条。这样可以防止在不应该的情况下将场景标记为“脏”，并且还有助于让创建的内容即使在显示滚动条时仍有空间。

如果其中一个滚动条或两个滚动条的可见性行为都设置为 **Auto Hide And Expand View**，则在隐藏滚动条时会自动展开视口，以便占用滚动条原本使用的额外空间。如果使用此设置，**视图**的位置和大小将由滚动矩形决定，并且**水平滚动条**的宽度以及**垂直滚动条**的高度也由滚动矩形决定。使用此设置时，视口以及滚动条都必须是滚动矩形根游戏对象的子项。

## 提示
- 使用内容 RectTransform 的轴心和锚点可以确定内容伸缩时在滚动视图内的对齐方式。如果内容应与顶部保持对齐，请将锚点设置为父项的顶部，并将轴心设置为顶部位置。
- 请参阅[使 UI 元素适应其内容的大小](https://docs.unity3d.com/cn/2023.2/Manual/HOWTO-UIFitContentSize.html)页面，了解如何使内容矩形变换自动调整大小来适应内容。