namespace 对象池
{
    public class ObjectPool<T>
    {
        private readonly Queue<T> _objects = new Queue<T>();
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        }

        public T Acquire()
        {
            return _objects.Count > 0 ? _objects.Dequeue() : _objectGenerator();
        }

        public void Release(T item)
        {
            _objects.Enqueue(item);
        }
    }

    public class ExpensiveObject
    {
        public void Use()
        {
            Console.WriteLine("ExpensiveObject is being used.");
        }

        public void Reset()
        {
            // 重置对象状态，以便可以被重新使用
            Console.WriteLine("ExpensiveObject is being reset.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建对象池，预生成一些对象
            var pool = new ObjectPool<ExpensiveObject>(() => new ExpensiveObject());
            for (int i = 0; i < 5; i++)
            {
                pool.Release(pool.Acquire());
            }

            // 使用对象池
            for (int i = 0; i < 10; i++)
            {
                var obj = pool.Acquire();  // 从对象池中获取对象
                obj.Use();  // 使用对象
                obj.Reset();  // 重置对象状态
                pool.Release(obj);  // 释放对象到对象池
            }
        }
    }
}
