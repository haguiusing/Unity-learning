namespace Lesson13_Using声明空合并赋值静态本地函数解构函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson13_Using声明空合并赋值静态本地函数解构函数");
            #region 知识点一：C#8对旧的Unity版本
            //Unity 2020.3 - C#8
            //但是部分新内容还不在这个版本Unity中被支持
            //我筛选了一些比较实用的内容给大家讲解
            #endregion

            #region 知识点二：C#8新增功能和语法
            //1.Using 声明
            //2.静态本地函数
            //3.Null 合并赋值
            //4.解构函数Deconstruct

            //5.模式匹配增强功能
            #endregion

            #region 知识点三：静态本地函数
            //知识回顾:
            //  在C#7的新语法中我们学习了本地函数
            //本地函数知识问答
            //基本概念: 在函数内部声明一个临时函数
            //注意:
            //  本地函数只能在声明该函数的函数内部使用
            //  本地函数可以使用声明自己的函数中的变量
            //作用: 方便逻辑的封装
            //建议: 把本地函数与在主要逻辑的后面, 万使代码的查看

            //新知识点:
            //  静态本地函数就是在本地函数前方加入静态关键字
            //  它的作用就是让本地函数不能够使用访问封闭范围内(也就是上层方法中的)任何变量
            //  作用 让本地函数只能处理逻辑, 避免让它通过直接改变上层变量来处理逻辑造成逻辑混乱
            #endregion

            #region 知识点四：Using 声明
            //知识回顾：
            //在数据持久化xml相关知识当中
            //我们学习了using相关的知识点
            //using(对象声明)
            //{
            //使用对象。语句块结束后，对象将被释放掉
            //当语句块结束 会自动帮助我们调用 对象的 Dispose这个方法 让其进行销毁
            //using一般都是配合 内存占用比较人 或者 有读写操作时 进行使用的
            //}
            //举例回顾:
            using (StreamWriter strem = new StreamWriter("文件路径"))
            {
                //对该变量进行逻辑处理 该变量只能在这个语句块中使用
                strem.Write(true);
                strem.Write(1.2F); 
                strem.Flush();
                strem.Close();
            }//在这个语句块结束后 自动调用了 StreamWriter的 Dispose方法 释放了对象

            //新知识点:
            //Using 声明就是对using () 语法简写
            //当函数执行完毕时 会调用 对象的 Dispose方法 释放对象

            if (true)
            {
                using StreamWriter s2 = new StreamWriter("文件路径");
                //对该对象进行缓存操作
                s2.Write(5);
                s2.Flush();
                s2.Close();
                //在上层语句块结束后 自动调用了 StreamWriter的 Dispose方法 释放了对象
            }

            //注意：在using语法时，使用的对象必须继承System.IDisposable接口
            //该对象必须实现Dispose方法。所以当声明有非接口成员的对象时就会报错

            using TestUsing t = new TestUsing();
            #endregion

            #region 知识点五：空合并赋值
            //知识回顾：
            //在C#进阶的特殊语法知识点中我们学习了 ?? 空合并操作符
            //空合并操作符知识点
            // 左边值 ?? 右边值
            // 如果左边值为null 就返回右边值 否则返回左边值// 只要是可以是null1类型的都能用
            // 举例:
            string str = null;
            string str2 = str ?? "234";
            Console.WriteLine(str2); // 234

            //新知识点:
            //空合并赋值是C#8.0新加的一个运算符 ??=
            //类似复合运算符
            //左边值 ??= 右边值
            // 当左侧为空时才会把右侧值赋值给变量
            // 举例:
            str ??= "123";
            Console.WriteLine(str); // 123

            //注意:由于左侧为空才会讲右侧值赋给变量,所以不为空的变量不会改变
            str ??= "789";
            Console.WriteLine(str); // 123
            #endregion

            #region 知识点六：解构函数Deconstruct
            //知识回顾:
            //我们之前学习过元组的解构,就是可以用单独的变量存储元组的值
            //相当于把多返回值元组拆分到不同的变量中
            //举例回顾:

            //新知识点: 解构函数Deconstruct (C# 7就有了)
            //我们可以在自定义类当中声明解构函数
            //这样我们可以将该门定义类对象利用元组的写法对其进行变量的获取
            //语法:
            //在类的内部申明函数public void Deconstruct(out 变量类型 变量名, out 变量类型 变量名.....)
            //特点:
            //一个类中可以有多个Deconstruct,但是参数数量不能相同

            Person p = new Person();
            p.name = "应辉长";
            p.sex = false;
            p.email = "tpandime@163.com";
            p.number = "123123123123";

            //我们可以对该对象利用元组将其具体的变量值 解构出来
            //相当于把不同的成员变量拆分到不同的临时变量中
            (string name, bool sex) = p;
            Console.WriteLine(name);    //应辉长
            Console.WriteLine(sex);    //false
            string str3;
            (_, _, str3) = p;
            Console.WriteLine(str3);    //123123123123
            #endregion
        }

        public (int, float, bool, string) GetInfo()
        {
            return (1, 3.4f, true, "123");
        }

        public int CalcInfo(int i)
        {
            bool b = false;
            Calc1();
            Calc2(i, b);
            Calc3(ref i, ref b);
            i += 10;
            return i;

            void Calc1()
            {
                i += 10;
                b = true;
            }

            static void Calc2(int i, bool b)
            {
                i += 10;
                b = true;
            }

            static void Calc3(ref int i, ref bool b)
            {
                i += 10;
                b = true;
            }
        }
    }

    public class TestUsing : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        public string name;
        public bool sex;
        public string number;
        public string email;

        /// <summary>
        /// 解构函数 把Person对象拆分成name和sex两个变量
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sex"></param>
        public void Deconstruct(out string n, out bool sex)
        {
            n = name;
            sex = this.sex;
        }
        //简写
        public void Deconstruct(out string n, out bool sex,out string num) => (n, sex, num) = (name, this.sex, number);
        public void Deconstruct(out string n, out bool sex, out string num, out string email)
        {
            n = name;
            sex = this.sex;
            num = number;
            email = this.email;
        }
    }

}
