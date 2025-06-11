`Image` 组件是 `Graphic` 组件的一个子类，专门用于显示图像。DOTween 提供了一些专门针对 `Image` 组件的方法来进行插值（Tweening）。
## DOColor(Color to, float duration)
改变 `Image` 组件的颜色到指定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Image的颜色渐变到红色
myImage.DOColor(Color.red, 1f);
```

## DOFade(float to, float duration)
改变 `Image` 组件的透明度（alpha）到指定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Image的透明度渐变到0.5
myImage.DOFade(0.5f, 1f);
```

## DOFillAmount(float to, float duration)
改变 `Image` 组件的填充量（fillAmount）到指定值（0 到 1）。
- `float to`: 目标填充量。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Image的填充量渐变到0.5
myImage.DOFillAmount(0.5f, 1f);
```

## DOGradientColor(Gradient to, float duration)
通过给定的渐变改变 `Image` 组件的颜色。
- `Gradient to`: 目标渐变。
- `float duration`: 插值持续时间。
- 注意：此方法只使用渐变中的颜色，不包括透明度。
```csharp
Gradient myGradient = new Gradient();
// ... 配置渐变颜色
myImage.DOGradientColor(myGradient, 2f); // 在2秒内通过渐变改变颜色
```

# Blendable tweens
## DOBlendableColor(Color to, float duration)
允许多个颜色插值在同一目标上协同工作，而不是相互覆盖。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将Image的颜色渐变到绿色，允许与其他颜色插值协同工作
myImage.DOBlendableColor(Color.green, 1f);
```