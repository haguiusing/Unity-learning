using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LINQ_元素运算符_Last和LastOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_元素运算符_Last和LastOrDefault");
            //元素运算符	描述
            //Last            返回集合中的最后一个元素，或满足条件的最后一个元素
            //LastOrDefault   返回集合中的最后一个元素，或满足条件的最后一个元素。如果不存在这样的元素，则返回默认值。

            //Last和LastOrDefault具有两个重载方法。
            //一个重载方法不使用任何输入参数，而是返回集合中的最后一个元素。
            //第二个重载方法使用lambda表达式指定条件，然后返回满足指定条件的最后一个元素。
            //Last<TSource>(this IEnumerable<TSource> source);
            //Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
            // LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue);
            //? LastOrDefault<TSource>(this IEnumerable<TSource> source);
            // LastOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue);
            //? LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

            //Last()方法从集合中返回最后一个元素，或者使用lambda表达式或Func委托返回满足指定条件的最后一个元素。
            //如果给定的集合为空或不包含任何满足条件的元素，则它将抛出 InvalidOperation 异常。
            //LastOrDefault()方法与Last()方法具有相同的作用。
            //唯一的区别是，如果集合为空或找不到满足条件的任何元素，它将返回集合数据类型的默认值。

            //下面的示例演示Last()方法。
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("intList中的最后一个元素: {0}", intList.Last());

            Console.WriteLine("intList中的最后一个偶数: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("strList中的最后一个元素: {0}", strList.Last());

            Console.WriteLine("emptyList.Last()抛出InvalidOperationException ");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(emptyList.Last());  //抛出异常
            //输出：
            //intList中的最后一个元素：87
            //intList中的最后一个偶数：50
            //strList中的最后一个元素：Five
            //emptyList.Last()抛出InvalidOperationException
            //---------------------------------------------- - --------------
            //Run - time exception: Sequence contains no elements...

            //下面的示例演示LastOrDefault()方法。
            Console.WriteLine("intList中的最后一个元素: {0}", intList.LastOrDefault());
            Console.WriteLine("intList中的最后一个偶数元素: {0}", intList.LastOrDefault(i => i % 2 == 0));
            Console.WriteLine("strList中的最后一个元素: {0}", strList.LastOrDefault());
            Console.WriteLine("emptyList中的最后一个元素: {0}", emptyList.LastOrDefault());
            //输出：
            //intList中的最后一个元素：87
            //intList中的最后一个偶数元素：50
            //strList中的最后一个元素：Five
            //emptyList中的最后一个元素：

            //在Last()或LastOrDefault()中指定条件时要小心。
            //如果集合不包含任何满足指定条件的元素或包含null元素，那么Last()将抛出异常。

            //如果集合包含null元素，则LastOrDefault()在评估指定条件时会引发异常。以下示例对此进行了演示。
            //Console.WriteLine("intList中大于250的最后一个元素: {0}", intList.Last(i => i > 250));  //抛出异常

            //Console.WriteLine("intList中的最后一个偶数元素: {0}", strList.LastOrDefault(s => s.Contains("T")));  //抛出异常
            //输出：
            //Run - time exception: Sequence contains no matching element
            //运行时异常：序列不包含匹配元素
        }
    }
}
