# Unity 中的 Sprite Resolver 组件
新版本Sprite Resolver多了合集功能需要手动挂载到子物体挂载，并保留一个子物体作为切换使用，将其他子物体死活或删除

Sprite Resolver 组件从分配给角色预制件根部的 [Sprite Library 组件](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-component.html)的 [Sprite Library 资源](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Asset.html)中提取信息，并显示可供选择的 Sprite。此组件是 [Sprite Swap 设置和工作流程](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SpriteSwapSetup.html)的一部分，通过将 Sprite Resolver 组件附加到属于角色预制件的游戏对象，可以更改该游戏的 [Sprite Renderer 组件](https://docs.unity.cn/Manual/class-SpriteRenderer.html)渲染的精灵。

## 属性设置

该组件包含两个属性（[Category](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#categories) 和 [Label](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/SL-Editor.html#labels)）以及 **Visual variant selector** 界面，该界面显示 Sprite Library 资源中 Sprite 的缩略图。

![](https://docs.unity.cn/Packages/com.unity.2d.animation@9.0/manual/images/2D-animation-SResolver-properties.png)  
_Sprite Resolver 组件的 Inspector 窗口属性。_

|财产|功能|
|---|---|
|**类别**|选择包含要用于此游戏对象的 Sprite 的 **Category**。|
|**标签**|选择要用于此游戏对象的 Sprite 的 **Label** name。|
|**视觉对象变体选择器**|选择要使用的 Sprite 的缩略图。此选择器显示上面所选 Category 中包含的所有 Sprite。|
# Class SpriteResolver
更新 SpriteRenderer 的 Sprite 引用，以设置它的 Category 和 Label 值。

##### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object)

[Behaviour](https://docs.unity3d.com/2022.2/Documentation/ScriptReference/Behaviour.html)

[MonoBehaviour](https://docs.unity3d.com/2022.2/Documentation/ScriptReference/MonoBehaviour.html)

SpriteResolver

##### Implements

[ISerializationCallbackReceiver](https://docs.unity3d.com/2022.2/Documentation/ScriptReference/ISerializationCallbackReceiver.html)

IPreviewable

##### Inherited Members

[MonoBehaviour.IsInvoking()](https://docs.unity3d.com/2022.2/Documentation/ScriptReference/MonoBehaviour.IsInvoking.html)

[MonoBehaviour.CancelInvoke()](https://docs.unity3d.com/2022.2/Documentation/ScriptReference/MonoBehaviour.CancelInvoke.html)

[MonoBehaviour.Invoke(string, float)](https://learn.microsoft.com/dotnet/api/system.string)

[MonoBehaviour.InvokeRepeating(string, float, float)](https://learn.microsoft.com/dotnet/api/system.string)

[MonoBehaviour.CancelInvoke(string)](https://learn.microsoft.com/dotnet/api/system.string)

###### **Namespace**: [UnityEngine](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.html).[U2D](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.html).[Animation](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.html)

###### **Assembly**: solution.dll

##### Syntax

```csharp
[ExecuteInEditMode]
[DisallowMultipleComponent]
[AddComponentMenu("2D Animation/Sprite Resolver")]
[Icon("Packages/com.unity.2d.animation/Editor/Assets/ComponentIcons/Animation.SpriteResolver.png")]
[DefaultExecutionOrder(-2)]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/manual/SL-Resolver.html")]
[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
public class SpriteResolver : MonoBehaviour, ISerializationCallbackReceiver, IPreviewable
```

### [Properties](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.html#properties)

|Name|Description|
|---|---|
|[spriteLibrary](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.spriteLibrary.html#UnityEngine_U2D_Animation_SpriteResolver_spriteLibrary)|Property to get the SpriteLibrary the SpriteResolver is resolving from.|

### [Methods](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.html#methods)

| Name                                                                                                                                                                                                                                                                | Description                                                       |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- |
| [GetCategory()](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.GetCategory.html#UnityEngine_U2D_Animation_SpriteResolver_GetCategory)                                                                    | 获取 SpriteResolver 的 Category 集。                                   |
| [GetLabel()](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.GetLabel.html#UnityEngine_U2D_Animation_SpriteResolver_GetLabel)                                                                             | 获取 SpriteResolver 的 Label 集。                                      |
| [OnPreviewUpdate()](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.OnPreviewUpdate.html#UnityEngine_U2D_Animation_SpriteResolver_OnPreviewUpdate)                                                        | Empty 方法。为 IPreviewable 接口实现。                                     |
| [ResolveSpriteToSpriteRenderer()](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.ResolveSpriteToSpriteRenderer.html#UnityEngine_U2D_Animation_SpriteResolver_ResolveSpriteToSpriteRenderer)              | 将 SpriteResolver 中的 Sprite 设置为同一 GameObject 中的 SpriteRenderer 组件。 |
| [SetCategoryAndLabel(string, string)](https://docs.unity3d.com/Packages/com.unity.2d.animation@9.0/api/UnityEngine.U2D.Animation.SpriteResolver.SetCategoryAndLabel.html#UnityEngine_U2D_Animation_SpriteResolver_SetCategoryAndLabel_System_String_System_String_) | 设置要使用的 Category （类别） 和 label （标签）。                                |
