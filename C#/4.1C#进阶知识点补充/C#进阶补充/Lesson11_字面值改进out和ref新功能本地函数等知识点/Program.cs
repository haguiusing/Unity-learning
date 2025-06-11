namespace Lesson11_字面值改进out和ref新功能本地函数等知识点
{
    public struct TestRef
    {
        public int atk;
        public int def;

        public TestRef(int atk, int def)
        {
            this.atk = atk;
            this.def = def;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson11_字面值改进out和ref新功能本地函数等知识点");

            #region 知识点一：C#7对应的Unity版本
            //Unity 2018.3 版支持 C# 7
            //Unity 2019.4 版支持C# 7.3
            //Unity[7, 7.1, 7.2, 7.3] 版本的内容都是基于 C# 7 的一些改进
            #endregion

            #region 知识点二：C#7的新增功能和语法
            //1. 字面量改进
            //2. out 参数相关 和 弃元知识点
            //3. ref 返回值
            //4. 本地函数

            //5. 抛出表达式
            //6. 元组
            //7. 模式匹配
            #endregion

            #region 知识点三：字面值的改进
            //主要概念:在声明数值变量时,为了方便查看数值可以在数值之后插入作为分隔符
            //主要作用:方便数值变量的阅读
            int i = 9_123_1239;
            Console.WriteLine(i);  //输出: 91231239
            int i2 = 0xAB_CD_17;
            Console.WriteLine(i2);  //输出: 43985517
            #endregion

            #region 知识点四：out变量的快捷使用 和 弃元
            //注释: 不需要再使用带有out参数的函数之前, 声明对应变量
            //作用: 简化代码, 提高开发效率

            //1. 以前使用带有out函数的写法
            int a;
            int b;
            Calc(out a, out b);

            //2. 现在的写法
            Calc(out int x, out int y);
            Console.WriteLine(x);
            Console.WriteLine(y);

            //3.结合var类型更简便(但是这种写法在存在审核时不能正常使用,必须明确编译的是谁)
            Calc(out int c, out var d);
            Console.WriteLine(c);
            Console.WriteLine(d);

            //4. 可以使用 _ 共享符号  宽容不想使用的参数
            Calc(out int e, out _);   // 这里的_可以忽略掉第二个参数
            Console.WriteLine(e);

            #endregion

            #region 知识点五：ref修饰临时变量和返回值
            //基本概念：使用ref修饰局部变量和函数数据间值，可以将值型变为引用传递
            //作用：用于修改数据对象中的某些基类型变量

            //1.定义偏类型化的变量
            int test1 = 100;
            ref int test2 = ref test1;  // 定义局部变量的引用
            test2 = 900;
            Console.WriteLine(test1);  // 输出: 900
            TestRef r = new TestRef(5, 5);
            ref TestRef r2 = ref r;
            r2.atk = 10;
            Console.WriteLine(r.atk);

            //2.获取对象中的参数
            ref int atk = ref r.atk;
            atk = 99;
            Console.WriteLine(r.atk);

            //3.函数返回值
            int[] numbers1 = new int[] { 1, 2, 3, 45, 5, 65, 4532, 12 };
            int number = FindNumber(numbers1, 5);
            number = 98765;
            Console.WriteLine(numbers1[4]);

            int[] numbers2 = new int[] { 1, 2, 3, 45, 5, 65, 4532, 12 };
            ref int number2 = ref FindNumberRef(numbers2, 5);
            number = 98765;
            Console.WriteLine(numbers2[4]);

            #endregion

            #region 知识点六：本地函数
            //基本概念: 在函数内部声明一个临时函数
            //注意:
            //本地函数只能在声明该函数的函数内部使用
            //本地函数可以使用声明自己的函数中的变量
            //作用：方便逻辑的封装
            //建议: 把本地函数写在主要逻辑的后面,方便代码的查看

            Console.WriteLine(TestTst(10));
            #endregion

            #region 总结
            //C#7的新语法更新重点是 代码简化
            //今天讲out和ref新用法, 弃元、本地函数都是相对比较重要的内容
            //可以给我们带来很多便捷性
            #endregion
        }

        public static void Calc(out int x, out int y)
        {
            x = 10;
            y = 20;
        }
        
        public static void Calc(out float x, out float y)
        {
            x = 10;
            y = 20;
        }

        public static int FindNumber(int[] numbers, int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                    return numbers[i];
            }
            return numbers[0];
        }

        public static ref int FindNumberRef(int[] numbers, int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                    return ref numbers[i];
            }
            return ref numbers[0];
        }

        public static int TestTst(int i)
        {
            bool b = false;
            i += 10;
            Calc();
            Console.WriteLine(b);
            return i;

            void Calc()
            {
                i += 10;
                b = true;
            }
        }
    }
}
