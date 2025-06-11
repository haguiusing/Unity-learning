# 1.External Forces 模块
此属性可修改风区和[粒子系统力场](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystemForceField.html)对系统发射的粒子的影响。
![[Pasted image 20241022130412.png]]
该模块需要和Force Field组件配合使用，作用是模拟物理的力对粒子的影响。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它并更改值的信息，请参阅[外力模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-externalForces.html)。

## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **_属性_**             | **_功能_**                                                                                                                                                                                                                                                                                                                                                                                                                                                          |                           |
| -------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------- |
| **Multiplier**       | 应用于风区外力的比例值，即施加到该粒子系统上的力的乘数，1全施加，0不施加。                                                                                                                                                                                                                                                                                                                                                                                                                            |                           |
| **Influence Filter** | 选择是否基于__层遮罩 (Layer Mask)__ 或通过显式__列表 (List)__ 包含力场。                                                                                                                                                                                                                                                                                                                                                                                                               |                           |
|                      | Layer Mask(通过层的方式选择力场对哪一层生效)                                                                                                                                                                                                                                                                                                                                                                                                                                      | 通过层的方式选择力场对哪一层生效          |
|                      | List                                                                                                                                                                                                                                                                                                                                                                                                                                                              | 通过力场List来确定，哪些力场对当前粒子系统生效 |
|                      | Layer Mask And List                                                                                                                                                                                                                                                                                                                                                                                                                                               | (我全都要！)                   |
| **Influence Mask**   | 使用层遮罩来确定哪些力场影响此粒子系统。当 **Influence Filter** 设置为 **Layer Mask** 时，将显示此属性。  <br>此属性在默认情况下设置为 **Everything__，但您可以单独启用或禁用以下选项： <br>- Nothing（自动取消勾选所有其他选项，将它们关闭）  <br>- Everything（自动勾选所有其他选项，将它们打开）  <br>- Default <br>- **TransparentFX**  <br>- **Ignore [Raycast](https://docs.unity3d.com/cn/current/Manual/Raycasters.html)**  <br>- **Water**  <br>- **UI**  <br>- **[PostProcessing](https://docs.unity3d.com/cn/current/Manual/PostProcessingOverview.html)** |                           |


## 详细信息
要通过此功能获得最佳效果，请使用 [ParticleSystemForceFields](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystemForceField.html) 组件创建单独的游戏对象。

__地形__可添加_风区_来影响树在景观中的运动。启用此部分的功能允许风区吹动系统发射的粒子。通过_ Multiplier_ 值可调整风对粒子的影响，因为风对粒子的吹动作用通常比树枝更强烈。

# 粒子系统力场 (Particle System Force Field)
**Particle System Force Field** 组件将力应用于[粒子系统](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html)中的粒子。要将此组件附加到粒子系统，请在粒子系统中启用 [External Forces 模块](https://docs.unity3d.com/cn/current/Manual/PartSysExtForceModule.html)，并指定 Layer Mask 或特定的 Force Field 组件。
![[Pasted image 20241022132457.png]]

有关粒子系统及其用途的完整介绍，请参阅关于[粒子系统](https://docs.unity3d.com/cn/current/Manual/ParticleSystems.html)的文档。
## 属性
使用 Particle System Force Field 组件将各种类型的力应用于粒子。

所有力都施加在力场的本地空间中。例如，旋转变换组件会影响方向和旋转属性。

| **_Property_**   |                           | **_Function_**                                                                                                                                                                 |
| ---------------- | ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Shape**        |                           |                                                                                                                                                                                |
|                  | Shape                     | 选择影响区域的形状。圆、半圆、圆柱、盒                                                                                                                                                            |
|                  | Start Range               | 设置影响区域开始的形状内点的值。                                                                                                                                                               |
|                  | End Range                 | 设置影响区域结束的形状的外部点的值。                                                                                                                                                             |
|                  | Direction X, Y and Z      | 设置沿 x 轴、y 轴和 z 轴应用于粒子的线性力。值越高，力越大。您可以指定恒定力或随时间改变力。有关更多信息，请参阅 [随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime) 文档。                         |
| **Gravity**      |                           |                                                                                                                                                                                |
|                  | Strength                  | 设置粒子对形状内焦点的吸引力。值越高，强度越大。您可以指定恒定强度或随时间改变强度。有关更多信息，请参阅 [随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime) 文档。                                 |
|                  | Gravity Focus             | 设置重力的焦点，以将粒子拉向其。值为 0 时，粒子会吸引到形状的中心，值 1 会吸引粒子到形状的外边缘。                                                                                                                           |
| **Rotation**     |                           |                                                                                                                                                                                |
|                  | Speed                     | 设置 Particle System （粒子系统） 的速度，以推动粒子围绕漩涡（力场的中心）。值越高，速度越快。您可以指定恒定速度或随时间改变速度。有关更多信息，请参阅 [随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime) 文档。 |
|                  | Attraction                | 设置将粒子拖动到漩涡运动中的强度。值为 1 时，应用最大吸引力，值为 0 时，不应用任何吸引力。您可以指定恒定吸引力或随时间改变吸引力。有关更多信息，请参阅 [随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime) 文档。       |
|                  | Rotation Randomness       | 设置形状的随机轴以推动粒子。值 1 应用最大随机性，值 0 不应用随机性。                                                                                                                                          |
| **Drag**         |                           |                                                                                                                                                                                |
|                  | Strength                  | 设置减慢粒子速度的拖动效果的强度。值越高，强度越大。您可以指定恒定强度或随时间改变强度。有关更多信息，请参阅 [随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime) 文档。                               |
|                  | Multiply Drag by Size     | 启用此复选框可根据粒子的大小调整阻力。                                                                                                                                                            |
|                  | Multiply Drag by Velocity | 启用此复选框可根据粒子的速度调整阻力。                                                                                                                                                            |
| **Vector Field** |                           |                                                                                                                                                                                |
|                  | Volume Texture            | 选择向量场的纹理。                                                                                                                                                                      |
|                  | Speed                     | 设置要应用于穿过向量场的粒子的倍增的速度。值越高，速度越快。您可以指定恒定强度或随时间改变强度。请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。                                      |
|                  | Attraction                | 设置 Unity 将粒子拖动到向量场运动中的强度。值越高，吸引力越大。您可以指定恒定吸引力或随时间改变吸引力。请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。                               |
矢量场是预先计算好的力场，Unity无法直接制作，需要用到插件或去其他软件制作

Unity矢量场的制作，参考这篇 [Unity学习笔记 Vol.15 制作矢量场（B站文章）](https://www.bilibili.com/read/cv2695515?from=search&spm_id_from=333.337.0.0)