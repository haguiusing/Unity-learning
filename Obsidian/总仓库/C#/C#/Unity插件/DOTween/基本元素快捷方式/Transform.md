用于对 Unity 中 `Transform` 组件的位置进行插值（Tweening）。
# Move

## DOMove(Vector3 to, float duration, bool snapping)
将目标的位置移动到给定的三维空间值。
- `Vector3 to`: 目标位置。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
transform.DOMove(new Vector3(5, 10, 0), 1f); // 在1秒内移动到新位置 (5, 10, 0)
```
## DOMoveX/DOMoveY/DOMoveZ(float to, float duration, bool snapping)
仅在选定的轴上移动目标的位置。
- `float to`: 目标轴的值。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
transform.DOMoveX(5, 1f); // 在1秒内仅在X轴上移动到新位置 5
```

## DOLocalMove(Vector3 to, float duration, bool snapping)
将目标的局部位置移动到给定的值。
- `Vector3 to`: 目标局部位置。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
transform.DOLocalMove(new Vector3(5, 10, 0), 1f); // 在1秒内移动到新局部位置 (5, 10, 0)
```
## DOLocalMoveX/DOLocalMoveY/DOLocalMoveZ(float to, float duration, bool snapping)
仅在选定的轴上移动目标的局部位置。
- `float to`: 目标轴的局部值。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
transform.DOLocalMoveX(5, 1f); // 在1秒内仅在X轴上移动到新局部位置 5
```

## DOJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping)
在Y轴上应用跳跃效果，同时将目标位置移动到给定的值。
==- `Vector3 endValue`: 跳跃结束时的位置。==
==- `float jumpPower`: 跳跃的力度（最大跳跃高度由这个值加上最终Y轴偏移量表示）。==
==- `int numJumps`: 跳跃次数。==
==- `float duration`: 插值持续时间。==
==- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
transform.DOJump(new Vector3(0, 0, 0), 10f, 2, 1f); // 在1秒内跳跃两次，跳跃力度为10
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dojump.gif)

## DOLocalJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping)
在Y轴上应用跳跃效果，同时将目标的局部位置移动到给定的值。
- 参数与 `DOJump` 相同，但应用于 `Transform` 的局部位置。
```csharp
transform.DOLocalJump(new Vector3(0, 0, 0), 10f, 2, 1f); // 在1秒内跳跃两次，跳跃力度为10
```
![[dotween_dojump.gif]]

# Rotate
用于对 Unity 中 `Transform` 组件的旋转进行插值（Tweening）。
## DORotate(Vector3 to, float duration, RotateMode mode)
将目标旋转到给定的三维角度值。
- `Vector3 to`: 目标旋转角度（以度为单位）。
- `float duration`: 插值持续时间。
- `RotateMode mode`: 旋转模式，可以是 `Fast`（最短路径，不超过360°）、`FastBeyond360`（超过360°）、`WorldAxisAdd`（世界轴相对旋转）或 `LocalAxisAdd`（局部轴相对旋转）。
```csharp
transform.DORotate(new Vector3(0, 90, 0), 1f, RotateMode.Fast); // 在1秒内快速旋转到Y轴90度
```

## DORotateQuaternion(Quaternion to, float duration)
使用纯 Quaternion 值将目标旋转到给定的旋转。
- `Quaternion to`: 目标旋转。
- `float duration`: 插值持续时间。
```csharp
Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
transform.DORotateQuaternion(targetRotation, 1f); // 在1秒内旋转到Y轴90度
```

## DOLocalRotate(Vector3 to, float duration, RotateMode mode)
将目标的局部旋转（localRotation）旋转到给定的三维角度值。
- 参数与 `DORotate` 相同，但应用于局部旋转。
```csharp
transform.DOLocalRotate(new Vector3(0, 90, 0), 1f, RotateMode.Fast); // 在1秒内快速旋转局部Y轴90度
```

## DOLocalRotateQuaternion(Quaternion to, float duration)
使用纯 Quaternion 值将目标的局部旋转（localRotation）旋转到给定的旋转。
- 参数与 `DORotateQuaternion` 相同，但应用于局部旋转。
```csharp
Quaternion targetLocalRotation = Quaternion.Euler(0, 90, 0);
transform.DOLocalRotateQuaternion(targetLocalRotation, 1f); // 在1秒内旋转局部Y轴90度
```
## DOLookAt(Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3 up = Vector3.up)
使目标旋转以面向给定的位置。
- `Vector3 towards`: 目标面向的位置。
- `float duration`: 插值持续时间。
- `AxisConstraint axisConstraint`: 轴约束，限制旋转发生在特定的轴上。
- `Vector3 up`: 定义“上”方向的向量。
```csharp
transform.DOLookAt(new Vector3(5, 0, 0), 1f); // 在1秒内面向X轴正方向的位置
```
## DODynamicLookAt(Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3 up = Vector3.up)
实验性功能，每帧更新目标的面向位置，使其面向给定的位置。
- 参数与 `DOLookAt` 相同，但提供了动态更新面向位置的能力。
```csharp
transform.DODynamicLookAt(new Vector3(5, 0, 0), 1f); // 在1秒内动态面向X轴正方向的位置
```

# Scale
用于对 Unity 中 `Transform` 组件的缩放进行插值（Tweening）。
## DOScale(float/Vector3 to, float duration)
将目标的局部缩放（localScale）缩放到给定的值。
- `float/Vector3 to`: 目标缩放值。可以传递一个 `float` 来均匀缩放（在所有轴上应用相同的缩放因子），或者传递一个 `Vector3` 来独立设置每个轴的缩放。
- `float duration`: 插值持续时间。
```csharp
transform.DOScale(2f, 1f); // 在1秒内均匀缩放到2倍大小
transform.DOScale(new Vector3(2, 1, 1), 1f); // 在1秒内缩放到X轴2倍，Y轴和Z轴保持不变
```

## DOScaleX/DOScaleY/DOScaleZ(float to, float duration)
在X/Y/Z轴上对目标的局部缩放进行插值。
- `float to`: 目标X轴缩放值。
- `float duration`: 插值持续时间。
```csharp
// 在2秒内，仅在X轴上缩放到2倍大小
transform.DOScaleX(2f, 2f);

// 在2秒内，仅在Y轴上缩放到2倍大小
transform.DOScaleY(2f, 2f);

// 在2秒内，仅在Z轴上缩放到2倍大小
transform.DOScaleZ(2f, 2f);

// 在2秒内，缩放到X轴2倍，Y轴3倍，Z轴1倍
transform.DOScale(new Vector3(2, 3, 1), 2f);
```

# Punch – no FROM
`DOPunch` 系列方法用于创建类似于弹簧振子的动画效果，其中对象会向某个方向“冲击”然后返回到原始位置。这些方法适用于位置（`DOPunchPosition`）、旋转（`DOPunchRotation`）和缩放（`DOPunchScale`）。
## DOPunchPosition(Vector3 punch, float duration, int vibrato, float elasticity, bool snapping)
1. **Vector3 punch**: 冲击的方向和强度，将加到 Transform 的当前位置。
2. **float duration**: 插值持续时间。
3. **int vibrato**: 冲击的振动次数。
4. **float elasticity**: 弹性系数，表示向量在反弹时超出起始位置的程度（0 到 1）。
5. **bool snapping**: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOPunchPosition(new Vector3(1, 0, 0), 1f, 10, 0.5f, false);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dopunchposition.gif)
## DOPunchRotation(Vector3 punch, float duration, int vibrato, float elasticity)
1. **Vector3 punch**: 冲击的强度，将加到 Transform 的当前旋转。
2. **float duration**: 插值持续时间。
3. **int vibrato**: 冲击的振动次数。
4. **float elasticity**: 弹性系数，表示向量在反弹时超出起始旋转的程度（0 到 1）。
```csharp
transform.DOPunchRotation(new Vector3(0, 90, 0), 1f, 10, 0.5f);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dopunchrotation.gif)
## DOPunchScale(Vector3 punch, float duration, int vibrato, float elasticity)
1. **Vector3 punch**: 冲击的强度，将加到 Transform 的当前缩放。
2. **float duration**: 插值持续时间。
3. **int vibrato**: 冲击的振动次数。
4. **float elasticity**: 弹性系数，表示向量在反弹时超出起始大小的程度（0 到 1）。
```csharp
transform.DOPunchScale(new Vector3(1, 1, 1), 1f, 10, 0.5f);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dopunchscale.gif)

# Path – no FROM
用于对 Unity 中 `Transform` 组件的位置进行路径插值（Tweening）。
## DOPath(Vector3[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null)
1. **Vector3[] waypoints**: 路径点数组，定义了对象需要经过的一系列位置。
2. **float duration**: 插值持续时间。
3. **PathType pathType**: 路径类型，可以是线性（Linear）、CatmullRom 曲线（CatmullRom）或立方贝塞尔曲线（CubicBezier）。
4. **PathMode pathMode**: 路径模式，用于确定正确的 LookAt 选项，可以是忽略（Ignore）、3D、侧滚动 2D 或顶视 2D。
5. **int resolution**: 路径的分辨率，对于线性路径无用，但对于曲线路径，更高的分辨率可以提供更平滑的曲线。
6. **Color gizmoColor**: 路径的 Gizmo 颜色，当 Gizmos 在 Play 面板中激活且 Tween 正在运行时显示。
![](https://dotween.demigiant.com/_imgs/content/dotween_path_cubicBezier.png)
## DOLocalPath(Vector3[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null)
`DOLocalPath` 的参数与 `DOPath` 类似，但应用于 Transform 的局部位置（localPosition）。![](https://dotween.demigiant.com/_imgs/content/dotween_path_cubicBezier.png)
### 使用示例：
假设你有一个名为 `myTransform` 的 `Transform` 组件，你想要它沿着一系列路径点移动。
```csharp
using DG.Tweening;
using UnityEngine;

public class PathTweenExample : MonoBehaviour
{
    void Start()
    {
        Vector3[] waypoints = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(1, 2, 0),
            new Vector3(2, 0, 0)
        };

        // 创建一个 CatmullRom 曲线路径
        myTransform.DOPath(waypoints, 2f, PathType.CatmullRom);

        // 创建一个立方贝塞尔曲线路径
        Vector3[] bezierWaypoints = new Vector3[] {
            new Vector3(0, 0, 0), // 第一个点没有控制点
            new Vector3(1, 3, 0), // 第二个点的 IN 控制点
            new Vector3(1, 0, 0), // 第三个点
            new Vector3(2, 3, 0), // 第四个点的 OUT 控制点
            new Vector3(2, 0, 0)  // 第五个点
        };
        myTransform.DOPath(bezierWaypoints, 2f, PathType.CubicBezier);
    }
}
```

# Blendable tweens
`DOBlendable` 系列方法允许你在同一个对象上同时运行多个插值（Tweens），这些插值可以和谐地混合在一起，而不是相互冲突。这对于创建复杂的动画效果非常有用，特别是当你想要在同一个对象上同时应用多个移动、旋转或缩放效果时。
## DOBlendableMoveBy(Vector3 by, float duration, bool snapping)
1. **Vector3 by**: 相对于当前位置的移动量。
2. **float duration**: 插值持续时间。
3. **bool snapping**: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOBlendableMoveBy(new Vector3(3, 3, 0), 3f); // 在3秒内移动到相对位置 (3, 3, 0)
```

在 3 秒内移动到相对位置 (3, 3, 0)，并且同时在 1 秒内循环3次移动到相对位置 (-3, 0, 0)。
```cs
// Tween a target by moving it by 3,3,0
﻿﻿﻿﻿﻿﻿﻿// while blending another move by -3,0,0 that will loop 3 times
﻿﻿﻿﻿﻿﻿﻿// (using the default OutQuad ease)
﻿﻿﻿﻿﻿﻿﻿transform.DOBlendableMoveBy(new Vector3(3, 3, 0), 3);
﻿﻿﻿﻿﻿﻿﻿transform.DOBlendableMoveBy(new Vector3(-3, 0, 0), 1f).SetLoops(3, LoopType.Yoyo);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_doblendablemove.gif)
## DOBlendableLocalMoveBy(Vector3 by, float duration, bool snapping)
1. **Vector3 by**: 相对于当前局部位置的移动量。
2. **float duration**: 插值持续时间。
3. **bool snapping**: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOBlendableLocalMoveBy(new Vector3(3, 3, 0), 3f); // 在3秒内局部移动到相对位置 (3, 3, 0)
```
## DOBlendableRotateBy(Vector3 by, float duration, RotateMode mode)
1. **Vector3 by**: 相对于当前旋转的旋转量。
2. **float duration**: 插值持续时间。
3. **RotateMode mode**: 旋转模式，可以是 `Fast`、`FastBeyond360`、`WorldAxisAdd` 或 `LocalAxisAdd`。
```csharp
transform.DOBlendableRotateBy(new Vector3(90, 0, 0), 1f, RotateMode.Fast); // 在1秒内快速旋转Y轴90度
```
## DOBlendableLocalRotateBy(Vector3 by, float duration, RotateMode mode)
1. **Vector3 by**: 相对于当前局部旋转的旋转量。
2. **float duration**: 插值持续时间。
3. **RotateMode mode**: 旋转模式。
```csharp
transform.DOBlendableLocalRotateBy(new Vector3(90, 0, 0), 1f, RotateMode.Fast); // 在1秒内快速局部旋转Y轴90度
```

## DOBlendableScaleBy(Vector3 by, float duration)
1. **Vector3 by**: 相对于当前缩放的缩放量。
2. **float duration**: 插值持续时间。
```csharp
transform.DOBlendableScaleBy(new Vector3(2, 2, 2), 1f); // 在1秒内缩放到2倍大小
```

# PRO ONLY ➨ Spiral – no FROM
用于在 Unity 中创建螺旋形的路径插值（Tweening）。
## DOSpiral(float duration, Vector3 axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1, float frequency = 10, float depth = 0, bool snapping = false)
### 参数说明：
1. **float duration**: 插值持续时间。
2. **Vector3 axis**: 螺旋旋转的轴。如果为 `null`，则默认为世界Z轴。
3. **SpiralMode mode**: 螺旋运动的类型，可以是 `Expand`（向外扩展）、`Contract`（向内收缩）或 `ExpandThenContract`（先扩展后收缩）。
4. **float speed**: 旋转的速度。
5. **float frequency**: 旋转的频率。较低的值会导致螺旋更宽。
6. **float depth**: 沿着螺旋轴的移动量。
7. **bool snapping**: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。

### 使用示例：
假设你有一个名为 `myTransform` 的 `Transform` 组件，你想要它在 3 秒内沿着螺旋形的轨迹移动。
```cs
transform.DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 1, 10);
```
![](https://dotween.demigiant.com/_imgs/content/dotween_dospiral.gif)