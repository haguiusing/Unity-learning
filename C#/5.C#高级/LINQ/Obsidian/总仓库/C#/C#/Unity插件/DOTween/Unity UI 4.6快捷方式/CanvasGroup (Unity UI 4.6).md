应用于 `CanvasGroup` 组件，以实现透明度的插值（Tweening）
## DOFade(float to, float duration)
### 参数说明：
1. **float to**: 目标透明度值。这个值的范围通常是从 0（完全透明）到 1（完全不透明）。
2. **float duration**: 插值持续时间，即从当前透明度变化到目标透明度所需的时间。

### 使用示例：
假设你有一个名为 `myCanvasGroup` 的 `CanvasGroup` 组件，你想要在 2 秒内将其透明度从当前值渐变到 0.5。 
```csharp
using DG.Tweening;
using UnityEngine;

public class CanvasGroupFadeExample : MonoBehaviour
{
    public CanvasGroup myCanvasGroup;

    void Start()
    {
        // 在2秒内将CanvasGroup的透明度渐变到0.5
        myCanvasGroup.DOFade(0.5f, 2f);
    }
}
```

在这个示例中，我们使用 `DOFade` 方法将 `CanvasGroup` 的透明度在 2 秒内渐变到 0.5。这可以用来实现淡入淡出效果，或者在需要时动态地显示或隐藏 UI 元素。

请注意，`CanvasGroup` 的 `DOFade` 方法不仅影响透明度，还会影响到其子元素的交互性（如按钮的可点击性）。如果你只想改变 UI 元素的视觉效果而不改变其交互性，你可能需要考虑使用其他方法，如改变 UI 元素的 `Image` 组件的 `color` 属性。