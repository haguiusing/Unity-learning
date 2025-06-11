using System.Reflection;

namespace Lesson20_反射和特性_反射
{
    #region 知识点一：什么是程序集
    //程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    //在WINDONS系统中，它一般表现为后缀为·dll(库文件) 或者是·exe (可执行文件)的格式

    //说人话:
    //程序集就是我们写的一个代码集合，我们现在写的所有代码
    //最终都会被编译器翻译为一个程序集供别人使用
    //比如一个代码库文件 (dll) 或者一个可执行文件(exe)
    #endregion 知识点一：什么是程序集

    #region 知识点二：元数据

    //元数据就是用来描述数据的数据
    //这个概念不仅仅用于程序上，在别的领域也有元数据

    //说人话:
    //程序中的类，类中的函数、变量等等信息就是 程序的 元数据
    //有关程序以及类型的数据被称为 元数据，它们保存在程序集中

    #endregion 知识点二：元数据

    #region 知识点三：反射的概念

    //程序正在运行时，可以查看其它程序集或者自身的元数据。
    //一个运行的程序重看本身或者其已程序的元数据的行为就叫做反射

    //说人话:
    //在程序运行时，通过反射可以得到其它程序集或者自己程序集代码的各种信息
    //类，函数，变量，对象等等，实例化它们，执行它们，操作它们

    #endregion 知识点三：反射的概念

    #region 知识点四：反射的作用

    //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性
    //1.程序运行时得到所有元数据，包括元数据的特性
    //2.程序运行时，实例化对象，提作对象
    //3.程序运行时创建新对象，用这些对象执行任务

    #endregion 知识点四：反射的作用
    public interface IMyInterface { }
    internal class Test:IMyInterface
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";
        public event EventHandler MyEvent;

        public int I
        {
            get { return i; }
            set { i = value; }
        }

        public Test()
        {
        }

        public Test(int j)
        {
            this.j = j;
        }

        public Test(int i, string str) : this(i)
        {
            this.str = str;
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("反射和特性_反射");

            #region 知识点五：语法相关

            //Type (类的信息类)
            //它是反射功能的基础!
            //它是访问元数据的主要方式
            //使用 Type 的成员获取有关类型声明的信息
            //有关类型的成员(如构造函散、方法、字段、属性和类的事件)

            #region Type

            #region 获取Type

            //1.万物之父object中的 GetType()可以获取对象的Type
            int a = 42;
            Type type = a.GetType();
            //Console.WriteLine(type);
            //2.通过typeof关键字 传入类名 也可以得到对象的Type
            Type type2 = typeof(int);
            //Console.WriteLine(type2);
            //3.通过类的名字 也可以获取类型
            // 注意 类名必须包含命名空间 不然找不到
            Type type3 = Type.GetType("System.Int32");
            //Console.WriteLine(type3);

            #endregion 获取Type

            #region 获取类的程序集信息

            //可以通过Type可以得到类型所在程序集信息
            //Console.WriteLine(type.Assembly);
            //Console.WriteLine(type2.Assembly);
            //Console.WriteLine(type3.Assembly);

            #endregion 获取类的程序集信息

            #region 获取类中的所有公共成员
            Console.WriteLine("获取类中的所有公共成员:");
            //首先得到Type
            Type t = typeof(Test);
            //然后得到所有公共成员
            //需更引|用命名空间 using System.Reflection;
            MemberInfo[] infos = t.GetMembers();
            for (int i = 0; i < infos.Length; i++)
            {
                //Console.WriteLine(infos[i]);
            }

            #endregion 获取类中的所有公共成员

            #region 获取类的构造函数并调用
            Console.WriteLine("获取类的构造函数并调用:");
            //1.获取所有构造函数
            ConstructorInfo[] ctors = t.GetConstructors();
            for (int i = 0; i < ctors.Length; i++)
            {
                //Console.WriteLine(ctors[i]);
            }

            //2.获取其中一个构造函 并执行
            //得构造函数传入 Type数组 组中内容按顺序是参数类型
            //执行构造函数传入 object数组 表示按顺序传入的参数
            // 2-1得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            //执行无参构造 没有参数 传null；
            Test obj = info.Invoke(null) as Test;
            //Console.WriteLine(obj.j);

            // 2-2得到有参构造
            ConstructorInfo info2 = t.GetConstructor(new Type[] { typeof(int) });
            obj = info2.Invoke(new object[] { 2 }) as Test;  //传入2
            //Console.WriteLine(obj.j);

            ConstructorInfo info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
            obj = info3.Invoke(new object[] { 4, "4444" }) as Test;  //传入2
            //Console.WriteLine(obj.str);

            #endregion 获取类的构造函数并调用

            #region 获取类中的公共成员变量

            //1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                //Console.WriteLine(fieldInfos[i]);
            }

            //2.得到指定名称的公共成员变量
            FieldInfo infoJ = t.GetField("j");
            //Console.WriteLine(infoJ);

            //3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "2222";
            // 3-1通过反射 获取对象的某个变量的值
            //Console.WriteLine(infoJ.GetValue(test));
            // 3-2通过反射 设置指定对象的菜个变量的值
            infoJ.SetValue(test, 100);
            //Console.WriteLine(infoJ.GetValue(test));

            #endregion 获取类中的公共成员变量

            #region 获取类中的公共成员方法

            //通过Type类中的 GetMethod方法 得到类中的方法
            //MethodInfo 是方法的反射信息
            Type strType = typeof(string);

            //1.如果存在方法重载 用Type数组表示参数类型
            MethodInfo[] methods = strType.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                //Console.WriteLine(methods[i]);
            }
            MethodInfo subStr = strType.GetMethod("Substring",
                new Type[] { typeof(int), typeof(int) });

            //2.调用该方法
            //注意: 如果是静态方法 Invoke中的第一个参数传nu11即可
            string str = "Hello,World!";
            //不是静态方法第一个参数 相当于 是哪个对象要执行这个成员方法
            object result = subStr.Invoke(str, new object[] { 7, 5 });
            //Console.WriteLine(result);

            #endregion 获取类中的公共成员方法

            #region 其他

            //Type;
            //得枚举
            //GetEnumName
            //GetEnumNames
            // 获取枚举类型
            Type enumType = typeof(System.DayOfWeek);

            // 获取枚举的所有名称
            string enumName = enumType.GetEnumName(1); // 获取值为1的枚举名称
            string[] enumNames = enumType.GetEnumNames(); // 获取枚举的所有名称
            Type enumUnderlyingType = enumType.GetEnumUnderlyingType(); // 获取枚举的基础类型
            Array enumValues = enumType.GetEnumValues(); // 获取枚举的所有值
            Array enumValuesAsUnderlyingType = enumType.GetEnumValuesAsUnderlyingType(); // 获取枚举的所有值

            //得事件
            //GetEvemt
            //GetEvents
            // 获取事件信息
            EventInfo eventInfo = t.GetEvent("MyEvent");
            EventInfo[] eventInfos = t.GetEvents();
            Console.WriteLine("Event Name: " + eventInfo.Name);

            //得接口
            //GetInterface
            //GetInterfaces
            // 获取类实现的所有接口
            Type myInterface = t.GetInterface("IMyInterface");
            Type[] interfaces = t.GetInterfaces();
            Console.WriteLine("Implemented Interfaces:");
            foreach (Type iface in interfaces)
            {
                Console.WriteLine(iface.Name);
            }

            //得属性
            //Getproperty
            //GetProperties
            // 获取属性信息
            PropertyInfo propertyInfo = t.GetProperty("MyProperty");
            PropertyInfo[] propertyInfos = t.GetProperties();
            Console.WriteLine("Property Name: " + propertyInfo.Name);
            //等等
            Console.WriteLine("**************");

            #endregion 其他

            #endregion Type

            #region Assembly

            //程序集类
            //主要用来加载其它程序集，加载后
            //才能用Type来使用其它程序集中的信息
            //如果想要使用不是自己程序集中的内容 需要先加载程序集
            //比如 dll文件(库文件)
            //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量.函数或类

            //三种加载程序集的函数
            //一般用来加载在同一文件下的其它程序集
            //Assembly asembly2 = Assembly.Load("程序集名称");

            //一般用来加载不在同一文件下的其它程序集
            //Assembly asembly = Assembly.LoadFrom("包含程序集清单的文件的名称或路径");
            //Assembly asembly3 = Assembly.LoadFile(”要加载的文件的完全限定路径");

            //1.先加载一个指定程序集
            //注：\\或“@”取消转义字符
            Assembly assembly = Assembly.LoadFrom("F:\\Unity学习\\C#\\4.C#进阶\\C#进阶\\Lesson18_多线程\\bin\\Debug\\net8.0\\Lesson18_多线程");
            Type[] types = assembly.GetTypes();  //获取程序集元素
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }

            //2.再加载程序集中的一个类对象 之后才能使用反射
            Type programType = assembly.GetType("Lesson18_多线程.Program");
            MemberInfo[] members = programType.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }
            Console.WriteLine("**************");

            object programInstance = Activator.CreateInstance(programType);
            // 获取静态方法
            //Program 类中，drawRed 和 drawYellow 都是静态方法。
            //当您通过反射调用这些方法时，您不需要实例化 Program 类，因为静态方法属于类本身而不是类的任何特定实例。
            MethodInfo drawRed = programType.GetMethod("drawRed", BindingFlags.Static | BindingFlags.Public);
            MethodInfo drawYellow = programType.GetMethod("drawYellow", BindingFlags.Static | BindingFlags.Public);

            //方法
            //MethodInfo drawRed = programType.GetMethod("drawRed");
            //MethodInfo drawYellow = programType.GetMethod("drawYellow");

            while (true)
            {
                Thread.Sleep(1000);
                drawRed.Invoke(programType, null);
                drawYellow.Invoke(programType, null);
            }

            //枚举
            //通过反射 实例化一个 icon对象
            //首先得到枚举Type 来得到可以传入的参数
            //Type moveDir = assembly.GetType("Lesson18_多线程.MoveDir");
            //FieldInfo right = moveDir.GetField("Right");
            //直接实例化对象
            //object iconObj = Activator.CreateInstance(Program, 10, 5, right.GetValue(null));
            //得到对象中的方法 通过反射
            //MethodInfo move = icon.GetMethod("Move");
            //MethodInfo draw = icon.GetMethod("Draw");
            //MethodInfo clear = icon.GetMethod("Clear");

            //3.类库工程创建

            Console.WriteLine("**************");

            #endregion Assembly

            #region Activator

            //用于快速实例化对象的类
            //用于将Type对象快捷实例化为对象
            //先得到Type
            //然后 快速实例化一个对象
            Type testType = typeof(Test);
            //1.无参构造
            Test testObj = Activator.CreateInstance(testType) as Test;
            Console.WriteLine(testObj.str);

            //2.有参数构造
            testObj = Activator.CreateInstance(testType, 99) as Test;
            Console.WriteLine(testObj.j);

            testObj = Activator.CreateInstance(testType, 123, "456") as Test;
            Console.WriteLine(testObj.j + "  " + testObj.str);

            #endregion Activator

            #endregion 知识点五：语法相关
        }
    }
}