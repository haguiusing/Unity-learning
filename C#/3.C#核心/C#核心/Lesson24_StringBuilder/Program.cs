using System.Text;

namespace Lesson24_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StringBuilder");

            // string是特殊的引用
            //每次重新赋值或者拼接时会分配新的内存空间
            //如果一个字特串经常改变会非常浪费空间

            #region 知识点 StringBuilder
            // C#提供的一个用于处理字符串的公共类
            // 主要解决的问题是: 
            // 修改字符串而不创建新的对象，需要频紧修改和拼接的字符串可以使用它，可以提升性能 
            // 使用前 需要引用命名空间

            #region 初始化 直接指明内容
            StringBuilder sb = new StringBuilder("123123");
            StringBuilder sb2 = new StringBuilder("123123",100);  //容量为100
            Console.WriteLine(sb);
            #endregion

            #region 容量
            //StringBuilder存在一个容量的问题，每次往里面增加时 会自动扩容
            //获得容量
            Console.WriteLine(sb.Capacity);
            ////默认为16现在已经用了6 自动扩容会x2 变成32 64 128....

            //获得字符长度
            Console.WriteLine(sb.Length);
            #endregion

            #region 增删改查替换
            StringBuilder strBui = new StringBuilder("123123123");

            //⭕增
            strBui.Append("444");
            //结果为  "123123123444"
            strBui.AppendFormat("{0}{1}", 555, 666);
            //结果为  "123123123444555666"

            //⭕插入 参数1插入的位置 参数2插入的内容
            strBui.Insert(0, "苏同学");
            //结果为  "苏同学123123123444555666"

            //⭕删  参数1删除开始的位置 参数2删除的个数
            strBui.Remove(0, 3);
            //结果为  "123123123444555666"

            //⭕清空
            strBui.Clear();
            //结果为 ""

            //⭕重新赋值 先清空再增加 
            strBui.Clear();
            strBui.Append("苏同学");

            //⭕查 和数组一样
            Console.WriteLine(strBui[1]);
            //结果为 "同"

            //⭕改 和数组一样
            strBui[0] = '李';
            //strBui结果为 "李同学"

            //⭕替换 参数1被替换的字符  参数2要替换的内容
            strBui.Replace("同学", "老师");
            //strBui结果为 "李老师"
            strBui.Replace("同学", "老师");
            //strBui结果为 "李老师"

            //⭕判断是否相等
            strBui.Equals("李老师");
            //返回为 true
            #endregion

            #endregion

            #region string、stringBuilder、stringBuffer
            //Sting不变性，字符序列不可变，对原管理中实例对象赋值，会重新开一个新的实例对象赋值，
            //新开的实例对象会等待被GCstring拼接要重新开辟空间，
            //因为string原值不会改变，导致GC频繁，性能消耗大

            //C# 没有stringBuffer
            //StringBuffer是字符串可变对象，可通过自带的stringBuer.方法来改变并生成想要的学符串。
            //对原实例对象做拼接的实例，不会生成新的实例对象拼接使用StringBuilder和StringBuffer，
            //只开辟一个内存空间，这是性能优化的点。

            //tringBuilder是字符串可变对象，基本和stringBuilder相同。
            //唯一的区别是StringBuffer是线程安全，相关方法前带synchronized关键字，
            //一般用于多线程StringBulder是非线程安全，所以性能略好，一般用于单线程

            //三者性能比较StringBuilder>StringBuffer>String
            //1.如果要操作少量的数据=string
            //2.单线程操作字符串缓冲区下操作大量数据=StringBulder
            //3.多线程操作字符串缓冲区下操作大量数据=StringBuffer

            #endregion
        }
    }
}
