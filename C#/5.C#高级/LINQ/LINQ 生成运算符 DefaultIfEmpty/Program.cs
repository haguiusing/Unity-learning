using System.Linq;

namespace LINQ_生成运算符_DefaultIfEmpty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_生成运算符_DefaultIfEmpty");

            //如果调用DefaultIfEmpty()的给定集合为空，则DefaultIfEmpty()方法将返回一个具有默认值的新集合。

            //IEnumerable<TSource?> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source);
            //IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue);
            //
            //DefaultIfEmpty()的另一个重载方法接受一个值参数，该参数应替换为默认值。看以下示例。
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));
            //输出：
            //Count: 1
            //Value:
            //Count: 1
            //Value: None

            //在上面的示例中，emptyList.DefaultIfEmpty() 返回一个新的字符串集合，其中一个元素的值为null，因为null是string的默认值。
            //另一种方法emptyList.DefaultIfEmpty("None") 返回一个字符串集合，该字符串集合的一个元素的值为“ None”而不是null。

            //下面的示例演示如何在int集合上调用DefaultIfEmpty。
            IList<int> emptyList3 = new List<int>();

            var newList4 = emptyList3.DefaultIfEmpty();
            var newList5 = emptyList3.DefaultIfEmpty(100);

            Console.WriteLine("Count: {0}", newList4.Count());
            Console.WriteLine("Value: {0}", newList4.ElementAt(0));

            Console.WriteLine("Count: {0}", newList5.Count());
            Console.WriteLine("Value: {0}", newList5.ElementAt(0));
            //输出：
            //Count: 1
            //Value: 0
            //Count: 1
            //Value: 100

            //下面的示例演示复杂类型集合的 DefaultIfEmpty() 方法。
            IList<Student> emptyStudentList = new List<Student>();

            var newStudentList1 = emptyStudentList.DefaultIfEmpty(new Student());

            var newStudentList2 = emptyStudentList.DefaultIfEmpty(new Student()
            {
                StudentID = 0,
                StudentName = "Test"
            });

            Console.WriteLine("Count: {0} ", newStudentList1.Count());
            Console.WriteLine("Student ID: {0} ", newStudentList1.ElementAt(0).StudentID);
            Console.WriteLine("Student Name: {0} ", newStudentList1.ElementAt(0).StudentName);

            Console.WriteLine("Count: {0} ", newStudentList2.Count());
            Console.WriteLine("Student ID: {0} ", newStudentList2.ElementAt(0).StudentID);
            Console.WriteLine("Student Name: {0} ", newStudentList2.ElementAt(0).StudentName);
            //输出：
            //Count: 1
            //Student ID: 0
            //Student Name: 
            //Count: 1
            //Student ID: 0
            //Student Name: Test
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
