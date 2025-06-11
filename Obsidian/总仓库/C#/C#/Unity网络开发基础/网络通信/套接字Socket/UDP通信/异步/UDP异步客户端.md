### 使用UDP通信中Async相关异步方法，将UDP同步通信中客户端综合练习改为使用异步方法通信。
#### 定义UdpNetAsyncManager类，实现继承Monobehaviour的单例。定义必要的变量。
![[UdpAsyncNetMgr.cs]]
```cs
public class UdpNetAsyncManager : BaseSingletonInMonoBehaviour<UdpNetAsyncManager>
{
    private EndPoint serverIpPoint;// 服务器的IP地址和端口信息

    private Socket socket; // 客户端Socket

    //客户端socket是否关闭
    private bool isClose = true;

    //发送消息的队列 在多线程里面可以操作
    private Queue<BaseMessage> receiveQueue = new Queue<BaseMessage>();

    private byte[] cacheBytes = new byte[512];// 用于缓存接收的字节数据
}
```
#### 实现启动客户端和关闭客户端方法。销毁时需要调用关闭客户端。
```cs
/// <summary>
/// 启动客户端socket相关的方法
/// </summary>
/// <param name="ip">远端服务器的IP</param>
/// <param name="port">远端服务器的port</param>
public void StartClient(string ip, int port)
{
    // 如果当前是开启状态 就不用再开了
    if (!isClose)
        return;

    // 创建一个表示服务器地址的IPEndPoint对象，稍后用于发送消息
    serverIpPoint = new IPEndPoint(IPAddress.Parse(ip), port);

    // 创建表示客户端的本地地址和端口的IPEndPoint对象
    IPEndPoint clientIpPort = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
    try
    {
        // 创建UDP套接字
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        // 将套接字绑定到客户端的本地地址和端口
        socket.Bind(clientIpPort);
        isClose = false;

        // 创建SocketAsyncEventArgs对象来接收数据
        SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
        socketAsyncEventArgs.SetBuffer(cacheBytes, 0, cacheBytes.Length);
        socketAsyncEventArgs.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        // 设置接收完成后的事件处理函数
        socketAsyncEventArgs.Completed += ReceiveMsg;

        // 开始异步接收数据
        socket.ReceiveFromAsync(socketAsyncEventArgs);

        // 输出调试信息
        print("客户端网络启动");
    }
    catch (System.Exception e)
    {
        // 发生异常时输出错误信息
        print("启动Socket出问题" + e.Message);
    }
}

// 关闭socket
public void Close()
{
    if (socket != null)
    {
        isClose = true;

        // 创建一个退出消息对象
        QuitMessage quitMessage = new QuitMessage();

        // 向服务器发送退出消息，以通知服务器移除客户端记录
        socket.SendTo(quitMessage.Writing(), serverIpPoint);

        // 关闭套接字的发送和接收，然后关闭套接字
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
        socket = null;
    }
}

// 当对象被销毁时自动调用Close方法，确保关闭socket
private void OnDestroy()
{
    Close();
}
```
#### 实现收发消息方法
```cs
//收消息
private void ReceiveMsg(object obj, SocketAsyncEventArgs socketAsyncEventArgs)
{
    // 声明变量以存储消息的当前索引、消息ID和消息长度
    int nowIndex;
    int msgID;
    int msgLength;

    // 检查套接字异步事件是否成功
    if (socketAsyncEventArgs.SocketError == SocketError.Success)
    {
        try
        {
            // 检查接收到的消息是否来自服务器
            if (socketAsyncEventArgs.RemoteEndPoint.Equals(serverIpPoint))
            {
                // 初始化当前索引
                nowIndex = 0;

                // 解析消息ID（4字节整数）
                msgID = BitConverter.ToInt32(socketAsyncEventArgs.Buffer, nowIndex);
                nowIndex += 4;

                // 解析消息长度（4字节整数）
                msgLength = BitConverter.ToInt32(socketAsyncEventArgs.Buffer, nowIndex);
                nowIndex += 4;

                // 创建一个消息对象用于存储接收到的消息
                BaseMessage baseMessage = null;

                // 根据消息ID执行相应的处理
                switch (msgID)
                {
                    case 1001:
                        // 如果消息ID是1001，创建一个玩家消息对象
                        baseMessage = new PlayerMessage();

                        // 反序列化消息体
                        baseMessage.Reading(socketAsyncEventArgs.Buffer, nowIndex);
                        break;
                }

                // 如果消息对象不为空，将其加入接收队列
                if (baseMessage != null)
                    receiveQueue.Enqueue(baseMessage);
            }

            // 如果套接字仍处于打开状态且不被关闭
            if (socket != null && !isClose)
            {
                // 重置异步事件的缓冲区以接收更多数据
                socketAsyncEventArgs.SetBuffer(0, cacheBytes.Length);

                // 继续异步接收数据
                socket.ReceiveFromAsync(socketAsyncEventArgs);
            }
        }
        catch (SocketException s)
        {
            // 处理套接字异常，通常在接收消息时发生
            print("接收消息出错" + s.SocketErrorCode + s.Message);

            // 关闭套接字
            Close();
        }
        catch (Exception e)
        {
            // 处理其他异常，可能是反序列化问题
            print("接收消息出错(可能是反序列化问题)" + e.Message);

            // 关闭套接字
            Close();
        }
    }
    else
    {
        // 打印套接字错误，表示接收消息失败
        print("接收消息失败" + socketAsyncEventArgs.SocketError);
    }
}

//每帧检查消息列表
void Update()
{
    // 如果接收队列中有待处理的消息
    if (receiveQueue.Count > 0)
    {
        // 从队列中取出下一个消息
        BaseMessage baseMessage = receiveQueue.Dequeue();

        // 根据消息类型进行处理
        switch (baseMessage)
        {
            case PlayerMessage playerMessage:
                // 处理玩家消息，打印相关信息
                print(playerMessage.playerID);
                print(playerMessage.playerData.name);
                print(playerMessage.playerData.atk);
                print(playerMessage.playerData.lev);
                break;
        }
    }
}

// 发送消息
public void Send(BaseMessage baseMessage)
{
    try
    {
        // 检查套接字是否存在且未关闭
        if (socket != null && !isClose)
        {
            // 创建一个SocketAsyncEventArgs对象用于发送消息
            SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();

            // 将消息对象序列化为字节数组
            byte[] bytes = baseMessage.Writing();

            // 设置SocketAsyncEventArgs的缓冲区以包含要发送的字节数组
            socketAsyncEventArgs.SetBuffer(bytes, 0, bytes.Length);

            // 设置发送完成后的回调函数
            socketAsyncEventArgs.Completed += SendToCallBack;

            // 设置远端目标，即服务器的IP和端口
            socketAsyncEventArgs.RemoteEndPoint = serverIpPoint;

            // 发送消息
            socket.SendToAsync(socketAsyncEventArgs);
        }
    }
    catch (SocketException s)
    {
        // 处理套接字异常，通常在发送消息时发生
        print("发送消息出错" + s.SocketErrorCode + s.Message);
    }
    catch (Exception e)
    {
        // 处理其他异常，可能是序列化问题
        print("发送消息出错(可能是序列化问题)" + e.Message);
    }
}

// 发送消息后的回调函数
private void SendToCallBack(object o, SocketAsyncEventArgs socketAsyncEventArgs)
{
    // 如果发送消息过程中出现套接字错误
    if (socketAsyncEventArgs.SocketError != SocketError.Success)
    {
        // 打印错误信息，表示发送消息失败
        print("发送消息失败" + socketAsyncEventArgs.SocketError);
    }
}
```

#### 客户端入口连接服务端，并定义发消息测试按钮
![[Lesson17 1.cs]]
```cs
public InputField InputField;
public Button sendButton;
void Start()
{
    UdpNetAsyncManager.Instance.StartClient("127.0.0.1", 8080);

    sendButton.onClick.AddListener(() =>
    {
        PlayerMessage playerMessage = new PlayerMessage();
        playerMessage.playerData = new PlayerData();
        playerMessage.playerID = 1;
        playerMessage.playerData.name = "韬老狮的UDP客户端发的异步消息";
        playerMessage.playerData.atk = 888;
        playerMessage.playerData.lev = 666;
        UdpNetAsyncManager.Instance.Send(playerMessage);
    });
}
```
![[MainUdpAsync.cs]]

#### 开启UDP服务端和客户端进行测试
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/39.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-UDP%E9%80%9A%E4%BF%A1-%E5%BC%82%E6%AD%A5-%E5%AE%A2%E6%88%B7%E7%AB%AF%E7%BB%BC%E5%90%88%E7%BB%83%E4%B9%A0%E9%A2%98/1.png)