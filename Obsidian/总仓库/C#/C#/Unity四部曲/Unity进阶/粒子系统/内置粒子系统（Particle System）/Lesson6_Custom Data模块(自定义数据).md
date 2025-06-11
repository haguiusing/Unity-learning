# Custom Data 模块

Custom Data 模块允许您在 Editor 中定义要附加到粒子的自定义数据格式。您也可以在脚本中进行此设置。有关如何在脚本中设置自定义数据并将该数据发送到着色器的更多信息，请参阅[粒子系统顶点流](https://docs.unity3d.com/cn/current/Manual/PartSysVertexStreams.html)的相关文档。

数据可以是__矢量 (Vector)__ 的形式，包含最多 4 个 [MinMaxCurve](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.MinMaxCurve.html) 组件或__颜色 (Color)__，此颜色是支持 HDR 的 [MinMaxGradient](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.MinMaxGradient.html)。使用此数据可在脚本和着色器中驱动自定义逻辑。

可自定义每个曲线/渐变的默认标签，只需单击它们并输入上下文名称即可。将自定义数据传递给着色器时，了解如何在着色器中使用该数据非常有用。例如，曲线可用于自定义的 Alpha 测试，或者可使用渐变向粒子添加辅助颜色。通过编辑标签，很容易在 UI 中保留每个自定义数据条目的记录。

![](https://docs.unity3d.com/cn/current/uploads/Main/CustomDataModule.png)

## 使用自定义数据模块

此模块是 [Particle System （粒子系统](https://docs.unity3d.com/cn/current/Manual/class-ParticleSystem.html)） 组件的一部分。创建新的粒子系统游戏对象或将粒子系统组件添加到现有游戏对象时，Unity 会将 Custom Data 模块添加到粒子系统。默认情况下，Unity 会禁用此模块。要创建新的粒子系统并启用此模块，请执行以下操作：

1. 单击 **GameObject** > **Effects** > **Particle System**。
2. 在 Inspector 中，找到 Particle System 组件。
3. 在 Particle System （粒子系统） 组件中，找到 Custom Data （自定义数据） 模块折叠。
4. 在折叠式标题的左侧，启用复选框。
自定义数据可以有两种形式，Vector和Color

该模块和Renderer模块的Custom Vertex Streams作用差不多

有关如何发送自定义数据到着色器，请参阅：https://docs.unity3d.com/cn/2022.2/Manual/PartSysVertexStreams.html

### API

由于此模块是 Particle System 组件的一部分，因此您可以通过 [ParticleSystem](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem.html) 类访问它。有关如何在运行时访问它和更改值的信息，请参阅[自定义数据模块 API 文档](https://docs.unity3d.com/cn/current/ScriptReference/ParticleSystem-customData.html)。