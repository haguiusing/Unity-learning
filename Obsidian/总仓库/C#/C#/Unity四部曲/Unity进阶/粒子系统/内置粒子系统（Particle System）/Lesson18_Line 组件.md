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

| **控件**               | **描述**                                                                                                                                                                                                                 |
| -------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Simplify Preview** | 启用 **Simplify Preview** 可以查看简化操作结果的预览。                                                                                                                                                                                 |
| **Tolerance**        | 设置简化线可以偏离原始线的偏差量。  <br>  <br>值为 0 不会导致偏差，因此几乎没有简化。较高的正值会导致与原始线的偏差更大，因此更加简化。  <br>  <br>默认值为 1。                                                                                                                         |
| **Simplify**         | 单击 **Simplify** 可以减少线渲染器 (Line Renderer) 的 **Positions** 数组中的元素数量。  <br>  <br>简化操作使用 [Ramer-Douglas-Peucker 算法](https://en.wikipedia.org/wiki/Ramer%E2%80%93Douglas%E2%80%93Peucker_algorithm)根据 **Tolerance** 值来减少点数。 |

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
### 线设置 (Line settings)

|**属性**|   |**功能**|
|---|---|---|
|**Loop**|   |启用此属性可连接线的第一个和最后一个位置并形成一个闭环。|
|**Positions**|   |要连接的 Vector3 点的数组。|
|**Width**|   |定义宽度值和曲线值以控制线沿其长度的宽度。  <br>  <br>曲线是在每个顶点处采样的，因此其精度受制于线中的顶点数量。线的总宽度由宽度值控制。|
|**Color**|   |定义一个渐变来控制线沿其长度的颜色。  <br>  <br>Unity 在每个顶点处从颜色渐变 (Color Gradient) 中采样颜色。在每个顶点之间，Unity 对颜色应用线性插值。向线添加更多顶点可能会更接近详细的渐变。|
|**Corner Vertices**|   |此属性指示在绘制线中的角时使用多少个额外顶点。增加此值可使线的角显得更圆。|
|**End Cap Vertices**|   |此属性指示使用多少个额外顶点在线上创建端盖。增加此值可使线的端盖显得更圆。|
|**Alignment**|   |设置线面向的方向。|
||**View**|线面向摄像机。|
||**TransformZ**|线朝向其变换组件的 Z 轴。|
|**Texture Mode**|   |控制如何将纹理应用于线。|
||**Stretch**|沿线的整个长度映射纹理一次。|
||**Tile**|基于线长度（采用世界单位）沿线重复纹理。要设置平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。|
||**DistributePerSegment**|沿线的整个长度映射纹理一次（假设所有顶点均匀分布）。|
||**RepeatPerSegment**|沿线重复纹理（按每个线细分段一次的比率重复）。要调整平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。|
|**Shadow Bias**|   |设置沿着光照方向的阴影移动量以消除因使用公告牌几何体来模拟体积而导致的阴影瑕疵。|
|**Generate Lighting Data**|   |如果启用此属性，Unity 在构建线几何体时包含法线和切线。这样，线几何体就可以使用采用了场景光照的材质。|
|**Use World Space**|   |如果启用此属性，这些点被视为世界空间坐标。如果禁用此属性，这些点位于此组件附加到的游戏对象的变换组件本地。|

### 材质

**Materials** 部分列出了此组件使用的所有[材质](https://docs.unity3d.com/cn/current/Manual/class-Material.html)。

|**属性**|**描述**|
|---|---|
|**Size**|材质列表中的元素数。  <br>  <br>如果减少元素数量，Unity 会删除列表末尾的元素。如果增加元素的数量，Unity 会将新元素添加到列表的末尾。Unity 使用列表末尾的元素使用的相同材料填充新元素。|
|**Element**|列表中的材料。您可以为每个元素分配一个 Material 资源。  <br>  <br>默认情况下，Unity 根据材质名称按字母顺序对列表进行排序。此列表是可重新排序的，并且 Unity 会在您更改元素的顺序时自动更新元素的数量。|

## 光照

**Lighting** 部分包含与光照相关的属性。

|**属性**|   |**描述**|
|---|---|---|
|**Cast Shadows**|   |指定当合适的 [Light](https://docs.unity3d.com/cn/current/Manual/class-Light.html) 照射到此 Renderer 上时，是否以及如何投射阴影。  <br>  <br>此属性对应于 [Renderer.shadowCastingMode](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-shadowCastingMode.html) API。|
||**On**|当投射阴影的 Light 照射到它上面时，此 Renderer 会投射阴影。|
||**Off**|此 Renderer 不投射阴影。|
||**Two-sided**|此 Renderer 投射双面阴影。这意味着平面或四边形等单面对象可以投射阴影，即使光源位于网格后面也是如此。  <br>  <br>要使 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 支持双面阴影，材质必须支持 [Double Sided Global Illumination。](https://docs.unity3d.com/Manual/class-Material.html)|
||**Shadows Only**|此 Renderer 投射阴影，但 Renderer 本身不可见。|
|**Receive Shadows**|   |指定 Unity 是否显示投射到此 Renderer 上的阴影。  <br>  <br>仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才有效。  <br>  <br>此属性对应于 [Renderer.receiveShadows](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-receiveShadows.html) API。|
|**Contribute Global Illumination**|   |将此 Renderer 包含在全局照明计算中，该计算在烘焙时进行。  <br>  <br>仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才有效。  <br>  <br>启用此属性将在游戏对象的 [Static Editor Flags](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html) 中启用 Contribute GI 标志。它对应于 [StaticEditorFlags.ContributeGI](https://docs.unity3d.com/cn/current/ScriptReference/StaticEditorFlags.ContributeGI.html) API。|
|**Receive Global Illumination**|   |Unity 是从烘焙光照贴图还是从运行时光照探针向此渲染器提供全局光照数据。  <br>  <br>仅当启用 **Contribute Global Illumination** 时，此属性才可编辑。仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，它才有效。  <br>  <br>此属性对应于 [MeshRenderer.receiveGI](https://docs.unity3d.com/cn/current/ScriptReference/MeshRenderer-receiveGI.html) API。|
||**Lightmaps**|Unity 从光照贴图向此渲染器提供全局照明数据。|
||**Light Probes**|Unity 从场景中的[光照探针](https://docs.unity3d.com/cn/current/Manual/LightProbes.html)向此渲染器提供全局照明数据。|
|**Prioritize Illumination**|   |启用此属性后，在 Enlighten Realtime Global Illumination 计算中将始终包含此渲染器。这可确保 Renderer 受远处自发光的影响，即使是那些通常出于性能原因而被排除在 Global Illumination 计算之外的自发光。  <br>  <br>只有在游戏对象的[静态编辑器标志](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html)中启用了 **Contribute GI**，项目使用内置渲染管道，并在场景中启用了 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才可见。|

### Probes

**Probes** 部分包含与[光照探针](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) 和[反射探针](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html)有关的属性。

|**属性**|   |**描述**|
|---|---|---|
|**Light Probes**|   |设置此渲染器从 [Light Probes](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) 系统接收光线的方式。  <br>  <br>此属性对应于 [Renderer.lightProbeUsage](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-lightProbeUsage.html) API。|
||**Off**|渲染器不使用任何插值光照探针。|
||**Blend Probes**|渲染器使用一个插值光照探针。这是默认值。|
||**Use Proxy Volume**|Renderer 使用插值光照探针的 3D 网格。|
||**Custom Provided**|渲染器从 [MaterialPropertyBlock](https://docs.unity3d.com/cn/current/ScriptReference/MaterialPropertyBlock.html) 中提取光照探针着色器的 uniform 值。|
|**Proxy Volume Override**|   |设置对另一个具有 Light Probe Proxy Volume 组件的游戏对象的引用。  <br>  <br>仅当 **Light Probes （光照探针**） 设置为 **Use Proxy Volume （使用代理体积**） 时，此属性才可见。|
|**Reflection Probes**|   |设置 Renderer 从 [Reflection Probe](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html) 系统接收反射的方式。  <br>  <br>此属性对应于 [Renderer.probeAnchor](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-probeAnchor.html) API。|
||**Off**|禁用 Reflection Probes。Unity 使用天空盒进行反射。|
||**Blend Probes**|启用 Reflection Probes。混合仅在 Reflection Probe 之间发生。这在角色可能在具有不同照明设置的区域之间过渡的室内环境中非常有用。|
||**Blend Probes and Skybox**|启用 Reflection Probes。混合发生在 Reflection Probes 之间，或者 Reflection Probe 与默认反射之间。这对于室外环境非常有用。|
||**Simple**|启用 Reflection Probes，但当有两个重叠的体积时，Reflection Probes 之间不会发生混合。|
|**Anchor Override**|   |设置 Unity 在使用 [Light Probe](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) 或 [Reflection Probe](https://docs.unity3d.com/cn/current/Manual/class-ReflectionProbe.html) 系统时用于确定插值位置的 Transform。默认情况下，这是 Renderer 几何体的边界框的中心。  <br>  <br>此属性对应于 [Renderer.probeAnchor](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-probeAnchor.html) API。|

### Additional Settings

**Additional Settings** 部分包含额外的属性。

| **Property**          |                        | **Description**                                                                                                                                                                                                                                                                                                                                                                                             |
| --------------------- | ---------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Motion Vectors**    |                        | 设置是否使用运动矢量来跟踪此 Renderer 的每像素屏幕空间运动，从一个帧到下一个帧。您可以使用此信息来应用后期处理效果，例如运动模糊。  <br>  <br>**注意：**并非所有平台都支持运动矢量。有关更多信息，请参阅 [SystemInfo.supportsMotionVectors](https://docs.unity3d.com/cn/current/ScriptReference/SystemInfo-supportsMotionVectors.html)。  <br>  <br>此属性对应于 [Renderer.motionVectorGenerationMode](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-motionVectorGenerationMode.html) API。 |
|                       | **Camera Motion Only** | 仅使用 Camera movement 来跟踪运动。                                                                                                                                                                                                                                                                                                                                                                                  |
|                       | **Per Object Motion**  | 使用特定过程跟踪此 Renderer 的运动。                                                                                                                                                                                                                                                                                                                                                                                     |
|                       | **Force No Motion**    | 不跟踪运动。                                                                                                                                                                                                                                                                                                                                                                                                      |
| **Dynamic Occlusion** |                        | 启用 **Dynamic Occlusion** 后，当 Render Render 被静态遮挡物挡在摄像机视野之外时，Unity 的[遮挡剔除](https://docs.unity3d.com/cn/current/Manual/OcclusionCulling.html)系统会剔除该渲染器。否则，当 Static Occluder 挡住此 Renderer 无法从摄像机的视图中看到时，系统不会剔除此 Renderer。  <br>  <br>Dynamic Occlusion （动态遮挡） 默认处于启用状态。对于在墙后绘制角色轮廓等效果，禁用它。                                                                                                                     |
| **Sorting Layer**     |                        | 此 Renderer 的 [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html) 的名称。                                                                                                                                                                                                                                                                                                         |
| **Order in Layer**    |                        | 此 Renderer 在 [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html) 中的顺序。                                                                                                                                                                                                                                                                                                        |