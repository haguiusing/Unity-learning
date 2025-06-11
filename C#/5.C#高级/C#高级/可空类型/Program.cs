
namespace 可空类型
{
    internal class Program
    {

        //在C#中，可空类型（Nullable Types）允许值类型拥有一个额外的值，即 null。
        //这在处理数据库操作、JSON序列化，或者任何可能需要表示“没有值”的情况时非常有用。

        static void Main()
        {
            // 声明一个可空的整数类型
            int? nullableInt = 10; // 可以赋予一个int值

            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value : "null"); // 输出：10

            // 赋予null值
            nullableInt = null;

            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value : "null"); // 输出：null

            // 使用可空类型的属性和方法
            if (nullableInt.HasValue)
            {
                Console.WriteLine("The value is: " + nullableInt.Value);
            }
            else
            {
                Console.WriteLine("The value is null.");
            }

            // 使用可空类型的条件运算符
            int notNullableInt = nullableInt ?? -1; // 如果nullableInt有值，则使用它，否则使用-1
            Console.WriteLine(notNullableInt); // 输出：-1

            // 与null比较
            if (nullableInt == null)
            {
                Console.WriteLine("nullableInt is null");
            }
            else
            {
                Console.WriteLine("nullableInt is not null");
            }

            // 使用可空类型的数组
            int?[] nullableIntArray = new int?[] { 1, 2, null, 4 };

            foreach (int? item in nullableIntArray)
            {
                if (item.HasValue)
                {
                    Console.WriteLine("Item value: " + item.Value);
                }
                else
                {
                    Console.WriteLine("Item is null");
                }
            }

            // 使用可空类型与数据库操作
            // 假设从数据库获取一个可能为null的值
            int? dbValue = GetNullableIntFromDatabase();

            // 在使用这个值之前检查它是否为null
            if (dbValue.HasValue)
            {
                Console.WriteLine("Database value: " + dbValue.Value);
            }
            else
            {
                Console.WriteLine("Database value is null");
            }
        }

        // 模拟从数据库获取一个可空的整数
        static int? GetNullableIntFromDatabase()
        {
            // 这里只是一个示例，实际中你会从数据库获取这个值
            return null; // 或者返回一个实际的整数值
        }
    }
}
