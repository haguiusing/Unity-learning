namespace LINQ_限定运算符_All和Any
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_限定运算符_All和Any");

            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };

            List<Student> studentList = new List<Student>() {
               new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
               new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
               new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
               new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
               new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            #region All
            //All方法用于判断集合中的所有元素是否满足指定条件。
            //All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
            bool result = intList.All(x => x > 0);
            bool result2 = studentList.All(x => x.Age > 18);
            #endregion

            #region Any
            //Any方法用于判断集合中是否存在满足指定条件的元素。
            //Any<TSource>(this IEnumerable<TSource> source);
            //Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
            bool result3 = intList.Any(x => x > 3);
            bool result4 = studentList.Any(x => x.Age > 20);
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
