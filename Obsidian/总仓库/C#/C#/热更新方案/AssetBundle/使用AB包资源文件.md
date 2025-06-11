[ABTest](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/ABTest.cs)

### 4、压缩文件/AB包的加载
四种不同的API来加载资产包。它们的行为取决于构建资产包时所使用的包加载平台和压缩方法(未压缩、lzma、lz4)。
#### 同步加载
**AssetBundle LoadFromFile (string path, uint crc, ulong offset)：**[AssetBundle-LoadFromFile - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromFile.html)

**AssetBundle LoadFromMemory (byte[] binary, uint crc)：**[AssetBundle-LoadFromMemory - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromMemory.html)
说明：不推荐，两倍AB内存占用，三倍资源内存占用

**AssetBundle LoadFromStream (Stream stream, uint crc, uint managedReadBufferSize)：**[AssetBundle-LoadFromStream - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromStream.html)

**\WWW.LoadFromCacheOrDownload**
说明：Unity5.6之前使用，已废弃

#### 异步加载
**LoadFromFileAsync (string path, uint crc, ulong offset)：**[AssetBundle-LoadFromFileAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromFileAsync.html)

**LoadFromMemoryAsync (byte[] binary, uint crc)：**[AssetBundle-LoadFromMemoryAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromMemoryAsync.html)

**LoadFromStreamAsync (Stream stream, uint crc, uint managedReadBufferSize)：**[AssetBundle-LoadFromStreamAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadFromStreamAsync.html)

- AssetBundle.LoadFromMemoryAsync
- AssetBundle.LoadFromFile
- WWW.LoadfromCacheOrDownload
- UnityWebRequest’s DownloadHandlerAssetBundle(Unity 5.3 or newer)

**AssetBundle.LoadFromMemoryAsync (byte[] binary, uint crc);**
此函数接受一个包含资产包数据的字节数组。如果您愿意，也可以传入CRC值。如果包是lzma压缩的，它将在加载时解压资产包。lz4压缩包在压缩状态下加载。下面是如何使用此方法的一个示例：
``` cs
 IEnumerator LoadFromMemoryAsync(string path)
    ｛
        AssetBundleCreateRequest createRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return createRequest;
        AssetBundle bundle = createRequest.assetBundle;
        var prefab = bundle.LoadAsset.<GameObject>("MyObject");
        Instantiate(prefab);
    ｝
```
然而，这并不是唯一能够使用loadfromMemy异步的策略，可以用任何获得字节数组的过程来替换File.ReadAllBytes(path)。


> （1）我们来试下加载刚压缩的这个音频文件，新建脚本AssetBundleLoaderMgr，代码如下（该代码不需要挂载，后面直接调用的）：
``` cs
public class AssetBundleLoaderMgr
{
    /// <summary>
    /// 初始化，加载AssetBundleManifest，方便后面查找依赖
    /// </summary>
    public void Init()
    {
        string streamingAssetsAbPath = Path.Combine(Application.streamingAssetsPath, "StandaloneWindows");
        AssetBundle streamingAssetsAb = AssetBundle.LoadFromFile(streamingAssetsAbPath);
        m_manifest = streamingAssetsAb.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    }
    /// <summary>
    /// 加载AssetBundle
    /// </summary>
    /// <param name="abName">AssetBundle名称</param>
    /// <returns></returns>
    public AssetBundle LoadAssetBundle(string abName)
    {
        AssetBundle ab = null;
        if (!m_abDic.ContainsKey(abName))
        {
            string abResPath = Path.Combine(Application.streamingAssetsPath, abName);
            ab = AssetBundle.LoadFromFile(abResPath);
            m_abDic[abName] = ab;
        }
        else
        {
            ab = m_abDic[abName];
        }
        return ab;
    }
    /// <summary>
    /// 从AssetBundle中加载Asset
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="abName">AssetBundle名</param>
    /// <param name="assetName">Asset名</param>
    /// <returns></returns>
    public T LoadAsset<T>(string abName, string assetName) where T : Object
    {
        AssetBundle ab = LoadAssetBundle(abName);
        T t = ab.LoadAsset<T>(assetName);
        return t;
    }
    /// <summary>
    /// 缓存加载的AssetBundle，防止多次加载
    /// </summary>
    private Dictionary<string, AssetBundle> m_abDic = new Dictionary<string, AssetBundle>();
    /// <summary>
    /// 它保存了各个AssetBundle的依赖信息
    /// </summary>
    private AssetBundleManifest m_manifest;
    /// <summary>
    /// 单例
    /// </summary>
    private static AssetBundleLoaderMgr s_instance;
    public static AssetBundleLoaderMgr instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new AssetBundleLoaderMgr();
            return s_instance;
        }
    }
}
```
（2）调用加载，进行测试：把该代码挂载在物体上，输入要加载对象的AssetBundle标签名跟预制体名即可。
![](https://i-blog.csdnimg.cn/blog_migrate/4923bd19d4060b29153fd7606f7a762e.png)
``` cs
public class Main : MonoBehaviour
{
    [Header("标签名：")]
    public string assetBundle;
    [Header("预制体名：")]
    public string prefabName;
    void Awake()
    {
        //初始化
        AssetBundleLoaderMgr.instance.Init();
    }
    void LoadAsset()
    {
        //加载预设
        GameObject prefab = AssetBundleLoaderMgr.instance.LoadAsset<GameObject>(assetBundle, prefabName);
        //实例化预设
        Instantiate(prefab);
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 50), "LoadAsset"))
        {
            LoadAsset();
        }
    }
}
```

## 5.AB包中资源的加载
#### 同步加载
**public Object[] LoadAllAssets**[AssetBundle-LoadAllAssets - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAllAssets.html)

**public Object LoadAsset**[AssetBundle-LoadAsset - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAsset.html)

**public Object[] LoadAssetWithSubAssets**[AssetBundle-LoadAssetWithSubAssets - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAssetWithSubAssets.html)

#### 异步加载
**public [AssetBundleRequest](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundleRequest.html) LoadAllAssetsAsync**[AssetBundle-LoadAllAssetsAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAllAssetsAsync.html)

**public [AssetBundleRequest](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundleRequest.html) LoadAssetAsync**[AssetBundle-LoadAssetAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAssetAsync.html)

**public [AssetBundleRequest](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundleRequest.html) LoadAssetWithSubAssetsAsync**[AssetBundle-LoadAssetWithSubAssetsAsync - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.LoadAssetWithSubAssetsAsync.html)

#### 其他
**public bool Contains (string name);**[AssetBundle-Contains - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.Contains.html)检查 AssetBundle 是否包含特定对象。
如果 AssetBundle 包含 `name` 引用的对象，则返回 true，否则返回 false。

**public string[] GetAllAssetNames ();**[AssetBundle-GetAllAssetNames - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.GetAllAssetNames.html)
返回 AssetBundle 中的所有资源名称。
仅适用于普通 AssetBundles（非流式传输的场景 AssetBundle），否则返回空字符串数组。

**public string[] GetAllScenePaths ();**[AssetBundle-GetAllScenePaths - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.GetAllScenePaths.html)
返回 AssetBundle 中的所有场景资源路径（*.unity 资源的路径）。
仅适用于流式传输的场景 AssetBundles，否则返回空字符串数组。

**public void Unload (bool unloadAllLoadedObjects);**[AssetBundle-Unload - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.Unload.html)
卸载 AssetBundle 释放其数据。
当 `unloadAllLoadedObjects` 为 false 时，将释放捆绑包本身中的压缩文件数据，但已从该捆绑包中加载的任何对象实例将保持不变。  
当 `unloadAllLoadedObjects` 为 true 时，也将销毁从该捆绑包加载的所有对象。如果场景中有 GameObjects 引用这些资源，则对它们的引用将丢失。  
不管是哪种情况，除非重新加载该捆绑包，否则将无法再从它加载任何其他对象。  
有关所使用的不同压缩格式及其在加载时对内存的影响的说明，请参阅[构建 AssetBundle](https://docs.unity.cn/cn/2019.4/Manual/AssetBundles-Building.html)。

## 三、资源复用
当然，在实际项目中我们会遇到多个预制体有相同的部分，要是一个一个压缩，还是有点浪费资源，所以我们可以把共同的部分单独作为一个AssetBundle进行压缩，其他不同的部分再各自压缩就好了。所以，这样其他不同的部分就会跟这个共同部分产生一个依赖，我们要加载的时候，也必须把依赖加载上，不然就会造成资源丢失，不是原本的预制体的效果。
那么来试一下。
1、再新建个预制体Audio1，新标签audio1，用刚才的那个背景音乐，这样的话，Audio与Audio1有共同的资源song。
![](https://i-blog.csdnimg.cn/blog_migrate/5c5a01dbcd29d9691baa1cc321dafbad.png) ![](https://i-blog.csdnimg.cn/blog_migrate/2eeca2a14117e9e489e315b834e72df4.png)
2、拖入之后，我们会看到有感叹号出现，是因为有共同的资源song，我们可以在左侧栏右键，新建一个bundle，命名为res，把共用的素材放进去，再一起打包即可。
![](https://i-blog.csdnimg.cn/blog_migrate/6cafbdbb226f38fa7b97fe9f8334aaed.png) ![](https://i-blog.csdnimg.cn/blog_migrate/5a3ac5a211743a3de4edf2df9e403c19.gif)
3、这样就简单实现了资源复用，可以看到，audio和audio1都对res产生了依赖关系，所以加载audio或audio1时，也要把res加载进去，这样才完整。
![](https://i-blog.csdnimg.cn/blog_migrate/9cbef60dca5cb33230613b79ee529395.png)
4、资源加载
> （1）我们试一下上面所用的代码，不加载依赖，只加载audio，看看效果
> 
> ![](https://i-blog.csdnimg.cn/blog_migrate/ad5f4e1da264c90874bb253d44245fae.gif)
> 会发现，Audio Source的AudioClip丢失了，这就是因为没有把依赖的res文件夹加载上来。
> 
> （2）所以，要加载完整，我们可以对上面的AssetBundleLoaderMgr脚本加上加载依赖的代码，如下所示
``` cs
        //加载依赖
        string[] dependences = m_manifest.GetAllDependencies(abName);
        int dependenceLen = dependences.Length;
        if (dependenceLen > 0)
        {
            for (int i = 0; i < dependenceLen; i++)
            {
                string dependenceAbName = dependences[i];
                if (!m_abDic.ContainsKey(dependenceAbName))
                {
                    AssetBundle dependenceAb = LoadAssetBundle(dependenceAbName);
                    m_abDic[dependenceAbName] = dependenceAb;
                }
            }
        }
```
把这一段放入AssetBundleLoaderMgr脚本的如下位置，其他不做改变。
![[Pasted image 20250328212324.png]]
（3）再来验证一下，这里就加载上来了。
![](https://i-blog.csdnimg.cn/blog_migrate/6402cc027f4b6c8e46ac0afcf215bcdc.gif)
（4）两个audio的最终加载效果
![](https://i-blog.csdnimg.cn/blog_migrate/35a1c16a2bc33f78d7f4cf4dc75d84b4.gif)

# 四、从服务器获取AB包
[Networking.UnityWebRequestAssetBundle-GetAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.UnityWebRequestAssetBundle.GetAssetBundle.html)
可使用 [UnityWebRequest](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.UnityWebRequest.html) 下载资源捆绑包的 Helpers。

```cs
public class MyBehaviour : [MonoBehaviour](https://docs.unity.cn/cn/2019.4/ScriptReference/MonoBehaviour.html)
{
    void Start()
    {
        StartCoroutine(GetText());
    }  
  
    IEnumerator GetText()
    {
        using ([UnityWebRequest](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.UnityWebRequest.html) uwr = [UnityWebRequestAssetBundle.GetAssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.UnityWebRequestAssetBundle.GetAssetBundle.html)("http://www.my-server.com/mybundle"))
        {
            yield return uwr.SendWebRequest();  
  
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                [Debug.Log](https://docs.unity.cn/cn/2019.4/ScriptReference/Debug.Log.html)(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                [AssetBundle](https://docs.unity.cn/cn/2019.4/ScriptReference/AssetBundle.html) bundle = [DownloadHandlerAssetBundle.GetContent](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.DownloadHandlerAssetBundle.GetContent.html)(uwr);
            }
        }
    }
}
```
[Networking.UnityWebRequestAssetBundle-GetAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.UnityWebRequestAssetBundle.GetAssetBundle.html)
[Networking.DownloadHandlerAssetBundle - Unity 脚本 API](https://docs.unity.cn/cn/2019.4/ScriptReference/Networking.DownloadHandlerAssetBundle.html)