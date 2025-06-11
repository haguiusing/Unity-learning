![[Pasted image 20250606193448.png]]
### 主要内容
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E6%A6%82%E8%BF%B0/2.png)
### 服务端和客户端代码应该怎么写
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E6%A6%82%E8%BF%B0/3.png)
### TCP协议三次握手的体现
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E6%A6%82%E8%BF%B0/4.png)
### TCP协议四次挥手的体现
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E6%A6%82%E8%BF%B0/5.png)

### 总结
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/18.%E7%BD%91%E7%BB%9C%E9%80%9A%E4%BF%A1-%E5%A5%97%E6%8E%A5%E5%AD%97Socket-TCP%E9%80%9A%E4%BF%A1-%E6%A6%82%E8%BF%B0/6.png)

### 请简述Socket TCP编程中：服务端的编程流程和客户端的编程流程

#### 服务端的编程流程
##### 等待客户端连入
创建套接字Socket对象
使用Bind方法绑定地址
使用Listen方法设置监听最大数量
使用Accept接受方法等待客户端连入
##### 相互通信
利用Accept返回的套接字和客户端进行通信
##### 结束通信断开连接
调用Shutdown方法释放连接
调用Close方法关闭套接字
#### 客户端的编程流程
##### 与服务端建立连接
创建套接字Socket对象
利用Connect方法连接远端服务端
##### 相互通信
利用套接字对象和远端服务端进行通信
##### 结束通信断开连接
调用Shutdown方法释放连接
调用Close方法关闭套接字
