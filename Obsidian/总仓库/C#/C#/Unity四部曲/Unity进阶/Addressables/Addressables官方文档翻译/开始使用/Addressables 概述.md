Addressables 提供了一个可以随您的项目扩展的系统。您可以从简单的设置开始，然后随着项目复杂性的增加而重新组织，同时只需进行最少的代码更改。

例如，可以从一组 Addressable 资源开始，Unity 将其作为一个集合加载。然后，在添加更多内容时，您可以将资产拆分为多个组，以便仅在给定时间加载所需的资产。随着团队规模的增长，您可以创建单独的 Unity 项目来开发不同类型的资源。这些辅助项目可以生成自己的 Addressables 内容构建，您可以从主项目加载这些内容。

## [概念](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#concepts)

本概述讨论了以下概念，以帮助您了解如何通过 Addressables 系统管理和使用资产：

| **概念**                                                                                                                                            | **描述**                                                                                                                                                                                                                |
| ------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [Addressables 工具](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#addressables-tools)          | Addressables 包具有多个窗口和工具，可用于组织、构建和优化内容。                                                                                                                                                                                |
| [资产地址](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#asset-addresses)                        | 标识 Addressable 资产的字符串 ID。您可以使用地址作为键来加载资产。                                                                                                                                                                             |
| [资产加载和卸载](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#asset-loading-and-unloading)         | API 提供了自己的函数，用于在运行时加载和释放资产。`Addressables`                                                                                                                                                                             |
| **资产位置**                                                                                                                                          | 一个运行时对象，用于描述如何加载资产及其依赖项。您可以使用 location 对象作为键来加载资产。                                                                                                                                                                    |
| [AssetReferences （资产引用）](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#assetreference)       | 一种类型，可用于支持将 Addressable 资产分配给 Inspector 窗口中的字段。您可以使用 AssetReference 实例作为键来加载资产。这[`AssetReference`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AssetReferences.html)class 也提供了自己的 loading 方法。 |
| [内容构建](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#content-builds)                         | 在创建播放器版本之前，使用内容版本将资产整理和打包为单独的步骤。                                                                                                                                                                                      |
| [内容目录](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#content-catalogs)                       | Addressables 使用目录将您的资产映射到包含它们的资源。                                                                                                                                                                                     |
| [依赖](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#dependency-and-resource-management)       | 资源依赖关系是另一个资源使用的一种资源，例如场景资源中使用的预制件或预制件资源中使用的材质。                                                                                                                                                                        |
| [依赖项和资源管理](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#dependency-and-resource-management) | Addressables 系统使用引用计数来跟踪正在使用的资源和 AssetBundle，包括系统是加载还是卸载依赖项（其他引用的资源）。                                                                                                                                                 |
| [群](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#addressables-groups-and-labels)            | 您可以在 Editor 中将资源分配给组。组设置配置 Addressables 如何将组资源打包到 AssetBundle 中，以及如何在运行时加载它们。                                                                                                                                         |
| **键**                                                                                                                                             | 标识一个或多个 Addressables 的对象。键包括地址、标签、AssetReference 实例和位置对象。                                                                                                                                                             |
| [标签](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#addressables-groups-and-labels)           | 一个标签，您可以将其分配给多个资产，并用于将相关资产作为一个组一起加载。您可以使用标签作为键来加载资产。                                                                                                                                                                  |
| **多平台支持**                                                                                                                                         | 构建系统按平台分隔构建的内容，并在运行时解析正确的路径。                                                                                                                                                                                          |

默认情况下，Addressables 使用 AssetBundle 打包您的资源。您还可以实现自己的 [`IResourceProvider`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.ResourceManagement.ResourceProviders.IResourceProvider.html) 类，以支持其他访问资产的方式。

## [资产地址](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#asset-addresses)

Addressables 系统的一个关键功能是您可以为资源分配地址，并在运行时使用这些地址加载它们。Addressables 资源管理器在内容目录中查找地址，以找出资产的存储位置。资产可以内置到您的应用程序中、在本地缓存或远程托管。资源管理器加载资源和任何依赖项，如有必要，先下载内容。

![](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/images/addressables-overview-addresses.png)  
_Addressables 按地址加载资产，无论资产位于何处_

由于地址与资源的物理位置无关，因此您有多种选择可以在 Unity Editor 中和运行时管理和优化资源。[目录](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#content-catalogs) 将地址映射到物理位置。

尽管最佳做法是为资产分配唯一地址，但资产地址不必是唯一的。您可以在有用时将相同的地址字符串分配给多个资产。例如，如果您有资产的变体，则可以为所有变体分配相同的地址，并使用标签来区分变体：

- 资产 1：address：`"plate_armor_rusty"`，label：`"hd"`
- 资产 2：address：`"plate_armor_rusty"`，label：`"sd"`

仅使用分配给多个资产的地址调用这些 `Addressables`API 方法（例如 [`LoadAssetAsync`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.LoadAssetAsync.html)）会加载找到的第一个实例。其他方法（如 [`LoadAssetsAsync`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.LoadAssetsAsync.html)）在一个操作中加载多个资产，并使用指定地址加载所有资产。

##### 提示
您可以使用 `LoadAssetsAsync` 的[`MergeMode`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.MergeMode.html) 参数来加载两个键的交集。

在前面的示例中，您可以将地址`"plate_armor_rusty"` 和 标签`"hd"` 指定为键，并将交集指定为合并模式以加载资产 1。然后，您可以将 label 值更改为`"sd"` 以加载资产 2.

有关如何为资产分配地址的更多信息，请参阅 [使资产可寻址](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsGettingStarted.html).有关如何按键（包括地址）加载资产的信息，请参阅 [加载资产](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/LoadingAddressableAssets.html).

## [资产引用](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#assetreference)

[`AssetReference`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.AssetReference.html) 是一种类型，您可以将其设置为任何类型的 Addressable asset （可寻址资产）。Unity 不会自动加载分配给引用的资源，因此您可以更好地控制何时加载和卸载它。

在MonoBehaviour或ScriptableObject中使用AssetReference类型的字段来指定该字段使用哪个可寻址资产（而不是使用指定地址的字符串）。AssetReference支持拖放和对象选择器分配，这使得它们在编辑器检查器中使用起来更加方便。

Addressables还提供了一些更专门的类型，如AssetReferenceNameObject和AssetReference Texture。您可以使用这些专门的子类来防止将错误的资产类型分配给AssetReference字段。您还可以使用AssetReferenceUILabelRestriction属性来限制对具有特定标签的资产的分配。

请参阅 [使用资源引用](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AssetReferences.html) 以了解更多信息。

## [资产加载和卸载](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#asset-loading-and-unloading)

要加载可寻址资产，您可以使用其地址或其他键，如标签或AssetReference。有关更多信息，请参阅[加载可寻址资产](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/LoadingAddressableAssets.html)。您只需要加载主资产，Addressables会自动加载任何依赖资产。

当您的应用程序在运行时不再需要访问 Addressable 资产时，您必须释放它，以便 Addressables 可以释放关联的内存。Addressables 系统保留已加载资源的引用计数，并且在引用计数返回零之前不会卸载资产。因此，您无需跟踪资产或其依赖项是否仍在使用中。您只需确保每当显式加载资产时，当您的应用程序不再需要该实例时，您都可以释放它。请参阅 [释放可寻址资产](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/UnloadingAddressableAssets.html) 以了解更多信息。

## [依赖项和资源管理](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#dependency-and-resource-management)

Unity 中的一种资源可以依赖于另一种资源。场景可能引用一个或多个预制件，或者预制件可能使用一个或多个材质。一个或多个预制件可以使用相同的材质，并且这些预制件可以存在于不同的 AssetBundle 中。加载 Addressable 资产时，系统会自动查找并加载它引用的任何依赖资产。当系统卸载资产时，它还会卸载其依赖项，除非其他资产仍在使用它们。

在加载和发布资源时，Addressables 系统会保留每个项目的引用计数。当不再引用资产时，Addressables 会卸载它。如果资源所在的 bundle 中不再有任何正在使用的资源，Addressables 也会卸载该 bundle。

请参阅 [内存管理](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/MemoryManagement.html) 以了解更多信息。

## [Addressables 组和标签](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#addressables-groups-and-labels)

使用 Addressables 组来组织您的内容。所有 Addressable 资产都属于一个组。如果您没有将资产显式分配给组，Addressables 会将其添加到默认组。

您可以设置组设置，以指定 Addressables 构建系统如何将组中的资产打包到捆绑包中。例如，您可以选择是否将一个组中的所有资源一起打包到一个 AssetBundle 文件中。

使用标签标记要以某种方式一起处理的内容。例如，如果您为`red` 、`hat` 、 `feather`和 定义了标签，则可以在一次操作中为所有红色帽子加载羽毛，无论它们是否属于同一 AssetBundle。您还可以使用标签来决定如何将组中的资产打包到捆绑包中。

使用 [Addressables Groups](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/GroupsWindow.html) 窗口将资产添加到组并在组之间移动资产。您还可以在 Groups （组） 窗口中为资产分配标签。

### [组架构](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#group-schemas)

分配给组的架构定义用于在组中构建资产的设置。不同的架构可以定义不同的设置组。例如，一个标准架构定义了如何将资源打包和压缩到 AssetBundle 中的设置（以及其他选项）。另一个标准架构定义组中的资产属于哪些类别 **Can Change Post Release** 和 **Cannot Change Post Release** 。

您可以定义自己的架构以用于自定义构建脚本。

请参阅 [架构](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/GroupSchemas.html) 以了解有关组架构的更多信息。

## [内容目录
](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#content-catalogs)
Addressables 系统会生成一个内容目录文件，该文件将资产的地址映射到其物理位置。它还可以创建包含目录哈希的哈希文件。如果您远程托管 Addressable 资源，则系统会使用此哈希文件来确定内容目录是否已更改并需要下载它。有关更多信息[，请参阅 内容目录](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/BuildArtifacts.html) 。

的 Profile 在执行内容构建时选择，用于确定内容目录中的地址如何映射到资源加载路径。请参阅 [配置文件](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsProfiles.html) 以了解更多信息。

有关远程托管内容的信息，请参阅[远程分发内容](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/RemoteContentDistribution.html)。

## [内容构建](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#content-builds)

Addressables 系统将 Addressable 内容的构建与播放器的构建分开。内容生成版本会生成内容目录、目录哈希和包含您的资源的 AssetBundle。

由于资产格式是特定于平台的，因此在构建播放器之前，您必须为每个平台构建内容。

请参阅 [构建可寻址内容](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/Builds.html) 以了解更多信息。

## [播放模式脚本](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#play-mode-scripts)

当您在 Play （播放） 模式下运行游戏或应用程序时，始终在按下 Play （播放） 按钮之前执行内容构建可能会很不方便且速度很慢。同时，您希望能够在尽可能接近构建玩家的状态下运行游戏。Addressables 提供了三个选项，用于决定 Addressables 系统在 Play 模式下如何定位和加载资源：
- **使用 Asset Database**：Addressables 直接从 Asset Database 加载资源。如果您同时进行代码和资产更改，此选项通常提供最快的迭代速度，但也最不类似于生产版本。
- **Use existing build**：Addressables 加载您上次内容构建中的内容。此选项最类似于生产版本，如果您不更改资源，则可以提供快速的迭代周转时间。

请参阅 [播放模式脚本](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/GroupsWindow.html) 以了解更多信息。

## Addressables 工具[](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsOverview.html#addressables-tools)

Addressables 系统提供了以下工具和窗口来帮助您管理 Addressable 资产：
- [Addressable Groups 窗口](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/GroupsWindow.html)：用于管理资源、组设置和进行构建的主界面。
- [Profiles （配置文件） 窗口](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsProfiles.html)：帮助设置构建使用的路径。
- [生成布局报告](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/BuildLayoutReport.html)：描述内容生成生成的 AssetBundle。
- [分析工具](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/editor/tools/AnalyzeTool.html)：分析工具运行分析规则，检查您的 Addressables 内容是否符合您定义的规则集。Addressables 系统提供了一些基本规则，例如检查重复的资产;您可以使用 [AnalyzeRule] 类添加自己的规则。