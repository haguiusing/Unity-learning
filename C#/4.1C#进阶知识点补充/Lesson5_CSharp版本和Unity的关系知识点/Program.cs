namespace Lesson5_CSharp版本和Unity的关系知识点
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson5_CSharp版本和Unity的关系知识点");

            #region 知识点一：各Unity版本支持的C#版本
            //版本对应关系：
            //  Unity 5.5 支持 C#4
            //  Unity 2017 支持 C#6
            //  Unity 2019.4 支持 C#7.3
            //  Unity 2020.3 支持 C#8
            //  Unity 2021.2 支持 C#9

            //查询方式：可通过Unity官方文档查看具体版本对应关系，链接：https://docs.unity3d.com/2020.3/Documentation/Manual/CSharpCompiler.html
            #endregion

            #region 知识点二：不同Unity版本支持不同C#版本的原因
            //核心原因：不同Unity版本使用的C#编译器和脚本运行时版本不同
            //示例说明：
            //  Unity 2020.3使用的脚本运行时版本等效于.NET 4.6
            //  编译器采用Roslyn(罗斯林编译器)
            //  更新机制：随着Unity更新会采用较新的编译器和运行时版本，带来新版C#和.NET功能
            #endregion

            #region 知识点三：不同C#版本的意义
            //开发优势：
            //  可以使用各版本新功能进行编程
            //  新功能可写出更简单明了的代码
            //  能有效节约代码量
            //使用建议：
            //  非必须使用新功能，基础功能已能满足开发需求
            //  新功能可锦上添花，根据实际情况选择性使用
            #endregion

            #region 知识点四：Unity的.NET API兼容级别
            //设置位置：PlayerSetting->Other Setting->Api Compatibility Level
            //.NET 4.x：
            //  具备完整.NET API，包含无法跨平台的API
            //  适用于主要针对Windows平台且需要使用.NET Standard 2.0中没有的功能时
            //.NET Standard 2.0：
            //  标准API集合，内容比.NET 4.x少
            //  可减小最终可执行文件大小
            //  具有更好的跨平台支持
            //  配置文件大小是.NET 4.x的一半
            //  推荐选择：正常情况下建议使用.NET Standard 2.0
            #endregion

            #region 总结
            //版本更新规律：
            //新版本Unity会同时更新脚本运行时和C#编译器版本
            //随着Unity版本提升，能使用的C#新功能和特性也会增加
            //开发建议：
            //了解当前使用的Unity版本支持的C#版本
            //开发时可根据版本支持情况使用对应新功能
            //API兼容级别：
            //正常情况下推荐使用.NET Standard 2.0
            //特殊需求时才考虑使用.NET 4.x
            #endregion
        }
    }
}
