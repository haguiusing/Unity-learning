

namespace Lesson18_多线程
{
    public class Program
    {
        public static bool isRuning = true;

        public static int waitTime = 1000;

        public static object obj = new object();

        public static void Main(string[] args)
        {
            Console.WriteLine("多线程");

            #region 知识点一：了解线程前先了解进程
            //进程 (Process) 是计算机中的程序关于某数据集合上的一次运行活动
            //是系统进行资源分配和调的基本单位，是提作系统结构的基础
            //说人话: 打开一个应用程序就是在提作系统上开启了一个进程
            //进程之间可以相互独立运行，互不干扰
            //进程之间也可以相互访问、操作
            #endregion

            #region 知识点二：什么是线程
            //最作系统能够进行运算调度的最小单位
            //它被包含在进程之中，是进程中的实际运作单位
            //一条线程指的是进程中一个单一题序的控制流，一个进程中可以并发多个线程
            //我们目前写的程序 都在主线程中

            //简单理解线理:
            //就是代码从上到下运行的一条指令流
            #endregion

            #region 知识点三：什么是多线程
            //我们可以通过代码 开启新的线程
            //可以同时运行代码的多条“管道”就叫多线程
            #endregion

            #region 知识点四：语法相关
            //线程类 Thread 是最基础的线程处理类，它允许你直接控制线程的行为。
            //需更引用命名空间 using System.Threading;
            //1.申明一个新的线程
            // 注意 线程执行的代码 需要封装到一个函数中
            //新开线程 执行的代码逻辑 在该函数语句块中

            //本地方法
            Thread t = new Thread(NewThreadLogic);  //本地方法
            Thread t1 = new Thread(NewThreadLogic, 1000);  //本地方法 并指定线程的最大堆栈大小。
            Thread t11 = new Thread(() => NewThreadLogic(1000));  //本地方法 使用Lambda表达式
            //Thread t111 = new Thread(delegate { NewThreadLogic(1000); });  //使用匿名方法有二义性 应该使用Lambda表达式

            //本地方式直接传递一个方法（本地方法、Lambda表达式或匿名方法）作为线程的启动逻辑。
            //这是最简洁的方式，适用于不需要向线程方法传递参数的情况。
            //优点：
            //代码简洁，不需要显式定义委托类型。
            //直接使用方法引用，易于理解和维护。
            //缺点：
            //不能直接向线程方法传递参数。

            //使用 ThreadStart 委托
            Thread t2 = new Thread(new ThreadStart(NewThreadLogic)); //使用 ThreadStart 委托
            Thread t21 = new Thread(new ThreadStart(NewThreadLogic), 1000); //使用 Lambda表达式 并指定线程的最大堆栈大小。
            //Thread t2 = new Thread(new ThreadStart(NewThreadLogic)); //使用 ThreadStart 委托 无法传递参数
            //ThreadStart 委托方式通过 ThreadStart 委托来指定线程启动时执行的方法。
            //这也是一个常用的方式，适用于不需要向线程方法传递参数的情况。
            //优点：
            //明确地使用委托类型，可以在类型级别上进行更多的操作，如组合多个方法。
            //易于理解和维护。
            //缺点：
            //相比直接使用Lambda表达式或方法引用，代码略显冗长。
            //不能直接向线程方法传递参数。

            //使用 ParameterizedThreadStart 委托
            Thread t3 = new Thread(new ParameterizedThreadStart(ParameterizedThreadMethod)); //使用 ParameterizedThreadStart 委托 并传递参数
            Thread t31 = new Thread(new ParameterizedThreadStart(ParameterizedThreadMethod), 1000); //使用 Lambda表达式 并指定线程的最大堆栈大小。
            //ParameterizedThreadStart 委托方式通过 ParameterizedThreadStart 委托来指定线程启动时执行的方法，并允许向线程方法传递一个 object 类型的参数。
            //优点：
            //可以向线程方法传递一个参数，这在需要根据参数执行不同逻辑时非常有用。
            //缺点：
            //代码相对复杂，需要处理参数的传递和类型转换。
            //参数类型限制为 object，可能需要进行类型转换。

            //2.启动线程
            t.Start();
            t1.Start();
            t11.Start();
            //t111.Start(1);

            t2.Start();
            t21.Start();

            t3.Start("参数");
            t31.Start("参数");

            //3.设置为后台线程
            //当前台线程都结束了的时候,整个程序也就结束了,即使还有后台线程正在运行
            //后台线程不会防止应用程序的进程被终止掉
            //如果不设置为后台线程 可能导致进程无法正常关闭
            t.IsBackground = true;  // 设置为后台线程

            //4.关闭释放一个线程
            //自然结束
            //如果开启的线程中不是死循环 是能够结束的逻辑 那么 不用刻意的去关闭它 线程会自行完成并结束

            //如果是死循环 想要中止这个线程 有两种方式
            // 4.1-死循环中boo1标识
            //Console.ReadKey();
            //isRuning = false;

            //Console.ReadKey();

            // 4.2-使用 Abort 方法（不推荐）(已弃用)
            // Thread.Abort 方法可以用来强制终止线程，但由于它可能导致资源未被正确释放和不稳定的状态，因此不推荐使用。
            // 通过线程提供的方法(注意在.Net core版本中无法中止 会报错)
            //中止线程
            //try
            //{
            //    t.Abort();
            //    t = null;
            //}
            //catch
            //{
            //}

            // 新方法
            // 4.3-使用 Join 方法
            // Join 方法可以让主线程等待子线程结束，直到子线程结束后才继续执行。
            // 注意：Join 方法只能在主线程中使用，不能在子线程中使用。
            //try
            //{
            //    t.Join();
            //    t = null;
            //}
            //catch
            //{
            //}

            // 4.4-使用 CancellationToken https://www.cnblogs.com/shanfeng1000/p/13402152.html
            // CancellationToken 可以用来取消线程的执行。
            // 通过 CancellationToken 可以在线程执行过程中随时取消线程的执行。
            // 注意：CancellationToken 只能在 .Net Framework 4.0 及以上版本中使用。
            static void ThreadMethod(CancellationToken token)
            {
                while (!token.IsCancellationRequested)  //判断是否取消
                {
                    // 执行一些操作
                    Console.WriteLine("Thread is running...");
                    Thread.Sleep(1000); // 模拟工作负载
                }
                Console.WriteLine("Thread cancellation requested.");
            }

            CancellationTokenSource cts = new CancellationTokenSource();
            Thread thread = new Thread(() => ThreadMethod(cts.Token));
            thread.Start();

            // 在需要停止线程时调用
            cts.Cancel();
            cts.CancelAfter(1000);  //设置超时时间

            CancellationTokenSource cts2 = new CancellationTokenSource(1000);

            //CancellationToken
            //属性如下：　　
            //静态属性，获取一个空的CancellationToken，这个CancellationToken注册的回调方法不会被触发，作用类似于使用空构造函数得到的CancellationToken
            //public static CancellationToken None { get; }
            //表示当前CancellationToken是否可以被取消
            //public bool CanBeCanceled { get; }
            //表示当前CancellationToken是否已经是取消状态
            //public bool IsCancellationRequested { get; }
            //和CancellationToken关联的WaitHandle对象，CancellationToken注册的回调方法执行时通过这个WaitHandle实现的
            //public WaitHandle WaitHandle { get; }

            //常用方法：　　
            //往CancellationToken中注册回调
            //public CancellationTokenRegistration Register(Action callback);
            //public CancellationTokenRegistration Register(Action callback, bool useSynchronizationContext);
            //public CancellationTokenRegistration Register([NullableAttribute(new[] { 1, 2 })] Action<object?> callback, object? state);
            //public CancellationTokenRegistration Register([NullableAttribute(new[] { 1, 2 })] Action<object?> callback, object? state, bool useSynchronizationContext);
            //当CancellationToken处于取消状态是，抛出System.OperationCanceledException异常
            //public void ThrowIfCancellationRequested();

            //5.线程休眠
            //让线程休眠多少毫秒 1s = 1000毫秒
            //在哪个线程里执行 就休眠哪个线程
            // Thread.Sleep(1000);
            #endregion

            #region 知识点五：线程之间共享数据
            // 多个线程使用的内存是共享的，都庭于该应用程序(进程)
            //所以要注意 当多线程 同时撰作同一片内存区域时可能会出问题
            //可以通过加锁的形式避免问题

            //lock
            //当我们在多个线程当中想要访问同样的东西 进行逻辑处
            //为了避免不必要的逻辑质序执行的查错
            //lock(引用类型对象)

            while (true)
            {
                lock (obj)  //线程运行时锁住 被其他线程占据时等待资源 结束释放
                {
                    Thread.Sleep(1000);
                    drawRed();
                }
            }
            #endregion

            #region 知识点六：多线程对于我们的意义
            //可以用多线程专门处理一些复杂耗时的逻辑
            //比如 寻路、网络通信等等
            #endregion
        }

        private static void ParameterizedThreadMethod(object? obj)
        {
            Console.WriteLine("ParameterizedThreadMethod:" + obj);
        }

        static void NewThreadLogic()
        {
            //新开线程 执行的代码逻辑 在该函数语句块中
            while (isRuning)
            {
                lock (obj)  //必须为引用类型
                {
                    Console.WriteLine("无参线程执行中");
                    Thread.Sleep(1000);
                    drawYellow();
                }
            }
        }

        static void NewThreadLogic(int waitTime)
        {
            //新开线程 执行的代码逻辑 在该函数语句块中
            while (isRuning)
            {
                lock (obj)  //必须为引用类型
                {
                    Console.WriteLine("有参线程执行中:" + waitTime);
                    Thread.Sleep(1000);
                    drawYellow();
                }
            }
        }

        public static void drawRed()
        {
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("●");
        }
        public static void drawYellow()
        {
            Console.SetCursorPosition(0, 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■");
        }
    }
}
