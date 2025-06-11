namespace Lesson12_继承的基本规则
{
    #region 知识点一：基本概念
    //一个类A继承一个类B
    //类A将会继承类B的所有成员
    //A类将拥有B类的所有特征和行为

    //被继承的类
    //称为 父类、基类、超类

    //继承的类
    //称为子类、派生类

    //子类可以有自己的特征和行为

    //特点
    //1.单根性 子类只能有一个父类
    //2.传递性 子类可以间接继承父类的父类
    #endregion

    #region 知识点二：基本语法
    //class 类名 : 被继承的类名
    //{

    //}
    #endregion

    #region 知识点三：实例
    class Teacher
    {
        public string? Name { get; set; }    //名字
        private int Number { get; set; }    //职工号
        //private私有，只能在本类中使用，外部和子类都无法直接使用
        //protected保护，外部无法直接使用，子类可以使用

        public void TeacherName(string name = "未知教师")
        {
            this.Name = name;
        }
        //介绍名字
        public void SpeakName()
        {
            Console.WriteLine(Name);
        }
    }

    //继承Teacher类
    class TeachingTeacher : Teacher
    {
        //科目
        public string Subject { get; set; }
        public int WorkTime { get; set; }

        public TeachingTeacher(string subject = "未知科目", int time = 0)
        {
            this.Subject = subject;
            this.WorkTime = time;
        }
        //介绍科目
        public void SpeakSubject()
        {
            Console.WriteLine(Subject + "老师");
        }
    }

    class ChineseTeacher : TeachingTeacher
    {
        public ChineseTeacher() : base("语文", 20) { }
        public static void Skill()
        {
            Console.WriteLine("教学语文");
        }
    }
    #endregion

    #region 知识点四：访问修饰符的影响
    //public - 公共 内外部访问
    //private -私有 内部访问
    //protected- 保护 内部和子类访问

    //之后讲命名空间的时候讲
    //internsl - 内部的 只有在同一个程序集的文件中，内部类型或者是成员才可以访问
    #endregion

    #region 知识点五：子类和父类的同名成员
    //概念
    //C#中允许子类存在和父类同名的成员
    //但是 极不建议使用
    #endregion

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("继承的基本概念");

            TeachingTeacher teachingTeacher = new()
            {
                Name = "Test",
                //Number = 1
            };
            teachingTeacher.SpeakName();

            teachingTeacher.Subject = "Unity";
            teachingTeacher.SpeakSubject();

            Console.WriteLine("/n");

            ChineseTeacher chineseTeacher = new()
            {
                Name = "Chinese",
                //Number = 2
            };

            chineseTeacher.SpeakName();
            chineseTeacher.SpeakSubject();
            ChineseTeacher.Skill();
        }
    }
}
