[Rawimage](file://assets/Scripts/UGUI/Lesson9_RawImage/Lesson9_RawImage.cs)
# 原始图像 (Raw Image)
__原始图像__控件向用户显示非交互式图像。此图像可用于装饰或图标之类的用途，还可以从脚本更改图像以便反映其他控件的更改。该控件类似于[图像 (Image)](https://docs.unity3d.com/cn/2022.3/Manual/script-Image.html) 控件，但为动画化图像和准确填充控件矩形提供了更多选项。但是，图像控件要求其纹理为[精灵](https://docs.unity3d.com/cn/2022.3/Manual/class-TextureImporter.html)，而原始图像可以接受任何纹理。

![原始图像控件](https://docs.unity3d.com/cn/2022.3/uploads/Main/RawImageCtrlExample.png)
原始图像控件

## 属性
![[Pasted image 20241203215537.png]]

![[Pasted image 20241203215652.png]]

| **_属性：_**           | **_功能：_**                                                                   |
| ------------------- | --------------------------------------------------------------------------- |
| **Texture**         | 表示要显示的图像的纹理。                                                                |
| **Color**           | 要应用于图像的颜色。                                                                  |
| **Material**        | 用于渲染图像的[材质](https://docs.unity3d.com/cn/2022.3/Manual/class-Material.html)。 |
| **Raycast Target**  | 如果希望 Unity 将图像视为射线投射的目标，请启用 **Raycast Target**。                             |
| **Raycast Padding** | 射线检测范围                                                                      |
| Maskable            | 是否被遮罩                                                                       |
| **UV Rectangle**    | 图像在控件矩形内的偏移和大小，以标准化坐标（范围 0.0 到 1.0）表示。图像边缘将进行拉伸来填充 UV 矩形周围的空间。              |

## 详细信息
由于原始图像不需要精灵纹理，因此可以使用这种图像来显示 Unity 播放器可用的任何纹理。例如，可使用 [WWW](https://docs.unity3d.com/cn/2022.3/ScriptReference/WWW.html) 类显示从 URL 下载的图像，或显示来自游戏对象的纹理。

_UV Rectangle_ 属性允许显示较大图像的一小部分。_X_ 和 _Y_ 坐标指定图像的哪个部分与控件的左下角对齐。例如，X 坐标为 0.25 将会截断图像的最左边四分之一。_W_ 和 _H_（即宽度和高度）属性指示了要进行缩放来适应控件矩形的图像部分的宽度和高度。例如，宽度和高度为 0.5 将会将图像区域放大四分之一来适应控件矩形。通过更改这些属性，即可根据需要缩放图像（另请参阅[滚动条 (Scrollbar)](https://docs.unity3d.com/cn/2022.3/Manual/script-Scrollbar.html) 控件）。

## Image /RawImage的区别
- Imgae比RawImage更消耗性能
- Image只能使用Sprite属性的图片，但是RawImage什么样的都可以使用
- Image适合放一些有操作的图片，裁剪平铺旋转什么的，针对Image Type属性
- RawImage就放单独展示的图片就可以，性能会比Image好很多

RawImage可以配合Render Texture实现摄影机图像显示在UI界面上