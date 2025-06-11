ArrayList: Add AddRange Insert Remove RemoveAt Clear IndexOf LastIndexOf
Stack: Push Pop Peek Clear Contains
Queue: Enqueue Dequeue Peek Contains
Hashtable: Add Remove Clear Contains ContainsKey ContainsValue
泛型约束：struct class 自定义非抽象的类 接口 new() 另一个泛型
List：Add AddRange Insert Remove RemoveAt Clear IndexOf LastIndexOf Sort CompareTo
Dictionary：Add TryAdd Remove ContainsKey TryGetValue ContainsValue

delegate：访问修饰符 delegate 返回值 委托名(参数列表);
Predicate：访问修饰符 delegate bool Predicate<in T>(T obj);
Action：无返回值
Func：有返回值
event：访问修饰符 event 
匿名方法：delegate(参数列表){函数体};
lambad表达式：(参数列表)=>{函数体};

协变：out
逆变：in

lock
Thread：Start Cancel Sleep .IsBackGround Abort(已弃用) Join
new Thread(NewThreadLogic);  //本地方法
new Thread(new ThreadStart(NewThreadLogic)); //无参委托
new Thread(new ParameterizedThreadStart(ParameterizedThreadMethod)); //一个参数委托

关闭释放一个线程
Abort(已弃用)
Join
CancellationToken

ThreadPool：Get|SetMax|MinThreads QueueUserWorkItem

Task：Start Run RunSynchronously Wait WaitAny WaitAll WhenAny/WhenAll搭配ContinueWith 
Task.Factory：StartNew ContinueWhenAny|All
CancellationToken：Register 
CancellationTokenSource：Cancel CancelAfter

using(对象申明){}  需继承IDisposable

模式匹配：is
XXX is 常量----------------------判断
XXX is 变量类型 变量名---------判断加赋值
XXX is var 变量名----------------赋值
变量 is {属性:值, 属性:值}--------判断

switch表达式：
switch(XXX)
   case is 变量类型 变量名------判断加赋值
   ...

用=>表达式符号代替case:组合
用_弃元符号代替default
函数声明 => 变量 switch
{
 常量=>返回值表达式,
 常量=>返回值表达式,// 常量=>返回值表达式,
 ...
 _ => 返回值表达式,
}

元组：
            申明                                             读取
(参数类型类别) 元组名 =  另一个元组 --> 元组名.ItemN(N从1开始)
(参数类型+变量名) 元组名 =  另一个元组 --> 元组名.变量名
(变量名列表) 元组名 =  另一个元组 --> 元组名.变量名
(变量名列表) 元组名 =  方法()

元组+模式匹配：
(ii, bb) is (11, true)--------判断

位置模式：
类中需要实现解构函数 Deconstruct(out 参数列表)
类对象 is (字段列表)

空合并操作：??
空合并赋值：??=
