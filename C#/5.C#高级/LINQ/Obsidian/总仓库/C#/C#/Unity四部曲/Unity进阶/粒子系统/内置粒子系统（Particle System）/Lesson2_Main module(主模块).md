[Lesson2_ Main module(主模块)](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%E8%BF%9B%E9%98%B6/Particle%20System%E7%B2%92%E5%AD%90%E7%B3%BB%E7%BB%9F/Lesson2_Main.cs)
# 一、粒子系统主模块
1.阅读前注意事项
注1：由于参数过多且个别参数难以理解，所以本篇的所有参数都作为四级目录存在，方便读者定位查阅

# 2.参考图
![[Pasted image 20241019214546.png]]
Particle System 模块包含影响整个系统的全局属性。大多数这些属性用于控制新创建的粒子的初始状态。要展开和折叠主模块，请单击 Inspector 窗口中的 Particle System 栏。
该模块的名称在 Inspector 中显示为[粒子系统 (Particle System)](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html) 组件所附加到的游戏对象的名称。

## 使用 Main 模块

此模块是 [Particle System （粒子系统](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html)） 组件的一部分。创建新的 Particle System 游戏对象或将 Particle System 组件添加到现有游戏对象时，Unity 会将 Main 模块嵌入到粒子系统中。要创建新的粒子系统：

1. 单击 **GameObject** > **Effects** > **Particle System**。
2. 在 Inspector 中，找到 Particle System 组件。
3. 主模块属性显示在 Particle System （粒子系统） 组件的顶部。

# 3.参数讲解
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。

| **属性**                | **功能**                                                                                                                                                                                                          |                                                                                                           |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| **Duration**          | 系统运行的时间长度。                                                                                                                                                                                                      |                                                                                                           |
| **Looping**           | 如果启用此属性，系统将在其持续时间结束时再次启动并继续重复该循环。                                                                                                                                                                               |                                                                                                           |
| **Prewarm**           | 如果启用此属性，系统将初始化，就像已经完成一个完整周期一样（仅当 **Looping** 也启用时才有效）。                                                                                                                                                          |                                                                                                           |
| **Start Delay**       | 启用此属性后，系统开始发射前将延迟一段时间（以秒为单位）。                                                                                                                                                                                   |                                                                                                           |
| **Start Lifetime**    | 粒子的初始生命周期。                                                                                                                                                                                                      |                                                                                                           |
| **Start Speed**       | 每个粒子在适当方向的初始速度。                                                                                                                                                                                                 |                                                                                                           |
| **3D Start Size**     | 如果要分别控制每个轴的大小，请启用此属性。                                                                                                                                                                                           |                                                                                                           |
| **Start Size**        | 每个粒子的初始大小。                                                                                                                                                                                                      |                                                                                                           |
| **3D Start Rotation** | 如果要分别控制每个轴的旋转，请启用此属性。                                                                                                                                                                                           |                                                                                                           |
| **Start Rotation**    | 每个粒子的初始旋转角度。                                                                                                                                                                                                    |                                                                                                           |
| **Flip Rotation**     | 使一些粒子以相反的方向旋转。                                                                                                                                                                                                  |                                                                                                           |
| **Start Color**       | 每个粒子的初始颜色。                                                                                                                                                                                                      |                                                                                                           |
| **Gravity Modifier**  | 缩放 [Physics](https://docs.unity3d.com/cn/current/Manual/class-PhysicsManager.html) 窗口中设置的重力值。值为零会关闭重力。                                                                                                          |                                                                                                           |
| **Simulation Space**  | 控制粒子的运动位置是在父对象的局部空间中（因此与父对象一起移动）、在世界空间中还是相对于自定义对象（与您选择的自定义对象一起移动）。                                                                                                                                              |                                                                                                           |
| **Simulation Speed**  | 调整整个系统更新的速度。                                                                                                                                                                                                    |                                                                                                           |
| **Delta Time**        | 在 **Scaled** 和 **Unscaled** 之间进行选择，其中的 **Scaled** 使用 [Time](https://docs.unity3d.com/cn/current/Manual/class-TimeManager.html) 窗口中的 **Time Scale** 值，而 **Unscaled** 将忽略该值。此属性对于出现在暂停菜单 (Pause Menu) 上的粒子系统非常有用。 |                                                                                                           |
| **Scaling Mode**      | 选择如何使用变换中的缩放。设置为 **Hierarchy**、**Local** 或 **Shape**。Local 仅应用粒子系统变换缩放，忽略任何父级。Shape 模式将缩放应用于粒子起始位置，但不影响粒子大小。                                                                                                    |                                                                                                           |
| **Play on Awake**     | 如果启用此属性，则粒子系统会在创建对象时自动启动。                                                                                                                                                                                       |                                                                                                           |
| **Emitter Velocity**  | 选择 Particle System 如何计算 Inherit Velocity 和 Emission 模块使用的速度。系统可以使用 Rigidbody 组件（如果存在）或通过跟踪 Transform 组件的移动来计算速度。如果不存在 Rigidbody 组件，则系统默认使用其 Transform 组件。                                                       |                                                                                                           |
| **Max Particles**     | 系统中同时允许的最多粒子数。如果达到限制，则移除一些粒子。                                                                                                                                                                                   |                                                                                                           |
| **Auto Random Seed**  | 如果启用此属性，则每次播放时粒子系统看起来都会不同。设置为 false 时，每次播放时系统都完全相同。                                                                                                                                                             |                                                                                                           |
| **Random Seed**       | 禁用自动随机种子时，此值用于创建唯一的可重复效果。                                                                                                                                                                                       |                                                                                                           |
| **Stop Action**       | 当属于系统的所有粒子都已完成时，可使系统执行某种操作。当一个系统的所有粒子都已死亡，并且系统存活时间已超过 Duration 设定的值时，判定该系统已停止。对于循环系统，只有在通过脚本停止系统时才会发生这种情况。                                                                                                      | (要生效不能勾选循环)                                                                                               |
|                       | None                                                                                                                                                                                                            | 无                                                                                                         |
|                       | Disable                                                                                                                                                                                                         | 播放完所有粒子后，禁用游戏对象。                                                                                          |
|                       | Destroy                                                                                                                                                                                                         | 播放完所有粒子后，销毁游戏对象。                                                                                          |
|                       | Callback                                                                                                                                                                                                        | 播放完所有粒子后，将 播放完所有粒子后， 回调发送给附加到游戏对象的任何脚本。                                                                   |
| **Culling Mode**      | 选择粒子在屏幕外时是否暂停粒子系统模拟。在屏幕外时进行剔除具有最高效率，但您可能希望继续进行非一次性 (off-one) 效果的模拟。                                                                                                                                             |                                                                                                           |
|                       | Automatic                                                                                                                                                                                                       | 循环系统使用 Pause，而所有其他系统使用** Always Simulate**。                                                               |
|                       | Pause And Catch-up                                                                                                                                                                                              | 系统在屏幕外时停止模拟。当重新进入视图时，模拟会执行一大步以到达在不暂停的情况下可实现的程度。在复杂系统中，此选项可能会导致性能尖峰。                                       |
|                       | Pause                                                                                                                                                                                                           | 系统在屏幕外时停止模拟。                                                                                              |
|                       | Always Simulate                                                                                                                                                                                                 | 无论是否在屏幕上，系统始终处理每个帧的模拟。这对于烟花等一次性效果（在模拟过程中这些效果很明显）非常有用。                                                     |
| Ring Buffer Mode      | 保持粒子存活直到它们达到 **Max Particles** 计数，此时新粒子会取代最早的粒子，而不是在它们的寿命终结时才删除粒子。                                                                                                                                              |                                                                                                           |
|                       | Disabled                                                                                                                                                                                                        | 禁用 **Ring Buffer Mode**，以便系统在粒子生命周期终结时删除粒子。                                                               |
|                       | Pause Until Replaced                                                                                                                                                                                            | 在粒子生命周期结束时暂停旧粒子，直至达到** Max Particle** 限制，此时系统会进行粒子再循环，因此旧粒子会重新显示为新粒子。<br>到达数量上限后，直接强制替换之前生成的脚印 ,不会超过数量上限。 |
|                       | Loop Until Replaced                                                                                                                                                                                             | 在粒子生命周期结束时，粒子将倒回到其生命周期的指定比例，直至达到 **Max Particle** 限制，此时系统会进行粒子再循环，因此旧粒子会重新显示为新粒子。<br>可以超出数量上限 直到自然消失。     |
|                       |                                                                                                                                                                                                                 |                                                                                                           |

- Duration：粒子系统运行的时间长度（秒）；
- Looping：若启用此属性，系统将重复播放粒子，也就是开启循环模式（无论是Scene窗口还是运行时）；
- Prewarm：若启用此属性，则粒子系统会在播放前进行预加载，比如漫天星河有3000颗粒子，但按照粒子发射速率，估计要好多秒，勾选此项，一旦播放就会达到预设置的Max Particles（下面有这个属性的介绍）；
- Start Delay：粒子系统发射前将延迟播放一段时间（秒）；
- Start Lifetime：每个粒子的初始生命周期（秒），指粒子被创建出来到自动销毁的这段时间；
- Start Speed：每个粒子的初始速度；
- 3D Start Size：若要分别控制每个轴的大小，请启用该属性；
- Start Size：每个粒子的初始大小，按照给定值等比缩放，若要单独控制三个轴请启用3D Start Size；
- 3D Start Rotation：若要分别控制每个轴的旋转角度，请启用该属性；
- Start Rotation：每个粒子的初始旋转角度，按照给定值等比缩放，若要单独控制三个轴请启用3D Start Rotation；

- Flip Rotation：使一些粒子以相反的方向旋转，数值在0-1之间，数值越大，翻转越多；
（这里不要懵，这个属性和上一个Start Rotation是一对，如果上一个属性有值，比如45，那么下面这个属性就是让一些粒子反转度数为-45，如果这里的值是0.1，那就是让10%的粒子反转，如果值为1，则是全部反转）

- Start Color：每个粒子的初始颜色；
- Gravity Modifier：缩放物理系统的重力值，值为零会关闭重力，想要让粒子受到物理系统的重力影响，将值设为1即可；
- Simulation Space：当前粒子系统的参照坐标，一共三个选项，世界、局部、自定义；
- 自定义坐标可选择一个物体，将参照这个物体的坐标作为参照；
- Simulation Speed：调整粒子系统的更新速度，把粒子特效比作一个视频，值为0.3就是按照0.3倍速播放，值为1则是原速播放；
- Delta Time：在 Scaled 和 Unscaled 之间进行选择，其中的 Scaled 使用 Time Scale 值，而 Unscaled 将忽略该值。

- Scaling Mode：选择如何使用transform中的缩放；
1.Hierarchy 粒子跟随父级进行缩放；
2.Local 忽略父级缩放；
3.Shape 整体缩放是按照当前粒子的发射Shape来缩放的，且不影响粒子本身缩放，选Local则会影响粒子本身缩放。
![[Pasted image 20241020000831.png]]

![[Pasted image 20241020000840.png]]
这里缩放了整体，但粒子本身并没有变扁

- Play On Awake：若启用该属性，则粒子被创建时就开始播放
- Emitter Velocity：发射器速率，使用哪种组件方法来计算速度（.translate .velocity）Rigidbody，Transform；
- Max Particles：系统同时允许的最多粒子数,如果到达该值，则移除生命周期最长的粒子（活得最久的）
- Auto Random Seed：若启用该属性，则每次初始化发射粒子，粒子各自位置不一样。也就是随机。
- Random Seed：若禁用Auto Random Seed，则该值生效，该值用于创建唯一的可重复的粒子效果。
比如拿到我的世界随机种子，就可以生成一个一模一样的世界，该值如果不变，则粒子初始位置永远一致

- Stop Action：当所有粒子的生命周期都结束时，系统自动执行下列某个操作
  1.Disable 禁用当前对象
  2.Destroy 销毁当前对象
  3.CallBack 将 <font color="#ffc000">OnParticleSystemStopped</font> 回调函数发送给附加到游戏对象的任何脚本
注：若Looping处于激活状态，则该属性不生效（因为你都循环了，我就没法结束了）

- Culling Mode：当粒子特效不在摄像机范围内时是否暂停粒子系统模拟
  1.Automatic 自动模式（如果是单次播放则不暂停，如果是循环（Looping）播放则暂停模拟）
  2.Pause And Catch-up 暂停但是没有完全暂停（暂停模拟，但当再次注视时则演算出它应该在的位置）
  3.Pause 暂停模拟
  4.Always Simulate 总是模拟

- Ring Buffer Mode：粒子不会在它们的生命周期结束时死亡，而是会一直存活到最大粒子缓冲区（Max Particles）满，届时新的粒子将取代旧的粒子。
  1.Disabled 禁用该模式
  2.Pause Until Replaced 暂停直到替换
  3.Loop Until Replaced 循环直到替换（Particle lifetimes may loop between a fade-in and fade-out time, in order to use curves for the entire time they are alive. Values are in the 0-1 range / 粒子的生命周期可能在渐入渐出时间之间循环，以便在它们活着的整个时间内使用曲线。取值范围是0 ~ 1 / 这里不理解，贴出原文，你们自己理解吧）



# 4. API

由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Main module API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-main.html)。

[Main module - Unity 手册 (unity3d.com)](https://docs.unity3d.com/cn/current/Manual/PartSysMainModule.html)