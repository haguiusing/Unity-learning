# Sprite Library Editor 基础知识
在 Sprite Library Editor 窗口中，您可以编辑所选 [Sprite Library 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html)的内容。选择一个 Sprite Library 资源，然后在其 Inspector 窗口中选择 **Open in Sprite Library Editor** 以打开此编辑器。您还可以通过转到 **Window** > **2D** > **Sprite Library Editor**，直接打开 Sprite Library Editor 窗口。

Sprite Library 资源将其包含的 Sprite 分组到 [Categories （类别](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#categories)） 和 [Labels （标签](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#labels)） 中，您可以在 Sprite Library Editor （精灵库编辑器） 窗口中编辑其内容。本页介绍了 Sprite Library Editor 的基本[功能](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#useful-editor-features)，以及如何开始编辑 Sprite Library 资源。

## 类别

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-add-category.png)  
_在 Categories 列中创建新 Category。_

使用 **Categories** 将 **Labels** 包含并分组在一起，以实现一个共同的目的，以便更轻松地组织 Sprite。例如，您可以为 Labels 创建名为 'Hat' 的 Category，它指的是角色的帽子精灵。

要创建新的 Category，请选择 Categories 列中的 **Add （+），**或将 Sprite 直接[拖动到](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Drag.html) Sprite Library Editor 窗口中。为每个 Category 指定一个唯一的名称，以确保编辑器正确识别每个单独的 Category。

### 本地和继承的类别

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-category-local-inherited.png)  
_**Categories** （**类别**） 列中的 Inherited （继承） 和 **Local （本地**） 折叠组。_

有两种类型的类别：

- **Local**：Local Category 是在编辑器窗口打开的 Sprite Library Asset 中创建的 Category。
- **继承的**类别：继承的类别是从设置为[主库](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#main-library)的 Sprite 库资源中检索的类别。

**注意**：您无法重命名继承的 Categories，以确保 [Sprite Library Asset Variant](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#create-a-sprite-library-asset-variant) 中的 Category 名称与 Main Library 中的原始名称匹配。这可确保 Variant 资源可以从主库继承所有 Categories 和 Labels。

要更改继承的 Category 的内容，您可以创建对继承的 Category 或 Label 的[覆盖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html#create-overrides)，例如添加新的 Labels 或更改继承的 Label 引用的 Sprite。

## 标签

一个 Category 包含多个 Label，每个 Label 引用项目中的单个 sprite。当您[设置 Sprite Swap](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SpriteSwapSetup.html) 时，具有相似功能的 Label 通常放置在同一个 Category 中。例如，名为 'Hats' 的类别可能包含标签，每个标签都引用不同的帽子精灵。

要创建新的 Label，请在 Labels 列中选择 **Add （+），**或将 Sprite 直接[拖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Drag.html)到 Sprite Library Editor 窗口中。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-add-label.png)_通过选择 **Add （+）** 创建新标签。_

**注意：**如果标签是从主库继承的，并且存在于[继承的类别中](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#local-and-inherited-categories)，则无法重命名继承的标签，以确保它与主库中的原始名称匹配。这可确保 Variant 资源可以从主库继承所有 Categories 和 Labels。

您可以创建新的 Labels 或编辑继承的 Label 的 sprite 引用，作为继承的 Category 或 Label 的[覆盖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html#create-overrides)。请参阅 [Main Library 中的 Overrides](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html) 了解更多信息。

## 有用的编辑器功能

通过以下编辑器功能，可以更方便地编辑 Sprite Library 资源的内容。有关所有可用编辑器功能的更多信息，请参阅 [Sprite Library Editor 参考](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html)。

### 在不同资产之间导航

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-breadcrumbs.png)

在 Sprite Library Editor 中打开 Sprite Library Asset Variant 时，您可以使用 Sprite Library Editor 痕迹导航跟踪在打开的资源继承自的不同 Sprite Library 资源之间导航。在痕迹导航跟踪中选择一个资产，以在 Project （项目） 窗口中选择该资产。

### 在列表或网格视图之间切换

您可以在列表或网格中查看 Labels 的 sprite 内容。要在这两个视图之间切换，请选择编辑器窗口右下角的相应图标，然后使用滑块调整视觉对象预览的大小。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-labels-view-type.png)

### 按名称筛选类别和标签

通过在窗口右上角的筛选栏中输入文本字符串来筛选 Categories 和 Labels。您可以使用[过滤器上下文菜单](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#filter-context-menu)调整过滤器的参数。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-filter-box.png)

# Sprite Library Editor 参考

**Sprite Library Editor** 窗口显示所选 [Sprite Library 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html)的内容。使用编辑器查看、创建或编辑所选 Sprite Library 资源中的 [Categories](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#categories) 和 [Labels](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#labels)。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-blank.png)

A： 在此编辑器中打开的 Sprite Library Asset 的名称。 B：如果此资产是 [Variant 资产](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant)，则显示该资产的 [Main Library](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html)。请参阅 [Variant asset specific properties](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#variant-asset-specific-properties) 以了解更多信息。 C：在此编辑器中所做的更改的[保存选项](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#saving-options)。 D：在此处输入文本字符串以按名称筛选 类别 或 标签.选择筛选器左侧的放大镜图标以显示其[上下文菜单](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor-UI.html#filter-context-menu)。

## 保存选项

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-save-options.png)

|财产|描述|
|---|---|
|**恢复**|选择此选项可放弃所有未保存的更改，并返回到资源的上次保存状态。|
|**救**|选择此选项可保留所有未保存的更改，并将其包含在资源的已保存状态中。|
|**自动保存**|启用此选项可让编辑器在您对资源进行任何更改时自动保存。|

## 主库

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-main-library.png)

|财产|描述|
|---|---|
|**主库**|将 Sprite Library 资源分配给此资源，以将其设置为打开的 Sprite Library 资源的 Main Library，它将继承 Main Library 的 Categories 和 Labels。这样做还会将打开的 Sprite 库资源转换为[Sprite 库资产变体](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant).|

## Filter 上下文菜单

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-filter-context-menu.png)

|财产|描述|
|---|---|
|**类别和标签**|在 Category 和 Label names 中搜索输入的搜索字符串。|
|**类别**|仅在 类别名称 中搜索输入的搜索字符串。|
|**标签**|仅在 Label names 中搜索输入的搜索字符串。|

## 类别和标签列

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-category-contents.png)

|财产|描述|   |
|---|---|---|
|**类别**|显示全部[类别](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#categories)打开的 Sprite Library 资源包含。选择此列左上角的 **Add （+）** 以向此资产添加新的空 **Category**。|   |
||**本地**折叠组|将在此 Sprite Library 资源中创建的所有类别分组。|
||**继承的**折叠组|对从此 Sprite Library Asset Variant 的 Main Library 继承的所有 Categories 进行分组。**注意：**仅当打开的 Sprite 库资源是[变体资产](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant).|
|**标签**|显示全部[标签](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#labels)当您从 Categories （类别） 列中选择一个 Category 时，所选 **Category** 包含。选择此列左上角的 **Add （+）** 以向此资产添加新的空 **Label**。|   |
||**（Sprite）** 对象字段|显示此 Label 引用的 sprite。默认情况下，此字段为空。通过打开对象选择器来选择 Sprite，或将 Sprite 直接拖动到此字段上。|

### 特定于 Variant 资产的属性

只有在 Sprite Library Editor 中打开 [Sprite Library Variant 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html#convert-a-sprite-library-asset-into-a-variant)时，以下属性和 UI 功能才可见。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-variant-annotated.png)

E：痕迹导航跟踪，显示已打开的 Variant 资产及其继承自的 Library 资产的名称。 F：Variant 资源继承自的主库。 G：继承的组类型，显示从主库继承的所有类别。 H：一条垂直的白线，表示存在[覆盖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html#create-overrides)。

## 标签上下文菜单

右键单击 Labels 列中的 Label 以打开此上下文菜单。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-label-context-menu.png)

| 财产         | 描述                                                            |
| ---------- | ------------------------------------------------------------- |
| **创建新标签**  | 在选定的类别中创建新的本地标签。                                              |
| **重命名标签**  | 重命名所选 Label （标签）。如果它是继承的 Label，则此选项不可用。                       |
| **删除所选标签** | 删除所有选定的 Labels。如果它们是继承的 Labels，则此选项不可用。                       |
| **还原选定覆盖** | 删除在所选 Labels 中所做的所有覆盖，并将它们返回到其继承状态。                           |
| **还原所有覆盖** | 删除选定类别中的所有覆盖。                                                 |
| **显示标签位置** | 仅当所选 Label 具有设置的 sprite 引用时，此选项才可用。选择此选项可打开 Label 引用的 sprite。 |
## 其他资源

- [拖动 Sprite 以创建或编辑 Categories 和 Labels](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Drag.html)
- [主库的覆盖](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Main-Library.html)