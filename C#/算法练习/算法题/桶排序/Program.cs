namespace 桶排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("桶排序");

            int[] arr = { 3, 5, 2, 8, 1, 9, 4, 7, 6 };
            int bucketSize = 3;
            BucketSort(arr, bucketSize);

            Console.WriteLine("排序後:");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int[] arr2 = { 3, 5, 2, 8, 1, 9, 4, 7, 6 };
            int bucketSize2 = 2;
            UnBucketSort(arr2, bucketSize2);

            Console.WriteLine("反桶排序後:");
            foreach (var item in arr2)
            {
                Console.Write(item + " ");
            }
        }

        public static void BucketSort(int[] arr, int bucketSize)
        {
            if (arr.Length <= 1)
                return;

            int minValue = arr.Min();
            int maxValue = arr.Max();
            //根據原始數組最值差值，桶的大小來確定 桶的數量
            int bucketCount = (int)Math.Ceiling((decimal)(maxValue - minValue + 1) / bucketSize);

            List<List<int>> buckets = new List<List<int>>();
            //根據計算得到的桶數量添加桶列表
            for (int i = 0; i < bucketCount; i++)
                buckets.Add(new List<int>());

            for (int i = 0; i < arr.Length; i++)
            {
                //計算原始數組中的每一個元素應屬於哪一個桶
                int bucketIndex = (arr[i] - minValue) / bucketSize;
                //將元素分配至對應桶中
                buckets[bucketIndex].Add(arr[i]);
            }

            int index = 0;
            //遍歷桶列表，將每一個桶進行排序，並將排序好的元素順次取出放至原始數組中。
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                //將桶中元素排序好後，順次取出放入原始數組
                foreach (var value in bucket)
                    arr[index++] = value;
            }
        }

        public static void UnBucketSort(int[] arr, int bucketSize)
        {
            if(arr.Length <= 1) return;

            int minValue = arr.Min();
            int maxValue = arr.Max();
            int bucketCount = (int)Math.Ceiling((decimal)(maxValue - minValue + 1) / bucketSize);

            List<List<int>> buckets = new List<List<int>>();

            for (int i = 0; i < bucketCount; i++)
                buckets.Add(new List<int>());

            for(int i = 0; i < arr.Length; i++)
            {
                int bucketIndex = (arr[i] - minValue) / bucketSize;
                buckets[bucketIndex].Add(arr[i]);
            }

            int index = arr.Length - 1;
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                foreach (var value in bucket)
                    arr[index--] = value;
            }
        }
    }
}
