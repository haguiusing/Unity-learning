# Point Cache 烘焙工具
Point Cache 烘焙工具是一种实用程序，可让您烘焙 Point Cache 以用于依赖于复杂几何体的视觉效果。该工具接受输入 [Mesh](https://docs.unity3d.com/Manual/class-Mesh.html) 或 [Texture2D](https://docs.unity3d.com/ScriptReference/Texture2D.html)，并生成一个 [Point Cache 资源](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-asset.html)表示形式供您在视觉效果中使用。

有关什么是 Point Cache 以及它们的用途的信息，请参阅 [Visual Effect Graph 中的 Point Cache](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-in-vfx-graph.html)。

Point Cache 烘焙工具使用指定输入 Mesh/Texture2D 的窗口界面，以及控制输出 Point Cache 的各种属性。要打开 Point Cache 烘焙工具窗口，请单击 **Window > Visual Effects > Utilities > Point CacheBake Tool**。

## 使用 Point Cache 烘焙工具窗口
Point Cache 烘焙工具有两种烘焙模式：
- **Mesh**：从输入 Mesh 资源烘焙 Point Cache。
- **Texture**：从输入 Texture2D 资源烘焙 Point Cache。

根据您选择的模式，该窗口会显示不同的属性来控制烘焙过程。在指定输入 Mesh/Texture2D 并设置属性以后，单击 **Save to pCache file…** 以烘焙 Point Cache 并将结果保存到 Point Cache 资源中。

## 属性
### Common
无论选择何种 **Bake Mode**，这些属性都会出现在检查器中。

|**属性**|**描述**|
|---|---|
|**Bake Mode**|指定用于烘焙 Point Cache 的输入类型。选项：  <br>• **Mesh**：从输入 Mesh 资源烘焙 Point Cache。  <br>• **Texture**：从输入 Texture2D 资源烘焙 Point Cache。|
|**Seed**|用于生成 Point Cache 的随机种子。|
|**File Format**|指定用于对 Point Cache 进行编码的格式。选项：  <br>• **Ascii**：使用 Ascii 编码。  <br>• **Binary**：使用二进制编码。|

### Mesh 烘焙
此部分仅在将 **Bake Mode** 设置为 **Mesh** 时显示。
![](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/pcache-mesh-inspector.png)  
_Point Cache 烘焙工具在检查器中的 Mesh Baking 部分。_

|**属性**|**描述**|
|---|---|
|**Mesh**|用于生成点缓存表示形式的 Mesh。|
|**Distribution**|指定 Point Cache 烘焙工具用于对输入 Mesh 进行采样的点散射方法。选项：  <br>• **Sequential**：在每个三角形/顶点上顺序创建一个点。  <br>• **Random**：在每个三角形/顶点上随机创建一个点。如果 **Bake Mode** 设置为 **Triangle**，此选项不考虑三角形的面积。  <br>• **Random Uniform Area**：在每个三角形上随机创建一个点。此选项考虑三角形的面积。|
|**Bake Mode**|指定如何烘焙 Mesh。选项：  <br>• **Vertex**：在每个顶点的基础上烘焙 Mesh。  <br>• **Triangle**：在每个三角形的基础上烘焙 Mesh。  <br>  <br>此属性仅在将 **Distribution** 设置 **Sequential** 或 **Random** 时显示。如果将 **Distribution** 设置为 **Random Uniform Area**，此属性会消失并隐式使用 **Triangle**。|
|**Export Normals**|指示是否将顶点法线数据导出到 Point Cache。|
|**Export Colors**|指示是否将顶点颜色数据导出到 Point Cache。|
|**Exports UVs**|指示是否将顶点 UV 数据导出到 Point Cache。|
|**Point Count**|为 Point Cache 创建的点的数目。|
|**Seed**|请参见 [Common](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-bake-tool.html#common)。|
|**File Format**|请参见 [Common](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-bake-tool.html#common)。|

#### Mesh Statistics
仅当您将 Mesh 资源分配给 **Mesh** 属性时才显示窗口的此部分。它包含有关输入 Mesh 的信息。

|**Statistic**|**描述**|
|---|---|
|**Vertices**|输入 Mesh 所包含的顶点的数量。|
|**Triangles**|输入 Mesh 所包含的三角形的数量。|
|**Sub Meshes**|输入 Mesh 所包含的子网格的数量。|

### Texture Baking
此部分仅在将 **Bake Mode** 设置为 **Texture** 时显示。

![](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/pcache-texture-inspector.png)  
_Point Cache 烘焙工具在检查器中的 Texture Baking 部分。_

|**属性**|**描述**|
|---|---|
|**Texture**|用于生成 Point Cache 表示形式的 Texture2D。|
|**Decimation Threshold**|指定在烘焙过程中选择要忽略的 Texture2D 像素的方法。选项：  <br>• **None**：不忽略任何像素。  <br>• **Alpha**：使用 Alpha 通道。  <br>• **Luminance**：使用组合 RGB 通道的亮度。  <br>• **R**：使用红色通道。  <br>• **G**：使用绿色通道。  <br>• **B**：使用蓝色通道。|
|**Threshold**|确定在烘焙过程中要忽略哪些像素的阈值。Point Cache 烘焙工具会忽略值低于此值的像素。  <br>此属性仅在将 **Decimation Threshold** 设置为非 **None** 值时才显示。|
|**Randomize Pixels Order**|指示是否随机化点而不是按像素行/列进行排序。|
|**Seed**|请参见 [Common](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-bake-tool.html#common)。  <br>此属性仅在您启用 **Randomize Pixels Order** 时显示。|
|**Export Colors**|指示是否将纹理的颜色数据导出到 Point Cache。|
|**File Format**|请参见 [Common](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/point-cache-bake-tool.html#common)。|

#### Texture Statistics
仅当您将 Texture2D 资源分配给 **Texture** 属性时，才显示窗口的此部分。它包含有关输入 Texture 的信息。

|**Statistic**|**描述**|
|---|---|
|**Width**|输入 Texture2D 的宽度（以像素为单位）。|
|**Height**|输入 Texture2D 的高度（以像素为单位）。|
|**Pixels Count**|输入 Texture2D 包含的像素总数。此值等于 Texture2D 的宽度乘以 Texture2D 的高度。|