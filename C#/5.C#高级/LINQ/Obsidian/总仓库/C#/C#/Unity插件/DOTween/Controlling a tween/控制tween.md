在 DOTween 中，有三种主要方式可以操作（播放、暂停、重启、销毁等）Tweens（插值器）：

### A. 通过静态方法和过滤器
DOTween 类提供了许多静态方法来控制 Tweens。这些方法分为两种形式：
- **"All" 版本**：如 `DOTween.PauseAll()`，应用于所有现有的 Tweens。
- **简单版本**：如 `DOTween.Pause(myTargetOrId)`，允许你通过 Tween 的 ID 或目标来过滤操作。

静态方法还会返回一个 `int`，表示实际执行了请求操作的 Tween 数量。
```csharp
// 暂停所有 Tweens
DOTween.PauseAll();

// 暂停所有 ID 为 "badoom" 的 Tweens
DOTween.Pause("badoom");

// 暂停所有以某个 Transform 为目标的 Tweens
DOTween.Pause(someTransform);
```

### B. 直接从 Tween
与其使用静态方法，你可以直接从你的 Tween 引用调用相同的方法。
```csharp
// 假设 myTween 是之前创建的 Tween 的引用
myTween.Pause();
```

### C. 从快捷方式增强的引用
与上述类似，但你可以从快捷方式增强的对象调用这些方法。在这种情况下，方法名称有一个额外的 `DO` 前缀，以区分它们和常规对象方法。
```csharp
// 暂停通过快捷方式增强的 Tween
transform.DOPause();
```