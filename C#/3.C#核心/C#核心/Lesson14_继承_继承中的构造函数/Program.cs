namespace Lesson14_继承_继承中的构造函数
{
    #region 知识回顾
    //构造函数
    //实例化对象时调用的函数
    //主要用来初始化成员变量
    //每个类 都会有一个默认的无参构造函数

    //语法
    // 访问修饰符 类名()
    // {
    // }
    //不写返回值
    //函数名和类名相同
    //访问修饰符根据需求而定，一般为public
    //构造函数可以重载
    //可以用this语法重用代码

    //注意
    //有参构造会顶掉默认的无参构造
    //如想保留无参构造需重载出来 

    class Test
    {
        public int testI;
        public string testStr;
        public Test()
        {

        }

        public Test(int i)
        {
            this.testI = i;
        }

        public Test(int i, string str) : this(i)
        {
            this.testStr = str;
        }
    }
    #endregion

    #region 知识点一：继承中的构造函数 基本概念
    //特点
    //当申明一个子类对象时
    //先执行父类的构造函数
    //再执行子类的构造函数

    //注意:
    //1.父类的无参构造 很重要
    //2.子类可以通过base关键字 代表父类 调用父类构造

    #endregion

    #region 知识点二：继承中的构造函数的执行顺序
    //父类的父类的构造一>。。。一>父类构造一>。。。一>子类构造

    class GameObject
    {
        public GameObject()
        {
            Console.WriteLine("GameObject的构造函数");
        }
    }
    class Player : GameObject
    {
        public Player()
        {
            Console.WriteLine("Player的构造函数");
        }
    }
    class MainPlayer : Player
    {
        public MainPlayer()
        {
            Console.WriteLine("MainPlayer的构造函数");
        }
    }
    #endregion

    #region 知识点三：父类的无参构造函数重要
    //子类实例化时 默认自动调用的 是父类的无参构造 所以如果父类无参构造被顶掉 会报错
    class Father
    {
        public Father()
        {

        }

        int a;
        public Father(int a)
        {
            this.a = a;
            Console.WriteLine("Father构造");
        }

        public virtual void Say()
        {
            Console.WriteLine("Father说话");
        }
    }

    class Son : Father
    {

        #region 知识点四：通过base调用指定父类构造
        //base、this 属于 C# 的访问关键字。

        //base 用于从派生类中访问基类的成员：
        //调用基类上已被其他方法重写的方法。
        //指定创建派生类实例时应调用的基类构造函数。
        //基类访问只能在构造函数、实例方法或实例属性访问器中进行。
        //注：从静态方法中使用 base 关键字是错误的。另base 主要用于面向对象开发的多态。

        //this 关键字指代类的当前实例，还可用作扩展方法的第一个参数的修饰符。
        //1、限定被类似名称隐藏的成员；
        //2、将对象作为参数传递到其他方法；
        //3、声明索引器。
        //注：静态成员函数，因为它们存在于类级别且不属于对象，不具有 this 指针。 在静态方法中引用 this 是错误的。

        //通过base调用指定父类构造
        public Son(int i) : base(i)
        {
            Console.WriteLine("Son一个参数的构造");
        }

        //重载构造函数 调用父类构造 再执行自己的构造
        public Son(int i,string str) : this(i)
        {
            Console.WriteLine("Son两个参数的构造");
        }

        public override void Say()
        {
            base.Say();   //调用父类方法
            Console.WriteLine("Son说话");
        }
        #endregion
    }
    class son1 : Father
    {
        public son1(int a) : base(a)
        {

        }
    }
    
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("继承中的构造函数");

            MainPlayer mainPlayer = new MainPlayer();

            Son s = new Son(1, "123");
        }
    }
}
