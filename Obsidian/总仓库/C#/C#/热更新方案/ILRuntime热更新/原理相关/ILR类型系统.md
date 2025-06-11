![[Lesson23.cs]]

### 回顾 类型系统的作用
用于表示热更工程中的各种类型、方法、成员、实例对象等等信息。相当于，ILRuntime帮助我们利用它内部的解释器将我们实现的代码解释翻译为了自己的一套类型规则。在真正执行代码时，都是基于ILRuntime自己的类型系统中的规则来执行的。

说人话：类型系统是热更工程中的类、方法、成员等信息的载体。

就比如我们在热更写了一个Test类，里面有成员A和TestFun函数。会把代码打入dll中，dll又会翻译成IL代码。ILRuntime通过IL代码和自定义的IType接口生成Test类的载体类。载体类继承IType接口和Test类有相同成员。我们在Unity实际使用的是载体类。

### 类型系统中关键接口

#### 可以去Package Ilruntime包中看相关类
![[Pasted image 20250603205116.png]]

#### IType 所有ILRuntime内类型的基类
- CLRType：代表主工程中的类型
- ILType：热更工程中的类型
    - StaticInstance（类型静态实例，用于保存该类型静态字段）
- ReflectedType：对应的反射类型
    - ILRuntimeType：热更工程中的类型对应的反射类型
    - ILRuntimeWraperType：主工程中的类型对应的反射类型
- TypeForCLR：IType在主工程中对应的真实类型
    - 没有跨域继承——拿到的类型会是 ILTypeInstance
    - 有跨域继承——拿到的类型会是 适配器类型

#### IMethod 所有方法的基类
- CLRMethod：主工程中定义的方法
- ILMethod：热更工程中定义的方法
    - Method Body（方法体）
    - Instruction（指令相关）

#### ILTypeInstance 热更内类型的实例均为该类型
- ILTypeStaticInstance：静态字段
- ILEnumTypeInstance：枚举字段
- DelegateAdapter：委托适配器
- Fields：所有字段
- ManagedObjects：引用类型对象实例

#### 委托
- DelegateAdapter：委托适配器
- DummyDelegateAdapter：热更中的委托，没有跨域调用对应该类型
- Delegate转换
    - 转换为Action/Func
    - 转换为自定义委托类型

### 学习类型系统的目的
大概了解了类型系统的作用和构成后，我们再反观之前学习的知识点，我们能够明白之前为什么要那样做。

### 总结
类型系统就是ILRuntime用于解释热更工程中所有类、方法、属性等信息后逻辑的载体。ILRuntime读取DLL后，通过解释器，将其中的IL中间代码信息翻译为符合类型系统规则信息。我们可以利用它来执行DLL当中的代码逻辑。