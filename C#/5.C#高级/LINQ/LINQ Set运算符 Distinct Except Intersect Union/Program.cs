namespace LINQ_Set运算符_Distinct_Except_Intersect_Union
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //下表列出了LINQ中可用的所有Set运算符。
            //集合运算符 用法
            //Distinct 返回集合中的非重复值。
            //Except 返回两个序列之间的差，这意味着一个集合中的元素不出现在第二个集合中。
            //Intersect 返回两个序列的交集，即同时出现在两个集合中的元素。
            //Union 返回两个序列中的唯一元素，这意味着出现在两个序列中的唯一元素。
            Console.WriteLine("LINQ_Set运算符_Distinct_Except_Intersect_Union");

            #region Distinct
            Console.WriteLine("Distinct--------");
            //IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
            //IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer);

            //Distinct扩展方法从给定集合返回一个新的唯一元素集合。

            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strList.Distinct();
            foreach (var str in distinctList1)
                Console.WriteLine(str);
            var distinctList2 = intList.Distinct();
            foreach (var i in distinctList2)
                Console.WriteLine(i);
            //输出：
            //One
            //Two
            //Three
            //1
            //2
            //3
            //4
            //5

            //Distinct扩展方法不比较复杂类型对象的值。为了比较复杂类型的值，需要实现IEqualityComparer<T>接口。
            //现在，您可以在Distinct()方法中传递上述StudentComparer类的对象作为参数来比较Student对象，如下所示。
            //示例：C＃中的Distinct比较对象
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var distinctStudents = studentList.Distinct(new StudentComparer());
            foreach (Student std in distinctStudents)
                Console.WriteLine(std.StudentName);
            //输出：
            //John
            //Steve
            //Bill
            //Ron

            //查询语法中的Distinct运算符
            //C# 查询语法不支持 Distinct 运算符。
            //但是，您可以使用 Distinct 方法查询变量或将整个查询包装到括号中，然后调用 Distinct ()。
            //示例：C＃中的Distinct查询语法
            var query = from std in studentList
                        group std by std.Age into g
                        select new { Age = g.Key, Students = g.Distinct() };
            foreach (var item in query)
            {
                Console.WriteLine("Age: " + item.Age);
                foreach (var std in item.Students)
                {
                    Console.WriteLine(std.StudentName);
                }
            }
            //输出：
            //Age: 18
            //John
            //Age: 15
            //Steve
            //Age: 25
            //Bill
            //Age: 19
            //Ron
            #endregion

            #region Except
            Console.WriteLine("Except--------");
            //Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
            //Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer);

            //Except()方法需要两个集合。
            //它返回一个新集合，其中包含来自第一个集合的元素，该元素在第二个集合（参数集合）中不存在。

            //方法语法中的Except运算符
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);
            foreach (string str in result)
                Console.WriteLine(str);
            //输出：
            //One
            //Two
            //Three

            //Except扩展方法不返回复杂类型集合的正确结果。您需要实现IEqualityComparer接口，以便从Except方法获得正确的结果。
            IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var resultedCol = studentList1.Except(studentList2, new StudentComparer());
            foreach (Student std in resultedCol)
                Console.WriteLine(std.StudentName);
            //输出：
            //John
            //Steve

            //查询语法中的Except运算符
            //C # & VB.Net 查询语法不支持 Except 运算符。
            //但是，您可以对查询变量使用 Distinct 方法，或者将整个查询包装到括号中，然后调用 Except ()。
            var query1 = from std in studentList1
                         group std by std.Age into g
                         select new { Age = g.Key, Students = g.Except(studentList2, new StudentComparer()) };

            foreach (var item in query1)
            {
                Console.WriteLine("Age: " + item.Age);
                foreach (var std in item.Students)
                {
                    Console.WriteLine(std.StudentName);
                }
            }
            //输出：
            //Age: 18
            //John
            //Age: 15
            //Steve
            #endregion

            #region Intersect
            Console.WriteLine("Intersect--------");
            //Intersect扩展方法需要两个集合。它返回一个新集合，其中包含两个集合中都存在的公共元素。看下面的实例。
            IList<string> strList3 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList4 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result1 = strList3.Intersect(strList4);
            foreach (string str in result1)
                Console.WriteLine(str);
            //输出：
            //Four
            //Five

            //Intersect扩展方法不返回复杂类型集合的正确结果。您需要实现IEqualityComparer接口，以便从Intersect方法获得正确的结果。
            //您可以在Intersect扩展方法中通过StudentComparer类，以获取正确的结果：
            var resultedCol1 = studentList1.Intersect(studentList2, new StudentComparer());

            foreach (Student std in resultedCol1)
                Console.WriteLine(std.StudentName);
            //输出：
            //Bill
            //Ron

            //查询语法中的Intersect运算符
            //C # & VB.Net 查询语法不支持 Intersect 运算符。
            //但是，您可以对查询变量使用 Distinct 方法，或者将整个查询包装到括号中，然后调用 Intersect ()。
            var query2 = from std in studentList1
                         group std by std.Age into g
                         select new { Age = g.Key, Students = g.Intersect(studentList2, new StudentComparer()) };

            foreach (var item in query2)
            {
                Console.WriteLine("Age: " + item.Age);
                foreach (var std in item.Students)
                {
                    Console.WriteLine(std.StudentName);
                }
            }
            //输出：
            //Age: 25
            //Bill
            #endregion

            #region Union
            Console.WriteLine("Union--------");
            //IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
            //IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer);

            //Union扩展方法需要两个集合，并返回一个新集合，其中包含两个集合中不同的元素。看下面的实例。
            IList<string> strList5 = new List<string>() { "One", "Two", "three", "Four" };
            IList<string> strList6 = new List<string>() { "Two", "THREE", "Four", "Five" };

            var result2 = strList5.Union(strList6);
            foreach (string str in result2)
                Console.WriteLine(str);
            //输出：
            //One
            //Two
            //three
            //Four
            //THREE
            //Five

            //Union扩展方法不能为复杂类型的集合返回正确的结果。您需要实现IEqualityComparer接口，以便从Union方法中获取正确的结果。
            var resultedCol2 = studentList.Union(studentList2, new StudentComparer());
            foreach (Student std in resultedCol2)
                Console.WriteLine(std.StudentName);
            //输出：
            //John
            //Steve
            //Bill
            //Ron

            //查询语法中的Union运算符
            //C # & VB.Net 查询语法不支持 Union 运算符。
            //但是，您可以对查询变量使用 Distinct 方法，或者将整个查询包装到括号中，然后调用 Union ()。
            var query3 = from std in studentList
                         group std by std.Age into g
                         select new { Age = g.Key, Students = g.Union(studentList2, new StudentComparer()) };

            foreach (var item in query3)
            {
                Console.WriteLine("Age: " + item.Age);
                foreach (var std in item.Students)
                {
                    Console.WriteLine(std.StudentName);
                }
            }
            //输出：
            //Age: 18
            //John
            //Age: 15
            //Steve
            //Age: 25
            //Bill
            //Ron
            //Age: 19
            //Ron
            //Bill
            #endregion

            #region UnionBy
            Console.WriteLine("UnionBy--------");
            //IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector);
            //IEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer);

            //UnionBy()方法需要两个集合，一个键选择器函数，并返回一个新集合，其中包含两个集合中不同的元素。
            //键选择器函数用于从集合元素中提取键，以便对集合元素进行分组。

            //方法语法中的UnionBy运算符
            var numbers1 = new List<int>() { 1, 2, 3, 4, 5 };
            var numbers2 = new List<int>() { 3, 4, 5, 6, 7 };

            var result3 = numbers1.UnionBy(numbers2, x => x);
            foreach (int num in result3)
                Console.WriteLine(num);
            //输出：
            //1
            //2
            //3
            //4
            //5
            //6
            //7

            //UnionBy扩展方法为复杂类型的集合返回正确的结果。
            var result4 = studentList.UnionBy(studentList2, x => x.StudentID);
            foreach (Student std in result4)
                Console.WriteLine(std.StudentName);
            //输出：
            //John
            //Steve
            //Bill

            //查询语法中的UnionBy运算符
            //C # & VB.Net 查询语法不支持 UnionBy 运算符。
            //但是，您可以对查询变量使用 Distinct 方法，或者将整个查询包装到括号中，然后调用 UnionBy ()。
            var query4 = from std in studentList
                         group std by std.Age into g
                         select new { Age = g.Key, Students = g.UnionBy(studentList2, x => x.StudentID) };
            
            foreach (var item in query4)
            {
                Console.WriteLine("Age: " + item.Age);
                foreach (var std in item.Students)
                {
                    Console.WriteLine(std.StudentName);
                }
            }
            //输出：
            //Age: 18
            //John
            //Age: 15
            //Steve
            //Age: 25
            //Bill
            #endregion
        }
    }
    //在下面的示例中，StudentComparer类实现IEqualityComparer<Student>来比较Student<objects。
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID
                    && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }
}
