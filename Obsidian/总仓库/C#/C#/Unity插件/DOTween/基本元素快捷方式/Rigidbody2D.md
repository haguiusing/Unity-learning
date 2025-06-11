这些快捷方式在背景中使用rigidbody2D的MovePosition/MoveRotation方法，以正确设置与物理对象相关的动画。

# Move
## DOMove(Vector2 to, float duration, bool snapping)
将目标的位置移动到给定的二维值。
- `Vector2 to`: 目标二维位置。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOMove(new Vector2(5, 10), 1f); // 在1秒内移动到新位置 (5, 10)
```

## DOMoveX/DOMoveY(float to, float duration, bool snapping)
仅在选定的轴上移动目标的位置。
- `float to`: 目标轴的值。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOMoveX(5, 1f); // 在1秒内仅在X轴上移动到新位置 5
transform.DOMoveY(10, 1f); // 在1秒内仅在Y轴上移动到新位置 10
```
## DOJump(Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping)
在Y轴上应用跳跃效果，同时将目标位置移动到给定的二维值。
- `Vector2 endValue`: 跳跃结束时的二维位置。
- `float jumpPower`: 跳跃的力度（最大跳跃高度由这个值加上最终Y轴偏移量表示）。
- `int numJumps`: 跳跃次数。
- `float duration`: 插值持续时间。
- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。
```csharp
transform.DOJump(new Vector2(5, 0), 6f, 2, 1f); // 在1秒内跳跃两次，跳跃力度为6，结束位置为 (5, 0)
```

# Rotate
用于对 Unity 中的 GameObject 进行旋转。
## DORotate(float toAngle, float duration)
将目标旋转到给定的角度。
- `float toAngle`: 目标旋转角度（以度为单位）。
- `float duration`: 插值持续时间。
```csharp
transform.DORotate(90f, 1f); // 在1秒内旋转到Y轴90度
```

# Path – no FROM
用于对 Unity 中的 GameObject 进行路径插值（Tweening）。
## DOPath(Vector2[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null)
让 Rigidbody2D 沿着给定的路径点数组插值。
- `Vector2[] waypoints`: 路径点数组。
- `float duration`: 插值持续时间。
- `PathType pathType`: 路径类型，可以是线性（Linear）、CatmullRom 曲线（CatmullRom）或立方贝塞尔曲线（CubicBezier）。
- `PathMode pathMode`: 路径模式，用于确定正确的 LookAt 选项。
- `int resolution`: 路径的分辨率，对于线性路径无用，但对于曲线路径，更高的分辨率可以提供更平滑的曲线。
- `Color gizmoColor`: 路径的 Gizmo 颜色。
![[Pasted image 20241129111426.png]]
```csharp
Vector2[] waypoints = { new Vector2(0, 0), new Vector2(1, 2), new Vector2(2, 0) };
myRigidbody2D.DOPath(waypoints, 2f, PathType.CatmullRom);
```


## DOLocalPath(Vector2[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null)
让 Rigidbody2D 沿着给定的局部路径点数组插值。
- 参数与 `DOPath` 相同，但应用于 Rigidbody2D 的局部位置（localPosition）。
```csharp
myRigidbody2D.DOLocalPath(waypoints, 2f, PathType.Linear);
```