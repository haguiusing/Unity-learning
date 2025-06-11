### 修改服务端的ClientSocket类接收消息的逻辑，注释之前的逻辑，把TcpNetManager处理分包、黏包的方法拷贝过来，定义相同的缓存数组和长度。注意客户端消息入队的逻辑要改成开线程用函数处理的方式。在接收函数中调用处理分包、黏包的方法。
![[ClientSocket 2.cs]]
```cs
//用于处理分包时 缓存的 字节数组 和 字节数组长度
private byte[] cacheBytes = new byte[1024 * 1024];
private int cacheNum = 0;

// 接收来自客户端的消息
public void Receive()
{
    if (clientSocket == null)
        return;
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
        Close(); // 如果接收出现异常，关闭套接字连接
    }
}

// 处理接受消息 分包、黏包问题的方法
private void HandleReceiveMsg(byte[] receiveBytes, int receiveNum)
{
    int msgID = 0;       // 消息ID
    int msgLength = 0;   // 消息长度
    int nowIndex = 0;    // 当前消息解析到哪一位

    // 当接收到消息时，检查是否有之前缓存的数据
    // 如果有，说明有分包，将新收到的字节数组拼接到后面，数组长度加上缓存长度
    // 如果没有，缓存数组是空数组，缓存长度是0，不影响后面的逻辑
    receiveBytes.CopyTo(cacheBytes, cacheNum);
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
            // 解析消息体
            BaseMessage baseMessage = null;
            switch (msgID)
            {
                case 1001:
                    PlayerMessage playerMessage = new PlayerMessage();
                    playerMessage.Reading(cacheBytes, nowIndex);
                    baseMessage = playerMessage;
                    break;
            }

            // 如果成功解析了消息体，将消息加入接收队列
            if (baseMessage != null)
                //receiveQueue.Enqueue(baseMessage);
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
```

### 注意上节课修改了PlayerMessage的获取消息长度的逻辑，要重新拷贝客户端的PlayerMessage到服务端
![[PlayerMsg 2.cs]]
### 服务端入口添加接受和广播逻辑
![[Program 4.cs]]
```cs
internal class Program
{
    static void Main(string[] args)
    {
        // 创建一个ServerSocket对象，用于处理服务器端的操作
        ServerSocket serverSocket = new ServerSocket();

        // 启动服务器，绑定到本地IP地址 127.0.0.1，监听端口 8080，允许最大连接数为 1024
        serverSocket.Start("127.0.0.1", 8080, 1024);

        // 输出服务器开启成功的消息
        Console.WriteLine("服务器开启成功");

        while (true)
        {
            // 从控制台读取用户输入
            string input = Console.ReadLine();

            // 如果用户输入 "Quit"，则关闭服务器
            if (input == "Quit")
            {
                serverSocket.Close();
            }
            // 如果用户输入以 "B:" 开头，表示要广播消息给所有客户端
            else if (input.Substring(0, 2) == "B:")
            {
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
    }
}
```

### 客户端TcpNetManager定义直接发送字节数组的测试方法
```cs
/// <summary>
/// 用于测试直接发送字节数组的方法
/// </summary>
/// <param name="bytes"></param>
public void SendTest(byte[] bytes)
{
    socket.Send(bytes);
}
```

### 在场景中添加黏包、分包、分包黏包的按钮绑定脚本
```cs
// 黏包测试
nianSendButton.onClick.AddListener(() =>
{
    PlayerMessage playerMessage1 = new PlayerMessage();
    playerMessage1.playerID = 1001;
    playerMessage1.playerData = new PlayerData();
    playerMessage1.playerData.name = "韬老狮1";
    playerMessage1.playerData.atk = 1;
    playerMessage1.playerData.lev = 1;

    PlayerMessage payerMessage = new PlayerMessage();
    payerMessage.playerID = 1002;
    payerMessage.playerData = new PlayerData();
    payerMessage.playerData.name = "韬老狮2";
    payerMessage.playerData.atk = 2;
    payerMessage.playerData.lev = 2;

    // 黏包，把两个对象的字节数组合并在一起发送
    byte[] bytes = new byte[playerMessage1.GetBytesNum() + payerMessage.GetBytesNum()];
    playerMessage1.Writing().CopyTo(bytes, 0);
    payerMessage.Writing().CopyTo(bytes, playerMessage1.GetBytesNum());
    TcpNetManager.Instance.SendTest(bytes);
});

// 分包测试，使用异步函数
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

    TcpNetManager.Instance.SendTest(bytes1);
    await Task.Delay(500); // 延迟执行半秒进行分包
    TcpNetManager.Instance.SendTest(bytes2);
});

// 分包、黏包测试
fenNiansendButton.onClick.AddListener(async () =>
{
    PlayerMessage playerMessage = new PlayerMessage();
    playerMessage.playerID = 1004;
    playerMessage.playerData = new PlayerData();
    playerMessage.playerData.name = "韬老狮1";
    playerMessage.playerData.atk = 4;
    playerMessage.playerData.lev = 4;

    PlayerMessage playerMessage2 = new PlayerMessage();
    playerMessage2.playerID = 1005;
    playerMessage2.playerData = new PlayerData();
    playerMessage2.playerData.name = "韬老狮2";
    playerMessage2.playerData.atk = 5;
    playerMessage2.playerData.lev = 5;

    byte[] bytes1 = playerMessage.Writing(); // 消息A
    byte[] bytes2 = playerMessage2.Writing(); // 消息B

    byte[] bytes2_1 = new byte[10];
    byte[] bytes2_2 = new byte[bytes2.Length - 10];
    // 分成第一个包
    Array.Copy(bytes2, 0, bytes2_1, 0, 10);
    // 第二个包
    Array.Copy(bytes2, 10, bytes2_2, 0, bytes2.Length - 10);

    // 消息A和消息B前一段的黏包
    byte[] bytes1_2 = new byte[bytes1.Length + bytes2_1.Length];
    bytes1.CopyTo(bytes1_2, 0);
    bytes2_1.CopyTo(bytes1_2, bytes1.Length);

    TcpNetManager.Instance.SendTest(bytes1_2);
    await Task.Delay(500);
    TcpNetManager.Instance.SendTest(bytes2_2);
});
```

### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/25.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%88%86%E5%8C%85%E9%BB%8F%E5%8C%85-%E6%B5%8B%E8%AF%95/1.png)