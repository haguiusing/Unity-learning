
namespace LINQ访问列表
{
    internal class Program
    {
        public static List<Order> orders;

        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Order order = new Order(i, "订单" + i);
                orders.Add(order);
            }

            foreach (var order in orders)
            {
                Console.WriteLine(order.ID + " " + order.name);
            }


            //LINQ查询
            //GroupBy 和 group by


            //Where条件筛选


            //Select(取list中的id列数据)


            //Where与Select的同时使用

            //左联与内联(例子是DataTable类型)


            //OrderBy排序

            //OrderBy随机排序

            //Skip,Take分页(LINQ:使用Take和Skip实现分页)

            //Distinct去重


        }
    }

    /// <summary>
    /// 点
    /// </summary>
    public class Order
    {
        public int ID;  //编号  
        public string name;  //名称

        public Order(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }
    }
}
