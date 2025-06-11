
namespace 适配器模式_对象适配器
{
    // 目标抽象类/接口
    public interface ITarget
    {
        void Request();
    }

    // 被适配者类
    public class Adaptee
    {
        public void SpecificRequest()
        {
            System.Console.WriteLine("Adaptee.SpecificRequest");
        }
    }

    // 适配器类
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            _adaptee.SpecificRequest();
            System.Console.WriteLine("Adapter.Request: After SpecificRequest");
        }
    }

    // 客户类
    public class Client
    {
        public void Main()
        {
            ITarget target = new Adapter(new Adaptee());
            target.Request();
        }
    }
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");
    //    }
    //}
}
