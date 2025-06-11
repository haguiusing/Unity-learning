![[Lesson33.cs]]

### 回顾高级操作中的获取数据
#### 主要做法
将二进制字节数组处理，独立到下载处理对象中进行处理，主要设置 `UnityWebRequest` 对象中 `downloadHandler` 变量。

#### Unity 内置的类
1. `DownloadHandlerBuffer`：用于简单的数据存储，获取对应的二进制数据。
2. `DownloadHandlerFile`：用于下载文件并将文件保存到磁盘（内存占用较少）。
3. `DownloadHandlerTexture`：用于下载图像。
4. `DownloadHandlerAssetBundle`：用于提取 AssetBundle。
5. `DownloadHandlerAudioClip`：用于下载音频文件。

#### 自定义拓展方式
- 继承 `DownloadHandlerScript` 类，并重写其中的固定方法，自定义处理字节数组。

### 自定义上传数据 UploadHandler 相关类
**注意**：由于 `UnityWebRequest` 类在常用操作中已经封装了上传数据相关内容，我们可以方便地上传参数和文件，满足常用需求。以下内容主要用于了解，特别重要的变量是 `contentType` 内容类型，如果不设置，默认是 `application/octet-stream` 二进制流的形式。

#### UploadHandlerRaw上传字节数组
```cs
// 用于上传字节数组的协程
IEnumerator UploadHandlerRaw()
{
    // 创建一个 UnityWebRequest 对象，指定要访问的 URL 和 HTTP 请求方法为 POST
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbPOST);
    
    // 准备要上传的字节数组
    byte[] bytes = Encoding.UTF8.GetBytes("123123123123123");

    // 将字节数组分配给 UnityWebRequest 的 uploadHandler，用于上传数据
    unityWebRequest.uploadHandler = new UploadHandlerRaw(bytes);

    // 如果需要指定上传数据的类型，可以设置 contentType 属性
    // unityWebRequest.uploadHandler.contentType = "类型/细分类型";
    
    // 发送网络请求，并等待请求返回
    yield return unityWebRequest.SendWebRequest();
    
    // 打印请求的结果（成功或失败）
    print(unityWebRequest.result);
}

StartCoroutine(UploadHandlerRaw());
```

#### UploadHandlerFile上传文件
```cs
// 用于上传文件的协程
IEnumerator UploadHandlerFile()
{
    // 创建一个 UnityWebRequest 对象，指定要访问的 URL 和 HTTP 请求方法为 POST
    UnityWebRequest unityWebRequest = new UnityWebRequest("http://192.168.1.101:8000/HTTPRoot/pic.png", UnityWebRequest.kHttpVerbPOST);
    
    // 创建一个用于上传文件的 UploadHandlerFile 对象，指定要上传的文件路径
    unityWebRequest.uploadHandler = new UploadHandlerFile(Application.streamingAssetsPath + "/test.png");
    
    // 发送网络请求，并等待请求返回
    yield return unityWebRequest.SendWebRequest();
    
    // 打印请求的结果（成功或失败）
    print(unityWebRequest.result);
}

StartCoroutine(UploadHandlerFile());
```

### 运行结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/57.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-UnityWebRequest%E7%B1%BB-%E9%AB%98%E7%BA%A7%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/1.png)

### 总结
- 由于 `UnityWebRequest` 已经提供了较为完善的参数上传、文件上传相关功能，因此高级操作中的上传数据相关内容拓展较少，使用也较少。我们使用常用操作的上传数据相关功能已经足够，高级操作中的上传数据知识点主要做了解。

### 请在一个NetWWW管理类当中，封装一个基于UnityWebRequest下载远程数据或加载本地数据的方法，加载完成后，通过委托的形式让外部使用
![[NetWWWMgr 2.cs]]
#### 在定义协程UnityWebRequest去获取数据方法和启动协程方法
```cs
/// <summary>
/// 通过UnityWebRequest去获取数据
/// </summary>
/// <typeparam name="T">byte[]、Texture、AssetBundle、AudioClip、object（自定义的 如果是object证明要保存到本地）</typeparam>
/// <param name="path">远端或者本地数据路径 http ftp file</param>
/// <param name="action">获取成功后的回调函数</param>
/// <param name="localPath">如果是下载到本地 需要传第3个参数</param>
/// <param name="type">如果是下载 音效切片文件 需要穿音效类型</param>
public void UnityWebRequestLoad<T>(string path, UnityAction<T> action, string localPath = "", AudioType type = AudioType.MPEG) where T : class
{
    StartCoroutine(UnityWebRequestLoadAsync<T>(path, action, localPath, type));
}

/// <summary>
/// 异步方法，使用 UnityWebRequest 获取数据。
/// </summary>
/// <typeparam name="T">返回数据的类型，可以是 byte[]、Texture、AssetBundle、AudioClip、object（自定义类型，用于本地保存）</typeparam>
/// <param name="path">远程或本地数据的路径，可以是 http、ftp、file 协议</param>
/// <param name="action">获取成功后的回调函数</param>
/// <param name="localPath">如果是下载到本地，需要传递本地文件保存路径</param>
/// <param name="type">如果是下载音效文件，需要指定音效类型（默认为 MPEG）</param>
/// <returns>IEnumerator，用于协程处理</returns>
private IEnumerator UnityWebRequestLoadAsync<T>(string path, UnityAction<T> action, string localPath = "", AudioType type = AudioType.MPEG) where T : class
{
    // 创建 UnityWebRequest 实例，指定请求方式为 GET，并传递目标路径。
    UnityWebRequest unityWebRequest = new UnityWebRequest(path, UnityWebRequest.kHttpVerbGET);

    // 根据泛型类型 T 设置不同的下载处理器。
    if (typeof(T) == typeof(byte[]))
        unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
    else if (typeof(T) == typeof(Texture))
        unityWebRequest.downloadHandler = new DownloadHandlerTexture();
    else if (typeof(T) == typeof(AssetBundle))
        unityWebRequest.downloadHandler = new DownloadHandlerAssetBundle(unityWebRequest.url, 0);
    else if (typeof(T) == typeof(object))
        unityWebRequest.downloadHandler = new DownloadHandlerFile(localPath);
    else if (typeof(T) == typeof(AudioClip))
        unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(path, type);
    else
    {
        // 如果泛型类型不在预期的类型中，记录警告并退出协程。
        Debug.LogWarning("未知类型" + typeof(T));
        yield break;
    }

    // 发送 UnityWebRequest 并等待请求完成。
    yield return unityWebRequest.SendWebRequest();

    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        // 根据泛型类型 T 处理不同的下载结果，并调用回调函数 action。
        if (typeof(T) == typeof(byte[]))
            action?.Invoke(unityWebRequest.downloadHandler.data as T);
        else if (typeof(T) == typeof(Texture))
            action?.Invoke(DownloadHandlerTexture.GetContent(unityWebRequest) as T);
        else if (typeof(T) == typeof(AssetBundle))
            action?.Invoke((unityWebRequest.downloadHandler as DownloadHandlerAssetBundle).assetBundle as T);
        else if (typeof(T) == typeof(object))
            action?.Invoke(null);
        else if (typeof(T) == typeof(AudioClip))
            action?.Invoke(DownloadHandlerAudioClip.GetContent(unityWebRequest) as T);
    }
    else
    {
        // 如果请求失败，记录错误信息。
        Debug.LogWarning("获取数据失败" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}
```
#### 进行测试
```cs
NetWWWManager.Instance.UnityWebRequestLoad<Texture>("http://192.168.1.101:8000/HTTPRoot/pic.png", (texture) =>
{
    rawImage.texture = texture;
    Debug.Log("Texture下载成功");
});

NetWWWManager.Instance.UnityWebRequestLoad<byte[]>("http://192.168.1.101:8000/HTTPRoot/pic.png", (bytes) =>
{
    Debug.Log("字节数组长度为：" + bytes.Length);
});

NetWWWManager.Instance.UnityWebRequestLoad<object>("http://192.168.1.101:8000/HTTPRoot/pic.png", (obj) =>
{
    Debug.Log("保存本地成功");
},Application.persistentDataPath+ "/UnityWebRequestLoad.png");

Debug.Log(Application.persistentDataPath);
```
#### 运行结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/57.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-UnityWebRequest%E7%B1%BB-%E9%AB%98%E7%BA%A7%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/2.png)
