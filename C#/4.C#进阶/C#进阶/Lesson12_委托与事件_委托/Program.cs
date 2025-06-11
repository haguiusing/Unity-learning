using System;

namespace Lesson12_委托与事件_委托
{
    #region 知识点一：委托是什么
    //委托是 函数(方法)的容器
    //可以理解为表示函数(方法)的变量类型
    //用来 存储、传递函数(方法)
    //委托的本质是一个类，用来定义函数(方法)的类型(返回值和参数的类型)
    //不同的 函数(方法)必须对应和各自“格式”一致的委托
    #endregion

    #region 知识点二：基本语法
    //关键字delerate
    //语法: 访问修饰符 delegate 返回值 委托名(参数列表);

    //写在哪里?
    //可以申明在namespace和class语句块中
    //更多的写在namespace中

    //简单记忆委托语法 就是 函数申明语法前面加一个delegate关键字
    #endregion

    #region 知识点三：定义自定义委托
    //访问修饰默认不写 为public 在别的命名空间中也能使用
    //private 其它命名空间就不能用了
    //一般使用public

    //申明了一个可以用来存储无参无返回值函数的容器
    //这里只是定义了规则 并没有使用
    delegate void MyFun();
    //委托规则的申明 是不能重名的（在同一语句块中）
    //delegate void MyFun(int a);
    delegate void MyFun2(int a);
    //表示用来装载或传递 返回值为int 有一个int参数的函数的委托

    //自定义泛型委托
    delegate T MyFun3<T,K>(T v, K k);
    #endregion

    #region 知识点四：使用定义好的委托
    //委托变量是函数的容器

    //委托常用在:
    //1.作为类的成员
    //2.作为函数的参数
    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;
        public MyFun2 fun3;

        public Action action;

        public delegate void MyFun4();

        #region 知识点五：委托变量可以存储多个函数(多播委托)
        public void TestFun(MyFun fun,MyFun2 fun2)
        {
            //先处理一些别的逻辑 当这些逻辑处理完了 再执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //fun();
            //fun2(i);
            this.fun = fun;
            this.fun2 = fun2;
        }
        #region 增
        public void AddFun(MyFun fun,MyFun2 fun2)
        {
            //this.fun = thia.fun + fun;
            this.fun += fun;
            this.fun2 += fun2;
        }
        #endregion
        #region 删
        public void RemoveFun(MyFun fun, MyFun2 fun2)
        {
            //this.fun = thia.fun - fun;
            this.fun -= fun;
            this.fun2 -= fun2;
        }
        #endregion
        #endregion
    }

    #endregion

    #region 知识点七：系统定义好的委托
    //定义：
    //委托是一种类型，它定义了方法的类型，使得这些方法可以被当作对象传递。
    //委托可以持有对方法的引用，允许将方法作为参数传递给其他方法，或者将方法赋值给其他变量。

    //接口是一种契约，它定义了一组方法、属性、事件和索引器，但不提供实现。
    //接口可以被类实现（implement），类必须提供接口中所有成员的具体实现。

    //用途：
    //委托常用于事件处理、回调函数、LINQ查询、泛型编程、策略模式。
    //它们使得方法可以像对象一样被存储和传递。

    //接口用于定义类必须遵守的契约，常用于设计模式、依赖注入、多态、版本控制和扩展。
    //它们提供了一种方式，使得不同的类可以有相同的操作方式。

    //灵活性：
    //委托可以引用返回特定返回类型的方法，并接受特定参数。
    //可以同时关联多个方法到同一个委托实例上，通过调用委托可以依次执行这些方法。

    //接口可以包含多个成员，并且可以被多个接口继承。
    //一个类可以实现多个接口，但只能继承一个类。

    //语法：
    //委托定义和使用方法定义类似，但使用delegate关键字。
    //委托定义和使用方法定义类似，但使用delegate关键字。
    #endregion

    #region 知识点八：Predicate
    //Predicate<T> 是一个专门的委托，用于表示一个返回布尔值的函数，通常用来表示条件判断。
    //Predicate 基本语法
    public delegate bool Predicate<in T>(T obj);  //T 是输入参数的类型。返回值为 bool。

    //Predicate 委托 是返回bool型的泛型委托
    //Predicate<int>委托 表示传入参数为int 返回bool的委托
    //Predicate 委托 有且只有一个参数，返回值固定为bool
    #endregion

    internal class Program
    {    
        /// <summary>
        /// 判断字符串是否全部为大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("委托与事件_委托");
            //专门用来装函数的 容器
            //装载的函数返回值类型和参数应与委托一致
            //用 = 赋值 为单播委托
            MyFun f = new MyFun(Fun);
            f.Invoke();  //调用

            MyFun f2 = Fun;
            f2();  //调用

            MyFun2 f3 = Fun2;
            f3.Invoke(1);
            f3(1);

            Test test = new Test();
            test.TestFun(Fun, Fun2);
            test.fun();
            test.fun2(1);

            Console.WriteLine("*******如何用委托存储多个函数*******");
            //如何用委托存储多个函数
            // 使用+=或-+ 为多播委托
            MyFun ff = Fun;
            //MyFun fff += Fun;  报错，一开始不能+=
            MyFun fff = null;  //先赋值，才能+=
            fff += Fun;
            ff += Fun;
            //ff = ff + Fun3;  标准
            ff();  //按添加的顺序执行
            ff -= Fun;  //多减 不会报错 无非不处理而已
            ff();
            //清空容器
            ff = null;
            if (ff != null)
            {
                ff();
            }
            else { Console.WriteLine("ff为空"); }
            ff?.Invoke();

            Console.WriteLine("*******增*******");
            test.AddFun(Fun, Fun2);
            test.fun();
            test.fun2(2);

            Console.WriteLine("*******删*******");
            test.RemoveFun(Fun, Fun2);
            test.fun();
            test.fun2(2);

            #region 知识点六：系统定义好的委托
            //using System;
            //无参无返回值委托
            Action action1 = Fun; 
            action1 += Fun3;
            action1?.Invoke();

            //泛型委托
            Func<int> funInt1 = Fun5;
            Func<String> funString = Fun4; 
            Func<int> funInt = Fun5;

            //有
            //可以传N个参数（1~16个）
            Action<int,string,bool> action2 = Fun6;

            //可以传N个参数（1~16个） 并且有返回值
            Func<int, int> func = Fun7;

            //Action委托与Func委托区别
            //Action委托：无返回值，无参，可以有多个方法
            //Func委托：有返回值，无参，可以有多个方法

            //Predicate委托：返回bool型的泛型委托，可以有多个方法
            #endregion

            #region 知识点九：Predicate 用法示例
            ///检查是否为偶数
            Predicate<int> isEven = x => x % 2 == 0;
            Console.WriteLine(isEven(4)); // 输出 True
            Console.WriteLine(isEven(5)); // 输出 False

            //结合 List 使用
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var evenNumbers = numbers.FindAll(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", evenNumbers)); // 输出 2, 4

            //与其他委托类型相同，Predicate 委托也可以与任何方法，匿名方法 或 lambda表达式一起使用。
            // 委托与任何方法
            Predicate<string> isUpper = IsUpperCase;
            bool result = isUpper("hello world!!");
            Console.WriteLine(result);

            // 委托与匿名方法
            isUpper = delegate (string s) { return s.Equals(s.ToUpper()); };
            result = isUpper("hello world!!");
            Console.WriteLine(result);

            // 委托与 lambda 表达式
            isUpper = s => s.Equals(s.ToUpper());
            result = isUpper("hello world!!");
            Console.WriteLine(result);
            #endregion
        }
        static void Fun()
        {
            Console.WriteLine("123");
        }
        static void Fun2(int value)
        {
            Console.WriteLine(value + "456");
        }
        static void Fun3()
        {
            Console.WriteLine("789");
        }
        static string Fun4()
        {
            return "";
        }
        static int Fun5()
        {
            return 1;
        }
        static void Fun6(int value1,string value2,bool value3)
        {
            Console.WriteLine(value1 + value2 + value3);
        }
        static int Fun7(int value)
        {
            return 1;
        }
    }
}
