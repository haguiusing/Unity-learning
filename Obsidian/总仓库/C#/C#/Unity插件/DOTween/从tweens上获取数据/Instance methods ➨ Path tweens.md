在 DOTween 中，路径 Tweens 提供了一些实例方法，允许你获取有关路径的信息，如路径点、路径绘制点和路径长度。
## Vector3 PathGetPoint(float pathPercentage)
根据给定的路径百分比返回路径上的一个点。
- `float pathPercentage`: 路径上的百分比（0 到 1）。
- 返回值：路径上的点，如果这不是路径 Tween、Tween 无效或路径尚未初始化，则返回 `Vector3.zero`。

```csharp
// 获取路径中点（50% 处的点）
Vector3 myPathMidPoint = myTween.PathGetPoint(0.5f);
```

## Vector3[] PathGetDrawPoints(int subdivisionsXSegment = 10)
返回一个点数组，这些点可以用来绘制路径。
- `int subdivisionsXSegment`: 每个路径段（路径点到路径点）创建多少个点。仅在非线性路径中使用。
- 注意：此方法生成分配，因为它创建了一个新的数组。
- 返回值：用于绘制路径的点数组，如果这不是路径 Tween、Tween 无效或路径尚未初始化，则返回 `null`。

```csharp
// 获取用于绘制路径的点数组
Vector3[] myPathDrawPoints = myTween.PathGetDrawPoints();
```

## float PathLength()
返回路径的长度。
- 返回值：路径的长度，如果这不是路径 Tween、Tween 无效或路径尚未初始化，则返回 `-1`。

```csharp
// 获取路径的长度
float myPathLength = myTween.PathLength();
```