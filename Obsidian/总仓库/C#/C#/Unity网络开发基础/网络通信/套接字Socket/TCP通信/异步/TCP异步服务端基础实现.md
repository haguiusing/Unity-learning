### 实现服务端ClientSocket类
![[ClientSocket 5.cs]]
#### 创建ClientSocket类，定义和同步ClientSocket类类似的成员变量
```cs
private static int CLIENT_BEGIN_ID = 1;  // 静态变量，用于为客户端分配唯一的客户端ID
public int clientID;  // 客户端的唯一ID
public Socket clientSocket;  // 与客户端通信的套接字对象

//用于处理分包时 缓存的 字节数组 和 字节数组长度
private byte[] cacheBytes = new byte[1024 * 1024];
private int cacheNum = 0;

/// <summary>
/// 是否是连接状态
/// </summary>
public bool isClientConnected => this.clientSocket.Connected;  // 判断套接字是否处于连接状态
```

#### 在构造函数中开启接收来自客户端的消息。添加接收客户端消息回调函数，向客户端发消息和向客户端发消息回调函数，暂时模拟客户端字符串的收发。
```cs
public ClientSocket(Socket clientSocket)
{
    this.clientID = CLIENT_BEGIN_ID;  // 初始化客户端ID
    this.clientSocket = clientSocket;  // 初始化套接字
    ++CLIENT_BEGIN_ID;  // 为下一个客户端分配不同的ID

    //开始收消息
    this.clientSocket.BeginReceive(cacheBytes, cacheNum, cacheBytes.Length, SocketFlags.None, ReceiveCallBack, null);
}

//接收客户端消息回调函数
private void ReceiveCallBack(IAsyncResult asyncResult)
{
    try
    {
        cacheNum = this.clientSocket.EndReceive(asyncResult);
        //通过字符串去解析
        Console.WriteLine(Encoding.UTF8.GetString(cacheBytes, 0, cacheNum));
        //如果是连接状态再继续收消息
        //因为目前我们是以字符串的形式解析的 所以 解析完 就直接 从0又开始收
        cacheNum = 0;
        if (isClientConnected)
            this.clientSocket.BeginReceive(cacheBytes, cacheNum, cacheBytes.Length, SocketFlags.None, ReceiveCallBack, this.clientSocket);
        else
        {
            Console.WriteLine("没有连接，不用再收消息了");
        }
    }
    catch (SocketException e)
    {
        Console.WriteLine("接受消息错误" + e.SocketErrorCode + e.Message);
    }
}

//向客户端发消息
public void Send(string str)
{
    if (isClientConnected)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        this.clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, SendCallBack, null);
    }
    else
    {

    }
}

//向客户端发消息回调函数
private void SendCallBack(IAsyncResult asyncResult)
{
    try
    {
        this.clientSocket.EndSend(asyncResult);
    }
    catch (SocketException e)
    {
        Console.WriteLine("发送失败" + e.SocketErrorCode + e.Message);
    }
}
```

### 实现客户端ServerSocket类
![[ServerSocket 3.cs]]
#### 创建ServerSocket类，定义和同步ServerSocket类类似的成员变量
```cs
// 服务器端Socket
public Socket serverSocket;
// 保存客户端连接的所有Socket的字典
public Dictionary<int, ClientSocket> clientSocketDictionary = new Dictionary<int, ClientSocket>();
```

#### 定义开启服务端函数，服务端接收客户端连接回调函数，广播函数。
```cs
// 开启服务器端
public void Start(string ipString, int port, int clientSocketMaxNum)
{
    // 创建服务器套接字，指定地址族为IPv4、套接字类型为流套接字、协议类型为TCP
    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    // 创建IP终结点，指定IP地址和端口号
    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipString), port);

    try
    {
        // 将套接字绑定到指定的IP终结点
        serverSocket.Bind(serverEndPoint);

        // 启动服务器套接字，同时指定同时等待连接的最大客户端数
        serverSocket.Listen(clientSocketMaxNum);

        //通过异步接受客户端连入
        serverSocket.BeginAccept(AcceptCallBack, null);
    }
    catch (Exception e)
    {
        Console.WriteLine("启动服务器失败" + e.Message);
    }
}

//服务端接收客户端连接回调函数
private void AcceptCallBack(IAsyncResult asyncResult)
{
    try
    {
        //获取连入的客户端
        Socket clientSocket = serverSocket.EndAccept(asyncResult);
        ClientSocket client = new ClientSocket(clientSocket);

        //记录客户端对象
        clientSocketDictionary.Add(client.clientID, client);

        //继续去让别的客户端可以连入
        serverSocket.BeginAccept(AcceptCallBack, null);
    }
    catch (Exception e)
    {
        Console.WriteLine("客户端连入失败" + e.Message);
    }
}

// 向所有客户端广播消息
public void Broadcast(string str)
{
    foreach (ClientSocket client in clientSocketDictionary.Values)
    {
        client.Send(str);
    }
}
```

### 服务端主入口
#### 新建服务端类并开启，死循环接收打印信息
```cs
ServerSocket serverSocket = new ServerSocket();
serverSocket.Start("127.0.0.1", 8080, 1024);
Console.WriteLine("开启服务器成功");

while (true)
{
    string input = Console.ReadLine();
    if (input.Substring(0, 2) == "B:")
    {
        serverSocket.Broadcast(input.Substring(2));
    }
}
```


