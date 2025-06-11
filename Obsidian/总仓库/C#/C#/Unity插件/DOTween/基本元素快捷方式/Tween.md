这些实际上是其他tween属性之间的快捷方式。我打赌你不认为你能做到：P
允许你对一个正在运行的 Tween 的时间缩放（timeScale）属性进行插值（Tweening）。这意味着你可以动态地改变一个 Tween 的速度，使其在运行过程中加速或减速。
## DOTimeScale(float toTimeScale, float duration) 
### 参数说明：
1. **float toTimeScale**: 目标时间缩放值。这个值决定了 Tween 的新速度。例如，1 表示正常速度，0.5 表示速度减半，2 表示速度加倍。
2. **float duration**: 插值持续时间，即改变时间缩放值所需的时间。

### 使用示例：
假设你有一个名为 `myTween` 的 Tween，你想要在 2 秒内将其时间缩放值从当前值改变到 0.5。
```csharp
using DG.Tweening;
using UnityEngine;

public class TweenTimeScaleExample : MonoBehaviour
{
    void Start()
    {
        // 创建一个简单的 Tween，比如改变一个物体的位置
        Tween myTween = transform.DOMove(new Vector3(5, 0, 0), 5f);

        // 在2秒内将这个 Tween 的时间缩放值改变到0.5，即速度减半
        myTween.DOTimeScale(0.5f, 2f);
    }
}
```

在这个示例中，我们首先创建了一个 `DOMove` Tween，它将在 5 秒内将 `Transform` 移动到新的位置。然后，我们使用 `DOTimeScale` 方法在 2 秒内将这个 Tween 的时间缩放值改变到 0.5，这意味着在改变时间缩放值的过程中，Tween 的速度将减半。

请注意，`DOTimeScale` 方法可以应用于任何 Tween，包括 `DOMove`、`DOFade`、`DORotate` 等。这为动画效果的创造提供了更大的灵活性和控制力。通过动态调整 Tween 的时间缩放值，你可以实现更复杂和动态的动画效果。