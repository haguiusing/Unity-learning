# Web 构建文件夹
构建 Web 应用程序时，Unity 会创建一个包含在 Web 浏览器中运行应用程序所需的所有文件的 `Build` 文件夹。

## 构建文件夹结构
`Build` 文件夹的名称在 **构建设置** 窗口中指定。该文件夹包含以下文件，其中 `[ExampleBuild]` 表示目标构建文件夹的名称。

|文件名|描述|
|---|---|
|`[ExampleBuild].loader.js`|网页加载 Unity 内容所需的 JavaScript 代码。|
|`[ExampleBuild].framework.js`|JavaScript 运行时和**插件**[](https://docs.unity3d.org.cn/Manual/plug-ins.html)  <br>[](https://docs.unity3d.org.cn/Manual/Glossary.html#Plug-in)。|
|`[ExampleBuild].wasm`|WebAssembly 二进制文件。|
|`[ExampleBuild].mem`|用于初始化播放器堆内存的二进制映像。仅当您进行多线程 WebAssembly 构建时，Unity 才会生成此文件。|
|`[ExampleBuild].data`|资源数据和**场景**[](https://docs.unity3d.org.cn/Manual/CreatingScenes.html)  <br>[](https://docs.unity3d.org.cn/Manual/Glossary.html#Scene)。|
|`[ExampleBuild].symbols.json`|调试符号名称，用于反混淆错误堆栈跟踪。仅当您启用调试符号选项（**文件** > **构建设置** > **播放器设置**）时，才会在发布版本中生成此文件。|
|`[ExampleBuild].jpg`|背景图像，在构建加载时显示。仅当播放器设置（**文件** > **构建设置** > **播放器设置** > **启动画面图像**）中提供背景图像时才会生成此文件。有关更多信息，请参阅 [启动画面](https://docs.unity3d.org.cn/Manual/class-PlayerSettingsSplashScreen.html)。|

### 文件扩展名
如果为构建启用 **压缩**方法，Unity 会识别与压缩方法相对应的扩展名，并将此扩展名添加到 Build 子文件夹中文件的名称中。如果启用 **解压缩回退**，Unity 会将扩展名 `.unityweb` 附加到构建文件名。否则，Unity 会为 Gzip 压缩方法附加扩展名 `.gz`，或为 Brotli 压缩方法附加扩展名 `.br`。

**压缩**方法，一种存储数据的方法，可减少其所需的存储空间。请参阅 [纹理压缩](https://docs.unity3d.org.cn/Manual/class-TextureImporterOverride)、[动画压缩](https://docs.unity3d.org.cn/Manual/class-AnimationClip.html#AssetProperties)、[音频压缩](https://docs.unity3d.org.cn/Manual/class-AudioClip.html)、[构建压缩](https://docs.unity3d.org.cn/Manual/ReducingFilesize.html)。  
参见 [词汇表](https://docs.unity3d.org.cn/Manual/Glossary.html#compression)

有关更多信息，请参阅 [压缩构建和服务器配置](https://docs.unity3d.org.cn/Manual/webgl-deploying.html)。

### 将文件命名为哈希值
如果在 **播放器设置** 中启用 **将文件命名为哈希值**，Unity 会使用文件内容的哈希值而不是默认文件名。这适用于构建文件夹中的每个文件。此选项允许您将更新的游戏构建版本上传到服务器上的同一文件夹中，并且仅上传构建迭代之间已更改的文件。

播放器设置，允许您为 Unity 构建的最终游戏设置各种特定于播放器的选项的设置。[更多信息](https://docs.unity3d.org.cn/Manual/class-PlayerSettings.html)  
参见 [词汇表](https://docs.unity3d.org.cn/Manual/Glossary.html#PlayerSettings)

**注意**：在某些浏览器中，可能无法直接从文件系统打开播放器。这是由于对本地文件 URL 应用的安全限制所致。

## 其他资源
- [Web Player 设置](https://docs.unity3d.org.cn/Manual/class-PlayerSettingsWebGL.html)
- [Web 构建设置](https://docs.unity3d.org.cn/Manual/web-build-settings.html)
- [构建和分发 Web 应用程序](https://docs.unity3d.org.cn/Manual/webgl-building-distribution.html)
- [部署 Web 应用程序](https://docs.unity3d.org.cn/Manual/webgl-deploying.html)
- [网页](https://docs.unity3d.org.cn/Manual/webgl.html)