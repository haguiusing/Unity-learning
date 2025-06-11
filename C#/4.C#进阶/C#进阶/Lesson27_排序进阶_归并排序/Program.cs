using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Lesson27_排序进阶_归并排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("排序进阶_归并排序");

            #region 知识点一：归并排序基本原理
            //归井 = 递归 + 合并

            //数组分左右
            //左右元素相比较
            //满足条件放入新数组
            //一侧用完放对面

            //递归不停分
            //分完再排序
            //排序结束往上走
            //边走边合并
            //走到头顶出结果

            //归并排序分成两部分
            //1.基本排序规则
            //2.递归平分数组

            //递归平分数组:
            //不停进行分割
            //长度小于2停止
            //开始比较
            //一层一层向上比

            //基本排序规则:
            //左右元素进行比较
            //依次放入新数组中
            //一侧没有了另一侧直接放入新数组
            #endregion
            int[] arrTest = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };

            int[] array = Merge(arrTest);

            PrintArray(array);

            int[] arrTest2 = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };

            int[] sortedArray = MergeSort(arrTest2);

            PrintArray(sortedArray);
        }
        #region 知识点二：代码实现
        //第一步:
        //基本排序规则
        //左右元素相比较
        //满足条件放进去
        //一侧用完直接放
        public static int[] sort(int[] left, int[] right)
        {
            //先准备一个新数组
            int[] array = new int[left.Length + right.Length];
            int leftIndex = 0;//左数组索引
            int rightIndex = 0;//右数组索引
                                                                                
            //最终目的是要填满这个新数组
            for (int i = 0; i < array.Length; i++)
            {
                //左侧放完了 直接放对面
                if( leftIndex >= left.Length)
                {
                    array[i] = right[rightIndex];
                    //已经放入了一个右侧元素进入新数组
                    //所以 标识应该指向下一个嘛
                    rightIndex++;
                }
                //右侧放完了 直接放对面
                else if (rightIndex >= right.Length)
                {
                    array[i] = left[leftIndex];
                    //已经放入了一个右侧元素进入新数组
                    //所以 标识应该指向下一个嘛
                    leftIndex++;
                }

                else if (left[leftIndex] < right[rightIndex])
                {
                    array[i] = left[leftIndex];
                    //已经放入了一个左侧元素进入新数组
                    //所以 标识应该指向下一个嘛
                    leftIndex++;
                }
                else
                {
                    array[i] = right[rightIndex];
                    //已经放入了一个右侧元素进入新数组
                    //所以 标识应该指向下一个嘛
                    rightIndex++;
                }
            }
            return array;
        }

        //第二步:
        //递归平分数组
        //结束条件为长度小于2
        public static int[] Merge(int[] array)
        {
            //递归结束条件
           if (array.Length <= 1)
                return array;

            //1.数组分两段 得到一个中间索引
            int mid = array.Length / 2;
            //2.初始化左右数组
            //左数组
            int[] left = new int[mid];
            //右数组
            int[] right = new int[array.Length - mid];
            //左右初始化内容
            for (int i = 0; i < array.Length; i++)
            {
                if (i < mid) 
                    left[i] = array[i];
                else
                    right[i - mid] = array[i];
            }

            //3.递归再分再排序
            return sort(Merge(left), Merge(right));
        }
        #endregion

        // 归并排序的主函数  
        // 接收一个整型数组array，并返回排序后的数组
        public static int[] MergeSort(int[] array)
        {
            // 如果数组长度小于或等于1，则无需排序，直接返回原数组  
            if (array.Length <= 1)
                return array;

            // 找到数组的中间位置 
            int mid = array.Length / 2;
            // 创建两个数组，分别存储原数组的前半部分和后半部分
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            // 使用Array.Copy方法将原数组的前半部分复制到left数组
            Array.Copy(array, 0, left, 0, mid);
            // 使用Array.Copy方法将原数组的后半部分复制到right数组 
            Array.Copy(array, mid, right, 0, array.Length - mid);
            #region 数组复制
            //第一个参数 array 是源数组，即要从中复制数据的数组。
            //第二个参数 0 是源数组的起始索引，表示从 array 的哪个位置开始复制数据。在这个例子中，它是从 array 的第一个元素开始复制。
            //第三个参数 left 是目标数组，即要复制数据到哪个数组。
            //第四个参数 0 是目标数组的起始索引，表示从 left 的哪个位置开始放置复制过来的数据。在这个例子中，它也是从 left 的第一个元素开始放置。
            //第五个参数 mid 是要复制的元素数量。它指定了从源数组 array 中复制多少个元素到目标数组 left 中。
            #endregion

            // 递归地对left和right数组进行归并排序，并将排序后的结果合并 
            return Merge(MergeSort(left), MergeSort(right));
        }

        // 合并两个已排序的数组  
        // 接收两个已排序的数组left和right，并返回合并后的有序数组
        public static int[] Merge(int[] left, int[] right)
        {
            // 创建一个新的数组result，用于存储合并后的结果  
            // 大小为left和right数组长度之和  
            int[] result = new int[left.Length + right.Length];
            // 初始化三个索引变量，分别用于遍历left、right和result数组 
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            // 遍历left和right数组，将较小的元素按顺序放入result数组 
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }
            // 如果left数组还有剩余元素，将其复制到result数组的末尾 
            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }
            // 如果right数组还有剩余元素，同样将其复制到result数组的末尾 
            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }
            // 返回合并后的有序数组  
            return result;
        }

        public static void PrintArray(int[] arrTest)
        {
            Console.Write("\n ");
            for (int i = 0; i < arrTest.Length; i++)
            {
                Console.Write(arrTest[i] + " ");
            }
        }
    }
}
