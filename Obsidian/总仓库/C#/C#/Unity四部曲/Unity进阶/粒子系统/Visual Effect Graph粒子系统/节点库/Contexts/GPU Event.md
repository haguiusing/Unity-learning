# GPU Event
菜单路径：**Context > GPUEvent**

**GPU Event** 上下文允许您从 Update 或 Initialize 上下文中的特定代码块生成新粒子。

## 上下文设置

|**设置**|**类型**|**描述**|
|---|---|---|
|**Evt**|GPUEvent|来自一个触发 GPU 事件的 [代码块](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Blocks.html) 的连接。触发 GPU 事件的代码块有：  <br>• **Trigger Event Always**。  <br>• **Trigger Event On Die**。  <br>• **Trigger Event Rate**|

## Flow

|**Port**|**描述**|
|---|---|
|**SpawnEvent**|连接到 [初始化](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Context-Initialize.html) 上下文。来自 Spawn 上下文且 GPU 事件不能混合的流程锚点。|
