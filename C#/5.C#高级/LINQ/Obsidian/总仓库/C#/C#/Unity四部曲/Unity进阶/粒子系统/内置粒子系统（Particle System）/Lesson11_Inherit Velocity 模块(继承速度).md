# Inherit Velocity 模块
控制粒子的速度如何随时间推移而受到其父对象移动的影响  
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/40dad16f5dbc69d5e952ea2db03d91df.png)
在 subemitters 上使用此模块。父系统中的每个粒子都可以在子发射器中生成粒子。此模块从父粒子读取速度，并控制子发射器粒子的速度随时间对该速度的反应。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Inherit Velocity 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-inheritVelocity.html)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**         | **功能**           |                                              |
| -------------- | ---------------- | -------------------------------------------- |
| **Mode**       | 指定如何将发射器速度应用于粒子  |                                              |
|                | Current          | 发射器的当前速度将应用于每一帧上的所有粒子。例如，如果发射器减速，所有粒子也将减速。   |
|                | Initial          | 每个粒子出生时将施加一次发射器的速度。粒子出生后对发射器速度的任何改变都不会影响该粒子。 |
| **Multiplier** | 粒子应该继承的发射器速度的比例。 |                                              |
#### 应用场景演示
模拟一辆蒸汽火车，按照现实世界物理规则，火车行进过程中，喷出的蒸汽应该随着火车向前运动一段时间后才会停止。
- 首先是没有启用Inherit Velocity模块，可以明显看到蒸汽粒子原地上升，并没有随着火车向前运动。
![[56fec734fa195368606980827ac4abda.gif]]
其次是启用了Inherit Velocity模块，并将Mode选项设置为Initial，Multiplier设置为0.5；这次演示就比较符合物理规范了，但是演示的结果并不太好，这个后续可以继续调节的。
![[261466d0a8a6f6b7e50b21c7f26865ca.gif]]
最后是启用了Inherit Velocity模块，并将Mode选项设置为Current，Multiplier设置为0.5；该模式与上面的模式的区别，还是比较明显的。
![[3e4faba0bca8641bee7c914610ac1bc8.gif]]
## 详细信息
这种效果对于从移动对象发射粒子非常有用，例如汽车产生的尘云、火箭产生的烟雾、蒸汽火车烟囱产生的蒸汽，或者粒子最初应以所在对象的速度百分比移动的任何情况。仅当 **Simulation Space** 在[主模块](https://docs.unity3d.com/cn/current/Manual/PartSysMainModule.html)中设置为 **World** 时，此模块才对粒子有影响。

此外也可以使用曲线来影响随时间变化的效果。例如，可对新创建的粒子施加强烈的吸力，使吸力随时间推移而减少。这对于蒸汽火车烟雾可能有用，因为蒸汽火车烟雾会随着时间的推移而缓慢漂移并在发出后停止跟随火车。

Unity 通过以下两种方式之一计算发射器的速度： * 基于附加的刚体组件的速度 * 基于粒子系统的 Transform 组件在当前帧中移动的距离

要指定 Unity 使用的方法，请参阅 Main 模块的 [Emitter Velocity](https://docs.unity3d.com/cn/current/Manual/PartSysMainModule.html) 属性。