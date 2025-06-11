### 如同TCP通信一样让UDP服务端可以服务多个客户端
- 需要具备的功能有：
    - 区分消息类型（不需要处理分包、黏包）
    - 能够接受多个客户端的消息
    - 能够主动给发送过消息给自己的客户端发消息（记录客户端信息）
    - 主动记录上一次收到客户端消息的时间，如果长时间没有收到消息，主动移除记录的客户端信息

#### ServerSocket 类
![[ServerSocket 4.cs]]
##### 定义必要的变量
```cs
// 服务器端Socket
public Socket serverSocket;

// 用于标识服务器是否关闭的标志
private bool isServerClose;

//保存客户端连接的所有Socket的字典 我们可以通过记录谁给我发了消息 把它的 ip和端口记下来 这样就认为它是我的客户端了嘛
private Dictionary<string, Client> clientDictionary = new Dictionary<string, Client>();
```
##### 定义启动服务器方法，传入IP和端口并绑定。开两个线程分别处理消息和检查连接。定义关闭服务器方法。
```cs
// 启动服务器
public void Start(string ipString, int port)
{
    // 创建一个表示IP地址和端口的对象
    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipString), port);

    // 创建一个用于UDP通信的Socket
    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

    try
    {
        // 绑定Socket到指定的IP地址和端口
        serverSocket.Bind(ipPoint);
        isServerClose = false;
        // 消息接收的处理 
        ThreadPool.QueueUserWorkItem(ReceiveMsg);
        // 定时检测超时线程
        ThreadPool.QueueUserWorkItem(CheckTimeOut);
    }
    catch (Exception e)
    {
        Console.WriteLine("UDP开启出错" + e.Message);
    }
}

// 关闭服务器
public void Close()
{
    if (serverSocket != null)
    {
        isServerClose = true;
        serverSocket.Shutdown(SocketShutdown.Both);
        serverSocket.Close();
        serverSocket = null;
    }
}
```
##### 定义收发、广播消息，检查连接和移除客户端方法。超时则移除指定客户端。收消息时发现是新的客户端要加入到客户端字典中。
```cs
// 定时检测超时的客户端连接
private void CheckTimeOut(object obj)
{
    long nowTime = 0;
    List<string> delList = new List<string>();
    while (true)
    {
        // 每30秒检测一次是否移除长时间没有接收到消息的客户端信息
        Thread.Sleep(30000);
        // 得到当前系统时间
        nowTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
        foreach (Client c in clientDictionary.Values)
        {
            // 超过10秒没有收到消息的客户端信息需要被移除
            if (nowTime - c.frontTime >= 10)
                delList.Add(c.clientStrID);
        }
        // 从待删除列表中移除超时的客户端信息
        for (int i = 0; i < delList.Count; i++)
            RemoveClient(delList[i]);
        delList.Clear();
    }
}

// 处理接收到的消息
private void ReceiveMsg(object obj)
{
    // 接收消息的容器
    byte[] bytes = new byte[512];
    // 记录消息发送者的IP地址和端口
    EndPoint ipPoint = new IPEndPoint(IPAddress.Any, 0);
    // 用于拼接字符串，唯一ID是由IP + 端口构成的
    string strID = "";
    string ip;
    int port;
    while (!isServerClose)
    {
        if (serverSocket.Available > 0)
        {
            // 接收消息
            lock (serverSocket)
                serverSocket.ReceiveFrom(bytes, ref ipPoint);
            // 处理消息，最好不要在这直接处理，而是交给客户端对象处理
            // 收到消息时，判断是否记录了这个客户端信息（IP和端口）
           // 取出发送消息给服务器的IP和端口
            ip = (ipPoint as IPEndPoint).Address.ToString();
            port = (ipPoint as IPEndPoint).Port;
            strID = ip + port; // 拼接成一个唯一ID，这个是自定义的规则
            // 判断是否记录了这个客户端信息，如果有，用它直接处理消息
            if (clientDictionary.ContainsKey(strID))
                clientDictionary[strID].ReceiveMsg(bytes);
            else // 如果没有，直接添加并且处理消息
            {
                clientDictionary.Add(strID, new Client(ip, port));
                clientDictionary[strID].ReceiveMsg(bytes);
            }
        }
    }
}

// 指定发送一个消息给某个目标
public void SendTo(BaseMessage baseMessage, IPEndPoint ipPoint)
{
    try
    {
        // 同步发送消息
        lock (serverSocket)
            serverSocket.SendTo(baseMessage.Writing(), ipPoint);
    }
    catch (SocketException s)
    {
        Console.WriteLine("发消息出现问题" + s.SocketErrorCode + s.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("发送消息出问题（可能是序列化问题）" + e.Message);
    }
}

// 广播消息给所有客户端
public void Broadcast(BaseMessage baseMessage)
{
    // 遍历客户端列表，向每个客户端发送消息
    foreach (Client c in clientDictionary.Values)
    {
        SendTo(baseMessage, c.clientIPandPort);
    }
}

// 移除指定客户端
public void RemoveClient(string clientID)
{
    if (clientDictionary.ContainsKey(clientID))
    {
        Console.WriteLine("客户端{0}被移除了" + clientDictionary[clientID].clientIPandPort);
        clientDictionary.Remove(clientID);
    }
}
```
#### Client 类
![[Client.cs]]
##### 定义客户端必要的标识和变量，在构造函数初始化
```cs
public IPEndPoint clientIPandPort; // 客户端的IP地址和端口信息
public string clientStrID; // 客户端的唯一标识

// 上一次收到消息的时间
public long frontTime = -1;

// 构造函数，初始化客户端信息
public Client(string ip, int port)
{
    // 创建唯一ID，由IP + 端口拼接而成
    clientStrID = ip + port;
    // 记录客户端的IP地址和端口
    clientIPandPort = new IPEndPoint(IPAddress.Parse(ip), port);
}
```
##### 使用多线程处理客户端发送过来的消息
```cs
// 接收消息
public void ReceiveMsg(byte[] bytes)
{
    // 为了避免处理消息时又接受到了其他消息，需要在处理之前先将信息拷贝出来
    // 处理消息和接收消息需要使用不同的容器，以避免出现问题
    byte[] cacheBytes = new byte[512];
    bytes.CopyTo(cacheBytes, 0);
    // 记录收到消息的系统时间（单位为秒）
    frontTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
    ThreadPool.QueueUserWorkItem(ReceiveHandle, cacheBytes);
}

// 多线程处理消息
private void ReceiveHandle(object obj)
{
    try
    {
        // 取出传进来的字节
        byte[] bytes = obj as byte[];
        int nowIndex = 0;
        // 先处理消息ID
        int msgID = BitConverter.ToInt32(bytes, nowIndex);
        nowIndex += 4;
        // 再处理消息长度
        int msgLength = BitConverter.ToInt32(bytes, nowIndex);
        nowIndex += 4;
        // 根据消息ID解析消息体
        switch (msgID)
        {
            case 1001:
                PlayerMessage playerMessage = new PlayerMessage();
                playerMessage.Reading(bytes, nowIndex);
                Console.WriteLine(playerMessage.playerID);
                Console.WriteLine(playerMessage.playerData.name);
                Console.WriteLine(playerMessage.playerData.atk);
                Console.WriteLine(playerMessage.playerData.lev);
                break;
            case 1003:
                QuitMessage quitMessage = new QuitMessage();
                // 由于它没有消息体，所以不用反序列化
                // quitMessage.Reading(bytes, nowIndex);
                // 处理退出
                Program.serverSocket.RemoveClient(clientStrID);
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("处理消息时出错" + e.Message);
        // 如果出错，就不用记录这个客户端信息
        Program.serverSocket.RemoveClient(clientStrID);
    }
}
```

#### 服务端入口
![[Program 6.cs]]
##### 定义服务端静态变量，方便全局获得，检查服务端输入，广播消息
```cs
public static ServerSocket serverSocket;

static void Main(string[] args)
{
    serverSocket = new ServerSocket();
    serverSocket.Start("127.0.0.1", 8080);

    Console.WriteLine("UDP服务器启动了");

    while (true)
    {
        string input = Console.ReadLine();
        if (input.Substring(0, 2) == "B:")
        {
            PlayerMessage playerMessage = new PlayerMessage();
            playerMessage.playerData = new PlayerData();
            playerMessage.playerID = 1001;
            playerMessage.playerData.name = "韬老狮的UDP服务器";
            playerMessage.playerData.atk = 88;
            playerMessage.playerData.lev = 66;
            serverSocket.Broadcast(playerMessage);
        }
    }
}
```

#### 注意
实际上这是为了练习才这样处理。这样非常不安全。因为别人知道了你的IP地址和端口，可能一直给你发垃圾消息导致解析失败或者阻塞。商业游戏中，通常先建立可靠的TCP连接，使用UDP收发消息前，会检查服务端是否和该客户端进行了TCP连接，保证安全可靠后在使用UDP通信