# Output ShaderGraph Strip
菜单路径 : **Context > Output Particle ShaderGraph Strip**

您可以在专用的 Shader Graph 输出中使用自定义 Shader Graph。有关常规 Shader Graph 工作流程的更多信息，请参阅[使用 Shader Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Snippets/sg-working-with.md)。

此输出类似于 Output ParticleStrip Quad。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphStrip.html#context-settings)Context settings

|设置|类型|描述|
|---|---|---|
|**Shader Graph**|ShaderGraphVfxAsset|指定[Shader Graph](https://docs.unity3d.com/Packages/com.unity.shadergraph@latest)Unity 用于渲染此输出生成的粒子。将 Shader Graph 分配给此属性时，Inspector 会显示 Shader Graph 中的所有 Surface Options，从而允许您在 Inspector 中为上下文编辑 Shader Graph 属性。  <br>上下文属性将使用来自 shaderGraph 的兼容公开输入进行填充。  <br>有关此添加到 Inspector 的 Surface Options 的更多信息，请参阅您分配的 Shader Graph 类型的文档。例如，如果您分配了 HDRP 光照 Shader Graph，请参阅[光照 Shader Graph](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/master-stack-lit.html).|
|**Tiling Mode**|Enum|指定输出如何在条带内生成纹理坐标。选项包括：  <br>• **Stretch**：沿整个条带拉伸映射。  <br>• **Repeat Per Segment**：重新启动条带每个段的映射。  <br>• **Custom**：手动提供参考纹理坐标。|
|**Swap UV**|Bool|反转纹理坐标的两个通道。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputShaderGraphStrip.html#context-properties)Context properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Tex Coord**|float|自定义纹理坐标，用作条带每段的参考。  <br>仅当将 **Tiling Mode （平铺模式**） 设置为 **Custom （自定义**） 时，才会显示此属性。|

Shader Graph 与 VFX 集成的工作流程在 2023.3 中发生了变化。**Shader Graph** 设置已从大多数粒子输出中删除，Shader Graph 现在是独立的输出。

VFX Graph 在导入时自动将现有资源从旧工作流程迁移到新工作流程。