using System.Runtime.CompilerServices;
using System.Threading.Tasks;

internal class Program
{
    #region 多线程、并发、异步、同步与并行
    //多线程是指在一个程序中同时运行多个线程，每个线程执行不同的任务。
    //多线程可以提高程序的效率，特别是在处理I/O操作（如文件读写、网络通信）时。
    // 实现：可以通过Thread类或Task类来创建和管理线程。
    // 线程使用：需要直接创建和控制线程。
    // 使用场景：适用于CPU密集型任务，可以并行处理多个任务。

    //并发是指多个任务在同一时间段内交替进行,不一定并行。
    // 实现：通过异步编程、多线程或其他并发模型实现。
    // 线程使用：可以是异步操作，也可以是多个线程。
    // 使用场景：适用于需要提高吞吐量和响应性的应用程序。

    //同步操作是指必须等待前一个操作完成，后续操作才能继续,指协调多个线程的执行顺序，确保共享资源在同一时间只能被一个线程访问。
    //同步操作会阻塞线程直到任务完成。
    // 实现：可以使用lock、Monitor、Mutex等同步原语。
    // 线程使用：用于多线程环境中。
    // 使用场景：适用于保护共享资源不被并发访问导致数据不一致。

    //异步操作则允许程序在等待某个任务完成的同时，继续执行其他任务。这在需要长时间等待的操作（例如网络请求）中非常有用。
    // 实现：通过异步编程模型实现。
    // 线程使用：可以是异步操作编程(不需要直接操作线程，由.NET运行时管理)，也可以是多个线程。
    // 使用场景：适用于I/O密集型任务，如文件操作、网络请求等。

    //并行编程是指将任务分解为多个部分，并同时执行这些部分。
    // 实现：可以通过Parallel类、Task Parallel Library(TPL)或async/await实现。
    // 线程使用：通常由.NET运行时管理，但也可以显式创建线程。
    // 使用场景：适用于需要提高性能和吞吐量的并行计算任务。
    public void ProcessDataInParallel()
    {
        Parallel.For(0, 100, i =>
        {
            // Process data in parallel
        });
    }

    #endregion
    private static void Main(string[] args)
    {
        //在 C# 中，Task 是 System.Threading.Tasks 命名空间下的一个类，它代表了异步操作的完成。
        //Task 提供了一种基于任务的异步编程模型，允许你在不阻塞调用线程的情况下执行代码。
        //API 文档：https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task?view=net-8.0

        CancellationTokenSource cts = new CancellationTokenSource();

        #region 任务的创建和启动
        // 创建一个 Task 对象,8个重载
        //public Task(Action action); // 无参数 Action
        Task task = new Task(() => Console.WriteLine("Hello World!"));

        //public Task(Action action, CancellationToken cancellationToken); // 带取消标记的 Action
        CancellationToken token = cts.Token;
        Task task_token = new Task(() => Console.WriteLine("Hello World!"), token);

        //public Task(Action action, TaskCreationOptions creationOptions); // 带创建选项的 Action
        Task task_options = new Task(() => Console.WriteLine("Hello World!"), TaskCreationOptions.LongRunning);

        //public Task(Action<object?> action, object? state); // 有参数 Action
        Action<object?> action = state => Console.WriteLine("Hello " + (string)state);
        Task task_state = new Task(action, "World!");

        //public Task(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions); // 带取消标记和创建选项的 Action
        CancellationToken token_options = cts.Token;
        Task task_token_options = new Task(() => Console.WriteLine("Hello World!"), token, TaskCreationOptions.None);

        //public Task(Action<object?> action, object? state, CancellationToken cancellationToken); // 有参数 Action 带取消标记
        Action<object?> action_token = state => Console.WriteLine("Hello " + (string)state);
        CancellationToken token_state = cts.Token;
        Task task_token_state = new Task(action, "World!", token);

        //public Task(Action<object?> action, object? state, TaskCreationOptions creationOptions); // 有参数 Action 带创建选项
        Task task_options_state = new Task(action, "World!", TaskCreationOptions.LongRunning);

        //public Task(Action<object?> action, object? state, CancellationToken cancellationToken, TaskCreationOptions creationOptions); // 有参数 Action 带取消标记和创建选项
        Action<object?> action_options = state => Console.WriteLine("Hello " + (string)state);
        CancellationToken token_options_state = cts.Token;
        Task task_token_options_state = new Task(action, "World!", token, TaskCreationOptions.LongRunning);

        //TaskCreationOptions是一个枚举，它指定了在创建 Task 时的各种选项。
        //这些选项可以控制任务的行为，例如任务的执行方式、任务的生命周期等。
        //None：默认选项。不指定任何特殊行为。
        //PreferFairness：指示线程池尽量公平地调度任务。如果多个任务并发等待执行，设置这个选项可以使它们获得更公平的执行机会。
        //LongRunning：通知线程池该任务可能会运行很长时间。线程池可能会为这样的任务创建专用的线程，以避免长时间占用线程池中的工作线程。
        //AttachedToParent：指定任务是父任务的子任务，并且父任务的完成会等待子任务的完成。这在创建任务层次结构时非常有用。
        //DenyChildAttach：防止任务被其他任务附加。即使设置了 AttachedToParent 选项，也无法将此任务作为子任务附加到其他任务上。
        //HideScheduler：防止任务被调度器（Scheduler）看到。这通常用于调试和诊断目的，以确保任务只由线程池调度。
        //RunContinuationsAsynchronously：指示任务的继续执行（Continuations）应该异步运行。这可以确保即使在完成任务的线程上立即有可用的线程，继续执行的任务也会被排队到线程池中。
        //(已弃用，若需要用按位或操作（|）来组合)PreferFairnessRunContinuationsAsynchronously：结合了 PreferFairness 和 RunContinuationsAsynchronously 选项。这确保了任务的继续执行既公平又异步。
        //PreferFairnessRunContinuationsAsynchronously = TaskCreationOptions.PreferFairness | TaskCreationOptions.RunContinuationsAsynchronously;


        // -----启动Task-----
        //  Start()方法启动一个 Task 对象，它会在线程池中运行。
        task.Start();  // 启动一个 Task 对象

        //TaskScheduler 是一个抽象类，它定义了调度 Task 的行为。
        //默认情况下，当你创建一个 Task 并调用 Start 方法时，它将在 TaskScheduler.Default 调度器上运行，
        //这通常意味着 Task 会在线程池中的一个线程上执行。
        //var customScheduler = new CustomTaskScheduler();// 创建一个自定义的TaskScheduler
        //task.Start(customScheduler);// 使用自定义的TaskScheduler启动Task


        //  Run()方法创建并启动一个 Task 对象，它会在线程池中运行。
        // 使用 Action 版本的 Task.Run 用于无返回值的同步或异步操作 
        //   接受一个 Action 委托，即一个没有返回值的委托（返回类型为 void）。
        //   当你传递一个同步方法给这个版本的 Task.Run 时，它会在线程池的一个线程上异步执行这个方法。
        //   如果你传递的是一个返回 Task 的异步方法，这个方法仍然会异步执行，
        //   但是返回的 Task 将不会是异步方法实际返回的 Task 实例。
        //   相反，它将返回一个新的 Task 实例，该实例在原始任务完成时完成，
        //   但不提供对原始任务进度或结果的访问。
        Task taskAction = Task.Run(() =>  //一个重载 带取消标记的 Action
        {
            // 这是一个同步方法，没有返回值
            Console.WriteLine("Sync operation started on thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            // 执行一些工作
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Working... " + i);
                System.Threading.Thread.Sleep(1000); // 模拟耗时操作
            }
            Console.WriteLine("Sync operation completed on thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        });

        // 注意：Action 委托中不推荐执行异步操作，因为它隐藏了异步操作的返回值,应该使用 Task.Run(Func<Task>) 重载版本，这样可以正确地处理异步操作的返回值。

        // 使用 Func<Task?> 版本的 Task.Run 用于返回 Task 的异步操作。
        Task taskFunc = Task.Run(() =>  //一个重载 带取消标记的 Func<Task?>
        {
            // 这是一个异步方法
            Console.WriteLine("Func<Task> version: Task is starting on thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            return DoSomeAsyncWork();
        });

        //  使用Func<TResult> 版本的 Task.Run 用于返回 TResult 的同步操作。
        Task<int> taskFuncResult = Task.Run(() =>  //一个重载 带取消标记的 Func<TResult>
        {
            // 这是一个同步方法，返回一个 int 值
            Console.WriteLine("Func<TResult> version: Task is starting on thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            return 42;
        });

        //  使用Func<Task<TResult>?> 版本的 Task.Run 用于返回 Task<TResult> 的异步操作。
        Task<int> resultTask = Task.Run(() =>
        {
            Console.WriteLine("Starting an async operation.");
            return Task.FromResult(42); // 返回一个包含结果的Task
        });
        resultTask.ContinueWith(t =>
        {
            int result = t.Result;
            Console.WriteLine($"Background operation completed with result: {result}");
        });

        #endregion

        #region 等待任务完成
        // Wait()方法 该方法无限期地等待任务完成。
        // 如果任务已完成，则立即返回；如果任务未完成，则调用线程被阻塞，直到任务完成。
        task.Wait();  // 5个重载
        task_token.Wait(1000);  //等待任务完成，直到指定的超时时间。如果任务在超时时间内完成，则返回 true。如果超时时间到达而任务未完成，则返回 false。
        task_options.Wait(TimeSpan.FromSeconds(5));  // Wait(int millisecondsTimeout) 类似，但超时时间使用 TimeSpan 表示。
        //int millisecondsTimeout   等待任务完成的超时时间（以毫秒为单位）。
        //CancellationToken cancellationToken 允许你提供自定义的时间源。
        //TimeSpan timeout 允许你取消等待操作。

        //WaitAll (params Task[] tasks)方法 该方法等待一组任务完成。
        Task.WaitAll(task, task_token, task_options, task_state, task_token_options, task_options_state, task_token_options_state);  // 等待多个 Task 对象完成

        //WaitAny (params Task[] tasks)方法 该方法等待任意一个任务完成。
        Task.WaitAny(task, task_token, task_options, task_state, task_token_options, task_options_state, task_token_options_state);  // 等待任意一个 Task 对象完成

        //WaitAsync(TimeSpan timeout)方法 该方法返回一个 Task 对象，该对象在超时时间到达后完成。
        //在调用 WaitAsync 时，你需要使用 await 关键字，因为它返回的是一个 Task。

        //F:\Unity学习\C#\5.C#高级\C#高级\异步编程\Program.cs

        #endregion

        #region 其他方法
        //Delay：
        //创建一个在指定延迟后完成的任务。
        //可以指定一个 TimeSpan/int 值来表示延迟时间，一个可选的时间提供器，和一个取消令牌。
        //Task.Delay(1000).ContinueWith(t => Console.WriteLine("Delay completed."));

        //Dispose
        //Dispose 方法用于释放 Task 实例所使用的资源。
        //这个方法通常由实现了 IDisposable 接口的类实现，但在 Task 类中，
        //这个方法主要是为了释放与任务相关的资源。
        // 例如，在 Task 完成之前，Task 不会释放 CancellationTokenSource。
        // 因此，你需要在完成任务之前调用 Dispose 方法来释放 CancellationTokenSource。
        task_token_options_state.Dispose();  // 释放 Task 实例所使用的资源

        //FromCanceled：
        //创建一个已取消的任务。
        //这在你有一个操作需要提前取消，并且立即返回一个已取消的任务时使用,用于方法返回或错误处理。
        //简化取消逻辑，避免复杂的取消流程。
        Task.FromCanceled(new CancellationToken(true));

        //FromException：
        //创建一个已完成的任务，且其状态为异常。
        //当你在执行异步操作时遇到错误，你可以使用这个方法来创建一个出错的任务，而不是直接抛出异常。
        //方便的错误传播，允许调用者通过 await 或 ContinueWith 处理异常。
        Task.FromException(new InvalidOperationException("Something went wrong."));

        //RunSynchronously：
        //创建一个在调用线程上立即完成的任务。这个方法会阻塞调用线程，直到任务完成。(可能会导致死锁)
        //在需要立即执行任务并获取结果，而不想等待异步操作完成的场景中使用。
        //用于单元测试，可以同步执行异步代码并立即验证结果。
        try
        {
            Task task_sync = Task.Run(() =>
            {
                // 异步执行的操作
                Console.WriteLine("Hello from RunSynchronously");
            });
            task.RunSynchronously(); // 在当前线程同步执行任务
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        //WhenAll：
        //创建一个 Task，该 Task 等待一组 Task 完成。
        //当你需要等待一组 Task 完成时，可以使用 WhenAll 方法。
        //WhenAll 方法返回一个 Task，该 Task 在所有传入的 Task 完成时完成。
        //当你需要等待一组 Task 完成时，可以使用 WhenAll 方法。
        //WhenAll 方法返回一个 Task，该 Task 在所有传入的 Task 完成时完成。
        Task[] tasks = { task, task_token, task_options, task_state, task_token_options, task_options_state, task_token_options_state };
        Task whenAllTask = Task.WhenAll(tasks);

        //WhenAny：
        //创建一个 Task，该 Task 等待任意一个 Task 完成。
        //当你需要等待任意一个 Task 完成时，可以使用 WhenAny 方法。
        //WhenAny 方法返回一个 Task，该 Task 在任意一个传入的 Task 完成时完成。
        //当你需要等待任意一个 Task 完成时，可以使用 WhenAny 方法。
        //WhenAny 方法返回一个 Task，该 Task 在任意一个传入的 Task 完成时完成。
        Task whenAnyTask = Task.WhenAny(tasks);

        //Exception：
        //获取 Task 实例的异常。
        //当 Task 实例完成时，你可以通过 Exception 属性获取其异常。
        //如果 Task 实例已完成且没有异常，则该属性返回 null。
        //如果 Task 实例已完成且抛出了异常，则该属性返回该异常。
        //Task.Exception 是一个只读属性，只能在 Task 实例完成后读取。
        //Task.Exception 是一个只读属性，只能在 Task 实例完成后读取。
        try
        {
            task.Wait();
            Console.WriteLine(task.Exception);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions[0].Message);
        }
        #endregion 其他方法

        #region 取消任务
        //在C#中，取消一个 Task 对象通常涉及到 CancellationTokenSource 和 CancellationToken。
        cts.Cancel();  // 取消 CancellationTokenSource
        cts.CancelAfter(5000);  // 取消 CancellationTokenSource，并设置延迟时间
                                //只想取消其中的一个或几个，而不是全部，那么您需要为每个任务使用独立的 CancellationTokenSource。
        #endregion

        #region Task的生命周期
        //运行：
        //  任务开始执行，进入 Running 状态。
        //
        //完成：
        //  如果任务成功执行完毕，进入 Completed 状态。
        //
        //取消或失败：
        //  如果任务被取消或发生未处理的异常，分别进入 Canceled 或 Faulted 状态。
        #endregion

        #region TaskScheduler 
        //Task 的执行依赖于 TaskScheduler，它负责将任务分配到合适的线程中。
        //默认情况下，TaskScheduler 使用线程池（ThreadPool）来调度任务。

        //TaskScheduler 是一个抽象类，定义了任务的调度逻辑。
        //默认实现是 ThreadPoolTaskScheduler，它将任务调度到线程池中执行。
        //开发者也可以自定义 TaskScheduler，用于特定场景（如限制任务并发数量）。
        #endregion

        #region TaskCompletionSource  
        //在底层，Task 是通过状态机跟踪任务的状态，并在任务完成时触发相关的回调逻辑。
        //在底层，Task 是通过状态机实现的。状态机会跟踪任务的状态，并在任务完成时触发相关的回调逻辑。
        #endregion

        #region CancellationToken  
        //CancellationToken有一个构造函数，可以传入一个bool类型表示当前的CancellationToken是否是取消状态。
        //另外，因为CancellationToken是一个结构体，所以它还有一个空参数的构造函数。
        //属性如下：　　

        /// <summary>
        /// 静态属性，获取一个空的CancellationToken，这个CancellationToken注册的回调方法不会被触发，作用类似于使用空构造函数得到的CancellationToken
        /// </summary>
        //public static CancellationToken None { get; }


        /// <summary>
        /// 表示当前CancellationToken是否可以被取消
        /// </summary>
        //public bool CanBeCanceled { get; }

        /// <summary>
        /// 表示当前CancellationToken是否已经是取消状态
        /// </summary>
        //public bool IsCancellationRequested { get; }

        /// <summary>
        /// 和CancellationToken关联的WaitHandle对象，CancellationToken注册的回调方法执行时通过这个WaitHandle实现的
        /// </summary>
        //public WaitHandle WaitHandle { get; }
        #endregion

        #region CancellationToken  
        //CancellationTokenSource可以理解为CancellationToken的控制器，控制它什么时候变成取消状态的一个对象，
        //它有一个CancellationToken类型的属性Token，只要CancellationTokenSource创建，这个Token也会被创建，
        //同时Token会和这个CancellationTokenSource绑定：　　
        #endregion

        #region TaskAwaiter  
        //TaskAwaiter 表示等待异步任务完成的对象并为结果提供参数。
        //Task 有个 GetAwaiter() 方法，会返回TaskAwaiter 或TaskAwaiter<TResult>，
        //TaskAwaiter 类型在 System.Runtime.CompilerServices 命名空间中定义。

        //TaskAwaiter 类型的属性和方法如下：
        //属性：
        //属性                      说明
        //IsCompleted               获取一个值，该值指示异步任务是否已完成。

        //方法：
        //方法                      说明
        //GetResult()               结束异步任务完成的等待。
        //OnCompleted(Action)       将操作设置为当 TaskAwaiter 对象停止等待异步任务完成时执行。
        //UnsafeOnCompleted(Action) 计划与此 awaiter 相关异步任务的延续操作。
        #endregion

        #region TimeSpan  
        //表示一个时间间隔
        #endregion

    }

    // 自定义TaskScheduler实现
    class CustomTaskScheduler : TaskScheduler
    {
        protected override void QueueTask(Task task)
        {
            // 将任务添加到自定义队列
            // 这里只是一个示例，实际实现中你需要将任务添加到一个队列，并在适当的时候执行它们
            Console.WriteLine("Task queued on thread: " + Thread.CurrentThread.ManagedThreadId);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // 尝试在当前线程上执行任务
            // 这里只是一个示例，实际实现中你需要根据你的调度逻辑来决定是否在当前线程上执行任务
            return false;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            // 返回当前调度器上排队的任务
            // 这里只是一个示例，实际实现中你需要返回你的调度器上排队的任务
            return new Task[0];
        }
    }

    // 一个异步方法，模拟一些异步工作
    static async Task DoSomeAsyncWork()
    {
        Console.WriteLine("Doing some async work on thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(3000); // 模拟异步延迟
        Console.WriteLine("Async work completed on thread " + System.Threading.Thread.CurrentThread.ManagedThreadId);
    }
}