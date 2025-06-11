### 生成AB包
因为AB包工具中写死了AB包是放在ArtRes文件夹下的，所以创建相关文件夹
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/1.png)

生成AB包时，不能生成StreamingAssets文件夹中的资源，我们需要修改热更DLL、PDB文件的生成路径。生成后也要改成txt后缀。
![[Pasted image 20250603230743.png]]
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/2.png)  
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/3.png)

给我们要上传的资源添加到AB包。并且设置打包路径在ArtRes下，修改压缩方式。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/4.png)  
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/5.png)

生成AB包时，代码`appDomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId` 会有所冲突，会报错。需要先注释掉才能打包成功，打包完后解注释就行。

![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/6.png)
上传AB包

记得在Ftp服务器路径中新建文件夹用于上传AB包，要创建AB和对应平台的文件夹，因为这是上传时写好的规则。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/7.png)

上传前要创建对比文件。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/8.png)

点击上传AB包和对比文件，可以上传成功。
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/9.png)  
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E7%9B%B8%E5%85%B3AB%E5%8C%85%E7%94%9F%E6%88%90%E4%B8%8A%E4%BC%A0/10.png)

选择默认资源
LoadingPanel 应该作为默认资源，不然加载时啥也看不到。可以看到生成了默认包和对比文件。注意主包也要选择。