### 实现UDP客户端通信收发字符串
![[Lesson14 1.cs]]
```cs
//1.创建套接字 寻址类型还是Ipv4 Soket类型使用数据包 协议选择Udp
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//2.绑定本机地址 注意模拟测试时客户端本机和服务端远程机的端口号不能一样
IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
socket.Bind(ipPoint);

//3.发送到指定目标 注意模拟测试时客户端本机和服务端远程机的端口号不能一样
IPEndPoint remoteIpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
//指定要发送的字节数 和 远程计算机的 IP和端口
socket.SendTo(Encoding.UTF8.GetBytes("韬老狮来了"), remoteIpPoint);

//4.接受消息
//装接收消息的字节数组
byte[] bytes = new byte[512];
//装接收消息的IP地址和端口的对象 在ReceiveFrom方法会使用ref赋值 主要是用来记录 谁发的信息给你 传入函数后 在内部 它会帮助我们进行赋值
EndPoint remoteIpPoint2 = new IPEndPoint(IPAddress.Any, 0);
//接收消息 得到消息长度
int length = socket.ReceiveFrom(bytes, ref remoteIpPoint2);
print("IP:" + (remoteIpPoint2 as IPEndPoint).Address.ToString() +
    "port:" + (remoteIpPoint2 as IPEndPoint).Port +
    "发来了" +
    Encoding.UTF8.GetString(bytes, 0, length));

//5.释放关闭
socket.Shutdown(SocketShutdown.Both);
socket.Close();
```

### 实现UDP服务端通信收发字符串
![[Program 5.cs]]
```cs
//1.创建套接字 寻址类型还是Ipv4 Soket类型使用数据包 协议选择Udp
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//2.绑定本机地址 注意模拟测试时客户端本机和服务端远程机的端口号不能一样
IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
socket.Bind(ipPoint);
Console.WriteLine("服务器开启");

//3.接受消息
//装接收消息的字节数组
byte[] bytes = new byte[512];
//装接收消息的IP地址和端口的对象 在ReceiveFrom方法会使用ref赋值 主要是用来记录 谁发的信息给你 传入函数后 在内部 它会帮助我们进行赋值
EndPoint remoteIpPoint2 = new IPEndPoint(IPAddress.Any, 0);
int length = socket.ReceiveFrom(bytes, ref remoteIpPoint2);
Console.WriteLine("IP:" + (remoteIpPoint2 as IPEndPoint).Address.ToString() +
    "port:" + (remoteIpPoint2 as IPEndPoint).Port +
    "发来了" +
    Encoding.UTF8.GetString(bytes, 0, length));

//4.发送到指定目标
//由于服务端先收了消息 所以服务端已经知道谁发了消息给服务端 是使用remoteIpPoint2记录的 服务端直接发给它就行了
socket.SendTo(Encoding.UTF8.GetBytes("欢迎发送消息给服务器"), remoteIpPoint2);

//5.释放关闭
socket.Shutdown(SocketShutdown.Both);
socket.Close();
```

### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/34.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-UDP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E6%9C%8D%E5%8A%A1%E7%AB%AF%E5%92%8C%E5%AE%A2%E6%88%B7%E7%AB%AF/1.png)