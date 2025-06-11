namespace Lesson12_元组模式匹配抛出表达式等知识点
{
    class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
        }
    }

    //为自定义异常类添加一个属性来保存引发异常的特定对象：
    class InvalidDataException : Exception
    {
        public object InvalidObject { get; }

        public InvalidDataException(string message, object invalidObject) : base(message)
        {
            InvalidObject = invalidObject;
        }
    }

    class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {
        }
    }

    class InsufficientFundsException : PaymentException
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    class InvalidPaymentMethodException : PaymentException
    {
        public InvalidPaymentMethodException(string message) : base(message)
        {
        }
    }

    internal class Program
    {
        private static string jsonStr;
        private static void InitInfo(string str) => jsonStr = str ?? throw new ArgumentNullException(nameof(str));
        private static string GetInfo(string str, int index)
        {
            string[] strs = str.Split(',');
            return strs.Length > index ? strs[index] : "123";//throw new IndexOutOfRangeException();
        }

        public static (int, string) yz;

        private static (string, int, float) GetInfo()
        {
            return ("123", 2, 5.5F);
        }

        private static (string s, int i, float f) GetInfo1()
        {
            return ("123", 2, 5.5F);
        } 

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson12_元组模式匹配抛出表达式等知识点");

            #region 知识点一：抛出表达式
            //throw 知识点回顾
            //抛出表达式，就是抛出一个错误
            //一般的使用方式 都是 throw后面 new 一个异常类

            //异常类: Exception
            //throw new System.Exception("报错了");

            //throw new NullReferenceException("1231231");
            #region C#自带异常类
            //常见
            //IndexOutOfRangeException: 当一个数组的下标超出范围时运行时引发。
            //NullReferenceException: 当一个空对象被引用时运行时引发。
            //ArgumentException: 方法的参数是非法的
            //ArgumentNullException: 一个空参数传递给方法,该方法不能接受该参数
            //ArgumentOutOfRangeException: 参数值超出范围//SystemException: 其他用户可处理的异常的基本类
            //OutOfMemoryException: 内存空间不够
            //StackOverflowException堆栈溢出

            //ArithmeticException: 出现算术上溢或者下溢
            //ArrayTypeMismatchException: 尝试在数组中存储错误类型的对象
            //BadImageFormatException: 图形的格式错误
            //DivideByZeroException: 除零异常
            //DllNotFoundException: 找不到引用的DLL
            //FormatException: 参数格式错误
            //InvalidCastException: 使用无效的类
            //InvalidOperationException: 方法的调用时间错误
            //MethodAccessException: 试图访问成员或者受保护的方法
            //MissingMemberException: 访问一个无效版本的DLL
            //NotFiniteNumberException:对象不是一个有效的成员
            //NotSupportedException: 调用的方法在类中没有实现
            //InvalidOperationException: 当对方法的调用对对象的当前状态无效时, 由某些方法引发。
            #endregion
            //在C# 7中，可以在更多的表达式中进行错误抛出
            //好处：更节约代码量

            //  1. 空合并操作符后用throw
            InitInfo("123");
            //  2. 三目运算符后面用throw
            GetInfo("1,2,3", 4);
            //  3. =>符号后面直接throw
            Action action = () => throw new ArgumentException("参数错误");

            //自定义异常类的最佳实践
            // 1 使用有意义的名称
            //  自定义异常类的名称应该清晰明了，能够表达出异常的类型和意图。命名应当符合命名规范，以便开发人员能够理解其用途。

            // 2 提供有用的错误信息
            //  自定义异常类的构造函数可以接受参数，用于设置异常的错误信息。
            //  这些信息应该简洁明了，能够帮助开发人员快速理解异常的原因。

            // 3 添加额外的上下文信息
            //  如果有必要，您可以在自定义异常类中添加额外的属性或方法，用于提供有关异常情况的更多上下文信息。
            //  这些信息可以帮助开发人员更好地理解异常的背景和发生的环境。

            //例如，您可以为自定义异常类添加一个属性来保存引发异常的特定对象：

            // 4 考虑异常继承关系
            //  如果您需要创建多个相关的自定义异常类，可以考虑使用继承来建立它们之间的关系。
            //  这有助于组织异常类的层次结构，使其更加清晰和有组织。

            //在上述示例中，InsufficientFundsException和InvalidPaymentMethodException继承自PaymentException，形成了异常类的层次结构。

            // 5 慎重使用自定义异常
            //  尽管自定义异常类提供了更多的灵活性和可读性，但也应慎重使用。
            //  不必为每种情况都创建自定义异常，只有在需要为特定的业务逻辑或功能提供更精确的错误处理时，才应考虑创建自定义异常类。

            // 6 捕获和处理自定义异常
            //  在使用自定义异常类时，可以像使用系统异常一样捕获和处理它们。以下是一个示例：
            try
            {
                // 可能引发异常的代码
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine("无效的数据异常：" + ex.Message);
                Console.WriteLine("无效对象：" + ex.InvalidObject.ToString());
            }
            catch (PaymentException ex)
            {
                Console.WriteLine("支付异常：" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("其他异常：" + ex.Message);
            }

            #endregion

            #region 知识点二：元组_值类型
            //基本概念：多个值的集合, 相当于是种快速构建数据结构类的方式
            //  一般在函数存在多返回值时可以使用元组（返回值1类型, 返回值2类型,...）来声明返回值
            //  在函数内部返回具体内容时通过（返回值1, 返回值2,...）进行返回
            //主要作用: 提升开发效率, 更方便地处理多返回值等需要用到多个值时的需求

            //1. 无变量名元组的声明(获取值: Item'N'作为从左到右依次的参数, N从1开始)
            (int, float, bool, string) yz1 = (1, 5.5f, false, "1233");
            Console.WriteLine(yz1.Item1);
            Console.WriteLine(yz1.Item2);

            //2. 有变量名元组的声明
            (int i, float f, bool b, string str) yz2 = (1, 5.5f, false, "1233");
            Console.WriteLine(yz2.i);
            Console.WriteLine(yz2.f);
            Console.WriteLine(yz2.b);
            Console.WriteLine(yz2.str);

            //3. 元组可以进行等T和不等T的判断
            //  数量相同才比较, 类型相同才比较, 每一个参数的比较是通过==比较 如果都是true 则认为两个元组相等
            if (yz1 == yz2) 
            {
                Console.WriteLine("相等");
            } else
            {
                Console.WriteLine("不相等");
            }

            //元组不仅可以作为临时变量，也可以作为成员变量
            Console.WriteLine(yz.Item1);

            #region 元组应用_函数返回值
            //无变量名函数返回值 
            (string, int, float) info = GetInfo();
            var info1 = GetInfo();
            Console.WriteLine(info.Item1);
            Console.WriteLine(info.Item2);
            Console.WriteLine(info.Item3);

            var info2 = GetInfo1();
            Console.WriteLine(info2.s);
            Console.WriteLine(info2.i);
            Console.WriteLine(info2.f);

            // 元组的构造赋值
            // 相当于把整返回值元组拆分到不同的变量中
            (string myStr, int myInt, float myFloat) = GetInfo();
            Console.WriteLine(myStr);
            Console.WriteLine(myInt);
            Console.WriteLine(myFloat);
            //外部申明
            int myInt1;
            string myStr1;
            float myFloat1;
            (myStr1, myInt1, myFloat1) = GetInfo();
            Console.WriteLine(myStr); 
            Console.WriteLine(myInt);
            Console.WriteLine(myFloat);

            // 工程参数
            // 用于利用下划线_达到兵分该参数不使用的作用
            (string ss, int ii, _) = GetInfo();
            #endregion

            #region 元组应用_字典
            // //典!!键 需要用多个变量来控制
            Dictionary<(int, float), string> dic = new Dictionary<(int, float),string> ();
            dic.Add((1, 2.5f), "123");
            if (dic.ContainsKey((1, 2.5f)))
            {
                Console.WriteLine("存在");
                Console.WriteLine(dic[(1, 2.5f)]);
            }

            #endregion
            #endregion

            #region 知识点三：模式匹配
            //基本概念：模式匹配时一种语法元素，可以测试一个值是否满足某种条件，并可以从值中提取信息
            //  在C#7中，模式匹配增强了两个现有的语言结构
            //  1.is表达式，is表达式可以在右侧写一个模式语法，而不仅仅是一个类型
            //  2.switch语句中的case
            //主要作用：节约代码量，提高编程效率

            //1.常量模式(is 常量)：用于判断输入值是否等于某个值
            object o = 1;
            if (o is 1)
            {
                Console.WriteLine("o是1 " + o);
            }
            else
            {
                Console.WriteLine("o不是1 " + o);
            }
            if (o is null)
            {
                Console.WriteLine("o是null");
            }

            //2.类型模式(is 类型 变量名 case 类型 变量名)：用于判断输入值类型，如果类型相同，将输入值提取出来
            //判断某一个变量是否是某一个类型，如果满足会将该变量存入你声明的变量中
            //以前的写法
            //if (o is int)
            //{
            //    int i = (int)o;
            //    print(i);
            //}
            if (o is int i)  //匹配时i = o
            {
                Console.WriteLine(i);  //输出1 
            }

            switch (o)
            {
                case int value:
                    Console.WriteLine(value + "是int类型");
                    break;
                case float value:
                    Console.WriteLine(value + "是float类型");
                    break;
                case null:
                    Console.WriteLine("o是null");
                    break;
                default:
                    break;
            }

            //3.var模式：用于将输入值放入与输入值相同类型的新变量中
            //相当于将变量装入一个和自己类型一样的变量中
            if(o is var v)
            {
                Console.WriteLine(o);   //输出1
                Console.WriteLine(v);   //输出1
            }
            int kk = GetInt();
            if (kk >= 0 && kk <= 10)
            { 

            }

            //简化写法
            if ((GetInt() is var k && k >= 0 && k <= 10))
            { 

            }

            #endregion

            #region 总结
            //元组和模式匹配知识是C# 7中引入的最重要的两个知识点
            //他们可以帮助我们更效率的完成一些功能需求
            //建议大家常用他们
            #endregion
        }

        private static int GetInt()
        {
            return 1;
        }
    }
}