[[Lesson5_System]]
[[Lesson6_Contexts]]
[[Lesson7_Blocks]]
[[Lesson8_Operators]]
[[Lesson9_Properties]]
[[Lesson10_Events]]
[[Lesson11_Attributes]]
[[Lesson12_Subgraph]]
[[Lesson13_Blackboard]]
[[Lesson14_Sticky Notes]]
[[Lesson15_Default VFX Graph Templates 窗口]]
[[Lesson16_Visual Effect 项目设置]]
[[Lesson17_Visual Effect Graph 首选项]]
[[Lesson18_Visual Effect Bounds(视觉效果边界)]]
[[Lesson19_自定义 HLSL 节点(块和运算符)]]
[[Lesson20_Instancing]]
# Visual Effect Graph 逻辑
Visual Effect Graph 使用两种不同的工作流程：

- 一种**处理** （垂直） 逻辑，它将可自定义的阶段链接在一起以定义系统的生命周期。
    
- 一个**属性** （水平） 逻辑，它连接不同的 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 来定义粒子的外观和行为。
    

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#processing-workflow-vertical-logic)Processing workflow (vertical logic)|处理工作流 （垂直逻辑）
处理工作流将一系列可自定义的阶段链接在一起，以定义完整的系统逻辑。您可以在此处确定在效果期间何时生成、初始化、更新和渲染粒子。

处理工作流使用位于上下文节点顶部和底部的**流端口**连接上下文。

处理逻辑定义视觉效果处理的不同阶段。每个阶段都由一个称为 [Contexts](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 的大型彩色容器组成。每个 Context 都连接到另一个兼容的 Context，该 Context 定义了下一阶段的处理如何使用当前 Context。

上下文可以包含称为 [Block](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html) 的元素。每个 Block 都是一个可堆叠的 Node，负责一个操作。您可以对 Blocks 重新排序以更改 Unity 处理视觉效果的顺序。Unity 从上到下执行 Context 中的 Block。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#property-workflow-horizontal-logic)Property workflow (horizontal logic)|属性工作流 （水平逻辑）
在水平属性工作流中，您可以定义数学运算以增强视觉效果。这会影响粒子的外观和行为。

属性工作流使用其 Block 的属性**端口**连接上下文。左侧是输入，右侧是输出。

Visual Effect Graph 附带一个大型 Block 和 Node 库，可用于定义视觉效果的行为。您创建的节点网络控制渲染管道传递到图形上下文中的块的水平数据流。

要自定义粒子的行为方式，您可以将 horizontal Nodes 连接到 Block 以创建自定义数学表达式。为此，请使用 **Create Node** 上下文菜单添加 Nodes，更改其值，然后将 Nodes to Block 属性连接起来。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#graph-elements)Graph elements|图形元素
Visual Effect Graph 提供了一个工作区，您可以在其中创建图形元素并将它们连接在一起以定义效果行为。Visual Effect Graph 附带许多不同类型的图形元素，这些元素适合工作区。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#workspace)Workspace|工作
Visual Effect Graph 提供了一个**工作区**，您可以在其中创建图形元素并将它们连接在一起以定义效果行为。

![[Pasted image 20241022210909.png]]

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#systems)Systems|系统
[系统](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Systems.html)是 Visual Effect 的主要组件。每个系统都定义了一个不同的部分，渲染管道将其与其他系统一起模拟和渲染。在图中，由一系列 Context 定义的系统显示为虚线轮廓（见上图）。

- **Spawn System** 由单个 Spawn Context 组成。
- **粒子系统**由 Initialize （初始化）、Update （更新） 和 Output 上下文 （输出） 上下文的一系列序列组成。
- **网格输出系统**由单个网格输出上下文组成。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#contexts)Contexts|上下文
[上下文](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html)是定义处理阶段的 System 部分。上下文连接在一起以定义一个系统。

Visual Effect Graph 中最常见的四种上下文是：

- **生成**。如果处于活动状态，Unity 将每帧调用一次，并计算要生成的粒子数量。
- **初始化**。Unity 在每个粒子的 “出生” 时调用 This，这定义了粒子的初始状态。
- **更新**。Unity 为所有粒子的每一帧调用此函数，并使用它来执行模拟，例如 Forces 和 Collisions。
- **输出**。Unity 为每个粒子的每个帧调用此函数。这将确定粒子的形状，并执行预渲染变换。

**注意：**某些上下文（例如 Output Mesh）不连接到任何其他上下文，因为它们与其他系统无关。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#blocks)Blocks|块
[块](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html)是可以堆叠到 Context 中的节点。每个 Block 负责一个操作。例如，它可以对速度施加力、与球体碰撞或设置随机颜色。

创建 Block 时，您可以在其当前 Context 中对其进行重新排序，或将其移动到另一个兼容的 Context。

要自定义块，您可以：

- 调整属性。为此，请将属性 Port 连接到另一个具有 Edge 的 Node。
    
- 调整属性的设置。Settings 是可编辑的值，没有端口，您无法将其连接到其他节点。
    

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#operators)Operators|运营商
[运算符](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Operators.html)是组成**属性工作流**的低级操作的节点。您可以将节点连接在一起以生成自定义行为。节点网络连接到属于 Block 或 Context 的 Port。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#graph-common-elements)Graph Common Elements|图形公共元素
虽然图形元素不同，但它们的内容和行为往往相同。图形元素共享以下功能和布局项：

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#settings)Settings|设置
Settings 是无法使用属性工作流连接到的 Fields。每个图形元素都显示设置：
- 在**图表**中：在 Title 和 Graph 中的属性容器之间。
- 在 **Inspector** 中：当您选择节点时，Inspector 会显示其他高级设置。

如果更改设置的值，则需要重新编译 Graph 才能看到效果。

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#properties)Properties|性能
[属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html)是您可以使用属性工作流编辑和连接到的字段。您可以将它们连接到其他图形元素中包含的其他属性。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#other-graph-elements)其他图形元素

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#groups)Groups|组
您可以将 Node 分组在一起以组织您的图表。您可以将分组的节点一起拖动，甚至可以为它们指定一个标题来描述该组的作用。要添加组，请选择多个节点，右键单击，然后选择 **Group Selection**。

### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#sticky-notes)Sticky Notes|便笺
便笺是可拖动的评论元素，您可以添加这些元素来为同事或您自己留下解释或提醒。