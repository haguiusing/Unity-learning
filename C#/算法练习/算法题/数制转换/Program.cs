namespace 数制转换
{
    internal class Program
    {
        //static int ConvertTo8(int num)
        //{
        //    string result = 0;

        //    void temp(int num)
        //    {
        //        if (num > 7)
        //        {
        //            temp(num / 8);
        //            result++;
        //        }
        //    }

        //    return num % 8 + result * 10;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("数制转换，将任意整数转换成8进制形式");

            //1、Convert.ToInt32(string value, int fromBase); 
            //把不同进制数值的字符串转换为数字（十进制）
            //  value 参数 要进行转换的数值字符串
            //  fromBase参数 要转换成的进制格式，只能是2、8、10及16。

            //2、Convert.ToString(int value, int toBase);
            //可以把一个数字（十进制）转换为不同进制数值的字符串格式,
　　　　　　//  value 参数 要进行转换的数字（十进制数）
            //  toBase参数 要转换成的进制格式，只能是2、8、10及16。

            Convert.ToString(10, 8); //输出 "12"
            //Console.WriteLine(ConvertTo8(10));
        }
    }
}
