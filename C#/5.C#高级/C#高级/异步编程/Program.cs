namespace 异步编程
{
    internal class Program
    {
        #region C#中实现异步编程的几种方法
        //基于 async 和 await 关键字：这是最常见和推荐的方式，它允许你以接近同步代码的方式编写异步代码，使得代码易于阅读和维护。
        //基于 Task 对象：你可以手动创建和操作 Task 对象来实现异步编程，这种方式较为底层，通常不推荐直接使用，除非你需要更细粒度的控制。
        //基于回调（Callback Pattern）：这是一种传统的异步编程模式，通过将方法作为参数传递给另一个方法，并在操作完成时调用。
        //基于事件（Event-based Asynchronous Pattern, EAP）：这种模式使用事件来处理异步操作的完成，通常用于Windows Forms或WPF应用程序。
        //基于线程池（ThreadPool）：.NET Framework 4.0 引入了线程池，它允许你在后台线程上执行异步操作。
        //基于 Task.Factory：Task 类的工厂方法提供了更多创建和配置 Task 的选项。
        //基于 async 和 await 与 Task 对象结合使用：在某些情况下，你可能需要结合使用 async/await 和 Task 对象来实现复杂的异步逻辑。
        
        
        //基于 IAsyncResult：这是.NET Framework早期版本中使用的异步模式，现在较少使用，但仍有一些旧的库和框架支持这种模式。
        //基于 ValueTask：ValueTask 是一种轻量级的 Task，它旨在减少 Task 创建的开销，特别是在性能敏感的代码路径中。
        //基于 AsyncLocal：AsyncLocal 类允许你在异步上下文中存储和跟踪状态。
        //基于 AsyncEx：AsyncEx 库提供了一系列扩展方法，用于简化异步编程。
        //基于 TPL Dataflow：TPL Dataflow 库提供了用于并行和异步数据处理的组件。
        //基于 Reactive Extensions：Reactive Extensions 库提供了用于异步编程的扩展方法。
        //基于 F# Async：F# 语言提供的异步编程支持。
        #endregion C#中实现异步编程的几种方法

        #region 异步编程
        //定义：
        //异步编程允许程序在执行长时间运行的任务（如I/O操作）时，不会阻塞主线程。
        //这可以提高应用程序的响应性和吞吐量。

        //实现：
        //在C#中，async和await关键字是实现异步编程的主要方式。
        //async关键字用于声明一个方法为异步方法，而await关键字用于暂停方法的执行，直到等待的任务完成。

        //线程使用：
        //异步方法的执行不需要开发者直接管理线程。
        //.NET运行时会负责在后台线程上执行异步任务，并在任务完成时返回控制权给原始线程。

        //使用场景：
        //异步编程特别适合I/O密集型任务，如文件读写、网络通信、数据库访问等。
        //这些操作通常涉及等待外部资源，使用异步编程可以避免在等待期间阻塞线程。

        //示例：
        // 主程序入口，负责启动异步操作
        private static async Task Main()
        {
            // 使用 Task.Run 执行同步操作
            Task task_sync = Task.Run(() =>
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

            // 等待后台任务完成
            await task_sync;
            Console.WriteLine("Main thread waiting for sync operation to complete.");

            // 使用 await 执行异步操作
            await DoWorkAsync();
            Console.WriteLine("Main thread waiting for asynchronous operation to complete.");

            Console.WriteLine("Starting asynchronous operation...");
            Task task = DoWorkAsync();
            Console.WriteLine("Asynchronous operation started.");
            await task;
            Console.WriteLine("Asynchronous operation finished.");

            Task task_timeout = DelayTask(3000); // 一个延迟3秒的任务
            try
            {
                await task.WaitAsync(TimeSpan.FromSeconds(2)); // 等待2秒
                Console.WriteLine("Task completed within the timeout.");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("WaitAsync timed out.");
            }

            Console.WriteLine("Main method continues to run...");
        }

        static Task DelayTask(int milliseconds)
        {
            return Task.Delay(milliseconds);
        }

        // 异步工作方法，模拟一个耗时的操作
        private static async Task DoWorkAsync()
        {
            await Task.Delay(3000); // 模拟长时间操作
            Console.WriteLine("Work completed.");
        }

        #endregion 异步编程
    }

    class Program_not_async
    {
        public delegate void SimpleEventHandler(object sender, EventArgs e);

        public event SimpleEventHandler SimpleEvent;

        protected virtual void OnSimpleEvent()
        {
            SimpleEvent?.Invoke(this, EventArgs.Empty);
        }

        public void DoSomething()
        {
            Console.WriteLine("开始异步操作");
            OnSimpleEvent();
        }

        static void Main()
        {
            //使用回调
            //回调是一种传统的异步编程方法，它允许你将代码的执行推迟到某个操作完成时。
            //这种方法通常涉及将一个方法作为参数传递给另一个方法，并在某个点被调用。
            Task.Run(() =>
            {
                // 模拟异步操作
                Task.Delay(1000).ContinueWith(t =>
                {
                    Console.WriteLine("异步操作完成");
                });
            });

            Console.WriteLine("主线程继续执行");
            System.Threading.Thread.Sleep(2000); // 等待异步操作完成


            //使用基于任务的异步模式（TAP）
            //基于任务的异步模式（Task-based Asynchronous Pattern）是一种在 .NET 中
            //常用的异步编程模式。它使用 Task 对象来表示异步操作。
            Task task = Task.Factory.StartNew(() =>
            {
                // 模拟异步操作
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("异步操作完成");
            });

            Console.WriteLine("主线程继续执行");
            task.Wait(); // 等待异步操作完成


            //使用基于事件的异步模式（EAP）
            //事件驱动的异步编程模式允许你订阅和触发事件，从而实现异步操作。
            Program_not_async program = new Program_not_async();
            program.SimpleEvent += (sender, e) =>
            {
                Console.WriteLine("异步操作完成");
            };

            program.DoSomething();
            Console.WriteLine("主线程继续执行");


            //使用 Task.Factory.ContinueWhenAll 和 Task.WaitAll
            Task task1 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("任务1完成");
            });

            Task task2 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("任务2完成");
            });

            Task[] tasks = { task1, task2 };
            Task whenAll = Task.Factory.ContinueWhenAll(tasks, completedTasks =>
            {
                Console.WriteLine("所有任务完成");
            });

            whenAll.Wait(); // 等待所有任务完成


            //使用 Task.WhenAny
            Task task3 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("任务3完成");
            });

            Task task4 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("任务4完成");
            });

            Task<Task> whenAny = Task.WhenAny(task3, task4);
            whenAny.Wait(); // 等待任意一个任务完成
            Console.WriteLine("任意一个任务完成");


            //基于 Task.Factory
            //Task 类的工厂方法提供了创建和配置 Task 的选项。
            //例如，你可以使用 ContinueWith 方法来指定任务完成后要执行的操作。
            Task task5 = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("任务5完成");
            });

            task5.ContinueWith(t =>
            {
                Console.WriteLine("任务5继续执行");
            });

            Console.WriteLine("主线程继续执行");
            task5.Wait(); // 等待任务5完成








        }
    }
}