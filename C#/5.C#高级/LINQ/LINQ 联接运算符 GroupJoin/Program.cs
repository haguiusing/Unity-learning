using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace LINQ_联接运算符_GroupJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_联接运算符_GroupJoin");

            //我们已经在上一节中看到了Join运算符。
            //GroupJoin运算符执行与Join运算符相同的任务，不同之处在于GroupJoin根据指定的组键在组中返回结果。
            //GroupJoin运算符基于键联接两个序列，并通过匹配键将结果分组，然后返回分组的结果和键的集合。

            //GroupJoin需要与Join相同的参数。GroupJoin具有以下两种重载方法：
            //IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);
            //IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer);

            //正如您在第一个重载中看到的，方法接受五个输入参数（除了第一个“this”参数）：1）outer 2）inner 3）outerKeySelector 4）inner keyselector 5）resultSelector。请注意，resultSelector是Func委托类型，它的第二个输入参数是内部序列的IEnumerable类型。

            //方法语法中的GroupJoin
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1, TeacherID = 1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1, TeacherID = 2 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2, TeacherID = 2 },
                new Student() { StudentID = 4, StudentName = "Ram",  StandardID =2, TeacherID = 3 },
                new Student() { StudentID = 5, StudentName = "Ron", TeacherID = 3 }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            IList<Teacher> teacherList = new List<Teacher>() {
                new Teacher() { TeacherID = 1, TeacherName = "Mack" },
                new Teacher() { TeacherID = 2, TeacherName = "Lisa" },
                new Teacher() { TeacherID = 3, TeacherName = "Tom" }
            };

            var groupJoin = standardList.GroupJoin(studentList,  //内部序列
                                            std => std.StandardID, //outerKeySelector 
                                            s => s.StandardID,     //innerKeySelector
                                            (std, studentsGroup) => new // resultSelector 
                                            {
                                                Students = studentsGroup,  //Students 是内部序列的IEnumerable类型
                                                StandarFulldName = std.StandardName  //StandarFulldName 是外部序列的类型
                                            });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }
            //输出：
            //Standard 1:
            //John,
            //Moin,
            //Standard 2:
            //Bill,
            //Ram,
            //Standard 3:

            //在上面的GroupJoin查询示例中，standardList是外部序列，因为查询是从外部序列开始的。
            //GroupJoin方法中的第一个参数是指定内部序列，在上面的示例中为studentList。
            //该方法的第二和第三个参数GroupJoin()是指定一个字段，该字段的值应使用lambda表达式进行匹配，以便在结果中包含element。
            //外部序列的键选择器standard => standard.StandardID指示standardList中每个元素的StandardID字段应与内部序列studentList的键匹配student => student.StandardID。
            //如果两个键字段的值都匹配，则将该元素包括到分组集合studentsGroup中，其中键为StandardID。
            //Join方法中的最后一个参数是用于表达结果的表达式。在上面的示例中，结果选择器包括分组的集合studentGroup和StandardName。

            //下图说明了将内部序列分组到studentsGroup集合中以匹配StandardID键，并且可以使用分组的集合来表示结果。
            //https://www.cainiaojc.com/static/upload/201229/1703410.png
            //结果集将包含具有Students和StandardFullName属性的匿名对象。
            //学生属性将是其StandardID与Standard.StandardID匹配的Student的集合。
            //https://www.cainiaojc.com/static/upload/201229/1703411.png

            //可以使用“ foreach”循环访问结果。每个元素将具有StandardFullName＆Students属性，其中Student将是一个集合。

            //查询语法中的GroupJoin
            //查询语法中的GroupJoin运算符与方法语法稍有不同。
            //它需要一个外部序列，内部序列，键选择器和结果选择器。
            //“ on”关键字用于键选择器，其中“等于”运算符的左侧是outerKeySelector，
            //而“等于”运算符的右侧是innerKeySelector。使用into关键字创建分组的集合。

            //from ... in outerSequence
            //join... in innerSequence
            //on outerKey equals innerKey
            //into groupedCollection
            //select...

            //下面的示例演示了查询语法中的GroupJoin。
            var groupJoin1 = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID
                            into studentGroup
                            select new
                            {
                                Students = studentGroup,
                                StandardName = std.StandardName
                            };

            foreach (var item in groupJoin1)
            {
                Console.WriteLine(item.StandardName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }

            Console.WriteLine("练习");
            //组中包含存放的集合和键的集合
            var groupJoin3 = from tea in teacherList
                             join stu in studentList
                             on tea.TeacherID equals stu.TeacherID
                             into teacherGroup
                             select new
                             {
                                 Students = teacherGroup,
                                 TeachersName = tea.TeacherName
                             };

            foreach (var item in groupJoin3)
            {
                Console.WriteLine(item.TeachersName);

                foreach (var stud in item.Students)
                {
                    Console.WriteLine(stud.StudentName);

                }
            }

            var grounpJoin4 = teacherList.GroupJoin(
                studentList,
                tea => tea.TeacherID,
                stu => stu.TeacherID,
                (tea, studentsGroup) => new  //studentsGroup 是内部序列的IEnumerable类型
                {
                    Students = studentsGroup,  //Students 是内部序列的IEnumerable类型，相当于
                    TeacherName = tea.TeacherName  //TeacherName 是外部序列的类型
                });
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }

        public int TeacherID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
    }
}
