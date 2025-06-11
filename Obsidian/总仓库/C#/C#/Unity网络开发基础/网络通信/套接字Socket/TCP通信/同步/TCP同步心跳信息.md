![[HeartMsg 1.cs]]
![[Lesson11 1.cs]]

### 什么是心跳消息
所谓心跳消息，就是在长连接中，客户端和服务端之间定期发送的一种特殊的数据包，用于通知对方自己还在线，以确保长连接的有效性。由于其发送的时间间隔往往是固定的持续的，就像是心跳一样一直存在，所以我们称之为心跳消息。

### 为什么需要心跳消息
1. 避免非正常关闭客户端时，服务器无法正常收到关闭连接消息。通过心跳消息我们可以自定义超时判断，如果超时没有收到客户端消息，证明客户端已经断开连接。
    
2. 避免客户端长期不发送消息，防火墙或者路由器会断开连接，我们可以通过心跳消息一直保持活跃状态。

### 实现心跳消息
#### 主要功能
客户端：主要功能是定时发送消息。
服务器端：主要功能是不停检测上次收到某客户端消息的时间，如果超时则认为连接已经断开。

#### 定义心跳消息类
![[HeartMsg 2.cs]]
```cs
public class HeartMessage : BaseMessage
{
    public override int GetBytesNum()
    {
        // 需要存储 ID 和长度，两个 int，共 8 字节
        return 4 + 4;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        // 没有消息体，0 字节
        return 0;
    }

    public override byte[] Writing()
    {
        // 写入 ID 和长度到字节数组并返回
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteInt(bytes, GetID(), ref index);
        WriteInt(bytes, 0, ref index);
        return bytes;
    }

    public override int GetID()
    {
        return 999;
    }
}
```

#### TcpNetManager实现连接时每隔一段时间发送心跳消息
![[NetMgr 4.cs]]
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

private void SendHeartMsg()
{
    if (isConnected)
        Send(heartMessage);
}
```

#### 在服务端 ClientSocket 类定义上次心跳时间和超时时间
```cs
// 上一次收到消息的时间
private long frontTime = -1;
// 超时时间
private static int TIME_OUT_TIME = 10;
```

#### 在服务端 ClientSocket 类定义检查心跳是否超时的方法。可以在构造函数时就开一个线程每隔几秒检查一次，但是比较耗性能。可以在收消息的时候检查，但是也会每帧判断，可以自行加逻辑优化
```cs
public ClientSocket(Socket clientSocket)
{
    this.clientID = CLIENT_BEGIN_ID;  // 初始化客户端ID
    this.clientSocket = clientSocket;  // 初始化套接字
    ++CLIENT_BEGIN_ID;  // 为下一个客户端分配不同的ID

    //我们现在为了方便大家理解 所以开了一个线程专门计时 但是这种方式比较消耗性能 不建议这样使用
    //ThreadPool.QueueUserWorkItem(CheckTimeOut);
}

/// <summary>
/// 间隔一段时间 检测一次超时 如果超时 就会主动断开该客户端的连接
/// </summary>
/// <param name="obj"></param>
private void CheckTimeOut(/*object obj*/)
{
    //while (Connected)
    //{
    if (frontTime != -1 &&
    DateTime.Now.Ticks / TimeSpan.TicksPerSecond - frontTime >= TIME_OUT_TIME)
    {
        Program.serverSocket.AddDelSocket(this);
        //break;
    }
    //Thread.Sleep(5000);
    //}
}

// 接收来自客户端的消息
public void Receive()
{
    if (!isClientConnected)
    {
            ...
    }
        
    try
    {
        if (clientSocket.Available > 0)// 如果套接字中有可读数据
        {
                ...
        }

        //检测 是否超时 
        CheckTimeOut();
    }
    catch (Exception e)
    {
            ...
    }
}
```

#### 在服务端 ClientSocket 类分包、黏包方法和处理消息方法中加上对心跳消息的处理

```cs
// 处理接受消息 分包、黏包问题的方法
private void HandleReceiveMsg(byte[] receiveBytes, int receiveNum)
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
                case 999:
                    baseMessage = new HeartMessage();
                    //由于该消息没有消息体 所以都不用反序列化
                    break;
            }

                ...
        }
        
        else
        {
            ...
        }
}


// 处理接收到的消息
private void HandleMessage(object obj)
{
    BaseMessage baseMessage = obj as BaseMessage;
    if (baseMessage is PlayerMessage)
    {
            .../
    }
    else if(baseMessage is QuitMessage)
    {
        ...
    }
    else if (baseMessage is HeartMessage)
    {
        //收到心跳消息 记录收到消息的时间
        frontTime = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
        Console.WriteLine("收到心跳消息");
    }
}
```

#### 为了测试心跳消息超时是否能检测生效，暂时把 TcpNetManager 断开发送退出消息的逻辑注释

```cs
// 关闭连接
public void Close()
{
    print("客户端主动断开连接");
    if (socket != null) // 如果套接字对象存在
    {
        ////主动发送一条断开的消息个服务端 
        //QuitMessage quitMessage = new QuitMessage();
        ////这里不能用我们封装的Send方法 因为Send方法是开一个线程发送的 可能还没发就直接被断开了
        //socket.Send(quitMessage.Writing());

        //socket.Shutdown(SocketShutdown.Both); // 关闭套接字的发送和接收

        //socket.Disconnect(false);//手动停止连接 参数意思是这个socket以后还用不用

        //socket.Close(); // 关闭套接字连接

        socket = null;//当前socket不会再用了 置空

        isConnected = false; // 标记连接已关闭
    }
}
```

#### 开启服务端和客户端后，关闭客户端等10秒可以检测到客户端断开连接
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/27.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%BF%83%E8%B7%B3%E6%B6%88%E6%81%AF-%E5%AE%9E%E7%8E%B0/1.png)

### 总结
心跳消息是长连接项目中必备的一套逻辑规则。通过它可以帮助我们在服务器端及时的释放掉失效的 socket，可以有效避免当客户端非正常关闭时，服务器端不能及时判断连接已断开。


除了使用 `InvokeRepeating` 来实现定时发送心跳消息的功能外，还可以使用以下几种方法来实现类似的功能：
### 1. **使用 Coroutine（协程）**
协程可以用来实现定时任务，通过 `yield return new WaitForSeconds` 来控制间隔时间。这种方式比 `InvokeRepeating` 更灵活，可以随时暂停或停止。
```cs
private int SEND_HEART_MSG_TIME = 2;
private HeartMsg hearMsg = new HeartMsg();

void Awake()
{
    instance = this;
    DontDestroyOnLoad(this.gameObject);
    StartCoroutine(SendHeartbeatRoutine());
}

private IEnumerator SendHeartbeatRoutine()
{
    while (true)
    {
        if (isConnected)
        {
            Send(hearMsg);
        }
        yield return new WaitForSeconds(SEND_HEART_MSG_TIME);
    }
}

public void Send(BaseMsg msg)
{
    sendMsgQueue.Enqueue(msg);
}
```

**优点：**
- 更灵活，可以通过条件判断随时停止或暂停协程。
- 可以在协程中执行更复杂的逻辑。
**缺点：**
- 如果不熟悉协程的使用，可能会导致代码逻辑复杂。

### 2. **使用 Timer 类（System.Threading.Timer）**
`System.Threading.Timer` 是一个线程安全的定时器，可以用来实现定时任务。这种方式适合需要高精度定时的场景。
```cs
using System.Threading;

private int SEND_HEART_MSG_TIME = 2000; // 时间单位为毫秒
private HeartMsg hearMsg = new HeartMsg();
private Timer heartbeatTimer;

void Awake()
{
    instance = this;
    DontDestroyOnLoad(this.gameObject);
    StartHeartbeatTimer();
}

private void StartHeartbeatTimer()
{
    heartbeatTimer = new Timer(SendHeartbeat, null, 0, SEND_HEART_MSG_TIME);
}

private void SendHeartbeat(object state)
{
    if (isConnected)
    {
        // 确保在主线程中调用 Send 方法
        StartCoroutine(SendHeartbeatCoroutine());
    }
}

private IEnumerator SendHeartbeatCoroutine()
{
    Send(hearMsg);
    yield return null;
}

public void Send(BaseMsg msg)
{
    sendMsgQueue.Enqueue(msg);
}

void OnDestroy()
{
    // 停止定时器
    heartbeatTimer?.Dispose();
}
```

**优点：**
- 精度高，适合需要高精度定时的场景。
- 可以在后台线程中运行，减少对主线程的干扰。

**缺点：**
- 需要确保在主线程中调用与Unity对象相关的操作（如更新UI或调用Unity API）。

### 3. **使用 Unity 的 Update 方法**
通过在 `Update` 方法中计算时间间隔，也可以实现定时发送心跳消息。这种方式简单直接，但精度较低。
```csharp
private int SEND_HEART_MSG_TIME = 2;
private float elapsedTime = 0;
private HeartMsg hearMsg = new HeartMsg();

void Awake()
{
    instance = this;
    DontDestroyOnLoad(this.gameObject);
}

void Update()
{
    elapsedTime += Time.deltaTime;

    if (elapsedTime >= SEND_HEART_MSG_TIME)
    {
        elapsedTime = 0; // 重置时间
        if (isConnected)
        {
            Send(hearMsg);
        }
    }
}

public void Send(BaseMsg msg)
{
    sendMsgQueue.Enqueue(msg);
}
```

**优点：**
- 实现简单，不需要额外的线程或协程。

**缺点：**
- 精度依赖于帧率，如果帧率不稳定，可能会导致时间间隔不准确。

### 4. **使用 Unity 的 StartCoroutine 和 WaitForSecondsRealtime**
如果需要在固定时间间隔内执行任务，即使游戏暂停也不受影响，可以使用 `WaitForSecondsRealtime`。
```csharp
private int SEND_HEART_MSG_TIME = 2;
private HeartMsg hearMsg = new HeartMsg();

void Awake()
{
    instance = this;
    DontDestroyOnLoad(this.gameObject);
    StartCoroutine(SendHeartbeatRoutine());
}

private IEnumerator SendHeartbeatRoutine()
{
    while (true)
    {
        if (isConnected)
        {
            Send(hearMsg);
        }
        yield return new WaitForSecondsRealtime(SEND_HEART_MSG_TIME);
    }
}

public void Send(BaseMsg msg)
{
    sendMsgQueue.Enqueue(msg);
}
```

**优点：**
- 即使游戏暂停，定时任务也会继续执行。

**缺点：**
- 如果游戏暂停时不需要发送心跳消息，这种方式可能不合适。

### 总结
- 如果需要高精度定时，可以选择 `System.Threading.Timer`。
- 如果需要灵活控制定时任务（如暂停、停止），可以选择协程。
- 如果追求简单实现，可以选择 `Update` 方法或 `InvokeRepeating`。
- 如果需要在游戏暂停时继续执行定时任务，可以选择 `WaitForSecondsRealtime`。