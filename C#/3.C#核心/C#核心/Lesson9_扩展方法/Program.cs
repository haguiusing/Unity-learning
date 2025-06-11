
namespace Lesson9_扩展方法
{
    #region 知识点一：扩展方法基本概念
    //概念
    //为现有非静态 变量类型 添加 新方法
    //作用
    //1.提升程序拓展性
    //2.不需要再对象中重新写方法
    //3.不需要继承来添加方法
    //4.为别人封装的类型写额外的方法
    //特点
    //1.一定是写在静态类中
    //2.一定是个静态函数
    //3.第一个参数为拓展目标
    //4.第一个参数用this修饰
    #endregion

    #region 知识点二：基本语法
    //访问修饰符 static 返回值 函数名（this 拓展类名 参数名，参数类型 参数名）

    #endregion

    #region 知识点三：实例
    static class Tools
    {
        //为int拓展了一个成员方法
        //成员方法 是需要实例化对象后 才 能使用的
        //value 代表 使用该方法的 实例化对象
        public static void SpeakValue(this int value)
        {
            //拓展的方法的逻辑
            Console.WriteLine("唐老狮为int拓展的方法" + value);
        }

        public static void SpeakstringInfo(this string str, string str2, string str3)
        {
            Console.WriteLine("唐老狮为string拓展的方法");
            Console.WriteLine("调用方法的对象"+ str);
            Console.WriteLine("传的都救"+ str2 + str3);
        }

        //代表调用该方法的 Test 类型的对象
        public static void Fun3(this Test value, int a)
        {
            Console.WriteLine("方法3");
        }
        //当扩展方法与原方法重名时，使用原方法
        //public static void Fun1(this Test value, int a)
        //{
        //    Console.WriteLine("方法3");
        //}
    }
    #endregion

    #region 知识点五：为自定义的类型扩展方法
    class Test
    {
        public int i = 10;
        public void Fun1()
        {
            Console.WriteLine("方法1");
        }

        public void Fun2()
        {
            Console.WriteLine("方法2");
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("扩展方法");
            #region 知识点四：使用
            int i = 10;
            i.SpeakValue();

            string str = "000";
            str.SpeakstringInfo("参数1", "参数2");

            Test t = new Test();
            t.Fun3(1);
            #endregion
        }
    }
}
