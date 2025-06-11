![[Lesson42.cs]]

### 回顾 Protobuf
- Protobuf 全称是 protocol-buffers（协议缓冲区）
- 它是谷歌提供给开发者的一个开源的协议生成工具
- 它的主要工作原理和我们之前做的自定义协议工具类似
- 只不过它更加完善，可以基于协议配置文件生成
- 支持 C++、Java、C#、Objective-C、PHP、Python、Ruby、Go 等语言的代码文件
- 我们之前学习了如何使用它，已经能够使用 Protobuf 来配置协议，生成协议，使用协议了。

### Protobuf-Net 是什么
- 早期的 Protobuf 并不支持 C#
- 国外大神 Marc Gravell 在 Protobuf 的基础上进行了 .NET 环境下的移植
- 并发布到了 GitHub
- 让我们可以基于 Protobuf 的规则进行 C# 的代码生成，对象的序列化和反序列化
- Protobuf-Net 的 GitHub 地址：[https://github.com/protobuf-net/protobuf-net](https://github.com/protobuf-net/protobuf-net)
    
- 注意：
    - Protobuf 不支持 .Net3.5 及以下版本  
        所以如果想在 Unity 的老版本中使用 Protobuf 我们只能使用 Protobuf-Net  
        而在较新版本的 Unity 中不存在这个问题
    - 如何判断是否支持？  
        只要把 Protobuf 相关 dll 包导入后能够正常使用不报错，则证明支持

### 下载获取 Protobuf-Net
Protobuf-Net 的 GitHub 地址：[https://github.com/protobuf-net/protobuf-net](https://github.com/protobuf-net/protobuf-net)

我们需要在 GitHub 上去获取对应的工程生成后获取：
- DLL 库文件
- 根据配置生成脚本的编译器可执行程序

### 总结
- Protobuf-net 相对来说是较老的生产方式
- 但是它可以解决老版本 Unity 使用 Protobuf 的问题
- 它的使用方式和之前学习的 Protobuf 相关知识类似
- 只是获取 DLL 文件、protoc.exe 文件的方式不同而已
- 如果想要详细学习，可以前往 GitHub 看相关说明
- 在这里我们就不详细讲解了
- 目前我们使用的较新 Unity 版本直接使用之前学习的 Protobuf 相关知识完成需求即可。

