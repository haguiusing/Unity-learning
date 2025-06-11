using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        //在 C# 中，ThreadPool 是一个非常有用的工具，用于管理线程的池，以便线程可以被重复使用。
        //API 文档：https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.threadpool?view=net-8.0

        #region 基本概念
        //ThreadPool 是由系统维护的线程集合，它负责管理一组可以并行执行任务的线程。
        //通过使用线程池，可以减少在创建和销毁线程上的时间消耗和系统资源的开销，从而提升应用程序的响应速度和整体性能。

        //线程池的基本概念：
        //1.线程池中包含一组可供使用的线程；
        //2.线程池中的线程可以被重复使用；
        //3.线程池中的线程可以执行任务；
        //4.线程池中的线程可以被动态添加或删除；
        //5.线程池中的线程可以根据需要自动调整大小。

        //线程池的优点：
        //1.降低资源消耗：线程池可以重复使用线程，避免了频繁创建和销毁线程的开销；
        //2.提升响应速度：线程池可以异步执行任务，避免了等待线程执行的时间；
        //3.提升系统资源利用率：线程池可以根据需要自动调整线程的数量，避免了线程过多或过少带来的资源浪费。

        //线程池的缺点：
        //1.线程池中的线程数量有限：线程池中的线程数量是有限的，当线程池中的线程都被占用时，新任务将被暂时保存，直到线程池中的线程空闲；
        //2.线程切换开销：线程切换的开销是不可忽视的，线程池中的线程数量越多，切换的开销就越大；
        //3.线程安全问题：线程池中的线程是共享的，在多线程环境下，需要考虑线程安全问题。

        #endregion 基本概念

        #region ThreadPool常用属性和方法
        //属性：
        //CompletedWorkItemCount:获取迄今为止已处理的工作项数。
        //PendingWorkItemCount:获取当前已加入处理队列的工作项数。
        //ThreadCount:获取当前存在的线程池线程数。

        //方法：
        //BindHandle(IntPtr)	将操作系统句柄绑定到 ThreadPool。
        //BindHandle(SafeHandle)  将操作系统句柄绑定到 ThreadPool。
        //GetAvailableThreads(Int32, Int32)   检索由 GetMaxThreads(Int32, Int32) 方法返回的最大线程池线程数和当前活动线程数之间的差值。
        //GetMaxThreads(Int32, Int32) 检索可以同时处于活动状态的线程池请求的数目。 所有大于此数目的请求将保持排队状态，直到线程池线程变为可用。
        //GetMinThreads(Int32, Int32) 发出新的请求时，在切换到管理线程创建和销毁的算法之前检索线程池按需创建的线程的最小数量。
        //QueueUserWorkItem(WaitCallback) 将方法排入队列以便执行。 此方法在有线程池线程变得可用时执行。
        //QueueUserWorkItem(WaitCallback, Object) 将方法排入队列以便执行，并指定包含该方法所用数据的对象。 此方法在有线程池线程变得可用时执行。
        //QueueUserWorkItem(Action, TState, Boolean)  将 Action 委托指定的方法排入队列以便执行，并提供该方法使用的数据。 此方法在有线程池线程变得可用时执行。
        //RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean)    注册一个等待 WaitHandle 的委托，并指定一个 32 位有符号整数来表示超时值（以毫秒为单位）。
        //SetMaxThreads(Int32, Int32) 设置可以同时处于活动状态的线程池的请求数目。 所有大于此数目的请求将保持排队状态，直到线程池线程变为可用。
        //SetMinThreads(Int32, Int32) 发出新的请求时，在切换到管理线程创建和销毁的算法之前设置线程池按需创建的线程的最小数量。
        //UnsafeQueueNativeOverlapped(NativeOverlapped)   将重叠的 I/ O 操作排队以便执行。
        //UnsafeQueueUserWorkItem(IThreadPoolWorkItem, Boolean)   将指定的工作项对象排队到线程池。
        //UnsafeQueueUserWorkItem(WaitCallback, Object)   将指定的委托排队到线程池，但不会将调用堆栈传播到辅助线程。
        //UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean)  注册一个等待 WaitHandle 的委托，并使用一个 32 位带符号整数来表示超时时间（以毫秒为单位）。 此方法不将调用堆栈传播到辅助线程。
        #endregion

        #region 线程池的使用
        //在 C# 中，可以通过 ThreadPool 类来创建线程池。该线程池可用于执行任务、发送工作项、处理异步 I/O、代表其他线程等待以及处理计时器。
        //ThreadPool 类提供了以下方法来创建线程池：
        //QueueUserWorkItem 方法返回一个布尔值，指示操作是否成功。
        //如果线程池达到其最大工作项数，该方法可能返回 false，表示工作项没有被成功排队。
        //通常，这个返回值用于调试和诊断目的，因为线程池几乎总是能够接受新工作项。
        //QueueUserWorkItem 方法有三种重载：
        //1.public static bool QueueUserWorkItem(WaitCallback callBack);  无参,接受一个代表用户异步操作的委托(名为 WaitCallback )，调用此方法传入委托后，就会进入线程池内部队列中。
        //2.public static bool ThreadPool.QueueUserWorkItem(WaitCallback callBack, object state)： 有参
        //3.public static bool QueueUserWorkItem<TState>(Action<TState> callBack, TState state, bool preferLocal); 泛型方法

        // 将任务添加到线程池队列以便执行。 此方法在有线程池线程变得可用时执行。
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));  // 无参数的任务
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), "Task argument");  // 带参数的任务

        ThreadPool.QueueUserWorkItem<string>(new Action<string>(DoWork), "Task argument", true);  // 带参数的任务，使用方法组
        //true 表示首选在靠近当前线程的队列中对工作项进行排队；false 则表示首选将工作项排队到线程池的共享队列中。
        // 创建一个工作项并将其排队到线程池
        bool result = ThreadPool.QueueUserWorkItem(  //<lambda 表达式>
            callBack: (state) =>
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is processing work item.");
                // 执行一些操作，例如处理状态信息
                Console.WriteLine($"State: {state}");
            },
            state: "Some data",
            preferLocal: true);
        //callBack 参数是一个委托, 用于指定任务的执行逻辑。
        //state 参数是一个可选参数，用于指定任务的附加信息。
        //preferLocal 参数是一个布尔值，指示线程池尽量在与调用线程相同的处理器上执行任务，用于优化性能,但这不是一种保证。

        //几种不同方式编写 Action<TState> 委托的示例：
        ThreadPool.QueueUserWorkItem(  //匿名方法
            (state) =>
            {
                // 在这里处理任务逻辑
                Console.WriteLine("Task started with state: " + state);
                Thread.Sleep(2000);
            },
            state: "Some data",
            preferLocal: true);

        ThreadPool.QueueUserWorkItem(  //lambda 表达式
            (state) => Console.WriteLine("Task started with state: " + state),
            state: "Some data",
            preferLocal: true);

        ThreadPool.QueueUserWorkItem(  //方法组
            DoWork, // 已经定义好的方法
            state: "Some data",
            preferLocal: true);

        if (result)
        {
            Console.WriteLine("Work item has been queued.");
        }
        else
        {
            Console.WriteLine("Failed to queue work item.");
        }

        //ThreadPool.UnsafeQueueUserWorkItem 方法是 ThreadPool 类的一个较不常用的方法，它允许将工作项排队到线程池中。
        //这个方法与 ThreadPool.QueueUserWorkItem 类似，但它提供了一个额外的 preferLocal 参数，该参数可以用来指示线程池尽量在本地核心上执行任务。
        //UnsafeQueueUserWorkItem 方法不是线程安全的，这意味着你必须确保在调用它时外部同步。
        //它通常用于性能敏感的环境，或者当你需要更细粒度控制线程执行的位置时。

        Console.WriteLine("Main thread work continues...");
        // 为了演示，让主线程等待一会儿
        Console.ReadLine();

        //该方法用于将任务添加到线程池中，等待线程池中的线程执行。
        //参数：
        //callBack：一个委托，用于指定任务的执行逻辑。
        //state：一个可选参数，用于指定任务的附加信息。

        //2.static void ThreadPool.SetMaxThreads/SetMinThreads(int workerThreads, int completionPortThreads)：
        //该方法用于设置线程池的最大/最小线程数。
        // 设置线程池的最大线程数
        ThreadPool.SetMaxThreads(4, 4);
        // 设置线程池的最小线程数
        ThreadPool.SetMinThreads(2, 2);
        //参数：
        //workerThreads：工作线程的最大/最小数量。
        //completionPortThreads：I/O 完成端口线程的最大/最小数量。

        //3.static void ThreadPool.GetMaxThreads/GetMinThreads(out int workerThreads, out int completionPortThreads)：
        //该方法用于获取线程池的最大/最小线程数。
        //获取线程池的最大线程数
        int workerThreads, completionPortThreads;
        ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
        Console.WriteLine($"Maximum worker threads: {workerThreads}");
        Console.WriteLine($"Maximum completion port threads: {completionPortThreads}");
        //获取线程池的最小线程数
        ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
        Console.WriteLine($"Minimum worker threads: {workerThreads}");
        Console.WriteLine($"Minimum completion port threads: {completionPortThreads}");
        //参数：
        //workerThreads：工作线程的最大/最小数量。
        //completionPortThreads：I/O 完成端口线程的最大/最小数量。

        //4.static void ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads)：
        //该方法用于获取线程池中可用的线程数。
        //获取线程池中可用的线程数
        ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
        Console.WriteLine($"Available worker threads: {workerThreads}");
        Console.WriteLine($"Available completion port threads: {completionPortThreads}");
        //参数：
        //workerThreads：工作线程的可用数量。
        //completionPortThreads：I/O 完成端口线程的可用数量。

        //5.static bool ThreadPool.TryGetAvailableThreads(out int workerThreads, out int completionPortThreads)：
        #endregion 线程池的

        Console.WriteLine("Hello, World!");
    }

    static void DoWork(object state)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is processing work item with argument: {state}");
        // 执行一些工作...
        Thread.Sleep(2000); // 模拟耗时操作
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished processing.");
    }
}