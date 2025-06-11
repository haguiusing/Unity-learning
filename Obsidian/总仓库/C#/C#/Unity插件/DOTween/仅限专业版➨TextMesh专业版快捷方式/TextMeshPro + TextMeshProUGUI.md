TextMeshPro (TMP) 和 TextMeshProUGUI 是用于处理文本渲染的组件，它们提供了丰富的文本格式化和动画选项。DOTween 为这些组件提供了多种插值（Tweening）方法，允许你动态改变文本的各种属性。
## DOScale(float to, float duration)
改变 `TextMeshPro` 或 `TextMeshProUGUI` 的缩放到给定值。
- `float to`: 目标缩放值。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;
using TMPro;

public class TextMeshProScaleTweenExample : MonoBehaviour
{
    public TextMeshProUGUI myTextMeshPro;

    void Start()
    {
        // 在1秒内将文本缩放到2倍大小
        myTextMeshPro.DOScale(2f, 1f);
    }
}
```

## DOColor(Color to, float duration)
改变 `TextMeshPro` 或 `TextMeshProUGUI` 的颜色到给定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将文本颜色渐变到红色
myTextMeshPro.DOColor(Color.red, 1f);
```
## DOCounter(int fromValue, int endValue, float duration, bool addThousandsSeparator = true, CultureInfo culture = null)
将文本从一整数插值到另一个整数。
- `int fromValue`: 起始值。
- `int endValue`: 结束值。
- `float duration`: 插值持续时间。
- `bool addThousandsSeparator`: 是否添加千位分隔符。
- `CultureInfo culture`: 使用的文化信息。
```csharp
// 在2秒内将文本从100渐变到1000，添加千位分隔符
myTextMeshPro.DOCounter(100, 1000, 2f, true);
```

## DOFaceColor(Color to, float duration)
改变 `TextMeshPro` 的面部颜色到给定值。
- `Color to`: 目标面部颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将面部颜色渐变到蓝色
myTextMeshPro.DOFaceColor(Color.blue, 1f);
```

## DOFaceFade(float to, float duration)
改变 `TextMeshPro` 的面部透明度（alpha）到给定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将面部透明度（alpha）渐变到透明
myTextMeshPro.DOFaceColor(0, 1f);
```

## DOFade(float to, float duration)
改变 `TextMeshPro` 或 `TextMeshProUGUI` 的透明度（alpha）到给定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将文本透明度渐变到0.5
myTextMeshPro.DOFade(0.5f, 1f);
```

## DOFontSize(float to, float duration)
改变 `TextMeshPro` 或 `TextMeshProUGUI` 的字体大小到给定值。
- `float to`: 目标字体大小。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将字体大小渐变到30
myTextMeshPro.DOFontSize(30f, 1f);
```

## DOGlowColor(Color to, float duration)
改变 `TextMeshPro` 的发光颜色到给定值。
- `Color to`: 目标发光颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将发光颜色渐变到黄色
myTextMeshPro.DOGlowColor(Color.yellow, 1f);
```
## DOMaxVisibleCharacters(int to, float duration)
改变 `TextMeshPro` 的最大可见字符数到给定值。
- `int to`: 目标最大可见字符数。
- `float duration`: 插值持续时间。 
```csharp
// 在1秒内将最大可见字符数渐变到10
myTextMeshPro.DOMaxVisibleCharacters(10, 1f);
```
## DOOutlineColor(Color to, float duration)
改变 `TextMeshPro` 的轮廓颜色到给定值。
- `Color to`: 目标轮廓颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将轮廓颜色渐变到绿色
myTextMeshPro.DOOutlineColor(Color.green, 1f);
```

## DOText(string to, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
将 `TextMeshPro` 或 `TextMeshProUGUI` 的文本插值到给定值。
- `string to`: 目标文本。
- `float duration`: 插值持续时间。
- `bool richTextEnabled`: 是否启用富文本解析。
- `ScrambleMode scrambleMode`: 使用的混淆模式类型。
- `string scrambleChars`: 用于自定义混淆的字符字符串。
```csharp
// 在2秒内将文本渐变到"Hello, DOTween!"，启用富文本解析
myTextMeshPro.DOText("Hello, DOTween!", 2f);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dotext.gif)