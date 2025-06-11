# Output Particle Forward Decal
菜单路径 : **Context > Output Particle Forward Decal**

**Output Particle Forward Decal Context （输出粒子前向贴花**上下文） 使用贴花渲染粒子系统。贴花是 Visual Effect Graph 将纹理投影到的盒子中。然后，Unity 会沿其 xy 平面在任何相交几何体上渲染纹理。这意味着不与任何几何体相交的贴花粒子不可见。请注意，尽管它们不可见，但它们仍然会增加模拟和渲染系统所需的资源强度。

此输出实现最简单的贴花形式。它仅限于混合单个反照率纹理，并且不会被照亮。

我们计划在 Visual Effect Graph 的未来版本中提供更多贴花功能。

以下是特定于 Output Particle Forward Decal 上下文的设置和属性列表。有关此上下文与所有其他上下文共享的通用输出设置的信息，请参阅[全局输出设置和属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputSharedSettings.html)。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Context-OutputForwardDecal.html#context-properties)Context 属性

|输入|类型|描述|
|---|---|---|
|**Main Texture**|Texture 2D|每个粒子使用的贴花纹理。|