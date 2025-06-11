namespace 素数
{
    internal class Program
    {
        public static void GetPrimes1(int n)
        {
            int count = 0;
            for(int i = 1; i <= n; i++)
            {
                for(int j = 2;j <= i; j++)
                {
                    if (i % j == 0 && i!= j)
                        break;

                    if (j == i)
                    {
                        count++;
                        Console.WriteLine(i);
                    }
                }
            }
        }

        public static void GetPrimes2(int n)
        {
            if(n < 2)
            {
                return;
            }

            int count = 0;
            if (n >= 2)
            {
                count++;
                Console.WriteLine(2);
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 2; i == 3 || j <= i / 2; j++) 
                {
                    if (i % j == 0) 
                        break;

                    if (i / 2 <= j) 
                    {
                        count++;
                        Console.WriteLine(i);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //GetPrimes1(100);

            GetPrimes2(100);
        }
    }
}
