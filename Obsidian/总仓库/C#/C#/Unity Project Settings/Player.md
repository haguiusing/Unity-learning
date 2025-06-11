![[Pasted image 20250417173057.png]]
分为六部分:
- **Icon**：桌面上显示的游戏图标。可从项目中的 2D 图像资源选择图标。
    
- **Resolution and Presentation**：屏幕分辨率和其他演示详细信息的设置。
    
- **Splash Image**：游戏启动时显示的图像。此部分还包括用于创建启动画面的常用设置。
    
- **Other Settings**：平台特有的任何其他设置。
    
- **Publishing Settings**：有关如何准备将构建的应用程序从应用商店或托管网页上进行发布的详细信息。
    
- **XR Settings**：特定于虚拟现实、增强现实和混合现实应用的设置。
    
- **Lightmap Encoding**： 选择 `Normal Quality` 或 `High Quality` 来设置光照贴图编码。此设置影响光照贴图的编码方案和压缩格式。
    
- **Lightmap Streaming**：启用此选项可根据需要仅加载光照贴图 Mipmap 以渲染当前游戏摄像机。此值适用于生成的光照贴图纹理。【启用Texture Streaming Quality时可用】
    
    - **Streaming Priority**：设置光照贴图 Mipmap 串流优先级以解决资源冲突。这些值应用于生成的光照贴图纹理。  
        正数提供更高的优先级。有效值范围为 –128 到 127。
# ICON（图标）
![[Pasted image 20250417173307.png]]
由默认头像`Default Icon`自动转换的。
一般情况下是：美术给的`1024*1024`的图，我们直接在1.1中`Default Icon`赋值即可，不需要做特殊处理。
勾选`Override for PC,Mac && Linux Standalone`，可以上传不同大小的图标来填充提供的每个方块，下面的大尺寸选择图之后，会向下兼容小尺寸：
![[Pasted image 20250417173740.png]]
# Resolution and Presentation（分辨率和显示）
![[Pasted image 20250417173350.png]]
## Resolution 部分
![[Pasted image 20250417174017.png]]
- **Fullscreen Mode：** 选择全屏模式。此设置定义了启动时的默认窗口模式。
    1. Fullscreen Window：将程序窗口设置为显示器的全屏原始分辨率。
    2. Exclusive Fullscreen (Windows only)：设置应用程序以保持对显示器的单独全屏使用。此选项仅支持Windows系统，其他平台设置则会回退到Fullscreen Window。
    3. Maximized Window (Mac only)：将应用程序窗口设置为操作系统的“最大化”定义。在 macOS 上，这意味着显示带有自动隐藏菜单栏和停靠栏的全屏窗口。此选项仅支持macOS系统，其他平台设置则会回退到Fullscreen Window。
    4. Windowed：将应用程序设置为标准的非全屏可移动窗口，其大小取决于应用程序分辨率。此模式默认支持拖拽调整窗口大小（可任意大小且不会按照比例进行缩放），若禁用需取消勾选`Resizable Window`选项。
    
- **Default Is Native Resolution:** 启用此选项可使游戏使用目标机器上使用的默认分辨率。【Fullscreen Mode 选 Maximized Window 可用】
    
- **Default Screen Width:** 设置游戏画面的默认宽度。【Fullscreen Mode 选 Windowed 生效】
    
- **Default Screen Height:** 设置游戏画面的默认高度。【Fullscreen Mode 选 Windowed 生效】
    
- **Mac Retina Support:** 启用此选项可在 Mac 上启用高 DPI (Retina) 屏幕支持。Unity 默认情况下启用此功能。此功能可增强 Retina 显示屏上的项目显示效果，但在激活状态下会有点耗费资源。
    
- **Run In background:** 启用此选项可在应用程序失去焦点时让游戏继续运行（而不是暂停）。

## Standalone Player Options 部分
![[Pasted image 20250417174022.png]]