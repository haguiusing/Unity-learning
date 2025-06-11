`LayoutElement` 组件用于控制 UI 元素在布局中的尺寸行为。DOTween 提供了一些专门针对 `LayoutElement` 组件的方法来进行插值（Tweening）。
## DOFlexibleSize(Vector2 to, float duration, bool snapping)
改变 `LayoutElement` 组件的 `flexibleWidth` 和 `flexibleHeight` 到指定值。
- `Vector2 to`: 目标灵活尺寸，其中 x 代表 `flexibleWidth`，y 代表 `flexibleHeight`。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI; // 引用 UI 命名空间

public class LayoutElementTweenExample : MonoBehaviour
{
    public LayoutElement myLayoutElement;

    void Start()
    {
        // 在1秒内将LayoutElement的灵活尺寸渐变到新的值 (100, 200)
        myLayoutElement.DOFlexibleSize(new Vector2(100, 200), 1f, false);
    }
}
```

## DOMinSize(Vector2 to, float duration, bool snapping)
改变 `LayoutElement` 组件的 `minWidth` 和 `minHeight` 到指定值。
- `Vector2 to`: 目标最小尺寸，其中 x 代表 `minWidth`，y 代表 `minHeight`。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
// 在1秒内将LayoutElement的最小尺寸渐变到新的值 (50, 100)
myLayoutElement.DOMinSize(new Vector2(50, 100), 1f, false);
```

## DOPreferredSize(Vector2 to, float duration, bool snapping)
改变 `LayoutElement` 组件的 `preferredWidth` 和 `preferredHeight` 到指定值。
- `Vector2 to`: 目标首选尺寸，其中 x 代表 `preferredWidth`，y 代表 `preferredHeight`。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
// 在1秒内将LayoutElement的首选尺寸渐变到新的值 (150, 250)
myLayoutElement.DOPreferredSize(new Vector2(150, 250), 1f, false);
```