![[Lesson30.cs]]

### UnityWebRequest 是什么？
- **UnityWebRequest 是什么？**
    - UnityWebRequest 是 Unity 提供的一个模块化的系统类，用于构建 HTTP 请求和处理 HTTP 响应。
    - 主要目标是实现 Unity 游戏与 Web 服务端的交互，将之前的 WWW 相关功能集成在其中，因此在新版本中建议使用 UnityWebRequest 类来代替 WWW 类。
    
    **注意：**
    1. UnityWebRequest 和 WWW 一样，需要配合协程使用。
    2. 支持 http、ftp、file 协议下载或加载资源。
    3. 能够上传文件到 HTTP 资源服务器。

### UnityWebRequest 类的常用操作
#### **使用 Get 请求获取文本或二进制数据**
#### **使用 Get 请求获取纹理数据**
#### **使用 Get 请求获取 AB 包数据**
#### **使用 Post 请求发送数据**
#### **使用 Put 请求上传数据**

### Get 获取操作
#### UnityWebRequest.Get 获取文本或二进制
```cs
IEnumerator LoadText()
{
    UnityWebRequest unityWebRequest = UnityWebRequest.Get("http://192.168.1.101:8000/HTTPRoot/test.txt");

    //会等待服务器端响应后 断开连接后 再继续执行后面的内容
    yield return unityWebRequest.SendWebRequest();

    //如果处理成功 结果就是成功枚举
    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        //UnityWebRequest的downloadHandler属性是下载处理器 负责管理由UnityWebRequest从远程服务器接收的主体数据。

        //文本字符串
        print(unityWebRequest.downloadHandler.text);

        //字节数组
        byte[] bytes = unityWebRequest.downloadHandler.data;
        print("字节数组长度" + bytes.Length);
    }
    else
    {
        print("获取失败:" + unityWebRequest.result + unityWebRequest.error + unityWebRequest.responseCode);
    }
}

//获取文本或2进制
StartCoroutine(LoadText());
```
#### UnityWebRequest.GetTexture 获取纹理
```cs
IEnumerator LoadTexture()
{
    //UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture("http://192.168.1.101:8000/HTTPRoot/pic.png");

    //UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture("ftp://127.0.0.1/pic.png");

    UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture("file://" + Application.streamingAssetsPath + "/test.png");

    yield return unityWebRequest.SendWebRequest();

    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        //可以把UnityWebRequest的downloadHandler属性as成DownloadHandlerTexture纹理下载类得到其中的纹理
        //rawImage.texture = (unityWebRequest.downloadHandler as DownloadHandlerTexture).texture;

        //也可以用DownloadHandlerTexture纹理下载类的GetContent方法传入UnityWebRequest对象得到纹理 这两种方法都可以
        rawImage.texture = DownloadHandlerTexture.GetContent(unityWebRequest);
    }
    else
        print("获取失败" + unityWebRequest.error + unityWebRequest.result + unityWebRequest.responseCode);
}

//获取纹理
StartCoroutine(LoadTexture());
```
#### UnityWebRequestAssetBundle.GetAssetBundle 获取AB包
```cs
IEnumerator LoadAssetBundle()
{
    UnityWebRequest unityWebRequest = UnityWebRequestAssetBundle.GetAssetBundle("http://192.168.1.101:8000/HTTPRoot/model");

    unityWebRequest.SendWebRequest();

    //在没加载结束前 进行逻辑处理
    while (!unityWebRequest.isDone)
    {
        print(unityWebRequest.downloadProgress);
        print(unityWebRequest.downloadedBytes);
        yield return null;
    }
    //yield return unityWebRequest.SendWebRequest();

    print(unityWebRequest.downloadProgress);
    print(unityWebRequest.downloadedBytes);

    if (unityWebRequest.result == UnityWebRequest.Result.Success)
    {
        //可以把UnityWebRequest的downloadHandler属性as成DownloadHandlerAssetBundleAB包下载类得到其中的AB包
        //AssetBundle assetBundle = (unityWebRequest.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        //也可以用DownloadHandlerAssetBundleAB包下载类的GetContent方法传入UnityWebRequest对象得到AB包 这两种方法都可以
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(unityWebRequest);

        print(assetBundle.name);
    }
    else
        print("获取失败" + unityWebRequest.error + unityWebRequest.result + unityWebRequest.responseCode);
}

//获取AB包
StartCoroutine(LoadAssetBundle());
```
#### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/54.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-UnityWebRequest%E7%B1%BB-%E5%B8%B8%E7%94%A8%E8%8E%B7%E5%8F%96%E6%95%B0%E6%8D%AE/1.png)

### 总结
- UnityWebRequest 使用上和 WWW 类很类似。
- 需要注意：
    - 获取文本或二进制数据时使用 UnityWebRequest.Get。
    - 获取纹理图片数据时使用 UnityWebRequestTexture.GetTexture 以及 DownloadHandlerTexture.GetContent。
    - 获取 AB 包数据时使用 UnityWebRequestAssetBundle.GetAssetBundle 以及 DownloadHandlerAssetBundle.GetContent。