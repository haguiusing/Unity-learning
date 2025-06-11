
namespace Lesson10_运算符重载
{
    #region 知识点一：基本概念
    //概念
    //让自定义类和结构体
    //能够使用运算符

    //使用关键字
    //operator

    //特点
    //1.一定是一个公共的静态方法
    //2.返回值写在operator前
    //3.逻辑处理自定义

    //作用
    //让自定义类和结构体对象可以进行运算
    //注意
    //1.条件运算符需要成对实现
    //2.一个符号可以多个重戟
    //3.不能使用ref和out
    #endregion

    #region 知识点二：基本语法
    //public static 返回类型 operator 运算符（参数列表）
    #endregion

    #region 知识点三：实例
    class Point
    {
        public int x;
        public int y;

        //至少包含一个Point参数
        public static Point operator +(Point a, Point b)
        {
            Point p = new Point();
            p.x = a.x + b.x;
            p.y = a.y + b.y;
            return p;
        }

        public static Point operator +(Point a, int value)
        {
            Point p = new Point();
            p.x = a.x + value;
            p.y = a.y + value;
            return p;
        }

        #region 知识点五：可重载和不可重载的运算符
        //可重载的运算符
        #region 算数运算符：   +  -   *   /   %   ++   --
        //注意 符号需要两个参数还是一个参数
        //public static Point operator +(Point a, Point b)
        //{
        //    return null;
        //}
        public static Point operator -(Point a, Point b)
        {
            return null;
        }
        public static Point operator *(Point a, Point b)
        {
            return null;
        }
        public static Point operator /(Point a, Point b)
        {
            return null;
        }
        public static Point operator %(Point a, Point b)
        {
            return null;
        }
        public static Point operator ++(Point a)
        {
            return null;
        }
        public static Point operator --(Point a)
        {
            return null;
        }
        #endregion

        #region 逻辑运算符：  ！
        //注意 符号需要两个参数还是一个参数
        public static bool operator !(Point a)
        {
            return false;
        }
        #endregion

        #region 位运算符：       &   |  ^  ~  <<  >> 
        //注意 符号需要两个参数还是一个参数
        public static Point operator &(Point a, Point b)
        {
            return null;
        }
        public static Point operator |(Point a, Point b)
        {
            return null;
        }
        public static Point operator ^(Point a, Point b)
        {
            return null;
        }
        public static Point operator ~(Point a)
        {
            return null;
        }
        public static Point operator <<(Point a, Point b)
        {
            return null;
        }
        public static Point operator >>(Point a, Point b)
        {
            return null;
        }
        #endregion

        #region 条件运算符:      <  <=  >  >=  ==  != 
        //1.返回值一般是boo1值 也可以是其它的
        //2.相关符号必须配对实现
        public static bool operator <(Point a, Point b)
        {
            return false;
        }
        public static bool operator <=(Point a, Point b)
        {
            return false;
        }
        public static bool operator >(Point a, Point b)
        {
            return false;
        }
        public static bool operator >=(Point a, Point b)
        {
            return false;
        }
        public static bool operator ==(Point a, Point b)
        {
            return false;
        }
        public static bool operator !=(Point a, Point b)
        {
            return false;
        }
        #endregion

        //不可重载的 运算符
        #region 逻辑运算符 ：  &&    ||   [ ] ()  .  =   ?:
        //逻辑与(&&) 逻辑或(||)
        //索引符 []
        //强转运算符 (）
        //特殊运算符
        //点.
        //三目运算符?：
        //赋值符号=
        #endregion

        #endregion
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("运算符重载");

            #region 知识点四：使用
            Point p1 = new Point();
            Point p2 = new Point();

            p1.x = 1;
            p1.y = 2;
            p2.x = 1;
            p2.y = 2;

            Point p3 = p1 + p2;
            Point p4 = p3 + 3;
            //Point p5 = 3 + p3;  //对顺序有要求
            #endregion
        }
    }
}
