namespace Lesson8_ref和out
{
    internal class Program
    {
        #region 知识点一：学习ref和out的原因
        //学习ref和out的原因
        //它们可以解决 在的数内部改变外部传入的内容 里面变了 外面也要变
        static void ChangeValue(int value)
        {
            value = 3;
        }

        static void ChangeArrayValue(int[] arr)
        {
            arr[0]=99;
        }
        private static void ChangeArray(int[] arr)
        {
            // 重新申明了一个数组
            arr = new int[] { 10, 20, 30 };
        }
        #endregion

        #region 知识点二：ref和out的使用
        //函数参数的修饰符
        //当传入的值类型参数在内部修改时 或者引用类型参数在内部重新申明时
        //外部的值会发生变化

        // ref  
        static void ChangeValueRef(ref int value)
        {
            //2.out传入的变量必须在内部赋值，ref不用。
            value = 3;
        }
        private static void ChangeArrayRef(ref int[] arr)
        {
            arr = new int[] { 100, 200, 300 };
        }

        //out
        static void ChangeValueOut(out int value)
        {
            //2.out传入的变量必须在内部赋值，ref不用。
            value = 99;//没赋值会报错
        }
        private static void ChangeArrayOut(out int[] arr)
        {
            arr = new int[] { 999, 888, 777 };
        }
        #endregion

        #region 知识点三：ref和out的区别
        //1.ref传入的变量(参数) 必须初始化，out不用。
        //2.out传入的变量必须在内部赋值，ref不用。

        // ref传入的变量必须初始化 但是在内部 可改可不改
        // out传入的变量不用初始化 但是在内部 必须修改该值（必须赋值）
        #endregion

        #region 额外：in
        //in：参数变量需要初始化，参数在方法中不能进行修改。
        public static void Print(in int value)
        {
            //value = 100;//报错
            Console.WriteLine(value);
        }

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("ref和out");

            int a = 1;
            int b; //变量未初始化
            int c;

            ChangeValue(a);
            Console.WriteLine(a);//1

            ChangeValueRef(ref a);
            Console.WriteLine(a);//3

            ChangeValueOut(out a);
            Console.WriteLine(a);//99

            Console.WriteLine("***********");

            int[] arr2 = { 1, 2, 3 };
            ChangeArrayValue(arr2);
            Console.WriteLine(arr2[0]);//99

            ChangeArray(arr2);
            Console.WriteLine(arr2[0]);//99

            ChangeArrayRef(ref arr2);
            Console.WriteLine(arr2[0]);//100

            ChangeArrayOut(out arr2);
            Console.WriteLine(arr2[0]);//999

            Console.WriteLine("***********");

            //1.ref传入的变量(参数) 必须初始化，out不用。
            //ChangeValueRef(ref b);报错
            ChangeValueOut(out b);//不报错

            Print(10);
            Print(a);
            //Print(c);    //报错，c未初始化
        }
    }
}