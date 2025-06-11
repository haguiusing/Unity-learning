namespace Lesson8_Task任务类知识点1
{
    internal class Program
    {
        public static bool isRunning = true;

        static CancellationTokenSource cts;

        static Task t1;
        static Task t2;
        static Task<int> t3;
        static Task<string> t4;
        static Task<float> t5;

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson8_Task任务类知识点1");

            #region 知识点一：认识Task
            //命名空间: System.Threading.Tasks
            //类名: Task
            //Task顾名思义就是任务的意思
            //Task是在线程池基础上进行的改进，它拥有线程池的优点，同时解决了使用线程池不易控制的弊端
            //它是对主线程池的优点对线程的封装，可以让我们更方便高效的进行多线程开发
            //简单理解:
            //Task的本质是对线程Thread的封装，它的创建遵循线程池的优点，并且可以更方便的让我们控制线程
            //一个Task对象就是一个线程
            #endregion

            #region 知识点二：创建无返回值的任务三种方式
            //1.通过new一个Task对象传入委托函数并启动
            t1 = new Task(static () =>
            {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式一:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
            t1.Start();
            //特点: 这种方式与直接创建线程类似，但Task是基于线程池的封装，性能更优。

            //2.通过Task类的Run静态方法传入委托函数
            t2 = Task.Run(() =>
            {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式二:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
            //特点: 相对于第一种方式，这种方法更为简洁，不需要显式调用Start方法，Run方法会直接启动任务。

            //3.通过Task.Factory中的StartNew静态方法传入委托函数
            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式三:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
            //特点: Task.Factory提供了更多的配置选项，如任务创建选项、取消令牌等，适用于需要更细粒度控制的任务创建场景。
            #endregion

            #region 知识点三：创建有返回值的Task
            //1.通过new一个Task对象调入委托函数并启动
            t3 = new Task<int>(() =>
            {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式一" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
                return 1;
            });
            t1.Start();

            //2. 通知Task中的Run静态方法传入委托函数
            t4 = Task.Run<string>(() =>
            {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式二:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
                return "1231";
            });

            //3.通过Task.Factory中的StartNew静态方法传入委托函数
            t5 = Task.Factory.StartNew<float>(() => {
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine("方式三:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
                return 4.5f;
            });

            //获取返回值
            //注意:
            //Result获取结果时会阻塞线程 
            //即如果task没有执行完成
            //会等待task执行完成就收到Result
            //然后再执行后边的代码,也就是说 执行到这句代码时 由J我们的Task中是死循环
            //所以主线程就会被卡死

            #endregion

            #region 知识点四：同步执行Task
            //刚才我们举的例子都是通过多线程异步执行的
            //如果你希望Task能够同步执行
            //只需要调用Task对象中的RunSynchronously方法
            //注意：需要使用 new Task对象的方式，因为Run和StartNew在创建时就会启动

            Task t = new Task(() => {
                Thread.Sleep(1000);
                Console.WriteLine("哈哈哈");
            });
            t.RunSynchronously();
            Console.WriteLine("主线程执行");
            //不Start 而是 RunSynchronously

            #endregion

            #region 知识点五：任务中线程阻塞的方式（任务阻塞）
            //1.Wait方法: 等待任务执行完毕, 再执行后面的内容
            Task t6 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("t1:" + i);
                }
            });
            Task t7 = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("t2:" + i);
                }
            });
            t6.Wait();

            //2.WaitAny静态方法：传入任务中任意一个任务结束就继续执行
            Task.WaitAny(t6, t7);

            //3.WaitAll前态方法：任务列表中所有任务执行结束就继续执行
            Task.WaitAll(t1, t2);

            Console.WriteLine("主线程执行");
            #endregion

            #region 知识点六：Task完成后继续其他Task（任务延续）
            //1.WhenAll静态方法 + ContinueWith方法：传入任务完毕后再执行某任务
            //WhenAll静态方法 - 等待所有任务执行完毕后再执行后续操作
            //ContinueWith方法 - 传入一个委托函数, 任务执行完毕后执行该委托函数
            Task.WhenAll(t1).ContinueWith((t) =>
            {
                Console.WriteLine("一个新的任务开始了");
                int i = 0;
                while (true)
                {
                    Console.WriteLine(i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            Task.Factory.ContinueWhenAll(new Task[] { t1, t2 }, (t) =>
            {
                Console.WriteLine("一个新的任务开始了"); int i = 0;
                while (isRunning)
                {
                    Console.WriteLine(i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            //2.WhenAny静态方法 + ContinueWith方法：传入任务中任意一个任务结束就执行某任务
            Task.WhenAny(t1, t2).ContinueWith((t) =>
            {
                Console.WriteLine("一个新的任务开始了");
                int i = 0;
                while (isRunning)
                {
                    Console.WriteLine(i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
            Task.Factory.ContinueWhenAny(new Task[] { t1, t2 }, (t) =>
            {
                Console.WriteLine("一个新的任务开始了");
                int i = 0; while (isRunning)
                {
                    Console.WriteLine(i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            #endregion

            #region 知识点七：取消Task执行
            //方法一：通过加入bool标识 控制线程内死循环的结束

            //方法二：通过CancellationToken取消标识源类 来控制
            //CancellationToken对象可以达到延迟取消、取消回调等功能
            cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                int i = 0;
                while (!cts.IsCancellationRequested)
                {
                    Console.WriteLine("计时: " + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            //延迟取消
            cts.CancelAfter(2000);

            //取消回调
            cts.Token.Register(() => { Console.WriteLine("任务取消了"); });

            CancellationToken c = cts.Token;
            c.Register(() =>
            {

            });

            #endregion

            #region 总结
            //1. Task类是若干Thread的封装
            //2. Task类可以有返回值, Thread没有返回值
            //3. Task类可以执行后续操作, Thread没有这个功能
            //4. Task类可以更加方便的取消任务, Thread相对更加简单
            //5. Task具备ThreadPool线程池的优点, 更节约性能
            #endregion

            OnDestroy();
        }

        public static void OnDestroy()
        {
            isRunning = false;

            Console.WriteLine("程序结束" + t3.Result + t4.Result + t5.Result);

            cts.Cancel();
        }
    }
}
