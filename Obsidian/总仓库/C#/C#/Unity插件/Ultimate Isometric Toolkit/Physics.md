# 物理系统
此资源利用Unity的内置3D物理系统。您可以向GameObject添加常规的Rigidbody（刚体）和Collider（碰撞器）组件。
## 刚体（Rigidbody）
在添加Rigidbody组件时，请确保在检查器视图中勾选冻结旋转（freeze rotation）复选框。

![Shader](https://code-beans.github.io/Ultimate-Isometric-Toolkit-Docs-and-Issue-Tracker/Manual/images/freezeRotation.png)

您还可以从脚本中设置这些值。

以下是一个示例脚本，用于冻结GameObject的刚体旋转：
``` cs
public void fooBar() { 
    var rigidbody = gameObject.GetComponent<Rigidbody>(); 
    rigidbody.constraints = RigidbodyConstraints.FreezeRotation; // 更准确的方法是使用RigidbodyConstraints枚举 
    // rigidbody.freezeRotation = true; // 这行代码在Unity的API中不是直接可用的，应使用上面的枚举方式 }
```
请注意，`rigidbody.freezeRotation = true;` 这行代码在Unity的API中不是直接可用的。正确的方法是使用`RigidbodyConstraints`枚举来设置约束，如上面的示例所示。

## 碰撞器（Colliders）
您可以向GameObject添加任何Unity 3D碰撞器。当添加碰撞器组件时，Unity会将其大小设置为与精灵的边界相匹配，但这很可能不正确。请确保将碰撞器的大小设置为所需的体积。您可能需要根据精灵的实际大小和形状来调整碰撞器的尺寸和形状，以确保物理模拟的准确性。

要获取更多信息，请访问Unity的官方文档。