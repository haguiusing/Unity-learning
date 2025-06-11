namespace Lesson5_成员属性
{
    class Person()
    {
        private string name;
        private int age;
        private int money;
        private bool sex;
        private float height;

        public string Name
        {
            get
            {
                //可以在返回之前添加逻辑规则
                //意味着这个属性可以获取的内容
                return name;
            }
            set
            {
                //可以在设置前添加逻辑规则
                // value 关键字 用于表示外部传入的值
                name = value;
            }
        }

        public int Age
        {
            get
            {
                //解密处理
                return age - 5;
            }
            set
            {
                //加密处理
                if(age < 0)
                {
                    age = 0;
                    Console.WriteLine("金钱不能为负数");
                }
                age = value + 5;
            }
        }

        public int Money { get => money; set => money = value; }

        #region 知识点一：成员属性的基本概念
        //基本概念
        //1.用于保护成员变量
        //2.为成员属性的获取和赋值添加逻辑处理
        //3.解决3P的局限性
        //public一内外访问
        //private一内部访问
        //protected一内部和子类访问
        //属性可以让成员变量在外部
        //只能获取 不能修改 或者 只能修改 不能获取
        #endregion

        #region 知识点二：成员属性的基本语法
        // 访问修饰符 属性类型 属性名
        // {
        //    get{}
        //    set{}
        // }
        #endregion

        #region 知识点四：成员属性中 get和set前可以加访问修饰符
        // 注意
        // 1.默认不加 会使用属性申明时的访问权限
        // 2.加的访问修饰特要低于属性的访问权限
        // 3.不能让get和set的访问权限都低于属性的权限
        #endregion

        #region 知识点五：get和set可以只有一个
        //注意
        //只有一个时 没必要在前面加访问修饰符
        #endregion

        #region 知识点六：自动属性
        //作用:外部能得不施改的特征
        //如果类中有一个特征是只希望外部能得不能改的 又没什么特殊处理
        //那么可以直接使用自动属性
        public float Height
        {
            get;
            set;
        }
        public bool Sex { get => sex; }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("成员属性");

            #region 知识点六：成员属性的使用
            Person p = new Person();
            p.Name = "tang";
            Console.WriteLine(p.Name);

            p.Money = 1000;
            Console.WriteLine(p.Money);
            #endregion
        }
    }
}
