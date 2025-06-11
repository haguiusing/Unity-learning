![[Lesson40.cs]]

### 利用 protoc.exe 编译器生成脚本文件
- 打开 cmd 窗口
- 进入 protoc.exe 所在文件夹（也可以直接将 exe 文件拖入 cmd 窗口中）
- 输入转换指令
```cs
protoc.exe -I=配置路径 --csharp_out=输出路径 配置文件名
```

- 注意：路径不要有中文和特殊符号，避免生成失败
- 生成的类名会和配置文件名一样，只是首字母大写，将其拷贝到 Unity 中使用
- 有报错会告诉在哪一行 比如上节课的
```
//required 在proto2才能使用 给testF去掉required修饰符
float testF = 1; //C# - float
reserved "testInt3233333";//忘记加双引号
```

- 对上节课的test和test2都执行生成协议  
    ![](https://linwentao785293209.github.io/images/%E7%BD%91%E7%BB%9C/%E7%BD%91%E7%BB%9C%E5%BC%80%E5%8F%91%E5%9F%BA%E7%A1%80/Unity/01.%E7%BD%91%E7%BB%9C%E5%9F%BA%E7%A1%80%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/68.%E6%B6%88%E6%81%AF%E5%A4%84%E7%90%86-%E7%AC%AC%E4%B8%89%E6%96%B9%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90%E5%B7%A5%E5%85%B7Protobuf-%E5%8D%8F%E8%AE%AE%E7%94%9F%E6%88%90/1.png)

![[Test.cs]]
![[Test2.cs]] ^17fc6e

### 测试生成对象是否能使用
```cs
TestMsg testMsg = new TestMsg();
testMsg.TestBool = true;
// 对应的和 List 以及 Dictionary 使用方式一样的 数组和字典对象
testMsg.ListInt.Add(1);
print(testMsg.ListInt[0]);
testMsg.TestMap.Add(1, "韬老狮");
print(testMsg.TestMap[1]);

// 枚举
testMsg.TestEnum = TestEnum.Boss;
// 内部枚举
testMsg.TestEnum2 = TestMsg.Types.TestEnum2.Boss;

// 其它类对象
testMsg.TestMsg2 = new TestMsg2();
testMsg.TestMsg2.TestInt32 = 99;
// 其它内部类对象
testMsg.TestMsg3 = new TestMsg.Types.TestMsg3();
testMsg.TestMsg3.TestInt32 = 55;
// 在另一个生成的脚本当中的类 如果命名空间不同 需要命名空间点出来使用
testMsg.TestHeart = new GameSystemTest.HeartMsg();
```

### 总结
Protobuf 通过配置生成脚本文件，主要使用的就是 protoc.exe 可执行文件。我们需要记住对应的生成指令。

### 请写一个工具，让我们不需要通过在cmd中输入指令，就可以快捷的生成所有消息协议，可以去查询了解C#的Process类用于完成此题
![[ProtobufTool 1.cs]]

#### 创建ProtobufTool类，定义各个路径
```cs
public class ProtobufTool
{
    //协议配置文件所在路径
    private static string PROTO_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\proto";
    //协议生成可执行文件的路径
    private static string PROTOC_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\protoc.exe";
    //C#文件生成的路径
    private static string CSHARP_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\csharp";
    //C++文件生成的路径
    private static string CPP_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\cpp";
    //Java文件生成的路径
    private static string JAVA_PATH = "C:\\Users\\MECHREVO\\Desktop\\TeachNet\\Protobuf\\java";
}
```

#### 实现生成消息方法，外部可以传入是什么语言
```cs
//生成对应脚本的方法
private static void Generate(string outCmd, string outPath)
{
    //第一步：遍历对应协议配置文件夹 得到所有的配置文件 
    DirectoryInfo directoryInfo = Directory.CreateDirectory(PROTO_PATH);
    //获取对应文件夹下所有文件信息
    FileInfo[] fileInfos = directoryInfo.GetFiles();
    //遍历所有的文件 为其生成协议脚本
    for (int i = 0; i < fileInfos.Length; i++)
    {
        //后缀的判断 只有是 配置文件才能用于生成
        if (fileInfos[i].Extension == ".proto")
        {
            //第二步：根据文件内容 来生成对应的C#脚本 （需要使用C#当中的Process类）
            Process cmd = new Process();
            //protoc.exe的路径
            cmd.StartInfo.FileName = PROTOC_PATH;
            //命令
            cmd.StartInfo.Arguments = $"-I={PROTO_PATH} --{outCmd}={outPath} {fileInfos[i]}";
            //执行
            cmd.Start();
            //告诉外部 某一个文件 生成结束
            UnityEngine.Debug.Log(fileInfos[i] + "生成结束");
        }
    }
    UnityEngine.Debug.Log("所有内容生成结束");
}
```

#### 实现生成不同语言消息的方法
```cs
[MenuItem("ProtobufTool/生成C#代码")]
private static void GenerateCSharp()
{
    Generate("csharp_out", CSHARP_PATH);
}

[MenuItem("ProtobufTool/生成C++代码")]
private static void GenerateCPP()
{
    Generate("cpp_out", CPP_PATH);
}

[MenuItem("ProtobufTool/生成Java代码")]
private static void GenerateJava()
{
    Generate("java_out", JAVA_PATH);
}
```