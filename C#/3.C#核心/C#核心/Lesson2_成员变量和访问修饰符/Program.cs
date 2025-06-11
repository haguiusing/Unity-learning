using System.Security.Cryptography.X509Certificates;

namespace Lesson2_成员变量和访问修饰符
{
    #region 知识回顾
    //class Person
    //{
    //    //特征——成员变量
    //    //行为——成员方法
    //    //保护特征——成员属性

    //    //构造函数和析构函数
    //    //索引器
    //    //运算符重载
    //    //静态成员

    //    static void Main(string[] args)
    //    {
    //        //类名 变量名；   (没有分配堆内存)
    //        Person p;
    //        //类名 变量名 = null；	 (没有分配堆内存)
    //        Person p2 = null;
    //        //类名 变量名 = new 类名；	(在堆中新开了个房间)
    //        Person p3 = new Person();
    //    }
    //}
    #endregion

    #region 知识点一：成员变量
    //基本规则
    //1.申明在类语句块中
    //2.用来描述对象的特征
    //3.可以是任意变量类型
    //4.数量不做限制
    //5.是否赋值根据需求来定

    enum E_SexType
    {
        Man,
        Woman,
    }
    struct Position { }
    class Pet { }
    class Person
    {
        //特征——成员变量
        //姓名
        public string name;
        //年龄
        public int age;
        //性别
        public E_SexType sex;
        //女朋友
        public Person gridFriend;
        //如果要声明一个和自己相同类型的成员变量时，不能对他进行实例化（会死循环！！）
        //class Person
        //{
        //Person boy = new Person();
        //}
        //朋友
        public Person[] boyFriend;
        //位置
        public Position position;
        //宠物
        public Pet pet;


        //行为——成员方法
        //保护特征——成员属性

        //构造函数和析构函数
        //索引器
        //运算符重载
        //静态成员
    }
    #endregion

    #region 知识点二：访问修饰符
    //public:：公开的，所有对象都能访问和使用；
    //internal：内部访问，同一个程序集的类可以访问；
    //private：私有的，只有自己内部才能访问和使用，变量前不写默认为该状态；
    //protected:只有自己内部和子类才能访问和使用，继承的时候用到；
    //protected internal：受保护的内部访问，限于当前程序集或派生自包含类的类型。

    //internal和protected的并集，符合任意一条都可以访问。
    //跨程序集继承：在某些情况下，你可能有一个基类库，它定义了一些受保护的成员，
    //这些成员应该只能被同一程序集中的派生类访问。如果这些派生类位于不同的程序集中，
    //使用 protected internal 可以确保这些成员仍然可以被访问。

    //范围比较：
    //private < internal < protected < protected internal < public
    #endregion

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("成员变量和访问修饰符");

            Person p = new Person();
            p.name = "fghf";
            p.age = 10;

            #region 知识点三：成员变量的使用和初始值
            //默认的初始值，对值类型来说都是0（bool为false），引用类型来说都是null
            //default(变量);   //可以得到一个变量的默认值
            Console.WriteLine(default(int));
            #endregion

            #region 知识点四：

            #endregion
        }
    }
}
