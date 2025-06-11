using System;

namespace Lesson5_值与引用类型
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("值与引用类型");

            #region 知识点一：变量类型的复习
            //1.有符号的整形变量
            sbyte sb = 1;
            int i = 2;
            short s = 3;
            long l = 4;

            //2.无符号的整形变量
            byte by = 1;
            uint ui = 2;
            ushort us = 3;
            ulong ul = 4;

            //3.浮点数(小数)
            float f = 1.01234567890f;
            double d = 0.12345678901234567890123456789;
            decimal de = 0.123456789012345678901234567890m;

            //4.特殊类型
            bool bo1 = true;
            bool bo2 = false;
            char c = '唐';
            string str = "的骄傲了肯定就发生123123sdafjkasdkfiaskldifAKKSAJD";

            // 复杂数据类型
            // enum 枚举
            // 数组(一维，二维，交错)

            //把以上 学过的 变量类型 分成 值类型和引用类型

            //引用类型: string|字符串，object|对象，array|数组，class|类，
            //          delegate|委托，interface|接口，dynamic|动态

            //值类型:有/无符号整型，浮点型，字符型，布尔型，其它、结构体、枚举

            //其他类型：
            //指针类型（在不安全代码块中使用）:unsafe 关键字，指针，指针数组，指针引用

            //可空类型：任何值类型都可以声明为可空类型，例如 int? 表示可以存储 int 类型的值或者 null。

            //元组类型（C# 7.0及以后版本）：允许将多个值打包成一个单一的值，例如(int, string)。

            //记录类型（C# 9.0及以后版本）：提供了一种更简洁的方式来定义只包含数据的类。
            #endregion

            #region 知识点二：值类型与引用类型的区别

            #region 1.使用上的区别
            //值类型
            int a = 10;
            //引用类型
            int[] arr = new int[] { 1, 2, 3, 4 };

            //申明了一个b让其等于之前的a
            int b = a;
            //申明了一个arr2让其等于之前的arr
            int[] arr2 = arr; Console.WriteLine("a=(e]. b=(1]", a, b);
            Console.WriteLine("arr[e] = (e].arr2[e] = (1]", arr[0], arr2[0]);

            b = 20;
            arr2[0] = 5; 
            Console.WriteLine("修改了b和arr2[0]之后");
            Console.WriteLine("a=(e].b=(1}", a, b);
            Console.WriteLine("arr[e] = (e], arr2[e] = (1]", arr[0],arr2[0]);

            // 值类型 在相互赋值时 把内容拷贝给了对方 它变我不变
            // 引用类型的相互赋值 是 让两者指向同一个值（把指针指向同一内存地址） 它变我也变

            #endregion

            #region 2.为何有以上的区别
            //是由于 值类型 和 引用类型 存储的区域不同

            //值类型储存在 栈空间 —— 系统分配，自动回收，小而快
            //引用类型储存在 堆空间 ——手动申请和释放，大而慢

            //new实例化
            //通过关键字new 可以开一个新内存地址（在堆中新开一个房间）
            //这时候由于他们使用的不是同一个内存地址，自然赋值就不会牵扯到之前的数据

            //值类型
            int a1 = 10;
            //引用类型
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };

            //声明了一个b与其相等
            int b1 = a1;
            //声明了一个array2让其等于之前的array
            int[] array2 = array1;
            //打印结果
            //a=10 b=10
            //array=1,2,3,4,5  array2=1,2,3,4,5

            b1 = 20;
            array2[0] = 5;
            //打印结果
            //a=10 b=20
            //array= 5,2,3,4,5  array2= 5,2,3,4,5
            //由于引用类型 指向的内存地址是同一个所以相同

            array2 = new int[] { 6, 7, 8, 9 };
            //打印结果
            //array= 5,4,3,2,1  array2= 6,7,8,9
            //array2用new新开了一个内存地址 所以不会牵扯到之前的array
            #endregion

            #endregion

        }
    }
}