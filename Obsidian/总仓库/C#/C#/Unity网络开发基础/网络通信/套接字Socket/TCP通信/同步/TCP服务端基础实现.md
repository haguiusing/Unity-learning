![[Program.cs]] ^3a4f9b

### 回顾服务端需要做的事情
- 创建套接字Socket
- 用Bind方法将套接字与本地地址绑定
- 用Listen方法监听
- 用Accept方法等待客户端连接
- 建立连接，Accept返回新套接字
- 用Send和Receive相关方法收发数据
- 用Shutdown方法释放连接
- 关闭套接字

### 实现服务端基本逻辑
#### 创建套接字Socket对象（TCP）
```cs
//1.创建套接字Socket（TCP）
Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
#### 用Bind方法将套接字与本地地址绑定
```cs
//2.用Bind方法将套接字与本地地址绑定
try
{
    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);//把本机作为服务端程序 IP地址传入本机
    socketTcp.Bind(iPEndPoint);//绑定
}
catch (Exception e)
{
    //如果IP地址不合法或者端口号被占用可能报错
    Console.WriteLine("绑定报错" + e.Message);
    return;
}
```
#### 用Listen方法监听
```cs
//3.用Listen方法监听
socketTcp.Listen(1024);//最大接收1024个客户端
Console.WriteLine("服务端绑定监听结束，等待客户端连入");
```

#### 用Accept方法等待客户端连接
#### 建立连接，Accept返回新套接字
```cs
//5.建立连接，Accept返回新套接字
Socket socketClient = socketTcp.Accept();
//Accept是阻塞式的方法 会把主线程卡主 一定要等到客户端接入后才会继续执行后面的代码
//客户端接入后 返回新的Socket对象 这个新的Socket可以理解为客户段和服务端的通信通道
Console.WriteLine("有客户端连入了");
```
#### 用Send和Receive相关方法收发数据
```cs
//6.用Send和Receive相关方法收发数据
//发送字符串转成的字节数组给客户端
socketClient.Send(Encoding.UTF8.GetBytes("欢迎连入服务端"));
//声明接受客户端信息的字节数组 声明1024容量代表能接受1kb的信息
byte[] result = new byte[1024];
//接受客户端信息 返回值为接受到的字节数
int receiveNum = socketClient.Receive(result);
//打印 远程发送信息的客户端的IP和端口 以及 发送过来的字符串
Console.WriteLine("接受到了{0}发来的消息：{1}",
    socketClient.RemoteEndPoint.ToString(),
    Encoding.UTF8.GetString(result, 0, receiveNum));
```
#### 用Shutdown方法释放连接
```cs
//7.用Shutdown方法释放连接
//注意断开的是客户段和服务端的通信通道
socketClient.Shutdown(SocketShutdown.Both);
```
`SocketShutdown` 枚举的成员及其含义：

| 枚举值           | 描述                    |
| ------------- | --------------------- |
| `Receive` (0) | 关闭套接字的接收功能，但允许继续发送数据。 |
| `Send` (1)    | 关闭套接字的发送功能，但允许继续接收数据。 |
| `Both` (2)    | 同时关闭套接字的发送和接收功能。      |

#### 关闭套接字
```cs
//8.关闭套接字
//注意关闭的是客户段和服务端的通信通道
socketClient.Close();
```


### 总结
1. 服务端开启的流程每次都是相同的。
2. 服务端的Accept、Send、Receive是会阻塞主线程的，要等到执行完毕才会继续执行后面的内容。

抛出问题：
- 如何让服务端可以服务n个客户端？
- 我们会在之后的综合练习题进行讲解。

