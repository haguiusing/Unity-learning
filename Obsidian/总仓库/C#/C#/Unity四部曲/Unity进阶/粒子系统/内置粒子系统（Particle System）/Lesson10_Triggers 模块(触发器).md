[Lesson10_Triggers](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%E8%BF%9B%E9%98%B6/Particle%20System%E7%B2%92%E5%AD%90%E7%B3%BB%E7%BB%9F/Lesson10_Triggers.cs)
# Triggers 模块

内置粒子系统的 Triggers 模块可用于基于粒子与场景中一个或多个碰撞体的相互作用来访问和修改粒子。启用此模块时，粒子系统将在附加的脚本上调用 [OnParticleTrigger()](https://docs.unity3d.com/cn/current/ScriptReference/MonoBehaviour.OnParticleTrigger.html) 回调，因此可以根据粒子相对于场景中碰撞体的位置来访问粒子列表。
![[Pasted image 20241021214617.png]]

首先，指定粒子可与场景中的哪些碰撞体进行碰撞。为此，请将一个或多个碰撞体分配给 **Colliders** 列表属性。要增加列表中的碰撞体数量，请单击 Colliders 列表下方的 Add (+) 按钮。要从列表中移除某个碰撞体，请选择该碰撞体，然后单击 Remove (-) 按钮。如果尚未将碰撞体分配给列表的索引，则可以使用空条目右侧较小的 Add (+) 按钮来创建和分配新的碰撞体。这将创建一个新的游戏对象作为粒子系统的子项，并将球形碰撞体附加到该游戏对象，然后将碰撞体分配给空条目。

添加碰撞体后，可指定当粒子满足传递特定触发事件类型的条件时将执行的操作。事件类型有四种，它们描述了粒子如何与碰撞体相互作用。这些事件类型如下：
- **Inside**：粒子在碰撞体的边界内。
- **Outside**：粒子在碰撞体的边界外。
- **Enter**：粒子进入碰撞体的边界。
- **Exit**：粒子退出碰撞体的边界。

在 Inspector 中，每种事件类型都有一个下拉选单，可让您选择当粒子通过触发事件的条件时粒子将发生什么情况。选项包括：
- **Callback**：允许您在 OnParticleTrigger() 回调函数中访问粒子。
- **Kill**：销毁粒子。您无法在 OnParticleTrigger() 回调函数中访问粒子。
- **Ignore**：忽略粒子。您无法在 OnParticleTrigger() 回调函数中访问粒子。
### API
由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅 [Triggers 模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-trigger.html)。
### 在 OnParticleTrigger() 中访问粒子
如果选择 **Callback** 作为对某一触发事件的反应，则可以从附加的脚本访问满足事件条件的粒子。为此，首先需要将 `OnParticleTrigger()` 函数添加到附加的脚本。在此函数中，调用 [ParticlePhysicsExtensions.GetTriggerParticles()](https://docs.unity3d.com/cn/current/ScriptReference/ParticlePhysicsExtensions.GetTriggerParticles.html) 函数可获取满足触发事件条件的粒子列表。此函数接受 [ParticleSystemTriggerEventType](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystemTriggerEventType.html)（用于指定需要获取粒子的触发事件，即 **Inside**、**Outside**、**Enter** 还是 **Exit**）以及一个[粒子](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.Particle.html)列表（函数将向其中填充结果）。从这一列表中，可以访问、修改或销毁任何粒子。该函数还可以采用一个可选参数来输出碰撞信息，例如每个粒子触发哪个碰撞体。**Collider Query Mode** 属性通过此参数控制可以获得哪些信息。

有关该 API 以及如何使用该 API 的更多信息，请参阅[下文的示例](https://docs.unity3d.com/cn/current/Manual/PartSysTriggersModule.html#Example)。
## 属性
对于本节中的某些属性，您可以使用不同的模式来设置它们的值。有关可以使用的模式的信息，请参阅[随时间变化的属性](https://docs.unity3d.com/cn/current/Manual/PartSysUsage.html#VaryOverTime)。
#### 1.Colliders

需要指定**Colliders**列表的参数，该属性用于确定**粒子将与哪些碰撞体发生触发事件**；可通过加号或者减号来增删**碰撞体**列表。  
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/60a54e5827452945ee8a52fcd83a8080.png)

上图表示，粒子系统将与测试碰撞体和测试碰撞体(1)发生触发事件

#### 2.触发事件
![[Pasted image 20241021215407.png]]
Inside：粒子在碰撞体的边界内
Outside：粒子在碰撞体的边界外
Enter：粒子进入碰撞体的边界
Exit：粒子退出碰撞体的边界

每种触发事件都有对应的选项，来指定该事件如何被触发：
Callback：允许您在 OnParticleTrigger() 回调函数中访问粒子
Kill：销毁粒子；无法使用回调
Ignore：忽略粒子；无法使用回调

| **属性**      | **描述**                                                                                                                                     |
| ----------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| **Inside**  | 指定粒子系统在粒子位于碰撞体内的每一帧对粒子采取的操作。选项包括：  <br>• **Callback**：将粒子添加到可在 OnParticleTrigger() 回调中获取的列表中  <br>• **Kill**：销毁粒子。  <br>• **Ignore**：忽略粒子。 |
| **Outside** | 指定粒子系统在粒子位于碰撞体外的每一帧对粒子采取的操作。选项包括：  <br>• **Callback**：将粒子添加到可在 OnParticleTrigger() 回调中获取的列表中  <br>• **Kill**：销毁粒子。  <br>• **Ignore**：忽略粒子。 |
| **Enter**   | 指定粒子系统在粒子进入碰撞体的帧对粒子采取的操作。选项包括：  <br>• **Callback**：将粒子添加到可在 OnParticleTrigger() 回调中获取的列表中  <br>• **Kill**：销毁粒子。  <br>• **Ignore**：忽略粒子。    |
| **Exit**    | 指定粒子系统在粒子退出碰撞体的帧对粒子采取的操作。选项包括：  <br>• **Callback**：将粒子添加到可在 OnParticleTrigger() 回调中获取的列表中  <br>• **Kill**：销毁粒子。  <br>• **Ignore**：忽略粒子。    |
#### 3.其他参数

| **Collider Query Mode** | 指定此粒子系统用于获取有关与粒子交互的碰撞体的信息的方法。这增加了处理触发器模块所需的资源，因此，如果不需要任何额外的碰撞信息，请将此属性设置为 **Disabled**。选项是：  <br>• **Disabled**：没有获取关于每个粒子与哪个碰撞体交互的任何信息。 <br>• **One**：获取有关每个粒子交互的第一个碰撞体的信息。如果粒子与帧中的多个碰撞体交互，则返回 **Collider** 列表中与粒子交互的第一个碰撞体。  <br>• **All**：获取有关每个粒子交互的每个碰撞体的信息。                                 |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Radius Scale**        | 粒子的碰撞体边界。允许您更紧密地将粒子的碰撞体边界匹配到粒子的视觉外观。如果粒子为圆形且其纹理具有淡入淡出效果，这将很有用，因为默认粒子碰撞体将在粒子达到视觉效果之前位于触发器内。请注意，当事件实际触发时，此设置不会更改，但是可以延迟或提前达到触发器的视觉效果。  <br>  <br>• 输入 **1** 可以使粒子碰撞体保持同一大小，并使事件在粒子接触碰撞体时发生  <br>• 输入小于 **1** 的值可以使粒子碰撞体更小，并使触发看起来是在粒子穿透碰撞体之前发生  <br>• 输入大于 **1** 的值可以使粒子碰撞体更大，并使触发看起来是在粒子穿透碰撞体之后发生 |
| **Visualize Bounds**    | 指示是否在 Scene 视图中显示每个粒子的碰撞体边界。启用此属性可显示碰撞体边界，而禁用则可隐藏碰撞体边界。                                                                                                                                                                                                                                          |

#### 4.API调用案例
当你设置触发事件的方式为Callback时，就代表系统会自动调用回调函数。

你可以使用
ParticlePhysics.GetTriggerParticles(触发事件类型，返回粒子列表List)
函数来获取触发事件的粒子列表

下图，当粒子穿越预先设置的碰撞器，会触发事件，通过代码获取触发Enter和Exit事件的粒子list，然后循环迭代改变其颜色。
![[Pasted image 20241021220123.png]]