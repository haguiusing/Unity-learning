## [Rendering Paths](https://docs.unity3d.com/Manual/RenderingPaths.html)

Unity支持不同的_Rendering Paths_（渲染路径）。您应该根据游戏内容和目标平台／硬件来选择。不同的渲染路径有不同的表现特点，这主要影响光照和阴影。查看[render pipeline](https://docs.unity3d.com/Manual/SL-RenderPipeline.html)获取技术细节.

您项目所使用的渲染路径是在[Graphics Settings](https://docs.unity3d.com/Manual/class-GraphicsSettings.html)选择的. 此外, 你可以为每个 [Camera](https://docs.unity3d.com/Manual/class-Camera.html)重写.

如果一个显卡不支持选择的渲染路径，Unity将会自动选择一个低一点保真度（lower fidelity）的路径。例如，在一个GPU上，不能操作 Deferred Shading 那么 Forward Rendering 将会被使用。

### Deferred Shading

_Deferred Shading_（延迟渲染）是光照阴影保真度最高的渲染路径,很适合有许多实时光照的情况。它需要一定程度的硬件支持。

查看 [Deferred Shading page](https://docs.unity3d.com/Manual/RenderTech-DeferredShading.html)获取更多细节。

### Forward Rendering

_Forward_ 是传统渲染路径。它支持所有典型的Unity图形特性(normal maps, per-pixel lights, shadows etc.)。然而在默认设置下，只有少数最亮的光，在逐像素光照渲染下被渲染。剩下的光在对象顶点或每个对象中被计算。

查看 [Forward Rendering page](https://docs.unity3d.com/Manual/RenderTech-ForwardRendering.html) 获取更多细节.

### Legacy Deferred

_Legacy Deferred (light prepass)_ 和 Deferred Shading 相似, 只是使用不同的技术和不同的平衡。它不支持Unity5的基于物理的standard shader。

查看 [Deferred Lighting page](https://docs.unity3d.com/Manual/RenderTech-DeferredLighting.html)获取更多细节.

### Legacy Vertex Lit

_Legacy Vertex Lit_ 是最低光照保真度的渲染路径，并且不支持实时阴影。它是 Forward rendering path 的子集。

查看 [Vertex Lit page](https://docs.unity3d.com/Manual/RenderTech-VertexLit.html) 获取更多细节.

**NOTE**: _Deferred rendering 不被正投影所支持。如果相机的投影模式被设置为 Orthographic 相交会一直使用Forward rendering。_

### Rendering Paths Comparison（渲染路径的比较）

|                                                                     |                           Deferred                           |                       Forward                       |         Legacy Deferred         |   Vertex Lit   |
|:-------------------------------------------------------------------:|:------------------------------------------------------------:|:---------------------------------------------------:|:-------------------------------:|:--------------:|
|                         **Features**(特性)                          |                                                              |                                                     |                                 |                |
|    Per-pixel lighting (normal maps, light cookies)（逐像素光照）    |                             Yes                              |                         Yes                         |               Yes               |       -        |
|                    Realtime shadows（实时阴影）                     |                             Yes                              |                    With caveats                     |               Yes               |       -        |
|                    Reflection Probes（反射探针）                    |                             Yes                              |                         Yes                         |                -                |       -        |
|               Depth&Normals Buffers（深度&法向缓存）                |                             Yes                              |              Additional render passes               |               Yes               |       -        |
|                      Soft Particles（软粒子）                       |                             Yes                              |                          -                          |               Yes               |       -        |
|                Semitransparent objects（半透明对象）                |                              -                               |                         Yes                         |                -                |      Yes       |
|                       Anti-Aliasing（抗锯齿）                       |                              -                               |                         Yes                         |                -                |      Yes       |
|                   Light Culling Masks（消隐遮罩）                   |                           Limited                            |                         Yes                         |             Limited             |      Yes       |
|                    Lighting Fidelity（光照细度）                    |                        All per-pixel                         |                   Some per-pixel                    |          All per-pixel          | All per-vertex |
|                       **Performance**（表现）                       |                                                              |                                                     |                                 |                |
|          Cost of a per-pixel Light（一个逐像素光照的成本）          |               Number of pixels it illuminates                | Number of pixels * Number of objects it illuminates | Number of pixels it illuminates |       -        |
| Number of times objects are normally rendered（对象通常渲染的次数） |                              1                               |             Number of per-pixel lights              |                2                |       1        |
|            Overhead for simple scenes（简单场景的开销）             |                             High                             |                        None                         |             Medium              |      None      |
|                  **Platform Support**（平台支持）                   |                                                              |                                                     |                                 |                |
|                          PC (Windows/Mac)                           |                   Shader Model 3.0+ & MRT                    |                         ALL                         |        Shader Model 3.0+        |      ALL       |
|                        Mobile (iOS/Android)                         | OpenGL ES 3.0 & MRT, Metal (on devices with A8 or later SoC) |                         ALL                         |          OpenGL ES 2.0          |      ALL       |
|                              Consoles                               |                           XB1, PS4                           |                         All                         |          XB1, PS4, 360          |       -        |


