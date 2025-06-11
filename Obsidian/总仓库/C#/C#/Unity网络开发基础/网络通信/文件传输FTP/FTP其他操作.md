![[Lesson22 1.cs]]

### FTP其它操作指什么？
- **除了上传和下载，我们可能会对FTP服务器上的内容进行其它操作**
    - 删除文件
    - 获取文件大小
    - 创建文件夹
    - 获取文件列表
    - 等等

1. **`AppendFile` ("APPE")**
    - **作用**：将数据追加到服务器上的一个现有文件中。
    - **用途**：如果文件已存在，不会覆盖文件内容，而是将新数据追加到文件末尾。
2. **`DeleteFile` ("DELE")**
    - **作用**：删除服务器上的一个文件。
    - **用途**：用于删除不再需要的文件。
3. **`DownloadFile` ("RETR")**
    - **作用**：从服务器下载文件。
    - **用途**：将服务器上的文件传输到本地客户端。
4. **`GetDateTimestamp` ("MDTM")**
    - **作用**：获取文件的最后修改时间戳。
    - **用途**：用于检查文件的最后修改时间。
5. **`GetFileSize` ("SIZE")**
    - **作用**：获取文件的大小（以字节为单位）。
    - **用途**：用于在下载或上传文件之前获取文件大小信息。
6. **`ListDirectory` ("NLST")**
    - **作用**：列出指定目录中的文件和子目录名称。
    - **用途**：用于获取目录中的文件列表，但不包含详细信息。
7. **`ListDirectoryDetails` ("LIST")**
    - **作用**：列出指定目录中的文件和子目录的详细信息（包括文件大小、修改时间等）。
    - **用途**：用于获取目录中文件的完整信息。
8. **`MakeDirectory` ("MKD")**
    - **作用**：在服务器上创建一个新的目录。
    - **用途**：用于创建新的文件夹。
9. **`PrintWorkingDirectory` ("PWD")**
    - **作用**：打印当前工作目录的路径。
    - **用途**：用于确认当前所在的目录位置。
10. **`RemoveDirectory` ("RMD")**
    - **作用**：删除一个目录。
    - **用途**：用于删除不再需要的目录。
11. **`Rename` ("RENAME")**
    - **作用**：重命名文件或目录。
    - **用途**：用于更改文件或目录的名称。
12. **`UploadFile` ("STOR")**
    - **作用**：将文件上传到服务器。
    - **用途**：将本地文件传输到服务器上。
13. **`UploadFileWithUniqueName` ("STOU")**
    - **作用**：将文件上传到服务器，并自动分配一个唯一的文件名。
    - **用途**：用于避免文件名冲突，服务器会为上传的文件生成一个唯一的名称。
### 进行其它操作

#### 其他操作逻辑都写在FTP管理器上

##### 移除指定的文件
```cs
/// <summary>
/// 移除指定的文件
/// </summary>
/// <param name="fileName">文件名</param>
/// <param name="action">移除过后想做什么的委托函数</param>
public async void DeleteFile(string fileName, UnityAction<bool> action = null)
{
    await Task.Run(() => {
        try
        {
            // 通过一个线程执行这里面的逻辑 那么就不会影响主线程了
            // 1.创建一个Ftp连接
            FtpWebRequest req = FtpWebRequest.Create(new Uri(FTP_PATH + fileName)) as FtpWebRequest;
            // 2.进行一些设置
            // 凭证
            req.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            // 是否操作结束后 关闭 控制连接
            req.KeepAlive = false;
            // 传输类型
            req.UseBinary = true;
            // 操作类型
            req.Method = WebRequestMethods.Ftp.DeleteFile;
            // 代理设置为空
            req.Proxy = null;

            // 3.真正的删除
            FtpWebResponse ftpWebResponse = req.GetResponse() as FtpWebResponse;
            ftpWebResponse.Close();

            // 删除成功
            action?.Invoke(true);
        }
        catch (Exception e)
        {
            Debug.Log("移除失败" + e.Message);

            // 删除失败
            action?.Invoke(false);
        }
    });
}
```

##### 获取FTP服务器上某个文件的大小
```cs
/// <summary>
/// 获取FTP服务器上某个文件的大小 （单位 是 字节）
/// </summary>
/// <param name="fileName">文件名</param>
/// <param name="action">获取成功后传递给外部 具体的大小</param>
public async void GetFileSize(string fileName, UnityAction<long> action = null)
{
    await Task.Run(() => {
        try
        {
            // 通过一个线程执行这里面的逻辑 那么就不会影响主线程了
            // 1.创建一个Ftp连接
            FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri(FTP_PATH + fileName)) as FtpWebRequest;

            // 2.进行一些设置
            // 凭证
            ftpWebRequest.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            // 是否操作结束后 关闭 控制连接
            ftpWebRequest.KeepAlive = false;
            // 传输类型
            ftpWebRequest.UseBinary = true;
            // 操作类型
            ftpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            // 代理设置为空
            ftpWebRequest.Proxy = null;

            // 3.真正的获取
            FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
            // 把大小传递给外部 ContentLength是响应对象的字节的大小
            action?.Invoke(ftpWebResponse.ContentLength);

            ftpWebResponse.Close();
        }
        catch (Exception e)
        {
            Debug.Log("获取大小失败" + e.Message);
            action?.Invoke(0);
        }
    });
}
```

##### 创建一个文件夹
```cs
/// <summary>
/// 创建一个文件夹 在FTP服务器上
/// </summary>
/// <param name="directoryName">文件夹名字</param>
/// <param name="action">创建完成后的回调</param>
public async void CreateDirectory(string directoryName, UnityAction<bool> action = null)
{
    await Task.Run(() => {
        try
        {
            // 通过一个线程执行这里面的逻辑 那么就不会影响主线程了

            // 1.创建一个Ftp连接
            FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri(FTP_PATH + directoryName)) as FtpWebRequest;

            // 2.进行一些设置
            // 凭证
            ftpWebRequest.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            // 是否操作结束后 关闭 控制连接
            ftpWebRequest.KeepAlive = false;
            // 传输类型
            ftpWebRequest.UseBinary = true;
            // 操作类型
            ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            // 代理设置为空
            ftpWebRequest.Proxy = null;

            // 3.真正的创建
            FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
            ftpWebResponse.Close();

            action?.Invoke(true);
        }
        catch (Exception e)
        {
            Debug.Log("创建文件夹失败" + e.Message);
            action?.Invoke(false);
        }
    });
}
```

##### 获取指定路径下 所有文件的文件名 不包括子文件夹
```cs
/// <summary>
/// 获取指定路径下 所有文件的文件名 不包括子文件夹
/// </summary>
/// <param name="directoryName">文件夹路径</param>
/// <param name="action">返回给外部使用的 文件名列表</param>
public async void GetFileList(string directoryName, UnityAction<List<string>> action = null)
{
    await Task.Run(() => {
        try
        {
            // 通过一个线程执行这里面的逻辑 那么就不会影响主线程了

            // 1.创建一个Ftp连接
            FtpWebRequest ftpWebRequest = FtpWebRequest.Create(new Uri(FTP_PATH + directoryName)) as FtpWebRequest;

            // 2.进行一些设置
            // 凭证
            ftpWebRequest.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            // 是否操作结束后 关闭 控制连接
            ftpWebRequest.KeepAlive = false;
            // 传输类型
            ftpWebRequest.UseBinary = true;
            // 操作类型
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            // 代理设置为空
            ftpWebRequest.Proxy = null;

            // 3.真正的创建
            FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
            // 把下载的信息流 转换成StreamReader对象 方便我们一行一行的读取信息
            StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream());

            // 用于存储文件名的列表
            List<string> nameStrs = new List<string>();
            // 一行行的读取
            string line = streamReader.ReadLine();
            while (line != null)
            {
                // 文件名列表添加元素
                nameStrs.Add(line);
                // 一行行的读取
                line = streamReader.ReadLine();
            }
            ftpWebResponse.Close();

            action?.Invoke(nameStrs);
        }
        catch (Exception e)
        {
            Debug.Log("获取文件列表失败" + e.Message);
            action?.Invoke(null);
        }
    });
}
```

#### 进行其他操作测试
```cs
// 1.删除文件
FtpManager.Instance.DeleteFile("MrTaoPic.png", (result) =>
{
    print(result ? "删除成功" : "删除失败");
});
// 假如服务器上没有指定删除的文件会报错

// 2.获取文件大小
FtpManager.Instance.GetFileSize("pic.png", (size) =>
{
    print("文件大小为：" + size);
});

// 3.创建文件夹
FtpManager.Instance.CreateDirectory("韬老狮", (result) =>
{
    print(result ? "创建成功" : "创建失败");
});
// 假如服务器上有指同名文件夹会报错

// 4.获取文件列表
FtpManager.Instance.GetFileList("", (list) =>
{
    if (list == null)
    {
        print("获取文件列表失败");
        return;
    }
    for (int i = 0; i < list.Count; i++)
    {
        print(list[i]);
    }
});
```