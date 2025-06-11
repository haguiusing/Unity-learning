[官方文档](https://puremvc.org/docs/PureMVC_IIBP_Chinese.pdf)
## 一、通知名类
用来申明各个 通知 的名字 
方便使用和管理
[PureNotification](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/PureNotification.cs)
## 二、Model和Proxy
[PlayerDataObj](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/Model/PlayerDataObj.csfile:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/Model/PlayerDataObj.cs)：玩家的数据结构 
[PlayerProxy](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/Model/PlayerProxy.cs)：玩家数据代理对象
Proxy套路写法：
1、继承Proxy父类并覆盖父类代理的名字
2、构造函数，传入玩家数据代理名和玩家的数据结构数据（可选）实现初始化
3、一系列数据处理方法
4、可选：重写注册时的方法  void OnRegister()
5、可选：重写注销时的方法  void OnRemove()
## 三、View和Mediator
[NewMainView](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/View/NewMainView.cs)：面板控件引用，可以使用MVC或MVP思想提供面板更新的相关方法给外部
[NewMainViewMediator](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/View/NewMainViewMediator.cs)：面板代理对象
Mediator套路写法：
1、继承Mediator父类并覆盖父类代理的名字
2、构造函数，传入面板代理名和UI界面（可选，object）实现初始化
3、重写监听通知的方法  string[] ListNotificationInterests()
4、重写处理通知的方法  void HandleNotification(INotification notification)
5、可选：重写注册时的方法  void OnRegister()
6、可选：重写注销时的方法  void OnRemove()
## 四、Facade和Command执行流程
[GameFacade](file:///G:/Unity/Unity%E9%A1%B9%E7%9B%AE/Framework/Assets/Scripts/MVC%E6%A1%86%E6%9E%B6/PureMVC/GameFacade.cs)：统一的接口来简化交互
Facade套路写法：
1、继承PureMVC中Facade脚本
2、写一个单例模式的属性
3、初始化 控制层相关的内容
  将 命令 和 通知 进行绑定的逻辑，即使用switch表达式绑定string和Command
4、启动函数
[Command]()
1、继承Command相关的脚本
2、重写里面的执行函数  void Execute(INotification notification)

可以理解为Mediator中使用ListNotificationInterests(监听通知)和HandleNotification(处理通知)实现事件系统；Facade中使用InitializeController(命令和通知的绑定)和Command(处理通知)的事件系统
但是（观察者）Mediator是通过通知为外部提供处理面板上的逻辑的方法，（主题）Facade则负责给外部（被观察者）提供触发通知的方法，可通过通知触发Mediator中监听的通知。

## 五、Notifier通知
MacroCommand、SimpleCommand、Mediator、Facade都间接继承Notifier
外部通过使用void SendNotification(string notificationName, object body = null, string type = null)触发/发送通知