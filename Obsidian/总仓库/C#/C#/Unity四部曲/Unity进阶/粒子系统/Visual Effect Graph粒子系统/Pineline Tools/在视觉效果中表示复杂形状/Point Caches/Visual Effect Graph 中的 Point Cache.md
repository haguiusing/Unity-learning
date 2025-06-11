[[Point Cache 资源]]
# Visual Effect Graph 中的 Point Cache
Point Cache 是一种资源，用于存储烘焙到纹理中的一系列点及其属性。您可以使用 Point Cache 在复杂几何体形状中创建粒子效果。

## Point Cache 资源
Unity 将 Point Cache 作为资源进行导入和存储。Point Cache 资源遵循开源 [Point Cache](https://github.com/peeweek/pcache/blob/master/README.md) 规范并使用“.pCache”文件扩展名。它们没有可在检查器中编辑的公共属性，但它们显示一些只读信息，例如粒子数量和表示粒子属性的纹理。有关 Point Cache 资源的更多信息以及对于它们在检查器中显示的属性的说明，请参阅 [Point Cache 资源](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-asset.html)。
![](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/PointCacheImporter.png)

## 使用 Point Cache
[Point Cache 运算符](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Operator-PointCache.html)使您能够在视觉效果中使用 Point Cache。此运算符从 Point Cache 资源中提取粒子数量及其属性，并在运算符中以输出端口的形式公开它们。然后，您可以将端口连接到其他节点，例如 from Map](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Block-SetAttributeFromMap.html) 代码块。

![[Pasted image 20241026012310.png]]

## 生成 Point Cache
有多种方法可以生成用于视觉效果的 Point Cache：
- 内置 [Point Cache 烘焙工具](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-bake-tool.html)
- 随 [_VFXToolbox_](https://github.com/Unity-Technologies/VFXToolbox) 捆绑提供的 Houdini pCache Exporter（位于/DCC~ 文件夹中）使您能够烘焙 Point Cache。
    
- 您可以编写自己的导出器来编写 Point Cache 文件。有关 Point Cache 资源格式和规范的信息，请参阅 [pCache README](https://github.com/peeweek/pcache/blob/master/README.md)。
    

## 限制和注意事项

目前，导入程序仅支持“float”和“uchar”属性类型。任何其他类型的属性都会返回错误。