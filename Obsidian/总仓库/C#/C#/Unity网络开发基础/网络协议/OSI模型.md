### 主要内容
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/2.png)

### OSI模型是什么
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/3.png)

### OSI模型的规则
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/4.png)
物理层（物）、数据链路层（链）、网络层（网）、传输层（叔）、会话层（会）、表示层（示|使）、应用层（用）
![[Pasted image 20250606002042.png]]
![[Pasted image 20250606002150.png]]
##### 物理层
主要定义物理设备标准，如网线的接口类型、光纤的接口类型、各种传输介质的传输速率等。它的主要作用是传输比特流（就是由 1、0 转化为电流强弱来进行传输,到达目的地后在转化为1、0，也就是我们常说的模数转换与数模转换）。这一层的数据叫做比特。
##### 数据链路层
主要将从物理层接收的数据进行 <font color="#ffff00">MAC 地址</font>（网卡的地址）的封装与解封装。常把这一层的数据叫做帧。在这一层工作的设备是交换机，数据通过交换机来传输。
##### 网络层
主要将从下层接收到的数据进行 <font color="#ffff00">IP 地址</font>（例 192.168.0.1)的封装与解封装。在这一层工作的设备是路由器，常把这一层的数据叫做数据包。
##### 传输层
定义了一些传输数据的协议和<font color="#ffff00">端口号</font>（WWW 端口 80 等），如：TCP（传输控制协议，传输效率低，可靠性强，用于传输可靠性要求高，数据量大的数据），UDP（用户数据报协议，与 TCP 特性恰恰相反，用于传输可靠性要求不高，数据量小的数据，如 QQ 聊天数据就是通过这 种方式传输的）。主要是将从下层接收的数据进行分段进行传输，到达目的地址后在进行重组。常常把这一层数据叫做段。
##### 会话层
通过传输层（端口号：传输端口与接收端口）建立数据传输的通路。主要在你的系统之间发起会话或或者接受会话请求（设备之间需要互相认识可以是 IP 也可以是 MAC 或者是主机名）
##### 表示层
主要是进行对接收的数据进行解释、加密与解密、压缩与解压缩等（也就是把计算机能够识别的东西转换成人能够能识别的东西（如图片、声音等））
##### 应用层
主要是一些终端的应用，比如说FTP（各种文件下载），WEB（IE浏览），QQ之类的（你就把它理解成我们在电脑屏幕上可以看到的东西．就是终端应用）。

### OSI模型每层的职能
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/7.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/8.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/9.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/10.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/11.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/12.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/13.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/14.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/15.png)  
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/16.png)
![[Pasted image 20250606100720.png]]
![[Pasted image 20250606100724.png]]

### OSI七层模型
1. **应用层**
    - 为应用程序提供服务，程序员可操作的层，定义协议和发送数据。
2. **表示层**
    - 负责数据格式转换和数据加密，翻译数据使其在各个操作系统都能生效。
3. **会话层**
    - 建立、管理和维护会话，维护设备通信会话，例如检查对方是否收到数据、是否断开连接。
4. **传输层**
    - 建立、管理和维护端到端的连接，加入端口信息。
5. **网络层**
    - 负责 IP 地址选址和路由选择，加入 IP 地址信息。
6. **数据链路层**
    - 分帧，确定 MAC 地址，加入 MAC 地址信息。
7. **物理层**
    - 负责真正的物理设备传输数据，传输比特流和电信号。

### OSI模型对于我们的意义
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.%E7%BD%91%E7%BB%9C%E5%8D%8F%E8%AE%AE-OSI%E6%A8%A1%E5%9E%8B/19.png)