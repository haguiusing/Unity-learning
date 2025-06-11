![[Lesson12 1.cs]]

### 异步方法和同步方法的区别
- 同步方法：方法中逻辑执行完毕后，再继续执行后面的方法
- 异步方法：方法中逻辑可能还没有执行完毕，就继续执行后面的内容

#### 异步方法的本质
- 往往异步方法当中都会使用多线程执行某部分逻辑
- 因为我们不需要等待方法中逻辑执行完毕就可以继续执行下面的逻辑了

#### 注意
Unity中的协同程序中的某些异步方法，有的使用的是多线程有的使用的是迭代器分步执行，关于协同程序可以回顾Unity基础当中讲解协同程序原理的知识点

### 举例说明异步方法原理
我们以一个异步倒计时方法举例
#### 线程回调
```cs
/// <summary>
/// 在新线程中执行异步倒计时操作，并在倒计时结束时触发回调函数。会直接重头到尾把函数执行完毕
/// </summary>
/// <param name="second">倒计时的秒数。</param>
/// <param name="callBack">倒计时结束时要触发的回调函数（可选）。</param>
public void CountDownAsync(int second, UnityAction callBack)
{
    // 创建一个新线程来执行倒计时操作
    Thread t = new Thread(() =>
    {
        while (true)
        {
            print(second); // 打印当前剩余秒数
            Thread.Sleep(1000); // 线程休眠1秒，模拟每秒减少1秒
            --second; // 减少剩余秒数
            if (second == 0) // 如果剩余秒数为0，跳出循环
                break;
        }
        callBack?.Invoke(); // 调用回调函数（如果已提供）
    });
    t.Start(); // 启动新线程

    print("开始倒计时"); // 打印倒计时开始信息 倒计时开始时就会触发了
}

CountDownAsync(5, () =>
{
    print("倒计时结束");
});
print("异步执行后的逻辑1");
```

#### async和await
```cs
/// <summary>
/// 使用异步任务执行倒计时操作，打印剩余秒数，并在倒计时结束时打印结束信息。会在异步任务结束后才执行之后的逻辑
/// </summary>
/// <param name="second">倒计时的秒数。</param>
public async void CountDownAsync(int second)
{
    print("倒计时开始"); // 打印倒计时开始信息

    // 使用异步任务进行倒计时
    await Task.Run(() =>
    {
        while (true)
        {
            print(second); // 打印当前剩余秒数
            Thread.Sleep(1000); // 线程休眠1秒，模拟每秒减少1秒
            --second; // 减少剩余秒数
            if (second == 0) // 如果剩余秒数为0，跳出循环
                break;
        }
    });

    print("倒计时结束"); // 打印倒计时结束信息 要等上面的倒计时异步任务结束才会触发
}

// 会等待线程执行完毕 继续执行后面的逻辑
// 相对第一种方式 可以让函数分步执行
CountDownAsync(5);
print("异步执行后的逻辑2");
```

### Socket中TCP通信中Begin开头配合End开头方法使用的异步方法
#### 概述
- Socket中TCP通信中Begin开头配合End开头方法使用的
- 异步方法通常会存在回调函数作为异步方法的参数，通常也会有一个Socket类型的参数。
- 这个回调函数通常是有一个有参无返回值的类型函数，参数类型是IAsyncResult。
- IAsyncResult类中的AsyncState变量通常会as转换成Socket对象，相当于得到异步方法传入的Socket类型对象再进行操作。
- IAsyncResult类中的AsyncWaitHandle变量用于同步等待，了解即可。

#### 声明TCP的socket
```cs
// 声明TCP的socket
Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```

#### 服务端相关
##### Socket.BeginAccept 服务端接收客户端连接

##### Socket.EndAccept 服务端检测到客户端连接得到客户端Socket
```cs
// 处理服务端异步接受客户端连接的操作完成时的回调函数
private void AcceptCallBack(IAsyncResult asyncResult)
{
    try
    {
        // 获取IAsyncResult对象中的AsyncState 强转成Socket对象 这个对象就是我们传入的socketTcp
        Socket socketTcp = asyncResult.AsyncState as Socket;

        // EndAccept方法 服务端检测到客户端的连接结束得到客户端Socket
        // 通过调用EndAccept 会返回一个连入的客户端Socket
        Socket clientSocket = socketTcp.EndAccept(asyncResult);

        // 再次调用BeginAccept以便继续监听新的客户端连接请求
        socketTcp.BeginAccept(AcceptCallBack, socketTcp);
    }
    catch (SocketException e)
    {
        print("服务端异步接受客户端连接问题" + e.SocketErrorCode);
    }
}

// BeginAccept 服务端接收客户端的连接方法
// EndAccept 服务端检测到客户端的连接结束得到客户端Socket方法
// BeginAccept方法 让服务端开始接收客户端的连接 需要传入 处理异步接受客户端连接的操作完成时的回调函数 和 服务端Socket
socketTcp.BeginAccept(AcceptCallBack, socketTcp);
```

#### 客户端相关
##### Socket.BeginConnect 异步连接到服务器
##### Socket.EndConnect 完成异步连接服务器操作
```cs
// BeginConnect 客户端异步连接到服务器端方法
// EndConnect 客户端完成异步连接到服务器端方法
// 创建一个IPEndPoint对象，用于指定服务器的IP地址和端口号
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
// BeginConnect方法 开始异步连接到服务器需要传入 处理客户端异步连接的操作完成时的回调函数 和客户端的Socket
socketTcp.BeginConnect(iPEndPoint, (asyncResult) =>
{
    // 异步回调函数，处理连接操作的完成

    // 从异步操作结果中获取连接使用的Socket对象
    Socket socketTcp = asyncResult.AsyncState as Socket;

    try
    {
        // 完成异步连接操作
        socketTcp.EndConnect(asyncResult);
        print("连接成功");
        // 连接成功后，客户端一般不需要重复连接，可以开始发送和接收消息
    }
    catch (SocketException e)
    {
        print("连接出错" + e.SocketErrorCode + e.Message);
        // 在这里可以编写断线重连的逻辑，处理连接出错的情况
    }
}, socketTcp);
```

#### 服务器客户端通用
##### 声明字节数组
```cs
private byte[] resultBytes = new byte[1024];
```

##### Socket.BeginReceive 端开始接收消息
##### Socket.EndReceive 端结束接收消息
```cs
// 处理端开始接收消息的回调函数
private void ReceiveCallBack(IAsyncResult asyncResult)
{
    try
    {
        // 获取IAsyncResult对象中的AsyncState 强转成Socket对象 这个对象就是我们传入的socketTcp
        Socket socketTcp = asyncResult.AsyncState as Socket;

        // EndReceive方法 端结束接收消息 会返回接收的字节数组长度
        int num = socketTcp.EndReceive(asyncResult);

        // 进行消息处理 比如得到字符串
        Encoding.UTF8.GetString(resultBytes, 0, num);

        // 再次调用ReceiveCallBack 端重新开始接收消息方法
        socketTcp.BeginReceive(resultBytes, 0, resultBytes.Length, SocketFlags.None, ReceiveCallBack, socketTcp);
    }
    catch (SocketException e)
    {
        print("接受消息处问题" + e.SocketErrorCode + e.Message);
    }
}

// 接收消息
// BeginReceive 端开始接收消息方法
// EndReceive 端结束接收消息方法 会返回接收的字节数组长度
// BeginReceive方法 端开始接收消息 需要传入 接收消息的字节数组 从接收消息的字节数组第几位开始传 字节数数组长度 Socket标识 接收消息回调函数 端Socket对象
socketTcp.BeginReceive(resultBytes, 0, resultBytes.Length, SocketFlags.None, ReceiveCallBack, socketTcp);
```

##### Socket.BeginSend 端开始发送消息
##### Socket.EndSend 端结束发送消息
```cs
// 发送消息
// BeginSend 端开始发送消息方法
// EndSend 端结束发送消息方法 会返回成功发送的字节数
// 发送字符串的临时字节数组
byte[] beginSendBytes = Encoding.UTF8.GetBytes("1231231231223123123");
// BeginSend方法 需要传入 发送消息的字节数组 从接收消息的字节数组第几位开始传 字节数数组长度 Socket标识 发送消息回调函数 端Socket对象
socketTcp.BeginSend(beginSendBytes, 0, beginSendBytes.Length, SocketFlags.None, (result) =>
{
    try
    {
        // EndSend方法 根据需要看是否要得到成功发送的字节数进行分包黏包的逻辑
        socketTcp.EndSend(result);
        print("发送成功");
    }
    catch (SocketException e)
    {
        print("发送错误" + e.SocketErrorCode + e.Message);
    }
}, socketTcp);
```

### Socket中TCP通信中Async结尾的异步方法
#### 关键变量类型
- SocketAsyncEventArgs Socket套接字异步事件参数
- SocketAsyncEventArgs类型会作为Async异步方法的传入值
- SocketAsyncEventArgs.Completed会作为异步回调的事件
- 我们需要通过SocketAsyncEventArgs进行一些关键参数的赋值

#### 服务端相关
##### Socket.AcceptAsync 服务端来异步接受客户端连接
```cs
//AcceptAsync方法 服务端异步接受客户端连接方法

// 创建一个SocketAsyncEventArgs对象，用于异步接受客户端连接
SocketAsyncEventArgs socketAsyncEventArgs1 = new SocketAsyncEventArgs();

// SocketAsyncEventArgs对象的Completed事件，当异步操作完成时会执行以下的Lambda表达式 
// 第一个参数 引发事件的对象 Object类型 socketTcp代表引发事件的Socket对象 这里是参数名和变量名一致方便能理解 后面都是如此
// 第二个参数 事件参数 TEventArgs类型 SocketAsyncEventArgs对象是TEventArgs类型的子类 这里是参数名和变量名一致方便能理解 后面都是如此
socketAsyncEventArgs1.Completed += (socketTcp, socketAsyncEventArgs1) =>
{
    // 检查异步操作是否成功
    if (socketAsyncEventArgs1.SocketError == SocketError.Success)
    {
        // 从SocketAsyncEventArgs中获取连接进来的客户端Socket
        Socket clientSocket = socketAsyncEventArgs1.AcceptSocket;

        // 再次启动异步接受客户端连接，以便持续监听新的客户端连接请求
        (socketTcp as Socket).AcceptAsync(socketAsyncEventArgs1);
    }
    else
    {
        // 打印连接失败的信息，包括错误代码
        print("连入客户端失败" + socketAsyncEventArgs1.SocketError);
    }
};

// 使用socketTcp对象让服务端来异步接受客户端连接，同时传入socketAsyncEventArgs1以处理连接完成后的操作
socketTcp.AcceptAsync(socketAsyncEventArgs1);
// 进入异步操作完成时回调后
// 调用者socketTcp就是异步完成回调中的socketTcp
// AcceptAsync方法中传入的参数socketAsyncEventArgs1就是异步完成回调中的socketAsyncEventArgs1
// 这里是参数名和变量名一致方便能理解 后面都是如此
```

#### 客户端相关
##### Socket.ConnectAsync 客户端异步连接到服务器
```cs
// ConnectAsync方法 用于客户端异步连接到服务器

// 创建一个 SocketAsyncEventArgs 对象，用于异步连接到服务器
SocketAsyncEventArgs socketAsyncEventArgs2 = new SocketAsyncEventArgs();

// 订阅 SocketAsyncEventArgs 对象的 Completed 事件
// 当异步操作完成时，将执行以下的 Lambda 表达式
socketAsyncEventArgs2.Completed += (socketTcp, socketAsyncEventArgs2) =>
{
    // 检查异步操作是否成功
    if (socketAsyncEventArgs2.SocketError == SocketError.Success)
    {
        // 连接成功
    }
    else
    {
        // 连接失败
        print(socketAsyncEventArgs2.SocketError); // 打印连接失败的信息，包括错误代码
    }
};

// 使用 socketTcp 对象来让客户端异步连接到服务器，同时传入 socketAsyncEventArgs2 以处理连接完成后的操作
socketTcp.ConnectAsync(socketAsyncEventArgs2);
```

#### 服务器和客户端通用

##### Socket.SendAsync 异步发送消息
```cs
// SendAsync方法 发送消息

// 创建一个 SocketAsyncEventArgs 对象，用于异步发送消息
SocketAsyncEventArgs socketAsyncEventArgs3 = new SocketAsyncEventArgs();

// 准备要发送的数据，将字符串编码为字节数组
byte[] sendBytes = Encoding.UTF8.GetBytes("123123的就是拉法基萨克两地分居");

// 将数据缓冲区设置到 SocketAsyncEventArgs 对象中 传入字节数组 偏移位置 字节数
socketAsyncEventArgs3.SetBuffer(sendBytes, 0, sendBytes.Length);

// 订阅 SocketAsyncEventArgs 对象的 Completed 事件
// 当异步操作完成时，将执行以下的 Lambda 表达式
socketAsyncEventArgs3.Completed += (socketTcp, socketAsyncEventArgs3) =>
{
    if (socketAsyncEventArgs3.SocketError == SocketError.Success)
    {
        // 发送成功
        print("发送成功");
    }
    else
    {
        // 发送失败
    }
};

// 使用 socketTcp 对象来异步发送消息，同时传入 socketAsyncEventArgs3 以处理发送完成后的操作
socketTcp.SendAsync(socketAsyncEventArgs3);
```

##### Socket.ReceiveAsync 异步接受消息
```cs
// ReceiveAsync方法 接受消息

// 创建一个 SocketAsyncEventArgs 对象，用于异步接受消息
SocketAsyncEventArgs socketAsyncEventArgs4 = new SocketAsyncEventArgs();

// 设置接受数据的字节数组，包括字节数组的大小和偏移位置
socketAsyncEventArgs4.SetBuffer(new byte[1024 * 1024], 0, 1024 * 1024);

// 订阅 SocketAsyncEventArgs 对象的 Completed 事件
// 当异步操作完成时，将执行以下的 Lambda 表达式
socketAsyncEventArgs4.Completed += (socketTcp, socketAsyncEventArgs4) =>
{
    if (socketAsyncEventArgs4.SocketError == SocketError.Success)
    {
        // 从容器中提取已接受的字节数据
        // Buffer 是数据缓冲区 即字节数组
        // BytesTransferred 表示已接受的字节数
        Encoding.UTF8.GetString(socketAsyncEventArgs4.Buffer, 0, socketAsyncEventArgs4.BytesTransferred);

        // SetBuffer重载 重置接受缓冲区，传入从第几个位置开始收 收多少 以便接受下一条消息
        socketAsyncEventArgs4.SetBuffer(0, socketAsyncEventArgs4.Buffer.Length);
        (socketTcp as Socket).ReceiveAsync(socketAsyncEventArgs4);
    }
    else
    {
        // 接受失败
    }
};

// 使用 socketTcp 对象来异步接受消息，同时传入 socketAsyncEventArgs4 以处理接受完成后的操作
socketTcp.ReceiveAsync(socketAsyncEventArgs4);
```

### 总结
在C#中网络通信，异步方法主要提供了两种方案：
1. Begin开头的API：内部开多线程，通过回调形式返回结果，需要和End相关方法 配合使用
2. Async结尾的API：内部开多线程，通过回调形式返回结果，依赖SocketAsyncEventArgs对象配合使用，可以让我们更加方便的进行操作