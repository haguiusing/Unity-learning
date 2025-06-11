# 拖动 Sprite 以创建或编辑 Categories 和 Labels

本页介绍了在 Sprite Library 资源中创建或编辑 Categories 和 Labels 的不同方法，方法是将 Sprite 直接拖动到 Sprite Library Editor 窗口中。

您可以通过将 Sprite 或 [PSD Importer 支持的文件类型](https://docs.unity.cn/Packages/com.unity.2d.psdimporter@latest)直接拖动到 [Sprite Library Editor](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html) 窗口中来自动创建新的类别和标签。

## 先决条件

- Sprite Library Editor 需要 [PSD 导入器包](https://docs.unity.cn/Packages/com.unity.2d.psdimporter@latest)才能识别导入的 .psb 文件。

## 创建新类别

1. 在打开的 Sprite Library Editor 窗口中，将 Sprite 直接拖到 Categories 列上以创建新的 Category。如果不先选择现有 Category，则无法创建 Labels。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-sprite-category.png)
    

## 为每个 sprite 创建一个新的 Label

1. 选择一个 Category，然后将一个或一系列 sprite 拖到 Labels 列的空白区域。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-drag-n-drop-04.png)  
    _将 `head` sprite 拖动到 Labels 列中，将在所选 Category 中创建一个名为 `head` 的新 Label。_
    
2. Unity 会为选择中的每个 sprite 创建一个新 Label，并为其指定与它引用的 sprite 相同的名称。**注意：**如果目标中已存在同名的现有 Label，则编辑器会将 Label 附加到新 Label 的名称，其中是序列中的下一个数字，从零开始。`_X``X`
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-drag-n-drop-04-finished.png)  
    _拖动所有名为 `head` 的 sprite 选择会导致为每个 sprite 创建带有 `_X` 后缀的其他 Labels。_
    

## 替换 Label 的 sprite 引用

1. 将 sprite 拖动到现有 Label 上。![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-drag-n-drop-05.png)
    
2. 编辑器将替换对新 Sprite 的 sprite 引用。Label 的名称保持不变。![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SLAsset-drag-n-drop-05-finished.png)
    

## 创建具有多个标签的单个类别

1. 从 Project 窗口中选择多个 sprite。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-select-sprites.png)
    
2. 将选定的 sprite 拖动到 Categories 列中以创建新的 Category。Category 会自动以所选内容中的第一个 sprite 命名。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-select-sprites-drop.png)
    

**注意：**如果目标中已存在同名的现有 Category，则编辑器会将 Category 附加到新 Category 的名称，其中 是序列中的下一个数字，从 0 开始。`_X``X`

## 为每个图层和图层组创建类别

准备好角色的 [.psb](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/PreparingArtwork.html) 后，使用 PSD Importer 包将其导入 Unity。**注意：**以下[要求](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Drag.html#prerequisites)安装 PSD Importer 包。

1. 在导入的 .psb 属性中启用 **Use Layer Group**。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-wolf-layer-groups.png)
    
2. 将导入的 .psb 文件拖动到 Sprite Library Editor 的 Categories 列中。
    
3. 编辑器将为每个 Layer 和 Layer Group 创建一个 Category，并为每个 sprite 创建 Labels。属于同一 Layer Group 的 Sprite 会自动分组到同一 Category 中。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-wolf-labels.png)
    

## 替换每个 Labels 的 sprite 引用

以下步骤如何将每个 Label 的 sprite 引用替换为来自不同导入的 .psb 的 sprite。**注意：**仅当导入的 .psb 的图层和图层组与用于创建[类别和标签](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Drag.html#create-categories-for-each-layer-and-layer-group)的原始 .psb 名称完全相同时，此方法才有效。

当您有多个角色具有相同的 Layers 和 Layer Group，并且想要替换它们各自的 Sprite 而不创建新的 Sprite Library 资源时，此方法非常有用。

1. 在替换 .psb 文件的属性中启用 **Use Layer Groups**。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-knight-drag.png)
    
2. 将替换的 .psb 拖动到 Categories （类别） 列中的空白处，然后释放。所有同名且属于相同 Categories 的 sprite 引用都会自动替换为替换 .psb 中的相应引用。
    
    ![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/sl-editor-drag-knight-drop.png)