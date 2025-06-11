namespace Lesson25_排序进阶_插入排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("排序进阶_插入排序");

            int[] arrTest = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };

            int[] arrTest1 = new int[] { 8, 7, 1, 1, 4, 2, 7, 3, 9 };

            for (int i = 0; i < arrTest.Length; i++)
            {
                Console.Write(arrTest[i] + " ");
            }

            插入排序_方法1(arrTest);
            打印排序(arrTest);

            插入排序_方法1(arrTest1);
            打印排序(arrTest1);
        }

        public static void 插入排序_方法1(int[] arrTest)
        {
            #region 知识点一：插入排序的基本原理
            // 8 7 1 5 4 2 6 3 9
            // 两个区域
            // 排序区
            // 未排序区
            // 用一个索引值做分水岭

            // 未排序区元素
            // 与排序区元素比较
            // 插入到合适位置
            // 直到未排序区清空
            #endregion

            #region 知识点二：代码实现
            //实现升序 把 大的 放在最后面
            int[] arr = new int[arrTest.Length];
            arr = arrTest;

            //前提规则
            //排序开始前
            //首先认为第一个元素在排序区中
            //其它所有元素在未排序区中

            //排序开始后
            //每次将未排序区第一个元素取出用于和
            //排序区中元素比较(从后往前)
            //满足条件 (较大或者较小)
            //则排序区中元素往后移动一个位置

            //注意
            //所有数字都在一个数组中
            //所谓的两个区域是一个分水岭索引

            //第一步
            //能取出未排序区的所有元素进行比较
            //i=1的原因: 默认第一个元索就在排序区
            for (int i = 1; i < arr.Length; i++)
            {
                //第二步
                //每一轮
                //1.取出排序区的最后一个元素索引
                int sortIndex = i - 1;
                //2.取出未排序区的第一个元素
                int noSortNum = arr[i];
                //第三步
                //在未排序区进行比较
                //移动位置
                //确定插入索引
                //1.发现排序区中所有元素都已经比较完
                //2.发现排序区中的元素不满足比较条件了
                while (sortIndex >= 0 &&
                    arr[sortIndex] > noSortNum)
                {
                    //只要进了这个while循环 证明满足条件
                    //排序区中的元素 就应该往后退一格
                    arr[sortIndex + 1] = arr[sortIndex];
                    //移动到排序区前一个位置 准备继续比较
                    --sortIndex;
                }
                //最终插入数字
                //循环中知识在确定位置 和找最终的插入位置
                //最终插入对应位置 应该循环结束后
                arr[sortIndex + 1] = noSortNum;
                #endregion
            }
            Console.WriteLine("\n插入排序_方法1:");
        }

        public static void 打印排序(int[] arrTest)
        {
            int[] arr = new int[8];
            arr = arrTest;
            Console.Write(" ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
