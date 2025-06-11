using System.Collections.Generic;

namespace Lesson10_常用泛型数据结构类_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("常用泛型数据结构类_LinkedList");

            #region 知识点一：LinkedList的本质
            //LinkedList是一个C#为我们封装好的类
            //它的本质是一个可变类型的泛型双向链表
            //list是泛型数组，LinkedList是线性表
            #endregion

            #region 知识点二：申明
            //需要引用命名空间
            //using System.Collections.Generic
            LinkedList<int> linkedlist = new LinkedList<int>();
            //Console.WriteLine("初始容量：" + linkedlist.Capacity);  //无初始化容量和扩容
            Console.WriteLine("初始长度：" + linkedlist.Count);  //0
            LinkedList<string> Linkedlist2 = new LinkedList<string>();
            //链表对象 需要掌握两个类
            //一个是链表本身LinkedList   一个是链表节点类LinkedListNode
            #endregion

            #region 知识点三：增删查改
            #region 增
            //1.在链表尾部添加元素
            linkedlist.AddLast(10);
            //2.在链表头部添加元素
            linkedlist.AddFirst(20);
            //3.在某一个节点之后添加一个节!
            // 要指定节点 先得得到一个节点
            LinkedListNode<int> n = linkedlist.Find(20);
            linkedlist.AddAfter(n,15);
            //4.在某一个节点之前添加一个节点
            // 要指定节点 先得得到一个节点
            linkedlist.AddBefore(n,11);

            #endregion
            #region 删
            //1.移除头节点
            linkedlist.RemoveFirst();
            //2.移除尾节点
            linkedlist.RemoveLast();
            //3.移除指定节点
            // 无法通过位置直接移除
            linkedlist.Remove(20);
            //4.清空
            linkedlist.Clear();

            linkedlist.AddLast(1);
            linkedlist.AddLast(2);
            linkedlist.AddLast(3);
            linkedlist.AddLast(4);
            #endregion
            #region 查
            //1.头节点
            LinkedListNode<int> first = linkedlist.First;
            //2.尾节点
            LinkedListNode<int> last = linkedlist.Last;
            //3.找到指定值的节点
            // 无法直接通过下标获取中间元素
            // 只有遍历查找指定位置元素
            LinkedListNode<int> node = linkedlist.Find(3); 
            Console.WriteLine(node.Value); 
            node = linkedlist.Find(5);
            //4.判断是否存在
            if (linkedlist.Contains(1))
            {
                Console.WriteLine("链表中存在1");
            }
            #endregion
            #region 改
            //要先得再改(得到节点 再改变其中的值),确保正确更改
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Console.WriteLine(linkedlist.First.Value);
            linkedlist.First.Value = 10;
            Console.WriteLine(linkedlist.First.Value);
            #endregion
            #endregion

            #region 知识点四：遍历
            //1.foreach遍历
            foreach (int item in linkedlist)
            {
                Console.WriteLine(item);
            }
            //2.通过节点遍历
            // 从头到尾
            Console.WriteLine("****************");
            LinkedListNode<int> nowNode = linkedlist.First;
            while (nowNode != null)
            {
                Console.WriteLine(nowNode.Value); 
                nowNode = nowNode.Next;
            }
            // 从尾到头
            Console.WriteLine("****************"); 
            nowNode = linkedlist.Last;
            while (nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Previous;
            }
            #endregion
        }
    }
}
