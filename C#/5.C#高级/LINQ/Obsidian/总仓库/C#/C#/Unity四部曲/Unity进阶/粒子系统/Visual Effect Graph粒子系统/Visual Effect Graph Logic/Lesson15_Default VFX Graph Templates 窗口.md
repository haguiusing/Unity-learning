# Default VFX Graph Templates 窗口
使用模板窗口创建具有预定义效果的 VFX Graph 资源。您可以将这些模板用作您自己的效果的起点。 每个模板都有一个描述和一个图像来描述其行为。
![模板窗口](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/templates-window.png)
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Templates-window.html#create-a-vfx-graph-template)创建 VFX 图形模板
![工具栏](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/templates-window-toolbar.png)  
要打开 Default VFX Graph Templates 窗口，请执行以下操作：
1. 选择 Visual Effect Graph 工具栏中 **Add** （**+**） 图标旁边的下拉箭头。
2. 选择以下选项之一：
    - **从模板创建** - 基于 VFX 图表模板创建新的 VFX 图表资产。
    - **Insert template** - 将 VFX Graph 模板添加到当前打开的 VFX Graph 资产。
3. 在 Create new VFX Asset （创建新的 VFX 资源） 窗口中，选择 Default VFX Graph （默认 VFX 图形） 模板。
4. 双击 Template 资产，或选择 **Create**

> - 添加 **[+]** 按钮可打开模板窗口，以在当前 VFX 中插入模板。
> - 如果在单击 **[+]** 按钮时按住 **CTRL** 键，则模板窗口将打开以创建新的 VFX 资产。
## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Templates-window.html#create-a-custom-vfx-graph-template)创建自定义 VFX Graph 模板
VFX Graph 包括一个 API，您可以使用该 API 创建和管理自己的 VFX Graph 模板。

要创建新的 VFX Graph 模板，请使用该方法。  
在脚本中包含以下内容：`VFXTemplateHelper.TrySetTemplate`
- VFX 资产的路径。
- 包含以下信息的结构：`VFXTemplateDescriptor`
    - 名称：模板的名称。
    - 类别：此模板显示在其中的类别。
    - Description（描述）：要在模板窗口详细信息面板中显示的模板的描述。
    - 图标：（可选）要在模板窗口模板列表中显示的图像图标。
    - 缩略图：（可选）要在模板窗口详细信息面板中显示的图像。

该方法在脚本创建新模板时返回，否则返回 。 自定义模板显示在 templates （模板） 窗口中您定义的 Category （类别） 中。`true``false`
### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Templates-window.html#use-an-existing-vfx-graph-template-in-script)在脚本中使用现有的 VFX Graph 模板
要获取现有模板描述符，请执行以下操作：
1. 使用方法 .  
    2.提供资产的路径和结构，如果找到资产并且是模板，则将填充该结构。`VFXTemplateHelper.TryGetTemplate``VFXTemplateDescriptor`

该方法在脚本找到模板时返回，否则返回 。`true``false`