namespace LINQ_排序运算符_OrderBy和OrderByDescending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //排序运算符以升序或降序排列集合的元素。LINQ包括以下排序运算符。
            //运算符 描述
            //OrderBy  根据指定的字段按升序或降序对集合中的元素进行排序。
            //OrderByDescending  根据指定的字段按降序对集合进行排序。仅在方法语法中有效。
            //ThenBy  仅在方法语法中有效。用于按升序进行二次排序。
            //ThenByDescending  仅在方法语法中有效。用于按降序进行二次排序。
            //Reverse  仅在方法语法中有效。按相反顺序对集合排序。

            Console.WriteLine("LINQ_排序运算符_OrderBy和OrderByDescending");

            #region OrderBy
            //orderderby按升序或降序对集合的值进行排序。
            //默认情况下，它按升序对集合进行排序，因为ascending关键字在这里是可选的。
            //使用降序关键字对集合进行降序排序。

            //查询语法中的OrderBy
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var orderByResult = from s in studentList
                                orderby s.StudentName ascending  // ascending表示 按升序排序（默认）
                                select s;

            //OrderBy扩展方法有两个重载。
            //IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
            //IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);
            //OrderBy扩展方法的第一个重载接受Func委托类型参数。
            //  因此，您需要为要对集合进行排序的字段传递lambda表达式。
            //OrderBy的第二个重载方法接受IComparer的对象以及Func委托类型，以使用自定义比较进行排序。

            //以下示例使用OrderBy扩展方法按StudentName的升序对studentList集合进行排序。
            var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);

            #endregion

            #region OrderByDescending
            //OrderByDescending以降序对集合进行排序。
            //OrderByDescending仅对方法语法有效。它在查询语法中无效，因为查询语法使用升序和降序属性，如上所示。
            var orderByDescendingResult = from s in studentList
                                          orderby s.StudentName descending  // descending表示 按降序排序
                                          select s;

            //以下示例使用OrderByDescending扩展方法按StudentName的降序对studentList集合进行排序。
            var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);
            #endregion

            //多重排序
            //可以在用逗号分隔的多个字段上对集合进行排序。
            //给定的集合将首先基于第一个字段进行排序，
            //然后如果两个元素的第一个字段的值相同，则将使用第二个字段进行排序，
            //依此类推。

            var orderByResultMulti = from s in studentList
                                orderby s.StudentName, s.Age
                                select new { s.StudentName, s.Age };

            //在上面的示例中，studentList集合包括两个相同的StudentName，Ram。
            //因此，现在，studentList将首先基于StudentName进行排序，然后根据年龄进行升序排列。

            //方法语法中的多重排序的工作方式不同。使用ThenBy或ThenByDecenting扩展方法进行二次排序。

            #region Reverse
            //IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source);
            // Reverse仅在方法语法中有效。按相反顺序对集合排序。
            orderByResultMulti = orderByResultMulti.Reverse();
            #endregion
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
