### 观察假如正常手写Writing函数应该怎么写
```cs
namespace GamePlayer
{
    public enum E_Player_Type
    {
        Main,
        Other,
    }

    public class PlayerTest : BaseData
    {
        public List<int> list;
        public Dictionary<int, string> dic;
        public int[] arrays;
        public E_Player_Type type;
        public PlayerData player;

        public override int GetBytesNum()
        {
            //...
        }

        public override int Reading(byte[] bytes, int beginIndex = 0)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] Writing()
        {
            //固定内容
            int index = 0;
            byte[] bytes = new byte[GetBytesNum()];

            //可变的 是根据成员变量来决定如何拼接的
            //存储list的长度
            WriteShort(bytes, (short)list.Count, ref index);
            for (int i = 0; i < list.Count; i++)
                WriteInt(bytes, list[i], ref index);

            //存储Dictionary的内容
            //长度
            WriteShort(bytes, (short)dic.Count, ref index);
            foreach (int key in dic.Keys)
            {
                WriteInt(bytes, key, ref index);
                WriteString(bytes, dic[key], ref index);
            }

            //存储数组的长度
            WriteShort(bytes, (short)arrays.Length, ref index);
            for (int i = 0; i < arrays.Length; i++)
                WriteInt(bytes, arrays[i], ref index);

            //枚举
            WriteInt(bytes, Convert.ToInt32(type), ref index);

            //自定义数据结构类
            WriteData(bytes, player, ref index);

            //固定内容
            return bytes;
        }
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

### 定义返回不同类型序列化的函数。假如是常规类型变量直接调用序列化方法。非常规类型要返回他的WriteData()方法的结果。
```cs
private string GetFieldWritingStr(string type, string name)
{
    switch (type)
    {
        case "byte":
            return "WriteByte(bytes, " + name + ", ref index);";
        case "int":
            return "WriteInt(bytes, " + name + ", ref index);";
        case "short":
            return "WriteShort(bytes, " + name + ", ref index);";
        case "long":
            return "WriteLong(bytes, " + name + ", ref index);";
        case "float":
            return "WriteFloat(bytes, " + name + ", ref index);";
        case "bool":
            return "WriteBool(bytes, " + name + ", ref index);";
        case "string":
            return "WriteString(bytes, " + name + ", ref index);";
        case "enum":
            return "WriteInt(bytes, Convert.ToInt32(" + name + "), ref index);";
        default:
            return "WriteData(bytes, " + name + ", ref index);";
    }
}
```

### 定义拼接Writing函数字符串的函数GetWritingStr
```cs
private string GetWritingStr(XmlNodeList fields)
{
    string writingStr = "";

    string type = "";
    string name = "";
    foreach (XmlNode field in fields)
    {
        type = field.Attributes["type"].Value;
        name = field.Attributes["name"].Value;
        if(type == "list")
        {
            string T = field.Attributes["T"].Value;
            writingStr += "\t\t\tWriteShort(bytes, (short)" + name + ".Count, ref index);\r\n";
            writingStr += "\t\t\tfor (int i = 0; i < " + name + ".Count; ++i)\r\n";
            writingStr += "\t\t\t\t" + GetFieldWritingStr(T, name + "[i]") + "\r\n";
        }
        else if (type == "array")
        {
            string data = field.Attributes["data"].Value;
            writingStr += "\t\t\tWriteShort(bytes, (short)" + name + ".Length, ref index);\r\n";
            writingStr += "\t\t\tfor (int i = 0; i < " + name + ".Length; ++i)\r\n";
           writingStr += "\t\t\t\t" + GetFieldWritingStr(data, name + "[i]") + "\r\n";
        }
        else if (type == "dic")
        {
            string Tkey = field.Attributes["Tkey"].Value;
            string Tvalue = field.Attributes["Tvalue"].Value;
            writingStr += "\t\t\tWriteShort(bytes, (short)" + name + ".Count, ref index);\r\n";
            writingStr += "\t\t\tforeach (" + Tkey + " key in " + name + ".Keys)\r\n";
            writingStr += "\t\t\t{\r\n";
            writingStr += "\t\t\t\t" + GetFieldWritingStr(Tkey, "key") + "\r\n";
            writingStr += "\t\t\t\t" + GetFieldWritingStr(Tvalue, name + "[key]") + "\r\n";
            writingStr += "\t\t\t}\r\n";
        }
        else
        {
            writingStr += "\t\t\t" + GetFieldWritingStr(type, name) + "\r\n";
        }
    }
    return writingStr;
}
```

### 在生成数据结构类函数中调用GetWritingStr函数，进行Writing函数的拼接。注意要添加命名空间。
```cs
//生成数据结构类
public void GenerateData(XmlNodeList nodes)
{
    string namespaceStr = "";
    string classNameStr = "";
    string fieldStr = "";
    string getBytesNumStr = "";
    string writingStr = "";

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
        //通过某个方法 对Writing函数中的字符串内容进行拼接 返回结果
        writingStr = GetWritingStr(fields);

        string dataStr = "using System;\r\n" +
                         "using System.Collections.Generic;\r\n" +
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
                         "\t\tpublic override byte[] Writing()\r\n" +
                         "\t\t{\r\n" +
                         "\t\t\tint index = 0;\r\n"+
                         "\t\t\tbyte[] bytes = new byte[GetBytesNum()];\r\n" +
                         $"{writingStr}" +
                         "\t\t\treturn bytes;\r\n" +
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

### 点击编辑器按钮查看查看拼接的Writing函数结果
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
        ...
    }
    public override byte[] Writing()
    {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteInt(bytes, id, ref index);
        WriteFloat(bytes, atk, ref index);
        WriteBool(bytes, sex, ref index);
        WriteLong(bytes, lev, ref index);
        WriteShort(bytes, (short)arrays.Length, ref index);
        for (int i = 0; i < arrays.Length; ++i)
            WriteInt(bytes, arrays[i], ref index);
        WriteShort(bytes, (short)list.Count, ref index);
        for (int i = 0; i < list.Count; ++i)
            WriteInt(bytes, list[i], ref index);
        WriteShort(bytes, (short)dic.Count, ref index);
        foreach (int key in dic.Keys)
        {
            WriteInt(bytes, key, ref index);
            WriteString(bytes, dic[key], ref index);
        }
        WriteInt(bytes, Convert.ToInt32(heroType), ref index);
        return bytes;
    }
}

public class HeartData : BaseData
{
    public long time;
    public override int GetBytesNum()
    {
        …
    }
    public override byte[] Writing()
    {
        int index = 0;
        byte[] bytes = new byte[GetBytesNum()];
        WriteLong(bytes, time, ref index);
        return bytes;
    }
}
```

