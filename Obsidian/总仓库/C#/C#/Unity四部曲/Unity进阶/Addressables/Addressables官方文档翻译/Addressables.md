# Addressables （可寻址）
Addressables 系统提供了工具和脚本来组织和打包应用程序的内容，并提供了一个 API，用于在运行时加载和发布资产。

当您将资产设为 “Addressable” 时，您可以使用该资产的地址从任何位置加载它。无论该资产驻留在本地应用程序还是内容交付网络上，Addressable 系统都会找到并返回它。

采用 Addressables 系统来帮助在以下方面改进您的项目：
- **灵活性**：Addressables 让您可以灵活地调整资产的托管位置。您可以随应用程序一起安装资产，也可以按需下载它们。您可以在项目的任何阶段更改访问特定资源的位置，而无需重写任何游戏代码。
- **依赖项管理**：系统会自动加载您加载的任何资源的所有依赖项，以便在系统将内容返回给您之前加载所有网格、着色器、动画和其他资源。
- **内存管理**：系统卸载和加载资产，自动对引用进行计数，并提供强大的分析器来帮助您发现潜在的内存问题。
- **内容打包**：由于系统映射并了解复杂的依赖关系链，因此它可以有效地打包 AssetBundle，即使您移动或重命名资源也是如此。您可以为本地和远程部署准备资产，以支持可下载内容并减小应用程序大小。

有关 Addressables 系统的介绍，请参阅[使用 Addressables 简化内容管理](https://unity.com/how-to/simplify-your-content-management-addressables)。

##### 注意
Addressables 系统基于 Unity AssetBundle 构建。如果您想在项目中使用 AssetBundle，而不编写自己的详细管理代码，则应使用 Addressables。

## 将 Addressables 添加到现有项目
您可以通过安装 Addressables 包在现有 Unity 项目中采用 Addressables。为此，您需要为资产分配地址并重构任何运行时加载代码。有关更多信息，请参阅[升级到 Addressables 系统](https://docs.unity3d.com/Packages/com.unity.addressables@1.18/manual/AddressableAssetsMigrationGuide.html)。

尽管您可以在项目开发的任何阶段集成 Addressables，但 Unity 建议您立即开始在新项目中使用 Addressables，以避免在开发后期进行不必要的代码重构和内容规划更改。