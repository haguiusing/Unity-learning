[The PureMVC framework](http://puremvc.org/)
#### 一、PureMVC基本概念
##### 1. 主要学什么
- 内容概述: 本节课将学习PureMVC的基本概念，包括PureMVC是什么、如何获取以及它的基本结构。

##### 2. PureMVC是什么 
![[Pasted image 20250427152449.jpg]]
- 定义: PureMVC是基于MVC思想和一些基础设计模式建立的一个轻量级的应用框架。
- 特性:
    - 免费开源: 框架是免费且开源的。
    - 多平台支持: 最初执行于ActionScript 3，现已移植到几乎所有主流平台，如Unity、Cocos等。

##### 3. PureMVC如何获取
![[Pasted image 20250427152502.jpg]]
- 获取途径: 通过访问PureMVC的官方网站（http://puremvc.org/）进行下载。
- 额外资源: 官方网站还提供框架的基本说明及多语言（如中文）的文档支持。

##### 4. PureMVC的基本结构
![[Pasted image 20250427152511.jpg]]
- 结构概述: PureMVC的基本结构在MVC的基础上，增加了Proxy、Mediator、Command和Facade等组件。
- 组件详解:
    - Model与Proxy: Proxy作为代理模式的一种体现，负责处理数据，为Model提供一层包裹。
    - View与Mediator: Mediator作为中介者模式的一种实现，主要负责处理界面。
    - Controller与Command: Command作为命令模式的一种实现，负责处理业务逻辑。
    - Facade: Facade作为外观模式的一种实现，是三者（Model、View、Controller）的经纪人，统管全局。
- 通知机制: Notification作为观察者模式的一种实现，用于通知数据变化、界面更新等。
- ![[Pasted image 20250427152521.jpg]]
- 设计模式组合: PureMVC通过MVC与设计模式（如代理模式、中介者模式、外观模式、命令模式、观察者模式、单例模式）的组合，实现了一个更加框架化的MVC思想。

##### 5. 总结
- PureMVC是什么: 基于MVC思想的第三方开源框架。
- PureMVC如何获取: 通过官方网站（http://puremvc.org/）前往Github获取。
- PureMVC的基本结构: MVC+Proxy+Mediator+Command+Facade。 ![[Pasted image 20250427152532.jpg]]
- 学习要点: 了解PureMVC的基本概念、获取方式及基本结构，为后续深入学习奠定基础。

#### 二、Unity中MVC思想
##### 1. PureMVC实际应用的框架导入和通知名类
###### 1）纯净版PureMVC框架的导入
- 纯净版PureMVC框架的获取
    - 获取方式: 通过访问PureMVC官网，点击C#按钮，进入GitHub页面下载。
- 纯净版PureMVC框架单核版本和多核版本的区别
    - 区别概述: 单核版本只允许有一个Facade对象（单例），而多核版本允许有多个Facade对象，适用于更复杂的系统模块化管理。 
- 纯净版PureMVC框架标准版本的导入
    - 导入步骤: 在GitHub页面选择标准版本进行下载。 
- 纯净版PureMVC框架的解压
    - 解压操作: 将下载的压缩包解压到指定目录，如桌面。 
- 纯净版PureMVC框架的导入方式一
    - 导入方式一: 通过Visual Studio打开.sln文件，生成DLL包，并将DLL包导入到Unity的Plugins文件夹中。 
- 纯净版PureMVC框架的导入方式二
    - 导入方式二: 直接将PureMVC核心代码文件夹（如Patterns、Core、Interfaces）拖入Unity项目中的指定文件夹（如Scripts/PureMVC）。 

###### 2）通知名类的建立
- 通知名类的创建
    - 创建目的: 通知名类主要用于声明和管理PureMVC中的通知名字，方便使用和避免字符串错误。
    - 创建步骤:
        - 在Scripts文件夹下新建PureMVC文件夹。
        - 在PureMVC文件夹中创建名为PureNotification的C#脚本。
        - 在脚本中声明常量字符串，如public const string SHOW_PANEL = "showPanel";，用于表示通知名字。 
    - 使用方式: 通过类名.常量名的方式使用通知名字，如PureNotification.SHOW_PANEL。 