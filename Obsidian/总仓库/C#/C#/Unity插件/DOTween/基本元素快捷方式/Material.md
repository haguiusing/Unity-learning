这些 DOTween 方法用于对 Unity 中的各种材质属性进行插值（Tweening）。

# Color(Vector4)
## DOColor(Color to, float duration)
改变目标颜色。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
myRenderer.material.DOColor(Color.red, 1f); // 在1秒内改变材质颜色为红色
```

## DOColor(Color to, string property, float duration)
改变目标的命名颜色属性。
- `Color to`: 目标颜色。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。
```csharp
myMaterial.DOColor(Color.green, "_SpecColor", 1f); // 在1秒内改变材质的Specular颜色为绿色
```

## DOColor(Color to, int propertyID, float duration)
改变目标的命名颜色属性。
- `Color to`: 目标颜色。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Fade(float)
## DOFade(float to, float duration)
改变目标的透明度。
- `float to`: 目标透明度（0到1之间）。
- `float duration`: 插值持续时间。
```csharp
myRenderer.material.DOFade(0f, 1f); // 在1秒内完全透明
```

## DOFade(float to, string property, float duration)
改变目标的命名透明度属性。
- `float to`: 目标透明度。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。

## DOFade(float to, int propertyID, float duration)
改变目标的命名透明度属性。
- `float to`: 目标透明度。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Float
## DOFloat(float to, string property, float duration)
改变目标的命名浮点属性。
- `float to`: 目标浮点值。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。

## DOFloat(float to, int propertyID, float duration)
改变目标的命名浮点属性。
- `float to`: 目标浮点值。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Gradient
## DOGradientColor(Gradient to, float duration)
通过给定的渐变改变目标颜色。
- `Gradient to`: 目标渐变。
- `float duration`: 插值持续时间。
```csharp
Gradient myGradient = new Gradient();
// ... configure your gradient
myRenderer.material.DOGradientColor(myGradient, 2f);
```

## DOGradientColor(Gradient to, string property, float duration)
通过给定的渐变改变目标的命名颜色属性。
- `Gradient to`: 目标渐变。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。
```cs
// Tween the specular value of a material
﻿﻿﻿﻿﻿﻿﻿myMaterial.DOGradientColor(myGradient, "_SpecColor", 1);
```

## DOGradientColor(Gradient to, int propertyID, float duration)
通过给定的渐变改变目标的命名颜色属性。
- `Gradient to`: 目标渐变。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Offset
## DOOffset(Vector2 to, float duration)
改变目标的纹理偏移。
- `Vector2 to`: 目标偏移量。
- `float duration`: 插值持续时间。

## DOOffset(Vector2 to, string property, float duration)
改变目标的命名纹理偏移属性。
- `Vector2 to`: 目标偏移量。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。

## DOOffset(Vector2 to, int propertyID, float duration)
改变目标的命名纹理偏移属性。
- `Vector2 to`: 目标偏移量。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Tiling
## DOTiling(Vector2 to, float duration)
改变目标的纹理缩放。
- `Vector2 to`: 目标缩放量。
- `float duration`: 插值持续时间。

## DOTiling(Vector2 to, string property, float duration)
改变目标的命名纹理缩放属性。
- `Vector2 to`: 目标缩放量。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。

## DOTiling(Vector2 to, int propertyID, float duration)
改变目标的命名纹理缩放属性。
- `Vector2 to`: 目标缩放量。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。
# Vector4
## DOVector(Vector4 to, string property, float duration)
改变目标的命名向量属性。
- `Vector4 to`: 目标向量。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。

## DOVector(Vector4 to, int propertyID, float duration)
改变目标的命名向量属性。
- `Vector4 to`: 目标向量。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

# Blendable tweens
Blendable tweens 是 DOTween 提供的一种特殊类型的插值，它们允许多个插值效果在同一材质的同一属性上协同工作，而不是相互覆盖。这对于创建复杂的材质动画非常有用，例如，当你想要同时改变一个材质的多个颜色属性时。

## DOBlendableColor(Color to, float duration)
改变材质的颜色到给定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。

## DOBlendableColor(Color to, string property, float duration)
改变材质的命名颜色属性到给定值。
- `Color to`: 目标颜色。
- ==`string property`: 要插值的属性名称。==
- `float duration`: 插值持续时间。
```cs
// Tween the specular value of a material
﻿﻿﻿﻿﻿﻿﻿myMaterial.DOBlendableColor(Color.green, "_SpecColor", 1);
```

## DOBlendableColor(Color to, int propertyID, float duration)
改变材质的命名颜色属性到给定值。
- `Color to`: 目标颜色。
- ==`int propertyID`: 要插值的属性ID。==
- `float duration`: 插值持续时间。

### 使用示例：
假设你有一个材质 `myMaterial`，你想要在 1 秒内改变它的基础颜色和镜面颜色（Specular Color）。
```cs
using DG.Tweening;
using UnityEngine;

public class MaterialBlendableTweenExample : MonoBehaviour
{
    public Material myMaterial;

    void Start()
    {
        // 改变材质的基础颜色为红色，持续时间为1秒
        myMaterial.DOBlendableColor(Color.red, "_Color", 1f);

        // 同时，改变材质的镜面颜色为绿色，持续时间为1秒
        // 注意：这里假设 "_SpecColor" 是材质中镜面颜色属性的名称
        myMaterial.DOBlendableColor(Color.green, "_SpecColor", 1f);
    }
}
```
