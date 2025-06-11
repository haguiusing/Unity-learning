[屏幕坐标转UI相对坐标](file://assets/Scripts/UGUI/Lesson20_%E5%B1%8F%E5%B9%95%E5%9D%90%E6%A0%87%E8%BD%ACUI%E7%9B%B8%E5%AF%B9%E5%9D%90%E6%A0%87/Lesson20_%E5%B1%8F%E5%B9%95%E5%9D%90%E6%A0%87%E8%BD%ACUI%E7%9B%B8%E5%AF%B9%E5%9D%90%E6%A0%87.cs)
![[Pasted image 20241204155303.png]]
# RectTransformUtility
class in UnityEngine
## 描述
Utility 类，包含用于 [RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) 的 helper 方法。
## 静态函数

| [FlipLayoutAxes](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.FlipLayoutAxes.html)                                         | 翻转 RectTransform 大小和对齐方式的水平和垂直轴，可以选择同时翻转其子级。   |
| ----------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------- |
| [FlipLayoutOnAxis](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.FlipLayoutOnAxis.html)                                     | 沿水平或垂直轴翻转 RectTransform 的对齐方式，可以选择同时翻转其子级。     |
| [PixelAdjustPoint](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.PixelAdjustPoint.html)                                     | 将屏幕空间中的给定点转换为像素校正点。                            |
| [PixelAdjustRect](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.PixelAdjustRect.html)                                       | 根据给定的一个矩形变换，返回像素精确坐标中的角点。                      |
| [RectangleContainsScreenPoint](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.RectangleContainsScreenPoint.html)             | 此 RectTransform 是否包含从给定摄像机观察到的屏幕点？             |
| [ScreenPointToLocalPointInRectangle](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.ScreenPointToLocalPointInRectangle.html) | 将一个屏幕空间点转换为 RectTransform 的本地空间中位于其矩形平面上的一个位置。 |
| [ScreenPointToWorldPointInRectangle](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.ScreenPointToWorldPointInRectangle.html) | 将一个屏幕空间点转换为世界空间中位于给定 RectTransform 平面上的一个位置。   |
## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).FlipLayoutAxes
public static void FlipLayoutAxes ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rect, bool keepPositioning, bool recursive);
### 参数

| rect            | 要翻转的 RectTransform。                 |
| --------------- | ----------------------------------- |
| keepPositioning | 如果为 true，则绕轴心翻转。如果为 false，则在父矩形内翻转。 |
| recursive       | 是否同时翻转子级？                           |
### 描述
翻转 RectTransform 大小和对齐方式的水平和垂直轴，可以选择同时翻转其子级。
两次旋转，一个是绕着Z轴旋转了-90°，也就是绕着中心点顺时针旋转了90°，然后X轴旋转了180°。

这会交换 RectTransform 大小和对齐方式的水平和垂直轴。也可以认为这是对角线翻转。这不会翻转或旋转任何实际内容（如图像或文本），但可能调整大小或采用不同的对齐方式。  
  
示例用法就是实例化为一条轴的对齐方式设计的控件（例如水平滑动条），然后翻转轴以使布局适用于其他轴（例如垂直滑动条）。  
  
当 recursive 参数设置为 true 时，子级始终采用设置为 false 的 keepPositioning 选项翻转，以使它们随着父级正确翻转。

![[Pasted image 20241204161219.png]]
初始图
```
RectTransformUtility.FlipLayoutAxes(transform as RectTransform, true, true);
```
![[Pasted image 20241204161142.png]]
翻转图

如果我们在RectTransform中手动设置第一张图中控件的Rotation值的话，如下图：
![[Pasted image 20241204161258.png]]
可以看到上图和调用接口的图2想比，除了图片的显示外其他都一样。这是因为RectTransformUtility.FlipLayoutAxes接口并不会旋转图片和文字的显示，只是改变RectTransform的参数而已。

## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).FlipLayoutOnAxis
public static void FlipLayoutOnAxis ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rect, int axis, bool keepPositioning, bool recursive);
### 参数

| rect            | 要翻转的 RectTransform。                 |
| --------------- | ----------------------------------- |
| keepPositioning | 如果为 true，则绕轴心翻转。如果为 false，则在父矩形内翻转。 |
| recursive       | 是否同时翻转子级？                           |
| axis            | 要沿其翻转的轴。0 表示水平，1 表示垂直。              |
### 描述
沿水平或垂直轴翻转 RectTransform 的对齐方式，可以选择同时翻转其子级。

这会翻转 RectTransform 的对齐方式。这不会翻转任何实际内容（如图像或文本），但可能采用不同的对齐方式。 示例用法是实例化一个以从左到右方式设计的控件（例如 0 为向左的水平滑动条）并将其水平翻转，以使布局适用于相反的方向（例如 0 为向右的水平滑动条）。  
  
当 recursive 参数设置为 true 时，子级始终采用设置为 false 的 keepPositioning 选项翻转，以使它们随着父级正确翻转。

void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive)，把传入的RectTransform水平或者垂直翻转，axis为0表示水平方向，1表示垂直方向，如下图：
![[Pasted image 20241204161438.png]]翻转前
![[Pasted image 20241204161455.png]]水平翻转
![[Pasted image 20241204161500.png]]垂直翻转

# [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).PixelAdjustPoint
public static [Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) PixelAdjustPoint ([Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) point, [Transform](https://docs.unity3d.com/cn/2019.3/ScriptReference/Transform.html) elementTransform, [Canvas](https://docs.unity3d.com/cn/2019.3/ScriptReference/Canvas.html) canvas);
### 返回
**Vector2** 像素调整点。
### 描述
将屏幕空间中的给定点转换为像素校正点。
根据Transform和Canvas把point这个屏幕坐标点转换成像素正确的坐标点。

将屏幕空间中的给定点转换为像素校正点。
```csharp
Vector2 screenPoint = new Vector2(100, 200); // 屏幕空间中的点
        RectTransform rectTransform = GetComponent<RectTransform>(); // 需要校正的RectTransform
        Vector2 pixelCorrectedPoint = RectTransformUtility.PixelAdjustPoint(screenPoint, rectTransform, Camera.main);
```

## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).PixelAdjustRect
public static [Rect](https://docs.unity3d.com/cn/2019.3/ScriptReference/Rect.html) PixelAdjustRect ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rectTransform, [Canvas](https://docs.unity3d.com/cn/2019.3/ScriptReference/Canvas.html) canvas);
### 返回
**Rect** 像素调整矩形。
### 描述
根据给定的一个矩形变换，返回像素精确坐标中的角点。
返回recttransform角点的像素精确坐标，角点的值是左下角相对于中心点的相对坐标，存储在Rect的x，y中。

根据给定的一个矩形变换，返回像素精确坐标中的角点。
```csharp
Vector2[] corners = new Vector2[4];
        rectTransform.GetWorldCorners(corners);
        Vector2[] pixelCorrectedCorners = RectTransformUtility.PixelAdjustRect(rectTransform, Camera.main);
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i] = pixelCorrectedCorners[i];
        }
        rectTransform.SetAllCornerPositions(corners);
```

## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).RectangleContainsScreenPoint
public static bool RectangleContainsScreenPoint ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rect, [Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) screenPoint, [Camera](https://docs.unity3d.com/cn/2019.3/ScriptReference/Camera.html) cam);
### 参数

| rect        | 要测试的 RectTransform。 |
| ----------- | ------------------- |
| screenPoint | 要测试的屏幕点。            |
| cam         | 从其执行测试的摄像机。（可选）。    |
### 返回
**bool** 如果点在矩形内，则为 true。
### 描述
此 RectTransform 是否包含从给定摄像机观察到的屏幕点？

## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).ScreenPointToLocalPointInRectangle
public static bool ScreenPointToLocalPointInRectangle ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rect, [Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) screenPoint, [Camera](https://docs.unity3d.com/cn/2019.3/ScriptReference/Camera.html) cam, out [Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) localPoint);
### 参数

| rect        | 要在其中查找点的 RectTransform。 |
| ----------- | ----------------------- |
| screenPoint | 屏幕空间位置。                 |
| cam         | 与屏幕空间位置关联的摄像机。          |
| localPoint  | 矩形变换本地空间中的点。            |
### 返回
**bool** 如果点击 RectTransform 平面，则无论点是否在矩形内，都返回 true。
### 描述
将一个屏幕空间点转换为 RectTransform 的本地空间中位于其矩形平面上的一个位置（rect的内部坐标）。

cam 参数应为与此屏幕点关联的摄像机。对于设置为 Screen Space - Overlay 模式的 Canvas 中的 RectTransform，cam 参数应为 null。  
  
当从提供 PointerEventData 对象的事件处理程序中使用 ScreenPointToLocalPointInRectangle 时，可以通过使用 PointerEventData.enterEventData（对于悬停功能）或 [PointerEventData.pressEventCamera](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-pressEventCamera.html)（对于单击功能）获取正确的摄像机。这会为给定事件自动使用正确的摄像机（或 null）。

将一个屏幕空间点转换为`RectTransform`的本地空间中位于其矩形平面上的一个位置。
```csharp
Vector2 screenPoint = new Vector2(100, 200); // 屏幕空间中的点
        Camera cam = Camera.main; // 摄像机
        Vector2 localPoint = RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, cam);
        Debug.Log("Local Point: " + localPoint);
```

## [RectTransformUtility](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransformUtility.html).ScreenPointToWorldPointInRectangle
public static bool ScreenPointToWorldPointInRectangle ([RectTransform](https://docs.unity3d.com/cn/2019.3/ScriptReference/RectTransform.html) rect, [Vector2](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector2.html) screenPoint, [Camera](https://docs.unity3d.com/cn/2019.3/ScriptReference/Camera.html) cam, out [Vector3](https://docs.unity3d.com/cn/2019.3/ScriptReference/Vector3.html) worldPoint);
### 参数

| rect        | 要在其中查找点的 RectTransform。 |
| ----------- | ----------------------- |
| screenPoint | 屏幕空间位置。                 |
| cam         | 与屏幕空间位置关联的摄像机。          |
| worldPoint  | 输出：世界空间中的点。             |
### 返回
**bool** 如果点击 RectTransform 平面，则无论点是否在矩形内，都返回 true。
### 描述
将一个屏幕空间点转换为世界空间中位于给定 RectTransform 平面上的一个位置。

cam 参数应为与此屏幕点关联的摄像机。对于设置为 Screen Space - Overlay 模式的 Canvas 中的 RectTransform，cam 参数应为 null。  
  
当从提供 PointerEventData 对象的事件处理程序中使用 ScreenPointToWorldPointInRectangle 时，可以通过使用 PointerEventData.enterEventData（对于悬停功能）或 [PointerEventData.pressEventCamera](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-pressEventCamera.html)（对于单击功能）获取正确的摄像机。这会为给定事件自动使用正确的摄像机（或 null）。

将一个屏幕空间点转换为世界空间中位于给定`RectTransform`平面上的一个位置。
```csharp
Vector2 screenPoint = new Vector2(100, 200); // 屏幕空间中的点
        Camera cam = Camera.main; // 摄像机
        Vector2 worldPoint = RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPoint, cam);
```

这个函数一般的用法是：
```
RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out vecWorldPos);
//得到鼠标位置投射在Canvas平面上的世界坐标点。
```
