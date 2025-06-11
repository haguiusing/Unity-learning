![[Lesson9 1.cs]]

### 什么是分包、黏包？
- 分包、黏包指在网络通信中由于各种因素（网络环境、API规则等）造成的消息与消息之间出现的两种状态。
- 分包：一个消息分成了多个消息进行发送。
- 黏包：一个消息和另一个消息黏在了一起。

注意：分包和黏包可能同时发生。
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/24.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E5%90%8C%E6%AD%A5-%E5%88%86%E5%8C%85%E9%BB%8F%E5%8C%85-%E5%9F%BA%E6%9C%AC%E5%AE%9E%E7%8E%B0/1.png)

### 如何解决分包、黏包的问题？
现在的处理：  
我们收到的消息都是以字节数组的形式在程序中体现。  
目前我们的处理规则是默认传过来的消息就是正常情况。  
前4个字节是消息ID。  
后面的字节数组全部用来反序列化。  
如果出现分包、黏包会导致我们反序列化报错。

思考：  
那么通过接收到的字节数组我们应该如何判断收到的字节数组处于以下状态：
1. 正常
2. 分包
3. 黏包

突破点：  
如何判断一个消息没有出现分包或者黏包呢？  
答案——>消息长度。  
![[Pasted image 20250606232515.png]]
我们可以如同处理”区分消息类型”的逻辑一样。  
为消息添加头部，头部记录消息的长度。  
当我们接收到消息时，通过消息长度来判断是否分包、黏包。  
对消息进行拆分处理、合并处理。  
我们每次只处理完整的消息。

### 实践分包黏包
#### 为所有消息添加头部信息，用于存储其消息长度，修改PlayerMessage的获取字节数组长度和写入逻辑
![[TCP同步区分消息类型#^441e46]]
```cs
public override int GetBytesNum()
{
    return 
        4 + //消息ID的长度
        4 + //消息体的长度
        4 + //playerID的字节数组长度
        playerData.GetBytesNum(); //playerData的字节数组长度
}

public override byte[] Writing()
{
    int index = 0;

    int bytesNum = GetBytesNum();

    byte[] bytes = new byte[bytesNum];
    //先写消息ID
    WriteInt(bytes, GetID(), ref index);

    //写入消息体的长度 我们bytesNum-8的目的是取出前8个字节 是只存储消息体的长度 前面8个字节是消息ID和长度 是我们自己定的规则 解析时按照这个规则处理就行了
    WriteInt(bytes, bytesNum - 8, ref index);

    //写这个消息的成员变量
    WriteInt(bytes, playerID, ref index);
    WriteData(bytes, playerData, ref index);
    return bytes;
}
```

#### 根据分包、黏包的表现情况，修改TcpNetManager接收消息处的逻辑
![[NetMgr 2.cs]]
##### 定义处理分包时的缓存数组和缓存数组长度，注释之前的字节数组和字节数组长度
```cs
//private byte[] receiveBytes = new byte[1024 * 1024]; // 创建一个字节数组，用于存储接收到的数据
//private int receiveNum; // 用于存储接收到的字节数

//用于处理分包时 缓存的 字节数组 和 字节数组长度
private byte[] cacheBytes = new byte[1024 * 1024];
private int cacheNum = 0;
```
##### 在接收消息方法中，改用临时的字节数组和字节数组长度，注释掉之前直接解析消息ID再解析消息体的逻辑，改用一个函数传入临时的字节数组和字节数组长度处理接受消息 分包、黏包问题
```cs
// 在独立线程中处理接收消息的逻辑
private void ReceiveMsg(object obj)
{
    while (isConnected) // 只要连接有效
    {
        if (socket.Available > 0) // 如果有可接收的数据
        {
            //临时字节数组
            byte[] receiveBytes = new byte[1024 * 1024];

            // 接收从服务器发送来的数据，并将数据转换成字符串后存储到接收消息队列 得到字节数组长度
            int receiveNum = socket.Receive(receiveBytes);

            //处理接受消息 分包、黏包问题
            HandleReceiveMsg(receiveBytes, receiveNum);

            ////首先把收到字节数组的前4个字节  读取出来得到ID
            //int msgID = BitConverter.ToInt32(receiveBytes, 0);
            //BaseMessage baseMessage = null;
            //switch (msgID)
            //{
            //    case 1001:
            //        PlayerMessage playerMessage = new PlayerMessage();
            //        playerMessage.Reading(receiveBytes, 4);
            //        baseMessage = playerMessage;
            //        break;
            //}
            ////如果消息为空 那证明是不知道类型的消息 没有解析
            //if (baseMessage == null)
            //    continue;
            ////收到消息 解析消息为字符串 并放入公共容器
            //receiveQueue.Enqueue(baseMessage);
        }
    }
}
```
##### 在分包黏包处理函数中，首先，定义了三个整数变量，分别用于存储消息ID (msgID), 消息长度 (msgLength) 和当前消息解析位置 (nowIndex)。接下来，将新接收到的字节数组 (receiveBytes) 拼接到缓存数组 (cacheBytes) 的尾部，同时更新缓存长度 (cacheNum)，这是为了处理分包的情况。进入一个循环 (while (true))，用于不断尝试解析消息。在每次循环开始前，将消息长度 (msgLength) 初始化为-1，以确保上一次解析的数据不会影响当前的解析。如果缓存数组中剩余的字节长度大于等于8，尝试解析消息ID和消息长度。解析后，更新消息解析位置 (nowIndex)。如果消息长度 (msgLength) 不为-1，且缓存中剩余的字节长度大于等于消息长度，那么说明可以解析消息体。解析消息体，根据消息ID选择正确的消息类型（在此例中是1001，即 PlayerMessage），进行消息体的解析。如果成功解析了消息体，将该消息加入接收队列 (receiveQueue)。更新消息解析位置 (nowIndex)，加上消息体的长度，以准备解析下一条消息。如果刚好解析完当前缓存中的所有内容，表示当前包没有黏包，重置缓存 (cacheNum = 0) 并退出循环，解析结束。如果不满足解析条件，表明存在分包的情况，需要将当前接收的内容记录下来，以便在下次接收到消息后继续处理。如果已经解析了消息ID和消息长度，但没有成功解析消息体，需要减去消息解析位置的偏移，以便保留完整的消息ID和消息长度。使用 Array.Copy 方法，将剩余未解析的字节数组内容移到缓存数组的开头，用于缓存下次继续解析。最后，更新缓存的长度 (cacheNum)，减去已解析的部分，以便在下次继续解析时正确处理未解析的内容。
```cs
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
                receiveQueue.Enqueue(baseMessage);

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

### 总结
处理分包、黏包问题首先要了解什么是分包和黏包。  
解决该问题的逻辑实现的写法可能有很多种，采用最节约性能的方式解决问题就行。