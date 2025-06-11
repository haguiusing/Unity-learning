![[Lesson16 1.cs]]

### Socket中UDP通信中的异步方法
- 通过之前的学习，UDP用到的通信相关方法主要就是 `SendTo` 和 `ReceiveFrom`
- 所以在讲解UDP异步通信时也主要是围绕着收发消息相关方法来讲解
- 主要也分Begin开头和Async结尾的方法 Begin开头的回调函数中同样要配合End开头的方法
```cs
// 创建一个新的Socket对象，采用UDP协议，IPv4地址族
Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
// 将字符串转换为字节数组
byte[] bytes = Encoding.UTF8.GetBytes("123123lkdsajlfjas");
// 创建服务端端口号和IP
// 创建一个IP地址为127.0.0.1，端口号为8080的IPEndPoint实例对象
EndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
```

### UDP通信中Begin相关异步方法
#### Socket.BeginSendTo 向指定IP和端口异步发送数据
#### Socket.EndSendTo 结束异步发送操作
```cs
// BeginSendTo方法 开始向指定IP和端口发送数据，将结果异步传回SendToOver回调函数进行处理
// 参数依次为：要发送的数据字节数组、从字节数组的哪个位置开始发送、发送数据的长度、SocketFlags标识、目标IP和端口号、回调函数、回调函数的参数
socketUdp.BeginSendTo(bytes, 0, bytes.Length, SocketFlags.None, ipPoint, SendToOver, socketUdp);

// 发送数据完成时的回调函数
private void SendToOver(IAsyncResult asyncResult)
{
    try
    {
        // 从异步结果中获取Socket对象实例
        Socket socketUdp = asyncResult.AsyncState as Socket;

        // 结束异步发送操作
        socketUdp.EndSendTo(asyncResult);

        // 打印发送成功提示信息
        print("发送成功");
    }
    catch (SocketException s)
    {
        // 打印发送失败提示信息
        print("发送失败" + s.SocketErrorCode + s.Message);
    }
}
```

#### Socket.BeginReceiveFrom 异步从UDP客户端接收数据
#### Socket.EndReceiveFrom 结束异步接收操作，并返回接收到的字节数
```cs
// BeginReceiveFrom方法 开始异步从UDP客户端接收数据，将接收到的数据放入缓存区cacheBytes中
// 接收数据的来源ip和端口号会被保存在ipPoint变量中 这里没有新建 复用了之前服务端的
// 当有数据到达时就会自动调用ReceiveFromOver回调函数进行处理
// 参数依次为：缓存区、缓存区的起始位置、最大接收数据长度、SocketFlags标识、接收数据的来源IPEndPoint、回调函数、回调函数的参数
socketUdp.BeginReceiveFrom(cacheBytes, 0, cacheBytes.Length, SocketFlags.None, ref ipPoint, ReceiveFromOver, (socketUdp, ipPoint));

// 接收数据完成时的回调函数
private void ReceiveFromOver(IAsyncResult asyncResult)
{
    try
    {
        // 从异步结果中获取Socket对象实例和远程IPEndPoint实例
        // 因为BeginReceiveFrom回调函数的参数填了(socketUdp, ipPoint) 所以可直接用元组
        (Socket socketUdp, EndPoint ipPoint) socketUdpAndIpPoint = ((Socket, EndPoint))asyncResult.AsyncState;

        // 结束异步接收操作，并返回接收到的字节数
        int num = socketUdpAndIpPoint.socketUdp.EndReceiveFrom(asyncResult, ref socketUdpAndIpPoint.ipPoint);

        // 处理接收到的数据

        // 再次开始异步接收数据，以便下一次有数据到达时能够自动调用该回调函数处理
        socketUdpAndIpPoint.socketUdp.BeginReceiveFrom(cacheBytes, 0, cacheBytes.Length, SocketFlags.None, ref socketUdpAndIpPoint.ipPoint, ReceiveFromOver, socketUdpAndIpPoint);
    }
    catch (SocketException s)
    {
        // 打印接收失败提示信息
        print("接受消息出问题" + s.SocketErrorCode + s.Message);
    }
}
```

### UDP通信中Async相关异步方法
#### Socket.SendToAsync 开始向指定IP和端口发送数据
```cs
// SendToAsync方法 开始向指定IP和端口发送数据 发送完成后在SendToAsync回调函数处理
SocketAsyncEventArgs socketAsyncEventArgs1 = new SocketAsyncEventArgs();
// 设置要发送的数据
socketAsyncEventArgs1.SetBuffer(bytes, 0, bytes.Length);
// 设置服务端IP地址
socketAsyncEventArgs1.RemoteEndPoint = ipPoint;
// 附加完成事件处理程序 这里添加自定义完成回调 只是函数名一样
socketAsyncEventArgs1.Completed += SendToAsync;
// 启动发送操作
socketUdp.SendToAsync(socketAsyncEventArgs1);

//发送完成回调
private void SendToAsync(object socket, SocketAsyncEventArgs socketAsyncEventArgs1)
{
    // 检查发送操作是否成功
    if (socketAsyncEventArgs1.SocketError == SocketError.Success)
    {
        // 发送操作成功
        print("发送成功");
    }
    else
    {
        // 发送操作失败
        print("发送失败");
    }
}
```
#### Socket.ReceiveFromAsync 开始向指定IP和端口发送数据
```cs
// ReceiveFromAsync 开始异步从UDP客户端接收数据 接收完成后在ReceiveFromAsync回调函数进行处理
SocketAsyncEventArgs socketAsyncEventArgs2 = new SocketAsyncEventArgs();
// 设置接收数据的缓冲区 传入字节数组作为容器
socketAsyncEventArgs2.SetBuffer(cacheBytes, 0, cacheBytes.Length);
// 声明用于接收服务端的IP地址
socketAsyncEventArgs2.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
// 附加完成事件处理程序 这里添加自定义完成回调 只是函数名一样
socketAsyncEventArgs2.Completed += ReceiveFromAsync;
// 启动接收操作
socketUdp.ReceiveFromAsync(socketAsyncEventArgs2);


//接收完成回调
private void ReceiveFromAsync(object socket, SocketAsyncEventArgs socketAsyncEventArgs2)
{
    // 检查接收操作是否成功
    if (socketAsyncEventArgs2.SocketError == SocketError.Success)
    {
        // 接收操作成功
        print("接收成功");

        // 您可以通过 BytesTransferred 访问接收的字节数
        // int receivedBytes = socketAsyncEventArgs2.BytesTransferred;

        // 您可以从以下缓冲区中访问接收的数据：
        // byte[] receivedData = socketAsyncEventArgs2.Buffer;

        //也可以直接通过cacheBytes

        Socket socketUdp = socket as Socket;

        // 设置接收数据的缓冲区，指定从哪里开始接收和要接收多少数据 因为外面已经传了cacheBytes 可以不用再传一次
        socketAsyncEventArgs2.SetBuffer(0, cacheBytes.Length);

        // 启动另一个接收操作
        socketUdp.ReceiveFromAsync(socketAsyncEventArgs2);
    }
    else
    {
        // 接收操作失败
        print("接收失败");
    }
}
```

### 总结
由于学习了TCP相关的知识点，所以UDP的相关内容的学习就变得简单了。他们异步通信的唯一的区别就是API不同，使用规则都是一致的。