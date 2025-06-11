# Output Particle URP Lit Decal
**Output Particle URP Lit Decal** 上下文使用贴花来渲染粒子系统。贴花是 Visual Effect Graph 将纹理投影到的框。Unity 在沿贴花 xy 平面相交的任何几何体上渲染该纹理。这意味着不与任何几何体相交的贴花粒子不可见。当贴花不可见时，它仍然会增加模拟和渲染系统所需的资源强度。

此上下文可以使用 Base Color map （albedo）、Normal Map、Metallic Map 和/或 Occlusion Map 将其属性投影到表面上。

要使用此上下文，请将 [URP Decal Renderer 功能](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest?subfolder=/manual/renderer-feature-decal.html)添加到您的 Renderer 中。有关更多信息，请参阅[如何添加渲染器功能](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest?subfolder=/manual/urp-renderer-feature-how-to-add.html)。

菜单路径 ：**上下文 > 输出粒子 URP 光照贴花**

**Output Particle URP Lit Decal** Context 可以影响它投影到的表面的以下属性：
- 基色
- 金属度
- 环境光遮蔽
- 平滑
- 正常

粒子沿其正 Z 轴投影其属性。

以下是特定于 Output Particle URP 光照贴花上下文的设置和属性列表。有关此上下文与所有其他上下文共享的通用输出设置的信息，请参阅[Output Lit Settings 和 Properties](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputLitSettings.html)。

# Context Settings

|**输入**|**类型**|**描述**|
|---|---|---|
|**Normal Opacity Channel**|Enum|使用此下拉列表选择控制法线贴图不透明度的贴图 ：  <br>• **Base Color Map Alpha**：使用**基础贴图**的 Alpha 通道来控制不透明度。  <br>• **Metallic Map Blue**：使用 **Metallic Map** 的蓝色通道来控制不透明度。|
|**MAOS Opacity Channel**|Enum|使用此下拉列表选择 **MAOS 贴图 **的来源 **（金属、环境光遮蔽、平滑度）不透明度：  <br>• **基础颜色贴图 Alpha**：使用**基础贴图**的 Alpha 通道来控制 MAOS 贴图的不透明度。  <br>• **Metallic Map Blue**：使用 **Metallic Map** 的蓝色通道来控制其不透明度。|
|**Affect Base Color**|Bool|启用此复选框可使此贴花使用 **Base Color** 属性。禁用此属性后，贴花对 Base Color 没有影响。启用或禁用此属性时，HDRP 仍使用基色的 Alpha 通道作为其他属性的不透明度。|
|**Affect MAOS**|Bool|Inspector 使贴花影响 Metallic、Ambient Occlusion 和 Smoothness 表面属性。此属性在 Inspector 窗口中公开以下属性：  <br>• Use Occlusion Map  <br>• Use Metallic Map  <br>**Affect MAOS** 还会在输出上下文中公开以下属性。在 VFX Graph 中，每种纹理类型都存储在特定的颜色通道中：<br  <br>• **Metallic**：贴花蒙版纹理的红色通道。  <br>• **Ambient Occlusion**：贴花蒙版纹理的绿色通道。  <br>• **Smoothness**：贴花遮罩纹理的 Alpha 通道。  <br>![贴花纹理的红色、绿色和 Alpha 通道中的金属、环境光遮蔽和平滑度贴图。](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/MaskMapAndDetailMap2.png)|
|**Use Occlusion Map** **[URP]**|Bool|(**检查器**）指示输出是否接受 Occlusion Map 来模拟环境照明的阴影。  <br>此属性仅在启用 **MAOS Opacity Channel** 时显示。|
|**Use Metallic Map** **[URP]**|Bool|(**检查器**）指示输出是否接受金属贴图以将金属度值乘以。  <br>此属性仅在启用 **MAOS Opacity Channel** 时显示。|
|**Decal Layer**|Enum|指定 Unity 将贴花投影到哪些材质的图层。Unity 会将贴花显示在使用匹配贴花层的任何网格渲染器或地形上。|
|**Smoothness Source**|Enum|**（检查器）**指定平滑度贴图源。它可以是 Metallic Map 或 Base Color Map（基础颜色贴图）的 Alpha 通道（如果在输出中使用）。仅当启用了相应的映射时，单个枚举选项才可用。|
|**Smoothness**|Float (slider)|粒子的平滑度。更平滑的表面会更均匀地反射光线，从而产生更清晰的反射。  <br>此属性仅在启用 **Affect MAOS （影响 MAOS）** 时显示|
|**Metallic**|Float (slider)|颗粒的金属丰度。金属表面更能反映其环境，从而使其反照率颜色不太明显。  <br>仅当 Material Type （材质类型） 设置为 Standard （标准） 或 Simple Lit （简单光照） 并启用 **Affect MAOS （影响 MAOS）** 时，才会显示此属性。|
|**Occlusion Map** **[URP]**|Texture2D|控制材质表面的遮挡。有关遮挡映射及其效果的更多信息，请参见 [遮挡映射 （https://docs.unity3d.com/Manual/StandardShaderMaterialParameterOcclusionMap.html）。  <br>此属性仅在您启用 **Affect MAOS**（影响 MAOS）**时显示。|

# Context Properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Fade Factor**|Float|更改此值可淡入和淡出贴花。值为 0 时，贴花完全透明，值为 1 时不会更改整体不透明度。|
|**Angle Fade**|Vector2|使用 min-max 滑块可根据 Decal 向后方向与接收表面的顶点法线之间的角度来控制贴花的淡出范围（以度为单位）。此值限制在 0 到 180 度之间。|
|**Normal Alpha**|Float|使用滑块控制表面法线与 Normal 贴图中的法线之间的混合因子。|
|**Ambient Occlusion**|Float|使用滑块缩放 Occlusion Map 中包含的 Ambient occlusion 值。|

# 局限性
- 此输出不支持 Shader Graph。
- 要使此上下文正常工作，请将 [Decal Renderer Feature](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest?subfolder=/manual/renderer-feature-decal.html) 添加到您的 Renderer。
- 每种贴花渲染器技术都有其自身的限制。有关更多信息，请参阅 [Decal Renderer 功能](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest?subfolder=/manual/renderer-feature-decal.html)。