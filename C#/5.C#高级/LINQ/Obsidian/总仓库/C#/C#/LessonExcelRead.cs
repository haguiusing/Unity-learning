using Excel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LessonExcelRead
{
    #region 知识点一 打开Excel表
    //主要知识点：
    //1.FileStream读取文件流
    //2.IExcelDataReader类，从流中读取Excel数据
    //3.DataSet 数据集合类 将Excel数据转存进其中方便读取

    [MenuItem("GameTool/打开Excel表")]
    private static void OpenExcel()
    {
        using (FileStream fs = File.Open(Application.dataPath + "/ArtRes/Excel/PlayerInfo.xlsx", FileMode.Open, FileAccess.Read ))
        {
            //通过我们的文件流获取Excel数据
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            //将excel表中的数据转换为DataSet数据类型 方便我们 获取其中的内容
            DataSet result = excelReader.AsDataSet();
            //得到Excel文件中的所有表信息
            for (int i = 0; i < result.Tables.Count; i++)
            {
                Debug.Log("表名：" + result.Tables[i].TableName);
                Debug.Log("行数：" + result.Tables[i].Rows.Count);
                Debug.Log("列数：" + result.Tables[i].Columns.Count);
            }
            fs.Close();
        }
    }

    #endregion

    #region 知识点二 获取Excel表中单元格的信息
    //主要知识点：
    //1.FileStream读取文件流
    //2.IExcelDataReader类，从流中读取Excel数据
    //3.DataSet 数据集合类 将Excel数据转存进其中方便读取
    //4.DataTable 数据表类 表示Excel文件中的一个表
    //5.DataRow 数据行类 表示某张表中的一行数据
    [MenuItem("GameTool/读取Excel里的具体信息")]
    private static void ReadExcel()
    {
        using (FileStream fs = File.Open(Application.dataPath + "/ArtRes/Excel/PlayerInfo.xlsx", FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            DataSet result = excelReader.AsDataSet();

            for (int i = 0; i < result.Tables.Count; i++)
            {
                //得到其中一张表的具体数据
                DataTable table = result.Tables[i];
                //得到其中一行的数据
                //DataRow row = table.Rows[0];
                //得到行中某一列的信息
                //Debug.Log(row[1].ToString());
                DataRow row;
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    //得到每一行的信息
                    row = table.Rows[j];
                    Debug.Log("*********新的一行************");
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        Debug.Log(row[k].ToString());
                    }
                }
            }

            fs.Close();
        }
    }
    #endregion

    #region 知识点三 获取Excel表中信息对于我们的意义？
    //既然我们能够获取到Excel表中的所有数据
    //那么我们可以根据表中数据来动态的生成相关数据
    //1.数据结构类
    //2.容器类
    //3.2进制数据

    //为什么不直接读取Excel表而要把它转成2进制数据
    //1.提升读取效率
    //2.提升数据安全性
    #endregion
}
