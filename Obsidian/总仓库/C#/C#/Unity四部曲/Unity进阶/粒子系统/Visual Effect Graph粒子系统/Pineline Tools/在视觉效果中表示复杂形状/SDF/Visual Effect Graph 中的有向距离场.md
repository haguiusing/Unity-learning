# Visual Effect Graph 中的有向距离场
有序距离场 （SDF） 是 3D 纹理，其中每个纹素存储与对象表面的距离。按照惯例，此距离在对象内部为负值，在对象外部为正值。SDF 可用于创建与复杂几何体交互的粒子效果。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-in-vfx-graph.html#using-sdfs)使用 SDF
在 Visual Effect Graph 中，有几个nodes|节点使用 SDF 创建效果：
- [_Position On Signed Distance Field|有序距离场上的位置_](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Block-SetPosition(SignedDistanceField).html)：将粒子定位在 SDF 的体积内或其表面上。
- [_Conform To Signed Distance Field|符合有符号距离场（Conform To Signed Distance Field_](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Block-ConformToSignedDistanceField.html)）：将粒子吸引到 SDF。这对于将粒子拉向使用其他 Force Block 难以复制的复杂形状非常有用。
- [_Collide With Signed Distance Field|与有符号距离场碰撞_](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Block-CollideWithSignedDistanceField.html)）：模拟粒子与 SDF 之间的碰撞。当您希望粒子与复杂形状碰撞时，这非常有用。
- [_Sample Signed Distance Field|样例有向距离场_](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operator-SampleSDF.html)：对 SDF 进行采样，并使您能够使用结果创建自定义行为。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-in-vfx-graph.html#generating-sdfs)生成 SDF
有多种方法可以生成用于视觉效果的 SDF：
- 您可以在 Unity Editor 中使用窗口生成 SDF，并在运行时使用 API 和内置的 [SDF Bake Tool](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool.html) 生成 SDF。有关详细信息，请参见 [SDF 烘焙工具](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool.html)
- 您可以使用与 [_VFXToolbox_](https://github.com/Unity-Technologies/VFXToolbox)（位于 /DCC~ 文件夹中）捆绑的 Houdini Volume Exporter 烘焙 SDF。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-in-vfx-graph.html#limitations-and-caveats)限制和注意事项
[SDF 烘焙工具](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/sdf-bake-tool.html)（窗口和 API）可生成标准化的 SDF。这意味着底层表面会缩放，使得 Texture 的最大边的长度为 1。如果您使用 Sample Signed Distance Field 等运算符，请记住这一点。