![[Lesson41.cs]]

![[Protobuf协议生成#^17fc6e]]

### 序列化存储为本地文件
- **主要使用**
    - 生成的类中的 WriteTo 方法
    - 文件流 FileStream 对象
```cs
TestMsg testMsg1 = new TestMsg();
testMsg1.ListInt.Add(1);
testMsg1.TestBool = false;
testMsg1.TestD = 5.5;
testMsg1.TestInt32 = 99;
testMsg1.TestMap.Add(1, "韬老狮");
testMsg1.TestMsg2 = new TestMsg2();
testMsg1.TestMsg2.TestInt32 = 88;
testMsg1.TestMsg3 = new TestMsg.Types.TestMsg3();
testMsg1.TestMsg3.TestInt32 = 66;

testMsg1.TestHeart = new GameSystemTest.HeartMsg();
testMsg1.TestHeart.Time = 7777;

print(Application.persistentDataPath);
using (FileStream fileStream = File.Create(Application.persistentDataPath + "/TestMsg.tao"))
{
    testMsg1.WriteTo(fileStream);
}
```

### 反序列化本地文件
- **主要使用**
    - 生成的类中的 Parser.ParseFrom 方法
    - 文件流 FileStream 对象
```cs
using (FileStream fileStream = File.OpenRead(Application.persistentDataPath + "/TestMsg.tao"))
{
    TestMsg testMsg2 = null;
    testMsg2 = TestMsg.Parser.ParseFrom(fileStream);
    print(testMsg2.TestMap[1]);
    print(testMsg2.ListInt[0]);
    print(testMsg2.TestD);
    print(testMsg2.TestMsg2.TestInt32);
    print(testMsg2.TestMsg3.TestInt32);
    print(testMsg2.TestHeart.Time);
}
```

### 得到序列化后的字节数组
- **主要使用**
    - 生成的类中的 WriteTo 方法
    - 内存流 MemoryStream 对象
```cs
byte[] bytes = null;
using (MemoryStream memoryStream = new MemoryStream())
{
    testMsg1.WriteTo(memoryStream);
    bytes = memoryStream.ToArray();
    print("字节数组长度" + bytes.Length);
}
```

### 从字节数组反序列化
- **主要使用**
    - 生成的类中的 Parser.ParseFrom 方法
    - 内存流 MemoryStream 对象
```cs
using (MemoryStream memoryStream = new MemoryStream(bytes))
{
    print("内存流当中反序列化的内容");
    TestMsg testMsg2 = TestMsg.Parser.ParseFrom(memoryStream);
    print(testMsg2.TestMap[1]);
    print(testMsg2.ListInt[0]);
    print(testMsg2.TestD);
    print(testMsg2.TestMsg2.TestInt32);
    print(testMsg2.TestMsg3.TestInt32);
    print(testMsg2.TestHeart.Time);
}
```

### 总结
- **Protobuf 的序列化和反序列化都要通过流对象来进行处理。**
- **如果是进行本地存储，则可以使用文件流。**
- **如果是进行网络传输，则可以使用内存流获取字节数组。**

### 请封装一个工具类，用于快速的对Protobuf生成的内容，进行序列化和反序列化
![[NetTool.cs]]

#### 创建静态网络工具类
```cs
public static class NetTool
{
}
```
#### 序列化消息对象，可以自己写流，也可以用封装好的方法
```cs
//序列化Protobuf生成的对象
public static byte[] GetProtoBytes(IMessage msg)
{
    //拓展方法、里氏替换、接口 这些知识点 都在 C#相关的内容当中

    //基础写法 基于上节课学习的知识点
    //byte[] bytes = null;
    //using (MemoryStream ms = new MemoryStream())
    //{
    //    msg.WriteTo(ms);
    //    bytes = ms.ToArray();
    //}
    //return bytes;

    //通过该拓展方法 就可以直接获取对应对象的 字节数组了
    return msg.ToByteArray();
}
```
#### 反序列化消息对象，使用反射
```cs
/// <summary>
/// 反序列化字节数组为Protobuf相关的对象
/// </summary>
/// <typeparam name="T">想要获取的消息类型</typeparam>
/// <param name="bytes">对应的字节数组 用于反序列化</param>
/// <returns></returns>
public static T GetProtoMsg<T>(byte[] bytes) where T : class, IMessage
{
    //泛型 C#进阶
    //反射 C#进阶
    //得到对应消息的类型 通过反射得到内部的静态成员 然后得到其中的 对应方法
    //进行反序列化
    Type type = typeof(T);
    //通过反射 得到对应的 静态成员属性对象
    PropertyInfo propertyInfo = type.GetProperty("Parser");
    object parserObj = propertyInfo.GetValue(null, null);
    //已经得到了对象 那么可以得到该对象中的 对应方法 
    Type parserType = parserObj.GetType();
    //这是指定得到某一个重载函数
    MethodInfo methodInfo = parserType.GetMethod("ParseFrom", new Type[] { typeof(byte[]) });
    //调用对应的方法 反序列化为指定的对象
    object msg = methodInfo.Invoke(parserObj, new object[] { bytes });
    return msg as T;
}
```
#### 进行测试
```cs
TestMsg testMsg1 = new TestMsg();
testMsg1.ListInt.Add(1);
testMsg1.TestBool = false;
testMsg1.TestD = 5.5;
testMsg1.TestInt32 = 99;
testMsg1.TestMap.Add(1, "韬老狮");
testMsg1.TestMsg2 = new TestMsg2();
testMsg1.TestMsg2.TestInt32 = 88;
testMsg1.TestMsg3 = new TestMsg.Types.TestMsg3();
testMsg1.TestMsg3.TestInt32 = 66;

testMsg1.TestHeart = new GameSystemTest.HeartMsg();
testMsg1.TestHeart.Time = 7777;


print("练习题打印相关");
//封装的 序列化方法 
byte[] bytes = NetTool.GetProtoBytes(testMsg1);
//封装的 反序列化方法
TestMsg testMsg2 = NetTool.GetProtoMsg<TestMsg>(bytes);
print(testMsg2.TestMap[1]);
print(testMsg2.ListInt[0]);
print(testMsg2.TestD);
print(testMsg2.TestMsg2.TestInt32);
print(testMsg2.TestMsg3.TestInt32);
print(testMsg2.TestHeart.Time);
```
