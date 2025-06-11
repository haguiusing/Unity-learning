## 中介者模式
中介者模式(Mediator Pattern)定义：用一个中介对象来封装一系列的对象交互，中介者使各对象不需要显式地相互引用，从而使其耦合松散，而且可以独立地改变它们之间的交互。中介者模式又称为调停者模式，它是一种对象行为型模式。

模式结构：
- Mediator: 抽象中介者
- ConcreteMediator: 具体中介者
- Colleague: 抽象同事类
- ConcreteColleague: 具体同事类

中介者模式包含以下几个主要角色：
- **中介者（Mediator）**：定义了一个接口用于与各个同事对象通信，并管理各个同事对象之间的关系。通常包括一个或多个事件处理方法，用于处理各种交互事件。
- **具体中介者（Concrete Mediator）**：实现了中介者接口，负责实现各个同事对象之间的通信逻辑。它会维护一个对各个同事对象的引用，并协调它们的交互。
- **同事对象（Colleague）**：定义了一个接口，用于与中介者进行通信。通常包括一个发送消息的方法，以及一个接收消息的方法。
- **具体同事对象（Concrete Colleague）**：实现了同事对象接口，是真正参与到交互中的对象。它会将自己的消息发送给中介者，由中介者转发给其他同事对象。
![[Pasted image 20250424212406.jpg]]

- **`IMediator` 抽象中介者接口**：定义了发送消息的接口方法。
- **`ChatRoomMediator` 具体中介者类**：实现了 `IMediator` 接口，维护了一个用户列表，并负责在用户之间传递消息。
- **`User` 抽象同事类**：定义了发送和接收消息的方法，持有一个对中介者的引用。
- **`ConcreteUser` 具体同事类**：实现了 `User` 抽象类，具体实现了发送和接收消息的方法。
- **`MediatorPatternDemo` 客户类**：创建了中介者和用户对象，并演示了用户之间的通信。
### 步骤 1：创建抽象中介者接口
```csharp
// 抽象中介者接口
public interface IMediator
{
    void SendMessage(string message, User user);
}
```

### 步骤 2：创建具体中介者类
```csharp
using System;
using System.Collections.Generic;

// 具体中介者类
public class ChatRoomMediator : IMediator
{
    private readonly List<User> _users = new List<User>();

    public void RegisterUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
            {
                u.ReceiveMessage(message);
            }
        }
    }
}
```

### 步骤 3：创建抽象同事类
```csharp
// 抽象同事类
public abstract class User
{
    protected string Name;
    protected IMediator Mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        Mediator = mediator;
    }

    public abstract void SendMessage(string message);
    public abstract void ReceiveMessage(string message);
}
```

### 步骤 4：创建具体同事类
```csharp
// 具体同事类
public class ConcreteUser : User
{
    public ConcreteUser(string name, IMediator mediator) : base(name, mediator)
    {
    }

    public override void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sends message: {message}");
        Mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} receives message: {message}");
    }
}
```

### 步骤 5：创建客户类
```csharp
using System;

public class MediatorPatternDemo
{
    public static void Main(string[] args)
    {
        // 创建中介者
        ChatRoomMediator chatRoom = new ChatRoomMediator();

        // 创建用户
        User robert = new ConcreteUser("Robert", chatRoom);
        User john = new ConcreteUser("John", chatRoom);

        // 注册用户到中介者
        chatRoom.RegisterUser(robert);
        chatRoom.RegisterUser(john);

        // 用户发送消息
        robert.SendMessage("Hi! John!");
        john.SendMessage("Hello! Robert!");
    }
}
```

### 运行结果
```cs
Robert sends message: Hi! John!
John receives message: Hi! John!
John sends message: Hello! Robert!
Robert receives message: Hello! Robert!
```


![[Pasted image 20250424212422.jpg]]

## 与其他模式的关系
- [责任链模式](https://refactoringguru.cn/design-patterns/chain-of-responsibility)、 [命令模式](https://refactoringguru.cn/design-patterns/command)、 [中介者模式](https://refactoringguru.cn/design-patterns/mediator)和[观察者模式](https://refactoringguru.cn/design-patterns/observer)用于处理请求发送者和接收者之间的不同连接方式：
    - _责任链_按照顺序将请求动态传递给一系列的潜在接收者， 直至其中一名接收者对请求进行处理。
    - _命令_在发送者和请求者之间建立单向连接。
    - _中介者_清除了发送者和请求者之间的直接连接， 强制它们通过一个中介对象进行间接沟通。
    - _观察者_允许接收者动态地订阅或取消接收请求。
    
- [外观模式](https://refactoringguru.cn/design-patterns/facade)和[中介者](https://refactoringguru.cn/design-patterns/mediator)的职责类似： 它们都尝试在大量紧密耦合的类中组织起合作。
    - _外观_为子系统中的所有对象定义了一个简单接口， 但是它不提供任何新功能。 子系统本身不会意识到外观的存在。 子系统中的对象可以直接进行交流。
    - _中介者_将系统中组件的沟通行为中心化。 各组件只知道中介者对象， 无法直接相互交流。
    
- [中介者](https://refactoringguru.cn/design-patterns/mediator)和[观察者](https://refactoringguru.cn/design-patterns/observer)之间的区别往往很难记住。 在大部分情况下， 你可以使用其中一种模式， 而有时可以同时使用。 让我们来看看如何做到这一点。
    _中介者_的主要目标是消除一系列系统组件之间的相互依赖。 这些组件将依赖于同一个中介者对象。 _观察者_的目标是在对象之间建立动态的单向连接， 使得部分对象可作为其他对象的附属发挥作用。
    
    有一种流行的中介者模式实现方式依赖于_观察者_。 中介者对象担当发布者的角色， 其他组件则作为订阅者， 可以订阅中介者的事件或取消订阅。 当_中介者_以这种方式实现时， 它可能看上去与_观察者_非常相似。
    
    当你感到疑惑时， 记住可以采用其他方式来实现中介者。 例如， 你可永久性地将所有组件链接到同一个中介者对象。 这种实现方式和_观察者_并不相同， 但这仍是一种中介者模式。
    
    假设有一个程序， 其所有的组件都变成了发布者， 它们之间可以相互建立动态连接。 这样程序中就没有中心化的中介者对象， 而只有一些分布式的观察者。