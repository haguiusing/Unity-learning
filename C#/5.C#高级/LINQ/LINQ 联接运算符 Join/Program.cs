using System.Runtime.Intrinsics.Arm;

namespace LINQ_联接运算符_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //联接运算符将两个序列（集合）联接并产生结果。

            //联接运算符    用法
            //  Join        Join 运算符根据一个键连接两个序列(集合)并返回结果序列。
            //  GroupJoin   GroupJoin 运算符根据键连接两个序列并返回序列组。它类似于 SQL 的左外联接。

            Console.WriteLine("LINQ_联接运算符_Join");

            #region Join
            //Join运算符对两个集合（内部集合和外部集合）进行操作。
            //它返回一个新集合，其中包含两个集合中满足指定表达式的元素。
            //它与SQL的内部(inner join)联接相同。

            //Join方法语法
            //Join扩展方法有两个重载，如下所示。
            // IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
            // IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)

            //正如您在第一个重载中看到的，方法接受五个输入参数（除了第一个“this”参数）：
            //  1）outer
            //  2）inner
            //  3）outerKeySelector
            //  4）inner keyselector
            //  5）resultSelector。

            //让我们举一个简单的实例。下面的示例连接两个字符串集合，并返回两个集合中都包含匹配字符串的新集合。
            IList<string> strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four"
            };

            IList<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };

            var innerJoin = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);
            //输出结果:
            //One
            //Two

            //现在，让我们了解使用下面的Student和Standard类的join方法，
            //其中Student类包括与Standard类的StandardID相匹配的StandardID。

            //下面的示例演示LINQ Join查询。

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var innerJoin1 = studentList.Join(// outer 外序列 
                                  standardList,  // inner 内部序列 
                                  student => student.StandardID,    // outerKeySelector 外键选择器
                                  standard => standard.StandardID,  // innerKeySelector 内键选择器
                                  (student, standard) => new  // resultSelector 结果选择器
                                  {
                                      StudentName = student.StudentName,
                                      StandardName = standard.StandardName
                                  });
            //下图说明了上面示例中的Join运算符的各个部分。
            //https://www.cainiaojc.com/static/upload/201229/1640200.png

            //在上面的联接查询示例中，studentList是外部序列，因为查询从它开始。
            //Join方法中的第一个参数用于指定内部序列，在上面的示例中该序列为standardList。
            //Join方法的第二个和第三个参数用于指定一个字段，该字段的值应使用lambda表达式匹配，以便将元素包括在结果中。
            //外部序列的键选择器 student => student.StandardID指示StudentList的每个元素的标准ID字段应该与内部序列 standard => standard.StandardID 的键匹配。
            //如果两个键字段的值都匹配，则将该元素包括到结果中。

            //Join方法中的最后一个参数是用于表达结果的表达式。在上面的示例中，结果选择器包括两个序列的StudentName和StandardName属性。

            //两个序列（集合）的StandardID键必须匹配，否则该项将不包括在结果中。
            //例如，Ron不与任何标准关联，因此Ron不包含在结果集合中。
            //上述示例中的innerJoinResult在执行后将包含以下元素：
            foreach (var item in innerJoin1)
            {
                Console.WriteLine(item.StudentName + " - " + item.StandardName);
            }
            //John - Standard 1
            //Moin - Standard 1
            //Bill - Standard 2
            //Ram - Standard 2

            //联接查询语法
            //查询语法中的连接运算符的工作原理与方法语法略有不同。
            //它需要外部序列、内部序列、键选择器和结果选择器“on”关键字用于键选择器，
            //其中“equals”运算符的左侧是outerKeySelector，“equals”运算符的右侧是innerKeySelector。

            //from ... in outerSequence
            //join... in innerSequence
            //on outerKey equals innerKey
            //select...

            //下面的查询语法中的Join运算符示例，如果Student.StandardID和Standard.StandardID匹配，则返回来自studentList和standardList的元素的集合。

            var innerJoin2 = from s in studentList // 外序列
                            join st in standardList //内部序列 
                            on s.StandardID equals st.StandardID // 键选择器 
                            select new
                            { // 结果选择器 
                                StudentName = s.StudentName,
                                StandardName = st.StandardName
                            };
            //使用equals运算符匹配查询语法中的键选择器。==无效。
            #endregion

            //上述两种方法源码都通过下面这个内部方法实现
            //IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)

            //要记住的要点
            //  Join 和 GroupJoin是连接运算符
            //  Join 类似于SQL的内部连接。它返回一个新集合，其中包含两个键匹配的集合中的公共元素。
            //  Join 对内部序列和外部序列这两个序列进行运算，并生成结果序列。
            //  Join 查询语法
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
