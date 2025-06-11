![[Lesson32.cs]]

### UnityWebRequest类高级操作指什么？
- 在常用操作中我们使用的是Unity为我们封装好的一些方法，我们可以方便的进行一些指定类型的数据获取。
    - 比如下载数据时：
        - 文本和2进制
        - 图片
        - AB包
        - 如果我们想要获取其它类型的数据应该如何处理呢？
    - 上传数据时：
        - 可以指定参数和值
        - 可以上传文件
        - 如果想要上传一些基于HTTP规则的其它数据应该如何处理呢？
- 高级操作就是用来处理常用操作不能完成的需求。
    - 它的核心思想就是：UnityWebRequest中可以将数据处理分离开。
        - 比如常规操作中我们用到的DownloadHandlerTexture 和 DownloadHandlerAssetBundle两个类就是用来将2进制字节数组转换成对应类型进行处理的。
    - 所以高级操作时指 让你按照规则来实现更多的数据获取、上传等功能。

### UnityWebRequest类的更多内容
#### 目前已学的内容
##### UnityWebRequest.Get 获取文本或二进制
```cs
// 创建一个用于发送 GET 请求的 UnityWebRequest 对象（需要提供一个 URL）。
// UnityWebRequest unityWebRequest = UnityWebRequest.Get("");
```
##### UnityWebRequest.GetTexture 获取文本或二进制 获取纹理
```cs
// 创建一个用于下载纹理的 UnityWebRequest 对象（需要提供一个纹理的 URL）。
// UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture("");
```
##### UnityWebRequestAssetBundle.GetAssetBundle 获取 AssetBundle
```cs
// 创建一个用于下载 AssetBundle 的 UnityWebRequest 对象（需要提供一个 URL）。
// UnityWebRequest unityWebRequest = UnityWebRequestAssetBundle.GetAssetBundle("");
```
##### UnityWebRequest.Put PUT上传
```cs
// 创建一个用于发送 PUT 请求的 UnityWebRequest 对象（需要提供一个 URL）。
// UnityWebRequest unityWebRequest = UnityWebRequest.Put();
```
##### UnityWebRequest.Post POST上传
```cs
// 创建一个用于发送 POST 请求的 UnityWebRequest 对象（需要提供一个 URL）。
// UnityWebRequest unityWebRequest = UnityWebRequest.Post();
```
##### UnityWebRequest.isDone 检查操作是否完成
```cs
// 检查 UnityWebRequest 操作是否完成。
// bool isDone = unityWebRequest.isDone;
```
##### UnityWebRequest.downloadProgress 下载进度
```cs
// 获取 UnityWebRequest 的下载进度（0.0 到 1.0）。
// float downloadProgress = unityWebRequest.downloadProgress;
```
##### UnityWebRequest.downloadedBytes 已下载的字节数
```cs
// 获取已下载的字节数。
// long downloadedBytes = unityWebRequest.downloadedBytes;
```
##### UnityWebRequest.uploadProgress 上传进度
```cs
// 获取 UnityWebRequest 的上传进度（0.0 到 1.0）。
// float uploadProgress = unityWebRequest.uploadProgress;
```
##### UnityWebRequest.uploadedBytes 获取已上传的字节数
```cs
// 获取已上传的字节数。
// long uploadedBytes = unityWebRequest.uploadedBytes;
```
##### UnityWebRequest.SendWebRequest 发送请求操作
```cs
// 发送 UnityWebRequest 并开始请求操作。
// unityWebRequest.SendWebRequest();
```

#### 更多高级内容
##### UnityWebRequest 构造函数
```cs
// 构造函数
// UnityWebRequest unityWebRequest = new UnityWebRequest();
```
##### UnityWebRequest.url 设置请求地址
```cs
// 请求地址
// unityWebRequest.url = "服务器地址";
```
##### UnityWebRequest.method 设置请求类型
```cs
// 请求类型
// unityWebRequest.method = UnityWebRequest.kHttpVerbPOST;
```
##### UnityWebRequest.downloadProgress 下载进度
```cs
// 进度
// unityWebRequest.downloadProgress
```
##### UnityWebRequest.uploadProgress 上传进度
```cs
// 进度
// unityWebRequest.uploadProgress
```
##### UnityWebRequest.timeout 设置超时时间
```cs
// 超时设置
// unityWebRequest.timeout = 2000;
```
##### UnityWebRequest.downloadedBytes 下载字节数
```cs
// 下载的字节数
// unityWebRequest.downloadedBytes
```
##### UnityWebRequest.uploadedBytes 上传的字节数
```cs
// 上传的字节数
// unityWebRequest.uploadedBytes
```
##### UnityWebRequest.redirectLimit 设置重定向次数
```cs
// 重定向次数 设置为0表示不进行重定向 可以设置次数
// unityWebRequest.redirectLimit = 10;
```
##### UnityWebRequest.responseCode 状态码
```cs
// 状态码
// unityWebRequest.responseCode
```
##### UnityWebRequest.result 结果
```cs
// 结果
// unityWebRequest.result
```
##### UnityWebRequest.error 错误内容
```cs
// 错误内容
// unityWebRequest.error
```
##### UnityWebRequest.downloadHandler 下载处理对象
```cs
// 下载处理对象
// unityWebRequest.downloadHandler
```
##### UnityWebRequest.uploadHandler 上传处理对象
```cs
// 上传处理对象
// unityWebRequest.uploadHandler
```

#### 更多详细内容参考官方API
[https://docs.unity.cn/cn/2020.3/ScriptReference/Networking.UnityWebRequest.html](https://docs.unity.cn/cn/2020.3/ScriptReference/Networking.UnityWebRequest.html)

### 自定义获取数据DownloadHandler相关类
#### DownloadHandlerBuffer下载字节数组
```cs
// 协程函数用于下载数据并保存到字节数组中
IEnumerator DownloadHandlerBuffer()
{
    // 创建一个 UnityWebRequest 对象，指定要下载的 URL 和请求方法（GET）。
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbGET);

    // 创建一个 DownloadHandlerBuffer 对象，用于保存下载的数据。
    DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();

    // 将 DownloadHandlerBuffer 对象设置为 UnityWebRequest 的下载处理器。
    unityWebRequest.downloadHandler = downloadHandlerBuffer;

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 下载成功，获取下载的字节数组。
        byte[] downloadedData = downloadHandlerBuffer.data;
        // 现在可以使用 downloadedData 这个字节数组。
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerBuffer 下载得到对应的2进制数据并保存到字节数组中。
StartCoroutine(DownloadHandlerBuffer());
```

#### DownloadHandlerFile下载文件
```cs
// 协程函数用于下载文件并保存到本地
IEnumerator DownloadHandlerFile()
{
    // 创建一个 UnityWebRequest 对象，指定要下载的 URL 和请求方法（GET）。
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbGET);

    // 输出应用程序的持久数据路径，用于确定下载文件的保存位置。
    print(Application.persistentDataPath);

    // 创建一个 DownloadHandlerFile 对象，用于将下载的数据保存为文件。
    unityWebRequest.downloadHandler = new DownloadHandlerFile(Application.persistentDataPath + "/DownloadHandlerFile.png");

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 下载成功，可以在本地应用程序数据路径中找到下载的文件。
        // 此时，已经将文件保存在 Application.persistentDataPath + "/DownloadHandlerFile.png"。
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerFile 下载文件并将文件保存到本地磁盘（内存占用少）
StartCoroutine(DownloadHandlerFile());
```
#### DownloadHandlerTexture下载图像
```cs
// 协程函数用于下载图像文件并显示在 RawImage 控件中
IEnumerator DownloadHandlerTexture()
{
    // 创建一个 UnityWebRequest 对象，指定要下载的图像 URL 和请求方法（GET）。
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbGET);

    // 创建一个 DownloadHandlerTexture 对象，用于处理下载的图像数据。
    DownloadHandlerTexture downloadHandlerTexture = new DownloadHandlerTexture();

    // 将 DownloadHandlerTexture 对象设置为 UnityWebRequest 的下载处理器。
    unityWebRequest.downloadHandler = downloadHandlerTexture;

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 下载成功，将下载的图像显示在 RawImage 控件上。
        rawImage.texture = downloadHandlerTexture.texture;
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerTexture 下载图像
StartCoroutine(DownloadHandlerTexture());
```
#### DownloadHandlerAssetBundle下载AssetBundle
```cs
// 协程函数用于下载 AssetBundle 并加载
IEnumerator DownLoadAssetBundle()
{
    // 创建一个 UnityWebRequest 对象，指定要下载的 AssetBundle URL 和请求方法（GET）。
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/model", UnityWebRequest.kHttpVerbGET);

    // 创建一个 DownloadHandlerAssetBundle 对象，用于处理下载的 AssetBundle 数据。
    // 第二个参数表示需要已知的校验码（checksum）来进行完整性检查，如果不知道则传入 0，不进行完整性检查。
    DownloadHandlerAssetBundle downloadHandlerAssetBundle = new DownloadHandlerAssetBundle(unityWebRequest.url, 0);

    // 将 DownloadHandlerAssetBundle 对象设置为 UnityWebRequest 的下载处理器。
    unityWebRequest.downloadHandler = downloadHandlerAssetBundle;

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 下载成功，获取 AssetBundle 对象。
        AssetBundle assetBundle = downloadHandlerAssetBundle.assetBundle;

        // 使用 AssetBundle，例如加载资源。
        // 在这里可以通过 assetBundle.LoadAsset 或其他方法加载资源。
        print(assetBundle.name); // 输出 AssetBundle 名称。
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerAssetBundle 下载AssetBundle。
StartCoroutine(DownLoadAssetBundle());
```
#### UnityWebRequestMultimedia.GetAudioClip下载AudioClip
```cs
// 协程函数用于下载音频文件并获取 AudioClip
IEnumerator DownLoadAudioClip()
{
    // 创建一个 UnityWebRequest 对象，使用 UnityWebRequestMultimedia.GetAudioClip 方法指定要下载的音频文件的 URL 和音频类型（AudioType.MPEG）。
    UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip("http://192.168.1.101:8000/HTTPRoot/音效名.mp3", AudioType.MPEG);

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 获取下载的音频文件的 AudioClip。
        AudioClip audioClip = DownloadHandlerAudioClip.GetContent(unityWebRequest);

        // 现在可以使用 audioClip 来播放音频。
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerAudioClip 下载音频文件。
StartCoroutine(DownLoadAudioClip());
```

#### 自定义下载
##### 自定义文件处理类继承DownloadHandlerScript
```cs
// 自定义文件处理类
public class CustomDownLoadFileHandler : DownloadHandlerScript
{
    // 用于保存本地存储时的路径
    private string savePath;

    // 用于缓存收到的数据的容器
    private byte[] cacheBytes;

    // 这是当前已收到的数据长度
    private int index = 0;

    /// <summary>
    /// 无参数构造函数
    /// </summary>
    public CustomDownLoadFileHandler() : base()
    {
    }

    /// <summary>
    /// 带字节数组参数的构造函数
    /// </summary>
    /// <param name="bytes"></param>
    public CustomDownLoadFileHandler(byte[] bytes) : base(bytes)
    {
    }

    /// <summary>
    /// 带路径参数的构造函数，用于指定本地存储路径
    /// </summary>
    /// <param name="path"></param>
    public CustomDownLoadFileHandler(string path) : base()
    {
        savePath = path;
    }

    /// <summary>
    /// 返回字节数组
    /// </summary>
    protected override byte[] GetData()
    {
        return cacheBytes;
    }

    /// <summary>
    /// 从网络收到数据后，每帧会调用的方法，底层会自动调用的方法
    /// </summary>
    /// <param name="data"></param>
    /// <param name="dataLength"></param>
    /// <returns></returns>
    protected override bool ReceiveData(byte[] data, int dataLength)
    {
        Debug.Log("收到数据长度：" + data.Length);
        Debug.Log("收到数据长度 dataLength：" + dataLength);
        data.CopyTo(cacheBytes, index);
        index += dataLength;
        return true;
    }

    /// <summary>
    /// 从服务器收到 Content-Length 标头时，底层会自动调用的方法
    /// </summary>
    /// <param name="contentLength"></param>
    protected override void ReceiveContentLengthHeader(ulong contentLength)
    {
        // 根据收到的标头决定字节数组容器的大小
        cacheBytes = new byte[contentLength];
    }

    /// <summary>
    /// 当消息收完了，底层会自动调用的方法
    /// </summary>
    protected override void CompleteContent()
    {
        // 把收到的字节数组进行自定义处理，此处处理成存储到本地
        File.WriteAllBytes(savePath, cacheBytes);
        Debug.Log("消息收完");
    }
}
```

##### 使用协程函数创建CustomDownLoadFileHandler
```cs
// 协程函数用于下载并使用自定义下载处理器处理数据
IEnumerator DownLoadCustomHandler()
{
    // 创建一个 UnityWebRequest 对象，指定要下载的文件 URL 和请求方法（GET）。
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbGET);

    // 输出应用程序的持久数据路径，用于确定下载文件的保存位置。
    print(Application.persistentDataPath);

    // 使用自定义的下载处理对象来处理获取到的二进制字节数组，并指定保存路径。
    unityWebRequest.downloadHandler = new CustomDownLoadFileHandler(Application.persistentDataPath + "/CustomDownLoadFileHandler.png");

    // 发送下载请求并等待其完成。
    yield return unityWebRequest.SendWebRequest();

    // 检查下载是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 下载并存储到本地成功。
        print("存储本地成功");
    }
    else
    {
        // 下载失败，输出错误信息，包括结果、错误消息和响应代码。
        print("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

// DownloadHandlerScript 下载并使用自定义下载处理器处理数据
// DownloadHandlerScript 是一个特殊类。就其本身而言，不会执行任何操作。
// 但是，此类可由用户定义的类继承。此类接收来自 UnityWebRequest 系统的回调，
// 然后可以使用这些回调在数据从网络到达时执行完全自定义的数据处理。
StartCoroutine(DownLoadCustomHandler());
```
### 运行结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/56.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-UnityWebRequest%E7%B1%BB-%E9%AB%98%E7%BA%A7%E8%8E%B7%E5%8F%96%E6%95%B0%E6%8D%AE/1.png)

### 总结
我们可以自己设置 UnityWebRequest 当中的下载处理对象  
当设置后，下载数据后它会使用该对象中对应的函数处理数据  
让我们更方便的获取我们想要的数据  
方便我们对数据下载或获取进行拓展

### 请自己继承DownloadHandlerScript，实现一个模拟处理服务端下发的BaseMessage消息的类
![[DownLoadHandlerMsg.cs]]
#### 创建DownLoadHandlerMessage自定义下载处理信息类，定义必要的程艳变量和构造函数。
```cs
/// <summary>
/// 下载处理消息的类，继承自DownloadHandlerScript。
/// </summary>
public class DownLoadHandlerMessage : DownloadHandlerScript
{
    // 我们最终想要的消息对象
    private BaseMessage baseMessage;

    // 用于装载收到的字节数组的缓存和索引
    private byte[] cacheBytes;
    private int index = 0;

    //构造函数
    public DownLoadHandlerMessage() : base()
    {
    }
}
```
#### 自定义下载处理信息类重写自定义下载类要重写的方法，对下发的BaseMessage进行处理
```cs
//重写获得数据方法 返回缓存字节数组
protected override byte[] GetData()
{
    return cacheBytes;
}

/// <summary>
/// 接收数据的回调方法，将收到的数据拷贝到缓存中以便后续处理。
/// </summary>
/// <param name="data">接收到的数据</param>
/// <param name="dataLength">数据的长度</param>
/// <returns>始终返回true</returns>
protected override bool ReceiveData(byte[] data, int dataLength)
{
    // 将收到的数据拷贝到容器中，一起处理
    data.CopyTo(cacheBytes, index);
    index += dataLength;
    return true;
}

/// <summary>
/// 接收Content-Length头部的回调方法，用于初始化缓存数组。
/// </summary>
/// <param name="contentLength">消息内容的长度</param>
protected override void ReceiveContentLengthHeader(ulong contentLength)
{
    cacheBytes = new byte[contentLength];
}

/// <summary>
/// 完成内容接收的回调方法，解析接收到的消息并创建相应的消息对象。
/// </summary>
protected override void CompleteContent()
{
    // 默认服务器下发的是继承BaseMessage的消息，解析它
    index = 0;
    int msgID = BitConverter.ToInt32(cacheBytes, index);
    index += 4;
    int msgLength = BitConverter.ToInt32(cacheBytes, index);
    index += 4;

    // 根据消息ID创建相应的消息对象
    switch (msgID)
    {
        case 1001:
            baseMessage = new PlayerMessage();
            baseMessage.Reading(cacheBytes, index);
            break;
    }

    if (baseMessage == null)
        Debug.Log("对应ID " + msgID + " 没有处理");
    else
        Debug.Log("消息处理完毕");
}
```

#### 自定义下载处理信息类定义获得转换类型后的对象方法
```cs
/// <summary>
/// 获取消息对象的泛型方法，泛型参数T必须是BaseMessage的子类。
/// </summary>
/// <typeparam name="T">消息对象的类型，必须继承自BaseMessage。</typeparam>
/// <returns>消息对象</returns>
public T GetMessage<T>() where T : BaseMessage
{
    return baseMessage as T;
}
```

#### 测试脚本定义协程函数，模拟服务器下发BaseMessage时的处理
![[Lesson32E.cs]]
```cs
/// <summary>
/// 协程用于从web服务器获取消息的方法。
/// </summary>
IEnumerator GetMessage()
{
    // 创建一个UnityWebRequest对象，用于与web服务器通信，并指定请求类型为POST。
    UnityWebRequest unityWebRequest = new UnityWebRequest("web服务器地址", UnityWebRequest.kHttpVerbPOST);

    // 创建一个DownLoadHandlerMessage对象，用于处理接收的消息数据。
    DownLoadHandlerMessage downLoadHandlerMessage = new DownLoadHandlerMessage();

    // 将自定义的DownLoadHandlerMessage对象设置为UnityWebRequest的下载处理器。
    unityWebRequest.downloadHandler = downLoadHandlerMessage;

    // 发送网络请求并等待响应。
    yield return unityWebRequest.SendWebRequest();

    // 检查网络请求的结果是否成功。
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 从DownLoadHandlerMessage中获取解析后的消息对象，这里是PlayerMessage类型。
        PlayerMessage playerMessage = downLoadHandlerMessage.GetMessage<PlayerMessage>();

        // 使用消息对象来执行逻辑处理。
        // 在此处，你可以使用msg对象进行进一步的操作，根据接收到的消息数据执行相应的逻辑。
    }
}
```