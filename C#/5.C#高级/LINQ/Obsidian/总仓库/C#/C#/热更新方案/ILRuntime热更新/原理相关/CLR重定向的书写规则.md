![[Lesson25 1.cs]]

### 回顾自定义重定向流程
[[CLR重定向和CLR绑定]]
得到重定向类的Type  
得到想要重定向方法的方法信息  
使用AppDomain中的注册重定向方法RegisterCLRMethodRedirection进行重定向方法关联

```cs
//CLR重定向内容 要写到CLR绑定之前
//得到想要重定向类的Type
System.Type debugType = typeof(Debug);
//得到想要重定向方法的方法信息
MethodInfo methodInfo = debugType.GetMethod("Log", new System.Type[] { typeof(object) });
//进行CLR重定向
appDomain.RegisterCLRMethodRedirection(methodInfo, MyLog);
```

### 回顾ILRuntime中方法指令的调用
在执行代码时，ILRuntime内部自己实现了的运行栈来管理内存
```cs
参数1  
参数2 ——————> 返回值  
栈指针
```

### 重定向函数的规则套路

1. 通过解析器获取appdomain
2. 获取栈底指针（根据函数参数数量决定减多少，用于之后返回）
3. 获取函数参数
4. 参数类型转换
5. 释放对应栈指针内存
6. 重定向处理
7. 返回当前栈顶（栈指针位置）  
    7-1：无返回值  
	    直接返回之前记录的栈底位置  
    7-2: 有返回值  
	    如果是简单类型，直接设置后返回  
	    如果是复杂类型，使用PushObject方法

#### UnityEngine_Vector3_Binding类Dot方法的重定向函数
比如我们去CLR重定向自动生成的UnityEngine_Vector3_Binding绑定类查看Dot方法的重定向函数
![[Pasted image 20250603212319.png]]
```cs
// 会在注册函数进行注册
public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
{
    // 声明 BindingFlags 枚举，指定反射查找方法的标志
    BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                        BindingFlags.DeclaredOnly;
    MethodBase method;
    Type[] args;
    // 获取 UnityEngine.Vector3 类型
    Type type = typeof(UnityEngine.Vector3);
    args = new Type[] { typeof(UnityEngine.Vector3), typeof(UnityEngine.Vector3) };
    // 获取 Dot 方法的 MethodBase 对象
    method = type.GetMethod("Dot", flag, null, args, null);
    // 将 Dot 方法重定向到 Dot_0 方法
    app.RegisterCLRMethodRedirection(method, Dot_0);
    //...
}
```

```cs
static StackObject* Dot_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method,
    bool isNewObj)
{
    // 1.通过解释器获取 AppDomain 实例
    ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;

    StackObject* ptr_of_this_method; // 定义方法指针

    // 2.获取栈底指针（根据函数参数数量决定减多少，用于之后返回）
    StackObject* __ret = ILIntepreter.Minus(__esp, 2);

    // 3.获取函数参数 @rhs
    ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
    UnityEngine.Vector3 @rhs = new UnityEngine.Vector3();
    // 判断是否存在绑定信息，用于解析参数类型
    if (ILRuntime.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null)
    {
        // 将参数值解析为 UnityEngine.Vector3 类型
        ILRuntime.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @rhs,
            __intp, ptr_of_this_method, __mStack, true);
    }
    else
    {
        // 4.参数类型转换
        @rhs = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(
            StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)16);
        // 5.释放对应栈指针内存
        __intp.Free(ptr_of_this_method);
    }

    // 3.获取函数参数 @lhs
    ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
    UnityEngine.Vector3 @lhs = new UnityEngine.Vector3();
    // 判断是否存在绑定信息，用于解析参数类型
    if (ILRuntime.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder != null)
    {
        // 将参数值解析为 UnityEngine.Vector3 类型
        ILRuntime.Runtime.Generated.CLRBindings.s_UnityEngine_Vector3_Binding_Binder.ParseValue(ref @lhs,
            __intp, ptr_of_this_method, __mStack, true);
    }
    else
    {
        // 4.参数类型转换
        @lhs = (UnityEngine.Vector3)typeof(UnityEngine.Vector3).CheckCLRTypes(
            StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)16);
        // 5.释放对应栈指针内存
        __intp.Free(ptr_of_this_method);
    }

    // 6.调用真正的重定向处理方法，计算 Dot 乘积
    var result_of_this_method = UnityEngine.Vector3.Dot(@lhs, @rhs);

    
    //7.返回当前栈顶（栈指针位置）
    
    //  7-1：无返回值
    //  直接返回之前记录的栈底位置   return __ret;

    //  7-2: 有返回值
    //  如果是简单类型，直接设置后返回
    //  如果是复杂类型，使用PushObject方法 ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
    
    // 返回当前栈顶（栈指针位置）
    // 有返回值，设置栈顶为返回值类型
    __ret->ObjectType = ObjectTypes.Float;
    // 设置返回值
    *(float*)&__ret->Value = result_of_this_method;
    return __ret + 1; // 返回栈顶下一个位置

}
```

### 总结
当我们需要自己实现重定向函数时，我们只需要参考CLR绑定中生成的文档，根据其中的内容进行书写即可。只要我们大概了解了重定向函数的规则套路，我们自然能够看懂和写出我们需要的内容。
