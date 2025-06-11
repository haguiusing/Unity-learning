这些方法属于`DOCurve.CubicBezier`类，用于计算和处理三次贝塞尔曲线（Cubic Bezier Curve）。
## static Vector3 DOCurve.CubicBezier.GetPointOnSegment(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, float factor)
- `startPoint`: Vector3类型，贝塞尔曲线段的起始点。
- `startControlPoint`: Vector3类型，起始点的控制点。
- `endPoint`: Vector3类型，贝塞尔曲线段的终点。
- `endControlPoint`: Vector3类型，终点的控制点。
- `factor`: float类型，沿曲线的百分比（0到1），用于确定要计算的点的位置。

**示例**：
```csharp
Vector3 startPoint = new Vector3(0, 0, 0);
Vector3 startControlPoint = new Vector3(1, 2, 0);
Vector3 endPoint = new Vector3(3, 0, 0);
Vector3 endControlPoint = new Vector3(2, -1, 0);
float factor = 0.5f; // 50% along the curve
Vector3 pointOnCurve = DOCurve.CubicBezier.GetPointOnSegment(startPoint, startControlPoint, endPoint, endControlPoint, factor);
```
## static Vector3 DOCurve.CubicBezier.GetSegmentPointCloud(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10)
- `startPoint`: Vector3类型，贝塞尔曲线段的起始点。
- `startControlPoint`: Vector3类型，起始点的控制点。
- `endPoint`: Vector3类型，贝塞尔曲线段的终点。
- `endControlPoint`: Vector3类型，终点的控制点。
- `resolution`: int类型，点云的分辨率，默认为10，最小值为2。

**示例**：
```csharp
Vector3 startPoint = new Vector3(0, 0, 0);
Vector3 startControlPoint = new Vector3(1, 2, 0);
Vector3 endPoint = new Vector3(3, 0, 0);
Vector3 endControlPoint = new Vector3(2, -1, 0);
int resolution = 20; // 更高分辨率
Vector3[] pointsOnCurve = DOCurve.CubicBezier.GetSegmentPointCloud(startPoint, startControlPoint, endPoint, endControlPoint, resolution);
```
## static Vector3 DOCurve.CubicBezier.GetSegmentPointCloud(List<`Vector3`> addToList, Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10)
- `addToList`: List<`Vector3`>类型，一个已有的列表，计算出的点将被添加到这个列表中。
- `startPoint`: Vector3类型，贝塞尔曲线段的起始点。
- `startControlPoint`: Vector3类型，起始点的控制点。
- `endPoint`: Vector3类型，贝塞尔曲线段的终点。
- `endControlPoint`: Vector3类型，终点的控制点。
- `resolution`: int类型，点云的分辨率，默认为10，最小值为2。

**示例**：
```csharp
List<Vector3> pointsList = new List<Vector3>();
Vector3 startPoint = new Vector3(0, 0, 0);
Vector3 startControlPoint = new Vector3(1, 2, 0);
Vector3 endPoint = new Vector3(3, 0, 0);
Vector3 endControlPoint = new Vector3(2, -1, 0);
int resolution = 15; // 指定分辨率
DOCurve.CubicBezier.GetSegmentPointCloud(pointsList, startPoint, startControlPoint, endPoint, endControlPoint, resolution);
// 现在pointsList包含了曲线上的点
```