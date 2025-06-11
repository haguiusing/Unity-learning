`Outline` 组件用于给 `Text` 或 `Image` 等 UI 元素添加轮廓效果。DOTween 提供了专门针对 `Outline` 组件的方法来进行插值（Tweening）。
## DOColor(Color to, float duration)
改变 `Outline` 组件的颜色到指定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI; // 引用 UI 命名空间

public class OutlineColorTweenExample : MonoBehaviour
{
    public Outline myOutline;

    void Start()
    {
        // 在1秒内将Outline的颜色渐变到红色
        myOutline.DOColor(Color.red, 1f);
    }
}
```

## DOFade(float to, float duration)
改变 `Outline` 组件的透明度（alpha）到指定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Outline的透明度渐变到0.5
myOutline.DOFade(0.5f, 1f);
```