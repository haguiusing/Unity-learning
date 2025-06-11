
### 什么是Protobuf
- **Protobuf**  
    Protobuf全称是 protocol-buffers（协议缓冲区），是谷歌提供给开发者的一个开源的协议生成工具。它的主要工作原理和我们之前做的自定义协议工具类似，只不过它更加的完善，可以基于协议配置文件生成C++、Java、C#、Objective-C、PHP、Python、Ruby、Go等语言的代码文件。
    
    它是商业游戏开发中常常会选择的协议生成工具。有很多游戏公司选择它作为协议工具来进行网络游戏开发，因为它通用性强，稳定性高，可以节约出开发自定义协议工具的时间。
    
    [protocol-buffers官网](https://developers.google.com/protocol-buffers)

### Protobuf的使用流程
1. 下载对应语言要使用Protobuf相关内容
2. 根据配置规则编辑协议配置文件
3. 用Protobuf编译器，利用协议配置文件生成对应语言的代码文件
4. 将代码文件导入工程中进行使用

### 下载Protobuf相关内容——准备DLL文件
#### 在官网中前往下载地址，[protocol-buffers官网](https://developers.google.com/protocol-buffers)
![[Pasted image 20250608132213.png]]
#### 下载protobuf-csharp
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/2.png)
#### 解压后打开csharp\src中的Google.Protobuf.sln
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/3.png)
#### 选择Google.Protobuf右键生成 dll文件，可能遇到对应.net的sdk版本未下载，要查看当前电脑的,net版本并修改global.json文件
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/4.png)

![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/5.png)

![[Pasted image 20250608132411.png]]

#### 在csharp\src\Google.Protobuf\bin\Debug路径下找到对应.net版本的Dll文件（我们使用4.5即可）
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/7.png)

#### 将net45中的dll文件导入到Unity工程中的Plugins插件文件夹中
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/8.png)

### 下载Protobuf相关内容——准备编译器
#### 在官网中前往下载地址，[protocol-buffers官网](https://developers.google.com/protocol-buffers)，下载protoc-版本-win32或者64（根据操作系统而定）
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/9.png)

#### 解压后获取bin文件夹中的protoc.exe可执行文件
![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/66.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%88%9D%E8%AF%86%E5%92%8C%E5%87%86%E5%A4%87Protobuf%E5%B7%A5%E5%85%B7/10.png)
![[Pasted image 20250608132807.png]]

#### 可将其放入Unity工程中，方便之后的使用（你也可以不放入Unity工程，记住它的路径即可）

### 总结
Protobuf全称protocol-buffers，是谷歌提供给开发者的开源协议生成工具。

我们要使用它主要准备两步：
1. 下载对应Csharp版本，生成DLL包文件导入工程中（之后的基类，序列化反序列化都基于DLL包中写好的内容）
2. 下载对应操作系统的protoc编译器，用于之后生成代码文件（之后根据配置文件生成代码都是通过该应用程序）

