[[SDF Bake Tool 窗口]]
[[SDF Bake Tool API]]
[[Visual Effect Graph 中的有向距离场]]
# SDF 烘焙工具
SDF Bake Tool 是一个实用程序，可用于烘焙有向距离场 （SDF），以便在依赖于复杂几何体的视觉效果中使用。该工具采用输入网格并生成其 3D 纹理表示，您可以在视觉效果中使用该[网格](https://docs.unity3d.com/Manual/class-Mesh.html)。

有关什么是 SDF 以及它们可以用于什么的信息，请参阅 [Visual Effect Graph 中的有向距离场](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-in-vfx-graph.html)。

有两种方法可以使用 SDF 烘焙工具：
- 在 Unity Editor 中烘焙 SDF 的窗口界面。有关详细信息，请参见 [SDF Bake Tool 窗口](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool-window.html)。
- 一个 API，可让您在运行时和 Unity Editor 中烘焙 SDF。有关详细信息，请参阅 [SDF 烘焙工具 API](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool-api.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool.html#baking-box) Baking box
为了生成网格的 SDF 表示，SDF Bake Tool 将网格放入一个与轴对齐的边界框（称为烘焙框）中。烘焙箱表示生成的 3D 纹理的形状。要捕获远离网格的 SDF，可以放大烘焙箱。要仅烘焙网格的特定部分，请将烘焙箱设置为小于网格，并放置其中心，使其封装所需的网格部分。