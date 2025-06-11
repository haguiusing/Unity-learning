namespace Lesson6_索引器
{
    #region 知识点一：索引器基本概念
    //基本概念
    //让对象可以像数组一样通过索引访问其中元素，使程序看起来更直观，更容易缩写
    //结构体也支持索引器

    //补充： F:\Unity学习\C#\5.C#高级\C#高级\Indexer索引器\Program.cs
    #endregion

    #region 知识点二：索引器语法
    //访问修饰符 返回值 this[参数类型 参数名，参数类型 参数名...]
    //{
    //      内部的写法和规则和索引器相同
    //      get{}
    //      set{}
    //}
    class Person
    {
        private string name;
        private int age;
        private Person[] friends;

        private int[,] array;

        public Person this[int index]
        {
            get
            {
                #region 知识点四：索引器中可以写逻辑
                if (friends == null ||
                    friends.Length - 1 < index)
                {
                    return null;
                }
                
                return friends[index];
                #endregion
            }
            set
            {
                if (friends == null)
                {
                    friends = new Person[] { value };
                }
                else  if(index > friends.Length - 1)
                {
                    //自定义规则，如果越界，顶替最后一个朋友
                    friends[friends.Length - 1] = value;
                }
                friends[index] = value;
            }
        }

        #region 知识点五：索引器可以重载
        public int this[int i,int j]
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i,j]  = value;
            }
        }

        public string this[string str]
        {
            get
            {
                switch (str)
                {
                    case "name":
                        return this.name;
                    case "age":
                        return age.ToString();
                }
                return "";
            }
        }
        #endregion
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("索引器");
            #region 知识点三：索引器的使用
            Person p  = new Person();
            p[0] = new Person();
            Console.WriteLine(p[0]);
            #endregion
        }
    }
}
