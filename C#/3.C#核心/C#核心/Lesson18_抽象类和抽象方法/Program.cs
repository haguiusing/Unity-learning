
namespace Lesson18_抽象类和抽象方法
{
    #region 知识点一：抽象类
    //概念
    //被抽象关键字abstract修饰的类
    //特点：
    //1.不能被实例化的类
    //2.可以包含抽象方法
    //3.继承抽象类必须重写其抽象方法

    abstract class Thing
    {
        //抽象类中，封装的所有知识点都可以在其中书写
        public string name;

        //可以在抽象类中写抽象函数
    }
    class Water : Thing
    {

    }
    #endregion

    #region 知识点二：抽象方法
    //又叫 纯虚方法
    //用 abstract关健字修饰你的方法
    //特点:
    //1.只能在抽象类中申明
    //2.没有方法体
    //3.不能是私有的
    //4.继承后必须实现 用override重写

    abstract class Fruits
    {
        public string name;

        abstract public void Bad();  //抽象方法

        public virtual void Test()
        {
            //可以选择是否写逻辑
        }

        //虚方法（vritual）和纯虚方法（abstract）的区别
        //虚方法可以在抽象类和非抽象类中声明 纯虚方法只能在抽象类中声明
        //虚方法可以由子类选择性实现 纯虚方法必须实现重写。虚方法有方法体可实现逻辑
        //他们都可以被子类用override重写  可以多层重写 子子类重写子类重写父类
    }
    class Apple : Fruits
    {
        public override void Bad()
        {
            throw new NotImplementedException();
        }
    }
    class SuperApple : Apple
    {
        public override void Bad()
        {
            base.Bad();
        }
        public override void Test()
        {
            base.Test();
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("抽象类和抽象方法");

            //抽象类无法实例化
            //Thing thing = new Thing();
            //但是 可以遵循里氏替换原则 用父类容器装子类
            Thing t = new Water();
        }
    }
}
