using System.Numerics;

namespace Lesson14_模式匹配switch表达式属性位置元组模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson14_模式匹配switch表达式属性位置元组模式");
            #region 知识点一：模式匹配回顾_Lesson12
            //1）模式匹配的概念 
            //模式匹配: 是一种测试表达式是否具有特定特征的方法。在编程里，指的是把一个不知道具体数据信息的内容，通过一些固定的语法格式来确定模式数据的具体内容的过程。
            //
            //2）常量模式
            //常量模式: 是对is的一种拓展，通过is后面加一个常量来判断一个变量是否是某一个值。例如，object o = 1.5f; if (o is 1) 判断o是否是1。
            //
            //3）类型模式
            //类型模式: 在常量模式基础上进行变化，用is来判断变量是否是某一个类型，并直接在该类型后面声明一个变量名，将前面对象的值存入该变量中。
            //
            //4）var模式
            //var模式: 类似于类型模式，但后面跟的是var和一个变量名，不论前面是什么类型，都会把变量装到和它类型一样的新变量里。
            //作用: 可以通过一句代码把变量取出来，不需要在前面声明，更节约代码量，使代码看起来更优雅。
            //示例:
            //对比: 以前需要先声明变量，再判断值；现在可以直接通过var模式一行代码完成判断和变量声明。

            //F:\Unity学习\C#\4.1C#进阶知识点补充\C#进阶补充\Lesson12_元组模式匹配抛出表达式等知识点\Lesson12_元组模式匹配抛出表达式等知识点.csproj
            #endregion

            #region 知识点二：模式匹配增强功能——switch表达式
            //switch表达式是对有返回值的switch语句的缩写
            //用=>表达式符号代替case:组合
            //用_弃元符号代替default
            //它的使用限制,主要是用于switch语句当中只有一句代码用于返回值时使用
            //语法:
            //  函数声明 => 变量 switch
            //  {
            //   常量=>返回值表达式,
            //   常量=>返回值表达式,// 常量=>返回值表达式,
            //   ...
            //   _ => 返回值表达式,
            //  }

            Console.WriteLine(GetPos1(PosType.Top_Left));
            Console.WriteLine(GetPos2(PosType.Top_Left));
            #endregion

            #region 知识点三：模式匹配增强功能——属性模式
            //就是在常量模式的基础上判断对象上各属性
            //用法: 变量 is {属性:值, 属性:值}
            DiscountInfo info = new DiscountInfo("5折", true);
            if (info is {discount: "5折", isDiscount: true })  //= if(info.discount == "5折" && info.isDiscount == true)
                Console.WriteLine("信息相同");
            else
                Console.WriteLine("信息不同");

            Console.WriteLine(GetMoney(info, 100));
            //它可以综合switch表达式使用
            //结合switch使用可以过属性模式判断条件的组合
            #endregion

            #region 知识点四：模式匹配增强功能——元组模式
            //通过刚才学习的属性模式我们可以在switch表达式中判断多个变量同时满足可返回什么
            //但是它必须是一个数据结构类对象, 判断其中的变量
            //而且模式可以更简单的完成这样的功能, 我们不需要声明数据结构类, 可以直接利用元组进行判断
            int ii = 10;
            bool bb = true;
            if ((ii, bb) is (11, true))
            {
                Console.WriteLine("元组的值相同");
            }
            //举例说明
            Console.WriteLine(GetMoney("5折", true, 100));
            #endregion

            #region 知识点五：模式匹配增强功能——位置模式
            //如果自定义类中实现了解构函数
            //那么我们可以直接用对应类对象元组进行is判断
            if (info is ("5折", true))
            {
                Console.WriteLine("位置模式 满足条件");
            }

            //同样我们也可以配合switch表达式来处理逻辑
            //举例说明
            Console.WriteLine(GetMoney2(info, 100));

            //补充：配合when关键字了进行逻辑处理
            #endregion
        }

        public static Vector2 GetPos1(PosType type) => type switch
        {
            PosType.Top_Left => new Vector2(0, 0),
            PosType.Top_Right => new Vector2(1, 0),
            PosType.Bottom_Left => new Vector2(0, 1),
            PosType.Bottom_Right => new Vector2(1, 1),
            _ => new Vector2(0, 0)
        };

        public static Vector2 GetPos2(PosType type)
        {
            switch (type)
            {
                case PosType.Top_Left:
                    return new Vector2(0, 0);
                case PosType.Top_Right:
                    return new Vector2(1, 0);
                case PosType.Bottom_Left: 
                    return new Vector2(0, 1);
                case PosType.Bottom_Right:
                    return new Vector2(1, 1);
                default: 
                    return new Vector2(0, 0);
            }
        }

        //属性模式
        public static float GetMoney(DiscountInfo info, float money) => info switch
        {
            //可以利用属性模式 结合 switch 表达式 判断n个条件的组合
            { discount: "5折", isDiscount: true } => money * .5f,
            { discount: "6折", isDiscount: true } => money * .6f,
            { discount: "7折", isDiscount: true } => money * .7f,
            _ => money
        };

        //元组模式
        public static float GetMoney(string discount, bool isDiscount, float money) => (discount, isDiscount) switch
        {
            ("5折", true) => money * .5f,
            ("6折", true) => money * .6f,
            ("7折", true) => money * .7f,
            _ => money
        };

        //位置模式
        public static float GetMoney2(DiscountInfo info, float money) => info switch
        {
            ("5%", true) when money >100 => money * 5f,
            ("6%", true) => money * 6f,
            ("7%", true) => money * .7f,
            _ => money
        };

        public static float GetMoney3(DiscountInfo info, float money) => info switch
        {
            (string dis, bool isDis) when dis == "5折" && isDis => money * .5f,
            _ => money
        };
    }

    public enum PosType
    {
        Top_Left,
        Top_Right,
        Bottom_Left,
        Bottom_Right
    }

    public class DiscountInfo
    {
        public string discount;
        public bool isDiscount;
        public DiscountInfo(string discount, bool isDiscount)
        {
            this.discount = discount;
            this.isDiscount = isDiscount;
        }

        /// <summary>
        /// 解构函数
        /// </summary>
        /// <param name="dis"></param>
        /// <param name="isDis"></param>
        public void Deconstruct(out string dis, out bool isDis)
        {
            dis = this.discount;
            isDis = this.isDiscount;
        }

    }

}
