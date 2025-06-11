![[Lesson5 2.cs]]

### Socket套接字的作用
- Socket套接字是C#提供给我们用于网络通信的一个类（在其它语言当中也有对应的Socket类）。
- 类名：Socket
- 命名空间：System.Net.Sockets。
- Socket套接字是支持TCP/IP网络通信的基本操作单位。一个套接字对象包含以下关键信息：
    1. 本机的IP地址和端口
    2. 对方主机的IP地址和端口
    3. 双方通信的协议信息
- 一个Sccket对象表示一个本地或者远程套接字信息。它可以被视为一个数据通道。这个通道连接与客户端和服务端之间，数据的发送和接受均通过这个通道进行。
- 一般在制作长连接游戏时，我们会使用Socket套接字作为我们的通信方案。我们通过它连接客户端和服务端，通过它来收发消息。你可以把它抽象的想象成一根管子，插在客户端和服务端应用程序上，通过这个管子来传递交换信息。

### Socket的类型、构造函数和实例化
Socket套接字有3种不同的类型：
1. 流套接字：主要用于实现TCP通信，提供了面向连接、可靠的、有序的、数据无差错且无重复的数据传输服务。
2. 数据报套接字：主要用于实现UDP通信，提供了无连接的通信服务，数据包的长度不能大于32KB，不提供正确性检查，不保证顺序，可能出现重发、丢失等情况。
3. 原始套接字（不常用，不深入讲解）：主要用于实现IP数据包通信，用于直接访问协议的较低层，常用于侦听和分析数据包。

通过Socket的构造函数，我们可以申明不同类型的套接字。Socket的构造函数主要有三种重载，我们着重学习 `AddressFamily`、`SocketType`、`ProtocolType` 的重载：
```cs
public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
```

#### 构造函数参数说明
##### 参数一：AddressFamily
- 网络寻址枚举类型，决定寻址方案。
- **常用：**
    1. `InterNetwork`：IPv4寻址。
    2. `InterNetwork6`：IPv6寻址。
- **做了解：**
    1. `UNIX`：UNIX本地到主机地址。
    2. `ImpLink`：ARPANETIMP地址。
    3. `Ipx`：IPX或SPX地址。
    4. `Iso`：ISO协议的地址。
    5. `Osi`：OSI协议的地址。
    6. `NetBios`：NetBios地址。
    7. `Atm`：本机ATM服务地址。

| 枚举值                     | 描述                          |
| ----------------------- | --------------------------- |
| `Unknown` (-1)          | 未知的地址族，通常用于表示无效或未指定的地址族。    |
| `Unspecified` (0)       | 未指定的地址族。                    |
| `Unix` (1)              | Unix 域套接字，用于同一台机器上的进程间通信。   |
| `InterNetwork` (2)      | IPv4 地址族，用于互联网协议版本 4（IPv4）。 |
| `ImpLink` (3)           | ARPANET IMP 地址族。            |
| `Pup` (4)               | PUP 地址族。                    |
| `Chaos` (5)             | CHAOS 地址族。                  |
| `Ipx` (6)               | IPX 地址族，用于 Novell IPX 协议。   |
| `NS` (6)                | Xerox NS 地址族。               |
| `Iso` (7)               | ISO 地址族。                    |
| `Osi` (7)               | OSI 地址族。                    |
| `Ecma` (8)              | ECMA 地址族。                   |
| `DataKit` (9)           | Datakit 地址族。                |
| `Ccitt` (10)            | CCITT 地址族。                  |
| `Sna` (11)              | SNA 地址族。                    |
| `DecNet` (12)           | DECnet 地址族。                 |
| `DataLink` (13)         | 数据链路层协议地址族。                 |
| `Lat` (14)              | LAT 地址族。                    |
| `HyperChannel` (15)     | HyperChannel 地址族。           |
| `AppleTalk` (16)        | AppleTalk 地址族。              |
| `NetBios` (17)          | NetBIOS 地址族。                |
| `VoiceView` (18)        | VoiceView 地址族。              |
| `FireFox` (19)          | FireFox 地址族。                |
| `Banyan` (21)           | Banyan 地址族。                 |
| `Atm` (22)              | ATM 地址族。                    |
| `InterNetworkV6` (23)   | IPv6 地址族，用于互联网协议版本 6（IPv6）。 |
| `Cluster` (24)          | 集群地址族。                      |
| `Ieee12844` (25)        | IEEE 1284.4 地址族。            |
| `Irda` (26)             | IrDA 地址族，用于红外通信。            |
| `NetworkDesigners` (28) | 网络设计者地址族。                   |
| `Max` (29)              | 最大地址族值。                     |

##### 参数二：SocketType
- 套接字枚举类型，决定使用的套接字类型。
- **常用：**
    1. `Dgram`：支持数据报，最大长度固定的无连接、不可靠的消息（主要用于UDP通信）。
    2. `Stream`：支持可靠、双向、基于连接的字节流（主要用于TCP通信）。
- **做了解：**
    1. `Raw`：原始套接字，支持对基础传输协议的访问（主要用于开发底层网络|自定义协议或工具）。
    2. `Rdm`：支持无连接、面向消息、以可靠方式发送的消息（主要用于特定的网络协议）。
    3. `Seqpacket`：提供排序字节流的面向连接且可靠的双向传输（主要用于需要有序、可靠消息传输的场景）。
    4. `Unknown`：未知的套接字类型，通常用于表示无效或未指定的类型。

| 枚举值             | 描述                                     |
| --------------- | -------------------------------------- |
| `Unknown` (-1)  | 未知的套接字类型，通常用于表示无效或未指定的类型。              |
| `Stream` (1)    | 面向连接的、可靠的、基于流的套接字，通常使用 TCP（传输控制协议）。    |
| `Dgram` (2)     | 无连接的、不可靠的、基于数据报的套接字，通常使用 UDP（用户数据报协议）。 |
| `Raw` (3)       | 原始套接字，允许直接访问网络层协议（如 IP）。               |
| `Rdm` (4)       | 可靠的、无连接的、基于消息的套接字，适用于某些特定的网络协议。        |
| `Seqpacket` (5) | 可靠的、面向连接的、基于消息的套接字，通常用于有序的、可靠的通信。      |

##### 参数三：ProtocolType
- 协议类型枚举类型，决定套接字使用的通信协议。
- **常用：**
    1. `TCP`：TCP传输控制协议。
    2. `UDP`：UDP用户数据报协议。
- **做了解：**
    1. `IP`：IP网际协议。
    2. `Icmp`：Icmp网际消息控制协议。
    3. `Igmp`：Igmp网际组管理协议。
    4. `Ggp`：网关到网关协议。
    5. `IPv4`：Internet协议版本4。
    6. `Pup`：PARC通用数据包协议。
    7. `Idp`：Internet数据报协议。
    8. `Raw`：原始IP数据包协议。
    9. `Ipx`：Internet数据包交换协议。
    10. `Spx`：顺序包交换协议。
    11. `IcmpV6`：用于IPv6的Internet控制消息协议。

| 枚举值                                      | 描述                                 |
| ---------------------------------------- | ---------------------------------- |
| `Unknown` (-1)                           | 未知的协议类型，通常用于表示无效或未指定的协议。           |
| `IP` (0)                                 | 互联网协议（IP）。                         |
| `IPv6HopByHopOptions` (0)                | IPv6 跳对跳选项。                        |
| `Unspecified` (0)                        | 未指定的协议。                            |
| `Icmp` (1)                               | 互联网控制消息协议（ICMP）。                   |
| `Igmp` (2)                               | 互联网组管理协议（IGMP）。                    |
| `Ggp` (3)                                | 网关到网关协议（GGP）。                      |
| `IPv4` (4)                               | 互联网协议版本 4（IPv4）。                   |
| `Tcp` (6)                                | 传输控制协议（TCP）。                       |
| `Pup` (12)                               | PARC通用协议（PUP）。                     |
| `Udp` (17)                               | 用户数据报协议（UDP）。                      |
| `Idp` (22)                               | 网络层协议（IDP）。                        |
| `IPv6` (41)                              | 互联网协议版本 6（IPv6）。                   |
| `IPv6RoutingHeader` (43)                 | IPv6 路由头。                          |
| `IPv6FragmentHeader` (44)                | IPv6 分片头。                          |
| `IPSecEncapsulatingSecurityPayload` (50) | IP 安全封装安全载荷（ESP）。                  |
| `IPSecAuthenticationHeader` (51)         | IP 安全认证头（AH）。                      |
| `IcmpV6` (58)                            | ICMPv6。                            |
| `IPv6NoNextHeader` (59)                  | IPv6 无下一个头。                        |
| `IPv6DestinationOptions` (60)            | IPv6 目标选项头。                        |
| `ND` (77)                                | 网络诊断协议。                            |
| `Raw` (255)                              | 原始协议。                              |
| `Ipx` (1000)                             | Internetwork Packet Exchange（IPX）。 |
| `Spx` (1256)                             | Sequenced Packet Exchange（SPX）。    |
| `SpxII` (1257)                           | SPX II。                            |

##### SocketType和ProtocolType的常用搭配：
- `SocketType.Dgram` + `ProtocolType.Udp` = UDP协议通信（常用，主要学习）。
- `SocketType.Stream` + `ProtocolType.Tcp` = TCP协议通信（常用，主要学习）。
- `SocketType.Raw` + `ProtocolType.Icmp` = Internet控制报文协议（了解）。
- `SocketType.Raw` + `ProtocolType.Raw` = 简单的IP包通信（了解）。

#### 实例化Socket对象
我们必须掌握的是TCP和UDP的Socket
```cs
//TCP流套接字
Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//UDP数据报套接字
Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
```

### Socket的常用属性
#### Socket.Connected 套接字的连接状态
```cs
//1.套接字的连接状态
if(socketTcp.Connected)
{

}
```
#### Socket.SocketType 套接字的类型
```cs
//2.获取套接字的类型
print(socketTcp.SocketType);
```
#### Socket.ProtocolType 套接字的协议类型
```cs
//3.获取套接字的协议类型
print(socketTcp.ProtocolType);
```
#### Socket.AddressFamily 套接字的寻址方案
```cs
//4.获取套接字的寻址方案
print(Socket.AddressFamily);
```
#### Socket.Available 套接字可读取字节数
```cs
//5.从网络中获取准备读取的数据数据量 包含多少字节
print(socketTcp.Available);
```
#### Socket.LocalEndPoint 本机EndPoint对象
```cs
//6.获取本机EndPoint对象
//(注意 ：IPEndPoint继承EndPoint) IPEndPoint是IP地址和端口号的组合
//socketTcp.LocalEndPoint as IPEndPoint
```
#### Socket.RemoteEndPoint 远程EndPoint对象
```cs
//7.获取远程EndPoint对象 IPEndPoint是IP地址和端口号的组合
//socketTcp.RemoteEndPoint as IPEndPoint
```
### Socket的常用方法
#### 服务端
##### Socket.Bind 绑定IP和端口
```cs
//  1-1:绑定IP和端口 Bind方法 传入IPEndPoint对象 
IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
socketTcp.Bind(iPEndPoint);
```
##### Socket.Listen 设置客户端连接的最大数
```cs
//  1-2:设置客户端连接的最大数量 Listen方法 传入整形数字
socketTcp.Listen(10);
```
##### Socket.Accept 等待客户端连入
```cs
//  1-3:等待客户端连入 Accept方法 会返回一个Socket对象 之后和客户端连接时就使用这个对象
socketTcp.Accept();
```
#### 客户端
##### Socket.Connect 连接远程服务端
```cs
//  1-1:连接远程服务端 Connect方法 传入IPEndPoint对象 连接远程IP和端口
socketTcp.Connect(IPAddress.Parse("118.12.123.11"), 8080);
```
#### 客户端服务端通用
##### 同步异步收发数据 之后讲解
```cs
//  1-1:同步发送和接收数据 之后讲解 
//  1-2:异步发送和接收数据 之后讲解
```
##### Socket.Shutdown 释放连接并关闭Socket
```cs
//  1-3:释放连接并关闭Socket，先与Close调用  可以防止再发送和接收 选择Both是同时防止发送和接收
socketTcp.Shutdown(SocketShutdown.Both);
```
##### Socket.Close 关闭连接释放所有Socket关联资源
```cs
//  1-4:关闭连接，释放所有Socket关联资源
socketTcp.Close();
```

### 总结
这节课我们只是对Socket有一个大体的认识。  
主要要建立的概念就是TCP和UDP两种长连接通信方案都是基于Socket套接字的。  
我们之后只需要使用其中的各种方法，就可以进行网络连接和网络通信了。  
这节课必须掌握的内容就是如何声明TCP和UDP的Socket套接字。