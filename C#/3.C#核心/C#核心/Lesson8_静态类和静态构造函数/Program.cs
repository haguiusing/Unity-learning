namespace Lesson8_静态类和静态构造函数
{
    #region 知识点一：静态类
    //概念
    //用static修饰的类

    //特点
    //只能包含静态成员
    //不能被实例化

    //作用
    //1.将常用的静态成员写在静态类中 方便使用
    //2.静态类不能较实例化，更能体
    //比如 Console就是一个静态类
    #endregion

    static class TestStatic
    {
        public static int testIndex = 0;
        
        public static void TestFun()
        {

        }

        public static int TestIndex
        {
            get;
            set;
        }
    }

    #region 知识点二：静态构造函数
    //概念
    // 在构造函数加上 static 修饰

    //特点
    //1.静态类和普通类都可以有
    //2.不能使用访问修饰符
    //3.不能有参数
    //4.只会在当类被首次引用时（例如，创建类的实例或访问静态成员）自动调用一次，因此不能使用this、base、typeof、nameof等关键字

    //作用
    //在静态构造函数中初始化 静态变量

    //使用
    //1.静态类中的静态构造函数

    static class StaticClass
    {
        public static int testInt0 = 100;
        public static int testInt1 = 100;

        static StaticClass()
        {
            Console.WriteLine("StaticClass类静态构造函数");
            testInt0 = 200;
            testInt1 = 200;
        }
    }

    //2.普通类中的静态构造函数
    class Test
    {
        public static int testInt = 200;
        static Test()
        {
            Console.WriteLine("Test类静态构造函数");
        }

        public Test()  //不是重载，new
        {
            Console.WriteLine("Test类普通构造函数");
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("静态类和静态构造函数");

            Console.WriteLine(StaticClass.testInt0);
            Console.WriteLine(StaticClass.testInt1);

            Console.WriteLine(Test.testInt);
            Test t1 = new Test();
            Test t2= new Test();
        }
    }
}
