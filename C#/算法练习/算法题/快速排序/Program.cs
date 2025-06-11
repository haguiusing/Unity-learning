namespace 快速排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("快速排序");

            int[] arr = { 64, 34, 25, 12, 22, 11, 90, 110 };
            int n = arr.Length;

            QuickSortDemo quicksort = new QuickSortDemo();
            quicksort.Sort(arr, 0, n - 1);

            Console.WriteLine("Sorted array print:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            int[] arr2 = { 4, 1, 7, 2, 6, 8, 3, 5 };
            QuickSort(arr2, 0, arr2.Length - 1);
            for(int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }

            Console.WriteLine();

            int[] arr3 = { 5, 3, 8, 6, 2, 7, 1, 4 };
            QuickSort2(arr3, 0, arr3.Length - 1);
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write(arr3[i] + " ");
            }
        }

         static void QuickSort(int[] arr, int left, int right)
        {
            if(right - left < 1) return;

            int pivot = arr[left];  // 选择第一个元素作为pivot
            int s = left, e = right;  // s, e分别指向左右两边的指针

            while (s < e)  // 左右指针交叉移动
            {
                while (s < e && arr[e] >= pivot)  // 右边指针向左移动，直到遇到小于pivot的元素,退出循环
                    e--;
                arr[s] = arr[e];  // 交换左边指针指向的元素和右边指针指向的元素
                while (s < e && arr[s] <= pivot)  // 左边指针向右移动，直到遇到大于pivot的元素,退出循环
                    s++;
                arr[e] = arr[s];  // 交换右边指针指向的元素和左边指针指向的元素
            }//左右指针交叉移动结束
            arr[s] = pivot;  // 最后将pivot放到中间位置
            //arr[e] = pivot;  // 也可以将pivot放到右边

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            QuickSort(arr, left, s - 1);  // 递归左边
            QuickSort(arr, s + 1, right);  // 递归右边
        }

        static int[] QuickSort2(int[] arr, int left, int right)
        {
            if(right - left < 1)return arr;

            int piv = arr[right];
            int s = left, e = right;

            while (s < e)
            {
                while (s < e && arr[s] <= piv)
                    s++;
                arr[e] = arr[s];
                while (s < e && arr[e] >= piv)
                    e--;
                arr[s] = arr[e];
            }
            arr[s] = piv;

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            QuickSort2(arr, left, s - 1);
            QuickSort2(arr, s + 1, right);

            return arr;
        }
    }

    class QuickSortDemo
    {
        public void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);  // 选择最后一个元素作为pivot
                Sort(arr, low, pivot - 1);
                Sort(arr, pivot + 1, high);
            }
        }

        /// <summary>
        /// 分区函数
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        /// <summary>
        /// 交换数组中的两个元素  
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
