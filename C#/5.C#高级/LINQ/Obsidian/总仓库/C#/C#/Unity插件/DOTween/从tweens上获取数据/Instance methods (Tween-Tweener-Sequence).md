在 DOTween 中，`Tween`、`Tweener` 和 `Sequence` 实例提供了多种实例方法，允许你获取和设置 Tween 的状态和属性。
## float fullPosition
获取和设置 Tween 的时间位置（包括循环，不包括延迟）。
```csharp
// 设置 Tween 的时间位置为 0.5 秒
myTween.fullPosition = 0.5f;

// 获取 Tween 的当前时间位置
float currentPosition = myTween.fullPosition;
```

## int CompletedLoops()
返回 Tween 完成的循环总数。
```csharp
int completedLoops = myTween.CompletedLoops();
```

## float Delay()
返回为 Tween 设置的延迟。
```csharp
float delay = myTween.Delay();
```

## float Duration(bool includeLoops = true)
返回 Tween 的持续时间（不包括延迟，如果 `includeLoops` 为 `true` 则包括循环）。
```csharp
float duration = myTween.Duration(true); // 包括循环
float singleLoopDuration = myTween.Duration(false); // 单次循环
```

## float Elapsed(bool includeLoops = true)
返回 Tween 当前经过的时间（不包括延迟，如果 `includeLoops` 为 `true` 则包括循环）。
```cs
float loopCycleElapsed = myTween.Elapsed(false);
﻿﻿﻿﻿﻿﻿﻿float fullElapsed = myTween.Elapsed();
```

## float ElapsedDirectionalPercentage()
返回 Tween 经过的百分比（0 到 1），基于单次循环，并将最终的 Yoyo 循环计算为 1 到 0 而不是 0 到 1。
```csharp
float percentage = myTween.ElapsedPercentage();
```

## float ElapsedPercentage(bool includeLoops = true)
返回此tween的已用百分比（0到1）（不包括延迟，如果'includeLoops'为TRUE，则包括循环）。

- `bool includeLoops`: 一个布尔值，用于确定在计算进度百分比时是否包括已经完成的循环次数。
    - `true`（默认值）: 计算进度百分比时包括自 Tween 开始以来完成的所有循环。
    - `false`: 计算进度百分比时只考虑当前循环周期内的时间，不包括已完成的循环次数。

```cs
float loopCycleElapsedPerc = myTween.ElapsedPercentage(false);
﻿﻿﻿﻿﻿﻿﻿float fullElapsedPerc = myTween.ElapsedPercentage();
```

## bool IsActive()
检查 Tween 是否处于活跃状态（未被销毁）。
```csharp
bool isActive = myTween.IsActive();
```

## bool IsBackwards()
检查 Tween 是否被反转并设置为向后播放。
```csharp
bool isBackwards = myTween.IsBackwards();
```

## bool IsComplete()
检查 Tween 是否已完成（如果 Tween 被销毁，则默默失败并返回 `false`）。
```csharp
bool isComplete = myTween.IsComplete();
```

## bool IsInitialized()
检查 Tween 是否已被初始化。
```csharp
bool isInitialized = myTween.IsInitialized();
```

## bool IsPlaying()
检查 Tween 是否正在播放。
```csharp
bool isPlaying = myTween.IsPlaying();
```

## int Loops()
返回分配给 Tween 的循环总数。
```csharp
int totalLoops = myTween.Loops();
```