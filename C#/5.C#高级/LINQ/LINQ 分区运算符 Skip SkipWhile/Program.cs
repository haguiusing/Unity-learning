using System.Threading;

namespace LINQ_分区运算符_Skip_SkipWhile_Take_TakeWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //分区运算符将序列（集合）分为两部分，并返回其中一部分。
            //方法	    描述
            //Skip      从序列中的第一个元素开始，将元素跳到指定的位置。
            //SkipWhile 根据条件跳过元素，直到元素不满足条件为止。如果第一个元素本身不满足条件，那么它将跳过0个元素并返回序列中的所有元素。
            //Take      从序列中的第一个元素开始，将元素带到指定的位置。
            //TakeWhile 从第一个元素返回元素，直到元素不满足条件为止。如果第一个元素本身不满足条件，则返回一个空集合。
            Console.WriteLine("LINQ_分区运算符_Skip_SkipWhile_Take_TakeWhile");

            #region Skip
            //IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
            //Skip()方法从第一个元素开始跳过指定数量的元素，并返回其余元素。
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Skip(2);
            foreach (var str in newList)
                Console.WriteLine(str);
            //输出：
            //Three
            //Four
            //Five

            //查询语法中的 Skip 运算符
            //C # 查询语法不支持 Skip & SkipWhile 运算符。
            //但是，您可以对查询变量使用 Skip/SkipWhile 方法，或者将整个查询包装到括号中，然后调用 Skip/SkipWhile。

            var query = (from str in strList
                         select str).Skip(2);
            foreach (var str in query)
                Console.WriteLine(str);
            //输出：
            //Three
            //Four
            //Five
            #endregion

            #region SkipWhile
            //顾名思义，LINQ中的SkipWhile()扩展方法将跳过集合中的元素，直到指定的条件为true。
            //一旦任何元素的指定条件变为false，它将返回一个包含所有剩余元素的新集合。

            //SkipWhile()方法有两种重载方法。
            //一种方法接受Func<TSource, bool> 类型的谓词，
            //另一种重载方法接受Func<TSource, int, bool> 通过元素索引的谓词类型。

            //在下面的示例中，SkipWhile()方法跳过所有元素，直到找到长度等于或大于4个字符的字符串。
            //示例：在C＃中SkipWhile()方法跳过长度小于4的元素,并返回其后的所有元素
            IList<string> strList1 = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList1.SkipWhile(s => s.Length < 4);
            foreach (string str in resultList)
                Console.WriteLine(str);
            //输出：
            //Three
            //Four
            //Five
            //Six

            Console.WriteLine();

            //在上面的示例中，由于前两个元素的长度小于3，所以 SkipWhile() 跳过前两个元素，并找到长度等于或大于4的第三个元素。
            //一旦找到长度等于或大于4个字符的任何元素，它将不跳过其他任何元素元素，即使小于4个字符。

            //现在，看以下示例，该示例中，其中 SkipWhile()不会跳过任何元素，因为第一个元素的指定条件为 false。
            IList<string> strList2 = new List<string>() {
                                            "Three",
                                            "One",
                                            "Two",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList1 = strList2.SkipWhile(s => s.Length < 4);
            foreach (string str in resultList1)
                Console.WriteLine(str);
            //输出：
            //Three
            //One
            //Two
            //Four
            //Five
            //Six

            Console.WriteLine();

            //SkipWhile的第二个重载传递每个元素的索引。看下面的实例
            var result = strList2.SkipWhile((s, i) => s.Length > i);   // 跳过所有元素，直到索引大于元素长度
            foreach (string str in result)
                Console.WriteLine(str);
            //输出：
            //Five
            //Six

            //在上面的示例中，lambda表达式包括元素和元素的索引作为参数。它会跳过所有元素，直到字符串元素的长度大于其索引。

            //查询语法中的SkipWhile运算符
            //C# 查询语法不支持 Skip & SkipWhile 运算符。
            //但是，您可以对查询变量使用 Skip/SkipWhile 方法，或者将整个查询包装到括号中，然后调用 Skip/SkipWhile ()。
            var resultQuery = (from str in strList2
                              select str).SkipWhile(s => s.Length < 4);
            foreach (string str in resultQuery)
                Console.WriteLine(str);
            //输出：
            //Three
            //One
            //Two
            //Four
            //Five
            //Six
            #endregion

            #region Take
            //IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, Range range);
            //IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);

            //Take()扩展方法返回从第一个元素开始的指定数量的元素。
            IList<string> strList3 = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList1 = strList3.Take(2);
            foreach (var str in newList1)
                Console.WriteLine(str);
            //输出：
            //One
            //Two

            //C# 查询语法不支持 Take & takedwhile 运算符。
            //但是，您可以对查询变量使用 Take/Takedwhile 方法，或者将整个查询包装到括号中，然后调用 Take/Takedwhile ()。
            var query1 = (from str in strList3
                select str).Take(2);
            foreach (var str in query1)
                Console.WriteLine(str);
            //输出：
            //One
            //Two
            #endregion

            #region TakeWhile
            //IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
            //IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

            //TakeWhile()扩展方法返回给定集合中的元素，直到指定的条件为true。如果第一个元素本身不满足条件，则返回一个空集合。
            //TakeWhile方法有两个重载方法。
            //一种方法接受Func<TSource, bool> 类型的谓词，另一种重载方法接受Func<TSource, int, bool> 通过元素索引的谓词类型。

            //在下面的示例中，TakeWhile()方法返回一个包含所有元素的新集合，直到找到长度小于4个字符的字符串为止。
            //示例：C＃中的TakeWhile方法返回字符串长度大于4的元素
            IList<string> strList4 = new List<string>() {
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Hundred"  };

            var result2 = strList4.TakeWhile(s => s.Length > 4);

            foreach (string str in result2)
                Console.WriteLine(str);
            //输出：
            //Three
            //在上面的示例中，TakeWhile()返回仅包含第一元素，因为第二字符串元素不满足该条件。
            
            //TakeWhile 还在谓词函数中传递当前元素的索引。下面的 TakeWhile 方法示例接受元素，直到字符串元素的长度大于它的索引
            
            //示例：C#中的TakeWhile传递索引,返回字符串长度大于索引的元素
            IList<string> strList5 = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList2 = strList5.TakeWhile((s, i) => s.Length > i);
            foreach (string str in resultList2)
                Console.WriteLine(str);
            //输出：
            //One
            //Two
            //Three
            //Four
            #endregion
        }
    }
}
