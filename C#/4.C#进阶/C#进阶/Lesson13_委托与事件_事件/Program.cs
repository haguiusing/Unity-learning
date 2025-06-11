namespace Lesson13_委托与事件_事件
{
    #region 知识点一：事件是什么
    //事件基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件 是一种特殊的变量类型
    #endregion

    #region 知识点二：事件的使用
    //申明语法:
    //访问修饰符 event 委托类型 事件名;
    //事件的使用:
    //1.事件是作为 成员变量存在于类中
    //2.委托怎么用 事件就怎么用
    //事件相对于委托的区别:
    //1.不能在类外部 赋值
    //2.不能再类外部 调用
    //注意:
    //它只能作为成员存在于类和接口以及结构体中
    class Test
    {
        public Action myFun;

        public event Action myEvent;

        public Test()
        {
            //事件的使用与委托一样
            myFun = TestFun1;
            myEvent = TestFun1;

            myFun += TestFun2;
            myEvent += TestFun2;

            myFun -= TestFun2;
            myEvent -= TestFun2;

            myFun = null;
            myEvent = null;
        }
        //要在类内部封装调用该事件的方法，在外部调用
        public void DoEvent()
        {
            if (myEvent != null)
            {
                myEvent();
            }
        }
        public void TestFun1()
        {
            Console.WriteLine("123");
        }
        public void TestFun2()
        {
            Console.WriteLine("456");
        }
    }
    #endregion

    #region 知识点三：为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了一次封装 让其更加安全
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托与事件_事件");
            
            Test test = new Test();
            //区别
            //委托可以在外部赋值
            test.myFun = null;
            test.myFun = TestFun;
            //事件是不能在外部赋值的，但是可以加减
            //test.myEvent = null;
            //test.myEvent = TestFun;
            test.myEvent += TestFun;
            test.myEvent -= TestFun;

            //委托可以在外部调用
            test.myFun();
            test.myFun.Invoke();
            //事件不能在外部调用
            //test.myEvent();
            //test.myEvent.Invoke();

            test.DoEvent();
        }
        static void TestFun()
        {

        }
    }
}
