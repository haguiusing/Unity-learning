namespace Reflection
{
    internal class AssemblyClass
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";

        public AssemblyClass()
        {
            Console.WriteLine("AssemblyClass类的无参构造函数被调用");
        }

        public AssemblyClass(int j)
        {
            this.j = j;
            Console.WriteLine("AssemblyClass类的有参构造函数(int j)被调用");
        }

        public AssemblyClass(int i, string str) : this(i)
        {
            this.str = str;
            Console.WriteLine("AssemblyClass类的有参构造函数(int i, string str)被调用");
        }

        public void Speak()
        {
            Console.WriteLine("AssemblyClass类的Speak()方法被调用");
            Console.WriteLine(i);
        }
    }
}