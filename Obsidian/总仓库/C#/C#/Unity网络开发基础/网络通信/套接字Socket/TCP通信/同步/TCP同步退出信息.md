![[Lesson10 1.cs]]

### 目前的客户端主动断开连接
#### 存在的问题
目前在客户端主动退出时  
我们会调用socket的 ShutDown和Close方法  
但是通过调用这两个方法后 服务器端无法得知客户端已经主动断开  
尝试修改 服务器端中客户端类的断开逻辑  
会发现当客户端主动断开时 服务端中的客户端类仍然显示正在连接 需要解决
#### 修改服务端中ClientSocket类的收发消息判断，要客户段连接的时候才进行收发消息
![[ClientSocket 3.cs]]
```cs
// 发送消息给客户端
public void Send(BaseMessage baseMessage)
{
    if (isClientConnected)
    {
        ...           
    }
}

// 接收来自客户端的消息
public void Receive()
{
    if (!isClientConnected)
        return;
    ...
}
```

#### 开启服务端和客户端 当客户端主动断开时 服务端中的客户端类仍然显示正在连接 需要解决
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%BF%83%E8%B7%B3%E6%B6%88%E6%81%AF-%E5%AE%A2%E6%88%B7%E7%AB%AF%E4%B8%BB%E5%8A%A8%E6%96%AD%E5%BC%80%E8%BF%9E%E6%8E%A5/1.png)
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%BF%83%E8%B7%B3%E6%B6%88%E6%81%AF-%E5%AE%A2%E6%88%B7%E7%AB%AF%E4%B8%BB%E5%8A%A8%E6%96%AD%E5%BC%80%E8%BF%9E%E6%8E%A5/2.png)

### 解决目前断开不及时的问题
#### 客户端尝试使用Disconnect方法主动断开连接
##### 思路
Socket当中有一个专门在客户端使用的方法  
Disconect方法  
客户端调用该方法和服务器端断开连接  
看是否是因为之前直接Close而没有调用Disconet造成服务器端无法及时获取状态

主要修改的逻辑：
客户端：  
主动断开连接

服务端：  
收发消息时判断socket是否已经断开  
处理删除记录的socket的相关逻辑（会用到线程锁）

##### TcpNetManager关闭连接并手动将socket置空
![[NetMgr 3.cs]] ^744b4d
```cs
// 关闭连接
public void Close()
{
    print("客户端主动断开连接");
    if (socket != null) // 如果套接字对象存在
    {
        socket.Shutdown(SocketShutdown.Both); // 关闭套接字的发送和接收

        socket.Disconnect(false);//手动停止连接 参数意思是这个socket以后还用不用

        socket.Close(); // 关闭套接字连接

        socket = null;//当前socket不会再用了 置空

        isConnected = false; // 标记连接已关闭
    }
}
```

##### 在服务端的ServerSocket中添加关闭客户端连接并从字典中移除的方法，注意操作客户端对象字典时要添加线程锁
![[ServerSocket 2.cs]]
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
##### 服务端的ServerSocket其他操作或者访问字典的方法中也要添加线程锁
```cs
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
            //client.Send("欢迎连入服务器");

            //线程锁 保证字典线程安全
            lock (clientSocketDictionary)
            {

                // 将客户端Socket对象添加到字典中，以客户端ID作为键
                clientSocketDictionary.Add(client.clientID, client);

            }
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
            //线程锁 保证字典线程安全
            lock (clientSocketDictionary)
            {
                foreach (ClientSocket client in clientSocketDictionary.Values)
                {
                    // 从每个客户端接收消息
                    client.Receive();
                }
            }
        }
    }
}

// 向所有客户端广播消息
public void Broadcast(BaseMessage baseMessage)
{
    //线程锁 保证字典线程安全
    lock (clientSocketDictionary)
    {
        foreach (ClientSocket client in clientSocketDictionary.Values)
        {
            client.Send(baseMessage);
        }
    }
}
```

##### 关闭客户端类连接并从字典中移除的方法正常来说应该在给客户端发消息或者接收客户端消息的时候移除，但是客户端发消息和接收客户端消息是在服务端类遍历字典调用的，在遍历时操作集合可能会报错，需要解决

##### 在ServerSocket创建一个List存储待移除的客户端socket。并定义添加客户端到待移除的客户端列表的方法。
```cs
//有待移除的客户端socket 避免 在foreach时直接从字典中移除 出现问题
private List<ClientSocket> delList = new List<ClientSocket>();

//添加待移除的 socket内容
public void AddDelSocket(ClientSocket socket)
{
    if (!delList.Contains(socket))
        delList.Add(socket);
}
```

##### 把Program的serverSocket改成静态变量，在ClientSocket的发送和接收来自客户端的消息方法中，检测到断开连接或者解析报错就把当前客户端添加到服务端待移除的客户端列表中。
```cs
// 发送消息给客户端
public void Send(BaseMessage baseMessage)
{
    if (isClientConnected)
    {
        try
        {
            clientSocket.Send(baseMessage.Writing());  // 将消息编码为UTF-8字节数组并发送给客户端
        }
        catch (Exception e)
        {
            Console.WriteLine("发消息出错" + e.Message);
            //解析报错也加入到待移除客户端列表
            Program.serverSocket.AddDelSocket(this);
            //Close();  // 如果发送出现异常，关闭套接字连接
        }
    }
    else
    {
        //断开连接的话加入到待移除客户端列表
        Program.serverSocket.AddDelSocket(this);
    }
}

// 接收来自客户端的消息
public void Receive()
{
    if (!isClientConnected)
    {
        //断开连接的话加入到待移除客户端列表
        Program.serverSocket.AddDelSocket(this);
        return;
    }
        
    try
    {
        if (clientSocket.Available > 0)// 如果套接字中有可读数据
        {
            byte[] result = new byte[1024 * 5];  // 创建一个缓冲区来存储接收到的数据
            int receiveNum = clientSocket.Receive(result);// 从套接字接收数据并存储在缓冲区中
            HandleReceiveMsg(result,receiveNum);
            ////收到数据后 先读取4个字节 转为ID 才知道用哪一个类型去处理反序列化
            //int msgID = BitConverter.ToInt32(result, 0);
            //BaseMessage baseMessage = null;
            //switch (msgID)
            //{
            //    case 1001:
            //        baseMessage = new PlayerMessage();
            //        baseMessage.Reading(result, 4);
            //        break;
            //}
            //if (baseMessage == null)
            //    return;
            //ThreadPool.QueueUserWorkItem(HandleMessage, baseMessage);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("收消息出错" + e.Message);
        //解析报错也加入到待移除客户端列表
        Program.serverSocket.AddDelSocket(this);
        //Close(); // 如果接收出现异常，关闭套接字连接
    }
}
```

##### 在ServerSocket定义遍历待删除客户端列表方法，逐个关闭客户端连接。关闭后清空。
```cs
//遍历待删除列表断开连接并删除
public void CloseDelListSocket()
{
    //判断有没有 断开连接的 把其 移除
    for (int i = 0; i < delList.Count; i++)
        CloseClientSocket(delList[i]);
    delList.Clear();
}
```

##### 在ServerSocket接收客户端消息的函数中，遍历完一次客户端字典接收过一轮消息后，调用遍历待删除客户端列表方法。
```cs
// 接收客户端消息
private void ReceiveClientMessage(object obj)
{
    while (!isServerClose)
    {

        if (clientSocketDictionary.Count > 0)
        {
            //线程锁 保证字典线程安全
            lock (clientSocketDictionary)
            {
                foreach (ClientSocket client in clientSocketDictionary.Values)
                {
                    // 从每个客户端接收消息
                    client.Receive();
                }

                //把待删除列表中的客户端断开连接后删除
                CloseDelListSocket();
            }
        }
    }
}
```

##### 测试后，发现客户端断开，服务器仍然无法检测到客户端类isClientConnected的变化，需要自定义退出消息来辅助

#### 自定义退出消息
##### 思路
让服务器端收到该消息就知道是客户端想要主动断开  
然后服务器端处理释放socket相关工作

##### 创建退出消息QuitMessage 类，继承BaseMessage，只要消息ID和长度，没有消息体
![[QuitMsg 1.cs]]
```cs
public class QuitMessage : BaseMessage
{
    public override int GetBytesNum()
    {
        //需要存储 ID和长度 两个int 8字节
        return 4 + 4;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        //没有消息体 0字节
        return 0;
    }

    public override byte[] Writing()
    {
        //写入ID和长度到字节数组并返回
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteInt(bytes, GetID(), ref index);
        WriteInt(bytes, 0, ref index);
        return bytes;
    }

    public override int GetID()
    {
        return 1003;
    }
}
```

##### 在ClientSocket处理接受消息 分包、黏包问题的方法中，添加解析退出消息的逻辑
![[ClientSocket 4.cs]]
```cs
// 处理接受消息 分包、黏包问题的方法
private void HandleReceiveMsg(byte[] receiveBytes, int receiveNum)
{
    ...

    while (true)
    {
            ...  

        // 缓存数组长度减去当前解析的位置假如大于消息长度 且消息长度不能是-1（-1说明没有解析消息长度 那就更不能解析消息体了）说明可以解析消息体
        if (cacheNum - nowIndex >= msgLength && msgLength != -1)
        {
            // 解析消息体
            BaseMessage baseMessage = null;
            switch (msgID)
            {
                case 1001:
                    baseMessage = new PlayerMessage();
                    baseMessage.Reading(cacheBytes, nowIndex);
                    break;
                case 1003:
                    baseMessage = new QuitMessage();
                    //QuitMessage没有消息体 不用反序列化
                    break;
            }
        }
    ...
    }
}
```

##### 在ClientSocket处理收到消息方法中，假如收到的消息是退出消息，就把当前客户端类添加到待删除列表中
```cs
// 处理接收到的消息
private void HandleMessage(object obj)
{
    BaseMessage baseMessage = obj as BaseMessage;
    if (baseMessage is PlayerMessage)
    {
        PlayerMessage playerMessage = baseMessage as PlayerMessage;
        Console.WriteLine(playerMessage.playerID);
        Console.WriteLine(playerMessage.playerData.name);
        Console.WriteLine(playerMessage.playerData.lev);
        Console.WriteLine(playerMessage.playerData.atk);
    }
    else if(baseMessage is QuitMessage)
    {
        //收到断开消息 添加到断开列表中
        Program.serverSocket.AddDelSocket(this);
    }
}
```

##### TcpNetManager中断开连接时发送退出消息
![[TCP同步退出信息#^744b4d]]
```cs
// 关闭连接
public void Close()
{
    print("客户端主动断开连接");
    if (socket != null) // 如果套接字对象存在
    {
        //主动发送一条断开的消息个服务端 
        QuitMessage quitMessage = new QuitMessage();

        //这里不能用我们封装的Send方法 因为Send方法是开一个线程发送的 可能还没发就直接被断开了
        socket.Send(quitMessage.Writing());

        socket.Shutdown(SocketShutdown.Both); // 关闭套接字的发送和接收

        socket.Disconnect(false);//手动停止连接 参数意思是这个socket以后还用不用

        socket.Close(); // 关闭套接字连接

        socket = null;//当前socket不会再用了 置空

        isConnected = false; // 标记连接已关闭
    }
}
```
##### 断点测试成功实现客户端断开连接检测
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%BF%83%E8%B7%B3%E6%B6%88%E6%81%AF-%E5%AE%A2%E6%88%B7%E7%AB%AF%E4%B8%BB%E5%8A%A8%E6%96%AD%E5%BC%80%E8%BF%9E%E6%8E%A5/3.png)
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%BF%83%E8%B7%B3%E6%B6%88%E6%81%AF-%E5%AE%A2%E6%88%B7%E7%AB%AF%E4%B8%BB%E5%8A%A8%E6%96%AD%E5%BC%80%E8%BF%9E%E6%8E%A5/4.png)

### 总结
客户端可以通过Disconnect方法主动和服务器端断开连接  
服务器端可以通过Conected属性判断连接状态决定是否释放Socket

但是由于服务器端Conected变量表示的是上一次收发消息是否成功  
所以服务器端无法准确判断客户端的连接状态  
因此 我们需要自定义一条退出消息 用于准确断开和客户端之间的连接