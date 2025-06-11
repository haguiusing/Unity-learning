namespace LINQ_排序运算符_ThenBy和ThenByDescending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_排序运算符_ThenBy和ThenByDescending");
            //ThenBy和ThenByDescending扩展方法用于对多个字段排序。

            //OrderBy()方法根据指定的字段按升序对集合进行排序。
            //在 OrderBy 之后使用 ThenBy()方法按升序对另一个字段上的集合进行排序。
            //Linq 首先根据 OrderBy 方法指定的主字段对集合进行排序，
            //然后根据 ThenBy 方法指定的辅助字段按升序再次对结果集合进行排序。
            //以相同的方式，使用ThenByDescending方法以降序应用二次排序。
            //下面的示例演示如何使用ThenBy和ThenByDescending方法进行第二级排序：

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 },
                new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 }
            };
            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);

            var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);

            //如您在上面的示例中所见，我们首先按排序studentList集合StudentName，然后按排序Age。
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
