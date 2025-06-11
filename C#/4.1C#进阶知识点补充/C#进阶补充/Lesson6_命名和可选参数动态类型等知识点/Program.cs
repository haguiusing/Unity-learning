
using System.Reflection;

namespace Lesson6_命名和可选参数动态类型等知识点
{
    public class Test
    {
        public void TestMethod() { }
    }

    public class Test2
    {
        public void TestMethod() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson6_命名和可选参数动态类型等知识点");

            #region 知识点一：最低支持的C#版本
            //Unity 5.5及以上版本支持的C#版本: C# 4.0及以上版本。也就是说，C# 1到4的版本里面的内容，Unity都是支持的。
            #endregion

            #region 知识点二：C# 1~4的功能和语法有哪些
            //C# 1到4版本的功能和语法
            //讲解内容说明: 主要提及Unity开发当中会用到的一些C# 1到4版本的功能和特性，对于不适合在应用题当中使用的内容会省略。

            //注意: 这里不会提及C# 1到4版本的所有内容，而是有针对性地讲解Unity开发中常用的功能和语法。

            //1.C#1的功能和语法
            //  委托和事件: C#1中引入了委托和事件的概念，这是C#进阶课程中的重要内容。如果对此不熟悉，可以回顾C#进阶课程。
            //2.C#2的功能和语法
            //  泛型: 允许定义类、接口和方法时使用类型参数，从而使代码更加通用。
            //  匿名方法: 没有名称的方法，可以在代码中内联定义。
            //  迭代器: 用于逐一访问集合中的元素，而不需要显式使用循环。
            //  可空类型: 允许值类型变量存储null值。
            //3.C#3的功能和语法
            //  隐式类型: 编译器自动推断变量的类型。
            //  对象集合初始化: 允许在声明集合的同时进行初始化。
            //  Lambda表达式: 简洁地表示匿名方法，通常用于LINQ查询和事件处理。
            //  匿名类型: 允许在代码中直接定义类型，而无需显式声明类。
            //  自动实现属性: 简化了属性的定义，无需显式编写get和set访问器。
            //  拓展方法: 允许向现有类型添加新方法，而无需修改类型本身。
            //  分部类: 允许将类的定义分散在多个文件中，便于代码管理。
            //4.C#4的功能和语法
            //  泛型的协变和逆变: 提高了泛型接口的灵活性和可用性。
            //  命名和可选参数: 提高了方法调用的灵活性和代码的可读性。
            //  动态类型: 允许在运行时确定变量的类型，增强了代码的灵活性，但也增加了类型安全的风险。
            //5.补充讲解：命名和可选参数
            //  命名参数: 在调用方法时，可以明确指定参数的名称和值，提高代码的可读性。
            //  可选参数: 在定义方法时，可以为参数提供默认值，调用方法时可以省略这些参数。
            //6.补充讲解：动态类型
            //动态类型: 使用dynamic关键字声明的变量，其类型在运行时确定。这允许在编译时不确定类型的情况下编写代码，但也放弃了编译时的类型检查。
            //注意: 使用动态类型时，需要谨慎处理类型转换和成员访问，以避免运行时错误。
            #endregion

            #region 知识点三：补充未讲解全面的内容 命名和可选参数
            //命名参数: 调用函数时，可以不按参数顺序传递，而是直接指定参数名进行赋值。
            //示例:
            //调用方式:
            Test(1, 2.2f,true);
            Test(f: 3.3f, i: 5, b: false);

            //配合可选参数: 命名参数可以与可选参数结合使用，跳过某些默认参数直接为后面的参数赋值。
            //示例:
            //调用方式:
            Test2(1, s: "234");//这里b使用默认值true。
                               //好处:
                               //使函数调用更灵活，减少重载函数的编写。
            #endregion

            #region 知识点四：补充未讲解全面的内容 动态类型
            //关键字: dynamic
            //作用: 通过dynamic类型标识变量，绕过编译时类型检查，改为在运行时解析操作。
            //通过dynamic类型标识变量的使用和对其成员的引用绕过编译时类型检查
            //       改为在运行时解析这些操作。
            //       在大多数情况下, dynamic类型和object类型行为类似
            //       任何非Null表达式都可以转换为dynamic类型。
            //       dynamic类型和object类型不同之处在于,
            //       编译器不会对包含类型 dynamic的表达式的操作进行解析或类型检查
            //       编译器将有关该操作信息打包在一起,之后这些信息会用于在运行时评估操作.
            //       在此过程中, dynamic 类型的变量会编译为 object 类型的变量.
            //       因此, dynamic 类型只在编译时存在，在运行时则不存在

            //与object类型区别:
            //行为类似: 在多数情况下，dynamic类型和object类型行为相似。
            //编译检查: 编译器不会对包含dynamic类型的表达式进行类型检查，而是将操作信息打包，在运行时评估。

            //注意:
            //兼容级别: 使用dynamic功能需要将Unity的.Net API兼容级别切换为.Net 4.x。
            //IL2CPP不支持: IL2CPP不支持C# dynamic关键字，因为它需要JIT编译，而IL2CPP是AOT编译。
            //方法拼写: 动态类型无法自动补全方法，书写时必须保证方法拼写正确。

            //好处:
            //节约代码量: 当不确定对象类型，但确定对象成员时，可以使用动态类型。
            //反射替代: 通过反射处理某些功能时，可以考虑使用动态类型替换。

            //示例:
            //声明动态类型变量:
            dynamic dyn = 1;  //无法确定类型，编译器将其编译为object类型。无法导航
            object obj = 2;
            //调用方法:
            dyn.GetType();//注意方法拼写必须正确。
            Console.WriteLine(dyn.GetType());   //无提示
            Console.WriteLine(obj.GetType());

            object t = new Test();
            dynamic d = t;
            d.TestMethod();  //调用动态类型的方法

            // 获取Test类的Type信息
            Type testType = typeof(Test);
            // 使用反射创建Test类的实例
            t = Activator.CreateInstance(testType);
            // 获取TestMethod方法信息
            MethodInfo testMethod = testType.GetMethod("TestMethod");
            // 使用反射调用TestMethod方法
            testMethod.Invoke(t, null);
            //总结: 动态类型虽有其便利之处，但由于兼容性和编译方式的限制，不建议常规使用，仅作了解。

            dynamic MyDynamicVar = 100;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = "Hello World!!";
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = true;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = DateTime.Now;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());
            #endregion

            #region 内容总结

            #endregion
        }

        public static void Test(int  i,float f,bool b)
        {

        }

        /// <summary>
        /// 测试方法2
        /// </summary>
        /// <param name="i"> 参数1 </param>
        /// <param name="b"> 参数2 </param>
        /// <param name="s"> 参数3 </param>
        public static void Test2(int i,bool b = false,string s = "123")
        {

        }
    }
}
