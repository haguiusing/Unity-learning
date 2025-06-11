# Event
菜单路径：**Context > Event**

**Event** 上下文定义输入事件名称。它不一定需要唯一的命名；您可以在图中的不同位置复制相同的事件名称。

## 上下文设置

|**设置**|**类型**|**描述**|
|---|---|---|
|**Event Name**|String|事件的名称。此名称显示在 [GetOutputEventNames](https://docs.unity3d.com/2020.2/Documentation/ScriptReference/VFX.VisualEffect.GetOutputEventNames.html) 返回的名称列表中。默认值 **OnPlay** 是 VFX Graph 默认发送到 [Spawn](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Spawn.html) 上下文的事件名称。  <br>**Send** 按钮获取当前打开的场景中的每个活动 Visual Effect 组件并使用 [VisualEffect.SendEvent](https://docs.unity3d.com/ScriptReference/VFX.VisualEffect.SendEvent.html) 将此事件发送给所有这些组件。这表示 **Send** 也会影响不使用您正在编辑的 Visual Effect 资源的组件。|

## Flow

|**Port**|**描述**|
|---|---|
|**Output**|与 [Spawn](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Spawn.html) 上下文的连接。|
