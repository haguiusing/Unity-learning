# Visual Effect 组件 API
为了在场景中创建 [Visual Effect Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html) 的实例，Unity 使用 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html)。Visual Effect 组件附加到场景中的游戏对象，并引用定义视觉效果的 Visual Effect Graph。这允许您在不同的位置和方向创建不同的效果实例，并独立控制每个效果。为了在运行时控制效果，Unity 提供了 C# API，可用于修改 Visual Effect 组件和设置 [Property](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html) overrides。

本文档介绍了常见使用案例，并介绍了使用[组件 API](https://docs.unity3d.com/Documentation/ScriptReference/VFX.VisualEffect.html) 时要考虑的良好实践。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#setting-a-visual-effect-graph)设置 Visual Effect Graph
要在运行时更改 [Visual Effect Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)，请为该属性分配新的 Visual Effect Graph 资源。当您更改 Visual Effect Graph 时，该组件会重置其某些属性的值。`effect.visualEffectAsset`

重置的值为：
- **Total Time(总时间)**：当您更改图表时，API 会调用将此值设置为 0.0f 的函数。`Reset()`
- **Event Attributes（事件属性**）：该组件丢弃所有 Event [Attribues](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html)（事件属性）。

**不**重置的值是：
- **公开的属性覆盖**：如果新的 Visual Effect Graph 资源公开的属性与上一个资源中的属性具有相同的名称和类型，则此属性的值不会重置。
- **Random Seed （随机种子）** 和 **Reset Seed On Play Value （重置播放时种子值**）。
- **默认事件重写**。
- **渲染设置重写**。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#controlling-play-state)控制播放状态
你可以使用 API 来控制效果器播放。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#common-controls)常用控件(与Play Controls 窗口的逻辑一致)
- **Play**：`effect.Play()` 或 `effect.Play (eventAttribute)`（如果需要事件属性）。
- **Stop**：`effect.Stop()` 或 `effect.Stop (eventAttribute)`（如果需要事件属性）。 
- _**Pause_*：`effect.pause = true` 或 `effect.pause = false`。Unity 不会序列化此更改。
- **Step**：`effect.AdvanceOneFrame()`.此控件仅在 `effect.pause` 设置为 `true` 时起作用。
- **Reset Effect**：`effect.Reinit()` 此控件还：
    - 将 `TotalTime` 重置为 0.0f。
    - 将**默认事件**重新发送到 Visual Effect Graph。
- **Play Rate**：`effect.playRate = value`。Unity 不会序列化此更改。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#default-event)默认事件
启用 Visual Effect 组件（或它所附加到的游戏对象）时，它会向图形发送一个 [Event](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html)。默认情况下，此事件为 `OnPlay`，这是 [Spawn Contexts](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Contexts.html#spawn) 的标准开头。

您可以通过以下方式更改默认事件：
- 在 [Visual Effect Inspector](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html) 上，更改 **Initial Event Name** 字段。
- 在组件 API 中 ： .`initialEventName = "MyEventName";`
- 在组件 API 中 ： .`initialEventID = Shader.PropertyToID("MyEventName");`
- 使用 [ExposedProperty 帮助程序类](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ExposedPropertyHelper.html)。[[Pineline Tools]]

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#random-seed-control)随机种子控制
每个 effect 实例都有其随机种子的设置和控件。您可以修改种子以影响 Visual Effect Graph 使用的随机值。
- `resetSeedOnPlay = true/ false`：控制 Unity 是否在您每次调用 `ReInit()` 函数时都计算新的随机种子。这会导致 Visual Effect Graph 使用的每个随机值与之前模拟中的值不同。
- `startSeed = intSeed`：设置一个手动种子，**Random Number** 运算符用它为此视觉效果创建随机值。如果将 `resetSeedOnPlay` 设置为 `true`，Unity 将忽略此值。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#property-interface)Property|属性 接口
要访问 Exposed Properties 的状态和值，您可以在 [Visual Effect 组件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html)中使用多种方法。大多数 API 方法都允许通过以下方法访问属性：
- `string` 属性名称。这很容易使用，但属于最不优化的方法。
- `int` 属性 ID。要从字符串属性名称生成此 ID，请使用 `Shader.PropertyToID(string name)`。这是最优化的方法。
- [ExposedProperty Helper 类](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/ExposedPropertyHelper.html)。此类结合了字符串属性名称提供的易用性，以及整数属性 ID 的效率。[[Pineline Tools]]

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#checking-for-exposed-properties)检查公开的属性
您可以检查组件的 Visual Effect Graph 是否包含特定的公开属性。为此，您可以使用以下组中与属性类型对应的方法：
- `HasInt(property)`
- `HasUInt(property)`
- `HasBool(property)`
- `HasFloat(property)`
- `HasVector2(property)`
- `HasVector3(property)`
- `HasVector4(property)`
- `HasGradient(property)`
- `HasAnimationCurve(property)`
- `HasMesh(property)`
- `HasTexture(property)`
- `HasMatrix4x4(property)`

对于每个方法，如果 Visual Effect Graph 包含与您传入的名称或 ID 相同的正确类型的公开属性，则该方法返回 `true`。否则该方法返回 `false`。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#getting-the-values-of-exposed-properties)获取公开属性的值
组件 API 允许您在组件的 Visual Effect Graph 中获取公开属性的值。为此，您可以使用以下组中与属性类型对应的方法：
- `GetInt(property)`
- `GetUInt(property)`
- `GetBool(property)`
- `GetFloat(property)`
- `GetVector2(property)`
- `GetVector3(property)`
- `GetVector4(property)`
- `GetGradient(property)`
- `GetAnimationCurve(property)`
- `GetMesh(property)`
- `GetTexture(property)`
- `GetMatrix4x4(property)`

对于每个方法，如果 Visual Effect Graph 包含与您传入的名称或 ID 相同的正确类型的公开属性，则该方法返回属性的值。否则，该方法返回属性类型的默认值。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#setting-the-values-of-exposed-properties)设置公开属性的值
组件 API 允许您在组件的 Visual Effect Graph 中设置公开属性的值。为此，您可以使用以下组中与属性类型对应的方法：
- `SetInt(property,value)`
- `SetUInt(property,value)`
- `SetBool(property,value)`
- `SetFloat(property,value)`
- `SetVector2(property,value)`
- `SetVector3(property,value)`
- `SetVector4(property,value)`
- `SetGradient(property,value)`
- `SetAnimationCurve(property,value)`
- `SetMesh(property,value)`
- `SetTexture(property,value)`
- `SetMatrix4x4(property,value)`

每个方法都使用您传入的值重写相应属性的值。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#resetting-property-overrides-and-default-values)重置属性覆盖和默认值
组件 API 允许您将属性重写重置为其原始值。为此，请使用 `ResetOverride(property)` 方法。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#events)事件

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#sending-events)发送事件
组件 API 允许您在运行时将[事件](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html)发送到组件的 Visual Effect Graph。为此，请使用以下任一方法：
- `SendEvent(eventNameOrId)`
- `SendEvent(eventNameOrId, eventAttribute)`

`eventNameOrId` 参数可以是以下类型之一：
- `string` 属性名称。这很容易使用，但属于最不优化的方法。
- `int` 属性 ID。要从字符串属性名称生成此 ID，请使用 `Shader.PropertyToID(string name)`。这是最优化的方法。
- [ExposedProperty Helper 类](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/ExposedPropertyHelper.html)。此类结合了字符串属性名称提供的易用性，以及整数属性 ID 的效率。

可选的 `eventAttribute` 参数向事件附加一个 **Event Attribute Payload**。它们的有效负载提供 Graph 通过事件处理的数据。

**注意**：当您发送一个[事件](https://docs.unity3d.com/ScriptReference/VFX.VisualEffect.SendEvent.html)（或使用 [`.Simulate`](https://docs.unity3d.com/ScriptReference/VFX.VisualEffect.Simulate.html)方法）中，Visual Effect 组件会在其下一个`VisualEffect.Update`中处理发生的所有推送命令，该命令发生在 [`LateUpdate`](https://docs.unity3d.com/Manual/ExecutionOrder.html) 之后。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#event-attributes)事件属性
Event [Attributes 是附加到](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html) [Event](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html) 的属性，可由 Visual Effect Graph 处理。要创建和存储事件属性，请使用 `VFXEventAttribute` 类。Visual Effect 组件负责创建 `VFXEventAttribute` 类的实例，并根据当前分配的 [Visual Effect Graph](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/VisualEffectGraphAsset.html) 创建它们。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#creating-event-attributes)创建 Event Attributes
要创建`VFXEventAttribute` ，请使用 Visual Effect 组件的`CreateVFXEventAttribute()`方法。如果您想多次发送具有相同属性的同一事件，请存储`VFXEventAtrribute` ，而不是在每次发送事件时都创建一个新事件。将事件发送到 Visual Effect Graph 时，Unity 会创建当前状态的 EventAttribute 副本并发送该副本。这意味着，在发送 Event 后，您可以安全地修改 EventAttribute，而不会影响发送到 Visual Effect Graph 的信息。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#setting-the-attributes-payload)设置 Attribute 的有效负载
创建事件属性后，您可以使用类似于 [Property interface 部分](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#PropertyInterface)中描述的 Has/Get/Set 属性方法的 API 来设置属性负载。
- Has：“HasBool”、“HasVector3”、“HasFloat”、...检查属性是否存在。
- Get：`GetBool`, `GetVector3`, `GetFloat`,...获取属性的值。
- Set：`SetBool`, `SetVector3`, `SetFloat`,...设置属性的值。

有关完整的 Attribute API 文档，请参阅 Unity Script Reference 中的 [VFXEventAttribute](https://docs.unity3d.com/Documentation/ScriptReference/VFX.VFXEventAttribute.html)。

属性名称或 ID 可以是以下类型之一：
- 属性名称。这很容易使用，但却是优化程度最低的方法。`string`
- `int` 属性 ID。要从字符串属性名称生成此 ID，请使用 `Shader.PropertyToID(string name)`。这是最优化的方法。
- [ExposedProperty 帮助程序类](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ExposedPropertyHelper.html)。这将字符串属性 name 提供的易用性与整数属性 ID 的效率相结合。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#life-cycle-and-compatibility)生命周期和兼容性
创建事件属性时，它与当前分配给 Visual Effect 组件的 Visual Effect Graph 资源兼容。这意味着您可以使用相同的 `VFXEventAttribute` 将事件发送到同一图形的其他实例。如果将 Visual Effect 组件的 `visualEffectAsset` 属性更改为另一个图形，则不能再使用相同的 `VFXEventAttribute` 向其发送事件。

如果您想在同一个场景中管理多个 Visual Effect 实例并希望共享事件有效负载，您可以存储一个 `VFXEventAttribute` 并在所有实例上使用它。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#example-in-a-monobehaviour)示例（在 MonoBehaviour 中）
```c
VisualEffect visualEffect;
VFXEventAttribute eventAttribute;

static readonly ExposedProperty positionAttribute = "Position"
static readonly ExposedProperty enteredTriggerEvent = "EnteredTrigger"

void Start()
{
    visualEffect = GetComponent<VisualEffect>();
    // Caches an Event Attribute matching the
    // visualEffect.visualEffectAsset graph.
    eventAttribute = visualEffect.CreateVFXEventAttribute();
}

void OnTriggerEnter()
{
    // Sets some Attributes
    eventAttribute.SetVector3(positionAttribute, player.transform.position);
    // Sends the Event
    visualEffect.SendEvent(enteredTriggerEvent, eventAttribute);
}
```

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#debugging)调试
每个 Visual Effect 组件都包含以下调试属性：
- `aliveParticleCount`：整个效果中活动粒子的数量。  
    **注**： 组件每秒异步计算一次此值，这意味着结果可能是在您访问此属性之前一秒渲染的帧中活动粒子的数量。
- `culled`：指示是否有任何摄像机在上一帧中剔除效果。