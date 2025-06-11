- Model：存储数据内容、初始化、更新 升级、保存
PlayerModel

- View：找控件、更新面板数据（传入PlayerModel数据）
MainView  主界面
RoleView   角色面板

- ViewModel：存储view可能用到的数据
MainViewModel
RoleViewModel
#### 一、MVVM的概念
##### 1. MVVM的概念
- MVVM全称: 模型（Model）—视图（View）—视图模型（ViewModel）
- 各部分职责:
    - Model提供数据。
    - View负责界面。
    - ViewModel负责逻辑的处理。
    - ![[Pasted image 20250427152137.jpg]]

##### 2. MVVM的由来
- 由来: MVVM是由MVP（Model-View-Presenter）模式与WPF结合应用时发展演变过来的一种新型框架。
##### 3. 演示WPF
- WPF定义: Windows Presentation Foundation，是微软提供的一种用于开发桌面软件应用的工程模式。
- 演示内容:
    - 在Visual Studio中新建WPF应用项目。
    - 创建一个窗口，窗口信息由XAML文件（UI面板配置文件）定义。
    - 在窗口中添加按钮，XAML文件中会相应增加按钮的配置。![[Pasted image 20250427152151.jpg]]
- MVVM衍生原因: UI相关的东西都产生了一个类似XAML的配置文件，这是MVVM开发方式衍生的一个原因。
#### 二、MVVM和MVP的对比
##### 1. 数据绑定的概念
- 数据绑定定义: 数据绑定就是将一个用户界面元素（控件）的属性绑定到一个类型（对象）实例上的某个属性的方法。
- 数据绑定原理: 如果开发者有一个MainViewMode类型的实例，那么他就可以把MainViewMode的"Lev"属性绑定到一个UI中Text的"Text"属性上。绑定了这两个属性之后，对Text的Text属性的更改将“传播”到MainViewMode的Lev属性，而对MainViewMode的Lev属性的更改同样会“传播”到Text的Text属性。![[Pasted image 20250427152206.jpg]]
###### 1）数据绑定的演示
- 演示说明: 通过数据双向绑定，将View中的控件属性（如Text的Text属性）与ViewModel中的属性（如MainViewModel的Name、Lev、Money属性）绑定起来。当其中一方的属性发生变化时，另一方的对应属性也会随之变化。![[Pasted image 20250427152219.jpg]]
##### 2. MVVM在Unity中水土不服
- 原因一: View对象始终由我们来书写，并没有UI配置文件（如WPF中的XAML）的存在。
- 原因二: 硬要在Unity中实现MVVM，需要写三模块（View、ViewModel、Model），并且还要对V和VM进行数据绑定，工作量大且好处不够明显。 ![[Pasted image 20250427152241.jpg]]

##### 3. Unity的第三方MVVM框架
- 框架介绍: Loxodon Framework和uMVVM是Unity中的两种第三方MVVM框架。
- 评价: 这些框架在Unity中实现MVVM需要写很多代码，工作量变大，且好处不明显。它们更多是为了实现框架而实现，而非为了方便开发。 ![[Pasted image 20250427152251.jpg]]
##### 4. 唐老狮的MVVM粗暴变式—MP
- MP概念: 将MVVM中的View和ViewModel合二为一，用户操作变为Panel。关键是保持V和VM的数据双向绑定，即改变V或VM的属性，对方也会随之变化。
- 目的: 达到将界面和逻辑某种意义上的解耦，简化开发流程。
- 建议: 如果之前没有接触过MVVM或相关框架，可以直接跳过MVVM的实例，学习MVVM的概念，并通过后续的小框架视频来感受MVVM的应用。 ![[Pasted image 20250427152307.jpg]]

#### 三、知识小结

|                |                                                                                 |                                    |      |
| -------------- | ------------------------------------------------------------------------------- | ---------------------------------- | ---- |
| 知识点            | 核心内容                                                                            | 考试重点/易混淆点                          | 难度系数 |
| MVVM基本概念       | MVVM全称为模型（Model）-视图（View）-视图模型（View Model），Model提供数据，View负责界面，View Model负责逻辑处理。 | MVVM与MVP的区别和联系                     | 中等   |
| MVVM由来         | MVVM由MVP模式与WPF结合应用时发展演变而来。                                                      | WPF的含义及其在MVVM中的作用                  | 中等   |
| WPF简介          | WPF是C#开发桌面软件应用提供的一种工程模式，通过VS新建WPF应用可创建窗口应用程序，UI配置由XAML文件完成。                     | WPF与MVVM的关系                        | 简单   |
| 数据双向绑定         | 数据绑定是将UI元素属性绑定到类对象实例的某个属性上，实现属性的相互传播和更新。                                        | 数据绑定的实现方式和意义                       | 较难   |
| MVVM与MVP对比     | MVVM与MVP相似，但View和View Model之间通过数据双向绑定连接，实现了更紧密的关联。                              | MVP中的Presenter与MVVM中的View Model的区别 | 中等   |
| MVVM在Unity中的应用 | Unity中界面由开发者自己编写，没有类似WPF的UI配置文件，因此MVVM在Unity中应用存在水土不服。                          | Unity中实现MVVM的复杂性和必要性               | 较难   |
| 第三方MVVM框架      | 存在两种第三方MVVM框架可在Unity中应用，但实现框架需要写很多代码，工作量变大。                                     | 第三方框架的优缺点及适用场景                     | 中等   |
| MVVM核心         | MVVM的关键是View和View Model的数据双向绑定，改变一方属性，另一方也会随之改变。                                | 数据双向绑定的实现原理                        | 较难   |
| 建议             | 在Unity中不建议使用MVVM框架，因其实现复杂且好处不明显。建议了解MVVM概念，但不必在Unity中实际应用。                      | Unity开发中的框架选择建议                    | 简单   |