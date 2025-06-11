namespace Lesson13_冒泡排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("冒泡排序");

            #region 知识点一：排序的基本概念
            //排序是计算机内经常进行的一种操作，其目的是将一组“无序”的记录序列调整为"有序”的记录序列
            //常用的排序例子
            // 8 7 1 5 4 2 6 3 9
            // 把上面的这个无序序列 变为 有序 (升序或障序) 序列的过程
            // 1 2 3 4 5 6 7 8 9 (升序)
            // 9 8 7 6 5 4 3 2 1 (降序)

            //在程序中 序列一般 存储在数组当中
            //所以 排序往往息对 数组进行排序
            int[] arr = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9, };
            int[] arr1 = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9, };
            int[] arr2 = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9, };
            //把数组里面的内容变为有序的
            #endregion

            #region 知识点二：冒泡排序基本原理
            //两两相邻
            //不停比较
            //不停交换
            //比较n轮

            //两层循环
            //外层轮数
            //内层比较
            //两值比较
            //满足交换

            #endregion

            #region 知识点三：代码实现
            // 第一步 如何比校数组中两两相邻的数
            // 8，7, 1, 5，4，2，6，3，9
            // 从头开始
            // 第n个数和第n+1个数 比较
            //for (int n = 0; n < arr.Length - 1; n++)
            //{
            //    // 如果 第n个数 比第n+1个数 大 他们就要交换位置
            //    if(arr[n] > arr[n + 1])
            //    {
            //        // 第二步 交换位置
            //        // 中向商不赚差价
            //        int temp = arr[n];
            //        arr[n] = arr[n + 1];
            //        arr[n + 1] = temp;
            //    }
            //}

            ////第三步 如何换m论?
            ////有几个效 就比较多少轮
            //for (int m = 0; m < arr.Length; m++)
            //{
            //    // 进一次循环 就需要比较一轮
            //    for (int n = 0; n < arr.Length - 1 - m; m++)
            //    {
            //        //如果 第n个数 比第n+1个数 大 他们就要交换位置
            //        if (arr[n] > arr[n + 1])
            //        {
            //            //第二步 交换位置
            //            //可商不赚然价
            //            int temp = arr[n];
            //            arr[n] = arr[n + 1]; 
            //            arr[n + 1] = temp;
            //        }
            //    }

            //}

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            //第四步 优化
            //1.确定位置的数字 不用比较了
            // 确定了一轮后 极值 (最大或者最小) 已经放到了对应的位置 (往后放)
            // 所以 没完成n轮 后面位置的数 就不用再参与比较了
            BubbleSort1(arr);

            //练习
            Console.WriteLine();
            BubbleSort2(arr1);

            Console.WriteLine();
            BubblingSort(arr2);
            
            #endregion

            //总结：
            //两两相邻
            //不停比较
            //不停交换
            //比较m轮

            //两层循环
            //外层轮数
            //内层比较
            //两值比较
            //满足交换
        }

        public static void BubbleSort1(int[] arr)
        {
            for (int m = 0; m < arr.Length; m++)
            {
                // 进一次环 就需要比较一轮
                for (int n = 0; n < arr.Length - 1; n++)
                {
                    //如果 n个数 比第n+1个数 大 他们就交换位置
                    if (arr[n] > arr[n + 1])
                    {
                        // 第二步 交换位置
                        // 中间商不赚差价
                        int temp = arr[n];
                        arr[n] = arr[n + 1];
                        arr[n + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void BubbleSort2(int[] arr1)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1.Length - 1 - i; j++)
                {
                    if (arr1[j] > arr1[j + 1])
                    {
                        int temp = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
        }

        public static void BubblingSort(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > 0; j--)
                {

                    if (array[j] < array[j - 1]) 
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}