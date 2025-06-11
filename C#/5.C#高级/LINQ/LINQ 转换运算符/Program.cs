using System.Collections;
using System.Collections.Generic;

namespace LINQ_转换运算符
{
    internal class Program
    {
        //LINQ中的Conversion运算符可用于转换序列（集合）中元素的类型。转换运算符分为三种：
        //  As运算符（AsEnumerable和AsQueryable）
        //  To运算符（ToArray，ToDictionary，ToList和ToLookup）
        //  转换运算符（Cast和OfType）

        //下表列出了所有转换运算符。
        //方法             描述
        //AsEnumerable     将输入序列作为 IEnumerable<T> 返回
        //AsQueryable      将IEnumerableto转换为IQueryable，以模拟远程查询提供程序
        //Cast             将非泛型集合转换为泛型集合（IEnumerable到IEnumerable）
        //OfType           基于指定类型筛选集合
        //ToArray          将集合转换为数组
        //ToDictionary     根据键选择器函数将元素放入 Dictionary 中
        //ToList  将集合转换为 List
        //ToLookup    将元素分组到 Lookup<TKey, TElement>
        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }
    
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 转换运算符");

            Student[] studentArray = {
                new() { StudentID = 1, StudentName = "John", Age = 13} ,
                new() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new() { StudentID = 5, StudentName = "Ron" , Age = 15 }};

            ReportTypeProperties(studentArray);
            #region 知识点一：AsEnumerable和AsQueryable方法
            //AsEnumerable和AsQueryable方法分别将源对象转换或转换为IEnumerable <T>或IQueryable <T>。
            Console.WriteLine("AsEnumerable和AsQueryable方法");
            ReportTypeProperties(studentArray.AsEnumerable());
            ReportTypeProperties(studentArray.AsQueryable());
            #endregion

            #region 知识点二：Cast方法
            //Cast的作用与AsEnumerable<T>相同。它将源对象强制转换为IEnumerable<T>。
            Console.WriteLine("Cast方法");
            ReportTypeProperties(studentArray.Cast<Student>());
            //studentArray.Cast<Student>() 与 (IEnumerable<Student>)studentArray 相同，但是 Cast<Student>() 可读性更好。
            #endregion

            #region 知识点三：To运算符：ToArray()，ToList()，ToDictionary()
            //顾名思义，ToArray()，ToList()，ToDictionary()方法的源对象转换分别为一个数组，列表或字典。
            //To 运算符强制执行查询。它强制远程查询提供者执行查询并从底层数据源(如SQL Server数据库)获取结果。
            //C＃中的ToArray和ToList
            IList<string> strList = new List<string>() {
            "One",
            "Two",
            "Three",
            "Four",
            "Three"
            };

            string[] strArray = strList.ToArray<string>();// 将列表转换为数组
            strArray = [.. strList];  //可使用集合表达式简化代码
                                      //使用分布元素 ..在集合表达式中使用内联集合值

            IList<string> list = strArray.ToList<string>(); // converts array into list

            //ToDictionary - 将泛型列表转换为泛型词典--C＃中的 ToDictionary
            IList<Student> studentList = new List<Student>() {
                    new() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                    new() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new() { StudentID = 6, StudentName = "Ron" , Age = 21 }};

            //以下将列表转换成字典，其中StudentId是键
            IDictionary<int, Student> studentDict = new Dictionary<int, Student>(); //IDictionary 与 ToDictionary 的键值对位置不同
            //ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull;
            //  source:IEnumerable<TSource>要从其创建 Dictionary<TKey,TValue> 的 IEnumerable<T>。
            //  keySelector:Func<TSource,TKey>用于从每个元素中提取键的函数。
            //studentDict = studentList.ToDictionary<Student, int>(s => s.StudentID);  //需要提供一个用于提取键的函数

            //ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TKey : notnull;
            //  comparer:IEqualityComparer<TKey>用于比较键的 IEqualityComparer < T >。
            IEqualityComparer<int> comparer = EqualityComparer<int>.Default;  //默认
            //studentDict = studentList.ToDictionary<Student, int>(s => s.StudentID, comparer);   //可以指定一个比较器来比较键。 

            //ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull;
            //TElement:elementSelector 返回的值的类型。
            studentDict = studentList.ToDictionary(s => s.StudentID, s => s);  //可以指定键和值的选择器。

            //ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TKey : notnull;
            IDictionary<int, string> studentNameDict = studentList.ToDictionary(s => s.StudentID, s => s.StudentName+"1", comparer);

            //将一个键值对的集合转换为字典
            List<KeyValuePair<int, Student>> keyValuePairs = new List<KeyValuePair<int, Student>>{
                new KeyValuePair<int, Student>(1, new Student { StudentID = 1, StudentName = "张三" }),
                new KeyValuePair<int, Student>(2, new Student { StudentID = 2, StudentName = "李四" })};
            //ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull;
            studentDict = keyValuePairs.ToDictionary(pair => pair.Key, pair => pair.Value);

            //ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TKey : notnull;
            //可以指定一个比较器来比较键
            IEqualityComparer<int> comparer1 = new StudentIDComparer();  //外部方法实现
            IEqualityComparer<int> customComparer = EqualityComparer<int>.Create(  //内联方法实现
                (x, y) => Math.Abs(x - y) <= 1,     // 自定义相等比较逻辑
                 x => x.GetHashCode());             // 这里简单的使用默认的 GetHashCode 方法，但也可以自定义

            studentDict = keyValuePairs.ToDictionary(pair => pair.Key, pair => pair.Value, comparer1);

            //将一个包含键值对的元组集合转换为字典
            List<(int Key, Student Value)> keyValueTuples = new List<(int, Student)>{
                (1, new Student { StudentID = 1, StudentName = "张三" }),
                (2, new Student { StudentID = 2, StudentName = "李四" })};
            //ToDictionary<TKey, TValue>([TupleElementNames(new[] { "Key", "Value" })] this IEnumerable<(TKey Key, TValue Value)> source) where TKey : notnull;
            studentDict = keyValueTuples.ToDictionary(tuple => tuple.Key, tuple => tuple.Value);

            //ToDictionary<TKey, TValue>([TupleElementNames(new[] { "Key", "Value" })] this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TKey : notnull;
            studentDict = keyValueTuples.ToDictionary(tuple => tuple.Key, tuple => tuple.Value, comparer);

            foreach (var key in studentDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}",key, (studentDict[key] as Student).StudentName);

            foreach (var key in studentNameDict.Keys)
                Console.WriteLine("Key: {0}, Value: {1}", key, studentNameDict[key]);


            #endregion
        }
        #region IEqualityComparer<TKey>? comparer
        //IEqualityComparer<TKey>? comparer 参数用于在将列表转换为字典时自定义键的比较逻辑
        //默认情况下，字典使用键类型的默认相等比较器（EqualityComparer<TKey>.Default）
        //1、有一个字符串键的字典，且希望键的比较是忽略大小写的
        public class CaseInsensitiveStringComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y)
            {
                return x?.ToLower() == y?.ToLower();
            }

            public int GetHashCode(string? obj)
            {
                return obj?.ToLower().GetHashCode() ?? 0;
            }
        }

        //2、一个 Student 对象列表，我们希望根据 StudentID 创建字典，并且我们希望这个 StudentID 的比较逻辑是自定义的
        public class StudentIDComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                // 这里可以插入自定义的逻辑，例如忽略ID的某些位数
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }

        #endregion


        public class Student
        {
            public int StudentID { get; set; }
            public string? StudentName { get; set; }
            public int Age { get; set; }
        }
    }
}
