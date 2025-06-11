# Web browser compatibility | Web 浏览器兼容性

This page gives an overview of Unity’s Web platform support for desktop and mobile browsers.  
本页概述了 Unity 对桌面和移动浏览器的 Web 平台支持。

## Web browser compatibility for desktop | 桌面的 Web 浏览器兼容性
Unity’s Web platform support for desktop browsers differs depending on the browser. It supports browsers providing the following conditions are true:  
Unity 的 Web 平台对桌面浏览器的支持因浏览器而异。它支持满足以下条件的浏览器：

- The browser is WebGL 2 capable. **Note**: Unity no longer provides support for WebGL 1 in builds created with the Auto Graphics API option. For more details, see [WebGL 1 deprecation](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-browsercompatibility.html#webgl-depr).  
    该浏览器支持 WebGL 2。 **注意** ：Unity 在使用 Auto Graphics API 选项创建的版本中不再提供对 WebGL 1 的支持。有关更多详细信息，请参阅 [WebGL 1 弃用](https://docs.unity3d.com/2022.3/Documentation/Manual/webgl-browsercompatibility.html#webgl-depr) 。
- The browser is HTML 5 standards-compliant.  
    该浏览器符合 HTML 5 标准。
- The browser is 64-bit and supports WebAssembly.  
    浏览器为 64 位，支持 WebAssembly。

Unity WebGL supports some compressed **texture formats**[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-TextureImporterOverride.html)  [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#TextureFormat). For information on the compressed texture formats that Unity WebGL supports, see [Recommended, default, and supported texture compression formats, by platform](https://docs.unity3d.com/2022.3/Documentation/Manual/class-TextureImporterOverride.html).  
Unity WebGL 支持一些压缩 **texture formats** 的 .有关 Unity WebGL 支持的压缩纹理格式的信息，请参阅[按平台推荐、默认和支持的纹理压缩格式](https://docs.unity3d.com/2022.3/Documentation/Manual/class-TextureImporterOverride.html) 。

| **Desktop Browser  桌面浏览器**     | **Desktop Platforms  桌面平台**                |
| ------------------------------ | ------------------------------------------ |
| Google Chrome  谷歌浏览器           | Windows, macOS, Linux  Windows、macOS、Linux |
| Mozilla Firefox  Mozilla 火狐浏览器 | Windows, macOS, Linux  Windows、macOS、Linux |
| Apple Safari  苹果 Safari 浏览器    | macOS  macOS 的                             |
| Microsoft Edge                 | Windows, macOS, Linux  Windows、macOS、Linux |

**Notes:  笔记：**
- Unity WebGL also supports the latest version of the Chromium-based Edge browser.  
    Unity WebGL 还支持最新版本的基于 Chromium 的 Edge 浏览器。
- Apple Safari doesn’t support WebGL 2 in versions before Safari 15.  
    Apple Safari 在 Safari 15 之前的版本中不支持 WebGL 2。
- Apple Safari doesn’t support IndexedDB for content running in an iFrame.  
    Apple Safari 不支持对 iFrame 中运行的内容使用 IndexedDB。
- On Linux, you might have to install Advanced Audio Coding (AAC) codec support via a package manager (for example, the GStreamer package).  
    在 Linux 上，您可能必须通过包管理器（例如 GStreamer 包）安装高级音频编码 （AAC） 编解码器支持。

## Web browser compatibility for mobile | 移动 Web 浏览器兼容性
The Unity Web platform supports some mobile browsers. To use a Web application on a mobile device, you have a few options:  
Unity Web 平台支持某些移动浏览器。要在移动设备上使用 Web 应用程序，您有以下几种选择：

- Run the application in your mobile browser.  
    在移动浏览器中运行应用程序。
- Use WebView to embed the application into native apps.  
    使用 WebView 将应用程序嵌入到本机应用程序中。
- Use a **Progressive Web App**[](https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps) [](https://docs.unity3d.com/2023.2/Documentation/Manual/Glossary.html#ProgressiveWebApp) (PWA) template.  
    使用 **Progressive Web App** （PWA） 模板。

Unity’s Web platform supports the following mobile browsers:  
Unity 的 Web 平台支持以下移动浏览器：

| **Mobile Browser  移动浏览器**                        | **Mobile Platform  移动平台** |
| ------------------------------------------------ | ------------------------- |
| iOS Safari 15 and newer  <br>iOS Safari 15 及更高版本 | iOS                       |
| Chrome 58 and newer  <br>Chrome 58 及更高版本         | Android                   |
## WebGL 1 deprecation  WebGL 1 弃用
From Unity 2022.1, the **Auto Graphics API** setting no longer includes WebGL 1 Graphics API. However, if you still need to add support for WebGL 1 in your project then follow these steps:  
从 Unity 2022.1 开始，**Auto Graphics API** 设置不再包含 WebGL 1 Graphics API。但是，如果您仍然需要在项目中添加对 WebGL 1 的支持，请按照以下步骤作：

1. Open the **Player Settings**[](https://docs.unity3d.com/2022.3/Documentation/Manual/class-PlayerSettings.html) [](https://docs.unity3d.com/2022.3/Documentation/Manual/Glossary.html#PlayerSettings) window and expand the **Other Settings** section.  
    打开 **Player Settings** 窗口并展开 **Other Settings** 部分。
2. Disable the **Auto Graphics API** option and explicitly add **WebGL 1 (Deprecated)** to the Graphics API list.  
    禁用 **Auto Graphics API** 选项，并将 **WebGL 1（已弃用）** 显式添加到 Graphics API 列表中。![Unity will remove support for WebGL1 entirely in Unity 2023.1](https://docs.unity3d.com/2022.3/Documentation/uploads/Main/webgl-graphicsapi-deprecation.png)

## WebGL 1 graphics card blocklists  
WebGL 1 显卡黑名单
GPU blocklists apply. Older graphics cards might not support WebGL. For more information, see:  
GPU 黑名单适用。较旧的显卡可能不支持 WebGL。有关详细信息，请参阅：
- Mozilla’s documentation on [Blocklisting/Blocked Graphics Drivers](https://wiki.mozilla.org/Blocklisting/Blocked_Graphics_Drivers).  
    Mozilla 关于[将图形驱动程序列入黑名单/阻止的文档](https://wiki.mozilla.org/Blocklisting/Blocked_Graphics_Drivers) 。
- Khronos’s documentation on [Blacklists and Whitelists](https://www.khronos.org/webgl/wiki/BlacklistsAndWhitelists).  
    Khronos 关于[黑名单和白名单](https://www.khronos.org/webgl/wiki/BlacklistsAndWhitelists)的文档。

---
- WebGL 1 deprecated from the Auto Graphics API list in 2022.1  
    WebGL 1 在 2022.1 中已从自动图形 API 列表中弃用
- Brotli compression first documented on this page in User Manual 5.6  
    Brotli 压缩首次记录在本页的用户手册 5.6 中
- Updated with most recent compatibility information in 2019.1  
    更新了 2019.1 中的最新兼容性信息

Unity WebGL 虽然在大部分浏览器上都支持，但是支持程度以及性能表现不一样，另外，在移动设备上是不支持的，虽然在一些高端设备上有可能运行，但是绝大部分设备是没有那么大内存来支持 Unity WebGL 的。

下表列出了`Firefox`、`Chrome`、`Safri`、`Edge`各个浏览器的支持情况
![](https://pic4.zhimg.com/v2-d1830f7f2494e4616c6e4cba8de4144b_1440w.jpg)

说明：
1. 浏览器厂商为了稳定性，通常会采用黑名单/白名单的方式，针对不同的显卡驱动进行功能限制，在 chrome 中可以通过输入 `chrome://gpu` 来查看当前 gpu 的状态，或者可以在[这里](https://link.zhihu.com/?target=https%3A//www.khronos.org/webgl/wiki/BlacklistsAndWhitelists)查询；
2. Large-Allocation 响应头是高速浏览器需要分配大量内存，目前只有 Firefox 支持。
3. 浏览器打开如下页面（主流浏览器：chrome、safari、edge、firefox正常都支持）
[https://get.webgl.org/](https://link.zhihu.com/?target=https%3A//get.webgl.org/)

如出现以下信息，表示当前浏览器支持。
![](https://pic3.zhimg.com/v2-970141f19bb838448412ac4af22ecace_1440w.jpg)