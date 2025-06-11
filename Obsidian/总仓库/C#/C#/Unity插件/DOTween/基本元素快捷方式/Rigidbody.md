这些快捷方式在背景中使用rigidbody的MovePosition/MoveRotation方法，以正确设置与物理对象相关的动画。
# Move
用于对 Unity 中 GameObject 的位置进行插值（Tweening），包括移动、跳跃等效果。
## DOMove(Vector3 to, float duration, bool snapping)
将目标位置移动到给定值。
- `Vector3 to`: 目标位置。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
myTransform.DOMove(new Vector3(5, 0, 10), 2f); // 在2秒内移动到新位置
```

## DOMoveX/DOMoveY/DOMoveZ(float to, float duration, bool snapping) 
仅在选定的轴上移动目标位置。
- `float to`: 目标轴的值。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
myTransform.DOMoveX(5, 2f); // 在2秒内仅在X轴上移动到新位置
```

## DOJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping)
在Y轴上应用跳跃效果，同时将目标位置移动到给定值。
==- `Vector3 endValue`: 跳跃结束时的位置。==
==- `float jumpPower`: 跳跃的力度（最大跳跃高度由这个值加上最终Y轴偏移量表示）。==
==- `int numJumps`: 跳跃次数。==
==- `float duration`: 插值持续时间。==
==- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```csharp
myTransform.DOJump(new Vector3(0, 2, 0), 6f, 2, 1f); // 在1秒内跳跃两次，跳跃力度为6
```

# Rotate
## DORotate(Vector3 to, float duration, RotateMode mode)
将目标旋转到给定值。
- `Vector3 to`: 目标旋转角度（以度为单位）。
- `float duration`: 插值持续时间。
- `RotateMode mode`: 旋转模式，决定旋转的计算方式。
```csharp
transform.DORotate(new Vector3(0, 90, 0), 1f, RotateMode.Fast); // 在1秒内快速旋转到Y轴90度
```

## DOLookAt(Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3 up = Vector3.up)
使目标旋转以面向给定位置。
- `Vector3 towards`: 目标面向的位置。
- `float duration`: 插值持续时间。
- ==`AxisConstraint axisConstraint`: 轴约束，限制旋转发生在特定的轴上。==
- ==`Vector3 up`: 定义“上”方向的向量。==
```csharp
// 在2秒内快速旋转到Y轴180度
transform.DORotate(new Vector3(0, 180, 0), 2f, RotateMode.Fast);

// 在2秒内，使物体面向新的位置 (5, 0, 10)
transform.DOLookAt(new Vector3(5, 0, 10), 2f);

// 在2秒内，使物体面向新的位置 (5, 0, 10)，并且限制旋转只能在Y轴上发生
transform.DOLookAt(new Vector3(5, 0, 10), 2f, AxisConstraint.YAxis);
```


# Path – no FROM 
用于对 Unity 中 Rigidbody 组件的位置进行插值（Tweening），沿着由多个路径点（waypoints）定义的路径移动。
## DOPath(Vector3[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null) 
1. **Vector3[] waypoints**: 路径点数组，定义了路径的走向。
2. **float duration**: 插值持续时间。
3. **PathType pathType**: 路径类型，可以是线性（Linear）、CatmullRom 曲线（CatmullRom）或立方贝塞尔曲线（CubicBezier）。
4. **PathMode pathMode**: 路径模式，用于确定正确的 LookAt 选项，可以是忽略（Ignore）、3D、侧滚动 2D 或顶视 2D。
5. **int resolution**: 路径的分辨率，对于线性路径无用，但对于曲线路径，更高的分辨率可以提供更平滑的曲线。
6. **Color gizmoColor**: 路径的 Gizmo 颜色，当 Gizmos 在 Play 面板中激活且 Tween 正在运行时显示。
![[Pasted image 20241129105453.png]]

## DOLocalPath(Vector3[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null) 
`DOLocalPath` 的参数与 `DOPath` 类似，但应用于 Rigidbody 的局部位置（localPosition）而不是世界位置。
![[Pasted image 20241129105459.png]]
### 使用示例：
假设你有一个名为 `myRigidbody` 的 Rigidbody 组件，你想要它沿着一系列路径点移动。
```cs
using DG.Tweening;
using UnityEngine;

public class PathTweenExample : MonoBehaviour
{
    void Start()
    {
        Vector3[] waypoints = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(5, 0, 0),
            new Vector3(5, 5, 0),
            new Vector3(0, 5, 0)
        };

        // 创建一个线性路径
        myRigidbody.DOPath(waypoints, 5f, PathType.Linear);

        // 创建一个 CatmullRom 曲线路径
        myRigidbody.DOPath(waypoints, 5f, PathType.CatmullRom);

        // 创建一个立方贝塞尔曲线路径，注意路径点数量必须是3的倍数
        Vector3[] bezierWaypoints = new Vector3[] {
            new Vector3(0, 0, 0), // 第一个点没有控制点
            new Vector3(2, 5, 0), // 第二个点的 IN 控制点
            new Vector3(5, 0, 0), // 第三个点的 OUT 控制点
            new Vector3(7, 5, 0), // 第四个点的 IN 控制点
            new Vector3(10, 0, 0) // 第五个点
        };
        myRigidbody.DOPath(bezierWaypoints, 5f, PathType.CubicBezier);
    }
}
```

# Spiral
`DOSpiral` 是 DOTween Pro 扩展中的一个方法，它用于创建一个螺旋形的路径插值（Tweening）。这个方法允许 Rigidbody 组件沿着一个螺旋形的轨迹移动。
## DOSpiral(float duration, Vector3 axis = null, SpiralMode mode = SpiralMode.Expand, float speed = 1, float frequency = 10, float depth = 0, bool snapping = false)
### 参数说明：
1. **float duration**: 插值持续时间。
2. **Vector3 axis**: 螺旋旋转的轴。如果为 `null`，则默认为世界Z轴。
3. **SpiralMode mode**: 螺旋运动的类型，可以是 `Expand`（向外扩展）、`Contract`（向内收缩）或 `ExpandThenContract`（先扩展后收缩）。
4. **float speed**: 旋转的速度。
5. **float frequency**: 旋转的频率。较低的值会导致螺旋更宽。
6. **float depth**: 沿着螺旋轴的移动量。
7. **bool snapping**: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
### 使用示例：
假设你有一个名为 `myRigidbody` 的 Rigidbody 组件，你想要它沿着螺旋形的轨迹移动。
```csharp
using DG.Tweening;
using UnityEngine;

public class SpiralTweenExample : MonoBehaviour
{
    void Start()
    {
        // 在3秒内完成螺旋运动，螺旋轴为世界Z轴，模式为先扩展后收缩，旋转速度为1，频率为10，深度为0，不进行值的对齐
        transform.DOSpiral(3f, Vector3.forward, SpiralMode.ExpandThenContract, 1f, 10f, 0f, false)
            .SetEase(Ease.InSine); // 设置缓动类型为 Ease.InSine
    }
}
```
![[dotween_dospiral.gif]]
在这个示例中，我们使用了 `DOSpiral` 方法来创建一个螺旋形的路径。我们指定了螺旋运动的持续时间为3秒，螺旋轴为世界Z轴（`Vector3.forward`），模式为先扩展后收缩（`SpiralMode.ExpandThenContract`），旋转速度为1，频率为10，深度为0，并且不进行值的对齐。我们还设置了缓动类型为 `Ease.InSine`，这意味着螺旋运动将在开始时较慢，然后逐渐加快。

请注意，`DOSpiral` 方法是 DOTween Pro 的一部分，因此你需要拥有 DOTween Pro 许可证才能使用此方法。此外，由于螺旋运动涉及到旋转和移动，因此它适用于 Rigidbody 组件，而不是 Transform 组件。如果你想要对 Transform 组件使用类似的效果，你可能需要结合使用 `DORotate` 和 `DOMove` 方法来模拟螺旋运动。
