# Output ShaderGraph Mesh
菜单路径 : **Context > Output Particle ShaderGraph Mesh**

您可以在专用的 Shader Graph 输出中使用自定义 Shader Graph。有关常规 Shader Graph 工作流程的更多信息，请参阅[使用 Shader Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Snippets/sg-working-with.md)。

此输出类似于 [Output Particle Mesh （输出粒子网格](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputParticleMesh.html)）。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphMesh.html#context-settings)Context settings

|设置|类型|描述|
|---|---|---|
|**Shader Graph**|ShaderGraphVfxAsset|指定[Shader Graph](https://docs.unity3d.com/Packages/com.unity.shadergraph@latest)Unity 用于渲染此输出生成的粒子。当您将 Shader Graph 分配给此属性时，Inspector 会公开 Shader Graph 中的所有 Surface Options，从而允许您在 Inspector 中为上下文编辑 Shader Graph 属性。  <br>Context 属性填充了来自 Shader Graph 的兼容公开输入。  <br>有关此添加到 Inspector 的 Surface Options 的更多信息，请参阅您分配的 Shader Graph 类型的文档。例如，如果您分配了 HDRP 光照 Shader Graph，请参阅[光照 Shader Graph](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/master-stack-lit.html).|
|**Mesh Count**|uint (slider)|**（检查器）**用于此输出的不同网格数（从 1 到 4）。您可以按索引为粒子选择网格。这将使用粒子的 _meshIndex_ 属性。|
|**Lod**|bool|**（检查器）**指示粒子网格是否使用[细节级别](https://docs.unity3d.com/Manual/LevelOfDetail.html)（LOD）。如果启用此设置，则 Context （上下文） 将基于粒子在屏幕上的表观大小进行网格选择。要指定 LOD 网格选择的值，请使用 **Lod Values （Lod 值**） 属性。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphMesh.html#context-properties)Context properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Mesh [N]**|Mesh|用于渲染粒子的网格。网格输入字段的数量取决于 **Mesh Count** 设置。|
|**Sub Mesh Mask [N]**|uint (mask)|用于每个网格的子网格遮罩。子网格遮罩字段的数量取决于 **Mesh Count** 设置。|
|**Lod Values**|Vector4|Context 用于在 LOD 级别之间进行选择的阈值。这些值表示视口沿一个维度的百分比（例如，值 10.0 表示屏幕的 10%）。Context 从左到右（0 到 n）测试值，并且仅当屏幕上的粒子百分比高于阈值时，才选择 LOD 级别。这意味着您必须按降序指定 LOD 值。请注意，您还可以使用网格计数为 1 的 LOD 来剔除屏幕上的小颗粒。仅当启用 **LOD** 设置时，才会显示此属性。|
|**Radius Scale**|float|选择每个粒子的 LOD 级别时要应用的缩放。默认情况下，LOD 系统假定网格边界框是单位框。如果网格边界框小于/大于单位框，则可以使用此属性应用缩放，以便 LOD 阈值与外观大小一致。仅当启用 **LOD** 设置时，才会显示此属性。|

Shader Graph 与 VFX 集成的工作流程在 2023.3 中发生了变化。**Shader Graph** 设置已从大多数粒子输出中删除，Shader Graph 现在是独立的输出。

VFX Graph 在导入时自动将现有资源从旧工作流程迁移到新工作流程。