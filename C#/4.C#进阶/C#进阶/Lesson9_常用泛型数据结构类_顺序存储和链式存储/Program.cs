using System.Xml.Linq;

namespace Lesson9_常用泛型数据结构类_顺序存储和链式存储
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("常用泛型数据结构类_顺序存储和链式存储");

            #region 知识点一：数据结构
            //数据结构
            //数据结构是计算机存储、组织数据的方式(规则)
            //数据结构是指相互之间存在一种或多种特定关系的数据元素的集合
            //比如自定义的一个 类 也可以称为一种数据结构 自己定义的数据组合规则

            //不要把数据结构想的太复杂
            //简单点理解，就是人定义的 存储数据 和 表示数据之间关系 的规则而已

            //常用的数据结构(前辈总结和制定的一些经典规则)
            //数组、栈、队列、链表、树、图、堆、散列表
            #endregion

            #region 知识点二：线性表
            //线性表是一种数据结构，是由n个具有相同特性的数据元素的有限序列
            //比如数组、ArrayList、stack、Queue、链表等等
            #endregion

            //顺序存储和链式存储 是数据结构中两种 存储结构

            #region 知识点三：顺序存储
            //数组、stack、Queue、List、ArrayList - 顺序存储
            //只是 数组、stack、Queue的组织规则不同而已
            //顺序存储:
            //用一组地址连续的存储单元依次存储线性表的各个数据元素
            #endregion

            #region 知识点四：链式存储
            //单向链表、双向链表、循环链表 - 链式存储
            //链式存储(链接存储):
            //用一组任意的存储单元存储线性表中的各个数据元素
            #endregion

            //方法1：
            //LinkedNode<int> node1 = new LinkedNode<int>(1);
            //LinkedNode<int> node2 = new LinkedNode<int>(2);
            //node1.nextNode = node2;
            //node2.nextNode = new LinkedNode<int>(3);
            //node2.nextNode.nextNode = new LinkedNode<int>(3);

            //方法2
            LinkedList<int> lisk = new LinkedList<int>();
            lisk.Add(1);
            lisk.Add(2);
            lisk.Add(3);
            lisk.Add(4);
            LinkedNode<int> node = lisk.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }

            Console.WriteLine("删除2");
            lisk.Remove(2);
            node = lisk.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }
            Console.WriteLine("删除1");
            lisk.Remove(1);
            node = lisk.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }

            Console.WriteLine("删除4");
            lisk.Remove(4);
            node = lisk.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }

            Console.WriteLine("增加1、2");
            lisk.Add(1);
            lisk.Add(2);
            node = lisk.head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.nextNode;
            }
        }
    }

    #region 知识点五：实现一个简单的单向链表
    /// <summary>
    /// 单向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedNode<T>
    {
        public T Value { get; set; }  //数据
        public LinkedNode<T> nextNode;  //指针,指向下一个节点

        public LinkedNode(T value)
        {
            this.Value = value;
        }
    }
    /// <summary>
    /// 单向链表类 管理节点 添加节点 ...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T>
    {
        public LinkedNode<T> head;  //头节点
        public LinkedNode<T> last;  //尾节点

        public void Add(T value)
        {
            LinkedNode<T> node = new LinkedNode<T>(value);  //添加节点
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;
                last = node;
            }
        }

        public void Remove(T value)  //删除节点
        {
            if (head == null)
            {
                return;
            }
            if (head.Value.Equals(value))
            {
                head = head.nextNode;
                if(head == null)
                {
                    last = null;
                }
                return;
            }
            LinkedNode<T> node = head;  //临时节点
            //当你通过node改变这个对象的data属性时，
            //由于head也指向这个对象，所以通过head访问到的也是修改后的data属性。
            //然而，如果你让node指向一个新的LinkedNode对象，
            //比如node = new LinkedNode<>(anotherValue);
            //那么node和head就不再指向同一个对象了。
            //这时，对node的修改不会影响head。
            while (node.nextNode != null)
            {
                if (node.nextNode.Value.Equals(value))
                {
                    if (node.nextNode.nextNode == null)
                    {
                        last = node;
                    }
                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
                node = node.nextNode;
            }
        }
    }
    #endregion

    #region 知识点六：顺序存储与链式存储的优缺点
    //从增制查改的角度去思考
    //增: 链式存储 计算上 优于顺序存储  (中间插入时链式不用像顺序一样去移动位置)
    //删：链式存储 计算上 优于顺序存储  (中间删除时链式不用像顺序一样去移动位置)
    //查: 顺序存储 使用上 优于链式存储  (数组可以直接通过下标得到元素，链式需要遍历)
    //改: 顺序存储 使用上 优于链式存储  (数组可以直接通过下标得到元素，链式需要遍历)
    #endregion
}
