主入口：![[ILRuntimeMain.cs]]
![[Lesson12.cs]]

![[Pasted image 20250603152109.png]]
跨域继承时，尽量简单，不要存在多继承情况（比如类+多接口）

跨域继承基本原理：  
ILRuntime中的跨域继承实际上并不是直接继承Unity中的基类  
而是继承的适配器类  
基类（Unity中）  ——》适配器类（Unity工程中的实际类型）  ——》
子类（ILRuntime中）

注意事项：
1. 跨域继承时，不支持多继承，即同时继承类和接口
2. 如果项目框架设计中一定要出现多继承，那么在跨域继承时可以在主工程中声明一个多继承的基类用于跨域继承
3. 跨域继承中，不能在基类的构造函数中调用该类的虚函数

在Unity写一个基类和接口，在热更工程写一个类继承基类和接口，并在ILRuntimeMain实例化调用方法。
```
public interface Lesson13_Interface
{
    public void TestInterface();
}
```

```
public abstract class Lesson13_Father
{
    public abstract void TestAbstract(int i);
}
```

```
namespace HotFix_Project
{
    class Lesson13_Son : Lesson13_Father, Lesson13_Interface
    {
        public override void TestAbstract(int i)
        {
            Debug.Log("TestAbstract:" + i);
        }

        public void TestInterface()
        {
            Debug.Log("TestInterface");
        }
    }
}
```

```
Lesson13_Son lesson13_Son = new Lesson13_Son();
lesson13_Son.TestAbstract(666);
lesson13_Son.TestInterface();
```

在GenerateCrossbindAdapter绑定并生成适配器
```
using(System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/ILRuntime教程/Lesson13_更多跨域调用_跨域继承Unity中的类的注意事项/Lesson13_FatherAdapter.cs"))
{
    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(Lesson13_Father), "Lesson13_FatherNameSpace"));
}
        
using(System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/ILRuntime教程/Lesson13_更多跨域调用_跨域继承Unity中的类的注意事项/Lesson13_InterfaceAdapter.cs"))
{
    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(Lesson13_Interface), "Lesson13_InterfaceNameSpace"));
}
```

在ILRuntimeManager注册适配器类
```
appDomain.RegisterCrossBindingAdaptor((new Lesson13_FatherAdapter()));
appDomain.RegisterCrossBindingAdaptor((new Lesson13_InterfaceAdapter()));
```

运行会有报错，提示不能多继承。NotSupportedException: Inheriting and implementing interface at the same time is not supported yet。

因为本质上ILruntime的类继承的是适配器类，接口生成的适配器类也是类， public class Lesson13_InterfaceAdapter : CrossBindingAdaptor。但是C#不支持多继承类，所以报错了。所以ILruntime是不支持直接在ILruntime工程多继承的

如果一定要多继承可以在Unity实现一个多继承基类，再在ILruntime工程单继承。实现间接多继承。再绑定生成适配器并注册。重新生成后，可以正常使用间接多继承对象了。
```
public abstract class Lesson13_InheritAll : Lesson13_Father, Lesson13_Interface
{
    public abstract void TestInterface();
}
```

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix_Project
{
    class Lesson13_InheritAllSon : Lesson13_InheritAll
    {
        public override void TestAbstract(int i)
        {
            Debug.Log("TestAbstract:" + i);
        }


        public override void TestInterface()
        {
            Debug.Log("TestInterface");
        }
    }
}
```

```
Lesson13_InheritAllSon lesson13_InheritAll = new Lesson13_InheritAllSon();
lesson13_InheritAll.TestAbstract(666);
lesson13_InheritAll.TestInterface();
```

```
using(System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/ILRuntime教程/Lesson13_更多跨域调用_跨域继承Unity中的类的注意事项/Lesson13_InheritAllAdapter.cs"))
{
    sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(typeof(Lesson13_InheritAll), "Lesson13_InheritAllNameSpace"));
}
```

```
appDomain.RegisterCrossBindingAdaptor((new Lesson13_InheritAllAdapter()));
```

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/13.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB%E7%9A%84%E6%B3%A8%E6%84%8F%E4%BA%8B%E9%A1%B9/2.png)

注意，跨域继承中，不能在基类的构造函数中调用该类的虚函数,否则报错
```
public abstract class Lesson13_InheritAll : Lesson13_Father, Lesson13_Interface
{
    public Lesson13_InheritAll()
    {
        //跨域继承中，不能在基类的构造函数中调用该类的虚函数
        //NullReferenceException: Object reference not set to an instance of an object
        TestInterface();
    }
    public virtual void TestInterface();
}
```

## 总结
跨域继承时（ILRuntime工程继承Unity主工程中的类）
1. ILRuntime不支持跨域（ILRuntime继承Unity）多继承
2. 如果一定要跨域（ILRuntime继承Unity）多继承，就在主工程中用一个类将多继承关系疏离继承好，在热更工程中继承该类
3. 跨域继承中，不能在基类的构造函数中调用该类的虚函数，会报错