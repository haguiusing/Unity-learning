## DOAspect(float to, float duration)
改变摄像机的宽高比。
- `float to`: 目标宽高比值。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DOAspect(16f / 9f, 1f); // 1秒内改变摄像机宽高比到16:9
```

## DOColor(Color to, float duration)
改变对象颜色。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
myRenderer.material.SetColor("_Color", Color.red).DOColor(Color.green, 1f); // 1秒内颜色渐变到绿色
```

## DOFarClipPlane(float to, float duration)
改变摄像机的远裁剪面。
- `float to`: 目标远裁剪面距离。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DOFarClipPlane(1000f, 2f); // 2秒内将摄像机远裁剪面改变到1000单位
```

## DOFieldOfView(float to, float duration)
改变摄像机的视场角度。
- `float to`: 目标视场角度。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DOFieldOfView(60f, 1f); // 1秒内将摄像机视场角度改变到60度
```

## DONearClipPlane(float to, float duration)
改变摄像机的近裁剪面。
- `float to`: 目标近裁剪面距离。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DONEarClipPlane(0.1f, 1f); // 1秒内将摄像机近裁剪面改变到0.1单位
```

## DOOrthoSize(float to, float duration)
改变摄像机的正交大小。
- `float to`: 目标正交大小。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DOOrthoSize(10f, 1f); // 1秒内将摄像机正交大小改变到10单位
```

## DOPixelRect(Rect to, float duration)
改变摄像机的像素分辨率。
- `Rect to`: 目标像素分辨率。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DOPixelRect(new Rect(0, 0, 800, 600), 1f); // 1秒内改变摄像机像素分辨率到800x600
```

## DORect(Rect to, float duration)
改变摄像机的视口矩形。
- `Rect to`: 目标视口矩形。
- `float duration`: 插值持续时间。
```csharp
Camera.main.DORect(new Rect(0, 0, 1, 1), 1f); // 1秒内改变摄像机视口矩形到整个屏幕
```

## DOShakePosition(float duration, float/Vector3 strength, int vibrato, float randomness, bool fadeOut, ShakeRandomnessMode randomnessMode)
使对象位置产生抖动效果。
- `float duration`: 抖动持续时间。
- ==`float/Vector3 strength`: 抖动强度，使用Vector3而不是浮点数可以选择每个轴的强度。==
- ==`int vibrato`: 抖动波纹数量。==
- ==`float randomness`: 抖动随机性（0到180——数值高于90种吸吮，所以要小心）。将其设置为0将沿单个方向抖动。。==
- ==`bool fadeOut（默认值：true）`: 是否淡出抖动效果。如果为true，抖动将在tween的持续时间内自动平滑地衰减Out，否则不会。==
- ==`ShakeRandomnessMode randomnessMode（默认值：Full）`: 要应用的随机类型，Full（完全随机）或Harmonic（更平衡，视觉更舒适）。==
```csharp
myTransform.DOShakePosition(1f, 1f, 10, 90f, true); // 1秒内产生抖动效果，强度为1
```

## DOShakeRotation(float duration, float/Vector3 strength, int vibrato, float randomness, bool fadeOut, ShakeRandomnessMode randomnessMode)
使对象旋转产生抖动效果。
- `float duration`: 抖动持续时间。
- ==`float/Vector3 strength`: 抖动强度。使用Vector3而不是浮点数可以选择每个轴的强度。==
- ==`int vibrato`: 抖动波纹数量。==
- ==`float randomness`: 抖动随机性。（0到180——数值高于90种吸吮，所以要小心）。将其设置为0将沿单个方向抖动。==
- ==`bool fadeOut（默认值：true）`: 是否淡出抖动效果。如果为true，抖动将在tween的持续时间内自动平滑地衰减Out，否则不会。==
- ==`ShakeRandomnessMode randomnessMode（默认值：Full）`: 要应用的随机类型，Full（完全随机）或Harmonic（更平衡，视觉更舒适）。==
```csharp
myTransform.DOShakeRotation(1f, 30f, 10, 90f, true); // 1秒内产生旋转抖动效果，强度为30度
```