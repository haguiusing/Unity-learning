using System.Collections;
using System.Collections.Generic;

namespace Lesson4_简单数据结构类_Hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单数据结构类_Hashtable");

            #region 知识点一：Hashtable的本质
            //Hashtable (又称散列表) 是甚于键的哈希代码组织起来的 键/值对
            //它的主要作用是提高数据查询的效率
            //使用健来访问集合中的元素
            #endregion

            #region 知识点二：申明
            //using System.Collections;
            Hashtable hashtable = new Hashtable();
            //Console.WriteLine("初始容量：" + hashtable.Capacity);  //InitialSize = 3
            Console.WriteLine("初始长度：" + hashtable.Count);  //0
            #endregion

            #region 知识点三：增删查改
            #region 增  "键"与"值"的本质都是Object数组，可以存放任意类型数据
            hashtable.Add(1, "123");
            hashtable.Add("123", 2);
            hashtable.Add(true, false); 
            hashtable.Add(false, false);
            //注意: 不能出现相同键，值无所谓
            //hashtable.Add(1, "123");
            #endregion
            #region 删
            //1.只能通过键去删除
            hashtable.Remove(1);
            //2.删除不存在的键 没反应
            hashtable.Remove(2);
            //3.或者直接清空
            hashtable.Clear();
            #endregion
            #region 查
            //1.通过键查看值
            // 找不到会返回空
            Console.WriteLine(hashtable[1]);
            Console.WriteLine(hashtable[10]);  //null

            //2.查看是否存在
            //根据键检测
            if (hashtable.Contains(1))  //方法1
            {
                Console.WriteLine("存在键为“1”的键值对");
            }
            if (hashtable.ContainsKey(1))  //方法2
            {
                Console.WriteLine("存在键为“1”的键值对");
            }
            //根据值检测
            if (hashtable.ContainsValue(12))  //方法1
            {
                Console.WriteLine("存在值为“12”的键值对");
            }
            #endregion
            #region 改
            //只能改 键对应的值的内容 无法修改键
            hashtable[1] = 100.5f;
            #endregion
            #endregion

            #region 知识点四：遍历
            //得到键值对对数
            Console.WriteLine(hashtable.Count);

            //1.遍历所有键
            foreach(object item in hashtable.Keys)
            {
                Console.Write(item + "——");
                Console.WriteLine(hashtable[item]);
            }
            //2.遇历所有值  只能键找值，无法值找键
            foreach (object item in hashtable.Values)
            {
                Console.Write(item);
            }
            //3.键值对一起遍历
            foreach(DictionaryEntry item in hashtable)
            {
                Console.WriteLine("键：" + item.Key + "值：" + item.Value);
            }
            //4.选代器遍历法
            IDictionaryEnumerator dictionaryEnumerator = hashtable.GetEnumerator();
            bool flag = dictionaryEnumerator.MoveNext();
            while (flag)
            {
                Console.WriteLine("键：" + dictionaryEnumerator.Key + "值：" + dictionaryEnumerator.Value);
                flag = dictionaryEnumerator.MoveNext();
            }
            #endregion

            #region 知识点五：装箱拆箱
            //由于用万物之父来存储数据，自然存在装箱拆
            //当往其中进行值类型存储时就是在装箱
            //当将值类型对象取出来转换使用时，就存在拆箱
            #endregion
        }
    }
}
