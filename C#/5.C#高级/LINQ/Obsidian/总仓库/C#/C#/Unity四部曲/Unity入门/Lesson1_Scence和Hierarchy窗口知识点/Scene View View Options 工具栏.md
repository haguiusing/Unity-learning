# Scene View View Options 工具栏

您可以使用 Scene 视图的 View Options 工具栏 Overlay 来选择查看场景以及启用/禁用照明和音频的各种选项。这些控件仅在开发过程中影响 Scene 视图，对构建的游戏没有影响。

![](https://docs.unity.cn/cn/2021.3/uploads/Main/SceneViewControlBar.png)

## 绘制模式 （Draw mode） 菜单

第一个下拉菜单选择要用于描绘场景的__绘制模式__。 可用选项为：

|**绘制模式**||**功能**|
|---|---|---|
|**着色模式**|||
||阴影|显示表面时使纹理可见。|
||线框|使用线框表示形式绘制网格。|
||着色线框|显示网格纹理并叠加线框|
|**杂项**|||
||Shadow Cascades|显示方向光[阴影级联](https://docs.unity.cn/cn/2021.3/Manual/shadow-cascades.html)。|
||渲染路径|使用颜色代码显示每个游戏对象的[渲染路径](https://docs.unity.cn/cn/2021.3/Manual/RenderingPaths.html)：  <br>  <br>蓝色表示[延迟着色](https://docs.unity.cn/cn/2021.3/Manual/RenderTech-DeferredShading.html)  <br>绿色表示[延迟光照](https://docs.unity.cn/cn/2021.3/Manual/RenderTech-DeferredLighting.html)  <br>黄色表示[前向渲染](https://docs.unity.cn/cn/2021.3/Manual/RenderTech-ForwardRendering.html)  <br>红色表示[顶点光照](https://docs.unity.cn/cn/2021.3/Manual/RenderTech-VertexLit.html)|
||Alpha 通道|以 Alpha 渲染颜色。|
||透支|将游戏对象渲染为透明的“轮廓”。 透明的颜色会累积，因此可以轻松找到一个对象绘制在另一个对象上的位置。|
||Mipmap|使用颜色代码显示理想的纹理大小：  <br>  <br>红色表示纹理大于必要值（在当前距离和分辨率下）  <br>蓝色表示纹理可以更大。 理想的纹理大小取决于应用程序运行时采用的分辨率以及摄像机与特定表面的接近程度。|
||纹理流|根据游戏对象在[纹理串流](https://docs.unity.cn/cn/2021.3/Manual/TextureStreaming.html) 系统中的状态，将游戏对象着色为绿色、红色或蓝色。 如需了解更多信息，请参阅有关[纹理串流调试](https://docs.unity.cn/cn/2021.3/Manual/TextureStreaming-API.html#Debugging)的文档。|
||精灵遮罩 （Sprite Mask）|精灵遮罩用于隐藏或显示精灵或精灵组的各个部分。 有关更多信息，请参阅[精灵遮罩](https://docs.unity.cn/cn/2021.3/Manual/class-SpriteMask.html)。|
|**递 延**||通过这些模式，可以单独查看 G 缓冲区的每个元素（**Albedo**、**Specular**、**Smoothness** 和 **Normal**）。 请参阅有关[延迟着色](https://docs.unity.cn/cn/2021.3/Manual/RenderTech-DeferredShading.html)的文档以了解更多信息。|
|**全局照明**||可使用以下模式来可视化[全局光照](https://docs.unity.cn/cn/2021.3/Manual/lighting-window.html)系统的各个方面：**Systems**、**Clustering**、**Lit Clustering**、**UV Charts** 和 **Contributors/Receivers**。请参阅有关 [GI 可视化](https://docs.unity.cn/cn/2021.3/Manual/GIVis.html)的文档以了解每种模式。|
|**实时全局光照**||以下模式可用于帮助可视化 [Enlighten 实时全局照明](https://docs.unity.cn/cn/2021.3/Manual/realtime-gi-using-enlighten.html)系统的各个方面：**反照率**、**自发光**、**间接**和**方向性**。有关每种模式的信息，请参阅有关 [GI 可视化的文档](https://docs.unity.cn/cn/2021.3/Manual/GIVis.html)。|
|**烘焙全局光照**||可使用以下模式来可视化烘焙全局光照系统的各个方面：**Baked Light Map**、**Directionality**、**Shadowmask**、**Albedo**、**Emissive**、**UV Charts**、**Texel Validity**、**UV Overlap**、**Baked Lightmap Culling**、**Lightmap Indices** 和 **Light Overlap**。请参阅有关 [GI 可视化](https://docs.unity.cn/cn/2021.3/Manual/GIVis.html)的文档以了解每种模式。|
|**材质验证器**||**材质验证器 (Material Validator)** 有两种模式：**Albedo** 和 **Metal Specular**。 使用这些模式可以检查基于物理的材质是否使用建议范围内的值。 请参阅[基于物理的材质验证器](https://docs.unity.cn/cn/2021.3/Manual/MaterialValidator.html)以了解更多信息。|

## 2D、照明和音频开关

在 **Render Mode** 菜单的右侧有三个按钮，用于打开或关闭 Scene 视图的某些选项：

- **2D**：在场景的 2D 和 3D 视图之间切换。 在 2D 模式下，摄像机朝向正 z 方向，x 轴指向右方，y 轴指向上方。
- **Lighting**：打开或关闭 Scene 视图光照（光源、对象着色等）。
- **Audio**：打开或关闭 Scene 视图音频效果。

## “效果”按钮和菜单

菜单（由 **Audio** 按钮右侧的图标激活）包含用于在 Scene 视图中启用或禁用渲染效果的选项。

- **Skybox**：在场景的背景中渲染的天空盒纹理
- **Fog**：视图随着与摄像机之间的距离变远而逐渐消褪到单调颜色。
- **Flares**：光源上的镜头光晕。
- **Always Refresh**：定义动画化的材质是否显示动画。 选中后，任何基于时间的效果（例如，着色器）都将成为动画。 例如，场景效果（如在地形上舞动的草）。
- **后期处理**：添加[后期处理](https://docs.unity.cn/cn/2021.3/Manual/PostProcessingOverview.html)效果。
- **粒子系统**：显示 [粒子系统](https://docs.unity.cn/cn/2021.3/Manual/ParticleSystems.html)效果。

**Effects** 按钮本身充当一个开关，可同时启用或禁用所有选定的效果。

## 场景可见性开关

Scene visibility 开关用于打开和关闭游戏对象的 Scene visibility 。启用后，Unity 会应用 Scene visibility 设置。关闭后，Unity 会忽略它们。

如需了解更多信息，请参阅[场景可见性](https://docs.unity.cn/cn/2021.3/Manual/SceneVisibility.html)文档。

## Camera settings 菜单

摄像机设置菜单包含用于配置 Scene 视图摄像机的选项。 如需了解更多信息，请参阅[摄像机设置](https://docs.unity.cn/cn/2021.3/Manual/SceneViewCamera.html)文档。

## Gizmos 菜单

Gizmos 菜单包含有关对象、图标和 Gizmo 显示方式的选项。此菜单在 Scene 视图和 [Game 视图中](https://docs.unity.cn/cn/2021.3/Manual/GameView.html)均可用。有关更多信息，请参阅 [Gizmos Menu](https://docs.unity.cn/cn/2021.3/Manual/GizmosMenu.html) 手册页上的文档。

- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了场景可见性开关
- 在 2019.1 中添加了 Scene 视图摄像机设置
- 在 2019.1 中添加了 Component Editor Tools 面板开关
- 工具栏在 2021.2 中移至 Overlays