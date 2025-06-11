# Lights 模块
使用此模块可将实时光照添加到一部分粒子。
![[Pasted image 20241022121253.png]]
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Lights 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-lights.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| 属性                          | 功能                                                                                                                           |
| --------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| **Light**                   | 分配一个[光照](https://docs.unity3d.com/cn/current/Manual/LightingInUnity.html)预制件来描述粒子光照外观。                                       |
| **Ratio**                   | 一个介于 0 和 1 之间的值，表示将接受光照的粒子的比例。                                                                                               |
| **Random Distribution**     | 选择是随机分配还是定期分配光照。设置为 true 时，每个粒子都有根据 Ratio 值随机接受光照的机会。较高的值可增加粒子接受光照的概率。设置为 false 时，由 Ratio 控制新创建的粒子接受光照的频率（例如，每第 N 个粒子将接受光照）。 |
| **Use Particle Color**      | 设置为 True 时，光照的最终颜色将通过其附加到的粒子的颜色进行调制。如果设置为 False，则使用光照颜色而不进行任何修改。                                                             |
| **Size Affects Range**      | 启用此属性后，在光照中指定的 范围 (Range) 将受到粒子大小的影响。                                                                                        |
| **Alpha Affects Intensity** | 启用此属性后，光照的 强度 (Intensity)  将受到粒子 Alpha 值的影响。                                                                                 |
| **Range Multiplier**        | 使用此曲线在粒子的生命周期内将一个自定义乘数应用于光照范围。                                                                                               |
| **Intensity Multiplier**    | 使用此曲线在粒子的生命周期内将一个自定义乘数应用于光照强度。                                                                                               |
| **Maximum Lights**          | 使用此设置可避免意外创建大量光照，大量光照可能会使 Editor 无响应或使应用程序运行速度非常慢。                                                                           |
## 详细信息
Lights 模块是一种为粒子效果添加实时光照的快速方法。此模块可用于使系统将光照投射到周围环境，例如可用于火、烟花或闪电。此外，还可通过该模块让光照从所附着的粒子继承各种属性。这样可以使粒子效果本身的发光更加逼真。例如，为了实现此目的，可使光照随其粒子淡出并使它们共享相同的颜色。

该模块可以非常快速地创建大量实时光照，但实时光照有很高的性能成本，尤其是在前向渲染模式下。如果光照还要投射阴影，性能成本会更高。为了防止意外调整发射速率并因此导致创建数千个实时光照，应使用 Maximum Lights 属性。创建的光照数量超过目标硬件的管理能力可能会导致速度降低和无响应的问题。

Lights模块主要用于为粒子效果快速添加实时光照，注意，粒子本身使用了自发光材质，但粒子对环境的照亮，则是使用Lights模块添加的实时光照效果
![[Pasted image 20241022121405.png]]