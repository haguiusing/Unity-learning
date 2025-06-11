![[Lesson37 1.cs]]


### 观察假如正常手写GetBytesNum函数应该怎么写
```cs
public class PlayerTest : BaseData
{
    public List<int> list;
    public Dictionary<int, string> dic;
    public int[] arrays;
    public E_Player_Type type;
    public PlayerData player;

    public override int GetBytesNum()
    {
        int num = 0;

        num += 4; // list.Count
        for (int i = 0; i < list.Count; i++)
            num += 4;

        num += 4; // dic.Count
        foreach (int key in dic.Keys)
        {
            num += 4; // key所占的字节数
            num += 4; // value 字符串长度 占的字节数
            num += Encoding.UTF8.GetByteCount(dic[key]);
        }

        num += 4; // arrays.Length
        for (int i = 0; i < arrays.Length; i++)
            num += 4;

        num += 4; // 枚举

        num += player.GetBytesNum(); // 自定义类

        return num;
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        throw new System.NotImplementedException();
    }

    public override byte[] Writing()
    {
        throw new System.NotImplementedException();
    }
}
```

### 观察xml配置
```xml
<!--数据结构类配置规则 包含 类名 命名空间 变量类型 变量名-->
<data name="PlayerData" namespace="GamePlayer">
    <field type="int" name="id"/>
    <field type="float" name="atk"/>
    <field type="bool" name="sex"/>
    <field type="long" name="lev"/>
    <field type="array" data="int" name="arrays"/>
    <field type="list" T="int" name="list"/>
    <field type="dic" Tkey="int" Tvalue="string" name="dic"/>
    <field type="enum" data="E_HERO_TYPE" name="heroType"/>
</data>

<data name="HeartData" namespace="GameSystem">
    <field type="long" name="time"/>
</data>
```

### 定义返回不同类型字节长度的函数
```cs
private string GetValueBytesNum(string type, string name)
{
    //这里我没有写全 所有的常用变量类型 你可以根据需求去添加
    switch (type)
    {
        case "int":
        case "float":
        case "enum":
            return "4";
        case "long":
            return "8";
        case "byte":
        case "bool":
            return "1";
        case "short":
            return "2";
        case "string":
            return "4 + Encoding.UTF8.GetByteCount(" + name + ")";
        default:
            return name + ".GetBytesNum()";
    }
}
```

### 定义拼接GetBytesNum函数字符串的函数GetGetBytesNumStr
```cs
private string GetGetBytesNumStr(XmlNodeList fields)
{
    string bytesNumStr = "";

    string type = "";
    string name = "";
    foreach (XmlNode field in fields)
    {
        type = field.Attributes["type"].Value;
        name = field.Attributes["name"].Value;
        if (type == "list")
        {
            string T = field.Attributes["T"].Value;
            bytesNumStr += "\t\t\tnum += 2;\r\n"; //+2 是为了节约字节数 用一个short去存储信息
            bytesNumStr += "\t\t\tfor (int i = 0; i < " + name + ".Count; ++i)\r\n";
            //这里使用的是 name + [i] 目的是获取 list当中的元素传入进行使用
            bytesNumStr += "\t\t\t\tnum += " + GetValueBytesNum(T, name + "[i]") + ";\r\n";
        }
        else if (type == "array")
        {
            string data = field.Attributes["data"].Value;
            bytesNumStr += "\t\t\tnum += 2;\r\n"; //+2 是为了节约字节数 用一个short去存储信息
            bytesNumStr += "\t\t\tfor (int i = 0; i < " + name + ".Length; ++i)\r\n";
            //这里使用的是 name + [i] 目的是获取 list当中的元素传入进行使用
            bytesNumStr += "\t\t\t\tnum += " + GetValueBytesNum(data, name + "[i]") + ";\r\n";
        }
        else if (type == "dic")
        {
            string Tkey = field.Attributes["Tkey"].Value;
            string Tvalue = field.Attributes["Tvalue"].Value;
            bytesNumStr += "\t\t\tnum += 2;\r\n"; //+2 是为了节约字节数 用一个short去存储信息
            bytesNumStr += "\t\t\tforeach (" + Tkey + " key in " + name + ".Keys)\r\n";
            bytesNumStr += "\t\t\t{\r\n";
            bytesNumStr += "\t\t\t\tnum += " + GetValueBytesNum(Tkey, "key") + ";\r\n";
            bytesNumStr += "\t\t\t\tnum += " + GetValueBytesNum(Tvalue, name + "[key]") + ";\r\n";
            bytesNumStr += "\t\t\t}\r\n";
        }
        else
            bytesNumStr += "\t\t\tnum += " + GetValueBytesNum(type, name) + ";\r\n";
    }

    return bytesNumStr;
}
```

### 在生成数据结构类函数中调用GetBytesNum函数，进行GetBytesNum函数的拼接。注意要添加命名空间。
```cs
//生成数据结构类
public void GenerateData(XmlNodeList nodes)
{
    string namespaceStr = "";
    string classNameStr = "";
    string fieldStr = "";
    string getBytesNumStr = "";

    foreach (XmlNode dataNode in nodes)
    {
        //命名空间
        namespaceStr = dataNode.Attributes["namespace"].Value;
        //类名
        classNameStr = dataNode.Attributes["name"].Value;
        //读取所有字段节点
        XmlNodeList fields = dataNode.SelectNodes("field");
        //通过这个方法进行成员变量声明的拼接 返回拼接结果
        fieldStr = GetFieldStr(fields);
        //通过某个方法 对GetBytesNum函数中的字符串内容进行拼接 返回结果
        getBytesNumStr = GetGetBytesNumStr(fields);

        string dataStr = "using System.Collections.Generic;\r\n" +
            "using System.Text;\r\n" +
            $"namespace {namespaceStr}\r\n" +
            "{\r\n" +
            $"\tpublic class {classNameStr} : BaseData\r\n" +
            "\t{\r\n" +
            $"{fieldStr}" +
            "\t\tpublic override int GetBytesNum()\r\n" +
            "\t\t{\r\n" +
            "\t\t\tint num = 0;\r\n" +
            $"{getBytesNumStr}" +
            "\t\t\treturn num;\r\n" +
            "\t\t}\r\n" +
            "\t}\r\n" +
            "}";

        //保存为 脚本文件
        //保存文件的路径
        string path = SAVE_PATH + namespaceStr + "/Data/";
        //如果不存在这个文件夹 则创建
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        //字符串保存 存储为枚举脚本文件
        File.WriteAllText(path + classNameStr + ".cs", dataStr);
    }
    Debug.Log("数据结构类生成结束");
}
```

### 点击编辑器按钮查看查看拼接的GetBytesNum函数结果
![[PlayerData 2.cs]]
```cs
public class PlayerData : BaseData
{
    public int id;
    public float atk;
    public bool sex;
    public long lev;
    public int[] arrays;
    public List<int> list;
    public Dictionary<int, string> dic;
    public E_HERO_TYPE heroType;
    public override int GetBytesNum()
    {
        int num = 0;
        num += 4;
        num += 4;
        num += 1;
        num += 8;
        num += 2;
        for (int i = 0; i < arrays.Length; ++i)
            num += 4;
        num += 2;
        for (int i = 0; i < list.Count; ++i)
            num += 4;
        num += 2;
        foreach (int key in dic.Keys)
        {
            num += 4;
            num += 4 + Encoding.UTF8.GetByteCount(dic[key]);
        }
        num += 4;
        return num;
    }
}
```
![[HeartData.cs]]
```cs
public class HeartData : BaseData
{
    public long time;
    public override int GetBytesNum()
    {
        int num = 0;
        num += 8;
        return num;
    }
}
```

