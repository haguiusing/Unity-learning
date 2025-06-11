在 DOTween 中，静态方法（Static methods）提供了对 Tween 系统进行全局管理的能力。
## static DOTween.Clear(bool destroy = false)
清除所有 Tweens，清空所有池，并重置最大 Tweens/Sequences 容量到默认值。
- `bool destroy`: 如果为 `true`，则销毁 DOTween 的 GameObject 并重置其初始化、默认设置等。
- 注意：此方法仅用于调试目的或当你不打算在项目中创建/运行更多 Tweens 时使用，因为它会完全取消初始化 DOTween 及其内部插件。如果你想杀死所有 Tweens，应使用静态方法 `DOTween.KillAll()`。

```csharp
// 清除所有 Tweens，但保留 DOTween 的初始化状态
DOTween.Clear();

// 清除所有 Tweens 并销毁 DOTween 的 GameObject
DOTween.Clear(true);
```

## static DOTween.ClearCachedTweens()
清除所有缓存的 Tween 池。
```csharp
// 清除所有缓存的 Tween 池
DOTween.ClearCachedTweens();
```

## static DOTween.Validate()
验证所有活跃的 Tweens 并移除最终无效的 Tweens（通常是因为它们的目标被销毁了）。
```csharp
// 验证所有活跃的 Tweens 并移除无效的 Tweens
DOTween.Validate();
```
## static DOTween.ManualUpdate(float deltaTime, float unscaledDeltaTime)
更新所有设置为 `UpdateType.Manual` 的 Tweens。
```csharp
// 手动更新 Tweens，提供 delta 时间和未缩放的 delta 时间
DOTween.ManualUpdate(Time.deltaTime, Time.unscaledDeltaTime);
```