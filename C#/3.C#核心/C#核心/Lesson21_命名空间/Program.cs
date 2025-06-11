#region 知识点一：命名空间基本概念
//概念
//命名空间是用来组织和重用代码的
//作用
//就像是一个工具包，类就像是一件一件的工具，都是申明在命名空询中的
#endregion

#region 知识点二：命名空间的使用
//基本语法
//namespace 命名空间名
//{
//  类
//  类
//}
using MyGame;
using MyGame2;

namespace MyGame 
{
    class GameObject
    {

    }
}
namespace MyGame
{
    class Player:GameObject
    {

    }
}
//命名空间可以同名，但同一命名空间内的类不能同名
#endregion

#region 知识点四：不同命名空间中允许有同名类
namespace MyGame2
{
    //不同命名空间
    class GameObject
    {

    }
}
#endregion

#region 知识点五：命名空间可以包裹命名空间
namespace MyGame
{
    namespace UI
    {
        class Image
        {

        }
    }
    namespace Game
    {
        class Image
        {

        }
    }
}
#endregion

#region 知识点六：关于修饰类的访问修饰符
//public）—— 命名空间中的类
//internal—— 只能在该程序集中使用 默认为internal
//abstract—— 抽象类
//sealed  —— 密封类
//partial —— 分部类
#endregion

namespace Lesson21_命名空间
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("命名空间");

            #region 知识点三：不同命名空间相互使用 需要引用命名空间或指明出处
            MyGame.GameObject g = new MyGame.GameObject();
            MyGame2.GameObject g2 = new MyGame2.GameObject();

            MyGame.UI.Image image = new MyGame.UI.Image();
            MyGame.Game.Image image2 = new MyGame.Game.Image();
            #endregion
        }
    }
}
