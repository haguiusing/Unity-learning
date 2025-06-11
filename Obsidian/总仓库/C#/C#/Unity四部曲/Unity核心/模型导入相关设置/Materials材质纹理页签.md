
![[Pasted image 20240925135510.png]]
![[Pasted image 20240925135534.png]]

# Materials 选项卡

可以使用此选项卡更改 Unity 在导入模型时处理材质和纹理的方式。

当 Unity 导入没有指定任何材质的模型时，它使用 Unity 漫反射材质。如果模型有材质，Unity 会将这些材质导入为子资源。

![Materials 选项卡定义了 Unity 导入材质和纹理的方式](https://docs.unity3d.com/cn/current/uploads/Main/FBXImporter-Materials-1.png)

Materials 选项卡定义了 Unity 导入材质和纹理的方式

如果模型有纹理，还可以使用 [Extract Textures](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#textures) 按钮将纹理提取到项目中。

|**属性**|   |**功能**|
|---|---|---|
|**Material Creation Mode**|   |定义希望 Unity 如何为模型生成或导入材质。从该下拉菜单中选择 **None** 时，Inspector 将在此选项卡上隐藏其余设置。|
||**None**|不使用此模型中嵌入的任何材质。改用 Unity 的默认漫射材质。|
||**Standard**|导入时，Unity 应用一组默认规则来生成材质。如果要通过脚本来自定义 Unity 生成材质的方式，请改用 **Import via MaterialDescription (Experimental)** 模式。|
||**Import via MaterialDescription (Experimental)**|导入时，Unity 使用 FBX 文件中嵌入的材质描述来生成材质。与先前的导入方法相比，此方法可提供更准确的结果，并且支持更广泛的材质类型，例如 Autodesk 的 [Arnold](https://www.arnoldrenderer.com/home/) 和 [Physical](https://knowledge.autodesk.com/support/3ds-max/learn-explore/caas/CloudHelp/cloudhelp/2020/ENU/3DSMax-Lighting-Shading/files/GUID-809B9123-21A2-443E-A7A4-0DAB70410B8D-htm.html?st=Physical%20Material) 以及 Unity 的 [HDRP 材质](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/manual/Material-Type.html)。有关更多信息，请参阅下面的[材质描述](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#material_description)部分。|
|**sRGB Albedo Colors**|   |启用此选项可在伽马空间中使用反照率颜色。默认情况下为旧版导入方法启用了此选项。  <br>  <br>对于使用[线性颜色空间](https://docs.unity3d.com/cn/current/Manual/LinearLighting.html)的项目，请禁用此选项。  <br>  <br>如果从 **Material Creation Mode** 下拉菜单中选择 **Import via MaterialDescription (Experimental)**，则该属性不可用。|
|**Location**|   |定义如何访问材质和纹理。根据选择的这些选项，可以使用不同的属性。|
||**Use Embedded Materials**|[将导入的材质保持在导入的资源中](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#Embedded)。从 Unity 2017.2 版本开始，这是默认选项。|
||**Use External Materials (Legacy)**|[将导入的材质提取为外部资源](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#Legacy)。这是旧版的材质处理方式，适用于使用 Unity 2017.1 或早期版本创建的项目。|

## Use Embedded Materials

从 **Location** 选项中选择 **Use Embedded Materials** 时，将显示以下导入选项：

![材质的导入设置](https://docs.unity3d.com/cn/current/uploads/Main/FBXImporter-Materials-2.png)

材质的导入设置

**(A)** 单击 **Extract Materials** 和 **Extract Textures** 按钮可提取导入的资源中嵌入的所有材质和纹理。如果没有需要提取的子资源，这两个按钮显示为灰色。在这两个按钮下方，Unity 显示有关导入过程的所有消息。

**(B)** [On Demand Remap](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#remapped) 部分提供 [Naming](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#naming) 和 [Search](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#search) 属性，允许您自定义 Unity 将导入的材质映射到模型的方式。单击 **Search and Remap** 按钮可将导入的材质重新映射到现有材质资源。如果 Unity 找不到具有正确名称的任何材质，则不会有任何变化。

**(C)** Unity 显示在 [Remapped Materials](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#remapped) 列表中的资源中找到的所有导入材质。如果 Unity 无法自动将每种材质与项目中现有的材质资源进行匹配，则可以在此列表中自行设置对材质的引用。

### Remapped Materials

新导入操作或对原始资源的更改不会影响提取的材质。如果要从源资源重新导入材质，必须删除 **Remapped Materials** 列表中对提取的材质的引用。要从该列表中删除某一项，请选择该项，然后按键盘上的 Backspace 键。

### Naming

定义材质的命名策略。

|**属性**|**功能**|
|---|---|
|**By Base Texture Name**|使用导入材质的漫射纹理名称来命名材质。如果未将漫射纹理分配给材质，Unity 将使用导入材质的名称。|
|**From Model’s Material**|使用导入材质的名称来命名材质。|
|**Model Name + Model’s Material**|使用模型文件的名称与导入材质的名称相结合来命名材质。|

### Search

定义 Unity 尝试在使用 **Naming** 选项定义的名称时查找现有材质的位置。

|**属性**|**功能**|
|---|---|
|**Local Materials Folder**|在本地 _Materials_ 子文件夹（即模型文件所在的同一文件夹）中查找现有材质。|
|**Recursive-Up**|在所有父文件夹（一直向上追溯到 _Assets_ 文件夹）中的所有 Materials 子文件夹中查找现有材质。|
|**Project-Wide**|在所有 Unity 项目文件夹中查找现有材质。|

### 材质描述

从 2019.3 版本开始，Unity 引入了在导入期间通过脚本修改材质映射的功能。用户可以修改 Unity 如何将导入的材质属性从 FBX 文件中嵌入的数据映射到 Unity 材质属性。材质描述定义了一个名称和几组值，它们描述了材质及其引用的任何纹理。有关这种描述的结构的更多信息，请参阅 [MaterialDescription](https://docs.unity3d.com/cn/current/ScriptReference/AssetImporters.MaterialDescription.html) 类参考页面。

在 [ImportViaMaterialDescription](https://docs.unity3d.com/cn/current/ScriptReference/ModelImporterMaterialImportMode.ImportViaMaterialDescription.html) 模式下，模型导入器会将材质的创建任务委派给 [AssetPostProcessor.OnPreprocessMaterialDescription](https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.OnPreprocessMaterialDescription.html) 回调。

Unity 提供了该后期处理程序 (Post Processor) 的默认实现方案，可处理以下材质：

- 来自 FBX 文件的 FBX 标准材质 (FBX Standard Material)、Arnold 标准 (Arnold Standard)、Autodesk Interactive 和 3Ds 物理材质 (3Ds Physical Material)
- Sketchup、Collada 和 3DS 材质

与 [ImportStandard](https://docs.unity3d.com/cn/current/ScriptReference/ModelImporterMaterialImportMode.ImportStandard.html) 模式相比，这些默认实现方案处理导入材质的方式有所不同，有以下改进：

- 支持更多材质类型，例如 Autodesk 的 [Arnold](https://www.arnoldrenderer.com/home/) 和 Interactive 或 [Physical](https://knowledge.autodesk.com/support/3ds-max/learn-explore/caas/CloudHelp/cloudhelp/2020/ENU/3DSMax-Lighting-Shading/files/GUID-809B9123-21A2-443E-A7A4-0DAB70410B8D-htm.html?st=Physical%20Material)，还支持 Unity 的 [HDRP 材质](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/manual/Material-Type.html)。
    
- 支持[发光材质](https://docs.unity3d.com/cn/current/Manual/lighting-emissive-materials.html)。
    
- 如果设置了漫射纹理，则会忽略漫射颜色（与 Autodesk® Maya® 和 Autodesk® 3ds Max® 中的处理方式一致）。
    
- 将凹凸系数、发光颜色和发光系数纳入考虑范围。
    
- 在 FBX 文件中有相应定义时可以导入发光颜色动画。
    
    **注意**：3ds Max 不能导出发光颜色动画，因此 Unity 也无法导入发光颜色动画。
    
- 以完全透明形式导入透明材质。旧版系统则以完全不透明形式导入透明材质。
    

此外，还可以导入所有 [Autodesk Interactive](https://knowledge.autodesk.com/support/3ds-max/learn-explore/caas/CloudHelp/cloudhelp/2020/ENU/3DSMax-Lighting-Shading/files/GUID-7EEAC650-7D26-40AE-AC14-577F7A2EF2B3-htm.html) 材质属性动画，并且从 3DS 文件导入材质时不再忽略不透明度。

## Use External Materials (Legacy)

从 **Location** 选项中选择 **Use External Materials (Legacy)** 时，将显示以下导入选项：

![Use External Materials (Legacy) 导入设置](https://docs.unity3d.com/cn/current/uploads/Main/FBXImporter-Materials-3.png)

Use External Materials (Legacy) 导入设置

此选项提取材质并将它们保存到外部，而不是保存在模型资源内部。[Naming](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#naming) 和 [Search](https://docs.unity3d.com/cn/current/Manual/FBXImporter-Materials.html#search) 属性可帮助 Unity 找到导入的材质以映射到模型。

在 Unity 2017.2 版之前，这是默认的材质处理方式。

---

- [2017.2](https://docs.unity3d.com/2017.2/Documentation/Manual/30_search.html?q=newin20172) 中添加了 Materials 选项卡
- 在 [2017.3](https://docs.unity3d.com/2013.1/Documentation/Manual/30_search.html?q=newin20173) 中添加了 Use Embedded Materials 选项
- 在 [2019.3](https://docs.unity3d.com/2017.1/Documentation/Manual/30_search.html?q=newin20193) 中添加了 Import via Material Description 选项