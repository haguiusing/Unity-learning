[Lesson14_画线功能LineRenderer](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%E5%9F%BA%E7%A1%80/Lesson14_%E7%94%BB%E7%BA%BF%E5%8A%9F%E8%83%BDLineRenderer/Lesson14_%E7%94%BB%E7%BA%BF%E5%8A%9F%E8%83%BDLineRenderer.cs)
![[Pasted image 20240914142827.png]]
![[Pasted image 20240914142535.png]]
![[Pasted image 20240914142603.png]]
![[Pasted image 20240914142628.png]]
![[Pasted image 20240914142704.png]]
# Line Renderer component

**线渲染器 (Line Renderer)** 组件采用 3D 空间中两个或多个点的数组，在每个点之间绘制一条直线。可以使用线渲染器 (Line Renderer) 来绘制从简单直线到复杂螺旋线的任何线条。

这条线始终是连续的；如果需要绘制两条或更多完全独立的线，则应使用多个游戏对象，每个游戏对象都要有自己的线渲染器 (Line Renderer)。

线渲染器 (Line Renderer) 不渲染宽度以像素为单位的线。它会渲染宽度以世界单位为单位的多边形。线渲染器 (Line Renderer) 使用与[轨迹渲染器 (Trail Renderer)](https://docs.unity3d.com/cn/current/Manual/class-TrailRenderer.html) 相同的线渲染算法。

## 准备开始

要创建线渲染器，请执行以下操作：

1. 在 Unity 菜单栏中，选择 **GameObject** > **Effects** > **Line**。
2. 选择 Line Renderer 游戏对象。
3. 通过在 Inspector 窗口中直接设置数组值或使用 Create Points [场景编辑模式](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#SceneEditingMode)，可以将点添加到 Line Renderer 的 Positions 数组中。
4. 使用 Inspector 窗口配置线条的颜色、宽度和其他显示设置。

![Line Renderer 配置示例](https://docs.unity3d.com/cn/current/uploads/Main/LineRenderer-example.jpg)

Line Renderer 配置示例

## 线渲染器材质 (Line Renderer Materials)

默认情况下，线渲染器 (Line Renderer) 使用内置材质 **Default-Line**。您可以更改线条的外观而无需更改此材质，例如编辑线条的颜色渐变或宽度。

对于其他效果，例如在线条上应用纹理，需要使用其他材质。如果您不想为新材质编写自己的着色器，可以将 Unity 内置的[标准粒子着色器](https://docs.unity3d.com/cn/current/Manual/shader-StandardParticleShaders.html)与线渲染器 (Line Renderer) 结合使用。

请参阅[创建和使用材质](https://docs.unity3d.com/cn/current/Manual/Materials.html)以了解更多信息。

## 线渲染器场景编辑模式 (Line Renderer Scene Editing Mode)

可以使用线渲染器 (Line Renderer) 的 Inspector 来更改场景编辑模式。不同的场景编辑模式让您能够以不同的方式使用 Scene 视图和 Inspector 来编辑线渲染器 (Line Renderer)。

有三种场景编辑模式：**None**、**Edit Points** 和 **Create Points**。

### 设置场景编辑模式

![Line Renderer Edit Points 和 Create Points 按钮](https://docs.unity3d.com/cn/current/uploads/Main/line-renderer-scene-editing-mode.png)

Line Renderer Edit Points 和 Create Points 按钮

使用 Inspector 顶部的 **Edit Points** 和 **Create Points** 按钮可以设置当前的场景编辑模式。

单击 **Edit Points** 按钮可以将场景编辑模式设置为 **Edit Points**。再次单击该按钮可以将场景编辑模式设置为 **None**。

单击 **Create Points** 按钮可以将场景编辑模式设置为 **Create Points**。再次单击该按钮可以将场景编辑模式设置为 **None**。

### 场景编辑模式：None

![Line Renderer Simplify 控件](https://docs.unity3d.com/cn/current/uploads/Main/line-renderer-simplify.png)

Line Renderer Simplify 控件

如果未选择场景编辑模式，则可以配置并执行简化操作，从 Positions 数组中删除不必要的点。

Inspector 中会显示以下控件：

|**控件**|**描述**|
|---|---|
|**Simplify Preview**|启用 **Simplify Preview** 可以查看简化操作结果的预览。|
|**Tolerance**|设置简化线可以偏离原始线的偏差量。  <br>  <br>值为 0 不会导致偏差，因此几乎没有简化。较高的正值会导致与原始线的偏差更大，因此更加简化。  <br>  <br>默认值为 1。|
|**Simplify**|单击 **Simplify** 可以减少线渲染器 (Line Renderer) 的 **Positions** 数组中的元素数量。  <br>  <br>简化操作使用 [Ramer-Douglas-Peucker 算法](https://en.wikipedia.org/wiki/Ramer%E2%80%93Douglas%E2%80%93Peucker_algorithm)根据 **Tolerance** 值来减少点数。|

### 场景编辑模式：Edit Points

![线渲染器 (Line Renderer) 处于 Edit Points 场景编辑模式](https://docs.unity3d.com/cn/current/uploads/Main/line-renderer-edit-points.png)

线渲染器 (Line Renderer) 处于 Edit Points 场景编辑模式

当场景编辑模式设置为 **Edit Points** 时，Unity 在 Scene 视图中将线渲染器 (Line Renderer) 的 Positions 数组中的每个点表示为黄色球形。可以使用移动工具移动各个点。

Inspector 中会显示以下控件：

|**控件**|**描述**|
|---|---|
|**Show Wireframe**|启用此设置后，Unity 会在 Scene 视图中绘制线框以使线条显示出来。|
|**Subdivide Selected**|选择两个或多个相邻点时将会启用此按钮。按下此按钮将在选定的相邻点之间插入一个新点。|

### 场景编辑模式：Create Points

![线渲染器 (Line Renderer) 处于 Create Points 场景编辑模式](https://docs.unity3d.com/cn/current/uploads/Main/line-renderer-create-points.png)

线渲染器 (Line Renderer) 处于 Create Points 场景编辑模式

当场景编辑模式设置为 **Create Points** 时，可以在 Scene 视图中单击以将新点添加到线渲染器 (Line Renderer) 的 Positions 数组的末尾。

Inspector 中会显示以下控件：

|**控件**|   |**描述**|
|---|---|---|
|**Input**|   |设置要用于创建点的输入法。|
||**Mouse position**|根据鼠标在 Scene 视图中的位置创建点。|
||**Physics Raycast**|根据场景中的[射线投射](https://docs.unity3d.com/cn/current/ScriptReference/Physics.Raycast.html)创建点。Unity 在射线投射到的位置创建点。|
|**Layer Mask**|   |执行射线投射时要使用的图层遮罩。仅当 **Input** 设置为 **Physics Raycast** 时，此属性才可见。|
|**Min Vertex Distance**|   |拖动鼠标以在 Scene 视图中创建点时，如果与最后一个点之间的距离超过此距离，则线渲染器 (Line Renderer) 将创建一个新点。|
|**Offset**|   |应用于所创建的点的偏移量。当 **Input** 设置为 **Mouse Position** 时，线渲染器 (Line Renderer) 将应用来自场景摄像机的偏移量。当 Input 设置为 **Physics Raycast** 时，线渲染器 (Line Renderer) 将应用来自射线投射法线的偏移量。|

## Line Renderer Inspector reference

![](https://docs.unity3d.com/cn/current/uploads/Main/Inspector-LineRenderer.png)

本节包含以下小节：

- [Line settings](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#line-settings)
- [Materials](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#materials)
- [Lighting](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#lighting)
- [Probes](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#probes)
- [Additional Settings](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html#additional-settings)

### 线设置 (Line settings)

| **属性**                     |                          | **功能**                                                                                                                                           |
| -------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Loop**                   |                          | 启用此属性可连接线的第一个和最后一个位置并形成一个闭环。                                                                                                                     |
| **Positions**              |                          | 要连接的 Vector3 点的数组。                                                                                                                               |
| **Width**                  |                          | 定义宽度值和曲线值以控制线沿其长度的宽度。  <br>  <br>曲线是在每个顶点处采样的，因此其精度受制于线中的顶点数量。线的总宽度由宽度值控制。                                                                       |
| **Color**                  |                          | 定义一个渐变来控制线沿其长度的颜色。  <br>  <br>Unity 在每个顶点处从颜色渐变 (Color Gradient) 中采样颜色。在每个顶点之间，Unity 对颜色应用线性插值。向线添加更多顶点可能会更接近详细的渐变。                              |
| **Corner Vertices**        |                          | 此属性指示在绘制线中的角时使用多少个额外顶点。增加此值可使线的角显得更圆。                                                                                                            |
| **End Cap Vertices**       |                          | 此属性指示使用多少个额外顶点在线上创建端盖。增加此值可使线的端盖显得更圆。                                                                                                            |
| **Alignment**              |                          | 设置线面向的方向。                                                                                                                                        |
|                            | **View**                 | 线面向摄像机。                                                                                                                                          |
|                            | **TransformZ**           | 线朝向其变换组件的 Z 轴。                                                                                                                                   |
| **Texture Mode**           |                          | 控制如何将纹理应用于线。                                                                                                                                     |
|                            | **Stretch**              | 沿线的整个长度映射纹理一次。                                                                                                                                   |
|                            | **Tile**                 | 基于线长度（采用世界单位）沿线重复纹理。要设置平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。    |
|                            | **DistributePerSegment** | 沿线的整个长度映射纹理一次（假设所有顶点均匀分布）。                                                                                                                       |
|                            | **RepeatPerSegment**     | 沿线重复纹理（按每个线细分段一次的比率重复）。要调整平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。 |
| **Shadow Bias**            |                          | 设置沿着光照方向的阴影移动量以消除因使用公告牌几何体来模拟体积而导致的阴影瑕疵。                                                                                                         |
| **Generate Lighting Data** |                          | 如果启用此属性，Unity 在构建线几何体时包含法线和切线。这样，线几何体就可以使用采用了场景光照的材质。                                                                                            |
| **Use World Space**        |                          | 如果启用此属性，这些点被视为世界空间坐标。如果禁用此属性，这些点位于此组件附加到的游戏对象的变换组件本地。                                                                                            |

### 材质

**Materials** 部分列出了此组件使用的所有[材质](https://docs.unity3d.com/cn/current/Manual/class-Material.html)。

|**属性**|**描述**|
|---|---|
|**Size**|The number of elements in the material list.  <br>  <br>If you decrease the number of elements, Unity deletes the elements at the end of the list. If you increase the number of elements, Unity adds new elements to the end of the list. Unity populates new elements with the same material that the element at the end of the list uses.|
|**Element**|The materials in the list. You can assign a material asset to each element.  <br>  <br>By default, Unity orders the list alphabetically based on the name of the materials. This list is reorderable, and Unity updates the number of the elements automatically as you change their order.|

## 光照

**Lighting** 部分包含与光照相关的属性。

|**属性**|   |**描述**|
|---|---|---|
|**Cast Shadows**|   |Specify if and how this Renderer casts shadows when a suitable [Light](https://docs.unity3d.com/cn/current/Manual/class-Light.html) shines on it.  <br>  <br>This property corresponds to the [Renderer.shadowCastingMode](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-shadowCastingMode.html) API.|
||**On**|This Renderer casts a shadow when a shadow-casting Light shines on it.|
||**Off**|This Renderer does not cast shadows.|
||**Two-sided**|This Renderer casts two-sided shadows. This means that single-sided objects like a plane or a quad can cast shadows, even if the light source is behind the mesh.  <br>  <br>For [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) or Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) to support two-sided shadows, the material must support [Double Sided Global Illumination](https://docs.unity3d.com/Manual/class-Material.html).|
||**Shadows Only**|This Renderer casts shadows, but the Renderer itself isn’t visible.|
|**Receive Shadows**|   |Specify if Unity displays shadows cast onto this Renderer.  <br>  <br>This property only has an effect if you enable [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) or Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) for this scene.  <br>  <br>This property corresponds to the [Renderer.receiveShadows](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-receiveShadows.html) API.|
|**Contribute Global Illumination**|   |Include this Renderer in global illumination calculations, which take place at bake time.  <br>  <br>This property only has an effect if you enable [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) or Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) for this scene.  <br>  <br>Enabling this property enables the Contribute GI flag in the GameObject’s [Static Editor Flags](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html). It corresponds to the [StaticEditorFlags.ContributeGI](https://docs.unity3d.com/cn/current/ScriptReference/StaticEditorFlags.ContributeGI.html) API.|
|**Receive Global Illumination**|   |Whether Unity provides global illumination data to this Renderer from baked lightmaps, or from runtime Light Probes.  <br>  <br>This property is only editable if you enable **Contribute Global Illumination**. It only has an effect if you enable [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) or Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) for this scene.  <br>  <br>This property corresponds to the [MeshRenderer.receiveGI](https://docs.unity3d.com/cn/current/ScriptReference/MeshRenderer-receiveGI.html) API.|
||**Lightmaps**|Unity provides global illumination data to this Renderer from lightmaps.|
||**Light Probes**|Unity provides global illumination data to this Renderer from [Light Probes](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) in the scene.|
|**Prioritize Illumination**|   |Enable this property to always include this Renderer in Enlighten Realtime Global Illumination calculations. This ensures that the Renderer is affected by distant emissives, even those which are normally excluded from Global Illumination calculations for performance reasons.  <br>  <br>This property is visible only if **Contribute GI** is enabled in the GameObject’s [Static Editor Flags](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html), your project uses the Built-in Render Pipeline, and Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) is enabled in your scene.|

### Probes

**Probes** 部分包含与[光照探针](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) 和[反射探针](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html)有关的属性。

|**属性**|   |**描述**|
|---|---|---|
|**Light Probes**|   |Set how this Renderer receives light from the [Light Probes](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) system.  <br>  <br>This property corresponds to the [Renderer.lightProbeUsage](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-lightProbeUsage.html) API.|
||**Off**|The Renderer doesn’t use any interpolated Light Probes.|
||**Blend Probes**|The Renderer uses one interpolated Light Probe. This is the default value.|
||**Use Proxy Volume**|The Renderer uses a 3D grid of interpolated Light Probes.|
||**Custom Provided**|The Renderer extracts Light Probe shader uniform values from the [MaterialPropertyBlock](https://docs.unity3d.com/cn/current/ScriptReference/MaterialPropertyBlock.html).|
|**Proxy Volume Override**|   |Set a reference to another GameObject that has a Light Probe Proxy Volume component.  <br>  <br>This property is only visible when **Light Probes** is set to **Use Proxy Volume**.|
|**Reflection Probes**|   |Set how the Renderer receives reflections from the [Reflection Probe](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html) system.  <br>  <br>This property corresponds to the [Renderer.probeAnchor](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-probeAnchor.html) API.|
||**Off**|Disables Reflection Probes. Unity uses a skybox for reflection.|
||**Blend Probes**|Enables Reflection Probes. Blending occurs only between Reflection Probes. This is useful in indoor environments where the character may transition between areas with different lighting settings.|
||**Blend Probes and Skybox**|Enables Reflection Probes. Blending occurs between Reflection Probes, or between Reflection Probes and the default reflection. This is useful for outdoor environments.|
||**Simple**|Enables Reflection Probes, but no blending occurs between Reflection Probes when there are two overlapping volumes.|
|**Anchor Override**|   |Set the Transform that Unity uses to determine the interpolation position when using the [Light Probe](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) or [Reflection Probe](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html) systems. By default, this is the centre of the bounding box of the Renderer’s geometry.  <br>  <br>This property corresponds to the [Renderer.probeAnchor](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-probeAnchor.html) API.|

### Additional Settings

**Additional Settings** 部分包含额外的属性。

|**Property**|   |**Description**|
|---|---|---|
|**Motion Vectors**|   |Set whether to use motion vectors to track this Renderer’s per-pixel, screen-space motion from one frame to the next. You can use this information to apply post-processing effects such as motion blur.  <br>  <br>**Note:** not all platforms support motion vectors. See [SystemInfo.supportsMotionVectors](https://docs.unity3d.com/cn/current/ScriptReference/SystemInfo-supportsMotionVectors.html) for more information.  <br>  <br>This property corresponds to the [Renderer.motionVectorGenerationMode](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-motionVectorGenerationMode.html) API.|
||**Camera Motion Only**|Use only Camera movement to track motion.|
||**Per Object Motion**|Use a specific pass to track motion for this Renderer.|
||**Force No Motion**|Do not track motion.|
|**Dynamic Occlusion**|   |When **Dynamic Occlusion** is enabled, Unity’s [occlusion culling](https://docs.unity3d.com/cn/current/Manual/OcclusionCulling.html) system culls this Renderer when it is blocked from a Camera’s view by a Static Occluder. Otherwise, the system does not cull this Renderer when it is blocked from a Camera’s view by a Static Occluder.  <br>  <br>Dynamic Occlusion is enabled by default. Disable it for effects such as drawing the outline of a character behind a wall.|
|**Sorting Layer**|   |The name of this Renderer’s [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html).|
|**Order in Layer**|   |This Renderer’s order within a [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html).|