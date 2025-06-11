![[Lesson1.cs]]
### 什么是序列化和反序列化
序列化：把对象转化为可传输的字节序列过程称为序列化。
反序列化：把字节序列还原为对象的过程称为反序列化。

**说人话：**
序列化就是把想要存储的内容转换为字节序列用于存储或传递。
反序列化就是把存储或收到的字节序列信息解析读取出来使用。

### XML序列化
```cs
public class Lesson1Test
{
    public int testPublic = 1;
    [XmlElement("testPublic2222222222")]
    public int testPublic2 = 2;
    private int testPrivate = 3;
    protected int testProtected = 4;
    internal int testInternal = 5;

    public string testPublicStr = "我是testPublicStr";

    public int testPro { get; set; }

    public Lesson1Test2 testClass = new Lesson1Test2();

    public int[] arrayInt = new int[3] { 1, 2, 3 };

    [XmlArray("IntList")]
    [XmlArrayItem("Int32")]
    public List<int> listInt = new List<int> { 1, 2, 3, 4 };

    public List<int> listInt2 = new List<int> { 5, 6, 7, 8 };

    public List<Lesson1Test2> listItem = new List<Lesson1Test2> { new Lesson1Test2(),new Lesson1Test2()};

    //不支持字典
    //public Dictionary<int, string> testDic = new Dictionary<int, string>() { { 1, "123" } };
}

public class Lesson1Test2
{
    [XmlAttribute("Test1")]
    public int test1 = 1;
    [XmlAttribute()]
    public float test2 = 1.1f;
    [XmlAttribute()]
    public bool test3 = true;
}
```

#### 使用XML序列化的函数存储XML
##### 关键类和语法
- XmlSerializer Xml序列化器类：用于序列化对象为XML的关键类
- StreamWriter 流写入器类：用于存储文件
- using：用于方便流对象释放和销毁
##### 准备一个数据结构类对象
```cs
Lesson1Test lesson1Test = new Lesson1Test();
```
##### XmlSerializer.Serialize 配合流实例化对应类的序列化器进行序列化
```cs
//第一步：确定存储路径
string path = Application.persistentDataPath + "/Lesson1Test.xml";
print(Application.persistentDataPath);

//第二步：结合 using知识点 和 StreamWriter这个流对象 来写入文件
// 括号内的StreamWriter相关代码的作用：写入一个文件流 传入路径 如果路径上有该文件 直接打开并修改 如果路径上没有该文件 直接新建一个文件
// using的新用法：括号当中包裹的声明的对象 会在 大括号语句块结束后 自动释放掉 
// 当大括号语句块结束 会自动帮助我们调用 对象的 Dispose这个方法 让其进行销毁
// using一般都是配合 内存占用比较大 或者 有读写操作时  进行使用的 
using (StreamWriter streamWriter = new StreamWriter(path))
{
    //第三步：进行xml文件序列化

    //创建XmlSerializer类 传入要存储的类的反射类
    //可以XmlSerializer理解为一个翻译成xml的翻译机器
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lesson1Test));

    //XmlSerializer类中的Serialize方法 序列化对象转成xml传入流文件中
    //这句代码的含义 就是通过序列化对象 对我们类对象进行翻译 将其翻译成我们的xml文件 写入到对应的文件中
    //第一个参数 ： 文件流对象
    //第二个参数: 想要备翻译 的对象
    //注意 ：翻译机器的类型 一定要和传入的对象是一致的 不然会报错
    xmlSerializer.Serialize(streamWriter, lesson1Test);

    //只要是公共的的成员 都能存储 不支持字典
}
```

#### 查看存储的XML文件
- <font color="#ffff00">private protected internal 的变量都不能序列化</font> <font color="#ffff00">public的变量才能存储</font>
- 不支持字典 会报错
```xml
<?xml version="1.0" encoding="utf-8"?>
<Lesson1Test xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <testPublic>1</testPublic>
  <testPublic2222222222>2</testPublic2222222222>
  <testPublicStr>我是testPublicStr</testPublicStr>
  <testClass Test1="1" test2="1.1" test3="true" />
  <arrayInt>
    <int>1</int>
    <int>2</int>
    <int>3</int>
  </arrayInt>
  <IntList>
    <Int32>1</Int32>
    <Int32>2</Int32>
    <Int32>3</Int32>
    <Int32>4</Int32>
  </IntList>
  <listInt2>
    <int>5</int>
    <int>6</int>
    <int>7</int>
    <int>8</int>
  </listInt2>
  <listItem>
    <Lesson1Test2 Test1="1" test2="1.1" test3="true" />
    <Lesson1Test2 Test1="1" test2="1.1" test3="true" />
  </listItem>
  <testPro>0</testPro>
</Lesson1Test>
```

### 自定义节点名或设置属性
可以通过特性设置节点或设置属性，并且修改名字。
- `[XmlAttribute()]`：这个字段要变成XML的属性
- `[XmlAttribute("Test1")]`：这个字段要变成XML的属性，并且属性名是Test1
- `[XmlElement("testPublic123123")]`：这个字段要变成XML的元素节点，并且节点名是testPublic123123
- `[XmlArray("IntList")]`：改变数组对象存储XML的节点名为IntList
- `[XmlArrayItem("Int32")]`：改变数组元素对象存储XML的节点名，每个元素的节点名都变成Int32

### 总结
序列化流程：
1. 有一个想要保存的类对象
2. 使用`XmlSerializer`序列化该对象
3. 通过`StreamWriter`配合`using`将数据存储写入文件

注意：
- 只能序列化公共成员
- 不支持字典序列化
- 可以通过特性修改节点信息或者设置属性信息
- Stream相关要配合`using`使用