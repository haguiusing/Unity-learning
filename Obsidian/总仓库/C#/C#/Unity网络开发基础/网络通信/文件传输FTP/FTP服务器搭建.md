![[Lesson18 1.cs]]

### 搭建FTP服务器的几种方式
- 使用别人做好的FTP服务器软件（学习阶段建议使用）
- 自己编写FTP服务器应用程序，基于FTP的工作原理，用Socket中TCP通信来进行编程（工作后由后端程序员来做）
- 将电脑搭建为FTP文件共享服务器（工作后由后端程序员来做）

后面两点我们前端程序主要做了解。一般在工作中不会由我们来完成这部分工作。

### 使用别人做好的FTP服务器软件来搭建FTP服务器
#### 主要步骤
1. 下载Serv-U等FTP服务器软件
2. 在想要作为FTP服务器的电脑上运行之
    - 创建域，直接不停下一步即可
    - 使用单向加密
    - 创建用于上传下载的FTP账号和密码

#### 步骤图示
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E6%96%87%E4%BB%B6%E4%BC%A0%E8%BE%93FTP-%E6%90%AD%E5%BB%BAFTP%E6%9C%8D%E5%8A%A1%E5%99%A8/1.png)
![[Pasted image 20250607145948.png]]
![[Pasted image 20250607145951.png]]
![[Pasted image 20250607145955.png]]
![[Pasted image 20250607150006.png]]
![[Pasted image 20250607150010.png]]
![[Pasted image 20250607150013.png]]
![[Pasted image 20250607150017.png]]
![[Pasted image 20250607150024.png]]
![[Pasted image 20250607150029.png]]
![[Pasted image 20250607150032.png]]
在资源管理器输入[ftp://127.0.0.1/](ftp://127.0.0.1/) 和账号密码  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E6%96%87%E4%BB%B6%E4%BC%A0%E8%BE%93FTP-%E6%90%AD%E5%BB%BAFTP%E6%9C%8D%E5%8A%A1%E5%99%A8/12.png)

### 总结
在实际商业项目开发当中，如果需要用FTP来进行文件传输，那么FTP服务器的解决方案都是由后端程序员来完成的。不管它使用哪种方式来搭建FTP服务器，只要能正常上传下载内容并且保证安全性即可。