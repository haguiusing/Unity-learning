![[Lesson28.cs]]

### WWW 类的作用
- **命名空间**：`UnityEngine`
- **作用**：WWW 类是 Unity 提供给我们用于简单访问网页的类，可以通过该类进行数据的下载和上传。在使用 HTTP 协议时，默认的请求类型是 Get，如果需要进行 Post 上传，则需要配合后续学习的 WWWForm 类一起使用。
- **主要支持的协议**：
    1. `http://` 和 `https://`：超文本传输协议。
    2. `ftp://`：文件传输协议（仅限于匿名下载）。
    3. `file://`：本地文件传输协议，可用于异步加载本地文件（PC、iOS、Android 都支持）。
- **注意**
    1. 该类一般配合协程使用。
    2. 在较新的 Unity 版本中，虽然该类会提示过时，但仍可使用。新版本已将其功能整合到 UnityWebRequest 类中。

### WWW 类的常用方法和变量
#### WWW 类常用方法
##### WWW构造函数，用于创建一个WWW请求
```cs
//1.WWW：构造函数，用于创建一个WWW请求
WWW www = new WWW("http://192.168.1.101:8000/HTTPRoot/pic.png");
```
##### [WWW.GetAudioClip](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.GetAudioClip) 从下载数据返回一个音效切片AudioClip对象
```cs
//2.GetAudioClip：从下载数据返回一个音效切片AudioClip对象
//AudioClip audioClip = www.GetAudioClip()
```
##### [WWW.LoadImageIntoTexture](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.LoadImageIntoTexture) 从下载数据中的图像来替换现有的一个Texture2D对象
```cs
//3.LoadImageIntoTexture：用下载数据中的图像来替换现有的一个Texture2D对象
Texture2D texture2D = new Texture2D(100, 100);
www.LoadImageIntoTexture(texture2D);
```
##### [WWW.LoadFromCacheOrDownload](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.LoadFromCacheOrDownload) 从缓存加载对象，如果该包不在缓存则自动下载存储到缓存中，以便以后直接从本地缓存中加载
```cs
//4.LoadFromCacheOrDownload：从缓存加载AB包对象，如果该包不在缓存则自动下载存储到缓存中，以便以后直接从本地缓存中加载
WWW.LoadFromCacheOrDownload("http://192.168.1.101:8000/HTTPRoot/test.assetbundle", 1);
```

#### WWW 类常用变量
##### [WWW.assetBundle](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.assetBundle) 如果加载的数据是 AssetBundle，则可以通过该变量直接获取加载结果。
##### [WWW.audioClip](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.audioClip) 如果加载的数据是音效切片文件，则可以通过该变量直接获取加载结果（新版本使用 GetAudioClip 方法）。
##### [WWW.bytes](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.bytes) 以字节数组的形式获取加载到的内容。
##### [WWW.bytesDownloaded](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.bytesDownloaded) 已下载的字节数。
##### [WWW.error](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.error) 返回一个错误消息，若下载期间出现错误，可通过该变量获取错误信息。
##### [WWW.isDone](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.isDone) 判断下载是否已完成。
##### [WWW.movie](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.movie) 如果下载的是视频，则可获取一个 MovieTexture 类型结果（新版本使用 GetMovieTexture 方法）。
##### [WWW.progress](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.progress) 下载进度。
##### [WWW.text](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.text) 如果下载的数据是字符串，则以字符串的形式返回内容。
##### [WWW.texture](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/WWW.texture) 如果下载的数据是图片，则以 Texture2D 的形式返回加载结果。

### 利用 WWW 类来异步下载或加载文件
#### 下载 HTTP 服务器上的内容
```cs
public RawImage rawImage;

IEnumerator DownLoadHttp()
{
    WWW www = new WWW("https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png");

    while (!www.isDone)
    {
        print(www.bytesDownloaded);
        print(www.progress);
        yield return null;
    }

    print(www.bytesDownloaded);
    print(www.progress);

    if (www.error == null)
    {
        rawImage.texture = www.texture;
    }
    else
        print(www.error);
}

StartCoroutine(DownLoadHttp());
```

![[Pasted image 20250607215251.png]]

#### 下载 FTP 服务器上的内容（FTP 服务器需支持匿名账户）
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/2.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/3.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/4.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/5.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/6.png)

```cs
IEnumerator DownLoadFtp()
{
    WWW www = new WWW("ftp://127.0.0.1/pic.png");

    while (!www.isDone)
    {
        print(www.bytesDownloaded);
        print(www.progress);
        yield return null;
    }

    print(www.bytesDownloaded);
    print(www.progress);

    if (www.error == null)
    {
        rawImage.texture = www.texture;
    }
    else
        print(www.error);
}

StartCoroutine(DownLoadFtp());
```

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/7.png)

#### 加载本地内容（一般移动平台加载数据会使用该方式）
```cs
IEnumerator DownLoadLocal()
{
    WWW www = new WWW("file://" + Application.streamingAssetsPath + "/test.png");

    while (!www.isDone)
    {
        print(www.bytesDownloaded);
        print(www.progress);
        yield return null;
    }

    print(www.bytesDownloaded);
    print(www.progress);

    if (www.error == null)
    {
        rawImage.texture = www.texture;
    }
    else
        print(www.error);
}

StartCoroutine(DownLoadLocal());
```

![[Pasted image 20250607215516.png]]

### 总结
- Unity 中的 WWW 类比使用 C# 中的 Http 相关类更加方便。
- 建议使用 Unity 封装好的类来处理下载和加载相关逻辑。

### 请在一个NetWWW管理器当中，封装一个基于WWW下载远程数据或加载本地数据的方法，加载完成后，通过委托的形式让外部使用
#### 定义NetWWW管理器单例类
```cs
public class NetWWWManager : BaseSingletonInMonoBehaviour<NetWWWManager>
{
}
```

#### NetWWW管理器封装外部调用加载资源的方法，同时定义内部异步加载的方法
```cs
/// <summary>
/// 提供给外部加载资源用的方法
/// </summary>
/// <typeparam name="T">资源的类型</typeparam>
/// <param name="path">资源的路径 http ftp file都支持</param>
/// <param name="action">加载结束后的回调函数 因为WWW是通过结合协同程序异步加载的 所以不能马上获取结果 需要回调获取</param>
public void LoadResource<T>(string path, UnityAction<T> action) where T : class
{
    StartCoroutine(LoadResourceAsync<T>(path, action));
}

/// <summary>
/// 内部异步使用WWW加载资源用的协程方法
/// </summary>
/// <typeparam name="T">资源的类型</typeparam>
/// <param name="path">资源的路径 http ftp file都支持</param>
/// <param name="action">加载结束后的回调函数 因为WWW是通过结合协同程序异步加载的 所以不能马上获取结果 需要回调获取</param>
private IEnumerator LoadResourceAsync<T>(string path, UnityAction<T> action) where T : class
{
    //声明www对象 用于下载或加载
    WWW www = new WWW(path);

    //等待下载或者加载结束（异步）
    yield return www;

    //优化的话可以让外部多传一个在加载时逻辑处理的委托回调

    //如果没有错误 证明加载成功
    if (www.error == null)
    {
        //根据T泛型的类型 决定使用哪种类型的资源 传递给外部
        if (typeof(T) == typeof(AssetBundle))
        {
            action?.Invoke(www.assetBundle as T);
        }
        else if (typeof(T) == typeof(Texture))
        {
            action?.Invoke(www.texture as T);
        }
        else if (typeof(T) == typeof(AudioClip))
        {
            action?.Invoke(www.GetAudioClip() as T);
        }
        else if (typeof(T) == typeof(string))
        {
            action?.Invoke(www.text as T);
        }
        else if (typeof(T) == typeof(byte[]))
        {
            action?.Invoke(www.bytes as T);
        }
        //自定义一些类型 可能需要将bytes 转换成对应的类型来使用
    }
    //如果错误 就提示别人
    else
    {
        //优化的话可以让外部多传一个在错误时委托回调
        Debug.LogError("www加载资源出错" + www.error);
    }
}
```

#### 测试加载图片，写入图片和打印字符
```cs
public RawImage rawImage;

void Start()
{
    NetWWWManager.Instance.LoadResource<Texture>("http://192.168.1.101:8000/HTTPRoot/pic.png", (obj) =>
    {
        //使用加载结束的资源
        rawImage.texture = obj;
    });

    NetWWWManager.Instance.LoadResource<byte[]>("http://192.168.1.101:8000/HTTPRoot/pic.png", (obj) =>
    {
        //使用加载结束的资源
        //把得到的字节数组存储到本地 保存文件
        print(Application.persistentDataPath);
        File.WriteAllBytes(Application.persistentDataPath + "/www下载的字节数组图片.png", obj);
    });

    NetWWWManager.Instance.LoadResource<string>("http://192.168.1.101:8000/HTTPRoot/test.txt", (str) =>
    {
        print(str);
    });
}
```

#### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/52.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-Unity%E7%BD%91%E7%BB%9C%E7%B1%BB-WWW%E7%B1%BB/9.png)