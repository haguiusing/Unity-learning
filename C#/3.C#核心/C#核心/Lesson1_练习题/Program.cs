namespace Lesson1_练习题
{
    class GameObject()
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类和对象练习题");

            #region 练习题一：
            //将下面的事物进行分类，可重复
            //机器人、机器、人、猫、张阿姨、隔壁老王、汽车、飞机、向日葵、菊花、太阳、星星、荷花
            //机器: 机器人、机器、汽车、飞机
            //人:人、张阿姨、阳壁老王
            //动物:猫、人、张阿块、隔壁老王
            //植物: 向日要、菊花、荷花
            //星球：太阳、星星

            #endregion

            #region 练习题二：
            GameObject A = new GameObject();
            GameObject B = A;
            B = null;
            //A目前等于多少？
            //A地址不变，B=null
            //断点查看，&A、&B、F10

            #endregion

            #region 练习题三：
            GameObject C = new GameObject();
            GameObject D = C;
            D = new GameObject();
            //C和D有什么关系?
            //没有关系
            #endregion
        }
    }
}
