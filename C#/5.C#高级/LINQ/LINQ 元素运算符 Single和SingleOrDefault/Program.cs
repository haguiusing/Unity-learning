namespace LINQ_元素运算符_Single和SingleOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ_元素运算符_Single和SingleOrDefault");
            //元素运算符        描述                    
            //Single            返回集合中的唯一元素，或唯一满足条件的元素。如果Single()在集合中未找到任何元素或一个以上的元素，则抛出InvalidOperationException。                    
            //SingleOrDefault   与Single相同，不同之处在于它返回指定泛型类型的默认值，而不是在找不到指定条件的元素时抛出异常。但是，如果在集合中为指定条件找到了多个元素，它将抛出InvalidOperationException。  

            //Single和SingleOrDefault具有两个重载方法。
            //第一个重载方法不使用任何输入参数，并返回集合中的单个元素。
            //第二种重载方法将lambda表达式作为指定条件的谓词委托，并返回满足指定条件的单个元素。

            //Single()返回集合中的唯一元素，或唯一满足指定条件的元素。
            //如果给定的集合不包含任何元素或包含多个元素，则Single()抛出InvalidOperationException。

            //SingleOrDefault()方法与Single()方法具有相同的作用。
            //唯一的区别是，如果集合为空，不包含一个以上元素或对于指定条件不包含一个或多个元素，则它返回集合数据类型的默认值。

            IList<int> oneElementList = new List<int>() { 7 };
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("oneElementList 中的唯一元素: {0}", oneElementList.Single());
            Console.WriteLine("oneElementList 中的唯一元素: {0}", oneElementList.SingleOrDefault());

            Console.WriteLine("emptyList中的元素: {0}", emptyList.SingleOrDefault());
            Console.WriteLine("intList中唯一小于10的元素: {0}", intList.Single(i => i < 10));

            //下面抛出一个异常
            //Console.WriteLine("intList中唯一的元素: {0}", intList.Single());
            //Console.WriteLine("intList中唯一的元素: {0}", intList.SingleOrDefault());
            //Console.WriteLine("emptyList中唯一的元素: {0}", emptyList.Single());
            //输出：
            //oneElementList中的唯一元素：7
            //oneElementList中的唯一元素：7
            //emptyList中的元素：0
            //intList中唯一小于10的元素：7

            //以下示例代码将引发异常，因为Single()或SingleOrDefault()对于指定条件不返回任何元素或返回多个元素。
            //下面抛出错误，因为列表包含多个小于100的元素
            Console.WriteLine("intList中小于100的元素: {0}", intList.Single(i => i < 100));

            //下面抛出错误，因为列表包含多个小于100的元素
            Console.WriteLine("intList中小于100的元素: {0}", intList.SingleOrDefault(i => i < 100));

            //由于列表包含多个元素，下面抛出错误
            Console.WriteLine("intList中唯一的元素: {0}", intList.Single());

            //由于列表包含多个元素，下面抛出错误
            Console.WriteLine("intList中唯一的元素: {0}", intList.SingleOrDefault());

            //下面抛出错误，因为列表不包含任何元素
            Console.WriteLine("emptyList 中的唯一元素: {0}", emptyList.Single());

            //要记住的要点           
            //  Single()要求集合中只有一个元素。
            //  Single() 当集合中没有任何元素或一个以上元素时，抛出异常。
            //  如果在Single()中指定了一个条件，并且结果不包含任何元素或包含多个元素，则会引发异常。
            //  如果集合或指定条件中没有元素，SingleOrDefault()将返回泛型集合的数据类型的默认值。
            //  如果集合或指定条件中有多个元素，SingleOrDefault()将引发异常。
        }
    }
}
