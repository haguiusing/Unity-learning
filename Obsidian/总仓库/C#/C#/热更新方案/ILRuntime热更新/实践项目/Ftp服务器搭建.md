### 安装Serv-U
- 请按照Serv-U的安装说明进行安装。

创建域，直接不停下一步即可(使用单向加密)
- 在Serv-U中创建一个新的域，按照向导一步一步操作，使用单向加密。

创建用于上传下载的FTP账号密码
- 在Serv-U中创建一个FTP账号和密码，确保该账号有上传和下载的权限。

修改AssetBundleUpdateManager和ABTools代码中上传下载用的用户名和密码以及IP地址，查看当前本机的IP地址
- 打开AssetBundleUpdateManager和ABTools的代码文件，找到相关的部分，将其中的用户名、密码和IP地址改为你在Serv-U中设置的FTP账号信息和本机IP地址。  
    ![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/4.Ftp%E6%9C%8D%E5%8A%A1%E5%99%A8%E6%90%AD%E5%BB%BA/1.png)
    
    -在资源管理器输入[ftp://10.16.0.4/](ftp://10.16.0.4/) 可以正常进入服务器  
    ![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/4.Ftp%E6%9C%8D%E5%8A%A1%E5%99%A8%E6%90%AD%E5%BB%BA/2.png)

完成这些步骤后，你应该能够配置好上传和下载Asset Bundle 的环境了。

### 具体步骤图示参考网络基础中FTp服务器搭建
[https://linwentao785293209.github.io/2024/04/11/网络/01.网络基础基础知识/41.网络通信-文件传输FTP-搭建FTP服务器/](https://linwentao785293209.github.io/2024/04/11/%E7%BD%91%E7%BB%9C/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/41.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E6%96%87%E4%BB%B6%E4%BC%A0%E8%BE%93FTP-%E6%90%AD%E5%BB%BAFTP%E6%9C%8D%E5%8A%A1%E5%99%A8/)