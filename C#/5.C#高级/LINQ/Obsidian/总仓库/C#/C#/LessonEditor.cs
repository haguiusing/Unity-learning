using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LessonEditor
{
    #region 知识点一 为编辑器菜单栏添加新的选项入口
    //可以通过Unity提供我们的MenuItem特性在菜单栏添加选项按钮
    //特性名：MenuItem
    //命名空间：UnityEditor

    //规则一：一定是静态方法
    //规则二：我们这个菜单栏按钮 必须有至少一个斜杠 不然会报错 它不支持只有一个菜单栏入口 
    //规则三：这个特性可以用在任意的类当中
    [MenuItem("GameTool/Test")]
    private static void Test()
    {
        Debug.Log("测试测试");
        #region 知识点二 刷新Project窗口内容
        //类名：AssetDatabase
        //命名空间：UnityEditor
        //方法：Refresh

        Directory.CreateDirectory(Application.dataPath + "/测试文件夹");

        AssetDatabase.Refresh();
        #endregion


    }

    #endregion

    #region 知识点三 Editor文件夹
    //Editor文件夹可以放在项目的任何文件夹下，可以有多个
    //放在其中的内容，项目打包时不会被打包到项目中
    //一般编辑器相关代码都可以放在该文件夹中
    #endregion

    #region 总结
    //我们之后在学习通过Excel表生成数据的功能时
    //可以在菜单栏加一个按钮
    //点击后就可以自动为我们生成对应数据了
    #endregion

}
