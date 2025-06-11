## High Definition Render [Pipeline](https://so.csdn.net/so/search?q=Pipeline&spm=1001.2101.3001.7020) Wizard / 高清渲染管道向导
高清渲染管道（HDRP）包括**HD Render Pipeline Wizard**(高清渲染管道向导)，可帮助您配置Unity项目，使其与HDRP兼容。

要打开**Render Pipeline Wizard**,要到**Window > Render Pipeline**并且选择**HD Render Pipeline Wizard**。

在窗口顶部，有一个信息框，里面显示你当前安装的HDRP版本，以及与你当前Unity版本兼容的HDRP最新版。  
![在这里插入图片描述](https://i-blog.csdnimg.cn/blog_migrate/9ea4a74e8c628c67e7aa9516f2fdf607.png#pic_center)

## Default Path Settings / 默认路径设置

|**Property**|**Description**|
|---|---|
|**Default Resources Folder(默认资源文件夹)**|创建一个文件夹起名叫做 Render Pipeline Wizard，在加载或者创建资源的时候使用它，点击**Populate / Reset**按钮，让使用HDRP渲染场景所需要的资源填充**Default Resources Folder**文件夹(有关详情，请查看[填充默认资源文件夹](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Render-Pipeline-Wizard.html#PopulatingFolder))，如果文件夹中已经存在默认资源，则点击Populate/Reset按钮将重置现在已有的资源。|
|**Default Scene Prefab(默认场景预制物体)**|通过选择**File > New Scene**会在Unity中实例化创建一个新的默认场景，如果想要创建一个预设置好模板场景，需要到 **Assets > Create** 点击**HD Template Scene**，这样新创建的模板场景会包含这个Default Scene Prefab字段所指定的预制物体内的所有物体|
|**Default DXR Scene Prefab(默认的DXR场景预制物体)**|设置默认的带有光线追踪(DXR)的模板场景|
|**Install Configuration Editable Package(安装可编辑的包配置)**|在你的HDRP项目中的LocalPackage文件夹中创建实例化一个本地的[高清渲染管线包配置](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/HDRP-Config-Package.html)|

## Populating the default resources folder / 填充默认资源文件夹
当你点击Populate/Reseet，HDRP会生成以下资源：
- **DefaultSceneRoot**:Unity在创建每个新的HDRP预置模板场景时实例化的预置物体。
- **DefaultRenderingSettings**:模板场景用于设置Shadows,fog,sky等视觉元素的默认[Volume Profile](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Volume-Profile.html)。
- **DefaultPostprocessingSettings**:模板场景所使用的后处理效果的默认[Volume Profile](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Volume-Profile.html)的配置资源。
- **HDRenderPipellineAsset**:Unity用于为Unity项目的[HDRP的配置资源](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/HDRP-Asset.html)文件
- **Foliage Deffusion Profile**:用于模拟植物次表面和光相互作用的漫反射配置文件。
- **Skin Diffusion Profile**:用于模拟皮肤次表面和光相互作用的漫反射配置文件。  
    （这两个的翻译还是有点不太对劲）

## Configuration Checking
您的Unity项目必须遵守本节中的所有配置测试，HDRP才能正常工作。如果测试失败，会有错误信息告诉你，你可以点击修复按钮去修复这个错误。这可以帮助您快速解决HDRP项目中的所有的主要问题。这个渲染管道向导(Render Pipeline Wizard)可以加载或者创建你缺少的任何资源，最终会将这些资源放到**Default Resources Folder**(默认资源文件夹)中。

你可以使用三个不同的选项卡来设置你各个环境下的HDRP项目
- HDRP:使用此选项卡设置默认的HDRP项目.
- HDRP+VR:使用此选项卡设置HDRP项目并启用对虚拟现实的支持.
- HDRP+DXR:使用此选项卡可以设置HDRP项目并启用对光线跟踪的支持

## HDRP
该部分为您提供配置选项，以帮助你的Unity项目使用HDRP。

|**Configuration Option**配置选项|**Description**描述|
|---|---|
|**Color Space 色彩空间**|检查以确保将**Color Space** 设置为**Linear**。HDRP只支持**Linear Color Space**(线性色彩空间)，因为它提供了比**Gamma**更精确的物理结果 。点击**Fix**按钮，设置**Color Space** 为 **Linear**|
|**Lightmap Encoding 光照贴图编码**|检查以确保**Lightmap Encodings**的设置为**High Quality**,这是HDRP支持的唯一模式，点击Fix按钮，将Unity的光照贴图编码模式改为**High Quality**,这将会修改所有平台的光照贴图。|
|**Shadows 影子**|检查以确保Shadow **Quality**的设置为**All**,安装HDRP时，Unity会隐藏这个选项，并且自动将其设置为**All**.点击Fix按钮将**Shadow Quality**设置为**All**。|
|**Shadowmask Mode 影子遮罩模式**|检查以确保项目里的**Shadowmask Mode**的设置选项为**Distance Shadowmask**,它允许你在每个光源上更改**Shadowmask Mode**。点击**Fix**按钮将**Shadowmask Mode**设置为**Distance Shadowmask**。|
|**Asset Configuration 资源配置**|检查这部分中的所有的配置，按**Fix All** 按钮修复这部分中的所有配置|
|**-Assigned 已分配**|检查以确保你有一个[HDRP 资源](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/HDRP-Asset.html)已经分配给**Scriptable Render Pipeline Settings**属性(menu: **Edit > Project Settings > Graphics**)。点击**Fix**按钮打开一个弹出窗口，允许你分配HDRP资源或者创建并分配新的资源。|
|**-Runtime Resources 运行时的资源**|检查以确保你的HDRP资源引用了一个[**Render Pipeline Resources**](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/HDRP-Asset.html#GeneralProperties)资源。点击**Fix**按钮，重新加载HDRP资源在运行时引用的资源。|
|**-Editor Resources**|检查以确保你的HDRP资源引用了一个[**Render Pipeline Editor Resources**](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/HDRP-Asset.html#GeneralProperties)资源。点击**Fix**按钮，重新加载HDRP资源在运行时引用的资源。|
|**-Diffusion Profile**|检查以确保你的HDRP资源引用了一个[**Diffusion Profile**](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Diffusion-Profile.html)资源，点击**Fix**按钮，重新加载HDRP资源在运行时引用的资源。|
|**Default Scene Prefab**|检查以确保你有一个引用在这个向导面板上的**Default Scene Prefab**上，点击**Fix**按钮，打开一个弹出窗口，允许你分配一个预制物体或者创建并分配一个新的预制体|
## HDRP + VR
这部分提供了[HDRP窗口内容](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@7.1/manual/Render-Pipeline-Wizard.html#HDRPTab)里的所有的配置选项，以及一些其他配置选项，可以帮助你设置HDPR项目支持[虚拟现实](https://so.csdn.net/so/search?q=%E8%99%9A%E6%8B%9F%E7%8E%B0%E5%AE%9E&spm=1001.2101.3001.7020)（VR）。如果你在这个文档找不到这部分选项，检查上方的HDRP标签，这仅支持Windows系统。

|Configuration Option|Description|
|---|---|
|VR Activated|检查以确保**Virtual Reality Supported** 是启用的，在Unity里使用VR，只需要启用这个功能。点击Fix按钮，启用**Virtual Reality Supported**确保Unity支持VR。|

## HDRP + DXR
这部分提供HDRP窗口里的所有配置选项，以及一些其他选项配置，用来帮助你配置你的项目以支持光线追踪。如果你在这个文档找不到这部分选项，检查上方的HDRP标签，这仅支持Windows系统。

|Configuration Option|Description|
|---|---|
|Auto Graphics API|检查以确保你的**Auto Graphics API**选项在你当前平台的Player Settings里是关闭的，DXR需要使用**Direct3D 12**。点击Fix按钮关闭**Auto Graphics API**。|
|Direct3D 12|检查以确保**Direct3D 12**是Player Settings 中为当前平台的第一个Graphic API设置，点击**Fix**按钮为**Unity设置使用Direct3D 12**。|
|**Scripting Symbols**|检查以确保你的Player Settings里当前平台设置中的Scripting Symbols设置内设置包含了**REALTIME_RAYTRACING_SUPPORT**, 点击Fix按钮添**REALTIME_RAYTRACING_SUPPORT**到**Scripting Symbols**|
|**Screen Space Shadow**|检查以确保在当前的HDRP资产中启用了**Screen Space Shadow**,点击**Fix**按钮，启用**Screen Space Shadow**。|
|**DXR Activated**|检查以确保在当前的HDRP资产中启用了**DXR Activated**,点击Fix按钮，启用**DXR Activated**|
|**DXR Shader Config**|检查以确保你的项目里引用了**High Definition PR Config**包里的 **ShaderConfig.cs.hlsl**,并且将**SHADEROPTIONS_RAYTRACING**设置为**1**，点击**Fix**按钮，创建一个**High Definition RP Config**包的本地副本，然后在**ShaderConfig.cs.hlsl**里的**SHADEROPTIONS_RAYTRACING**设置为**1**。|
|**Default DXR Scene Prefab**|检查以确保在这个向导面板里**Default DXR Scene Prefab**属性字段分配了内容。点击Fix按钮，打开一个弹出窗口，允许你分配一个预置物体或者创建并分配一个新的预置物体到这个字段。|

## Project Migration Quick-links / 项目迁移快速链接
当你从内置渲染管线升级到高清渲染管线的时候，你需要升级灯光和材质，可以使用以下的实用程序功能来帮助你快速升级：
- **Upgrade Project Materials to High Definition Materials**:将项目中的所有材质升级为HDRP材质。
- **Upgrade Selected Materials to High Definition Materials**:将当前选择的所有材质升级为HDRP材质。
- **Upgrade Unity Builtin Scene Light Intensity for High Definition**:将当前场景中的所有灯光升级到HDRP兼容的强度值。