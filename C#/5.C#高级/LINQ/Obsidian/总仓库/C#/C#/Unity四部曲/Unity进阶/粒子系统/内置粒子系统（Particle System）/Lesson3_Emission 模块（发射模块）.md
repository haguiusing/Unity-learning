
# Emission模块
该模块主要用于控制粒子每秒的发射数量、波次、间隔等。
![[Pasted image 20241020222231.png]]
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**                 | **功能**                                           |
| ---------------------- | ------------------------------------------------ |
| **Rate over Time**     | 每个时间单位发射的粒子数。（每秒生成的粒子数量。）                        |
| **Rate over Distance** | 每个移动距离单位发射的粒子数。(每移动一定距离生成的粒子数量。)                 |
| **Bursts**             | 爆发是指生成粒子的事件。通过这些设置可允许在指定时间发射粒子。                  |
| _Time_                 | 设置发射爆发粒子的时间（粒子系统开始播放后的秒数）。                       |
| _Count_                | 设置可能发射的粒子数的值。                                    |
| _Cycles_               | 设置播放爆发次数的值。                                      |
| _Interval_             | 设置触发每个爆发周期的间隔时间（以秒为单位）的值。                        |
| _Probability_          | 控制每个爆发事件生成粒子的可能性。较高的值使系统产生更多的粒子，而值为 1 将保证系统产生粒子。 |
## 1.Rate over Time & Rate over Distance
Rate over Time：每个时间单位发射的粒子数量（秒）
Rate over Distance：每个移动距离单位发射的粒子数量（米）

第一个很容易理解，每秒钟发射多少粒子；第二个参数是每个移动距离单位发射的粒子数量，举个例子：假如该值设为3，把粒子比作汽车，汽车向前移动10米，那么就向外发射30个粒子，也就是每移动一米，就发射3颗粒子。

这两个值不相互冲突，假如10秒内汽车（粒子系统）移动了20米，那么就要发射（10×参数1） + （20×参数2）个粒子数，也就是各自计算各自所发射的粒子数

## 2.Bursts
该参数主要用于粒子爆发的参数设置、比如爆炸、或间歇性的粒子喷射之类的效果
注：该参数和上述两个参数依旧相互不冲突，各管各的

下面是演示效果以及参数设置

该粒子每波发射30个，波次间隔1秒，无限发射
![[Pasted image 20241020222246.png]]

参数	描述:
Time	设置发射爆发粒子的时间
Count	设置发射的粒子数
Cycles	设置发射波次，可自定义波次，也可选择无限波次
Interval	设置每个爆发周期的间隔时间
Probability	设置每个爆发周期生成粒子的可能性
解释Probability: 如果Count设置为30.该值设置1,那么每波必定发射30个粒子，如果设置为0，那么不会产生一个粒子。具体也不是相乘的关系，而是一个随机的设置，只能说越接近1也就越接近Count设置的值。

## 3.API

由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Emission 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-emission.html)。