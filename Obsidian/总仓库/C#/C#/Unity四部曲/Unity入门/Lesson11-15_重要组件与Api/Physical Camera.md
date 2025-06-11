# 物理摄像机 (Physical Camera)参数
|       ISO       |              | 感光度，值越大感光越强，这个参数只有当体积的**曝光**功能设置为UsePhysicalCamera时才会生效，这个值一般需要给的很大。![[Pasted image 20240905180442.png]]<br>将用到的体积曝光功能设置为UsePhysicalCamera![[Pasted image 20240905180519.png]]<br>iso 设置为 10K![[Pasted image 20240905180527.png]]<br>Iso 设置为 3500K                                                                                                                 |
| :-------------: | :----------: | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
|  ShutterSpeed   |              | 快门速度，就是拍摄一次需要接受多久的曝光，iso 不变，这个值越大，则场景越亮。也需要体积的曝光功能设置为UsePhysicalCamera时才会生效<br>单位分为秒，和多少分之一秒，表示方式和单位的不同而已可以互相转换。<br>当单位为 Second 时，数值代表渲染一帧接受多少秒曝光，如，0.005，则代表渲染一帧接受0.005秒的曝光<br>当单位为 1/second 时，则代表渲染一帧接受多少分之1秒，如，200，则代表渲染一帧接受 1/200 秒的曝光![[Pasted image 20240905180345.png]]<br>ISO 1000K 快门时间 0.005秒![[Pasted image 20240905180401.png]]<br>ISO 1000K 快门时间 0.1秒 |
|    Aperture     |              | 孔径比，也称为 f 值 (f-stop) 或 f 数 (f-number)，指摄像机焦距与镜头直径的比率  <br>Aperture 越大，证明焦距大孔径小，所以景深模糊小，曝光度低，Aperture 越小，证明焦距小孔径大，景深模糊越大，曝光度越低  <br>当 Volume 中的 DepthOfField 和 Expose 的模式设置为 UsePhysicalCamera 时会受 Aperture 影响。<br><br>                                                                                                                                             |
|  FocusDistance  |              |                                                                                                                                                                                                                                                                                                                                                                    |
|   Blade Count   |              | 用来表示真是相机快门（光圈）的叶片数量，可以影响景深的散景外观，实测对景深的模糊效果影响不大                                                                                                                                                                                                                                                                                                                     |
|    Curvature    |              | 使用重新映射器将光圈范围映射到叶片曲率。在较高的光圈值下，光圈叶片在散景上变得更加明显。调整此范围可以定义散景在给定光圈下的外观。最小值产生完全弯曲的完美圆形散景，而最大值产生具有可见光圈叶片的完全成形的散景。此属性会影响景深散景的外观。实测对景深的模糊效果影响不大                                                                                                                                                                                                                              |
|                 |     _X_      |                                                                                                                                                                                                                                                                                                                                                                    |
|                 |     _Y_      |                                                                                                                                                                                                                                                                                                                                                                    |
| Barrel Clipping |              | 猫眼效果的强度，实测对镜头效果影响不大                                                                                                                                                                                                                                                                                                                                                |
|   Anamorphism   |              | 控制相机模糊的变形，正直会使摄像机垂直模糊更明显，负值会使摄像机水平，模糊更明显，可以影响 景深 和 辉光。                                                                                                                                                                                                                                                                                                             |
| _Focal Length_  |              | 设置摄像机传感器和摄像机镜头之间的距离（以毫米为单位）。  <br>  <br>较小的值产生更宽的 **Field of View**，反之亦然。  <br>  <br>更改此值时，Unity 会相应自动更新 **Field of View** 属性。                                                                                                                                                                                                                                     |
|  _Sensor Type_  |              | 指定希望摄像机模拟的真实摄像机格式。从列表中选择所需的格式。  <br>  <br>选择摄像机格式时，Unity 会自动将 **Sensor Size > X** 和 **Y** 属性设置为正确的值。  <br>  <br>如果手动更改 **Sensor Size** 值，Unity 会自动将此属性设置为 **Custom**。                                                                                                                                                                                              |
|  _Sensor Size_  |              | 设置摄像机传感器的大小（以毫米为单位）。  <br>  <br>选择 **Sensor Type** 时，Unity 会自动设置 **X** 和 **Y** 值。如果需要，可以输入自定义值。                                                                                                                                                                                                                                                                    |
|                 |     _X_      | 传感器的宽度。                                                                                                                                                                                                                                                                                                                                                            |
|                 |     _Y_      | 传感器的高度。                                                                                                                                                                                                                                                                                                                                                            |
|  _Lens Shift_   |              | 从中心水平或垂直移动镜头。值是传感器大小的倍数；例如，在 X 轴上平移 0.5 将使传感器偏移其水平大小的一半。  <br>  <br>可使用镜头移位来校正摄像机与拍摄对象成一定角度时发生的失真（例如，平行线会聚）。  <br>  <br>沿任一轴移动镜头均可使摄像机视锥体[倾斜](https://docs.unity.cn/cn/2022.2/Manual/ObliqueFrustum.html)。                                                                                                                                                         |
|                 |     _X_      | 传感器水平偏移。                                                                                                                                                                                                                                                                                                                                                           |
|                 |     _Y_      | 传感器垂直偏移。                                                                                                                                                                                                                                                                                                                                                           |
|   _Gate Fit_    |              | 相机视野适配 SensorSize 的方式。一般我们手动设置的长宽不一定正好就是相机显示分辨的长宽，这时就需要一个适配方案，比如是按照SensorSize 宽度来计算相机视野的大小，还是按照SensorSize 高度来计算相机视野大小。包含五种适配方式。![[Pasted image 20240905181115.png]]<br><br>用于更改**分辨率门**大小（Game 视图的大小/宽高比）相对于**胶片门**大小（物理摄像机传感器的大小/纵横比）的选项。  <br>  <br>有关分辨率门和胶片门的更多信息，请参阅关于[物理摄像机](https://docs.unity.cn/cn/2022.2/Manual/PhysicalCameras.html)的文档。                |
|                 |  _Vertical_  | 使分辨率门适应胶片门的高度。  <br>  <br>如果传感器宽高比大于 Game 视图宽高比，Unity 会在两侧裁剪渲染的图像。  <br>  <br>如果传感器宽高比小于 Game 视图宽高比，Unity 会在两侧对渲染的图像进行过扫描。  <br><br>选择此设置时，更改传感器宽度（**Sensor Size > X 属性**）不会影响渲染的图像。                                                                                                                                                                               |
|                 | _Horizontal_ | 使分辨率门适应胶片门的宽度。  <br>  <br>如果传感器宽高比大于 Game 视图宽高比，Unity 会在顶部和底部对渲染的图像进行过扫描。  <br>  <br>如果传感器宽高比小于 Game 视图宽高比，Unity 会在顶部和底部裁剪渲染的图像。  <br>  <br>选择此设置时，更改传感器高度（**Sensor Size > Y** 属性）不会影响渲染的图像。                                                                                                                                                                       |
|                 |    _Fill_    | 使分辨率门适应胶片门的宽度或高度（以较小者为准）。这会裁剪渲染的图像。<br>按照最小的适配边来适配，即保尽最大程度证相机视野框在SensorSize框内                                                                                                                                                                                                                                                                                      |
|                 |  _Overscan_  | 使分辨率门适应胶片门的宽度或高度（以较大者为准）。这会过扫描 (overscan) 渲染的图像。<br>按照最大适配边来适配，即保尽最大程度证相机的视野范围始终可以涵括SensorSize的范围                                                                                                                                                                                                                                                                  |
|                 |    _None_    | 忽略分辨率门，仅使用胶片门。这会拉伸渲染的图像以适应 Game 视图宽高比。<br>将 SensorSize 的范围作为渲染范围，除非SensorSize和相机输出长宽比一致，不然会引起图像长宽失调                                                                                                                                                                                                                                                                |

# 使用物理摄像机 (Physical Camera)

[摄像机组件](https://docs.unity.cn/cn/2022.2/Manual/class-Camera.html)的 Physical Camera 属性在 Unity 摄像机上模拟真实摄像机格式。这可用于从同样模拟真实摄像机的 3D 建模应用程序导入摄像机信息。

![](https://docs.unity.cn/cn/2022.2/uploads/Main/InspectorCameraPhysCam.png)

Unity 提供的设置与大多数 3D 建模应用程序的物理摄像机设置相同。控制摄像机视野的两个主要属性是 **Focal Length** 和 **Sensor Size**。

- **Focal Length：**传感器和摄像机镜头之间的距离，即焦距。此属性决定了垂直视野。Unity 摄像机处于 Physical Camera 模式时，改变 Focal Length 也会相应改变视野。焦距越小，视野越大，反之亦然。
    
    ![摄像机焦距、视野和传感器尺寸之间的关系](https://docs.unity.cn/cn/2022.2/uploads/Main/PhysCamAttributes.png)
    
    摄像机焦距、视野和传感器尺寸之间的关系
    
- **Sensor Size：**捕捉图像的传感器的宽度和高度，表示传感器大小。这些数值决定了物理摄像机的宽高比。可从对应于真实摄像机格式的几个预设传感器大小中进行选择，或设置自定义大小。传感器宽高比与渲染的宽高比（在 Game 视图中设置）不同时，可以控制 Unity 如何将摄像机图像与渲染的图像匹配（请参阅下文中关于 [Gate Fit](https://docs.unity.cn/cn/2022.2/Manual/PhysicalCameras.html#GateFit) 的信息）。
    

## Lens Shift

**Lens Shift** 从传感器水平和垂直偏移摄像机的镜头。这样一来便可以改变焦点中心，并在渲染的帧中重新定位拍摄对象，确保很少或完全没有失真。

这种方法在建筑摄影中很常见。例如，如果要拍摄一座高楼，可以旋转摄像机。但这会使图像失真，导致平行线看起来发生会聚。

![向上旋转摄像机来拍摄楼顶时会让垂直线会聚](https://docs.unity.cn/cn/2022.2/uploads/Main/LensShift_VRot.png)

向上旋转摄像机来拍摄楼顶时会让垂直线会聚

如果把镜头上移，而不是旋转摄像机，就可以改变构图以包含楼顶，但平行线保持直线。

![沿 Y 轴移动镜头会移动焦点中心，但能使垂线保持直线](https://docs.unity.cn/cn/2022.2/uploads/Main/LensShift_VShift.png)

沿 Y 轴移动镜头会移动焦点中心，但能使垂线保持直线

同样，可以使用水平镜头位移方法来拍摄宽大的对象，避免由于旋转摄像机而可能产生的失真。

![](https://docs.unity.cn/cn/2022.2/uploads/Main/LensShift_HRot.png)

![旋转摄像机（上图）来框定大楼会使水平线会聚。而水平移动镜头（下图）会重新框定图像，但使水平线保持直线。](https://docs.unity.cn/cn/2022.2/uploads/Main/LensShift_HShift.png)

旋转摄像机（上图）来框定大楼会使水平线会聚。而水平移动镜头（下图）会重新框定图像，但使水平线保持直线。

### 镜头移位 (Lens Shift) 和视锥体倾斜

镜头移位的一个副作用是会使摄像机的[视锥体](https://docs.unity.cn/cn/2022.2/Manual/UnderstandingFrustum.html)倾斜。这意味着摄像机的中心线与其视锥体之间的角度在一侧要小于另一侧。

![上图显示了 Y 轴镜头移位之前（左）和之后（右）的摄像机视锥体。向上移动镜头会使视锥体倾斜。](https://docs.unity.cn/cn/2022.2/uploads/Main/ObliqueFrustum_LensShift.png)

上图显示了 Y 轴镜头移位之前（左）和之后（右）的摄像机视锥体。向上移动镜头会使视锥体倾斜。

此功能可用于根据视角来创造视觉效果。例如，在赛车游戏中，可能希望将视角保持在接近地面的较低位置。镜头移位是一种不用脚本即可实现视锥体倾斜的方式。

有关更多信息，请参阅关于[使用斜视锥体](https://docs.unity.cn/cn/2022.2/Manual/ObliqueFrustum.html)的文档。

## Gate Fit

Camera 组件的 **Gate Fit** 属性决定了 Game 视图和物理摄像机传感器具有不同宽高比时会发生什么情况。

在 **Physical Camera** 模式中，一个摄像机有两个“门”。

- 根据 **Aspect** 下拉菜单中设置的分辨率在 Game 视图中渲染的区域被称为“分辨率门”。
    
- 摄像机实际看到的区域（由 **Sensor Size** 属性定义）被称为“胶片门”。
    

![分辨率门与胶片门具有不同宽高比的示例](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitGates.png)

分辨率门与胶片门具有不同宽高比的示例

两个门具有不同宽高比时，Unity 让分辨率门“适应”胶片门。有几种适应模式，但是这些模式都会产生以下三种结果之一。

- **裁剪 (Cropping)：**适应后，胶片门超过分辨率门时，Game 视图在满足宽高比的情况下渲染尽可能多的摄像机图像面积，并裁掉其余部分。
- **过扫描 (Overscanning)：**适应后，胶片门超过分辨率门时，Game 视图仍然对摄像机视野之外的场景部分进行渲染计算。
- **拉伸 (Stretching)：**Game 视图渲染完整的摄像机图像，将其水平或垂直拉伸以适应宽高比。

要在 Scene 视图中查看这些门，并查看它们如何相互适应，请选择摄像机并查看其视锥体。分辨率门是摄像机远裁剪面。胶片门是位于视锥体底部的第二个矩形。

![在以上示例中，位于摄像机视锥体底部的外矩形 (A) 是分辨率门。内矩形 (B) 是胶片门](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitUI.png)

在以上示例中，位于摄像机视锥体底部的外矩形 (A) 是分辨率门。内矩形 (B) 是胶片门

### Gate Fit 模式

选择的 **Gate Fit** 模式决定了 Unity 如何调整分辨率门的大小（因而调整摄像机的视锥体）。胶片门始终保持相同大小。

以下部分提供了关于每种 Gate Fit 模式的更多详细信息。

### Vertical

**Gate Fit** 设置为 **Vertical** 时，Unity 让分辨率门适应胶片门的高度（Y 轴）。对传感器宽度 (**Sensor Size > X**) 进行的任何更改都不会影响渲染的图像。

如果传感器宽高比大于 Game 视图宽高比，Unity 会在两侧裁剪渲染的图像：

![Gate Fit 设置为 Vertical：分辨率门宽高比为 0.66:1 (600 x 900 px)。胶片门宽高比为 1.37:1 (16mm)。红色区域表示 Unity 在 Game 视图中裁剪图像的位置。](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitV_600x900_16mm.png)

**Gate Fit** 设置为 **Vertical**：分辨率门宽高比为 0.66:1 (600 x 900 px)。胶片门宽高比为 1.37:1 (16mm)。红色区域表示 Unity 在 Game 视图中裁剪图像的位置。

如果传感器宽高比小于 Game 视图宽高比，Unity 会在两侧对渲染的图像进行过扫描：

![Gate Fit 设置为 Vertical：分辨率门宽高比为 16:9。胶片门宽高比为 1.37:1 (16mm)。绿色区域表示 Unity 在 Game 视图中对图像进行过扫描的位置。](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitV_16-9_16mm.png)

**Gate Fit** 设置为 **Vertical**：分辨率门宽高比为 16:9。胶片门宽高比为 1.37:1 (16mm)。绿色区域表示 Unity 在 Game 视图中对图像进行过扫描的位置。

### Horizontal

**Gate Fit** 设置为 **Horizontal** 时，Unity 让分辨率门适应胶片门的宽度（X 轴）。对传感器高度 (Sensor Size > Y) 进行的任何更改都不会影响渲染的图像。

如果传感器宽高比大于 Game 视图宽高比，Unity 会在顶部和底部对渲染的图像进行过扫描：

![Gate Fit 设置为 Horizontal：分辨率门宽高比为 0.66:1 (600 x 900 px)。胶片门宽高比为 1.37:1 (16mm)。绿色区域表示 Unity 在 Game 视图中对图像进行过扫描的位置。](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitH_600x900_16mm.png)

**Gate Fit** 设置为 **Horizontal**：分辨率门宽高比为 0.66:1 (600 x 900 px)。胶片门宽高比为 1.37:1 (16mm)。绿色区域表示 Unity 在 Game 视图中对图像进行过扫描的位置。

如果传感器宽高比小于 Game 视图宽高比，则会在顶部和底部裁剪渲染的图像。

![Gate Fit 设置为 Horizontal：分辨率门宽高比为 16:9。胶片门宽高比为 1.37:1 (16mm)。红色区域表示 Unity 在 Game 视图中裁剪图像的位置。](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitH_16-9_16mm.png)

**Gate Fit** 设置为 **Horizontal**：分辨率门宽高比为 16:9。胶片门宽高比为 1.37:1 (16mm)。红色区域表示 Unity 在 Game 视图中裁剪图像的位置。

### None

Gate Fit 设置为 None 时，Unity 让分辨率门适应胶片门的宽度和高度（X 轴和 Y 轴）。Unity 会拉伸渲染的图像以适应 Game 视图宽高比。

![无 Gate Fit。摄像机使用的胶片门宽高比为 1.37:1 (16 mm)，并水平拉伸图像以适应 16:9 的 Game 视图宽高比（左），垂直拉伸图像以适应 0.66:1 的 Game 视图宽高比（右）](https://docs.unity.cn/cn/2022.2/uploads/Main/GateFitF_16mm.png)

无 Gate Fit。摄像机使用的胶片门宽高比为 1.37:1 (16 mm)，并水平拉伸图像以适应 16:9 的 Game 视图宽高比（左），垂直拉伸图像以适应 0.66:1 的 Game 视图宽高比（右）

### Fill 和 Overscan

**Gate Fit** 设置为 **Fill** 或 **Overscan** 时，Unity 根据分辨率门和胶片门的宽高比，自动进行垂直或水平适应。

- **Fill** 让分辨率门适应胶片门的较小轴，并裁剪摄像机图像的其余部分。
- **Overscan** 让分辨率门适应胶片门的较大轴，并对摄像机图像边界以外的区域进行过扫描。

---

- 2018–10–05 页面已修订
    
- 在 [2018.2](https://docs.unity.cn/2018.2/Documentation/Manual/30_search.html?q=newin20182) 版中添加了 Physical Camera 选项
    
- 在 Unity 2018.3 中添加了 Gate Fit 选项