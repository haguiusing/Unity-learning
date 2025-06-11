# Trails 模块
使用此模块可将轨迹添加到一部分粒子。此模块与[轨迹渲染器 (Trail Renderer)](https://docs.unity3d.com/cn/current/Manual/class-TrailRenderer.html) 组件共享许多属性，但提供了将轨迹轻松附加到粒子以及从粒子继承各种属性的功能。轨迹可用于各种效果，例如子弹、烟雾和魔法视觉效果。

![处于 Particles 模式的 Trails 模块](https://docs.unity3d.com/cn/current/uploads/Main/PartSysTrailsModule.png)
处于 Particles 模式的 Trails 模块

![处于 Ribbon 模式的 Trails 模块](https://docs.unity3d.com/cn/current/uploads/Main/PartSysTrailsModuleRibbon.png)
处于 Ribbon 模式的 Trails 模块

### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Trails 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-trails.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性：**  | **功能：**        |                         |
| -------- | -------------- | ----------------------- |
| **Mode** | 选择如何为粒子系统生成轨迹。 |                         |
|          | **Particle**   | 模式可创建每个粒子在自身路径中留下固定轨迹的效 |
|          | **Ribbon**     | 模式可创建根据存活时间连接每个粒子的轨迹带。  |

**Particle**


| **Ratio**                   | 一个介于 0 和 1 之间的值，表示已分配轨迹的粒子的比例。Unity 随机分配轨迹，因此该值表示概率。                                        |
| --------------------------- | ------------------------------------------------------------------------------------------- |
| **Lifetime**                | 轨迹中每个顶点的生命周期，表示为所属粒子的生命周期的乘数。当每个新顶点添加到轨迹时，该顶点将在其存在时间超过其总生命周期后消失。                            |
| **Minimum Vertex Distance** | 定义粒子在其轨迹接收新顶点之前必须经过的距离。(值越小，尾迹顶点越多，越丝滑)                                                     |
| **World Space**             | 启用此属性后，即便使用 **Local Simulation Space**，轨迹顶点也不会相对于粒子系统的游戏对象移动。相反，轨迹顶点将被置于世界空间中，并忽略粒子系统的任何移动。 |
| ** Die With Particles**     | 如果选中此框，轨迹会在粒子死亡时立即消失。如果未选中此框，则剩余的轨迹将根据自身的剩余生命周期自然到期。                                        |

**Ribbon**

| **Ribbon Count**               | 选择要在整个粒子系统中渲染的轨迹带数量。值为 1 将创建连接每个粒子的单个轨迹带。但是，大于 1 的值将创建连接每第 N 个粒子的轨迹带。例如，使用值 2 时，将有一条轨迹带连接粒子 1、3、5，另一条轨迹带连接粒子 2、4、6，以此类推。粒子的排序取决于它们的存活时间。 |
| ------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------- |
| ** Split Sub Emitter Ribbons** | 在用作子发射器的系统上启用此属性时，从同一父系统粒子生成的粒子将共享一个轨迹带。                                                                                                 |
| **Size affects Width**         | 如果启用此属性（选中复选框），则轨迹宽度受粒子大小影响。                                                                                                             |
| **Size affects Lifetime**      | 如果启用此属性（选中复选框），则轨迹生命周期受粒子大小影响。                                                                                                           |
| **Inherit Particle Color**     | 如果启用此属性（选中复选框），则轨迹颜色由粒子颜色调制。                                                                                                             |
| **Color over Lifetime**        | 通过一条曲线控制整个轨迹在其附着粒子的整个生命周期内的颜色。                                                                                                           |
| **Width over Trail**           | 通过一条曲线控制轨迹沿其长度的宽度。                                                                                                                       |
| **Color over Trail**           | 通过一条曲线控制轨迹沿其长度的颜色。                                                                                                                       |
| **Generate Lighting Data**     | 通过启用此属性（选中复选框），可在构建轨迹几何体时包含法线和切线。这样允许它们使用具有场景光照的材质，例如通过标准着色器，或通过使用自定义着色器。                                                                |
| **Shadow Bias**                | 沿光线方向移动阴影。这将消除因使用公告牌轨迹几何体近似体积而导致的阴影伪影。                                                                                                   |

| ** Texture Mode** | 选择将纹理应用于 Particle Trails （粒子轨迹）的方式。 |                                                                      |
| ----------------- | ----------------------------------- | -------------------------------------------------------------------- |
|                   | **Stretch**                         | 沿线的整个长度映射纹理一次                                                        |
|                   | **Tile**                            | 基于线长度（采用世界单位）沿线重复纹理，每 N 个距离单位重复一次纹理。重复率根据**材质**中的 **Tiling** 参数进行控制。 |
|                   | **Repeat per Segment**              | 沿线重复纹理，每个轨迹段重复一次。重复率根据**材质**中的 **Tiling** 参数进行控制。                    |
|                   | **Distribute per Segment**          | 沿线的整个长度映射纹理一次，并假定所有顶点的间距相等。                                          |