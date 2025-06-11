namespace Lesson16_密封类
{
    #region 知识点一：基本概念
    //密封类 是使用 sealed 密封关键字修饰的类
    //作用: 让类无法再被继承
    #endregion

    #region 知识点二：实例
    class Father
    {

    }

    sealed class Son : Father
    {

    }
    #endregion

    #region 知识点三：作用
    //在面向对象程序的设计中，密封类的主要作用就是不允许最底层子类被继承
    //可以保证程序的规范性、安全性
    //目前对于大家来说 可能用处不大
    //随着大家的成长，以后制作复杂系统或者程序框架时受体会到密封的作用
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("密封类");
        }
    }
}
