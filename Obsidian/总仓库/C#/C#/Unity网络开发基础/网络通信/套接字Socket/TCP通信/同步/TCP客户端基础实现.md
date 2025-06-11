![[Lesson6 2.cs]] ^e0e413

### 回顾客户端需要做的事情
- 创建套接字Socket
- 用Connect方法与服务端相连
- 用Send和Receive相关方法收发数据
- 用Shutdown方法释放连接
- 关闭套接字

### 实现客户端基本逻辑
#### 创建套接字Socket对象（TCP）
```cs
//1.创建套接字Socket Tcp
Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```
#### 用Connect方法与服务端相连
```cs
//2.用Connect方法与服务端相连
//确定服务端的IP和端口 正常来说填的应该是远端服务器的ip地址以及端口号
//由于只有一台电脑用于测试 本机也当做服务器 所以传入当前电脑的ip地址
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
try
{
    //连接
    socketTcp.Connect(iPEndPoint);
}
catch (SocketException e)
{
    //如果连接没有开启或者服务器异常 会报错 不同的返回码代表不同报错
    if (e.ErrorCode == 10061)
        print("服务器拒绝连接");
    else
        print("连接服务器失败" + e.ErrorCode);
    return;
}
```
#### 用Send和Receive相关方法收发数据
```cs
//3.用Send和Receive相关方法收发数据

//接收数据 
//声明接收数据字节数组
byte[] receiveBytes = new byte[1024];
//Receive方法接受数据 返回接收多少字节
int receiveNum = socketTcp.Receive(receiveBytes);

print("收到服务端发来的消息：" + Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));

//发送数据
socketTcp.Send(Encoding.UTF8.GetBytes("你好，我是韬老狮的客户端"));
```
#### 用Shutdown方法释放连接
```cs
//4.用Shutdown方法释放连接
socketTcp.Shutdown(SocketShutdown.Both);
```
#### 关闭套接字
```cs
//5.关闭套接字
socketTcp.Close();
```

### 实现客户端和服务端的通信
- 开启上节课的服务端控制台，将当前脚本挂载到场景中对象上运行，进行客户端和服务端的通信。  
    ![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/20.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%AE%A2%E6%88%B7%E7%AB%AF/1.png)

### 总结
1. 客户端连接的流程每次都是相同的。
2. 客户端的 Connect、Send、Receive 是会阻塞主线程的，要等到执行完毕才会继续执行后面的内容。

抛出问题：
- 如何让客户端的 Socket 不影响主线程，并且可以随时收发消息？
- 我们会在之后的综合练习题讲解。