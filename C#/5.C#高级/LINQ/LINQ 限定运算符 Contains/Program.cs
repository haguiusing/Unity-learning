using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQ_限定运算符_Contains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_限定运算符_Contains\r\n{");
            //Contains运算符检查集合中是否存在指定的元素，并返回布尔值。

            //Contains()扩展方法有以下两个重载。
            //第一个重载方法需要一个值来检入集合，
            //第二个重载方法需要使用IEqualityComparer类型的附加参数来进行自定义相等性比较。
            //bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);
            //bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer);

            //如上所述，Contains()扩展方法需要一个值作为输入参数进行检查。
            //值的类型必须与泛型集合的类型相同。下面的示例包含检查集合中是否存在10。请注意，int是泛型集合的一种类型。

            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
            bool result = intList.Contains(10);  // 返回 false

            //上面的示例适用于原始数据类型。但是，它不适用于自定义类。看以下示例：
            List<Student> studentList = new List<Student>() {
               new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
               new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
               new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
               new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
               new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };
            //tudent std = new Student() { StudentID = 3, StudentName = "Bill" };
            //ool result = studentList.Contains(std); //returns false  报错

            //正如您在上面的示例中看到的，Contains返回false，即使studentList中存在“Bill”。
            //这是因为Contains扩展方法只比较对象的引用，而不比较对象的实际值。
            //所以要比较student对象的值，需要通过实现IEqualityComparer接口创建一个类，该接口比较两个student对象的值并返回boolean。

            //现在，你可以在Contains扩展方法的第二个重载方法中使用上面的StudentComparer类，
            //该方法接受第二个参数为IEqualityComparer类型，如下所示:

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            bool result1 = studentList.Contains(std, new StudentComparer()); //returns true
                                                                             //因此，必须使用Comparer类才能从自定义类的Contains扩展方法中获得正确的结果。

            //注意事项
            //  All, Any & Contains是LINQ中的限定运算符。
            //  All检查序列中的所有元素是否满足指定条件。
            //  检查序列中是否有任何元素满足指定条件
            //  Contains 操作符检查指定的元素是否存在于集合中。
            //  使用派生 IEqualityOperator 和 Contains 的自定义类检查集合中的对象。
            //  在C#或VB.Net的查询语法中不支持All, Any & Contains。
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    //以下是StudentComparer类，它实现IEqualityComparer<Student> 接口来比较两个Students对象的值：
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID &&
                        x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
