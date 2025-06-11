namespace LINQ_生成运算符_Empty_Range_Repeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_生成运算符_Empty_Range_Repeat");
            //LINQ包括生成运算符DefaultIfEmpty，Empty，Range＆Repeat。
            //Empty，Range和Repeat方法不是IEnumerable或IQueryable的扩展方法，而只是在静态类Enumerable中定义的静态方法。  

            //方法	描述
            //Empty 返回一个空集合
            //Range 从第一个元素开始，使用指定数量的具有顺序值的元素生成IEnumerable<T> 类型的集合。
            //Repeat 生成具有指定元素数的IEnumerable<T>类型的集合，并且每个元素包含相同的指定值。

            #region Empty
            //IEnumerable<TResult> Empty<TResult>();
            //Empty()与其他LINQ方法一样，该方法不是IEnumerable或IQueryable的扩展方法。它是Enumerable静态类中包含的静态方法。
            //因此，您可以像其他静态方法（如Enumerable.Empty <TResult>()）一样调用它。Empty()方法返回指定类型的空集合，如下所示。
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);
            //输出：
            //Count: 0
            //Type: EmptyPartition`1
            //Count: 0
            //Type: EmptyPartition`1
            #endregion

            #region Range
            //IEnumerable<int> Range(int start, int count);
            //Range()方法返回IEnumerable <T>类型的集合，该集合具有指定数量的元素和从第一个元素开始的顺序值。
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("总计数: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("值，索引位置为 {0} : {1}", i, intCollection.ElementAt(i));
            //输出：
            //总数：10
            //值，索引位置为 0 : 10
            //值，索引位置为 1 : 11
            //值，索引位置为 2 : 12
            //值，索引位置为 3 : 13
            //值，索引位置为 4 : 14
            //值，索引位置为 5 : 15
            //值，索引位置为 6 : 16
            //值，索引位置为 7 : 17
            //值，索引位置为 8 : 18
            //值，索引位置为 9 : 19

            //在上面的示例中，Enumerable.Range(10, 10)创建了具有10个整数元素的集合，其顺序值从10开始。
            //第一个参数指定元素的起始值，第二个参数指定要创建的元素数。
            #endregion

            #region Repeat
            //IEnumerable<TResult> Repeat<TResult>(TResult element, int count);
            //Repeat()方法使用指定数量的元素生成IEnumerable <T>类型的集合，每个元素包含相同的指定值。
            var intCollection1 = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("总数: {0} ", intCollection1.Count());

            for (int i = 0; i < intCollection1.Count(); i++)
                Console.WriteLine("值，索引位置为 {0} : {1}", i, intCollection1.ElementAt(i));
            //输出：
            //总数：10
            //值，索引位置为 0 : 10
            //值，索引位置为 1 : 10
            //值，索引位置为 2 : 10
            //值，索引位置为 3 : 10
            //值，索引位置为 4 : 10
            //值，索引位置为 5 : 10
            //值，索引位置为 6 : 10
            //值，索引位置为 7 : 10
            //值，索引位置为 8 : 10
            //值，索引位置为 9 : 10

            //在上面的示例中，Enumerable.Repeat<int>(10, 10) 创建具有100个重复值为10的整数类型元素的集合.
            //第一个参数指定所有元素的值，第二个参数指定要创建的元素数。
            #endregion
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
