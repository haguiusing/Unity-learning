`RectTransform` 组件用于控制 UI 元素的位置、大小和旋转。DOTween 提供了一系列专门针对 `RectTransform` 组件的方法来进行插值（Tweening）。
## DOAnchorMax(Vector2 to, float duration, bool snapping)
改变 `RectTransform` 的 `anchorMax` 属性到给定值。
- `Vector2 to`: 目标 `anchorMax` 值。
- `float duration`: 插值持续时间。
- ==`bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```cs
RectTransform rectTransform = ...; // 获取 RectTransform 组件
rectTransform.DOAnchorMax(new Vector2(0.5f, 0.5f), 1f, false); // 在1秒内将 anchorMax 插值到 (0.5, 0.5)
```
## DOAnchorMin(Vector2 to, float duration, bool snapping)
改变 `RectTransform` 的 `anchorMin` 属性到给定值。
- 参数与 `DOAnchorMax` 相同。
```cs
rectTransform.DOAnchorMin(new Vector2(0f, 0f), 1f, false); // 在1秒内将 anchorMin 插值到 (0, 0)
```
## DOAnchorPos(Vector2 to, float duration, bool snapping)
改变 `RectTransform` 的 `anchoredPosition` 到给定值。
- 参数与 `DOAnchorMax` 相同。
```cs
rectTransform.DOAnchorPos(new Vector2(100f, 100f), 1f, false); // 在1秒内将 anchoredPosition 插值到 (100, 100)
```
## DOAnchorPosX/DOAnchorPosY(float to, float duration, bool snapping)
仅在选定的轴上改变 `RectTransform` 的 `anchoredPosition`。
- `float to`: 目标轴的值。
- 参数与 `DOAnchorPos` 相同。
```cs
rectTransform.DOAnchorPosX(100f, 1f, false); // 在1秒内仅在X轴上将 anchoredPosition 插值到 100
```

## DOAnchorPos3D(Vector3 to, float duration, bool snapping)
改变 `RectTransform` 的 `anchoredPosition3D` 到给定值。
- `Vector3 to`: 目标 `anchoredPosition3D` 值。
- 参数与 `DOAnchorPos` 相同。
```cs
rectTransform.DOAnchorPos3D(new Vector3(100f, 100f, 0f), 1f, false); // 在1秒内将 anchoredPosition3D 插值到 (100, 100, 0)
```
## DOAnchorPos3DX/DOAnchorPos3DY/DOAnchorPos3DZ(float to, float duration, bool snapping)
改变 `RectTransform` 中 `anchoredPosition3D`的X/Y轴到给定值。
- `float to`: 目标目标轴的值。
- 参数与 `DOAnchorPos` 相同。
```cs
rectTransform.DOAnchorPos3DX(new Vector3( 100f, 1f, false); // 在1秒内将 anchoredPosition3D 插值到 (100, 100, 0)
```
## DOJumpAnchorPos(Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping)
在 Y 轴上应用跳跃效果，同时将 `anchoredPosition` 移动到给定值。
==- `Vector2 endValue`: 跳跃结束时的位置。==
==- `float jumpPower`: 跳跃的力度。==
==- `int numJumps`: 跳跃次数。==
==- 参数与 `DOAnchorPos` 相同。==
```cs
rectTransform DOJumpAnchorPos(new Vector2(100f, 100f), 10f, 2, 1f, false); // 在1秒内跳跃两次，跳跃力度为10
```

## DOPivot(Vector2 to, float duration)
改变 `RectTransform` 的 `pivot` 到给定值。
- `Vector2 to`: 目标 `pivot` 值。
- `float duration`: 插值持续时间。**
```cs
rectTransform.DOPivot(new Vector2(0.5f, 0.5f), 1f); // 在1秒内将 pivot 插值到 (0.5, 0.5)
```

## DOPivotX/DOPivotY(float to, float duration)
仅在选定的轴上改变 `RectTransform` 的 `pivot`。
- `float to`: 目标轴的 `pivot` 值。
- `float duration`: 插值持续时间。
```cs
rectTransform.DOPivotX( 0.5f, 1f); //在1秒内将 pivot 插值到X
```
## DOPunchAnchorPos(Vector2 punch, float duration, int vibrato, float elasticity, bool snapping)
对 `RectTransform` 的 `anchoredPosition` 应用冲击效果。
==- `Vector2 punch`: 冲击的方向和强度。==
==- `float duration`: 插值持续时间。==
==- `int vibrato`: 冲击的振动次数。==
==- `float elasticity`: 弹性系数。==
==- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```cs
// 应用一个向右下角冲击的动画，持续1秒，振动5次，弹性为0.5
myRectTransform.DOPunchAnchorPos(new Vector2(50, 50), 1f, 5, 0.5f, false);
```
## DOShakeAnchorPos(float duration, float/Vector3 strength, int vibrato, float randomness, bool snapping, bool fadeOut, ShakeRandomnessMode randomnessMode)
对 `RectTransform` 的 `anchoredPosition` 应用震动效果。
==- `float duration`: 插值持续时间。==
==- `float/Vector3 strength`: 震动强度。==
==- `int vibrato`: 震动的振动次数。==
==- `float randomness`: 震动的随机性。==
==- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
==- `bool fadeOut`: 如果为 `true`，则震动将自动淡出。==
==- `ShakeRandomnessMode randomnessMode`: 震动随机性的类型。==
```cs
// 应用一个震动动画，持续1秒，强度为20，振动5次，随机性为90度，淡出
myRectTransform.DOShakeAnchorPos(1f, 20f, 5, 90f, false, true, ShakeRandomnessMode.Full);
```

## DOSizeDelta(Vector2 to, float duration, bool snapping)
改变 `RectTransform` 的 `sizeDelta` 到给定值。
- `Vector2 to`: 目标 `sizeDelta` 值。
- 参数与 `DOAnchorPos` 相同。
```cs
// 在2秒内将RectTransform的sizeDelta改变到新值 (100, 100)
myRectTransform.DOSizeDelta(new Vector2(100f, 100f), 2f, false);
```

# Shape tweens
## DOShapeCircle(Vector2 center, float endValueDegrees, float duration, bool relativeCenter = false, bool snapping = false)
使 `RectTransform` 的 `anchoredPosition` 沿着给定中心点画圆。
==- `Vector2 center`: 圆心/旋转中心点。==
==- `float endValueDegrees`: 结束值的度数。==
==- `float duration`: 插值持续时间。==
==- `bool relativeCenter`: 如果为 `true`，则坐标将被视为相对于目标的当前 `anchoredPosition`。==
==- `bool snapping`: 如果为 `true`，则插值过程中的值将平滑地对齐到整数。==
```cs
// 使RectTransform沿着中心点(100, 100)画一个圆，持续2秒，结束角度为360度
myRectTransform.DOShapeCircle(new Vector2(100f, 100f), 360f, 2f);
```