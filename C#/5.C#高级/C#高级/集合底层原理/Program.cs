using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace 集合底层原理
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("集合底层原理");

            #region 链表
            //底层数据结构是泛型数组 T[]
            #region 非泛型接口
            #region IEnumerator
            //非泛型的迭代器接口，定义了访问和遍历聚合对象中各个元素的方法
            //object Current { get; }   //获取当前元素
            //bool MoveNext();          //移动到下一个元素
            //void Reset();             //重置迭代器
            #endregion

            #region IEnumerable
            //非泛型的聚合对象接口(创建迭代器对象的接口),提供创建迭代器的方法
            //IEnumerator GetEnumerator();  //返回循环访问集合的枚举器。
            #endregion

            #region ICollection : IEnumerable
            //非泛型的集合接口，继承了IEnumerable接口，扩展了非泛型集合的基本操作
            //定义所有非泛型集合的大小、枚举器和同步方法。
            //int Count { get; }             //获取元素个数
            //bool IsSynchronized { get; }   //获取一个值，该值指示是否同步对 ICollection 的访问（线程安全）。
            //object SyncRoot { get; }       //获取一个对象，该对象是当前集合的同步根。获取可用于同步对ICollection的访问的对象。

            //void CopyTo(Array array, int index);  //从特定 Array 索引开始，将 ICollection 的元素复制到 Array。
            //GetEnumerator()	                    //返回循环访问集合的枚举器。(继承自 IEnumerable)
            #endregion

            #region IList : ICollection
            //非泛型的列表接口，继承了ICollection接口，扩展了非泛型列表的基本操作
            //定义所有非泛型列表的索引访问、插入、删除、搜索等操作。

            //object? this[int index] { get; set; }   //获取或设置指定索引处的元素。
            //bool IsFixedSize { get; }     //获取一个值，该值指示 IList 是否具有固定大小。
            //bool IsReadOnly { get; }      //获取一个值，该值指示 IList 是否为只读。
            //int Count { get; }             //获取 ICollection中包含的元素数。(继承自 ICollection)
            //bool IsSynchronized { get; }   //获取一个值，该值指示是否同步对 ICollection 的访问（线程安全）。(继承自 ICollection)
            //object SyncRoot { get; }       //获取一个对象，该对象是当前集合的同步根。获取可用于同步对ICollection的访问的对象。(继承自 ICollection)

            //int Add(object? value);        //将一个新元素添加到 IList 中，并返回其索引。
            //void Clear();                  //清空 IList。
            //bool Contains(object? value);  //确定 IList 是否包含指定的元素。
            //int IndexOf(object? value);    //返回 IList 中第一个匹配项的索引。
            //void Insert(int index, object? value);    //将一个新元素插入到 IList 中指定索引处。
            //void Remove(object? value);   //从 IList 中移除指定元素。
            //void RemoveAt(int index);     //从 IList 中移除指定索引处的元素。
            #endregion
            #endregion

            #region List<T>
            #region IDisposable
            //释放非托管资源，并通知垃圾回收器不再调用终结器（析构器）来释放非托管资源。
            //void Dispose();         //释放非托管资源
            #endregion

            #region IEnumerator<out T> : IEnumerator, IDisposable
            //T Current { get; }      //获取当前元素
            //bool MoveNext();          //移动到下一个元素(继承自 IEnumerator)
            //void Reset();             //重置迭代器(继承自 IEnumerator)
            //void Dispose();           //释放非托管资源(继承自 IDisposable)
            #endregion
            #endregion

            #region IEnumerable<out T> : IEnumerable
            //泛型的聚合对象接口(创建迭代器对象的接口),提供创建迭代器的方法
            //IEnumerator<T> GetEnumerator();  //返回循环访问集合的枚举器。
            #endregion

            #region ICollection<T> : IEnumerable<T>
            //泛型的集合接口，继承了IEnumerable<T>接口，扩展了泛型集合的基本操作
            //int Count { get; }             //获取元素个数
            //bool IsReadOnly { get; }       //获取一个值，该值指示 ICollection 是否为只读。

            //void Add(T item);       //将项添加到 ICollection<T>。
            //void Clear();           //清空 ICollection<T>。
            //bool Contains(T item);  //确定 ICollection<T> 是否包含指定的元素。
            //void CopyTo(T[] array, int arrayIndex);  //从特定 Array 索引开始，将 ICollection<T> 的元素复制到 Array。
            //bool Remove(T item);   //从 ICollection<T> 中移除指定元素。
            //IEnumerator<T> GetEnumerator();  //返回循环访问集合的枚举器。(继承自 IEnumerable<T>)
            #endregion

            #region IList<T> : ICollection<T>
            //泛型的列表接口，继承了ICollection<T>接口，扩展了泛型列表的基本操作
            //T this[int index] { get; set; }  //获取或设置指定索引处的元素。

            //int IndexOf(T item);             //返回 IList 中第一个匹配项的索引。
            //void Insert(int index, T item);  //将一个新元素插入到 IList 中指定索引处。
            //void RemoveAt(int index);        //从 IList 中移除指定索引处的元素。
            #endregion

            #region IReadOnlyCollection<out T> : IEnumerable<T>
            //泛型的只读集合接口，继承了IEnumerable<T>接口，扩展了泛型只读集合的基本操作
            //int Count { get; }               //获取元素个数
            //IEnumerator<T> GetEnumerator();  //返回循环访问集合的枚举器。(继承自 IEnumerable<T>)
            #endregion

            #region IReadOnlyList<out T> : IReadOnlyCollection<T>
            //泛型的只读列表接口，继承了IReadOnlyCollection<T>接口，扩展了泛型只读列表的基本操作
            //T this[int index] { get; }        //获取指定索引处的元素。
            #endregion

            #region 新属性
            //Capacity     //获取或设置内部数据结构可以在不调整大小的情况下保留的元素总数。
            #endregion
            #region 新方法
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.list-1?view=net-8.0#methods
            #endregion
            #endregion

            #region ArrayList数组
            //底层数据结构是object?[] _items
            //IList
            #region ICloneable
            //ICloneable接口，提供对象的复制功能。
            //object Clone();  //返回对象的浅表副本。
            #endregion

            #region 新属性
            //Capacity	    //获取或设置 ArrayList 可包含的元素数。

            //注解
            //Capacity 是 可以存储的元素 ArrayList 数。 Count 是 实际位于 中的 ArrayList元素数。
            //Capacity 始终大于或等于 Count。 如果在 Count 添加元素时超出 Capacity ，则通过在复制旧元素和添加新元素之前重新分配内部数组来自动增加容量。
            #endregion
            #region 新方法
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.arraylist?view=net-8.0#methods
            #endregion
            #endregion

            #region LinkedListNode<T>链表节点
            //LinkedList<T>? List //获取 LinkedList<T> 所属的 LinkedListNode < T >。
            //LinkedListNode<T>? Next //获取 LinkedList<T> 中的下一个节点。
            //LinkedListNode<T>? Previous //获取 LinkedList<T> 中的上一个节点。
            //T Value //获取节点中包含的值。
            //ref T ValueRef  //获取对节点所持有值的引用。

            //void Invalidate() //使节点无效。
            #endregion

            #region LinkedList<T>双向链表
            //底层数据结构是LinkedListNode的Value
            //ICollection<T>, ICollection, IReadOnlyCollection<T>
            #region ISerializable
            //允许对象通过二进制和 XML 序列化控制其自己的序列化和反序列化。
            //void GetObjectData(SerializationInfo info, StreamingContext context);  //已过时.将对象数据写入 SerializationInfo 对象。
            #endregion

            #region IDeserializationCallback
            //指示在完成整个对象图形的反序列化时通知类。 使用 XmlSerializer进行反序列化时，不会调用此接口。
            //void OnDeserialization(object? sender);  //在整个对象图形已经反序列化时运行。
            #endregion

            #region 新属性
            //int Count   //获取双向链表中的元素数。
            //LinkedListNode<T>? First   //获取双向链表中的第一个节点。
            //LinkedListNode<T>? Last    //获取双向链表中的最后一个节点。
            #endregion
            #region 新方法
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.linkedlist-1?view=net-8.0#methods
            #endregion
            #endregion

            #region Queue队列
            //底层数据结构 object?[]  T[]
            //ICollection, IEnumerable, ICloneable
            //IEnumerable<T>, ICollection, IReadOnlyCollection<T>

            #region 新属性

            #endregion
            #region 新方法
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.queue-1?view=net-8.0#methods
            #endregion
            #endregion

            #region Stack栈
            //底层数据结构 object?[]  T[]
            //ICollection, IEnumerable, ICloneable
            // IEnumerable<T>, System.Collections.ICollection, IReadOnlyCollection<T>

            #region 新属性

            #endregion
            #region 新方法
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.stack-1?view=net-8.0#methods
            #endregion
            #endregion

            #region Hashtable哈希表
            //底层数据结构 struct Bucket
            //IDictionary, ISerializable, IDeserializationCallback, ICloneable
            //ICollection<T>, ISet<T>, IReadOnlyCollection<T>, IReadOnlySet<T>, ISerializable, IDeserializationCallback

            //闭散列法是把所有的元素存储在哈希表数组中。当发生冲突时，在冲突位置的附近寻找可存放记录的空单元。

            #region ISet<T>
            //为集的抽象提供基接口。
            //bool Add(T item);  //将元素添加到当前集，并返回一个值，该值指示元素是否已成功添加。
            //void ExceptWith(IEnumerable<T> other);  //从当前集中删除指定集合中的所有元素。
            //void IntersectWith(IEnumerable<T> other);  //修改当前集，使其仅包含指定集合中的元素。
            //bool IsProperSubsetOf(IEnumerable<T> other);  //确定当前集是否为指定集合的正确（严格）子集。
            //bool IsProperSupersetOf(IEnumerable<T> other);  //确定当前集是否为指定集合的正确（严格）超集。
            //bool IsSubsetOf(IEnumerable<T> other);  //确定集是否为指定集合的子集。
            //bool IsSupersetOf(IEnumerable<T> other);  //确定当前集是否为指定集合的超集。
            //bool Overlaps(IEnumerable<T> other);  //确定当前集是否与指定的集合重叠。
            //bool SetEquals(IEnumerable<T> other);  //确定当前集和指定的集合是否包含相同的元素。
            //void SymmetricExceptWith(IEnumerable<T> other);  //修改当前集，使其仅包含当前集或指定集合中存在的元素，但不包含两者。
            //void UnionWith(IEnumerable<T> other);  //修改当前集，使其包含当前集中、指定集合或两者中存在的所有元素。
            #endregion

            #region 新属性

            #endregion
            #region 新方法

            #endregion
            #endregion

            #region HashSet<T>哈希集合
            //ICollection<T>, ISet<T>, IReadOnlyCollection<T>, IReadOnlySet<T>, ISerializable, IDeserializationCallback
            //https://www.cnblogs.com/louzixl/p/15996332.html
            #region 新属性
            //Count	获取集合中现有元素的总数
            #endregion
            #region 新方法
            //bool Add (T item);	添加指定元素，返回bool值指示是否执行成功
            //bool Remove(T item); 移除指定元素，返回bool值表示是否执行成功
            //void Clear(); 移除所有元素
            //bool Contains(T item); 判断是否包含指定元素
            //void CopyTo(T[] array); 复制元素到数组中
            //void ExceptWith(IEnumerable<T> other); 移除当前集合中指定子集的元素
            //void IntersectWith(IEnumerable<T> other); 修改当前集合元素为当前集合与指定集合的交集
            //void UnionWith(IEnumerable other); 修改当前集合元素为当前集合与指定集合的并集
            //bool IsProperSubsetOf(IEnumerable other); 判断当前集合是否为指定集合的真子集
            //bool IsProperSupersetOf(IEnumerable other); 判断当前集合是否为指定集合的真超集
            //bool IsSubsetOf(IEnumerable other); 判断当前集合是否为指定集合的子集
            //bool IsSupersetOf(IEnumerable other); 判断当前集合是否为指定集合的超集
            //bool Overlaps(IEnumerable other); 判断当前集合是否与指定集合至少有一个公共元素
            //bool SetEquals(IEnumerable other); 判断当前集合是否与指定集合包含相同的元素
            //bool TryGetValue(T equalValue, out T actualValue); 搜索给定值，并返回所找到的相等值
            //void TrimExcess(); 将当前集合的容量设置为它包含的实际元素数
            #endregion
            #endregion

            #region 字典
            //对于Dictionary的实现原理，其中有两个关键的算法，https://zhuanlan.zhihu.com/p/96633352 | https://www.bilibili.com/video/BV1fC4y1y7L2/?spm_id_from=333.337.search-card.all.click&vd_source=d097c8a842fe6434d37d10a01926a6b3
            //一个是Hash算法，
            //一个是用于应对Hash碰撞冲突解决算法。
            //底层数据结构 struct Entry
            //ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary, IDeserializationCallback, ISerializable
            #region Dictionary<TKey, TValue>
            #region IDictionary
            //键/值对的非泛型集合的基本接口
            //object? this[object key] { get; set; }  //获取或设置具有指定键的元素。
            //bool IsFixedSize { get; }  //获取一个值，该值指示 IDictionary 对象是否具有固定大小。
            //bool IsReadOnly { get; }  //获取一个值，该值指示 IDictionary 对象是否为只读。
            //ICollection Keys { get; }  //获取包含 IDictionary 对象的键的 ICollection 对象。
            //ICollection Values { get; }  //获取一个 ICollection 对象，该对象包含 IDictionary 对象中的值。

            //void Add(object key, object? value);  //将具有提供的键和值的元素添加到 IDictionary 对象。
            //void Clear();  //从 IDictionary 对象中删除所有元素。
            //bool Contains(object key);  //确定 IDictionary 对象是否包含具有指定键的元素。
            //IDictionaryEnumerator GetEnumerator();  从特定 Array 索引开始，将 ICollection 的元素复制到 Array。(继承自 ICollection)
            //void Remove(object key);  //从 IDictionary 对象中删除具有指定键的元素。
            #endregion

            #region IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>,
            //TValue this[TKey key] { get; set; }
            //ICollection<TKey> Keys { get; }
            //ICollection<TValue> Values { get; }

            //void Add(TKey key, TValue value);
            //bool ContainsKey(TKey key);
            //bool Remove(TKey key);
            //bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);

            #endregion

            #region IReadOnlyCollection<out T> : IEnumerable<T>
            //int Count { get; }
            #endregion

            #region IReadOnlyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
            //TValue this[TKey key] { get; }
            //IEnumerable<TKey> Keys { get; }
            //IEnumerable<TValue> Values { get; }

            //bool ContainsKey(TKey key);
            //bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
            #endregion

            #region Enumerator
            #region IEnumerator<KeyValuePair<TKey, TValue>>

            #endregion
            #region IDisposable

            #endregion
            #endregion

            #region KeyCollection
            #region ICollection<TKey>

            #endregion

            #region IEnumerable<TKey>

            #endregion

            #region IReadOnlyCollection<TKey>

            #endregion
            #endregion

            #region ValueCollection
            #region ICollection<TValue>

            #endregion

            #region IEnumerable<TValue>

            #endregion

            #region IReadOnlyCollection<TValue>

            #endregion
            #endregion

            #endregion

            #region 新属性

            #endregion
            #region 新方法

            #endregion
            #endregion

            #region SortedSet排序
            //ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ISet<T>, IReadOnlySet<T>, ICollection, IDeserializationCallback, ISerializable

            #endregion

            #region SortedList<TKey, TValue>排序列表
            //ICollection, IEnumerable, IDictionary, ICloneable
            //IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue> where TKey

            #endregion

            #region SortedDictionary<int, string>排序字典
            //

            #endregion

            #region BitArray点阵列
            //ICollection, IEnumerable, ICloneable

            #endregion

            #region KeyValuePair<int, string>键值对
            //

            #endregion

            #region PriorityQueue<TElement, TPriority>优先级队列
            //

            #endregion
        }
    }
}
