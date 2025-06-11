namespace 希尔排序
{
    internal class Program
    {
        public static void Sort(int[] arr, int gapValue = 0)
        {
            int gap1 = arr.Length / 2 + 1;
            int gap2 = arr.Length / 2;
            int gap3 = gapValue;
            if(gapValue > 0 && gapValue <= arr.Length / 2)
            {
                gap3 = gapValue;
            }

            int count = 0;
            int countp = 0;

            //暴力
            //while (gap2 > 0)
            //{
            //    for (int i = 0; i < gap2; i++)
            //    {
            //        for (int j = i + gap2; j < arr.Length; j += gap2)
            //        {
            //            if (arr[j] < arr[j - gap2])
            //            {
            //                int temp = arr[j - gap2];
            //                arr[j - gap2] = arr[j];
            //                arr[j] = temp;
            //                countp++;       
            //            }
            //            count++;
            //        }
            //    }
            //    gap3 = gap3 / gapValue;
            //}

            //暴力（只支持gap = n/2）
            //while (gap2 > 0)
            //{
            //    for (int i = 0; i < gap2; i++)
            //    {
            //        for (int j = i + gap2; j < arr.Length; j += gap2)
            //        {
            //            if (arr[j] < arr[j - gap2])
            //            {
            //                int temp = arr[j - gap2];
            //                arr[j - gap2] = arr[j];
            //                arr[j] = temp;
            //                countp++;
            //            }
            //            count++;
            //        }
            //    }
            //    gap2 = gap2 / 2;
            //}

            //交换优化    
            while (gap1 > 0)
            {
                for (int i = gap1; i < arr.Length; i++)
                {
                    for (int j = i - gap1; j >= 0; j -= gap1)
                    {
                        if (arr[j] > arr[j + gap1])
                        {
                            int temp = arr[j + gap1];
                            arr[j + gap1] = arr[j];
                            arr[j] = temp;
                            countp++;
                        }
                        count++;
                    }
                }
                gap1 = gap1 / 2;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("循环次数:" + count);
            Console.WriteLine("交换次数:" + countp);
        }

        public static void ShellSort(int[] array)
        {
            int count = 0;
            int arrLength = array.Length;

            // 初始化增量（初始间隔）为数组长度的一半
            int gap = arrLength / 2;

            // 不断缩小增量，直到增量为1
            while (gap > 0)
            {
                // 对每个子序列进行插入排序
                for (int i = gap; i < arrLength; i++)
                {
                    int temp = array[i];
                    int j = i;

                    // 在子序列内部进行插入排序
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;

                        count++;
                    }

                    array[j] = temp;
                }

                // 缩小增量
                gap /= 2;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("循环次数:" + count);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("希尔排序");

            int[] arr1 = { 5, 3, 8, 6, 2, 7, 1, 4 };
            int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] arr3 = { 8, 7, 6, 5, 4, 3, 2, 1 };
            //Sort(arr3);

            ShellSort(arr1);
        }
    }
}
