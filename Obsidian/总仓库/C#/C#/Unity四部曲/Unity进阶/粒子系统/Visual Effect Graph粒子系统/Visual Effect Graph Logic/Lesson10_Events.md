## Events|事件
事件定义 Visual Effect Graph [**处理**工作流程](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#processing-workflow-(vertical-logic))的输入。Spawn 和 Initialize [上下文](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html)使用 事件 作为其输入。通过 Event，Visual Effect Graph 可以：
- 开始和停止生成粒子。
- 读取从 C# 脚本发送[的事件属性负载](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#event-attribute-payloads)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#creating-events)创建事件
[![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventContexts.png)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventContexts.png)
通常，Event 只是一个表示 Event 名称的字符串。要在 Visual Effect Graph 中接收事件，请创建一个 Event [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html)，并在 **Event Name** 属性中键入要接收的事件的名称。事件上下文没有输入流端口，只能将其输出流端口连接到 Spawn 或 Initialize 上下文。

要创建 Event Context：
1. 在 [Visual Effect Graph 窗口中](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphWindow.html)，右键单击空白区域。
2. 从菜单中，单击 **Create Node （创建节点**）。
3. 在 Node Creation 菜单中，单击 **Contexts > Event （Context）。**
4. 在 **Event Name （事件名称**） 输入字段中，键入事件的名称。

菜单路径：**Context > Event**
**Event** 上下文定义输入事件名称。它不一定需要唯一的命名；您可以在图中的不同位置复制相同的事件名称。
### 上下文设置

|**设置**|**类型**|**描述**|
|---|---|---|
|**Event Name**|String|事件的名称。此名称显示在 [GetOutputEventNames](https://docs.unity3d.com/2020.2/Documentation/ScriptReference/VFX.VisualEffect.GetOutputEventNames.html) 返回的名称列表中。默认值 **OnPlay** 是 VFX Graph 默认发送到 [Spawn](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Spawn.html) 上下文的事件名称。  <br>**Send** 按钮获取当前打开的场景中的每个活动 Visual Effect 组件并使用 [VisualEffect.SendEvent](https://docs.unity3d.com/ScriptReference/VFX.VisualEffect.SendEvent.html) 将此事件发送给所有这些组件。这表示 **Send** 也会影响不使用您正在编辑的 Visual Effect 资源的组件。|
Flow

|**Port**|**描述**|
|---|---|
|**Output**|与 [Spawn](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Spawn.html) 上下文的连接。|
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#default-events)默认事件
Visual Effect Graph 提供两个默认事件：
- **OnPlay**：当 Unity 将 Event 发送到 Visual Effect 时启用粒子的生成。如果未将 Event 分配给 Spawn Context 的 **Start** 输入流端口，则 Visual Effect Graph 会将此事件隐式绑定到该输入流端口。`Play`
- **OnStop**：当 Unity 将 Event 发送到 Visual Effect 时禁用粒子的生成。如果未将 Event 分配给 Spawn Context 的 **Stop** 输入流端口，则 Visual Effect Graph 会将此事件隐式绑定到该输入流端口。`Stop`

如果将事件上下文连接到 Spawn 上下文的 **Start** 或 **Stop** 输入流端口，则会分别删除对 **OnPlay** 和 **OnStop** 事件的隐式绑定。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#custom-events)自定义事件
如果您不想使用默认 Event，则可以使用 Event Context 来创建自己的自定义 Event。

为此，请首先[创建一个 Event Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#creating-events)，然后在 **Event Name** 属性中键入自定义 Event 的名称。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#event-attribute-payloads)Event Attribute Payloads|事件属性有效负载
Event Attribute 负载是您可以附加到 Event 的属性。要在 Visual Effect Graph 中设置这些属性，您可以在 Spawn Contexts 中使用 **Set [Attribute]** Blocks，但也可以将它们附加到从 C# 脚本发送的事件。有关如何执行后者的信息，请参 阅[组件API](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ComponentAPI.html#event-attributes) 。

Event Attribute Payloads 是隐式穿过图表从 Events 经过 Spawn Contexts，并最终到达 Initialize Context 的属性。若要在 Initialize 上下文中捕获有效负载，请使用 **Get Source Attribute** 运算符或 **Inherit [Attribute]** 块。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#default-visual-effect-event)默认 Visual Effect 事件
默认的 Visual Effect Event 定义 [Visual Effect Graph 在 Visual Effect](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html) 实例**重置**时隐式发送的 Event 的名称。当 effect 首次启动时，或者当 effect 重新启动时，会发生这种情况。

您可以为每个 [Visual Effect Graph 资源](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectGraphAsset.html)单独定义默认 Visual Effect Event。您还可以为 Visual Effect Graph 资源的每个实例覆盖此值。要覆盖实例的默认 Visual Effect Event，请参阅 [Visual Effect Inspector](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectComponent.html) 中**的初始事件名称**。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Events.html#gpu-events)GPU 事件
GPU 事件是 Visual Effect Graph 的一项**实验性功能**。它们允许您基于其他粒子生成粒子。要启用 GPU 事件，请启用 [Visual Effect Preferences](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectPreferences.html) 中的 **Experimental Operators/Blocks** 复选框。

菜单路径：**Context > GPUEvent**
**GPU Event** 上下文允许您从 Update 或 Initialize 上下文中的特定代码块生成新粒子。

|**设置**|**类型**|**描述**|
|---|---|---|
|**Evt**|GPUEvent|来自一个触发 GPU 事件的 [代码块](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Blocks.html) 的连接。触发 GPU 事件的代码块有：  <br>• **Trigger Event Always**。  <br>• **Trigger Event On Die**。  <br>• **Trigger Event Rate**|

| **Port**       | **描述**                                                                                                                                             |
| -------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| **SpawnEvent** | 连接到 [初始化](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Initialize.html) 上下文。来自 Spawn 上下文且 GPU 事件不能混合的流程锚点。 |

GPU 事件是依赖于从其他系统发送的数据的事件上下文，例如，当粒子死亡时。以下更新块可以发送 GPU 事件数据：
- **Trigger Event On Die（死亡时触发事件**）：当粒子死亡时，在另一个系统上生成 N 个粒子。
- **Trigger Event Rate （触发事件速率**）：根据系统中的粒子，每秒（或每行进的距离）生成 N 个粒子。
- **Trigger Event Always（始终触发事件）**：每帧生成 N 个粒子。

这些块连接到 **GPUEvent** 上下文。此 Context 不处理任何 Block，而是连接到子系统的 Initialize Context。

要从父粒子收集数据，子系统必须在其 Initialize Context 中引用 [Source Attributes](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Attributes.html)。为此，子系统可以使用 **Get Source Attribute** 运算符或 **Inherit Attribute** 块。有关直观示例，请参阅下图。
[![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/GPUEvent.png)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/GPUEvent.png)_在此示例中，子 System 继承创建它的粒子的源位置。它还继承了父粒子大约 50% 的速度。