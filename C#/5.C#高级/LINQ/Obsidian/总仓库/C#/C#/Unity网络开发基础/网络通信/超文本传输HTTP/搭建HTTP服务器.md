![[Lesson23 1.cs]]

[HFS: HTTP File Server (version 3) 0.57.0 - suv789 - 博客园](https://www.cnblogs.com/suv789/p/12124442.html)

### 搭建 HTTP 服务器的几种方式
- **1. 使用别人做好的 HTTP 服务器软件：** 一般作为资源服务器时使用该方式（学习阶段建议使用）
- **2. 自己编写 HTTP 服务器应用程序：** 一般作为 Web 服务器或者短连接游戏服务器时使用该方式（工作后由后端程序员来做）一般在工作中不会由我们来完成这部分工作

### 使用别人做好的 HTTP 服务器软件来搭建 HTTP 资源服务器
- 下载 HFS 等 HTTP 服务器软件
- 在想要作为 HTTP 资源服务器的电脑上运行之

### 使用别人做好的 HTTP 服务器软件来搭建 HTTP 资源服务器
- 下载 HFS 等 HTTP 服务器软件
- 在想要作为 HTTP 资源服务器的电脑上运行之
#### HFS 搭建 HTTP 服务器步骤
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E6%90%AD%E5%BB%BAHTTP%E6%9C%8D%E5%8A%A1%E5%99%A8/1.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E6%90%AD%E5%BB%BAHTTP%E6%9C%8D%E5%8A%A1%E5%99%A8/2.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E6%90%AD%E5%BB%BAHTTP%E6%9C%8D%E5%8A%A1%E5%99%A8/3.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E8%B6%85%E6%96%87%E6%9C%AC%E4%BC%A0%E8%BE%93HTTP-%E6%90%AD%E5%BB%BAHTTP%E6%9C%8D%E5%8A%A1%E5%99%A8/4.png)

### 使用别人做好的 Web 服务器进行测试
- **我们在学习过程中，可以直接在别人做好的 Web 服务器上获取信息和资源**
- **比如我们可以下载任意网站上可被下载的图片**

### 总结
在实际商业项目开发当中，HTTP 资源服务器可以自己写也可以用别人做好的软件。HTTP 网站服务器或游戏服务器需要自己根据需求进行实现。这些工作一般都是由后端或者运维程序员来进行制作。我们主要做了解，我们之后主要着重学习前端 HTTP 相关的知识点。

在游戏开发时，我们更多时候需要的是 HTTP 的资源服务器。除非你要做短连接游戏，那么后端程序可以以 HTTP 协议为基础来开发服务端应用程序。我们只需要学习前端用于进行 HTTP 通信的相关知识即可。