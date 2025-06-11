Renderer 模块的设置决定了粒子的图像或[网格](https://docs.unity3d.com/cn/current/Manual/class-Mesh.html)如何被其他粒子变换、着色和过度绘制。
![[Pasted image 20241021000308.png]]
## Using the Renderer module
此模块是 [Particle System （粒子系统](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html)） 组件的一部分。创建新的 Particle System 游戏对象或将 Particle System 组件添加到现有游戏对象时，Unity 会将 Renderer 模块添加到粒子系统。Unity 默认启用此模块。

要创建新的粒子系统，请转到 **GameObject** > **Effects**，然后单击 **Particle System** 选项。然后，Unity 会创建一个新的 Particle System 游戏对象，并在 Hierarchy 窗口中选择它。在 Inspector 窗口中，Particle System 组件包含与 Particle System 相关的所有设置和模块。选择 Renderer （渲染器） 模块以显示此模块的选项。

### API
因为这个模块是 [Particle System](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 组件的一部分，所以你可以通过 ParticleSystem 类来访问它。有关如何在运行时访问此类和更改值的更多信息，请参阅 [Renderer](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystemRenderer.html) 模块。

## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。
### 1.渲染模式讲解

| **属性：**         |                          |                     |                                                                                                                  | **功能：**                                                                                                                                                                                                                                                                                          |
| --------------- | ------------------------ | ------------------- | ---------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Render Mode** |                          | 渲染模式                |                                                                                                                  | Unity 如何从图形图像（或网格）生成渲染图像。有关更多信息，请参阅[渲染模式](https://docs.unity3d.com/cn/current/Manual/PartSysRendererModule.html#render-mode)和[公告牌渲染模式](https://docs.unity3d.com/cn/current/Manual/PartSysRendererModule.html#billboard-render-modes)。                                                            |
|                 | **Billboard**            | 公告牌                 | ![[Pasted image 20241021003046.png]]                                                                             | Unity 将粒子渲染为公告牌，并且它们面向您在 **Render Alignment** 中指定的方向。                                                                                                                                                                                                                                            |
|                 | **Stretched Billboard**  | 拉伸公告牌               | ![[Pasted image 20241021003121.png]]                                                                             | 粒子面向 **Camera**，并应用了各种可能的缩放选项。                                                                                                                                                                                                                                                                   |
|                 |                          | Camera Scale        |                                                                                                                  | 仅当使用 **Stretched Billboard** Render 模式时，此设置才可用。  <br>  <br>根据摄像机移动拉伸粒子。将此项设置为零可禁用 Camera movement stretching。                                                                                                                                                                                    |
|                 |                          | Velocity Scale      |                                                                                                                  | 仅当使用 Stretched Billboard Render 模式时，此设置才可用。  <br>  <br>按速度按比例拉伸粒子。将此项设为 0 可禁用基于速度的拉伸。                                                                                                                                                                                                            |
|                 |                          | Length Scale        |                                                                                                                  | 仅当使用 Stretched Billboard Render 模式时，此设置才可用。  <br>  <br>沿粒子的速度方向按比例拉伸粒子的当前大小。将此项设置为零会使粒子消失，实际上长度为零。                                                                                                                                                                                               |
|                 |                          | Freeform Stretching |                                                                                                                  | 仅当使用 Stretched Billboard Render 模式时，此设置才可用。  <br>  <br>指示粒子是否应使用自由拉伸。通过这种拉伸行为，当您正面观察粒子时，粒子不会变薄。                                                                                                                                                                                                  |
|                 |                          | Rotate With Stretch |                                                                                                                  | 仅当使用 Stretched Billboard Render 模式时，此设置才可用。  <br>  <br>指示是否根据粒子的拉伸方向旋转粒子。这是在其他粒子旋转之上添加的。此属性仅在启用 **Freeform Stretching** 时有效。如果禁用 **Freeform Stretching**，则粒子始终根据其拉伸方向旋转，即使禁用**了 Rotate With Stretch** 也是如此。                                                                                      |
|                 | **Horizontal Billboard** | 水平公告牌               | 水平设置粒子。如魔法阵，水平于地面  <br>![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/caf8a1d8a7ea7ed6a475cb15e5c72fa0.png) | 粒子平面与 XZ“地板”平面平行。                                                                                                                                                                                                                                                                                |
|                 | **Vertical Billboard**   | 垂直公告牌               | 垂直设置粒子。主要运用于2D。  <br>![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/a4d6603cbd2fcce3ff83df0864c58dd9.png)   | 粒子在世界 Y 轴上直立，但转向面向摄像机。                                                                                                                                                                                                                                                                           |
|                 | **Mesh**                 | 网格                  | ![[Pasted image 20241021003055.png]]                                                                             | Unity 从 3D 网格而不是 Billboard 渲染粒子。有关 Mesh Render 模式的特定设置的更多信息，请参阅下面的 [Details](https://docs.unity3d.com/cn/current/Manual/PartSysRendererModule.html#details) 部分。                                                                                                                                  |
|                 |                          | Mesh Distribution   |                                                                                                                  | 指定 Unity 用于将网格随机分配给粒子的方法。  <br>  <br>仅当使用 Mesh Render （**网格**渲染） 模式时，此设置才可用。                                                                                                                                                                                                                     |
|                 |                          |                     | Uniform Random                                                                                                   | Unity 将网格随机分配给权重均匀的粒子。粒子系统作为一个整体，在任何给定时刻都应该包含大致相等数量的每个可能的网格。  <br>  <br>仅当使用 Mesh Render （**网格**渲染） 模式时，此设置才可用。                                                                                                                                                                                  |
|                 |                          |                     | Non-uniform Random                                                                                               | Unity 将网格随机分配给具有用户为每个网格定义权重的粒子。  <br>  <br>启用此设置后，Renderer module Inspector 窗口将显示 Meshes 列表和列表中每个网格的 Mesh Weightings 字段。可以使用 Mesh Weightings 字段来控制 Unity 将每个网格分配给粒子的频率。  <br>  <br>仅当使用 Mesh Render （**网格**渲染） 模式时，此设置才可用。                                                                       |
|                 |                          | Mesh Weightings     |                                                                                                                  | 控制 Unity 将此网格分配给粒子的可能性。权重彼此相关;Unity 分配一个网格的权重是另一个网格的两倍，而不管它们的绝对值如何。有关更多信息，请参阅下面的 详细信息 部分中的 [网格分布：非均匀随机](https://docs.unity3d.com/cn/current/Manual/PartSysRendererModule.html#non-uniform-random) 。  <br>  <br>仅当使用 **Mesh** Render 模式且 **Mesh Distribution** 属性设置为“Non-uniform Random”时，此设置才可用。 |
|                 | **None**                 | 无                   |                                                                                                                  | Unity 不会渲染任何粒子。如果您只想渲染轨迹并隐藏任何默认粒子渲染，那么这与 [Trails](https://docs.unity3d.com/cn/current/Manual/PartSysTrailsModule.html) 模块一起很有用。                                                                                                                                                                  |
前四个的粒子都是2D形式，也就是图片，而选择第五个Mesh，则会让你通过选择网格来确定粒子的3D形式。None选项无视即可。如下图（第一张为2D粒子，第二张为3D粒子形式）
![[Pasted image 20241021001128.png]]
![[Pasted image 20241021001134.png]]
下面我们来详细说明一下，前四种的区别：
Billboard：粒子朝向渲染对齐方向（默认朝向摄像机），也就是无论如何移动，粒子都是面向玩家摄像机的。

Stretched Billboard：保证朝向的情况下（粒子依旧面对相机），对粒子进行特殊拉伸，但可以调节更多的参数。该选项更多用于营造速度感。比如下雨之类的。


通过摄像机移动拉伸粒子
通过粒子速度来决定粒子拉伸程度
通过速度方向比例拉伸粒子，一般调节这个和上一个参数（这里解释随便看看，没啥意义，自己动手调就明白啥意思了）
![[Pasted image 20241021001215.png]]

Horizontal Billboard：水平设置粒子。如魔法阵，水平于地面
![[Pasted image 20241021001223.png]]

Vertical Billboard：垂直设置粒子。如。。。。不知道举啥例子。。
![[Pasted image 20241021001236.png]]

### 2.属性讲解
粒子属性

| **Normal Direction** | 法线方向 | 指定如何计算公告牌的照明。值为 0 表示 Unity 计算光照时，就像公告牌是一个球体一样。这会导致公告牌看起来更像一个球体。值为 1 表示 Unity 将公告牌的光照计算为平面四边形。  <br>  <br>仅当使用 Billboard 渲染模式之一时，此属性才可用：**Billboard**、**Stretched Billboard**、**Horizontal Billboard** 或 **Vertical Billboard**。 |
| -------------------- | ---- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Material**         |      | Unity 用于渲染粒子的材质。新建Shader修改为Additive(Mobile/Particles/。。。)                                                                                                                                                                       |
| **Trail Material**   |      | Unity 用于渲染粒子轨迹的材质，即拖尾材质，比如流星的尾焰，仅当启用Trail模块该属性生效。                                                                                                                                                                               |
渲染顺序

| **Sort Mode** |                   | Unity 使用 Particle System 绘制和覆盖粒子的顺序。                                  |
| ------------- | ----------------- | --------------------------------------------------------------------- |
|               | 无                 | 启用此设置后，Unity 不会对粒子进行排序。                                               |
|               | By Distance       | 根据到活动摄像机的距离对系统中的粒子进行排序。Unity 将粒子渲染到离摄像机较远的粒子之上。使用该设置旋转摄像机时，粒子的顺序不会更改。 |
|               | Oldest in Front   | Unity 渲染在 Particle System 前面存在时间最长的粒子。                                |
|               | Youngest in Front | Unity 在 Particle System 的前面渲染存在时间最短的粒子。                               |
|               | By Depth          | Unity 根据粒子与摄像机近平面的距离来渲染粒子。使用此设置旋转摄像机时，粒子的顺序可能会更改。                     |
粒子大小

| **Sorting Fudge**     | Particle System 排序的偏差。粒子系统与粒子系统之间的渲染次序。值越小，优先级越高。                                                                                                              |
| --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Min Particle Size** | 单个粒子的最小粒度，占据视口多少，Mesh渲染模式不可用  <br>  <br>仅当使用 Billboard 渲染模式之一时，此属性才可用：**Billboard**、**Stretched Billboard**、**Horizontal Billboard** 或 **Vertical Billboard**。 |
| **Max Particle Size** | 单个粒子的最大粒度，占据视口多少，Mesh渲染模式不可用<br>  <br>仅当使用 Billboard 渲染模式之一时，此属性才可用：**Billboard**、**Stretched Billboard**、**Horizontal Billboard** 或 **Vertical Billboard**。   |
粒子朝向

| **Render Alignment** | 渲染对齐方向   | 此属性确定粒子公告板的朝向。                        |
| -------------------- | -------- | ------------------------------------- |
|                      | View     | 粒子面向摄像机平面。                            |
|                      | World    | 粒子与世界轴对齐。                             |
|                      | Local    | 粒子与其游戏对象的 **Transform 组件**对齐。         |
|                      | Facing   | 粒子面向活动摄像机的游戏对象中的 Transform 组件定义的直接位置。 |
|                      | Velocity | 粒子的朝向与其速度矢量的方向相同。                     |
可视化效果

| **Flip**                       | 随机翻转                 | 在指定轴上镜像一定比例的粒子。较高的值会翻转更多的粒子。                                                                                                                                             |
| ------------------------------ | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Enable Mesh GPU Instancing** |                      | 此属性仅在使用 Mesh 渲染模式时可用。  <br>  <br>此属性控制 Unity 是否使用 GPU 实例化渲染粒子系统。这需要使用兼容的着色器。有关更多信息，请参阅[粒子网格 GPU 实例化](https://docs.unity3d.com/cn/current/Manual/PartSysInstancing.html)。 |
| **Allow Roll**                 |                      | 控制面向摄像机的粒子是否可以绕摄像机的 Z 轴旋转。禁用此功能对于 VR 应用程序特别有用，其中 HMD（头戴式显示器）滚动可能会导致粒子系统出现不需要的粒子旋转。                                                                                       |
| **Pivot**                      |                      | 修改旋转粒子的中心轴心点。此值是粒子大小的乘数。                                                                                                                                                 |
| **Visualize Pivot**            |                      | 在 **Scene** 视图中预览粒子枢轴点。                                                                                                                                                  |
| **Masking**                    |                      | 设置粒子系统渲染的粒子在与 **Sprite 遮罩**交互时的行为方式。                                                                                                                                     |
|                                | No Masking           | 粒子系统不与场景中的任何精灵遮罩交互。这是默认选项。                                                                                                                                               |
|                                | Visible Inside Mask  | 粒子在由精灵遮罩覆盖的地方是可见的，而在遮罩外部不可见。                                                                                                                                             |
|                                | Visible Outside Mask | 粒子在精灵遮罩外部是可见的，而在遮罩内部不可见。精灵遮罩会隐藏其覆盖的粒子部分。                                                                                                                                 |

| **Apply Active Color Space** | 在线性色彩空间中渲染时，系统会先从伽马空间转换粒子颜色，然后再将其上传到 GPU。                                                                                              |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| **Custom Vertex Streams**    | 自定义顶点流，配置材质的 Vertex Shader 中可用的粒子属性。有关更多信息，请参阅[粒子系统顶点流和标准着色器支持](https://docs.unity3d.com/cn/current/Manual/PartSysVertexStreams.html)。 |
阴影

| **Cast Shadows** |                                   | 如果启用此属性，则粒子系统将在阴影投射光源照射到其上时创建阴影。                    |
| ---------------- | --------------------------------- | --------------------------------------------------- |
|                  | On                                | 为此粒子系统启用阴影。                                         |
|                  | Off                               | 禁用此粒子系统的阴影。                                         |
|                  | Two-Sided                         | 选择 **Two Sided** 以允许从 Mesh 的任一侧投射阴影。启用此属性时，不考虑背面剔除。 |
|                  | Shadows Only                      | 选择 **Shadows Only （仅阴影**） 以使阴影可见，但网格本身不可见。          |
| Receive Shadows  | 规定阴影是否可以投射到粒子上，只有不透明材质才可以接受阴影     |                                                     |
| **Shadow Bias**  | 沿光线方向移动阴影。这将消除因使用公告牌近似体积而导致的阴影伪影。 |                                                     |

运动追踪

| **Motion Vectors** |                    | 设置是否使用运动矢量来跟踪此粒子系统的 Transform （变换） 组件从一帧到下一帧的每像素屏幕空间运动。  <br>  <br>**注：** 并非所有平台都支持运动矢量。有关更多信息，请参阅 [SystemInfo.supportsMotionVectors](https://docs.unity3d.com/cn/current/ScriptReference/SystemInfo-supportsMotionVectors.html)。 |
| ------------------ | ------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|                    | Camera Motion Only | 仅使用摄像机移动来跟踪运动。                                                                                                                                                                                                                    |
|                    | Per Object Motion  | 使用特定通道来跟踪此渲染器的运动。                                                                                                                                                                                                                 |
|                    | Force No Motion    | 不跟踪运动。                                                                                                                                                                                                                            |
排序层级

| **Sorting Layer ID** | Renderer 的排序图层的名称。   |
| -------------------- | -------------------- |
| **Order in Layer**   | 此 Renderer 在排序层中的顺序。 |
光照：

| **Light Probes**      | 基于探针的光照插值模式。                                                                                                                                                                            |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Reflection Probes** | 如果启用，并且场景中存在反射探针，则 Unity 会将来自最近的反射探针的反射纹理分配给此游戏对象，并将该纹理设置为内置的着色器 uniform 变量。                                                                                                            |
| **Anchor Override**   | 一种变换，用于确定使用 [Light Probe](https://docs.unity3d.com/cn/current/Manual/LightProbes.html) 或 [Reflection Probe](https://docs.unity3d.com/cn/current/Manual/ReflectionProbes.html) 系统时的插值位置。 |
