# Asset Bundle 格式简析
文章目录
Asset Bundle 格式简析
	1. Header 信息
	2. BlocksInfo
		2.1 BlockInfo
		2.2 每个block信息
	3. 路径信息
		3.1 每个路径节点信息
	4. 数据

Unity 中，AssetBundle 可以理解成一个档案文件，其中包含了压缩的资源文件。用户在使用 AssetBundle 时，可以流式加载资源，用户可以以数据流的方式陆续地、按需地加载 AssetBundle 中资源的各个部分。可以用 Asset Studio 看下 Bundle 中的具体内容，比如我们打开一个 AB 包，看到一个 ScrollList_Equip_jinse 的资源，该资源下又挂了几个粒子系统。
![[Pasted image 20250524221912.png]]
简单说明 AssetBundle 是什么之后，下面开始介绍下中的数据具体是什么样的

## 1. Header 信息
跟其他格式的文件一样，Unity AssetBundle 会先写入头信息，写入标记、版本号、文件大小等信息。Unity AssetBundle 中的头信息如下所示。
![[Pasted image 20250524221930.png]]

| 数据                                                                                                   | 二进制示例                                                                                     |
| ---------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| Unity标记，比如这里表示 UnityFS                                                                               | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/305a9a57b7521f113b86218504ca7b38.png) |
| Archive 的版本号，此处版本号为 6                                                                                | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/5de45cbce6e6b03b3c1b2dbb17830823.png) |
| Unity Bundle 的版本号                                                                                    | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/2ec47176a9e0951aca0849fe6fd476b2.png) |
| bundle所需的最小版本号  <br>这里使用的是 Unity2018.4.18f1 的程序进行打包，此bundle有效运行的最小版本号为 Unity2018.4.18f1              | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/a09a6dfcd6a671498055480486f01c38.png) |
| 整个AssetBundle文件的大小(header + blocks/directory + data)  <br>_此处，注意，使用大端序，比如此处文件的大小是 0x65fb，而不是 0xfb65_ | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/7960af1bdcba80bc351ab6025eb4403f.png) |
| 压缩的block数据大小  <br>_此处，注意，使用大端序_                                                                      | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/326b0b8f2fd8e25c155d701ad8774202.png) |
| 未压缩的block数据大小  <br>_此处，注意，使用大端序_                                                                     | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/294370fb993d0c91f8d6f4a53d700898.png) |
| 压缩选项 `ArchiveFlags`                                                                                  | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/2cbd027e1ad1c61f99ff7b084b857c72.png) |
## 2. BlocksInfo
在写完头信息后，开始写入 block（数据块） 信息，block 信息会保存所有数据块的压缩前的大小、压缩后的大小以及Flags。这部分数据，unity 默认使用 Lz4HC 进行压缩，这里解压缩这部分数据，以方便分析。

### 2.1 BlockInfo
首先会写入一个 Hash 值，以及有多少个 block。
即使只有一个文件，如果文件比较大，也会存成多个 Block，unity在开启流失加载的情况下，每个block的最大值是 128Kb。

| 数据               | 二进制示例                                                                                     |
| ---------------- | ----------------------------------------------------------------------------------------- |
| Block数据未压缩前的hash | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/44a8feb2ee53d6dbfc49354312067aa7.png) |
| block 数量（大端序编写）  | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/d02bfc28e210bd9d8c92341523e8f24a.png) |

### 2.2 每个block信息
每个 block 会有10个字节的数据，压缩前后的block大小 8 个字节，flags 有2个字节大小

|数据|二进制示例|
|---|---|
|未压缩的block数据大小（大端序）  <br>示例中表示的大小为 0x01ccd8|![image.png](https://i-blog.csdnimg.cn/blog_migrate/a31673fd7aa000bb3b2de7781227eb38.png)|
|压缩的block数据大小（大端序）  <br>示例中表示 0x6588|![image.png](https://i-blog.csdnimg.cn/blog_migrate/1690a0b426ae2d13bd704a77f9b1fe6f.png)|
|Flags，比如 block 是不是 流式加载|![image.png](https://i-blog.csdnimg.cn/blog_migrate/33ee2f1608ec6ebd9cec54feccc44329.png)|

## 3. 路径信息
这部分存储的是每个子文件的路径。当然首先存储的是路径数量，本文示例中只有一个文件，数量为1。

|数据含义|二进制示例|
|---|---|
|路径 数量_（大端序）_|![image.png](https://i-blog.csdnimg.cn/blog_migrate/df6786b30f0dbaf3b2037a995765337f.png)|
### 3.1 每个路径节点信息
| 数据                                                                                    | 二进制示例                                                                                     |
| ------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| 路径信息数据的位置，第一个文件路径节点，其值一定是 0 _（大端序）_                                                   | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/8cd0b11673ba05a1996e5ab593cba775.png) |
| 该节点未压缩数据的大小_（大端序）_                                                                    | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/1dd1c52b4fc2dddbc64dbcc71552e884.png) |
| 节点标志，如是否是一个路径，是否是 serialize文件…_（大端序）_  <br>_如本例中，值为0x04，表示序列化的文件，而本例中确实是 material 文件_ | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/6134c6cf2cf778d85ddc44d4122d69ae.png) |
| 该节点对应的文件路径，比如`CAB-3bdc32e90076da9198352f0261e7413c`                                   | ![image.png](https://i-blog.csdnimg.cn/blog_migrate/0852dfef2872a26836dbd104583dd5ea.png) |
## 4. 数据
之后存储的就是一个个文件数据了
