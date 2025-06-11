[RectTransform](file://assets/Scripts/UGUI/Lesson6_RectTransform/Lesson6_RectTransform.cs)
# 矩形变换(RectTransform)
![[Pasted image 20241203215340.png]]
![[Pasted image 20241203200250.png]]
**矩形变换 (Rect Transform)** 组件是[变换 (Transform)](https://docs.unity3d.com/cn/2022.3/Manual/class-Transform.html) 组件在 2D 布局中的对应组件。变换组件表示单个点，而矩形变换组件表示可包含 UI 元素的矩形。如果矩形变换的父项也是矩形变换，则子矩形变换还可指定子矩形应该如何相对于父矩形进行定位和大小调整。
![](https://docs.unity3d.com/cn/2022.3/uploads/Main/UI_RectTransform.png)
## 属性
| **_属性：_**                    | **_功能：_**                                                                                                                 |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| **Pos (X, Y, Z)**            | 矩形轴心点相对于锚点的位置。轴心点是矩形旋转所围绕的位置。                                                                                             |
| **Width/Height**             | 矩形的宽度和高度。                                                                                                                 |
| **Left, Top, Right, Bottom** | 矩形边缘相对于锚点的位置。可视为由锚点定义的矩形内的填充。当锚点分离时（见下文）将取代 _Pos_ 和 _Width/Height_ 显示。要访问这些选项，请单击 RectTransform 组件左上方的 Anchor Presets 方框。 |
| **Anchors**                  | 矩形左下角和右上角的锚点。                                                                                                             |
| **Min**                      | 矩形左下角的锚点，定义为父矩形大小的一个比例。0,0 相当于锚定到父项的左下角，而 1,1 相当于锚定到父项的右上角。                                                               |
| **Max**                      | 矩形右上角的锚点，定义为父矩形大小的一个比例。0,0 相当于锚定到父项的左下角，而 1,1 相当于锚定到父项的右上角。                                                               |
| **Pivot**                    | 矩形旋转围绕的轴心点的位置，定义为矩形本身大小的一个比例。0,0 相当于左下角，而 1,1 相当于右上角。                                                                     |
| **Rotation**                 | 对象围绕其轴心点沿 X、Y 和 Z 轴的旋转角度（以度为单位）。                                                                                          |
| **Scale**                    | 在 X、Y 和 Z 维度中应用于对象的缩放因子。                                                                                                  |
| **Blueprint Mode**           | 编辑 RectTransform，就好像它们没有旋转和缩放一样。这也会启用贴靠。                                                                                  |
| **Raw Edit Mode**            | 启用此属性后，编辑轴心和锚点值不会反向调整矩形的位置和大小来使矩形保持在同一个位置。                                                                                |
## 详细信息
请注意，有些 RectTransform 计算会在帧的末尾进行，即在计算 UI 顶点之前进行，目的是确保与整个帧中执行的所有最新更改保持同步。这意味着在 Start 回调和第一次 Update 回调中尚未进行首次计算。
为解决这一问题，可创建 `Start()` 回调并向其中添加 `Canvas.ForceUpdateCanvases()` 方法。这样将强制画布不在帧的末尾更新，而是在调用该方法时进行更新。
请参阅[基本布局](https://docs.unity3d.com/cn/2022.3/Manual/UIBasicLayout.html)页面了解关于矩形变换用法的完整介绍和概述。