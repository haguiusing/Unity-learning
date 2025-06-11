# 在 Inspector 中操作

本页面描述了一些用于控制 Inspector 窗口本身的选项。有关设置游戏对象、脚本和资源的属性的信息，请参阅[编辑属性](https://docs.unity3d.com/cn/2023.2/Manual/EditingValueProperties.html)。

## Lock the Inspector

通常，Inspector 会显示当前选定的游戏对象、脚本或资源的属性。但有时，在处理其他项目时将一项保留在 Inspector 中很有用。在这种情况下，您可以将 Inspector 窗口锁定到特定项目。

要将 Inspector 窗口锁定到某个项目，请单击 Inspector 窗口中的锁定图标。锁定图标会发生变化，显示 Inspector 现已锁定到所选项目。

![Inspector 锁定按钮处于解锁（左）和锁定（右）状态](https://docs.unity3d.com/cn/2023.2/uploads/Main/inspector-lock-button.png)

Inspector 锁定按钮处于解锁（左）和锁定（右）状态

当您经常编辑一个项目的属性时，这很有用。例如，如果您要微调一台摄像机的位置，您可以将一个 Inspector 窗口锁定到该摄像机，然后打开第二个 Inspector 窗口 (**More Items** (**⋮**) 菜单：**Add Tab > Inspector**) 继续显示当前选择的属性。

|**注意：**|
|---|
|[专属 Inspector](https://docs.unity3d.com/cn/2023.2/Manual/InspectorFocused.html)是锁定 Inspector 窗口的替代方法。专属 Inspector 只显示为其打开的项目的属性。|

## Reorder GameObject components

您可以在 Inspector 窗口中重新排序游戏对象的组件。在 Inspector 窗口中应用的组件顺序也是在您的脚本中查询组件时需使用的顺序。

游戏对象的 Transform 组件始终是最顶层的组件。您不能移动它，也不能在它上面放置其他组件。

要在 Inspector 窗口中重新排序游戏对象的组件，请执行以下操作之一：

- 将组件标题从一个位置拖放到另一个位置。当您拖动组件标题时，Unity 将放置组件的位置会出现一个蓝色插入标记。

![通过在 Inspector 中拖放操作重新排序游戏对象的组件](https://docs.unity3d.com/cn/2023.2/uploads/Main/inspector-component-reorder-drag.png)

通过在 Inspector 中拖放操作重新排序游戏对象的组件

- 右键单击一个组件以打开上下文菜单，然后选择 **Move Up** 或 **Move Down**。

![通过在 Inspector 中使用上下文菜单重新排序游戏对象的组件](https://docs.unity3d.com/cn/2023.2/uploads/Main/inspector-component-reorder-menu.png)

通过在 Inspector 中使用上下文菜单重新排序游戏对象的组件

### 为多个游戏对象重新排序组件

选择[多个游戏对象](https://docs.unity3d.com/cn/2023.2/Manual/UsingTheInspector.html#inspecting-multiple-items)时，Inspector 会显示选定游戏对象的所有共有的组件。如果您对这些公共组件重新排序，该更改将应用于所有选定的游戏对象。

## Assign icons

您可以从 Inspector 窗口将自定义图标分配给游戏对象、预制件和脚本。自定义图标出现在 [Scene 视图](https://docs.unity3d.com/cn/2023.2/Manual/UsingTheSceneView.html)的方式与光照和摄像机等项目的默认图标相同。

- 为游戏对象分配一个图标后，Scene 视图中该游戏对象（以及之后的任何重复项）的上方都会显示此图标。
- 为预制件分配一个图标后，Scene 视图中该预制件所有实例的上方都会显示此图标。
- 为脚本分配一个图标后，Scene 视图中任何附加了此脚本的游戏对象上方都会显示此图标。

要控制 Unity 在 Scene 视图中绘制自定义图标的方式，请使用 [Gizmos 菜单](https://docs.unity3d.com/cn/2023.2/Manual/GizmosMenu.html)。

|注意|
|---|
|当您更改资源的图标时，Unity 会将该资源标记为已修改，并且版本控制系统会注册此更改。|

### Assign custom icons to GameObjects, scripts, and Prefabs

要将自定义图标分配给游戏对象或脚本：

1. 在 Inspector 窗口中打开该项目。
2. 单击 **Select icon** 按钮。
3. 从 **Select icon** 菜单选择一个图标（如下）。

![Select Icon 按钮：游戏对象/预制件（左）和脚本（右）](https://docs.unity3d.com/cn/2023.2/uploads/Main/inspector-select-icon-button.png)

Select Icon 按钮：游戏对象/预制件（左）和脚本（右）

要将自定义图标分配给某个预制件，您必须在[预制件模式](https://docs.unity3d.com/cn/2023.2/Manual/EditingInPrefabMode.html)打开该预制件。

### Choose icons from the Select icon menu

从 **Select Icon** 菜单分配自定义图标。

![](https://docs.unity3d.com/cn/2023.2/uploads/Main/IconSelectorPopup.png)

|图标类型：|描述：|
|---|---|
|1|标签图标是彩色胶囊。在 Scene 视图中，它们显示所分配的项目的名称。  <br>  <br>单击标签图标进行分配。|
|2|仅图像图标是彩色的色块。当您处理可能没有直观表示的对象时，它们很有用。例如，您可以为导航路径点分配仅图像图标，以便在 Scene 视图中查看和选择它们。  <br>  <br>单击一个仅图像图标进行分配。|
|3|资源图标是场景中用作自定义图标的图像资源。例如，您可以使用骷髅头图标来指示游戏关卡中的危险区域。  <br>  <br>单击 **Other** 按钮打开 Object Picker 窗口，然后选择要指定为图标的图像资源。|

## Toggle Debug Mode

通常，Inspector 窗口被配置为选择内容的属性的编辑器。但有时仅查看属性及其值即可。当您激活调试模式时，Inspector 仅显示属性及其值。如果选择内容具有脚本组件，调试模式也会显示私有变量，但您无法编辑它们的值。

您可以单独为每个 Inspector 窗口切换调试模式。

- 要打开调试模式，请单击 **More Items** (**⋮**) 按钮打开上下文菜单，然后选择 **Debug**。
- 要返回到正常模式，请单击 **More Items** (**⋮**) 按钮打开上下文菜单，然后选择 **Normal**。

![处于正常模式（左）和调试模式（右）的 Mesh Renderer 组件](https://docs.unity3d.com/cn/2023.2/uploads/Main/DebugModeInspector.png)

处于正常模式（左）和调试模式（右）的 Mesh Renderer 组件