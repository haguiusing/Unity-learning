using System.Collections.Generic;

namespace Lesson8_常用泛型数据结构类_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("常用泛型数据结构类_Dictionary");

            #region 知识点一：Dictionary的本质
            //可以将Dictionary理解为 拥有泛型的Hashtable
            //它也是甚于键的哈希代码组织起来的 键/值对
            //键值对类型从Hashtable的object变为了可以自己制定的泛型
            #endregion

            #region 知识点二：申明
            //需要引用命名空间 using System.Collections.Generic
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Console.WriteLine("初始容量：" + dictionary.EnsureCapacity(18));  //0 3 7 11 17 23
            Console.WriteLine("初始长度：" + dictionary.Count);  //0
            Dictionary<int, string> dictionary1 = new Dictionary<int, string>(){
                {1,"123"},
                {2,"222"},
                {3,"333"}
            };
            #endregion

            #region 知识点三：增删查改
            #region 增
            //注意: 不能出现相同键
            //方法一
            dictionary.Add(1, "123");
            dictionary.Add(2, "222");
            //方法二
            dictionary[3] = "333";  //对于不存在的键，会自动添加；对于已存在的键，会覆盖原值
            //dictionary.Add(3，"123");  //对于已存在的键，会报错
            dictionary.TryAdd(3, "123");   //对于已存在的键，不覆盖原值，返回false；对于不存在的键，添加成功，返回true
            #endregion
            #region 删
            //1.只能通过键去删除
            // 删除不存在键 没反应
            dictionary.Remove(1 , out string value1);  //删除成功，返回true，value1为被删除的值
            dictionary.Remove(4);  //删除失败，返回false

            //2.清空
            dictionary.Clear();
            dictionary.Add(1, "123");
            dictionary.Add(2, "222");
            dictionary.Add(3, "222");
            #endregion
            #region 查
            //1.通过键查看值
            // 找不到直接报错
            Console.WriteLine(dictionary[2]);
            //Console.WriteLine(dictionary[4]);
            Console.WriteLine(dictionary[1]);

            //2.查看是否存在
            // 根据键检测
            if (dictionary.ContainsKey(4))
            {
                Console.WriteLine("存在键为4的键值对");
            }
            if(dictionary.TryGetValue(3, out string value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("不存在值为123的键值对");
            }
            Console.WriteLine("3" + value);

            // 根据值检测
            if (dictionary.ContainsValue("123"))
            {
                Console.WriteLine("存在值为123的键值对");
            }
            #endregion
            #region 改
            Console.WriteLine(dictionary[1]);
            dictionary[1] = "555";
            Console.WriteLine(dictionary[1]);
            #endregion
            #endregion

            #region 知识点四：遍历
            Console.WriteLine("*********");
            Console.WriteLine(dictionary.Count);
            //1.遍历所有键
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item); 
                Console.WriteLine(dictionary[item]);
            }
            //2.遍历所有值
            Console.WriteLine("********");
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            //3.键值对一起遍历
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine("键: "+ item.Key +"值: "+ item.Value);
            }
            #endregion
        }
    }
}
