在 DOTween 中，`TweenParams` 类似于 HOTween 中的 `TweenParms`，它是一个用于存储可以应用到多个 Tweens 上的设置的工具。与 HOTween 的不同之处在于，在 DOTween 中，你可以直接在 Tween 上进行链式设置，而 `TweenParams` 仅作为一个额外的工具类存在。

以下是如何使用 `TweenParams` 的步骤：
1. **创建 TweenParams 实例**: 实例化一个新的 `TweenParams` 对象。
2. **设置 TweenParams**: 使用链式方法为 `TweenParams` 设置各种参数。
3. **应用 TweenParams**: 使用 `SetAs` 方法将 `TweenParams` 应用到一个或多个 Tweens 上。

### 使用示例
```csharp
using DG.Tweening;
using UnityEngine;

public class TweenParamsExample : MonoBehaviour
{
    void Start()
    {
        // 创建并设置 TweenParams 实例
        TweenParams tParms = new TweenParams()
            .SetLoops(-1) // 设置为无限循环
            .SetEase(Ease.OutElastic); // 设置缓动类型为弹性缓动

        // 应用 TweenParams 到两个 Tweens 上
        transform.DOMoveX(15, 1).SetAs(tParms);
        transform.DOMoveY(10, 1).SetAs(tParms);
    }

    void MyCallback()
    {
        Debug.Log("Tween completed");
    }
}
```

在这个示例中，我们首先创建了一个 `TweenParams` 实例，并为其设置了无限循环和弹性缓动。然后，我们将这个 `TweenParams` 应用到了两个不同的 `DOMove` Tweens 上。

