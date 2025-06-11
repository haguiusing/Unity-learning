## Properties|可编辑的字段|属性
属性是可编辑的字段，您可以使用[属性工作流](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html)将其连接到图形元素。它们可以在 [Contexts](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html)、[Blocks](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html) 和 [Operators](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html) 等图形元素上找到。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#using-properties)使用属性
属性显示在图形元素上，并根据它们在图形中的实际值更改其值。当您将另一个属性连接到属性端口时，图形元素将显示已连接属性的计算值。

断开已连接属性的连接后，该字段将恢复为之前设置的属性值。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#property-types)属性类型
![[Pasted image 20241023155710.png]]
Visual Effect Graph 中的属性可以是任何类型，包括：
- 布尔
- 整数
- 浮
- 向量
- 纹理
- AnimationCurve （动画曲线）
- 梯度

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#accessing-property-components)访问属性组件
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyComponents.png)

由多个组件组成的属性（例如 Vectors 或 Colors）可以单独显示每个组件，以便将这些组件连接到兼容类型的其他属性。使用属性旁边的箭头展开组件。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#casting-properties)强制转换属性
属性可以在基类型之间连接以执行强制转换。强制转换会更改您正在处理的数据类型，以便继承其属性。例如，如果将 float 强制转换为 integer，则 float 可以使用整数除法。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyCast.png)

从一种类型转换为另一种类型遵循以下规则：
- HLSL 中的所有 Casting 规则都适用：
    - 无法强制转换的 Boolean 类型除外。
    - 标量可通过设置所有分量转换为矢量
-  通过仅取用前 N 个分量，矢量可以转换为更小尺寸的矢量

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#compound-property-types)Compound Property Types|复合属性类型
复合属性类型由基本数据类型组成。这些类型描述更复杂的数据结构。例如，Sphere 由位置 （Vector3） 和半径 （float） 组成。

展开 Compound Property Types 以访问其组件。
[![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyCompound.png)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyCompound.png)

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#spaceable-properties)Spaceable Properties|空间属性属性
Spaceable Properties 是携带 **Space 信息** （Local/World） 及其值的属性类型。图形在需要时使用此信息执行自动空间转换。

单击 Property Field 左侧的 Space Modifier 以更改它。

例如，Position 类型带有 Vector3 值和 Spaceable 属性。如果将 Spaceable Property 设置为 Local [0,1,0]，则表示我们引用的是本地空间中的 0,1,0 值。

根据 [System Simulation Space](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Systems.html#system-spaces)，该值将在需要时自动转换为仿真空间。
##### 提示
您可以使用 Change Space 运算符手动更改 Property Space。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html#property-nodes)Property Nodes|属性节点
属性节点是允许访问 [Blackboard](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html) 中定义的图形范围属性的[运算符](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html)。这些属性允许您在整个图表的不同位置重复使用相同的值。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyNode.png)

- 如果属性已公开，则 Property Nodes 会在 Property name （属性名称） 后面显示一个绿点。
- 要创建 Property 节点：
    - 将 Node 从 Blackboard Panel 拖动到工作区中。
    - 打开 右键单击 上下文菜单，打开 **创建节点** 菜单，然后从 属性 类别中选择所需的属性。
- 要将属性节点转换为相同类型的内联节点，请右键单击属性节点，然后选择 **Convert to Inline**
- 从 Blackboard 中删除属性时，Unity 还会从图形中删除其属性 Node 实例。