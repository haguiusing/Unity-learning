![[Lesson24 1.cs]]

### HttpWebRequest 类
- 命名空间：`System.Net`
- **HttpWebRequest 是主要用于发送客户端请求的类**
- **主要用途**：用于向服务器发送 HTTP 客户端请求，可进行消息通信、上传、下载等操作。
#### HttpWebRequest 类的重要方法
##### HttpWebRequest.Create 创建新的 WebRequest
```cs
//1.Create 创建新的WebRequest，用于进行HTTP相关操作 能as成HttpWebRequest是因为字符串中的协议头有http
HttpWebRequest httpWebRequest = HttpWebRequest.Create(new Uri("http://192.168.1.101:8000/HTTPRoot/")) as HttpWebRequest;
```
##### HttpWebRequest.Abort 终止文件传输
```cs
//2.Abort  如果正在进行文件传输，用此方法可以终止传输 
httpWebRequest.Abort();
```
##### HttpWebRequest.GetRequestStream 获取用于上传的流
```cs
//3.GetRequestStream  获取用于上传的流
Stream requestStream = httpWebRequest.GetRequestStream();
```
##### HttpWebRequest.GetResponse 返回 HTTP 服务器响应
```cs
//4.GetResponse  返回HTTP服务器响应
HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
```
##### HttpWebRequest.Begin/EndGetRequestStream 异步获取用于上传的流
```cs
//5.Begin/EndGetRequestStream 异步获取用于上传的流
//httpWebRequest.BeginGetRequestStream()
```
##### HttpWebRequest.Begin/EndGetResponse 异步获取返回的 HTTP 服务器响应
```cs
//6.Begin/EndGetResponse 异步获取返回的HTTP服务器响应
//httpWebRequest.BeginGetResponse()
```

#### HttpWebRequest 类的重要成员
##### HttpWebRequest.Credentials 通信凭证
```cs
//1.Credentials 通信凭证，设置为NetworkCredential对象
httpWebRequest.Credentials = new NetworkCredential("", "");
```
##### HttpWebRequest.PreAuthenticate 是否随请求发送一个身份验证标头
```cs
//2.PreAuthenticate 是否随请求发送一个身份验证标头,一般需要进行身份验证时需要将其设置为true
httpWebRequest.PreAuthenticate = true;
```
##### HttpWebRequest.Headers 构成标头的名称/值对的集合
```cs
//3.Headers 构成标头的名称/值对的集合
//httpWebRequest.Headers
```
##### HttpWebRequest.ContentLength 发送信息的字节数
```cs
//4.ContentLength 发送信息的字节数 上传信息时需要先设置该内容长度
httpWebRequest.ContentLength = 100;
```
##### HttpWebRequest.ContentType 在进行 POST 请求时，需要对发送的内容进行内容类型的设置
```cs
//5.ContentType 在进行POST请求时，需要对发送的内容进行内容类型的设置
httpWebRequest.ContentType = "";
```
##### HttpWebRequest.Method 操作命令设置
```cs
// 操作命令设置
//  WebRequestMethods.Http 类中的操作命令属性
//  Get     获取请求，一般用于获取数据
//  Post    提交请求，一般用于上传数据，同时可以获取
//  Head    获取和 Get 一致的内容，只是只会返回消息头，不会返回具体内容
//  Put     向指定位置上传最新内容
//  Connect 表示与代理一起使用的 HTTP CONNECT 协议方法，该代理可以动态切换到隧道
//  MkCol   请求在请求 URI（统一资源标识符）指定的位置新建集合
httpWebRequest.Method = WebRequestMethods.Http.Get;
```
#### HttpWebRequest类的更多信息
了解HttpWebRequest类的更多信息，访问 [https://docs.microsoft.com/zh-cn/dotnet/api/system.net.httpwebrequest?view=net-6.0](https://docs.microsoft.com/zh-cn/dotnet/api/system.net.httpwebrequest?view=net-6.0)。

### HttpWebResponse 类
- 命名空间：`System.Net`
- 它主要用于获取服务器反馈信息的类
- 我们可以通过 HttpWebRequest 对象中的 GetResponse() 方法获取
- 当使用完毕时，要使用 Close 释放
#### HttpWebResponse 类的重要方法
##### HttpWebResponse.Close 释放所有资源
```cs
// 释放所有资源
httpWebResponse.Close();
```
##### HttpWebResponse.GetResponseStream 返回从 FTP 服务器下载数据的流
#### HttpWebResponse 类的重要成员
##### HttpWebResponse.ContentLength 接受到数据的长度
##### HttpWebResponse.ContentType 接受数据的类型
##### HttpWebResponse.StatusCode HTTP 服务器下发的最新状态码
##### HttpWebResponse.StatusDescription HTTP 服务器下发的状态代码的文本
##### HttpWebResponse.BannerMessage 登录前建立连接时 HTTP 服务器发送的消息

##### HttpWebResponse.ExitMessage HTTP 会话结束时服务器发送的消息

##### HttpWebResponse.LastModified HTTP 服务器上的文件的上次修改日期和时间
#### HttpWebResponse类的更多信息
了解该类的更多信息，访问 [https://docs.microsoft.com/zh-cn/dotnet/api/system.net.httpwebresponse?view=net-6.0](https://docs.microsoft.com/zh-cn/dotnet/api/system.net.httpwebresponse?view=net-6.0)。

### NetworkCredential、Uri、Stream、FileStream 类
- 这些类在学习 FTP 时已经使用过了
- 在 HTTP 通讯时使用方式不变

### 总结
Http 相关通讯类的使用和 FTP 非常类似，只有一些细节上的区别。之后我们在学习上传下载时再来着重讲解。