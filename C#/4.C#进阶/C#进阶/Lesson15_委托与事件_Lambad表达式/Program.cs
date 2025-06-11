namespace Lesson15_委托与事件_Lambda表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson15_委托与事件_Lambda表达式");

            #region 知识点一：什么是lambda表达式
            //可以将lambda表达式 理解为匿名函数的简写
            //它除了写法不同外
            //使用上和匿名函数一模一样
            //都是和委托或者事件 配合使用的
            #endregion

            #region 知识点二：lambda表达式语法
            //匿名函数
            //delegate (参数列表)
            //{
            //
            //};

            //lambad表达式
            //(参数列表) =>
            //{
            //函数体
            //};
            #endregion

            #region 知识点三：使用
            //1.无参无返回
            Action a = () =>
            {
                Console.WriteLine("无参无返回的lambda表达式");
            };
            a();

            // 2.有参
            Action<int> a2 = (int value) =>
            {
                Console.WriteLine("有参数的lambda表达式" + value) ;
            };
            a2(100);

            //3.甚至参数类型都可以省略 参数类型和委托或事件容器一致
            Action<int> a3 = (value) =>
            {
                Console.WriteLine("省略参数类型写法的lambda表达式" + value);
            };
            a3(200);

            //4.有返回值,分配给委托
            //Action委托只能具有输入参数
            //Func委托期望第一个为输入参数类型，最后一个为返回值类型
            Func<string, int> a4 = (value) =>
            {
                Console.WriteLine("有返回值的lambda表达式", value);
                return 1;
            };
            a4("300");
            Console.WriteLine(a4("500"));

            //5.具有多个参数的Lambda表达式
            Func<Student, int, bool> a5 = (s, youngAge) => s.Age >= youngAge;
            //如果觉得参数表达不清，您还可以给出每个参数的类型
            Func<Student, int, bool> a6 = (Student s,int youngAge) => s.Age >= youngAge;

            //其它传参使用等和匿名函数一样
            //缺点也是和匿名函数一样的
            #endregion
            Console.WriteLine("*******");
            Test t = new Test();
            t.DoSomthing();
        }
    }
    #region 知识点四：闭包
    //内层的函数可以引用包含在它外层的函数的变量
    //即使外层函数的执行已经终止
    //注意:
    // 该变量提供的值并非变量创建时的值，而是在父函数范围内的最终值。
    class Test
    {
        public event Action action;

        public Test()
        {
            int value = 100;

            //这里就形成了闭包
            //因为 当构造函数执行完毕时 其中申明的临时变量value的生命周期被改变了
            action = () =>
            {
                value += 100;
                Console.WriteLine("闭包" + value);
            };
            //value 是一个在 Test 构造函数内部定义的局部变量。
            //由于匿名方法（lambda 表达式）引用了 value，
            //因此 value 的生命周期被延长了，直到匿名方法（现在作为 action 事件的一部分）不再被引用。
            //这展示了闭包的一个特性：它能够捕获并存储其外部作用域中的变量，即使外部作用域已经执行完毕。

            for (int i = 0; i < 10; i++)
            {
                action += () =>
                {
                    Console.Write(i + " ");
                };
            }

            Console.WriteLine();
            //在这个循环中，您尝试为 action 事件添加多个委托，每个委托都试图打印变量 i 的值。
            //然而，这里有一个问题：由于所有匿名方法都共享同一个 i 变量（它是循环变量），
            //当循环结束时，i 的值将会是 10（因为循环条件 i< 10 在 i 等于 10 时不再为真，
            //从而退出循环）。因此，当任何这些匿名方法被调用时，
            //它们都会打印出 10，而不是它们各自在循环中对应的 i 值。
            //修改为
            for (int i = 0; i < 10; i++)
            {
                int index = i;
                action += () =>
                {
                    Console.Write(index + " ");
                };
            }
            //在这个修正后的版本中，通过在循环体内创建一个新的局部变量 index
            //并将其初始化为当前的 i 值，每个匿名方法都捕获了它自己的 index 副本。
            //因此，当这些匿名方法被调用时，它们会打印出各自在循环中对应的 index 值（即 0 到 9）。
            //这是因为每个匿名方法都捕获了一个独立的 index 变量，这些变量在循环的每次迭代中都被赋予了一个新的值。

            Console.WriteLine();
            //使用foreach 循环也能实现同样的效果
            foreach (int i in Enumerable.Range(0, 10))
            {
                action += () =>
                {
                    Console.Write(i + " ");
                };
            }
        }
        public void DoSomthing()
        {
            action();
        }
    }
    #endregion

    class Student
    {
        public int Age { get; set; }
    }
}
