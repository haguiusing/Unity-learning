using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LINQ_分组运算符_GroupBy和ToLookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 分组运算符 GroupBy和ToLookup");

            //分组运算符的作用与SQL查询的GroupBy子句相同。
            //分组运算符根据给定的键创建一组元素。
            //该组包含在实现IGrouping <TKey，TSource>接口的特殊类型的集合中，其中TKey是键值，
            //在其上已形成该组，TSource是与该分组键值匹配的元素的集合。

            //分组运算符	描述
            //GroupBy       GroupBy操作符根据某个键值返回元素组。每个组由 IGrouping<TKey，TElement> 对象表示。
            //ToLookup      ToLookup 与 GroupBy 相同; 唯一的区别是 GroupBy 的执行被延迟，而 ToLookup 的执行是立即的。

            #region GroupBy
            //GroupBy运算符基于某个键值从给定集合返回一组元素。
            //每个组由IGrouping <TKey，TElement>对象表示。
            //另外，GroupBy方法有8个重载方法，因此您可以根据需要在方法语法中使用适当的扩展方法。

            //LINQ查询可以以GroupBy或Select子句结尾。
            //GroupBy运算符的结果是组的集合。
            //例如，GroupBy从Student集合返回IEnumerable <IGrouping <TKey，Student >>：
            //https://www.cainiaojc.com/static/upload/201229/1608210.png

            //查询语法中的GroupBy
            //下面的示例创建一组年龄相同的学生。年龄相同的学生将在同一集合中，
            //每个分组的集合将具有一个密钥和内部集合，其中密钥将是年龄，内部集合将包括年龄与密钥匹配的学生。

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            var groupedResult = from s in studentList
                                group s by s.Age;

            // 遍历结果（此时 GroupBy 查询才会执行）
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //每组都有一个钥匙 

                foreach (Student s in ageGroup) // 每组都有内部收藏
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
            //输出结果：
            //Age Group: 18
            //Student Name: John
            //Student Name: Bill
            //Age Group: 20
            //Student Name: Ram
            //Age Group: 21
            //Student Name: Steve
            //Student Name: Abram

            //如上例所示，您可以使用“ foreach”循环对组进行迭代，其中每个组都包含一个键和内部集合。
            //下图显示了调试视图中的结果。
            //https://www.cainiaojc.com/static/upload/201229/1608211.png
            //请注意，每个组都有一个执行该组的属性名称。在上面的示例中，
            //我们使用Age来组成一个组，因此每个组将使用“ Age”属性名称而不是“ Key”作为属性名称。

            //方法语法中的GroupBy
            //GroupBy()扩展方法工作在方法的语法一样。
            //在GroupBy扩展方法中为键选择器字段名称指定lambda表达式。
            var groupedResult1 = studentList.GroupBy(s => s.Age);

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key);  //每组都有一个钥匙 

                foreach (Student s in ageGroup)  //每个组都有一个内部集合  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
            #endregion

            #region ToLookup
            //ToLookup与GroupBy相同；唯一的区别是GroupBy执行被推迟，而ToLookup执行是立即执行。
            //GroupBy 是延迟执行的，这意味着它不会立即执行数据处理，而是在遍历结果时才执行。
            //ToLookup 是立即执行的，意味着它会在方法调用时立即执行数据处理，返回一个 Lookup 对象，可以快速进行键值查找。
            //另外，ToLookup仅适用于方法语法。查询语法不支持 ToLookup。

            var lookupResult = studentList.ToLookup(s => s.Age);

            foreach (var group in lookupResult)
            {
                Console.WriteLine("Age Group: {0}", group.Key);  //每组都有一个键 

                foreach (Student s in group)  //每个组都有一个内部集合  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
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
