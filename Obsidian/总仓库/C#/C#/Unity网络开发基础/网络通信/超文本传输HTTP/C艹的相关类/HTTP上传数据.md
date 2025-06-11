![[Lesson27.cs]]

### 上传文件到 HTTP 资源服务器需要遵守的规则
1. ContentType = “multipart/form-data; boundary=边界字符串”;
2. 上传的数据必须按照格式写入流中
```cs
//  --边界字符串
//  Content-Disposition: form-data; name="字段名字，之后写入的文件2进制数据和该字段名对应";filename="传到服务器上使用的文件名"
//  Content-Type:application/octet-stream（由于我们传2进制文件 所以这里使用2进制）

//  空一行
//  （这里直接写入传入的内容 即文件数据体）

//  --边界字符串--
```
3. 保证服务器允许上传
4. 写入流前需要先设置 ContentLength 内容长度

### HFS服务器可以设置所有人可上传，也可以设置用户上传权限，否则可能没有上传权限
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/51.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/1.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/51.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/2.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/51.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/3.png)

### 上传文件
#### 创建 HttpWebRequest 对象，不需写要上传的文件名
```cs
//1.创建HttpWebRequest对象 不用写要上传的文件名
HttpWebRequest httpWebRequest = HttpWebRequest.Create("http://192.168.1.101:8000/HTTPRoot/") as HttpWebRequest;
```
#### 相关设置（请求类型、内容类型、超时、身份验证等）
```cs
//2.相关设置（请求类型，内容类型，超时，身份验证等）
httpWebRequest.Method = WebRequestMethods.Http.Post;
httpWebRequest.ContentType = "multipart/form-data;boundary=MrTao";//复合文件类型 自定义边界字符串是MrTao
httpWebRequest.Timeout = 500000;
httpWebRequest.Credentials = new NetworkCredential("MrTao", "MrTao");//服务器身份验证信息
httpWebRequest.PreAuthenticate = true;//先验证身份 再上传数据 标识设置为True
```
#### 按格式拼接字符串并转为字节数组用于上传
##### 文件数据前的头部信息
```cs
//3-1.文件数据前的头部信息

//其中\r\n是多平台换行 自定义边界字符串是MrTao 字段名字传入file 声明是文件 字段名可以自定义的 

//  --边界字符串 
//  Content-Disposition: form-data; name="字段名字，之后写入的文件2进制数据和该字段名对应";filename="传到服务器上使用的文件名"
//  Content-Type:application/octet-stream（由于我们传2进制文件 所以这里使用2进制）
//  空一行

string head = 
    "--MrTao\r\n" +
    "Content-Disposition:form-data;name=\"file\";filename=\"http上传的文件.jpg\"\r\n" +
    "Content-Type:application/octet-stream\r\n\r\n";

//头部拼接字符串规则信息的字节数组
byte[] headBytes = Encoding.UTF8.GetBytes(head);
```
##### 结束的边界信息
```cs
//3-2.结束的边界信息
//  --边界字符串--
byte[] endBytes = Encoding.UTF8.GetBytes("\r\n--MrTao--\r\n");
```
#### 写入上传流
```cs
//4.写入上传流
using (FileStream localFileStream = File.OpenRead(Application.streamingAssetsPath + "/test.png"))
{
    //4-1.设置上传长度
    //总长度 是前部分头部字符串 + 文件本身有多大 + 后部分边界字符串
    httpWebRequest.ContentLength = headBytes.Length + localFileStream.Length + endBytes.Length;
    //用于上传的流
    Stream uploadRequestStream = httpWebRequest.GetRequestStream();

    //4-2.先写入前部分头部信息
    uploadRequestStream.Write(headBytes, 0, headBytes.Length);

    //4-3.再写入文件数据
    byte[] bytes = new byte[2048];//字节数组
    //不停的读取
    int contentLength = localFileStream.Read(bytes, 0, bytes.Length);
    while (contentLength != 0)
    {
        uploadRequestStream.Write(bytes, 0, contentLength);
        contentLength = localFileStream.Read(bytes, 0, bytes.Length);
    }

    //4-4.在写入结束的边界信息
    uploadRequestStream.Write(endBytes, 0, endBytes.Length);

    uploadRequestStream.Close();
    localFileStream.Close();
}
```
#### 上传数据，获取响应
```cs
//5.上传数据，获取响应
HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
if (httpWebResponse.StatusCode == HttpStatusCode.OK)
    print("上传通信成功");
else
    print("上传失败" + httpWebResponse.StatusCode);
```
### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/51.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E4%B8%8A%E4%BC%A0%E6%95%B0%E6%8D%AE/4.png)
![[Pasted image 20250607211828.png]]
![[Pasted image 20250607213722.png]]

### 总结
HTTP 上传文件相对比较麻烦，需要按照指定的规则进行内容拼接达到上传文件的目的。其中相对重要的知识点是上传文件时的规则：
- 边界字符串
- Content-Disposition: form-data; name=”file”; filename=”传到服务器上使用的文件名”
- Content-Type: application/octet-stream（由于我们传2进制文件，所以这里使用2进制）
- 空行
- （这里直接写入传入的内容）
- 边界字符串

关于更多规则，可前往官网查看详细说明。  
有关 ContentType 的更多内容，可前往 [https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Type](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Type)。  
有关媒体类型的更多内容，可前往 [https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types)。  
有关 Content-Disposition 的更多内容，可前往 [https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Disposition](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Disposition)。

### 实现一个Ftp管理器，将上传方法封装在其中用多线程的形式处理上传，避免影响主线程逻辑
![[HttpMgr.cs]]
![[Lesson25E_Test.cs]]

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

![[Pasted image 20250607220000.png]]