namespace Lesson5_泛型_泛型
{
    internal class Program
    {
        #region 知识点一：泛型是什么
        //泛型实现了类型参数化，达到代码重用目的
        //通过类型参数化来实现同一份代码上操作多种类型

        //泛型相当于类型占位符
        //定义类或方法时使用替代符代表变量类型
        //当真正使用类或者方法时再具体指定类型
        #endregion

        #region 知识点二：泛型分类
        //泛型类和泛型接口
        //基本语法:
        //class 类名<泛型占位字母>
        //interface 接口名<泛型占位字母>

        //泛型函数
        //基本语法: 函数名<泛型占位字母>(参数列表)

        //注意: 泛型占位字母可以有多个，用逗号分开
        #endregion

        #region 知识点三：泛型类和泛型接口
        //泛型类提供不同的类型参数来创建该类的不同实例，
        //这些实例在逻辑上可以视为“重名”的不同版本，
        //但实际上它们是不同的类型。
        class TestClass<T>
        {
            public T Value { get; set; }
        }
        class TestClass2<T1, T2, K, M, Value>
        {
            public T1 value1;
            public T2 value2;
            public K key;
            public M map;
            public Value value;
        }

        interface ITestInterface<T>
        {
            public T Value { get; set; }
        }
        class Test : ITestInterface<int>
        {
            public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
        #endregion

        #region 知识点四：泛型方法
        //1.普通类中的泛型方法
        class Test2
        {
            public void TestFun<T>(T value)
            {
                Console.WriteLine(value);
            }
            public void TestFun<T>()
            {
                //用泛型类型 在里面做逻辑处理
                T t = default(T);
                //方法内部创建了一个类型为T的变量t，并将其初始化为T类型的默认值。
                //default(T)用于获取类型T的默认值，
                //例如，对于引用类型是null，对于数值类型是0。
            }
            public T TestFun<T>(string v)
            {
                return default(T);
                //这个方法演示了如何在泛型方法中使用非泛型参数。

            }
            public void TestFun<T,K,M>(T t,K k,M m)
            {
                //这个方法展示了如何在同一个方法中使用多个泛型类型参数
            }
        }

        //2.泛型类中的泛型方法
        class Test2<T>
        {
            public T value;

            public void TestFun<K>(K k)  //泛型占位字母不能与更高位的泛型占位字母同名
            {
                Console.WriteLine(k);
            }

            public void TestFun(T t)
            {
                //这个不叫泛型方法 因为 T是泛型类申明的时候 就指定 在使用这个函数的时候
                //我们不能再去动态的变化
            }
        }
        #endregion

        #region 知识点五：泛型的作用

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("泛型");
            
            //申明以后t的类型无法改变
            TestClass<int> t= new TestClass<int>();
            t.Value = 1;
            Console.WriteLine(t.Value);

            TestClass<string> t2 = new TestClass<string>();
            t2.Value = "123";
            Console.WriteLine(t2.Value);

            TestClass2<int, string, float, double, TestClass<int>> t3 = new TestClass2<int, string, float, double, TestClass<int>>();

            Test2 test2 = new Test2();
            test2.TestFun<string>("456");

            Console.WriteLine("*************");
            Test2<int> test21 = new Test2<int>();
            test21.TestFun(10);
            test21.TestFun("123");  //注销86~89行后，这行代码在编译时会报错
            //因为 TestFun(T t) 方法期望一个 int 类型的参数，但传入的是一个 string
            test21.TestFun<string>("456");  //<string>可省略
            test21.TestFun<float>(1.2f);
        }
    }
}
