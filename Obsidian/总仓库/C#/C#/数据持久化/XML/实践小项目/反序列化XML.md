![[Lesson2.cs]]
### 知识回顾
序列化就是把类对象转换为可存储和传输的数据。
反序列化就是把存储或收到的数据转换为类对象。

**XML序列化关键知识：**
1. `using` 和 `StreamWriter`
2. `XmlSerializer` 的 `Serialize` 序列化方法

### 判断文件是否存在
```cs
string path = Application.persistentDataPath + "/Lesson1Test.xml";
// 存在再进行反序列化的处理，不存在就不能反序列化
if (File.Exists(path))
{
    // 反序列化处理
}
```

### XmlSerializer.Deserialize 配合流实例化对应类的序列化器进行反序列化
如果路径指向的文件存在，则进行反序列化处理。
```cs
// 使用 StreamReader 读取文件对象初始化，传入路径
using (StreamReader streamReader = new StreamReader(path))
{
    // 创建 XmlSerializer 类，传入要反序列化的类的反射类
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lesson1Test));

    // XmlSerializer 类中的 Deserialize 反序列化方法，反序列化对应 streamReader 读取到的内容，返回值是万物之父
    Lesson1Test lesson1Test = xmlSerializer.Deserialize(streamReader) as Lesson1Test;

    // 注意：如果要读取的类的列表成员变量声明时初始化就赋值了，反序列化出来会有两倍数组
    // 比如：public List<int> listInt = new List<int> { 1, 2, 3 }; 反序列化出来的 listInt 会有 { 1, 2, 3,1, 2, 3 };
    // 所以最好不要在读取的类的列表成员变量声明时初始化就赋值
}
```

- 注意：如果要读取的类的列表成员变量声明时初始化就赋值了，反序列化出来会有两倍数组  
    ![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/04.Xml%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/2.%E5%BF%85%E5%A4%87%E7%9F%A5%E8%AF%86%E7%82%B9-CSharp%E4%B8%ADXML%E5%8F%8D%E5%BA%8F%E5%88%97%E5%8C%96/1.png)
- 比如：`public List<int> listInt = new List<int> { 1, 2, 3 };` 反序列化出来的 `listInt` 会有 { 1, 2, 3,1, 2, 3 };
- 所以最好不要在读取的类的列表成员变量声明时初始化就赋值

### 总结
1. 判断文件是否存在使用 `File.Exists`
2. 获取文件流使用 `StreamReader streamReader = new StreamReader(path)`
3. 根据文件流，通过 `XmlSerializer` 的 `Deserialize` 反序列化出对象

注意：List 对象如果有默认值，在反序列化时不会清空，会往后面添加。