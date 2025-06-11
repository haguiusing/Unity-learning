using System.Linq.Expressions;
using System;

namespace LINQ_表达式_Expression
{
    internal class Program
    {
        //Expression 类是表达式树节点的类的基类
        //可以将lambda表达式分配给Func或Action类型委托，以处理内存中的集合。
        //.NET编译器在编译时将分配给Func或Action类型委托的lambda表达式转换为可执行代码。

        //LINQ引入了一种名为Expression的新类型，该类型代表强类型的lambda表达式。
        //这意味着lambda表达式也可以分配给Expression <TDelegate>类型。
        //.NET编译器将分配给Expression <TDelegate>的lambda表达式转换为Expression树，而不是可执行代码。
        //远程LINQ查询提供程序使用此表达式树作为数据结构，以其构建运行时查询（例如LINQ-to-SQL，EntityFramework或实现IQueryable <T>接口的任何其他LINQ查询提供程序）。

        //下图说明了将lambda表达式分配给Func或Action委托与LINQ中的Expression时的区别。
        //https://www.cainiaojc.com/static/upload/201230/1210390.png
        //首先，让我们看看如何定义和调用表达式。

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 表达式（Expression）");

            #region 知识点一：定义 Expression
            //引用System.Linq.Expressions命名空间，并使用Expression<TDelegate> 类定义一个Expression。
            //Expression<TDelegate> 需要委托类型Func或Action。
            //例如，你可以将 lambda 表达式赋给 Func 类型委托 的 isTeenAger 变量，如下所示:

            Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;

            //现在，您可以使用Expresson包装Func委托，将上述Func类型委托转换为Expression，如下所示：
            Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

            //以相同的方式，如果您不从委托返回值，则还可以用Expression包装Action<t>类型委托。
            Expression<Action<Student>> printStudentName = s => Console.WriteLine(s.StudentName);
            //因此，您可以定义Expression <TDelegate>类型。现在，让我们看看如何调用由Expression <TDelegate>包装的委托。
            #endregion

            #region 知识点二：调用表达式(Expression)
            //您可以用与委托相同的方式调用由Expression包裹的委托，但是首先需要使用Compile()方法进行编译。
            //Compile()返回Func或Action类型的委托，以便您可以像委托一样调用它。

            Expression<Func<Student, bool>> isTeenAgerExprI = s => s.Age > 12 && s.Age < 20;

            //使用Compile方法编译Expression以将其作为委托调用
            Func<Student, bool> isTeenAgerI = isTeenAgerExprI.Compile();

            //Invoke
            bool result = isTeenAger(new Student() { StudentID = 1, StudentName = "Steve", Age = 20 });

            #endregion
        }
        public class Student
        {
            public int StudentID { get; set; }
            public string? StudentName { get; set; }
            public int Age { get; set; }
        }
    }
}
