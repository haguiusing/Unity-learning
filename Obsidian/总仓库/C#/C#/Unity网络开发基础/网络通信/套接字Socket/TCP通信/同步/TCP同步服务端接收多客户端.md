![[Program 1.cs]]

#### 使用Scoket服务端编程基础知识和多线程知识实现多客户端服务，允许多个客户端连入服务端，可以分别和多个客户端进行通信
##### 创建套接字，绑定到指定IP地址和端口，开始监听连接请求
```cs
// 1. 建立Socket，绑定，监听
static Socket serverSocket; // 用于监听客户端连接的服务器套接字

// 创建一个IPv4套接字
serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080); // 指定服务器监听的IP地址和端口
serverSocket.Bind(serverEndPoint); // 绑定套接字到指定的IP地址和端口
serverSocket.Listen(1024); // 开始监听，允许最多1024个等待连接的客户端
```
##### 使用单独的线程等待客户端连接
```cs
static List<Socket> connectedClientSockets = new List<Socket>(); // 用于存储客户端套接字的列表
static bool isServerClose = false; // 控制服务器关闭的标志

// 2. 等待客户端连接
Thread acceptThread = new Thread(AcceptClientConnect); // 创建用于接受客户端连接的线程
acceptThread.Start();

static void AcceptClientConnect()
{
    while (!isServerClose)
    {
        Socket clientSocket = serverSocket.Accept(); // 接受客户端连接
        connectedClientSockets.Add(clientSocket); // 将客户端套接字添加到列表
        clientSocket.Send(Encoding.UTF8.GetBytes("欢迎你连入服务端")); // 向客户端发送欢迎消息
    }
}
```
##### 使用另一个线程接收和处理客户端发送的消息
```cs
// 3. 收发消息
Thread receiveThread = new Thread(ReceiveClientMessage); // 创建用于接收消息的线程
receiveThread.Start();

static void ReceiveClientMessage()
{
    Socket clientSocket;
    byte[] result = new byte[1024 * 1024]; // 存储接收数据的缓冲区
    int receiveNum;
    int i;
    while (!isServerClose)
    {
        for (i = 0; i < connectedClientSockets.Count; i++)
        {
            clientSocket = connectedClientSockets[i]; // 获取当前客户端套接字

            if (clientSocket.Available > 0) // 检查套接字是否有可接收的数据
            {
                receiveNum = clientSocket.Receive(result); // 接收数据并返回字节数
                ThreadPool.QueueUserWorkItem(HandleMessage, (clientSocket, Encoding.UTF8.GetString(result, 0, receiveNum))); // 使用线程池处理接收到的消息 
                //ThreadPool.QueueUserWorkItem是传入一个方法和他的参数
                // 这里是传入客户端的Socket对象和反序列化后的字符串
            }
        }
    }
}

static void HandleMessage(object obj)
{
    // 使用元组
    (Socket clientSocket, string message) messageInfo = ((Socket clientSocket, string message))obj;
    Console.WriteLine("收到客户端{0}发来的信息：{1}", messageInfo.clientSocket.RemoteEndPoint, messageInfo.message); // 打印接收到的消息和客户端的远程端点
}
```
##### 在主线程中通过控制台输入来控制服务器的关闭
```cs
// 4. 关闭相关
while (true)
{
    string input = Console.ReadLine(); // 从控制台获取输入

    // 关闭服务器并断开所有连接
    if (input == "Quit")
    {
        isServerClose = true;
        for (int i = 0; i < connectedClientSockets.Count; i++)
        {
            connectedClientSockets[i].Shutdown(SocketShutdown.Both); // 关闭套接字的发送和接收
            connectedClientSockets[i].Close(); // 关闭套接字
        }
        connectedClientSockets.Clear(); // 清空客户端套接字列表
        break; // 退出循环，关闭服务器
    }

    // 广播消息给所有客户端
    else if (input.Substring(0, 2) == "B:")
    {
        for (int i = 0; i < connectedClientSockets.Count; i++)
        {
            connectedClientSockets[i].Send(Encoding.UTF8.GetBytes(input.Substring(2))); // 发送消息给客户端 截取掉B:
        }
    }
}
```

#### 使用面向对象思想对服务端客户端Socket进行封装
##### 创建客户端套接字类，定义成员变量和构造函数
![[ClientSocket 1.cs]]
```cs
class ClientSocket
{
    private static int CLIENT_BEGIN_ID = 1;  // 用于为客户端分配唯一的客户端ID
    public int clientID;  // 客户端的唯一ID
    public Socket clientSocket;  // 与客户端通信的套接字对象

    /// <summary>
    /// 是否是连接状态
    /// </summary>
    public bool isClientConnected => this.clientSocket.Connected;  // 判断套接字是否处于连接状态

    public ClientSocket(Socket clientSocket)
    {
        this.clientID = CLIENT_BEGIN_ID;  // 初始化客户端ID
        this.clientSocket = clientSocket;  // 初始化套接字
        ++CLIENT_BEGIN_ID;  // 为下一个客户端分配不同的ID
    }
}
```
##### 封装客户端套接字的成员方法
```cs
// 关闭套接字连接
public void Close()
{
    if (clientSocket != null)
    {
        clientSocket.Shutdown(SocketShutdown.Both);  // 关闭套接字的读写
        clientSocket.Close();  // 关闭套接字连接
        clientSocket = null;
    }
}

// 发送消息给客户端
public void Send(string info)
{
    if (clientSocket != null)
    {
        try
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(info));  // 将消息编码为UTF-8字节数组并发送给客户端
        }
        catch (Exception e)
        {
            Console.WriteLine("发消息出错" + e.Message);
            Close();  // 如果发送出现异常，关闭套接字连接
        }
    }
}

// 接收来自客户端的消息
public void Receive()
{
    if (clientSocket == null)
        return;
    try
    {
        if (clientSocket.Available > 0)  // 如果套接字中有可读数据
        {
            byte[] resultByteArray = new byte[1024 * 5];  // 创建一个缓冲区来存储接收到的数据
            int byteLength = clientSocket.Receive(resultByteArray);  // 从套接字接收数据并存储在缓冲区中
            ThreadPool.QueueUserWorkItem(HandleMessage, Encoding.UTF8.GetString(resultByteArray, 0, byteLength));  // 异步处理接收到的消息
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("收消息出错" + e.Message);
        Close();  // 如果接收出现异常，关闭套接字连接
    }
}

// 处理接收到的消息
private void HandleMessage(object obj)
{
    string str = obj as string;
    Console.WriteLine("收到客户端{0}发来的消息：{1}", this.clientSocket.RemoteEndPoint, str);  // 将接收到的消息和客户端的信息输出到控制台
}
```

##### 创建服务端套接字类，定义成员变量
![[ServerSocket 1.cs]]
```cs
class ServerSocket
{
    // 服务器端Socket
    public Socket serverSocket;
    // 保存客户端连接的所有Socket的字典
    public Dictionary<int, ClientSocket> clientSocketDictionary = new Dictionary<int, ClientSocket>();

    // 用于标识服务器是否关闭的标志
    private bool isServerClose;
}
```

##### 封装服务端套接字的成员方法
```cs
// 开启服务器端
public void Start(string ipString, int port, int clientSocketMaxNum)
{
    // 初始化服务器关闭标志为假
    isServerClose = false;

    // 创建服务器套接字，指定地址族为IPv4、套接字类型为流套接字、协议类型为TCP
    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    // 创建IP终结点，指定IP地址和端口号
    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipString), port);

    // 将套接字绑定到指定的IP终结点
    serverSocket.Bind(serverEndPoint);

    // 启动服务器套接字，同时指定同时等待连接的最大客户端数
    serverSocket.Listen(clientSocketMaxNum);

    // 启动线程池中的线程来处理客户端连接请求和消息接收
    ThreadPool.QueueUserWorkItem(AcceptClientConnect);
    ThreadPool.QueueUserWorkItem(ReceiveClientMessage);
}

// 关闭服务器端
public void Close()
{
    // 设置服务器关闭标志为真
    isServerClose = true;

    // 关闭所有客户端连接
    foreach (ClientSocket client in clientSocketDictionary.Values)
    {
        client.Close();
    }
    clientSocketDictionary.Clear();

    // 关闭服务器套接字的读写
    serverSocket.Shutdown(SocketShutdown.Both);

    // 关闭服务器套接字
    serverSocket.Close();

    // 将服务器套接字设置为null
    serverSocket = null;
}

// 接受客户端连接
private void AcceptClientConnect(object obj)
{
    while (!isServerClose)
    {
        try
        {
            // 等待并接受一个客户端连接请求
            Socket clientSocket = serverSocket.Accept();

            // 创建一个新的ClientSocket对象来管理客户端连接
            ClientSocket client = new ClientSocket(clientSocket);

            // 向客户端发送欢迎消息
            client.Send("欢迎连入服务器");

            // 将客户端Socket对象添加到字典中，以客户端ID作为键
            clientSocketDictionary.Add(client.clientID, client);
        }
        catch (Exception e)
        {
            Console.WriteLine("客户端连入报错" + e.Message);
        }
    }
}

// 接收客户端消息
private void ReceiveClientMessage(object obj)
{
    while (!isServerClose)
    {
        if (clientSocketDictionary.Count > 0)
        {
            foreach (ClientSocket client in clientSocketDictionary.Values)
            {
                // 从每个客户端接收消息
                client.Receive();
            }
        }
    }
}

// 向所有客户端广播消息
public void Broadcast(string info)
{
    foreach (ClientSocket client in clientSocketDictionary.Values)
    {
        client.Send(info);
    }
}
```
##### 主入口创建服务端并开启，定义一些命令
![[Program 3.cs]]
```cs
// 创建一个ServerSocket对象，用于处理服务器端的操作
ServerSocket serverSocket = new ServerSocket();

// 启动服务器，绑定到本地IP地址 127.0.0.1，监听端口 8080，允许最大连接数为 1024
serverSocket.Start("127.0.0.1", 8080, 1024);

// 输出服务器开启成功的消息
Console.WriteLine("服务器开启成功");

while (true)
{
    // 从控制台读取用户输入
    string input = Console.ReadLine();

    // 如果用户输入 "Quit"，则关闭服务器
    if (input == "Quit")
    {
        serverSocket.Close();
    }
    // 如果用户输入以 "B:" 开头，表示要广播消息给所有客户端
    else if (input.Substring(0, 2) == "B:")
    {
        // 提取输入的消息内容（去掉 "B:"）
        string message = input.Substring(2);

        // 调用服务器的广播方法，向所有客户端发送消息
        serverSocket.Broadcast(message);
    }
}
```