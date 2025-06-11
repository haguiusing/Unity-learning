## 一、AB包获取
![[Pasted image 20250328210705.png]]
[Changelog | Package Manager UI website](https://docs.unity3d.com/Packages/com.unity.assetbundlebrowser@1.7/changelog/CHANGELOG.html)
![[Pasted image 20250328210858.png]]
### 旧版轻量化可视化AB包工具
![[Pasted image 20250328211712.png]]

![[Pasted image 20250524151308.png]]

![[Pasted image 20250328211715.jpg]]
![[Pasted image 20250328211719.png]]
![[Pasted image 20250328213933.png]]
AssetBundle的压缩方式
      Unity支持 三种 AssetBundle打包的压缩方式：LZMA, LZ4, 以及不压缩。
 
1、LZMA压缩方式——流压缩方式（stream-based）
      BuildAssetBundleOptions.None  是一种默认的压缩形式，这种标准压缩格式是一个单一LZMA流序列化数据文件，并且在使用前需要解压缩整个包体。LZMA压缩是比较流行的压缩格式，能使压缩后文件达到最小，但是解压相对缓慢，导致加载时需要较长的解压时间。

 2、LZ4压缩方式（推荐）——块压缩方式（chunk-based）
       BuildAssetBundleOptions.ChunkBasedCompression   Unity支持LZ4压缩，能使得压缩量更大，而且在使用资源包前不需要解压整个包体。LZ4压缩是一种“Chunk-based”算法，因此当对象从LZ4压缩包中加载时，只有这个对象的对应模块被解压即可，这速度更快，意味着不需要等待解压整个包体。LZ4压缩格式是在Unity5.3版本中开始引入的，之前的版本不可用。
![[1460000038943918.webp]]
 
 3、不压缩的方式
       BuildAssetBundleOptions.UncompressedAssetBundle  不压缩的方式打包后包体会很大，导致很占用空间，但是一旦下载Assetbundle，访问非常快。不推荐这种方式打包，因为现在的加载功能做的很友好了，完全可以用加载界面来进行后台加载资源，而且时间也不长。
![[Pasted image 20250328213253.png]]
默认包文件及其依赖信息；无后缀为资源文件，.manifest为对应资源文件的配置信息
![[Pasted image 20250328213520.png]]
![[Pasted image 20250328211722.png]]
## 二、打包流程
1、新建一个预制体，例如下图，再给它一个AssetBundle标签audio，点击一下助手左上角的刷新，则标签为audio的预制体就会出现（也可以直接拖进来）。
![](https://i-blog.csdnimg.cn/blog_migrate/f4f4e713b8d62699a10ac75f8ad649e9.png) ![](https://i-blog.csdnimg.cn/blog_migrate/3c2e7b4a2c30b039a270d70637fc20c4.png) ![](https://i-blog.csdnimg.cn/blog_migrate/cb70b7b958722233a29a8c2076cafa65.png)

2、接下来，切换到Build栏，设置好发布平台和路径，（一般也会选择复制到StreamingAssets文件夹中，方便加载调用）就可以点击Build进行压缩了。
![](https://i-blog.csdnimg.cn/blog_migrate/b8ad938af765d5080aff4db7f52926b4.png)

3、压缩完后，在Project窗口中右键刷新，就可以在StreamingAssets文件夹中看到压缩过的文件。其中StandaloneWindows文件只会出现这两个，后面再压缩其他文件不会再出现，只会产生两个压缩过的文件。
![](https://i-blog.csdnimg.cn/blog_migrate/1b6bf58b9f6c2ec51158348efa41b2bd.png)

