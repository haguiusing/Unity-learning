namespace Indexer索引器
{
    public class IntIndexTest
    {
        int[] arr = new int[10];
        public int[] arr1 = new int[10];
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int this[int index,bool flag]
        {
            get => flag ? arr[index] : arr1[index];
            set { arr[index] = value; }
        }
    }

    public class GenericIndexTest<T>
    {
        T[] arr = new T[10];
        public T this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
    }

    public  class IndexedWeek
    {
        string[] weekArr =
        {
            "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
        };

        public string this[int index]
        {
            get { return weekArr[index]; }
            set { weekArr[index] = value; }
        }

        public int this[string day]
        {
            get{ return Array.IndexOf(weekArr, day); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indexer索引器");

            #region 知识点一：索引器(Indexer)的定义
            //索引器(Indexer)是C#引入的一个新型的类成员，它使得类中的对象可以像数组那样方便、直观的被引用。
            //索引器非常类似于属性，但索引器可以有参数列表，且只能作用在实例对象上，而不能在类上直接作用。
            //定义了索引器的类可以让您像访问数组一样的使用 [ ] 运算符访问类的成员。
            //（当然高级的应用还有很多，比如说可以把数组通过索引器映射出去等等）

            //语法
            //访问修饰符 返回类型 this[参数列表] { get; set; }

            //索引器（Indexer）的用途
            //索引器的行为的声明在某种程度上类似于属性（property）。就像属性（property），
            //您可使用 get 和 set 访问器来定义索引器。但是，属性返回或设置一个特定的数据成员，
            //而索引器返回或设置对象实例的一个特定值。换句话说，它把实例数据分为更小的部分，
            //并索引每个部分，获取或设置每个部分。

            //定义一个属性（property）包括提供属性名称。索引器定义的时候不带有名称，但带有 this 关键字，它指向对象实例。

            //索引器的使用
            var intIndexTest = new IntIndexTest();
            intIndexTest[0] = 11;
            Console.WriteLine(intIndexTest[0]); //输出11
            intIndexTest.arr1[0] = 10;
            Console.WriteLine(intIndexTest.arr1[0]); //输出10
            #endregion

            #region 知识点二：泛型索引器(Generic Indexer)的定义
            //泛型索引器(Generic Indexer)是C# 2.0引入的新特性，它可以让您定义具有不同类型参数的索引器。
            //泛型索引器可以让您定义具有不同类型参数的索引器，从而可以处理不同类型的数据。

            GenericIndexTest<int> intGenericIndexTest = new GenericIndexTest<int>();
            intGenericIndexTest[0] = 11;
            Console.WriteLine(intGenericIndexTest[0]); //输出11

            IndexedWeek indexedWeek = new IndexedWeek();
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(indexedWeek[i]);
            }
            #endregion

            #region 知识点三：重载索引器（Indexer）
            //索引器（Indexer）可被重载。索引器声明的时候也可带有多个参数，且每个参数可以是不同的类型。
            //没有必要让索引器必须是整型的。C# 允许索引器可以是其他类型，例如，字符串类型。
            Console.WriteLine(indexedWeek["Monday"]); //输出0
            Console.WriteLine(indexedWeek[6]); //输出"Sunday"


            //多形参索引器
            //索引器可以有多个参数，每个参数可以是不同的类型。例如，可以定义一个具有两个参数的索引器，
            //第一个参数是字符串类型，第二个参数是整数类型。
            intIndexTest[1, true] = 10;
            #endregion
        }
    }
}
