namespace 计数排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("计数排序");

            int[] arr = { 4, 2, 7, 1, 3, 9, 8, 6, 6 };
            CountSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            int[] arr1 = { 4, 2, 7, 1, 3, 9, 8, 6, 6 };
            CountSort1(arr1);
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
        }

        public static void CountSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            // 申明数组中的最大值和最小值
            int maxValue = arr.Max();
            int minValue = arr.Min();

            // 创建计数数组，长度为最大值和最小值之差加1
            int[] countArray = new int[maxValue - minValue + 1];

            // 遍历数组并在计数数组中对应位置增加计数
            for (int i = 0; i < arr.Length; i++)
            {
                countArray[arr[i] - minValue]++;

                //等于
                //countArray[arr[i] - minValue] = countArray[arr[i] - minValue] + 1;
            }

            // 重新排列原始数组
            int index = 0;
            for (int i = 0; i < countArray.Length; i++)
            {
                // 根据计数数组中的计数，将元素回写到原始数组中
                while (countArray[i]-- > 0)
                {
                    arr[index++] = i + minValue;
                }

                //等于
                //while (countArray[i] > 0)
                //{
                //    arr[index] = i + minValue;
                //    index = index + 1;
                //    countArray[i] = countArray[i] - 1;
                //}
            }
        }

        public static void CountSort1(int[] arr)
        {
            if (arr.Length <= 1) return;

            int maxValue = arr[0];
            int minValue = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            int[] countArray = new int[maxValue - minValue + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                countArray[arr[i] - minValue]++;
            }

            int index = 0;
            for(int i = 0; i < countArray.Length; i++)
            {
                while (countArray[i] > 0)
                {
                    arr[index] = i + minValue;
                    index = index + 1;
                    countArray[i]--;
                }
            }
        }
    }
}
