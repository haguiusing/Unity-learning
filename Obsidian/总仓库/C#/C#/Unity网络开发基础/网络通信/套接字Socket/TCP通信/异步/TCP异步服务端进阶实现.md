### 将异步服务端，加上同步中的：区分消息类型，分包、黏包，心跳消息等功能
#### 拷贝消息和基础数据相关代码到服务端
#### 在ClientSocket类实现心跳消息检查
![[ClientSocket 6.cs]]
```cs
//上一次收到消息的时间
private long frontTime = -1;
//超时时间
private static int TIME_OUT_TIME = 10;

public ClientSocket(Socket clientSocket)
{
    this.clientID = CLIENT_BEGIN_ID;  // 初始化客户端ID
    this.clientSocket = clientSocket;  // 初始化套接字
    ++CLIENT_BEGIN_ID;  // 为下一个客户端分配不同的ID

    //开始收消息
    this.clientSocket.BeginReceive(cacheBytes, cacheNum, cacheBytes.Length, SocketFlags.None, ReceiveCallBack, null);

    //心跳消息检查
    ThreadPool.QueueUserWorkItem(CheckTimeOut);
}

/// <summary>
/// 间隔一段时间 检测一次超时 如果超时 就会主动断开该客户端的连接
/// </summary>
/// <param name="obj"></param>
private void CheckTimeOut(object obj)
{
    while (this.clientSocket != null && isClientConnected)
    {
        if (frontTime != -1 &&
            DateTime.Now.Ticks / TimeSpan.TicksPerSecond - frontTime >= TIME_OUT_TIME)
        {
            Program.serverSocket.CloseClientSocket(this);
            break;
        }
        Thread.Sleep(5000);
    }
}
```

#### 在ClientSocket类，收发消息不使用字符串，使用BaseMessage，拷贝重写处理分包黏包函数和处理信息函数
```cs
// 发送消息给客户端
public void Send(BaseMessage baseMessage)
{
    // 检查 clientSocket 不为 null 并且客户端已连接。
    if (clientSocket != null && isClientConnected)
    {
        // 使用 Writing() 方法将消息序列化为字节数组。
        byte[] bytes = baseMessage.Writing();

        // 在 clientSocket 上启动异步发送操作以发送消息。
        // 参数：bytes - 要发送的数据，0 - 数据中的起始位置，
        // bytes.Length - 要发送的字节数，SocketFlags.None - 无特殊标志，
        // SendCallBack - 发送操作完成时执行的回调方法，null - 用户定义的对象。
        clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, SendCallBack, null);
    }
    else
    {
        // 如果 clientSocket 为 null 或客户端未连接，则关闭客户端的连接。
        Program.serverSocket.CloseClientSocket(this);
    }
}

// 发送消息给客户端的回调。
private void SendCallBack(IAsyncResult asyncResult)
{
    try
    {
        // 检查 clientSocket 不为 null 并且客户端已连接。
        if (clientSocket != null && isClientConnected)
            // 结束异步发送操作，标记其完成。
            this.clientSocket.EndSend(asyncResult);
        else
            // 如果 clientSocket 为 null 或客户端未连接，则关闭客户端的连接。
            Program.serverSocket.CloseClientSocket(this);
    }
    catch (SocketException e)
    {
        // 处理可能在发送操作期间发生的 SocketException。
        // 打印错误消息，包括 SocketErrorCode 和异常消息。
        Console.WriteLine("发送失败" + e.SocketErrorCode + e.Message);

        // 作为错误响应关闭客户端的连接。
        Program.serverSocket.CloseClientSocket(this);
    }
}

// 接收来自客户端的消息的回调
private void ReceiveCallBack(IAsyncResult asyncResult)
{
    try
    {
        if (this.clientSocket != null && isClientConnected)
        {
            // 从客户端成功接收消息
            int num = this.clientSocket.EndReceive(asyncResult);

            // 处理消息的分包和黏包问题
            HandleReceiveMsg(num);

            // 再次启动异步接收操作以等待下一条消息，将已接收的消息添加到缓存中。
            this.clientSocket.BeginReceive(cacheBytes, cacheNum, cacheBytes.Length - cacheNum, SocketFlags.None, ReceiveCallBack, this.clientSocket);
        }
        else
        {
            // 如果 clientSocket 为 null 或客户端未连接，则不再接收消息。
            Console.WriteLine("没有连接，不用再收消息了");
            Program.serverSocket.CloseClientSocket(this);
        }
    }
    catch (SocketException e)
    {
        // 处理可能在接收消息期间发生的 SocketException。
        Console.WriteLine("接受消息错误" + e.SocketErrorCode + e.Message);

        // 作为错误响应关闭客户端的连接。
        Program.serverSocket.CloseClientSocket(this);
    }
}

// 处理接受消息 分包、黏包问题的方法
private void HandleReceiveMsg(int receiveNum)
{
    int msgID = 0;       // 消息ID
    int msgLength = 0;   // 消息长度
    int nowIndex = 0;    // 当前消息解析到哪一位

    //由于消息接收后是直接存储在 cacheBytes中的 所以不需要进行什么拷贝操作
    //收到消息的字节数量
    cacheNum += receiveNum;

    while (true)
    {
        // 在每次循环开始时将消息长度设置为-1作为标记，以避免上一次解析的数据影响当前的判断
        msgLength = -1;

        // 如果当前的缓存数组长度大于8 那么就可以解析这一个包的消息ID和消息长度 移动解析位置
        if (cacheNum - nowIndex >= 8)
        {
            // 解析消息ID
            msgID = BitConverter.ToInt32(cacheBytes, nowIndex);
            nowIndex += 4;

            // 解析消息长度
            msgLength = BitConverter.ToInt32(cacheBytes, nowIndex);
            nowIndex += 4;
        }

        // 缓存数组长度减去当前解析的位置假如大于消息长度 且消息长度不能是-1（-1说明没有解析消息长度 那就更不能解析消息体了）说明可以解析消息体
        if (cacheNum - nowIndex >= msgLength && msgLength != -1)
        {
            //解析消息体
            BaseMessage baseMessage = null;
            switch (msgID)
            {
                case 1001:
                    baseMessage = new PlayerMessage();
                    baseMessage.Reading(cacheBytes, nowIndex);
                    break;
                case 1003:
                    baseMessage = new QuitMessage();
                    //由于该消息没有消息体 所以都不用反序列化
                    break;
                case 999:
                    baseMessage = new HeartMessage();
                    //由于该消息没有消息体 所以都不用反序列化
                    break;
            }
            if (baseMessage != null)
                ThreadPool.QueueUserWorkItem(HandleMessage, baseMessage);//开启线程进行处理

            //移动解析位置 加上消息体长度
            nowIndex += msgLength;

            // 如果刚好解析完当前缓存数组所有内容，说明这个包没有黏包，重置缓存并退出循环，解析结束
            if (nowIndex == cacheNum)
            {
                cacheNum = 0;
                break;
            }
        }
        // 如果不满足条件，表明存在分包的情况，需要将当前接收的内容记录下来 以便在下次接收到消息后继续处理
        else
        {
            // 如果已经解析了消息ID和消息长度，但没有成功解析消息体，需要减去nowIndex解析位置的偏移。
            // 要保留完整的消息ID和消息长度，以便下次完整解析。
            if (msgLength != -1)
                nowIndex -= 8;

            // 使用Array.Copy方法，将剩余未解析的字节数组内容移到前面，用于缓存下次继续解析。
            // 参数1: 要拷贝的数组  这里是原始的缓存数组 cacheBytes。
            // 参数2: 从第几个索引开始拷贝后面的内容  这里是 nowIndex，表示从未解析的部分开始，把nowIndex到尾部的字节元素都要拷贝
            // 参数3: 拷贝到的目标数组  也是原始的缓存数组 cacheBytes，因此在这里实际上是在原数组中进行移动操作。
            // 参数4: 目标数组开始索引  这里是0，表示将数据移动到数组的开头。
            // 参数5: 拷贝长度  这里是 cacheNum - nowIndex，表示要移动的字节数，即未解析部分的长度。cacheNum代表原先缓存数组所有要解析的字节数组长度，减去nowIndex代表未解析部分的长度。
            Array.Copy(cacheBytes, nowIndex, cacheBytes, 0, cacheNum - nowIndex);

            // 更新缓存的长度，减去已解析的部分，以便在下次继续解析时正确处理未解析的内容。
            cacheNum = cacheNum - nowIndex;

            break;
        }
    }

}

// 处理接收到的消息
private void HandleMessage(object obj)
{
    switch (obj)
    {
        case PlayerMessage baseMessage:
            PlayerMessage playerMessage = baseMessage as PlayerMessage;
            Console.WriteLine(playerMessage.playerID);
            Console.WriteLine(playerMessage.playerData.name);
            Console.WriteLine(playerMessage.playerData.lev);
            Console.WriteLine(playerMessage.playerData.atk);
            break;
        case QuitMessage baseMessage:
            //收到断开连接消息 把自己添加到待移除的列表当中
            Program.serverSocket.CloseClientSocket(this);
            break;
        case HeartMessage baseMessage:
            //收到心跳消息 记录收到消息的时间
            frontTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            Console.WriteLine("收到心跳消息");
            break;
    }
}
```

#### 在ServerSocket类，实现关闭客户端连接的方法
```cs
//关闭客户端连接的 从字典中移除
public void CloseClientSocket(ClientSocket socket)
{
    //添加线程锁 服务器类有很多线程 假如同时操作字典会有问题 保证线程安全
    lock (clientSocketDictionary)
    {
        socket.Close();
        if (clientSocketDictionary.ContainsKey(socket.clientID))
        {
            clientSocketDictionary.Remove(socket.clientID);
            Console.WriteLine("客户端{0}主动断开连接了", socket.clientID);
        }
    }
}
```

#### 服务端入口定义ServerSocket类静态变量和输入1001广播逻辑
```cs
public static ServerSocket serverSocket;
static void Main(string[] args)
{
    serverSocket = new ServerSocket();
    serverSocket.Start("127.0.0.1", 8080, 1024);
    Console.WriteLine("开启服务器成功");

    while (true)
    {
        string input = Console.ReadLine();
        if (input.Substring(2) == "1001")
        {
            PlayerMessage playerMessage = new PlayerMessage();
            playerMessage.playerID = 9876;
            playerMessage.playerData = new PlayerData();
            playerMessage.playerData.name = "服务器端发来的消息";
            playerMessage.playerData.lev = 99;
            playerMessage.playerData.atk = 80;
            serverSocket.Broadcast(playerMessage);
        }
    }
}
```