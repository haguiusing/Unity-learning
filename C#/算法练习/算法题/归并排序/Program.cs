namespace 归并排序
{
    internal class Program
    {
        public static List<int> sort(List<int> lst)
        {
            if (lst.Count <= 1)
                return lst;
            int mid = lst.Count / 2;
            List<int> left = new List<int>();  // 定义左侧List
            List<int> right = new List<int>(); // 定义右侧List
                                               // 以下兩個循環把 lst 分為左右兩個 List
            for (int i = 0; i < mid; i++)
                left.Add(lst[i]);
            for (int j = mid; j < lst.Count; j++)
                right.Add(lst[j]);
            left = sort(left);
            right = sort(right);
            return merge(left, right);
        }
        /// <summary>
        /// 合併兩個已經排好序的List
        /// </summary>
        /// <param name="left">左側List</param>
        /// <param name="right">右側List</param>
        /// <returns></returns>
        static List<int> merge(List<int> left, List<int> right)
        {
            List<int> temp = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                    temp.Add(left[i]);
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                    temp.Add(right[i]);
            }
            return temp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("归并排序");

            List<int> list = new List<int> { 3, 7, 1, 9, 2, 5, 8, 4, 6 };
            list = sort(list);

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            List<int> list2 = new List<int> { 3, 7, 1, 9, 2, 5, 8, 4, 6 };
            list2 = PrintList(list2);

            foreach (int i in list2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            List<float> list3 = new List<float> { 3.5f, 7.2f, 1.8f, 9.1f, 2.6f, 5.3f, 8.7f, 4.1f, 6.4f };
            list3 = PrintListSort(list3);   
            foreach (float i in list3)
            {
                Console.Write(i + " ");
            }   
        }

        //分割
        public static List<int> PrintList(List<int> lst)
        {
            if (lst.Count <= 1)
                return lst;

            int mid = lst.Count / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            for (int i = 0; i < mid; i++)
            {
                left.Add(lst[i]);
            }
            for (int j = mid; j < lst.Count; j++)
            {
                right.Add(lst[j]);
            }
            left = PrintList(left);
            right = PrintList(right);
            return MergeSort(left, right);
        }

        //排序与合并
        public static List<int> MergeSort(List<int> lstL, List<int> lstR)
        {
            List<int> temp = new List<int>();
            //三种情况
            //左右两边都有
            while (lstL.Count > 0 && lstR.Count > 0)
            {
                if (lstL[0] < lstR[0])
                {
                    temp.Add(lstR[0]);
                    lstR.RemoveAt(0);
                }
                else
                {
                    temp.Add(lstL[0]);
                    lstL.RemoveAt(0);
                }
            }

            //左边为空
            if (lstL.Count > 0)
            {
                for (int i = 0; i < lstL.Count; i++)
                    temp.Add(lstL[i]);
            }

            //右边为空
            if (lstR.Count > 0)
            {
                for (int i = 0; i < lstR.Count; i++)
                    temp.Add(lstR[i]);
            }

            return temp;
        }

        public static List<float> PrintListSort(List<float> lst)
        {
            if (lst.Count <= 1)
                return lst;
            int mid = lst.Count / 2;
            List<float> left = new List<float>();
            List<float> right = new List<float>();

            for (int i = 0; i < mid; i++)
            {
                left.Add(lst[i]);
            }
            for (int j = mid; j < lst.Count; j++)
            {
                right.Add(lst[j]);
            }

            left = PrintListSort(left);
            right = PrintListSort(right);

            return MergeSort(left, right);
        }

        public static List<float> MergeSort(List<float> lstL,List<float> lstR)
        {
            List<float> temp = new List<float>();
            while(lstL.Count > 0 && lstR.Count > 0)
            {
                if(lstL[0] < lstR[0])
                {
                    temp.Add(lstR[0]);
                    lstR.RemoveAt(0);
                }
                else
                {
                    temp.Add(lstL[0]);
                    lstL.RemoveAt(0);
                }
            }
            if (lstL.Count > 0)
            {
                for (int i = 0; i < lstL.Count; i++)
                    temp.Add(lstL[i]);
            }
            if (lstR.Count > 0)
            {
                for (int i = 0; i < lstR.Count; i++)
                    temp.Add(lstR[i]);
            }

            return temp;
        }
    }
}
