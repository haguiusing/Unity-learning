﻿namespace Lesson12_结构体
{
    #region 知识点一：基本概念
    //结构体 是一种自定义变量类型 类似枚举需要自己定义
    //它是数据和函数的集合
    //在结构体中 可以申明各种变量和方法

    //作用:用来表现存在关系的数据集合 比如用结构体表现学生 动物 人类等等
    #endregion

    #region 知识点二：基本语法
    //1.结构体一般写在 namespace语句块中
    //2.结构体关键字 struct

    //struct 自定义结构体名
    //{
    //    // 第一部分
    //    // 变量

    //    // 第二部分
    //    // 构造函数(可选)


    //    // 第三部分
    //    // 函数
    //}
    // 注意： 结构体名字 命名规范 是 帕斯卡命名法

    #endregion

    #region 知识点三：实例

    struct S
    {

    }

    struct Student
    {
        #region 知识点五：访问修饰符
        //public  公开的 可以被外部访问
        //private 私有的 只能内部使用
        //默认不写 为private
        //要让外部调用 就必须加public
        #endregion


        //🔴变量
        //声明结构体的变量 不能直接初始化
        //年龄
        public int age;
        //性别
        public bool sex;
        //学号
        public int number;
        //姓名
        public string name;
        // 正确：结构可以有只读字段。
        //public readonly int ReadOnlyField;
        //变量类型 可以写任意型 包括结构体 但是 不能包含自己的结构体
        //Student stu;
        S s;

        //结构成员不能指定为 abstract、virtual 或 protected。
        //// 错误：结构成员不能指定为 abstract。
        //public abstract void AbstractMethod();

        //// 错误：结构成员不能指定为 virtual。
        //public virtual void VirtualMethod()
        //{
        //    // ...
        //}

        //// 错误：结构成员不能指定为 protected。
        //protected void ProtectedMethod()
        //{
        //    // ...
        //}


        #region 知识点六：结构体的构造函数
        //🔴构造函数
        //1.没有返回值
        //2.函数名必须和结构体相同
        //3.必须有参数
        //4.如果结构体声明构造函数 那么必须在其中对所有变量数据初始化
        //构造函数一般是用于在外部方便初始化的
        public Student(int age, bool sex, int number, string name)
        {
            //新的关键字this
            //代表自己
            this.age = age;
            this.sex = sex;
            this.number = number;
            this.name = name;
        }

        public Student()
        {
            age = 0;
            sex = false;
            number = 0;
            name = "";
        }
        #endregion

        //🔴函数方法
        //表现这个数据结构的行为
        //注意： 结构体中的函数不需要加static关键字
        public void Speak()
        {
            //函数中可以直接使用结构体内部的变量
            Console.WriteLine("我的名字是{0}，我今年{1}岁", name, age);
        }
        //可以根据需求写无数个函数
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("结构体");

            #region 知识点四：结构体的使用
            Student s1;
            s1.name = "苏先生";
            s1.age = 20;
            s1.number = 123321123;
            s1.sex = true;
            s1.Speak();

            //可以再次实例化 复用
            Student s2;
            s2.name = "苏小姐";
            s2.age = 20;
            s2.number = 123371524;
            s2.sex = false;
            s2.Speak();

            //使用构造函数初始化 可以比上面简便
            Student s3 = new Student(18, true, 2, "小红");
            s3.Speak();
            #endregion

            // 总结
            //1概念: 结构体 struct 是变量和函数的集合 用来表示特定的数据集合

            // 访问修饰符:public 和private 用来修饰变量和方法的 public 外部可以调用 private内部用 不写的话默认就是private
            // 构造函数 :没有返回值 函数名和结构体名相同 可以重载 主要是帮助我们快速初始化结构体对象的
            
            //注意:
            //1.在结构体中申明的变量 不能初始化在外部或者在函数中赋值 (初始化)
            //2.在结构体中申明的函数 不用加static的
        }
    }
}