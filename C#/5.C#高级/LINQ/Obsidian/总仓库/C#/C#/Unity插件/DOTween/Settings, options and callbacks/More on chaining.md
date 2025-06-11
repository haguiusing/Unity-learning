DOTween 允许你以链式的方式一次性设置多个 Tween 参数，如下所示：
```csharp
transform.DOMoveX(45, 1)
    .SetDelay(2) // 设置延迟启动
    .SetEase(Ease.OutQuad) // 设置缓动类型为二次方出
    .OnComplete(MyCallback); // 设置完成时的回调
```

在这个示例中，我们创建了一个 `DOMoveX` Tween，并一次性链式设置了延迟、缓动类型和完成时的回调。