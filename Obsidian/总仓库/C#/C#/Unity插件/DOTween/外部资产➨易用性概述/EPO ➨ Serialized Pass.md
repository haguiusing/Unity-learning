`Serialized Pass` 通常与 Shader 渲染器和材质的 Shader 属性相关联。DOTween Pro 扩展提供了一些方法来对这些 Shader 属性进行插值（Tweening）。
## DOColor(string/int propertyName/id, Color to, float duration)
改变 Shader 属性的颜色值。
- `string/int propertyName/id`: Shader 属性的名称或 ID。
- `Color to`: 目标颜色。
- `float duration`: 插值持续时间。
```csharp
using DG.Tweening;
using UnityEngine;

public class ShaderPropertyTweenExample : MonoBehaviour
{
    public Material myMaterial;

    void Start()
    {
        // 假设 Shader 中有一个名为 "_TintColor" 的颜色属性
        myMaterial.DOColor("_TintColor", Color.red, 1f);
    }
}
```
## DOFade(string/int propertyName/id, float to, float duration)
改变 Shader 属性的透明度（alpha）值。
- `string/int propertyName/id`: Shader 属性的名称或 ID。
- `float to`: 目标透明度（0 完全透明，1 完全不透明）。
- `float duration`: 插值持续时间。
```csharp
// 假设 Shader 中有一个名为 "_Alpha" 的透明度属性
myMaterial.DOFade("_Alpha", 0.5f, 1f);
```
## DOFloat(string/int propertyName/id, float to, float duration)
改变 Shader 属性的浮点数值。
- `string/int propertyName/id`: Shader 属性的名称或 ID。
- `float to`: 目标浮点数值。
- `float duration`: 插值持续时间。
```csharp
// 假设 Shader 中有一个名为 "_Glossiness" 的浮点属性
myMaterial.DOFloat("_Glossiness", 0.8f, 1f);
```
## DOVector(string/int propertyName/id, Vector4 to, float duration)
改变 Shader 属性的向量值。
- `string/int propertyName/id`: Shader 属性的名称或 ID。
- `Vector4 to`: 目标向量值。
- `float duration`: 插值持续时间。
```csharp
// 假设 Shader 中有一个名为 "_MainTex_ST" 的向量属性
myMaterial.DOVector("_MainTex_ST", new Vector4(1f, 1f, 1f, 1f), 1f);
```