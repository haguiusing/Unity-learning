# Visual Effect 项目设置
Visual Effect Graph Project Settings 是 Unity Project Settings 窗口中的一个部分。您可以在 **VFX > Edit > Project Settings** 中访问这些设置。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/VisualEffectProjectSettings.png)

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/VisualEffectProjectSettings.html#properties)性能：

| 名字                                 | 描述                                                                                                                                                       |
| ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Current Scriptable Render Pipeline | 显示 Unity 用于编译 VFX Graph 着色器的当前渲染管线资源。                                                                                                                    |
| Fixed Time Step                    | 设置您在 **Fixed Delta Time** Simulation 中配置的任何效果的模拟步骤之前的延迟。                                                                                                 |
| Max Delta Time                     | 设置模拟允许的最大固定时间步长。                                                                                                                                         |
| Max Scrub Time                     | 设置在 Timeline 中启用 **Scrubbing** 时可以跳过的最长时间。                                                                                                               |
| Max Capacity(new)                  | 设置系统允许的最大分配计数。Unity 会跳过请求高于此值的分配计数的任何系统。                                                                                                                 |
| Indirect Shader                    | 设置用于间接调用的主计算着色器。  <br>Unity 会自动设置此值。                                                                                                                     |
| Copy Buffer Shader                 | 设置用于 Compute Buffer Copy 的计算着色器。  <br>Unity 会自动设置此值。                                                                                                     |
| Sort Shader                        | 设置用于 Particle Sorting 的计算着色器。  <br>Unity 会自动设置此值。                                                                                                        |
| Strip Update Shader                | 设置用于 Particle Strips 更新的计算着色器。  <br>Unity 会自动设置此值。                                                                                                       |
| Runtime Resources                  | 确定 VFX 使用的哪些运行时资源在运行时可用。例如，[SDF 烘焙工具](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool.html).  <br>Unity 会自动设置此值。 |
| Batch Empty Lifetime               | 在删除最后一个实例后，将空批处理保留指定数量的帧，从而允许创建新实例。如果在此时间范围内未创建任何实例，则会删除空批处理。                                                                                            |

> **注意：**修复了 Delta 时间在 （with ） 的异步更新中工作的问题。N 由当前帧速率决定。在此模式下，在某些帧处可以等于 0。`deltaTime = N * FixedTimeStep``deltaTime = min(deltaTime , MaxDeltaTime)``deltaTime`