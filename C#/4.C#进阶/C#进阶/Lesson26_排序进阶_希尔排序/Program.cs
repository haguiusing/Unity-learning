
namespace Lesson26_排序进阶_希尔排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson26_排序进阶_希尔排序");

            int[] arrTest = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };

            int[] arrTest1 = new int[] { 8, 7, 1, 1, 4, 2, 7, 3, 9 };

            for (int i = 0; i < arrTest.Length; i++)
            {
                Console.Write(arrTest[i] + " ");
            }

            希尔排序_方法1(arrTest);

            打印排序(arrTest);

            希尔排序_方法2(arrTest1);

            打印排序(arrTest1);

        }

        public static int 除2次数(int numberCount)
        {
            int count = 0;
            int numberCountindex = numberCount;
            while (numberCountindex > 1)
            {
                numberCountindex /= 2;
                count++;
            }
            return count;
        }

        private static void 希尔排序_方法1(int[] arrTest)
        {
            
            int[] arr = new int[8];
            arr = arrTest;

            int count = 除2次数(arr.Length);  //需要处于2的轮数

            for (int i = 1; i < count; i++) 
            {
                int stepLength = arr.Length / 2 * i;  //计算步长
                int numberOfComparison = arr.Length - stepLength;  //剩余比较的次数

                int noSortIndex = stepLength;//未排序区的第一个元素索引
                int sortIndex = noSortIndex - stepLength ;  //要与比较的元素的索引
                int sortNum = arr[sortIndex]; //要与比较的元素
                int noSortNum = arr[noSortIndex];  //未排序区的第一个元素
                for (int y = numberOfComparison; numberOfComparison >= 0 && arr[sortIndex] > noSortNum; numberOfComparison--)
                {
                    arr[noSortIndex] = arr[sortIndex];
                    arr[noSortIndex - stepLength] = noSortNum;
                    sortIndex--;
                    noSortIndex++;
                    sortIndex++;
                }
                while (numberOfComparison >= 0 &&
                    arr[sortIndex] > noSortNum)
                {
                    
                }
            }

            Console.WriteLine("\n希尔排序_方法1:");
        }

        private static void 希尔排序_方法2(int[] arrTest)
        {

            int[] arr = new int[8];
            arr = arrTest;

            //学习希尔排序的前提条件
            //先掌握插入排序
            //第一步: 实现插入排序
            //第一层循环 是用来取出未排序区中的元素的
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    //得出排序区的最后一个元素索引
            //    int sortIndex = i - 1;
            //    //得出未排序区的第一个元素
            //    int noSortNum = arr[i];
            //    //进入条件
            //    //首先排序区中还有可以比较的 >=0
            //    //排序区中元素 满足交换条件 升序就是排序区中元素要大于未排序区中元素
            //    while (sortIndex >= 0 &&
            //        arr[sortIndex] > noSortNum)
            //    {
            //        arr[sortIndex + 1] = arr[sortIndex];
            //        --sortIndex;
            //    }
            //    //循环中知识在确定位置 和找最终的插入位置
            //    //最终插入对应位置 应该循环结束后
            //    arr[sortIndex + 1] = noSortNum;


            //第二步: 确定步长
            //基本规则: 每次步长变化都是/2
            //一开始步长 就是数组的长度/2
            //之后每一次 都是在上一次的步长基础上/2
            //结束条件是 步长<=0
            //1.第一次的步长是数组长度/2 所以: int step = arr.length/2
            //2.之后每一次步长变化都是/2 索引: step /= 2
            //3.最小步长是1 所以: step > 0
            for (int step = arr.Length / 2; step > 0; step /= 2)
            {
                //注意:
                //每次得到步长后 会把该步长下所有序列都进行插入排序

                //第三步: 执行插入排序
                //i=1代码 相当于 代表取出来的排序区的第一个元素
                //for (int i = 1; i < arr.Length; i++)
                //i=step 相当于 代表取出来的排序区的第一个元素
                for (int i = step; i < arr.Length; i++)
                {
                    //得出排序区的最后一个元素索引
                    //int sortIndex = i - 1;
                    //i-step 代表和子序列中 已排序区元素一一比较
                    int sortIndex = i - step;
                    //得出未排序区的第一个元素
                    int noSortNum = arr[i];
                    //进入条件
                    //首先排序区中还有可以比较的 >=0
                    //排序区中元素 满足交换条件 升序就是排序区中元素要大于未排序区中元素
                    while (sortIndex >= 0 &&
                        arr[sortIndex] > noSortNum)
                    {
                        //arr[sortIndex + 1] = arr[sortIndex];
                        //代表移步长个位置 代表子序列中的下一个位置
                        arr[sortIndex + step] = arr[sortIndex];
                        //--sortIndex;
                        //一个步长单位之间的比较
                        sortIndex -= step;
                    }
                    //循环中知识在确定位置 和找最终的插入位置
                    //最终插入对应位置 应该循环结束后
                    //arr[sortIndex + 1] = noSortNum;
                    //
                    arr[sortIndex + step] = noSortNum;
                }
            }
            Console.WriteLine("\n希尔排序_方法2:");
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
