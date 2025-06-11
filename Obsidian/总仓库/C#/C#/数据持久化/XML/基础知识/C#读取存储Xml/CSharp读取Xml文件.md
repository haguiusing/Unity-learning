![[LoadXml.cs]]
## 一、资源路径

Unity中的资源路径在Window平台下打印出来如下图：
![](https://pic2.zhimg.com/v2-69dada2d0b0eb9371abe3fbe2a605dd9_b.jpg)

![](https://pic1.zhimg.com/v2-7c7fa71ddb45ef9d2c751b073fa4455c_b.jpg)

**Android平台**
![](https://pic1.zhimg.com/v2-c550a826d664b7e095b7d8f00e9d4bfe_b.jpg)

**iOS平台**
![](https://pica.zhimg.com/v2-631756754f7ec2de42b23d211254c5e2_b.jpg)

1、Application.dataPath
用于返回工程文件所在位置的数据文件夹的路径
`public string filePath;//存档路径`
 
`private void Awake()`
    `{`
        `filePath = Application.dataPath + "/StreamingFile/jsonDatas.txt"；`
        `filePath = Application.dataPath + "/StreamingAssets/jsonDatas.json";`
    `}`
 
`//数据流形式读取文件数据`
`private void testLoad()`
    `{`
        `if (!File.Exists(FilePath)) Debug.Log("找不到存档文件");`
        `else`
        `{`
            `StreamReader sr = new StreamReader(FilePath);`
            `string ReadStr = sr.ReadToEnd();`
            `sr.Close();`
            `Ddatas tempDatas= JsonMapper.ToObject<Datas>(ReadStr);`
            `datas= tempDatas;`
        `}`
    `}`

2、Application.streamingAssetsPath
用于返回流数据的缓存目录，返回路径为相对路径，适合设置一些外部数据文件的路径。
`public string filePath;//存档路径`
 
`private void Awake()`
`{`
     `filePath = Application.streamingAssets +"jsonDatas.txt"；`
    `filePath = Application.dataPath + "/StreamingAssets/jsonDatas.json";`
`}`
`private void testLoad()`
`{`
    `Application.streamingAssetsPath（filePath）;`
`}`

3、Application.persistenDataPath
用于返回一个持久化数据存储目录的路径，可以在此路径下存储一些持久化的数据文件。

该值是目录路径；此目录中可以存储每次运行要保留的数据。在 iOS 和 Android 上发布时，persistentDataPath 指向设备上的公共目录。应用程序更新不会擦除此位置中的文件。用户仍然可以直接擦除这些文件。

内容可读写，不过只能运行时才能写入或者读取

是一个外部存储路径，和项目安装位置无关的绝对路径，多是保存用户信息数据的位置，升级版本不会影响到这些数据；

考虑多平台的话，尽量存到Application.persistenDataPath；

public string filePath;//存档路径
 
private void Temp()
{
    filePath = Application.persistentDataPath + "/jsonDatas.json";
}

4、Application.temporaryCachePath
用于返回一个临时数据的缓存目录。

是用来放缓存和临时的，用户可以清理掉；
`public string filePath;//存档路径`
 
`private void Temp()`
`{`
    `filePath = Application.temporaryCachePath+ "/jsonDatas.json";`
`}`

5、Application.consoleLogPath
描述：Unity 编辑器或构建应用程序的日志文件路径。

使用场景：用于获取日志文件的位置，主要用于调试。这个路径在不同平台上会有所不同，通常位于系统日志目录中。

6、Application.unityCachePath
描述：Unity缓存的路径。

使用场景：用于缓存和优化资源的加载速度。这个路径在不同平台上有所不同，通常用于缓存数据的存储。
