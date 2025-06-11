# Output Particle HDRP 体积雾
**输出粒子 HDRP 体积雾**环境允许将雾直接注入 HDRP 的体积光照系统，从而使用 VFX 图形模拟创建动态雾效果。

在使用此输出之前，请确保在项目中启用了体积雾。有关更多信息，请参阅 [HDRP 体积光照](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/Volumetric-Lighting.html)文档页面。

**Output Particle HDRP Volumetric Fog** Context 将系统的所有粒子转换为 HDRP 的体积雾。为此，它将每个粒子转换为实心球体。它将球体的中心设置为粒子的中心，并根据粒子的大小确定球体的大小。

粒子颜色控制雾的颜色，粒子 alpha 控制雾的密度，使颜色和 alpha 成为此上下文的两个主要输入。

菜单路径 : **Context > Output Particle HDRP Volumetric Fog**

# 上下文设置

|**输入**|**类型**|**描述**|
|---|---|---|
|**Fog Blend Mode**|Enum|确定粒子的雾如何与场景中的现有雾混合。此模式与[渲染器优先级](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@latest?subfolder=/manual/VisualEffectComponent.html#rendering-properties)因为它允许在使用 Commutative Blending 模式时控制 Fog Blending 的顺序。此属性类似于[局部体积雾（Local Volumetric Fog）](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/Local-Volumetric-Fog.html#properties)元件。|
|**Falloff Mode**|Enum|确定要应用于 **Fade Radius** 的衰减类型，类似于[局部体积雾（Local Volumetric Fog）](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/Local-Volumetric-Fog.html#properties)元件。|
|**Use Mask Map**|Bool|在输出 Context 上显示 3D 纹理，在粒子的体积中采样。请注意，由于粒子形状是一个球体，因此永远不会对 3D 纹理角进行采样。|
|**Use Distance Fading**|Bool|显示两个端口以控制粒子淡化。距离淡化由“开始”和“结束”距离组成，其中粒子 Alpha 插值为 0（即，当粒子与摄像机的中心距离等于**“距离淡化开始**”时，Alpha 乘以 1，当距离达到**“距离淡化结束**”时，将乘以 0）。距离淡化有助于防止小雾粒子闪烁。|

# Context Properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Fade Radius**|Float|一个介于 0 和 1 之间的值，表示球体边界的柔和程度。较低的值会产生更硬的边缘和更明显的锯齿，因此当雾粒子较小时，建议将该值保持得相当高。|
|**Density**|Float|确定粒子内部雾的密度。密度越高，雾的不透明度就越大。|
|**Mask**|Texture3D|一种 3D 纹理，可在雾粒子内部添加细节。纹理的 RGB 通道乘以粒子颜色，以创建最终的雾颜色。纹理的 Alpha 通道乘以密度和粒子 Alpha 以创建最终的雾密度。|
|**UV Scale**|Vector3|允许缩放 3D 纹理的 UV。|
|**UV Bias**|Vector3|允许在纹理的 UV 中添加偏移。偏移量在缩放后应用。|
|**Distance Fade Start**|Float|确定从摄像机到粒子开始淡化的粒子中心的距离。|
|**Distance Fade End**|Float|确定从摄像机到粒子结束淡化的粒子中心的距离。|

# 局限性
- 此输出不支持 [Shader Graph](https://docs.unity3d.com/Packages/com.unity.shadergraph@latest)。
- 要使此上下文正常工作，请在 HDRP 资源和 HDRP Global Settings 中启用体积雾。
- 雾的质量由场景中 [Fog](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest?subfolder=/manual/Override-Fog.html) volume （雾体积） 组件的设置决定，因此请确保调整这些值以获得更好的视觉效果。
- 仅支持将球体作为输出雾的基元。