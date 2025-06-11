![[XmlDataMgr 1.cs]] ^323f70

### 需求分析
- 目标：
    - 提供公共的序列化和反序列化方法给外部
    - 方便外部存储和获取数据  
        ![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/04.Xml%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/5.%E9%9C%80%E6%B1%82%E5%88%86%E6%9E%90%E5%92%8CXml%E6%95%B0%E6%8D%AE%E7%AE%A1%E7%90%86%E7%B1%BB%E5%88%9B%E5%BB%BA/1.png)

### 创建XML数据管理类并实现单例
```cs
public class XmlDataMgr
{
    private static XmlDataMgr instance = new XmlDataMgr();

    public static XmlDataMgr Instance => instance;

    private XmlDataMgr() { }
}
```

### 声明存储和读取的方法
```cs
/// <summary>
/// 保存数据到xml文件中
/// </summary>
/// <param name="data">数据对象</param>
/// <param name="fileName">文件名</param>
public void SaveData(object data, string fileName)
{

}

/// <summary>
/// 从xml文件中读取内容 
/// </summary>
/// <param name="type">对象类型</param>
/// <param name="fileName">文件名</param>
/// <returns></returns>
public object LoadData(Type type, string fileName)
{

}
```