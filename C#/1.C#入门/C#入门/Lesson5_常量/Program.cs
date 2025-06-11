using System;

namespace Lesson5_常量
{
    class Program
    {
        static readonly int i3 = 30;

        #region 知识点一:常量的声明
        //关键字 const
        //固定写法:
        //const 变量类型 变量名 = 初始值;
        //变量的申明
        int i = 10;
        //常量的申明
        const int i2 = 20;

		//const是编译时常量，在编译时确定该值；readonly是运行时常量，可以延迟到构造函数初始化,在运行时确定该值。
		//const默认是静态的；而readonly如果设置成静态需要显示声明.

		const int A = B * 10;
		const int B = 10;
		static readonly int C = D * 10;
		static readonly int D = 10;
		#endregion
		static void Main(string[] args)
        {
            Console.WriteLine("常量");

            Console.WriteLine(i3);
            //i3 = 40; //错误，常量不能被修改

            #region 知识点二:常量的特点
            //1.必须初始化
            //2.不能被修改

            //变量申明可以不初始化
            string name;
            //之后可以来修改
            name = "123";
            name = "345";

            //作用: 申明一些常用不变的变量

            Console.WriteLine(A + " " + B);   //100 10
            Console.WriteLine(C + " " + D);   //0  10

            new Test();
            Console.WriteLine(Test.i + " " + Test.j);   //10 20
            #endregion

        }
    }

    public class Test
    {
        public static readonly int i = 0;
		public static readonly int j;

        static Test()
        {
            i = 10;
            j = 20;
        }

        public void TestMethod()
        {
            //i = 10;
        }
    }
}