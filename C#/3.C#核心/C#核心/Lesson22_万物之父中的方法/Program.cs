using static System.Net.Mime.MediaTypeNames;

namespace Lesson22_万物之父中的方法
{
    class Test
    {
        public int i = 1;
        public Test2 test2 = new Test2();

        public Test Clone()
        {
            return MemberwiseClone() as Test;
        }

        //重写Object中的虚方法
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "自定义ToString";
        }
    }
    class Test2
    {
        public int i = 2;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("万物之父中的方法");

            #region 知识点一：object中的静态方法
            //静态方法 Eguals 判断两个对象是否相等
            //最终的判断权，交给左侧对象的 Equals 方法
            //不管值类型引用类型都会按照左侧对象 Equa1s 方法的规则来进行比较
            Console.WriteLine(Object.Equals(1, 1));  
            //值类型判断 对比两个对象是否相等


            Test t = new Test();
            Test t2 = new Test();
            Console.WriteLine(object.Equals(t, t2));
            //引用类型判断 对比的是两个对象 是否指向同一内存地址，并不是判断是否是相同类型

            //静态方法ReferenceEquals
            //比较两个对像是否是相同的引用，主要是用来比较引用类型的对象.
            //值类型对象返回值始终是false.
            Console.WriteLine(object.ReferenceEquals(1, 1));
            Console.WriteLine(object.ReferenceEquals(t, t2));
            #endregion

            #region 知识点二：object中的成员方法
            // 普通方法GetType
            // 该方法在反射相关知识点中是非常重要的方法，之后我们会具体的讲解这里返回的Type类型。
            // 该方法的主要作用就是获取对象运行时的类型Type。
            // 通过Type结合反射相关知识点可以做很多关于对象的操作
            Test t3 = new Test();
            Type type = t3.GetType();

            //普通方法MemberwiseClone
            //该方法用于获取对象的浅拷贝对象，口语化的意思就是会返回一个新的对象
            //但是新对象中的引用变量会和老对象中一致
            Test t4 = t3.Clone();
            Console.WriteLine("克隆对象前");
            Console.WriteLine("t3.i=" + t3.i);
            Console.WriteLine("t3.test2.i=" + t3.test2.i);
            Console.WriteLine("t4.i=" + t4.i);
            Console.WriteLine("t4.test2.i=" + t4.test2.i);

            t4.i = 20;
            t4.test2.i = 21;
            Console.WriteLine("t3.i=" + t3.i);
            Console.WriteLine("t3.test2.i=" + t3.test2.i);
            Console.WriteLine("t4.i=" + t4.i);
            Console.WriteLine("t4.test2.i=" + t4.test2.i);
            //浅拷贝：值类型直接复制过来，引用类型复制的是内存地址。
            //所以改变拷贝后的值类型变量与拷贝前的值类型变量无关，改变拷贝后的引用类型变量
            //拷贝前的引用类型变量也会跟着改变
            #endregion

            #region 知识点三：object中的虚方法
            // 虚方法Equals
            // 默认实现还是比较两者是否为同一个引用，即相当于ReferenceEquals
            // 但是微软在所有值类型的基类system.ValueType中重写了该方法，用来比较值相等.
            // 我们也可以重写该方法，定义自已的比较相等的规则

            // 虚方法GetHashCode 
            // 该方法是获取对象的哈希码 
            //（一种通过算法算出的，表示对象的唯一编码，不同对象哈希码有可能一样，具体值根据哈希算法决定 
            // 我们可以通过重写该函数来自己定义对象的哈希码算法，正常情况下，我们使用的极少，基本不用。

            //虚方法ToString
            //该方法用于返回当前对象代表的字符串，我们可以重写它定义我们己的对象转字符事规则,
            //该方法非常常用。当我们调用打印方法时，默认使用的就是对象的Tostring方法后打印出来的内容.

            Console.WriteLine(t);
            #endregion
        }
    }
}
