using System;
using System.Runtime.InteropServices;

namespace 指针类型
{
    internal class Program
    {
        //在C#中，指针的使用通常被限制在不安全（unsafe）的代码块中，
        //这是为了防止潜在的内存安全问题。不安全代码允许直接访问内存地址，
        //这在某些高级编程场景中是必要的，比如与非托管代码交互或者进行底层的内存操作。

        //指针算术
        //在C#中，指针可以进行算术操作，如加法和减法。当你对指针进行加法操作时，你实际上是在移动指针的位置。
        //指针的增量取决于指针指向的数据类型的大小。
        //例如，如果指针指向一个 int 类型的数据，那么每次指针增加1，它就会移动4个字节（假设 int 是4个字节）。

        //解引用操作符
        //解引用操作符* 用于获取指针指向的内存位置的值。
        //如果你有一个指向某个变量的指针，使用解引用操作符可以读取或修改该变量的值。

        static unsafe void Main(string[] args)
        {
            // 示例1：基本指针操作
            int number = 10;
            int* p = &number; // 获取number的地址
            *p = 20; // 通过指针修改number的值
            Console.WriteLine(number); // 输出：20

            // 示例2：指针数组
            // 示例2-1：Array固定数组的位置
            //在 unsafe 代码块中使用 fixed 语句来固定托管数组的位置，这样就可以在固定的作用域内获取数组第一个元素的地址。
            int[] numbers = { 1, 2, 3, 4, 5 };
            fixed (int* pArray = numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    *(pArray + i) = i * i; // 通过指针访问并修改数组元素
                    Console.Write(*(pArray + i) + " "); // 使用指针访问数组元素
                }
            }
            Console.WriteLine();

            // 示例2-2：栈上分配内存
            int[] numbers_stack = { 1, 2, 3, 4, 5 };
            int* pArray_stack = stackalloc int[5] { 1, 2, 3, 4, 5 };
            // 使用stackalloc分配栈内存,pArray 是一个指向堆内存块第一个 int 的指针
            for (int i = 0; i < numbers_stack.Length; i++)
            {
                *(pArray_stack + i) = i * i; // 通过指针访问并修改数组元素
            }
            for (int i = 0; i < numbers_stack.Length; i++)
            {
                Console.Write(*(pArray_stack + i) + " "); // 输出：0 1 4 9 16
            }
            Console.WriteLine();

            // 示例2-3：堆上分配内存
            int[] numbers_heap = { 1, 2, 3, 4, 5 };
            IntPtr ptr = Marshal.AllocHGlobal(numbers_heap.Length * sizeof(int));
            int* pArray_heap = (int*)ptr;
            // 使用Marshal.AllocHGlobal分配堆内存
            for (int i = 0; i < numbers.Length; i++)
            {
                *(pArray_heap + i) = i * i; // 通过指针访问并修改数组元素
            }
            for (int i = 0; i < numbers_heap.Length; i++)
            {
                Console.Write(*(pArray_heap + i) + " "); // 输出：0 1 4 9 16
            }
            Marshal.FreeHGlobal(ptr);
            //不再需要时使用 Marshal.FreeHGlobal 释放这块内存
            Console.WriteLine();

            // 示例3：指针引用
            int number2 = 10;
            int* p2 = &number2;  // 获取number2的地址
            int** pp2 = &p2; // 获取指针p2的地址
            *(*pp2) = 30; // // 通过 pp2 找到 p2，然后通过 p2 找到 number，并将其设置为 30
            Console.WriteLine(number2); // 输出：30

            // 示例4：使用指针进行字符串操作
            string str = "Hello, World!";
            //IntPtr strPtr = Marshal.StringToHGlobalAnsi(str); //托管字符串转换为非托管的ANSI字符串
            IntPtr strPtr = Marshal.StringToHGlobalUni(str);  // 托管字符串转换为非托管的Unicode字符串
            char* pStr = (char*)strPtr;
            for (int i = 0; i < str.Length; i++)
            {
                *(pStr + i) = char.ToUpper(*(pStr + i)); // 通过指针将字符串转换为大写
            }
            Console.WriteLine(new string((char*)pStr)); // 输出：HELLO, WORLD!
            Marshal.FreeHGlobal(strPtr); // 释放分配的内存
        }
    }
}
