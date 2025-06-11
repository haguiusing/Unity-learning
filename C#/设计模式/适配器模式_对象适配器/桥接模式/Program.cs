namespace 桥接模式
{
    // 实现类接口
    public interface IImplementor
    {
        void DrawCircle(int radius, int x, int y);
    }
    public class RedCircleImplementor : IImplementor
    {
        public void DrawCircle(int radius, int x, int y)
        {
            System.Console.WriteLine($"Drawing Circle[ color: red, radius: {radius}, x: {x}, y: {y}]");
        }
    }

    public class GreenCircleImplementor : IImplementor
    {
        public void DrawCircle(int radius, int x, int y)
        {
            System.Console.WriteLine($"Drawing Circle[ color: green, radius: {radius}, x: {x}, y: {y}]");
        }
    }

    public class Abstraction
    {
        protected IImplementor Implementor;

        // 添加用于绘制的参数
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Abstraction(IImplementor implementor)
        {
            Implementor = implementor;
        }

        // 实现Draw方法
        public virtual void Draw()
        {
            Implementor.DrawCircle(Radius, X, Y);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("桥接模式");

            // 创建不同颜色的圆的实现类
            IImplementor redCircleImplementor = new RedCircleImplementor();
            IImplementor greenCircleImplementor = new GreenCircleImplementor();

            // 创建抽象类实例并关联不同的实现类
            Abstraction redCircle = new Abstraction(redCircleImplementor)
            {
                X = 100,
                Y = 100,
                Radius = 10
            };

            Abstraction greenCircle = new Abstraction(greenCircleImplementor)
            {
                X = 100,
                Y = 100,
                Radius = 10
            };

            // 调用绘制方法
            redCircle.Draw();
            greenCircle.Draw();
        }
    }
}
