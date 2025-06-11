# 1.AssetBundle是什么
AssetBundle是Unity提供的热更新方案

 表现形式上是一个存档文件，包含可在运行时由 Unity 加载的特定于平台的非代码资源（比如模型、纹理、预制件、音频剪辑甚至整个场景）

[AssetBundle - Unity 手册](https://docs.unity.cn/cn/2022.3/Manual/AssetBundlesIntro.html "AssetBundle - Unity 手册") ,其本质就是一个文件夹(或者压缩包),用来存储/加载重要资源

其包含了有两类文件

序列化文件
![[Pasted image 20250328205655.png]]

源文件
![[Pasted image 20250328205853.png]]

# 2.抽象流程分析
![[Pasted image 20250328205900.png]]
## 游戏运行时
加载 AssetBundle：从文件或服务器加载 AssetBundle
加载 Asset：从 AssetBundle 中加载具体的资源
卸载 AssetBundle 和 Asset：使用完资源后，卸载 AssetBundle 和资源以释放内存
## AssetBundle本身
AssetBundle：包含打包的资源文件
manifest：包含 AssetBundle 的元数据，用于管理依赖关系和版本控制
## 编辑器下
直接加载资源路径下的资源文件：在编辑器模式下，直接从资源路径加载资源文件
AssetDatabase 加载 Asset：使用 AssetDatabase API 加载资源
StreamingAssets 文件夹下的资源文件不做处理直接使用：StreamingAssets 文件夹中的资源文件在运行时直接使用，无需打包
# AssetBundle的作用
![[Pasted image 20250328210027.png]]
![[Pasted image 20250328210131.png]]
