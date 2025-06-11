# 网格采样
Visual Effect Graph 能够从网格中获取数据并在整个图形中使用结果。目前，它只能从网格中获取顶点，不能访问三角形拓扑。

Visual Effect Graph 提供了两种网格采样方法：
- [Position (Mesh) 代码块](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/MeshSampling.html#position-(mesh))。
- [Sample Mesh 运算符](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/MeshSampling.html#sample-mesh)。

### Position (Mesh)
此代码块设置位置读取顶点位置属性和方向读取法线属性。
![](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/PositionMesh.png)

#### Input Slot
- **Mesh**：要获取的网格。
    
- **Vertex**：要采样的顶点索引（如果 **Spawn Mode** 设置为 **Custom**）
    

#### 设置
- **Addressing Mode**：设置当顶点索引超出顶点范围时 Unity 使用的方法。
    - **Wrap**：将索引环绕到顶点列表的另一侧。
    - **Clamp**：将索引限制到第一个和最后一个顶点之间。
    - **Mirror**：镜像顶点列表，以使超出范围的索引在列表中来回移动。
- **Spawn Mode**
    - **Random**：获取每个实例的随机索引选择。
    - **Custom**：设置要获取的特定顶点索引。

### Sample Mesh
此运算符提供对任何顶点属性的自定义读取。在检查器中选择输出 [VertexAttribute](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.html)。
![image-20200320154843722](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/SampleMesh.png)

#### Input Slot
- **Mesh**：要获取的网格。
- **Vertex**：要采样的顶点索引（如果 **Spawn Mode** 设置为 **Custom**）

#### Output Slot
- **Position** ([Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html))：返回顶点属性 [Position](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.Position.html)
- **Normal** ([Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html))：返回顶点属性 [Normal](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.Normal.html)
- **Tangent** ([Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html))：返回顶点属性 [Tangent](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.Tangent.html)
- **Color** ([Vector4](https://docs.unity3d.com/ScriptReference/Vector4.html))：返回顶点属性 [Color](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.Color.html)
- **TexCoord0-7** ([Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html))：返回顶点属性 [TexCoord0 到 7](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.TexCoord0.html)
- **BlendWeight** ([Vector4](https://docs.unity3d.com/ScriptReference/Vector4.html))：返回顶点属性 [BlendWeight](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.BlendWeight.html)
- **BlendIndices** ([Vector4](https://docs.unity3d.com/ScriptReference/Vector4.html))：返回顶点属性 [BlendIndices](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.BlendIndices.html)

#### 设置
- **Addressing Mode**：设置当顶点索引超出顶点范围时 Unity 使用的方法。
    - **Wrap**：将索引环绕到顶点列表的另一侧。
    - **Clamp**：将索引限制到第一个和最后一个顶点之间。
    - **Mirror**：镜像顶点列表，以使超出范围的索引在列表中来回移动。
- **Output**：指定输出 VertexAttribute。此设置仅在检查器中可见。

## 限制
网格采样功能具有以下限制：
- 对于所有 [VertexAttribute](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.html) 仅支持 [VertexAttributeFormat.Float32](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttributeFormat.Float32.html)，但 [Color](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttribute.Color.html) 除外，因为它必须是使用 [VertexAttributeFormat.UInt8](https://docs.unity3d.com/ScriptReference/Rendering.VertexAttributeFormat.Float32.html) 格式的四分量属性 ([Color32](https://docs.unity3d.com/ScriptReference/Color32.html))。
- TexCoord 属性受限于二维属性。
- TexCoord 属性受限于二维属性。如果网格不是[可读的](https://docs.unity3d.com/ScriptReference/Mesh-isReadable.html)，**Position (Mesh)** 代码块和 **Sample Mesh** 运算符在尝试对其进行采样时返回零值。有关如何使网格可读的信息，请参阅 [模型导入设置](https://docs.unity3d.com/Manual/FBXImporter-Model.html)

![image-20200320154843722](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/ReadWrite.png)