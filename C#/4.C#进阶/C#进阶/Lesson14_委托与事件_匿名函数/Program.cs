namespace Lesson14_委托与事件_匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托与事件_匿名函数");

            #region 知识点一：什么是匿名函数
            //顾名思义，就是没有名字的函数
            //匿名函数的使用主要是配合委托和事件进行使用
            //脱离委托和事件 是不会使用匿名函数的
            #endregion

            #region 知识点二：基本语法
            //delegate (参数列表)
            //{
            //  //函数逻辑
            //};
            //何时使用？
            //1.函数中传递委托参数时
            //2.委托或事件赋值时
            #endregion

            #region 知识点三：使用
            //1.无参无返回
            //这样申明匿名函数 只是在申明函数而已 还没有调用
            //真正调用它的时候 是这个委托容器啥时候调用 就什么时候调用这个匿名函数
            Action a = delegate ()  //仅申明,为调用
            {
                Console.WriteLine("匿名函数逻辑1");
            };

            a += delegate ()
            {
                Console.WriteLine("匿名函数逻辑2");
            };

            a();

            // 2.有参
            Action<int, string> b = delegate (int a, string b)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            };

            b += delegate (int a, string b)
            {
                Console.WriteLine(a * 2);
                Console.WriteLine(b + "123");
            };

            b(100, "123");

            //3.有返回值
            Func<string> c = delegate ()
            {
                return "456";
            };

            //4.一般情况会作为函数参数传递 或者 作为函数返回值
            Test t = new Test();
            // 参数传递
            //写法一 一步到位
            t.Dosomthing(100, delegate ()
            {
                Console.WriteLine("随参数传入的匿名函数逻辑");
            });
            //写法二 先用委托容器存匿名函数，再传委托
            Action ac = delegate ()  //仅申明,为调用
            {
                Console.WriteLine("随参数传入的匿名函数逻辑");
            };
            t.Dosomthing(50, ac);

            // 返回值
            //写法一
            Action ac2 = t.GetFun2();
            ac2();
            //写法二 一步到位
            t.GetFun()();  //第一个()是委托容器，第二个()是运行
            #endregion

            #region 知识点四：匿名函数的缺点
            //添加到委托容器或容器中后 不记录 无法单独移除
            Action ac3 = delegate ()
            {
                Console.WriteLine("匿名函数一");
            };
            ac3 += delegate ()
            {
                Console.WriteLine("匿名函数二");
            };
            ac3();
            //因为匿名函数没有名字 所以没有办法指定移除某一匿名函数
            //此匿名函数 非彼匿名函数 不能通过看逻辑是否一样 就证明是同一个
            //ac3 -= delegate ()  //无效的
            //{
            //    Console.WriteLine("匿名函数二");
            //};
            //ac3();
            ac3 = null ;
            #endregion
        }
    }
    class Test
    {
        public Action action;

        // 匿名函数作为参数传递时
        public void Dosomthing(int a,Action fun)
        {
            Console.WriteLine(a);
            fun();
        }
        // 匿名函数作为返回值时
        //原写法
        public Action GetFun()
        {
            return TestTTT;
        }
        public void TestTTT()
        {

        }
        //匿名函数写法
        public Action GetFun2()
        {
            return delegate ()
            {
                Console.WriteLine("函数内部返回的匿名函数逻辑");
            };
        }
    }
}
