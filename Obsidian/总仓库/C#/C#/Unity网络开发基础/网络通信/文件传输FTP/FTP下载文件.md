![[Lesson21.cs]]

### 使用FTP下载文件关键点
- 通信凭证：进行FTP连接操作时需要的账号密码。
- 操作命令：设置你想要进行的FTP操作。
- 文件流相关：上传和下载时都会使用的文件流。下载文件流使用FtpWebResponse类获取。
- 保证FTP服务器已经开启，并且能够正常访问。
### FTP下载
```cs
try
{
    // 创建一个Ftp连接。
    // 这里和上传不同，上传的文件名是自己定义的，下载的文件名一定是资源服务器上有的，比如一张叫pic的图片。
    FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri("ftp://127.0.0.1/pic.png")) as FtpWebRequest;

    // 设置通信凭证(如果不支持匿名，就必须设置这一步)。
    ftpWebRequest.Credentials = new NetworkCredential("MrTao", "MrTao");

    // 请求完毕后是否关闭控制连接，如果要进行多次操作，可以设置为false。
    ftpWebRequest.KeepAlive = false;

    // 设置操作命令。
    ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;

    // 指定传输类型。
    ftpWebRequest.UseBinary = true;

    // 代理设置为空。
    ftpWebRequest.Proxy = null;

    // 得到用于下载的流对象。
    // 相当于把请求发送给FTP服务器，返回值就会携带我们想要的信息。
    FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;

    // 这就是下载的流。
    Stream downloadResponseStream = ftpWebResponse.GetResponseStream();

    // 开始下载。
    print(Application.persistentDataPath);
    using (FileStream fileStream = File.Create(Application.persistentDataPath + "/pic2.png"))
    {
        // 读取流的字节数组。
        byte[] bytes = new byte[1024];

        // 读取下载下来的流数据。
        int contentLength = downloadResponseStream.Read(bytes, 0, bytes.Length);

        // 一点一点的下载到本地流中。
        while (contentLength != 0)
        {
            // 把读取出来的字节数组写入到本地文件流中。
            fileStream.Write(bytes, 0, contentLength);

            // 继续读。
            contentLength = downloadResponseStream.Read(bytes, 0, bytes.Length);
        }

        // 下载结束，关闭流。
        downloadResponseStream.Close();
        fileStream.Close();
    }
    print("下载结束");
}
catch (Exception e)
{
    print("下载出错" + e.Message);
}
```