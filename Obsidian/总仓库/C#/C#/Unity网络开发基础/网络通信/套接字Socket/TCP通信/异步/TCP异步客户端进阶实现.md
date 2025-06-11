

### 将异步客户端，加上同步中：区分消息类型，分包、黏包，心跳消息等功能
#### 在 TcpNetAsyncManager 定义心跳消息相关
![[NetAsyncMgr 1.cs]]
```cs
// 发送心跳消息的间隔时间
private int SEND_HEART_MSG_TIME = 2;
private HeartMessage heartMessage = new HeartMessage();

protected override void Awake()
{
    base.Awake();

    // 客户端循环定时给服务端发送心跳消息
    InvokeRepeating("SendHeartMsg", 0, SEND_HEART_MSG_TIME);
}

// 发送心跳消息
private void SendHeartMsg()
{
    if (socket != null && this.socket.Connected)
        Send(heartMessage);
}
```
#### 定义发消息测试方法和发消息方法，把字符串改成 BaseMessage 类型
```cs
/// <summary>
/// 用于测试 直接发字节数组的方法
/// </summary>
/// <param name="bytes"></param>
public void SendTest(byte[] bytes)
{
    SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
    socketAsyncEventArgs.SetBuffer(bytes, 0, bytes.Length);
    socketAsyncEventArgs.Completed += (socket, args) =>
    {
        if (args.SocketError != SocketError.Success)
        {
            print("发送消息失败" + args.SocketError);
            Close();
        }

    };
    this.socket.SendAsync(socketAsyncEventArgs);
}

// 发送消息
public void Send(BaseMessage baseMessage)
{
    if (this.socket != null && this.socket.Connected)
    {
        byte[] bytes = baseMessage.Writing();
        SocketAsyncEventArgs args = new SocketAsyncEventArgs();
        args.SetBuffer(bytes, 0, bytes.Length);
        args.Completed += (socket, args) =>
        {
            if (args.SocketError != SocketError.Success)
            {
                print("发送消息失败" + args.SocketError);
                Close();
            }

        };
        this.socket.SendAsync(args);
    }
    else
    {
        Close();
    }
}
```
#### 定义收消息队列和相关方法
```cs
private Queue<BaseMessage> receiveQueue = new Queue<BaseMessage>(); // 创建一个队列，用于存储接收到的消息

// 收消息完成的回调函数
private void ReceiveCallBack(object obj, SocketAsyncEventArgs socketAsyncEventArgs)
{
    if (socketAsyncEventArgs.SocketError == SocketError.Success)
    {
        HandleReceiveMsg(socketAsyncEventArgs.BytesTransferred);
        // 继续去收消息
        socketAsyncEventArgs.SetBuffer(cacheNum, socketAsyncEventArgs.Buffer.Length - cacheNum);
        // 继续异步收消息
        if (this.socket != null && this.socket.Connected)
            socket.ReceiveAsync(socketAsyncEventArgs);
        else
            Close();
    }
    else
    {
        print("接受消息出错" + socketAsyncEventArgs.SocketError);
        // 关闭客户端连接
        Close();
    }
}

// 处理接受消息 分包、黏包问题的方法
private void HandleReceiveMsg(int receiveNum)
{
    int msgID = 0;
    int msgLength = 0;
    int nowIndex = 0;

    cacheNum += receiveNum;

    while (true)
    {
        // 每次将长度设置为-1 是避免上一次解析的数据 影响这一次的判断
        msgLength = -1;
        // 处理解析一条消息
        if (cacheNum - nowIndex >= 8)
        {
            // 解析ID
            msgID = BitConverter.ToInt32(cacheBytes, nowIndex);
            nowIndex += 4;
            // 解析长度
            msgLength = BitConverter.ToInt32(cacheBytes, nowIndex);
            nowIndex += 4;
        }

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
            }
            if (baseMessage != null)
                receiveQueue.Enqueue(baseMessage);
            nowIndex += msgLength;
            if (nowIndex == cacheNum)
            {
                cacheNum = 0;
                break;
            }
        }
        else
        {
            if (msgLength != -1)
                nowIndex -= 8;
            // 就是把剩余没有解析的字节数组内容 移到前面来 用于缓存下次继续解析
            Array.Copy(cacheBytes, nowIndex, cacheBytes, 0, cacheNum - nowIndex);
            cacheNum = cacheNum - nowIndex;
            break;
        }
    }

}

void Update()
{
    if (receiveQueue.Count > 0)
    {
        BaseMessage baseMessage = receiveQueue.Dequeue();
        switch (baseMessage)
        {
            case PlayerMessage msg:
                print(msg.playerID);
                print(msg.playerData.name);
                print(msg.playerData.lev);
                print(msg.playerData.atk);
                break;
        }
    }
}
```

#### 在客户端进行发消息测试
![[Lesson13 2.cs]]
```cs
public InputField InputField;
public Button sendButton;
public Button nianSendButton;
public Button fenSendButton;
public Button fenNiansendButton;
void Start()
{
    TcpNetAsyncManager.Instance.Connect("127.0.0.1", 8080);

    sendButton.onClick.AddListener(() =>
    {
        PlayerMessage PlayerMessage = new PlayerMessage();
        PlayerMessage.playerID = 1111;
        PlayerMessage.playerData = new PlayerData();
        PlayerMessage.playerData.name = "韬老狮客户端发送的信息";
        PlayerMessage.playerData.atk = 22;
        PlayerMessage.playerData.lev = 10;
        TcpNetAsyncManager.Instance.Send(PlayerMessage);
    });

    // 黏包测试
    nianSendButton.onClick.AddListener(() =>
    {
        PlayerMessage PlayerMessage1 = new PlayerMessage();
        PlayerMessage1.playerID = 1001;
        PlayerMessage1.playerData = new PlayerData();
        PlayerMessage1.playerData.name = "韬老狮1";
        PlayerMessage1.playerData.atk = 1;
        PlayerMessage1.playerData.lev = 1;

        PlayerMessage PlayerMessage2 = new PlayerMessage();
        PlayerMessage2.playerID = 1002;
        PlayerMessage2.playerData = new PlayerData();
        PlayerMessage2.playerData.name = "韬老狮2";
        PlayerMessage2.playerData.atk = 2;
        PlayerMessage2.playerData.lev = 2;
        // 黏包
        byte[] bytes = new byte[PlayerMessage1.GetBytesNum() + PlayerMessage2.GetBytesNum()];
        PlayerMessage1.Writing().CopyTo(bytes, 0);
        PlayerMessage2.Writing().CopyTo(bytes, PlayerMessage1.GetBytesNum());
        TcpNetAsyncManager.Instance.SendTest(bytes);
    });

    // 分包测试
    fenSendButton.onClick.AddListener(async () =>
    {
        PlayerMessage playerMessage = new PlayerMessage();
        playerMessage.playerID = 1003;
        playerMessage.playerData = new PlayerData();
        playerMessage.playerData.name = "韬老狮1";
        playerMessage.playerData.atk = 3;
        playerMessage.playerData.lev = 3;

        byte[] bytes = playerMessage.Writing();
        // 分包
        byte[] bytes1 = new byte[10];
        byte[] bytes2 = new byte[bytes.Length - 10];
        // 分成第一个包
        Array.Copy(bytes, 0, bytes1, 0, 10);
        // 第二个包
        Array.Copy(bytes, 10, bytes2, 0, bytes.Length - 10);

        TcpNetAsyncManager.Instance.SendTest(bytes1);
        await Task.Delay(500);
        TcpNetAsyncManager.Instance.SendTest(bytes2);
    });

    // 分包、黏包测试
    fenNiansendButton.onClick(async () =>
    {
        PlayerMessage playerMessage1 = new PlayerMessage();
        playerMessage1.playerID = 1001;
        playerMessage1.playerData = new PlayerData();
        playerMessage1.playerData.name = "韬老狮1";
        playerMessage1.playerData.atk = 1;
        playerMessage1.playerData.lev = 1;

        PlayerMessage playerMessage2 = new PlayerMessage();
        playerMessage2.playerID = 1002;
        playerMessage2.playerData = new PlayerData();
        playerMessage2.playerData.name = "韬老狮2";
        playerMessage2.playerData.atk = 2;
        playerMessage2.playerData.lev = 2;

        byte[] bytes1 = playerMessage1.Writing(); // 消息A
        byte[] bytes2 = playerMessage2.Writing(); // 消息B

        byte[] bytes2_1 = new byte[10];
        byte[] bytes2_2 = new byte[bytes2.Length - 10];
        // 分成第一个包
        Array.Copy(bytes2, 0, bytes2_1, 0, 10);
        // 第二个包
        Array.Copy(bytes2, 10, bytes2_2, 0, bytes2.Length - 10);

        // 消息A和消息B前一段的 黏包
        byte[] bytes = new byte[bytes1.Length + bytes2_1.Length];
        bytes1.CopyTo(bytes, 0);
        bytes2_1.CopyTo(bytes, bytes1.Length);

        TcpNetAsyncManager.Instance.SendTest(bytes);
        await Task.Delay(500);
        TcpNetAsyncManager.Instance.SendTest(bytes2_2);
    });
}
```