using System.Runtime.CompilerServices;

namespace Lesson7_回顾线程学习线程池知识点
{
    internal class Program
    {
        static Thread t;
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson7_回顾线程学习线程池知识点");

            #region 知识点一：回顾知识点一线程
            //Unity线程使用注意事项
            //支持性: Unity支持多线程编程
            //限制:
            //  开启的多线程不能使用主线程中的Unity对象
            //  开启多线程后必须记得关闭
            //关闭方法: 在OnDestroy生命周期函数中关闭线程

            t = new Thread(() =>
            {
                Thread.Sleep(1000);
                //Console.WriteLine(gameObjct.name);  //错误用法，不能在线程中使用Unity主线程中的对象
            });
            t.Start();
            #endregion

            #region 知识点二：补充知识点一线程池
            //线程池基本概念
            //定义: 线程池(ThreadPool)是System.Threading命名空间下的类
            //优点:
            //  避免频繁创建删除线程带来的性能消耗
            //  减少内存垃圾产生
            //  有效减少GC触发
            //工作原理:
            //  从池中获取空闲线程执行任务
            //  任务完成后线程被回收而非销毁
            //  所有线程忙碌时才创建新线程

            //线程池重要方法
            //1. 获取可用的工作线程数和I/O线程数(线程池中空闲线程的数量)
            int num1;
            int num2;
            ThreadPool.GetAvailableThreads(out num1, out num2);
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            //2. 设置线程池中可以同时处于活动状态的工作线程的最大数目和I/O线程的最大数目
            // 大于次数的请求将保持排队状态，知道主线程池线程变为可用
            // 更改成功返回true，失败返回false
            if (ThreadPool.SetMaxThreads(20, 20))
            {
                Console.WriteLine("更改成功");
            }

            //3. 获取线程池中工作线程的最大数目和I/O线程的最大数目（当前设置值）
            ThreadPool.GetMaxThreads(out num1, out num2);
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            //4.设置 工作线程的最小数目和I/O线程的最小数目
            if (ThreadPool.SetMinThreads(5, 5))
            {
                Console.WriteLine("设置成功");
            }
            //5.获取线程池中工作线程的最小数目和I/O线程的最小数目
            ThreadPool.GetMinThreads(out num1, out num2);
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            //6.将方法排入队列以便执行,当线程池中线程变得可用时执行
            ThreadPool.QueueUserWorkItem(obj =>
            {
                Console.WriteLine("开启了一个线程");
            }, "obj参数");
            Console.WriteLine("主线程执行");

            //线程池局限性
            //缺点:
            //  不能控制线程执行顺序
            //  无法获取线程取消 / 异常 / 完成通知
            //  线程池中的线程是后台线程
            #endregion

            #region 总结
            //线程使用要点:
            //    Unity支持多线程但有限制
            //    新线程不能访问主线程Unity对象
            //      必须手动关闭开启的线程
            //线程池优势:
            //  减少线程创建开销
            //  降低GC触发频率
            //  提高多线程应用性能
            #endregion
            OnDestroy();
        }

        private static void OnDestroy()
        {
            t.Abort();
        }
    }
}
