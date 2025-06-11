![[Lesson24.cs]]

![[ILIntepreter.cs]]

![[Pasted image 20250603205156.png]]
![[Pasted image 20250603205434.png]]
### ILRuntime中的解释器用来干什么？
当ILRuntime通过Mono.Cecil库将DLL文件中的 IL 中间语言读取出来后，会利用已经写好的相关代码将IL代码解释翻译，之后用于执行。它主要做了以下几个步骤：

1. 遍历方法体中的每一条指令。
2. 使用内部巨大的 switch case 用于处理IL中的每一条指令，判断不同的指令类型来处理对应逻辑。

在执行代码时，使用ILRuntime内部自己实现的运行栈来管理内存。ILRuntime中使用非托管内存，内存不会被GC管理，而是ILRuntime内部自己管理，通过指针直接对内存进行操作。其中使用自定义类 StackObject 来表达基础类型值。

### ILRuntime中的内存布局
在ILRuntime实现的非托管运行栈中存储的对象主要是StackObject对象。在该运行栈中，StackObject对象是依次排列的，我们只需要移动当前的栈指针就可以获取到栈中存储的各数据。
```
                     **StackObject** (栈指针 - 1)
                        ObjectType
                          Value
                         ValueLow
 栈指针   ————>      **StackObject** (栈指针)
                        ObjectType
                          Value
                         ValueLow
                     **StackObject** (栈指针 + 1)
                        ObjectType
                          Value
                         ValueLow
```
### ILRuntime中方法指令的调用
1. 按顺序将参数依次压栈。
2. 利用栈指针的移动获取到各参数进行处理。
3. 清理栈(将栈指针移动到顶部，下方内容就认为会被释放了)。
```
  参数1                  返回值
  参数2                  栈指针
  局部变量1    ——————>
  局部变量2
  栈指针
```

### 关于CLR重定向
我们可以在ILIntepreter脚本中搜索callvirt指令（对对象调用后期绑定方法，并且将返回值推送到计算堆栈上）。  
在该指令处理中，如果直接是IL方法直接执行，不是的话，再判断，如果发现是CLR重定向，会调用对应绑定的委托函数，不是的话调用反射。关键参数是esp 代表当前栈指针位置。  
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/25.%E5%8E%9F%E7%90%86%E7%9B%B8%E5%85%B3-%E8%A7%A3%E9%87%8A%E5%99%A8/1.png)

我们可以在ILIntepreter脚本中搜索.Add，把栈指针前移，得到参数a和b，栈指针最终指向栈顶，计算返回值。  
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/25.%E5%8E%9F%E7%90%86%E7%9B%B8%E5%85%B3-%E8%A7%A3%E9%87%8A%E5%99%A8/2.png)

```cs
 b = esp - 1;
 a = esp - 1 - 1;
 esp = a;
```
![[Pasted image 20250603210908.png]]
栈的生长方向是高地址往低地址，所以在压栈时，栈顶指针esp减小；出栈时，栈顶指针esp增加

根据a的类型计算返回值后让栈指针++。
```cs
switch (a->ObjectType)
{
    case ObjectTypes.Long:
        *((long*)&esp->Value) = *((long*)&a->Value) + *((long*)&b->Value);
        break;
    case ObjectTypes.Integer:
        esp->Value = a->Value + b->Value;
        break;
    case ObjectTypes.Float:
        *((float*)&esp->Value) = *((float*)&a->Value) + *((float*)&b->Value);
        break;
    case ObjectTypes.Double:
        *((double*)&esp->Value) = *((double*)&a->Value) + *((double*)&b->Value);
        break;
    default:
        throw new NotImplementedException();
}
esp++;

// 返回值设置
// 栈指针++
```

### 总结
ILRuntime的解释器利用已经写好的相关代码将IL代码解释翻译后进行执行。对于我们来说，需要大致了解它的内存布局，以及方法指令是如何调用的。这样我们才能够看懂或书写CLR重定向相关的逻辑。