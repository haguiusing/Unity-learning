您可以通过安装 Addressables 包将 Addressables 添加到现有 Unity 项目中。安装包后，您需要为资产分配地址并重构任何运行时加载代码。

尽管你可以在项目开发的任何阶段集成 Addressables，但最佳实践是立即开始在新项目中使用 Addressables，以避免在开发后期进行不必要的代码重构和内容规划更改。

## [转换为 Addressables](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-to-addressables)

使用 Addressables 构建的内容仅引用该 Addressables 构建中构建的其他资产。使用或引用的内容包含在两个 Addressables 中，并且通过 **Scene data** 和 **Resource 文件夹**构建的 Player 将在磁盘和内存中复制（如果它们都已加载）。由于此限制，您必须将所有 **Scene data** 和 **Resource 文件夹**转换为 Addressables 构建系统。这减少了由于重复而导致的内存开销，并且意味着您可以使用 Addressables 管理所有内容。这也意味着内容可以是本地的或远程的，您可以通过[内容更新](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/ContentUpdateWorkflow.html)版本来更新它。

要将项目转换为 Addressables，您需要根据当前项目引用和加载资源的方式执行不同的步骤：
- **预制件**：使用游戏对象和组件创建并保存在场景外部的资源。有关如何将预制件数据升级到 Addressables 的信息，请参阅[转换预制件](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-prefabs)。
- **AssetBundle**：将资产打包在AssetBundle中，并使用AssetBundle API加载。有关如何将AssetBundles升级为Addressables的信息，请参阅转换[转换 AssetBundle](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-assetbundles)
- **StreamingAssets**：放置在StreamingAsset文件夹中的文件。Unity按原样包含内置播放器应用程序中StreamingAssets文件夹中的任何文件。有关信息，请参阅[StreamingAssets 中的文件](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#files-in-streamingassets)

## [转化场景数据](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-scene-data)

要将场景数据转换为 Addressable，请将场景从 [Build Settings](https://docs.unity3d.com/6000.0/Documentation/Manual/BuildSettings.html) 列表中移出，并使这些场景可寻址。列表中必须有一个场景，即 Unity 在应用程序启动时加载的场景。你可以为此创建一个新场景，除了加载你的第一个 Addressable 场景之外，什么都不做。

要转换场景：
1. 创建新的初始化场景。
2. 打开 **Build Settings** 窗口（菜单：**File > Build Settings**）。
3. 将初始化场景添加到场景列表中。
4. 从列表中删除其他场景。
5. 在项目列表中选择每个场景，并在其 Inspector 窗口中启用 Addressable 选项。或者，您可以将场景资源拖动到 Addressables Groups （可寻址组） 窗口中的组中。不要将新的初始化场景设为 Addressable。
6. 更新用于加载场景的代码，以使用 [`Addressables`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.html) 类的场景加载方法，而不是方法。`SceneManager`

您现在可以将一个大型 Addressable Scene 组拆分为多个组。最好的方法取决于项目目标。要继续，您可以将场景移动到它们自己的组中，以便您可以彼此独立地加载和卸载每个场景。您可以通过使资源本身 Addressable 来避免复制从两个不同捆绑包引用的资源。通常，最好将共享资源也移动到它们自己的组中，以减少 AssetBundle 之间的依赖关系。

为避免复制从两个不同捆绑包引用的资源，请将资源设为 Addressable。通常，最好将共享资源移动到它们自己的组中，以减少 AssetBundle 之间的依赖关系数量。

### [](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#use-addressable-assets-in-non-addressable-scenes)在非 Addressable 场景中使用 Addressable 资产

对于您不想设为 Addressable 的任何场景，您仍然可以通过 [AssetReferences](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AssetReferences.html) 将 Addressable 资源用作场景数据的一部分。

将 AssetReference 字段添加到自定义 MonoBehaviour 或 ScriptableObject 类时，可以在 Unity Editor 中将 Addressable 资源分配给该字段，其方式与将资源分配为直接引用的方式类似。主要区别在于，您需要向类中添加代码，以加载和释放分配给 AssetReference 字段的资源（而 Unity 在场景中实例化对象时会自动加载直接引用）。

##### 注意

不能将 Addressable 资源用于非 Addressable 场景中任何 UnityEngine 组件的字段。例如，如果将可寻址网格资源分配给非可寻址场景中的 MeshFilter 组件，则 Unity 不会将该网格数据的可寻址版本用于场景。相反，Unity 会复制网格资源并在应用程序中包含两个版本的网格：一个版本位于为包含网格的 Addressable 组构建的 AssetBundle 中，另一个位于非 Addressable 场景的内置 Scene 数据中。在可寻址场景中使用时，Unity 不会复制网格数据，而是始终从 AssetBundle 加载数据。

要在自定义类中将直接引用替换为 AssetReferences，请执行以下步骤：

1. 将对对象的直接引用替换为资产引用（例如，变为 ）。`public GameObject directRefMember;``public AssetReference assetRefMember;`
2. 将资源拖动到相应组件的 Inspector 上，就像直接引用一样。
3. 添加运行时代码以使用 [`Addressables`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.html) API 加载分配的资产。
4. 添加代码以在不再需要时释放加载的资源。

有关使用 AssetReference 字段的更多信息，请参阅[资产引用](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AssetReferences.html)。

有关加载 Addressable 资源的更多信息，请参阅[加载 Addressable 资源](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/LoadingAddressableAssets.html)。

## [](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-prefabs)转换预制件

要将预制件转换为 Addressable 资源，请在其 Inspector 窗口中启用 **Addressables** 选项，或将其拖动到 [Addressables Groups](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/Groups.html) 窗口中的组中。

在 Addressable 场景中使用时，您并不总是需要将预制件设为 Addressable。Addressables 自动包含您添加到场景层次结构中的预制件，这些预制件作为场景的 AssetBundle 中包含的数据的一部分。如果您在多个场景中使用预设件，请将该预设件制作成 Addressable 资产，以便预制件数据不会在使用它的每个场景中重复。如果要在运行时动态加载和实例化预制件，还必须将其设为 Addressable。

##### 注意

如果在不可寻址场景中使用预制件，则无论预制件是否可寻址，Unity 都会将预制件数据复制到内置场景数据中。

## [](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-the-resources-folder)转换 Resources 文件夹

如果您的项目在 Resources 文件夹中加载资源，您可以将这些资源迁移到 Addressables 系统：

1. 使资产 Addressable。为此，请在每个资源的 Inspector 窗口中启用 **Addressable** 选项，或将资源拖到 [Addressables Groups](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/Groups.html) 窗口中的组中。
2. 更改任何使用 [`Resources`](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Resources.html) API 加载资产的运行时代码，以使用 [`Addressables`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.html) API 加载资产。
3. 添加代码以在不再需要时释放加载的资源。

与场景一样，如果将所有以前的 Resources 资产放在一个组中，则加载和内存性能应该是等效的。

当您将 Resources 文件夹中的资源标记为 Addressable 时，系统会自动将该资源移动到项目中名为 .移动资产的默认地址是旧路径，省略文件夹名称。例如，您的加载代码可能会从以下位置更改：`Resources_moved`

```c
Resources.LoadAsync\<GameObject\>("desert/tank.prefab");
```

自：

```c
Addressables.LoadAssetAsync\<GameObject\>("desert/tank.prefab");.
```

在修改项目以使用 Addressables 系统后，您可能必须以不同的方式实现类的某些功能。`Resources`

例如，请考虑 [`Resources.LoadAll`](https://docs.unity3d.com/ScriptReference/Resources.LoadAll.html) 方法。以前，如果您在名为 的文件夹中有资产，并运行 ，它将以匹配类型加载所有资产 。Addressables 系统不支持这种确切的功能，但你可以使用 [Addressable 标签](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/Labels.html)获得类似的结果。`Resources/MyPrefabs/``Resources.LoadAll\<SampleType\>("MyPrefabs");``Resources/MyPrefabs/``SampleType`

## [](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#convert-assetbundles)转换 AssetBundle

首次打开 **Addressables Groups** 窗口时，Unity 会提供将所有 AssetBundle 转换为 Addressables 组的功能。这是将 AssetBundle 设置迁移到 Addressables 系统的最简单方法。您仍然必须更新运行时代码，以使用 [`Addressables`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.html) API 加载和释放资产。

如果要手动转换 AssetBundle 设置，请单击 **Ignore** 按钮。手动将 AssetBundle 迁移到 Addressables 的过程类似于对场景和 Resources 文件夹描述的过程：

1. 通过在每个资源的 Inspector 窗口上启用 **Addressable** 选项，或将资源拖动到 [Addressables Groups （可寻址组](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/Groups.html)） 窗口中的某个组中，使资源可寻址。Addressables 系统忽略资源的现有 AssetBundle 和标签设置。
2. 更改使用 [`AssetBundle`](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/AssetBundle.html) 或 [`UnityWebRequestAssetBundle`](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Networking.UnityWebRequestAssetBundle.html) API 加载资源的任何运行时代码，以使用 [`Addressables`](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/api/UnityEngine.AddressableAssets.Addressables.html) API 加载资源。您无需显式加载 AssetBundle 对象本身或资源的依赖项;Addressables 系统会自动处理这些方面。
3. 添加代码以在不再需要时释放加载的资源。

##### 注意

资产地址的默认路径是其文件路径。如果使用路径作为资源的地址，则加载资源的方式与从捆绑包加载的方式相同。Addressable 资源系统处理捆绑包及其所有依赖项的加载。

如果您选择了自动转换选项或手动将资源添加到等效的 Addressables 组，则根据您的组设置，您最终会得到包含相同资源的同一组捆绑包。捆绑包文件本身不会相同。

## [](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/AddressableAssetsMigrationGuide.html#files-in-streamingassets)StreamingAssets 中的文件

当您使用 Addressables 系统时，您可以继续从该文件夹加载文件。但是，此文件夹中的文件不能是 Addressable （寻址） 文件，也不能引用项目中的其他资源。`StreamingAssets`

在构建过程中，Addressables 系统将其运行时配置文件和本地 AssetBundle 放在 StreamingAssets 文件夹中。Addressables 在构建过程结束时删除这些文件，您将不会在 Editor 中看到它们。