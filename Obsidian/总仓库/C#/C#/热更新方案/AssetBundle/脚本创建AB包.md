[BuildPipeline - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildPipeline.html)
[Unity新版AssetBundle打包API以及使用策略 - 简书](https://www.jianshu.com/p/565d02b180ff)


1. 必须在编辑器脚本中使用@MenuItem特性声明编辑器菜单项函数以用来实现相应的菜单功能。
2. 编辑器脚本必须放在名为Editor的文件夹下。
3. 在编辑器的菜单回调函数中实现菜单点击功能（不能是游戏运行时的功能）。
![](https://i-blog.csdnimg.cn/blog_migrate/82d2167681082d86843241c0e243e539.png)

# [BuildPipeline](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.html).BuildAssetBundle
[BuildPipeline-BuildAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.BuildAssetBundle.html)
构建一个资源包。
创建一个包含 `assets` 集合的 unity3d 压缩文件。AssetBundles 可包含在项目文件夹中找到的所有资源。这允许您流式传输任何类型的资源数据，并完整设置预制件、纹理、网格、动画以及项目窗口中显示的任何类型的资源。\ 所有路径均是相对于项目文件夹的路径。如：“Assets/MyTextures/hello.png”。\  
  
请注意，针对独立平台目标构建的资源包不能由 针对移动平台构建的应用程序加载，反之亦然。此外，捆绑包 在 iOS 和 Android 平台之间不兼容。  
  
如果构建成功，该函数将返回布尔值 true，否则返回 f
alse。  
BuildAssetBundle 已弃用。请使用 5.0 中引入的新 AssetBundle 构建系统，并查看 BuildAssetBundles 文档，了解详细信息。

# [BuildPipeline](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.html).BuildAssetBundleExplicitAssetNames
[BuildPipeline-BuildAssetBundleExplicitAssetNames - Unity 脚本 API](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.BuildAssetBundleExplicitAssetNames.html)
使用资源的自定义名称构建资源包。
如果构建成功，该函数将返回布尔值 true，否则返回 false。\ 注意：指定字符串将会增加资源包的大小。构建日志中显示的内置 AssetBundle 数据是指字符串大小。

# [BuildPipeline](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.html).BuildAssetBundles
[BuildPipeline-BuildAssetBundles - Unity 脚本 API](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.BuildAssetBundles.html)
构建编辑器中指定的所有 AssetBundle。

# [BuildPipeline](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.html).GetCRCForAssetBundle
[BuildPipeline-GetCRCForAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.GetCRCForAssetBundle.html)
提取给定 AssetBundle 的 CRC 校验和。

# [BuildPipeline](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.html).GetHashForAssetBundle
[BuildPipeline-GetHashForAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2021.3/ScriptReference/BuildPipeline.GetHashForAssetBundle.html
提取给定 AssetBundle 的哈希值。


# **参数详解**

## string outputPath
AssetBundle 的输出路径（**Assets路径**）。

## AssetBundleBuild[] builds
**Bundle生成信息**
![[16674860-62ca613ef2d23572.webp]]
assetBundleName：Bundle包名字
assetBundleVariant：Bundle包后缀/变体
assetNames：该bundle包内所包含的资源路径（Asset路径）
addressableNames：这个变量类似于assetNames数组的重写，该数组的长度必须保证与assetsNames的长度一样，打包时会先寻找该数组内索引的路径资源，如果该索引没有设置，就按照assetNames内索引的资源路径添加资源

## BuildAssetBundleOptions assetBundleOptions
资源包构建选项。
此属性允许您选择用于构建资源包的选项。 要按照额外说明构建资源包，请使用此属性作为 [BuildPipeline.BuildAssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildPipeline.BuildAssetBundle.html) 或 [BuildPipeline.BuildAssetBundles](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildPipeline.BuildAssetBundles.html) 的参数。

| [None](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.None.html)                                                                       | 不使用任何特殊选项构建 assetBundle。         |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------- |
| [UncompressedAssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.UncompressedAssetBundle.html)                                 | 创建资源包时不压缩数据。                     |
| [DisableWriteTypeTree](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.DisableWriteTypeTree.html)                                       | 不包括 AssetBundle 中的类型信息。          |
| [DeterministicAssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.DeterministicAssetBundle.html)                               | 使用存储在资源包中对象的 ID 的哈希构建资源包。        |
| [ForceRebuildAssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.ForceRebuildAssetBundle.html)                                 | 强制重新构建 assetBundle。              |
| [IgnoreTypeTreeChanges](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.IgnoreTypeTreeChanges.html)                                     | 在执行增量构建检查时忽略类型树更改。               |
| [AppendHashToAssetBundleName](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.AppendHashToAssetBundleName.html)                         | 向 assetBundle 名称附加哈希。            |
| [ChunkBasedCompression](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.ChunkBasedCompression.html)                                     | 创建 AssetBundle 时使用基于语块的 LZ4 压缩。  |
| [StrictMode](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.StrictMode.html)                                                           | 如果在此期间报告任何错误，则构建无法成功。            |
| [DryRunBuild](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.DryRunBuild.html)                                                         | 进行干运行构建。                         |
| [DisableLoadAssetByFileName](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.DisableLoadAssetByFileName.html)                           | 禁用按照文件名称查找资源包 LoadAsset。         |
| [DisableLoadAssetByFileNameWithExtension](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension.html) | 禁用按照带扩展名的文件名称查找资源包 LoadAsset。    |
| [AssetBundleStripUnityVersion](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildAssetBundleOptions.AssetBundleStripUnityVersion.html)                       | 在构建过程中删除存档文件和序列化文件头中的 Unity 版本号。 |

## BuildTarget targetPlatform
目标构建平台。

| [StandaloneOSX](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.StandaloneOSX.html)             | 构建一个 macOS 独立平台（Intel 64 位）。 |
| ----------------------------------------------------------------------------------------------------------- | ---------------------------- |
| [StandaloneWindows](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.StandaloneWindows.html)     | 构建一个 Windows 独立平台。           |
| [iOS](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.iOS.html)                                 | 构建一个 iOS 播放器。                |
| [Android](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.Android.html)                         | 构建 Android .apk 独立平台应用程序。    |
| [StandaloneWindows64](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.StandaloneWindows64.html) | 构建一个 Windows 64 位独立平台。       |
| [WebGL](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.WebGL.html)                             | WebGL。                       |
| [WSAPlayer](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.WSAPlayer.html)                     | 构建一个 Windows 应用商店应用程序播放器。    |
| [StandaloneLinux64](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.StandaloneLinux64.html)     | 构建一个 Linux 64 位独立平台。         |
| [PS4](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.PS4.html)                                 | 构建一个 PS4 独立平台。               |
| [XboxOne](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.XboxOne.html)                         | 构建一个 Xbox One 独立平台。          |
| [tvOS](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.tvOS.html)                               | 构建到 Apple 的 tvOS 平台。         |
| [Switch](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.Switch.html)                           | 构建一个 Nintendo Switch 播放器。    |
| [Stadia](https://docs.unity.cn/cn/2019.4/ScriptReference/BuildTarget.Stadia.html)                           | 构建一个 Stadia 独立平台。            |

# 返回AssetBundleManifest
构建中所有 AssetBundle 的清单/主包。
# **参考实例**
**Unity内选取一个文件夹，将该文件夹内所有文件打成一个bundle**
![[16674860-f29b3c85dc346201.webp]]
EditorBundlePackageMenu：拓展编辑器

![](https://upload-images.jianshu.io/upload_images/16674860-5cdbd7afb9db3525.png?imageMogr2/auto-orient/strip|imageView2/2/w/1068/format/webp)
BundlePackagePath：主要包含打包相关路径

![](https://upload-images.jianshu.io/upload_images/16674860-0cdc3e3da92c71e9.png?imageMogr2/auto-orient/strip|imageView2/2/w/1092/format/webp)
BundlePackageManager第一页

![](https://upload-images.jianshu.io/upload_images/16674860-5f5806a191cebd3f.png?imageMogr2/auto-orient/strip|imageView2/2/w/1200/format/webp)
BundlePackageManager第二页
---

# **5.实现效果**
![](https://upload-images.jianshu.io/upload_images/16674860-eacec0903d54863e.png?imageMogr2/auto-orient/strip|imageView2/2/w/602/format/webp)
选取文件夹-右键-BuildAssetBundle-Windows

![](https://upload-images.jianshu.io/upload_images/16674860-ee6a5c3ea6a2676a.png?imageMogr2/auto-orient/strip|imageView2/2/w/831/format/webp)
输出目录生成Bundle