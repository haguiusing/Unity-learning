# Trail Renderer component
Trail Renderer 组件在移动的游戏对象后面随着时间的推移渲染一条多边形轨迹。此组件可用于强调移动对象的运动感，或突出移动对象的路径或位置。

Trail Renderer 使用与 [Line Renderer](https://docs.unity3d.com/cn/current/Manual/class-LineRenderer.html) 相同的轨迹渲染算法。

## 准备开始
要创建轨迹渲染器，请执行以下操作：
1. 在 Unity 菜单栏中，选择 **GameObject** > **Effects** > **Trail**。
2. 选择 Trail Renderer 游戏对象，并将其作为要生成轨迹的游戏对象的父项。
3. 使用 Inspector 窗口配置轨迹的颜色、宽度和其他显示设置。
4. 通过移动游戏对象并在 Scene 视图中观察效果，可在编辑模式下预览轨迹。
![示例 Trail Renderer 配置和生成的轨迹。](https://docs.unity3d.com/cn/current/uploads/Main/TrailRenderer-example2.jpg)
示例 Trail Renderer 配置和生成的轨迹。

## 轨迹渲染器材质
默认情况下，轨迹渲染器 (Trail Renderer) 使用内置材质 **Default-Line**。您可以更改轨迹的外观而无需更改此材质，例如编辑轨迹的颜色渐变或宽度。

对于其他效果，例如在轨迹上应用纹理，需要使用其他材质。如果您不想为新材质编写自己的着色器，可以将 Unity 内置的[标准粒子着色器](https://docs.unity3d.com/cn/current/Manual/shader-StandardParticleShaders.html)与轨迹渲染器结合使用。如果将纹理应用到轨迹渲染器，则纹理应为正方形尺寸（例如 256x256 或 512x512）。

如果将多个材质应用于轨迹渲染器，则会为每个材质渲染一次。

请参阅[创建和使用材质](https://docs.unity3d.com/cn/current/Manual/Materials.html)以了解更多信息。

## 点之间的距离
**Min Vertex Distance** 值可以确定在将新段添加到该路径之前，应用轨迹的游戏对象必须行进的距离（采用世界单位）。像 0.1 这样较小的值会更频繁地创建轨迹段，从而形成更平滑的轨迹。像 1.5 这样较大的值会创建在外观上更有锯齿状的轨迹段。另外，当顶点非常靠近并且轨迹会在短距离内显著改变方向时，较宽的轨迹可能出现视觉瑕疵。

出于性能原因，最好使用尽可能最大的值来实现要创建的效果。
## Trail Renderer Inspector 面板
![[Pasted image 20241022134845.png]]
### 轨迹设置

| **属性**                     |                          | **功能**                                                                                                                                                 |
| -------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Width**                  |                          | 定义宽度值和曲线值以控制轨迹沿其长度的宽度。  <br>  <br>曲线是在每个顶点处采样的，因此其精度受制于轨迹中的顶点数量。轨迹的总宽度由宽度值控制。                                                                          |
| **Time**                   |                          | 定义轨迹中某个点的生命周期（以秒为单位）。                                                                                                                                  |
| **Min Vertex Distance**    |                          | 轨迹中两点之间的最小距离（采用世界单位）。                                                                                                                                  |
| **AutoDestruct**           |                          | 启用此属性可在附加到 Trail Renderer 组件的游戏对象静止 **Time** 秒之后销毁该游戏对象。                                                                                               |
| **Emitting**               |                          | 启用此属性后，Unity 会在轨迹中添加新点。禁用此属性后，Unity 不会向轨迹中添加新点。使用此属性可暂停和恢复轨迹生成功能。                                                                                      |
| Apply Active Color Space   |                          |                                                                                                                                                        |
| **Color**                  |                          | 定义一个渐变来控制轨迹沿其长度的颜色。  <br>  <br>Unity 在每个顶点处从颜色渐变 (Color Gradient) 中采样颜色。在每个顶点之间，Unity 对颜色应用线性插值。向轨迹添加更多顶点可能会更接近详细的渐变。                                  |
| **Corner Vertices**        |                          | 此属性指示在绘制轨迹中的角时使用多少个额外顶点。增加此值可使轨迹的角显得更圆。                                                                                                                |
| **End Cap Vertices**       |                          | 此属性指示使用多少个额外顶点在轨迹上创建端盖。增加此值可使轨迹的端盖显得更圆。                                                                                                                |
| **Alignment**              |                          | 设置轨迹面向的方向。                                                                                                                                             |
|                            | **View**                 | 轨迹面向摄像机，适合3D。                                                                                                                                          |
|                            | **TransformZ**           | 轨迹朝向其变换组件的 Z 轴，适合2D。                                                                                                                                   |
| **Texture Mode**           |                          | 控制如何将纹理应用于轨迹。                                                                                                                                          |
|                            | **Stretch**              | 沿轨迹的整个长度映射纹理一次。                                                                                                                                        |
|                            | **Tile**                 | 基于轨迹长度（采用世界单位）沿轨迹重复纹理。要设置平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。适合做传动轴。 |
|                            | **DistributePerSegment** | 沿轨迹的整个长度映射纹理一次（假设所有顶点均匀分布）。                                                                                                                            |
|                            | **RepeatPerSegment**     | 沿轨迹重复纹理（每个轨迹段重复一次）。要调整平铺率，请使用 [Material.SetTextureScale](https://docs.unity3d.com/cn/current/ScriptReference/Material.SetTextureScale.html)。           |
|                            | Static                   | 与**Tile**类似，但是不会动，适合做脚印。                                                                                                                               |
| Texture Scale              |                          | 图片个数                                                                                                                                                   |
| **Shadow Bias**            |                          | 设置沿着光照方向的阴影移动量以消除阴影瑕疵。                                                                                                                                 |
| **Generate Lighting Data** |                          | 如果启用此属性，Unity 在构建轨迹几何体时包含法线和切线。这样，轨迹几何体就可以使用采用了场景光照的材质。                                                                                                |
| Mask Interaction           |                          | 遮罩                                                                                                                                                     |

### 材质
**Materials** 部分列出了此组件使用的所有[材质](https://docs.unity3d.com/cn/current/Manual/class-Material.html)。

| **属性**      | **描述**                                                                                                               |
| ----------- | -------------------------------------------------------------------------------------------------------------------- |
| **Size**    | 材质列表中的元素数。  <br>  <br>如果减少元素数量，Unity 会删除列表末尾的元素。如果增加元素的数量，Unity 会将新元素添加到列表的末尾。Unity 使用列表末尾的元素使用的相同材料填充新元素。           |
| **Element** | 列表中的材料。您可以为每个元素分配一个 Material 资源。  <br>  <br>默认情况下，Unity 根据材质名称按字母顺序对列表进行排序。此列表是可重新排序的，并且 Unity 会在您更改元素的顺序时自动更新元素的数量。 |


## 光照
**Lighting** 部分包含与光照相关的属性。

| **属性**                             |                  | **描述**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| ---------------------------------- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Cast Shadows**                   |                  | 指定当合适的 [Light](https://docs.unity3d.com/cn/current/Manual/class-Light.html) 照射到此 Renderer 上时，是否以及如何投射阴影。  <br>  <br>此属性对应于 [Renderer.shadowCastingMode](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-shadowCastingMode.html) API。                                                                                                                                                                                                                                                                                                                                         |
|                                    | **On**           | 当投射阴影的 Light 照射到它上面时，此 Renderer 会投射阴影。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|                                    | **Off**          | 此 Renderer 不投射阴影。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
|                                    | **Two-sided**    | 此 Renderer 投射双面阴影。这意味着平面或四边形等单面对象可以投射阴影，即使光源位于网格后面也是如此。  <br>  <br>要使 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 支持双面阴影，材质必须支持 [Double Sided Global Illumination。](https://docs.unity3d.com/Manual/class-Material.html)                                                                                                                                                        |
|                                    | **Shadows Only** | 此 Renderer 投射阴影，但 Renderer 本身不可见。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| **Receive Shadows**                |                  | 指定 Unity 是否显示投射到此 Renderer 上的阴影。  <br>  <br>仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才有效。  <br>  <br>此属性对应于 [Renderer.receiveShadows](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-receiveShadows.html) API。                                                                                                                                   |
| **Contribute Global Illumination** |                  | 将此 Renderer 包含在全局照明计算中，该计算在烘焙时进行。  <br><br>仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才有效。  <br>  <br>启用此属性将在游戏对象的 [Static Editor Flags](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html) 中启用 Contribute GI 标志。它对应于 [StaticEditorFlags.ContributeGI](https://docs.unity3d.com/cn/current/ScriptReference/StaticEditorFlags.ContributeGI.html) API。 |
| **Receive Global Illumination**    |                  | Unity 是从烘焙光照贴图还是从运行时光照探针向此渲染器提供全局光照数据。  <br>  <br>仅当启用 **Contribute Global Illumination** 时，此属性才可编辑。仅当为此场景启用 [Baked Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#MixedLighting) 或 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，它才有效。  <br>  <br>此属性对应于 [MeshRenderer.receiveGI](https://docs.unity3d.com/cn/current/ScriptReference/MeshRenderer-receiveGI.html) API。                                                                               |
|                                    | **Lightmaps**    | Unity 从光照贴图向此渲染器提供全局照明数据。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|                                    | **Light Probes** | Unity 从场景中的[光照探针](https://docs.unity3d.com/cn/current/Manual/LightProbes.html)向此渲染器提供全局照明数据。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| **Prioritize Illumination**        |                  | 启用此属性后，在 Enlighten Realtime Global Illumination 计算中将始终包含此渲染器。这可确保 Renderer 受远处自发光的影响，即使是那些通常出于性能原因而被排除在 Global Illumination 计算之外的自发光。  <br>  <br>只有在游戏对象的[静态编辑器标志](https://docs.unity3d.com/cn/current/Manual/StaticObjects.html)中启用了 **Contribute GI**，项目使用内置渲染管道，并在场景中启用了 Enlighten [Realtime Global Illumination](https://docs.unity3d.com/cn/current/Manual/class-LightingSettings.html#RealtimeLighting) 时，此属性才可见。                                                                                                                                                                   |

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
| **Dynamic Occlusion** |                        | 启用 **Dynamic Occlusion** 后，当 Render 被静态遮挡物挡在摄像机视野之外时，Unity 的[遮挡剔除](https://docs.unity3d.com/cn/current/Manual/OcclusionCulling.html)系统会剔除该渲染器。否则，当 Static Occluder 挡住此 Renderer 无法从摄像机的视图中看到时，系统不会剔除此 Renderer。  <br>  <br>Dynamic Occlusion （动态遮挡） 默认处于启用状态。对于在墙后绘制角色轮廓等效果，禁用它。                                                                                                                            |
| **Sorting Layer**     |                        | 此 Renderer 的 [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html) 的名称。                                                                                                                                                                                                                                                                                                         |
| **Order in Layer**    |                        | 此 Renderer 在 [Sorting Layer](https://docs.unity3d.com/cn/current/Manual/class-TagManager.html) 中的顺序。                                                                                                                                                                                                                                                                                                        |