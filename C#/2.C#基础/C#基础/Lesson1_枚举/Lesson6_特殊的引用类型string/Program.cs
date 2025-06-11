namespace Lesson6_特殊的引用类型string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("特殊的引用类型string");

            #region 知识点一：复习 值类型和引用类型
            // 值类型——它变我不变——存储在栈内存中
            // 无符号整形 有符号整形 浮点数 char bool 结构体 (未学习)

            // 引用类型——它变我也变——存储在堆内存中
            // 数组 (一维、二维、交错)  string类(末学习)
            #endregion

            #region 知识点二：string的它变我不变
            //string str1 = "123";
            //string str2 = str1;
            // 因为string是引用类型 按理说 应该是它变我也变
            // string非常的特殊 它具备 值类型的特征 它变现不变
            //str2 = "321";

            //Console.WriteLine(str1);
            //Console.WriteLine(str2);

            //string在c#中进行了处理使其具有值类型的特征
            //虽然方便，但是频繁的改变 string 重新赋值会产生内存垃圾
            //会产生 内存垃圾
            //string 虽然方便 但是有一个小缺点 就是频繁的 改变string 重新赋值
            //优化替代方案 我们会在 C#核心当中进行讲解

            #endregion

            //监视窗口的使用
            //&取址,*取值
            string str1 = "123";
            string str2 = str1;
            // 因为string是引用类型 按理说 应该是它变我也变
            // string非常的特殊 它具备 值类型的特征 它变现不变
            str2 = "321";

            Console.WriteLine(str1);
            Console.WriteLine(str2);

            #region String 类的属性和方法
            //属性
            //Chars    在当前 String 对象中获取 Char 对象的指定位置。
            //Length   在当前的 String 对象中获取字符数。

            //方法
            //public static int Compare( string strA, string strB, [bool ignoreCase] )
            //比较两个指定的 string 对象，并返回一个表示它们在排列顺序中相对位置的整数。但是，如果布尔参数为真时，该方法不区分大小写。

            //public bool Contains( string value )
            //返回一个表示指定 string 对象是否出现在字符串中的值。

            //public static string Copy( string str )
            //创建一个与指定字符串具有相同值的新的 String 对象。

            //public void CopyTo( int sourceIndex, char[] destination, int destinationIndex, int count )
            //从 string 对象的指定位置开始复制指定数量的字符到 Unicode 字符数组中的指定位置。

            //public bool EndsWith( string value )
            //判断 string 对象的结尾是否匹配指定的字符串。

            //public bool Equals( string value )
            //判断当前的 string 对象是否与指定的 string 对象具有相同的值。

            //public static bool Equals( string a, string b )
            //判断两个指定的 string 对象是否具有相同的值。

            //public static string Format( string format, Object arg0 )
            //把指定字符串中一个或多个格式项替换为指定对象的字符串表示形式。

            //public int IndexOf( char value )
            //返回指定 Unicode 字符在当前字符串中第一次出现的索引，索引从 0 开始。

            //public int IndexOf( string value )
            //返回指定字符串在该实例中第一次出现的索引，索引从 0 开始。

            //public int IndexOf( char value, int startIndex )
            //返回指定 Unicode 字符从该字符串中指定字符位置开始搜索第一次出现的索引，索引从 0 开始。

            //public int IndexOf( string value, int startIndex )
            //返回指定字符串从该实例中指定字符位置开始搜索第一次出现的索引，索引从 0 开始。

            //public int IndexOfAny( char[] anyOf )
            //返回某一个指定的 Unicode 字符数组中任意字符在该实例中第一次出现的索引，索引从 0 开始。

            //public int IndexOfAny( char[] anyOf, int startIndex )
            //返回某一个指定的 Unicode 字符数组中任意字符从该实例中指定字符位置开始搜索第一次出现的索引，索引从 0 开始。

            //public string Insert( int startIndex, string value )
            //返回一个新的字符串，其中，指定的字符串被插入在当前 string 对象的指定索引位置。

            //public static bool IsNullOrEmpty( string value )
            //指示指定的字符串是否为 null 或者是否为一个空的字符串。

            //	public static string Join( string separator, string[] value )
            //连接一个字符串数组中的所有元素，使用指定的分隔符分隔每个元素。

            //public static string Join( string separator, string[] value, int startIndex, int count )
            //连接一个字符串数组中的指定位置开始的指定元素，使用指定的分隔符分隔每个元素。

            //public int LastIndexOf( char value )
            //返回指定 Unicode 字符在当前 string 对象中最后一次出现的索引位置，索引从 0 开始。

            //public int LastIndexOf( string value )
            //返回指定字符串在当前 string 对象中最后一次出现的索引位置，索引从 0 开始。

            //public string Remove( int startIndex )
            //移除当前实例中的所有字符，从指定位置开始，一直到最后一个位置为止，并返回字符串。

            //public string Replace( string oldValue, string newValue )
            //把当前 string 对象中，所有指定的字符串替换为另一个指定的字符串，并返回新的字符串。

            //public string[] Split(params char[] separator)
            //返回一个字符串数组，包含当前的 string 对象中的子字符串，子字符串是使用指定的 Unicode 字符数组中的元素进行分隔的。

            //public string[] Split(char[] separator, int count)
            //返回一个字符串数组，包含当前的 string 对象中的子字符串，子字符串是使用指定的 Unicode 字符数组中的元素进行分隔的。int 参数指定要返回的子字符串的最大数目。

            //public bool StartsWith(string value)
            //判断字符串实例的开头是否匹配指定的字符串。

            //public char[] ToCharArray()
            //返回一个带有当前 string 对象中所有字符的 Unicode 字符数组。

            //public char[] ToCharArray(int startIndex, int length)
            //返回一个带有当前 string 对象中所有字符的 Unicode 字符数组，从指定的索引开始，直到指定的长度为止。

            //public string ToLower()
            //把字符串转换为小写并返回。

            //public string ToUpper()
            //把字符串转换为大写并返回。

            //public string Trim()
            //移除当前 String 对象中的所有前导空白字符和后置空白字符。

            #endregion

            #region 字符串格式化
            //常用的几种实例

            #endregion
        }
    }
}