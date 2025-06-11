# Output Particle Mesh
菜单路径 ：**Context > Output [Strip/Particle] Distortion [Quad/Mesh]**

Output Particle Mesh Context 允许您使用网格渲染粒子。它们分为常规 （无光照） 和 [光照](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputLitSettings.html) （仅限 HDRP） 两种。

以下是特定于 Output Particle Mesh Context 的设置和属性列表。有关此上下文与所有其他上下文共享的通用输出设置的信息，请参阅[全局输出设置和属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputSharedSettings.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputParticleMesh.html#context-settings)Context settings

| **设置**         | **类型**        | **描述**                                                                                                                                                                               |
| -------------- | ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Mesh Count** | uint (slider) | **(Inspector)** 用于此输出的不同网格数（从 1 到 4）。您可以按索引为粒子选择网格。这将使用粒子的 _meshIndex_ 属性。                                                                                                           |
| **Lod**        | bool          | **(Inspector)** 指示粒子网格是否使用[细节级别](https://docs.unity3d.com/Manual/LevelOfDetail.html)（LOD）。如果启用此设置，则 Context （上下文） 将基于粒子在屏幕上的表观大小进行网格选择。要指定 LOD 网格选择的值，请使用 **Lod Values （Lod 值**） 属性。 |


## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputParticleMesh.html#context-properties)Context properties

| **输入**                | **类型**      | **描述**                                                                                                                                                                                                 |
| --------------------- | ----------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Mesh [N]**          | Mesh        | 用于渲染粒子的网格。网格输入字段的数量取决于 **Mesh Count** 设置。                                                                                                                                                              |
| **Sub Mesh Mask [N]** | uint (mask) | 用于每个网格的子网格掩码。子网格遮罩字段的数量取决于 **Mesh Count** 设置。                                                                                                                                                          |
| **Lod Values**        | Vector4     | Context 用于在 LOD 级别之间进行选择的阈值。这些值表示视口沿一个维度的百分比（例如，值 10.0 表示屏幕的 10%）。Context 从左到右（0 到 n）测试值，并且仅当屏幕上的粒子百分比高于阈值时，才选择 LOD 级别。这意味着您必须按降序指定 LOD 值。请注意，您还可以使用网格计数为 1 的 LOD 来剔除屏幕上的小颗粒。仅当启用 **LOD** 设置时，才会显示此属性。 |
| **Radius Scale**      | float       | 选择每个粒子的 LOD 级别时要应用的缩放。默认情况下，LOD 系统假定网格边界框是单位框。如果您的网格边界框小于/大于单位框，您可以使用此属性来应用缩放，以便 LOD 阈值与外观大小一致。仅当启用 **LOD** 设置时，才会显示此属性。                                                                               |

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputParticleMesh.html#limitations)局限性

请注意，您不能指定网格和子网格掩码，因为它们是 CPU 表达式，而不是 GPU 表达式。如果要使用各种网格来渲染粒子，则必须使用多网格系统，方法是指定大于 1（最多 4）的网格计数，并使用 _meshIndex_ 属性

每粒子排序和多网格不是输出的全局对象。排序仅发生在使用相同网格索引的粒子之间。这意味着使用网格 0 的粒子始终在使用网格 1 的粒子上方渲染，例如，无论它们与摄像机的距离是多少。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputParticleMesh.html#performance-considerations)性能注意事项

使用多网格实际上会发出不同的绘制调用。这意味着使用此功能时可能会有一些 CPU 开销。它相当于使用多个输出，但优化程度更高。这也意味着使用 LOD 作为优化仅适用于具有许多粒子的大型系统。

如果您使用具有许多顶点的网格，并且您的系统占用率较低（活动粒子数/容量），则最好将渲染模式（输出检查器中的设置）切换为间接，以消除顶点阶段的工作负载并提高性能。