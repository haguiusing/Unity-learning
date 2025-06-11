`Outline` 组件用于为 `Text` 或 `Image` 等 UI 元素添加轮廓效果。DOTween Pro 扩展提供了几个专门针对 `Outline` 组件的方法来进行插值（Tweening）。
## DOBlurShift(float to, float duration, bool snapping = false)
改变 `Outline` 组件的模糊偏移量。
- `float to`: 目标模糊偏移量。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OutlineTweenExample : MonoBehaviour
{
    public Outline myOutline;

    void Start()
    {
        // 在1秒内将Outline的模糊偏移量渐变到5
        myOutline.DOBlurShift(5f, 1f);
    }
}
```

## DODilateShift(float to, float duration, bool snapping = false)
改变 `Outline` 组件的膨胀偏移量。
- `float to`: 目标膨胀偏移量。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
// 在1秒内将Outline的膨胀偏移量渐变到3
myOutline.ODilateShift(3f, 1f);
```

## DOInfoRendererScale(float to, float duration, bool snapping = false)
改变 `Outline` 组件的 `InfoRenderer` 的缩放。
- `float to`: 目标缩放值。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
// 在1秒内将Outline的InfoRenderer缩放渐变到2
myOutline.DOInfoRendererScale(2f, 1f);
```

## DOPrimaryRendererScale(float to, float duration, bool snapping = false)
改变 `Outline` 组件的 `PrimaryRenderer` 的缩放。
- `float to`: 目标缩放值。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
// 在1秒内将Outline的PrimaryRenderer缩放渐变到1.5
myOutline.DOPrimaryRendererScale(1.5f, 1f);
```