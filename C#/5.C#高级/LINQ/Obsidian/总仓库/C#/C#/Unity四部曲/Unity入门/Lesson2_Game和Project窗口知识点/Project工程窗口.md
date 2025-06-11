# Project 窗口

The Project window displays all of the files related to your Project and is the main way you can navigate and find Assets and other Project files in your application. When you start a new Project by default this window is open. However, if you cannot find it, or it is closed, you can open it via **Window > General > Project** or press Ctrl+5 (macOS: Cmd+5).
Project （项目） 窗口显示与项目相关的所有文件，这是在应用程序中导航和查找 Assets 和其他项目文件的主要方式。默认情况下，当您启动新项目时，此窗口处于打开状态。但是，如果找不到它，或者它已关闭，您可以通过**窗口>常规>项目**或按 Ctrl+5（macOS：Cmd+5）打开它。

![处于 Tall 布局中的 Project 窗口](https://docs.unity.cn/cn/2020.3/uploads/Main/project-window-context.png)

处于 Tall 布局中的 Project 窗口

可以通过单击和拖动 Project 窗口的顶部来移动该窗口。可以将该窗口停靠在 Editor 中，或者将其拖出 Editor 窗口，从而用作自由浮动窗口。还可更改窗口本身的布局。为此，请选择窗口右上方的上下文按钮，然后选择 **One Column Layout** 或 **Two Column Layout**。**Two Column Layout** 有一个额外面板，其中显示每个文件的可视化预览。

![设置为 Two Column Layout 的 Project 窗口](https://docs.unity.cn/cn/2020.3/uploads/Main/project-window-wide-layout.png)

设置为 Two Column Layout 的 Project 窗口

浏览器的左侧面板将项目的文件夹结构显示为层级列表。从列表中选择文件夹时，Unity 将在右侧面板中显示其内容。可单击小三角形来展开或折叠文件夹，显示文件夹包含的任何嵌套文件夹。单击时按住 **Alt** 键将以递归方式展开或折叠所有嵌套文件夹。

各个资源在右侧面板中显示为图标，这些图标指示了资源的类型（例如，脚本、材质、子文件夹）。要调整图标的大小，可使用面板底部的滑动条；如果滑动条移动到最左侧，这些图标将替换为层级列表视图。滑动条左侧的空白位置显示当前选定项，包括该项的完整路径（如果正在执行搜索）。

项目结构列表上方是 **Favorites** 部分，可在其中保存常用项以方便访问。可将所需项从项目结构列表拖动到 Favorites 部分，也可在此处保存搜索查询结果。

## Project 窗口工具栏

沿窗口顶部边缘的是浏览器的工具栏。

![](https://docs.unity.cn/cn/2020.3/uploads/Main/project-window-toolbar.png)
![[Pasted image 20240831170216.png]]
窗口布局设置
创建相关资源文件
查找
1. 按资源类型查找
2. 按名字查找

| **属性**                    | **描述**                                                                          |
| ------------------------- | ------------------------------------------------------------------------------- |
| **Create menu**           | 显示可以添加到当前选定文件夹的资源和其他子文件夹的列表。                                                    |
| **Search bar**            | 使用搜索栏来搜索项目中的文件。可以选择在整个项目 (**A ll**)、项目的顶级文件夹（单独列出）、当前选择的文件夹或 Asset Store 中进行搜索。 |
| **Search by Type**        | 选择此属性可将搜索限制为特定类型，例如“网格”、“预制件”、“场景”。                                             |
| **Search by Label**       | 选择此属性可选择要在其中搜索的标签。                                                              |
| **Hidden packages count** | 选择此属性可在 Project 窗口中切换包的可见性。                                                     |

## 搜索筛选条件

搜索筛选条件的工作原理是在搜索文本中添加额外的搜索词。
以“t:”开头的搜索词按指定的资源类型进行筛选，而“l:”按标签筛选。
如果知道要查找的具体内容，可直接在搜索框中输入这些搜索词，无需使用菜单。一次可搜索多个类型或标签。添加几个类型将使搜索扩展以便包括所有指定的类型（即，多个类型通过 OR 逻辑结合）。添加多个标签会将搜索范围缩小到具有任意指定标签的项（即，多个标签将通过 OR 逻辑组合在一起）。

## 搜索 Asset Store

Project Browser 的搜索也可应用于 Unity **Asset Store** 中可用的资源。如果从示踪导航栏的菜单中选择 __Asset Store__，则会显示 Asset Store 中与查询匹配的所有免费和付费资源。按类型和标签搜索的工作方式与 Unity 项目相同。首先根据资源名称检查搜索查询词，然后按顺序检查资源包名称、资源包标签和资源包描述（因此，名称中包含搜索词的项的排名将高于资源包描述中包含该搜索词的项）。

如果从列表中选择一项，该项的详细信息将显示在 Inspector 中，同时还提供购买和/或下载选项。有些资源类型在此部分中提供了预览，因此可以在购买前旋转 3D 模型。Inspector 还提供了一个选项允许在常规 Asset Store 窗口中查看资源以了解更多详细信息。

## 快捷键

当浏览器视图获得焦点时，可使用以下键盘快捷键。请注意，其中一些快捷键仅在视图使用双列布局时才起作用（可使用右上角的面板菜单在单列和双列布局之间切换）。

|**快捷键**|**功能**|
|---|---|
|**F**|定格所选项（即，在包含文件夹中显示所选资源）|
|**Tab**|在第一列和第二列之间移动焦点（两列）|
|**Ctrl/Cmd + F**|聚焦搜索字段|
|**Ctrl/Cmd + A**|选择列表中的所有可见项|
|**Ctrl/Cmd + D**|复制所选资源|
|**Delete**|删除并显示对话框 (Win)|
|**Delete + Shift**|删除而不显示对话框 (Win)|
|**Delete + Cmd**|删除而不显示对话框 (OSX)|
|**Enter**|开始重命名所选项 (OSX)|
|**Cmd + 向下箭头**|打开所选资源 (OSX)|
|**Cmd + 向上箭头**|跳转到父文件夹（OSX，两列）|
|**F2**|开始重命名所选项 (Win)|
|**Enter**|打开所选资源 (Win)|
|**Backspace**|跳转到父文件夹（Win，两列）|
|**向右箭头**|展开所选项（树视图和搜索结果）。如果该项已展开，则将选择其第一个子项。|
|**向左箭头**|折叠所选项（树视图和搜索结果）。如果该项已折叠，则将选择其父项。|
|**Alt + 向右箭头**|将资源显示为预览时展开项|
|**Alt + 向左箭头**|将资源显示为预览时折叠项|
## 默认文件夹
窗口中显示的内容主要是
![[Pasted image 20240830165909.png]]
1. Assets:  Assets文件夹中的所有内容主要用来管理资源脚本文件所有游戏资源都会显示在该窗口中
2. Scenes: 里面有一个默认空场景(老版本没有)
3. Packages: 官方拓展包

