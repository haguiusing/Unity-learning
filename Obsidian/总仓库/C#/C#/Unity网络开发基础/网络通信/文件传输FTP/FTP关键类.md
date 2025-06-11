![[Lesson19 1.cs]]

### NetworkCredential 类
- 命名空间：`System.Net`
- **NetworkCredential 通信凭证类**
- **用途**：在网络身份验证中存储用户名和密码信息，特别是在 FTP 文件传输场景下，用于提供访问 FTP 服务器所需的认证凭据。
- **通俗解释**：该类允许你为 FTP 服务器提供登录凭证（用户名和密码），使得你的应用程序可以通过 FTP 协议与服务器建立安全连接并执行文件传输任务。
```cs
// 创建 NetworkCredential 实例
NetworkCredential networkCredential = new NetworkCredential("MrTao", "MrTao");
```

### FtpWebRequest 类
- 命名空间：`System.Net`
- **FtpWebRequest FTP 客户端操作类**
- **主要功能**：用于执行上传、下载、删除 FTP 服务器上的文件等操作。
- **通俗解释**：FtpWebRequest 类允许你构建与 FTP 服务器的连接，并发送 FTP 指令，实现诸如上传、下载及删除文件等功能。
#### FtpWebRequest 类的重要方法
##### FtpWebRequest.Create 创建新Ftp请求
```cs
//1.Create 创建新的WebRequest转成FtpWebRequest，用于进行Ftp相关操作 Uri构造时传入的是服务器IP地址和要操作的文件的路径
FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri("ftp://127.0.0.1/Test.txt")) as FtpWebRequest;
```
##### FtpWebRequest.Abort 终止Ftp传输
```cs
//2.Abort  如果正在进行文件传输，用此方法可以终止传输
ftpWebRequest.Abort();
```
##### FtpWebRequest.GetRequestStream 获取用于上传的流
```cs
//3.GetRequestStream  获取用于上传的流
Stream requestStream = ftpWebRequest.GetRequestStream();
```
##### FtpWebRequest.GetResponse 返回FTP服务器响应
```cs
//4.GetResponse  返回FTP服务器响应
FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
```

#### FtpWebRequest 类的重要成员
##### FtpWebRequest.Credentials 通信凭证
```cs
//1.Credentials 通信凭证，设置为NetworkCredential对象，就是为服务器设置一个账号密码
ftpWebRequest.Credentials = networkCredential;
```
##### FtpWebRequest.KeepAlive 当完成请求时是否关闭掉FTP服务器的控制连接
```cs
//2.KeepAlive bool值，当完成请求时是否关闭到FTP服务器的控制连接（默认为true，不关闭）
ftpWebRequest.KeepAlive = false;
```
##### FtpWebRequest.Method 设置 FTP 请求的操作命令，如删除、下载、列出目录等
```cs
//3.Method  操作命令设置
//  WebRequestMethods.Ftp类中的操作命令属性
//  DeleteFile  删除文件
//  DownloadFile    下载文件    
//  ListDirectory   获取文件简短列表
//  ListDirectoryDetails    获取文件详细列表
//  MakeDirectory   创建目录
//  RemoveDirectory 删除目录
//  UploadFile  上传文件
ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
```

##### FtpWebRequest.UseBinary 指定是否采用二进制模式传输数据
```cs
//4.UseBinary 是否使用2进制传输
ftpWebRequest.UseBinary = true;
```
##### FtpWebRequest.RenameTo 重命名文件
```cs
//5.RenameTo    重命名文件
ftpWebRequest.RenameTo = "myTest.txt";
```

### FtpWebResponse 类
- 命名空间：`System.Net`
- 它是用于封装FTP服务器对请求的响应
- 它提供操作状态以及从服务器下载数据
- 我们可以通过FtpWebRequest对象中的GetResponse()方法获取
- **作用**：FtpWebResponse类用于表示FTP服务器响应的信息，包括响应代码、响应消息和其他有关FTP操作的详细信息。
- **通俗解释**：当你执行FTP操作后，FTP服务器会返回响应，这个类用于捕获和处理服务器的响应，以便你的应用程序了解操作是否成功，以及获取有关操作的额外信息，如文件大小、文件列表等。
```cs
//通过它来真正的从服务器获取内容
FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
```
#### FtpWebResponse 类的重要方法
##### FtpWebResponse.Close 释放所有资源
```cs
//1.Close:释放所有资源
ftpWebResponse.Close();
```
##### FtpWebResponse.GetResponseStream 返回从FTP服务器下载数据的流
```cs
//2.GetResponseStream：返回从FTP服务器下载数据的流
Stream responseStream = ftpWebResponse.GetResponseStream();
```
#### FtpWebResponse 类的重要成员
##### FtpWebResponse.ContentLength 接受到数据的长度
```cs
//1.ContentLength:接受到数据的长度
print(ftpWebResponse.ContentLength);
```
##### FtpWebResponse.ContentType 接受数据的类型
```cs
//2.ContentType：接受数据的类型
print(ftpWebResponse.ContentType);
```
##### FtpWebResponse.StatusCode FTP服务器下发的最新状态码
```cs
//3.StatusCode:FTP服务器下发的最新状态码
print(ftpWebResponse.StatusCode);
```
##### FtpWebResponse.StatusDescription FTP服务器下发的状态代码的文本
```cs
//4.StatusDescription:FTP服务器下发的状态代码的文本
print(ftpWebResponse.StatusDescription);
```
##### FtpWebResponse.BannerMessage 登录前建立连接时FTP服务器发送的消息
```cs
//5.BannerMessage:登录前建立连接时FTP服务器发送的消息
print(ftpWebResponse.BannerMessage);
```
##### FtpWebResponse.ExitMessage 获取 FTP 会话结束时服务器发送的消息
##### FtpWebResponse.LastModified 获取 FTP 服务器上文件的最后修改日期和时间

### 总结
通过 C# 提供的这三个类（NetworkCredential、FtpWebRequest 和 FtpWebResponse），我们可以实现客户端对 FTP 服务器的文件操作需求，例如上传、下载、删除文件等。

### 实现一个Ftp管理器，将上传方法封装在其中用多线程的形式处理上传，避免影响主线程逻辑

![[FtpMgr.cs]]
![[Lesson20E_Test.cs]]

#### 创建FtpManager单例类，定义服务器IP地址和密码
```cs
public class FtpManager : BaseSingletonInCSharp<FtpManager>
{
    //远端FTP服务器的地址 这里用本机来测试
    private string FTP_PATH = "ftp://127.0.0.1/";
    //用户名和密码
    private string USER_NAME = "MrTao";
    private string PASSWORD = "MrTao";
}
```

#### 定义异步上传FTP服务器的方法
```cs
/// <summary>
/// 上传文件到Ftp服务器（异步）
/// </summary>
/// <param name="fileName">FTP上的文件名</param>
/// <param name="localPath">本地文件路径</param>
/// <param name="action">上传完毕后想要做什么的委托函数</param>
public async void UpLoadFile(string fileName, string localPath, UnityAction action = null)
{
    //异步任务
    await Task.Run(() =>
    {
        try
        {
            //通过一个线程执行这里面的逻辑 那么就不会影响主线程了
            //1.创建一个Ftp连接
            FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri(FTP_PATH + fileName)) as FtpWebRequest;

            //2.进行一些设置
            //凭证
            ftpWebRequest.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            //是否操作结束后 关闭 控制连接
            ftpWebRequest.KeepAlive = false;
            //传输类型
            ftpWebRequest.UseBinary = true;
            //操作类型
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            //代理设置为空
            ftpWebRequest.Proxy = null;

            //3.上传
            Stream uploadRequestStream= ftpWebRequest.GetRequestStream();
            //开始上传
            using (FileStream fileStream = File.OpenRead(localPath))
            {
                byte[] bytes = new byte[1024];
                //返回值 为具体读取了多少个字节
                int contentLength = fileStream.Read(bytes, 0, bytes.Length);
                //有数据就上传
                while (contentLength != 0)
                {
                    //读了多少就写(上传)多少
                    uploadRequestStream.Write(bytes, 0, contentLength);
                    //继续从本地文件中读取数据
                    contentLength = fileStream.Read(bytes, 0, bytes.Length);
                }
                //上传结束
                fileStream.Close();
                uploadRequestStream.Close();
            }
            Debug.Log("上传成功");
        }
        catch (Exception e)
        {
            Debug.Log("上传文件出错" + e.Message);
        }
    });
    //上传结束后 你想在外部做的事情
    action?.Invoke();
}
```

#### 测试上次文件，开启服务器挂载测试脚本，运行
```cs
FtpManager.Instance.UpLoadFile("MrTaoPic.png", Application.streamingAssetsPath + "/test.png", () =>
{
    print("上传结束 调用委托函数");
});

FtpManager.Instance.UpLoadFile("MrTaoPic2.png", Application.streamingAssetsPath + "/test.png", () =>
{
    print("上传结束 调用委托函数");
});

FtpManager.Instance.UpLoadFile("MrTaoPic3.png", Application.streamingAssetsPath + "/test.png", () =>
{
    print("上传结束 调用委托函数");
});

print("测试测试");
```

![[Pasted image 20250607225904.png]]