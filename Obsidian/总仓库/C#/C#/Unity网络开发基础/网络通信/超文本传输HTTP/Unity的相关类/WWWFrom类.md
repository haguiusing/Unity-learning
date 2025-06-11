![[Lesson29.cs]]

### WWWFrom 类的作用
- **作用**：在使用 `WWW` 类下载数据的基础上，如果需要上传数据，则需要结合 `WWWFrom` 类使用。`WWWFrom` 主要用于集成数据，可以设置上传的参数或者二进制数据。在结合 `WWWFrom` 上传数据时，主要使用的请求类型是 `Post`，使用 `Http` 协议进行上传处理。
- **注意**：  
    使用 `WWW` 结合 `WWWFrom` 上传数据通常需要与后端程序制定上传规则。

### WWWFrom 类的常用方法和变量
- 主要使用方法，相关变量很少使用，重点讲解方法。
#### WWWForm 构造函数
```cs
//1.WWWForm：构造函数
WWWForm wWWForm = new WWWForm();
```
#### WWWForm.AddBinaryData 添加二进制数据
```cs
//2.AddBinaryData：添加二进制数据
wWWForm.AddBinaryData()
```
#### WWWForm.AddField 添加字段
```cs
//3.AddField：添加字段
wWWForm.AddField()
```
### WWW 结合 WWWFrom 对象来异步上传数据
```cs
IEnumerator UpLoadData()
{
    WWWForm wWWForm = new WWWForm();

    //上传的数据 对应的后端程序 必须要有处理的规则 才能生效

    //比如写入一些字段 比如字符串 年龄 图片二进制数据
    wWWForm.AddField("Name", "MrTao", Encoding.UTF8);
    wWWForm.AddField("Age", 99);
    //传入 字段 字节数组 上传后的文件名 媒体类型
    wWWForm.AddBinaryData("file", File.ReadAllBytes(Application.streamingAssetsPath + "/test.png"), "testtest.png", "application/octet-stream");

    WWW www = new WWW("http://192.168.1.101:8000/HTTPRoot/", wWWForm);

    yield return www;

    if (www.error == null)
    {
        print("上传成功");
        //上传成功可以打印内容
        //www.bytes
    }
    else
        print("上传失败" + www.error);
}

StartCoroutine(UpLoadData());
```

![[Pasted image 20250607220608.png]]

### 总结
- 使用 `WWW` 结合 `WWWFrom` 上传数据需要与后端服务器配合指定上传规则。
- 上传的数据需要后端知道如何处理。
- 该方式适用于制作短连接游戏的前端网络层，可以对 `WWW` 进行二次封装，用于上传自定义消息给对应的 Web 服务器。

### 在NetWWW管理器中封装发送HTTP消息的方法，方法可以传入TCP知识当中封装的BaseMessage对象，我们假设，服务器返回的内容为字节数组,该字节数组同样也是遵循客户端规则的继承自BaseMessage的对象

![[NetWWWMgr.cs]]
![[Lesson28E_Test.cs]]
#### 定义服务器所在路径，封装异步发送信息的协程方法
```cs
private string HTTP_SERVER_PATH = "http://192.168.1.101:8000/HTTPRoot/";

/// <summary>
/// 通过协程异步发送消息，并等待响应。
/// </summary>
/// <typeparam name="T">消息类型的泛型参数，必须是BaseMsg的派生类。</typeparam>
/// <param name="BaseMessage">要发送的消息对象。</param>
/// <param name="action">消息发送成功后要执行的动作。</param>
private IEnumerator SendMessageAsync<T>(BaseMessage BaseMessage, UnityAction<T> action) where T : BaseMessage
{
    // 创建一个WWWForm来准备要发送的消息数据
    WWWForm wWWForm = new WWWForm();

    // 将消息数据以二进制形式添加到WWWForm中
    wWWForm.AddBinaryData("BaseMessage", BaseMessage.Writing());

    // 创建一个WWW对象并发送消息到HTTP服务器
    WWW www = new WWW(HTTP_SERVER_PATH, wWWForm);

    // 等待异步操作完成，即等待消息发送结束
    yield return www;

    // 检查是否有错误发生
    if (www.error == null)
    {
        // 解析从服务器返回的消息，提取消息ID和消息长度
        int index = 0;
        int msgID = BitConverter.ToInt32(www.bytes, index);
        index += 4;
        int msgLength = BitConverter.ToInt32(www.bytes, index);
        index += 4;

        // 根据消息ID反序列化消息
        BaseMessage baseMessage = null;
        switch (msgID)
        {
            case 1001:
                baseMessage = new PlayerMessage();
                baseMessage.Reading(www.bytes, index);
                break;
        }

        // 调用指定的动作，并将反序列化后的消息作为泛型参数传递
        if (baseMessage != null)
            action?.Invoke(baseMessage as T);
    }
    else
    {
        // 输出错误信息
        Debug.LogError("发消息出问题" + www.error);
    }
}
```

#### 封装给外部使用发送信息的方法
```cs
/// <summary>
/// 发送消息的通用方法，通过协程异步发送消息并在接收响应后执行指定的动作。
/// </summary>
/// <typeparam name="T">消息类型的泛型参数，必须是BaseMsg的派生类。</typeparam>
/// <param name="baseMessage">要发送的消息对象。</param>
/// <param name="action">消息发送成功后要执行的动作。</param>
public void SendMessage<T>(BaseMessage baseMessage, UnityAction<T> action) where T : BaseMessage
{
    // 启动协程异步发送消息
    StartCoroutine(SendMessageAsync<T>(baseMessage, action));
}
```