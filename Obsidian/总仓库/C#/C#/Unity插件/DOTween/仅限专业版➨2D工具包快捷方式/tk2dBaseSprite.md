`tk2dBaseSprite` 是 2D Toolkit (2DTK) 中的一个组件，用于处理精灵的渲染。DOTween 为 `tk2dBaseSprite` 提供了一些插值（Tweening）方法，允许你动态改变精灵的缩放和颜色。
## DOScale(Vector3 to, float duration)
改变 `tk2dBaseSprite` 的缩放到给定值。
- `Vector3 to`: 目标缩放值，可以为精灵的 X、Y 和 Z 轴指定不同的缩放值。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;

public class Tk2dSpriteScaleTweenExample : MonoBehaviour
{
    public tk2dBaseSprite mySprite;

    void Start()
    {
        // 在1秒内将精灵缩放到2倍大小
        mySprite.DOScale(new Vector3(2f, 2f, 2f), 1f);
    }
}
```

## DOScaleX/Y/Z(float to, float duration)
仅在选定的轴上改变 `tk2dBaseSprite` 的缩放。
- `float to`: 目标轴的缩放值。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内仅在X轴上将精灵缩放到2倍大小
mySprite.DOScaleX(2f, 1f);

// 在1秒内仅在Y轴上将精灵缩放到2倍大小
mySprite.DOScaleY(2f, 1f);

// 在1秒内仅在Z轴上将精灵缩放到2倍大小
mySprite.DOScaleZ(2f, 1f);
```

## DOColor(Color to, float duration)
改变 `tk2dBaseSprite` 的颜色到给定值。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将精灵颜色渐变到红色
mySprite.DOColor(Color.red, 1f);
```

## DOFade(float to, float duration)
改变 `tk2dBaseSprite` 的透明度（alpha）到给定值。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内将精灵透明度渐变到0.5
mySprite.DOFade(0.5f, 1f);
```