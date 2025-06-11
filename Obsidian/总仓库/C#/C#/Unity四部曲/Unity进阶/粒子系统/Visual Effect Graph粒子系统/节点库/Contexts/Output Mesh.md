# Output Mesh
菜单路径：**Context > Output Mesh**

**Output Mesh** 上下文渲染一个常规的静态网格，并完全独立于粒子系统发挥作用。效果通常由不同的元素组成，例如粒子系统和网格。此输出允许您直接在视觉效果资源中渲染网格，并使用节点控制它们的着色器和变换属性。

要为此网格指定着色器，请将一个 [Shader Graph](https://docs.unity3d.com/Packages/com.unity.shadergraph@latest) 分配给上下文的 **Shader** 设置。然后，Visual Effect Graph 将所有公开的着色器属性转换为输入端口，并将它们显示在标准属性下方。请注意，需要 GPU 评估的运算符如[示例 Texture2D](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Operator-SampleTexture2D.html) 和其他示例纹理运算符，与此输出上下文上的端口不兼容。

## 上下文设置

| **设置**           | **类型**          | **描述**                                                                                                                                                          |
| ---------------- | --------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Shader**       | Shader Graph 资源 | 用于渲染网格的 Shader Graph。当您将 Shader Graph 资源分配给此属性时，Visual Effect Graph 会将所有公开的属性转换为输入端口并在此上下文中显示它们。请注意，需要 GPU 评估的操作符（例如 Sample Texture2D 和其他采样纹理操作符）与此输出上下文的端口不兼容。 |
| **Cast Shadows** | bool            | **（Inspector**）指示网格是否投射阴影。                                                                                                                                      |

## 上下文属性

| **Input**         | **类型**                                                                                                        | **描述**                        |
| ----------------- | ------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| **Mesh**          | Mesh                                                                                                          | 此输出渲染的网格。                     |
| **Transform**     | [Transform](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Type-Transform.html) | 要应用于网格的变换。变换可以在世界空间或局部空间中。    |
| **Sub Mesh Mash** | uint                                                                                                          | 输出用于渲染网格的子网格遮罩。输出仅渲染设置了位的子网格。 |
| **Sub Mesh Mask** | uint                                                                                                          | 输出用于渲染网格的子网格掩码。输出仅渲染设置了位的子网格。 |
