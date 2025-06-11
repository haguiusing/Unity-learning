`ScrollRect` 组件用于创建可滚动的视图。DOTween 提供了一些专门针对 `ScrollRect` 组件的方法来进行插值（Tweening）。
## DONormalizedPos(Vector2 to, float duration, bool snapping)
将 `ScrollRect` 的 `horizontalNormalizedPosition` 和 `verticalNormalizedPosition` 属性插值到给定值。
- `Vector2 to`: 目标归一化位置，其中 x 代表 `horizontalNormalizedPosition`，y 代表 `verticalNormalizedPosition`。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI; // 引用 UI 命名空间

public class ScrollRectTweenExample : MonoBehaviour
{
    public ScrollRect myScrollRect;

    void Start()
    {
        // 在1秒内将ScrollRect的归一化位置渐变到 (0.5, 0.5)
        myScrollRect.DONormalizedPos(new Vector2(0.5f, 0.5f), 1f, false);
    }
}
```
## DOHorizontalNormalizedPos(float to, float duration, bool snapping)
将 `ScrollRect` 的 `horizontalNormalizedPosition` 属性插值到给定值。
- `float to`: 目标水平归一化位置。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
// 在1秒内将ScrollRect的水平归一化位置渐变到 0.5
myScrollRect.DOHorizontalNormalizedPos(0.5f, 1f, false);
```

## DOVerticalPos(float to, float duration, bool snapping)
将 `ScrollRect` 的 `verticalNormalizedPosition` 属性插值到给定值。
- `float to`: 目标垂直归一化位置。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
// 在1秒内将ScrollRect的垂直归一化位置渐变到 0.5
myScrollRect.DOVerticalNormalizedPos(0.5f, 1f, false);
```