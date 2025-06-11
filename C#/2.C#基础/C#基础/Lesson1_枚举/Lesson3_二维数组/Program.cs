using System;

namespace Lesson3_二维数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("二维数组");

            #region 知识点一：基础概念
            // 二维数组 是使用两个下标(索引)来确定元素的数姐
            // 两个下标可以理解成 行标 和 列标
            // 比如矩阵
            // 1 2 3
            // 4 5 6
            // 可以用二堆数组 int[23]表示
            // 好比 两行 三列的数据集合
            #endregion

            #region 知识点二：二维数组的申明

            //变量类型[,] 二维数组变量名;
            int[,] arr;//申明过后 会在后面进行初始化

            //变量类型[,] 二维数组变量名 = new 变量类型[行，列];
            int[,] arr2 = new int[3, 3];

            //变量类型[,] 二维数组变量名 = new 变量类型[行,列]{ {0行内容1，0行内容2，0行内容3.....},{1行内容1，1行内容2，1行内容3.....}......}
            int[,] arr3 = new int[3, 3] { { 1, 2, 3 },
                                          { 4, 5, 6 },
                                          { 7, 8, 9 } };

            //变量类型[,] 二维数组变量名 = new 变量类型[,]{(0行内容1，0行内容2，0行内容3......}，(1行内容1，1行内容2，1行内容3......}......}
            int[,] arr4 = new int[,] { { 1, 2, 3 },
                                       { 4, 5, 6 },
                                       { 7, 8, 9 } };

            //变量类型[,] 二维数组变量名 = {(0行内容1，0行内容2，0行内容3......}，(1行内容1，1行内容2，1行内容3......}......}
            int[,] arr5 = { { 1, 2, 3 },
                            { 4, 5, 6 },
                            { 7, 8, 9 } };

            #endregion

            #region 知识点三：二维数组的使用
            int[,] array = new int[,] { { 1, 2, 3 },
                                        { 4, 5, 6 } };

            //1.二维数组的长度
            //我们要获取 行和列分别有多长
            //得到多少行
            Console.WriteLine(array.GetLength(0));
            //得到多少列
            Console.WriteLine(array.GetLength(1));

            //2.获取二维数组中的元素
            // 注意:第一个元案的索引是0 最后一个元案的索引 肯定是长度-1
            Console.WriteLine(array[0, 1]);
            Console.WriteLine(array[1, 2]);

            //3.修改二维数组中的元素
            array[0, 0] = 99;
            Console.WriteLine(array[0, 0]);

            //4.遍历二维数组
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++){
                    // i 行 0 1
                    // j 列 0 1
                    Console.WriteLine(array[i, j]);
                    //0,0 0,1 0,2
                    //1,0 1,1 1,2
                }
            }

            //5.增加数组的元素
            // 数组 声明初始化过后 就不能再原有的基础上进行 添加 或者制除了
            int[,] array2 = new int[3, 3];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array2[i, j] = array[i, j];
                }

            }
            array = array2; 
            array[2,0] = 7; 
            array[2,1] = 8; 
            array[2,2] = 9;
            Console.WriteLine("**********");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // i 行 0 1
                    // j 列 0 1 2
                    Console.WriteLine(array[i, j]);
                    //0,0 0,1 0,2
                    //1,0 1,1 1,2
                }
            }

            int[,] array3 = new int[3, 3] { {1,2,3 },
                                            {4,5,6 },
                                            {7,8,9 } };

            int[,] arr3add = new int[4, 3];

            for (int i = 0; i < array3.GetLength(0); i++)
            {
                for (int j = 0; j < array3.GetLength(1); j++)
                {
                    arr3add[i, j] = array3[i, j];
                }
            }
            array3 = arr3add;

            //6.删除数组的元素
            int[,] array4 = new int[3, 3] { {1,2,3 },
                                            {4,5,6 },
                                            {7,8,9 } };

            int[,] arr4sub = new int[2, 3];

            for (int i = 0; i < arr4sub.GetLength(0); i++)
            {
                for (int j = 0; j < arr4sub.GetLength(1); j++)
                {
                    arr4sub[i, j] = array4[i, j];
                }
            }
            array4 = arr4sub;

            //7.查找数组中的元素
            //如果要在数组中查找一个元素是否等于某个值
            //通过遍历的形式去查找
            int[,] array5 = new int[3, 3] { {1,2,3 },
                                            {4,5,6 },
                                            {7,8,9 } };

            for (int i = 0; i < array5.GetLength(0); i++)
            {
                for (int j = 0; j < array5.GetLength(1); j++)
                {
                    if (array5[i, j] == 2)
                    {
                        Console.WriteLine("2为数组中的{0}行{1}列", i, j);
                    }

                }
            }

            #endregion

            // 总结:
            //1.概念:同一变量类型的 行列数据集合
            //2.一定要掌握的内容: 申明，遍历，增删查改
            //3.所有的变量类型可以申明为 二维数组
            //4.游戏中一般用来存储 矩阵，再控制台小游戏中可以用二堆数组 来表示地图格子

        }
    }
}