# Property Binders|属性绑定器
Property Binders(属性绑定器)是可以通过 [Visual Effect 组件](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/VisualEffectComponent.html)附加到游戏对象的 C# 行为。使用这些行为可在 scene 或 gameplay 值与此 Visual Effect 实例的 [Exposed Properties(公开属性)](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Blackboard.html#exposed-properties-in-inspector) 之间建立连接。

例如，Sphere Binder 可以使用场景中链接的球体碰撞器的值自动设置球体公开属性的位置和半径。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/PropertyBinders.html#adding-property-binders)添加属性绑定器
![[Pasted image 20241025132047.png]]

您可以通过名为 **VFX Property Binder** 的通用 MonoBehaviour 添加属性绑定器。此行为允许使用一个或多个**属性绑定**。每个属性绑定负责在[公开属性](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Blackboard.html#exposed-properties-in-inspector)和运行时或场景元素之间创建一个关系。

您还可以通过 **Add Component （添加组件**） 菜单添加 Property Binders。如果 VFX Property Binder 组件尚不存在，Unity 会自动创建一个组件。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/PropertyBinder_example.png)

> 以下是使用 Property Binder 将游戏对象的**变换**和**位置**绑定到 VFX 图形的类似类型的公开属性的示例。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/PropertyBinders.html#built-in-property-binders)内置属性绑定器
Visual Effect Graph 包附带以下内置属性绑定器：
- Audio|音频
    - **Audio Spectrum to AttributeMap**：将 Audio Spectrum 烘焙到 Attribute 映射，并将其绑定到 Texture2D 和 uint Count 属性。
- GameObject：
    - **Enabled**：将游戏对象的 Enabled 标志绑定到一个布尔属性上。这可以用来根据游戏对象的启用状态来控制粒子效果。
- Point Cache|点缓存：
    - **Hierarchy to AttributeMap（将层次结构到 AttributeMap**）：将层级结构中的变换位置和目标位置绑定到 Texture2D 的 AttributeMaps 和 uint 类型的 Count 上。
    - **Multiple Position Binder**：将一系列变换的位置绑定到一个 Texture2D 的 AttributeMap 和 uint 类型的 Count 上。
- Input|输入：
    - **Axis**（轴） ：将 Input Axis （输入轴） 的浮点值绑定到 float 属性。
    - **Button**：将按钮按下状态的 bool 值绑定到 bool 属性。
    - **Key|键**：将键盘按键状态的 bool 值绑定到 bool 属性。
    - **Mouse**：将鼠标的常规值（Position、Velocity、Clicks）绑定到公开的属性。
    - **Touch**（触摸）：将 Touch Input （触摸输入） 的输入值（Position， Velocity）绑定到公开的属性。
- Utility|效用：
    - **Light**：将 Light 属性（Color、Brightness、Radius）绑定到公开的属性。
    - **Plane**：将 Plane 属性（Position、Normal）绑定到公开的属性。
    - **Terrain|地形**：将地形属性（大小、高度贴图）绑定到公开的属性。
- Tranform|变换：
    - **Position**：将游戏对象位置绑定到矢量公开属性。在 Binder 中，您需要在属性名称的末尾添加 “__position” ，以便它按所示工作。
    - **Position （previous）**：将上一个游戏对象位置绑定到 vector exposed 属性。
    - **Transform**：将游戏对象 transform 绑定到 transform 公开的属性。
    - **Velocity**：将游戏对象速度绑定到向量公开属性。
- Physics|物理：
    - **Raycast**：执行物理光线投射并将其结果值（hasHit、Position、Normal）绑定到公开的属性。
- Collider碰撞器：
    - **Sphere**：将 Sphere Collider （球体碰撞体） 的属性绑定到 Sphere （球体） 公开的属性。
- UI|用户界面：
    - **Dropdown**：将 Dropdown 的索引绑定到 uint 公开的属性。
    - **Slider**：将 float 滑块的值绑定到 uint 公开的属性。
    - **Toggle**：将切换开关的 bool 值绑定到 bool 公开的属性。

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/PropertyBinders.html#writing-property-binders)编写属性绑定器
要编写属性绑定器，请将新的 C# 类添加到您的项目中，并扩展`UnityEngine.VFX.Utility.VFXBinderBase`类 .

要扩展该类，请使用以下方法之一：`VFXBinderBase`
- `bool IsValid(VisualEffect component)`：验证是否可以进行绑定的方法。VFX Property Binder 组件仅在此方法返回 true 时执行。您需要在此方法中实现所有检查，以确定 binding.`UpdateBinding()`
- `void UpdateBinding(VisualEffect component)`：如果返回 true，则此方法应用绑定。`IsValid`

## 演例中的属性绑定器

#### [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/PropertyBinders.html#example-code)示例代码
以下示例演示了一个简单的 Property Binder，它将浮点型 Property 值设置为当前游戏对象与另一个（目标）游戏对象之间的距离：

```csharp
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

// The VFXBinder Attribute will populate this class into the property binding's add menu.
[VFXBinder("Transform/Distance")]
// The class need to extend VFXBinderBase
public class DistanceBinder : VFXBinderBase
{
    // VFXPropertyBinding attributes enables the use of a specific
    // property drawer that populates the VisualEffect properties of a
    // certain type.
    [VFXPropertyBinding("System.Single")]
    public ExposedProperty distanceProperty;

    public Transform target;

    // The IsValid method need to perform the checks and return if the binding
    // can be achieved.
    public override bool IsValid(VisualEffect component)
    {
        return target != null && component.HasFloat(distanceProperty);
    }

    // The UpdateBinding method is the place where you perform the binding,
    // by assuming that it is valid. This method will be called only if
    // IsValid returned true.
    public override void UpdateBinding(VisualEffect component)
    {
        component.SetFloat(distanceProperty, Vector3.Distance(transform.position, target.position));
    }
}
```