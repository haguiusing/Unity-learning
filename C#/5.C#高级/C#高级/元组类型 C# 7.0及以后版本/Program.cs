using System;
using System.Linq; // 包含System.Linq命名空间以使用Zip方法

namespace 元组类型
{
    internal class Program
    {
        //在C# 7.0及以后的版本中，元组类型允许你将多个值打包成一个单一的复合值。
        //这使得返回多个值从方法变得简单，也方便了数据的打包和传输。

        static void Main()
        {
            // 创建一个元组并分配给一个变量
            var person = (Name: "Alice", Age: 30);

            // 访问元组的元素
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

            // 解构元组
            var (name, age) = person;
            Console.WriteLine($"Name: {name}, Age: {age}");

            // 使用元组返回多个值从方法
            var (status, message) = TryDoSomething();
            Console.WriteLine($"Status: {status}, Message: {message}");

            // 使用元组的元素初始化对象
            var customer = new Customer
            {
                Name = person.Name,
                Age = person.Age
            };
            Console.WriteLine($"Customer Name: {customer.Name}, Age: {customer.Age}");

            // 使用元组方法Zip比较两个序列
            var numbers = new[] { 1, 2, 3 };
            var words = new[] { "one", "two", "three" };
            var paired = numbers.Zip(words, (number, word) => (Number: number, Word: word));
            foreach (var pair in paired)
            {
                Console.WriteLine($"Number: {pair.Number}, Word: {pair.Word}");
            }
        }

        // 示例方法，返回一个元组
        static (bool status, string message) TryDoSomething()
        {
            // 假设的逻辑...
            return (true, "Operation successful.");
        }
    }

    // 用于存储客户信息的类
    class Customer
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
