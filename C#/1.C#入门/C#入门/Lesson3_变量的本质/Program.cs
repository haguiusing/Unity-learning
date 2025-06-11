using System;

namespace Lesson3_变量本质
{
    class Program
    {
        static bool b;
        static void Main(string[] args)
        {
            Console.WriteLine("变量本质");

            #region 变量类型回顾
            // 有符号
            //sbyte  (-128~127)
            //int  (-21亿多~21亿多)
            //short  (-3万多~3万多)
            //long  (-9百万兆多~9百万兆多)
            
            // 无符号
            //byte  (0~255)
            //uint  (0~42亿多)
            //ushort  (0~6万多)
            //ulong  (0~18百万兆多)

            // 浮点数
            //float  (7~8位有效数字)
            //double  (15~17位有效数字)
            //decimal  (27~28位有效数字)

            // 特殊
            //boo1  (true和false)
            //char  (一个字符)
            //string  (一串字符)
            #endregion

            #region 知识点一 变量的存储空间(内存中)
            // 1byte = 8bit
            // 1KB = 1024byte
            // 1MB = 1024KB
            // 1GB = 1024MB
            // 1TB = 1024GB

            // 通过sizeof方法 可以获取变量类型所占的内存空间 (单位: 字节)
            //有符号
            int sbyteSize = sizeof(sbyte);
            Console.WriteLine("sbyte 所占的字节数为: "+ sbyteSize);  // 1
            int intSize = sizeof(int);
            Console.WriteLine("int 所占的字节数为:"+intSize);  // 4
            int shortSize = sizeof(short);
            Console.WriteLine("short 所占的字节数为:" + shortSize);  // 2
            int longSize = sizeof(long);
            Console.WriteLine("long 所占的字节数为:" +longSize);  // 8
            Console.WriteLine("******************************");

            //无符号
            int byteSize = sizeof(byte);
            Console.WriteLine("byte 所占的字节数为:" + byteSize);  // 1
            int uintSize = sizeof(uint);
            Console.WriteLine("uint 所占的字节数为:" + uintSize);  // 4
            int ushortSize = sizeof(ushort);
            Console.WriteLine("ushort 所占的字节数为:" + ushortSize);   // 2
            int ulongSize = sizeof(ulong);
            Console.WriteLine("ulong 所占的字节数为:" + ulongSize);  // 8
            Console.WriteLine("******************************");

            //浮点数
            int floatSize = sizeof(float); 
            Console.WriteLine("float 所占的字节数为:" + floatSize);  // 4
            int doubleSize = sizeof(double);
            Console.WriteLine("double 所占的字节数为:" +doubleSize);   // 8
            int decimalSize = sizeof(decimal);
            Console.WriteLine("decimal 所占的字节数为:" + decimalSize);  // 16
            Console.WriteLine("******************************");

            //特殊类型
            int boolsize = sizeof(bool); 

            Console.WriteLine(b);
            Console.WriteLine("bool 所占的字节数为:" + boolsize);  // 1
            int charSize = sizeof(char);
            Console.WriteLine("char 所占的字节数为: "+ charSize);  // 2
            //sizeof是不能够得到string类型所占的内存大小的
            //因为字符串长度是可变的 不定
            //int stringSize = sizeef(string);

            #endregion

            #region 知识点二 变量的本质
            //变量的本质是2进制一>计算机中所有数据的本质都是二进制 是一堆0和1
            //为什么是2进制?
            //数据传递只能通过电信号，只有开和关两种状态。所以就用0和1来表示这两种状态
            //计算机中的存储单位最小为bit (位) ，他只能表示和1两个数字
            // 1bit 就是1个数 要不是要不是1
            // 为了方便数据表示
            // 出现一个叫byte(字节)的单位，它是由8个bit组成的存储单位.1
            // 所以我们一般说一个字节为8位
            // 1 byte = 8 bits

            // 2进制和10进制的对比
            // 2进制和10进制之间的相互转换
            #endregion
        }
    }
}