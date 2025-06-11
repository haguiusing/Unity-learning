![[Lesson31.cs]]

### 上传相关数据类
#### 父接口IMultipartFormSection 数据相关类都继承该接口
```cs
//数据相关类都继承该接口
//我们可以用父类装子类
List<IMultipartFormSection> multipartFormSectionList = new List<IMultipartFormSection>();
```
#### 子类MultipartFormDataSection 传键值对
```cs
//MultipartFormDataSection 一般用来传键值对
//1.二进制字节数组
multipartFormSectionList.Add(new MultipartFormDataSection(Encoding.UTF8.GetBytes("123123123123123")));
//2.字符串
multipartFormSectionList.Add(new MultipartFormDataSection("12312312312312312dsfasdf"));
//3.参数名，参数值（字节数组，字符串），编码类型，资源类型（常用）
multipartFormSectionList.Add(new MultipartFormDataSection("Name", "MrTao", Encoding.UTF8, "application/...."));
//4.参数名，字节数组，资源类型
multipartFormSectionList.Add(new MultipartFormDataSection("Msg", new byte[1024], "appl....."));
```
#### 子类MultipartFormFileSection 传文件
```cs
//MultipartFormFileSection 一般用来传文件
//1.字节数组
multipartFormSectionList.Add(new MultipartFormFileSection(File.ReadAllBytes(Application.streamingAssetsPath + "/test.png")));
//2.文件名，字节数组（常用）
multipartFormSectionList.Add(new MultipartFormFileSection("上传的文件.png", File.ReadAllBytes(Application.streamingAssetsPath + "/test.png")));
//3.字符串数据，文件名（常用）
multipartFormSectionList.Add(new MultipartFormFileSection("12312313212312", "test.txt"));
//4.字符串数据，编码格式，文件名（常用）
multipartFormSectionList.Add(new MultipartFormFileSection("12312313212312", Encoding.UTF8, "test.txt"));
//5.表单名，字节数组，文件名，文件类型
multipartFormSectionList.Add(new MultipartFormFileSection("file", new byte[1024], "test.txt", ""));
//6.表单名，字符串数据，编码格式，文件名
multipartFormSectionList.Add(new MultipartFormFileSection("file", "123123123", Encoding.UTF8, "test.txt"));
```
### UnityWebRequest.Post上传相关
```cs
// 用于协同处理Post上传操作
IEnumerator UploadPost()
{
    // 准备上传的数据的列表
    List<IMultipartFormSection> multipartFormSectionList = new List<IMultipartFormSection>();

    // 添加键值对相关的信息字段数据
    // 添加名为 "Name" 的文本字段，值为 "MrTao"
    multipartFormSectionList.Add(new MultipartFormDataSection("Name", "MrTao"));

    // 创建一个 PlayerMessage 对象
    PlayerMessage playerMessage = new PlayerMessage();
    playerMessage.playerID = 1;
    playerMessage.playerData = new PlayerData();
    playerMessage.playerData.name = "MrTao";
    playerMessage.playerData.atk = 6;
    playerMessage.playerData.lev = 666;
    // 添加名为 "playerMessage" 的文本字段，值为 PlayerMessage 对象的 JSON 字符串表示
    multipartFormSectionList.Add(new MultipartFormDataSection("playerMessage", playerMessage.Writing()));

    // 添加一些文件上传部分

    // 添加名为 "TestTest123.png" 的二进制文件，内容为从指定路径读取的二进制数据
    multipartFormSectionList.Add(new MultipartFormFileSection("TestTest123.png", File.ReadAllBytes(Application.streamingAssetsPath + "/test.png")));

    // 添加名为 "123123123123123" 的文本文件，内容为 "Test123.txt" 文件的内容
    multipartFormSectionList.Add(new MultipartFormFileSection("123123123123123", "Test123.txt"));

    // 创建 UnityWebRequest 对象，将数据上传到指定的URL
    UnityWebRequest unityWebRequest = UnityWebRequest.Post("http://192.168.1.101:8000/HTTPRoot/", multipartFormSectionList);

    // 发送上传请求
    unityWebRequest.SendWebRequest();

    // 等待上传完成
    while (!unityWebRequest.isDone)
    {
        // 打印上传进度和已上传的字节数
        print(unityWebRequest.uploadProgress);
        print(unityWebRequest.uploadedBytes);
        yield return null;
    }

    // 打印最终上传进度和已上传的字节数
    print(unityWebRequest.uploadProgress);
    print(unityWebRequest.uploadedBytes);

    // 检查上传是否成功
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        print("上传成功");
        // 上传成功后，可以使用 unityWebRequest.downloadHandler.multipartFormSectionList 获取上传数据列表
    }
    else
    {
        // 上传失败时，打印错误信息、响应代码和结果
        print("上传失败" + unityWebRequest.error + unityWebRequest.responseCode + unityWebRequest.result);
    }
}

StartCoroutine(UploadPost());
```
### UnityWebRequest.Put上传相关
```cs
// 用于协同处理Put上传操作
IEnumerator UploadPut()
{
    // 创建 UnityWebRequest 对象，使用 HTTP PUT 方法上传文件

    // 指定要上传的URL和要上传的文件内容，这里使用了 UnityWebRequest.Put 方法 要后端配合
    UnityWebRequest unityWebRequest = UnityWebRequest.Put("http://192.168.1.101:8000/HTTPRoot/", File.ReadAllBytes(Application.streamingAssetsPath + "/test.png"));

    // 发送上传请求并等待完成
    yield return unityWebRequest.SendWebRequest();

    // 检查上传是否成功
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        print("Put 上传成功");
    }
    else
    {
        // 在上传失败时可以添加错误处理逻辑
        // 例如，可以通过 unityWebRequest.error 访问错误消息，以便进行错误处理
    }
}

// 注意：Put请求类型不是所有的web服务器都认，必须要服务器处理该请求类型那么才能有相应
StartCoroutine(UploadPut());
```

### 总结
我们可以利用Post上传数据或上传文件  
Put主要用于上传文件，但是必须资源服务器支持Put请求类型  
为了通用性，我们可以统一使用Post请求类型进行数据和资源的上传  
它的使用和之前的WWW类似，只要前后端制定好规则就可以相互通信了

### 请在一个NetWWW管理类当中，封装一个基于UnityWebRequest上传文件的方法
![[NetWWWMgr 1.cs]]

#### 在NetWWW管理器中封装异步用UnityWebRequest上传的方法
```cs
/// <summary>
/// 上传文件的方法
/// </summary>
/// <param name="fileName">上传上去的文件名</param>
/// <param name="localPath">本地想要上传文件的路径</param>
/// <param name="action">上传完成后的回调函数</param>
public void UploadFile(string fileName, string localPath, UnityAction<UnityWebRequest.Result> action)
{
    StartCoroutine(UploadFileAsync(fileName, localPath, action));
}

/// <summary>
/// 异步上传文件的方法
/// </summary>
/// <param name="fileName">上传上去的文件名</param>
/// <param name="localPath">本地想要上传文件的路径</param>
/// <param name="action">上传完成后的回调函数</param>
/// <returns></returns>
private IEnumerator UploadFileAsync(string fileName, string localPath, UnityAction<UnityWebRequest.Result> action)
{
    // 创建一个列表来存储上传文件的数据
    List<IMultipartFormSection> multipartFormSectionList = new List<IMultipartFormSection>();
    // 向列表中添加要上传的文件，包括文件名和文件的二进制数据
    multipartFormSectionList.Add(new MultipartFormFileSection(fileName, File.ReadAllBytes(localPath)));

    // 创建一个UnityWebRequest对象，用于执行文件上传
    UnityWebRequest unityWebRequest = UnityWebRequest.Post(HTTP_SERVER_PATH, multipartFormSectionList);

    // 发送上传请求并等待完成
    yield return unityWebRequest.SendWebRequest();

    // 调用回调函数，传递上传结果
    action?.Invoke(unityWebRequest.result);

    // 如果上传不成功
    if (unityWebRequest.result != UnityWebRequest.Result.Success)
    {
        // 输出警告信息，包括错误消息和响应代码
        Debug.LogWarning("上传出现问题" + unityWebRequest.error + unityWebRequest.responseCode);
    }
}
```

#### 进行测试
```cs
NetWWWManager.Instance.UploadFile("练习题上传UnityWebRequest.png", Application.streamingAssetsPath + "/test.png", (code) =>
{
    if (code == UnityWebRequest.Result.Success)
    {
        print("上传成功");
    }
    else
        print("上传失败" + code);
});
```