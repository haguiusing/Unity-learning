[Lesson9_Collision](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%E8%BF%9B%E9%98%B6/Particle%20System%E7%B2%92%E5%AD%90%E7%B3%BB%E7%BB%9F/Lesson9_Collision.cs)
# Collision 模块

此模块控制[粒子](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html)与[场景中](https://docs.unity3d.com/cn/current/Manual/CreatingScenes.html)[的游戏对象](https://docs.unity3d.com/cn/current/Manual/GameObjects.html)碰撞的方式。使用第一个下拉列表定义碰撞设置是应用于 **Planes** 还是 **World**。如果您选择 World （**世界**），请使用 **Collision Mode （碰撞模式**） 下拉列表来定义您的碰撞设置是应用于 [2D 还是 3D](https://docs.unity3d.com/cn/current/Manual/2Dor3D.html) 世界。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Collision 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-collision.html)。

该模块分为两种模式，分别是Planes和World，通过这两种模式可以设置粒子是与平面碰撞还是与世界中的所有物体碰撞。
## Planes module properties
![[Pasted image 20241021173829.png]]
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**                      | **功能**                                                                                                                                       |
| --------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| **Planes 弹出菜单**             | 选择 **Planes** 模式。                                                                                                                            |
| **Planes**                  | 用于定义碰撞平面的变换的可扩展列表。通过获取游戏对象的Transform来沿着XZ轴生成一个无限大的平面，Y轴为其平面法向                                                                                |
| **Visualization**           | 选择要将 Scene 视图中的碰撞平面辅助图标显示为线框网格还是实体平面。                                                                                                        |
| **Scale Plane**             | 用于可视化的平面大小。                                                                                                                                  |
| **Dampen**                  | 粒子碰撞后损失的速度比例。                                                                                                                                |
| **Bounce**                  | 粒子碰撞后从表面反弹的速度比例。                                                                                                                             |
| **Lifetime Loss**           | 粒子碰撞后损失的总生命周期比例。                                                                                                                             |
| **Min Kill Speed**          | 碰撞后运动速度低于此速度的粒子将从系统中予以移除。                                                                                                                    |
| **Max Kill Speed**          | 碰撞后运动速度高于此速度的粒子将从系统中予以移除。                                                                                                                    |
| **Radius Scale**            | 允许调整粒子碰撞球体的半径，使其更贴近粒子图形的可视边缘。                                                                                                                |
| **Send Collision Messages** | 如果启用此属性，则可从脚本中通过 [OnParticleCollision](https://docs.unity3d.com/cn/current/ScriptReference/MonoBehaviour.OnParticleCollision.html) 函数检测粒子碰撞。 |
| **Visualize Bounds**        | 在 Scene 视图中将每个粒子的碰撞边界渲染为线框形状。                                                                                                                |
Planes肯定要比World模式节省计算量，但Planes仅能对平面产生一个碰撞，适用于简易房间，地板等场景（注意，Planes是可叠加的，并不是只能设置一块，Planes选项下有一个“加号”按钮）
## World module properties
![](https://docs.unity3d.com/cn/current/uploads/Main/PartSysCollisionInsp2.png)
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **_属性_**           | **_功能_**                  |
| ------------------ | ------------------------- |
| **World 弹出菜单**     | 选择 **World** 模式。          |
| **Collision Mode** | 3D 或 2D。                  |
| **Dampen**         | 粒子碰撞后损失的速度比例。             |
| **Bounce**         | 粒子碰撞后从表面反弹的速度比例。          |
| **Lifetime Loss**  | 粒子碰撞后损失的总生命周期比例。          |
| **Min Kill Speed** | 碰撞后运动速度低于此速度的粒子将从系统中予以移除。 |
| **Max Kill Speed** | 碰撞后运动速度高于此速度的粒子将从系统中予以移除。 |
| **Radius Scale**   | 2D 或 3D 的设置。              |

| **Collision Quality**        | 使用下拉选单来设置粒子碰撞的质量。此设置会影响有多少粒子可以穿过碰撞体。在较低的质量水平下，粒子有时会穿过碰撞体，但需要的计算资源较少。                                                                                                                                | <font color="#ffc000">当为High时，粒子响应一切碰撞，当设置为Medium时，粒子忽略刚体碰撞体，仅响应静态碰撞体。</font>                                                                                                                                                                                                                                                           |
| ---------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|                              | High                                                                                                                                                                                                | 当 **Collision Quality** 设置为 **High** 时，碰撞始终使用物理系统来检测碰撞结果。此设置是最耗费资源但也是最准确的选项。                                                                                                                                                                                                                                                            |
|                              | Medium (Static Colliders)                                                                                                                                                                           | 当 **Collision Quality** 设置为 **Medium (Static Colliders)** 时，碰撞使用一组体素来缓存先前的碰撞，从而在以后的帧中更快地重用。请参阅下方的[世界碰撞](https://docs.unity3d.com/cn/current/Manual/PartSysCollisionModule.html#WorldCollisions)以了解与此缓存相关的更多信息。  <br>  <br>**Medium** 和 **Low** 之间的唯一区别是粒子系统在每帧查询物理系统的次数。**Medium** 每帧的查询次数多于 **Low**。  <br>  <br>请注意，此设置仅适用于从不移动的静态碰撞体。 |
|                              | Low (Static Colliders)                                                                                                                                                                              | 当 **Collision Quality** 设置为 **Low (Static Colliders)** 时，碰撞使用一组体素来缓存先前的碰撞，从而在以后的帧中更快地重用。请参阅下方的[世界碰撞](https://docs.unity3d.com/cn/current/Manual/PartSysCollisionModule.html#WorldCollisions)以了解与此缓存相关的更多信息。  <br>  <br>**Medium** 和 **Low** 之间的唯一区别是粒子系统在每帧查询物理系统的次数。**Medium** 每帧的查询次数多于 **Low**。  <br>  <br>请注意，此设置仅适用于从不移动的静态碰撞体。    |
| **Collides With**            | 粒子只会与所选层上的对象发生碰撞。                                                                                                                                                                                   |                                                                                                                                                                                                                                                                                                                                         |
| **Max Collision Shapes**     | 粒子碰撞可包括的碰撞形状个数。多余的形状将被忽略，且地形优先。                                                                                                                                                                     | 默认为256，也就是说粒子可与256个不同的Mesh碰撞，再多一个就不生效了                                                                                                                                                                                                                                                                                                  |
| **Enable Dynamic Colliders** | 动态碰撞器是未配置为 Kinematic 的任何碰撞器（有关碰撞器类型的更多信息，请参阅有关[碰撞器](https://docs.unity3d.com/cn/current/Manual/CollidersOverview.html)的文档）。  <br>  <br>选中此选项可将这些碰撞器类型包含在粒子在碰撞中响应的对象集中。如果取消选中此选项，则粒子仅响应与静态碰撞体的碰撞。    | 粒子是否响应与刚体碰撞体的碰撞                                                                                                                                                                                                                                                                                                                         |
| **Voxel Size**               | 体素 (voxel) 表示三维空间中的常规网格上的值。使用 **Medium** 或 **Low** 质量碰撞时，Unity 会在网格结构中缓存碰撞。此设置控制着网格大小。较小的值可提供更高的准确性，但会占用更多内存，效率也会降低。  <br>  <br>**注意**：仅当 **Collision Quality** 设置为 **Medium** 或 **Low** 时，才能访问此属性。 |                                                                                                                                                                                                                                                                                                                                         |

| **Collider Force** | 在粒子碰撞后对物理碰撞体施力。这对于用粒子推动碰撞体很有用。  |                                                 |
| ------------------ | ------------------------------- | ----------------------------------------------- |
|                    | **Multiply by Collision Angle** | 向碰撞体施力时，根据粒子与碰撞体之间的碰撞角度来缩放力的强度。掠射角将比正面碰撞产生更小的力。 |
|                    | **Multiply by Particle Speed**  | 向碰撞体施力时，根据粒子的速度来缩放力的强度。快速移动的粒子会比较慢的粒子产生更大的力。    |
|                    | **Multiply by Particle Size**   | 向碰撞体施力时，根据粒子的大小来缩放力的强度。较大的粒子会比较小的粒子产生更大的力。      |

| **Send Collision Messages** | 如果选中此复选框，则允许从脚本中通过 [OnParticleCollision](https://docs.unity3d.com/cn/current/ScriptReference/MonoBehaviour.OnParticleCollision.html) 函数检测粒子碰撞。 |
| --------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| **Visualize Bounds**        | 在 Scene 视图中预览每个粒子的碰撞球体。                                                                                                                        |
