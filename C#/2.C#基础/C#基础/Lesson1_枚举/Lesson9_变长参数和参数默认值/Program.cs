namespace Lesson9_变长参数和参数默认值
{
    internal class Program
    {

        #region 知识点一：函数语法复习
        //    1       2       3               4
        // static 返回类型 函歌名(参数类型 参数名1，参数类型 参数名2，.......)
        //{
        //      函数的代码逻辑；
        //      函数的代码逻辑；
        //      函数的代码逻辑；
        //      ...............
        //      5
        //      return 返回值;(如果有返回类型才返回)
        //}

        //1.关于static 不是必须的 在没有学习类和结构体之前 都是必须写的

        //2-1.关于返回类型 引出一个新的关键字 void(表示没有返回值)
        //2-2.返回类型 可以写任意的变量类型 14种变量类型 + 复杂数据类型 (数组、枚举、结构体、类class)

        //3.关于的函数名 使用帕斯卡命名法命名 MyName(帕斯卡命名法)  myName(驼峰命名法）

        //4-1.参数不是必须的，可以有 0~n 个参数  参数的类型也是可以是任意类型的 14种变量类型 + 杂数据类型(数组、枚举、结构休、类e1ass)
        //    多个参数的时候 需要用 逗号隔开
        //4-2.参数名 驼峰命名法

        //5.当返回值类型不为void时 必须通过新的关键词 return返回对应类型的内容  （注意：即使是void也可以选择性使用return）
        #endregion

        #region 知识点二：变长参数关键词
        //举例 函数要计算 n个整数的和
        //static int Sum(int a, int b,.....)

        //变长参数关键字 params
        static int[] Sum(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return arr;
        }

        //params int[] 意味着可以传入n个int参数 n可以等于0 传入的参数会存在arr数组中
        // 注意:
        //1.params关键字后面必为数组
        //2.数组的类型可以是任意的类型
        //3.函数参数可以有 别的参数和 params关键字修饰的参数
        //4.函数参数中只能最多出现一个params关键字 并且一定是在最后一组参数 前面可以有n个其它参数
        //5.不能用ref或out修饰且不能手动给默认值

        //在函数参数中只能最多出现一个params关键字 且一定在最后一组参数
        static int Sum1(int a, int b, params int[] arr)
        {
            return 1;
        }
        #endregion

        #region 知识点三：参数默认值
        //有参数默认值的参数 一般称为可选参数
        //作用 当调用函数时可以不传入参数，不传就会使用默认值作为参数的值
        static void Speak(string str = "啊大大")
        {
            Console.WriteLine(str);
        }

        //注意:
        //1.支持多参数默认值 每个参数都可以有默认值
        //2.如果要混用 可选参数 必须写在 普通参数后面
        static void Speak2(string test,string name ="asd",string str = "啊大大")
        {
            Console.WriteLine(test);
            Console.WriteLine(name);
            Console.WriteLine(str);
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("变长参数和参数默认值");

            int[] intArr = Sum(1, 2, 3, 4);
            foreach (int i in intArr)
            {
                Console.WriteLine(i);
            }
            Sum1(1,2,3,4,5);

            Speak();
            Speak("是的是的");

            //Speak2();
            Speak2("sdad");
            Speak2("sd", "sdad");

            // 总结
            // 1 变长参数关键字 params
            // 作用: 可以传入n个同类型参数 n可以是0
            // 注意:
            // 1. params后面必须是数组 意味着只能是同一类型的可变参数
            // 2.变长参数只能有一个
            // 3.必须在所有参数最后写变长参数

            // 2 参数默认值(可选参数)
            // 作用: 可以给参数默认值 使用时可以不传参 不传用默认的 传了用传的
            // 注意:
            // 1.可选参数可以有多个
            // 2.正常参数比写在可选参数前面，可选参数只写在参数的后面
        }
    }
}