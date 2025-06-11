**草稿：此页面上的内容已完成，但尚未经过审核。

**实验：此功能目前处于实验阶段，在以后的主要版本中可能会发生更改。要使用此功能，请启用项目首选项 Visual Effects** 选项卡中的 **Experimental Operators/Blocks**。

# 生成器回调
生成器回调是一个 C# API，允许定义自定义运行时行为并创建新代码块以在 Spawn 上下文中使用。

生成器回调使您能够执行以下操作：
- 控制 Spawn 上下文状态（播放、停止、延迟）
- 读/写入输出生成计数
- 读/写 SpawnEvent 属性

## 编写生成器回调
该 API 的完整参考位于[此处](https://docs.unity3d.com/2019.3/Documentation/ScriptReference/VFX.VFXSpawnerCallbacks.html)。[Unity - Scripting API: VFXSpawnerCallbacks (unity3d.com)](https://docs.unity3d.com/2019.3/Documentation/ScriptReference/VFX.VFXSpawnerCallbacks.html)