using System;
using System.Text;

namespace Lesson15_随机数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("随机数");

            Random random1 = new Random();
            Random random2 = new Random(Guid.NewGuid().GetHashCode());
            //使用GUID的哈希码作为种子确保每次运行程序时都会得到不同的随机数序列。

            Console.WriteLine("random1");

            int num1 = random1.Next(10);
            Console.WriteLine (num1);
            int num2 = random1.Next(0, 10);
            Console.WriteLine(num2);

            double dob1 = random1.NextDouble();
            Console.WriteLine(dob1);
            double dob2 = random1.NextDouble();
            Console.WriteLine($"{dob2,0:N3}");
            //,0:N3:格式说明符，用来格式化dob2的值。
                //,0: 这部分表示数字的千位分隔符。0表示始终使用千位分隔符，但实际上在大多数地区并不会显示。如果省略这个部分，则数字不会有千位分隔符。
                //:N3: 这部分表示将数字格式化为带有三位小数的标准数字格式。例如，如果dob2是1234567.89，则输出会是1,234,567.890。

            Console.WriteLine("***********");
            Console.WriteLine("random2");

            int num3 = random2.Next(10);
            Console.WriteLine(num3);
            int num4 = random2.Next(0, 10);
            Console.WriteLine(num4);

            byte[] buffer = new byte[5];
            random2.NextBytes(buffer);
            foreach (byte b in buffer)
            {
                Console.Write(b+" ");
            }

            Console.WriteLine(" ");
            string strs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(strs[random2.Next(strs.Length)]);
            }
            Console.WriteLine(sb.ToString());
            while (sb.Length <8)
            {
                sb.Append(strs[random2.Next(strs.Length)]);
            }
            Console.WriteLine(sb.ToString());

            string str = new string(Enumerable.Repeat(strs, 6).Select(s => s[random2.Next(s.Length)]).ToArray());
            Console.WriteLine(str);

            Console.WriteLine(sb.ToString());

            string[] colors = { "red", "green", "blue", "yellow", "black" };
            string color = colors[random2.Next(colors.Length)];
            Console.WriteLine(color);

            Console.ReadKey();
        }
    }
}