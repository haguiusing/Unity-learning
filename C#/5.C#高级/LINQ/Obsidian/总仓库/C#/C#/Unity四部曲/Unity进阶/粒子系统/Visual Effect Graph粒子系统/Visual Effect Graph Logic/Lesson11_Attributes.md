<font color="#ffc000">Attributes是系统中元素的特定数据片段，用于粒子的模拟和渲染，而Properties是可编辑的字段，用于在Visual Effect Graph中创建和操作各种类型的数据。Attributes通常与粒子数据和渲染直接相关，而Properties则提供了一种更通用的方式来操作和重用数据。</font>
# Attributes|属性

属性是附加到 System 中元素的一段数据。例如，粒子的颜色、粒子的位置或生成系统创建的粒子数量都是 Attributes。

系统可以读取或写入 Attributes，以便执行自定义行为并区分元素。

A 系统仅在需要时存储 Attributes。这意味着系统不会存储任何不必要的数据，从而节省内存。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#using-attributes)使用属性

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#writing-attributes)写入属性

要写入 Attribute，请使用 [Block](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html)。块是唯一可以将 Attributes 写入 System 的图形元素。

Visual Effect Graph 仅存储您在模拟数据中写入的 Attribute（如果以后的 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 读取该 Attribute）。这意味着：

- 当您在 Initialize 或 Update Contexts 中写入 Attribute 时，如果以后的 Update 或 Output Context 从该属性中读取，则 Visual Effect Graph 仅将该属性存储在模拟数据中。
- 当您在 Output Contexts 中写入 Attribute 时，Visual Effect Graph 不会将 Attribute 存储在模拟数据中，而只使用 Attribute 进行渲染。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#reading-attributes)读取属性

要从 Attribute 中读取，请使用 Operator 或 Block：

- 使用 **Get Attribute** 运算符。
- 在 **Set Attribute** 块中使用不同的合成模式，具体取决于 Attribute 的上一个值。

**注意**：

- 如果您从 Visual Effect Graph 尚未存储在模拟数据中的 Attribute 读取，则该 Attribute 会传递其默认的常量值。
- 目前，您只能从 Particle 和 ParticleStrip Systems 中的 Attributes 读取。要从 Spawn Systems 中的 Attributes 中读取，请使用 [Spawner 回调](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/SpawnerCallbacks.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#attribute-locations)属性位置

每个系统都将 Attributes 存储在其自己的特定数据容器中。但是，您可以从当前仿真数据池或系统所依赖的另一个数据池中读取 Attribute。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#current)当前

当前 Attribute location （属性） 位置是指您从中读取值**的当前**系统数据容器。例如：

- 来自粒子系统的粒子数据。
- ParticleStrip 系统中的 ParticleStrip 数据。
- 来自 Spawn 上下文或通过 [SendEvent](https://docs.unity3d.com/Documentation/ScriptReference/VFX.VisualEffect.SendEvent.html) [EventAttribute](https://docs.unity3d.com/Documentation/ScriptReference/VFX.VFXEventAttribute.html) 负载发送的 SpawnEvent 数据。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#source)Source|源

source Attribute location （源属性） 位置是指您从中读取值的**上一个**系统数据容器。在系统数据更改后，您只能从系统的第一个 Context 中的源 Attribute 中读取数据。例如，您只能在 Particle / ParticleStrip System Initialize Contexts 中访问 EventAttributes 和 GPU EventAttributes。

- 在 Initialize Particle / Initialize Particle Strips 上下文中：
    - 从传入的 Spawn Contexts。
    - 从其他粒子系统，通过 GPUEvent 生成。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html#variadic-attributes)Variadic Attributes|可变参数属性

某些属性具有**可变参数**属性。这些 Attributes 可以是不同维度的标量或向量，具体取决于模拟和/或渲染所需的组件。

当您从可变参数 Attribute 中读取时，它会使用其默认值从所有其他隐式组件中读取。

例如，可以将 Quad 粒子的**缩放**表示为 **Vector2**（作为 Quad 的宽度和长度），而要表示 Box 粒子的**缩放**，可以使用 **Vector3**（作为立方体的宽度、长度和深度）。设置可变参数属性时，所有通道组合的下拉列表允许您仅写入必要的通道。

另一个示例是 sprite 围绕其法线旋转。您只需要 angle Attribute （**angleZ**） 的 **Z** 分量，因此无需存储 **angleX** 和 **angleY**。