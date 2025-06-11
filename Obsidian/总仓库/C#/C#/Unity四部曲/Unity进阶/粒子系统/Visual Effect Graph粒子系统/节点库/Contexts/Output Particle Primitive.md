# Output Particle Primitive
菜单路径 : **Context > Output Particle [Primitive]** _（输出粒子 （Lit） 四边形、Output Particle （Lit） 三角形、Output Particle （Lit） 八边形）_

Output Particle Primitives （quad/triangle/octagon） 上下文是最常用的输出类型，非常适合各种效果。它们分为常规 （无光照） 和 [光照](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputLitSettings.html) （仅限 HDRP） 两种。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Context-OutputPrimitiveExamples.png)

此 Context 支持以下平面基元：
- **四边形：标准矩形粒子，在大多数情况下都很有用。
- **三角形：与四边形粒子相比，三角形基元的几何体只有一半，对于快速移动的效果或渲染许多粒子的效果非常有用。
- **八角形：八边形基元可用于减少过度绘制，但代价是推送额外的几何体，八边形基元可用于紧密贴合粒子纹理并避免渲染不必要的透明区域。

以下是特定于 Output Particle Primitive 上下文的设置和属性列表。有关此上下文与所有其他上下文共享的通用输出设置的信息，请参阅[全局输出设置和属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputSharedSettings.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputPrimitive.html#context-settings)Context settings

|**设置**|**类型**|**描述**|
|---|---|---|
|**Primitive Type**|Enum|**（检查器）**指定此 Context 用于渲染每个粒子的基元。选项包括：  <br>• **四边形**：将每个粒子渲染为四边形。  <br>• **Triangle**：将每个粒子渲染为三角形。  <br>• **Octagon**：将每个粒子渲染为八边形。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputPrimitive.html#context-properties)Context properties

|**输入**|**类型**|**描述**|
|---|---|---|
|**Crop Factor**|float|裁剪八边形粒子形状的量。这消除了透明像素，从而实现更紧密的贴合并减少潜在的过度绘制。  <br>仅当将 **Primitive Type （基元类型**） 设置为 **Octagon** 时，才会显示此属性。|