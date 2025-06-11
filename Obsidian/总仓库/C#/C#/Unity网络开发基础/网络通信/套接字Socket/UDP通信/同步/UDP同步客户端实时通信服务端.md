### 如同TCP通信一样制作客户端网络通信模块，需要具备的功能有：
- 区分消息类型
- 发送消息
- 接受消息
- 判断如果不是服务端发送的消息不处理

#### 定义UdpNetManager类，实现继承Monobehaviour的单例。定义必要的变量。
![[UdpNetMgr.cs]]
```cs
public class UdpNetManager : BaseSingletonInMonoBehaviour<UdpNetManager>
{
    private EndPoint serverIpPoint; // 服务器的IP地址和端口信息

    private Socket socket; // 客户端Socket

    // 客户端socket是否关闭
    private bool isClose = true;

    // 两个消息队列：发送消息和接收消息，在多线程中可以操作
    private Queue<BaseMessage> sendQueue = new Queue<BaseMessage>();
    private Queue<BaseMessage> receiveQueue = new Queue<BaseMessage>();

    private byte[] cacheBytes = new byte[512]; // 用于缓存接收的字节数据
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
    // 如果当前是开启状态，就不用再开了
    if (!isClose)
        return;

    // 先记录服务器地址，一会发消息时会使用
    serverIpPoint = new IPEndPoint(IPAddress.Parse(ip), port);

    // 创建一个本地IP和端口，用于绑定客户端Socket
    IPEndPoint clientIpPort = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
    try
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(clientIpPort);
        isClose = false;
        print("客户端网络启动");
        // 启动消息接收和发送线程
        ThreadPool.QueueUserWorkItem(ReceiveMsg);
        ThreadPool.QueueUserWorkItem(SendMsg);
    }
    catch (System.Exception e)
    {
        print("启动Socket出问题" + e.Message);
    }
}

// 关闭socket
public void Close()
{
    if (socket != null)
    {
        isClose = true;
        QuitMessage quitMessage = new QuitMessage();
        // 发送一个退出消息给服务器，让其移除记录
        socket.SendTo(quitMessage.Writing(), serverIpPoint);
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
        socket = null;
    }
}

// 销毁时关闭socket
private void OnDestroy()
{
    Close();
}
```
#### 实现收发消息方法
```cs
// 接收消息的方法
private void ReceiveMsg(object obj)
{
    EndPoint tempIpPoint = new IPEndPoint(IPAddress.Any, 0);
    int nowIndex;
    int msgID;
    int msgLength;
    while (!isClose)
    {
        if (socket != null && socket.Available > 0)
        {
            try
            {
                socket.ReceiveFrom(cacheBytes, ref tempIpPoint);
                // 为了避免处理非服务器发来的骚扰消息
                if (!tempIpPoint.Equals(serverIpPoint))
                    continue; // 如果发现发消息给你的不是服务器，那么证明是骚扰消息，就不用处理

                // 处理服务器发来的消息
                nowIndex = 0;
                // 解析消息ID
                msgID = BitConverter.ToInt32(cacheBytes, nowIndex);
                nowIndex += 4;
                // 解析消息长度
                msgLength = BitConverter.ToInt32(cacheBytes, nowIndex);
                nowIndex += 4;
                // 解析消息体
                BaseMessage baseMessage = null;
                switch (msgID)
                {
                    case 1001:
                        baseMessage = new PlayerMessage();
                        // 反序列化消息体
                        baseMessage.Reading(cacheBytes, nowIndex);
                        break;
                }
                if (baseMessage != null)
                    receiveQueue.Enqueue(baseMessage);
            }
            catch (SocketException s)
            {
                print("接受消息出问题" + s.SocketErrorCode + s.Message);
            }
            catch (Exception e)
            {
                print("接受消息出问题(非网络问题)" + e.Message);
            }
        }
    }
}

// 每帧检查接收数组看看要不要接收消息
void Update()
{
    if (receiveQueue.Count > 0)
    {
        BaseMessage baseMessage = receiveQueue.Dequeue();
        switch (baseMessage)
        {
            case PlayerMessage playerMessage:
                print(playerMessage.playerID);
                print(playerMessage.playerData.name);
                print(playerMessage.playerData.atk);
                print(playerMessage.playerData.lev);
                break;
        }
    }
}

// 发送消息的方法
private void SendMsg(object obj)
{
    while (!isClose)
    {
        if (socket != null && sendQueue.Count > 0)
        {
            try
            {
                socket.SendTo(sendQueue.Dequeue().Writing(), serverIpPoint);
            }
            catch (SocketException s)
            {
                print("发送消息出错" + s.SocketErrorCode + s.Message);
            }
        }
    }
}

// 发送消息到服务器
public void Send(BaseMessage baseMessage)
{
    sendQueue.Enqueue(baseMessage);
}
```

#### 客户端入口连接服务端，并定义发消息测试按钮
![[Lesson15 1.cs]]
```cs
public InputField InputField;
public Button sendButton;

void Start()
{
    UdpNetManager.Instance.StartClient("127.0.0.1", 8080);

    sendButton.onClick.AddListener(() =>
    {
        PlayerMessage playerMessage = new PlayerMessage();
        playerMessage.playerData = new PlayerData();
        playerMessage.playerID = 1;
        playerMessage.playerData.name = "韬老狮的客户端发的消息";
        playerMessage.playerData.atk = 888;
        playerMessage.playerData.lev = 666;
        UdpNetManager.Instance.Send(playerMessage);
    });
}
```
![[MainUdp.cs]]

#### 开启UDP服务端和客户端进行测试
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/36.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-UDP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%AE%A2%E6%88%B7%E7%AB%AF%E7%BB%BC%E5%90%88%E7%BB%83%E4%B9%A0%E9%A2%98/1.png)