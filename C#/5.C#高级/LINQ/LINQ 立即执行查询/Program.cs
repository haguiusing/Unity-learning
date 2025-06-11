namespace LINQ_立即执行查询
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_立即执行查询");
            //立即执行与延迟执行相反。它强制LINQ查询执行并立即获取结果。“ To”转换运算符执行给定的查询并立即给出结果。

            //方法语法
            //在下面的示例中，ToList()扩展方法立即执行查询并返回结果。

            //C＃：立即执行
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student { name = "John", age = 18 });
            studentList.Add(new Student { name = "Mary", age = 22 });
            studentList.Add(new Student { name = "Tom", age = 15 });
            studentList.Add(new Student { name = "Jane", age = 20 });

            IList<Student> teenAgerStudents =
                studentList.Where(s => s.age > 12 && s.age < 20).ToList();

            //查询语法
            //C＃：
            var teenAgerStudents1 = from s in studentList
                       where s.age > 12 && s.age < 20
                       select s;
            //上面的查询不会立即执行。您不会找到任何结果，如下所示：
            //https://www.cainiaojc.com/static/upload/201230/1359190.png

            //查询语法不支持“To”运算符，但可以使用ToList()、ToArray()或ToDictionary()立即执行，如下所示：
            IList<Student> teenAgerStudents2 = (from s in studentList
                                               where s.age > 12 && s.age < 20
                                               select s).ToList();

            //您可以在teenAgerStudents集合中查看结果，如下所示：
            //https://www.cainiaojc.com/static/upload/201230/1359191.png
        }
    }
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
