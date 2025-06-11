![[Lesson25 2.cs]]

http://192.168.3.242/HTTPRoot/pic.png
### Head请求类型检测资源可用性
利用 Head 请求类型，获取信息
```cs
try
{
    // 尝试执行以下操作，捕获可能的异常
    // 在这里，我们尝试获取远程服务器上文件的信息
    
    // 1. 创建 HTTP 通讯用连接对象 HttpWebRequest 对象
    HttpWebRequest httpWebRequest = HttpWebRequest.Create(new Uri("http://192.168.1.101:8000/HTTPRoot/pic.png")) as HttpWebRequest;
    
    // 2. 设置请求类型或其他相关参数
    httpWebRequest.Method = WebRequestMethods.Http.Head; // 使用 HTTP HEAD 请求方法
    httpWebRequest.Timeout = 2000; // 设置请求超时时间为 2 秒
    
    // 3. 发送请求，获取响应结果 HttpWebResponse 对象
    HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
    
    // 检查响应的状态码
    if (httpWebResponse.StatusCode == HttpStatusCode.OK)
    {
        // 如果状态码为 200 (OK)，表示文件存在且可用
        print("文件存在且可用");
        print(httpWebResponse.ContentLength); // 打印文件大小
        print(httpWebResponse.ContentType); // 打印文件的 MIME 类型
        
        httpWebResponse.Close(); // 关闭响应对象，释放资源
    }
    else
    {
        // 如果状态码不是 200，文件不能用，打印状态码
        print("文件不能用" + httpWebResponse.StatusCode);
    }
}
catch (WebException w)
{
    // 捕获 WebException 异常，通常表示网络请求出错
    print("获取出错" + w.Message + w.Status); // 打印错误消息和状态信息
}
```

### Get请求类型下载资源
利用 Get 请求类型，下载资源
```cs
try
{
    // 尝试执行以下操作，捕获可能的异常
    // 在这里，我们尝试下载远程文件到本地
    
    // 1. 创建 HTTP 通讯用连接对象 HttpWebRequest 对象
    HttpWebRequest httpWebRequest = HttpWebRequest.Create(new Uri("http://192.168.1.101:8000/HTTPRoot/pic.png")) as HttpWebRequest;
    
    // 2. 设置请求类型或其他相关参数
    httpWebRequest.Method = WebRequestMethods.Http.Get; // 使用 HTTP GET 请求方法
    httpWebRequest.Timeout = 3000; // 设置请求超时时间为 3 秒
    
    // 3. 发送请求，获取响应结果 HttpWebResponse 对象
    HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
    
    // 4. 获取响应数据流，写入本地路径
    if (httpWebResponse.StatusCode == HttpStatusCode.OK)
    {
        // 打印本地数据存储路径
        print("本地存储路径：" + Application.persistentDataPath);
        
        // 创建本地文件流以将下载的数据写入本地
        using (FileStream fileStream = File.Create(Application.persistentDataPath + "/httpPic.png"))
        {
            Stream downloadResponseStream = httpWebResponse.GetResponseStream();
            byte[] bytes = new byte[2048];
            
            // 读取数据
            int contentLength = downloadResponseStream.Read(bytes, 0, bytes.Length);
            
            // 一点一点地写入本地
            while (contentLength != 0)
            {
                fileStream.Write(bytes, 0, contentLength);
                contentLength = downloadResponseStream.Read(bytes, 0, bytes.Length);
            }
            
            fileStream.Close();
            downloadResponseStream.Close();
            httpWebResponse.Close();
        }
        // 打印下载成功消息
        print("下载成功");
    }
    else
    {
        // 如果状态码不是 200 (OK)，下载失败，打印状态码
        print("下载失败，状态码：" + httpWebResponse.StatusCode);
    }
}
catch (WebException w)
{
    // 捕获 WebException 异常，通常表示网络请求出错
    print("下载出错，状态：" + w.Status + "，错误消息：" + w.Message);
}
```

### 测试结果
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/49.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E4%B8%8B%E8%BD%BD%E6%95%B0%E6%8D%AE/1.png)

### Get 请求类型携带额外信息
我们在进行 HTTP 通信时，可以在地址后面加一些额外参数传递给服务端。一般在和短连接游戏服务器通讯时，需要携带额外信息。
举例：
- [http://www.aspxfans.com:8080/news/child/index.asp?boardID=5&ID=24618&page=1](http://www.aspxfans.com:8080/news/child/index.asp?boardID=5&ID=24618&page=1)

这个链接可以分成几部分：
1. 协议部分：取决于服务器端使用的哪种协议
    - http:// —— 普通的 HTTP 超文本传输协议
    - https:// —— 加密的超文本传输协议
2. 域名部分：
    - [www.aspxfans.com](http://www.aspxfans.com/)
    - 也可以填写服务器的公网 IP 地址
3. 端口部分：
    - 8080
    - 可以不写，如果不写默认为 80
4. 虚拟目录部分：
    - news/child/
    - 域名后的 / 开始，到最后一个 / 之前的部分
5. 文件名部分：
    - index.asp
    - ？之前的最后一个 / 后的部分
6. 参数部分：
    - boardID=5&ID=24618&page=1
    - ？之后的部分就是参数部分，多个参数一 & 分隔开
    - 这里有三个参数
        - boardID = 5
        - ID = 24618
        - page = 1

我们在和服务端进行通信时，只要按照这种规则格式进行通信，就可以传递参数给对象。主要可用于：
- web 网站服务器
- 游戏短连接服务器
- 等

### 总结
1. Head 请求类型
    - 主要用于获取文件的一些基础信息，可以用于确定文件是否存在。
2. Get 请求类型
    - 主要用于传递信息给服务器，用于获取具体信息。
    - 服务器返回的信息，可以通过 Response 中的流来获取。
    - 用 Get 请求时，可以在连接中携带一些额外参数（在链接后面加上 ? 参数名=参数值&参数名=参数值&参数名=参数值&…）。
    - 正常的 HTTP 服务器应用程序，都会去解析 Get 请求时连接中的参数进行逻辑处理（后端程序的工作）。
    - 我们主要要掌握的知识点：
        - 额外参数按格式书写
        - 通过 Response 对象中的流来获取返回的数据（数据的类型多种多样，可以是文件、自定义消息等等，我们按照规则解析即可）。
3. 在和 HTTP 服务器通信时，我们经常会使用额外参数的形式传递信息，特别是以后和一些运营平台对接时。
4. 文件下载功能和 Ftp 非常类似，只是其中使用的类、协议、请求类型不同而已。