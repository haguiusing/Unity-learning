Tweens附带了一组有用的YieldInstructions，您可以将其放置在您的协程中，并允许您等待事情发生。
所有这些方法都有一个可选的bool参数，允许返回“CustomYieldInstruction”。

## WaitForCompletion()
创建一个等待指令，直到 Tween 被销毁或完成。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1);
    yield return myTween.WaitForCompletion();
    // Tween 完成后发生
    Debug.Log("Tween completed!");
}
```

## WaitForElapsedLoops(int elapsedLoops)
创建一个等待指令，直到 Tween 被销毁或已经完成给定数量的循环。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1).SetLoops(4);
    yield return myTween.WaitForElapsedLoops(2);
    // 第二次循环完成后发生
    Debug.Log("Tween has looped twice!");
}
```

## WaitForKill()
创建一个等待指令，直到 Tween 被销毁。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1);
    yield return myTween.WaitForKill();
    // Tween 被销毁后发生
    Debug.Log("Tween killed!");
}
```

## WaitForPosition(float position)
创建一个等待指令，直到 Tween 被销毁或已达到给定的时间位置（包括循环，不包括延迟）。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1);
    yield return myTween.WaitForPosition(0.3f);
    // Tween 播放 0.3 秒后发生
    Debug.Log("Tween has played for 0.3 seconds!");
}
```

## WaitForRewind()
创建一个等待指令，直到 Tween 被销毁或倒带。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1).SetAutoKill(false).OnComplete(myTween.Rewind);
    yield return myTween.WaitForRewind();
    // Tween 倒带后发生
    Debug.Log("Tween rewinded!");
}
```

## WaitForStart()
创建一个等待指令，直到 Tween 被销毁或开始（意味着在任何延迟后第一次设置为播放状态）。
```csharp
IEnumerator SomeCoroutine()
{
    Tween myTween = transform.DOMoveX(45, 1);
    yield return myTween.WaitForStart();
    // Tween 开始时发生
    Debug.Log("Tween started!");
}
```