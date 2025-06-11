## 适配器模式(Adapter Pattern) 
将一个接口转换成客户希望的另一个接口，适配器模式使接口不兼容的那些类可以一起工作，其别名为包装器(Wrapper)。适配器模式既可以作为类结构型模式，也可以作为对象结构型模式。

模式结构：
- Target：目标类/接口
- Adapter：适配器类
- Adaptee：被适配者类/接口
- Client：客户类

适配器模式包含以下几个主要角色：
- **目标接口（Target）**：定义客户需要的接口。
- **适配者类（Adaptee）**：定义一个已经存在的接口，这个接口需要适配。
- **适配器类（Adapter）**：实现目标接口，并通过组合或继承的方式调用适配者类中的方法，从而实现目标接口。

适配器模式有对象适配器和类适配器两种实现：
对象适配器：![[Pasted image 20250424165611.jpg]]
``` cs
// 目标抽象类/接口
public interface ITarget
{
    void Request();
}

// 被适配者类
public class Adaptee
{
    public void SpecificRequest()
    {
        System.Console.WriteLine("Adaptee.SpecificRequest");
    }
}

// 适配器类
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
        System.Console.WriteLine("Adapter.Request: After SpecificRequest");
    }
}

// 客户类
public class Client
{
    public void Main()
    {
        ITarget target = new Adapter(new Adaptee());
        target.Request();
    }
}
```

类适配器：
![../_images/Adapter_classModel.jpg](https://design-patterns.readthedocs.io/zh-cn/latest/_images/Adapter_classModel.jpg)
```cs
// 目标类/接口
public interface ITarget
{
    void Request();
}

// 被适配者类
public class Adaptee
{
    public void SpecificRequest()
    {
        System.Console.WriteLine("Adaptee.SpecificRequest");
    }
}

// 适配器类
public class Adapter : Adaptee, ITarget
{
    public void Request()
    {
        base.SpecificRequest();
        System.Console.WriteLine("Adapter.Request: After SpecificRequest");
    }
}

// 客户类
public class Client
{
    public void Main()
    {
        ITarget target = new Adapter();
        target.Request();
    }
}
```

![[Pasted image 20250424171147.jpg]]

类适配器模式的缺点如下：
对于Java、C#等不支持多重继承的语言，一次最多只能适配一个适配者类，而且目标抽象类只能为抽象类，不能为具体类，其使用有一定的局限性，不能将一个适配者类和它的子类都适配到目标接口。

对象适配器模式的缺点如下：
与类适配器模式相比，要想置换适配者类的方法就不容易。如果一定要置换掉适配者类的一个或多个方法，就只好先做一个适配者类的子类，将适配者类的方法置换掉，然后再把适配者类的子类当做真正的适配者进行适配，实现过程较为复杂。

| 对象适配器              | 类适配器           |
| ------------------ | -------------- |
| 通过组合实现             | 通过继承实现         |
| 更灵活，可以适配多个被适配者     | 只能适配一个被适配者     |
| 需要创建适配器对象并传入被适配者对象 | 直接继承被适配者类      |
| 通常更符合开闭原则          | 如果被适配者是类，可能更简单 |

## 模式扩展
默认适配器模式(Default Adapter Pattern)或缺省适配器模式
当不需要全部实现接口提供的方法时，可先设计一个抽象类实现接口，并为该接口中每个方法提供一个默认实现（空方法），那么该抽象类的子类可有选择地覆盖父类的某些方法来实现需求，它适用于一个接口不想使用其所有的方法的情况。因此也称为单接口适配器模式。

1. `ITarget` 是目标接口，定义了需要实现的方法。
2. `DefaultAdapter` 是缺省适配器类，实现了 `ITarget` 接口，并为每个方法提供了默认的空实现。这允许子类只重写需要的方法，而不必实现所有方法。
3. `ConcreteAdapter` 是具体适配器类，继承自 `DefaultAdapter`，并重写了 `Method1` 方法以提供特定的实现。对于 `Method2` 和 `Method3`，它直接继承了 `DefaultAdapter` 的默认实现。
4. `Client` 是客户端类，演示了如何使用 `ConcreteAdapter` 来调用目标接口的方法。
``` cs
using System;

// 定义一个目标接口，包含多个方法
public interface ITarget
{
    void Method1();
    void Method2();
    void Method3();
}

// 缺省适配器类，实现目标接口并为每个方法提供默认实现
public abstract class DefaultAdapter : ITarget
{
    public virtual void Method1()
    {
        // 默认实现为空
        Console.WriteLine("Default implementation of Method1");
    }

    public virtual void Method2()
    {
        // 默认实现为空
        Console.WriteLine("Default implementation of Method2");
    }

    public virtual void Method3()
    {
        // 默认实现为空
        Console.WriteLine("Default implementation of Method3");
    }
}

// 具体适配器类，继承自缺省适配器并重写需要的方法
public class ConcreteAdapter : DefaultAdapter
{
    // 重写需要的方法
    public override void Method1()
    {
        Console.WriteLine("ConcreteAdapter's implementation of Method1");
    }

    // 可选择不重写其他方法，使用缺省适配器的默认实现
}

// 客户端类
public class Client
{
    public static void Main()
    {
        ITarget target = new ConcreteAdapter();
        target.Method1(); // 使用 ConcreteAdapter 的实现
        target.Method2(); // 使用 DefaultAdapter 的默认实现
        target.Method3(); // 使用 DefaultAdapter 的默认实现
    }
}
```

## 实例
- `IMediaTarget` 是目标接口，定义了播放音频的方法。
- `IAdvancedMediaTarget` 是适配目标接口，提供了更高级的播放功能。
- `VlcAdaptee` 和 `Mp4Adaptee` 是被适配者类，实现了适配目标接口。
- `MediaAdapter` 是适配器类，实现了目标接口，根据不同的音频类型选择不同的被适配者类。
- `MediaClient` 是客户类，实现了目标接口，使用适配器来播放不同类型音频文件。
- `AdapterPatternDemo` 是测试类，演示了如何使用客户类来播放不同类型的音频文件。
### 步骤 1
定义目标接口和适配目标接口。
```csharp
// 目标接口
public interface IMediaTarget
{
    void Play(string audioType, string fileName);
}

// 适配目标接口
public interface IAdvancedMediaTarget
{
    void PlayVlc(string fileName);
    void PlayMp4(string fileName);
}
```

### 步骤 2
创建实现适配目标接口的被适配者类。
```csharp
// 被适配者类1
public class VlcAdaptee : IAdvancedMediaTarget
{
    public void PlayVlc(string fileName)
    {
        System.Console.WriteLine($"Playing vlc file. Name: {fileName}");
    }

    public void PlayMp4(string fileName)
    {
        // 什么也不做
    }
}

// 被适配者类2
public class Mp4Adaptee : IAdvancedMediaTarget
{
    public void PlayVlc(string fileName)
    {
        // 什么也不做
    }

    public void PlayMp4(string fileName)
    {
        System.Console.WriteLine($"Playing mp4 file. Name: {fileName}");
    }
}
```

### 步骤 3
创建适配器类，实现目标接口并使用被适配者类。
```csharp
// 适配器类
public class MediaAdapter : IMediaTarget
{
    private readonly IAdvancedMediaTarget _advancedMediaTarget;

    public MediaAdapter(string audioType)
    {
        if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            _advancedMediaTarget = new VlcAdaptee();
        }
        else if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _advancedMediaTarget = new Mp4Adaptee();
        }
    }

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase))
        {
            _advancedMediaTarget.PlayVlc(fileName);
        }
        else if (audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _advancedMediaTarget.PlayMp4(fileName);
        }
    }
}
```

### 步骤 4
创建实现目标接口的客户类。
```csharp
// 客户类
public class MediaClient : IMediaTarget
{
    private MediaAdapter _mediaAdapter;

    public void Play(string audioType, string fileName)
    {
        if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine($"Playing mp3 file. Name: {fileName}");
        }
        else if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase) || audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        {
            _mediaAdapter = new MediaAdapter(audioType);
            _mediaAdapter.Play(audioType, fileName);
        }
        else
        {
            System.Console.WriteLine($"Invalid media. {audioType} format not supported");
        }
    }
}
```

### 步骤 5
使用客户类来播放不同类型的音频格式。
```csharp
// 测试类
public class AdapterPatternDemo
{
    public static void Main(string[] args)
    {
        MediaClient mediaClient = new MediaClient();

        mediaClient.Play("mp3", "beyond the horizon.mp3");
        mediaClient.Play("mp4", "alone.mp4");
        mediaClient.Play("vlc", "far far away.vlc");
        mediaClient.Play("avi", "mind me.avi");
    }
}
```

### 运行结果
运行上述代码后，输出结果如下：
``` cs
Playing mp3 file. Name: beyond the horizon.mp3
Playing mp4 file. Name: alone.mp4
Playing vlc file. Name: far far away.vlc
Invalid media. avi format not supported
```