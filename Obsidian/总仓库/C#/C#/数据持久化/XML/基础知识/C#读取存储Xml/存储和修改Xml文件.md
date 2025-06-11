![[SaveXml.cs]]
### 决定Xml存储在哪个文件夹下
- 注意：存储xml文件 在Unity中一定是使用各平台都可读可写可找到的路径
    - Resources 可读 不可写 打包加密后通过路径找不到 ×
    - Application.streamingAssetsPath 可读 PC端可写 但是其他平台不可写 打包加密后通过路径找得到 可以存些不会改的xml文件 ×
    - Application.dataPath 编辑器上操作看起来没什么问题 但是打包后找不到 ×
    - Application.persistentDataPath 可读可写 各个平台找得到 √
- 准备好我们最终要存储的路径
```cs
string path = Application.persistentDataPath + "/PlayerInfo2.xml";
print(Application.persistentDataPath);//C:/Users/LinWentao/AppData/LocalLow/DefaultCompany/XML教程
```

### 存储xml文件
#### 存储xml文件用到的关键类
- XmlDocument Xml文档类 用于创建节点存储文件
- XmlDeclaration Xml声明类 用于添加版本信息
- XmlElement Xml元素类

#### 存储xml文件具体的五个步骤
##### 创建XmlDocument文档对象
```cs
//创建XmlDocument类文本对象 
//相当于新建xml文件
XmlDocument xmlDocument = new XmlDocument();
```
##### 添加固定版本信息
XmlDocument.CreateXmlDeclaration方法 添加固定版本信息
```cs
//XmlDocument类中的CreateXmlDeclaration方法 添加固定版本信息
//这一句代码 相当于就是创建<?xmlDocument version="1.0" encoding="UTF-8"?>这句内容
XmlDeclaration xmlDec = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "");
```
XmlDocument.AppendChild方法 把对象添加到xml文本对象中
```cs
//XmlDocument类中的AppendChild方法 把版本信息对象添加到xml文本对象中 
//创建完成过后 要添加进入 文本对象中
xmlDocument.AppendChild(xmlDec);
```
##### 添加根节点
XmlDocument.CreateElement方法 创建根节点
```cs
//XmlDocument类中的CreateElement方法 添加根节点
XmlElement root = xmlDocument.CreateElement("Root");
//创建完成过后 要添加进入 文本对象中
xmlDocument.AppendChild(root);
```
##### 为根节点添加子节点
###### XmlElement.SetAttribute方法 给节点设置属性和属性值
```cs
//为根节点添加子节点
//创建了了一个name子节点
XmlElement name = xmlDocument.CreateElement("name");

//XmlElement中的InnerText属性 设置包裹信息
name.InnerText = "林文韬";

//XmlElement类中的AppendChild方法 把子节点添加到xml文本对象中 
root.AppendChild(name);

//使用CreateElement方法在根节点下创建名称为“atk”的节点，并设置其InnerText（即节点内部的文本值）为“10”
XmlElement atk = xmlDocument.CreateElement("atk");
atk.InnerText = "10";
//将“atk”子节点添加至根节点“Root”中
root.AppendChild(atk);

//使用CreateElement方法在根节点下创建名称为“listInt”的XmlNode节点，并将三个名为“int”的子节点添加到该节点中。
XmlElement listInt = xmlDocument.CreateElement("listInt");
//遍历给listInt添加子节点
for (int i = 1; i <= 3; i++)
{
    //使用CreateElement方法在“listInt”节点下依次创建三个名为“int”的XmlElement节点
    XmlElement childNode = xmlDocument.CreateElement("int");

    //依次设置三个“int”子节点的InnerText值，分别为1、2、3
    childNode.InnerText = i.ToString();
    listInt.AppendChild(childNode);
}
//将“listInt”子节点添加至根节点“Root”中
root.AppendChild(listInt);

//使用CreateElement方法在根节点下创建名称为“itemList”的XmlElement节点，并将三个名为“Item”的子节点添加到该节点中，
XmlElement itemList = xmlDocument.CreateElement("itemList");
//遍历给itemList添加子节点
for (int i = 1; i <= 3; i++)
{
    //使用CreateElement方法在“itemList”节点下依次创建三个名为“Item”的XmlElement节点
    XmlElement childNode = xmlDocument.CreateElement("Item");

    //XmlElement中的SetAttribute方法 给节点设置属性和属性值
    //使用SetAttribute方法给每个“Item”节点设置两个属性，分别为“id”和“num”
    childNode.SetAttribute("id", i.ToString());
    childNode.SetAttribute("num", (i * 10).ToString());
    itemList.AppendChild(childNode);
}
//将“itemList”节点添加至根节点“Root”中
root.AppendChild(itemList);
```
##### 保存
###### XmlDocument.Save方法 在指定路径保存xml文件
```cs
//XmlDocument类中的Save方法 在指定路径保存xml文件
xmlDocument.Save(path);
```
##### 保存后的xml文件
```cs
<?xml version="1.0" encoding="UTF-8"?>
<Root>
  <name>林文韬</name>
  <atk>10</atk>
  <listInt>
    <int>1</int>
    <int>2</int>
    <int>3</int>
  </listInt>
  <itemList>
    <Item id="1" num="10" />
    <Item id="2" num="20" />
    <Item id="3" num="30" />
  </itemList>
</Root>
```

### 修改xml文件
#### File.Exists方法 判断某路径是否存在文件
```cs
//File类中的Exists方法 判断路径是否存在
if ( File.Exists(path) )
{

}
```
#### 加载后利用学过的方法修改xml文件
```cs
//File类中的Exists方法 判断路径是否存在
if ( File.Exists(path) )
{
    //2.加载后 直接添加节点 移除节点即可

    //创建xml文本对象 加载对应路径的xml文件
    XmlDocument newXml = new XmlDocument();
    newXml.Load(path);

    //修改就是在原有文件基础上 去移除 或者添加

    //移除节点
    XmlNode node;

    //可以在XmlNode中连续使用SelectSingleNode方法得到子节点
    node = newXml.SelectSingleNode("Root").SelectSingleNode("atk");

    //也可以通过/来区分父子节点的关系 得到子节点
    node = newXml.SelectSingleNode("Root/atk");

    //得到自己的父节点
    XmlNode root2 = newXml.SelectSingleNode("Root");

    //XmlNode类中的RemoveChild方法 移除子节点方法
    root2.RemoveChild(node);

    //添加节点
    //CreateElement创建一个节点
    XmlElement moveSpeed = newXml.CreateElement("moveSpeed");
    //设置包裹内容
    moveSpeed.InnerText = "20";
    //加到更节点
    root2.AppendChild(moveSpeed);

    //改了记得保存文档对象
    newXml.Save(path);
}
```

#### 修改后的结果
```cs
<?xml version="1.0" encoding="UTF-8"?>
<Root>
  <name>林文韬</name>
  <listInt>
    <int>1</int>
    <int>2</int>
    <int>3</int>
  </listInt>
  <itemList>
    <Item id="1" num="10" />
    <Item id="2" num="20" />
    <Item id="3" num="30" />
  </itemList>
  <moveSpeed>20</moveSpeed>
</Root>
```

### 总结
- 路径选取
    - 在运行过程中存储 只能往可写且能找到的文件夹存储
    - 故选择了Application.persistentDataPath
- 存储xml关键类
    - XmlDocument 文件
        - 创建节点 CreateElement
        - 创建固定内容方法 CreateXmlDeclaration
        - 添加节点 AppendChild
        - 保存 Save
    - XmlDeclaration 版本
    - XmlElement 元素节点
        - 设置属性方法 SetAttribute
- 修改
    - RemoveChild 移除节点
    - 可以通过 / 的形式来表示子节点的子节点