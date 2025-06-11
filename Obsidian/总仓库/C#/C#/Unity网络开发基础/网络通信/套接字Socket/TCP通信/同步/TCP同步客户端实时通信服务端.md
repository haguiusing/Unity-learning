![[Lesson7 2.cs]]
![[Main.cs]]
![[NetMgr 1.cs]]

### 使用Scoket客户端编程基础知识结合多线程，实现客户端的网络连接不会影响主线程且可以随时和服务端进行通信
#### 创建Tcp网络管理器，实现MonoBehaviour单例，定义一些成员变量
```cs
// 创建Tcp网络管理器，实现MonoBehaviour单例，定义一些成员变量
public class TcpNetManager: BaseSingletonInMonoBehaviour<TcpNetManager>
{
    private Socket socket; // 创建Socket对象，用于网络通信
    private Queue<string> sendMsgQueue = new Queue<string>(); // 创建一个队列，用于存储待发送的消息
    private Queue<string> receiveQueue = new Queue<string>(); // 创建一个队列，用于存储接收到的消息
    private byte[] receiveBytes = new byte[1024 * 1024]; // 创建一个字节数组，用于存储接收到的数据
    private int receiveNum; // 用于存储接收到的字节数
    private bool isConnected = false; // 用于标识是否已连接到服务器
}
```
#### 创建连接服务端和关闭连接方法，连接服务器时开启收发消息线程，销毁对象时确保关闭连接。
```cs
// 连接服务器
public void Connect(string ip, int port)
{
    if (isConnected) // 如果已连接，则直接返回
        return;

    if (socket == null) // 如果套接字为空，创建一个套接字对象
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port); // 创建一个IP终结点对象
    try
    {
        // 尝试连接到指定的IP地址和端口
        socket.Connect(ipPoint);
        isConnected = true; // 标记已连接
        ThreadPool.QueueUserWorkItem(SendMsg); // 创建并启动发送消息的线程
        ThreadPool.QueueUserWorkItem(ReceiveMsg); // 创建并启动接收消息的线程
    }
    catch (SocketException e)
    {
        if (e.ErrorCode == 10061) // 如果连接被服务器拒绝
            print("服务器拒绝连接");
        else
            print("连接失败" + e.ErrorCode + e.Message); // 打印连接失败的信息
    }
}

// 关闭连接
public void Close()
{
    if (socket != null) // 如果套接字对象存在
    {
        socket.Shutdown(SocketShutdown.Both); // 关闭套接字的发送和接收
        socket.Close(); // 关闭套接字连接
        isConnected = false; // 标记连接已关闭
    }
}

// 当对象被销毁时，确保关闭连接
private void OnDestroy()
{
    Close(); // 调用关闭连接的方法
}
```
#### 实现收发消息方法，分别把消息放到对列中每帧检测处理。
```cs
// 发送消息
public void Send(string info)
{
    sendMsgQueue.Enqueue(info); // 将消息添加到发送消息队列
}

// 在独立线程中处理发送消息的逻辑
private void SendMsg(object obj)
{
    while (isConnected) // 只要连接有效
    {
        if (sendMsgQueue.Count > 0) // 如果发送消息队列中有待发送的消息
        {
            // 从队列中取出消息并发送到服务器
            socket.Send(Encoding.UTF8.GetBytes(sendMsgQueue.Dequeue()));
        }
    }
}

// 在独立线程中处理接收消息的逻辑
private void ReceiveMsg(object obj)
{
    while (isConnected) // 只要连接有效
    {
        if (socket.Available > 0) // 如果有可接收的数据
        {
            // 接收从服务器发送来的数据，并将数据转换成字符串后存储到接收消息队列
            receiveNum = socket.Receive(receiveBytes);
            receiveQueue.Enqueue(Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));
        }
    }
}

void Update()
{
    // 在Unity的每一帧中检查是否有待处理的接收消息，如果有，则打印出来
    if (receiveQueue.Count > 0)
    {
        print(receiveQueue.Dequeue()); // 打印并移除接收队列中的消息
    }
}
```
#### 开启上节课写的服务端，连接服务端，定义按钮和输入框，进行通信测试
```cs
public InputField InputField;
public Button sendButton;

void Start()
{
    TcpNetManager.Instance.Connect("127.0.0.1", 8080);

    sendButton.onClick.AddListener(() =>
    {
        if (InputField.text != "")
            TcpNetManager.Instance.Send(InputField.text);
    });
}
```

![[Pasted image 20250606225538.png]]