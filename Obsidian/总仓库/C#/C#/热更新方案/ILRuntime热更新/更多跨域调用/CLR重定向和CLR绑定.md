主入口：![[ILRuntimeMain.cs]]
![[Lesson13.cs]]
![[ILRuntimeMgr 2.cs]]


## CLR（Common Language Runtime）
公共语言运行时，它是.Net Framework的基础，所有的.Net技术都是建立在此之上的。它帮助我们实现了跨语言和跨平台。

它是一个在执行时管理代码的代码，提供内存管理、线程管理等等核心服务，就好像一个小型的操作系统一样。所以形象的把它称为“.Net虚拟机”。

如果想要应用程序在目标操作系统上能够运行，就必须依靠.Net提供的CLR环境来支持。

### CLR重定向是什么
CLR重定向主要是用于对热更工程中的的一些方法进行”挟持”，就是将原本的方法”挟持”了，重新实现方法里面的逻辑，达到重定向的目的。

说人话：
我们可以通过CLR重定向，将某一个方法的执行定位到我们的自定义逻辑中，而不是执行原本的方法逻辑。有点类似重写。

### CLR绑定的作用和原理
默认情况下，ILRuntime热更工程调用Unity主工程相关内容都会通过反射来调用，这样有2个缺点：
1. 性能较低，反射调用比直接调用效率低。
2. IL2CPP打包时容易被裁剪。

因此ILRuntime提供了自动分析生成CLR绑定的工具，它的作用是：
1. 可以提高性能，将反射调用变为了直接调用。
2. 避免IL2CPP裁剪有用内容。

原理：
CLR绑定，就是借助了ILRuntime的CLR重定向机制来实现的，本质上就是将方法的反射调用重定向到了我们自定义的方法里面来。

注意：
<font color="#ffff00">每次我们打包发布工程之前都要记得生成CLR绑定。</font>

### 如何进行CLR绑定
#### CLR绑定步骤概述
1. 打开 `Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCLRBinding.cs` 代码，在 `InitILRuntime` 函数中注册跨域继承相关的类以及其他内容（以后会讲解）。![[ILRuntimeCLRBinding.cs]]
2. 点击 工具栏——>ILRuntime——>通过自动分析热更DLL生成CLR绑定，此时就可以在 `ILRuntimeCLRBinding.cs` 代码中设置的导出路径中看到生成的绑定代码。
3. 在初始化处添加：`ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain)`。

注意：
如果在CLR绑定注册前进行了CLR重定向相关设置，为了保证自定义的重定向能够正常使用，初始化CLR绑定一定要放在最后一步，这样就不会影响自己想要保留的重定向等初始化操作了。

打开ILRuntimeCLRBinding脚本，在InitILRuntime函数添加我们注册适配器的代码。添加了之后等一下点击才能生成我们跨域继承适配器的绑定类。

```cs
static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain domain)
{
    //这里需要注册所有热更DLL中用到的跨域继承Adapter，否则无法正确抓取引用
    domain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
    domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
    domain.RegisterCrossBindingAdaptor(new TestClassBaseAdapter());
    
    
    //注册跨域继承的父类适配器 我们自己手动添加进来的 其他注册是其他官方测试示例添加的
    domain.RegisterCrossBindingAdaptor((new Lesson12_FatherAdapter()));
    domain.RegisterCrossBindingAdaptor((new Lesson13_FatherAdapter()));
    domain.RegisterCrossBindingAdaptor((new Lesson13_InterfaceAdapter()));
    domain.RegisterCrossBindingAdaptor((new Lesson13_InheritAllAdapter()));
    
    
    domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
    domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
    domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
}
```

点击 工具栏——>ILRuntime——>通过自动分析热更DLL生成CLR绑定，执行的其实就是ILRuntimeCLRBinding脚本的GenerateCLRBindingByAnalysis方法。此时就可以在ILRuntimeCLRBinding.cs 代码中设置的导出路径中看到生成的绑定代码。我们自己写的适配器代码绑定也被生成了。

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/1.png)

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/2.png)

在ILRuntimeManager的InitILRuntime方法中添加注册CLR绑定信息的逻辑

```cs
//注册CLR绑定信息
ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);
```

### CLR绑定性能提升测试
#### 测试思路
我们再ILRuntime中去调用Unity中的方法。如果不进行CLR绑定，就是通过反射；如果绑定了，就是直接调用。我们可以通过测试函数来体现出性能的提升。

在Unity工程中写一个静态测试函数
```cs
/// <summary>
/// 用于测试CLR绑定性能提升的函数
/// </summary>
/// <param name="i"></param>
/// <param name="j"></param>
/// <returns></returns>
public static int TestFun(int i, int j)
{
    return i + j;
}
```

在ILRuntime工程进行十万次调用测试，重新生成代码
```cs
//得到当前系统时间
System.DateTime currentTime = System.DateTime.Now;
for (int i = 0; i < 100000; i++)
{
    Lesson14_更多跨域调用_CLR重定向和CLR绑定.TestFun(i, i);
}
Debug.Log("十万次循环花费的时间：" + (System.DateTime.Now - currentTime).TotalMilliseconds + "ms");
```
运行Unity，测试十万次循环的事件。注意，现在直接在Unity运行是不会优化性能的。因为我们是再之前绑定后，新加的代码。之前绑定时还没有TestFun这个方法，在IlRuntime工程也没有调用。

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/3.png)

重新点击CLR绑定。会分析有哪些使用的方法和类。可以看到因为我们用了Lesson14脚本所以也被绑定了，内部绑定的是TestFun方法。因为在IlRuntime工程调用了。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/1.png)
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/4.png)

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/5.png)

重新运行优化性能后的代码，性能得到显著提升。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/6.png)

### 自定义CLR重定向
我们以Debug.Log举例，如果在ILRuntime工程中调用Debug.Log，我们是无法获取到热更工程中的脚本、行号相关信息的。比如之前我们 Debug.Log(“十万次循环花费的时间：” + (System.DateTime.Now - currentTime).TotalMilliseconds + “ms”); 

在Unity看不到热更工程是在哪一行打印的。我们可以通过CLR重定向的形式获取到信息后再打印。

步骤：
1. 利用CLR绑定中自动生成的绑定代码，反射获取Debug中的Log函数，对其进行重定向。
2. 在重定向中调用Debug.Log之前，获取DLL内的堆栈信息最后拼接打印。

注意：
要使用CLR重定向时，需要在unsafe语句块中使用，所以我们需要在定义重定向函数和使用重定向函数的地方加上unsafe。

主要目标是，让Unity的Log走进我们自己写的Log函数中，在我们的Log中能打印在热更工程行号信息。现在我们直接运行是看不到的行号的。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/7.png)

打开CLR绑定UnityDebug相关脚本，可以看到CLR绑定是通过反射得到方法，并替换成下方的自己Log0方法
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/8.png)

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/9.png)

新版本不同
```cs
static StackObject* Log_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
{
    ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
    StackObject* ptr_of_this_method;
    StackObject* __ret = ILIntepreter.Minus(__esp, 1);

    ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
    System.Object @message = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
    __intp.Free(ptr_of_this_method);


    UnityEngine.Debug.Log(@message);

    return __ret;
}
```

我们可以拷贝Log_0方法到我们Ilruntime管理器，再原绑定函数的基础上修改，改方法名改成MyLog，改成非静态的方法。AutoList改成List。注意因为用到指针相关，要用到unsafe关键字。原Debug绑定脚本没使用unsafe修饰是因为他一整个类都是unsafe修饰的，unsafe class UnityEngine_Debug_Binding。使用__domain.DebugService.GetStackTrace(__intp);获取行号，打印时拼接了行号信息。

```cs
// MyLog函数用于记录日志，并输出调用栈信息
// 参数：
//   __intp: ILRuntime解释器实例
//   __esp: 栈指针
//   __mStack: 托管堆栈
//   __method: 当前方法
//   isNewObj: 是否为新对象
unsafe StackObject* MyLog(ILIntepreter __intp, StackObject* __esp, List<object> __mStack, CLRMethod __method, bool isNewObj)
{
    // 获取当前应用程序域
    ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
    // 指针的声明
    StackObject* ptr_of_this_method;
    // 为了方便减法运算，计算栈顶指针位置
    StackObject* __ret = ILIntepreter.Minus(__esp, 1);

    // 获取栈顶参数的指针
    ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
    // 将栈顶参数转换为System.Object类型
    System.Object @message = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (ILRuntime.CLR.Utils.Extensions.TypeFlags)0);
    // 释放栈顶参数的指针
    __intp.Free(ptr_of_this_method);

    // 获取调用栈信息 是我们自己添加的
    var stackTrace = __domain.DebugService.GetStackTrace(__intp);

    // 输出日志信息和调用栈信息
    UnityEngine.Debug.Log(@message + "\n" + stackTrace);

    return __ret;
}
```

查看自动生成的绑定脚本UnityEngine_Debug_Binding的重定向代码逻辑，准备进行模仿。在Ilruntime管理器的InitILRuntime方法中，要在注册CLR绑定信息前，进行CLR重定向MyLog中。使用反射得到Debug的Type，再得到Debug中Log方法的方法信息进行重定向。模仿UnityEngine_Debug_Binding的重定向代码逻辑即可。

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/9.png)

```cs
Type type = typeof(UnityEngine.Debug);
args = new Type[]{typeof(System.Object)};
method = type.GetMethod("Log", flag, null, args, null);
app.RegisterCLRMethodRedirection(method, Log_0);
```

```cs
/// <summary>
/// 初始化ILRuntime相关的内容
/// </summary>
unsafe private void InitILRuntime()
{
    //其他初始化
            
    //委托注册
    //...
            
    //注册跨域继承的父类适配器
     //...          
    
    //CLR重定向内容 要写到CLR绑定之前 我们重定向到自己的MyLog函数中
    //得到想要重定向类的Type
    System.Type debugType = typeof(Debug);
    //得到想要重定向方法的方法信息
    MethodInfo methodInfo = debugType.GetMethod("Log", new System.Type[] { typeof(object) });
    //进行CLR重定向
    appDomain.RegisterCLRMethodRedirection(methodInfo, MyLog);
    
    //注册CLR绑定信息
    ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);
    
    //初始化ILRuntime相关信息（目前只需要告诉ILRuntime主线程的线程ID，主要目的是能够在Unity的Profiler剖析器窗口中分析问题）
    appDomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
}
```

现在可以看到我们在热更工程第几行打印信息的。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/10.png)

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/14.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-CLR%E9%87%8D%E5%AE%9A%E5%90%91%E5%92%8CCLR%E7%BB%91%E5%AE%9A/11.png)
### 总结
CLR绑定就是利用CLR重定向将原本需要反射调用的内容变为直接调用，可以帮助我们：
1. 提升ILRuntime的性能。
2. 避免IL2CPP打包时裁剪我们需要用的内容。
