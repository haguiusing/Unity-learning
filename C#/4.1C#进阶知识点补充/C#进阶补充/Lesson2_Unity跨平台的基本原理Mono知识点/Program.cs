namespace Lesson2_Unity跨平台的基本原理Mono知识点
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson2_Unity跨平台的基本原理Mono知识点");

            #region 知识点一：Unity和Mono的关系
            //底层实现：Unity引擎底层使用C / C++编写，包含平台相关代码、图形API、物理引擎等核心功能
            //上层开发：通过Mono支持多语言开发（最初支持C#/JavaScript/Boo，现仅保留C#）
            //选择原因：
            //跨平台特性：Mono基于.NET的跨平台方案，2004年发布时完美匹配Unity需求
            //跨语言特性：支持多种语言编译为统一中间代码
            //开发友好：相比C++更易学习，降低开发者门槛
            #endregion

            #region 知识点二：Unity跨平台的必备概念
            //Unity主要包括两个部分：
            //  Unity Engine（引擎）:
            //      提供UnityEngine.dll动态库，各平台不同，C / C++编写，包含平台相关代码、图形API、物理引擎、灯光等等所有游戏引擎底层内容
            //  Unity Editor（编辑器）:
            //      提供UnityEditor.dll动态库，大部分由C#编写，用户脚本最初可以使用C#、JavaScript、Boo语言编写，项目代码最后由Mono编译
            //      础类库：提供基础功能支持
            //      Mono类库：扩展.NET功能，支持多平台应用开发
            //      技术基础：Mono基于.NET的CLI（公共语言基础结构）规则开发
            //  核心组件：
            //      C#编译器(mcs)：将源代码编译为CIL中间代码
            //      Mono运行时：包含JIT / AOT编译器、GC、类库加载器等
            //      BCL基础类库：提供基础功能支持
            //      Mono类库：扩展.NET功能，支持多平台应用开发
            #endregion

            #region 知识点三：Unity跨平台的基本原理（Mono）
            //编译阶段：通过Mono编译器将C#代码转为CIL中间代码
            //运行阶段：Mono运行时（虚拟机）将中间代码转换为各平台原生机器码
            //关键技术：
            //  CLI规范：确保多语言可编译为统一中间格式
            //  虚拟机抽象：隔离平台差异，实现"一次编写，到处运行"
            #endregion

            #region 知识点四：基于Mono跨平台的优缺点
            //优点：
            //  平台扩展性强：只需为新平台实现Mono VM即可支持
            //  开发效率高：统一代码库支持多平台部署
            //缺点：
            //  维护成本高：需为每个平台维护虚拟机实现
            //  特性滞后：低版本Mono无法支持新版C#特性
            //  性能损耗：虚拟机转换带来额外开销
            #endregion
        }
    }
}
