在 Unity 编辑器中预览 Tween 动画是 DOTween 提供的一个功能，它允许你在不运行游戏的情况下查看动画效果。
## static DOTweenEditorPreview.PrepareTweenForPreview(bool clearCallbacks = true, bool preventAutoKill = true, bool andPlay = true)
这个方法用于设置 Tween 以供编辑器预览。
- `bool clearCallbacks`: 如果为 `true`（推荐），在预览时移除所有回调（如 `OnComplete`、`OnRewind` 等）。
- `bool preventAutoKill`: 如果为 `true`，在预览时防止 Tween 在完成时自动销毁。
- `bool andPlay`: 如果为 `true`，立即开始播放 Tween。

```csharp
// 准备一个 Tween 用于编辑器预览
DOTweenEditor.PrepareTweenForPreview(true, true, true);
```

## static DOTweenEditorPreview.Start(Action onPreviewUpdated = null)
开始编辑器中 Tween 的更新循环。在播放模式下没有效果。
在调用此方法之前，您必须通过DOTweenEditorPreview将tween添加到预览循环中。准备TweenForPreview。
onReview更新了每次更新后调用的最终回调（在编辑器预览中）。
```csharp
// 开始编辑器中 Tween 预览的更新循环
DOTweenEditorPreview.Start((onPreviewUpdated) =>
{
    // 在这里处理每次更新后的操作
    Debug.Log("Tween preview updated");
}));
```

## static DOTweenEditorPreview.Stop()
停止预览更新循环并清除任何回调。
```csharp
// 停止编辑器中 Tween 预览的更新循环
DOTweenEditorPreview.Stop();
```
Stops the preview update loop and clears any callback.