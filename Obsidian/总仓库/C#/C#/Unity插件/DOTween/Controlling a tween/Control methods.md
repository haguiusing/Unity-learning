同样，请记住，所有这些方法名称都由所有操作方式共享，但在对象快捷方式的情况下，还有一个额外的“DO”前缀。
**重要提示**：请记住，要在tween结束后对其使用这些方法，您必须禁用其autoKill行为，否则tween将在完成时自动终止。
  
在 DOTween 中，你可以通过多种方式操纵 Tweens，这些方式共享相同的方法名称，但对于快捷方式增强的对象，方法名前会有额外的 `DO` 前缀。以下是这些方法的详细说明和使用示例：

## CompleteAll/Complete(bool withCallbacks = false)
将所有 Tween 动画完成到结束位置。
```csharp
// 完成所有 Tween 动画
DOTween.CompleteAll();

// 完成所有 Tween 动画并触发回调
DOTween.CompleteAll(true);
```

## FlipAll/Flip()
反转 Tween 动画的方向。
```csharp
// 反转所有 Tween 动画的方向
DOTween.FlipAll();
```

## GotoAll/Goto(float to, bool andPlay = false)
将 Tween 动画发送到指定的时间位置。
```csharp
// 将 Tween 动画发送到 0.5 秒的位置并播放
DOTween.GotoAll(0.5f, true);
```

## KillAll/Kill(bool complete = false, params object[] idsOrTargetsToExclude)
销毁 Tween 动画。
```csharp
// 销毁所有 Tween 动画
DOTween.KillAll();

// 销毁所有 Tween 动画并立即完成它们
DOTween.KillAll(true);

// 销毁特定 ID 或目标的 Tween 动画，排除其他
DOTween.Kill("myId", someTransform);
```

## PauseAll/Pause()
暂停所有 Tween 动画。
```csharp
// 暂停所有 Tween 动画
DOTween.PauseAll();
```
## PlayAll/Play()
播放所有 Tween 动画。
```csharp
// 播放所有 Tween 动画
DOTween.PlayAll();
```

## PlayBackwardsAll/PlayBackwards()
反向播放所有 Tween 动画。
```csharp
// 反向播放所有 Tween 动画
DOTween.PlayBackwardsAll();
```

## PlayForwardAll/PlayForward()
正向播放所有 Tween 动画。
```csharp
// 正向播放所有 Tween 动画
DOTween.PlayForwardAll();
```

## RestartAll/Restart(bool includeDelay = true, float changeDelayTo = -1)
重启所有 Tween 动画。
```csharp
// 重启所有 Tween 动画，包括延迟
DOTween.RestartAll();

// 重启所有 Tween 动画，跳过延迟
DOTween.RestartAll(false);
```

## RewindAll/Rewind(bool includeDelay = true)
倒带所有 Tween 动画。
```csharp
// 倒带所有 Tween 动画，包括延迟
DOTween.RewindAll();

// 倒带所有 Tween 动画，跳过延迟
DOTween.RewindAll(false);
```

## SmoothRewindAll/SmoothRewind()
平滑倒带所有 Tween 动画。
```csharp
// 平滑倒带所有 Tween 动画
DOTween.SmoothRewindAll();
```

## TogglePauseAll/TogglePause()
切换所有 Tween 动画的播放/暂停状态。
```csharp
// 切换所有 Tween 动画的播放/暂停状态
DOTween.TogglePauseAll();
```