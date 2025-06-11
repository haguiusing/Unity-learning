### 使用UDP通信中Begin相关异步方法,将UDP同步通信中服务端综合练习改为使用异步方法通信
#### ServerSocket 类
![[ServerSocket 5.cs]]
##### 定义必要的变量
```cs
// 服务器端Socket
public Socket serverSocket;

// 用于标识服务器是否关闭的标志
private bool isServerClose;

// 我们可以通过记录谁给我发了消息 把它的 ip和端口记下来 这样就认为它是我的客户端了嘛
private Dictionary<string, Client> clientDictionary = new Dictionary<string, Client>();

// 用于接收消息的容器
private byte[] cacheBytes = new byte[512];
```
##### 定义启动服务器方法，传入IP和端口并绑定。处理消息和检查连接。定义关闭服务器方法。
```cs
// 启动服务器
public void Start(string ipString, int port)
{
    // 创建一个表示IP地址和端口的对象
    EndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipString), port);

    //声明一个用于UDP通信的Socket
    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    try
    {
        serverSocket.Bind(ipPoint);
        isServerClose = false;

        // 消息接收的处理 
        // BeginXXX系列方法都是异步方法，此处使用BeginReceiveFrom异步接收消息
        // cacheBytes为接收消息的缓存区，0为偏移量，cacheBytes.Length为接收消息的最大长度
        // SocketFlags.None表示不使用任何选项
        // ref ipPoint表示接收消息的IP地址和端口号
        // ReceiveMsg为接收完成后回调的方法
        serverSocket.BeginReceiveFrom(cacheBytes, 0, cacheBytes.Length, SocketFlags.None, ref ipPoint, ReceiveMsg, ipPoint);

        //定时检测超时线程
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
// 定期检测是否有超时客户端需要移除
private void CheckTimeOut(object obj)
{
    long nowTime = 0;
    List<string> delList = new List<string>();
    while (true)
    {
        //每30s检测一次 是否移除长时间没有接收到消息的客户端信息
        Thread.Sleep(30000);
        //得到当前系统时间
        nowTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
        foreach (Client c in clientDictionary.Values)
        {
            //超过10秒没有收到消息的 客户端信息 需要被移除
            if (nowTime - c.frontTime >= 10)
                delList.Add(c.clientStrID);
        }
        //从待删除列表中移除 超时的客户端信息
        for (int i = 0; i < delList.Count; i++)
            RemoveClient(delList[i]);
        delList.Clear();
    }
}

// 异步接收到消息后的处理
private void ReceiveMsg(IAsyncResult asyncResult)
{
    //接收消息的容器
    //记录谁发的
    //用于拼接字符串 位移ID 是由 IP + 端口构成的

    // 获取IP地址和端口号
    EndPoint ipPoint = asyncResult.AsyncState as IPEndPoint;
    string ip = (ipPoint as IPEndPoint).Address.ToString();
    int port = (ipPoint as IPEndPoint).Port;
    string strID = ip + port;//拼接成一个唯一ID 这个是我们自定义的规则

    try
    {
        // 调用EndReceiveFrom方法获取接收到的消息
        serverSocket.EndReceiveFrom(asyncResult, ref ipPoint);

        // 判断有没有记录这个客户端信息 如果有 用它直接处理消息
        if (clientDictionary.ContainsKey(strID))
            clientDictionary[strID].ReceiveMsg(cacheBytes);


        else
        {
            // 如果没有，直接添加并且处理消息
            clientDictionary.Add(strID, new Client(ip, port));
            clientDictionary[strID].ReceiveMsg(cacheBytes);
        }

        //继续接受消息
        serverSocket.BeginReceiveFrom(cacheBytes, 0, cacheBytes.Length, SocketFlags.None, ref ipPoint, ReceiveMsg, ipPoint);
    }
    catch (SocketException s)
    {
        Console.WriteLine("接受消息出错" + s.SocketErrorCode + s.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("接受消息出错(非Socket错误)" + e.Message);
    }
}

// 指定发送一个消息给某个目标
public void SendTo(BaseMessage baseMessage, IPEndPoint ipPoint)
{
    try
    {
        byte[] bytes = baseMessage.Writing();
        // BeginXXX系列方法都是异步方法，此处使用BeginSendTo异步发送消息
        // bytes为要发送的消息数据，0为偏移量，bytes.Length为消息数据的长度
        // SocketFlags.None表示不使用任何选项
        // ipPoint表示要发送的IP地址和端口号
        // 回调方法中处理如果发送失败的情况
        serverSocket.BeginSendTo(bytes, 0, bytes.Length, SocketFlags.None, ipPoint, (result) =>
        {
            try
            {
                serverSocket.EndSendTo(result);
            }
            catch (SocketException s)
            {
                Console.WriteLine("发消息出现问题" + s.SocketErrorCode + s.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("发送消息出问题（可能是序列化问题）" + e.Message);
            }
        }, null);
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
    //广播消息 给谁广播
    foreach (Client c in clientDictionary.Values)
    {
        SendTo(baseMessage, c.clientIPandPort);
    }
}

// 移除客户端信息
public void RemoveClient(string clientID)
{
    if (clientDictionary.ContainsKey(clientID))
    {
        Console.WriteLine("客户端{0}被移除了" + clientDictionary[clientID].clientIPandPort);
        clientDictionary.Remove(clientID);
    }
}
```

#### Client类
![[Client 1.cs]]
##### 定义客户端必要的标识和变量，在构造函数初始化
```cs
public IPEndPoint clientIPandPort; // 客户端的IP地址和端口
public string clientStrID; // 客户端的唯一标识

// 上一次收到消息的时间
public long frontTime = -1;

public Client(string ip, int port)
{
    // 规则和外面一样，记录唯一ID，通过 ip + port 拼接的形式
    clientStrID = ip + port;
    // 将客户端的信息记录下来
    clientIPandPort = new IPEndPoint(IPAddress.Parse(ip), port);
}
```
##### 使用多线程处理客户端发送过来的消息
```cs
// 接收消息
public void ReceiveMsg(byte[] bytes)
{
    // 为了避免处理消息时又接受到了其它消息，所以我们需要在处理之前先把信息拷贝出来
    // 处理消息和接收消息用不同的容器，避免出现问题
    byte[] cacheBytes = new byte[512];
    bytes.CopyTo(cacheBytes, 0);
    // 记录收到消息的系统时间，单位为秒
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
        // 再解析消息体
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
![[Program 7.cs]]
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
            PlayerMessage msg = new PlayerMessage();
            msg.playerData = new PlayerData();
            msg.playerID = 1001;
            msg.playerData.name = "韬老狮的UDP异步服务器";
            msg.playerData.atk = 88;
            msg.playerData.lev = 66;
            serverSocket.Broadcast(msg);
        }
    }
}
```