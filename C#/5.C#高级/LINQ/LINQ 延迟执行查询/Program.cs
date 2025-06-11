namespace LINQ_延迟执行查询
{
    internal class Program
    {
        //延迟执行意味着表达式的求值被延迟到实际需要的时候。它通过避免不必要的执行，极大地提高了性能。

        //延迟执行适用于任何内存集合以及远程LINQ提供程序，例如LINQ-to-SQL，LINQ-to-Entities，LINQ-to-XML等。
        //让我们使用以下示例了解延迟执行：
        //https://www.cainiaojc.com/static/upload/201230/1353020.png --延迟执行
        //在上面的示例中，您可以看到在使用foreach循环进行迭代时查询已实现并执行。这称为延迟执行。
        //当您实际访问集合中的每个对象并对其进行处理时，LINQ会处理studentList集合。

        //要检查每次延迟执行是否每次都返回最新数据，请在foreach循环后再添加一名青少年Ager学生，并检查青少年学生列表：
        //https://www.cainiaojc.com/static/upload/201230/1353021.png --延迟执行
        //正如您看到的，第二个foreach循环再次执行查询并返回最新数据。延迟执行在每次执行时重新计算;这被称为惰性求值。
        //这是延迟执行的主要优点之一:它总是为您提供最新的数据。

        //实现延迟执行
        //您可以使用c#的 yield 关键字为IEnumerable的自定义扩展方法实现延迟执行。
        //例如，您可以为IEnumerable实现自定义扩展方法GetTeenAgerStudents，该方法将返回所有青少年学生的列表。
        public static class EnumerableExtensionMethods
        {
        }
        //请注意，每当GetTeenAgerStudents()被调用时，我们都会在控制台上打印学生姓名。


        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 延迟执行查询");

            //数组不会在每次遍历时重新计算查询
            //获取数据源
            int[] numbers = [0, 1, 2, 3, 4, 5, 6];

            //创建查询
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;
            //执行查询
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            Console.WriteLine();
            numbers = [8, 5, 4, 3, 2, 1, 0];
            //执行查询
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            numbers = numbers.ToList().ToArray();
            //执行查询
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            string[] names = ["zero", "one", "two", "three", "four", "five", "six"];
            var nameQuery = from na in names
                            where na.Length > 3
                            select na;
            //执行查询
            foreach (string name in nameQuery)
            {
                Console.Write("{0,1} ", name);
            }

            names = ["eight", "five", "four", "three", "two", "one", "zero"];
            //执行查询
            foreach (string name in nameQuery)
            {
                Console.Write("{0,1} ", name);
            }

            Console.WriteLine();

            //列表会在每次遍历时重新计算查询
            //对于列表等可变集合，查询结果会根据集合的当前状态进行重新计算
            //现在，您可以使用以下扩展方法：
            IList<Student> studentList = [
                new() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new() { StudentID = 2, StudentName = "Steve", Age = 15 } ,
                new() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new() { StudentID = 4, StudentName = "Ram" , Age = 12 } ,
                new() { StudentID = 5, StudentName = "Ron" , Age = 21 }];

            var teenAgerStudents = from s in studentList
                                   where s.Age >= 12 && s.Age <= 18
                                   select s;

            foreach (Student teenStudent in teenAgerStudents)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);

            studentList.Add(new() { StudentID = 6, StudentName = "Ager", Age = 14 });

            foreach (Student teenStudent in teenAgerStudents)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);

            Console.WriteLine();

            teenAgerStudents = from s in studentList.GetTeenAgerStudents()
                                   select s;

            foreach (Student teenStudent in teenAgerStudents)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);

            //输出：
            //Accessing student John
            //Student Name: John
            //Accessing student Steve
            //Student Name: Steve
            //Accessing student Bill
            //Student Name: Bill
            //Accessing student Ram
            //Accessing student Ron

            //从输出中可以看到，GetTeenAgerStudents()当您使用foreach循环迭代studentList时，将被调用。
            //https://www.cainiaojc.com/static/upload/201230/1353022.png  --延迟执行
            //因此，通过这种方式，您可以使用yield关键字创建自定义方法，以获得延迟执行的优势。
        }
    }
}
