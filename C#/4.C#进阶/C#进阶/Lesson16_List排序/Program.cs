namespace Lesson16_List排序
{
    //C#中数组、ArrayList和List三者的区别
    //https://blog.csdn.net/zhang_xinxiu/article/details/8657431
    class Item : IComparable<Item>,IComparable  //两种排序接口，前者泛型，后者是object
    {
        public int money;

        public Item(int money)
        {
            this.money = money;
        }

        //IComparable<Item>
        public int CompareTo(Item? other)
        {
            //返回值的含义
            //小于0：放在传入对象的前面
            //等于0:保持当前的位置不变
            //大于0：放在传入对象的后面

            if (this.money > other.money)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //IComparable
        public int CompareTo(object? obj)
        {
            if (this.money > (obj as Item).money)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    class ShopItem
    {
        public int id;

        public ShopItem(int id)
        {
            this.id = id;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List排序");

            #region 知识点一：List自带排序方法
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(1);
            list.Add(4);
            list.Add(2);
            list.Add(5);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i]}");
            }
            Console.WriteLine("************");
            list.Sort();  //自带 升序排序
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i]}");
            }

            //ArrayList中也有Sort排序方法
            Console.WriteLine("************");
            #endregion

            #region 知识点二：自定义类的排序
            List<Item> itemList = new List<Item>();
            itemList.Add(new Item(31));
            itemList.Add(new Item(72));
            itemList.Add(new Item(13));
            itemList.Add(new Item(44));
            itemList.Add(new Item(25));
            //升序排序
            itemList.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(itemList[i].money);
            }
            Console.WriteLine("************");
            #endregion

            #region 知识点三：通过委托函数进行排序
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(32));
            shopItems.Add(new ShopItem(85));
            shopItems.Add(new ShopItem(14));
            shopItems.Add(new ShopItem(29));
            shopItems.Add(new ShopItem(67));

            //方法一 通过委托函数
            //shopItems.Sort(SortShopItem);
            //方法二 通过匿名函数
            shopItems.Sort(delegate (ShopItem a, ShopItem b)
            {
                if (a.id > b.id)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            });
            //方法三 通过Lambda表达式
            shopItems.Sort((a, b) =>
            {
                return  a.id > b.id ? -1 : 1;
            });
            //再简单,省略{}
            shopItems.Sort((a, b) => a.id > b.id ? -1 : 1);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(shopItems[i].id);
            }
            #endregion
        }
        static int SortShopItem(ShopItem a, ShopItem b)
        {
            //传入的两个对象 为列表中的两个对象
            //进行两两的比较 用左边的和右边的条件 比较
            //a是this   b是other
            //返回值规则与之前一致
            if (a.id > b.id)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
