
namespace Lesson11_内部类和分布类
{
    #region 知识点一：内部类
    //概念
    //在一个类中再申明一个类

    //特点
    //使用时要用包裹者点出自己

    //作用
    //亲密关系的变现

    //注意
    //访问修饰符作用很大
    class Person
    {
        public int age;
        private string name;
        public Body body;

        public class Body
        {
            Arm leftArm;
            Arm rightAtm;

            //class Arm { }  默认私有
            public class Arm
            {

            }
        }
    }
    #endregion

    #region 知识点二：分部类
    //概念
    //把一个类分成几部分申明

    //关键字
    //partial

    //作用
    //分部描述一个类
    //增加程序的拓展性

    //注意
    //分部类可以写在多个脚本文件中
    //分部类的访问修饰符要一致
    //分部类中不能有重复成员

    partial class Student
    {
        public bool sex;
        public string name;
        partial void speak();   //方法申明
    }

    partial class Student
    {
        public int nmuber;

        partial void speak()
        {
            //方法实现
        }
        public void Speak(string str)
        {

        }
    }
    #endregion

    #region 知识点三：分部方法
    //概念
    //将方法的申明和实现分离
    //特点
    //1.不加访问修饰符 默认私有
    //2.只能在分部类中申明
    //3.返回值只能是void
    //4.可以有参数但不用 out关键字

    //局限性大，了解即可
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("内部类和分布类");
        }
        Person p = new Person();
        Person.Body body = new Person.Body();
        Person.Body.Arm Arm = new Person.Body.Arm();

        Student stu = new Student();

    }
}
