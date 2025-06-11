# Operators|运算符
运算符是 [Property Workflow](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#property-workflow-horizontal-logic) 的原子元素。这些节点允许您在 Visual Effect Graph 中定义自定义表达式，以用于创建自定义行为。例如，通过数学运算计算值，并使用这些运算的结果对曲线、梯度进行采样，以将结果值用于 [Block](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html) 或 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 输入 [Properties](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html)。

[![运营商](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Operators.png)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Operators.png)
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#adding-operator-nodes)添加 Operator 节点
您可以通过以下方式添加 Operator 节点：
- 在 Create Node 菜单中：
    - 右键单击空白区域，然后从菜单中选择 **Create Node**。
    - 右键单击边，然后从菜单中选择 **Create Node （创建节点**）。
    - 当光标位于空白区域时，按空格键。
    - 从 Property 中拖动 Edge Connection，然后在空白处释放。
- 重复节点：
    - 在 Context menu（上下文菜单）中选择 **Duplicate**（复制）（或 Ctrl+D）。
    - **从**上下文菜单复制、**剪切**和**粘贴**操作符（或 Ctrl+C/Ctrl+X，然后按 Ctrl+V）。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#configuring-operators)配置 Operator
当您在 Node UI 或 Inspector 中更改 Operator [Settings](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#settings) 时，Operator 会更改其外观和行为方式。

例如，当您将 Operator 的 Cull Mode 从 **None** 更改为 **Range** 时，Unity 会向 Operator 添加额外的 **Depth Range** 属性。`Position (Depth)`

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#uniform-operators)Uniform Operators|单目运算符
Uniform Operators 是可与 Variable Type 的<font color="#ffc000">单个输入</font>一起使用的节点。例如，您可以对 float、Vector3 或 Integer 使用绝对值。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsUniform.png)

任何 Uniform 运算符的输出类型始终与其输入 Type 相同。连接具有不同类型的新输入将自动更改运算符的输出类型。如果要手动将 Node 设置为特定类型，请参阅**配置 Uniform 运算符**。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#configuring-uniform-operators)配置 uniform 运算符
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsUniformOptions.png)

按右上角的 Options 图标，将 Node （节点） 视图切换到 Configuration （配置） 模式。在此模式下，您可以手动更改运算符 Type。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#unified-operators)Unified Operators|统一运算符
除了 Uniform Operators 之外，一些具有许多输入的运算符还可以处理 **Variable Types 的<font color="#ffc000">多个输入**</font>。这些节点称为 **Unified Operator**。

例如，**Lerp** 运算符可以基于浮点数在两个 Vector 之间均匀插值，或者使用相同长度的 Vector 在每个组件之间进行插值。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsUnified.png)
Unified Operators 具有类型约束，但允许一些灵活性，以适应某些类型的类型。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#configuring-unified-operators)配置统一操作员
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsUnifiedOptions.png)
按右上角的 Options 图标，将 Node （节点） 视图切换到 Configuration （配置） 模式。在此模式下，您可以手动更改每个输入的运算符 Types。在某些情况下，更改一种输入类型将更改另一种输入类型，以保持兼容性。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#cascaded-operators)Cascaded Operators|级联运算符
**级联运算符**处理可变输入计数。这些 Operator 可以处理许多 output 并处理不同的 input Type，例如 **Unified Operators**

例如，Add Node 允许您使用单个 Node 添加许多不同类型的输入。
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsCascaded.png)
您可以将许多输入连接到 Cascaded Operator。要向列表中添加新项目，请将一条边连接到 Node 底部的最后一个灰色输入。这将创建一个使用您连接的属性类型的新输入。

删除连接时，Unity 还会从列表中删除 input 属性。但是，您也可以使用 Configuration Mode 手动删除 input 属性。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html#configuring-cascaded-operators)配置 Cascaded Operator
![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/OperatorsCascadedOptions.png)
按右上角的 Options 图标，将 Node （节点） 视图切换到 Configuration （配置） 模式。在此模式下，您可以：
- 使用其文本字段重命名输入。
- 使用类型 Drop 更改 Input Types。
- 通过拖动每个输入行左侧的 Handle 对 Inputs 重新排序。
- 使用 “+” 按钮手动添加输入。
- 使用 “-” 按钮删除选定的输入。