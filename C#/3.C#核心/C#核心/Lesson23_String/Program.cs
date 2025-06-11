namespace Lesson23_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String");

            #region 知识点一：字符串指定位置获取
            //字符串的本质是char数组
            string str = "唐老狮";
            Console.Write(str[0]);
            //转为char数组
            char[] chars = str.ToCharArray();
            Console.WriteLine(chars[1]);

            for(int i=0; i<chars.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(chars[i]);
                }
                else
                {
                    Console.Write(str[i]);
                }
                if (i == chars.Length - 1)
                {
                    Console.WriteLine();
                }
            }
            #endregion

            #region 知识点二：字符串拼接
            str = string.Format("{0}{1}", 1, 3333);
            Console.WriteLine(str);
            #endregion

            #region 知识点三：正向查找字符位置
            //⭕正向查找字符位置 
            str = "我是苏同学？";
            int index = str.IndexOf("苏");  //返回 2 字符串的索引 , 找不到就会返回-1
            index = str.IndexOf("苏") + 1;
            Console.WriteLine(index);  //返回 3
            #endregion

            #region 知识点四：反向查找字符串位置
            //⭕反向查找字符位置
            str = "我是苏同学苏同学？";
            index = str.LastIndexOf("苏同学");
            Console.WriteLine(index);
            //返回 5 从后面开始查找词组就返回第一个字的索引，找不到就返回-1
            #endregion

            #region 知识点五：移除指定位置后的字符
            //⭕移除指定位置后的字符
            str = "我是苏同学苏同学";
            str = str.Remove(4);
            Console.WriteLine(str);
            //返回 "我是苏同"

            //⭕执行两个参数进行移除 参数1开始的位置 参数2字符个数
            str = "我是苏同学陈同学";
            str = str.Remove(3, 3);
            Console.WriteLine(str);
            //返回"我是陈同学" 
            #endregion

            #region 知识点六：替换指定字符串
            //⭕替换指定字符串
            str = "我是苏同学陈同学";
            str = str.Replace("苏同学", "李同学");
            Console.WriteLine(str);
            //返回"我是李同学陈同学" 
            #endregion

            #region 知识点七：大小写转换
            //⭕大小写转换
            str = "abcdefg";
            str = str.ToUpper();
            Console.WriteLine(str);
            //返回"ABCDEFG"
            str = str.ToLower();
            Console.WriteLine(str);
            //返回"abcdefg"
            #endregion

            #region 知识点八：字符串规则
            //⭕字符串截取 截取从指定位置开始之后的字符串
            str = "苏同学陈同学";
            str = str.Substring(3);
            Console.WriteLine(str);
            //返回 "陈同学"

            //重载 参数1开始位置 参数2指定个数
            str = "苏同学陈同学苏同学";
            str = str.Substring(3, 3);
            Console.WriteLine(str);
            //返回 "陈同学"
            #endregion

            #region 知识点九：字符串切割
            //⭕⭕⭕字符串切割 指定切割符号来切割字符串
            str = "1|2|3|4|5|6|7|8";
            string[] strs = str.Split("|");
            for(int i = 0; i < strs.Length; i++)
            {
                Console.Write(strs[i]+",");
            }
            //返回 string[]{1,2,3,4,5,6,7,8}
            #endregion

            str.Contains("a");  //判断字符串是否包含指定字符 返回bool值
            str.StartsWith("a");  //判断字符串是否以指定字符开头 返回bool值
            str.EndsWith("a");  //判断字符串是否以指定字符结尾 返回bool值
        }
    }
}
