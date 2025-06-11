![[ExcelTool.cs]] ^a9db9b

### 创建ExcelTool类
```cs
public class ExcelTool
{
}
```

在ExcelTool类中定义了一个常量EXCEL_PATH，表示Excel文件存放的路径。
```cs
/// <summary>
/// excel文件存放的路径
/// </summary>
public static string EXCEL_PATH = Application.dataPath + "/ArtRes/Excel/";
```

创建为GenerateExcelInfo静态方法，使用[MenuItem]特性为GenerateExcelInfo方法创建了一个菜单项，用于在Unity编辑器中手动触发Excel数据生成的操作。
```cs
[MenuItem("GameTool/GenerateExcel")]
private static void GenerateExcelInfo()
{
}
```

GenerateExcelInfo方法中首先通过Directory.CreateDirectory方法得到了存放Excel文件的目录对象dInfo，CreateDirectory方法如果存在对应路径的话会返回目录对象，否则会创建对应目录。
```cs
//加载指定路径中的所有Excel文件 用于生成对应的3个文件 CreateDirectory方法如果存在对应路径的话会返回目录对象
DirectoryInfo dInfo = Directory.CreateDirectory(EXCEL_PATH);
```

获取目录中的所有文件信息，即Excel文件，保存在FileInfo数组files中。
```cs
//得到指定路径中的所有文件信息 相当于就是得到所有的Excel表
FileInfo[] files = dInfo.GetFiles();
```

初始化一个DataTableCollection对象tableConllection用于存储读取到的Excel表格数据。
```cs
//数据表容器
DataTableCollection tableConllection;
```

[DataTableCollection 类 (System.Data) | Microsoft Learn](h
```embed
title: "DataTableCollection 类 (System.Data)"
image: "https://learn.microsoft.com/en-us/media/open-graph-image.png"
description: "表示 DataSet 的表的集合。 "
url: "https://learn.microsoft.com/zh-cn/dotnet/api/system.data.datatablecollection?view=net-8.0"
favicon: ""
aspectRatio: "52.5"
```

对目录中的所有文件信息进行遍历，判断文件的扩展名是否是.xlsx或.xls，如果是则继续处理，否则跳过该文件。
使用FileStream打开Excel文件流，并使用ExcelReaderFactory.CreateOpenXmlReader方法创建一个IExcelDataReader实例Excel文件数据对象excelReader。将Excel文件数据对象读取为DataSet对象，并获取其中的数据表集合，将其赋值给tableConllection。关闭文件流。
遍历tableConllection中的每个数据表table，输出当前表格的名称，即Debug.Log(table.TableName)。之后遍历表的每条循环中，根据表格数据生成数据结构类，容器类和二进制数据。
- 注意：
    - excelReader.AsDataSet()得到的是DataSet 代表整个Excel文件的数据
    - excelReader.AsDataSet().Tables得到的是tableConllection tableConllection是DataTable集合 代表的是一个是Excel文件中的子表集合  
        ![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/6.Excel%E8%A1%A8%E8%87%AA%E5%8A%A8%E7%94%9F%E6%88%90%E7%9B%B8%E5%85%B3%E6%96%87%E4%BB%B6-%E8%AF%BB%E5%8F%96Excel%E7%9B%AE%E5%BD%95%E4%B8%8B%E6%89%80%E6%9C%89Excel%E6%96%87%E4%BB%B6/1.png)
        
    - 比如PlayerInfo和Sheet2都算一个子表 对应数据结构是一个DataTable 只不过Sheet2是空而已
```cs
//遍历所有文件
for (int i = 0; i < files.Length; i++)
{
    //如果不是excel文件就不要处理了
    if (files[i].Extension != ".xlsx" &&
        files[i].Extension != ".xls")
        continue;

    //打开一个 Excel 文件并获取其中的所有表的数据
    using (FileStream fs = files[i].Open(FileMode.Open, FileAccess.Read))
    {
        //创建 ExcelDataReader 实例 调用ExcelReaderFactory的CreateOpenXmlReader方法读取文件流
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

        //将 Excel 数据读取为 DataSet 对象，并获取其中的数据表集合
        tableConllection = excelReader.AsDataSet().Tables;

        fs.Close();
    }

    //遍历文件中的所有表的信息
    foreach (DataTable table in tableConllection)
    {
        Debug.Log(table.TableName);

        //生成数据结构类

        //生成容器类

        //生成2进制数据
    }
}
```

