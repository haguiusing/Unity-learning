using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;

namespace LINQ_转换运算符_AsEnumerable_AsQueryable_Cast_ToArray_ToDictionary_ToList_ToLookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ中的Conversion运算符可用于转换序列（集合）中元素的类型。
            //转换运算符分为三种：
            //As运算符（AsEnumerable和AsQueryable），
            //To运算符（ToArray，ToDictionary，ToList和ToLookup）和转换运算符（Cast和OfType）。

            //下表列出了所有转换运算符。
            //方法            描述
            //AsEnumerable    将输入序列作为 IEnumerable<T> 返回
            //AsQueryable     将IEnumerableto转换为IQueryable，以模拟远程查询提供程序
            //Cast            将非泛型集合转换为泛型集合（IEnumerable到IEnumerable）
            //ToArray         将集合转换为数组
            //ToDictionary    根据键选择器函数将元素放入 Dictionary 中
            //ToList          将集合转换为 List
            //ToLookup        将元素分组到 Lookup<TKey, TElement>

            Console.WriteLine("LINQ_转换运算符_AsEnumerable_AsQueryable_Cast_ToArray_ToDictionary_ToList_ToLookup");

            #region AsEnumerable和AsQueryable方法
            //AsEnumerable和AsQueryable方法分别将源对象转换或转换为IEnumerable <T>或IQueryable <T>。

            //请看以下示例：
            //示例：C＃中的AsEnumerable和AsQueryable运算符：

            Student[] studentArray = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            };

            ReportTypeProperties(studentArray);
            ReportTypeProperties(studentArray.AsEnumerable());
            ReportTypeProperties(studentArray.AsQueryable());
            //输出：
            //Compile - time type: Student[]
            //Actual type: Student[]
            //Compile - time type: IEnumerable`1
            //Actual type: Student[]
            //Compile - time type: IQueryable`1
            //Actual type: EnumerableQuery`1

            //如上例所示，AsEnumerable和AsQueryable方法分别将编译时间类型转换为IEnumerable和IQueryable
            #endregion

            #region Cast
            //Cast的作用与AsEnumerable<T>相同。它将源对象强制转换为IEnumerable<T>。
            Student[] studentArray1 = {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            };

            ReportTypeProperties1(studentArray1);
            ReportTypeProperties1(studentArray1.Cast<Student>());
            //输出：
            //Compile - time type: Student[]
            //Actual type: Student[]
            //Compile - time type: IEnumerable`1
            //Actual type: Student[]
            //Compile - time type: IEnumerable`1
            //Actual type: Student[]
            //Compile - time type: IEnumerable`1
            //Actual type: Student[]

            //studentArray.Cast<Student>() 与(IEnumerable<Student>)studentArray 相同，但是 Cast<Student>() 可读性更好。
            #endregion

            #region To运算符：ToArray()，ToList()，ToDictionary()
            //顾名思义，ToArray()，ToList()，ToDictionary()方法的源对象转换分别为一个数组，列表或字典。
            //To 运算符强制执行查询。它强制远程查询提供者执行查询并从底层数据源(如SQL Server数据库)获取结果。

            //示例：C＃中的ToArray和ToList
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Three"
                                            };

            string[] strArray = strList.ToArray<string>();// 将列表转换为数组
            IList<string> list = strArray.ToList<string>(); // converts array into list

            //ToDictionary - 将泛型列表转换为泛型词典：
            //示例：C＃中的 ToDictionary：
            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
                };

            //以下将列表转换成字典，其中StudentId是键
            IDictionary<int, Student> studentDict =
                                            studentList.ToDictionary<Student, int>(s => s.StudentID);
            foreach (var key in studentDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}", key, (studentDict[key] as Student).StudentName);
            //输出：
            //Key: 1, Value: John
            //Key: 2, Value: Steve
            //Key: 3, Value: Bill
            //Key: 4, Value: Ram
            //Key: 5, Value: Ron

            //下图显示了上面示例中的studentDict如何包含一个key-value对，其中key是StudentID，value是Student对象。
            //https://www.cainiaojc.com/static/upload/201230/1152530.png
            #endregion
        }
        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }

        static void ReportTypeProperties1<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }

    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
