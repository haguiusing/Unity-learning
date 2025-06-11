namespace LINQ_相等运算符_SequenceEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_相等运算符_SequenceEqual");

            //只有一个相等运算符：SequenceEqual。
            //SequenceEqual方法检查两个集合中的元素数量，每个元素的值和元素的顺序是否相等。
            //bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
            //bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer);
            
            //如果集合包含原始数据类型的元素，则它将比较元素的值和数量，而具有复杂类型元素的集合将检查对象的引用。
            //因此，如果对象具有相同的引用，则将它们视为相等，否则将其视为不相等。

            //下面的示例演示了带有原始数据类型集合的SequenceEqual方法。
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            bool isEqual = strList1.SequenceEqual(strList2); // 返回true
            Console.WriteLine(isEqual);
            //输出：
            //True

            //如果元素的顺序不同，则SequenceEqual()方法返回false。
            IList<string> strList3= new List<string>() { "Two", "One", "Three", "Four", "Three" };

            bool isEqual1 = strList1.SequenceEqual(strList3); // 返回false
            Console.WriteLine(isEqual1);
            //输出：
            //False

            //SequenceEqual扩展方法检查两个对象的引用，以确定两个序列是否相等。这可能会给出错误的结果。看以下示例： 
            Student std = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList1 = new List<Student>() { std };

            IList<Student> studentList2 = new List<Student>() { std };

            bool isEqual2 = studentList1.SequenceEqual(studentList2); // 返回true

            Student std1 = new Student() { StudentID = 1, StudentName = "Bill" };
            Student std2 = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList3 = new List<Student>() { std1 };

            IList<Student> studentList4 = new List<Student>() { std2 };

            isEqual = studentList3.SequenceEqual(studentList4);// 返回false
            //在上面的示例中，studentList1和studentList2包含相同的学生对象std。
            //因此studentList1.SequenceEqual(studentList2)返回true。
            //但是，stdList1和stdList2包含两个单独的学生对象std1和std2。
            //所以现在，即使std1和std2包含相同的值，stdList1.SequenceEqual(stdList2)也将返回false。

            //现在，您可以使用SequenceEqual扩展方法中的上述StudentComparer类作为第二个参数来比较值：
            //示例：C＃使用SequenceEqual比较对象类型元素
            IList<Student> studentList5 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList6 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            // 以下返回true
            bool isEqual3 = studentList5.SequenceEqual(studentList6, new StudentComparer());

            //要记住的要点
            //  SequenceEqual方法比较项目数及其原始数据类型的值。
            //  SequenceEqual方法比较对象对复杂数据类型的引用。
            //  如果要比较两个复杂类型集合的值使用IEqualityComparer类可通过SequenceEqual方法比较两个复杂类型的集合。
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    //要比较两个复杂类型（引用类型或对象）集合的值，需要实现IEqualityComperar<T> 接口，如下所示。
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
