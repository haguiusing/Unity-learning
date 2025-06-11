在Unity中实现建造者模式（Builder Pattern），可以帮助我们将复杂对象的构建过程抽象化，使得对象的创建更加灵活和易于管理。以下是建造者模式在Unity中的一个实现示例：

模式结构：
- Builder：抽象建造者
- ConcreteBuilder：具体建造者
- Director：指挥者
- Product：产品角色

建造者模式包含以下几个主要角色：
- **产品（Product）**：要构建的复杂对象。产品类通常包含多个部分或属性。
- **抽象建造者（Builder）**：定义了构建产品的抽象接口，包括构建产品的各个部分的方法。
- **具体建造者（Concrete Builder）**：实现抽象建造者接口，具体确定如何构建产品的各个部分，并负责返回最终构建的产品。
- **指导者（Director）**：负责调用建造者的方法来构建产品，指导者并不了解具体的构建过程，只关心产品的构建顺序和方式。
### 1. 定义产品接口和具体产品类

首先，我们定义一个产品接口，它代表了我们需要构建的复杂对象。然后，我们实现这个接口，创建具体的产品类。
```csharp
// 产品接口
public interface ICharacter
{
    void Display();
}

// 具体产品类
public class Warrior : ICharacter
{
    public string Body { get; private set; }
    public string Head { get; private set; }
    public string Weapon { get; private set; }

    public Warrior(WarriorBuilder builder)
    {
        Body = builder.Body;
        Head = builder.Head;
        Weapon = builder.Weapon;
    }

    public void Display()
    {
        Debug.Log($"Warrior with body: {Body}, head: {Head}, and weapon: {Weapon}");
    }
}
```

### 2. 定义建造者接口和具体建造者类

接下来，我们定义一个建造者接口，它包含了构建产品所需的所有步骤。然后，我们实现这个接口，创建具体的建造者类。
```csharp
// 建造者接口
public interface IBuilder
{
    void BuildBody();
    void BuildHead();
    void BuildWeapon();
    ICharacter GetResult();
}

// 具体建造者类
public class WarriorBuilder : IBuilder
{
    public string Body { get; private set; }
    public string Head { get; private set; }
    public string Weapon { get; private set; }

    public void BuildBody()
    {
        Body = "Body of Warrior";
    }

    public void BuildHead()
    {
        Head = "Head of Warrior";
    }

    public void BuildWeapon()
    {
        Weapon = "Sword";
    }

    public ICharacter GetResult()
    {
        return new Warrior(this);
    }
}
```

### 3. 定义导演类

导演类负责指导建造者完成产品的构建过程。它不关心产品的具体构建细节，只负责调用建造者的方法。
```csharp
// 导演类
public class Director
{
    private IBuilder builder;

    public Director(IBuilder builder)
    {
        this.builder = builder;
    }

    public ICharacter Construct()
    {
        builder.BuildBody();
        builder.BuildHead();
        builder.BuildWeapon();
        return builder.GetResult();
    }
}
```

### 4. 客户端代码

最后，客户端代码使用导演类和建造者类来创建产品。
```csharp
public class Client
{
    public void Start()
    {
        IBuilder builder = new WarriorBuilder();
        Director director = new Director(builder);
        ICharacter character = director.Construct();
        character.Display();
    }
}
```
`WarriorBuilder` 是 `IBuilder` 的一个子类型，它被用作 `Director` 类的参数。这遵循了里氏替换原则，因为 `Director` 类期望一个 `IBuilder` 类型的对象，而 `WarriorBuilder` 就是 `IBuilder` 的一个实现。这种设计使得 `Director` 类可以与任何实现了 `IBuilder` 接口的建造者一起工作，而不需要知道具体的建造者是谁，这增加了代码的灵活性和可扩展性。

在这个示例中，我们通过建造者模式创建了一个战士角色。建造者模式允许我们以更灵活和可扩展的方式创建不同变体的对象，同时隐藏了对象的内部构建细节。这种模式<font color="#ffc000">尤其适用于需要构造具有多个可选或必须组件的对象，并且希望客户端代码无需了解内部构造细节的情况下</font>。
![[Pasted image 20250424161302.jpg]]
![[Pasted image 20250424161306.jpg]]

## 5.建造者模式的简化
- 省略抽象建造者角色：如果系统中只需要一个具体建造者的话，可以省略掉抽象建造者。
- 省略指挥者角色：在具体建造者只有一个的情况下，如果抽象建造者角色已经被省略掉，那么还可以省略指挥者角色，让Builder角色扮演指挥者与建造者双重角色，这样子就不用再多一步申明导演的代码。
```csharp
// 产品接口
public interface ICharacter
{
    void Display();
}

// 具体产品类
public class Warrior : ICharacter
{
    public string Body { get; private set; }
    public string Head { get; private set; }
    public string Weapon { get; private set; }

    public Warrior(WarriorBuilder builder)
    {
        Body = builder.Body;
        Head = builder.Head;
        Weapon = builder.Weapon;
    }

    public void Display()
    {
        Debug.Log($"Warrior with body: {Body}, head: {Head}, and weapon: {Weapon}");
    }
}
```

```csharp
// 唯一建造者类
public class WarriorBuilder
{
    public string Body { get; private set; }
    public string Head { get; private set; }
    public string Weapon { get; private set; }

    public void BuildBody()
    {
        Body = "Body of Warrior";
    }

    public void BuildHead()
    {
        Head = "Head of Warrior";
    }

    public void BuildWeapon()
    {
        Weapon = "Sword";
    }

    public ICharacter GetResult()
    {
        return new Warrior(this);
    }

    // 指挥者方法
    public ICharacter Construct()
    {
        BuildBody();
        BuildHead();
        BuildWeapon();
        return GetResult();
    }
}
```

```csharp
public class Client
{
    public void Start()
    {
        WarriorBuilder builder = new WarriorBuilder();
        ICharacter character = builder.Construct();
        character.Display();
    }
}
```

## 与其他模式的关系
- 在许多设计工作的初期都会使用[工厂方法模式](https://refactoringguru.cn/design-patterns/factory-method) （较为简单， 而且可以更方便地通过子类进行定制）， 随后演化为使用[抽象工厂模式](https://refactoringguru.cn/design-patterns/abstract-factory)、 [原型模式](https://refactoringguru.cn/design-patterns/prototype)或[生成器模式](https://refactoringguru.cn/design-patterns/builder) （更灵活但更加复杂）。
    
- [生成器](https://refactoringguru.cn/design-patterns/builder)重点关注如何分步生成复杂对象。 [抽象工厂](https://refactoringguru.cn/design-patterns/abstract-factory)专门用于生产一系列相关对象。 _抽象工厂_会马上返回产品， _生成器_则允许你在获取产品前执行一些额外构造步骤。
    
- 你可以在创建复杂[组合模式](https://refactoringguru.cn/design-patterns/composite)树时使用[生成器](https://refactoringguru.cn/design-patterns/builder)， 因为这可使其构造步骤以递归的方式运行。
    
- 你可以结合使用[生成器](https://refactoringguru.cn/design-patterns/builder)和[桥接模式](https://refactoringguru.cn/design-patterns/bridge)： _主管_类负责抽象工作， 各种不同的_生成器_负责_实现_工作。
    
- [抽象工厂](https://refactoringguru.cn/design-patterns/abstract-factory)、 [生成器](https://refactoringguru.cn/design-patterns/builder)和[原型](https://refactoringguru.cn/design-patterns/prototype)都可以用[单例模式](https://refactoringguru.cn/design-patterns/singleton)来实现。