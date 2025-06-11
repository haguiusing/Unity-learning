using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace 集合类
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("集合类");

            #region 知识点一：Array

            //数组（Array）：https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-8.0
            //固定大小：一旦创建，其长度不能改变。
            //零基索引：元素通过零开始的索引访问。
            //底层数据结构: 数组是一系列相同类型元素的集合，存储在连续的内存位置。
            //编译时类型检查：必须指定元素类型，且只能存储该类型的元素。
            //性能：通常在性能要求高的场合使用，因为它们存储的元素类型相同，没有额外的元数据开销。

            int[] intArray = new int[5]; // 初始化一个长度为5的整型数组
            intArray[0] = 10;
            intArray[1] = 20;

            #endregion 知识点一：Array

            #region 知识点二：List<T>

            //List<T>：https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.list-1?view=net-8.0
            //可变大小：可以在运行时动态调整大小。
            //泛型：要求所有元素都是相同类型，提供类型安全。
            //性能：与 ArrayList 相比，由于避免了装箱和拆箱操作，通常性能更好。
            //索引：同样是零基索引。
            //底层数据结构：基于动态数组的实现。
            //功能丰富：提供更多方法，如 AddRange、BinarySearch、FindIndex 等。
            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);

            #endregion 知识点二：List<T>

            #region 知识点三：ArrayList

            //ArrayList：https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.arraylist?view=net-8.0
            //可变大小：可以在运行时动态调整大小。
            //非泛型：不要求元素类型相同，可以存储任何类型的对象。
            //性能：由于存储的是对象的引用，所以会有额外的内存开销。
            //索引：同样是零基索引。
            //底层数据结构：基于动态数组的实现。

            ArrayList arrayList = new ArrayList();
            arrayList.Add(10); // 添加一个整数
            arrayList.Add("Hello"); // 添加一个字符串

            #endregion 知识点三：ArrayList

            #region 知识点四：LinkedList<T>

            //LinkedList<T> :https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0
            //是一个双向链表，适合于频繁插入和删除的场景。
            //索引：同样是零基索引。
            //底层数据结构：基于双向链表的实现。
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(10);
            linkedList.AddLast(20);
            linkedList.AddLast(30);

            #endregion 知识点四：LinkedList<T>

            #region 知识点五：Queue<T>

            //Queue<T>（队列）:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.queue-1?view=net-8.0
            //先进先出（FIFO）的集合。
            //索引：同样是零基索引。
            //底层数据结构：基于动态数组的实现。

            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue(20);
            Queue<int> queue_int = new Queue<int>();
            queue_int.Enqueue(10);
            queue_int.Enqueue(20);

            #endregion 知识点五：Queue<T>

            #region 知识点六：Stack<T>

            //Stack < T >（栈）:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.stack-1?view=net-8.0
            //后进先出（LIFO）的集合。
            //索引：同样是零基索引。
            //底层数据结构：基于动态数组的实现。

            Stack stack = new Stack();
            stack.Push(10);
            stack.Push(20);
            Stack<int> stack_int = new Stack<int>();
            stack_int.Push(10);
            stack_int.Push(20);

            #endregion 知识点六：Stack<T>

            #region 知识点七：Hashtable

            //Hashtable（哈希表）：https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.hashtable?view=net-8.0
            //非泛型的键值对集合。
            //键必须唯一，值可以重复。
            //底层数据结构：基于哈希表的实现。
            //尝试查找不存在的键，则返回null
            //Hashtable是松散类型的数据结构，我们可以添加任何类型的键和值,需要装箱和拆箱操作，性能较差
            //HashTable是经过优化的，访问下标的对象先散列过，所以内部是无序散列的
            //哈希表中的所有成员都是线程安全的
            //哈希表不是通用类型

            Hashtable hashtable = new Hashtable();
            hashtable.Add("key1", "value1");
            hashtable.Add("key2", "value2");

            #endregion 知识点七：Hashtable

            #region 知识点八：HashSet<T>

            //HashSet<T>（哈希集合）:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.hashset-1?view=net-8.0
            //无序且唯一的元素集合。
            //底层数据结构：基于哈希表的实现。

            //主要是设计用来做高性能集运算的，例如对两个集合求交集、并集、差集等。集合中包含一组不重复出现且无特性顺序的元素，HashSet拒绝接受重复的对象。
            //HashSet的一些特性如下:
            //  a.HashSet中的值不能重复且没有顺序。
            //  b.HashSet的容量会按需自动添加。

            HashSet<int> hashSet = new HashSet<int>();
            Console.WriteLine("hashSet.Count: "+ hashSet.EnsureCapacity(0));
            hashSet.Add(10);
            hashSet.Add(20);

            #endregion 知识点八：HashSet<T>

            #region 知识点九：Dictionary<TKey,TValue>

            //Dictionary<TKey,TValue>:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
            //键值对集合。
            //键必须唯一，值可以重复。
            //底层数据结构：基于哈希表的实现。
            //试图找到一个不存在的键，它将返回/抛出异常
            //仅公共静态成员是线程安全的
            //字典是一种通用类型，这意味看我们可以将其与任何数据类型一起使用（创建时，必须同时指定键和值的数据类型）
            //Dictionay是Hashtable的类型安全实现，Keys和Values是强类型的
            //Dictionary遍历输出的顺序，就是加入的顺序

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(10, "Hello");
            dictionary.Add(20, "World");

            #endregion 知识点九：Dictionary<TKey,TValue>

            #region 知识点十：SortedDictionary<TKey,TValue>

            //SortedDictionary<TKey,TValue>(排序字典):https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-8.0
            //键值对集合。
            //键必须唯一，值可以重复。
            //底层数据结构：基于红黑树的实现。

            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            sortedDictionary.Add(10, "Hello");
            sortedDictionary.Add(20, "World");

            #endregion 知识点十：SortedDictionary<TKey,TValue>

            #region 知识点十一：SortedList<TKey,TValue>

            //SortedList<TKey, TValue>(排序列表):https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sortedlist-2?view=net-8.0
            //键值对集合。
            //键必须唯一，值可以重复。
            //排序列表是数组和哈希表的组合。
            //底层数据结构：基于红黑树的实现。

            SortedList sortedList1 = new SortedList();
            sortedList1.Add(10, "Hello");
            sortedList1.Add(20, "World");
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(10, "Hello");
            sortedList.Add(20, "World");

            #endregion 知识点十一：SortedList<TKey,TValue>

            //SortedDictionary<TKey,TValue> 类是检索运算复杂度为 O(log n) 的二叉搜索树，其中 n 是字典中的元素数。
            //它与 SortedList<T> 泛型类相似。这两个类具有相似的对象模型，并且都具有 O(log n) 的检索运算复杂度。
            //这两个类的区别在于内存的使用以及插入和移除元素的速度：
            //1）SortedList 使用的内存比 SortedDictionary 少。
            //2）SortedDictionary 可对未排序的数据执行更快的插入和移除操作：它的时间复杂度为 O(log n)，而SortedList 为 O(n)。
            //3）如果使用排序数据一次性填充列表，则 SortedList 比 SortedDictionary 快。

            #region 知识点十二：SortedSet<T>

            //SortedSet<T>(排序):https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.sortedset-1?view=net-8.0
            //无序且唯一的元素集合，自动去重。
            //底层数据结构：基于红黑树的实现。

            SortedSet<int> sortedSet = new SortedSet<int>();
            sortedSet.Add(10);
            sortedSet.Add(20);

            #endregion 知识点十二：SortedSet<T>

            #region 知识点十三：BitArray

            //BitArray(点阵列):https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.bitarray?view=net-8.0
            //一个固定大小的数组，元素为布尔值。
            //底层数据结构：一个字节数组，每个字节表示一个元素。

            BitArray bitArray = new BitArray(10);
            bitArray[0] = true;
            bitArray[1] = false;

            #endregion 知识点十三：BitArray

            #region 知识点十四：LinkedListNode<T>

            //LinkedListNode<T>:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.linkedlistnode-1?view=net-8.0
            //一个链表节点。
            //底层数据结构：一个链表节点。

            LinkedList<int> linkedList1 = new LinkedList<int>();
            linkedList1.AddFirst(10);
            linkedList1.AddLast(20);
            LinkedListNode<int> node = linkedList1.First;

            #endregion 知识点十四：LinkedListNode<T>

            #region 知识点十五：KeyValuePair<TKey,TValue>

            //KeyValuePair<TKey,TValue>:https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-8.0
            //键值对。
            //底层数据结构：一个键值对。

            KeyValuePair<int, string> keyValuePair = new KeyValuePair<int, string>(10, "Hello");

            #endregion 知识点十五：KeyValuePair<TKey,TValue>

            #region 知识点十六：CollectionExtensions

            //CollectionExtensions:https://docs.microsoft.com/zh-cn/dotnet/api/system.collections.generic.collectionextensions?view=net-6.0
            //为泛型集合提供提供一些扩展方法，用于操作集合。

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            list.AddRange(new List<int>() { 6, 7, 8, 9, 10 });
            list.RemoveRange(2, 3);
            list.RemoveAll(x => x % 2 == 0);
            list.Find(x => x == 3);
            list.FindAll(x => x % 2 == 0);
            list.TrueForAll(x => x % 2 == 0);
            list.ForEach(x => Console.WriteLine(x));
            list.ConvertAll(x => x.ToString());
            list.IndexOf(3);
            list.LastIndexOf(3);
            list.Contains(3);
            list.CopyTo(new int[5], 0);
            list.AsReadOnly();
            list.AsParallel();
            list.AsEnumerable();
            list.ToDictionary(x => x, x => x.ToString());
            list.ToHashSet();
            list.ToList();
            list.ToArray();

            #endregion 知识点十六：CollectionExtensions

            #region 知识点十七：Queue<TElement,TPriority>

            //Queue<TElement,TPriority>:https://docs.microsoft.com/zh-cn/dotnet/api/system.collections.generic.priorityqueue-2?view=net-6.0
            //一个优先级队列。
            //底层数据结构：一个堆。

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(10, 1);
            priorityQueue.Enqueue(20, 2);
            priorityQueue.Dequeue();
            //int value =priorityQueue.TryDequeue(out int value);
            //int value = priorityQueue.Count;
            priorityQueue.Peek();
            priorityQueue.Clear();
            //priorityQueue.Contains(10);
            //priorityQueue.TryPeek(out int value);
            //priorityQueue.TryDequeue(out int value, out int priority);
            priorityQueue.TrimExcess();

            #endregion 知识点十七：Queue<TElement,TPriority>

            //Heap（堆）：https://docs.microsoft.com/zh-cn/dotnet/standard/collections/heap-sort-overview

            #region 性能排序

            //Array\List\ArrayList\LinkedList\Queue\Stack\Hashtable\Dictionary
            //性能排序：
            //插入性能： LinkedList > Dictionary > HashTable > List
            //遍历性能：List > LinkedList > Dictionary > HashTable
            //删除性能： Dictionary > LinkedList > HashTable > List
            //
            //统计：
            //Dictionary，3项性能都在前三的位置
            //LinkedList，3项性能都在前二的位置
            //
            //小结：
            //在修改较频繁，且查找和删除也较多时，首选LinkedList,
            //在主要以删除为主，插入为辅，且查找较少时，首选Dictionary，
            //在查找频繁，而又无需修改的情况下，则首选List。

            //只查找，首选List；
            //插入为主，查找和删除为辅，首选LinkedList；
            //删除为主，查找和插入为辅，首选Dictionary；
            //注意：是插入不是新增，新增大家没多大区别。

            //C#_数据结构_性能对比:https://blog.csdn.net/HadesNyx/article/details/107467003

            #endregion 性能排序
        }
    }
}