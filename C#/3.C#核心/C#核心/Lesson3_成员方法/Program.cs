using System;

namespace Lesson3_成员方法
{
    #region 知识点一：成员方法的申明
    //基本概念
    //成员方法(函数) 用来表现对象行为
    // 1.申明在类语句块中
    // 2.是用来描述对象的行为的
    // 3.规则和函数申明规则相同
    // 4.受到访问修饰符规则影响
    // 5.返回值参数不做限制
    // 6.方法数量不做限制

    //注意:
    //1.成员方法不要加static关键字
    //2.成员方法 必须实例化出对象 再通过对象来使用 相当于该对象执行了某个行为
    //3.成员方法 受到访问修饰符影响

    class Person
    {
        //特征——成员变量
        public string name;
        public float high;
        public int age;
        public Person[] friend;

        /// <summary>
        /// 说话的方法
        /// </summary>
        /// <param name="str"><说话的内容/param>
        public void Speak(string str)
        {
            Console.WriteLine("{0}说{1}", name, str);
        }

        /// <summary>
        /// 判断是否成年
        /// </summary>
        /// <returns></returns>
        public bool IsAdult()
        {
            return age >= 18;
        }

        //行为——成员方法
        /// <summary>
        /// 扩容friend数组
        /// </summary>
        /// <param name="p"></param>
        public void AddFriend(Person p)
        {
            if (friend == null)
            {
                friend = new Person[] { p };
            }
            else
            {
                //数组扩容+1
                Person[] newFriend = new Person[friend.Length + 1];
                for (int i = 0; i < friend.Length; i++)
                {
                    newFriend[i] = friend[i];
                }

                //将新成员p存在新数组的最后一个索引
                newFriend[newFriend.Length - 1] = p;
            }
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("成员方法");

            #region 知识点二：成员方法的使用
            //2.成员方法 必须实例化出对象 再通过对象来使用 相当于该对象执行了某个行为
            Person p = new Person();
            p.name = "ljj";
            p.age = 18;
            p.Speak("ljj");

            if (p.IsAdult())
            {
                p.Speak("我要耍朋友");
            }

            Person p2 = new Person(); 
            p2.name="火山哥";
            p2.age = 16;

            for (int i = 0; i < p.friend.Length; i++)
            {
                Console.WriteLine(p.friend[i].name);
            }
            #endregion
        }
    }
}
