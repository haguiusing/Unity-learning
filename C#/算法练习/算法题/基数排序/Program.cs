namespace 基数排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("基数排序");

            int[] arr = { 1, 32, 457, 65, 839, 8, 43, 720, 35, 4 };
            RadixSort_Array(arr);
            Console.WriteLine(string.Join(",", arr));

        }

        ///基数排序
        static void RadixSort_List(List<int> list)
        {
            int maxValue = list.Max();//列表内部方法拿过来用用（在Linq中）
            int it = 0;//需要几趟
                       //maxvalue 9-1 99-2 999-3
                       //10^0<=9 10^1>9 it=1
                       //10^0<99 10^1<99 10^2>99 it=2
            while (Math.Pow(10, it) <= maxValue)
            {
                List<List<int>> buckets = new List<List<int>>(10);//分10个桶对应0-9
                for (int i = 0; i < 10; i++)
                {
                    buckets.Add(new List<int>());
                }//列表初始化大小

                for (int i = 0; i < list.Count; i++)//入桶
                {
                    //989 it=0 989/10^it=989 989%10=9;
                    int digit = (int)((list[i]) / (Math.Pow(10, it)) % 10);//得到对应桶
                    buckets[digit].Add(list[i]);
                }//全部入桶

                list.Clear();//依次取出来
                for (int i = 0; i < buckets.Count; i++)
                {
                    list.AddRange(buckets[i]);
                }
                it += 1;//继续下一次循环入桶出桶
            }
        }

        static void RadixSort_Array(int[] arr)
        {
            List<int> list1 = new List<int>(arr);
            RadixSort_List(list1);

            Array.Copy(list1.ToArray(), arr, arr.Length);
        }
    }
}
