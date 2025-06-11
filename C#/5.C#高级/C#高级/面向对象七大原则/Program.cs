namespace 面向对象七大原则
{
    //一般地，可以把这七个原则分成了以下两个部分：
    //  设计目标：开闭原则、里氏代换原则、迪米特原则
    //  设计方法：单一职责原则、接口分隔原则、依赖倒置原则、组合/聚合复用原则

    #region 单一职责原则（Single Responsibility Principle, SRP）
    //违背单一职责原则的例子
    //假设我们有一个 Employee 类，它负责员工信息的存储，并且负责将员工信息打印到控制台：
    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public string Department { get; set; }

    //    // 负责存储员工信息
    //    public Employee(string name, int age, string department)
    //    {
    //        Name = name;
    //        Age = age;
    //        Department = department;
    //    }

    //    // 负责打印员工信息
    //    public void PrintInfo()
    //    {
    //        Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}");
    //    }
    //}
    //在这个例子中，Employee 类有两个职责：存储员工信息和打印员工信息。如果未来需要修改打印格式，可能会影响到存储逻辑，这违反了单一职责原则。

    //遵循单一职责原则的例子
    //我们可以将 Employee 类和打印逻辑分开：
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }

        public Employee(string name, int age, string department)
        {
            Name = name;
            Age = age;
            Department = department;
        }
    }
    // 负责打印员工信息
    public class EmployeePrinter
    {
        private Employee employee;

        public EmployeePrinter(Employee employee)
        {
            this.employee = employee;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");
        }
    }

    #endregion 单一职责原则（Single Responsibility Principle, SRP）

    #region 开闭原则（Open / Closed Principle, OCP）
    //  软件实体（模块，类，方法等）应该对扩展开放，对修改关闭。

    // 违背开闭原则的例子
    //假设我们有一个简单的形状类层次结构，其中包括一个抽象的 Shape 类和几个具体的子类，
    //如 Circle 和 Rectangle。还有一个 ShapeDrawer 类，它负责绘制形状：
    //public abstract class Shape
    //{
    //    public abstract void Draw();
    //}

    //public class Circle : Shape
    //{
    //    public override void Draw()
    //    {
    //        Console.WriteLine("Drawing a circle.");
    //    }
    //}

    //public class Rectangle : Shape
    //{
    //    public override void Draw()
    //    {
    //        Console.WriteLine("Drawing a rectangle.");
    //    }
    //}

    //public class ShapeDrawer
    //{
    //    public void DrawShape(Shape shape)
    //    {
    //        shape.Draw();
    //    }
    //}
    //在这个例子中，如果我们要添加一个新的形状，比如 Triangle，我们需要修改 ShapeDrawer 类来处理这个新形状，这违反了开闭原则。

    //遵循开闭原则的例子
    //为了遵循开闭原则，我们可以使用一个工厂模式来创建形状，并且让 ShapeDrawer 类不依赖于具体的 Shape 类型：
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle.");
        }
    }

    public class ShapeFactory
    {
        public Shape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case "Circle":
                    return new Circle();

                case "Rectangle":
                    return new Rectangle();

                case "Triangle":
                    return new Triangle();

                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }

    public class ShapeDrawer
    {
        private ShapeFactory _factory = new ShapeFactory();

        public void DrawShape(string shapeType)
        {
            Shape shape = _factory.CreateShape(shapeType);
            shape.Draw();
        }
    }
    #endregion 开闭原则（Open / Closed Principle, OCP）

    #region 里氏替换原则（Liskov Substitution Principle, LSP）
    //所有引用基类的地方必须能透明地使用其派生类的对象。
    //引申意义：子类可以扩展父类的功能，但不能改变父类原有的功能。

    //具体来说：
    //  子类可以实现父类的抽象方法，但不能覆盖父类的非抽象方法。
    //  子类中可以增加自己特有的方法。
    //  当子类的方法重载父类的方法时，方法的前置条件（即方法的输入/入参）要比父类方法的输入参数更宽松。
    //  当子类的方法实现父类的方法时（重载/重写或实现抽象方法）的后置条件（即方法的输出/返回值）要比父类更严格或相等。

    //违背里氏替换原则的例子
    //假设我们有一个基类 Animal 和一个子类 Bird，其中 Animal 类有一个 Eat 方法，而 Bird 类重写了这个方法：
    //public class Animal
    //{
    //    public virtual void Eat()
    //    {
    //        Console.WriteLine("The animal eats food.");
    //    }
    //}

    //public class Bird : Animal
    //{
    //    public override void Eat()
    //    {
    //        Console.WriteLine("The bird pecks at food.");
    //    }

    //    public void Fly()
    //    {
    //        Console.WriteLine("The bird flies.");
    //    }
    //}
    //在这个例子中，Bird 类正确地重写了 Eat 方法，并且添加了 Fly 方法。
    //如果我们有一个函数 FeedAnimal，它接受 Animal 类型的参数：
    //public void FeedAnimal(Animal animal)
    //{
    //    animal.Eat();
    //}
    //我们可以将 Bird 对象传递给 FeedAnimal 方法，而不会导致任何错误或不一致的行为
    //，因为 Bird 是 Animal 的子类，并且正确地实现了 Eat 方法。这符合里氏替换原则。
    //然而，如果我们添加一个新的方法 Swim 到 Animal 类中，并在 Bird 类中重写它：
    //public class Animal
    //{
    //    public virtual void Eat()
    //    {
    //        Console.WriteLine("The animal eats food.");
    //    }

    //    public virtual void Swim()
    //    {
    //        Console.WriteLine("The animal swims.");
    //    }
    //}
    //public class Bird : Animal
    //{
    //    public override void Eat()
    //    {
    //        Console.WriteLine("The bird pecks at food.");
    //    }

    //    public override void Swim()
    //    {
    //        throw new NotImplementedException("Not all birds can swim.");
    //    }

    //    public void Fly()
    //    {
    //        Console.WriteLine("The bird flies.");
    //    }
    //}
    //现在，Swim 方法在 Bird 类中被重写为抛出异常，这违反了里氏替换原则，因为不是所有的 Bird 都能游泳。
    //这意味着我们不能在不知道具体类型的情况下将 Bird 对象替换为 Animal 对象，因为这种行为不一致可能会导致程序出错。

    //遵循里氏替换原则的例子
    //为了遵循里氏替换原则，我们可以引入一个新接口或抽象类来表示能够游泳的动物：
    public interface ISwimable
    {
        void Swim();
    }

    public class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("The animal eats food.");
        }
    }

    public class Bird : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The bird pecks at food.");
        }

        public void Fly()
        {
            Console.WriteLine("The bird flies.");
        }
    }

    public class Duck : Animal, ISwimable
    {
        public override void Eat()
        {
            Console.WriteLine("The duck eats food.");
        }

        public void Swim()
        {
            Console.WriteLine("The duck swims.");
        }
    }
    //在这个改进的例子中，我们引入了 ISwimable 接口来表示能够游泳的动物。
    //Bird 类不再实现 Swim 方法，而 Duck 类（作为 Animal 的子类和 ISwimable 接口的实现）提供了 Swim 方法的具体实现。
    //这样，我们可以确保只有能够游泳的动物才会提供 Swim 方法的实现，从而遵循里氏替换原则。

    //通过这种方式，我们可以确保子类可以无缝替换其基类，而不改变程序的行为，从而提高代码的可维护性和可扩展性。
    #endregion 里氏替换原则（Liskov Substitution Principle, LSP）

    #region 依赖倒转原则（Dependency Inversion Principle, DIP）
    //  A. 高层模块不应该依赖于低层模块，二者都应该依赖于抽象
    //  B. 抽象不应该依赖于细节，细节应该依赖于抽象
    //  C. 针对接口编程，不要针对实现编程。

    //违背依赖倒转原则的例子
    //假设我们有一个 Document 类，它依赖于一个具体的 PDF 实现来保存文档：
    //public class Document
    //{
    //    private PDF pdf;

    //    public Document()
    //    {
    //        pdf = new PDF();
    //    }

    //    public void Save()
    //    {
    //        pdf.SaveToFile("document.pdf");
    //    }
    //}

    //public class PDF
    //{
    //    public void SaveToFile(string filename)
    //    {
    //        Console.WriteLine($"Saving PDF to {filename}");
    //    }
    //}
    //在这个例子中，Document 类直接依赖于 PDF 类的具体实现。
    //如果未来我们想要支持其他格式，比如Word文档，我们需要修改 Document 类，这违反了依赖倒转原则。

    //遵循依赖倒转原则的例子
    //为了遵循依赖倒转原则，我们可以定义一个 ISaveable 接口，让 PDF 和其他格式的实现类都实现这个接口，
    //然后让 Document 类依赖于这个接口：
    public interface ISaveable
    {
        void SaveToFile(string filename);
    }

    public class PDF : ISaveable
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving PDF to {filename}");
        }
    }

    public class WordDocument : ISaveable
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving Word Document to {filename}");
        }
    }

    public class Document
    {
        private ISaveable saver;

        public Document(ISaveable saver)
        {
            this.saver = saver;
        }

        public void Save()
        {
            saver.SaveToFile("document.pdf");
        }
    }
    //在这个改进的例子中，Document 类现在依赖于 ISaveable 接口，而不是具体的 PDF 类。
    //这样，如果我们想要支持新的文档格式，比如Word文档，我们只需要创建一个新的类 WordDocument 来实现 ISaveable 接口，而不需要修改 Document 类。
    //这降低了类之间的耦合度，提高了系统的灵活性和可扩展性。

    //通过依赖注入（DI），我们可以进一步解耦 Document 类和具体的实现类，使得 Document 类更加灵活和可配置：

    //在这个示例中，我们通过依赖注入的方式，将具体的保存实现传递给 Document 类，
    //使得 Document 类可以在运行时动态地选择使用哪种保存实现，而不需要修改其代码。
    //这样，Document 类真正做到了对扩展开放，对修改关闭，符合依赖倒转原则。
    #endregion 依赖倒转原则（Dependency Inversion Principle, DIP）

    #region 接口隔离原则（Interface Segregation Principle, ISP）
    //不能强迫用户去依赖那些他们不使用的接口。

    //违背接口隔离原则的例子
    //假设我们有一个 IVehicle 接口，它包含了所有车辆共有的方法，包括一些特定类型的车辆特有的方法：
    //public interface IVehicle
    //{
    //    void StartEngine();
    //    void StopEngine();
    //    void Refuel();
    //    void Repair();
    //    void Navigate();
    //}
    //现在，我们有一个 Car 类和一个 Boat 类，它们都实现了 IVehicle 接口：
    //public class Car : IVehicle
    //{
    //    public void StartEngine() { /* ... */ }
    //    public void StopEngine() { /* ... */ }
    //    public void Refuel() { /* ... */ }
    //    public void Repair() { /* ... */ }
    //    public void Navigate() { /* ... */ }
    //}

    //public class Boat : IVehicle
    //{
    //    public void StartEngine() { /* ... */ }
    //    public void StopEngine() { /* ... */ }
    //    public void Refuel() { /* ... */ }
    //    public void Repair() { /* ... */ }
    //    public void Navigate()
    //    {
    //        throw new NotImplementedException("Boats do not have a navigation system like cars.");
    //    }
    //}
    //在这个例子中，Boat 类不需要 Navigate 方法，因为它不像汽车那样使用导航系统。
    //因此，Boat 类不得不实现一个它不需要的方法，这违反了接口隔离原则。

    //遵循接口隔离原则的例子
    //为了遵循接口隔离原则，我们可以将 IVehicle 接口拆分成几个更小的接口，每个接口只包含相关的方法：
    public interface I陆路交通工具
    {
        void StartEngine();
        void StopEngine();
        void Refuel();
        void Repair();
    }

    public interface I水上交通工具
    {
        void StartEngine();
        void StopEngine();
        void Refuel();
        void Repair();
    }

    public interface I导航系统
    {
        void Navigate();
    }
    //现在，我们可以为 Car 和 Boat 类定义更精确的接口：
    public class Car : I陆路交通工具, I导航系统
    {
        public void StartEngine() { /* ... */ }
        public void StopEngine() { /* ... */ }
        public void Refuel() { /* ... */ }
        public void Repair() { /* ... */ }
        public void Navigate() { /* ... */ }
    }

    public class Boat : I水上交通工具
    {
        public void StartEngine() { /* ... */ }
        public void StopEngine() { /* ... */ }
        public void Refuel() { /* ... */ }
        public void Repair() { /* ... */ }
    }
    //在这个改进的例子中，Car 类实现了 I陆路交通工具 和 I导航系统 接口，而 Boat 类只实现了 I水上交通工具 接口。这样，每个类只依赖于它们实际需要的方法，遵循了接口隔离原则。

    //通过这种方式，我们可以减少类之间的不必要依赖，提高代码的可维护性和可扩展性。接口隔离原则鼓励设计更小、更具体的接口，以满足特定客户的需求，而不是强迫客户依赖于它们不需要的方法。
    #endregion 接口隔离原则（Interface Segregation Principle, ISP）

    #region 合成/聚合复用原则（Composite/Aggregate Reuse Principle, CRP）
    //尽量使用组合/聚合，不要使用类继承。

    //违背合成复用原则的例子（使用继承）
    //假设我们有一个 Vehicle 类，我们想要创建一个 Car 类来扩展 Vehicle 的功能：
    //public class Vehicle
    //{
    //    public void StartEngine()
    //    {
    //        Console.WriteLine("Engine started.");
    //    }
    //}

    //public class Car : Vehicle
    //{
    //    public void HonkHorn()
    //    {
    //        Console.WriteLine("Car honking horn.");
    //    }
    //}
    //在这个例子中，Car 类通过继承 Vehicle 类来复用 StartEngine 方法，并添加了 HonkHorn 方法。
    //这种方式简单直接，但如果 Vehicle 类在未来发生变化，比如添加了一些不适合所有 Vehicle 的方法，
    //那么 Car 类也会受到影响，这增加了类之间的耦合度。

    //遵循合成复用原则的例子（使用组合/聚合）
    //为了遵循合成复用原则，我们可以将 Vehicle 作为 Car 类的一个成员，而不是通过继承：
    //public class Vehicle
    //{
    //    public void StartEngine()
    //    {
    //        Console.WriteLine("Engine started.");
    //    }
    //}

    //public class Car
    //{
    //    private Vehicle vehicle;

    //    public Car()
    //    {
    //        vehicle = new Vehicle();
    //    }

    //    public void HonkHorn()
    //    {
    //        Console.WriteLine("Car honking horn.");
    //    }

    //    public void StartEngine()
    //    {
    //        vehicle.StartEngine();
    //    }
    //}
    //在这个例子中，Car 类包含了一个 Vehicle 类的实例，这样 Car 类就可以复用 Vehicle 类的 StartEngine 方法，而不需要继承它。这种方式使得 Car 类和 Vehicle 类之间的耦合度降低，Car 类不再依赖于 Vehicle 类的整个继承结构，而是仅依赖于 Vehicle 类提供的功能。

    //进一步的例子：使用聚合
    //聚合是一种特殊的组合关系，其中整体对象仅作为一个容器，不包含对部分对象的具体实现细节：
    public class Vehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Engine started.");
        }
    }

    public class Car1
    {
        private Vehicle vehicle;

        public Car1(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public void HonkHorn()
        {
            Console.WriteLine("Car honking horn.");
        }

        public void StartEngine()
        {
            vehicle.StartEngine();
        }
    }
    //在这个例子中，Car 类通过构造函数接收一个 Vehicle 对象，这允许客户端决定使用哪个具体的 Vehicle 实例。
    //这种设计使得 Car 类更加灵活，可以与任何 Vehicle 类型的实例一起工作，而不是仅限于 Vehicle 类的特定实现。

    //通过这种方式，合成复用原则鼓励设计者使用组合/聚合来实现代码复用，从而提高系统的灵活性和可维护性，降低类之间的耦合度。
    #endregion 合成复用原则（Composite Reuse Principle, CRP）

    #region 迪米特法则（Law of Demeter, LoD）
    //迪米特原则（Law of Demeter）又叫最少知道原则（Least Knowledge Principle），
    //可以简单说成：talk only to your immediate friends，只与你直接的朋友们通信，不要跟“陌生人”说话。
    //迪米特原则要求类“羞涩”一点，尽量不要对外公布太多的public方法和非静态的public变量，尽量内敛，多使用private、protected等访问权限。

    //违背迪米特法则的例子
    //假设我们有一个 Student 类，一个 University 类，以及一个 Address 类。
    //Student 类中有一个方法用来获取学生所在大学的名字，而大学的名字是通过 University 类中的 GetName 方法获取的。
    //现在，如果 University 类中有一个 Address 成员，并且 Address 类有一个 GetCity 方法，那么 Student 类不应该直接调用 GetCity 方法：
    //public class Address
    //{
    //    public string City { get; set; }

    //    public string GetCity()
    //    {
    //        return City;
    //    }
    //}

    //public class University
    //{
    //    public string Name { get; set; }
    //    public Address address { get; set; }

    //    public string GetName()
    //    {
    //        return Name;
    //    }

    //    // 违背迪米特法则的方法
    //    public string GetUniversityCity()
    //    {
    //        return address.GetCity(); // Student 应该不知道 University 包含 Address
    //    }
    //}

    //public class Student
    //{
    //    public University University { get; set; }

    //    // 违背迪米特法则的方法
    //    public string GetUniversityCity()
    //    {
    //        return University.GetUniversityCity(); // Student 直接与 University 的 Address 通信
    //    }
    //}
    //在这个例子中，Student 类直接与 University 类的 Address 成员通信，这违反了迪米特法则。

    //遵循迪米特法则的例子
    //为了遵循迪米特法则，我们可以修改 University 类，使其不暴露 Address 的细节给 Student 类：
    public class Address
    {
        public string City { get; set; }
    }

    public class University
    {
        public string Name { get; set; }
        private Address address;

        public University(Address address)
        {
            this.address = address;
        }

        public string GetName()
        {
            return Name;
        }

        // 直接提供城市信息，不暴露Address对象
        public string GetCity()
        {
            return address.City;
        }
    }

    public class Student
    {
        private University university;

        public Student(University university)
        {
            this.university = university;
        }

        // 通过University获取城市信息，不直接与Address通信
        public string GetUniversityCity()
        {
            return university.GetCity();
        }
    }
    //在这个改进的例子中，Student 类只与 University 类通信，而不关心 University 的内部结构，比如 Address。这样，Student 类只与它的直接朋友 University 通信，符合迪米特法则。

    //遵循迪米特法则可以降低类之间的耦合度，提高模块化，使得系统更容易理解和维护。每个类只需要关注自己的职责，而不需要了解其他类的内部实现细节。
    #endregion 迪米特法则（Law of Demeter, LoD）

    internal class Program
    {
        private static void Main(string[] args)
        {
            //面向对象七大原则
            //
            //单一职责原则（Single Responsibility Principle, SRP）：
            //一个类应该只有一个引起它变化的原因，即一个类应该只负责一个功能。
            //
            //开闭原则（Open / Closed Principle, OCP）：
            //类应该对扩展开放，对修改关闭。这意味着当需要增加新功能时，应该通过继承或组合的方式来扩展现有的代码，而不是直接修改现有的代码。
            //
            //里氏替换原则（Liskov Substitution Principle, LSP）：
            //子类对象应该能够替换其基类对象，而不影响程序的正确性。即子类应该可以无缝替换其父类。
            //
            //依赖倒转原则（Dependency Inversion Principle, DIP）：
            //高层模块不应该依赖于低层模块，两者都应该依赖于抽象；抽象不应该依赖于细节（具体实现），细节应该依赖于抽象。
            ISaveable pdfSaver = new PDF();
            Document document = new Document(pdfSaver);
            document.Save();

            ISaveable wordSaver = new WordDocument();
            Document wordDocument = new Document(wordSaver);
            wordDocument.Save();
            //
            //接口隔离原则（Interface Segregation Principle, ISP）：
            //不应该强迫客户依赖于它们不使用的方法。即客户端不应该依赖于它们不使用接口，一个类对另一个类的依赖应该建立在最小的接口上。
            //
            //合成复用原则（Composite Reuse Principle, CRP）：
            //尽量使用对象的组合 / 聚合来达到代码复用，而不是通过继承。
            //
            //迪米特法则（Law of Demeter, LoD）：
            //也被称为最少知识原则（Principle of Least Knowledge），指出一个对象应该对其他对象有最少的了解。
            //换句话说，一个对象应该只与它的直接朋友（直接朋友指的是成员对象、参数对象、本地对象以及调用栈上的其他对象）通信，而不与“朋友的朋友”通信。
        }
    }
}