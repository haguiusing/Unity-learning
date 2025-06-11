namespace LINQ_into_关键字
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_into_关键字");
            //在LINQ查询中使用into关键字可组成一个组或在select子句后继续查询。

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };
            //示例：LINQ中的 into 关键字
            var teenAgerStudents = from s in studentList
                       where s.Age > 12 && s.Age < 20
                       select s
                            into teenStudents
                            where teenStudents.StudentName.StartsWith("B")
                            select teenStudents;
            //在上面的查询中，“into”关键字引入了一个新的范围变量teenStudents，因此第一个范围变量s超出范围。您可以使用新的范围变量在into关键字之后编写进一步的查询。
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
