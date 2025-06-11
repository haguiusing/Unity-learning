# 常规设置
DOTween 提供了一系列全局设置，允许你根据项目需求调整其行为。
## static LogBehaviour DOTween.logBehaviour
控制 DOTween 的日志行为。
**默认值：** LogBehaviour.ErrorsOnly
- `LogBehaviour.ErrorsOnly`: 仅记录错误。
- `LogBehaviour.Default`: 记录错误和警告。
- `LogBehaviour.Verbose`: 记录错误、警告和额外信息。
```csharp
// 设置 DOTween 仅记录错误
DOTween.logBehaviour = LogBehaviour.ErrorsOnly;
```

## static bool DOTween.maxSmoothUnscaledTime
当 `useSmoothDeltaTime` 设置为 `true` 时，此值表示在时间独立（timeIndependent）的 Tweens 中将被视为经过的最大时间。
**默认值：** 0.15f
```csharp
// 设置时间独立 Tweens 的最大时间
DOTween.maxSmoothUnscaledTime = 0.15f;
```

## static bool DOTween.nestedTweenFailureBehaviour
在安全模式下，当一个 Tween 嵌套在 Sequence 中失败时的行为。
**默认值：** NestedTweenFailureBehaviour.TryToPreserveSequence
- `NestedTweenFailureBehaviour.TryToPreserveSequence`: 尝试保留序列。
```csharp
// 设置在嵌套 Tween 失败时的行为
DOTween.nestedTweenFailureBehaviour = NestedTweenFailureBehaviour.TryToPreserveSequence;
```

## static bool DOTween.onWillLog<LogType,object>
用于拦截 DOTween 的日志记录。如果此方法非空，DOTween 将在通过 Unity 的日志方法记录日志之前调用它。
```csharp
// 自定义一个日志拦截方法
bool OnWillLog(LogType logType, object message)
{
    // 处理日志消息
    return true; // 返回 true 允许 DOTween 继续记录日志，返回 false 则阻止
}

// 设置日志拦截方法
DOTween.onWillLog = OnWillLog;
```

## static bool DOTween.showUnityEditorReport
设置为 `true` 时，在退出播放模式时（仅在编辑器中）会显示 DOTween 报告，有助于了解最大 Tweeners 和 Sequences 数量，以便优化项目。
```csharp
// 显示 DOTween 报告
DOTween.showUnityEditorReport = true;
```
## static float DOTween.timeScale
应用于所有 Tweens 的全局时间缩放。
```csharp
// 设置全局时间缩放
DOTween.timeScale = 0.5f; // 所有 Tweens 的速度将减半
```
## static float DOTween.unscaledTimeScale
仅应用于独立 Tweens 的全局时间缩放。
```csharp
// 设置独立 Tweens 的全局时间缩放
DOTween.unscaledTimeScale = 2f; // 所有独立 Tweens 的速度将加倍
```
## static bool DOTween.useSafeMode
设置为 `true` 时，Tweens 会稍微慢一些，但更安全，允许 DOTween 自动处理目标在 Tween 运行时被销毁等问题。
```csharp
// 使用安全模式
DOTween.useSafeMode = true;
```

## static bool DOTween.useSmoothDeltaTime
设置为 `true` 时，DOTween 将使用 `Time.smoothDeltaTime` 代替 `Time.deltaTime` 进行动画。
```csharp
// 使用平滑的时间增量
DOTween.useSmoothDeltaTime = true;
```
## static DOTween.SetTweensCapacity(int maxTweeners, int maxSequences)
设置 DOTween 的最大活动 Tweens 和 Sequences 数量，以避免自动增加容量时的性能影响。
```csharp
// 设置最大 Tweens 和 Sequences 数量
DOTween.SetTweensCapacity(2000, 100);
``````

# 应用于所有新创建的高音扬声器的设置
在 DOTween 中，你可以设置一些全局默认值，这些值将应用于所有新创建的 Tweens。l
## static bool DOTween.defaultAutoKill
- 默认值: `true`
- 描述: 设置所有新创建的 Tweens 的默认自动销毁行为。
```csharp
// 设置默认行为为自动销毁完成的 Tweens
DOTween.defaultAutoKill = true;
```

## static AutoPlay DOTween.defaultAutoPlay
- 默认值: `AutoPlay.All`
- 描述: 设置所有新创建的 Tweens 的默认自动播放行为。
```csharp
// 设置默认行为为所有 Tweens 都自动播放
DOTween.defaultAutoPlay = AutoPlay.All;
```

## static float DOTween.defaultEaseOvershootOrAmplitude
- 默认值: `1.70158f`
- 描述: 设置所有缓动函数的默认过度或振幅值。
```csharp
// 设置默认的缓动过度值
DOTween.defaultEaseOvershootOrAmplitude = 1.7f;
```
## static float DOTween.defaultEasePeriod
- 默认值: `0`
- 描述: 设置所有缓动函数的默认周期。
```csharp
// 设置默认的缓动周期
DOTween.defaultEasePeriod = 0.5f;
```

## static Ease DOTween.defaultEaseType
- 默认值: `Ease.OutQuad`
- 描述: 设置所有新创建的 Tweens 的默认缓动类型。
```csharp
// 设置默认的缓动类型
DOTween.defaultEaseType = Ease.OutQuad;
```

## static LoopType DOTween.defaultLoopType
- 默认值: `Ease.OutQuad`
- 描述: 设置所有新创建的 Tweens 的默认缓动类型。
```csharp
// 设置默认的缓动类型
DOTween.defaultEaseType = Ease.OutQuad;
```

## static bool DOTween.defaultRecyclable
- 默认值: `false`
- 描述: 设置所有新创建的 Tweens 的默认回收行为。
```csharp
// 设置默认行为为可回收
DOTween.defaultRecyclable = true;
```

## static bool DOTween.defaultTimeScaleIndependent
- 默认值: `false`
- 描述: 设置是否默认考虑 Unity 的时间缩放（timeScale/maximumDeltaTime）。
```csharp
// 设置默认行为为时间独立
DOTween.defaultTimeScaleIndependent = true;
```

## static UpdateType DOTween.defaultUpdateType
- 默认值: `UpdateType.Normal`
- 描述: 设置所有新创建的 Tweens 的默认更新类型。
```csharp
// 设置默认的更新类型
DOTween.defaultUpdateType = UpdateType.Normal;
```