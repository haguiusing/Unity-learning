namespace Lesson3_Unity跨平台的基本原理IL2CPP知识点
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson3_Unity跨平台的基本原理IL2CPP知识点");

            #region 知识点一：IL2CPP是什么
            //IL2CPP: IL2CPP（Intermediate Language To C++）是Unity提供的一个后端编译器，
            //它将Unity的C#代码（以及UnityScript、BOO脚本）转换成C++代码，
            //然后编译成平台特定的机器码。这使得Unity游戏可以在多种平台上高效运行。
            //作用: 提高游戏性能，特别是对于那些对性能要求较高的游戏或应用。
            #endregion

            #region 知识点二：Mono跨平台回顾
            //Mono: Mono是一个开源的.NET Framework实现，支持多种操作系统，包括Windows、Linux和macOS。它使得开发者可以用C#等语言编写跨平台的应用程序。
            //特点: 提供了广泛的API兼容性，使得Unity可以在Mono环境下运行C#脚本。
            #endregion

            #region 知识点三：IL2CPP跨平台原理
            //Mono: Mono是一个开源的.NET Framework实现，支持多种操作系统，包括Windows、Linux和macOS。它使得开发者可以用C#等语言编写跨平台的应用程序。
            //特点: 提供了广泛的API兼容性，使得Unity可以在Mono环境下运行C#脚本。

            //需要注意的是
            //虽然中间代码变为了C++
            //但是内存管理还是遵循C#中GC的方式
            //这也是为什么有一个IL2CPP VM（虚拟机）存在的原因，它主要是用来完成
            //GC管理，线程创建等服务工作的
            #endregion

            #region 知识点四：Mono和IL2CPP的区别
            //Mono
            //  1.构建（最终打包时）速度快
            //  2.Mono编译机制是JIT即时编译, 所以支持更多类库
            //  3.必须将代码发布为托管程序集(.dll文件)
            //  4.Mono VM虚拟机平台维护麻烦, 且部分平台不支持 (WebGL)
            //  5.由于Mono版本授权原因, C#很多新特性无法使用
            //  6.iOS支持Mono, 但不在允许32位的Mono应用提交到应用商店

            //IL2CPP
            //  1.相对Mono构建（最终打包时）速度慢
            //  2.只支持AOT提前编译
            //  3.可以启用引擎代码剥离来减少代码的大小
            //  4.程序的运行效率比Mono高，运行速度快
            //  5.多平台移植更加方便

            //Mono和IL2CPP的最大区别就是
            //IL2CPP不能在运行时动态生成代码和类型
            //所以必须在编译时就完全确定需要用到的类型
            //举例：List<A> 和 List<B> 中 A 和 B 是我们自定义的类, 我能必须在代码中显示的调用过, IL2CPP 才能保留 List<A> 和 List< B > 两个类型。如果在热更新时我们调用 List<C>, 但是它之前并没有在代码中显示调用过, 那么这时就会出现报错等问题。主要就是因为JIT和AOT两个编译模式的不同造成的
            //具体的解决方案我们在下节课中讲解

            #endregion

            #region 知识点五：Mono和IL2CPP两种方式的使用建议
            //根据项目需求选择:
            //  对于需要快速迭代和频繁更新的项目，Mono可能更合适。
            //  对于性能要求较高的项目，如大型3D游戏，IL2CPP是更好的选择。
            //  结合使用: 在开发过程中，也可以考虑结合使用两种技术，比如开发阶段使用Mono，发布时使用IL2CPP进行最终编译。
            #endregion
        }
    }
}
