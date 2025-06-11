# Build your WebGL application | 构建您的 WebGL 应用程序

To create a build for WebGL, go to **File > Build Settings** from Unity’s main menu. In the Platform list, select **WebGL** and then click **Switch Platform**.  
要为 WebGL 创建构建，请从 Unity 的主菜单转到 **File > Build Settings**。在 Platform （平台） 列表中，选择 **WebGL** ，然后单击 **Switch Platform （切换平台** ）。

For Build Settings, refer to [WebGL Build Settings](https://docs.unity3d.com/2022.3/Documentation/Manual/web-build-settings.html).  
有关 Build Settings，请参阅 [WebGL Build Settings](https://docs.unity3d.com/2022.3/Documentation/Manual/web-build-settings.html)。

When you have configured the Build Settings, choose from one the following options:  
配置 Build Settings 后，从以下选项之一中进行选择：
- **Build**: Builds your application into a Player.  
    **Build**：将应用程序构建到 Player 中。
- **Build and Run**: Builds your application in a Player, and opens that Player on your target platform.  
    **Build and Run**：在 Player 中构建应用程序，并在目标平台上打开该 Player。

![Build Settings Window](https://docs.unity3d.com/2022.3/Documentation/uploads/Main/WebGLBuilding-BuildPlayerOptions.png)
Build Settings Window  Build Settings 窗口

## Build folder structure | 构建文件夹结构
The `Build` folder has the following files, where `[ExampleBuild]` represents the name of the target build folder.  
`Build` 文件夹包含以下文件，其中 `[ExampleBuild]` 表示目标 Build 文件夹的名称。

|File name  文件名|Contains  包含|
|---|---|
|`[ExampleBuild].loader.js`|The JavaScript code that the web page needs to load the Unity content.  <br>网页加载 Unity 内容所需的 JavaScript 代码。|
|`[ExampleBuild].framework.js`|JavaScript runtime and plugins.  <br>JavaScript 运行时和插件。|
|`[ExampleBuild].wasm`|WebAssembly binary.  WebAssembly 二进制文件。|
|`[ExampleBuild].mem`|A binary image to initialize the heap memory for your Player. Unity generates this file for multi-threaded WebAssembly builds only.  <br>用于初始化 Player 的堆内存的二进制映像。Unity 仅为多线程 WebAssembly 构建生成此文件。|
|`[ExampleBuild].data`|Asset data and **Scenes**[](https://docs.unity3d.com/2022.3/Documentation/Manual/CreatingScenes.html)  <br>  <br>[](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#Scene).  <br>资产数据和 **Scenes** .|
|`[ExampleBuild].symbols.json`|Debug symbol names necessary to demangle an error stack trace. This file is only generated for Release builds when you enable the Debug Symbols option (**File** > **Build Settings** > **Player Settings**.)  <br>解缠错误堆栈跟踪所需的调试符号名称。仅当启用“调试符号”选项（ **文件** > **生成设置** > **播放器设置** ）时，才会为发布版本生成此文件。|
|`[ExampleBuild].jpg`|A background image, which displays while the build is loading. This file is only generated when a Background Image is available in the Player Settings (**File** > **Build Settings** > **Player Settings** > **Splash Image**). For more information, see [Splash Screen](https://docs.unity3d.com/2022.3/Documentation/Manual/class-PlayerSettingsSplashScreen.html).  <br>背景图像，在加载生成时显示。仅当播放器设置（ **文件** > **生成设置** > **播放器设置** > **启动画面** ）中有背景图像可用时，才会生成此文件。有关更多信息，请参阅[初始屏幕](https://docs.unity3d.com/2022.3/Documentation/Manual/class-PlayerSettingsSplashScreen.html) 。|

If you enable a ****Compression**[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-TextureImporterOverride.html)[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-AnimationClip.html#AssetProperties)[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-AudioClip.html)[](https://docs.unity3d.com/2022.3/Documentation/Manual/ReducingFilesize.html) [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#compression) Method** for your build, Unity identifies the extension that corresponds with the compression method and adds this extension to the names of the files inside the Build sub folder. If you enable **Decompression Fallback**, Unity appends the extension `.unityweb` to the build file names. Otherwise, Unity appends the extension `.gz` for the Gzip compression method, or `.br` for the Brotli compression method. For more information, refer to [Compressed builds and server configuration](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-deploying.html).  
如果为生成启用 ****Compression** Method，Unity** 会识别与压缩方法对应的扩展名，并将此扩展名添加到 Build 子文件夹中的文件名称中。如果启用**解压缩回退** ，Unity 会将扩展名 `.unityweb` 附加到构建文件名中。否则，Unity 会为 Gzip 压缩方法附加扩展`名 .gz`，或者为 Brotli 压缩方法附加 `.br`。有关更多信息，请参阅 [压缩版本和服务器配置](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-deploying.html) 。

If you enable **Name Files As Hashes** in the ****Player Settings**[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-PlayerSettings.html) [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#PlayerSettings)**, Unity uses the hash of the file content instead of the default file name. This applies to each file in the build folder. This option allows you to upload updated versions of the game builds into the same folder on the server, and only upload the files which have changed between build iterations.  
如果在 中启用 **Name Files As Hashes** ****Player Settings**** ，则 Unity 将使用文件内容的哈希值，而不是默认文件名。这适用于 build 文件夹中的每个文件。此选项允许您将游戏构建的更新版本上传到服务器上的同一文件夹中，并且仅上传在构建版本迭代之间发生更改的文件。

**Note**: Opening a Player directly from the file system might not work in some browsers. This is due to security restrictions applied to local file URLs.  
**注意** ：在某些浏览器中，直接从文件系统打开 Player 可能不起作用。这是由于对本地文件 URL 应用的安全限制。

## Enable exceptions  启用例外
Use **Enable Exceptions** to specify how unexpected code behavior (also known as errors) is handled at runtime. To access **Enable Exceptions**, go to the **Publishing Settings** section in **WebGL**[](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-gettingstarted.html) [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#WebGL) Player Settings.  
使用 **Enable Exceptions** 指定在运行时如何处理意外的代码行为 （也称为错误）。要访问 **Enable Exceptions**，请转到 Player Settings 中的 **WebGL** **Publishing Settings** 部分。

It has the following options:  
它具有以下选项：
- **None**: Select this if you don’t need any exception support. This gives the best performance and smallest builds. With this option, any exception thrown causes your content to stop with an error in that setting.  
    **None**：如果您不需要任何异常支持，请选择此选项。这提供了最佳性能和最小的构建。使用此选项时，引发的任何异常都会导致您的内容停止，并在该设置中出现错误。
- **Explicitly Thrown Exceptions Only** (default): Select this to capture exceptions which are explicitly specified from a `throw` statement in your **scripts**[](https://docs.unity3d.com/2022.3/Documentation/Manual/CreatingAndUsingScripts.html) [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#Scripts) and to also ensure `finally` blocks are called. Note that selecting this option makes the generated JavaScript code from your scripts longer and slower; This might only be an issue if scripts are the main bottleneck in your project.  
    **Explicit Thrown Exceptions Only** （默认）：选择此选项可捕获从 `throw` 语句中显式指定的异常， **scripts** 并确保调用 `finally` 块。请注意，选择此选项会使从脚本生成的 JavaScript 代码更长、更慢;只有当脚本是项目中的主要瓶颈时，这可能才是一个问题。
- **Full Without Stacktrace**: Select this option to capture: * Exceptions which are explicitly specified from `throw` statements in your scripts (the same as in the _Explicitly Thrown Exceptions Only_ option)  
    **Full Without Stacktrace**：选择此选项可捕获： * 从脚本中的 `throw` 语句显式指定的异常（与 _Explicit Thrown Exceptions Only_ 选项中相同）
    - Null References | Null 引用
    - Out of Bounds Array accesses | 越界数组访问
- **Full With Stacktrace**: This option is similar to the option above but it also captures Stack traces. Unity generates these exceptions by embedding checks for them in the code, so this option decreases performance and increases browser memory usage. Only use this for debugging, and always test in a 64-bit browser.  
    **Full With Stacktrace**：此选项与上述选项类似，但它也会捕获堆栈跟踪。Unity 通过在代码中嵌入对这些异常的检查来生成这些异常，因此此选项会降低性能并增加浏览器内存使用量。仅将其用于调试，并始终在 64 位浏览器中进行测试。

## Additional resources  其他资源
- [Web Build Settings  Web 构建设置](https://docs.unity3d.com/2022.3/Documentation/Manual/web-build-settings.html)
- [Build and distribute a Web application  
    [构建和分发 Web 应用程序](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-building-distribution.html)
- [Deploy a Web application  
    [部署 Web 应用程序](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-deploying.html)