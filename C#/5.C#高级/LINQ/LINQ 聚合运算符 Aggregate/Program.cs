using System.Runtime.Intrinsics.Arm;
using System.Threading;

namespace LINQ_聚合运算符_Average_Aggregate_Count_LongCount_Max_Min和Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_聚合运算符_Average_Aggregate_Count_LongCount_Max_Min和Sum");
            //聚合运算符对集合中元素的数值属性执行数学运算，如Average、Aggregate、Count、Max、Min和Sum。

            //方法	      描述
            //Aggregate   对集合中的值执行自定义聚合操作。
            //Average     计算集合中数字项的平均值。
            //Count       统计集合中的元素。
            //LongCount   统计集合中的元素。 
            //Max         查找集合中的最大值。
            //Min         查找集合中的最小值。
            //Sum         计算集合中值的总和。

            #region Aggregate
            //聚合方法执行累加操作。聚合扩展方法具有以下重载方法：
            //TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
            //TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
            //TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);
            //C # 或 VB.Net 中的查询语法不支持聚合运算符。
            #region 基本用法

            //下面的示例演示了 Aggregate 方法，该方法返回字符串列表中逗号分隔的元素。
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);
            //输出：
            //One, Two, Three, Four, Five

            //在上面的示例中，Aggregate扩展方法从strList集合返回逗号分隔的字符串。下图说明了以上示例中执行的整个聚合操作。
            //https://www.cainiaojc.com/static/upload/201229/2037040.png
            //如上图所示，strList“ One”的第一项将作为 s1传递，其余项将作为 s2传递。
            //Lambda 表达式(s1，s2) = > s1 + ","+ s2将被视为 s1 = s1 +","+ s1，其中 s1将为集合中的每个项累积。
            //因此，Aggregate 方法将返回逗号分隔的字符串。
            #endregion

            #region 带种子值的聚合方法
            // 学生集合
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                };

            string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                                    "Student Names: ",  // 种子价值
                                                    (str, s) => str += s.StudentName + ",");
            Console.WriteLine(commaSeparatedStudentNames);
            //输出：
            //Student Names: John, Moin, Bill, Ram, Ron,
            //在上面的示例中，Aggregate 方法的第一个参数是“ Student Names: ”字符串，该字符串将与所有学生名一起累积。Lambda 表达式中的逗号将作为第二个参数传递。

            //下面的示例使用 Aggregate 运算符添加所有学生的年龄。
            int SumOfStudentsAge = studentList.Aggregate<Student, int>(0,
                                                            (totalAge, s) => totalAge += s.Age);
            Console.WriteLine("Sum of Students Age: " + SumOfStudentsAge);
            //输出：
            //Sum of Students Age: 100
            #endregion

            #region 带有结果选择器的聚合方法
            //现在，让我们看看第三个重载方法，它需要 Func 委托表达式的第三个参数作为结果选择器，这样您就可以公式化结果。
            string commaSeparatedStudentNames1 = studentList.Aggregate<Student, string, string>(
                                            String.Empty, // 种子值
                                            (str, s) => str += s.StudentName + ",", // 使用种子值返回结果，String.Empty以str的形式进入lambda表达式
                                            str => str.Substring(0, str.Length - 1)); // 删除最后一个逗号的结果选择器

            Console.WriteLine(commaSeparatedStudentNames1);
            //在上面的示例中，我们指定了一个lambda表达式str => str.Substring(0,str.Length - 1 )，该表达式将删除字符串结果中的最后一个逗号。

            //输出：
            //John, Moin, Bill, Ram, Ron
            #endregion
            #endregion

            #region Average
            // 20 种重载方法
            //C # 不支持查询语法中的 Average 运算符。但是VB.Net 支持它.
            //Average 扩展方法计算集合中数值项的平均值。Average 方法返回可空或不可空的十进制值、双值或浮点值。

            //下面的示例演示Agerage方法，该方法返回集合中所有整数的平均值。
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50 };

            var avg = intList.Average();
            Console.WriteLine("Average: {0}", avg);
            //输出：
            //平均值：30

            //您可以将类的 int、 decimal、 double 或 float 属性指定为 lambda 表达式，希望获得其平均值。
            //下面的示例演示复杂类型上的 Average 方法。

            var avgAge = studentList.Average(s => s.Age);
            Console.WriteLine("Average Age of Student: {0}", avgAge);
            //输出：
            //学生的平均年龄：17.4
            #endregion

            #region Count
            //Count运算符返回集合中的元素数或满足给定条件的元素数。
            //Count()扩展方法有以下两种重载：
            //int Count<TSource>(this IEnumerable<TSource> source);
            //int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

            //方法语法中的Count运算符
            var totalElements = intList.Count();
            Console.WriteLine("元素总数: {0}", totalElements);

            var evenElements = intList.Count(i => i % 2 == 0);
            Console.WriteLine("偶数元素: {0}", evenElements);
            //输出：
            //元素总数：5
            //偶数元素：3

            //下面的示例演示Count()复杂类型集合上的方法。
            var totalStudents = studentList.Count();
            Console.WriteLine("学生总人数: {0}", totalStudents);

            var adultStudents = studentList.Count(s => s.Age >= 18);
            Console.WriteLine("成人学生人数: {0}", adultStudents);
            //输出：
            //学生总人数：5
            //成人学生人数：3

            //查询语法中的Count运算符
            //C＃查询语法不支持聚合运算符。但是，您可以将查询括在方括号中并使用聚合函数，如下所示。


            var totalAge = (from s in studentList
                            select s.Age).Count();
            Console.WriteLine("学生总年龄: {0}", totalAge);
            //输出：
            //学生总年龄：100
            #endregion

            #region LongCount
            //LongCount 方法统计集合中的元素。
            //long LongCount<TSource>(this IEnumerable<TSource> source);
            //long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

            //方法语法中的LongCount运算符
            var totalElements1 = intList.LongCount();
            Console.WriteLine("元素总数: {0}", totalElements1);
            //输出：
            //元素总数：5

            //下面的示例演示LongCount()复杂类型集合上的方法。
            var totalStudents1 = studentList.LongCount();
            Console.WriteLine("学生总人数: {0}", totalStudents1);
            //输出：
            //学生总人数：5

            //查询语法中的LongCount运算符
            //C＃查询语法不支持聚合运算符。但是，您可以将查询括在方括号中并使用聚合函数，如下所示。

            var totalAge1 = (from s in studentList
                             select s.Age).LongCount();
            Console.WriteLine("学生总年龄: {0}", totalAge1);
            //输出：
            //学生总年龄：100
            #endregion

            #region Max
            //Max()方法返回集合中最大的数值元素。

            //下面的示例演示原始集合上的Max()方法。
            var largest = intList.Max();
            Console.WriteLine("最大元素: {0}", largest);

            var largestEvenElements = intList.Max(i => {
                if (i % 2 == 0)
                    return i;

                return 0;
            });
            Console.WriteLine("最大偶数: {0}", largestEvenElements);
            //输出：
            //最大元素：50
            //最大偶数：50

            //下面的示例演示复杂类型集合上的Max()方法。
            var oldest = studentList.Max(s => s.Age);
            Console.WriteLine("Oldest Student Age: {0}", oldest);
            //输出：
            //最年长的学生的年龄：21

            //方法语法中的Max()方法
            //Max返回任何数据类型的结果。以下示例显示了如何找到集合中 名称最长 的学生：
            var studentWithLongName = studentList.Max();
            Console.WriteLine("Student ID: {0}, Student Name: {1}", studentWithLongName.StudentID, studentWithLongName.StudentName);
            //输出：
            //Student ID: 3, Student Name: Bill
            //根据上面的实例，要找到名字最长的学生，需要实现IComparable<T>接口，并在CompareTo方法中比较学生名字的长度。
            //现在，您可以使用Max()方法，它将使用CompareTo方法来返回适当的结果。

            //查询语法中的Max运算符
            //C#查询语法不支持Max运算符。但是，它在VB.Net版支持查询语法。
            #endregion

            #region Min
            //Min 方法查找集合中的最小值。

            //同Max()方法一样，Min()方法返回集合中最小的数值元素。
            #endregion

            #region Sum
            //Sum 方法计算集合中值的总和。

            //下面的示例演示原始集合上的Sum()方法。
            var total = intList.Sum();
            Console.WriteLine("总计: {0}", total);

            var sumOfEvenElements = intList.Sum(i => {
                if (i % 2 == 0)
                    return i;

                return 0;
            });
            Console.WriteLine("偶数元素的总计: {0}", sumOfEvenElements);
            //输出：
            //总计：156
            //偶数元素的总计：90

            //下面的示例计算学生集合中所有学生的年龄总和，以及成年学生的人数。
            var sumOfAge = studentList.Sum(s => s.Age);
            Console.WriteLine("学生年龄总和: {0}", sumOfAge);

            var numOfAdults = studentList.Sum(s => {

                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });
            Console.WriteLine("成年学生人数: {0}", numOfAdults);
            //输出：
            //学生年龄总和: 100
            //成年学生人数: 3

            //查询语法中的Sum运算符
            //C# 查询语法中不支持Sum运算符。但是，它在VB.Net版支持查询语法。
            #endregion
        }
    }
    public class Student : IComparable<Student>
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }

        public int CompareTo(Student other)
        {
            if (this.StudentName.Length >= other.StudentName.Length)
                return 1;

            return 0;
        }
    }
}
