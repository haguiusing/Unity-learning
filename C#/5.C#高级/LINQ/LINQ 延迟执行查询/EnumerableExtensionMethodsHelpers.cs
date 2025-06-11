using static LINQ_延迟执行查询.Program;

namespace LINQ_延迟执行查询
{
    internal static class EnumerableExtensionMethodsHelpers
    {
        public static IEnumerable<Student> GetTeenAgerStudents(this IEnumerable<Student> source)
        {

            foreach (Student std in source)
            {
                Console.WriteLine("Accessing student {0}", std.StudentName);

                if (std.Age > 12 && std.Age < 20)
                    yield return std;
            }
        }
    }
}