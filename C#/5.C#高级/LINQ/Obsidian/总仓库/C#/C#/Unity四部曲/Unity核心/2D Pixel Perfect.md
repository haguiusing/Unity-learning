# 2D 像素完美
**2D Pixel Perfect** 包包含 **Pixel Perfect Camera** 组件，可确保您的像素图在不同分辨率下保持清晰，并在运动中保持稳定。

它是一个组件，可以进行 Unity 根据分辨率更改缩放视口所需的所有计算，因此您无需手动执行。您可以使用组件设置在摄像机视区中调整渲染像素艺术的定义，并且可以使用 **Run in Edit Mode（在编辑模式下运行**）功能立即在 Game 视图中预览任何更改。
![Pixel Perfect Camera 小工具](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_0.png)
将 **Pixel Perfect Camera** 组件附加到场景中的主 Camera 游戏对象，它由 Scene 视图中以 **Camera** Gizmo 为中心的两个绿色边界框表示。绿色实心边界框显示 Game 视图中的可见区域，而虚线边界框显示 **Reference Resolution。**

**Reference Resolution** 是您的资产设计的原始分辨率，其对组件功能的影响将在文档中进一步详细说明。

在使用该组件之前，首先通过以下步骤确保您的 Sprite 已正确准备以获得最佳结果。

## 准备 Sprite

1. 将纹理作为 Sprite 导入项目后，将所有 Sprite 设置为相同的 **Pixels Per Unit** 值。
    ![设置 PPU 值](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_1.png)
    
2. 在 Sprite 的 Inspector 窗口中，将其 **Filter Mode** 设置为 'Point'。
    ![设置 'Point' 模式](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_2.png)
    
3. 将其 **Compression** 设置为 'None'。
    ![设置“无”压缩](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_3.png)
    
4. 按照以下步骤正确设置 Sprite 的枢轴
    1. 打开所选 **Sprite 的 Sprite Editor**。
        
    2. 如果 **Sprite Mode __is设置为 'Multiple' 并且有多个 __Sprite** 元素，则需要为每个单独的 Sprite 元素设置一个枢轴点。
        
    3. 在 Sprite 设置下，将 **Pivot** 设置为 'Custom'，然后将 **Pivot Unit Mode** 设置为 'Pixels'。这允许您以像素为单位设置枢轴点的坐标，或者在 **Sprite Editor** 中自由拖动枢轴点并使其自动对齐到像素角。
        
    4. 根据需要对每个 **Sprite** 元素重复此操作。
        ![设置 Sprite 的 Pivot](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_4.png)
        

## 捕捉设置
为确保 Sprite 的像素化移动彼此一致，请按照以下步骤为项目设置适当的对齐设置。
![Snap Setting 窗口](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_5.png)
1. 要打开 **Snap 设置**，请转到 **Edit** > **Snap Settings。**
    
2. 将 **Move X/Y/Z** 属性设置为 1 除以 Pixel Perfect 相机的**每单位资产像素 （PPU）** 值。例如，如果资产 **PPU** 为 100，则应将 **Move X/Y/Z** 属性设置为 0.01 （1 / 100 = 0.01）。
    
3. Unity 不会追溯应用 Snap 设置。如果场景中有任何预先存在的游戏对象，请选择每个游戏对象，然后选择 **Snap All Axes** 以应用 Snap 设置。

## 性能
![属性表](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_6.png)  
组件的 Inspector 窗口

|**财产**|**功能**|
|---|---|
|**每单位资产像素**|这是构成一个场景单元的像素量。将此值与场景中所有 Sprite 的 **Pixels Per Unit** 值匹配。|
|**参考分辨率**|这是您的资产设计的原始分辨率。|
|**高档渲染纹理（Upscale Render Texture）**|启用此属性可创建接近或以 Reference Resolution （参考分辨率） 为场景的临时渲染纹理，然后将其放大。|
|**像素捕捉（仅在禁用 'Upscale Render Texture' 时可用）**|启用此功能可在渲染时将 **Sprite 渲染器**对齐到世界空间中的网格。网格大小基于 Assets 的 **Pixels Per Unit** 值。|
|**裁剪帧**|裁剪带有黑条的视口，以匹配沿选中轴的 Reference Resolution。选中 X 可添加水平黑条，选中 Y 可添加垂直黑条。有关更多信息和直观示例，请参阅下面的 Property Details。|
|**拉伸填充（在同时选中 X 和 Y 时可用）**|启用此选项可扩展视口以适应屏幕分辨率，同时保持视口的纵横比。|
|**在 Edit 模式下运行**|启用此复选框可在 Edit Mode 中预览 Camera 设置更改。这会导致 Scene 在活动时不断变化。|
|**当前像素比（在启用“在编辑模式下运行”时可用）**|显示渲染的 Sprite 与其原始大小的大小比率。|

## 其他物业详细信息

### 参考分辨率
这是您的资产设计的原始分辨率。从此分辨率放大 Scenes 和 Assets （场景和资源） 可以在更高的分辨率下清晰地保留您的像素图。

### 高档渲染纹理（Upscale Render Texture）
默认情况下，场景以最接近全屏分辨率的像素完美分辨率渲染。

启用此选项可将场景渲染为尽可能接近 **Reference Resolution** 的临时纹理，同时保持全屏纵横比。然后，此临时纹理将放大以适应整个屏幕。
![框示例](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_7.png)

结果是无锯齿和未旋转的像素，这可能是某些游戏项目所需的视觉样式。

### 像素对齐

启用此功能可在渲染时将 Sprite 渲染器对齐到世界空间中的网格。网格大小基于 **Assets Pixels Per Unit** 值。

**像素对齐**可防止子像素移动，并使 Sprite 看起来以逐像素的增量移动。这不会影响任何游戏对象的 Transform 位置。

### 裁剪帧
沿带有黑条的选中轴裁剪视口，以匹配 **Reference Resolution （参考分辨率）。**添加了黑条以使 Game 视图适合全屏分辨率。

|![未裁剪的猫](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_8.png)|![短款猫](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/images/2D_Pix_image_9.png)|
|---|---|
|未裁剪|裁剪|

## Cinemachine 扩展
由于 **Pixel Perfect Camera** 和 [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest) 都会修改摄像机的正交大小，因此在单个场景中同时使用这两个系统会导致它们争夺对摄像机的控制权，并可能产生不需要的结果。要解决这种不兼容问题，请将 [Cinemachine Pixel Perfect](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.4/manual/CinemachinePixelPerfect.html) 扩展添加到您的[虚拟摄像机](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.4/manual/CinemachineSetUpVCam.html)中。您可以在 [Cinemachine 文档](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.4/manual/CinemachinePixelPerfect.html)中找到有关扩展功能的更多信息。
