namespace LINQ_标准查询运算符
{
    internal class Program
    {
        //LINQ中的标准查询运算符实际上是 IEnumerable<T> and IQueryable<T>类型的扩展方法。
        //它们在System.Linq.Enumerable和System.Linq.Queryable类中定义。
        //LINQ中提供了50多个标准查询运算符，它们提供了不同的功能，例如过滤，排序，分组，聚合，串联等。

        //查询语法中的标准查询运算符
        //https://www.cainiaojc.com/static/upload/201229/1138520.png  查询语法中的标准查询运算符

        //方法语法中的标准查询运算符
        //https://www.cainiaojc.com/static/upload/201229/1443321.png  方法语法中的标准查询运算符
        //查询语法中的标准查询运算符在编译时转换为扩展方法。所以两者都是一样的。

        //可以根据标准查询运算符提供的功能对其进行分类。下表列出了标准查询运算符的所有分类：
        //    类别	          标准查询运算符
        //    过滤            Where, OfType
        //    排序            OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse
        //    分组            GroupBy, ToLookup
        //    联合            GroupJoin, Join
        //    投射            Select, SelectMany
        //    聚合            Aggregate, Average, Count, LongCount, Max, Min, Sum
        //  限定/修饰         All, Any, Contains
        //    元素            ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
        //  Set/集合          Distinct, Except, Intersect, Union
        //    分区            Skip, SkipWhile, Take, TakeWhile
        //    串联            Concat
        //    相等            SequenceEqual
        //生成/范围状态       DefaultEmpty, Empty, Range, Repeat
        //    转换            AsEnumerable, AsQueryable, Cast, ToArray, ToDictionary, ToList

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 标准查询运算符");
        }
    }
}
