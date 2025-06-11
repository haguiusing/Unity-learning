因为AB包存放着游戏的各种资源，所以如果AB包不加密，那么别人在得到AB包的时候可以直接看到AB包内所有的资源。经过一定特殊操作后可以直接从AB包中导出图片、音频、动画，甚至可以在Unity中直接实例化出来另存为Prefab。

加密思路如下：
1、在构建完AB包后，可以将AB包中的内容以byte[]形式读取。
2、之后选用任意加密方式对该byte[]加密。
3、加密完后重新写入AB包中。
4、AB包加密完成。

这样对AB包加密之后，如果使用AssetBundle.LoadFromFile()来加载加密的AB包是会报错的，因为Unity以及无法识别加密过后的内容了，这样也就防止了别人随意对AB包进行的读取和加载，保证了资源的安全性。

解密思路如下：
1、先以byte[]形式读取AB包中的内容。
2、之后使用对应的解密算法对该byte[]进行解密。
3、解密过后的byte[]通过AssetBundle.LoadFromMemory()来进行加载。
4、AB包加载完成。

总的来说，这种二进制加密AB包的方式虽然有效，但是加载时间和内存占用是一个需要考虑的问题。很多时候选择不进行加密，一方面原因是因为需要多占用一份内存的问题，代价过大。虽然说从byte[]加载成AB包之后，byte[]可以从内存中释放，但是在加载的过程中还是会有一个内存占用的巅峰。

另一种简单的加密方式，即可以实现直接手段加载不出AB包，而且相对上述二进制加密AB包方式加载更快、耗费更小。

本质是通过在AB包中添加偏移量来实现加密。
``` cs
    public static AssetBundle LoadFromFile(string path, uint crc, ulong offset);
```

AssetBundle.LoadFromFile()的第三个参数是AB包内容的byte偏移量。也就是说从offset个byte开始读取AB包的内容。

因此如果在构建完AB包之后，在AB包前插入N个随机byte，那么此时想要加载该AB包，如不知道这个N值，则是无法成功读取和加载AB包的。这也就实现了加密。

### 从Stream中加载
AssetBundle.LoadFromStream()不像AssetBundle.LoadFromMemory()会多占用一份内存。
``` cs
    public static AssetBundle LoadFromStream(Stream stream, uint crc, uint managedReadBufferSize)
```

这是从托管流中加载AB包的方法。它跟LoadFromFile()一样，只会读取AB包的头文件。

使用Stream加载的限制：
1、AB包数据必须是从Stream的0位置开始。
2、当从AssetBundle数据的末尾开始并尝试读取数据时，Stream实现必须返回读取的0字节且不引发异常。
3、Stream必须是可读（CanRead返回true）和可搜寻（CanSeek返回true）的。
4、可以从任何Unity线程中调用Seek()和Read()。