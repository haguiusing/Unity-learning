using System;

namespace Lesson4_变量的命名规则
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("变量的命名规则");

            #region 知识点一:必须遵守的
            //1.不能重名
            //2.不能以数字开头
            //3.不能使用程序关键字命名
            //4.不能有特殊符号 (下划线除外)
            //建议的命名规则: 变量名要有含义一>用英文 (拼音) 表示变量的作用
            //非常不建议的命名规则: 用汉字命名
            #endregion

            #region 知识点二:常用命名规则
            //驱峰命名法一首字母小写，之后单词首字母大写 (变量）
            //帕斯卡命名法一所有单词首字母都大写 (函数、类)
            #endregion

        }
    }
}