[浅谈Unity与.Net、Mono、IL2CPP_什么是mono vm-CSDN博客](https://blog.csdn.net/LLLLL__/article/details/123942210)

1. 用ref、out、in关键字修饰函数参数时，分别有哪些作用与区别:
当参数使用ref、out、in修饰后，参数则会按引用传递，而非按[值传递](https://so.csdn.net/so/search?q=%E5%80%BC%E4%BC%A0%E9%80%92&spm=1001.2101.3001.7020)。
- ref：参数变量需要初始化，参数在方法中可以修改或不修改。
- out：参数变量无需初始化，参数在方法中必须进行赋值。
- in：参数变量需要初始化，参数在方法中不能进行修改。

2. const和readonly关键字的区别:
静态常量（Const）是指编译器在编译时候会对常量进行解析，并将常量的值替换成初始化的那个值。  
动态常量（Readonly）的值则是在运行的那一刻才获得的，编译器编译期间将其标示为只读常量，而不用常量的值代替，这样动态常量不必在声明的时候就初始化，而可以延迟到构造函数中初始化。
Const的变量是嵌入在IL代码中，编译时就加载好，不依赖外部dll（这也是为什么不能在构造方法中赋值）。Const在程序集更新时容易产生版本不一致的情况。
Readonly的变量是在运行时加载，需请求加载dll，每次都获取最新的值。Readonly赋值引用类型以后，引用本身不可以改变，但是引用所指向的实例的值是可以改变的。在构造方法中，我们可以多次对Readonly赋值。

|         | 静态常量（Compile-time Constant） | 动态常量（Runtime Constant）            |
| ------- | --------------------------- | --------------------------------- |
| 定义      | 声明的同时要设置常量值。                | 声明的时候可以不需要进行设置常量值，可以在类的构造函数中进行设置。 |
| 类型限制    | 只能修饰基元类型，枚举类型或者字符串类型。       | 没有限制，可以用它定义任何类型的常量。               |
| 对于类对象而言 | 对于所有类的对象而言，常量的值是一样的。        | 对于类的不同对象而言，常量的值可以是不一样的。           |
| 内存消耗    | 无。                          | 要分配内存，保存常量实体。                     |
| **综述**  | **性能要略高，无内存开销，但是限制颇多，不灵活。** | **灵活，方便，但是性能略低，且有内存开销。**          |
```CS
	 public static class MyClass
    {
        public const int Count = 10;
    }
    
	public static void Main(string[] args)
    {
        Console.WriteLine(DoTestConst.MyClass.Count);//输出10
        Console.ReadKey();
    }

	//值类型
    public class Student
    {
        public readonly int Age;

        public Student(int age)
        {
            this.Age = age;
        }
    }
    //Student的实例Age在构造函数中被赋值以后就不可以改变，下面的代码不会编译通过：
	Student student = new Student(20);
	student.Age = 21; //错误信息：无法对只读的字段赋值（构造函数或变量初始化器中除外）

    //引用类型
	public class Student
    {
        public int Age; //注意这里的Age是没有readonly修饰符的

        public Student(int age)
        {
            this.Age = age;
        }
    }
    public class School
    {
        public readonly Student Student;

        public School(Student student)
        {
            this.Student = student;
        }
    }
    //School实例的Student是一个引用类型的变量，赋值后，变量不能再指向其他任何的Student实例，所以，下面的代码将不会编译通过：

	School school = new School(new Student(10));
	school.Student = new Student(20);//错误信息：无法对只读的字段赋值（构造函数或变量初始化器中除外）

　　//引用本身不可以改变，但是引用说指向的实例的值是可以改变的。所以下面的代码是可以编译通过的：
	School school = new School(new Student(10));
	school.Student.Age = 20;

　　//在构造方法中，我们可以多次对Readonly修饰的常量赋值。举个例子说明一下：
　　public class Student
    {
        public readonly int Age = 20;//注意:初始化器实际上是构造方法的一部分，它其实是一个语法糖

        public Student(int age)
        {
            this.Age = age;
            this.Age = 25;
            this.Age = 30;
        }
    }
```

3. 值类型和引用类型的区别
所有的值类型都是密封（seal）的，所以无法派生出新的值类型。
引用类型和值类型都继承自System.Object类。不同的是，几乎所有的引用类型都直接从System.Object继承，而值类型则继承其子类，即直接继承System.ValueType。System.ValueType直接派生于System.Object。即System.ValueType本身是一个类类型，而不是值类型。

相同点：
引用类型可以实现接口，值类型当中的结构体也可以实现接口；
引用类型和值类型都继承自System.Object类。

4. 接口和抽象类的区别
- 抽象类中可以有构造函数；接口中不能
- 抽象类只能被单一继承；接口可以被继承多个
- 抽象类中可以有成员变量；接口中不能
- 抽象类中可以申明成员方法，虚方法，抽象方法，静态方法，接口中只能申明没有实现的抽象方法
- 抽象类方法可以使用访问修饰符;接口中建议不写，默认public
[接口和抽象类的区别](file:///F:/Unity%E5%AD%A6%E4%B9%A0/C#\3.C#%E6%A0%B8%E5%BF%83\C#%E6%A0%B8%E5%BF%83\Lesson26_%E6%8A%BD%E8%B1%A1%E7%B1%BB%E5%92%8C%E6%8E%A5%E5%8F%A3%E7%9A%84%E5%8C%BA%E5%88%AB\Program.cs)

5. 介绍装箱与拆箱
[装箱与拆箱](file:///F:/Unity%E5%AD%A6%E4%B9%A0/C#\3.C#%E6%A0%B8%E5%BF%83\C#%E6%A0%B8%E5%BF%83\Lesson15_%E4%B8%87%E7%89%A9%E4%B9%8B%E7%88%B6%E5%92%8C%E8%A3%85%E7%AE%B1%E6%8B%86%E7%AE%B1\Program.cs)

6. 介绍委托、事件等概念
[委托](file:///F:/Unity%E5%AD%A6%E4%B9%A0/C#\4.C#%E8%BF%9B%E9%98%B6\C#%E8%BF%9B%E9%98%B6\Lesson12_%E5%A7%94%E6%89%98%E4%B8%8E%E4%BA%8B%E4%BB%B6_%E5%A7%94%E6%89%98\Program.cs)
[事件](file:///F:/Unity%E5%AD%A6%E4%B9%A0/C#\4.C#%E8%BF%9B%E9%98%B6\C#%E8%BF%9B%E9%98%B6\Lesson13_%E5%A7%94%E6%89%98%E4%B8%8E%E4%BA%8B%E4%BB%B6_%E4%BA%8B%E4%BB%B6\Program.cs)

8. 介绍异步、协程（async/await）等概念
[异步](file:///F:/Unity%E5%AD%A6%E4%B9%A0/C#\5.C#%E9%AB%98%E7%BA%A7\C#%E9%AB%98%E7%BA%A7\Task\Program.cs)

10. 介绍[GC](https://zhida.zhihu.com/search?content_id=251176997&content_type=Article&match_order=1&q=GC&zhida_source=entity)（垃圾回收）的原理与作用

11. 分别有哪几种GC算法，简要介绍一下
12. GC的分代机制
13. GC如何处理内存碎片（保守式GC与精确式GC）
14. 如何避免频繁GC，怎么做性能优化




