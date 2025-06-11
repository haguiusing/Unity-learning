`DOFade` 和 `DOPitch` 是 DOTween 库中用于对 `AudioSource` 组件的音量（volume）和音调（pitch）进行插值的方法。

## DOFade(float to, float duration)
将 AudioSource 补间 `volume`到给定的值..

### 参数说明：
1. **float to**：这是你想要将音量或音调插值到的目标值。
    
    - 对于 `DOFade`，这个值通常在 0（静音）到 1（最大音量）之间。
    - 对于 `DOPitch`，这个值表示音调的倍数，1 表示正常音调，小于 1 表示降低音调，大于 1 表示提高音调。
2. **float duration**：这是插值过程持续的时间，单位是秒。
    

### 使用示例：
假设你有一个 `AudioSource` 组件，你想要在 2 秒内将其音量从当前值渐变到 0（静音），然后在接下来的 2 秒内渐变回原始音量。
```cs
using DG.Tweening;
using UnityEngine;

public class AudioTweenExample : MonoBehaviour
{
    public AudioSource audioSource; // 你的 AudioSource 组件

    private void Start()
    {
        // 渐变音量到 0，持续时间 2 秒
        audioSource.DOFade(0, 2f);

        // 等待 2 秒后渐变回原始音量，持续时间 2 秒
        // 注意：这里使用 SetEase 设置缓动类型，SetLoops 设置循环
        audioSource.DOFade(1, 2f).SetEase(Ease.InOutSine).SetDelay(2).SetLoops(-1, LoopType.Yoyo);
    }
}
```
在这个示例中，我们首先使用 `DOFade` 方法在 2 秒内将音量渐变到 0。然后，我们链式调用了另一个 `DOFade` 方法，将音量渐变回原始值，同样持续 2 秒。我们使用 `SetEase` 方法设置了缓动类型为 `Ease.InOutSine`，这意味着过渡将开始和结束时较慢，中间较快。使用 `SetDelay` 方法设置了延迟时间为 2 秒，这样第二个渐变将在第一个渐变完成后开始。最后，我们使用 `SetLoops` 方法设置了循环，`LoopType.Yoyo` 表示 Tween 将在到达目标值后反向回到起始值，然后重复这个过程。

## DOPitch(float to, float duration)
将 AudioSource 补间 `pitch`到给定的值..
```cs
// 渐变音调到 1.5（比原始音调高），持续时间 2 秒
audioSource.DOPitch(1.5f, 2f).SetEase(Ease.InOutSine);
```
在这个示例中，我们使用 `DOPitch` 方法在 2 秒内将音调渐变到 1.5 倍，这将使声音的音调提高。同样，我们使用了 `Ease.InOutSine` 作为缓动类型。