# Sub Emitters 模块
在粒子生命周期的阶段创建附加粒子发射器  (注意要单击“+”添加子粒子)
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/d6f36d89f63c5197a7b450e78503a848.png)
在此模块中可设置子发射器。这些子发射器是在粒子生命周期的某些阶段在粒子位置处创建的附加粒子发射器。
如上图所示，该模块是由一个个子发射器配置项组成的，注释如下图  
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/28cb86335396555a78891512ff87d7e2.png)
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Sub Emitters 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-subEmitters.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

|**_属性_**|**_功能_**|
|---|---|
|**Sub Emitters**|配置一个子发射器列表，并选择它们的触发条件以及它们从父粒子继承的属性。|
## 详细信息
许多类型的粒子都会在其生命周期的不同阶段产生一些效果，而这也可使用粒子系统来实现。例如，子弹离开枪管时可能伴随着一缕烟尘，火球可能会在撞击时爆炸。您可以使用子发射器来创建诸如此类的效果。

子发射器是在场景中创建的或来自[预制件](https://docs.unity3d.com/cn/current/Manual/Prefabs.html)的普通粒子系统对象。这意味着子发射器还可以有自己的子发射器（这种类型的布置对于像烟花这样的复杂效果很有用）。但是，虽然使用子发射器生成大量粒子非常容易，但这可能非常耗费资源。

要触发子发射器，可使用以下条件：
- __Birth__：粒子的创建时间。
- __Collision__：粒子与对象发生碰撞的时间。
- __Death__：粒子的销毁时间。
- __Trigger__：粒子与触发碰撞体相互作用的时间。
- __Manual__：仅在通过脚本进行请求时触发。请参阅 [ParticleSystem.TriggerSubEmitter](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.TriggerSubEmitter.html)。

请注意，__Collision**、**Trigger**、**Death__ 和 **Manual** 事件只能使用 [Emission](https://docs.unity3d.com/cn/current/Manual/PartSysEmissionModule.html) 模块中的爆发发射。

此外，还可使用 **Inherit** 选项将属性从父粒子转移到每个新创建的粒子。可转移属性包括大小、旋转、颜色和生命周期。要控制速度的继承方式，请在子发射器系统上配置 [Inherit Velocity](https://docs.unity3d.com/cn/current/Manual/PartSysInheritVelocity.html) 模块。

还可以通过设置 **Emit Probability** 属性来配置子发射器事件的触发概率。值为 1 可以保证事件将触发，而更小的值则会降低概率。

- 2018–03–28 页面已修订
    
- 在 [2018.1](https://docs.unity3d.com/2018.1/Documentation/Manual/30_search.html?q=newin20181) 版中的 Sub Emitters 模块的条件列表中添加了“Trigger”和“Manual”条件
    
- 在 [2018.3](https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) 版中向粒子 Sub Emitters 模块添加了 Emit Probability 属性