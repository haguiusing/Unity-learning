![[Lesson3 1.cs]]
### IXmlSerializable是什么
C# 的 `XmlSerializer` 接口提供了可拓展内容，可以让一些不能被序列化和反序列化的特殊类能够被处理。通过让特殊类继承 `IXmlSerializable` 接口并实现其中的方法，就能实现这一点。例如，字典就不能直接序列化，但可以通过自定义拓展让其序列化。

### 自定义类实践
#### 创建 `TestLesson3` 自定义类，实现IXmlSerializable接口
```cs
//让自定义的类TestLesson3继承IXmlSerializable这个接口
public class TestLesson3 : IXmlSerializable
{
    public int test1;
    public string test2;

    //继承IXmlSerializable接口必须要实现的方法 返回结构
    public XmlSchema GetSchema()
    {
        //返回空就行
        return null;
    }

    //继承IXmlSerializable接口必须要实现的方法 反序列化时 会自动调用的方法
    //在里面可以自定义反序列化 的规则
    public void ReadXml(XmlReader xmlReader)
    {
        //如果要自定义 序列化的规则 一定会用到 XmlReader中的一些方法 来进行序列化

        ////1.读属性
        ////XmlReader["属性名"] 读属性 看要不要转类型
        ////< TestLesson3 test1 = "0" test2 = "123" />
        //this.test1 = int.Parse(xmlReader["test1"]);
        //this.test2 = xmlReader["test2"];

        ////2.读节点
        ////XmlReader读节点
        ////< TestLesson3 >
        ////  < test1 > 0 </ test1 >
        ////  < test2 > 123 </ test2 >
        ////</ TestLesson3 >
        ////有两种方式
        ////方式一
        ////XmlReader中的Read方法
        //xmlReader.Read();//这时是读到的是第一个子节点的首节点 test1节点 <test1>
        //xmlReader.Read();//这时是读到的是第一个子节点包裹的内容 test1节点包裹的内容 0
        ////XmlReader中的Value变量 得到当前内容的值 在转类型
        //this.test1 = int.Parse(xmlReader.Value);//得到当前内容的值 0
        //xmlReader.Read();//这时读到的是第一个子节点的尾部节点 包裹节点 </test1>
        //xmlReader.Read();//这时是读到的是第二个子节点的首节点 test2节点 <test2>
        //xmlReader.Read();//这时是读到的是第二个子节点包裹的内容 test2节点包裹的内容 123
        ////XmlReader中的Value变量 得到当前内容的值 本来就是string 不用转类型
        //this.test2 = xmlReader.Value;////得到当前内容的值 123
        //xmlReader.Read();//这时读到的是第二个子节点的尾部节点 包裹节点 </test2>
        ////方式二
        ////XmlReader中的Read方法有返回值 假如能读就一直读
        //while (xmlReader.Read())
        //{
        //    //XmlReaderd中的NodeType变量 判断当前节点是不是元素
        //    if (xmlReader.NodeType == XmlNodeType.Element)
        //    {
        //        //判断当前xmlReader读到的名字
        //        switch (xmlReader.Name)
        //        {
        //            //如果名字和自己想要读的节点名的名字相同 就在读一次 获取里面的值
        //            case "test1":
        //                xmlReader.Read();
        //                this.test1 = int.Parse(xmlReader.Value);
        //                break;
        //            case "test2":
        //                xmlReader.Read();
        //                this.test2 = xmlReader.Value;
        //                break;
        //        }
        //    }
        //}

        //3.读包裹元素节点
        //使用XmlSerializer翻译机器配合着XmlReader中的ReadStartElement方法、XmlReader中的Deserialize方法和XmlWriter中的ReadEndElement方法
        //读在节点中间再包裹一层节点
        //< TestLesson3 >
        //  < test1 >
        //    < int > 0 </ int >
        //  </ test1 >
        //  < test2 >
        //    < string > 123 </ string >
        //  </ test2 >
        //</ TestLesson3 >
        // 创建两个XmlSerializer实例。其中一个用于将XML中的int类型数据反序列化，另一个用于将XML中的string类型数据反序列化。
        XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(int));
        XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(string));
        // 跳过根节点，开始读取XML中的内容。
        xmlReader.Read();
        //XmlReader中的ReadStartElement方法 ReadStartElement将XML阅读器移动到下一个元素并检查它是否具有给定的本地名称和命名空间
        //这里我们将XML阅读器移动到"test1"元素，并准备将其反序列化为 int 类型。
        xmlReader.ReadStartElement("test1");
        //XmlReader中的Deserialize方法 反序列化从 XML 中读取的int值，和前面代码块序列化时对应的成员名必须一致
        test1 = (int)xmlSerializer1.Deserialize(xmlReader);
        //XmlWriter中的ReadEndElement方法 阅读器从当前位置读取并跳过此元素的内容，然后向前移动到兄弟元素或父元素关闭，即关闭“test1”元素。
        xmlReader.ReadEndElement();
        // 将XML阅读器移动到XML文档中的"test2"元素。准备将它反序列化为 string类型，
        
        xmlReader.ReadStartElement("test2");
        // 反序列化从 XML 中读取的string值。和前面代码块序列化时对应的成员名必须保持一致。
        //由于反序列化string之后获得的是object类型的结果，因此需要使用ToString()将其转换为string类型。
        test2 = xmlSerializer2.Deserialize(xmlReader).ToString();
        // 阅读器从当前位置读取并跳过此元素的内容，然后向前移动到兄弟元素或父元素关闭，即“test2”元素。
        xmlReader.ReadEndElement();
    }

    //继承IXmlSerializable接口必须要实现的方法
    //假如继继承IXmlSerializable接口 序列化时 会自动调用的方法
    //在里面可以自定义序列化 的规则
    //假如继承IXmlSerializable接口 但是里面又啥都没写 序列化出来的xml就只有固定内容和一个根节点
    //<TestLesson3 />
    public void WriteXml(XmlWriter xmlWriter)
    {
        //如果要自定义 序列化的规则 一定会用到 XmlWriter中的一些方法 来进行序列化

        ////1.写属性
        ////XmlWriter类中的WriteAttributeString方法 写属性 传入属性名并且传入属性值转string
        ////< TestLesson3 test1 = "0" test2 = "123" />
        //xmlWriter.WriteAttributeString("test1", this.test1.ToString());
        //xmlWriter.WriteAttributeString("test2", this.test2);
        ////这样根节点下就有test1和test2两个属性

        ////2.写节点
        ////XmlWriter类中的WriteElementString方法 写节点 传入节点名并且传入节点值转string
        ////< TestLesson3 >
        ////  < test1 > 0 </ test1 >
        ////  < test2 > 123 </ test2 >
        ////</ TestLesson3 >
        //xmlWriter.WriteElementString("test1", this.test1.ToString());
        //xmlWriter.WriteElementString("test2", this.test2);

        //3.写包裹节点
        //使用XmlSerializer翻译机器配合着XmlWriter中的WriteStartElement方法、XmlWriter中的Serialize方法和XmlWriter中的WriteEndElement方法
        //在节点中间再包裹一层节点
        //< TestLesson3 >
        //  < test1 >
        //    < int > 0 </ int >
        //  </ test1 >
        //  < test2 >
        //    < string > 123 </ string >
        //  </ test2 >
        //</ TestLesson3 >
        
        // 创建XmlSerializer实例，指定我们要序列化/反序列化的对象类型为int。
        XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(int));
        // XmlWriter中的WriteStartElement方法  将一个名为"test1"的元素写入XML Writer流中
        xmlWriter.WriteStartElement("test1");
        //XmlWriter中的Serialize方法 使用XmlSerializer将test1 int变量序列化成XML格式，并将其写入由xmlWriter引用的文本编写器位置。
        xmlSerializer1.Serialize(xmlWriter, test1);
        // XmlWriter中的WriteEndElement方法  标记已完成在此元素周围对属性和子元素的操作，即关闭“test1”元素。
        xmlWriter.WriteEndElement();
        
        // 接下来，建立另一个XmlSerializer实例，指定其被序列化的对象类型为string。
        XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(string));
        // 将名为"test2"的元素写入XML Writer流中
        xmlWriter.WriteStartElement("test2");
        //XmlWriter中的Serialize方法 使用XmlSerializer将test2 string变量序列化成XML格式，并将其写入由xmlWriter引用的文本编写器位置.
        xmlSerializer2.Serialize(xmlWriter, test2);
        // 标记已完成在此元素周围对属性和子元素的操作，即关闭“test2”元素。
        xmlWriter.WriteEndElement();
    }
}
```
#### 在 Start 方法内实践序列化和反序列化
```cs
// 创建一个TestLesson3实例
TestLesson3 TestLesson3_1 = new TestLesson3();

// 给TestLesson3_1的test1和test2赋值
TestLesson3_1.test1 = 666;
// 注意：假如是引用类型对象 没有初始化的话不会存到xml上去
TestLesson3_1.test2 = "123";

// 获取应用程序可以访问的持久数据路径，并在其末尾添加要保存的文件名。
string path = Application.persistentDataPath + "/TestLesson3.xml";

// 用Writter对象创建StreamWriter实例流来写文件到path上
using (StreamWriter streamWriter = new StreamWriter(path))
{
    // 先创建一个XmlSerializer实例，以说明我们正在序列化什么类型的对象
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestLesson3));

    // 使用XmlSerializer将已创建的TestLesson3序列化为XML，并将其写入由streamReader引用的位置。
    // 在序列化时  如果对象中的引用成员 为空 那么xml里面是看不到该字段的
    xmlSerializer.Serialize(streamWriter, TestLesson3_1);
}

// 使用StreamReader从磁盘中读取path路径上的XML信息并读取到此代码块中自定义的新的实例中
using (StreamReader streamReader = new StreamReader(path))
{
    // 序列化"翻译机器"，这里也是通过XmlSerializer实现反序列化操作
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestLesson3));

    // 反序列化 把流传进去as成TestLesson3
    TestLesson3 TestLesson3_2 = xmlSerializer.Deserialize(streamReader) as TestLesson3;
}
```

### 验证序列化和反序列化
查看路径下序列化的xml文件
```xml
<?xml version="1.0" encoding="utf-8"?>
<TestLesson3>
  <test1>
    <int>666</int>
  </test1>
  <test2>
    <string>123</string>
  </test2>
</TestLesson3>
```
#### 断点查看反序列化是否成功
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/04.Xml%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/3.%E5%BF%85%E5%A4%87%E7%9F%A5%E8%AF%86%E7%82%B9-IXmlSerializable%E6%8E%A5%E5%8F%A3/1.png)

### 总结
- `IXmlSerializable` 接口允许自定义类的序列化和反序列化。
- 在自定义类中实现 `IXmlSerializable` 接口的方法，可以定义序列化和反序列化的规则。 
- 在 `Start` 方法中，可以实践序列化和反序列化操作。