#define Fun
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Lesson21_反射和特性_特性
{
    #region 知识点一：特性是什么
    //特性是一种允许我们向程序的程序集添加元数据的语言结构
    //它是用于保存程序结构信息的某种特殊类型的类

    //特性提供功能强大的方法以将声明信息与 C# 代码(类型、方法、属性等) 相关联
    //特性与程序实体关联后，即可在运行时使用反射查询特性信息

    //特性的目的是告诉编译器把程序结构的某组元数据嵌入程序集中
    //它可以放置在几乎所有的声明中 (类、变量、函数等等申明)

    //说人话:
    //特性本质是个类
    //我们可以利用特性类为元数据添加额外信息
    //比如一个类、成员变量、成员方法等等为他们添加更多的额外信息
    //之后可以通过反射来获取这些额外信息
    #endregion

    #region 知识点二：自定义特性
    //继承特性基类 Attribute
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    class MyCustomAttribute : Attribute
    {
        //特性中的成员 一般根据需求来写
        public string info;

        public MyCustomAttribute(string info) 
        {
            this.info = info;
        }
        public void TestFun()
        {
            Console.WriteLine("特性的方法");
        }
    }

    #endregion

    #region 知识点三：特性的使用
    //基本语法:
    //[特性名(参数列表)]
    //本质上 就是在调用特性类的构造函数
    //写在哪里?
    //类、函数、变量上一行，表示他们具有该特性信息

    [MyCustomAttribute("这个是我自己写的一个用于计算的类")]
    class MyClass
    {
        [MyCustom2Attribute("这是一个成员变量")]
        public int value;

        //[MyCustom("这是一个用于计算加法的函数")]
        //public void TestFun([MyCustom("函数参数")]int a)
        //{

        //}
        public void TestFun1(int a)
        {

        }
    }
    #endregion

    #region 知识点四：限制自定义特性的使用范围
    //通过为特性类 加特性 限制其使用范围
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    //参数一:AttributeTargets - 特性能够用在哪些地方
    //参数二:A1lowMultiple - 是否允许多个特性实例用在同一个目标上
    //参数三:Inherited - 特性是否能被派生类和重写成员继承
    public class MyCustom2Attribute : Attribute
    {
        public string info;

        public MyCustom2Attribute(string info)
        {
            this.info = info;
        }
    }
    #endregion

    #region 知识点五：系统自带特性——过时特性
    //过时特性
    //Obsolete
    //用于提示用户 使用的方法等成员已经过时 建议使用新方法
    //一般加在函数前的特性

    class TestClass
    {
        //参数一: 调用过时方法时 提示的内容
        //参数二: true-使用该方法时会报错 false-使用该方法时直接警告
        [Obsolete("oldSpeak方法已经过时了，请使用speak方法",false)]
        public void OldSpeak(string str)
        {
            Console.WriteLine("oldSpeak方法已经过时了，请使用speak方法");
        }
        public void Speak()
        {
    
        }
        public void SpeakCaller(string str,[CallerFilePath]string fileName="",
            [CallerLineNumber]int line = 0, [CallerMemberName] string target = "")
        {
            // 这里可以使用 fileName, line, 和 target 变量来获取调用者的信息  
            // 例如，打印出调用此方法的文件名、行号和成员名  
            Console.WriteLine($"Called from {fileName}, Line {line}, Member {target} with message: {str}");
        }
        //当你在其他方法调用了 SpeakCaller 方法时，SpeakCaller 方法会自动捕获调用它的文件名、行号和成员名，并将这些信息连同传入的字符串一起打印出来。
    }
    #endregion

    #region 知识点六：系统自带特性——调用者信息特性
    //哪个文件调用?
    //CallerFilePath特性
    //哪一行调用?
    //CallerLineNumber特性
    //哪个函数调用?
    //CallerMemberName特性

    //需要引用命名空间 using System.Runtime.CompilerServices;
    //一般作为函数参数的特性

    //注意事项
    //这些特性仅在编译器能够确定调用者信息时有效。例如，如果你通过反射调用一个方法，那么这些特性可能不会返回预期的值。
    //这些特性主要用于调试和日志记录，它们不应被用于安全敏感的逻辑中，因为它们的值可以被修改或伪造。
    //在某些情况下，如果编译器无法确定调用者信息（例如，在匿名方法或lambda表达式中），这些特性可能会返回默认值（如空字符串或零）。
    #endregion

    #region 知识点七：系统自带特性——条件编译特性
    //条件编译特性
    //Conditional
    //它会和预处理指令#define配合使用

    //需要引用命名空间using System.Diagnostics;
    //主要可以用在一些调试代码上
    //有时想执行有时不想执行的代码
    #endregion

    #region 知识点八：系统自带特性——外部dll包函数特性
    //DllImpor——外包

    //用来标记非.Net(C#)的函数，表明该函数在一个外部的DLL中定义
    //一般用来调用 C或者C++的D11包写好的方法
    //需要引|用命名空间 using System.Runtime.InteropServices
    #endregion

    internal class Program
    {
        [DllImport("类库测试.dll")]
        public static extern int Add(int a, int b);  //extern 修饰符用于声明在外部实现的方法。

        [Conditional("Fun")]
        static void Fun()
        {
            Console.WriteLine("执行Fun");
        }

        [Conditional("Fun1")]
        static void Fun1()
        {
            Console.WriteLine("执行Fun1");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("反射和特性_特性");

            #region 特性的使用
            MyClass mc = new MyClass(); 
            Type t = mc.GetType();
            //t = typeof(MyClass);
            //t = Type.GetType("Lesson21 特性.MyClass");
            //
            //判断是否使用了某个特性
            //参数一: 特性的类型                                               
            //参数二: 代表是否搜索继承链(属性和事件忽略此参数)
            if( t.IsDefined(typeof(MyCustomAttribute), false))  //只能检测类前的特性
            {
                Console.WriteLine("该类型应用了MyCustom特性");
            }
            #region GetCustomAttributes
            Console.WriteLine("*********");
            //用于获取应用于某个成员（如方法、属性、字段等）上的所有自定义属性（Custom Attributes）的数组。
            //自定义属性是一种在运行时提供关于程序元素（如类、方法、属性等）的额外信息的机制。

            //方法参数
            //inherit（布尔类型）: 这个参数决定了是否搜索此成员的继承链以查找属性。
            //如果设置为true，则会检查当前成员及其所有基类中定义的属性；
            //如果设置为false，则仅检查当前成员上定义的属性。
            //然而，对于属性和事件来说，这个参数是被忽略的，因为属性和事件的属性继承规则与方法和字段不同。

            //返回值
            //返回一个对象数组，包含应用于此成员的所有自定义属性。
            //如果没有定义任何属性，则返回一个包含零个元素的数组。

            //异常
            //System.InvalidOperationException：如果此成员属于一个仅在反射上下文中加载的类型，则抛出此异常。
            //    这通常发生在尝试对在反射上下文中加载的类型（而非正常加载的类型）执行操作时。
            //System.TypeLoadException：如果无法加载自定义属性的类型，则抛出此异常。
            //    这可能是因为类型不存在、无法访问或存在其他问题导致类型无法被正确加载。

            //使用场景
            //    这个方法在多种情况下都非常有用，例如：
            //    在运行时检查类的成员是否标记了特定的自定义属性，以改变其行为或提供额外的功能。
            //    实现依赖注入、AOP（面向切面编程）等设计模式时，通过检查成员上的自定义属性来动态地添加行为。
            //    在单元测试中，利用自定义属性来标记测试方法或类，以便于测试框架识别和执行。
            #endregion
            object[] array = t.GetCustomAttributes(true);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is MyCustomAttribute)
                {
                    Console.WriteLine((array[i] as MyCustomAttribute).info);
                    (array[i] as MyCustomAttribute).TestFun();
                }
            }
            Console.WriteLine("*********");

            TestClass tc = new TestClass();
            tc.OldSpeak("123");

            Fun();
            Fun1();

            int result = Add(5, 3);
            Console.WriteLine($"The result is: {result}");
            #endregion
        }
    }
}
