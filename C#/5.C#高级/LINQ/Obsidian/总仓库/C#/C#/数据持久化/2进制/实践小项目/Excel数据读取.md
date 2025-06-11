![[LessonExcelRead.cs]]

### 打开Excel表
注意
- 假如ExcelDll放到Eiditor文件夹下 对Excel数据读取的脚本也要放到Eiditor文件夹下 否则无法访问 同时代码访问对应Excel表时不能打开占用对应Excel表 否则报错


#### 在Eiditor文件夹下创建一个Excel表。写入一些内容。
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/3.%E7%9F%A5%E8%AF%86%E7%82%B9%E8%A1%A5%E5%85%85-Excel%E6%95%B0%E6%8D%AE%E8%AF%BB%E5%8F%96/1.png)
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/3.%E7%9F%A5%E8%AF%86%E7%82%B9%E8%A1%A5%E5%85%85-Excel%E6%95%B0%E6%8D%AE%E8%AF%BB%E5%8F%96/2.png)

#### 创建打开Excel表方法
- 主要知识点：
    1. FileStream读取文件流
    2. IExcelDataReader类，从流中读取Excel数据
    3. DataSet 数据集合类 将Excel数据转存进其中方便读取
- 注意：
    - excelReader.AsDataSet()得到的是DataSet 代表整个Excel文件的数据
    - excelReader.AsDataSet().Tables得到的是tableConllection tableConllection是DataTable集合 代表的是一个是Excel文件中的子表集合
    - 比如PlayerInfo和Sheet2都算一个子表 对应数据结构是一个DataTable 只不过Sheet2是空而已

```cs
[MenuItem("Lesson03_知识点补充_Excel数据读取/打开Excel表")]
private static void OpenExcel()
{
    using (FileStream fileStream = File.Open(Application.dataPath + "/ArtRes/Excel/PlayerInfo.xlsx", FileMode.Open, FileAccess.Read))
    {
        // 通过ExcelReaderFactory的CreateOpenXmlReader和我们的文件流 获取Excel数据
        IExcelDataReader iExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

        // 将excel表中的数据转换为DataSet数据类型 方便我们 获取其中的内容
        DataSet dataSet = iExcelDataReader.AsDataSet();

        // 得到Excel文件中的所有表信息 现在Excel文件有PlayerInfo表和Sheet2空表 假如是空表不会遍历
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            Debug.Log("表名：" + dataSet.Tables[i].TableName);
            Debug.Log("行数：" + dataSet.Tables[i].Rows.Count);
            Debug.Log("列数：" + dataSet.Tables[i].Columns.Count);
        }

        fileStream.Close();
    }
}
```

#### 运行结果
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/3.%E7%9F%A5%E8%AF%86%E7%82%B9%E8%A1%A5%E5%85%85-Excel%E6%95%B0%E6%8D%AE%E8%AF%BB%E5%8F%96/3.png)

### 获取Excel表中单元格的信息
#### 主要知识点
- FileStream读取文件流
- IExcelDataReader类，从流中读取Excel数据
- DataSet 数据集合类 将Excel数据转存进其中方便读取
- DataTable 数据表类 表示Excel文件中的一个表
- DataRow 数据行类 表示某张表中的一行数据

```cs
[MenuItem("Lesson03_知识点补充_Excel数据读取/获取Excel表中单元格的信息")]
private static void ReadExcel()
{
    // 打开 Excel 文件并创建文件流（FileMode.Open 表示以只读方式打开）
    using (FileStream fileStream = File.Open(Application.dataPath + "/ArtRes/Excel/PlayerInfo.xlsx", FileMode.Open, FileAccess.Read))
    {
        // 创建 ExcelDataReader 实例，用于读取 Excel 数据
        IExcelDataReader iExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

        // 将 Excel 数据读取为 DataSet 对象
        DataSet dataSet = iExcelDataReader.AsDataSet();

        // 遍历 DataSet 中的所有表格 一个Table代表Excel的一个子表
        for (int i = 0; i < dataSet.Tables.Count; i++)
        {
            // 得到当前表格
            DataTable table = dataSet.Tables[i];

            // 遍历当前表格中的所有行
            DataRow row;
            for (int j = 0; j < table.Rows.Count; j++)
            {
                // 得到当前行数据
                row = table.Rows[j];

                Debug.Log("*********新的一行************");

                // 遍历当前行中的所有列
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    // 打印当前列的数据
                    Debug.Log(row[k].ToString());
                }
            }
        }

        // 关闭文件流
        fileStream.Close();
    }
}
```

![[Pasted image 20250605174944.png]]