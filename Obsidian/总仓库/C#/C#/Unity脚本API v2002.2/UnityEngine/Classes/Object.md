class in UnityEngine
## 描述

Unity 可以引用的所有对象的基类。

您从 Object 派生的任何公共变量都将在 Inspector 中显示为放置目标， 让您能够从 GUI 设置其值。UnityEngine.Object 是所有 Unity 内置对象的基类。  
  
虽然 Object 是一个类，但其本意不是为了在脚本中广泛使用。 但是作为示例，我们在 [Resources](https://docs.unity.cn/cn/2022.2/ScriptReference/Resources.html) 类中使用了 Object。请参阅使用 [[Object]] 作为返回值的 [Resources.LoadAll](https://docs.unity.cn/cn/2022.2/ScriptReference/Resources.LoadAll.html)。  
  
该类不支持 [null 条件运算符](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#null-conditional-operator) (**?.**) 和 [null 合并运算符](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#the-null-coalescing-operator) (**??**)。  
  
See Also: [ScriptableObject](https://docs.unity.cn/cn/2022.2/ScriptReference/ScriptableObject.html).

## 变量

| [hideFlags](https://docs.unity.cn/cn/2022.2/ScriptReference/Object-hideFlags.html) | 该对象应该隐藏、随场景一起保存还是由用户修改？ |
| ---------------------------------------------------------------------------------- | ----------------------- |
| [name](https://docs.unity.cn/cn/2022.2/ScriptReference/Object-name.html)           | 对象的名称。                  |
### **hideFlags**: 
- 一个枚举值，用于控制对象在Unity编辑器中的可见性和保存行为。你可以通过修改这个属性来决定对象是否应该在Hierarchy视图中隐藏，是否应该随场景一起保存，或者是否允许用户通过Inspector面板修改其属性。

`HideFlags` 枚举是一个使用 `[Flags]` 属性标记的枚举，这意味着它的值可以通过按位或运算符（`|`）组合起来，以表示多个选项。这个枚举用于控制Unity编辑器中对象的显示、保存和卸载行为。

下面是对 `HideFlags` 枚举中每个成员的简要说明：

- `None = 0`：对象正常显示，没有特殊的隐藏或保存行为。这是默认值。
    
- `HideInHierarchy = 1`：对象在Hierarchy视图中隐藏，但仍然会出现在Inspector面板中，并且会随场景一起保存。
    
- `HideInInspector = 2`：对象在Inspector面板中隐藏，但仍在Hierarchy视图中可见，并且会随场景一起保存。
    
- `DontSaveInEditor = 4`：对象在编辑器中不会被保存到场景文件中。这通常用于临时对象，或者你不希望它们被意外保存到场景中的情况。
    
- `NotEditable = 8`：对象在Inspector面板中显示为只读，但仍然可见和可访问。
    
- `DontSaveInBuild = 0x10`（16）：对象在构建播放器时不会被保存。这对于那些仅在编辑器中使用，而不需要在最终游戏中出现的资源很有用。
    
- `DontUnloadUnusedAsset = 0x20`（32）：对于资源（如Texture、Material等），这个标志防止Unity在资源未被引用时自动卸载它们。这通常用于你希望在游戏运行期间持续可用的资源。
    
- `DontSave = 0x34`（52）：这是一个组合标志，等同于 `DontSaveInBuild | DontSaveInEditor | DontUnloadUnusedAsset`。它表示对象既不会在构建中保存，也不会在编辑器中保存，并且不会被`Resources.UnloadUnusedAssets`卸载。
    
- `HideAndDontSave = 0x3D`（61）：这是另一个组合标志，它隐藏对象（在Hierarchy和可能的Inspector中，取决于其他标志的组合），并且不会将其保存到场景中。这通常用于临时对象，你希望在加载新场景时自动销毁它们，同时又不希望它们在编辑器中占用空间或影响性能。
使用 `hideFlags` 的基本方法如下：
```
public class MyScript : MonoBehaviour  
{  
    void Start()  
    {  
        // 设置当前 GameObject 在 Hierarchy 中隐藏  
        gameObject.hideFlags = HideFlags.HideInHierarchy;  
  
        // 或者，组合使用多个标志  
        // 例如，隐藏在 Hierarchy 和 Inspector 中，但随场景一起保存  
        gameObject.hideFlags = HideFlags.HideInHierarchy |        HideFlags.HideInInspector;  
  
        // 注意：通常不会在 Start 方法中更改 hideFlags，因为这会影响编辑器的行为  
        // 更改 hideFlags 通常在编辑时通过脚本编辑器或自定义编辑器进行  
    }  
  
    // 注意：由于 hideFlags 主要影响编辑器的行为，因此更改它的代码通常不会出现在游戏的运行逻辑中  
    // 如果你需要在运行时控制某些行为，请考虑使用其他机制（如启用/禁用组件、设置 GameObject 的 activeSelf 等）  
}
```
### **name**: 
对象的名称，这是一个字符串属性，用于唯一标识对象。你可以通过修改这个属性来改变对象的名称。
## 公共函数

| [GetInstanceID](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.GetInstanceID.html) | Gets the instance ID of the object. |
| ------------------------------------------------------------------------------------------ | ----------------------------------- |
| [ToString](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.ToString.html)           | 返回对象的名称。                            |
### **GetInstanceID()**: 
获取对象的实例ID。这个ID在当前Unity会话中是唯一的，但它不是持久的，即不同的会话或运行之间可能会不同。
### **ToString()**: 
返回对象的名称。这通常与`name`属性的值相同，但如果你重写了`ToString`方法，它可能会返回不同的字符串。
## 静态函数

| [Destroy](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.Destroy.html)                             | 移除 GameObject、组件或资源。                                   |
| ---------------------------------------------------------------------------------------------------------- | ------------------------------------------------------ |
| [DestroyImmediate](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.DestroyImmediate.html)           | 立即销毁对象 /obj/。强烈建议您改用 Destroy。                          |
| [DontDestroyOnLoad](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.DontDestroyOnLoad.html)         | 在加载新的 Scene 时，请勿销毁 Object。                             |
| [FindAnyObjectByType](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.FindAnyObjectByType.html)     | Retrieves any active loaded object of Type type.       |
| [FindFirstObjectByType](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.FindFirstObjectByType.html) | Retrieves the first active loaded object of Type type. |
| [FindObjectOfType](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.FindObjectOfType.html)           | 返回第一个类型为 type 的已加载的激活对象。                               |
| [FindObjectsByType](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.FindObjectsByType.html)         | Retrieves a list of all loaded objects of Type type.   |
| [FindObjectsOfType](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.FindObjectsOfType.html)         | Gets a list of all loaded objects of Type type.        |
| [Instantiate](https://docs.unity.cn/cn/2022.2/ScriptReference/Object.Instantiate.html)                     | 克隆 original 对象并返回克隆对象。                                 |
### **Destroy(Object obj, float t = 0.0f)**: 
销毁一个GameObject、Component或资源。如果提供了时间`t`，则对象会在`t`秒后被销毁；如果不提供时间，对象会在当前帧结束时被销毁。
### **DestroyImmediate(Object obj)**: 
立即销毁一个对象。这个函数会立即从内存中移除对象，但使用时需要小心，因为它可能会导致一些不可预见的问题，比如对象引用仍然有效但对象已经被销毁。因此，官方推荐尽可能使用`Destroy`而不是`DestroyImmediate`。
### **DontDestroyOnLoad(Object target)**: 
标记一个对象，使其在加载新场景时不被销毁。这通常用于保持游戏状态（如玩家数据、UI等）跨场景持久存在。
### **FindObjectOfType< T >()**: 
返回第一个类型为`T`的已加载并激活的对象。如果没有找到任何对象，则返回“null”。
### **FindObjectsOfType< T >()**: 
返回所有类型为`T`的已加载并激活的对象的列表。如果没有找到任何对象，则返回一个空数组。注意：这个函数在文档中出现了两次，但实际上它们指的是同一个函数。
### **Instantiate(Object original, ...)**: 
克隆一个对象（如GameObject或Component），并可以指定其位置、旋转和父对象。这个函数返回克隆后的对象。
## 运算符

| [bool](https://docs.unity.cn/cn/2022.2/ScriptReference/Object-operator_Object.html)    | 该对象是否存在？                |
| -------------------------------------------------------------------------------------- | ----------------------- |
| [operator !=](https://docs.unity.cn/cn/2022.2/ScriptReference/Object-operator_ne.html) | 比较两个对象是否引用不同的对象。        |
| [operator ==](https://docs.unity.cn/cn/2022.2/ScriptReference/Object-operator_eq.html) | 比较两个对象引用，判断它们是否引用同一个对象。 |
- `UnityEngine.Object` 类不支持null条件运算符（`?.`）和null合并运算符（`??`），因此在使用时需要显式地检查对象是否为`null`。
- 尽管`Object`是一个基类，但通常不建议从它直接派生自定义类，因为Unity的序列化机制对`UnityEngine.Object`派生类的处理比较特殊。如果你的目的是创建可序列化的数据类，请考虑使用`ScriptableObject`。
- 当你从`Object`派生类时，请确保了解Unity对对象生命周期和内存管理的处理方式，以避免内存泄漏或其他问题。