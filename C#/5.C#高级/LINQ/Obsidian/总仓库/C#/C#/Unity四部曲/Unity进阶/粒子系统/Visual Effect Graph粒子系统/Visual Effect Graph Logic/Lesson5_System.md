# System|系统

System 是指定义视觉效果的独立部分的一个或多个 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html)。系统可以是粒子系统、粒子条带系统、网格或生成机器。在坐标图视图中，System 在其包含的 Context 周围绘制一个虚线框。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/SystemDrawBox.png)

多个系统可以在 Visual Effect Graph 中相互交互：
- **Spawn(生成)**系统可以在一个或多个 Particle System中**生成粒子**。这是生成粒子的主要方法。
    
- **粒子系统**可以使用 GPU 事件在其他**粒子系统中****生成粒子**。这种替代方法可以基于模拟事件（如粒子消亡）从其他粒子生成粒子。
    
- **生成**系统可以**启用和禁用**其他**生成系统**。这允许您使用管理其他 Spawn System 的主 Spawn System 来同步粒子发射。
    

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Systems.html#system-simulation-spaces)## System simulation spaces|系统仿真空间
某些系统使用模拟空间属性来定义用于模拟其内容的参考空间：
- **本地空间**系统在本地模拟包含 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html)的游戏对象的效果。
- **世界空间**系统独立于包含 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html)的游戏对象来模拟效果。

无论系统的模拟空间如何，您都可以使用 [Spaceable Properties](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#spaceable-properties) 来访问 Local 或 World Values。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Systems.html#setting-a-system-simulation-space)设置 System 仿真空间
System 在其包含的每个 Context 的右上角显示其模拟空间。这是系统的**模拟空间标识符**。如果 Context 不使用处理任何依赖于模拟空间的内容，则它不会显示模拟空间标识符。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/SystemSpaceIdentifier.png)

要更改系统的模拟空间，请单击系统的模拟空间标识符以在兼容空间之间循环。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/SystemSpaceLocalWorld.png)

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Systems.html#simulation-space-identifiers-in-properties)Properties 中的模拟空间标识符
某些 [Spaceable Properties](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html) 显示较小版本的模拟空间标识符。这不会更改系统的模拟空间，而是允许您在不同于系统模拟空间的空间中表示值。例如，System 可以在世界空间中进行模拟，但 Property 可以是本地位置。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/SystemSpaceLocalWorldSmall.png)