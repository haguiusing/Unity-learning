
namespace 记录类型
{
    //记录类型（Record Types）是C# 9.0中引入的一种新的类类型，它提供了一种简洁的方式来定义只包含数据的类，
    //并且自动提供了一些有用的功能，如相等性检查、哈希代码生成和对象初始化。

    // 使用record关键字定义一个记录类型
    public record Person(string Name, int Age);

    // Person记录类型的扩展方法
    public static class PersonExtensions
    {
        public static void Deconstruct(this Person person, out string name, out int age)
        {
            name = person.Name;
            age = person.Age;
        }
    }

    internal class Program
    {
        static void Main()
        {
            // 使用记录类型定义一个Person类
            var person1 = new Person("Alice", 30);
            Console.WriteLine(person1);

            // 使用With方法创建一个新的记录，并修改一个字段
            var person2 = person1 with { Age = 31 };
            Console.WriteLine(person2);

            // 比较两个记录是否相等
            if (person1 == person2)
            {
                Console.WriteLine("person1 and person2 are equal.");
            }
            else
            {
                Console.WriteLine("person1 and person2 are not equal.");
            }

            // 使用Deconstruct方法解构记录
            var (name, age) = person1;
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }
}
