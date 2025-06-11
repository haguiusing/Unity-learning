using MathLibrary;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace 类库测试
{
    public class MrTang
    {
        

    }
}
//类库无法直接运行，
//类库通常包含了一系列的类、接口、结构体、枚举、委托等，
//这些成员可以被多个不同的程序或项目所使用。
//通过使用类库，开发者可以避免重复编写相同的代码，从而提高开发效率和代码质量。

//创建 C# 类库
//在 Visual Studio 中，你可以通过以下步骤创建一个 C# 类库项目：

//打开 Visual Studio。
//选择“创建新项目”。
//在“创建新项目”对话框中，搜索并选择“类库”（Class Library）模板，
//确保选择的是 C# 下的模板。
//点击“下一步”，填写项目名称、位置等信息，然后点击“创建”。

//创建一个用于数学计算的类库，我们可以创建一个名为 MathLibrary 的类库项目，
//并在其中添加一个名为 Calculator 的类。
namespace MathLibrary
{
    public class Calculator
    {
        // 加法  
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // 减法  
        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        // 乘法  
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        // 除法  
        public static int Divide(int a, int b)
        {
            if (b == 0)
                throw new System.DivideByZeroException("除数不能为0");
            return a / b;
        }
    }
}
//使用类库
//创建类库后，你可以在其他项目中引用这个类库，并使用其中的类和成员。
//在 Visual Studio 中，你可以通过“添加引用”对话框来添加对类库的引用。
//示例：在控制台应用程序中使用类库
//创建一个新的控制台应用程序项目。
//右键点击项目名称，选择“添加” -> “引用” -> “浏览”，然后找到并添加你的类库项目（通常是 .dll 文件）。
//在控制台应用程序中，你可以使用 using 指令来引用类库中的命名空间，然后就可以像使用本地类一样使用类库中的类了。