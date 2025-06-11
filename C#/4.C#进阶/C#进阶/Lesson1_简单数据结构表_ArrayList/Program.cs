using System.Collections;

namespace Lesson1_简单数据结构类_ArrayList
{
    class Test
    {

    }
    internal class Program
    {
        //自定义一个整形数组类，该类中有一个整形数组变量
        //为它封装增删查改的方法
        class IntArray
        {
            private int[] array;
            private int capacity;  //房间容量
            private int length;  //当前放了几个房间
            public IntArray(int initialCapacity = 10)
            {
                capacity = initialCapacity;
                array = new int[capacity];
            }
            // 增
            public void Add(int value)
            {
                if (length >= capacity)
                {
                    // 如果数组已满，扩展数组
                    ResizeArray();
                }
                array[length++] = value;
            }

            // 删
            public void Remove(int value)
            {
                for (int i = 0; i < length; i++)
                {
                    if (array[i] == value)
                    {
                        array[i] = 0;  // 将找到的元素设置为0
                        break;
                    }
                }
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                array[index] = 0;  // 将指定位置的元素设置为0
            }

            // 查改
            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= length)
                    {
                        throw new IndexOutOfRangeException("Index out of range");
                    }
                    return array[index];
                }
                set
                {
                    if (index < 0 || index >= length)
                    {
                        throw new IndexOutOfRangeException("Index out of range");
                    }
                    array[index] = value;
                }
            }
            private void ResizeArray()
            {
                capacity *= 2;  // 将容量翻倍
                int[] newArray = new int[capacity];
                Array.Copy(array, newArray, length);
                array = newArray;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("简单数据结构类_ArrayList");

            #region 知识点一：ArrayList的本质
            //ArrayList是一个C#为我们封装好的类
            //它的本质是一个object类型的数组
            //ArrayList类帮助我们实现了很多方法，
            //比如数组的增删查改
            #endregion

            #region 知识点二：申明
            //using System.Collections;
            ArrayList array = new ArrayList();
            Console.WriteLine("初始容量：" + array.Capacity);  //0
            Console.WriteLine("初始长度：" + array.Count);  //0
            #endregion

            #region 知识点三：增删查改
            #region 增 本质是Object数组，可以存放任意类型数据
            array.Add(1);
            Console.WriteLine("初始容量：" + array.Capacity);  //4
            Console.WriteLine("初始长度：" + array.Count);  //1
            array.Add("123");
            array.Add(true);
            array.Add(new object());
            array.Add(new Test());

            ArrayList array1 = new ArrayList();
            array1.Add(123);
            //范围增加（批量增加 把另一个list容器里的内容加到后面）
            array.AddRange(array1);

            //插入
            array.Insert(1, "1234567");
            Console.WriteLine(array[1]);
            #endregion
            #region 删
            //移除指定元素，从头找
            array.Remove(1);
            //移除指定位置的元素
            array.RemoveAt(1);
            //清空
            //array.Clear();
            #endregion
            #region 查
            //得到指定位置的元素
            Console.WriteLine(array[0]);

            //查看元素是否存在
            if (array.Contains("123"))
            {
                Console.WriteLine("存在123");
            }

            //正向查找元素位置
            //能找到返回元素位置，找不到返回-1
            int index=array.IndexOf("123");
            Console.WriteLine(index);

            Console.WriteLine(array.IndexOf(false));

            //反向查找元素位置
            //返回从头开始的索引数
            index = array.LastIndexOf("123");
            Console.WriteLine(index);
            #endregion
            #region 改
            Console.WriteLine(array[0]);
            array[0] = "999";
            Console.WriteLine(array[0]);
            #endregion
            #endregion

            #region 遍历
            //长度
            Console.WriteLine(array.Count);
            //容量  避免产生过多的垃圾
            Console.WriteLine(array.Capacity);
            for (int j = 0; j < array.Count; j++)
            {
                Console.WriteLine(array[j]);
            }

            //迭代器遍历
            foreach(object item in array)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 知识点四：装箱拆箱
            //ArrayList本质上是一个可以自动扩容的object数组
            //由于用万物之父来存储数据，自然存在装箱拆箱。
            //当往其中进行值类型存储时就是在装箱，当将值类型对象取出来转换使用时，就存在拆箱
            //所以ArrayList尽量少用，之后我们会学习更好的数据容器。

            int i = 1;
            array[0] = i;  //装箱

            i = (int)array[0];  //拆线
            #endregion
        }
    }
}
