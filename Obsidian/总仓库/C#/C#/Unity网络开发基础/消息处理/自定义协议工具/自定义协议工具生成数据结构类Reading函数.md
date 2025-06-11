### 观察假如正常手写Reading函数应该怎么写
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
        ...
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        int index = beginIndex;

        list = new List<int>(); // 初始化规则
        short listCount = ReadShort(bytes, ref index);
        for (int i = 0; i < listCount; i++)
            list.Add(ReadInt(bytes, ref index));

        dic = new Dictionary<int, string>(); // 初始化规则
        short dicCount = ReadShort(bytes, ref index);
        for (int i = 0; i < dicCount; i++)
            dic.Add(ReadInt(bytes, ref index), ReadString(bytes, ref index));

        short arraysLength = ReadShort(bytes, ref index);
        arrays = new int[arraysLength]; // 初始化规则
        for (int i = 0; i < arraysLength; i++)
            arrays[i] = ReadInt(bytes, ref index);

        type = (E_Player_Type)ReadInt(bytes, ref index);

        player = ReadData<PlayerData>(bytes, ref index);

        return index - beginIndex;
    }

    public override byte[] Writing()
    {
        ...
    }
}
```

### 观察xml配置
```xml
<!-- 数据结构类配置规则 包含 类名 命名空间 变量类型 变量名 -->
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

### 定义返回不同类型反序列化的函数。假如是常规类型变量直接调用序列化方法。非常规类型要返回他的ReadData()方法的结果。
```cs
private string GetFieldReadingStr(string type)
{
    switch (type)
    {
        case "byte":
            return "ReadByte(bytes, ref index)";
        case "int":
            return "ReadInt(bytes, ref index)";
        case "short":
            return "ReadShort(bytes, ref index)";
        case "long":
            return "ReadLong(bytes, ref index)";
        case "float":
            return "ReadFloat(bytes, ref index)";
        case "bool":
            return "ReadBool(bytes, ref index)";
        case "string":
            return "ReadString(bytes, ref index)";
        default:
            return "ReadData<" + type + ">(bytes, ref index)";
    }
}
```

### 定义拼接Reading函数字符串的函数GetReadingStr
```cs
private string GetReadingStr(XmlNodeList fields)
{
    string readingStr = "";

    string type = "";
    string name = "";
    foreach (XmlNode field in fields)
    {
        type = field.Attributes["type"].Value;
        name = field.Attributes["name"].Value;
        if (type == "list")
        {
            string T = field.Attributes["T"].Value;
            readingStr += "\t\t\t" + name + " = new List<" + T + ">();\r\n";
            readingStr += "\t\t\tshort " + name + "Count = ReadShort(bytes, ref index);\r\n";
            readingStr += "\t\t\tfor (int i = 0; i < " + name + "Count; ++i)\r\n";
            readingStr += "\t\t\t\t" + name + ".Add(" + GetFieldReadingStr(T) + ");\r\n";
        }
        else if (type == "array")
        {
            string data = field.Attributes["data"].Value;
            readingStr += "\t\t\tshort " + name + "Length = ReadShort(bytes, ref index);\r\n";
            readingStr += "\t\t\t" + name + " = new " + data + "["+ name + "Length];\r\n";
            readingStr += "\t\t\tfor (int i = 0; i < " + name + "Length; ++i)\r\n";
            readingStr += "\t\t\t\t" + name + "[i] = " + GetFieldReadingStr(data) + ";\r\n";
        }
        else if (type == "dic")
        {
            string Tkey = field.Attributes["Tkey"].Value;
            string Tvalue = field.Attributes["Tvalue"].Value;
            readingStr += "\t\t\t" + name + " = new Dictionary<" + Tkey + ", " + Tvalue + ">();\r\n";
            readingStr += "\t\t\tshort " + name + "Count = ReadShort(bytes, ref index);\r\n";
            readingStr += "\t\t\tfor (int i = 0; i < " + name + "Count; ++i)\r\n";
            readingStr += "\t\t\t\t" + name + ".Add(" + GetFieldReadingStr(Tkey) + ", " +
                                                              GetFieldReadingStr(Tvalue) + ");\r\n";
        }
        else if (type == "enum")
        {
            string data = field.Attributes["data"].Value;
            readingStr += "\t\t\t" + name + " = (" + data + ")ReadInt(bytes, ref index);\r\n";
        }
        else
            readingStr += "\t\t\t" + name + " = " +GetFieldReadingStr(type) + ";\r\n";
    }

    return readingStr;
}
```

### 在生成数据结构类函数中调用GetReadingStr函数，进行Reading函数的拼接。
```cs
// 生成数据结构类
public void GenerateData(XmlNodeList nodes)
{
    string namespaceStr = "";
    string classNameStr = "";
    string fieldStr = "";
    string getBytesNumStr = "";
    string writingStr = "";
    string readingStr = "";

    foreach (XmlNode dataNode in nodes)
    {
        // 命名空间
        namespaceStr = dataNode.Attributes["namespace"].Value;
        // 类名
        classNameStr = dataNode.Attributes["name"].Value;
        // 读取所有字段节点
        XmlNodeList fields = dataNode.SelectNodes("field");
        // 通过这个方法进行成员变量声明的拼接 返回拼接结果
        fieldStr = GetFieldStr(fields);
        // 通过某个方法 对GetBytesNum函数中的字符串内容进行拼接 返回结果
        getBytesNumStr = GetGetBytesNumStr(fields);
        // 通过某个方法 对Writing函数中的字符串内容进行拼接 返回结果
        writingStr = GetWritingStr(fields);
        // 通过某个方法 对Reading函数中的字符串内容进行拼接 返回结果
        readingStr = GetReadingStr(fields);

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
                             "\t\tpublic override int Reading(byte[] bytes, int beginIndex = 0)\r\n" +
                             "\t\t{\r\n" +
                                 "\t\t\tint index = beginIndex;\r\n" +
                                 $"{readingStr}" +
                                 "\t\t\treturn index - beginIndex;\r\n" +
                             "\t\t}\r\n" +
                         "\t}\r\n" +
                         "}";

        // 保存为 脚本文件
        // 保存文件的路径
        string path = SAVE_PATH + namespaceStr + "/Data/";
        // 如果不存在这个文件夹 则创建
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        // 字符串保存 存储为枚举脚本文件
        File.WriteAllText(path + classNameStr + ".cs", dataStr);

    }
    Debug.Log("数据结构类生成结束");
}
```

### 点击编辑器按钮查看查看拼接的Reading函数结果
```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePlayer
{
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
            ...
        }
        public override int Reading(byte[] bytes, int beginIndex = 0)
        {
            int index = beginIndex;
            id = ReadInt(bytes, ref index);
            atk = ReadFloat(bytes, ref index);
            sex = ReadBool(bytes, ref index);
            lev = ReadLong(bytes, ref index);
            short arraysLength = ReadShort(bytes, ref index);
            arrays = new int[arraysLength];
            for (int i = 0; i < arraysLength; ++i)
                arrays[i] = ReadInt(bytes, ref index);
            list = new List<int>();
            short listCount = ReadShort(bytes, ref index);
            for (int i = 0; i < listCount; ++i)
                list.Add(ReadInt(bytes, ref index));
            dic = new Dictionary<int, string>();
            short dicCount = ReadShort(bytes, ref index);
            for (int i = 0; i < dicCount; ++i)
                dic.Add(ReadInt(bytes, ref index), ReadString(bytes, ref index));
            heroType = (E_HERO_TYPE)ReadInt(bytes, ref index);
            return index - beginIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace GameSystem
{
    public class HeartData : BaseData
    {
        public long time;
        public override int GetBytesNum()
        {
            ...
        }
        public override byte[] Writing()
        {
            ...
        }
        public override int Reading(byte[] bytes, int beginIndex = 0)
        {
            int index = beginIndex;
            time = ReadLong(bytes, ref index);
            return index - beginIndex;
        }
    }
}
```