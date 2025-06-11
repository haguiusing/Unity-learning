这段文档介绍了`DOVirtual`类的一些静态方法，用于创建虚拟补间动画（Tween）。虚拟补间动画是指不直接作用于游戏对象属性上的补间动画，而是通过回调函数来更新值。
注意：虚拟方法不能放置在序列中。
## static Tweener DOVirtual.Float(float from, float to, float duration, TweenCallback<`float`> onVirtualUpdate)
- 功能：补间一个虚拟的浮点数。
- 参数：
    - `from`：起始值。
    - `to`：目标值。
    - `duration`：补间动画的持续时间。
    - `onVirtualUpdate`：每次更新时调用的回调函数，该函数接受一个`float`类型的参数。
- 注意事项：可以添加常规设置到生成的补间，但不要使用`OnUpdate`，否则会覆盖`onVirtualUpdate`参数。
```csharp
// 将数值从0变化到1，持续时间为2秒，并在每次更新时打印当前值
Tweener myTween = DOVirtual.Float(0, 1, 2, val => Debug.Log(val));
```
## static Tweener DOVirtual.Int(int from, int to, float duration, TweenCallback<`int`> onVirtualUpdate)
- 功能：补间一个虚拟的整数。
- 参数：
    - `from`：起始值。
    - `to`：目标值。
    - `duration`：补间动画的持续时间。
    - `onVirtualUpdate`：每次更新时调用的回调函数，该函数接受一个`int`类型的参数。
- 注意事项：可以添加常规设置到生成的补间，但不要使用`OnUpdate`，否则会覆盖`onVirtualUpdate`参数。
```cs
// 将整数数值从0变化到10，持续时间为3秒，并在每次更新时打印当前值
Tweener myTween = DOVirtual.Int(0, 10, 3, val => Debug.Log(val));
```
## static Tweener DOVirtual.Vector3(Vector3 from, Vector3 to, float duration, TweenCallback<`Vector3`> onVirtualUpdate)
- 功能：补间一个虚拟的`Vector3`向量。
- 参数：
    - `from`：起始值。
    - `to`：目标值。
    - `duration`：补间动画的持续时间。
    - `onVirtualUpdate`：每次更新时调用的回调函数，该函数接受一个`Vector3`类型的参数。
- 注意事项：可以添加常规设置到生成的补间，但不要使用`OnUpdate`，否则会覆盖`onVirtualUpdate`参数。
```csharp
// 将Vector3数值从(0,0,0)变化到(1,1,1)，持续时间为4秒，并在每次更新时打印当前值
Tweener myTween = DOVirtual.Vector3(new Vector3(0,0,0), new Vector3(1,1,1), 4, val => Debug.Log(val));
```
## static Tweener DOVirtual.Color(Color from, Color to, float duration, TweenCallback<`Color`> onVirtualUpdate)
- 功能：补间一个虚拟的颜色。
- 参数：
    - `from`：起始值。
    - `to`：目标值。
    - `duration`：补间动画的持续时间。
    - `onVirtualUpdate`：每次更新时调用的回调函数，该函数接受一个`Color`类型的参数。
- 注意事项：可以添加常规设置到生成的补间，但不要使用`OnUpdate`，否则会覆盖`onVirtualUpdate`参数。
```csharp
// 将颜色从红色变化到蓝色，持续时间为5秒，并在每次更新时打印当前值
Tweener myTween = DOVirtual.Color(Color.red, Color.blue, 5, val => Debug.Log(val));
```
## static float DOVirtual.EasedValue(float from, float to, float lifetimePercentage, Ease easeType \ AnimationCurve animCurve)
- 有两个重载版本，分别用于浮点数和`Vector3`向量的缓动值计算。
- 功能：根据给定的缓动类型和生命周期百分比（0到1）返回一个值。
- 参数：
    - `from`：当生命周期百分比为0时的起始值。
    - `to`：当生命周期百分比为1时的目标值。
    - `lifetimePercentage`：时间百分比（0到1），用于确定应该取哪个值。
    - `easeType`：缓动类型。
    - `animCurve`（在某些重载中）：一个动画曲线，用于自定义缓动效果。
```csharp
// 计算从0到1的float数值在生命周期50%时的缓动值
float easedValue = DOVirtual.EasedValue(0, 1, 0.5f, Ease.InOutQuad);
```
## static Tween DOVirtual.DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true)
- 功能：在给定时间后触发给定的回调函数。
- 参数：
    - `delay`：回调延迟时间。
    - `callback`：当延迟时间结束时触发的回调函数。
    - `ignoreTimeScale`：如果为TRUE（默认），则忽略Unity的时间缩放。
- 示例：
    - 示例1：在1秒后调用另一个方法。
    - 示例2：使用lambda表达式在1秒后打印日志。

```cs
﻿﻿﻿﻿﻿﻿﻿﻿//示例1：1秒后调用另一个方法
DOVirtual。DelayedCall（1，MyOtherMethodName）；
//示例2：使用lambda在1秒后抛出日志
DOVirtual。DelayedCall（1，（）=>调试。日志（"Hello world"）；
```