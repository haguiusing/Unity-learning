![[Lesson13 1.cs]]

### 创建TcpNetAsyncManager，实现Monobehaviour的单例。定义和服务器进行连接的Socket还有缓存字节数组及长度
![[NetAsyncMgr.cs]]
```cs
// 用于和服务器进行连接的Socket
private Socket socket;

// 用于处理分包时缓存的字节数组和字节数组长度
private byte[] cacheBytes = new byte[1024 * 1024];
private int cacheNum = 0;
```

### 实现连接服务器和关闭连接的方法
```cs
// 连接服务器
public void Connect(string ip, int port)
{
    // 检查当前是否已经连接，如果已经连接则直接返回
    if (socket != null && socket.Connected)
        return;

    // 创建IP地址和端口信息
    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);

    // 创建一个Socket用于TCP连接
    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    // 创建异步Socket事件参数
    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
    socketAsyncEventArgs.RemoteEndPoint = ipPoint;

    // 注册连接完成时的回调函数
    socketAsyncEventArgs.Completed += (socket, socketAsyncEventArgs) =>
    {
        if (socketAsyncEventArgs.SocketError == SocketError.Success)
        {
            print("连接成功");
            // 设置接收消息的Socket事件参数
            SocketAsyncEventArgs receiveSocketAsyncEventArgs = new SocketAsyncEventArgs();
            receiveSocketAsyncEventArgs.SetBuffer(cacheBytes, 0, cacheBytes.Length);
            receiveSocketAsyncEventArgs.Completed += ReceiveCallBack;
            this.socket.ReceiveAsync(receiveSocketAsyncEventArgs);
        }
        else
        {
            print("连接失败" + socketAsyncEventArgs.SocketError);
        }
    };

    // 开始异步连接
    socket.ConnectAsync(socketAsyncEventArgs);
}

// 关闭连接
public void Close()
{
    if (socket != null)
    {
        // 关闭连接前先关闭读写流
        socket.Shutdown(SocketShutdown.Both);
        // 断开连接
        socket.Disconnect(false);
        // 关闭Socket
        socket.Close();
        socket = null;
    }
}
```

### 实现客户端收消息回调函数和发消息给服务端函数
```cs
// 客户端收消息完成的回调函数
private void ReceiveCallBack(object obj, SocketAsyncEventArgs receiveSocketAsyncEventArgs)
{
    if (receiveSocketAsyncEventArgs.SocketError == SocketError.Success)
    {
        // 解析消息，目前使用UTF-8编码将字节数组转换为字符串
        print(Encoding.UTF8.GetString(receiveSocketAsyncEventArgs.Buffer, 0, receiveSocketAsyncEventArgs.BytesTransferred));

        // 继续接收消息，重置接收缓冲区
        receiveSocketAsyncEventArgs.SetBuffer(0, receiveSocketAsyncEventArgs.Buffer.Length);

        // 继续异步接收消息
        if (this.socket != null && this.socket.Connected)
            socket.ReceiveAsync(receiveSocketAsyncEventArgs);
        else
            Close();
    }
    else
    {
        print("接受消息出错" + receiveSocketAsyncEventArgs.SocketError);
        // 关闭客户端连接
        Close();
    }
}

// 发送消息给服务端
public void Send(string str)
{
    if (this.socket != null && this.socket.Connected)
    {
        // 将字符串转换为字节数组
        byte[] bytes = Encoding.UTF8.GetBytes(str);

        // 创建异步Socket事件参数用于发送消息
        SocketAsyncEventArgs sendSocketAsyncEventArgs = new SocketAsyncEventArgs();
        sendSocketAsyncEventArgs.SetBuffer(bytes, 0, bytes.Length);
        sendSocketAsyncEventArgs.Completed += (socket, args) =>
        {
            if (args.SocketError != SocketError.Success)
            {
                print("发送消息失败" + args.SocketError);
                Close();
            }
        };

        // 开始异步发送消息
        this.socket.SendAsync(sendSocketAsyncEventArgs);
    }
    else
    {
        // 如果Socket未连接，则关闭连接
        Close();
    }
}
```

### 在客户端入口添加测试代码，开启服务端和客户端进行收发消息的测试
![[MainAsync.cs]]
```cs       
public InputField InputField;
public Button sendButton;
void Start()
{
    TcpNetAsyncManager.Instance.Connect("127.0.0.1", 8080);

    //直接发消息测试
    sendButton.onClick.AddListener(() =>
    {
        if (InputField.text != "")
            TcpNetAsyncManager.Instance.Send(InputField.text);
    });
}
```