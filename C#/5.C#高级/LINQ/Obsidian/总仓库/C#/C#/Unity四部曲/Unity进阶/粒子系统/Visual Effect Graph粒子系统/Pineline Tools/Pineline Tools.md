[[在视觉效果中表示复杂形状]]
[[公开属性类(Exposed​Property Helper)]]
[[矢量场(Vector Field)]]
[[网格采样(Mesh sampling)]]
# 公开属性类
“ExposedProperty”类是一个 helper 类，它根据属性的名称存储属性 ID。您分配给“ExposedProperty”的值是一个着色器属性的字符串名称。该类自动调用“Shader.PropertyToID (string name)”函数，以该着色器属性名称为参数，并存储函数返回的整数 ID。当您在 [组件 API](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/ComponentAPI.html) 中的属性、事件或 EventAttribute 方法中使用此类时，它隐式地使用这个整数。

当您想要访问一个着色器属性时，可以使用该属性的名称或其 ID。使用属性名称通常更加方便，但使用属性的整数 ID 更有效率。这个类很有用，因为它结合了使用属性名称的便利性和使用属性 ID 的效率。

## 代码示例
```
ExposedProperty m_MyProperty;
VisualEffect m_VFX;

void Start()
{
    m_VFX = GetComponent<VisualEffect>();
    m_MyProperty = "My Property"; // 分配一个字符串。
}

void Update()
{
    m_VFX.SetFloat(m_MyProperty, someValue); // 使用属性 ID。
}
```