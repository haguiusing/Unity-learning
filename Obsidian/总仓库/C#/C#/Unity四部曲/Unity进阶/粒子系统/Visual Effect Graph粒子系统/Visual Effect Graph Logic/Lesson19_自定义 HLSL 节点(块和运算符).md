## 自定义 HLSL 节点（块和运算符）
这些自定义 HLSL 节点允许您在粒 您可以将[运算符子模拟期间执行自定义 HLSL 代码。](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operator-CustomHLSL.html)用于水平流，也可以将[块](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Block-CustomHLSL.html)用于垂直流（在上下文中）。

![自定义 HLSL](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/custom-hlsl.png)

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#node-settings)节点设置

| **设置名称**               | 用户界面 | 位置            | 行动        |
| ---------------------- | ---- | ------------- | --------- |
| **Name**               | 文本字段 | 检查员           | 选择数据块的名称  |
| **HLSL Code**          | 按钮   | Graph （图形） 节点 | 打开代码编辑器窗口 |
| **Available Function** | 下拉   | Graph （图形） 节点 | 选择要执行的函数  |

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#hlsl-code)HLSL 代码

HLSL 代码可以**嵌入**到节点中，也可以使用 **HLSL 文件**。 您可以在同一个 HLSL 源（嵌入或文件）中提供多个函数，在这种情况下，您必须在节点的选择列表中选择所需的函数。  
要使 VFX Graph 有效并正确解释，必须采用一些约定。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#function-declaration)函数声明
要被 VFX Graph 正确识别，该函数必须满足以下要求：
- 返回支持的类型 [支持的类型](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#Supported-types)
- 每个函数参数都必须是 [Supported types](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#Supported-types)
- 如果声明多个函数，则它们必须具有唯一的名称。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#inline-documentation)内联文档
您可以使用三个斜杠注释表示法为每个函数参数指定工具提示，如下所示：
```csharp
/// <parameter-name>: the tooltip's text
```

这些注释必须位于函数声明的正上方。
```csharp
/// a: the tooltip for parameter a
/// b: the tooltip for parameter b
float Distance(in float3 a, in float3 b)
{
  return distance(a, b);
}
```

您可能希望编写一个不希望在节点的选择列表中公开的帮助程序函数。  
在这种情况下，只需将这个特殊注释放在函数声明的上方：
```csharp
/// Hidden
float SomeFunction(in float a)
{
  ...
}
```

##### 重要
当您需要实现帮助程序函数时，必须使用 HLSL 文件，而不是嵌入的 HLSL 代码。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#supported-types)支持的类型

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#basic-types)基本类型

| **HLSL 类型**     | **端口类型**              | **描述**            |
| --------------- | --------------------- | ----------------- |
| **bool**        | bool                  | 表示为布尔值的标量值。       |
| **uint**        | uint                  | 表示为无符号整数的标量值。     |
| **int**         | int                   | 以整数表示的标量值。        |
| **float**       | float                 | 表示为 float 的标量值。   |
| **float 2**     | float 2               | 包含两个 float 的结构。   |
| **float3**      | float 3               | 包含三个 float 的结构。   |
| **float 4**     | float 4               | 包含 4 个 float 的结构。 |
| **float4x4**    | float4x4              | 表示矩阵的结构。          |
| **VFXGradient** | Gradient              | 描述可采样的梯度的结构。      |
| **VFXCurve**    | AnimationCurve （动画曲线） | 描述可采样曲线的结构体。      |

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#texture-types)纹理类型

| **HLSL 类型**                    | **端口类型**                    | **描述**                |
| ------------------------------ | --------------------------- | --------------------- |
| **VFXSampler2D （视觉传感器 2D）**    | Texture2D                   | 包含采样器状态和二维纹理的结构。      |
| **VFXSampler3D （视觉特效采样器3D）**   | Texture3D                   | 包含采样器状态和三维纹理的结构。      |
| **VFXSampler2DArray**          | Texture2DArray （纹理 2DArray） | 一个包含采样器状态和二维纹理数组的结构。  |
| **VFXSamplerCube （视觉x采样器立方体）** | TextureCube （纹理立方体）         | 一个包含采样器状态和多维数据集纹理的结构。 |

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#buffers)缓冲区

| **HLSL 类型**                          | **端口类型**              | **描述**                       |
| ------------------------------------ | --------------------- | ---------------------------- |
| **StructuredBuffer （结构化缓冲区）**        | GraphicsBuffer(图形缓冲区) | 用于存储结构数组或基本 HLSL 数据类型的只读缓冲区。 |
| **ByteAddressBuffer(字节地址缓冲区)**       | GraphicsBuffer(图形缓冲区) | 只读原始缓冲区。                     |
| **Buffer(缓冲区)**                      | GraphicsBuffer(图形缓冲区) | 用于基本 HLSL 类型的只读原始缓冲区。        |
| **AppendStructuredBuffer(附加结构化缓冲区)** | GraphicsBuffer(图形缓冲区) | 一个只读缓冲区，您可以在其中添加新条目。         |
| **ConsumeStructuredBuffer**          | GraphicsBuffer(图形缓冲区) | 一个只读缓冲区，您可以在其中删除条目。          |
| **RWBuffer**                         | GraphicsBuffer(图形缓冲区) | 用于基本 HLSL 类型的读写原始缓冲区。        |
| **RWStructuredBuffer 缓冲区**           | GraphicsBuffer(图形缓冲区) | 用于存储结构数组或基本 HLSL 数据类型的读写缓冲区。 |
| **RWByteAddressBuffer**              | GraphicsBuffer(图形缓冲区) | 读写原始缓冲区。                     |

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#sampling)采样

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#textures)纹理
对纹理进行采样的最简单方法是使用称为 VFXSampler2D（或 VFXSample3D）的 VFX 图形结构，其定义如下所示：
```csharp
struct VFXSampler2D
{
    Texture2D t;
    SamplerState s;
};
```

VFX Graph 提供此功能：。  
但您也可以使用 HLSL 内置函数通过 VFXSampler2D 字段对纹理进行采样。  
在这种情况下，由于这在计算着色器中使用，因此您必须指定要采样的 mipmap 级别（例如使用）。`float4 SampleTexture(VFXSampler2D texure, float2 coordinates)``SampleLevel`

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#buffers-1)缓冲区

您可以使用两种类型的缓冲区：和 . 在这两种情况下，用法与任何 HLSL 代码中的用法相同：`ByteAddressBuffer``StructuredBuffer<>`

- `ByteAddressBuffer`：使用函数`Load`
```csharp
uint char = buffer.Load(attributes.particleId % count);
```

- `StructuredBuffer<>`：使用经典索引访问器
```csharp
float angle = phase + freq * buffer[attributes.particleId % bufferSize];
```

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#gradient)梯度
渐变在 VFX Graph 中专门处理（它们打包在单个纹理中），因此您必须使用专用函数对它们进行采样。  
以下是函数定义：`SampleGradient(VFXGradient gradient, float t)`
```csharp
float3 color = SampleGradient(grad, t);
```

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#curve)曲线
对曲线进行采样与对渐变进行采样非常相似。  
以下是函数定义：`SampleCurve(VFXCurve curve, float t)`
```csharp
float r = SampleCurve(curve, t);
```

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#hlsl-code-editor)HLSL 代码编辑器
您可以通过单击图形中节点上的按钮，直接在 Unity 编辑器中编辑 HLSL 代码（请参阅[上面的](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/CustomHLSL-Common.html#custom-hlsl-nodes-block-and-operator)屏幕截图）。  
HLSL 代码编辑器支持以下快捷方式：`Edit`
- `Ctrl + Z`以及撤消/重做（独立于 Unity Editor 撤消堆栈）`Ctrl + Y`
- `Ctrl + S`保存当前 HLSL 代码
- `Ctrl + Mouse Wheel`更改字体大小

> 如果需要记下粒子属性的名称，可以将属性从黑板拖放到代码编辑器中。这样您就可以避免任何拼写错误的风险。
![自定义 HLSL 编辑器](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/custom-hlsl-editor.png)