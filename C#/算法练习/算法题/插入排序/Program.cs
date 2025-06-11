namespace 插入排序
{
    internal class Program
    {

        public static void InsertSort(int[] arr)
        {
            int count = 0;
            int countP = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                        countP++;
                    }
                    count++;
                }
            }

            // 优化版
            //for(int i = 1; i < arr.Length; i++)
            //{
            //    int temp = arr[i];
            //    int j = i;
            //    while (j - 1 >= 0 && arr[j - 1] > temp) 
            //    {
            //        arr[j] = arr[j - 1];
            //        j--;
            //        count++;
            //        countP++;
            //    }
            //    arr[j] = temp;
            //}

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n共进行了" + count + "次比较，" + countP + "次交换");  
        }

        static void Main(string[] args)
        {
            Console.WriteLine("插入排序");

            int[] arr = { 5, 2, 4, 6, 1, 3 };
            InsertSort(arr);

            int[] arr1 = { 7, 1, 2, 3, 4, 5, 6 };
            InsertSort1(arr1);
        }

        public static void InsertSort1(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i;
                while (j - 1 >= 0 && arr[j - 1] < temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
