`OutlineProperties` 类用于控制 `Text` 组件的轮廓效果，这是 Unity UI 系统中的一部分。DOTween Pro 扩展提供了几个专门针对 `OutlineProperties` 的方法来进行插值（Tweening）。
## DOBlurShift(float to, float duration, bool snapping = false)
改变轮廓的模糊偏移量。
- `float to`: 目标模糊偏移量。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OutlinePropertiesTweenExample : MonoBehaviour
{
    public Text myText;

    void Start()
    {
        // 在1秒内将Text的轮廓模糊偏移量渐变到5
        myText.GetComponent<Outline>().effectColor.DOBlurShift(5f, 1f);
    }
}
```

## DOColor(Color to, float duration)
改变轮廓的颜色。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Text的轮廓颜色渐变到红色
myText.GetComponent<Outline>().effectColor.DOColor(Color.red, 1f);
```

## DODilateShift(float to, float duration, bool snapping = false)
改变轮廓的膨胀偏移量。
- `float to`: 目标膨胀偏移量。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
// 在1秒内将Text的轮廓膨胀偏移量渐变到3
myText.GetComponent<Outline>().effectDistance.ODilateShift(3f, 1f);
```

## DOFade(float to, float duration)
改变轮廓的透明度。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Text的轮廓透明度渐变到0.5
myText.GetComponent<Outline>().effectColor.DOFade(0.5f, 1f);
```

## DOFloat(float to, float duration)
改变轮廓的某个浮点属性，如膨胀或模糊偏移。
- `float to`: 目标浮点值。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Text的轮廓膨胀偏移量渐变到2
myText.GetComponent<Outline>().effectDistance.DOFloat(2f, 1f);
```

## DOVector(Vector4 to, float duration)
改变轮廓的 `Vector4` 属性，这可以是颜色带透明度的属性。
- `Vector4 to`: 目标 `Vector4`，通常用于颜色和透明度。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Text的轮廓颜色和透明度渐变到新的值
myText.GetComponent<Outline>().effectColor.DOVector(new Vector4(1f, 0f, 0f, 0.5f), 1f);
```