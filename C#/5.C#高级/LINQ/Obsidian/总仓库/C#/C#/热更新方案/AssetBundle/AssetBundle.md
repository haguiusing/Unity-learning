[[AssetBundle理论基础]]
[[生成AB包资源文件]]
[[使用AB包资源文件]]
[[AB包依赖]]


[Unity Asset Bundle 浏览器工具 |Package Manager UI 网站 --- Unity Asset Bundle Browser tool | Package Manager UI website](https://docs.unity.cn/Packages/com.unity.assetbundlebrowser@1.7/manual/index.html)

# Unity Asset Bundle 浏览器工具
此工具使用户能够查看和编辑其 Unity 项目的 asset bundle 的配置。它将阻止会创建无效 bundle 的编辑，并通知您现有 bundle 的任何问题。它还提供基本的构建功能。

使用此工具作为在 Inspector 中手动选择资产并设置其 Asset Bundle 的替代方法。它可以放入任何 5.6 或更高版本的 Unity 项目中。它将在 **Window** > **AssetBundle Browser** 中创建一个新菜单项。bundle configuration（包配置）、build functionality（构建功能）和 build-bundle inspection （构建包检查）在新窗口中分为三个选项卡。
![BrowserHeader](https://docs.unity.cn/Packages/com.unity.assetbundlebrowser@1.7/manual/images/browser_header.png)
<font color="#ffff00">需要 Unity 5.6+</font>

# Usage - Configure  用法 - 配置
此窗口提供了一个类似资源管理器的界面，用于管理和修改项目中的 Asset Bundle。首次打开时，该工具将在后台解析所有捆绑包数据，缓慢标记检测到的警告或错误。它尽其所能与项目保持同步，但不能始终了解工具外部的活动。要强制快速通过错误检测，或使用外部所做的更改更新工具，请点击左上角的 Refresh 按钮。

该窗口分为四个部分：Bundle List、Bundle Details、Asset List 和 Asset Details。![BroserConfigure](https://docs.unity.cn/Packages/com.unity.assetbundlebrowser@1.7/manual/images/browser_configure2.png)

### Bundle List  捆绑商品列表
左侧窗格显示项目中所有捆绑包的列表。可用功能：
- 选择一个捆绑包或一组捆绑包，以查看将在 Asset List （资产列表） 窗格中的捆绑包中的资产列表。
- 带有变体的捆绑商品为深灰色，可以展开以显示变体列表。
- 右键单击或慢速双击可重命名捆绑包或捆绑包文件夹。
- 如果捆绑包有任何错误、警告或信息消息，右侧将显示一个图标。将鼠标悬停在图标上可了解更多信息。
- 如果捆绑包中至少包含一个场景（使其成为场景捆绑包）并且明确包含非场景资源，则会将其标记为有错误。此捆绑包在修复之前不会构建。
- 包含重复资源的捆绑包将标有警告（有关重复的更多信息，请参阅下面的 Asset List 部分）
- 空捆绑包将标有一条信息消息。由于多种原因，空捆绑包不是很稳定，有时会从此列表中消失。
- 捆绑包的文件夹将标有所包含捆绑包中最高的消息。
-  Bundle 中重复包含的资源问题，您可以：
    - 右键单击单个 bundle 可将所有确定为重复项的资源移动到新 bundle 中。
    - 右键单击多个捆绑包，将资产从所有选定的重复资产包移动到新资产包中，或者仅将选定资产库中共享的资产移动到新资产包中。
    - 您还可以将重复的资源从 Asset List （资源列表） 窗格拖到 Bundle List （捆绑包列表） 中，以将它们显式包含在捆绑包中。有关更多信息，请参阅下面的 Asset List 功能集。
- 右键单击或按 DEL 以删除捆绑包。
- 拖动捆绑包以将它们移入和移出文件夹，或合并它们。
- 将资源从 Project Explorer 拖到 bundels 上以添加它们。
- 将资源拖到空白区域以创建新的捆绑包。
- 右键单击以创建新的捆绑包或捆绑包文件夹。
- 右键单击 “Convert to Variant”
    - 这会将变体（最初称为 “newvariant”）添加到所选捆绑包中。
    - 当前所选捆绑包中的所有资产都将移动到新变体中
    - ComingSoon：变体之间的不匹配检测。


图标指示捆绑包是标准捆绑包还是场景捆绑包。
![Icon for standard bundle](https://docs.unity.cn/Packages/com.unity.assetbundlebrowser@1.7/manual/images/ABundleBrowserIconY1756Basic.png)
![Icon for scene bundle](https://docs.unity.cn/Packages/com.unity.assetbundlebrowser@1.7/manual/images/ABundleBrowserIconY1756Scene.png)

### Bundle Details  捆绑包详细信息
左下窗格显示在 Bundle List 窗格中选择的捆绑包的详细信息。此窗格将显示以下信息（如果可用）：
- 总捆绑包大小。这是所有资产的磁盘大小之和。
- 当前 bundle 所依赖的 bundle
- 与当前捆绑包关联的任何消息 （error/warning/info）。

### Asset List  资产列表
右上方的窗格，提供在 Bundle List 中选择的任何捆绑包中包含的资源列表。此列表上方的搜索字段将与任何 bundle 中的资产匹配。Asset List （资源列表） 将仅显示匹配的资源，而 Bundle List （捆绑包列表） 将仅显示包含匹配资源的捆绑包。可用功能：
- 查看预期包含在捆绑包中的所有资产。按任何列标题对资产列表进行排序。
- 查看 bundle 中明确包含的资源。这些是已显式分配捆绑包的资源。Inspector 将反映 bundle 包含，在此视图中，他们将在资源名称旁边显示 bundle name。
- 查看隐式包含在 bundle 中的资产。这些资源将在资源名称旁边显示 _auto_ 作为捆绑包的名称。如果在 Inspector 中查看这些资源，它们将说 _None_ 作为分配的捆绑包。
    - 由于依赖于另一个包含的资源，这些资源已添加到选定的捆绑包中。只有未明确分配给 bundle 的资产才会隐式包含在任何 bundle 中。
    - 请注意，此隐式 include 列表可能不完整。存在材质和纹理并不总是正确显示的已知问题。
    - 由于多个资源可以共享依赖项，因此给定资源隐式包含在多个捆绑包中是很常见的。如果该工具检测到这种情况，它将使用警告图标标记捆绑包和有问题的资产。
    - 要修复重复包含警告，您可以手动将资源移动到新的捆绑包中，或右键单击该捆绑包并选择“移动重复项”选项之一。
- 将资源从 Project Explorer 拖动到此视图中，以将其添加到选定的捆绑包中。仅当仅选择一个捆绑包，并且资源类型兼容（场景到场景捆绑包等）时，此选项才有效。
- 将资源（显式或隐式）从 Asset List 拖到 Bundle List 中（以将它们添加到不同的 Bundle 或新创建的 Bundle）。
- 右键单击或按 DEL 可从捆绑包中删除资源（不会从项目中删除资源）。
- 选择或双击资源以在 Project Explorer 中显示它们。

有关在捆绑包中包含文件夹的说明。可以将资源文件夹（从 Project Explorer 中）分配给捆绑包。在浏览器中查看此内容时，文件夹本身将列为 expilation，而 contents 将列为 implicit。这反映了用于将资源分配给 bundle 的优先级系统。例如，假设您的游戏在 Assets/Prefabs 中有 5 个预制件，并且您将文件夹“Prefabs”标记为位于一个捆绑包中，并将其中一个实际预制件（“PrefabA”）标记为位于另一个捆绑包中。构建完成后，“PrefabA” 将位于一个捆绑包中，其他四个 prefab 将位于另一个捆绑包中。

### Asset Details  资产详细信息
右下角的窗格显示在 Asset List 窗格中所选资产的详细信息。此窗格无法与之交互，但将显示以下信息（如果可用）：
- 资产的完整路径
- 隐式包含在 bundle 中的原因（如果它是隐式的）。
- 警告原因（如果有）。
- 错误原因（如果有）。

### Troubleshooting  故障 排除
- _无法重命名或删除特定捆绑包。_ 首次将此工具添加到现有项目时，偶尔会出现此问题。请通过 Unity 菜单系统强制重新导入您的资源以刷新数据。

### External Tool Integration  外部工具集成
生成 Asset Bundle 数据的其他工具可以选择与浏览器集成。目前的主要示例是 [Asset Bundle Graph Tool](https://bitbucket.org/Unity-Technologies/assetbundlegraphtool)。如果检测到集成，则浏览器顶部附近将出现一个选择栏。它将允许您选择 Default 数据源 （Unity 的 AssetDatabase） 或集成工具。如果未检测到任何选择器，则选择器不存在，但您可以通过右键单击选项卡标题并选择“自定义源”来添加它。

# Usage - Build  用法 - 构建
Build （构建） 选项卡提供基本的构建功能，帮助您开始使用资源包。在大多数专业场景中，用户最终需要更高级的构建设置。欢迎所有人使用此工具中的构建代码作为编写自己的代码的起点，一旦这不再满足他们的需求。在大多数情况下，此处的选项与引擎在 [BuildAssetBundleOptions](https://docs.unity.cn/ScriptReference/BuildAssetBundleOptions.html) 中期望的选项直接相关。接口：
- _Build Target_ - 将为其构建捆绑包的平台
- _Output Path （输出路径）_ - 用于保存构建的捆绑包的路径。默认情况下，此值为 AssetBundles/。您可以手动编辑路径，也可以通过选择“浏览”来编辑路径。要返回默认命名约定，请点击 “Reset”。
- _Clear Folders_ - 这将在构建之前删除构建路径文件夹中的所有数据。
- _复制到 StreamingAssets_ - 构建完成后，这会将结果复制到 Assets/StreamingAssets。这对于测试很有用，但不会在生产中使用。
- _Advanced Settings  高级设置_
    - _压缩_ - 在无压缩、标准 LZMA 或基于数据块的 LZ4 压缩之间进行选择。
    - _Exclude Type Information （排除类型信息_ ） - 不在资源包中包含类型信息
    - _Force Rebuild_ - 需要构建的 Rebuild 捆绑包。这与 “Clear Folders” 不同，因为此选项不会删除不再存在的捆绑包。
    - 忽略类型树更改_ - 在执行增量构建检查时忽略类型树更改。
    - _Append Hash （附加哈希_ ） - 将哈希附加到资产包名称。
    - 严格模式_ - 如果在此期间报告任何错误，则不允许构建成功。
    - _试运行构建_ - 执行试运行构建。
- _Build （构建_ ） - 执行 build。

# Usage - Inspect  用法 - 检查
通过此选项卡，您可以检查已构建的捆绑包的内容。
### Usage  用法
- 如果您使用浏览器进行构建，则您构建的路径将自动添加到此处。
- 单击“Add File（添加文件）”或“Add Folder（添加文件夹）”以添加要检查的捆绑包。
- 单击每行旁边的 “-” 可删除该文件或文件夹。请注意，您无法删除通过添加文件夹添加的单个文件。
- 选择列出的任何捆绑包以查看详细信息：
    - Name  名字
    - Size on disk  磁盘大小
    - Source Asset Paths - 显式添加到此捆绑包的资源。请注意，此列表对于场景包不完整。
    - 高级数据 - 包括有关预加载表、容器（显式资产）和依赖项的信息。