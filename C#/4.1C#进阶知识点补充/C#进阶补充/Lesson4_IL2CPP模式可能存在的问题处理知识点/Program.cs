using System.Numerics;
using System.Reflection.Emit;

namespace Lesson4_IL2CPP模式可能存在的问题处理知识点
{
    public class A { }
    public class B { }
    public class C { }

    public class IL2CPP_Info
    {
        public List<A> list1;
        public List<B> list2;
        public List<C> list3;

        public  Dictionary<int, string> dict;

        public void Test<T>(T t) { }

        public static void TestStatic() 
        {
            IL2CPP_Info info = new IL2CPP_Info();
            info.Test<int>(1);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson4_IL2CPP模式可能存在的问题处理知识点");

            #region 知识点一：安装Unity IL2CPP打包工具
            //切换模式:
            //  在File→Build Settings→Player Settings→Other Settings中
            //  将Scripting Backend从Mono切换为IL2CPP

            //工具安装:
            //  通过Unity Hub→安装→添加模块
            //  选择对应平台(如Windows)的IL2CPP工具进行安装
            //  必须安装后才能正常使用IL2CPP打包功能
            #endregion

            #region 知识点二：类型裁剪问题及解决方案
            //问题描述:
            //IL2CPP打包时会自动裁剪未引用的类型以减小包体
            //但有些类型裁剪后仍然会被使用可能导致反射调用等运行时类型丢失异常

            //解决方案1:
            //设置剥离级别: Player Settings→Other Settings→Managed Stripping Level
            //  Disable: 仅Mono模式下可用，不删除任何代码
            //  Low(推荐): 保守删除，最大限度保留可能使用的代码
            //  Medium: 中等删除级别
            //  High: 激进删除，需配合link.xml使用

            //解决方案2:
            //使用link.xml:https://docs.unity3d.com/cn/2018.4/Manual/ManagedCodeStripping.html
            //在Assets目录创建link.xml文件
            //通过XML配置指定需要保留的类型和成员
            //支持保留整个程序集、特定类型或具体成员
            //可精细控制字段、方法、属性、事件等的保留

            //轻量级的游戏开发框架:https://github.com/jinglikeblue/ZeroGameKit

            #endregion

            #region 知识点三：泛型问题处理
            //我们上节课提到了IL2CPP和Mono最大的区别是 不能在运行时动态生成代码和类型
            //也就是说 泛型相关的类，如果你在打包生成前没有把之后想要使用的泛型类型显示使用一次
            //那么之后如果使用没有被编译的 类型就会出现找不到类型的报错
            //举例：List<A> 和 List<B> 中A和B是我们自定义的类，
            //我必须在代码中显示的调用过，IL2CPP才能保留List<A>和List<B>两个类型。
            //如果在热更新时我们调用List<C>，但是它之前并没有在代码中显示调用过，
            //那么这时就会出现报错等问题。主要就是因为JIT和AOT两个编译模式的不同造成的
            List<A> list1 = new List<A>();
            List<B> list2 = new List<B>();
            //解决方案：
            //  泛型声明一个类，然后在这个类中声明一些public的泛型类变量
            //  泛型方法：随便写一个静态方法，在将这个泛型方法在其中调用一下。这个静态方法无需被调用
            //  这样做的目的其实就是让预编译之前就让IL2CPP知道我们需要使用这个内容

            //特殊处理:
            //泛型类型需要在link.xml中特别声明
            //可保留泛型字段、方法和事件
            //示例：<field signature="System.Collections.Generic.List'1&lt;System.Int32&gt;field1"/>
            //条件保留:
            //使用required属性控制条件保留
            //如<type fullname="MyGame.I" preserve="fields" required="0"/>表示使用时保留字段
            #endregion
        }
    }
}
