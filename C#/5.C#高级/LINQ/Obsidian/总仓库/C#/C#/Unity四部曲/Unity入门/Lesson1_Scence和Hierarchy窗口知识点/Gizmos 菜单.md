# Gizmos 菜单/辅助图标

[Scene 视图](https://docs.unity.cn/cn/2021.3/Manual/UsingTheSceneView.html)和 [Game 视图](https://docs.unity.cn/cn/2021.3/Manual/GameView.html)都有 **Gizmos** 菜单。单击 Scene 视图或 Game 视图的工具栏中的 **Gizmos** 按钮，即可访问 **Gizmos** 菜单。

![The Gizmos button in the Scene view](https://docs.unity.cn/cn/2021.3/uploads/Main/gizmo-button-scene-view.png)

The **Gizmos** button in the Scene view

![The Gizmos button in the Game view](https://docs.unity.cn/cn/2021.3/uploads/Main/gizmo-button-game-view.png)

The **Gizmos** button in the Game view

![Scene 视图或 Game 视图窗口之上的 Gizmos 菜单](https://docs.unity.cn/cn/2021.3/uploads/Main/GizmosMenu.png)

Scene 视图或 Game 视图窗口之上的 Gizmos 菜单

|**属性**|**功能**|
|---|---|
|**3D Icons**|**3D Icons** 复选框控制是否在 Scene 视图中由 Editor 绘制 3D 组件图标（例如光源和摄像机的图标）。  <br>  <br>勾选 **3D Icons** 复选框后，组件图标由 Editor 根据组件与摄像机的距离进行缩放，并被场景中的游戏对象遮挡。可使用滑动条来控制外观的总体大小。未勾选 **3D Icons** 复选框时，以固定大小绘制组件图标，且这些图标始终绘制在 Scene 视图中所有游戏对象之上。  <br>  <br>请参阅下面的[辅助图标和图标](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#GizmosIcons)以查看图像以及更多信息。|
|**Fade Gizmos**|Fade out and stop rendering gizmos that are small on screen.|
|**Selection Outline**|选中 **Selection Outline** 可以通过彩色轮廓来显示所选的游戏对象，并用另一种彩色轮廓显示其子项。默认情况下，Unity 以橙色突出显示所选游戏对象，而以蓝色突出显示子游戏对象。  <br>  <br>**注意：**此选项仅在 Scene 视图的 Gizmos 菜单中可用；无法在 Game 视图的 Gizmos 菜单中启用该选项。  <br>  <br>请参阅下面的 [Selection Outline 和 Selection Wire](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#SelectionOutlineWire) 以查看图像以及更多信息。|
|**Selection Wire**|Check **Selection Wire** to show the selected GameObjects with their wireframe Mesh visible. To change the colour of the Selection Wire, go to **Unity** > **Preferences** (macOS) or **Edit** > **Preferences** (Windows), select **Colors**, and alter the **Selected Wireframe** setting.  <br>  <br>This option is only available in the Scene view Gizmos menu; you cannot enable it in the Game view Gizmos menu.  <br>  <br>See [Selection Outline and Selection Wire](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#SelectionOutlineWire), below, for images and further information.|
|**Recently Changed**|控制最近修改的组件和脚本是否显示图标和辅助图标。  <br>  <br>此部分在您第一次更改一个或多个项时出现，并在后续更改后更新。  <br>  <br>有关更多信息，请参阅下面的[内置组件、脚本和最近更改的项](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#Components)。|
|**Scripts**|控制场景中的脚本是否显示图标和辅助图标。  <br>  <br>仅当您的场景使用满足特定条件的脚本时才会显示此部分。  <br>  <br>请参阅下面的[内置组件、脚本和最近更改的项](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#Components)以了解更多信息。|
|**Built-in Components**|控制具有图标或辅助图标的所有组件类型是否显示图标和辅助图标。  <br>  <br>请参阅下面的[内置组件、脚本和最近更改的项](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#Components)以了解更多信息。|

## 辅助图标和图标

### 辅助图标

**辅助图标**是与场景中的游戏对象相关联的图形。有些辅助图标仅在选择游戏对象时才会显示，而其他辅助图标由 Editor 显示（无论选择什么游戏对象）。这些辅助图标通常是线框，使用代码而不是位图图形来绘制，还可以交互。**摄像机**辅助图标和**光线方向**辅助图标（如下图所示）是内置辅助图标的两个示例；还可以使用脚本来创建自己的辅助图标。请参阅[了解视锥体](https://docs.unity.cn/cn/2021.3/Manual/UnderstandingFrustum.html)相关文档以了解有关摄像机的更多信息。

有些辅助图标是被动图形覆盖层，显示来供参考（例如，**光线方向**辅助图标用于显示光线的方向）。其他辅助图标具有交互性，例如[音频源 (AudioSource)](https://docs.unity.cn/cn/2021.3/Manual/class-AudioSource.html) **球形范围**辅助图标，可以单击并拖动此辅助图标来调整音频源的最大范围。

**移动**、**缩放**、**旋转**和**变换**工具也是交互式辅助图标。请参阅关于[游戏对象定位](https://docs.unity.cn/cn/2021.3/Manual/PositioningGameObjects.html)的文档以了解关于这些工具的更多信息。

![摄像机辅助图标和光源辅助图标。这些辅助图标仅在被选中时才可见。](https://docs.unity.cn/cn/2021.3/uploads/Main/IconAndGizmoForLightAndCamera.png)

摄像机辅助图标和光源辅助图标。这些辅助图标仅在被选中时才可见。

请参阅 [OnDrawGizmos](https://docs.unity.cn/cn/2021.3/ScriptReference/MonoBehaviour.OnDrawGizmos.html) 函数的脚本参考页面以了解关于在脚本中实现自定义辅助图标的更多信息。

### 图标

You can display **icons** in the Game view or Scene view. They are flat, billboard-style overlays which you can use to clearly indicate a GameObject’s position while you work on your game. The **Camera** icon and **Light** icon are examples of built-in icons; you can also assign your own to GameObjects or individual scripts (see documentation on [Assigning Icons](https://docs.unity.cn/cn/2021.3/Manual/InspectorOptions.html#assigning-icons) to learn how to do this).

![摄像机和光源的内置图标](https://docs.unity.cn/cn/2021.3/uploads/Main/GizmosMenu2.png)

摄像机和光源的内置图标

![Left: icons in 3D mode. Right: icons in 2D mode.](https://docs.unity.cn/cn/2021.3/uploads/Main/GizmoMenu2Dvs3Dicons.png)

**Left**: icons in 3D mode. **Right**: icons in 2D mode.

## Selection Outline 和 Selection Wire

### Selection Outline

启用 **Selection Outline** 后，所选游戏对象及其子游戏对象周围将显示轮廓。默认情况下，Unity 以橙色显示所选游戏对象的轮廓，而以蓝色显示子游戏对象的轮廓。可以在 Unity 偏好设置中更改这些颜色（请参阅下文的[选择颜色](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html#SelectionColors)）。

![选择的游戏对象（最左边的盒体）以橙色显示其轮廓，并以蓝色显示其子游戏对象（中间和右边的盒体）的轮廓。](https://docs.unity.cn/cn/2021.3/uploads/Main/GameObjectSelectedOutline.jpg)

选择的游戏对象（最左边的盒体）以橙色显示其轮廓，并以蓝色显示其子游戏对象（中间和右边的盒体）的轮廓。

选择游戏对象时，Unity 会显示其所有子游戏对象（以及它们的子游戏对象，依此类推）的轮廓，但不会显示父游戏对象（或它们的父游戏对象，依此类推）的轮廓。

![选择中间的盒体会以橙色突出显示该盒体，并以蓝色突出显示其子游戏对象（最右边的盒体），但不会突出显示其父游戏对象（最左边的盒体）。](https://docs.unity.cn/cn/2021.3/uploads/Main/GameObjectSelectedOutlineParentChild.jpg)

选择中间的盒体会以橙色突出显示该盒体，并以蓝色突出显示其子游戏对象（最右边的盒体），但不会突出显示其父游戏对象（最左边的盒体）。

如果所选的游戏对象延伸到 Scene 视图边缘之外，则选择轮廓 (Selection Outline) 将沿窗口边缘显示：

![](https://docs.unity.cn/cn/2021.3/uploads/Main/GameObjectSelectedBeyondEdges.png)

### Selection Wire

启用 **Selection Wire** 后，在 Scene 视图或 Hierarchy 窗口中选择游戏对象时，将在 Scene 视图中显示该游戏对象的线框网格：

![](https://docs.unity.cn/cn/2021.3/uploads/Main/GameObjectSelectedWire.png)

### 选择颜色

可为选择线框设置自定义颜色。

1. Go to **Unity** > **Preferences** (macOS) or **Edit** > **Preferences** (Windows) to open the [Preferences](https://docs.unity.cn/cn/2021.3/Manual/Preferences.html) editor.
2. 在 Colors 选项卡上，更改以下一种或多种颜色：
    - **Selected Children Outline**: outline color for selected GameObjects’ children.
    - **Selected Outline**: outline color for selected GameObjects.
    - **Wireframe Selected**: outline color for selected GameObjects’ wireframes.

![](https://docs.unity.cn/cn/2021.3/uploads/Main/game-object-selected-custom-colors.png)

## 内置组件、脚本和最近更改的项

使用 **Gizmos** 菜单中的列表可以控制各种组件是否显示图标和辅助图标。此列表分为多个部分：

![Gizmos 菜单显示了具有自定义图标的项以及最近修改的一些项](https://docs.unity.cn/cn/2021.3/uploads/Main/GizmosMenuAll.png)

Gizmos 菜单显示了具有自定义图标的项以及最近修改的一些项

### Recently Changed

The **Recently Changed** section controls the visibility of the icons and gizmos for items that you’ve modified recently. It appears the first time you change one or more items. Unity updates the list after subsequent changes.

### Scripts

The **Scripts** section controls the visibility of the icons and gizmos for scripts that:

- 为脚本分配了图标（请参阅关于[分配图标](https://docs.unity.cn/cn/2021.3/Manual/AssigningIcons.html)的文档）。
    
- 实现了 [OnDrawGizmos](https://docs.unity.cn/cn/2021.3/ScriptReference/MonoBehaviour.OnDrawGizmos.html) 函数。
    
- 实现了 [OnDrawGizmosSelected](https://docs.unity.cn/cn/2021.3/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html) 函数。
    

当场景包含一个或多个满足以上条件的脚本时，将显示此部分。

### Built-in Components

The **Built-in Components** section controls the visibility of the icons and gizmos for all component types that have an icon or gizmo.

此处不会列出在 Scene 视图中不显示图标或辅助图标的内置组件类型（例如刚体）。

### 切换图标可见性

**icon** 列显示或隐藏每个组件类型的图标。全彩色图标显示在主 Scene 视图窗口中，褪色的图标则不会显示。

![The Light icon is faded, indicating that the Editor does not display light icons in the Scene view. The Camera icon is full-color, indicating that the Editor does display camera icons in the Scene view.](https://docs.unity.cn/cn/2021.3/uploads/Main/gizmos-icon.png)

The **Light** icon is faded, indicating that the Editor does not display light icons in the Scene view. The **Camera** icon is full-color, indicating that the Editor does display camera icons in the Scene view.

要在 Scene 视图中切换图标的可见性，请单击 **icon** 列中的任何图标。

**注：**如果列表中的项具有辅助图标而没有图标，则该项的 **icon** 列为空。

### 更改脚本图标

带有自定义图标的脚本会在 **icon** 列中显示一个下拉菜单小箭头。要更改自定义图标，请单击该箭头以打开 [Select Icon](https://docs.unity.cn/cn/2021.3/Manual/InspectorOptions.html#assigning-icons) 菜单。

![](https://docs.unity.cn/cn/2021.3/uploads/Main/GizmosMenuIconsMenu.png)

### 切换辅助图标可见性

要控制 Editor 是否绘制特定组件类型或脚本的辅助图标图形（例如，**碰撞体**的线框辅助图标或**摄像机**的[视锥体](https://docs.unity.cn/cn/2021.3/Manual/UnderstandingFrustum.html)辅助图标），请使用 **Gizmo** 列中的复选框。

- 选中复选框后，Editor 将为该组件类型绘制辅助图标。
    
- 清除复选框后，Editor 不为该组件类型绘制辅助图标。
    

**注：**如果列表中的项具有图标而没有辅助图标，则该项的 **Gizmo** 列为空。

要切换整个部分的辅助图标可见性（所有 **Built-in Components**、所有 **Scripts**，等等），请使用相应部分的名称旁边的复选框。

The **Built-in Components** checkbox toggles gizmo visibility for every type of component listed in that section

选中复选框后，该部分的一个或多个项类型的辅助图标可见性就会启用。

---

- 在 [2018.3](https://docs.unity.cn/2018.3/Documentation/Manual/30_search.html?q=newin20183) 中添加了子游戏对象的选择轮廓线
    
- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了为一个部分的所有组件切换辅助图标可见性的辅助图标菜单选项