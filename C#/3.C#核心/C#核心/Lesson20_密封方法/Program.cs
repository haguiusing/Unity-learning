
namespace Lesson20_密封方法
{
    #region 知识点一：密封方法基本概念
    //密封类
    //用 sealed 修饰的类
    //让类不再能被继承

    //用密封关键字sealed 修饰的重写函数
    //作用: 让虚方法或者抽象方法不能再被重写
    //特点: 和override一同出现
    #endregion

    #region 知识点二：实例
    abstract class Animal
    {
        public string name;
        public abstract void Eat();
        public virtual void Speak()
        {
            Console.WriteLine("叫");
        }
    }
    class Person : Animal
    {
        public sealed override void Eat()
        {
            
        }
        public override void Speak()
        {
            base.Speak();
        }
    }
    class WhitePerson : Person
    {
        //public override void Eat()
        //{

        //}
        public override void Speak()
        {
            base.Speak();
        }
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("密封方法");
        }
    }
}
