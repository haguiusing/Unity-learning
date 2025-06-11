# 实验性功能
Visual Effect Graph 中的某些功能处于试验状态，因为将来计划进行改进，以使用这些工具改进工作流程。这包括工作流程中的潜在 UX 更改、错误修复或撤销限制。

默认情况下，实验性功能处于禁用状态，这意味着当您创建 Blocks、运算符或 Context 时，它们不会显示在搜索结果中。

要启用实验性功能，请转到 **Visual Effects** >**编辑** > [**首选项**](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectPreferences.html)，然后启用**实验性运算符/阻止程序**。这样，您就可以访问图表中标记为 experimental 的所有节点。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Experimental-features-enable.png)

# 版本 16 / Unity 2023.2 中的实验性功能
本页列出了版本 16 中处于实验状态的 Visual Effect Graph 功能。有关详细信息，请参阅[实验性功能](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/ExperimentalFeatures.html)。

- GPU 事件：
    
    - [GPUEvent](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Context-GPUEvent.html)
    - [GPUEventAlways](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-TriggerEventAlways.html)
    - [GPUEventOnDie](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-TriggerEventOnDie.html)
    - [GPUEventRate](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-TriggerEventRate.html)
- 来自方向和速度的速度：
    
    - [方向和速度的速度（改变速度）](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-VelocityFromDirectionAndSpeed(ChangeSpeed).html)
    - [速度来自方向和速度（新方向）](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-VelocityFromDirectionAndSpeed(NewDirection).html)
    - [方向和速度的速度（随机方向）](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-VelocityFromDirectionAndSpeed(RandomDirection).html)
    - [方向和速度的速度（球形）](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-VelocityFromDirectionAndSpeed(Spherical).html)
    - [方向和速度（切线）的速度](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-VelocityFromDirectionAndSpeed(Tangent).html)
- [粒子输出（Particle Outputs）：](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Context-OutputSharedSettings.html)
    
    - 输出粒子立方体
    - Output ParticleStrip Line
    - Output ParticleStrip Quad（输出 ParticleStrip 四边形）
- 示例操作员：
    
    - [示例属性贴图](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Block-SetAttributeFromMap.html)
    - [采样点缓存](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@16.0/manual/Operator-PointCache.html)