[ABTest](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/ABTest.cs)


![[Pasted image 20250328223300.png]]

### AB包内部结构
主包：
![[Pasted image 20250524204959.png]]

副包：
![[Pasted image 20250524205033.png]]

AssetBundleFileHeader：记录了版本号、压缩等主要描述信息。

AssetFileHeader：包含一个文件列表，记录了每个资源的name、offset、length等信息。

Asset1：
- AssetHeader：记录了TypeTree大小、文件大小、format等信息。
- TypeTree（可选，有不要TypeTree的构建方式）：记录了Asset对象的class ID。Unity可以用class ID来序列化和反序列化一个类。（每个class对应了一个ID，如0是Object类，1是GameObject类等。具体可在[Unity官网](https://link.segmentfault.com/?enc=XWV10WjQs36A9dlnFy%2FAcg%3D%3D.zfwC3X8NAVtRxTV1xyCn6cshSnDSC6UFJBUykV4%2FKGM1zSABLtsQ8Lb11BMhjlnXaZBsqj8sIbOOb8Xsi3pXaQ%3D%3D)上查询。）
- ObjectPath：记录了path ID（资源唯一索引ID）等。
- AssetRef：记录了AB包对外部资源对引用情况。

Asset2：
.manifest文件信息
![[Pasted image 20250329221150.png]]

```
`ManifestFileVersion: 0 # 文件版本
CRC: 2657307167 # CRC校验码
Hashes: # 哈希
  AssetFileHash: # AB包中所有资源的哈希，可用于增量更新检测
    serializedVersion: 2 # Unity序列化版本
    Hash: 717e408ba50ee41b0960161fd2d5a827
  TypeTreeHash: # AB包中所有类型的哈希，可用于增量更新检测
    serializedVersion: 2 # Unity序列化版本
    Hash: 8d552bf2f5bdba1177c938cb98ca6f2f
HashAppended: 0
ClassTypes: # TypeTree
- Class: 1 # GameObject
  Script: {instanceID: 0}
- Class: 21 # Material
  Script: {instanceID: 0}
- Class: 28 # Texture2D
  Script: {instanceID: 0}
- Class: 48 # Shader
  Script: {instanceID: 0}
- Class: 114 # MonoBehaviour
  Script: {fileID: 1392445389, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: -765806418, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: -1200242548, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: -146154839, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: 708705254, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: 1297475563, guid: f70555f144d8491a825f0804e09c671c, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: 11500000, guid: 20e8969313b8e4614b498f042e99683a, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: 11500000, guid: c86dbe77db44a434bb15895563508b65, type: 3}
- Class: 114 # MonoBehaviour
  Script: {fileID: 11500000, guid: 1a7e2f4cb82d9b94a91270d550c880c0, type: 3}
- Class: 115 # MonoScript
  Script: {instanceID: 0}
- Class: 128 # Font
  Script: {instanceID: 0}
- Class: 198 # ParticleSystem
  Script: {instanceID: 0}
- Class: 199 # ParticleSystemRenderer
  Script: {instanceID: 0}
- Class: 213 # Sprite
  Script: {instanceID: 0}
- Class: 222 # CanvasRenderer
  Script: {instanceID: 0}
- Class: 224 # RectTransform
  Script: {instanceID: 0}
- Class: 687078895 # SpriteAtlas
  Script: {instanceID: 0}
Assets: # 包含资源
- Assets/Bundle/.../a.prefab
- Assets/Bundle/.../b.prefab
- Assets/Bundle/.../c.spriteatlas
Dependencies: # AB包依赖
- /Users/apple/.../AssetBundles/Android/q
- /Users/apple/.../AssetBundles/Android/w
- /Users/apple/.../AssetBundles/Android/e
- /Users/apple/.../AssetBundles/Android/r
- /Users/apple/.../AssetBundles/Android/t` 
```

`Resources`对应的是Resources特殊文件夹路径。（只读）
- 在Unity下对应为：/Assets/Resources。

`Application.streamingAssetsPath`对应的是StreamingAsset文件夹：
- 在Unity下对应为：/Assets/StreamingAssets。（可读可写）
- 在Android下对应为：jar:file:///data/app/xxx.apk!/assets。 （只读）
- 在iOS下对应为：Application/…/xxx.app/Data/Raw。（只读）

`Application.persistentDataPath`对应的是持久化数据存储文件夹路径：
- 在Unity下对应为：/该Unity项目文件夹路径。
- 在Android下对应为：/…/data/应用名/files。
- 在iOS下对应为：Application/…/Documents。iOS还会自动将persistentDataPath路径下的文件上传到iCloud，会占用用户的iCloud空间。如果persistentDataPath路径下的文件过多，苹果审核可能被拒，所以，iOS平台，有些数据得放temporaryCachePath路径下。

`Application.dataPath`对应的是应用Asset文件夹路径。（只读。Android不可读，因为改目录指向的是个.apk文件，而不是目录）
- 在Unity下对应为：/Assets。
- 在Android下对应为：/data/app/…/xxx.apk。
- 在iOS下对应为：Application/…/xxx.app/Data。

`Application.temporaryCachePath`对应的是应用临时数据缓存文件夹路径。（只读）
- 在Unity下对应为：/该Unity项目文件夹路径。
- 在Android下对应为：/…/data/应用名/cache。
- 在iOS下对应为：Application/…/Library/Caches。

# AssetBundleManifest
```cs
    //加载主包中的固定文件
	AssetBundleManifest manifest = mainBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    //从固定文件中 得到依赖的AB包名
    string[] dependencies = manifest.GetAllDependencies("ui");
    //得到依赖的AB包名后，加载依赖的AB包
    for(int i = 0; i < dependencies.Length; i++)
    {
        AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + dependencies[i]);
    }
```
## public string[] GetAllAssetBundles ();
返回：**string[]** 资源捆绑包名称数组。
描述：获取清单中的所有 AssetBundle。

### public string[] GetAllAssetBundlesWithVariant ();
返回：**string[]** 资源捆绑包名称数组。
描述：获取清单中包含变体的所有 AssetBundle。

### public string[] GetAllDependencies (string assetBundleName);
参数：assetBundleName   资源捆绑包的名称。
描述：获取给定 AssetBundle 的所有依赖 AssetBundle。

### public [Hash128](https://docs.unity.cn/cn/2019.4/ScriptReference/Hash128.html) GetAssetBundleHash (string assetBundleName);
参数：assetBundleName	资源捆绑包的名称。
返回：Hash128 资源捆绑包的 128 位哈希值。
描述：获取给定 AssetBundle 的哈希值。

### public string[] GetDirectDependencies (string assetBundleName);
参数：assetBundleName	资源捆绑包的名称。
返回：string[] 该资源捆绑包依赖的资源捆绑包的名称数组。
描述：获取给定 AssetBundle 的直接依赖 AssetBundle。