DOTween 库中用于处理 Unity 中光源（Light）和颜色插值的函数。
## DOColor(Color to, float duration) 
改变光源的颜色。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
light.DOColor(Color.red, 1f); // 在1秒内将光源颜色改变为红色
```

## DOIntensity(float to, float duration) 
改变光源的强度。
- `float to`: 目标强度值。
- `float duration`: 插值持续时间。
```csharp
light.DOIntensity(2f, 1f); // 在1秒内将光源强度改变为2
```

## DOShadowStrength(float to, float duration) 
改变光源的阴影强度。
- `float to`: 目标阴影强度值，范围从0（无阴影）到1（完全阴影）。
- `float duration`: 插值持续时间。
```csharp
light.DOShadowStrength(0.5f, 1f); // 在1秒内将光源的阴影强度改变为0.5
```

## DOBlendableColor(Color to, float duration) 
允许多个颜色插值在同一个目标上协同工作，而不是相互冲突。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
light.DOBlendableColor(Color.green, 1f); // 在1秒内将光源的颜色平滑过渡到绿色
```
`DOBlendableColor` 特别有用，当你需要在同一个对象上同时运行多个颜色插值时。传统的 `DOColor` 插值可能会相互覆盖，而 `DOBlendableColor` 则允许它们混合在一起，创造出更复杂的颜色变化效果。

使用 `DOBlendableColor` 的示例：
```csharp
// 你可以在不同的脚本或不同的时间点调用DOBlendableColor
// 这些颜色插值将会混合在一起，而不是相互覆盖
light.DOBlendableColor(Color.red, 1f);
light.DOBlendableColor(Color.blue, 1f);
```

在这个示例中，两个颜色插值将同时应用于 `myRenderer`，它们会根据各自的插值进度混合颜色，创造出一个从当前颜色到红色和蓝色混合的颜色的过渡效果。这种混合是动态的，取决于两个插值的相对进度。