using System.Numerics;

namespace LINQ
{
    internal class Program
    {
        //https://www.cainiaojc.com/linq/linq-tutorial.html  教程地址

        //语言集成查询（LINQ）是.Net 3.5和Visual Studio 2008引入的功能强大的查询语言。
        //LINQ可与C＃或Visual Basic一起使用，以查询不同的数据源。
        //LINQ（语言集成查询）是C＃和VB.NET中的统一查询语法，用于从不同的源和格式检索数据。
        //它集成在C＃或VB中，从而消除了编程语言和数据库之间的不匹配，并为不同类型的数据源提供了单个查询接口。

        //例如，SQL是一种结构化查询语言，用于保存和检索数据库中的数据。
        //同样，LINQ是C＃和VB.NET中内置的结构化查询语法，用于从不同类型的数据源（例如集合，ADO.Net DataSet，XML Docs，Web服务和MS SQL Server和其他数据库）中检索数据。

        //LINQ查询将结果作为对象返回。它使您可以在结果集上使用面向对象的方法，而不必担心将不同格式的结果转换为对象。

        /// <summary>
        /// 测试1-查询从包含“ a”的数组中获取所有字符串
        /// </summary>
        public static void Test1()
        {
            // 数据源
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            // LINQ查询 
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;

            // 查询执行
            foreach (var name in myLinqQuery)
                Console.Write(name + "  ");
        }

        //版本发展
        //在C＃2.0之前，我们必须使用“ foreach”或“ for”循环遍历集合以查找特定对象;
        //for循环的使用很麻烦，不可维护和可读性差。C#2.0引入了委托，来处理这种情况;
        //C＃3.0中引入了扩展方法，lambda表达式，表达式树，匿名类型和查询表达式。 您可以使用C＃3.0的这些功能（它们是LINQ的构建块）来查询不同类型的集合并在单个语句中获取结果元素。

        //LINQ的优势
        //Familiar language（熟悉的语言）: 开发人员不必为每种类型的数据源或数据格式学习新的查询语言。
        //Less coding（更少的代码）: 与更传统的方法相比，它减少了要编写的代码量。
        //Readable code（代码可读性）: LINQ使代码更具可读性，因此其他开发人员可以轻松地理解和维护它。
        //Standardized way of querying multiple data sources（查询多个数据源的标准化方法）: 相同的LINQ语法可用于查询多个数据源。
        //Compile time safety of queries（查询的编译时安全性）: 它在编译时提供对象的类型检查。
        //IntelliSense Support（智能感知支持）: LINQ为通用集合提供了IntelliSense。
        //Shaping data（数据形状）: 您可以以不同形状检索数据。

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");
            Test1();
        }
    }
}
