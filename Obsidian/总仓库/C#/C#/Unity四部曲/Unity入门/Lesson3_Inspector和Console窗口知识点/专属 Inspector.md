# 专属 Inspector

专属 Inspector 是专门用于特定游戏对象、Unity 组件或资源的 Inspector 窗口。它始终显示为其打开的项目的属性，即使您在场景或项目中选择了其他内容。

专属 Inspector 的工作方式与常规 Inspector 一样，但有以下不同：

- 它显示的属性不会随当前选择而更新。
- 您无法锁定。每个专属 Inspector 显示特定项目的属性，因此没有必要进行锁定。
- 您无法从专属 Inspector 在调试和正常模式之间切换。

您可以根据需要打开任意数量的专属 Inspector。专属 Inspector 在一个浮动窗口中打开，您可以[重新定位、停靠和调整大小](https://docs.unity3d.com/cn/2023.2/Manual/CustomizingYourWorkspace.html)，和其他任何窗口的方式一样。

当您关闭项目时，Unity 会保存所有打开的专属 Inspector，并在您重新打开项目时恢复。

## Open focused Inspectors

有多种方法可以打开专属 Inspector，具体取决于您要检查的内容。

Unity 将专属 Inspector 添加到打开的窗口列表中（菜单：**Window > Panels > _[打开的窗口列表]_**）。

从列表中选择一个专属 Inspector 以将其置于最前面。

### 对于游戏对象和项目资源

要为单个游戏对象或资源打开一个专属 Inspector：

1. 右键单击 Hierarchy 视图中的一个游戏对象，或 Project 视图中的一个资源。
2. 从上下文菜单中选择 **Properties**。

或者，选择游戏对象或资源并执行以下操作之一：

- 从主菜单中选择 **Assets > Properties**。
- 使用 **Alt + P**/** Option + Shift + P** 快捷键。

Unity 在新窗口中打开专属 Inspector。

要打开多个游戏对象/或资源的专属 Inspector：

1. 选择 Hierarchy 视图中的游戏对象和 Project 视图中的资源的任意组合。
2. 执行以下操作之一： 右键单击选定的项之一，然后从上下文菜单中选择 **Properties**。
3. 从主菜单中选择 **Assets > Properties**。
4. 使用 **Alt + P**/** Option + Shift + P** 快捷键。

Unity 会打开一个新窗口，其中包含每个选定项目的专属 Inspector 选项卡。

下图显示了三个选定的项目（左）：两个游戏对象和一个资源，以及为它们打开专属 Inspector 时的窗口（右）。

![](https://docs.unity3d.com/cn/2023.2/uploads/Main/focused-inspector-multi.png)

### 对于组件

要为游戏对象的组件之一打开一个专属 Inspector：

1. 查看游戏对象，并确定要为其打开专属 Inspector 的组件。
2. 从组件的 **More items** (**⋮**) 菜单，选择 **Properties**。

这对于经常编辑的属性很有用。例如，您可能需要频繁移动游戏对象，但保持其余属性不变。在这种情况下，您可以打开其 Transform 组件。

下图显示了在常规 Inspector (1) 中打开的摄像机，以及在专属 Inspector (2) 中打开的变换组件。请注意，专属 Inspector 的选项卡标题显示了该组件所属的游戏对象的名称。

![](https://docs.unity3d.com/cn/2023.2/uploads/Main/focused-inspector-component.png)

### 用于引用属性

当游戏对象具有引用属性时，您可以为它们引用的游戏对象或资源打开专属 Inspector。

1. 查看游戏对象并确定引用属性，其引用的内容将在专属 Inspector 中打开。
2. 右键单击引用字段，然后从上下文菜单中选择 **Properties** 。

### 对于悬停项目

您可以设置打开专属 Inspector 的快捷方式，用于将指针悬停在 Hierarchy 视图或 Project 视图中的任何项目。

要将键盘快捷键分配给 **PropertyEditor > OpenMouseOver** 命令，请使用 [Shortcuts Manager](https://docs.unity3d.com/cn/2023.2/Manual/ShortcutsManager.html)。

当您想要打开一个项目的专属 Inspector 而不影响当前选择时，这很有用。

## Locate a focused Inspector’s source

要定位专属 Inspector 中显示的属性所属的项目，请执行以下操作之一：

- 从专属 Inspector 的 **More Items** (**⋮**) 菜单，选择 **Ping**。Unity 在 Hierarchy 视图或 Project 视图中突出显示该项目。

![](https://docs.unity3d.com/cn/2023.2/uploads/Main/focused-inspector-ping.png)

- 将指针悬停在专属 Inspector 的选项卡标题上将出现工具提示，显示项目在 Scene 层次结构或 Project 中的完整路径。

![](https://docs.unity3d.com/cn/2023.2/uploads/Main/focused-inspector-tooltip.png)