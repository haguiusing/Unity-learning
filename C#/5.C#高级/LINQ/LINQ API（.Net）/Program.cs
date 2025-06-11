using System.Collections.Generic;

namespace LINQ_API_.Net_
{
    //https://www.cainiaojc.com/linq/linq-api.html
    internal class Program
    {
        //LINQ查询对实现IEnumerable或IQueryable接口的类使用扩展方法。Enumerable和Queryable是两个静态类，它们包含编写LINQ查询的扩展方法。

        //可枚举类(Enumerable)
        //Enumerable类包括用于实现IEnumerable<T>接口的类的扩展方法，例如，所有内置集合类都实现了IEnumerable<T>接口，因此我们可以编写LINQ查询来从内置集合中检索数据。

        //https://www.cainiaojc.com/static/upload/201229/1137311.png  可以与C＃或VB.Net中的泛型集合一起使用
        //https://www.cainiaojc.com/static/upload/201229/1137312.png  Enumerable该类中所有可用的扩展方法

        //可查询(Queryable)
        //Queryable类包含用于实现成员“> IQueryable <t>接口的类的扩展方法。
        //该IQueryable<T>接口用于提供针对已知数据类型的特定数据源的查询功能，
        //例如，Entity Framework api实现了IQueryable<T>针对通过底层数据库（例如MS SQL Server）支持LINQ查询。

        //此外，还有一些API可用于访问第三方数据。例如，LINQ to Amazon提供了将LINQ与Amazon Web服务结合使用以搜索书籍和其他物品的功能。
        //这可以通过IQueryable为Amazon实现接口来实现。

        //https://www.cainiaojc.com/static/upload/201229/1137313.png  Queryable该类中可用的扩展方法，可以与各种本机或第三方数据提供程序一起使用
        //https://www.cainiaojc.com/static/upload/201229/1137314.png  Queryable该类中可用的所有扩展方法

        // 要记住的要点
        //1.使用 System.LINQ 命名空间来使用 LINQ。
        //2.LINQ api包括两个主要的静态类Enumerable 和 Queryable。
        //3.静态Enumerable类包括用于实现IEnumerable<T> 接口的类的扩展方法。
        //4.IEnumerable<T> 集合的类型是内存中的集合，例如List，Dictionary，SortedList，Queue，HashSet，LinkedList。
        //5.静态Queryable类包括用于实现IQueryable<T> 接口的类的扩展方法。
        //6.远程查询提供程序实现了例如Linq-to-SQL，LINQ-to-Amazon等。


        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_API_.Net");
        }
    }
}
