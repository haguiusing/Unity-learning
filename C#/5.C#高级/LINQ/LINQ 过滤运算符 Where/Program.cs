namespace LINQ_过滤运算符_Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_过滤运算符_Where");

            //LINQ中的过滤运算符根据某些给定的标准过滤序列（集合）。
            //下表列出了LINQ中所有可用的过滤运算符。
            //筛选运算符 描述
            //Where 根据谓词函数从集合中返回值。
            //OfType 根据指定类型返回集合中的值。 然而，它取决于它们是否能够向指定类型转换。

            #region 筛选运算符 Where
            //Where运算符（Linq扩展方法）基于给定的条件表达式过滤集合并返回新集合。可以将标准指定为lambda表达式或Func委托类型。
            //Where扩展方法有以下两个重载。两种重载方法都接受Func委托类型参数。一个重载需要Func < TSource，bool> 输入参数，第二个重载方法需要Func < TSource，int，bool> 输入参数，其中int用于索引：
            //IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            //查询语法中的Where子句
            //根据年龄大于12岁小于20岁的学生的姓名筛选出集合。
            var filteredResult = from s in studentList
                                 where s.Age > 12 && s.Age < 20
                                 select s.StudentName;
            //在上面的示例查询中，lambda表达式主体 s.Age > 12 && s.Age < 20 作为评估集合中每个学生的谓词函数传递。Func<TSource, bool>
            
            //IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
            //另外，您还可以将Func类型委托与匿名方法一起使用，作为如下的谓词函数进行传递（输出是相同的）：

            Func<Student, bool> isTeenAger = delegate (Student s) {
                return s.Age > 12 && s.Age < 20;
            };

            var filteredResult1 = from s in studentList
                                 where isTeenAger(s)
                                 select s;

            //你也可以通过Where()方法的重载调用任何与Func形参匹配的方法。
            var filteredResult2 = from s in studentList
                                 where IsTeenAger1(s)
                                 select s;

            //方法语法中的where扩展方法
            //与查询语法不同，您需要将整个lambda表达式作为谓词函数传递，而不仅仅是LINQ方法语法中的表达式主体。
            var filteredResult3 = studentList.Where(s => s.Age > 12 && s.Age < 20);

            //如上所述，Where扩展方法还具有第二重载，其包括集合中当前元素的索引。如果需要，可以在逻辑中使用该索引。
            //以下示例使用Where子句过滤出集合中的奇数元素，仅返回偶数元素。请记住，索引从零开始。

            var filteredResult4 = studentList.Where((s, i) => {
                if (i % 2 == 0) // 如果是偶数
                    return true;

                return false;
            });

            //多个where子句
            //您可以在单个 LINQ 查询中多次调用 Where() 扩展方法。
            //示例：查询语法C＃中的多个where子句
            var filteredResult5 = from s in studentList
                                 where s.Age > 12
                                 where s.Age < 20
                                 select s;
            //示例：C＃中的方法语法多个where子句
            var filteredResult6 = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);
            #endregion

        }

        public static bool IsTeenAger1(Student stud)
        {
            return stud.Age > 12 && stud.Age < 20;
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
