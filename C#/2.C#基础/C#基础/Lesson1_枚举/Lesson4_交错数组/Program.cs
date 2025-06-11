﻿using System;

namespace Lesson4_交错数组
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("交错数组");

            #region 知识点一：基本概念
            // 交错数组 是 数组的数组，每个维度的数量可以不同

            // 注意:二维数组的每行的列数相同，交错数组每行的列数可能不同
            #endregion

            #region 知识点二：数组的申明
            //变量类型[][] 交错数组名;
            int[][] arr;

            //变量类型[][] 交错数组名 = new 变量类型[行数][];
            int[][] arr2 = new int[3][];

            //变量类型[][] 交错数组名 = new 变量类型[行数][]{ 一维数组1， 一维数组2，......};
            int[][] arr3 = new int[3][] { new int[] { 1, 2, 3},
                              new int[] { 4, 5},
                              new int[] { 6} };

            //变量类型[][] 交错数组名 = new 变量类型[][]{ 一维数组1， 一维数组2，......};
            int[][] arr4 = new int[][] { new int[] { 1, 2, 3},
                              new int[] { 4, 5},
                              new int[] { 6} };

            //变量类型[][] 交错数组名 = { 一维数组1， 一维数组2，......};
            int[][] arr5 = { new int[] { 1, 2, 3},
                              new int[] { 4, 5},
                              new int[] { 6} };
            #endregion

            #region 知识点三：数组的使用
            int[][] array = {new int[] { 1, 2, 3},
                             new int[] { 4, 5} };
            //1.数组的长度
            // 行
            Console.WriteLine(array.GetLength(0));
            // 得到某一行的列数
            Console.WriteLine(array[0].Length);

            //2.获取交错数组中的元素
            // 注意: 不要越界
            Console.WriteLine(array[0][1]);

            //3.修改交错数组中的元素
            array[0][1] = 99;
            Console.WriteLine(array[0][1]);

            //4.遍历交错数组
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }           
                Console.WriteLine();
            }

            //5.增加交错数组的元素
            //略 参考之前的数组课程

            //6.删除交错数组的元素
            //略 参考之前的数组课程

            //7.查找交错数组中的元素
            //略 参考之前的数组课程
            #endregion

        }
    }
}