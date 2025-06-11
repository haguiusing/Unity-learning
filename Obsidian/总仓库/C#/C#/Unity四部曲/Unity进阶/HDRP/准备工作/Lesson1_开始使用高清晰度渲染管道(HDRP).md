# 开始使用高清渲染管线 (High Definition Render Pipeline)
[高清渲染管线 (HDRP)](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/index.html) 与 Unity 内置渲染管线使用不同的[着色器](https://docs.unity3d.com/Manual/class-Shader.html)和光照单位。这意味着必须创建一个使用 HDRP 的新项目，或者[升级现有项目以使用 HDRP](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Getting-started-with-HDRP.html#UpgradingToHDRP)。

本文档将说明如何创建使用 HDRP 的场景，并介绍有助于生成高保真视觉效果的关键功能。

要升级未使用 HDRP 的现有项目，需要转换材质以使其与 HDRP 兼容。有关升级过程的更多信息，请参阅[升级到 HDRP](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Upgrading-To-HDRP.html)。

## 从模板创建 HDRP 项目
要设置和管理 Unity 项目，请安装 [Unity Hub](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html)。

Unity 提供了一个 HDRP 模板项目，您可以使用它来快速设置 HDRP。要创建 HDRP 模板项目，请执行以下操作：
1. 打开 Unity Hub，找到 **Projects** 选项卡，然后单击 **New**。
2. 在 **Project Name** 中输入项目名称，然后在 **Template** 部分单击 **High Definition RP**。
3. 单击 **Create**。

Unity 会创建一个项目并自动安装 HDRP 包及其所有依赖项。Unity 打开模板项目后，您可以看到主场景。具体如下所示：
![](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/images/GettingStarted1.png)

此模板是高端图形项目的极好起点。该模板包含多个基于物理的光照设置，有助于利用 HDRP 创建逼真的光照环境。此外，模板中还包括多个 HDRP 功能（如[贴花](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Decal.html)、[体积](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Volumes.html)以及物理精确材质）的使用示例。

## 管线设置
在使用 HDRP 之前，需要一个 HDRP 资源，此资源可以控制全局渲染设置并创建高清渲染管线实例。**High-Definition RP** 模板将为你创建 HDRP 资源，但你可以创建不同的 HDRP 资源来满足自己的渲染需求，例如为每个目标平台创建一个 HDRP 资源。HDRP 资源允许你在编辑器中为整个项目启用功能。该资源为不同的功能分配内存，因此你无法在运行时编辑它们。有关更多信息，请参阅 [HDRP 资源](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Asset.html)。

要在渲染质量和运行时性能之间找到适当的平衡点，请调整[摄像机](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Camera.html)的[帧设置](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Frame-Settings.html)。只要在进入运行模式/构建 HDRP 项目之前在 HDRP 资源中启用了效果，便可以通过帧设置在运行时基于每个摄像机启用或禁用效果。

## Render Pipeline Wizard
HDRP 提供了 [Render Pipeline Wizard](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Render-Pipeline-Wizard.html)，旨在帮助你为项目设置 HDRP。还可以使用该向导为 HDRP 项目添加对 DirectX 光线追踪 (DXR) 或 VR 的支持。如果使用 **High-Definition RP** 模板创建项目，则除非要使用 DXR 或 VR，否则无需使用 Render Pipeline Wizard。

## 体积
使用[体积](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Volumes.html)，可以将场景划分为多个区域，因此可以更精细地控制光照和效果，而不是调整整个场景。可以根据需要为场景添加任意数量的体积，创建不同的空间，然后单独为它们设置光照以获得逼真的效果。每个体积都有一个环境，因此可以调整其天空、雾效和阴影设置。还可以创建自定义的[体积配置文件](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Volume-Profile.html)并在它们之间切换。

要将体积添加到场景并编辑其体积配置文件，请执行以下操作：
1. 前往 **GameObject > Volume** 并从列表中选择一个选项。
2. 在 Scene 视图或 Hierarchy 视图中选择新的游戏对象以在 Inspector 中查看该游戏对象。
3. 在 **Volume** 组件上，为 **Profile** 属性字段分配一个体积配置文件。如果要创建新的体积配置文件，请单击该属性字段右侧的 **New** 按钮。
4. 体积配置文件包含的[体积覆盖](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Volume-Components.html)列表现在应该会出现在 **Profile** 属性下。在此处可以添加或移除体积覆盖，并可编辑其属性。

### 视觉环境
[视觉环境 (Visual Environment)](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Override-Visual-Environment.html) 覆盖允许你更改场景中所需的天空和雾效类型。例如，使用体积雾来创建大气光线，如下所示：
![](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/images/GettingStarted3.png)

有关更多信息，请参阅[视觉环境 (Visual Environment)](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Override-Visual-Environment.html)、[天空概述](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Features.html#sky)和[雾效概述](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Features.html#fog)。

## 材质和着色器
HDRP 提供了一些着色器可用于创建各种不同的材质。例如，可以创建具有折射效果的玻璃或具有次表面散射效果的叶子。材质的选项取决于材质使用的着色器。HDRP 在着色器之间共享多种材质属性。有关更多信息，请参阅 [HDRP 材质功能](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Features.html#Material)。

## 光照
为了在场景中应用逼真的光照，HDRP 使用物理光单位 (PLU)，这种单位基于真实的可测量值，就像在商店中寻找灯泡或使用摄影测光表来测光时所看到的单位一样。请注意，为使光源在使用 PLU 时正常工作，需要遵循 HDRP 单位约定（1 个 Unity 单位等于 1 米）。有关更多信息，请参阅[物理光单位](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Physical-Light-Units.html)。

另外请注意，鉴于以上原因，默认情况下，HDRP 使用的 HDRI 天空的曝光值为 10。但是，新创建的方向光的强度为 3.14，这会导致对象看起来为黑色，因为自动曝光可以补偿过亮的天空。将方向光的值设置为 10000 应该适合于混合的室内和室外场景。如果正确设置了 HDRP 向导，则新创建的场景应具有立即可用的合理值。

有关更多信息，请参阅 [HDRP 光照功能](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Features.html#Lighting)。有关向场景添加光源的建议，请参阅[光源](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Light-Component.html)。

### 光源资源管理器
HDRP 向[光源资源管理器 (Light Explorer)](https://docs.unity3d.com/Manual/LightingExplorer.html) 中添加设置（菜单：**Window > Rendering > Light Explorer**），便于调整 HDRP 功能和光照单位。![](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/images/GettingStarted4.png)

使用光源资源管理器 (Light Explorer) 可以更改项目中任何光源类型的设置，而无需在场景中查找光源。还可以在此窗口中管理反射探针和光照探针。

## 阴影
[Shadows](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Override-Shadows.html) 体积覆盖允许你确定体积中阴影的整体质量。例如，**Max Distance** 字段根据摄像机与阴影的距离来计算阴影的质量。

有关更多信息，请参阅[阴影](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/Override-Shadows.html)。

## 相关信息
- 如需查看完整的 HDRP 功能列表，请参阅 [HDRP 功能](https://docs.unity3d.com/cn/Packages/com.unity.render-pipelines.high-definition@10.4/manual/HDRP-Features.html)。
- 如需观看关于如何在 HDRP 中实现实时高保真图形的在线教程，请参阅[使用 HDRP 为游戏实现高保真图形 (Achieving High Fidelity Graphics for Games with HDRP)](https://resources.unity.com/unitenow/onlinesessions/achieving-high-fidelity-graphics-for-games-with-hdrp)。