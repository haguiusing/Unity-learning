using System;

namespace Lesson4_构造_析构_垃圾回收
{
    #region 知识点一：构造函数
    //基本概念
    //在实例化对象时 会调用的用于初始化的函数
    //如果不写 默认存在一个无参构造函数

    //构造函数的写法
    //1.没有返回值
    //2.函数名和类名必须相同
    //3.没有特殊需求时 一般都是public的
    //4.构造函数可以被证载
    //5.this代表当前调用该函数的对象自己

    //注意:
    // 如果不自己实现无参构适函数而实现了有参构造函数
    // 会失去默认的无参构造

    class Person
    {
        public string name; 
        public int age;

        public Person()
        {
            name = "唐老狮";
            age = 18;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public Person(int age)
        {
            this.age = age;
        }

        //public Person(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //}

        public Person(int age, string name) : this(name) //先调用public Person(string name)
        {
            Console.WriteLine("Person两个参数构造函数调用");
        }

        public Person(string name ,int age ) : this(age + 10)
        {
            Console.WriteLine("Person两个参数构造函数调用");
        }

        //当引用类型的堆内存被回收时调用
        ~Person()
        {

        }
    }//end class Person
    //类中是允许自己申明无参构造函数的
    //结构体是不允许
    //C# 10 结构体struct新特性，结构体可以显式声明无参构造函数，以及其他构造函数。!!!

    public struct MyStruct
    {
        public int Value{ get; set; }

        // 显式声明无参构造函数
        public  MyStruct(int value)
        {
            Value = value;
            Console.WriteLine("MyStruct 有参构造函数被调用");
        }

        // 也可以声明一个无参构造函数，但需要手动初始化所有值类型成员
        public MyStruct()
        {
            Value = 1; // 初始化默认值
            Console.WriteLine("MyStruct 无参构造函数被调用");
        }

        //C#中存在，可以初始化静态字段
        //https://blog.csdn.net/SwordArcher/article/details/102833121
        //(1)静态构造函数声明中使用static关键字
        //(2)类只能有一个静态构造函数，而且不能带参数
        //(3)静态构造函数不能有访问修饰符
        //如同静态方法，静态构造函数不能访问所在类的实例成员，因此也不能使用this访问器
        //不能从程序中显示调用静态构造函数，系统会自动调用它们，在类的任何实例被创建之前、类的任何静态成员被引用之前，
        //例如new个对象的时候，系统会先调用到静态构造函数(在已经定义的情况下)，然后在调用默认构造函数。
        static MyStruct() 
        { 
            Console.WriteLine("MyStruct 静态构造函数被调用");
        } // 静态构造函数，不能有返回值，不能有参数，不能有访问修饰符，不能有其他代码块
    }
    #endregion

    #region 知识点二：构造函数的特殊写法
    //可以通过this 重用构造函数代码
    //访问修饰符 构造函数名(参数列表):this(参数1，参数2....)
    #endregion

    #region 知识点三：析构函数
    //基本概念
    //当引用类型的堆内存被回收时，会调用该函数
    //对于需要手动管理内存的语言(比如C++) ，需要在析构函数中做一些内存回收处理
    //但是C#中存在自动垃圾回收机制GC
    //所以我们几乎不会怎么使用析构函数。除非你想在某一个对象被垃圾回收时，做一些特殊处理
    //注意:
    //在Unity开发中析构函数几乎不会使用，所以该知识点只做了解即可

    //基本语法
    //~类名()
    //{
    //}
    #endregion

    #region 知识点四：垃圾回收机制
    //垃圾回收，英文简写GC (Garbage Collector)
    //垃圾回收的过程是在遍历堆(Heap)上动态分配的所有对象
    //通过识别它们是否被引用来确定哪些对象是垃圾，哪些对象仍要被使用
    //所谓的垃圾就是没有被任何变量，对象引用的内容
    //垃圾就需要被回收释放

    //垃圾回收有很多种算法，比如
    //引用计数(Reference Counting）
    //标记清除(Mark Sweep)
    //标记整理(Mark Compact)
    //复制集合(Copy Collection)

    //老版本mono CLR的版本为2.6.5， GC算法为BoehmGC （标记-清除垃圾收集器）。https://juejin.cn/post/6966954993869914119#heading-13  https://juejin.cn/post/6968400262629163038
    //新版本mono CLR的版本为5.11.0， GC算法为SGenGC （分代垃圾收集器）。
    //il2cpp使用的也是BoehmGC（标记-清除垃圾收集器）。


    //注意:
    //GC只负责堆(Heap)内存的垃圾回收
    //引用类型都是存在堆(Heap)中的，所以它的分配和释放都通过垃圾回收机制来管理

    //栈(stack)上的内存是由系统自动管理的
    //值类型在栈(stack)中分配内存的，他们有自己的生命周期，不用对他们进行管理，会自动分配和释放

    //C#中内存回收机制的大概原理 https://zhuanlan.zhihu.com/p/265217138
    //0代内存    1代内存    2代内存
    //代的概念:
    //代是垃圾回收机制使用的一种算法 (分代算法)
    //新分配的对象都会被配置在第0代内存中
    //每次分配都可能会进行垃圾回收以释放内存(0代内存满时)

    //在一次内存回收过程开始时，垃圾回收器会认为堆中全是垃圾，会进行以下两步
    //1.标记对象 从根(静态字段、方法参数）开始检查引用对象，标记后为可达对象，未标记为不可达对象
    //  不可达对象就认为是垃圾
    //2.搬迁对象压缩堆(挂起执行托管代码线程) 释放未标记的对象 搬迁可达对象(使它们紧密排列，减少内存碎片) 修改引用地址

    //大对象总被认为是第二代内存 目的是减少性能损耗，提高性能 
    //不会对大对象进行搬迁压缩 85000字节(83kb) 以上的对象为大对象

    //减少垃圾收集影响的策略:
    //1.尽量减少对象创建，尽量使用对象池(对象缓存)
    //2.尽量减少对象引用，避免过多的循环引用
    //3.尽量减少循环引用，使用弱引用(WeakReference)

    //对象池（Object Pooling）：
    //对于频繁创建和销毁的对象，可以使用对象池来重用对象。这可以减少垃圾收集的频率，因为对象可以被重复使用而不是每次都被销毁。

    //优化数据结构：
    //使用高效的数据结构来减少内存分配。例如，使用数组而不是List<T>，或者使用StringBuilder而不是字符串连接，可以减少中间对象的创建。

    //缓存和重用对象：
    //对于那些创建成本高昂的对象，可以考虑缓存它们以供后续使用，而不是每次都创建新的对象。

    //减少不必要的对象创建：
    //仔细检查代码，避免不必要的对象创建。例如，避免在循环中使用new关键字创建对象，或者避免创建临时对象来存储中间结果。

    //使用struct而不是class：
    //对于小的值类型，使用结构体（struct）而不是类（class），因为结构体是值类型，它们在栈上分配，而不是在托管堆上。

    //管理非托管资源：
    //对于使用非托管资源的类（如文件句柄、数据库连接等），确保实现IDisposable接口，并在不再需要资源时调用Dispose方法。

    //使用fixed语句：
    //如果你需要固定托管对象的地址，可以使用fixed语句来防止垃圾收集器移动对象。但这种做法应该谨慎使用，因为它会影响垃圾收集器的优化。

    //选择合适的数据类型：
    //使用最合适的数据类型来存储数据，例如，使用int而不是long，如果值的范围允许的话，这样可以减少内存的使用。

    //监控和分析：
    //使用性能分析工具来监控应用程序的内存使用情况。这可以帮助你识别内存泄漏和过度的内存分配。

    //异步和延迟执行：
    //对于可以延迟执行的操作，使用异步编程模式来避免在等待操作完成时占用资源。

    //调整垃圾收集设置：
    //对于服务器应用程序，可以根据应用程序的特定需求调整垃圾收集的设置，例如调整堆的大小或调整垃圾收集的代。
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("构造函数与析构函数");

            Person p = new Person();
            Person p1 = new Person("sdsd",12);  //栈连接到堆地址，堆地址存储"sdsd",12
            Console.WriteLine(p.name);

            p1 = null;  //栈为空，连接到堆地址断开，数据"sdsd",12成为垃圾

            //手动触发垃圾回收的方法
            GC.Collect();
            //一般情况下 我们不会频繁调用
            //都是在 Loading 过场时才调用

            MyStruct s = new MyStruct();
            Console.WriteLine(s.Value);
            s = new MyStruct(20);
            Console.WriteLine(s.Value);
            //输出：1,1

            MyStruct s1 = new MyStruct();
            Console.WriteLine(s1.Value);
        }
    }
}
