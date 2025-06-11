using System.Collections;

namespace LINQ_过滤运算符_OfType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_过滤运算符_OfType");

            #region OfType 运算符
            //OfType运算符基于将集合中的元素强制转换为指定类型的能力来过滤筛选集合。

            //查询语法中的OfType
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            //方法语法中的OfType
            //您可以在linq方法语法中使用OfType <TResult>()扩展方法，如下所示。
            var stringResult1 = mixedList.OfType<string>();
            #endregion
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
