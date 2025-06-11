using System.Runtime.ConstrainedExecution;
using static System.Formats.Asn1.AsnWriter;

namespace Lesson1_了解.Net相关知识
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson1_了解.Net相关知识");
            #region 知识点一：微软的.Net
            //.Net的定义: .Net不是编程语言，也不是框架，而是微软提供的一整套技术体系的统称，是微软的技术平台代号。
            //包含内容: .Net Framework, .Net Core, Mono等，以及开发语言如C#, VB, F#等。
            //C#的地位: C#是.Net平台主推的开发语言。
            //开发工具: 如Visual Studio, Visual Studio Code等。
            //跨语言: 允许使用不同编程语言（如C#, VB, C++等）编写的代码无缝集成在.Net平台下。
            //跨平台: 一次编译，无需修改代码，即可在多种操作系统（如Windows, Android, iOS, macOS）上运行。
            //微软的目的: 通过.Net平台，微软旨在垄断市场，鼓励开发者使用其提供的技术体系。

            //.Net的实现手段
            //跨语言实现: 通过.Net平台，不同语言编写的程序可以相互调用和集成。
            //跨平台实现: .Net应用可以在不同操作系统上运行，无需针对每个系统单独开发。
            #endregion

            #region 知识点二：.Net跨语言的实现
            //CLS（公共语言规范）
            //定义: CLS是公共语言规范（Common Language Specification）的简称，是一组语言互操作的标准规范。
            //作用: 它定义了不同编程语言之间需要遵守的共性规则，以确保代码能在.Net平台下被任意支持的语言所通用。

            //CTS（公共类型系统）
            //定义: CTS是公共类型系统（Common Type System）的简称，是设计面向.Net语言时需要遵循的体系。
            //关系: CTS包含了CLS，即CLS是CTS的一个子集。

            //CLI（公共语言基础结构）
            //是微软将CTS（Common Language Infrastructure）等内容提交给国际组织计算机制造联合会ECMA的一个工业标准

            //跨语言实现总结
            //实现方式: 微软为了实现跨语言，制定了一些规范，如CTS和CLS。只要一门语言支持CTS的规则，就能使用它在.Net平台下开发应用程序。
            //关系梳理: CLS是CTS的一个子集，CLI包含了CTS，是微软提交给国际组织的工业标准。
            //意义: 遵循这些规范，开发者可以在.Net平台下使用多种语言进行开发，实现跨语言互操作。

            //关于CLR、CIL、CTS、CLS、CLI、BCL和FCL 的区分与总结
            //https://www.cnblogs.com/xiekeli/p/4680846.html
            //CLR，公共语言运行时（Common Language Runtime）是一个由多种语言使用的“运行时”。
            //他的核心功能包括（内存管理、程序集加载、安全性、异常处理和线程同步），可以被面向CLR的所有语言使用。
            //这里的“运行时”，就是一个运行时环境.

            //BCL，基础类库（Base Class Library）
            //BCL是一个公共编程框架，称为基类库，所有语言的开发者都能利用它。
            //是CLI（Common Language Infrastructure，公共语言基础结构）的规范之一，
            //主要包括：执行网络操作，执行I / O操作，安全管理，文本操作，数据库操作，XML操作，
            //与事件日志交互，跟踪和一些诊断操作，使用非托管代码，创建与调用动态代码等，
            //粒度相对较小，为所有框架提供基础支持。

            //FCL，框架类库（Framework Class Library）
            //FCL提供了大粒度的编程框架，它是针对不同应用设计的框架 ，FCL大部分实现都引用了BCL，
            //例如我们常说的开发框架：ASP.NET、MVC、WCF和WPF等等，提供了针对不同层面的编程框架 。

            //CLI > CLR/CTS > C#/VB/F# > CLS > BCL/FCL
            #endregion

            #region 知识点三：.Net跨平台的实现
            //框架定位: 早期.Net Framework是主要用于跨语言开发的Windows操作系统下的应用程序框架。

            //.Net Framework https://learn.microsoft.com/zh-cn/dotnet/framework/get-started/overview
            //.Net Framework 在2002年推出1.0版本
            //.NET Framework 是一个可以快速开发、部署网站服务及应用程序的开发框架是 Windows 中的一个组件, 部分开源, 主要用于开发Windows下应用程序包括
            //  公共语言运行时(Common Language Runtime, CLR)
            //  虚拟执行系统
            //  .NET Framework 类库等
            //不支持跨平台: 需注意.Net Framework不支持跨平台开发。
            //核心特性: 通过CLR和CIL代码实现跨语言特性，不同语言编写的代码最终都能在Windows操作系统上运行。

            //.Net Core
            //Net Core与.Net Framework的关系 
            //推出时间: .Net Core于2016年推出。
            //关系: .Net Core是.Net Framework的新一代版本，类似于.Net Framework的“兄弟”。
            //实现语言: C#、VB、C++、JScript等是.Net Framework的实现语言，.Net Core也支持这些语言。
            //开源性: .Net Core是一个开源项目。
            //.Net Core的跨平台原理 
            //设计目的: .Net Core的主要目的是实现跨平台。
            //跨平台实现: 通过为不同的操作系统实现对应的CLR（公共语言运行时），即Core RT和Core CLR，使得.Net Core能够在Windows、MacOS、Linux等系统上运行。
            //Core RT: 用于在不同平台使用不同技术将代码转码为机器码。
            //Core CLR: 是CLR的移植，性能更高，作为实时编译器将IL（中间代码）翻译成机器码。
            //.Net Core的类库与CLR的修改
            //类库: .Net Core基于.Net Framework的FCL（框架类库）和BCL（基础类库）进行了修改，形成了CoreFX，以适应不同操作系统的需求。
            //CLR修改: .Net Core对CLR进行了修改，分为Core RT和Core CLR两部分，以实现跨平台运行。
            //.Net Core的工作流程
            //工作流程: 编写的代码首先被编译成IL（中间代码），然后由Core CLR将IL翻译成目标操作系统可以执行的机器码。
            //跨平台能力: 通过Core RT和Core CLR的协同工作，.Net Core能够在不同的操作系统上运行相同的代码。

            //从.Net Framework到.Net Core的跨平台之路 
            //.Net Framework: 并不跨平台，于2002年正式问世。
            //空窗期: 从.Net Framework问世到.Net Core诞生的14年间，.Net平台并没有官方的跨平台解决方案。
            //Mono: 在这段空窗期内，Mono作为一个开源项目，提供了.Net的跨平台支持。
            //.Net Core诞生: 2016年，.Net Core作为官方的跨平台解决方案诞生。
            //总结: .Net Core是在.Net Framework基础上发展起来的，通过修改类库和CLR，实现了跨平台的能力。从.Net Framework到.Net Core，标志着.Net平台从单一平台走向了跨平台的新时代。

            //Mono 
            //Mono概述
            //定义: Mono是一个由Xamarin公司（已被微软收购）赞助的开源项目。
            //基础: 基于.Net的CLI（Common Language Infrastructure）公共语言基础结构。
            //功能: 提供了微软.Net Framework的另一种实现，具备跨平台能力。
            //版本: 1.0版本出现在2004年，是.Net平台实现跨平台的不二之选（在.Net Core出现之前）。
            //Mono如何实现跨平台
            //原理:
            //利用.Net平台制定的CLI公共语言基础结构规则。
            //将多种语言编译成通用规范的CIL（Common Intermediate Language）公共中间语言。
            //再利用CLR（Common Language Runtime）公共语言运行时，将这些CIL转换为操作系统的原生代码。
            //实现: 在各种操作系统上实现了对应的CLR内容，使得用各种不同语言编写的逻辑能够在指定操作系统上运行。
            //与.Net Framework的关系: Mono的这套规则是在.Net Framework规则上进行的修改和添加。
            //相似点:
            //Mono和.Net Core的实现原理非常相似，都是把语言编译成中间语言，再由公共语言运行时翻译成对应的机器码。
            //Mono会在各个操作系统上实现对应的CLR，以达到跨平台的效果。
            //区别:
            //Mono出现的时间比.Net Core早很多，早在2004年就可以基于.Net Framework来实现跨平台。
            //Mono在实现跨平台时，会有一些Mono的中间公共库，根据不同操作系统实现了一套Mono的库。

            //总结如何实现的跨平台
            //跨平台实现方式
            //.Net Framework: 2002年发布，部分开源，主要用于开发Windows平台下的应用，包含Windows平台的所有特性。
            //.Net Core: 2016年发布，完全开源，可以针对多个平台开发应用，包含.Net Framework的部分特性。
            //Mono: 2004年发布，完全开源，是.Net的跨平台解决方案，早期乃至现在也是通过Mono来实现.Net的跨平台。
            //跨平台实现历史: 在.Net Core出现之前，开发者主要通过Mono来实现.Net的跨平台。使用基于.Net平台的Mono开发，可以发布在各主流的操作系统上面能够运行的应用程序。2016年之后，可以选择使用.Net Core来实现跨平台。
            //学习建议: 对于现在很多学习.Net平台的开发者来说，基本上只用学习.Net Core即可，因为.Net Framework的部分特性已经包含在.Net Core中。
            #endregion
        }
    }
}
