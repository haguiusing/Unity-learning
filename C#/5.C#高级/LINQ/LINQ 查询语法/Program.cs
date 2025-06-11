using Microsoft.VisualBasic;
using System.Linq;
using System.Linq.Expressions;

namespace LINQ_查询语法
{
    internal class Program
    {
        //有两种将LINQ查询写入 IEnumerable 集合 或 IQueryable数据源的基本方法。
        //  1.查询语法或查询表达式语法
        //  2.方法语法或方法扩展语法或连贯语法

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_查询语法");

            #region 知识点一：查询语法
            //获取数据源
            int[] numbers = [0, 1, 2, 3, 4, 5, 6];

            //创建查询
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;

            //执行查询
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            //查询语法：
            //from < range variable--变量范围> in < IEnumerable<T> or IQueryable<T> Collection--数据源>
            //< Standard Query Operators--查询标准操作符> < lambda expression--lambda表达式>
            //< select or groupBy operator--选择或分组操作符> < result formation--结果格式>

            //要记住的要点
            // 1.顾名思义，查询语法与SQL（结构查询语言）语法相同。
            // 2.查询语法以from子句开头，可以以Select或GroupBy子句结尾。
            // 3.使用各种其他运算符，例如过滤，联接，分组，排序运算符来构造所需的结果。
            // 4.隐式类型变量 - var可用于保存LINQ查询的结果。
            #endregion

            #region 知识点二：LINQ 方法语法
            //方法语法（也称为连贯语法）使用Enumerable 或 Queryable静态类中包含的扩展方法，类似于您调用任何类的扩展方法的方式.
            // 字符串集合
            IList<string> stringList = new List<string>() {
                    "C# Tutorials",
                    "VB.NET Tutorials",
                    "Learn C++",
                    "MVC Tutorials" ,
                    "Java"
            };

            // LINQ方法语法
            var result = stringList.Where(s => s.Contains("Tutorials"));
            //                     扩展方法      lambda表达式
            //如上图所示，方法语法包括扩展方法和 Lambda 表达式。在枚举(Enumerable)类中定义的扩展方法 Where ()。

            //如果检查Where扩展方法的签名，就会发现Where方法接受一个 predicate 委托 Func<Student,bool>。
            //这意味着您可以传递任何接受Student对象作为输入参数并返回布尔值的委托函数，如下图所示。lambda表达式用作Where子句中传递的委托。
            //https://www.cainiaojc.com/static/upload/201229/1339391.png

            //下面的示例演示如何将LINQ方法语法查询与IEnumerable <T>集合一起使用。
            // 学生集合
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }};
            // LINQ方法语法找出青少年学生
            var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();

            //要记住的要点
            // 1.顾名思义，方法语法就像调用扩展方法。
            // 2.LINQ方法语法又称Fluent语法（连贯语法），因为它允许一系列扩展方法调用。
            // 3.隐式类型变量 - var可用于保存LINQ查询的结果。
            #endregion

            #region 知识点三：LINQ中的Lambda表达式
            // LINQ方法语法中的Func泛型委托
            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;
            var teenAgerSudents = studentList.Where(isStudentTeenAger).ToList<Student>();
            //简化版本（Enumerable仅提供Func<TSource, bool>，Func<TSource, int, bool>）
            teenAgerSudents = studentList.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();
            //                                | 参数 |      表达式主体       |
            //                                Student         bool

            Func<Student, List<Student>, bool> isStudentTeenAgerAndName = (s, n) => s.Age > n.Count() && s.Age < (n.Count() + 20);
            var teenAgerAndNameSudents = studentList.Where(s => isStudentTeenAgerAndName(s, (List<Student>)studentList)).ToList<Student>();
            //或
            Func<Student, IList<Student>, bool> isStudentTeenAgerAndNameI = (s, n) => s.Age > n.Count() && s.Age < (n.Count() + 20);
            teenAgerAndNameSudents = studentList.Where(s => isStudentTeenAgerAndNameI(s, studentList)).ToList<Student>();

            //LINQ查询语法中的Func委托
            Func<Student, bool> isStudentTeenAgerII = s => s.Age > 12 && s.Age < 20;

            var teenStudents = from s in studentList
                               where isStudentTeenAgerII(s)
                               select s;

            //F:\Unity学习\C#\4.C#进阶\C#进阶\Lesson15_委托与事件_Lambad表达式\Program.cs
            #endregion
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string? StudentName { get; set; }
            public int Age { get; set; }
        }
    }
}
