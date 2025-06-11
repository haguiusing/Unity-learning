![[SerizlizerDictionary 1.cs]]
### 思考如何让Dictionary支持xml序列和反序列化
- 我们没办法修改C#自带的类
- 那我们可以重写一个类 继承Dictionary 然后让这个类继承序列化拓展接口IXmlSerializable
- 实现里面的序列化和反序列化方法即可

### 让Dictionary支持序列化和反序列化
#### 声明SerizlizerDictionary类，继承Dictionary和IXmlSerializable接口，实现自定义序列化反序列化字典

这是一个继承自Dictionary，实现了IXmlSerializable接口的自定义字典类型，用于XML序列化和反序列化键值对数据。
```cs
public class SerizlizerDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    // 返回空值。GetSchema方法是必须由接口 IXMlSerializable实现的方法，但在此类中不需要使用它。
    public XmlSchema GetSchema()
    {
        return null;
    }
    
    // 自定义字典类型（继承自Dictionary）的反序列化规则。接受一个XmlReader阅读器作为反序列化数据源。
    public void ReadXml(XmlReader xmlReader)
    {
        // 创建两个XmlSerializer实例，一个key的类型、一个是value的类型，用于反序列化XML流中的键值对数据。
        XmlSerializer keyXmlSerializer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueXmlSerializer = new XmlSerializer(typeof(TValue));
        
        // 要跳过根节点
        xmlReader.Read();
        // 只要当前节点不为EndElement，则意味着还可以读取到新的节点，继续反序列化操作。
        while (xmlReader.NodeType != XmlNodeType.EndElement)
        {
            // 反序列化从XML阅读器读取的键对象，并进行强制类型转换到泛型TKey类别 
            TKey key = (TKey)keyXmlSerializer.Deserialize(xmlReader);
            // 反序列化从XML阅读器读取的值对象，并进行强制类型转换到泛型TValue类别 
            TValue value = (TValue)valueXmlSerializer.Deserialize(xmlReader);
            // 将键和值添加到字典中
            this.Add(key, value);
        }
        // 要跳过尾节点 避免影响之后的数据读取
        xmlReader.Read();
    }
    
    // 自定义字典类型的序列化规则。使用提供的XmlWriter实例将该字典序列化为XML。
    public void WriteXml(XmlWriter xmlWriter)
    {
        // 创建两个XmlSerializer实例，一个key的类型、一个是value的类型，用于序列化键值对数据。
        XmlSerializer keyXmlSerializer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueXmlSerializer = new XmlSerializer(typeof(TValue));
        
        // 使用foreach循环安全遍历字典中所有的键值对象，并依次将其序列化到由writer引用的输出流中。
        foreach (KeyValuePair<TKey, TValue> kv in this)
        {
            // 序列化键和值到writer流。
            keyXmlSerializer.Serialize(xmlWriter, kv.Key);
            valueXmlSerializer.Serialize(xmlWriter, kv.Value);
        }
    }
}
```

#### 创建TestLesson4，用于测试自定义序列化字典的序列化和反序列化
在TestLesson4类定义了一个公共int类型成员test1，“SerizlizerDictionary<int, string>”自定义字典类型变量serizlizerDictionary。
```cs
public class TestLesson4
{
    public int test1; // 定义一个公共int类型变量 test1.
    public SerizlizerDictionary<int, string> serizlizerDictionary;//自定义一个 字典 类型 serizlizerDictionary.
}
```

#### 测试TestLesson4实例的序列化和反序列化
```cs
void Start()
{
    // 先通过创建TestLesson4类类型变量testLesson4_1并为其 serizlizerDictionary 成员 添加了三个键值对数据，调用Application对象的 persistentDataPath 成员获取应用程序数据路径，使用StreamWriter类打开要输出的文件流
    TestLesson4 testLesson4_1 = new TestLesson4();
    testLesson4_1.serizlizerDictionary = new SerizlizerDictionary<int, string>();
    
    // 向 serizlizerDictionary 添加三个键值对。
    testLesson4_1.serizlizerDictionary.Add(1, "123");
    testLesson4_1.serizlizerDictionary.Add(2, "234");
    testLesson4_1.serizlizerDictionary.Add(3, "345");
    
    // 通过Application对象的 persistentDataPath 成员获取用于存储数据文件的路径。并将路径记录在日志中以进行调试验证.
    string path = Application.persistentDataPath + "/TestLesson4.xml";
    Debug.Log(path);
    
    // 使用StreamWriter类为指定的文件建立新的编写器，并使用测试程序运行时序列化器生成 XML 文档。然后将XML文档提交给StreamWriter文本流进行保存。
    using (StreamWriter streamWriter = new StreamWriter(path))
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestLesson4));
        xmlSerializer.Serialize(streamWriter, testLesson4_1);
    }
    
    // 接下来我们要反序列化上面序列化的文件，将XML数据中的内容读取到一个新的 TestLesson4实例 对象testLesson4_2中
    TestLesson4 testLesson4_2 = new TestLesson4();
    
    // 使用StreamReader打开创建的存成XML格式的文件，XmlSerializer生成适当的类以反序列化 XML 文档，动态将其转换为 TestLesson4 类型，然后将反序列化得到TestLesson4对象的应用返回到 testLesson4_2.
    using (StreamReader streamReader = new StreamReader(path))
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestLesson4));
        testLesson4_2 = xmlSerializer.Deserialize(streamReader) as TestLesson4;
    }
    
    // 至此，整个操作过程完成，TestLesson4 对象已被序列化为XML，再通过反序列化将XML数据导入了一个新的TestLesson4实例对象testLesson4_2中。
}
```

### 验证序列化和反序列化
#### 查看路径下序列化的xml文件
```cs
<?xml version="1.0" encoding="utf-8"?>
<TestLesson4 xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <test1>0</test1>
  <serizlizerDictionary>
    <int>1</int>
    <string>123</string>
    <int>2</int>
    <string>234</string>
    <int>3</int>
    <string>345</string>
  </serizlizerDictionary>
</TestLesson4>
```

#### 断点查看反序列化是否成功
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/04.Xml%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/4.%E5%BF%85%E5%A4%87%E7%9F%A5%E8%AF%86%E7%82%B9-%E8%AE%A9Dictionary%E6%94%AF%E6%8C%81%E5%BA%8F%E5%88%97%E5%8C%96%E5%8F%8D%E5%BA%8F%E5%88%97%E5%8C%96/1.png)