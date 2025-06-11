# Tweener特定设置和选项
在 DOTween 中，有一些特定的设置只能应用于 Tweens（插值器），并且对 Sequences（序列）没有影响。这些设置在 Tween 运行时链式添加将不会生效，除了 `SetEase`。
## From(bool isRelative = false)
将 Tween 设置为 FROM 插值器（而不是常规的 TO 插值器），立即将目标发送到给定值，然后从该值插值到之前的目标值。
```csharp
// 将 Transform 的 X 轴位置设置为 2，然后从该位置插值到原始位置
transform.DOMoveX(2, 1).From();
```

```cs
//Transform 的 X 轴位置从当前值插值到 2，持续时间为 1 秒。
﻿﻿﻿﻿﻿﻿﻿transform.DOMoveX(2, 1);
﻿﻿﻿﻿﻿﻿﻿//立即将 Transform 的 X 轴位置设置为 2，然后插值回其原始位置，持续时间为 1 秒。
﻿﻿﻿﻿﻿﻿﻿transform.DOMoveX(2, 1).From();
﻿﻿﻿﻿﻿﻿﻿//Transform 的 X 轴位置从当前值加上 2（如果当前值为 0，则从 2 开始），然后插值回原始位置，持续时间为 1 秒。这里的 `true` 参数表示 FROM 值是相对于当前值计算的。
﻿﻿﻿﻿﻿﻿﻿transform.DOMoveX(2, 1).From(true);
```

## From(T fromValue, bool setImmediately = true, bool isRelative = false)
直接设置 Tween 的起始值，而不是依赖于 Tween 开始时目标的值。
```csharp
// 从指定的起始值开始 Tween，而不是使用目标的当前值
transform.DOMoveX(4, 1).From(2, true);
```

## SetDelay(float delay)
为 Tween 设置延迟启动。
```csharp
// 在 1 秒后开始移动 Tween
transform.DOMoveX(4, 1).SetDelay(1);
```

## SetDelay(float delay, bool asPrependedIntervalIfSequence)
为 Tween 设置延迟启动，并选择如何在 Sequence 中应用延迟。
```csharp
// 在 Sequence 中，延迟将作为序列开头的间隔重复
transform.DOMoveX(4, 1).SetDelay(1, true);
```

## SetSpeedBased(bool isSpeedBased = true)
如果 `isSpeedBased` 为 `true`，则将 Tween 设置为基于速度（duration 将表示 Tween 每秒移动的单位/度数）。
```csharp
// 设置 Tween 为基于速度的插值，这意味着 duration 将表示每秒移动的单位数
transform.DOMoveX(4, 1).SetSpeedBased();
```

# SetOptions
在 DOTween 中，`SetOptions` 是一个方法，它允许你为特定类型的 Tweens 设置特定的选项。这些选项在创建 Tween 时自动可用，并且必须在 Tween 创建函数之后立即链式添加，否则将不再可用。

## Generic Tweens Specific Options (already included in the corresponding tween shortcuts)

### Color tween ➨ SetOptions(bool alphaOnly)
设置颜色之间的特定选项。
alphaOnly如果为真，则只有颜色的alpha会被推特。
```cs
// 仅对颜色的透明度进行插值
DOTween.To(()=> myColor, x=> myColor = x, new Color(1,1,1,0), 1).SetOptions(true);
```

### float tween ➨ SetOptions(bool snapping)
为浮点数之间设置特定选项。
snaping If TRUE值将平滑地转换为整数。
```cs
// 插值过程中将值平滑地对齐到整数
DOTween.To(()=> myFloat, x=> myFloat = x, 45, 1).SetOptions(true);
```

### Quaternion tween ➨ SetOptions(bool useShortest360Route)
```csharp
// 使用最短路径进行旋转插值（不超过360度）
DOTween.To(()=> myQuaternion, x=> myQuaternion = x, new Vector3(0,180,0), 1).SetOptions(true);
```

### Rect tween ➨ SetOptions(bool snapping)
```cs
// 使用最短路径进行旋转插值（不超过360度）
DOTween.To(()=> myRect, x=> myRect = x, new Rect(0,0,10,10), 1).SetOptions(true);
```

### String tween ➨ SetOptions(bool richTextEnabled, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
#### 富文本解析（Rich Text Enabled）
- `richTextEnabled`: 如果设置为 `true`（默认值），在动画过程中将正确解析富文本标签。如果设置为 `false`，则所有标签都将被视为普通文本。

#### 混淆模式（Scramble Mode）
- `scramble`: 指定在动画过程中字符串的显示方式。如果设置为 `ScrambleMode.None`（默认），字符串将正常显示，不进行混淆。如果设置为 `ScrambleMode.All`、`ScrambleMode.Uppercase`、`ScrambleMode.Lowercase` 或 `ScrambleMode.Numerals`，则字符串将显示为随机字符的动画。`ScrambleMode.Custom` 允许你使用自定义的字符集进行混淆。

#### 自定义混淆字符（ScrambleChars）
- `scrambleChars`: 一个字符串，包含用于自定义混淆的字符。为了获得更好的混淆效果，建议使用尽可能多的字符（最少10个）。
```csharp
// 启用富文本解析并设置混淆模式为全部字符
DOTween.To(()=> myString, x=> myString = x, "hello world", 1).SetOptions(true, ScrambleMode.All);
```

### Vector2/3/4 tween ➨ SetOptions(AxisConstraint constraint, bool snapping)
设置Vector2/3/4之间的特定选项。
约束告诉青少年只设置给定轴的动画。
捕捉If TRUE值将平滑地捕捉到整数（非常适合像素完美移动）。
```csharp
// 仅在 Y 轴上进行插值，并将值平滑地对齐到整数
DOTween.To(()=> myVector, x=> myVector = x, new Vector3(2,2,2), 1).SetOptions(AxisConstraint.Y, true);
```

### Vector3Array tween ➨ SetOptions(bool snapping)
为Vector3数组的tween设置特定选项。
捕捉If TRUE值将平滑地捕捉到整数（非常适合像素完美移动）。
```csharp
// 插值过程中将值平滑地对齐到整数
DOTween.ToArray(()=> myVector, x=> myVector = x, myEndValues, myDurations).SetOptions(true);
```

# DOPath Specific Options
在 DOTween 中，`DOPath` 方法用于创建沿指定路径的 Tween 动画。`SetOptions` 和 `SetLookAt` 是 `DOPath` Tween 的两个特定选项，它们允许你更细致地控制路径 Tween 的行为和目标对象的朝向。
## Path tween ➨ SetOptions(bool closePath, AxisConstraint lockPosition = AxisConstraint.None, AxisConstraint lockRotation = AxisConstraint.None)
为路径 Tween 设置特定选项。
- `bool closePath`: 如果为 `true`，路径将自动闭合。
- `AxisConstraint lockPosition`: 限制对象在特定轴上的移动。可以组合多个轴，如 `AxisConstraint.X | AxisConstraint.Y`。
- `AxisConstraint lockRotation`: 限制对象在特定轴上的旋转。
```csharp
// 创建一个路径 Tween，并设置选项使路径闭合，并限制 X 轴的移动
transform.DOPath(path, 4f).SetOptions(true, AxisConstraint.X);
```

## Path tween ➨ SetLookAt(Vector3 lookAtPosition/lookAtTarget/lookAhead, Vector3 forwardDirection, Vector3 up, bool stableZRotation)
为路径 Tween 设置额外的朝向选项。
- `Vector3 lookAtPosition`: 目标对象将朝向的特定位置。
- `Transform lookAtTarget`: 目标对象将朝向的特定 Transform。
- `Vector3 forwardDirection`: 定义“前方”的可选方向。
- `Vector3 up`: 定义“上”方向的向量，默认为 `Vector3.up`。
- `bool stableZRotation`: 如果设置为 `true`，在朝向路径时不会沿 Z 轴旋转目标。s
```csharp
// 创建一个路径 Tween，并设置目标对象朝向特定位置
transform.DOPath(path, 4f).SetLookAt(new Vector3(2, 1, 3));

// 创建一个路径 Tween，并设置目标对象朝向特定 Transform
transform.DOPath(path, 4f).SetLookAt(someOtherTransform);

// 创建一个路径 Tween，并设置目标对象朝向路径的特定百分比位置
transform.DOPath(path, 4f).SetLookAt(0.01f);
```