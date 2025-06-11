using System.Collections.Generic;
using System;
using System.Linq;

namespace LINQ_元素运算符_ElementAt_ElementAtOrDefault_First_FirstOrDefault_Last_LastOrDefault_Single_SingleOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //元素运算符从序列（集合）中返回特定元素。

            //下表列出了LINQ中的所有Element运算符。
            //元素运算符（方法）	描述
            //ElementAt             返回集合中指定索引处的元素
            //ElementAtOrDefault    返回集合中指定索引处的元素；如果索引超出范围，则返回默认值。
            //First                 返回集合的第一个元素，或满足条件的第一个元素。
            //FirstOrDefault        返回集合的第一个元素，或满足条件的第一个元素。如果索引超出范围，则返回默认值。
            //Last                  返回集合的最后一个元素，或满足条件的最后一个元素
            //LastOrDefault         返回集合的最后一个元素，或满足条件的最后一个元素。如果不存在这样的元素，则返回默认值。
            //Single                返回集合中的唯一元素，或唯一满足条件的元素。
            //SingleOrDefault       返回集合中的唯一元素，或唯一满足条件的元素。如果不存在这样的元素，或者该集合不完全包含一个元素，则返回默认值。
            Console.WriteLine("LINQ_元素运算符_ElementAt_ElementAtOrDefault_First_FirstOrDefault_Last_LastOrDefault_Single_SingleOrDefault");

            #region ElementAt，ElementAtOrDefault
            //ElementAt()方法从给定集合返回指定索引中的元素。如果指定的索引超出集合的范围，则它将抛出“索引超出范围（Index out of range exception）”异常。请注意，索引是从零开始的索引。
            //ElementAtOrDefault()方法还从协作中返回指定索引中的元素，如果指定索引不在集合的范围内，则它将返回数据类型的默认值，而不是引发错误。
            //下面的示例演示原始集合上的ElementAt和ElementAtOrDefault方法。

            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("intList中的第一个元素: {0}", intList.ElementAt(0));
            Console.WriteLine("strList中的第一个元素: {0}", strList.ElementAt(0));

            Console.WriteLine("intList中的第二个元素: {0}", intList.ElementAt(1));
            Console.WriteLine("strList中的第二个元素: {0}", strList.ElementAt(1));

            Console.WriteLine("intList中的第三个元素: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("strList中的第三个元素: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("intList中的第10个元素: {0} - 默认int值",
                            intList.ElementAtOrDefault(9));
            Console.WriteLine("strList中的第十个元素: {0} - 默认字符串值(null)",
                             strList.ElementAtOrDefault(9));


            Console.WriteLine("intList. ElementAt (9)抛出异常: 索引超出范围");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(intList.ElementAt(9));
            //输出：
            //intList中的第一个元素：10
            //strList中的第一个元素：
            //intList中的第二元素：21
            //strList中的第二个元素：   
            //intList中的第三个元素：30
            //strList中的第三个元素：
            //
            //intList中的第十个元素：0 - 默认int值
            //strList中的第十个元素：-默认字符串值(null)
            //-------------------------------------------------------------
            //intList.ElementAt(9)  抛出异常: 索引超出范围

            //正如您在上面示例中所看到的那样，intList.ElementAtOrDefault(9)返回0(默认值为int)，因为intList不包含第十元素。
            //然而，intList.ElementAt(9)以相同的方式抛出“索引超出范围”，(9)返回null，它是字符串类型的默认值。
            //(控制台显示空白空间，因为它不能显示空)

            //因此，建议使用 ElementAtOrDefault 扩展方法来消除运行时异常的可能性。
            #endregion

            #region First，FirstOrDefault
            //First和FirstOrDefault方法从集合中第零个索引返回一个元素，即第一个元素。另外，它返回满足指定条件的元素。
            //First和FirstOrDefault具有两个重载方法。
            //第一个重载方法不使用任何输入参数，并返回集合中的第一个元素。
            //第二个重载方法将lambda表达式作为谓词委托来指定条件，然后返回满足指定条件的第一个元素。
            #endregion

            #region Last，LastOrDefault

            #endregion

            #region Single，SingleOrDefault

            #endregion
        }
    }
}
