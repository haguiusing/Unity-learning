namespace LINQ_串联运算符_Concat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_串联运算符_Concat");

            //Concat()方法附加两个相同类型的序列，并返回一个新序列（集合）。
            //IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);

            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };

            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
                Console.WriteLine(str);
            //输出：
            //One
            //Two
            //Three
            //Five
            //Six

            IList<int> collection4 = new List<int>() { 1, 2, 3 };
            IList<int> collection5 = new List<int>() { 4, 5, 6 };

            var collection6 = collection4.Concat(collection5);

            foreach (int i in collection6)
                Console.WriteLine(i);
            //输出：
            //1
            //2
            //3
            //4
            //5
            //6

            //C＃或VB.Net中的查询语法不支持Concat运算符。
        }
    }
}
