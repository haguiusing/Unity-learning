namespace Lesson7_常用泛型数据结构类_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("常用泛型数据结构类_List");

            #region 知识点一：List的本质
            //List是一个C#为我们封装好的类
            //它的本质是一个可变类型的泛型数组
            //List类帮助现们实现了很多方法
            //比如泛型数组的增删查改
            #endregion

            #region 知识点二：申明
            //需要引用命名空间（22版以后不用）
            //using System.Collections .Generic
            List<int> list = new List<int>();
            Console.WriteLine("初始容量：" + list.Capacity);  //0
            Console.WriteLine("初始长度：" + list.Count);  //0
            List<string> list2 = new List<string>();
            List<bool> list3 = new List<bool>();
            #endregion

            #region 知识点三：增删查改
            #region 增
            list.Add(1);
            Console.WriteLine("初始容量：" + list.Capacity);  //4
            Console.WriteLine("初始长度：" + list.Count);  //1
            list.Add(2);
            list.Add(3);

            list2.Add("123");

            List<string>listStr =  new List<string>();
            listStr.Add("123");
            list2.AddRange(listStr);

            list.Insert(0, 999);
            Console.WriteLine(list[0]);
            #endregion
            #region 删
            //1.移除指定元素
            list.Remove(1);
            //2.移除指定位置的元素
            list.RemoveAt(1);
            //3.清空
            list.Clear();
            #endregion
            #region 查
            list = new List<int> { 1, 2, 3, 4, 5 };
            //1.得到指定位置的元素
            Console.WriteLine(list[0]);// 输出: 1
            //2.查看元素是否存在
            if (list.Contains(1))
            {
                Console.WriteLine("存在元素 1");
            }
            //3.正向查找元素位置
            // 找到返回位置 找不到 返回-1
            int index = list.IndexOf(5);
            Console.WriteLine(index); // 输出: 4
            //4.反向查找元素位置
            // 找到返回位置 找不到 返回-1
            index = list.LastIndexOf(2);
            Console.WriteLine(index); // 输出: 4
            #endregion
            #region 改
            Console.WriteLine(list[0]);
            list[0] = 99;
            Console.WriteLine(list[0]);
            #endregion
            #endregion

            #region 知识点四：遍历
            //长度
            Console.WriteLine(list.Count);
            //容量
            //避免产生垃圾
            Console.WriteLine(list.Capacity);

            //9、2、3、4、5
            Console.WriteLine("for遍历");
            //正确，实时获取链表大小
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 2)
                    list.Remove(i);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            //错误，链表大小固定
            int listCount = list.Count;
            for (int i = 0; i < listCount; i++)
            {
                if (i == 2)
                    list.Remove(i);
            }
            for (int i = 0; i < listCount; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine("foreach遍历");
            foreach (int item in list)
            {
                if (item == 3)
                    list.Remove(item);
            }
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
