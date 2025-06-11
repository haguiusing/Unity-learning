至少需要Unity 2018.1和。NET标准2.0或4.6
这些方法返回一个在异步操作中使用的“Task”，以等待事情发生。

## AsyncWaitForCompletion()
返回一个等待 Tween 被销毁或完成的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1);
    await myTween.AsyncWaitForCompletion();
    Debug.Log("Tween completed!");
}
```

## AsyncWaitForElapsedLoops(int elapsedLoops)
返回一个等待 Tween 被销毁或已完成给定数量循环的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1).SetLoops(4);
    await myTween.AsyncWaitForElapsedLoops(2);
    Debug.Log("Tween has looped twice!");
}
```

## AsyncWaitForKill()
返回一个等待 Tween 被销毁的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1);
    await myTween.AsyncWaitForKill();
    Debug.Log("Tween killed!");
}
```

## AsyncWaitForPosition(float position)
返回一个等待 Tween 被销毁或已达到给定时间位置的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1);
    await myTween.AsyncWaitForPosition(0.3f);
    Debug.Log("Tween has played for 0.3 seconds!");
}
```

## AsyncWaitForRewind()
返回一个等待 Tween 被销毁或倒带的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1).SetAutoKill(false).OnComplete(myTween.Rewind);
    await myTween.AsyncWaitForRewind();
    Debug.Log("Tween rewinded!");
}
```

## AsyncWaitForStart()
返回一个等待 Tween 被销毁或开始的任务。
```csharp
async void SomeAsyncMethod()
{
    Tween myTween = transform.DOMoveX(45, 1);
    await myTween.AsyncWaitForStart();
    Debug.Log("Tween started!");
}
```