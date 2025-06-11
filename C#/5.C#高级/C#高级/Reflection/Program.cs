using System.Reflection;

namespace Reflection
{
    //反射

    //核心类：
    //  1.Assembly类  表示一个程序集，该程序集是公共语言运行时应用程序的可重用、可版本控制且自描述的构建基块。
    //  2.Type类  表示类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型的类型声明。
    //  3.Constructorlnto类  发现类构造函数的属性信息，并提供对构造函数元数据的访问权限。
    //  4.Methodinto类  发现方法的属性信息并提供对方法元数据的访问。
    //  5.Fieldlnfo类  描述了类的字段信息并提供对字段元数据的访问。
    //  6.Propertylnfo类  描述类的属性信息
    //  7.MemberInfo类  获取有关成员属性的信息并提供对成员元数据的访问权限。
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Assembly

            //获取程序集
            //一个完整的C#项目，都会有一套统一的模式。
            //解决方案-- > 程序集-- > 命名空间-- > 类-- > 方法
            //主要用来加载其它程序集，加载后
            //才能用Type来使用其它程序集中的信息

            Assembly assembly = typeof(AssemblyClass).Assembly;  //加载AssemblyClass的程序集
            Console.WriteLine("程序集名称：" + assembly.FullName);

            //Assembly.Load 方法(4个重载）
            //一般用来加载在同一文件下的其它程序集
            String path = "F:\\Unity学习\\C#\\5.C#高级\\C#高级\\Reflection\\bin\\Debug\\net8.0\\Reflection";
            //byte[] assemblyData = File.ReadAllBytes(path);// 从文件中读取程序集的字节
            //Assembly assembly_loadByByteArray = Assembly.Load(assemblyData);  // Load(Byte[])

            //Assembly asembly_loadByString = Assembly.Load("程序集名称");  //Load(String)

            //AssemblyName assemblyName = new AssemblyName { Name = "System", Version = new Version("4.0.0.0") };// 创建程序集名称
            //Assembly assembly_loadByAssemblyName = Assembly.Load(assemblyName);// 加载程序集

            //assemblyData = File.ReadAllBytes("path_to_assembly.dll");
            //byte[] symbolData = File.ReadAllBytes("path_to_symbols.dll"); // 可选的符号文件
            //Assembly assembly_loadByDoubleByteArray = Assembly.Load(assemblyData, symbolData);// 加载程序集和符号

            //一般用来加载不在同一文件下的其它程序集
            //Assembly.LoadFile 方法
            //Assembly asembly3 = Assembly.LoadFile(”要加载的文件的完全限定路径");

            //Assembly.LoadFrom 方法
            Assembly assembly_loadFrom = Assembly.LoadFrom(path); //"包含程序集清单的文件的名称或路径"

            #endregion Assembly

            //获取程序集元素
            Type[] types = assembly.GetTypes();
            Type? type = assembly_loadFrom.GetType("Reflection.AssemblyClass");
            Console.WriteLine(assembly_loadFrom?.FullName);
        }
    }
}