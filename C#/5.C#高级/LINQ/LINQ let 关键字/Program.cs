using System.Runtime.Intrinsics.Arm;

namespace LINQ_let_关键字
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_let_关键字");
            //let'关键字在查询语法中很有用。它投影了一个新的范围变量，允许复用使用表达式并使查询更具可读性。

            //例如，您可以比较字符串值并选择小写字符串值，如下所示：
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            var lowercaseStudentNames = from s in studentList
                                        where s.StudentName.ToLower().StartsWith("r")
                                        select s.StudentName.ToLower();

            //正如您看到的，ToLower()方法在上面的查询中被多次使用。
            //下面的示例使用“ let”引入新的变量“ lowercaseStudentName”，然后将在每个地方使用该变量。
            //因此，let关键字使查询更具可读性。

            //示例：C＃中的let关键字
            var lowercaseStudentNames1 = from s in studentList
                                        let lowercaseStudentName = s.StudentName.ToLower()
                                        where lowercaseStudentName.StartsWith("r")
                                        select lowercaseStudentName;

            foreach (var name in lowercaseStudentNames1)
                Console.WriteLine(name);
            //输出：
            //ram
            //ron
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
