using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LINQ_表达式树
{
    internal class Program
    {
        //顾名思义，表达式树不过是按树状数据结构排列的表达式。表达式树中的每个节点都是一个表达式。
        //例如，表达式树可用于表示数学公式x <y，其中x，<和y将表示为表达式，并排列在树状结构中。

        //表达式树是lambda表达式的内存表示形式。它保存查询的实际元素，而不是查询的结果。

        //表达式树使lambda表达式的结构透明和显式。您可以与表达式树中的数据进行交互，就像与其他任何数据结构一样。

        //例如，看以下isTeenAgerExpr表达式：
        Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
        // 编译器会将上面的表达式转换为以下表达式树：
        ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

        //编译器会将上面的表达式转换为以下表达式树：
        //Expression.Lambda<Func<Student, bool>>(
        //    Expression.AndAlso(
        //        Expression.GreaterThan(Expression.Property(pe, "Age"), Expression.Constant(12, typeof(int))),
        //            Expression.LessThan(Expression.Property(pe, "Age"), Expression.Constant(20, typeof(int)))),
        //                new[] { pe });

        //也可以手动构建表达式树。让我们看看如何为以下简单的lambda表达式构建表达式树：
        Func<Student, bool> isAdult = s => s.Age >= 18;
        //此Func类型委托将被视为以下方法：
        public bool function(Student s) { return s.Age > 18; }

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 表达式树");
            #region 知识点一：创建表达式树
            //以lambda表达式的方式创建
            Expression<Func<Student, bool>> isAdultExpr = s => s.Age >= 18;

            //通过API静态方法创建
            //编译器会将上面的表达式转换为以下表达式树：
            Expression.Lambda<Func<Student, bool>>(
                    Expression.GreaterThan(Expression.Property(Expression.Parameter(typeof(Student), "s"), "Age"), Expression.Constant(12, typeof(int))),
                        new[] { Expression.Parameter(typeof(Student), "s") });

            //要创建表达式树，首先，创建一个参数表达式，其中Student是参数的类型，'s'是参数的名称，如下所示：
            //步骤1：在C＃中创建参数表达式
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            //现在，使用Expression.Property() 创建s.Age表达式，其中s是参数，Age是Student的属性名称。
            //（Expression是一个抽象类，其中包含用于手动创建表达式树的静态帮助器方法。）
            //步骤2：在C＃中创建属性表达式
            MemberExpression me = Expression.Property(pe, "Age");

            //现在，为18创建一个常量表达式：
            //步骤3：在C＃中创建常量表达式
            ConstantExpression constant = Expression.Constant(18, typeof(int));
            //到目前为止，我们已经为s.Age（成员表达式）和18（常量表达式）构建了表达式树。

            //现在，我们需要检查成员表达式是否大于常量表达式。
            //为此，请使用Expression.GreaterThanOrEqual() 方法，并将成员表达式和常量表达式作为参数传递：
            //步骤4：在C＃中创建大于等于表达式
            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);
            //因此，我们为lambda表达式主体 s.Age> = 18 构建了一个表达式树。
            //我们现在需要将参数表达式和主体表达式连接起来。
            //使用Expression.Lambda(body,parameters array)连接lambda表达式s => s.age> = 18的body(主体)和parameter(参数)部分：

            //步骤5：在C＃中创建lambda表达式
            var isAdultExprTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });
            //这样，您可以为带有lambda表达式的简单Func委托构建表达式树。

            Console.WriteLine("表达式树: {0}", isAdultExprTree);
            Console.WriteLine("表达式树体: {0}", isAdultExprTree.Body);
            Console.WriteLine("表达式树中的参数个数: {0}", isAdultExprTree.Parameters.Count);
            Console.WriteLine("表达式树中的参数: {0}", isAdultExprTree.Parameters[0]);

            //下图说明了创建表达式树的整个过程：
            //https://www.cainiaojc.com/static/upload/201230/1329330.png
            #endregion

            TestExpressionTree();

            //不在同一应用程序域中执行针对LINQ-to-SQL或Entity Framework的LINQ查询。
            //例如，对于Entity Framework的以下LINQ查询永远不会在程序内部实际执行：
            ////dbContext 是一个实体框架（Entity Framework）上下文对象的实例，用于与数据库进行交互
            using (var dbContext = new SchoolContext())  
            {
                var query = from s in dbContext.Students
                            where s.Age >= 18
                            select s;

                // 在此处可以执行查询，例如将其转换为列表：
                var adults = query.ToList();

                // 输出结果
                foreach (var student in adults)
                {
                    Console.WriteLine($"学生ID: {student.StudentID}, 学生姓名: {student.StudentName}, 年龄: {student.Age}");
                }
            }
            //首先将其转换为SQL语句，然后在数据库服务器上执行。

            //在查询表达式中找到的代码必须转换为SQL查询，该查询可以作为字符串发送到另一个进程。
            //对于LINQ-to-SQL或Entity Framework，该过程恰好是SQL Server数据库。
            //将数据结构（如表达式树）转换为SQL显然比将原始IL或可执行代码转换为SQL容易得多，
            //因为正如您看到的，从表达式中检索信息很容易。

            //创建表达式树的目的是将诸如查询表达式之类的代码转换为可以传递给其他进程并在此处执行的字符串。

            //可查询的静态类包括接受Expression类型的谓词参数的扩展方法。
            //将该谓词表达式转换为表达式树，然后将其作为数据结构传递到远程LINQ提供程序，
            //以便提供程序可以从表达式树构建适当的查询并执行查询。
        }

        #region 知识点二：为什么选择表达树？
        //在上一节中，我们已经看到分配给lambda表达式Func<T>编译为可执行代码,
        //分配给lambda表达式Expression<TDelegate>类型编译为Expression树。

        //可执行代码在同一个应用程序域中执行，以处理内存中的集合。
        //可枚举的静态类包含用于实现IEnumerable<T>接口的内存中集合的扩展方法，例如List<T>，Dictionary<T>等。
        //Enumerable类中的扩展方法接受Func类型委托的谓词参数。
        //例如，Where扩展方法接受Func<TSource，bool>谓词。
        //然后，将其编译为IL（中间语言）以处理同一AppDomain中的内存中集合。

        //下图显示了Enumerable类中的where扩展方法包括Func委托作为参数的情况：
        //https://www.cainiaojc.com/static/upload/201230/1329331.png  Where 的Func 委托

        //Func委托是原始的可执行代码，因此，如果调试代码，则会发现Func委托将表示为不透明代码。
        //您无法看到其参数，返回类型和主体：
        //https://www.cainiaojc.com/static/upload/201230/1329332.png  调试模式下的Func委托

        //Func委托用于内存中的集合，因为它将在同一个AppDomain中进行处理，
        //但是诸如LINQ-to-SQL，EntityFramework或其他提供LINQ功能的第三方产品的远程LINQ查询提供者呢？
        //他们将如何解析已编译为原始可执行代码的lambda表达式，以了解参数，lambda表达式的返回类型以及构建运行时查询以进一步处理？
        //答案是表达树。

        //Expression <TDelegate>被编译成称为表达式树的数据结构。

        //如果调试代码，则表达式代表将如下所示：
        //https://www.cainiaojc.com/static/upload/201230/1329333.png  调试模式下的表达式树

        //现在您可以看到普通委托和表达式之间的区别。表达式树是透明的。
        //您可以从表达式中检索参数，返回类型和主体表达式信息，如下所示：
        public static void TestExpressionTree()
        {
            Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

            Console.WriteLine("Expression: {0}", isTeenAgerExpr);

            Console.WriteLine("表达式类型: {0}", isTeenAgerExpr.NodeType);

            var parameters = isTeenAgerExpr.Parameters;

            foreach (var param in parameters)
            {
                Console.WriteLine("参数名称: {0}", param.Name);
                Console.WriteLine("参数类型: {0}", param.Type.Name);
            }
            var bodyExpr = isTeenAgerExpr.Body as BinaryExpression;

            Console.WriteLine("表达式主体左侧: {0}", bodyExpr.Left);
            Console.WriteLine("二进制表达式类型: {0}", bodyExpr.NodeType);
            Console.WriteLine("表达式主体右侧: {0}", bodyExpr.Right);
            Console.WriteLine("返回类型: {0}", isTeenAgerExpr.ReturnType);
        }
        //输出：
        //Expression: s => ((s.Age > 12) AndAlso(s.Age< 20))
        //表达式类型: Lambda
        //参数名称: s
        //参数类型: Student
        //表达式主体左侧: (s.Age > 12)
        //二进制表达式类型: AndAlso
        //表达式主体右侧: (s.Age< 20)
        //返回类型: System.Boolean
        #endregion

        public class SchoolContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string? StudentName { get; set; }
            public int Age { get; set; }
        }
    }
}
