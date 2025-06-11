using static System.Math;
using static Lesson10_静态导入异常筛选器nameof等知识点.MyClass;

namespace Lesson10_静态导入异常筛选器nameof等知识点
{
    public class MyClass
    {
        public  class NestedClass
        {
            public int MyProperty { get; set; }
        }
        public static int MyProperty { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson10_静态导入异常筛选器nameof等知识点");

            #region 知识点一：C# 6.0 新增功能和语法
            //1.=>运算符 (C#进阶套课—特殊语法 =>)
            //2.Null 传播器 (C#进阶套课—特殊语法 ?)
            //3.字符串内插 (C#讲阶套课—特殊语法 $)
            //4.静态导入
            //5.异常筛选器
            //6.namsOf运算符
            #endregion

            #region 知识点二：补充讲解—静态导入
            //用法：在引用命名空间时，在using关键字后面加入static关键词
            //作用：无需指定类型名称即可访问其静态成员和嵌套类型
            //好处：节约代码量，可以写出更简洁的代码

            MathF.Abs(1);
            Abs(1); //静态导入后可以直接使用Abs方法

            MyClass.MyProperty = 10;
            MyProperty = 10; //静态导入后可以直接使用MyProperty属性
            NestedClass nestedClass = new NestedClass();
            nestedClass.MyProperty = 10; //静态导入后可以直接使用NestedClass.MyProperty属性
            #endregion

            #region 知识点三 补充讲解—异常筛选器_上下文关键字when
            //用法：在异常捕获语句块中的Catch语句后通过加入when关键词来筛选异常
            //  when(表达式) 该表达式返回值必须为bool值, 如果为ture则执行异常处理,如果为false, 则不执行
            //作用: 用于筛选异常
            //好处: 帮助我们更准确的排查异常
            try
            {
                //用于检查异常的语句块
            }
            catch (System.Exception e) when (e.Message.Contains("301"))
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Exception e) when (e.Message.Contains("404"))
            {
                Console.WriteLine(e.Message);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
            #endregion

            #region 知识点四：nameof运算符
            //用法: nameof(变量、类型、成员)通过该表达式,可以将他们的名称转为字符串
            //作用：可以得到变量、类、函数等信息的具体字符串名称
            int i = 10;
            Console.WriteLine(nameof(i));  //输出i
            Console.WriteLine(nameof(List<int>));  //输出List<int>
            Console.WriteLine(nameof(List<int>.Add));   //输出Add
            Console.WriteLine(nameof(System.Math));  //输出System.Math

            List<int> list = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine(nameof(list));
            Console.WriteLine(nameof(list.Count));
            Console.WriteLine(nameof(list.Add));

            #endregion

            #region 总结
            //C#6中新的内容
            //我们认为 => 运算符、Null传播器(?)、字符串串插对于我们来说是可以常用的
            //其它增加的几个知识点使用情景不多，了解即可

            #endregion
        }
    }
}
