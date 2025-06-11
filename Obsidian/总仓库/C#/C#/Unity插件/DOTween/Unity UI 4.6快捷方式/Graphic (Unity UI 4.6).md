`Graphic` 类型的组件（如 `Image`、`Text`、`RawImage` 等）可以使用 DOTween 来实现颜色和透明度的变化。
## DOColor(Color to, float duration)
改变 `Graphic` 组件的颜色到指定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI; // 确保你已经引用了 UnityEngine.UI 命名空间

public class GraphicColorTweenExample : MonoBehaviour
{
    public Graphic myGraphic;

    void Start()
    {
        // 在1秒内将Graphic的颜色渐变到红色
        myGraphic.DOColor(Color.red, 1f);
    }
}
```

## DOFade(float to, float duration)
改变 `Graphic` 组件的透明度（alpha）到指定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Graphic的透明度渐变到0.5
myGraphic.DOFade(0.5f, 1f);
```

# Blendable tweens
## DOBlendableColor(Color to, float duration)
允许多个颜色插值在同一目标上协同工作，而不是相互覆盖。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Graphic的颜色渐变到绿色，允许与其他颜色插值协同工作
myGraphic.DOBlendableColor(Color.green, 1f);
```