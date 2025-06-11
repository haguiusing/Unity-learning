using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LINQ_元素运算符_First和FirstOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_元素运算符_First和FirstOrDefault");

            //First和FirstOrDefault方法从集合中第零个索引返回一个元素，即第一个元素。另外，它返回满足指定条件的元素。
            //元素运算符        描述                    
            //First             返回集合的第一个元素，或满足条件的第一个元素。                    
            //FirstOrDefault    返回集合的第一个元素，或满足条件的第一个元素。如果索引超出范围，则返回默认值。

            //First和FirstOrDefault具有两个重载方法。
            //第一个重载方法不使用任何输入参数，并返回集合中的第一个元素。
            //第二个重载方法将lambda表达式作为谓词委托来指定条件，然后返回满足指定条件的第一个元素。
            // First<TSource>(this IEnumerable < TSource > source, Func<TSource, bool> predicate);
            // First<TSource>(this IEnumerable < TSource > source);
            // FirstOrDefault<TSource>(this IEnumerable < TSource > source, Func<TSource, bool> predicate, TSource defaultValue);
            // FirstOrDefault<TSource>(this IEnumerable < TSource > source, TSource defaultValue);
            //? FirstOrDefault<TSource>(this IEnumerable < TSource > source);
            //? FirstOrDefault<TSource>(this IEnumerable < TSource > source, Func<TSource, bool> predicate);

            //First()方法使用lambda表达式或Func委托返回集合的第一个元素，或满足指定条件的第一个元素。
            //如果给定的集合为空或不包含任何满足条件的元素，则它将抛出 InvalidOperation 异常。

            //FirstOrDefault()方法与First()方法具有相同的作用。
            //唯一的区别是，如果集合为空或找不到满足条件的任何元素，它将返回集合数据类型的默认值。

            //下面的示例演示First()方法。
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("intList中的第一个元素: {0}", intList.First());
            Console.WriteLine("intList中的第一个偶数元素: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("strList中的第一个元素： {0}", strList.First());

            Console.WriteLine("emptyList.First()抛出InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(emptyList.First()); //抛出异常
            //输出：
            //intList中的第一个元素：7
            //intList中的第一个偶数元素：10
            //strList中的第一个元素：
            //emptyList.First()抛出InvalidOperationException
            //-------------------------------------------------------------
            //运行时异常：序列不包含任何元素...

            //下面的示例演示FirstOrDefault()方法。
            Console.WriteLine("intList中的第一个元素: {0}", intList.FirstOrDefault());
            Console.WriteLine("intList中的第一个偶数元素: {0}", intList.FirstOrDefault(i => i % 2 == 0));
            Console.WriteLine("strList中的第一个元素: {0}", strList.FirstOrDefault());
            Console.WriteLine("emptyList中的第一个元素: {0}", emptyList.FirstOrDefault());
            //输出：
            //intList中的第一个元素：7
            //intList中的第一个偶数元素：10
            //strList中的第一个元素：
            //emptyList中的第一个元素：

            //在First()或FirstOrDefault()中指定条件时要小心。
            //如果集合不包含任何满足指定条件的元素或包含null元素，则First()将抛出异常。

            //如果集合包含空元素，则 FirstOrDefault()在计算指定条件时抛出异常。下面的示例演示了这一点。
            //Console.WriteLine("intList中大于250的第一个元素: {0}", intList.First(i => i > 250)); //抛出异常

            //Console.WriteLine("在 intList 中的第一个偶数元素: {0}", strList.FirstOrDefault(s => s.Contains("T")));  //抛出异常
            //输出：
            //Run - time exception: Sequence contains no matching element
            //运行时异常：序列不包含匹配元素
        }
    }
}
