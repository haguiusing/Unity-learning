![[Lesson8.cs]]

### 如何发送之前的自定义类的二进制信息
- 继承 `BaseData` 类
- 实现其中的序列化、反序列化、获取字节数等相关方法
- 发送自定义类数据时，进行序列化
- 接收自定义类数据时，进行反序列化

#### 问题：当将序列化的二进制数据发送给对象时，对方如何区分？
举例：
- PlayerInfo: 玩家信息
- ChatInfo: 聊天信息
- LoginInfo: 登录信息
- 等等
这些数据对象序列化后是长度不同的字节数组。将它们发送给对象后，对方如何区分出它们分别是什么消息？如何选择对应的数据类反序列化它们？

### 如何区分消息类型
#### 解决方案：
为发送的信息添加标识，比如添加消息 ID。在所有发送的消息的头部加上消息 ID（可以是 int、short、byte、long，根据实际情况选择）。
#### 举例说明：
消息构成：
- 如果选用 int 类型作为消息 ID 的类型
- 前 4 个字节为消息 ID
- 后面的字节为数据类的内容

这样每次收到消息时，先把前 4 个字节取出来解析为消息 ID，再根据 ID 进行消息反序列化即可。

### 实践区分消息类型
#### 创建消息基类,基类继承BaseData,基类添加获取消息ID的方法或者属性
![[BaseData 1.cs]]

![[BaseMsg 1.cs]]
```cs
public class BaseMessage : BaseData
{
    public override int GetBytesNum()
    {
        throw new System.NotImplementedException();
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        throw new System.NotImplementedException();
    }

    public override byte[] Writing()
    {
        throw new System.NotImplementedException();
    }

    public virtual int GetID()
    {
        return 0;
    }
}
```
#### 让想要被发送的消息继承消息基类，实现序列化反序列化方法

![[PlayerData 1.cs]]
```cs
/// <summary>
/// 玩家数据类
/// </summary>
public class PlayerData : BaseData//0
{
    //1
    public string name;
    public int atk;
    public int lev;

    //2
    public override int GetBytesNum()
    {
        int num = 0;
        num += 4 + Encoding.UTF8.GetBytes(name).Length;//name
        num += 4;//atk
        num += 4;//lev
        return num;
    }

    //4
    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        int index = beginIndex;
        name = ReadString(bytes, ref index);
        atk = ReadInt(bytes, ref index);
        lev = ReadInt(bytes, ref index);
        return index - beginIndex;
    }

    //3
    public override byte[] Writing()
    {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteString(bytes, name, ref index);
        WriteInt(bytes, atk, ref index);
        WriteInt(bytes, lev, ref index);
        return bytes;
    }
}
```

![[PlayerMsg 1.cs]] ^441e46
```cs
public class PlayerMessage : BaseMessage
{
    //成员变量
    public int playerID;
    public PlayerData playerData;
    
    public override byte[] Writing()
    {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        //先写消息ID
        WriteInt(bytes, GetID(), ref index);
        //写这个消息的成员变量
        WriteInt(bytes, playerID, ref index);
        WriteData(bytes, playerData, ref index);
        return bytes;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        //反序列化不需要去解析ID 因为在这一步之前 就应该把ID反序列化出来
        //用来判断到底使用哪一个自定义类来反序化
        int index = beginIndex;
        playerID = ReadInt(bytes, ref index);
        playerData = ReadData<PlayerData>(bytes, ref index);
        return index - beginIndex;
    }

    public override int GetBytesNum()
    {
        return 4 + //消息ID的长度
                4 + //playerID的字节数组长度
                playerData.GetBytesNum();//playerData的字节数组长度
    }

    /// <summary>
    /// 自定义的消息ID 主要用于区分是哪一个消息类
    /// </summary>
    /// <returns></returns>
    public override int GetID()
    {
        return 1001;
    }
}
```

#### 修改客户端和服务端收发消息的逻辑
##### 服务端
![[TCP服务端基础实现#^3a4f9b]]
```cs
//发送
PlayerMessage playerMessage = new PlayerMessage();
playerMessage.playerID = 666;
playerMessage.playerData = new PlayerData();
playerMessage.playerData.name = "我是韬老狮的服务端";
playerMessage.playerData.atk = 99;
playerMessage.playerData.lev = 50;

socketClient.Send(playerMessage.Writing());

//发送字符串转成的字节数组给客户端
socketClient.Send(Encoding.UTF8.GetBytes("欢迎连入服务端"));
```
##### 客户端
![[TCP客户端基础实现#^e0e413]]
```cs
//接收数据 
//声明接收数据字节数组
byte[] receiveBytes = new byte[1024];
//Receive方法接受数据 返回接收多少字节
int receiveNum = socketTcp.Receive(receiveBytes);

//首先解析消息的ID
//使用字节数组中的前四个字节 得到ID
int msgID = BitConverter.ToInt32(receiveBytes, 0);
switch (msgID)
{
    case 1001:
        PlayerMessage playerMessage = new PlayerMessage();
        playerMessage.Reading(receiveBytes, 4);
        print(playerMessage.playerID);
        print(playerMessage.playerData.name);
        print(playerMessage.playerData.atk);
        print(playerMessage.playerData.lev);
        break;
}

//重新声明接收数据字节数组 接收字符串 服务端分了两次发 我们也要分两次接
receiveBytes = new byte[1024];
//Receive方法接受数据 返回接收多少字节
receiveNum = socketTcp.Receive(receiveBytes);
print("收到服务端发来的消息：" + Encoding.UTF8.GetString(receiveBytes, 0, receiveNum));
```

### 总结
区分消息的关键点是在数据字节数组头部加上消息 ID。只要前后端定义好统一的规则，通过 ID 就可以决定如何反序列化消息，并且可以决定应该如何处理该消息。