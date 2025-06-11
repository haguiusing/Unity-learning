using System.Collections;

namespace Lesson3_简单数据结构类_Queue
{
    internal class Test
    {
        public Test()
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单数据结构类_Queue");

            #region 知识点一：Queue的本质
            //Queue是一个C#为我们封装好的类
            //它的本质也是object[]数组，只是封装了特殊的存储规则

            //Queue是队列存储容器
            //队列是一种先进先出的数据结构
            //先存入的数据先获取，后存入的数据后获取
            //先进先出
            #endregion

            #region 知识点二：申明
            //System.Collections
            Queue queue = new Queue();
            //Console.WriteLine("初始容量：" + queue.Capacity);  //capacity = 32
            Console.WriteLine("初始长度：" + queue.Count);  //0
            #endregion

            #region 知识点三：增取查改
            #region 增
            queue.Enqueue(1);
            queue.Enqueue("123");
            queue.Enqueue(1.4f);
            queue.Enqueue(new Test());
            #endregion
            #region 取
            //队列中不存在删除的概念
            //只有取的概念 取出先加入的对象
            object o = queue.Dequeue();
            Console.WriteLine(o);
            #endregion
            #region 查
            //1.查看队列头部元素但不会移除
            o = queue.Peek();
            Console.WriteLine(o);

            //2.查看元素是否存在于队列中
            if (queue.Contains(1))
            {
                Console.WriteLine("队列中存在“1”");
            }
            #endregion
            #region 改
            //队列无法改变其中的元素 只能进出队列
            //实在要改 只有清
            queue.Clear();
            #endregion
            #endregion

            #region 知识点四：遍历
            //1.长度
            Console.WriteLine(queue.Count);
            //2.用foreach
            foreach(object item in queue)
            {
                Console.WriteLine(item);
            }
            //3.还有一种遍历方式
            //  将队列转换为object数组
            object[] array = queue.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            //4.循环出列
            while(queue.Count > 0)
            {
                object o1 = queue.Dequeue();
            }
            #endregion

            #region 知识点五：装箱拆箱
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储时就是在装箱
            //当将值类型对象取出来转换使用时，就存在拆箱
            #endregion

            #region 使用场景
            //贪吃蛇

            #endregion
        }
    }
}
