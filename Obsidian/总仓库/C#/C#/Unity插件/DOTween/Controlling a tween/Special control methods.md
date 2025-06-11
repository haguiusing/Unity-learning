# Common for all tweens
## ForceInit()
在 DOTween 中，`ForceInit()` 方法是一个通用方法，可以应用于 `Tween`、`Tweener` 或 `Sequence` 实例。这个方法强制 Tween 立即初始化其设置。这在你需要从尚未初始化的 Tween 中获取数据时非常有用，比如获取路径长度（`PathLength`）。
### 使用示例
假设你有一个 `Transform` 组件，你想要创建一个沿路径移动的 Tween，并在 Tween 开始之前获取路径的长度。
```csharp
using DG.Tweening;
using UnityEngine;

public class TweenInitExample : MonoBehaviour
{
    public Transform pathStart;
    public Transform pathEnd;

    void Start()
    {
        // 创建一个从 pathStart 到 pathEnd 的路径 Tween
        Tween pathTween = DOTween.To(pathStart.position, pathEnd.position, 1f);

        // 强制初始化 Tween 以立即获取路径长度
        pathTween.ForceInit();

        // 现在可以安全地获取路径长度
        float pathLength = pathTween.pathLength;
        Debug.Log("Path length: " + pathLength);
    }
}
```

在这个示例中，我们首先创建了一个从 `pathStart` 到 `pathEnd` 的 `To` Tween。然后，我们调用 `ForceInit()` 方法来强制 Tween 初始化其设置，这样我们就可以在 Tween 开始之前获取路径的长度。这对于在 Tween 开始之前需要路径长度进行计算或设置的场景非常有用。

### 注意事项
- `ForceInit()` 方法通常用于需要在 Tween 动画开始之前获取 Tween 相关信息的情况。
- 这个方法不会影响 Tween 的动画效果，它只是确保 Tween 的内部数据在需要时已经准备好。
- 使用 `ForceInit()` 可以避免在 Tween 动画开始之前尝试访问未初始化的数据，这可能会导致错误或不准确的结果。

通过使用 `ForceInit()`，你可以确保在需要时能够访问 Tween 的所有属性和数据，从而使得你的代码更加健壮和可靠。

## Type-specific
在 DOTween 中，`GotoWaypoint` 是一个特定于路径 Tweens 的控制方法，它允许你将 Tween 动画发送到路径上的特定路径点（waypoint）。这个方法仅适用于使用线性缓动（Linear ease）的 `Tween` 或 `Tweener` 实例。以下是 `GotoWaypoint` 方法的详细说明和使用示例：

### GotoWaypoint(int waypointIndex, bool andPlay = false)
将路径 Tween 动画发送到给定的路径点索引。
- `int waypointIndex`: 要到达的路径点索引。如果索引大于路径点的最大索引，Tween 将简单地移动到最后一个路径点。
- `bool andPlay`: 如果为 `true`，在到达给定位置后 Tween 将继续播放，否则将暂停。

#### 使用示例
假设你有一个 `Transform` 组件，你想要创建一个沿路径移动的 Tween，并在特定路径点暂停或继续播放。
```csharp
using DG.Tweening;
using UnityEngine;

public class PathTweenExample : MonoBehaviour
{
    public Transform[] waypoints; // 假设这是你的路径点数组

    void Start()
    {
        // 创建一个沿路径移动的 Tween
        Tween myTween = transform.DOMove(new Vector3(waypoints[waypoints.Length - 1].position.x, waypoints[waypoints.Length - 1].position.y, 0), 3f);

        // 将 Tween 发送到第二个路径点并继续播放
        myTween.GotoWaypoint(1, true);

        // 或者，发送到第二个路径点并暂停
        myTween.GotoWaypoint(1, false);
    }
}
```

在这个示例中，我们首先创建了一个 `DOMove` Tween，它将在 3 秒内将对象移动到路径的最后一个点。然后，我们使用 `GotoWaypoint` 方法将 Tween 发送到第二个路径点，并根据 `andPlay` 参数决定是否继续播放。

#### 注意事项
- 使用 `GotoWaypoint` 方法时，需要注意路径点的索引。如果索引超出了路径点数组的范围，Tween 将自动移动到最后一个路径点。
- 这个方法适用于需要在路径上特定点进行操作的场景，比如在游戏关卡设计中到达特定检查点。
- 需要注意的是，使用 `GotoWaypoint` 后，Tween 的朝向可能不正确，可能需要手动设置 LookAt 方向以确保对象朝向正确。这是因为 `GotoWaypoint` 依赖于平滑的路径移动，对于包含剧烈方向变化的跳跃路径可能不适用。