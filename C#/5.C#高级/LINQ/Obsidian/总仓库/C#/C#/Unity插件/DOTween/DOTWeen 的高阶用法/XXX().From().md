在 DOTween 中，快捷方式（shortcuts）提供了一种快速简便的方法来对 Unity 中的常见对象（如 Transform、Rigidbody 和 Material）进行插值（Tweening）。这些方法允许你直接从这些对象的引用开始一个插值，并且自动将对象本身设置为插值的目标。以下是一些使用快捷方式的例子：
从目标位置，移动到当前位置
### Transform 组件的插值
```csharp
// 在1秒内将 Transform 的位置移动到 (2, 3, 4)
transform.DOMove(new Vector3(2, 3, 4), 1);
```

### Rigidbody 组件的插值
```csharp
// 在1秒内将 Rigidbody 的位置移动到 (2, 3, 4)
rigidbody.DOMove(new Vector3(2, 3, 4), 1);
```

### Material 组件的插值
```csharp
// 在1秒内将 Material 的颜色改变为绿色
material.DOColor(Color.green, 1);
```

### 使用 FROM 版本的插值
DOTween 还提供了 FROM 版本的插值方法，允许你指定插值的起始位置。使用 FROM 版本时，目标对象会立即跳转到 FROM 位置（在你编写那行代码的瞬间，而不是在插值开始时）。
```csharp
// 在1秒内将 Transform 的位置从 (1, 2, 3) 移动到 (2, 3, 4)
transform.DOMove(new Vector3(2, 3, 4), 1).From(new Vector3(1, 2, 3));

// 在1秒内将 Rigidbody 的位置从 (1, 2, 3) 移动到 (2, 3, 4)
rigidbody.DOMove(new Vector3(2, 3, 4), 1).From(new Vector3(1, 2, 3));

// 在1秒内将 Material 的颜色从红色渐变到绿色
material.DOColor(Color.green, 1).From(Color.red);
```

绝对位置，若当前坐标（1,0,0），即X坐标从5运动到1，先从1闪现到5然后再在指定的时间内移动到1
```cs
transform.DOMoveX(5, 1).From();
transform.DOMoveX(5, 1).From(false);
```

相对位置，若当前坐标（1,0,0），即X坐标从6运动到1（6-1=5，相对位移5）
```cs
transform.DOMoveX(5, 1).From(true);
```

#### 注意事项
- 使用 FROM 方法时，确保你已经知道起始位置或状态，因为它会在插值开始之前立即应用。
- FROM 方法特别有用，当你需要从非当前状态开始动画，或者当你想要在动画开始时立即看到变化。
- 这些快捷方式简化了代码，使得对 Unity 对象的动画处理更加直观和方便。

通过这些快捷方式，DOTween 提供了一系列方便的方法来对 Unity 对象进行动画处理，从而让动画效果更加丰富和动态。
