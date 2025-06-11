namespace 堆排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("堆排序");
            //大顶堆：每个节点的值都大于或等于其子节点的值，在堆排序算法中用于升序排列；
            //小顶堆：每个节点的值都小于或等于其子节点的值，在堆排序算法中用于降序排列；

            int[] arr = { 4, 2, 7, 1, 3, 9, 8, 6, 6 };  
            int n = arr.Length;
            HeapSort(arr, n);
            
            for (int i = 0; i < arr.Length; i++)
            {   
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            int[] arr2 = { 4, 2, 7, 1, 3, 9, 8, 6, 6 };
            HeapSortOnly(arr2);
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
        }

        // 堆排序函数
        static void HeapSort(int[] arr, int n)
        {
            // 构建最大堆。从最后一个非叶子节点开始，向上逐个节点进行下沉操作，直到堆顶。
            for (int i = n / 2 - 1; i >= 0; i--)  //i为最后一个非叶子节点的索引, n/2-1 为第一个非叶子节点的索引
                Heapify(arr, n, i);

            // 执行排序，将堆顶元素与堆的最后一个元素交换，然后缩小堆的范围，重新调整堆，直到堆中只剩下一个元素。
            for (int i = n - 1; i > 0; i--)  //i为最后一个元素的索引, n-1 为第一个元素的索引
            {
                // 交换堆顶元素和当前堆的最后一个元素
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // 重新调整堆
                Heapify(arr, i, 0);
            }
        }

        /// <summary>
        /// 调整堆以确保堆的性质
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"> 堆的大小 </param>
        /// <param name="i"> 当前节点的索引 </param>
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // 假设当前节点是最大值节点
            int left = 2 * i + 1; // 左子节点
            int right = 2 * i + 2; // 右子节点  

            // 如果左子节点存在且大于当前节点
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // 如果右子节点存在且大于当前最大值节点
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // 如果最大值节点已经改变
            if (largest != i)
            {
                // 交换当前节点和最大值节点
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                // 继续下沉
                Heapify(arr, n, largest);
            }
        }
        
        public static void HeapSortOnly(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1) return;

            for(int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for(int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }

        public static void Heapify2(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            while (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            while (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if(largest!= i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                Heapify2(arr, n, largest);
            }
        }
    }
}
