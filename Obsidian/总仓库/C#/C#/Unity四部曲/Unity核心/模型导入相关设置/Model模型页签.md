[Model模型页签](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%C2%B7%E6%A0%B8%E5%BF%83/%E6%A8%A1%E5%9E%8B%E5%AF%BC%E5%85%A5%E7%9B%B8%E5%85%B3%E8%AE%BE%E7%BD%AE/Lesson43_Model%E6%A8%A1%E5%9E%8B%E9%A1%B5%E7%AD%BE.cs)
![[Pasted image 20240924203342.png]]
![[Pasted image 20240924203401.png]]
![[Pasted image 20240924203432.png]]
![[Pasted image 20240924203515.png]]
![[Pasted image 20240924203540.png]]
# Model 选项卡

选择模型时，模型文件的 **Import Settings** 显示在 Inspector 窗口的 **Model** 选项卡中。这些设置会影响模型中存储的各种元素和属性。Unity 使用这些设置导入每个资源，因此您可以调整任何设置以应用于项目中的不同资源。

![模型的导入设置 (Import settings)](https://docs.unity3d.com/cn/current/uploads/Main/FBXImporter-Model.png)

模型的导入设置 (Import settings)

本节提供有关 Model 选项卡中每个部分的信息：

**(A)** [场景 (Scene)](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#sceneprops) 级别的属性，比如，是否导入光源和摄像机以及使用何种缩放因子。

**(B)** 特定于[网格 (Meshes)](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#meshprops) 的属性。

**(C)** [几何体 (Geometry)](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#geoprops) 相关属性，用于处理拓扑、UV 和法线。

## Scene

| **属性**                     | **功能**                                                                                                                                                                                                                                       |
| -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Scale Factor**           | 当原始文件比例（来自模型文件）不符合项目中的预期比例时，请设置此值以应用导入的模型中的全局比例。Unity 的物理系统希望游戏世界中的 1 米在导入文件中为 1 个单位。                                                                                                                                                        |
| **Convert Units**          | 启用此选项可将模型文件中定义的[模型比例](https://docs.unity3d.com/cn/current/Manual/CreatingDCCAssets.html#Scaling)转换为 Unity 的比例。                                                                                                                               |
| **Bake Axis Conversion**   | 如果启用此属性，当您导入使用与 Unity 不同的轴系统的模型时，可将轴转换的结果直接烘焙到应用程序的资源数据（例如，顶点或动画数据）中。如果禁用此属性，将在运行时补偿根游戏对象的 Transform 组件以模拟轴转换。                                                                                                                               |
| **Import BlendShapes**     | 启用此属性可允许 Unity 随网格一起导入混合形状。请参阅下面的[导入混合形状](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#BlendShapesImportProperties)以了解详细信息。  <br>  <br>**注意：**导入混合形状法线需要在 FBX 文件中具有平滑组。                                                 |
| **Import Visibility**      | 导入 FBX 设置，这些设置定义了是否启用 MeshRenderer 组件（可见）。有关详细信息，请参阅下面的[导入可见性](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#VisibilityImportProperties)。                                                                                |
| **Import Cameras**         | 从 .FBX 文件导入摄像机。有关详细信息，请参阅下面的[导入摄像机](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#CameraImportProperties)。                                                                                                               |
| **Import Lights**          | 从 .FBX 文件导入光源。有关详细信息，请参阅下面的[导入光源](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#LightImportProperties)。                                                                                                                  |
| **Preserve Hierarchy**     | 始终创建一个显式预制件根，即使这个模型只有一个根。通常，FBX Importer 会将模型中的任何空根节点作为优化策略进行剥离。但是，如果您的多个 FBX 文件中包含同一层级视图的某些部分，则可以使用此选项来保留原始层级视图。  <br>  <br>例如，file1.fbx 包含一个骨架和一个网格，file2.fbx 包含相同骨架，但只包含该骨架的动画。如果在不启用此选项的情况下导入 file2.fbx，那么 Unity 将剥离根节点，层级视图将不匹配，并且动画暂停。 |
| **Sort Hierarchy By Name** | 启用此属性可在层级视图中按字母顺序对游戏对象进行排序。禁用此属性可保留 FBX 文件中定义的层级视图顺序。                                                                                                                                                                                        |

### 导入混合形状

Unity 支持混合形状（变形），并可从 3D 建模应用程序导出的 FBX 和 DAE 文件中导入混合形状。此外还可从 FBX 文件导入动画。Unity 支持混合形状在顶点、法线和切线上的顶点级动画。

网格可能同时受到皮肤和混合形状的影响。Unity 导入包含混合形状的网格时，它将使用 [SkinnedMeshRenderer](https://docs.unity3d.com/cn/current/Manual/class-SkinnedMeshRenderer.html) 组件（而不是 [MeshRenderer](https://docs.unity3d.com/cn/current/Manual/class-MeshRenderer.html) 组件），无论其是否具有皮肤。

Unity 将混合形状动画作为常规动画的一部分导入：对 SkinnedMeshRenderer 上的混合形状权重进行动画化。

选择以下两种方法之一来导入具有法线的混合形状：

- 将 [Blend Shape Normals](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#blendshapenormals) 属性设置为 __Import__，以便 Unity 使用来自 FBX 文件的法线。有关更多信息，请参阅下面的 [Blend Shape Normals](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#blendshapenormals) 属性文档。
    
    _或_
    
- 将 [Blend Shape Normals](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#blendshapenormals) 属性设置为 __Calculate__，以便 Unity 使用相同的逻辑来计算网格和混合形状上的法线。
    

**注意：**如果需要混合形状上的切线，则应将 [Tangents](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Model.html#Tangents) 导入设置设为 **Calculate**。

### 导入可见性

Unity 可以通过 **Import Visibility** 属性从 FBX 文件读取可见性属性。值和动画曲线可以通过控制 [Renderer.enabled](https://docs.unity3d.com/cn/current/ScriptReference/Renderer-enabled.html) 属性来启用或禁用 MeshRenderer 组件。

默认情况下，可见性是可以继承的（设置为 true），但可以覆盖。例如，如果父网格上的可见性设置为 0，那么其子网格上的所有渲染器也将被禁用。在此情况下，将为每个子项的 `Renderer.enabled` 属性创建一个动画曲线。

一些 3D 建模应用程序要么不支持可见性属性，要么存在限制。有关更多信息，请参阅：

- [将模型从 Autodesk® Maya® 导入 Unity 的限制](https://docs.unity3d.com/cn/current/Manual/HOWTO-ImportObjectsFrom3DApps.html#Maya)
- [将模型从 Blender 导入 Unity 的限制](https://docs.unity3d.com/cn/current/Manual/HOWTO-ImportObjectsFrom3DApps.html#Blender)

### 导入摄像机

从 .FBX 文件导入摄像机时，Unity 支持以下属性：

| **属性：**                                  | **功能：**                                                                                                                                                                                                                                                        |
| ---------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Projection** 模式                        | 正交或透视。不支持动画。                                                                                                                                                                                                                                                   |
| **Field of View**                        | 支持动画。                                                                                                                                                                                                                                                          |
| 所有 **Physical Camera** 属性                | 如果导入包含物理属性的摄像机（例如，从 Maya 导入），那么 Unity 将创建一个启用了 **Physical Camera** 属性的摄像机，并且采用来自 FBX 文件的 **Focal Length**、**Sensor Type**、**Sensor Size**、**Lens Shift** 和 **Gate Fit** 值。  <br>**_注意：_**并非所有 3D 建模应用程序都有 _Gate Fit_ 概念。当 3D 建模应用程序不支持时，Unity 中的默认值是 **None**。 |
| **Near** 和 **Far** **Clipping Plane** 距离 | Unity 不会根据这些属性导入任何动画。从 3ds Max 导出时，请启用 **Clip Manually** 设置；否则，在导入时将应用默认值。                                                                                                                                                                                     |
| **Target Cameras**                       | 如果导入目标摄像机，Unity 将使用目标对象作为源游戏对象创建具有 [LookAt](https://docs.unity3d.com/cn/current/Manual/class-LookAtConstraint.html) 约束的摄像机。                                                                                                                                    |

### 导入光源

支持以下光源类型：

- 全向光
- 聚光灯
- 方向光
- 面光源

支持以下光源属性：

|**属性：**|**功能：**|
|---|---|
|**Range**|如果启用 **UseFarAttenuation__，则使用** FarAttenuationEndValue**。**FarAttenuationEndValue__ 不支持动画。|
|**Color**|支持动画。|
|**Intensity**|支持动画。|
|**Spot Angle**|Supports animation. Only available for Spot Lights.|

**注意**：在 3ds Max 中，导出的默认值是当前选定帧上的属性值。为了避免混淆，在导出时将播放头移动到第 0 帧。

#### 限制

Some 3D modeling applications apply scaling on light properties. For instance, you can scale a Spot Light by its hierarchy and affect the light cone. Unity does not do this, which may cause lights to look different in Unity.

The FBX format does not define the width and height of area lights. Some 3D modeling applications don’t have this property and only allow you to use scaling to define the rectangle or disc area. Because of this, area lights always have a size of 1 when imported.

不支持目标光照动画，除非它们的动画经过烘焙。

## Meshes 属性部分

|**属性**|   |**功能**|
|---|---|---|
|**Mesh Compression**|   |设置压缩比级别以减小网格的文件大小。提高压缩比会降低网格的精度，方法是在每个组件中使用网格边界和更低的位深来压缩网格数据。  <br>  <br>最好是尽可能调高网格，而不会使网格看起来与未压缩版本有太大区别。这对于[优化游戏大小](https://docs.unity3d.com/cn/current/Manual/ReducingFilesize.html)很有用。|
||**Off**|不使用压缩。|
||**Low**|使用低压缩比。|
||**Medium**|使用中等压缩比。|
||**High**|使用高压缩比。|
|**Read/Write Enabled**|   |启用此选项时，Unity 会将网格数据上传到 GPU 可寻址内存，但也会将其保存在 CPU 可寻址内存中。这意味着 Unity 可以在运行时访问网格数据，您也可以从脚本中访问网格数据。例如，如果您正在按过程生成一个网格，或者想要从一个网格中复制一些数据，可能会希望这样做。  <br>  <br>当禁用此选项时，Unity 会将网格数据上传到 GPU 可寻址内存，然后从 CPU 可寻址内存中删除网格数据。  <br>  <br>默认情况下会禁用此选项。在大多数情况下，为节省运行时内存使用量，请将此选项禁用为禁用状态。有关何时启用 Read/Write Enabled 的信息，请参阅 [Mesh.isReadable](https://docs.unity3d.com/cn/current/ScriptReference/Mesh-isReadable.html)。|
|**Optimize Mesh**|   |确定三角形在网格中列出的顺序以提高 GPU 性能。|
||**Nothing**|无优化。|
||**Everything**|让 Unity 对顶点以及多边形和顶点的索引进行重新排序。此为默认值。|
||**Polygon Order**|仅对多边形重新排序。|
||**Vertex Order**|仅对顶点重新排序。|
|**Generate Colliders**|   |启用此属性可在自动附加网格碰撞体的情况下导入您的网格。这可以用于为环境几何体快速生成碰撞网格，但是对于您正在移动的几何体，应避免使用。|

## Geometry 属性部分

| **属性**                         |                                      | **功能**                                                                                                                                                                                                                                                                                                                                                                                             |
| ------------------------------ | ------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Keep Quads**                 |                                      | 启用此属性可使 Unity 停止将包含四个顶点的多边形转换为三角形。例如，如果您正在使用[曲面细分着色器](https://docs.unity3d.com/cn/current/Manual/SL-SurfaceShaderTessellation.html)，可能会希望启用此选项，因为四边形的曲面细分要比多边形的曲面细分效率更高。  <br>  <br>Unity 可以导入任意类型的多边形（三角形到 N 边形）。顶点数量_超过_四个的多边形将始终转换为三角形，无论此设置如何。然而，如果一个网格有四边形和三角形（或者转换为三角形的 N 边形），那么 Unity 会创建两个子网格来分离四边形和三角形。每个子网格要么只包含三角形，要么只包含四边形。  <br>  <br>**提示：**如果要从 3ds Max 将四边形导入 Unity，必须将其导出为可编辑多边形。 |
| **Weld Vertices**              |                                      | 合并在空间中共享相同位置的顶点，前提是这些顶点总体上共享相同的属性（包括 UV、法线、切线和 VertexColor）。  <br>  <br>这通过减少网格的总数量来优化网格的顶点计数。默认情况下会启用此选项。  <br>  <br>在某些情况下，您可能需要在导入网格时关闭此优化。例如，如果有意包含重复顶点，这些重复顶点在网格中占据相同的位置，那么您可能更喜欢使用脚本来读取或操作单个顶点和三角形数据。                                                                                                                                                                                        |
| **Index Format**               |                                      | 定义网格索引缓冲区的大小。  <br>  <br>**注意：**由于带宽和内存存储大小的原因，通常会希望将 **16 bit** 索引保留为默认设置，并且只在必要时使用 **32 bit__，这也是** Auto__ 选项所使用的设置。                                                                                                                                                                                                                                                                             |
|                                | **Auto**                             | 在导入网格时，让 Unity 根据网格顶点数来决定是使用 16 位索引还是 32 位索引。对于 Unity 2017.3 和更高版本中添加的资源，这是默认设置。                                                                                                                                                                                                                                                                                                                   |
|                                | **16 bit**                           | 导入网格时使用 16 位索引。如果网格较大，则会将其分割为小于 64k 顶点块。对于在 Unity 2017.2 或更低版本中建立的项目，这是默认设置。                                                                                                                                                                                                                                                                                                                       |
|                                | **32 bit**                           | 导入网格时使用 32 位索引。如果使用的是基于 GPU 的渲染管线（例如，使用计算着色器三角形剔除），那么使用 32 位索引将确保所有网格使用相同的索引格式。这降低了着色器的复杂性，因为它们只需要处理一种格式。                                                                                                                                                                                                                                                                                          |
| **Legacy Blend Shape Normals** |                                      | 启用此选项可基于 **Smoothing Angle** 值来计算法线。                                                                                                                                                                                                                                                                                                                                                               |
| **Normals**                    |                                      | 定义是否以及如何计算法线。这对于[优化游戏大小](https://docs.unity3d.com/cn/current/Manual/ReducingFilesize.html)很有用。                                                                                                                                                                                                                                                                                                     |
|                                | **Import**                           | 从文件中导入法线。这是默认选项。如果文件不包含法线，则将计算法线。                                                                                                                                                                                                                                                                                                                                                                  |
|                                | **Calculate**                        | 根据 **Normals Mode**、**Smoothness Source** 和 **Smoothing Angle**（下文）属性来计算法线。                                                                                                                                                                                                                                                                                                                        |
|                                | None                                 | 禁用法线。如果 Mesh 既不是法线贴图，也不受实时光照的影响，请使用此选项。                                                                                                                                                                                                                                                                                                                                                            |
| **Blend Shape Normals**        |                                      | 定义 Unity 是否以及如何为混合形状计算法线。此值应与 **Normals** 属性的值匹配。  <br>  <br>仅当禁用 **Legacy Blend Shape Normals** 时，此属性才可见。                                                                                                                                                                                                                                                                                         |
|                                | **Import**                           | 从文件中导入法线。如果混合形状不包含法线，则 FBX SDK 会使用其自己的方法来计算法线，从而导致法线值通常会不同于 Unity 使用 **Calculate** 选项创建的法线值。                                                                                                                                                                                                                                                                                                       |
|                                | **Calculate**                        | 根据 **Normals Mode**、**Smoothness Source** 和 **Smoothing Angle**（下文）属性来计算法线。                                                                                                                                                                                                                                                                                                                        |
|                                | None                                 | 混合形状法线不会影响基础形状。                                                                                                                                                                                                                                                                                                                                                                                    |
| **Normals Mode**               |                                      | 定义 Unity 计算法线的方式。仅当 **Normals** 设置为 **Calculate** 或 **Import** 时，此属性才可用。                                                                                                                                                                                                                                                                                                                           |
|                                | **Unweighted Legacy**                | 旧版的法线计算方法（在 2017.1 版本之前）。在某些情况下，旧版给出的结果与当前实现给出的结果略有不同。对于在将项目迁移到最新版本的 Unity 之前导入的所有 FBX 预制件，这是默认设置。                                                                                                                                                                                                                                                                                                 |
|                                | **Unweighted**                       | 法线不加权。                                                                                                                                                                                                                                                                                                                                                                                             |
|                                | **Area Weighted**                    | 法线按照图面面积加权。                                                                                                                                                                                                                                                                                                                                                                                        |
|                                | **Angle Weighted**                   | 法线按照每个图面上的顶角加权。                                                                                                                                                                                                                                                                                                                                                                                    |
|                                | **Area and Angle Weighted**          | 法线按照每个图面上的图面面积和顶角加权。这是默认选项。                                                                                                                                                                                                                                                                                                                                                                        |
| **Smoothness Source**          |                                      | 设置如何确定平滑行为（哪些边应该是平滑的，哪些应该是粗糙的）。  <br>  <br>仅当禁用 **Legacy Blend Shape Normals** 时，此属性才可见。                                                                                                                                                                                                                                                                                                           |
|                                | **Prefer Smoothing Groups**          | 尽可能使用模型文件中的平滑组。                                                                                                                                                                                                                                                                                                                                                                                    |
|                                | **From Smoothing Groups**            | 仅使用模型文件中的平滑组。                                                                                                                                                                                                                                                                                                                                                                                      |
|                                | **From Angle**                       | 使用 **Smoothing Angle** 值来确定哪些边应该是平滑的。                                                                                                                                                                                                                                                                                                                                                              |
|                                | **None**                             | 不拆分硬边的任何顶点。                                                                                                                                                                                                                                                                                                                                                                                        |
| **Smoothing Angle**            |                                      | 控制是否为硬边拆分顶点。通常，值越大，产生的顶点越少。  <br>  <br>**注意：**此设置仅用于非常光滑的有机物或非常复杂的多边形模型。否则，最好在 3D 建模软件中手动平滑，然后导入，并且需要将 **Normals** 选项设置为 **Import**（上文）。由于 Unity 仅以单个角度作为硬边的基础，因此您可能会错误地在模型的某些部分上平滑。  <br>  <br>仅当** Normals** 设置为 **Calculate** 时才可用。                                                                                                                                                             |
| **Tangents**                   |                                      | 定义如何导入或计算顶点切线。仅当 **Normals** 设置为 **Calculate** 或 **Import** 时，此属性才可用。                                                                                                                                                                                                                                                                                                                              |
|                                | **Import**                           | 如果 **Normals** 设置为 **Import**，则从 FBX 文件中导入顶点切线。如果网格没有切线，那么将无法使用法线贴图着色器。                                                                                                                                                                                                                                                                                                                            |
|                                | Calculate Tangent Space              | 使用 MikkTSpace 计算切线。如果 **Normals** 设置为 **Calculate**，则这是默认选项。                                                                                                                                                                                                                                                                                                                                       |
|                                | Calculate Legacy                     | 使用旧版算法计算切线。                                                                                                                                                                                                                                                                                                                                                                                        |
|                                | **Calculate Legacy - Split Tangent** | 使用旧版算法计算切线，并在 UV 图表上进行拆分。如果网格上的接缝破坏了法线贴图光照，请使用此属性。此属性通常仅适用于角色。                                                                                                                                                                                                                                                                                                                                     |
|                                | **None**                             | 不导入顶点切线。网格没有切线，因此将无法使用法线贴图着色器。                                                                                                                                                                                                                                                                                                                                                                     |
| **Swap UVs**                   |                                      | 在网格中交换 UV 通道。如果漫射纹理使用光照贴图中的 UV，请使用此选项。Unity 最多支持八个 UV 通道，但并不是所有的 3D 建模应用程序都会导出两个以上的通道。                                                                                                                                                                                                                                                                                                             |
| **Generate Lightmap UVs**      |                                      | 为光照贴图创建第二个 UV 通道。有关更多信息，请参阅[生成光照贴图 UV](https://docs.unity3d.com/cn/current/Manual/LightingGiUvs-GeneratingLightmappingUVs.html) 文档。                                                                                                                                                                                                                                                                |

---

- 在 Unity [2017.1](https://docs.unity3d.com/cn/current/Manual/30_search.html?q=newin20171) 中添加了 **Normals Mode**、**Light** 和 **Camera** 导入选项
- [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) 中添加了 **Materials** 选项卡
- 在 [2017.3](https://docs.unity3d.com/2017.3/Documentation/Manual/30_search.html?q=newin20173) 版中添加了 **Index Format** 属性
- 更新了 read/write enabled 设置的描述并且重新整理了属性表以便与 Unity [2017.3](https://docs.unity3d.com/cn/current/Manual/30_search.html?q=newin20173) 中的改进相符
- 在 Unity [2019.3](https://docs.unity3d.com/cn/current/Manual/30_search.html?q=newin20193) 中添加了 **Legacy Blend Shape Normals** 和 **Sort Hierarchy By Name** 属性