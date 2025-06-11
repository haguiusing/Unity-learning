using System.Collections;
using System.Collections.Generic;

namespace Lesson22_迭代器
{
    #region 知识点一：迭代器是什么
    //迭代器 (iterator) 有时又称光标 (cursor)
    //是程序设计的软件设计模式
    //迭代器模式提供一个方法顺序访问一个聚合对象中的各个元素
    //而又不暴露其内部的标识

    //初始状态（-1）

    //在表现效果上看
    //是可以在容器对象 (例如链表或数组) 上遍历访问的接口
    //设计人员无需关心容器对象的内存分配的实现细节
    //可以用foreach遍历的类，都是实现了迭代器的
    #endregion

    #region 知识点二：标准迭代器的实现方法(麻烦)
    //关键接口: IEnumerator,IEnumerable
    //命名空间: using System.Collections;
    //可以通过同时继承IEnumerable和IEnumerator实现其中的方法
    class CustomList:IEnumerable, IEnumerator
    {
        private int[] list;
        //从-1开始的光标 用于表示 数据到了哪个位置
        private int position = -1;

        public CustomList()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        #region IEnumerable
        //IEnumerable 接口是.NET Framework 中的一个核心接口，
        //它定义了一个用于遍历集合的方法，而不需要知道集合的具体类型。
        //这个接口是非泛型的，意味着它适用于任何类型的元素集合。
        //IEnumerable 接口通过提供一个 GetEnumerator 方法来实现这一点，
        //该方法返回一个 IEnumerator 对象，该对象支持对当前集合进行简单的迭代。

        //IEnumerable 接口的主要特点：
        //1.非泛型：由于它是非泛型的，所以它不要求集合中的元素具有特定的类型。
        //   这提供了灵活性，但也意味着在迭代过程中可能需要进行类型转换或使用反射等技术来获取元素的具体类型信息。
        //2.简单迭代：通过 GetEnumerator 方法返回的 IEnumerator 对象，
        //   可以逐个访问集合中的元素。IEnumerator 接口提供了 MoveNext、Reset 和 Current 三个方法/属性，分别用于移动到集合的下一个元素、重置枚举器到集合的初始位置，以及获取当前枚举的元素
        //  （但请注意，在调用 MoveNext 之前，Current 的值是未定义的）。
        //3.链式枚举：IEnumerable 接口允许实现自定义的集合或数据结构，并能够与.NET Framework 中的其他集合类型（如数组、列表等）无缝协作。
        //   例如，LINQ（Language Integrated Query）就是建立在 IEnumerable 和其泛型版本 IEnumerable<T> 之上的，它提供了一套丰富的查询操作，允许以声明性方式查询和操作数据集合。
        #endregion
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        #region IEnumerator
        //IEnumerator 接口是.NET Framework 中用于遍历非泛型集合的一个关键接口。
        //它定义了三个成员：Current 属性、MoveNext 方法和 Reset 方法，这些成员共同支持对集合的迭代操作。

        //IEnumerator 接口的成员

        //Current 属性
        //类型：object
        //说明：获取集合中当前枚举器位置上的元素。在调用 MoveNext 方法之前，Current 的值是未定义的；在调用 MoveNext 方法之后，如果 MoveNext 返回 true，则 Current 包含集合中的下一个元素。
        //注意：由于 Current 的类型是 object，因此在访问具体类型的元素时可能需要进行类型转换。
        
        //MoveNext 方法
        //返回类型：bool
        //说明：将枚举器前进到集合的下一个元素。如果枚举器成功地前进到下一个元素，则返回 true；如果枚举器已经越过了集合的末尾，则返回 false。
        //异常：如果集合在枚举器创建后被修改（除非集合的类型特别说明支持修改），则可能抛出 InvalidOperationException 异常。
        
        //Reset 方法
        //返回类型：void
        //说明：将枚举器重置到集合的初始位置，即集合中第一个元素之前的位置。并非所有枚举器都支持重置操作。
        //异常：
        //如果集合在枚举器创建后被修改（除非集合的类型特别说明支持修改），则可能抛出 InvalidOperationException 异常。
        //如果枚举器不支持重置操作，则可能抛出 NotSupportedException 异常。
        #endregion
        public object Current
        {
            get { return list[position]; }
        }
        public bool MoveNext()
        {
            //移动光标
            ++position;
            //是否溢出 溢出就不合法
            return position < list.Length;
        }
        //reset是重置光标位置 一般写在获取 IEnumerator对象这个函数中
        //用于第一次重置光标位
        public void Reset()
        {
            position = -1;
        }
    }
    #endregion

    #region 知识点三：用yield return 语法实现迭代器
    //yield return 是C#提供给我们的语法糖
    //所谓语法糖，也称糖衣语法
    //主要作用就是将复杂逻辑简单化，可以增加程序的可读性
    //从而减少程序代码出错的机会

    //关键接口: IEnumerable
    //命名空间: using System.Collections;
    //让想要通过foreach遍历的自定义类实现接口中的方法GetEnumerator即可

    class CustomList2 : IEnumerable
    {
        private int[] list;

        public CustomList2()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                //yield关键字 配合迭代器使用
                //可以理解为 暂时返回 保留当前的状态
                yield return list[i];   //相当于系统自动生成IEnumerator的方法
            }
        }
    }
    #endregion

    #region 知识点四：用yield return 语法为泛型类实现迭代器


    class CustomList3<T> : IEnumerable
    {
        private T[] array;

        public CustomList3(params T[] array)
        {
            this.array = array;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("迭代器");

            CustomList list = new CustomList();

            //foreach本质
            //1.先获取in后面这个对象的 IEnumerator
            //  会调用对象其中的GetEnumerator方法 来获取
            //2.执行得到这个IEnumerator对象中的 MoveNext方法
            //3.只要MoveNext方法的返回值时true就会去得到Current
            //  然后赋值给 item
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n" + "*********");
            CustomList2 list2 = new CustomList2();

            foreach (int item in list2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n"+"*********");
            CustomList3<string> list3 = new CustomList3<string>("123","456","789");
            foreach (string item in list3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
