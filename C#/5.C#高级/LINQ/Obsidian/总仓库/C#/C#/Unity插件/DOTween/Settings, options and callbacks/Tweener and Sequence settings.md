#   实例属性
`timeScale` 允许你调整 Tween 的播放速度。
## float timeScale
- **类型**: `float`
- **默认值**: `1`
- **描述**: 设置 Tween 内部的时间缩放（timeScale）。这个值影响 Tween 动画的快慢。
### 使用示例
假设你有一个 Tween，你希望它以一半的速度播放。
```csharp
// 获取一个现有的 Tween 实例，或者创建一个新的 Tween 实例
Tween myTween = transform.DOMoveX(5f, 1f);

// 设置 Tween 的 timeScale 为 0.5f，使其以一半的速度播放
myTween.timeScale = 0.5f;
```
在这个示例中，我们首先创建了一个移动 Tween，然后在运行时将 `timeScale` 设置为 `0.5f`。这意味着 Tween 将花费两倍的时间来完成其动画。

### 动态调整 timeScale
`timeScale` 属性也可以被另一个 Tween 控制，这允许你创建慢动作效果或其他复杂的时间缩放效果。
```csharp
// 创建一个 Tween 来控制原始 Tween 的 timeScale
DOTween timeScaleTween = DOTween.To(() => myTween.timeScale, x => myTween.timeScale = x, 0.5f, 1f);

// 播放 timeScale Tween
timeScaleTween.Play();
```

在这个示例中，我们创建了一个新的 Tween（`timeScaleTween`），它将在 1 秒内将 `myTween` 的 `timeScale` 从默认值渐变到 `0.5f`。这样，原始 Tween 的速度将逐渐减半。

### 注意事项
- 改变 `timeScale` 属性会直接影响 Tween 的播放速度，但不会影响其持续时间（duration）。如果你希望 Tween 在相同的物理时间内完成动画，但以不同的速度播放，这是非常有用的。
- `timeScale` 属性可以用于实现复杂的动画效果，比如逐渐加速或减速的动画。
- 动态调整 `timeScale` 可以用于创建更丰富的动画序列，例如，一个对象开始时快速移动，然后逐渐减速停止。

# 链式设置
在 DOTween 中，链式设置（Chained settings）允许你对 Tweens 进行一系列配置，这些设置可以被链接到所有类型的 Tweens 上。
## SetAs(Tween tween `\`TweenParams tweenParams)
将给定 Tween 的参数设置为另一个 Tween 或 TweenParams 对象的参数。
```csharp
// 将一个 Tween 的参数复制到另一个 Tween 上
transform.DOMoveX(4, 1).SetAs(myOtherTween);
``````

## SetAutoKill(bool autoKillOnCompletion = true)
设置 Tween 在完成时是否自动销毁。
```csharp
// 设置 Tween 在完成时不自动销毁，允许重用
transform.DOMoveX(4, 1).SetAutoKill(false);
``````

## SetEase(Ease easeType `\` AnimationCurve animCurve `\` EaseFunction customEase)
设置 Tween 的缓动类型。
```csharp
// 使用内置的缓动类型
transform.DOMoveX(4, 1).SetEase(Ease.InOutQuint);

// 使用 AnimationCurve 对 Tween 进行缓动
AnimationCurve myAnimationCurve = new AnimationCurve();
// ... 配置 AnimationCurve ...
transform.DOMoveX(4, 1).SetEase(myAnimationCurve);

// 使用自定义缓动函数
EaseFunction customEase = (float t) => { /* 自定义缓动函数 */ };
transform.DOMoveX(4, 1).SetEase(customEase);
```
### **缓动函数** (Ease)
自定义参数随时间变化的速率。 现实生活中，物体并不是突然启动或者停止， 当然也不可能一直保持匀速移动。就像我们 打开抽屉的过程那样，刚开始拉的那一下动作很快， 但是当抽屉被拉出来之后我们会不自觉的放慢动作。 或是掉落在地板上的物体，一开始下降的速度很快， 接着就会在地板上来回反弹直到停止。 这个页面将帮助你选择正确的缓动函数。
[缓动函数速查表](https://easings.net/zh-cn)
![[Pasted image 20241130214143.png]]
### 特殊缓动类型（SPECIAL EASES）
- **Flash**: 应用 Flash 风格的缓动效果。
- **InFlash**: 在 Flash 缓动效果之前应用。
- **OutFlash**: 在 Flash 缓动效果之后应用。
- **InOutFlash**: 在 Flash 缓动效果的开始和结束时应用。
```csharp
// 设置 Flash 缓动效果
transform.DOMoveX(4, 1).SetEase(Ease.Flash(5, 1f, 0.5f));
```
![](https://dotween.demigiant.com/_imgs/content/dotween_easeflash.gif)  
### EaseFactory.StopMotion(int fps, EaseAnimationCurve/EaseFunction ease)
额外的层，可以添加到你的缓动上，使其表现为停止运动（stop-motion）效果。
```csharp
// 设置停止运动效果，模拟 5 FPS 的播放速率
transform.DOMoveX(4, 1).SetEase(EaseFactory.StopMotion(5, Ease.InOutQuint));
```

## SetId(object id)
为 Tween 设置一个 ID，这可以用来在 DOTween 的静态方法中作为过滤条件。
```csharp
// 为 Tween 设置一个字符串 ID
transform.DOMoveX(4, 1).SetId("supertween");
```

## SetInverted()
实验性功能：反转 Tween 的播放方向，使其从结束位置播放到开始位置。
```csharp
// 反转 Tween 的播放方向
tween.SetInverted();
```

## SetLink(GameObject target, LinkBehaviour linkBehaviour = LinkBehaviour.KillOnDestroy)
将 Tween 链接到一个 GameObject，并根据其活动状态分配行为。
```csharp
// 将 Tween 链接到一个 GameObject 上，并在 GameObject 被销毁时杀死 Tween
transform.DOMoveX(4, 1).SetLink(aGameObject, LinkBehaviour.KillOnDestroy);
```

## SetLoops(int loops, LoopType loopType = LoopType.Restart)
设置 Tween 的循环选项。
1. **LoopType.Restart**: 当循环结束时，Tween 将从开始重新播放。
    - 这是默认的循环行为，意味着每次循环结束后，Tween 将重置到初始状态并重新开始。
2. **LoopType.Yoyo**: 当循环结束时，Tween 将反向播放直到完成另一个循环周期，然后再次正向播放，接着再次反向播放，如此反复。
    - 这种模式下，Tween 会在正向和反向之间交替，创建一种来回摆动的效果。
3. **LoopType.Incremental**: 每次循环结束时，Tween 的结束值（`endValue`）与开始值（`startValue`）之间的差值将被加到结束值上，从而在每个循环周期后增加 Tween 的值。
    - 这种循环类型仅适用于 Tweens，并且可以创建随着每个循环周期增加其值的 Tween 动画。例如，如果你有一个移动 Tween 沿着直线移动对象，使用 Incremental 循环模式将使对象在每个循环周期后移动更远。
```csharp
// 设置 Tween 循环3次，使用 Yoyo 模式
transform.DOMoveX(4, 1).SetLoops(3, LoopType.Yoyo);
```

## SetRecyclable(bool recyclable)
设置 Tween 的回收行为。
```csharp
// 设置 Tween 为可回收
transform.DOMoveX(4, 1).SetRecyclable(true);
```

## SetRelative(bool isRelative = true)
如果设置为 `true`，则将 Tween 设置为相对模式。
<font color="#ffff00">重要提示</font>：对From tween没有影响，因为在这种情况下，在链接From设置时，您可以直接选择tween是否是相对的。
如果孩子已经开始，则没有效果。
```csharp
// 设置 Tween 为相对模式
transform.DOMoveX(4, 1).SetRelative();
```

## SetTarget(object target)
设置 Tween 的目标。
```csharp
// 设置 Tween 的目标
DOTween.To(() => myInstance.aFloat, (x) => myInstance.aFloat = x, 2.5f, 1).SetTarget(myInstance);
```
## SetUpdate(UpdateType updateType, bool isIndependentUpdate = false)
设置 Tween 的更新类型。
```csharp
// 设置 Tween 使用 LateUpdate 更新，并忽略 Unity 的时间缩放
transform.DOMoveX(4, 1).SetUpdate(UpdateType.Late, true);
```

# 链式回调
在 DOTween 中，链式回调（Chained callbacks）允许你在 Tween 的生命周期中的特定点执行自定义操作。这些回调可以被链接到 Tweens 上，并在 Tween 完成、被销毁、播放、暂停、回退、开始、循环完成或更新时触发。
## OnComplete(TweenCallback callback)
当 Tween 完成所有循环后触发。
```csharp
void MyCallback() {
    Debug.Log("Tween completed");
}
transform.DOMoveX(4, 1).OnComplete(MyCallback);
```

## OnKill(TweenCallback callback)
当 Tween 被销毁时触发。
```csharp
transform.DOMoveX(4, 1).OnKill(MyCallback);
```

## OnPlay(TweenCallback callback)
当 Tween 开始播放时触发，包括从暂停状态恢复。
```csharp
transform.DOMoveX(4, 1).OnPlay(MyCallback);
```

## OnPause(TweenCallback callback)
当 Tween 从播放状态变为暂停状态时触发。
```csharp
transform.DOMoveX(4, 1).OnPause(MyCallback);
```

## OnRewind(TweenCallback callback)
当 Tween 被回退到开始位置时触发。
```csharp
transform.DOMoveX(4, 1).OnRewind(MyCallback);
```

## OnStart(TweenCallback callback)
当 Tween 第一次开始播放时触发。
```csharp
transform.DOMoveX(4, 1).OnStart(MyCallback);
```

## OnStepComplete(TweenCallback callback)
每次 Tween 完成一个循环周期时触发。
```csharp
transform.DOMoveX(4, 1).OnStepComplete(MyCallback);
```

## OnUpdate(TweenCallback callback)
每次 Tween 更新时触发。
```csharp
transform.DOMoveX(4, 1).OnUpdate(MyCallback);
```

## OnWaypointChange(TweenCallback<`int`> callback)

当路径 Tween 的当前路径点改变时触发。
```cs
void Start() {
﻿﻿﻿﻿﻿﻿﻿   transform.DOPath(waypoints, 1).OnWaypointChange(MyCallback);
﻿﻿﻿﻿﻿﻿﻿}
﻿﻿﻿﻿﻿﻿﻿void MyCallback(int waypointIndex) {
﻿﻿﻿﻿﻿﻿﻿   Debug.Log("Waypoint index changed to " + waypointIndex);
﻿﻿﻿﻿﻿﻿﻿}
```
### 使用 Lambda 表达式传递参数
如果你需要在回调中使用参数，可以使用 Lambda 表达式来实现：
```cs
// Callback without parameters
﻿﻿﻿﻿﻿﻿transform.DOMoveX(4, 1).OnComplete(MyCallback);
﻿﻿﻿﻿﻿﻿// Callback with parameters
﻿﻿﻿﻿﻿﻿transform.DOMoveX(4, 1).OnComplete(()=>MyCallback(someParam, someOtherParam));
```
