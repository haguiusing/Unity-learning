![[Pasted image 20250606110234.png]]
### 主要内容
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/2.png)

### TCP/IP协议中的重要协议
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/3.png)
![[Pasted image 20250606110522.png]]

### TCP协议
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/5.png)
![[Pasted image 20250606110642.png]]
![[Pasted image 20250606110652.png]]
![[Pasted image 20250606110713.png]]

### UDP协议
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/9.png)
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/10.png)

### 总结
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/11.png)
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/9.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-TCP%E5%92%8CUDP/12.png)

### 请说明TCP协议和UDP协议的区别
- 连接方面：TCP面向连接，UDP无连接
- 是否可靠：TCP可靠（无差错、不丢失、不重复、按顺序），UDP不可靠
- 传输效率：TCP相对UDP较低
- 连接对象：TCP一对一，UDP n对n

### 请简述TCP协议 三次握手，四次挥手在做什么？
#### 三次握手：
i. 第一次：C—>S ，TCP连接请求  
ii. 第二次：S—>C，授予TCP连接  
iii. 第三次：C—>S，TCP确认连接  
iv. 三次握手过后就可以相互通信了

#### 四次挥手：
i. 第一次：C—>S，告诉服务器客户端数据发完了，想要断开连接  
ii. 第二次：S—>C，告诉客户端等待服务器的剩余消息  
iii. 2,3次之间服务器会把剩余消息全部发送给客户端  
iv. 第三次：S—>C，告诉客户端消息发完了，可以断开连接了  
v. 第四次：C—>S，告诉服务器我等一会就要断开连接了  
vi. 四次挥手过后，连接正式断开