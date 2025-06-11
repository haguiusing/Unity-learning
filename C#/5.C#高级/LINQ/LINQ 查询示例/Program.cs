using System.Runtime.Intrinsics.Arm;

namespace LINQ_查询示例
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_查询示例");
            //在本节中，您将学习一些复杂的LINQ查询。我们将使用以下学生和标准集合进行查询。
            //样本集合：
            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
                };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            #region 多个Select和where运算符
            var studentNames = studentList.Where(s => s.Age > 18)
                              .Select(s => s)
                              .Where(st => st.StandardID > 0)
                              .Select(s => s.StudentName);
            //输出：
            //Steve
            //Ram

            //以下查询返回仅具有StudentName属性的匿名对象的Enumerable：

            //示例：LINQ查询返回匿名对象的集合
            var teenStudentsName = from s in studentList
                       where s.Age > 12 && s.Age < 20
                       select new { StudentName = s.StudentName };

            teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));
            //输出：
            //John
            //Bill
            #endregion

            #region Group By
            //以下查询返回按StandardID列出的学生组：
            //示例：LINQ Group通过查询-C＃
            var studentsGroupByStandard = from s in studentList
                                          group s by s.StandardID 
                                                into sg
                                                orderby sg.Key
                                                select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            //输出：
            //StandardID 0:
            //Ron
            //StandardID 1:
            //John
            //Steve
            //StandardID 2:
            //Bill
            //Ram

            //输出包括没有任何 StandardID 的 Ron，因此 Ron 属于 StandardID 0。
            //要删除没有StandardID的学生，请在组运算符之前使用where运算符：
            //示例：LINQ Group by查询 - C＃
            var studentsGroupByStandard1 = from s in studentList
                                          where s.StandardID > 0
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };

            //输出：
            //StandardID 1:
            //John
            //Steve
            //StandardID 2:
            //Bill
            //Ram
            #endregion

            #region Left outer join
            //使用左外部联接(Left outer join)显示每个标准下的学生。即使没有分配该标准的学生，也要显示标准名称。
            //示例：C＃LINQ 中Left outer join联接-
            var studentsGroup = from stad in standardList
                                join s in studentList
                                on stad.StandardID equals s.StandardID
                                    into sg
                                select new
                                {
                                    StandardName = stad.StandardName,
                                    Students = sg
                                };

            foreach (var group in studentsGroup)
            {
                Console.WriteLine(group.StandardName);

                group.Students.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            //输出：
            //Standard 1:
            //John
            //Steve
            //Standard 2:
            //Bill
            //Ram
            //Standard 3:

            //在下面的group by查询示例中，我们对组进行排序并只选择StudentName:
            //示例：LINQ 左外部联接 - C＃
            var studentsWithStandard = from stad in standardList
                                       join s in studentList
                                       on stad.StandardID equals s.StandardID
                                       into sg
                                       from std_grp in sg
                                       orderby stad.StandardName, std_grp.StudentName
                                       select new
                                       {
                                           StudentName = std_grp.StudentName,
                                           StandardName = stad.StandardName
                                       };


            foreach (var group in studentsWithStandard)
            {
                Console.WriteLine("{0} is in {1}", group.StudentName, group.StandardName);
            }
            //输出：
            //ohn is in Standard 1
            //teve is in Standard 1
            //ill is in Standard 2
            //am is in Standard 2
            #endregion

            #region 排序
            //以下查询按StandardID和Age的升序返回学生列表。
            var sortedStudents = from s in studentList
                                 orderby s.StandardID, s.Age
                                 select new
                                 {
                                     StudentName = s.StudentName,
                                     Age = s.Age,
                                     StandardID = s.StandardID
                                 };

            sortedStudents.ToList().ForEach(s => Console.WriteLine("Student Name: {0}, Age: {1}, StandardID: {2}", s.StudentName, s.Age, s.StandardID));
            //输出：
            //Student Name: Ron, Age: 21, StandardID: 0
            //Student Name: John, Age: 18, StandardID: 1
            //Student Name: Steve, Age: 21, StandardID: 1
            //Student Name: Bill, Age: 18, StandardID: 2
            //Student Name: Ram, Age: 20, StandardID: 2
            #endregion

            #region 内部联接(Inner Join)
            var studentWithStandard = from s in studentList
                                      join stad in standardList
                                      on s.StandardID equals stad.StandardID
                                      select new
                                      {
                                          StudentName = s.StudentName,
                                          StandardName = stad.StandardName
                                      };

            studentWithStandard.ToList().ForEach(s => Console.WriteLine("{0} is in {1}", s.StudentName, s.StandardName));

            //输出：
            //John is in Standard 1
            //Steve is in Standard 1
            //Bill is in Standard 2
            //Ram is in Standard 2
            #endregion

            #region 嵌套查询
            var nestedQueries = from s in studentList
                                where s.Age > 18 && s.StandardID ==
                                    (from std in standardList
                                     where std.StandardName == "Standard 1"
                                     select std.StandardID).FirstOrDefault()
                                select s;

            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));
            //输出：
            //Steve
            #endregion
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }
    }
    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
