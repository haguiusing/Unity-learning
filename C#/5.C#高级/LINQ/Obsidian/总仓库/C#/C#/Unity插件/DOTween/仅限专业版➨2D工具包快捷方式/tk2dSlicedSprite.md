`tk2dSlicedSprite` 是 2D Toolkit (2DTK) 中的一个组件，用于处理切片精灵的渲染。DOTween 为 `tk2dSlicedSprite` 提供了一些插值（Tweening）方法，允许你动态改变切片精灵的尺寸。
## DOScale(Vector2 to, float duration)
改变 `tk2dSlicedSprite` 的尺寸到给定值。
- `Vector2 to`: 目标尺寸值，用于精灵的宽度和高度。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;

public class Tk2dSlicedSpriteScaleTweenExample : MonoBehaviour
{
    public tk2dSlicedSprite mySlicedSprite;

    void Start()
    {
        // 在1秒内将切片精灵的尺寸渐变到新的值 (宽度: 2, 高度: 3)
        mySlicedSprite.DOScale(new Vector2(2f, 3f), 1f);
    }
}
```

## DOScaleX/Y(float to, float duration)
仅在选定的轴上改变 `tk2dSlicedSprite` 的尺寸。
- `float to`: 目标轴的尺寸值。
- `float duration`: 插值持续时间。
```csharp
// 在1秒内仅在X轴上将切片精灵的尺寸渐变到2
mySlicedSprite.DOScaleX(2f, 1f);

// 在1秒内仅在Y轴上将切片精灵的尺寸渐变到3
mySlicedSprite.DOScaleY(3f, 1f);
```