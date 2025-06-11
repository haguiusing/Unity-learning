using Microsoft.VisualBasic;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lesson9_异步方法async和await关键字
{
    internal class Program
    {
        CancellationTokenSource source;

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson9_异步方法async和await关键字");
            #region 知识点一：什么是同步和异步
            //1）同步和异步的定义
            //同步方法: 当一个方法被调用时，调用者需要等待该方法执行完毕后返回，才能继续执行。例如，我们调用一个方法，必须等待这个方法里面的所有逻辑执行完毕过后，再返回继续执行后面的代码。
            //异步方法: 当一个方法被调用时立即返回，并获取一个线程执行该方法内部的逻辑。调用者不用等待该方法执行完毕。例如，执行了一个方法后，内部的逻辑可能不需要让它执行完，就立即返回，里面的复杂逻辑交给另一个线程去处理。
            //2）异步编程的理解
            //异步编程: 会把一些不需要立即得到结果且耗时的逻辑设置为异步执行，这样可以提高程序的运行效率，避免由于复杂逻辑带来的线程阻塞。
            #endregion

            #region 知识点二：什么时候需要异步编程
            //1）异步编程的需求
            //需求场景: 当需要处理的逻辑会严重影响主线程执行的流畅性时，我们需要使用异步编程。
            //具体场景:
            //  复杂逻辑计算: 如A星寻路算法，由于计算量大，直接在主线程中调用会导致卡顿。通过异步编程，可以将耗时计算放到后台线程，提高程序流畅性。
            //  网络下载与通讯: 如下载图片或发送信息，使用异步编程可以避免等待时间，提高用户体验。例如，在滑动浏览视频缩略图时，边加载边滚动，不会造成阻塞。
            //  资源加载: 加载大型资源时，通过异步编程可以避免主线程阻塞，提高程序响应速度。

            //2）异步方法的关键字
            //async和await: 这两个关键字是异步编程的核心。它们允许我们将一些不需要立即得到结果且耗时的逻辑设置为异步执行，从而提高程序的运行效率，并避免由于复杂逻辑带来的线程阻塞。
            //使用场景: 在Unity等游戏开发框架中，虽然协同程序可以满足大部分异步需求，但在某些情况下，使用async和await关键字进行异步编程可能更加直观和方便。
            #endregion

            #region 知识点三：异步方法async和await
            //async和await一般需要配合Task进行使用
            //async用」修饰函数、lambda表达式、匿名函数
            //await用」在函数中和async配对使用,主要作用是等待某个逻辑结束
            //此时逻辑会返回函数外部继续执行,直到等待的内容执行结束后,再继续执行异步函数内部逻辑
            //在一个async异步函数中可以有多个await等待关键字
            TestAsync();
            Console.WriteLine("主线程逻辑");

            //使用async修饰异步方法
            //1.在异步方法中使用await关键字（不使用编译器会给警告但不报告）,否则异步方法会以同步方式执行
            //2.异步方法名建议以Async结尾.
            //3.异步方法的返回值只能是void、Task、Task<>
            //4.异步方法中不能声明使用ref或out关键字修饰的变量

            //使用await等待异步内容执行完毕（一般和Task配合使用）
            //遇到await关键字时
            //1. 斥步方法将被挂起
            //2. 将控制权返回给调用者
            //3. 当await修饰内容异步执行结束后,继续通过调用者线程执行后面内容

            //举例说明
            //1.复杂逻辑计算 (利用Task新开线程进行计算 计算完毕后再使用 比如复杂的寻路算法)
            CalcPathAsync( new GameObject(), Vector3.One);

            //2.计时器
            TimerAsync(1);

        //3.资源加载(Addressables的资源异步加载是可以使用async和await的)
        //注意：Unity中大部分异步方法是不支持异步关键字async和await的，我们只有使用协程程序进行使用
        //虽然官方 不支持 但是 存在第三方的工具（插件）可以让Unity内部的一些异步加载的方法 支持 异步关键字
        //https://github.com/svermeulen/Unity3dAsyncAwaitUtil
                          
              //虽然Unity中的各种异步加载对异步方法支持不太好
              //但是当我们用到.Net 库中提供的一些API时，可以考虑使用异步方法
              //1.Web访问：HttpClient
              //2.文件使用：StreamReader、StreamWriter、JsonSerializer、XmlReader、XmlWriter等等
              //3.图像处理：BitmapEncoder、BitmapDecoder
              //一般.Net 提供的API里 方法名后面带有 Async的方法 都支持异步方法


            Console.WriteLine("主线程逻辑执行");

            #endregion

            #region 总结
            // 异步编程async和await是一个比较重要的功能
            // 我们可以利用它们配合Task进行异步编程
            // 虽然Unity自带的一些异步加载原本是不支持 异步方法关键字的
            // 但是可以利用别人写好的第三方工具 让他们支持 大家可以根据自己的需求 选择性使用
            #endregion
        }

        /// <summary>
        /// 异步方法,不加await关键字,则不会等待Task.Delay执行完毕,直接执行下面的代码（同步）
        /// </summary>
        public async static void TestAsync()
        {
            //1
            Console.WriteLine("Test start");
            //2 遇到await关键字时,将被挂起,直到await的内容执行完毕,再继续执行
            await Task.Delay(1000);  
            //3
            Console.WriteLine("Test end");
        }
        //异步方法 与 协程

        public async static void CalcPathAsync(GameObject obj, Vector3 endPos)
        {
            Console.WriteLine("开始处理寻路逻辑");
            int value = 10;
            await Task.Run(() =>
            {
                //处理复杂逻辑计算 我这是通过休眠来模拟 计算的复杂性Thread.Sleep(1000);
                value = 50;
                //是多线程 总意味着我们不能在多线程里去访问 Unity主线程场景中的对象
                //Console.WriteLine(obj.transform.position);  不能访问主线程对象
            });
            Console.WriteLine("寻路计算完毕 处理逻辑" + value); obj.transform.position = Vector3.Zero;
        }

        public async static void TimerAsync(float time)
        {
            await Task.Delay(TimeSpan.FromSeconds(time));
            Console.WriteLine("计时器结束");
        }

        public async void Timer()
        {
            source = new CancellationTokenSource();
            int i = 0;
            while (!source.IsCancellationRequested)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
                ++i;
            }
        }
    }

    //模拟Unity
    public class GameObject { 
        public Transform transform { get; set; }
    }
    public class Transform { public Vector3 position; }
}
