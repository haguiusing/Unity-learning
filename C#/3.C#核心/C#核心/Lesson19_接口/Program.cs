
namespace Lesson19_接口
{
    #region 知识点一：接口的概念
    //接口是行为的抽象规范
    //它也是一种自定义类型
    //关键字：interface
    
    //接口申明的规范
    //1.不包含成员变量
    //2.只包含方法、属性、索引器、事件
    //3.成员不能被实现
    //4.成员可以不用写访问修饰符，不能是私有的
    //5.接口不能继承类，但是可以继承另一个接口
    
    //接口的使用规范
    //1.类可以继承多个接口
    //2.类继承接口后，必须实现接口中所有成员
    
    //特点：
    //1.它和类的申明类似
    //2.接口是用来继承的
    //3.接口不能被实例化，但是可以作为容器存储对象
    #endregion

    #region 知识点二：接口的申明
    //接口关键字：interface
    //语法：
    //interface 接口
    //{
    //}
    //一句话记忆：接口是抽象行为的“基类
    //接口命名规范:帕斯卡前面加个I

    interface Ifly
    {
        //如果使用protected,需要显示实现接口
        public void Fly();

        string Name { 
            get;
            set;
        }

        int this[int index]
        {
            get;
            set;
        }

        event Action doSomhting;
    }
    #endregion

    #region 知识点三：接口的使用
    //接口用来继承
    class Animal { }

    class Person : Animal, Ifly
    {
        public int this[int index]
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        public string Name { get ; set; }

        public event Action doSomhting;

        public virtual void Fly()  //实现的接口函数，可以加v再在子类重写
        {
            
        }
    }

    //1.类可以继承1个类，n个接口
    //2.继承了接口后 必须实现其中的内容 并且必须是public的
    //3.实现的接口函数，可以加v再在子类重写
    //4.接口也遵循里氏替换原则
    #endregion

    #region 知识点四：接口可以继承接口
    //相当于行为合并
    //接口继承接口时 不需要实现
    //待类继承接口后 类去实现所有内容

    interface IWalk
    {
        void Walk();
    }
    interface IMove : Ifly, IWalk
    {

    }

    class Test : IMove
    {
        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action doSomhting;

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region 知识点五：显示实现的接口
    //当一个类继承两个接口
    //但是接口中存在着同名方法时
    //注意：显示实现接口时不能写访问修饰符

    interface IAtk
    {
        void Atk();
    }
    interface ISuperAtk
    {
        void Atk();
    }
    class Player : IAtk, ISuperAtk
    {
        void IAtk.Atk()
        {

        }
        void ISuperAtk.Atk()
        {

        }
        public void Atk()
        {

        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("接口");

            //接口也遵循里氏替换原则
            Ifly f = new Person();

            IMove im = new Test();
            Ifly ifly = new Test();
            IWalk iw = new Test();

            IAtk atk = new Player();
            ISuperAtk superAtk = new Player();
            atk.Atk();
            superAtk.Atk();

            Player p = new Player();
            (p as IAtk).Atk();
            (p as ISuperAtk).Atk();
            p.Atk();
        }
    }
}
