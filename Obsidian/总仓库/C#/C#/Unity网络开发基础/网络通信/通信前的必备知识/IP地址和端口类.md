![[Lesson1 3.cs]]

# IPAddress类和IPEndPoint类
### IP类和端口类用来干什么？
通过之前的理论知识学习，我们知道想要进行网络通信，进行网络连接，首先我们需要找到对应设备，IP和端口号是定位网络中设备必不可少的关键元素。在C#中提供了对应的IP和端口相关的类来声明对应信息，对于之后的网络通信是必不可少的内容。

### IPAddress类
- 命名空间：System.Net;
- 类名：IPAddress

#### 初始化IP信息IPAddress对象的方式
##### 用byte数组进行初始化
```cs
//1.用byte数组进行初始化
byte[] ipAddress = new byte[] { 118, 102, 111, 11 };
IPAddress iPAddress1 = new IPAddress(ipAddress);
```
##### 用long长整型进行初始化
```cs
//2.用long长整型进行初始化
//4字节对应的长整型 传入的是16进制 一般不建议大家使用
//0x 是16进制固定的前缀
//118 转成16进制为 0x  76
//102 转成16进制为 0x  66
//111 转成16进制为 0x  6F
//11  转成16进制为 0x  0B
IPAddress iPAddress2 = new IPAddress(0x76666F0B);
```
##### 使用字符串转换
```cs
//3.推荐使用的方式 使用字符串转换
IPAddress iPAddress3 = IPAddress.Parse("118.102.111.11");
```

#### 特殊IP地址
127.0.0.1代表本机地址

#### 静态成员
```cs
//获取可用的IPv6地址
//IPAddress.IPv6Any
```

### IPEndPoint类
- 命名空间：System.Net;
- 类名：IPEndPoint
- IPEndPoint类将网络端点表示为IP地址和端口号，表现为IP地址和端口号的组合
- 端口号没有自己的类
- 用IP地址和端口号表示计算机的一个程序

#### 初始化IPEndPoint方式
##### 传入 long长整型IP地址 和 端口号 进行初始化
```cs
//传入 long长整型IP地址 和 端口号 进行初始化
IPEndPoint iPEndPoint1 = new IPEndPoint(0x79666F0B, 8080);
```
##### 传入 IP地址对象 和 端口号 进行初始化
```cs
// 推荐使用
IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.Parse("118.102.111.11"), 8080);
```

### 总结
#### IPAddress对象推荐直接传入IP地址字符串进行初始化
```cs
//IP地址对象
IPAddress iPAddress = IPAddress.Parse("IPv4地址");
```
#### IPEndPoint对象推荐传入IPAddress和端口号进行初始化
```cs
//目标通信程序对象
IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 8080);
```

