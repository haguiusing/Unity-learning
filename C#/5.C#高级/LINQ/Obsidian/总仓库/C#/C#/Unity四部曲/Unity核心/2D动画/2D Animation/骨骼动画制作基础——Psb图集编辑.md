[骨骼动画制作基础——Psb图集编辑](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%C2%B7%E6%A0%B8%E5%BF%83/2D%E5%8A%A8%E7%94%BB/2D%20Animation/Lesson36_%E9%AA%A8%E9%AA%BC%E5%8A%A8%E7%94%BB%E5%88%B6%E4%BD%9C%E5%9F%BA%E7%A1%80_Psb%E5%9B%BE%E9%9B%86%E7%BC%96%E8%BE%91.cs)
由于未知原因PSD插件无法使用，创建了一个新Unity项目
位置：[D:\Obsidian Unity\Unity](file:///D:/Obsidian%20Unity/Unity)

Unity2022.2.16 对应 PSD插件8.0.2
![[Pasted image 20240923142551.png]]
# 新版本PSD Importer  
网站：[Collapsing Groups | 2D PSD Importer | 9.0.3 (unity3d.com)](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html)
PSD Importer Inspector 属性 将 .psb 文件导入项目后，即可使用 PSD 导入器。选择 .psb 资源文件，并将其 Texture Type （2D and UI） 设置为 Sprite （2D and UI）。PSD 导入器属性分为两个主要选项卡，并提供以下属性。

## Settings 选项卡 
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/psdimporter-properties-22.2.png)
设置 选项卡允许您自定义 PSD 导入器导入文件的方式。这些设置分为各个部分的折叠。

### General 
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/psdimporter-properties-22.2-general.png)

| **财产**                                                                                                                             |                                                                                                 | **描述**                                                                                                                                                                                                                                       |
| ---------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **纹理类型**                                                                                                                           |                                                                                                 | 选择[Sprite （2D 和 UI）](https://docs.unity3d.com/Manual/TextureTypes.html#Sprite)将 Texture 导入为[精灵](https://docs.unity3d.com/Manual/Sprites.html).需要开始使用导入的 Texture 和[2D 动画](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/)包。 |
| **Sprite 模式**                                                                                                                      |                                                                                                 | 使用此属性可指定 Unity 如何从图像中提取 Sprite 图形。默认情况下，此属性设置为 **Multiple （多个**）。                                                                                                                                                                            |
|                                                                                                                                    | **单**                                                                                           | 选择此选项可让 Unity 将导入的纹理视为单个 Sprite 资源，而不使用多个单独的部分。这对于在源文件的单个图层上绘制而不是拆分到多个图层上的字符来说是理想的。                                                                                                                                                          |
|                                                                                                                                    | **倍数**                                                                                          | 这是默认选项。选择此选项可让 Unity 为源文件中的每个图层创建一个 Sprite。这非常适合在源文件中的多个图层之间拆分不同部分的复杂图稿，并使用[2D 动画](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest)包。                                                                                        |
| **每单位像素数**                                                                                                                         |                                                                                                 | 设置等于一个 Unity 单位的像素数。                                                                                                                                                                                                                         |
| **网格类型**                                                                                                                           |                                                                                                 | 设置 Unity 为 Sprite 生成的 Mesh 类型。默认情况下，此字段设置为 **Tight**。                                                                                                                                                                                        |
|                                                                                                                                    | **[完整矩形](https://docs.unity3d.com/Documentation/ScriptReference/SpriteMeshType.FullRect.html)** | Unity 将精灵映射到矩形网格上。                                                                                                                                                                                                                           |
|                                                                                                                                    | **[紧](https://docs.unity3d.com/Documentation/ScriptReference/SpriteMeshType.Tight.html)**       | Unity 根据 Sprite 的轮廓生成网格。如果 Sprite 小于 32 x 32 像素，则 Unity 始终会将其映射到 **Full Rect** 四边形网格上，即使选择 **Tight** 也是如此。                                                                                                                                   |
| **挤出边**                                                                                                                            |                                                                                                 | 使用滑块确定从 Sprite 边缘延伸网格的程度。                                                                                                                                                                                                                    |
| **生成物理形状**                                                                                                                         |                                                                                                 | 如果尚未定义 [自定义物理形状]（https://docs.unity3d.com/Manual/CustomPhysicsShape.html），则启用此选项可从 Sprite 的轮廓生成默认的 [物理形状]（https://docs.unity3d.com/2017.4/Documentation/Manual/SpritePhysicsShapeEditor.html）                                                |
| **[自动重新切片](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#automatic-reslice)** |                                                                                                 | 仅当 **Import Mode （导入模式**） 设置为[单个精灵 （Mosaic）](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#Mosaic).启用此设置可从导入的图层重新生成 Sprite，并清除对 Sprite 及其元数据所做的                                         |

#### Automatic Reslice
启用此设置可放弃对当前 [SpriteRect](https://docs.unity3d.com/Packages/com.unity.2d.sprite@1.0/api/UnityEditor.SpriteRect.html) 数据集的所有用户修改，并根据当前源文件重新生成所有 SpriteRect。如果额外的 SpriteRect 元数据（例如权重和骨骼数据）对重新生成的 SpriteRect 仍然有效，则它们仍然存在。

### Layer Import 
以下部分仅在 **Texture Type （纹理类型**） 设置为 **Multiple （多个**） 时可用。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/psdimporter-properties-22.2-layerimport.png)

| **财产**        |                                                                                                                                | **描述**                                                                                                                                                                              |
| ------------- | ------------------------------------------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **包括隐藏图层**    |                                                                                                                                | 启用此属性可包含隐藏的[层](https://helpx.adobe.com/photoshop/using/layer-basics.html#layers_panel_overview)的 .psb 文件。这将产生与在源文件中取消隐藏源文件中的所有图层之前取消隐藏源文件中的所有图层相同的导入结果。如果只想导入 .psb 文件中的可见图层，请清除此选项。 |
| **保留重复名称**    |                                                                                                                                | 启用此设置可使 PSD 导入器从与其源图层名称完全相同的源文件生成 Sprite，即使存在多个具有相同名称的图层也是如此。                                                                                                                       |
| **使用图层组**     |                                                                                                                                | 仅当启用 **Character Rig** 时，此设置才可用。启用此设置可使导入器生成一个 Prefab，该预制件遵循导入的 .psb 的层和分组层次结构。文件。                                                                                                  |
| **图层映射**      |                                                                                                                                | 选择此选项可使用 .psb 文件提供的内部 ID 在 .psb 文件的图层和生成的 Sprite 之间进行映射。                                                                                                                            |
|               | **使用图层 ID**                                                                                                                    | 选择此选项可仅导入 .psb 文件中的可见图层。                                                                                                                                                            |
|               | **使用图层名称**                                                                                                                     | 选择此选项可使用 .psb 文件中的图层名称在 .psb 文件的图层和生成的 Sprite 之间进行映射。请注意，要使此选项正常工作，每个图层的名称都需要唯一。重复的名称可能会导致图层映射到错误的 Sprite。                                                                          |
|               | **使用图层名称（区分大小写）**                                                                                                              | 选择此选项可使用 .psb 文件中的图层名称（区分大小写）在 .psb 文件的图层和生成的 Sprite 之间进行映射。请注意，要使此选项正常工作，每个图层的名称都需要唯一。重复的名称可能会导致图层映射到错误的 Sprite。                                                                   |
| **导入模式**      |                                                                                                                                | 使用此属性可指定如何导入源文件中的图层。默认情况下，此属性设置为 **Individual Sprites （Mosaic）。**                                                                                                                   |
|               | **[单个精灵 （Mosaic）](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#Mosaic)** | 选择此选项可让 PSD 导入器从源文件的各个图层生成单个 Sprite，并将它们组合成 Sprite 表单布局中的单个纹理。                                                                                                                      |
|               | **[合并](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#merged)**            | 选择此选项可让 PSD 导入器生成合并所有图层的纹理。                                                                                                                                                         |
| **马赛克填充**     |                                                                                                                                | 当“导入模式”设置为“单个精灵（马赛克）”时，用于控制纹理中每一层之间的填充空间的设置。                                                                                                                                        |
| **Sprite 填充** |                                                                                                                                | 当“导入模式”设置为“单个精灵（马赛克）”时，用于增加纹理中每个精灵矩形大小的设置。                                                                                                                                          |

#### Individual Sprites (Mosaic) 
启用此选项可让 PSD 导入器使用 Photoshop 源文件中的图层创建纹理，就像所有[图层都已拼合](https://helpx.adobe.com/photoshop/using/layers.html)一样。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/individual-sprites-mosaic-22.2.png)  
各个图层作为单独的精灵导入，以马赛克的形式合并到单个纹理中。

#### Merged 
启用此选项可让 PSD 导入器使用 Photoshop 源文件中的图层创建纹理，就像所有[图层都已拼合](https://helpx.adobe.com/photoshop/using/layers.html)一样。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/merged-layers-22.2.png)

#### Keep Duplicate Names 
当存在重复名称时，Unity 的默认导入行为是将“_[number]”附加到它从具有相同名称的源层生成的 Sprite 和 SpriteRect 中。启用此功能后，Unity 会为 Sprite 和 SpriteRect 提供与其源层完全相同的名称，即使它们是重复的名称。

#### Layer Group
默认情况下，导入器仅为源文件中的层生成游戏对象。这是出于性能原因，以最大限度地减少预制件所需的游戏对象数量。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/ignore-layer-groups-22.2.png)  
生成的 **Layer Group** 设置为 **Ignore Layer Groups** 的预制件。

要根据源文件包含和维护组和层次结构，可以将 **Layer Group** 设置为 **As Per Source File**，如下例所示。
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/as-per-source-22.2.png)  
生成的同一源文件的预制件，其中 **Layer Group** 设置为 **As Per Source File**。

### Character Rig 
仅当 **Texture Type** 设置为 **Multiple，Import Mode** 设置为 **Individual Sprites （Mosaic）** 并且安装了 [2D 动画包](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest)时，此部分才可用。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/character-rig-22.2.png)

| **财产**                                                                                                                      |              | **描述**                                                                                                                                                                                                                                                                                                                                                                                     |
| --------------------------------------------------------------------------------------------------------------------------- | ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **[用作绑定](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#use-as-rig)**   |              | 启用此属性可让 PSD 导入器基于导入的源文件生成预制件。PSD 导入器从源文件的导入图层生成 Sprite，而 Sprite 的[等级制度](https://docs.unity3d.com/Manual/Hierarchy.html)和位置基于他们的[层层次结构](https://helpx.adobe.com/photoshop/using/layer-basics.html#layers_panel_overview)及其在源文件中的位置。                                                                                                                                                         |
| **[主骨架](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#main-skeleton)** |              | 仅当启用 **Use as Rig** 时，此选项才可用。分配此角色预制件的骨骼层次结构将引用的 **Skeleton Asset**。  <br>如果未分配 Skeleton Asset，导入器将自动生成 Skeleton Asset 作为此角色的子资源。骨架资源包含在 2D 动画包的[蒙皮编辑器](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/SkinningEditor.html)（请参阅[骨架共享](http://docs.unity3d.com/Packages/com.unity.2d.psdimporter@latest?subfolder=/manual/skeleton-sharing.html)了解更多信息）。 |
| **支点**                                                                                                                      |              | 仅当启用 **Use as Rig** 时，此选项才可用。选择 Sprite 的枢轴点。                                                                                                                                                                                                                                                                                                                                               |
|                                                                                                                             | **习惯**       | 定义自定义 Pivot 位置的 X 和 Y 坐标。                                                                                                                                                                                                                                                                                                                                                                  |
|                                                                                                                             | **（所有位置选择）** | 从下拉菜单中选择要在 Sprite 上放置枢轴的位置。                                                                                                                                                                                                                                                                                                                                                                |

####Use as Rig 
启用此属性可让 PSD 导入器根据导入的源文件的图层生成包含 Sprite 的预制件。PSD 导入器还会自动为 Sprite 提供 [Order in Layer](https://docs.unity3d.com/Manual/2DSorting.html) 值，该值根据它们在源文件的图层层次结构中的位置对它们进行排序。因此，生成的预制件会尽可能接近地在原始源文件中重新创建资源的排列和外观。

预制件中每个 Sprite 的名称与其所基于的源层相同，除非发生**名称冲突错误**，这通常是由于源层中的名称重复造成的。

如果 Sprite 包含[骨骼](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/SkinEdToolsShortcuts.html%23bone-tools)或[权重](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/SkinEdToolsShortcuts.html%23weight-tools)数据，则 PSD 导入器会自动将 Sprite Skin 组件添加到其中。如果已在 [Skinning Editor](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/SkinningEditor.html) 中使用骨骼和权重[绑定](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/CharacterRig.html) Sprite，并且正在重新导入源文件，或者您已手动将骨骼和权重数据[复制并粘贴到](https://docs.unity3d.com/Packages/com.unity.2d.animation@latest?subfolder=/manual/SkinEdToolsShortcuts.html%23copy-and-paste-behavior) Sprite 上，则会发生这种情况。

####Main Skeleton A skeleton Asset (.skeleton) 是包含骨骼层次结构的资源，可以使用 2D Animation 包进行动画处理。**Main Skeleton （主骨架**） 属性仅在启用 **Use As Rig importer （用作绑定**） 导入器设置的情况下导入 .psb 文件时可用。导入 .psb 文件后，将 .skeleton 资源分配给 **Main Skeleton** 属性，以使用该 .skeleton 资源中包含的骨骼层次结构自动绑定生成的预制件角色。

如果没有将 .skeleton 资源分配给导入器的 **Main Skeleton** 属性，则会自动生成一个 .skeleton 资源作为导入的源文件，并将其命名为“[Asset File Name] Skeleton”。您可以在不同生成的预制件之间**共享 .skeleton 资源**，方法是在导入 .skeleton 资源时为其 **Main Skeleton** 属性分配相同的 .skeleton 资源。

当您在 2D Animation 包的 **Skinning Editor** 中打开并编辑角色时，该模块将显示分配给 **Main Skeleton** 进行绑定的骨架资源提供的骨骼层次结构。

## Layer Management
**Layer Management 选项卡**允许您自定义导入器从 Photoshop 文件导入图层的方式。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-management-tab-22.2.png)

### Layer hierarchy tree（Layer 层次结构树）
Photoshop 中的[图层](https://helpx.adobe.com/photoshop/using/selecting-grouping-linking-layers.html)组在图层管理选项卡的层次结构树中用折叠文件夹图标![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/group-layers-icon.png)表示，而 Photoshop 中的常规 Photoshop 图层仅由其名称表示。

### Layer visibility （Layer 可见性）
与可见的组或图层相比，隐藏在源文件中的组或图层用不同颜色的文本表示。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-visibility-hidden-layer-22.2.png)

###Layer Importing 
每个组/图层上的复选框指示是否应导入 Photoshop 文件中的组或图层。选中该复选框后，将导入 Group 或 Layer。

清除 **Layer Management 选项卡**或 [Settings 选项卡中](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#settings-tab)的 **Include Hidden Layers** 选项将仅从源文件导入可见图层。

如果隐藏的组或图层在此状态下标记为导入，则会显示一个警告图标。
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-visibility-hidden-warning-22.2.png)

要导入隐藏层，请在 **Settings 选项卡**或 **Layer Management 选项卡中**选中 **Include Hidden Layers** 复选框

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-visibility-hidden-no-warning-22.2.png)
要批量选择或取消选择图层，您可以使用位于 Layer Importing 列标题的下拉菜单。![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/import-selection-dropdown-22.2.png)

### [Collapsing Groups](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#collapsing-groups)
导入组时，可以将组中的 Photoshop 图层折叠为单个 Sprite。将光标悬停在图层组上，**Collapse** 图标将显示在其左侧。
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-tab-collapse-22.2.png)箭头朝下的折叠图标。

单击该图标以指示所选组中的图层应作为单个 Sprite 导入。

### [Uncollapsing Groups](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#uncollapsing-groups)
将鼠标悬停在 Collapsed Group 图层上会显示 Uncollapse 图标（箭头朝上）。
![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-tab-uncollapse-22.2.png)  
再次选择该图标可取消折叠 Group 图层，并将 Group 中的所有 Layers 作为单独的 Sprite 导入。

#### [Subgroups within Group layers](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/PSD-importer-properties.html#subgroups-within-group-layers)
如果一个 Group 包含其他 Group 图层并被折叠，则子组中的图层也将折叠为单个 Sprite。

![](https://docs.unity3d.com/Packages/com.unity.2d.psdimporter@9.0/manual/images/layer-tab-subgroup-child-collapse-22.2.png)如果子组当前设置为折叠，则父组将具有单独的图标，指示当前设置为折叠的子组。