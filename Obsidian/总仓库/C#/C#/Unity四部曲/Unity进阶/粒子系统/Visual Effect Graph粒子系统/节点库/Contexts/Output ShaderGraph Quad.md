# Output ShaderGraph Quad
菜单路径 : **Context > Output Particle ShaderGraph Quad**

您可以在专用的 Shader Graph 输出中使用自定义 Shader Graph。有关常规 Shader Graph 工作流程的更多信息，请参阅[使用 Shader Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Snippets/sg-working-with.md)。

此输出类似于 [Output Particle Quad。](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputPrimitive.html)

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphPlanarPrimitive.html#context-settings)Context settings

|设置|类型|描述|
|---|---|---|
|**Shader Graph**|ShaderGraphVfxAsset|指定[Shader Graph](https://docs.unity3d.com/Packages/com.unity.shadergraph@latest)Unity 用于渲染此输出生成的粒子。将 Shader Graph 分配给此字段时，Inspector 会显示 Shader Graph 中的所有 Surface Options，从而允许您在 Inspector 中为上下文编辑 Shader Graph 属性。  <br>Context 属性填充了来自 Shader Graph 的兼容公开输入。  <br>有关此设置添加到 Inspector 的 Surface Options 的更多信息，请参阅您分配的 Shader Graph 类型的文档。例如，如果您分配了 HDRP 光照 Shader Graph，请参阅[光照 Shader Graph](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/master-stack-lit.html).|
|**Primitive Type**|枚举|**（检查器）**指定此 Context 用于渲染每个粒子的基元。选项包括：  <br>• **四边形**：将每个粒子渲染为四边形。  <br>• **Triangle**：将每个粒子渲染为三角形。  <br>• **Octagon**：将每个粒子渲染为八边形。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphPlanarPrimitive.html#context-properties)Context properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Crop Factor**|float|裁剪八边形粒子形状的量。这消除了透明像素，从而实现更紧密的贴合并减少潜在的过度绘制。  <br>仅当将 **Primitive Type （基元类型**） 设置为 **Octagon** 时，才会显示此属性。|

Shader Graph 与 VFX 集成的工作流程在 2023.3 中发生了变化。**Shader Graph** 设置已从大多数粒子输出中删除，Shader Graph 现在是独立的输出。

VFX Graph 在导入时自动将现有资源从旧工作流程迁移到新工作流程。