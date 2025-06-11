**草稿：此页面上的内容已完成，但尚未经过审核。

**实验：此功能目前处于实验阶段，在以后的主要版本中可能会发生更改。要使用此功能，请启用项目首选项 Visual Effects** 选项卡中的 **Experimental Operators/Blocks**。

# 矢量场/有向距离场
矢量场和有向距离场是包含存储在体素中的值的 3D 场。它们可作为 Visual Effect Graph 中的 3D 纹理使用，并且可以使用卷文件 (`.vf`) 文件格式导入。

卷文件是一个包含存储浮点数据所用基本结构的[开源规范](https://github.com/peeweek/VectorFieldFile/blob/master/README.md)。VF 文件作为 3D 纹理在 Unity 中自动导入，可用于 Visual Effect Graph 代码块和输入 3D 纹理的运算符（例如矢量场或有向距离场代码块）。

## 矢量场导入器
![](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/images/VectorFieldInspector.png)

导入 VF 文件时，Unity 在检查器中提供以下设置：
- **Output Format**：输出 3D 纹理的精度
    - Half：使用 16 位半精度的浮点。
    - Float：使用 32 位单精度浮点。
    - Byte：8 位精度的无符号定点值
- **Wrap Mode**：输出纹理的环绕模式
- **Filter Mode**：输出纹理的过滤模式
- **Generate Mip Maps**：是否为纹理生成 mip-map
- **Aniso Level**：各向异性水平

## 生成矢量场文件
您可以使用各种方法生成矢量场：
- 使用与 [VFXToolbox](https://github.com/Unity-Technologies/VFXToolbox) 捆绑提供的 Houdini VF 导出器（位于 /DCC~ 文件夹）
- 通过编写自己的导出器来编写符合规范的 [VF 文件](https://github.com/peeweek/VectorFieldFile/blob/master/README.md)。