![[Lesson20 1.cs]]

### 使用FTP上传文件关键点
- 通信凭证：进行FTP连接操作时需要的账号密码。
- 操作命令：设置你想要进行的FTP操作。
- 文件流相关：上传和下载时都会使用的文件流。
- 保证FTP服务器已经开启，并且能够正常访问。

#### Ser-U开启服务器例子
在远程服务器机找到Ser-U文件夹下的Ser-U-Tray.exe，右键以管理员的身份运行，这样就开启了服务器。使用 `ipconfig /all` 查看远程机的IP地址。在本机输入远程机的IP地址，输入账号密码进行访问，验证成功后可以在服务器创建文件。注意要关闭防火墙，否则可能无法访问。

### FTP上传
```cs
try
{
    // 创建一个Ftp连接，pic.png代表想上传名叫pic的png图片。
    // 这里的ftp://127.0.0.1是使用本机开启服务器进行测试，实际使用时应该是远端服务器IP。
    FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri("ftp://127.0.0.1/pic.png")) as FtpWebRequest;

    // 设置通信凭证(如果不支持匿名，就必须设置这一步)。
    // 将代理相关信息置空，避免服务器同时有http相关服务造成冲突。
    ftpWebRequest.Proxy = null;

    // 创建并设置通信凭证。
    NetworkCredential networkCredential = new NetworkCredential("MrTao", "MrTao");
    ftpWebRequest.Credentials = networkCredential;

    // 请求完毕后是否关闭控制连接，如果想要关闭，可以设置为false。
    ftpWebRequest.KeepAlive = false;

    // 设置操作命令。
    ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;//设置命令操作为上传文件。

    // 指定传输类型，使用二进制。
    ftpWebRequest.UseBinary = true;

    // 得到用于上传的流对象。
    Stream uploadRequestStream = ftpWebRequest.GetRequestStream();

    // 开始上传，使用流读取StreamingAssets文件夹下的名叫test的图片。
    using (FileStream fileStream = File.OpenRead(Application.streamingAssetsPath + "/test.png"))
    {
        // 我们可以一点一点的把这个文件中的字节数组读取出来，然后存入到上传流中。
        byte[] bytes = new byte[1024];

        // 返回值是真正从文件中读了多少个字节。
        int contentLength = fileStream.Read(bytes, 0, bytes.Length);

        // 不停的去读取文件中的字节，除非读取完毕了，不然一直读，并且写入到上传流中。
        while (contentLength != 0)
        {
            // 写入上传流中。
            uploadRequestStream.Write(bytes, 0, contentLength);

            // 写完了继续读。
            contentLength = fileStream.Read(bytes, 0, bytes.Length);
        }

        // 出了循环就证明写完了。
        fileStream.Close();
        uploadRequestStream.Close();

        // 上传完毕。
        print("上传结束");
    }
}
catch (Exception e)
{
    print("上传出错，失败" + e.Message);
}
```

![[Pasted image 20250607152217.png]]

开启服务器，挂载脚本后可以成功上传。

### 总结
C#已经把FTP相关操作封装的很好了，我们只需要熟悉API，直接使用它们进行FTP上传即可。我们主要做的操作是把本地文件流读出字节数据写入到要上传的FTP流中。FTP上传相关API也有异步方法，使用上和以前的TCP相关类似，这里不赘述。