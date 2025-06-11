namespace Lesson17_多态_vob
{
    #region 知识点一：多态的概念
    //多态按字面的意思就是“多种状态”
    //让继承同一父类的子类们在执行相同方法时有不同的表现（状态）
    //多态（Polymorphism）与重写（Overriding）有关，而不是与重载（Overloading）有关。

    //主要目的
    //同一父类的对象 执行相同行为（方法）有不同的表现
    //解决的问题
    //让同一个对象有唯一行为的特征
    #endregion

    #region 知识点二：解决的问题
    class Father
    {
        public void SpeakName()
        {
            Console.WriteLine("Father的方法");
        }
    }
    class Son : Father
    {
        public new void SpeakName()
        {
            Console.WriteLine("Son的方法");
        }
    }
    #endregion

    #region 知识点三：多态的实现
     //我们目前已经学过的多态
     //译时多态一函数重载，开始就写好的

     //我们将学习的:
     //运行时多态（vob、抽象函数、接口）
     //我们今天学习vob
     //v:virtual（虚函数）
     //o:override(重写）
     //b：base（父类）


    class GameObject
    {
        public string name;
        public GameObject(String name)
        {
            this.name = name;
        }
        //虚函数 virtual  可以被子类重写
        public virtual void Atk()
        {
            Console.WriteLine("游戏对象发动攻击");
        }
    }
    class Player : GameObject
    {
        public Player(String name):base(name)
        {

        }
        //重写虚函数
        public override void Atk()
        {
            //base可以保留父类的方法
            //base.Atk();
            Console.WriteLine("玩家对象发动攻击");
        }
    }
    class Monster : GameObject
    {
        public Monster(String name) : base(name)
        {

        }
        //重写
        public override void Atk()
        {
            //base可以保留父类的方法
            //base.Atk();
            Console.WriteLine("怪物对象进行攻击");
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("多态_vob");

            #region 解决的问题
            Father f = new Son();
            f.SpeakName();  //执行Father的方法

            (f as Son).SpeakName();  //执行Son的方法
            #endregion

            #region 多态的使用
            GameObject p = new Player("玩家");
            p.Atk();
            (p as Player).Atk();

            GameObject m = new Monster("怪物");
            m.Atk();
            #endregion
        }
    }

    //虚函数的原理
    //方法表（VTable）
    //在 C# 中，虚函数的实现依赖于 方法表（Virtual Method Table, VTable）。每个类都有一个方法表，其中存储了虚函数的地址。
    //
    //基类的虚函数在方法表中有自己的地址。
    //
    //如果子类重写了虚函数，方法表中的地址会被替换为子类方法的地址。
    //
    //运行时多态
    //当通过基类引用调用虚函数时，运行时会根据对象的实际类型查找方法表，并调用正确的方法。这就是 动态绑定（Dynamic Binding）。
}
