# Inspector 检查窗口

使用 Inspector 窗口可对 Unity 编辑器中几乎所有内容（包括游戏对象、Unity 组件、资源、材质）[查看和编辑属性](https://docs.unity3d.com/cn/2023.2/Manual/EditingValueProperties.html)和设置，以及查看和编辑编辑器内的设置和首选项。

![Unity 编辑器中停靠的 Inspector 窗口](https://docs.unity3d.com/cn/2023.2/uploads/Main/InspectorWindowCallout.jpg)

Unity 编辑器中停靠的 Inspector 窗口

## Open an Inspector window

要打开 Inspector 窗口，请执行以下操作之一：

- 从菜单中选择 **Windows > General > Inspector** 以打开浮动的 Inspector 窗口。
- 从任何窗口的 More Items 菜单 (⋮) 中，选择 **Add Tab > Inspector** 以在新选项卡中打开 Inspector。

可以打开所需数量的 Inspector 窗口，并且可以对它们进行[重新定位、停靠和调整大小](https://docs.unity3d.com/cn/2023.2/Manual/CustomizingYourWorkspace.html)，和其他任何窗口的方式一样。

## Control Inspector window focus[[在 Inspector 中操作]]

默认情况下，Inspector 窗口显示当前选择的属性。每当选择更改时，Inspector 窗口的内容便会更改。要保持打开同一组属性而无论当前选择如何，请执行以下操作之一：

- [将 Inspector 窗口锁定](https://docs.unity3d.com/cn/2023.2/Manual/InspectorOptions.html#locking-the-inspector)到当前选择。锁定 Inspector 窗口时，如果更改选择，则它不再更新。
- 为游戏对象、资源或组件打开[专属 Inspector](https://docs.unity3d.com/cn/2023.2/Manual/InspectorFocused.html)[[专属 Inspector]]。专属 Inspector 只显示为其打开的项的属性。

## Inspect items

可以在 Inspector 窗口中查看和编辑的内容取决于所选择的内容。本部分介绍对于可以选择的不同类型的项，Inspector 窗口所显示的内容。

### 检查游戏对象

选择游戏对象时（例如在 [Hierarchy](https://docs.unity3d.com/cn/2023.2/Manual/Hierarchy.html) 或 [Scene 视图](https://docs.unity3d.com/cn/2023.2/Manual/UsingTheSceneView.html)中），Inspector 会显示其所有组件和材质的属性。可以在 Inspector 窗口中[编辑属性](https://docs.unity3d.com/cn/2023.2/Manual/EditingValueProperties.html)和[重新排列组件](https://docs.unity3d.com/cn/2023.2/Manual/InspectorOptions.html#reordering-components)。

### Inspect custom script components

当游戏对象附加了自定义脚本组件时，Inspector 会显示脚本的公共变量。可以采用与编辑任何其他属性相同的方式编辑脚本变量，这意味着可以在脚本中设置参数和默认值而无需修改代码。

有关更多信息，请参阅[脚本部分](https://docs.unity3d.com/cn/2023.2/Manual/ScriptingSection.html)中的[变量和 Inspector](https://docs.unity3d.com/cn/2023.2/Manual/VariablesAndTheInspector.html)。

### Inspect Assets

选择[资源](https://docs.unity3d.com/cn/2023.2/Manual/AssetWorkflow.html)时（例如通过 [Project 窗口](https://docs.unity3d.com/cn/2023.2/Manual/ProjectView.html)），Inspector 会显示控制 Unity 如何在运行时导入和使用资源的设置。

每种类型的资源都有自己的设置。在 Inspector 窗口中编辑的资源导入设置示例包括：

- [Model Import Settings](https://docs.unity3d.com/cn/2023.2/Manual/class-FBXImporter.html) 窗口。
- [Audio Clip Import Settings](https://docs.unity3d.com/cn/2023.2/Manual/class-AudioClip.html) 窗口。
- [Texture Import Settings](https://docs.unity3d.com/cn/2023.2/Manual/class-TextureImporter.html) 窗口。

### Inspect settings and preferences

When you open the [Project Settings](https://docs.unity3d.com/cn/2023.2/Manual/comp-ManagerGroup.html) (menu: **Edit** > **Project Settings**), Unity displays them in an Inspector window.

### Inspect Prefabs

处理预制件时，Inspector 窗口会显示一些附加信息并提供一些附加选项。例如：

- [编辑预制件实例](https://docs.unity3d.com/cn/2023.2/Manual/EditingPrefabViaInstance.html)时，Inspector 窗口会提供处理预制件资源和应用覆盖的选项。
- 应用[实例覆盖](https://docs.unity3d.com/cn/2023.2/Manual/PrefabInstanceOverrides.html)时，Inspector 窗口会以粗体显示覆盖的属性的名称。

有关在 Inspector 窗口中处理预制件的更多信息，请参阅[预制件](https://docs.unity3d.com/cn/2023.2/Manual/Prefabs.html)部分。

## Inspect multiple Items

选择了两个或更多项时，可以在 Inspector 窗口中编辑它们共有的所有属性。Unity 会将提供的值复制到所有选定项。Inspector 窗口会显示选定项的数量。

### 多个游戏对象

选择多个游戏对象时，Inspector 窗口会显示它们共有的所有组件。

- 对于在两个或更多选定游戏对象中不同的属性值，Inspector 会显示破折号 (**-**)（以下屏幕截图中的 1）。
- 对于在所有选定游戏对象中相同的属性值，Inspector 会显示实际值（以下屏幕截图中的 2）。
- 要将一个选定游戏对象中的属性值应用于所有选定游戏对象，请右键单击属性名称并从上下文菜单中选择 **Set to Value of _[游戏对象的名称]_**（以下屏幕截图中的 3）。
- 如果任何选定游戏对象具有其他选定对象上不存在的组件，则 Inspector 会显示一条消息，指出某些组件已隐藏。

![显示多个选定游戏对象的 Inspector](https://docs.unity3d.com/cn/2023.2/uploads/Main/MultiObjectEdit.png)

显示多个选定游戏对象的 Inspector

### 多个资源

选择相同类型的多个资源时，Inspector 窗口会显示它们共有的所有属性。

- 对于在所有选定资源中相同的属性值，Inspector 会显示实际值。
- 对于在两个或更多选定资源中不同的属性值，Inspector 会显示破折号 (**-**)（以下屏幕截图中的 1）。
- 对于无法同时为所有选定资源编辑的属性，Inspector 会将它们显示为灰色（以下屏幕截图中的 2）。

![显示相同类型的多个选定资源的 Inspector](https://docs.unity3d.com/cn/2023.2/uploads/Main/MultiAssetEdit-Same.png)

显示相同类型的多个选定资源的 Inspector

选择不同类型的多个资源时，Inspector 会显示一个列表，其中显示选择的每种类型资源的数量。单击该列表中的任何项可检查该类型的所有资源。

![显示不同类型的多个选定资源的 Inspector](https://docs.unity3d.com/cn/2023.2/uploads/Main/MultiAssetEdit-Diff.png)

显示不同类型的多个选定资源的 Inspector

### 多个预制件

可以采用与编辑多个游戏对象相同的方式检查预制件的多个选定实例，但 Inspector 会隐藏 **Select**、**Revert** 和 **Apply** 按钮（请参阅[通过预制件的实例编辑预制件](https://docs.unity3d.com/cn/2023.2/Manual/EditingPrefabViaInstance.html)）。

## Locate an Inspector window’s source

在 Inspector 窗口中打开游戏对象或资源时，可以使用 **Ping** 命令在 Scene 视图或 Project 视图中查找它。

从 Inspector 窗口的 **More Items** (**⋮**) 菜单，选择 **Ping**。Unity 在 Hierarchy 视图或 Project 视图中突出显示该项目。

![ping 命令会突出显示当前在 Inspector 中显示的项](https://docs.unity3d.com/cn/2023.2/uploads/Main/inspector-ping.png)

ping 命令会突出显示当前在 Inspector 中显示的项

---

- 在 Unity 5.6 中添加了组件拖放功能
- 在 Unity 2020.1 中重新组织了 Inspector 部分页面