namespace LINQ_投影运算符_Select_SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_投影运算符_Select_SelectMany");
            //LINQ中有两个可用的投影运算符。
            //  1）Select
            //  2）SelectMany

            #region Select
            //Select运算符始终返回IEnumerable集合，该集合包含基于转换函数的元素。它类似于产生平面结果集的SQL的Select子句。
            //IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
            //IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
            //现在，让我们了解使用以下Student类的Select查询运算符。

            //查询语法中的Select
            //LINQ查询语法必须以Select 或 GroupBy子句结尾。下面的示例演示了Select 运算符，该运算符返回StudentName的字符串集合。
            Grade[] grades = new Grade[] {
                new Grade(1, "A", 90) ,
                new Grade(2, "B", 80),
                new Grade(3, "C", 70) ,
                new Grade(4, "D", 60) ,
                new Grade(5, "F", 50)
            };

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Grades =grades},
                new Student() { StudentID = 2, StudentName = "Moin", Grades =grades},
                new Student() { StudentID = 3, StudentName = "Bill", Grades =grades},
                new Student() { StudentID = 4, StudentName = "Ram", Grades =grades},
                new Student() { StudentID = 5, StudentName = "Ron", Grades =grades}
            };

            var selectResult = from s in studentList
                               select s.StudentName;
            //选择运算符可用于根据我们的要求制定结果。它可用于返回自定义类或匿名类型的集合，其中包括根据我们的需要的属性。
            //下面的select子句示例返回一个包含Name和Age属性的匿名类型的集合。

            // 返回具有Name和Age属性的匿名对象的集合
            var selectResult1 = from s in studentList
                               select new { Name = "Mr. " + s.StudentName, Age = s.Age };

            // 迭代selectResult
            foreach (var item in selectResult1)
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);

            //在方法语法中Select
            //Select运算符在方法语法中是可选的。但是，您可以使用它来塑造数据。
            //在以下示例中，Select扩展方法返回具有Name和Age属性的匿名对象的集合：
            var selectResult2 = studentList.Select(s => new {
                Name = s.StudentName,
                Age = s.Age
            });

            //在上面的示例中，selectResult将包含具有Name和Age属性的匿名对象，如下面的调试视图所示。
            //https://www.cainiaojc.com/static/upload/201229/1717330.png
            #endregion

            #region SelectMany
            //SelectMany 运算符投射基于转换函数的值序列，然后将它们扁平化为一个序列。
            //IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
            //IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
            //IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
            //IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
            
            //SelectMany方法不支持查询语法

            //方法语法中的SelectMany
            var selectManyResult1 = studentList.SelectMany(s => s.Grades, (s, g) => new { StudentName = s.StudentName, GradeName = g.GradeName });
            #endregion
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public required Grade[] Grades { get; set; }
    }

    public class Grade
    {
        public int GradeID { get; set; }
        public string GradeName { get; set; }
        public int GradeLevel { get; set; }

        public Grade(int gradeID, string gradeName, int gradeLevel)
        {
            this.GradeID = gradeID;
            this.GradeName = gradeName;
            this.GradeLevel = gradeLevel;
        }
    }
}
