namespace 杨辉三角形
{
    internal class Program
    {
        public static void PrintTriangle(int rows)
        {
            int[][] a = new int[rows][];
            a[0] = new int[1];   
            for(int i = 0; i < rows; i++)
            {
                a[i] = new int[i + 1];
                a[i][0] = 1;
                a[i][i] = 1;
                if (i > 1)
                {
                    for (int j = 1; j <= i - 1; j++) 
                    {
                        a[i][j] = a[i - 1][j - 1] + a[i - 1][j];
                    }
                }
                
            }

            for(int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= i; j++) 
                {
                    Console.Write(a[i][j] + " ");
                }
            }
            //                
            //0       1       
            //1      1 1      
            //2     1 2 1     
            //3    1 3 3 1    
            //4   1 4 6 4 1   
            //5  1 5 10 10 5 1
            //6 1 6 15 20 15 6 1
        }

        static void Main(string[] args)
        {
            Console.WriteLine("杨辉三角形");

            PrintTriangle(7);

            //Console.WriteLine("请输入杨辉三角的行数：");
            //int len = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("输出" + len + "行杨辉三角：");
            //Console.WriteLine();
            //int[,] a = new int[len, len];
            //for (int i = 0; i < len; i++)
            //{
            //    for (int k = 0; k < len - i; k++)
            //    {
            //        // 打印每行第一个1前的空格
            //        Console.Write(" ");
            //    }
            //    for (int j = 0; j <= i; j++)
            //    {
            //        if (j == 0 || i == j)
            //        {
            //            // 每行第一个和最后一个值为1
            //            a[i, j] = 1;
            //        }
            //        else
            //        {
            //            a[i, j] = a[i - 1, j - 1] + a[i - 1, j];
            //        }
            //        Console.Write(a[i, j].ToString() + " ");
            //    }
            //    Console.WriteLine(); // 换行
            //}
            //Console.ReadKey();
        }
    }
}
