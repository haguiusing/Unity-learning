
namespace Lesson6_泛型_泛型约束
{
    #region 知识点一：什么是泛型约束
    //让泛型的类型有一定的限制
    //关键字: where
    //泛型约束一共有6种
    //1.值类型                               //where 泛型字母:struct
    //2.引用类型                             //where 泛型字母:class
    //3.存在无参公共构造函数                 //where 泛型字母:new () 
    //4.某个类本身或者其派生类               //where 泛型字母:类名
    //5.某个接口的派生类型                   //where 泛型字母:接口名
    //6.另一个泛型类型本身或者派生类型       //where 泛型字母:另一个泛型字母

    // where 泛型字母:(约束的类型)
    #endregion

    #region 知识点二：各泛型约束讲解
    #region 值类型
    class Test1<T> where T : struct
    {
        public T value;

        public void TestFun<K>(K v)where K : struct
        {
            Console.WriteLine(v);
        }
    }
    #endregion
    #region 引用类型
    class Test2<T> where T : class
    {
        public T value;

        public void TestFun<K>(K k) where K : class
        {
            Console.WriteLine($"{k}");
        }
    }
    #endregion
    #region 存在无参公共构造函数非抽象类型
    class Test3<T> where T : new()
    {
        public T value;

        public void TestFun<K>(K k) where K : class
        {
            Console.WriteLine($"{k}");
        }
    }
    class Test_1
    {

    }
    //有参构造函数会报错
    class Test_2
    {
        public Test_2(int i) { }
    }
    class Test_3
    {
        private Test_3(int i) { }
    }
    //抽象类型也会报错
    abstract class Test_4
    {
        
    }
    #endregion
    #region 某个类本身或者其派生类
    class Test4<T> where T : TestP1
    {
        public T value;

        public void TestFun<K>(K k) where K : TestP1
        {
            Console.WriteLine($"{k}");
        }
    }
    class TestP1
    {

    }
    class TestP2:TestP1
    {

    }
    #endregion
    #region 某个接口的派生类型
    interface IFly
    {

    }
    interface IMove:IFly
    {

    }
    class Test4 : IFly, IMove
    {

    }
    class Test5<T> where T : IFly
    {
        public T value;

        public void TestFun<K>(K k) where K : IFly
        {
            Console.WriteLine($"{k}");
        }
    }
    #endregion
    #region 另一个泛型类型本身或者派生类型
    class Test6<T,U> where T : U   //另一个泛型类型"U"应为T本身或者其派生类型
    {
        public T value;

        public void TestFun<K, V>(K k) where K : V
        {
            Console.WriteLine($"{k}");
        }
    }
    #endregion
    #endregion

    #region 知识点三：约束的组合使用
    //部分约束有包含关系组合不了
    //new()一般写最后，写前面有时报错
    class Tes7<T>where T : class, new()
    {

    }
    #endregion

    #region 知识点四：多个泛型有约束
    class Test8<T,K>where T: class, new() where K : struct
    {

    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型_泛型约束");

            Test1<int> test1 = new Test1<int>();
            test1.TestFun<float>(1.3f);

            Test2<Random> test2 = new Test2<Random>();
            test2.value = new Random();
            test2.TestFun<object>(new object ());

            Test3<Test_1> t3 = new Test3<Test_1>();
            //Test3<Test_2> t4 = new Test4<Test_2>();  //报错
            //Test3<Test_3> t5 = new Test3<Test_3>();
            //Test3<Test_4> t6 = new Test3<Test_4>();

            Test4<TestP1> t4 = new Test4<TestP1>();
            Test4<TestP2> t5 = new Test4<TestP2>();
            //Test4<Test1> t6 = new Test4<Test1>();
            //Test4<object> t7 = new Test4<object>();

            Test5<IFly> t6 =  new Test5<IFly> ();
            Test5<IMove> t7 = new Test5<IMove>();
            t6.value = new Test4();
            t7.value = new Test4();

            Test6<Test4,IFly> t8 = new Test6<Test4,IFly>();
            Test6<Test4, Test4> t9 = new Test6<Test4, Test4>();
            //Test6<Test4, Test3> t10 = new Test6<Test4, Test3>();
        }
    }
}
