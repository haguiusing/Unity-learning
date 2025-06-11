# 1.Velocity over Lifetime模块
**Velocity over Lifetime** 模块可控制粒子在其生命周期内的速度。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Velocity over Lifetime 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-velocityOverLifetime.html)。
![[Pasted image 20241021162101.png]]
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**              | **功能**                                |
| ------------------- | ------------------------------------- |
| **Linear X, Y, Z**  | 粒子在 X、Y 和 Z 轴上的线性速度。                  |
| **Space**           | 指定 **Linear X, Y, Z** 轴是参照本地空间还是世界空间。 |
| **Orbital X, Y, Z** | 粒子围绕 X、Y 和 Z 轴的轨道速度。                  |
| **Offset X, Y, Z**  | 轨道中心的位置，适用于轨道运行粒子。                    |
| **Radial**          | 粒子远离/朝向中心位置的径向速度。                     |
| **Speed Modifier**  | 在当前行进方向上/周围向粒子的速度应用一个乘数。              |
## 详细信息
要创建在特定方向上漂移的粒子，请使用 Linear X、Y 和 Z 曲线。

要创建围绕中心位置旋转的粒子效果，请使用 **Orbital** 速度值。此外，可使用 **Radial** 速度值推动粒子朝向或远离中心位置。您可以使用 **Offset** 值为每个粒子定义自定义的旋转中心。
![[Pasted image 20241021163803.png]]

还可以使用此模块调整粒子系统中的粒子速度，而不影响粒子的方向，方法是将所有上述值保留为零，仅修改 **Speed Modifier** 值。
**模块说明:** 对于上述参数的合理应用可以做出很炫的效果，比如漩涡，轮回圈，螺纹，螺旋攻击波等，主要是修改Linear用以指定方向，修改Orbital用于使粒子绕着某轴向旋转。记得在主模块把初始速度设为0，这样更加方便参数计算修改。

# 2.Limit Velocity over Lifetime模块
此模块控制粒子的速度在其生命周期内如何降低。
![[Pasted image 20241021164241.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅[在生命周期内限制速度模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-limitVelocityOverLifetime.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**                   | **功能**                                                |
| ------------------------ | ----------------------------------------------------- |
| **Separate Axes**        | 将轴拆分为单独的 X、Y 和 Z 分量。                                  |
| **Speed**                | 设置粒子的速度限制。                                            |
| **Space**                | 选择速度限制是适用局部空间还是世界空间。仅当启用了 **Separate Axes** 时，此选项才可用。 |
| **Dampen**               | 当粒子速度超过速度限制时，粒子速度降低的比例。                               |
| **Drag**                 | 对粒子速度施加线性阻力。                                          |
| **Multiply by Size**     | 启用此属性后，较大的粒子会更大程度上受到阻力系数的影响。                          |
| **Multiply by Velocity** | 启用此属性后，较快的粒子会更大程度上受到阻力系数的影响。                          |
## 详细信息
该模块非常适合用于模拟会减慢粒子速度的空气阻力，特别是在使用下降曲线随时间推移而降低速度限制的情况下。例如，爆炸或烟花最初以极快的速度爆发，但是发射的粒子在穿过空气的过程中会迅速减速。

**Drag** 选项通过提供基于粒子大小和速度施加不同阻力的选项，提供在物理上更加精确的空气阻力模拟。
**模块说明：** 该模块本质上和Velocity over Lifetime是相对的，一个是控制速度，一个是限制速度。很少有在一起使用的场景。该模块的主要使用场景是爆炸（粒子初始速度很高，然后逐渐减弱到一个均值下落速度）、子弹、炮弹等等。

# 3.Force over Lifetime模块
通过此模块中指定的力（例如风或吸力）可对粒子加速。
![[Pasted image 20241021164410.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Force over Lifetime 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-forceOverLifetime.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **_属性_**      | **_功能_**                                                                        |
| ------------- | ------------------------------------------------------------------------------- |
| **X, Y, Z**   | 在 X、Y 和 Z 轴上施加到每个粒子的力。                                                          |
| **Space**     | 选择是在局部空间还是在世界空间中施力。                                                             |
| **Randomize** | 使用 Two Constants 或 Two Curves 模式时，此属性会导致在每个帧上在定义的范围内选择新的作用力方向。因此会产生更动荡、更不稳定的运动。 |
## 详细信息
流体在移动时经常受到力的影响。例如，烟雾从火中升起时因周围热空气的拉升作用而略微加速。使用曲线在粒子生命周期内进行力的控制，可实现微妙的效果。根据前面的例子，烟雾最初会向上加速，但随着上升的空气逐渐冷却，力会减弱。从火焰冒出的浓烟可能最初会加速，然后随着烟雾的蔓延而减速，如果持续很长时间，甚至可能开始落到地上。

# 4.Color over Lifetime模块
此模块指定粒子的颜色和透明度在其生命周期中如何变化。
![[Pasted image 20241021164822.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Color over Lifetime 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-colorOverLifetime.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性：_**|**_功能：_**|
|---|---|
|**Color**|粒子在其生命周期内的颜色渐变。渐变条的左侧点表示粒子寿命的开始，而渐变条的右侧表示粒子寿命的结束。  <br>  <br>在上图中，粒子从橙色开始，随着时间的推移逐渐变淡，并在其寿命结束时不可见。|
## 详细信息
许多类型的天然和超现实粒子的颜色随时间而变化，因此该属性有许多用途。例如，白色强火花在通过空气时会冷却，魔法可能会突然变成彩虹色。但同样重要的还有 Alpha（透明度）的变化。粒子在达到其生命周期终点时燃尽、褪色或消散是很常见的现象（例如，强火花、烟花和烟雾粒子），通过简单的梯度渐变即可产生这种效果。

当还使用 [Start Color](https://docs.unity3d.com/cn/current/Manual/PartSysMainModule.html) 属性时，此模块会将 2 种颜色相乘，以获得最终的粒子颜色。

# 5.Color by Speed模块
在此模块中可设置粒子的颜色根据粒子速度（每秒的距离单位）变化。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Color by Speed 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-colorBySpeed.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性_**|**_功能_**|
|---|---|
|**Color**|在速度范围内定义的粒子的颜色渐变。|
|**Speed Range**|颜色渐变映射到的速度范围的下限和上限（超出范围的速度将映射到渐变的端点）。|
## 详细信息
燃烧或发光的粒子（如火花）在空气中快速移动时会更明亮地燃烧（例如，当火花接触到更多氧气时），但随着它们减速时会略微变暗。要模拟这一点，可使用 _Color By Speed_ 模块，使渐变在速度范围的上限为白色，而在下限为红色（在火花示例中，较快的粒子将显示为白色，而较慢的粒子为红色）。

# 6.Size over Lifetime
许多效果涉及根据曲线改变粒子大小，这些设置可在此模块中进行。
![[Pasted image 20241021172850.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Size over Lifetime 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-sizeOverLifetime.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性_**|**_功能_**|
|---|---|
|**Separate Axes**|在每个轴上独立控制粒子大小。|
|**Size**|通过一条曲线定义粒子的大小在其生命周期内如何变化。|
## 详细信息
一些粒子通常会在远离发射点时发生大小变化，比如表示气体、火焰或烟雾的粒子。例如，随着时间的推移，烟雾往往会消散并占据更大的体积。为实现此目的，可将烟雾粒子的曲线设置为向上坡道曲线，随着粒子的存活时间而增加。此外还可使用 **Color Over Lifetime** 模块在烟雾蔓延时淡化烟雾，从而进一步增强此效果。

对于燃料燃烧产生的火球，火焰粒子在发射后会趋于膨胀，但后期随着燃料用完和火焰消散而逐渐消失和收缩。在这种情况下，曲线会有一个先上升再下降到较小大小的“驼峰”。

将曲线中指定的值乘以 [Start Size](https://docs.unity3d.com/cn/current/Manual/PartSysMainModule.html) 以获得最终的粒子大小。
## 非均匀粒子缩放
![](https://docs.unity3d.com/cn/current/uploads/Main/PartSysSizeOverLife-InspSepAxes.png)
您可以指定粒子的宽度、高度和深度如何在生命周期内分别变化。在 **Size over Lifetime** 模块中，选中 **Separate Axes** 复选框，然后更改 X（宽度）、Y（高度）和 Z（深度）。请注意，Z 仅用于网格粒子。

# 7.Size by Speed模块
在此模块中可创建能够根据速度（每秒的距离单位）改变大小的粒子。
![[Pasted image 20241021173532.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Size by Speed 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-sizeBySpeed.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性_**|**_功能_**|
|---|---|
|**Separate Axes**|在每个轴上独立控制粒子大小。|
|**Size**|通过曲线定义粒子在速度范围内的大小。|
|**Speed Range**|大小曲线映射到的速度范围的下限和上限（超出范围的速度将映射到曲线的端点）。|
## 详细信息
某些情况下需要能够根据速度改变大小的粒子。例如，发生爆炸时，您可能希望小碎片的加速度高于更大的碎片。使用 **Size By Speed** 并结合简单的斜坡曲线（此曲线可随粒子大小减小使粒子速度按比例增加），即可实现这样的效果。请注意，此模块不应与 **Limit Velocity Over Lifetime** 模块一起使用，除非您希望粒子在减速时改变其大小。

**Speed Range** 指定 X（宽度）、Y（高度）和 Z（深度）形状适用的值范围。仅当大小处于其中一种曲线模式时才应用 Speed Range。快速的粒子将使用曲线右端的值缩放，而较慢的粒子将使用曲线左侧的值。例如，如果指定 10 到 100 之间的 Speed Range：
- 低于 10 的速度将设置粒子大小与曲线的最左边相对应。
- 高于 100 的速度将设置粒子大小与曲线的最右边相对应。
- 10 到 100 之间的速度会将粒子大小设置为由曲线上与速度对应的点确定。在此示例中，速度为 55 将根据曲线的中点设置粒子大小。
## 非均匀粒子缩放
![](https://docs.unity3d.com/cn/current/uploads/Main/PartSysSizeBySpeed-SepAxes.png)
您可以指定粒子的宽度、高度和深度大小如何分别随速度变化。在 **Size by Speed** 模块中，选中 **Separate Axes** 复选框，然后选择粒子的 X（宽度）、Y（高度）和 Z（深度）如何受粒子速度的影响。请注意，Z 仅用于网格粒子。

# 8.Rotation over Lifetime模块
在模块中可配置粒子在移动时旋转。
![[Pasted image 20241021173526.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Rotation over Lifetime 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-rotationOverLifetime.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|属性|功能|
|---|---|
|**Separate Axes**|允许根据每个轴指定旋转。启用此选项后，即可为 X、Y 和 Z 轴中的每个轴设置旋转。|
|**Angular Velocity**|旋转速度（以度/秒为单位）。请参阅下文以了解更多信息。|
## 详细信息
当粒子表示小型实体对象（例如爆炸产生的碎片）时，此设置很有用。分配随机的旋转值将使效果比粒子在飞行时保持直立更加真实。随机旋转也有助于打破粒子形状相似的规律性（重复多次的相同纹理可能会非常明显）。
![使用具有随机 3D 旋转特性的粒子渲染的树叶](https://docs.unity3d.com/cn/current/uploads/Main/PartSysRotOverLifeModule2.gif)
使用具有随机 3D 旋转特性的粒子渲染的树叶
## 选项
角速度选项可在默认的恒定速度基础上进行更改。速度右侧的下拉选单可提供：

|属性|功能|
|---|---|
|**Constant**|粒子旋转的速度，以度/秒为单位。|
|**Curve**|角速度可设定为在粒子的生命周期内变化。Inspector 底部会出现一个曲线编辑器，可用于控制粒子在整个生命周期内的速度变化情况（请参阅下图 A）。如果勾选了 Separate Axes 复选框，则可为每个 X、Y 和 Z 轴赋予曲线速度值。|
|**Random Between Two Constants**|角速度属性具有两个角度，允许在它们之间旋转。|
|**Random Between Two Curves**|角速度可设定为在粒子的生命周期（由曲线指定）内变化。在此模式下，两条曲线均为可编辑状态，每个粒子将在您定义的这两条曲线的范围之间选择一条随机曲线（请参阅下图 B）。|

![](https://docs.unity3d.com/cn/current/uploads/Main/PartSysRotOverLifeModule3.png)
图 A：Z 轴角速度

![](https://docs.unity3d.com/cn/current/uploads/Main/PartSysRotOverLifeModule4.png)
图 B：两条曲线之间的角速度

# 9.Rotation by Speed模块
在此模块中可设置粒子的旋转根据粒子速度（每秒的距离单位）变化。
![[Pasted image 20241021173518.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Rotation by Speed 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-rotationBySpeed.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性_**|**_功能_**|
|---|---|
|**Separate Axes**|为每个旋转轴独立控制旋转。|
|**Angular Velocity**|旋转速度（以度/秒为单位）。|
|**Speed Range**|大小曲线映射到的速度范围的下限和上限（超出范围的速度将映射到曲线的端点）。|
## 详细信息
当粒子表示在地面上移动的固体对象（例如滑坡的岩石）时，可使用此属性。可根据速度按比例设置粒子的旋转，使粒子在表面上滚动的效果具有令人信服。

仅当速度处于其中一种曲线模式时才应用 Speed Range。快速的粒子将使用曲线右端的值旋转，而较慢的粒子将使用曲线左侧的值。