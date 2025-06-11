# Position GameObjects

要更改游戏对象的[变换](https://docs.unity.cn/cn/2021.3/Manual/class-Transform.html)组件，请使用鼠标操纵任何辅助图标轴，或直接在 Inspector 中的__变换__组件的数字字段中输入值。

Alternatively, you can select each of the five **Transform** modes from the Scene view’s Tools [Overlay](https://docs.unity.cn/cn/2021.3/Manual/overlays.html) or with a hotkey:

- **W** for Move
- **E** for Rotate
- **R** for Scale
- **T** for RectTransform
- **Y** for Transform

![The Move, Rotate, Scale, Rect Transform, and Transform Gizmos](https://docs.unity.cn/cn/2021.3/uploads/Main/game-objects-transform-modes.png)

The Move, Rotate, Scale, Rect Transform, and Transform Gizmos

### 移动

在__移动__辅助图标的中心，有三个小方块可用于在单个平面内拖动游戏对象（意味着可一次移动两个轴，而第三个保持静止）。

如果在移动辅助图标的中心单击并拖动时按住 Shift，则辅助图标的中心将变为平面方块。平面方块表示可相对于 Scene 视图摄像机所面向的方向在平面上移动游戏对象。

### 旋转

选择__旋转__工具后，通过单击并拖动围绕游戏对象显示的线框球体辅助图标的轴来更改游戏对象的旋转。与移动辅助图标一样，更改的最后一个轴将显示为黄色。红色、绿色和蓝色圆圈可视为围绕在移动模式中出现的红色、绿色和蓝色轴进行旋转（红色表示 x 轴，绿色表示 y 轴，蓝色表示 z 轴）。最后，使用最外面的圆圈围绕 Scene 视图 z 轴旋转游戏对象。可将此行为视为在屏幕空间中旋转。

### 缩放

使用__缩放__工具，可通过单击并拖动辅助图标中心的立方体，在所有轴上均匀地重新缩放游戏对象。也可以单独缩放每个轴，但如果在有子游戏对象的情况下执行此操作，则应该注意，因为效果看起来会很奇怪。

### 矩形变换

[矩形变换](https://docs.unity.cn/cn/2021.3/Manual/class-RectTransform.html)通常用于定位 2D 元素（如精灵或 [UI 元素](https://docs.unity.cn/cn/2021.3/Manual/UIBasicLayout.html)），但也可用于操作 3D 游戏对象。此工具将移动、缩放和旋转功能整合到了同一个辅助图标中：

- 在矩形辅助图标中单击并拖动可移动游戏对象。
- 单击并拖动矩形辅助图标的任何角或边可缩放游戏对象。
- 拖动某条边可沿一个轴缩放游戏对象。
- 拖动某个角可在两个轴上缩放游戏对象。
- 要旋转游戏对象，请将光标放在矩形的某个角之外。光标变为显示旋转图标。单击并从此区域拖动可旋转游戏对象。

请注意，在 2D 模式下，无法使用辅助图标更改场景中的 z 轴。但是，某些脚本技术可将 z 轴用于其他目的，因此仍然可以使用 Inspector 中的变换组件设置 z 轴。

有关变换游戏对象的更多信息，请参阅关于[变换组件](https://docs.unity.cn/cn/2021.3/Manual/class-Transform.html)的文档。

### 变换

**变换__工具组合了__移动**、**旋转__和__缩放__工具。该工具的辅助图标提供了用于移动和旋转的控制柄。当** Tool Handle Rotation__ 设置为 __Local__（见下方）时，变换组件工具还提供用于缩放所选游戏对象的控制柄。

### 自定义工具

如果您的项目使用自定义 Editor 工具，则其中一些可能还允许您放置游戏对象。

You can access custom tools from the **Editor Tools** dropdown menu in the Scene view **Tools** toolbar Overlay.

![](https://docs.unity.cn/cn/2021.3/uploads/Main/scene-view-custom-tools-overlay.png)

如需了解更多信息，请参阅有关[使用自定义 Editor 工具](https://docs.unity.cn/cn/2021.3/Manual/UsingCustomEditorTools.html)的文档。

## 辅助图标控制柄位置开关

![Tool Settings Overlay](https://docs.unity.cn/cn/2021.3/uploads/Main/gizmo-handle-position-toggles.png)

Tool Settings Overlay

The **Gizmo handle position toggles** found in the Tool Settings [Overlay](https://docs.unity.cn/cn/2021.3/Manual/overlays.html) are used to define the location of any Transform tool Gizmo, and the handles used to manipulate the Gizmo itself.

![](https://docs.unity.cn/cn/2021.3/uploads/Main/gizmo-handle-position-toggles-menu.png)

### 位置

Use the dropdown menu to switch between **Pivot** and **Center**.

- **Pivot** 将辅助图标定位在游戏对象的实际轴心点（由变换组件进行定义）。
- **Center** 将辅助图标定位在中心位置（根据所选游戏对象）。

### 旋转

Use the dropdown menu to switch between **Local** and **Global**.

- **Local** 保持辅助图标相对于游戏对象的旋转。
- **Global** 将辅助图标固定在世界空间方向。

## 对齐

Unity 提供了三种对齐方式：

- [世界网格对齐](https://docs.unity.cn/cn/2021.3/Manual/GridSnapping.html)：将游戏对象对齐到沿 X、Y 或 Z 轴投影的网格，或将游戏对象沿 X、Y 或 Z 轴进行递增变换。仅当使用世界 (World) 或全局 (Global) 控制柄方向时，这种对齐方式才可用。
- [表面对齐](https://docs.unity.cn/cn/2021.3/Manual/PositioningGameObjects.html#SrfSnapping)：将游戏对象对齐到任何__碰撞体__的交点。
- [顶点对齐](https://docs.unity.cn/cn/2021.3/Manual/PositioningGameObjects.html#VtxSnapping)：将任何顶点从给定网格对齐到另一个网格的顶点或表面的位置。可将顶点对齐到顶点，将顶点对齐到表面，将轴心对齐到顶点。
- [[网格对齐]]

### 表面对齐

使用__移动__工具在中心拖动时，按住 **Shift** 和 **Control__（Mac 上为** Command__）可快速将游戏对象对齐到任何__碰撞体__的交叉点。

### 顶点对齐

使用__顶点对齐__可快速组合场景：从给定的网格中获取任何顶点，并将该顶点放置在与您选择的任何其他网格中的任何顶点相同的位置。例如，使用顶点对齐在赛车游戏中精确对齐路段，或者在网格的顶点定位能量块。

按照以下步骤使用顶点对齐：

1. 选择要操作的网格，并确保__移动__工具处于活动状态。
    
2. 按住 **V** 键激活顶点对齐模式。
    
3. 将光标移动到网格上要用作轴心点的顶点上。
    
4. 当光标位于所需顶点上方时按住鼠标左键，将网格拖动到另一个网格上的任何其他顶点旁边。
    
    要将顶点对齐到另一个网格上的表面，请添加并按下 **Shift+Ctrl** (Windows) 或 **Shift+Command** (macOS) 键，同时移动到要对齐到的表面上。
    
    要将轴心对齐到另一个网格上的顶点，请添加并按住 **Ctrl** (Windows) 或 **Command** (macOS) 键，同时将光标移动到要对齐到的顶点上。
    
5. 对结果感到满意时，松开鼠标按键和 **V** 键（__Shift+V__ 用作此功能的开关）。
    

## 观察旋转

使用__旋转__工具时，按住 **Shift** 和 **Control__（Mac 上为** Command__）可将游戏对象朝任何__碰撞体__表面上的一个点旋转。

## 屏幕空间变换

使用__变换__工具时，按住 **Shift** 键启用屏幕空间 (Screen Space) 模式。当游戏对象出现在屏幕上而不是在场景中时，可使用此模式来移动、旋转和缩放游戏对象。

---

- 在 [2017.3](https://docs.unity.cn/2017.3/Documentation/Manual/30_search.html?q=newin20173) 中添加了变换组件工具
- 在 [2018.3](https://docs.unity.cn/2018.3/Documentation/Manual/30_search.html?q=newin20183) 版中添加了子游戏对象的选择轮廓 (Selection Outline)
- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了用于访问自定义 Editor 工具的按钮和菜单
- 在 [2019.3](https://docs.unity.cn/2019.3/Documentation/Manual/30_search.html?q=newin20193) 中添加了本地网格
- Gizmo handles moved to Tool Settings Overlays in [2021.2](https://docs.unity.cn/2021.2/Documentation/Manual/30_search.html?q=newin20212)