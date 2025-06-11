在 Unity 中，使用 TextMeshPro 进行逐字符动画是一种高级技术，它允许你对文本中的每个字符单独进行动画处理。这可以通过 DOTween 的 `DOTweenTMPAnimator` 包装器实现，它为 TextMeshPro 对象提供了额外的动画控制。以下是如何使用 `DOTweenTMPAnimator` 进行逐字符动画的步骤和示例：
### 创建 DOTweenTMPAnimator 包装器
首先，你需要为你的 `TMP_Text` 对象创建一个 `DOTweenTMPAnimator` 包装器。这允许 DOTween 跟踪所有变化并更有效地应用修改。
```csharp
DOTweenTMPAnimator animator = new DOTweenTMPAnimator(myTextMeshProTextField);
```

### 逐字符动画示例
#### 示例 1：单个字符的缩放动画
如果你想对文本中的单个字符进行缩放动画，可以使用 `DOScaleChar` 方法。这个方法允许你指定字符索引、目标缩放值和动画持续时间。
```csharp
// 假设我们想要对索引为 5 的字符进行缩放动画
int characterIndex = 5;
float scaleValue = 2f; // 目标缩放值
float duration = 1f; // 动画持续时间

Tween tween = animator.DOScaleChar(characterIndex, scaleValue, duration)
    .SetEase(Ease.OutBack); // 设置缓动类型为 OutBack
```

#### 示例 2：文本中所有字符的入场动画
如果你想让文本中的所有字符从顶部滑入，你可以使用 `DOOffsetChar` 方法，并将其添加到一个 `Sequence` 中以更好地控制动画顺序。
```csharp
DOTweenTMPAnimator animator = new DOTweenTMPAnimator(myTextMeshProTextField);
Sequence sequence = DOTween.Sequence();

for (int i = 0; i < animator.textInfo.characterCount; ++i)
{
    if (!animator.textInfo.characterInfo[i].isVisible) continue; // 跳过不可见的字符

    Vector3 currCharOffset = animator.GetCharOffset(i); // 获取当前字符的偏移
    sequence.Join(animator.DOOffsetChar(i, currCharOffset + new Vector3(0, 30, 0), 1)); // 从顶部向下偏移30单位
}
```

在这个示例中，我们遍历了文本中的每个字符，检查它是否可见，然后计算其当前偏移，并设置一个新的偏移，使其从顶部滑入。所有这些动画被加入到一个 `Sequence` 中，这样可以确保它们按顺序执行。

### 注意事项
- 使用 `animator.textInfo.characterCount` 来循环遍历 `TMP_Text` 对象中的字符，忽略不可见的元素。
- 逐字符动画可以非常灵活，允许你创建复杂的文本动画效果，但也需要更多的计算资源。合理使用，避免在不必要的情况下对大量文本进行逐字符动画。
- 确保在动画开始之前，你的 TextMeshPro 对象已经正确设置并显示在屏幕上。

## ● DOTweenTMPAnimator ⇨ Setup Methods
### Refresh()
这个方法用于刷新动画器的文本数据，并重置所有变换数据。当你在 `TMP_Text` 对象中更改文本时，这个方法会自动被调用，确保动画器的数据与当前文本状态同步。

- **用途**：在文本内容发生变化后更新动画器的状态。
- **自动调用**：每次更改 `TMP_Text` 对象中的文本时，DOTween 会自动调用此方法。

### Reset()
这个方法用于重置所有由 `DOTweenTMPAnimator` 引起的变形。这包括由动画引起的任何缩放、旋转或位置变化。

- **用途**：当你想要将文本恢复到其原始状态，移除所有通过 `DOTweenTMPAnimator` 应用的动画效果时使用。
- **使用场景**：例如，在一个动画循环的结尾重置文本，或者在用户触发某个操作时重置文本状态。

### 使用示例
假设你有一个 `TextMeshProUGUI` 组件，你想要在文本更新后刷新动画器，并在特定条件下重置文本的变形。
```csharp
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextMeshProAnimatorExample : MonoBehaviour
{
    public TextMeshProUGUI myTextMeshPro;

    void Start()
    {
        // 初始化 DOTweenTMPAnimator
        DOTweenTMPAnimator animator = new DOTweenTMPAnimator(myTextMeshPro);

        // 应用一些动画
        animator.DOFade(0.5f, 1f); // 淡出效果
        animator.DOColor(Color.red, 1f); // 颜色渐变到红色

        // 模拟文本更新
        myTextMeshPro.text = "New Text!";
        animator.Refresh(); // 手动刷新动画器，尽管这通常不是必需的，因为 DOTween 会自动处理

        // 重置所有变形
        animator.Reset();
    }
}
```

在这个示例中，我们首先创建了一个 `DOTweenTMPAnimator` 实例，并对其应用了一些基本动画。然后，我们更改了 `TextMeshProUGUI` 的文本，并手动调用了 `Refresh()` 方法来更新动画器的状态。最后，我们调用了 `Reset()` 方法来重置所有动画效果，使文本恢复到其原始状态。

这些方法为使用 DOTween 与 TextMeshPro 一起工作提供了更大的灵活性和控制，允许开发者在文本更新或需要时精确地管理动画状态。

## ● DOTweenTMPAnimator ⇨ Per-character Tweens
DOTween 的 `DOTweenTMPAnimator` 类为 TextMeshPro (TMP) 文本提供了逐字符动画的能力。这意味着你可以对文本中的每个字符单独应用动画效果，如淡入淡出、颜色变化、位置偏移、旋转和缩放等。
### DOFadeChar(int charIndex, float endValue, float duration)
对指定索引的字符应用透明度变化。
- `int charIndex`: 字符的索引。
- `float endValue`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 动画持续时间。
```csharp
animator.DOFadeChar(0, 0.5f, 1f); // 将第一个字符的透明度在1秒内渐变到0.5
```

### DOColorChar(int charIndex, Color endValue, float duration)
对指定索引的字符应用颜色变化。
- `int charIndex`: 字符的索引。
- `Color endValue`: 目标颜色。
- `float duration`: 动画持续时间。
```csharp
animator.DOColorChar(1, Color.red, 1f); // 将第二个字符的颜色在1秒内渐变到红色
```

### DOOffsetChar(int charIndex, Vector3 endValue, float duration)
对指定索引的字符应用位置偏移变化。
- `int charIndex`: 字符的索引。
- `Vector3 endValue`: 目标偏移量。
- `float duration`: 动画持续时间。
```csharp
animator.DOOffsetChar(2, new Vector3(0.2f, 0.1f, 0f), 1f); // 将第三个字符的位置在1秒内偏移
```
### DORotateChar(int charIndex, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
对指定索引的字符应用旋转变化。
- `int charIndex`: 字符的索引。
- `Vector3 endValue`: 目标旋转角度（以度为单位）。
- `float duration`: 动画持续时间。
- `RotateMode mode`: 旋转模式。
```csharp
animator.DORotateChar(3, new Vector3(90, 0, 0), 1f, RotateMode.Fast); // 将第四个字符的旋转在1秒内渐变
```

### DOScaleChar(int charIndex, float endValue, float duration)
对指定索引的字符应用缩放变化。
- `int charIndex`: 字符的索引。
- `float endValue`: 目标缩放值。
- `float duration`: 动画持续时间。
```csharp
animator.DOScaleChar(4, 2f, 1f); // 将第五个字符的缩放在1秒内放大到2倍
```
### DOPunchCharOffset(int charIndex, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
对指定索引的字符应用冲击偏移效果。
- `int charIndex`: 字符的索引。
- `Vector3 punch`: 冲击的方向和强度。
- `float duration`: 动画持续时间。
- `int vibrato`: 每秒振动次数。
- `float elasticity`: 弹性系数。
```csharp
animator.DOPunchCharOffset(5, new Vector3(0.1f, 0.2f, 0f), 1f, 5, 0.7f); // 对第六个字符应用冲击偏移效果
```
### DOPunchCharRotation(int charIndex, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
对指定索引的字符应用旋转冲击效果。
- `int charIndex`: 字符的索引。
- `Vector3 punch`: 冲击的方向和强度。
- `float duration`: 动画持续时间。
- `int vibrato`: 每秒振动次数。
- `float elasticity`: 弹性系数，表示向量在反弹时超出起始大小的程度。
```csharp
animator.DOPunchCharRotation(0, new Vector3(0, 90, 0), 1f, 5, 0.5f); // 对第一个字符应用旋转冲击
```
### DOPunchCharScale(int charIndex, Vector3/float punch, float duration, int vibrato = 10, float elasticity = 1)
对指定索引的字符应用缩放冲击效果。
- `int charIndex`: 字符的索引。
- `Vector3/float punch`: 缩放冲击的强度。
- `float duration`: 动画持续时间。
- `int vibrato`: 每秒振动次数。
- `float elasticity`: 弹性系数。
```csharp
animator.DOPunchCharScale(1, 2f, 1f, 5, 0.5f); // 对第二个字符应用缩放冲击
```
### DOShakeCharOffset(int charIndex, float duration, Vector3/float strength, int vibrato = 10, float randomness = 90, bool fadeOut = true)
对指定索引的字符应用偏移震动效果。
- `int charIndex`: 字符的索引。
- `float duration`: 动画持续时间。
- `Vector3/float strength`: 震动强度。
- `int vibrato`: 每秒振动次数。
- `float randomness`: 震动的随机性。
- `bool fadeOut`: 是否在动画持续时间内平滑淡出。
```csharp
animator.DOShakeCharOffset(2, 1f, new Vector3(0.1f, 0.2f, 0f), 10, 90f, true); // 对第三个字符应用偏移震动
```
### DOShakeCharRotation(int charIndex, float duration, Vector3 strength, int vibrato = 10, float randomness = 90, bool fadeOut = true)
对指定索引的字符应用旋转震动效果。
- `int charIndex`: 字符的索引。
- `float duration`: 动画持续时间。
- `Vector3 strength`: 旋转震动的强度。
- `int vibrato`: 每秒振动次数。
- `float randomness`: 震动的随机性。
- `bool fadeOut`: 是否在动画持续时间内平滑淡出。
```csharp
animator.DOShakeCharRotation(3, 1f, new Vector3(30, 0, 0), 10, 90f, true); // 对第四个字符应用旋转震动
```
### DOShakeCharScale(int charIndex, Vector3/float duration, Vector3/float strength, int vibrato = 10, float randomness = 90, bool fadeOut = true)
对指定索引的字符应用缩放震动效果。
- `int charIndex`: 字符的索引。
- `Vector3/float duration`: 动画持续时间。
- `Vector3/float strength`: 缩放震动的强度。
- `int vibrato`: 每秒振动次数。
- `float randomness`: 震动的随机性。
- `bool fadeOut`: 是否在动画持续时间内平滑淡出。
```csharp
animator.DOShakeCharScale(4, 1f, new Vector3(0.5f, 0.5f, 0f), 10, 90f, true); // 对第五个字符应用缩放震动
```

## ● DOTweenTMPAnimator ⇨ Extra per-word/span methods
在 DOTween for TextMeshPro 中，`DOTweenTMPAnimator` 类提供了一些额外的方法来对文本中的单词或字符范围进行变形，而不是对它们进行动画处理。
### SkewSpanX(int fromCharIndex, int toCharIndex, float skewFactor, bool skewTop = true)
对字符范围在 X 轴上进行倾斜变形。
- `int fromCharIndex`: 要倾斜的字符范围的起始索引。
- `int toCharIndex`: 要倾斜的字符范围的结束索引。
- `float skewFactor`: 倾斜因子，正值表示向右倾斜，负值表示向左倾斜。
- `bool skewTop`: 如果为 `true`，则倾斜字符范围的顶部，否则倾斜底部。
```csharp
// 从第一个字符到第三个字符，在X轴上向右倾斜0.5单位
animator.SkewSpanX(0, 2, 0.5f);
```
### SkewSpanY(int fromCharIndex, int toCharIndex, float skewFactor, TMPSkewSpanMode mode = TMPSkewSpanMode.Default, bool skewRight = true)
对字符范围在 Y 轴上进行倾斜变形。
- `int fromCharIndex`: 要倾斜的字符范围的起始索引。
- `int toCharIndex`: 要倾斜的字符范围的结束索引。
- `float skewFactor`: 垂直倾斜因子，正值表示向上倾斜，负值表示向下倾斜。
- `TMPSkewSpanMode mode`: 倾斜模式，可以是 `TMPSkewSpanMode.Default` 或 `TMPSkewSpanMode.CwY`。
- `bool skewRight`: 如果为 `true`，则倾斜字符范围的右侧，否则倾斜左侧。
```csharp
// 从第二个字符到第四个字符，在Y轴上向上倾斜1单位
animator.SkewSpanY(1, 3, 1f);
```

## ● DOTweenTMPAnimator ⇨ Extra per-character methods
在 DOTween for TextMeshPro (TMP) 中，`DOTweenTMPAnimator` 类提供了一些额外的逐字符方法，这些方法可以用来直接改变或获取文本字符的信息，而不是对它们进行动画处理。
### Color GetCharColor(int charIndex)
获取指定字符的当前颜色。
- `int charIndex`: 字符的索引。
```csharp
Color charColor = animator.GetCharColor(0); // 获取第一个字符的颜色
```
### Vector3 GetCharOffset(int charIndex)
获取指定字符的当前偏移量。
- `int charIndex`: 字符的索引。
```csharp
Vector3 charOffset = animator.GetCharOffset(0); // 获取第一个字符的偏移量
```

### Vector3 GetCharRotation(int charIndex)
获取指定字符的当前旋转。
- `int charIndex`: 字符的索引。
```csharp
Vector3 charRotation = animator.GetCharRotation(0); // 获取第一个字符的旋转
```

### Vector3 GetCharScale(int charIndex)
获取指定字符的当前缩放。
- `int charIndex`: 字符的索引。
```csharp
Vector3 charScale = animator.GetCharScale(0); // 获取第一个字符的缩放
```

### ResetVerticesShift(int charIndex)
重置通过 `ShiftCharVertices` 应用到指定字符的顶点偏移。
- `int charIndex`: 字符的索引。
```csharp
animator.ResetVerticesShift(0); // 重置第一个字符的顶点偏移
```
### SetCharColor(int charIndex, Color color)
立即设置指定字符的颜色。
- `int charIndex`: 字符的索引。
- `Color color`: 要设置的颜色。
```csharp
animator.SetCharColor(0, Color.red); // 将第一个字符的颜色设置为红色
```

### SetCharOffset(int charIndex, Vector3 offset)
立即设置指定字符的偏移量。
- `int charIndex`: 字符的索引。
- `Vector3 offset`: 要设置的偏移量。
```csharp
animator.SetCharOffset(0, new Vector3(0.1f, 0.2f, 0f)); // 将第一个字符的偏移设置为 (0.1, 0.2, 0)
```

### SetCharRotation(int charIndex, Vector3 rotation)
立即设置指定字符的旋转。
- `int charIndex`: 字符的索引。
- `Vector3 rotation`: 要设置的旋转。
```csharp
animator.SetCharRotation(0, new Vector3(0, 90, 0)); // 将第一个字符的旋转设置为 Y 轴 90 度
```

### SetCharScale(int charIndex, Vector3 scale)
立即设置指定字符的缩放。
- `int charIndex`: 字符的索引。
- `Vector3 scale`: 要设置的缩放。
```csharp
animator.SetCharScale(0, new Vector3(2f, 2f, 2f)); // 将第一个字符的缩放设置为 2 倍
```
### ShiftCharVertices(int charIndex, Vector3 topLeftShift, Vector3 topRightShift, Vector3 bottomLeftShift, Vector3 bottomRightShift)
立即通过给定的因子偏移指定字符的顶点。
- `int charIndex`: 字符的索引。
- `Vector3 topLeftShift`: 左上角的偏移量。
- `Vector3 topRightShift`: 右上角的偏移量。
- `Vector3 bottomLeftShift`: 左下角的偏移量。
- `Vector3 bottomRightShift`: 右下角的偏移量。
```csharp
animator.ShiftCharVertices(0, new Vector3(0.05f, 0.1f, 0), new Vector3(-0.05f, 0.1f, 0), new Vector3(0.05f, -0.1f, 0), new Vector3(-0.05f, -0.1f, 0)); // 偏移第一个字符的顶点
```

### SkewCharX(int charIndex, float skewFactor, bool skewTop = true)
沿 X 轴水平倾斜指定的字符。
- `int charIndex`: 字符的索引。
- `float skewFactor`: 倾斜量。
- `bool skewTop`: 如果为 `true`，则倾斜字符的顶部，否则倾斜底部。
```csharp
animator.SkewCharX(0, 0.5f); // 将第一个字符沿 X 轴向右倾斜 0.5 单位
```

### SkewCharY(int charIndex, float skewFactor, bool skewRight = true, bool fixedSkew = false)
沿 Y 轴水平倾斜指定的字符。
- `int charIndex`: 字符的索引。
- `float skewFactor`: 倾斜量。
- `bool skewRight`: 如果为 `true`，则倾斜字符的右侧，否则倾斜左侧。
- `bool fixedSkew`: 如果为 `true`，则精确应用给定的倾斜因子，否则根据字符的宽高比调整倾斜量。
```csharp
animator.SkewCharY(0, 0.5f); // 将第一个字符沿 Y 轴向右倾斜 0.5 单位
```