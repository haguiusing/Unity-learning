using System;
using System.Text;

namespace Lesson11_字符串拼接
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("字符串拼接");

            #region 知识点一：字符串拼接方式1
            //之前的算数运算符 只是用来数值类型变量进行数学运算的
            //而 string 不存在算数运算符不能计算 但是可以通过+号来进行字符申拼接
            string str = "123";
            //用+号进行字符串拼接
            str = str + "456";
            Console.WriteLine(str);
            str = str + 1;
            Console.WriteLine(str);

            // 复合运算符 +=
            str ="123";
            str += "1" + 4 + true;
            Console.WriteLine(str);

            str += 2 + 3 + 4;
            Console.WriteLine(str);

            str += 1 + 2 + 3 + 4; ;
            Console.WriteLine(str);

            str += "" + 1 + 2 + 3 + 4;
            Console.WriteLine(str);

            str = "";
            str += 1 + 2 + "" + (3 + 4);
            Console.WriteLine(str);

            str = "123";
            str +=  str + (1 + 2 + 3);
            Console.WriteLine(str);

            //注意 :用+号拼接 是用符号唯一方法 不能用-*/%....

            //String.Concat方法
            string str1 = "123";
            string str2 = "456";
            string str3 = "789";
            string str4 = String.Concat(str1, str2, str3);
            Console.WriteLine(str4);
            
            //固定语法
            //string.Format(“待拼接的内容”，内容1，内容2,.....);
            //拼接内容中的固定规则一唐老狮一
            //想要被拼接的内容用占位符替代《数字} 数字:~n 依次往后
            string str5 = string.Format("我是{0}，我今年{1}岁，我想要{2}", "唐老狮", 18, "天天学习,好好向上");
            Console.WriteLine(str5);

            str5 = string.Format("asdf{0},{1},sdfasdf{2}", 1, true, false);
            Console.WriteLine(str5);

            // $ 的字符串内插
            string str6 = $"我是{1}，我今年{true}岁，我想要{false}";
            Console.WriteLine(str6);
            #endregion

            #region 知识点二：字符串拼接方式2
            //使用 StringBuilder 方法
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append("World");
            sb.Append("!");
            string str7 = sb.ToString();
            #endregion

            #region 控制台打印拼接
            //后面的 内容 比占位符多 不会报错
            //后面的 内容 比占位符少 会报错
            Console.WriteLine("A{0}B{1}C{2}", 1, true, false, 1, 2);
            //Console.Write("A{0}B{1}C{2}", 1, true); //报错
            #endregion
        }
    }
}