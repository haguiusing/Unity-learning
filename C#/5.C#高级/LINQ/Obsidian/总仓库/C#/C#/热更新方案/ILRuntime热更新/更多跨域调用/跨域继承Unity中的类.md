主入口：![[ILRuntimeMain.cs]]
![[Lesson11.cs]]

父类（Unity中）：![[TestLesson11.cs]]
子类（ILRuntime）：
![[TestLesson11 1.cs]]

#### TypeLoadException: Cannot find Adaptor for:Lesson12_Father报错
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB/1.png)
生成跨域适配器实际运行的是ILRuntimeCrossBinding脚本。路径是Assets\\Samples\\ILRuntime\\2.1.0\\Demo\\Editor\\ILRuntimeCrossBinding.cs。我们要准备修改这个脚本后再执行。

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB/2.png)

按照其中的模板，复制一份，填写自己要为哪个类生成跨域继承适配器对象。主要填写适配器类生成的路径，和绑定适配器的父类，命名空间可以根据自己的需求进行设置。

![1.png](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB/1.png)

#### TypeLoadException: Cannot find Adaptor for:Lesson12_Father
点击生成适配器，会发现生成了父类适配器类脚本。但是现在运行还是会报错。报错信息：TypeLoadException: Cannot find Adaptor for:Lesson12_Father。因为还要注册跨域继承适配器对象。

在ILRuntimeManager的InitILRuntime中注册Lesson12_FatherAdapter，现在可以正常跨域继承了

```cs
//注册跨域继承的父类适配器
appDomain.RegisterCrossBindingAdaptor((new Lesson12_FatherAdapter()));
```

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB/3.png)

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/01.ILRuntime%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/12.%E6%9B%B4%E5%A4%9A%E8%B7%A8%E5%9F%9F%E8%B0%83%E7%94%A8-%E8%B7%A8%E5%9F%9F%E7%BB%A7%E6%89%BFUnity%E4%B8%AD%E7%9A%84%E7%B1%BB/4.png)

### 总结
由于适配器在一些更为复杂的基类时，可能需要我们按照模板来手写一些内容，相对来说较为麻烦。如果没有特殊需求的情况下，或者是新开项目，都尽量不要出现跨域继承。