在 DOTween 中，`Tween` 和 `Tweener` 类提供了一些方法，允许你在 Tween 创建过程中进行更细致的控制。
# Tween (Tweeners + Sequences)

## Tween Done()
可选：表示tween创建已结束。（可选）用作tween链创建的最后一个元素。
此方法不会做任何事情，除非是在持续时间为0的tween的情况下，它会立即完成它们，而不是等待下一个内部更新例程（除非它们嵌套在序列中，在这种情况下，序列仍将是控制中的序列，此方法将被忽略）。
```csharp
// 创建一个 Tween 并在创建结束后立即完成它（如果持续时间为0）
transform.DOMoveX(45, 0).Done();
```

## ManualUpdate(float deltaTime, float unscaledDeltaTime)
强制此tween手动更新，而不管通过SetUpdate设置的UpdateType如何。
注意：tween仍将遵循正常的tween规则，因此，例如，如果它被暂停，此方法将不会执行任何操作。另请注意，如果您只想手动更新此tween实例，则必须将其设置为UpdateType。无论如何都是手动的，这样它就不会自动更新。
deltaTime：手动deltaTime。
unscaledDeltaTime：未缩放的增量时间（与设置为timeScaleIndependent的tween一起使用）。
```csharp
// 手动更新 Tween，提供 deltaTime 和 unscaledDeltaTime
myTween.ManualUpdate(0.016f, 0.016f);
```

# Tweener

## ChangeEndValue(newEndValue, float duration = -1, bool snapStartValue = false)
更改Tweener的结束值并将其倒回（不暂停）。
对序列中的**Tweeners**没有影响。
注意：适用于常规tween，而不是那些不仅仅是将一个值从一个点动画化到另一个点的tween（如DOLookAt）。
注意：对于接受单轴的快捷方式（DOMoveX/Y/Z、DOScaleX/YZ等），您仍然需要传递一个完整的Vector2/3/4值，即使只考虑您在两者之间设置的值。
```csharp
// 改变 Tweener 的结束值并倒带，不改变持续时间
myTween.ChangeEndValue(new Vector3(5, 5, 5), -1, false);
```

## ChangeStartValue(newStartValue, float duration = -1)
更改Tweener的起始值并将其倒回（不暂停）。
对序列中的**Tweeners**没有影响。
注意：适用于常规tween，而不是那些不仅仅是将一个值从一个点动画化到另一个点的tween（如DOLookAt）。
注意：对于接受单轴的快捷方式（DOMoveX/Y/Z、DOScaleX/YZ等），您仍然需要传递一个完整的Vector2/3/4值，即使只考虑您在两者之间设置的值。
```csharp
// 改变 Tweener 的开始值并倒带，不改变持续时间
myTween.ChangeStartValue(new Vector3(0, 0, 0), -1);
```

## ChangeValues(newStartValue, newEndValue, float duration = -1)
更改Tweener的开始和结束值并将其倒带（不暂停）。
对序列中的**Tweeners**没有影响。
注意：适用于常规tween，而不是那些不仅仅是将一个值从一个点动画化到另一个点的tween（如DOLookAt）。
注意：对于接受单轴的快捷方式（DOMoveX/Y/Z、DOScaleX/YZ等），您仍然需要传递一个完整的Vector2/3/4值，即使只考虑您在两者之间设置的值。
```csharp
// 同时改变 Tweener 的开始值和结束值并倒带
myTween.ChangeValues(new Vector3(0, 0, 0), new Vector3(5, 5, 5));
```