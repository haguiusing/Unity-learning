![[读取Excel目录下所有Excel文件#^a9db9b]]

创建生成Excel表对应的数据结构类函数，在生成Excel信息函数的遍历表循环中调用
```cs
[MenuItem("GameTool/GenerateExcel")]
private static void GenerateExcelInfo()
{
    // 遍历文件中的所有表的信息
    foreach (DataTable table in tableConllection)
    {
        Debug.Log(table.TableName);

        // 生成数据结构类
        GenerateExcelDataClass(table);

        // 生成容器类

        // 生成二进制数据
    }
}
private static void GenerateExcelDataClass(DataTable table)
{

}
```

创建获取变量名所在行函数和获取变量类型所在行函数。分别返回第0行和第1行，在生成Excel表对应的数据结构类函数中调用。
```cs
/// <summary>
/// 生成Excel表对应的数据结构类
/// </summary>
/// <param name="table"></param>
private static void GenerateExcelDataClass(DataTable table)
{
    // 字段名行
    DataRow rowName = GetVariableNameRow(table);

    // 字段类型行
    DataRow rowType = GetVariableTypeRow(table);
}

/// <summary>
/// 获取变量名所在行
/// </summary>
/// <param name="table"></param>
/// <returns></returns>
private static DataRow GetVariableNameRow(DataTable table)
{
    return table.Rows[0];
}

/// <summary>
/// 获取变量类型所在行
/// </summary>
/// <param name="table"></param>
/// <returns></returns>
private static DataRow GetVariableTypeRow(DataTable table)
{
    return table.Rows[1];
}
```

创建数据结构类脚本存储位置路径，在生成Excel表对应的数据结构类函数中判断数据结构类脚本存储位置路径是否存在，没有的话就创建文件夹
```cs
/// <summary>
/// 数据结构类脚本存储位置路径
/// </summary>
public static string DATA_CLASS_PATH = Application.dataPath + "/Scripts/ExcelData/DataClass/";

// 判断路径是否存在，没有的话就创建文件夹
if (!Directory.Exists(DATA_CLASS_PATH))
    Directory.CreateDirectory(DATA_CLASS_PATH);
```

在生成Excel表对应的数据结构类函数中用字符串逐个拼接出数据结构类和对应变量。把拼接好的字符串存到指定文件中去。刷新Project窗口。
```cs
// 如果我们要生成对应的数据结构类脚本，其实就是通过代码进行字符串拼接，然后存进文件就行了
string str = "public class " + table.TableName + "\n{\n";

// 遍历表的列 变量进行字符串拼接
for (int i = 0; i < table.Columns.Count; i++)
{
    str += "    public " + rowType[i].ToString() + " " + rowName[i].ToString() + ";\n";
}

str += "}";

// 把拼接好的字符串存到指定文件中去
File.WriteAllText(DATA_CLASS_PATH + table.TableName + ".cs", str);

// 刷新Project窗口
AssetDatabase.Refresh();
```