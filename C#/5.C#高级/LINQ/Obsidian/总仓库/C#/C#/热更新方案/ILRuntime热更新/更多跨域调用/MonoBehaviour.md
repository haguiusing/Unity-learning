主入口：![[ILRuntimeMain.cs]]
![[Lesson15.cs]]
![[ILRuntimeMono.cs]]
### ILRuntime不推荐直接使用MonoBehaviour
ILRuntime中支持在热更工程中跨域继承`MonoBehaviour`。
1. 注册跨域继承适配器。
2. 对泛型方法`AddComponent`进行重定向（较为复杂）。

但是，ILRuntime并不推荐通过跨域继承直接使用`MonoBehaviour`。推荐大家类似Lua中一样使用`MonoBehaviour`，在主工程中通过委托或事件的形式派发生命周期函数到热更中。

主要原因：  
`MonoBehaviour`是一个很特殊的类，很多底层逻辑是在C++中处理的，比如其中public字段的序列化，在Inspector窗口中显示的功能。如果在热更工程中去写，底层C++逻辑无法获取到热更工程中C#相关的信息。

### 派发生命周期函数的形式使用MonoBehaviour
思路:
在主工程中实现一个脚本，该脚本的主要目的就是派发`MonoBehaviour`的生命周期函数供热更工程中使用。

Unity工程中声明ILRuntimeMono类，定义各个生命周期的事件
```cs
public class ILRuntimeMono : MonoBehaviour
{
    // Awake相当于构造函数，在脚本添加的时候就会自动执行
    // 所以它不能使用这种事件分发的形式去触发它
    // public event Action awakeEvent;
    public event Action startEvent;
    public event Action updateEvent;

    // private void Awake()
    // {
    //     awakeEvent?.Invoke();
    // }
    
    void Start()
    {
        startEvent?.Invoke();
    }
    
    void Update()
    {
        updateEvent?.Invoke();
    }
}
```

在ILRuntime工程直接添加ILRuntimeMono组件并添加事件函数。注意Awake函数添加委托没意义，因为不会执行。
```
GameObject obj = new GameObject();
ILRuntimeMono mono = obj.AddComponent<ILRuntimeMono>();

// 由于Awake执行时机的特殊性，Awake会在脚本添加时自动执行，我们可以在添加了对应脚本后直接执行初始化相关逻辑即可
// 无需通过事件或者委托的形式去触发它
Debug.Log("Awake");
// mono.awakeEvent += () =>
// {
//     Debug.Log("Awake");
// };
mono.startEvent += () =>
{
    Debug.Log("Start");
};

mono.updateEvent += () =>
{
    Debug.Log("Update");
};
```

### 总结
ILRuntime中虽然支持跨域继承`MonoBehaviour`，但是作者并不建议大家这样做。我们可以通过类似Lua热更中那样，在主工程中实现用于派发生命周期函数的公共脚本，通过委托或事件达到生命周期函数的调用。