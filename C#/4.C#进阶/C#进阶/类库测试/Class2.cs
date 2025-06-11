using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;  
using MathLibrary; // 引用类库中的命名空间 

namespace 类库测试
{
    internal class Class2
    {

    }
}
  
namespace ConsoleApp
{
#region 引用类库中的命名空间来使用类库
    class Program
    {
        static void Main(string[] args)
        {
            int result = Calculator.Add(5, 3);
            Console.WriteLine($"5 + 3 = {result}");

            // 使用类库中的其他方法...  
        }

        #region 利用反射来使用类库
        //1. 加载类库
        //首先，你需要确保你的项目引用了目标类库，
        //或者你可以通过Assembly.Load方法在运行时动态加载类库（DLL）。
        
        // 假设类库名为 MyLibrary.dll，并且它位于应用程序的 bin 目录下  
        static Assembly assembly = Assembly.Load("MyLibrary");
        //如果你知道类库的完整路径，也可以使用Assembly.LoadFile方法：
        
        static string assemblyPath = @"C:\path\to\MyLibrary.dll";
        Assembly assembly1 = Assembly.LoadFile(assemblyPath);
        //2.获取类型信息
        //一旦加载了类库，你就可以通过类名来获取Type对象，进而访问该类型的成员。
        
        static Type type = assembly.GetType("MyLibrary.MyClass");
        //这里"MyLibrary.MyClass"是类名的完全限定名，包括其命名空间。
        
        //3. 创建对象实例
        //如果你想要创建该类型的一个实例，可以使用Activator.CreateInstance方法。
        
        static object instance = Activator.CreateInstance(type);
        //4.调用方法
        //在获取了类型实例后，你可以使用MethodInfo来调用该类型的方法。
        //首先，你需要获取MethodInfo对象，然后调用Invoke方法。
        
        // 假设 MyClass 有一个无参数的方法名为 MyMethod  
        static MethodInfo methodInfo = type.GetMethod("MyMethod");
        
        // 调用无参数的方法  
        //methodInfo.Invoke((instance, null)); // 第二个参数是方法的参数数组，这里为 null 因为 MyMethod 无参数  
        
        // 如果 MyMethod 有参数，你需要传递一个包含参数值的 object[]  
        // 例如：methodInfo.Invoke(instance, new object[] { param1, param2 });
        //5.访问字段和属性
        //类似地，你可以使用FieldInfo和PropertyInfo来访问字段和属性。
        
        // 访问字段  
        static FieldInfo fieldInfo = type.GetField("myField");
        object fieldValue = fieldInfo.GetValue(instance);
        
        // 设置字段值  
        //fieldInfo.SetValue(instance, newValue);
        
        // 访问属性  
        static PropertyInfo propertyInfo = type.GetProperty("MyProperty");
        object propertyValue = propertyInfo.GetValue(instance, null);

        // 设置属性值  
        //propertyInfo.SetValue(instance, newValue, null); // 第三个参数是索引器参数（如果有的话），对于普通属性，通常为 null
        
        #endregion
    }
#endregion
}
