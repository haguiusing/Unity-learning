# Blocks|块
块是定义 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 行为的节点。您可以在上下文中创建和重新排序块，当 Unity 播放视觉效果时，块会从上到下执行。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/Block-Anatomy.png)

您可以将块用于多种用途，从简单的值存储（例如，随机颜色）到高级复杂操作，例如 Noise Turbulence、Forces 或 Collisions。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html#adding-blocks)添加块
要将 Block 添加到 Context 中，请执行以下任一操作：
- 右键单击 Context 并从上下文菜单中选择 **Create Block**。
- 将光标置于 Context 上方，按空格键。

**注意**：Unity 会将您创建的 Block 放置在离光标最近的位置。使用此行为可将 Blocks 放置在正确的位置。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html#manipulating-blocks)操纵块
数据块本质上是具有不同工作流逻辑的节点。数据块始终堆叠在一个称为 [Context](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html) 的容器中，它们的工作流逻辑垂直连接，没有可见的链接。
- 要移动 Block，请点击 Block 的标题并将其拖动到另一个兼容的 Context。
    
- 要对 Block 重新排序，请点击 Block 的标题并将其拖动到同一 Context 中的不同位置。
    

- 您可以对 Block 执行各种操作，例如剪切、复制、粘贴和复制。操作步骤：
    
    - 右键单击 Block 并从上下文菜单中选择命令。
        
    - 选择 Block 并使用以下键盘快捷键：
        
        - **在 Windows 上：**
            
            - **复制：**Ctrl+C 组合键。
            - **切：**Ctrl+X 组合键。
            - **糊：**Ctrl+V 组合键。
            - **重复：**Ctrl + D 组合键。
        - **在 macOS 上：**
            
            - **复制：**Cmd + C 的 Cmd 键。
            - **切：**Cmd+X 的 Cmd 键。
            - **糊：**Cmd+V 命令。
            - **重复：**Cmd+D 命令。

- 要禁用 Block，请禁用 Block 标题左侧的复选框。这需要您重新编译图形。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html#configuring-blocks)配置块
要更改 Block 的外观和行为方式，请在 Node UI 或 Inspector 中调整 Block 的 [Settings](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/GraphLogicAndPhilosophy.html#settings)。

例如，如果在 Inspector 中，将 **Set Velocity** 块的 Composition Settings 从 **Overwrite** 更改为 **Blend**，则会将 Node 的标题更改为 **Blend Velocity**，并将 **Blend** 属性添加到节点 UI。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blocks.html#activation-port)激活端口
除了其[属性](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Properties.html)端口外，Block 还有一个称为 activation 端口的特殊端口。它位于 Block 的左上角，在其名称旁边。

激活端口链接到布尔属性，并允许用户控制 Block 是否处于活动状态。

您可以使用端口旁边的切换开关手动激活或停用 Block。

您可以将图形逻辑连接到激活端口，以准确控制每次调用时 Block 处于活动状态的条件。这允许您在同一系统中为每个粒子实现不同的行为或状态。

Unity 能够确定 Block 是否处于静态非活动状态。非活动块显示为灰色，Unity 会在编译期间将其删除，因此运行时成本为零。

**注意**：子图块没有激活端口。要模拟激活端口，您可以从子图中公开一个布尔公开的属性，并将该属性连接到子图内部 Block 的激活端口。