using UnityEditor;
using UnityEngine;

public class Lesson02_自定义菜单栏拓展 : MonoBehaviour
{
    [MenuItem("编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun")]
    private static void TestFun()
    {
        Debug.Log("TestFun");
    }

    [MenuItem("GameObject/编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun2")]
    private static void TestFun2()
    {
        Debug.Log("TestFun2");
    }

    [MenuItem("Assets/编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun3")]
    private static void TestFun3()
    {
        Debug.Log("TestFun3");
    }

    [MenuItem("CONTEXT/Lesson02_AddComponentMenu//编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun4")]
    private static void TestFun4()
    {
        Debug.Log("TestFun4");
    }

    [MenuItem("编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun5 _F4")]
    private static void TestFun5()
    {
        Debug.Log("TestFun5");
    }


    [MenuItem("编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun6 _A")]
    private static void TestFun6()
    {
        Debug.Log("TestFun6");
    }

    [MenuItem("编辑器拓展教程/Lesson02_自定义菜单栏拓展/TestFun7 _%#&A")]
    private static void TestFun7()
    {
        Debug.Log("TestFun7");
    }

    void Start()
    {
        #region 知识点一 特殊文件夹Editor

        //我们之前在学习Unity相关知识点时学习过
        //Editor文件夹是Unity中的特殊文件夹
        //所有Unity中编辑器相关的脚本都需要放置在其中

        //我们在本套课程学习中，会频繁的使用到UnityEditor等命名空间
        //这些使用了Unity编辑器相关命名空间的脚本最终是不能被打包出去的
        //我们需要把这些脚本放置到Editor文件夹中，避免打包时报错

        #endregion

        #region 知识点二 在Unity菜单栏中添加自定义页签

        //命名空间：UnityEditor
        //特性：MenuItem

        //用法：
        //在静态函数前加上
        //[MenuItem("页签/一级选项/二级选项/....")]

        //作用：
        //当在菜单栏点击该页签时
        //将执行静态函数中逻辑

        //注意：
        //1.不用在意继承对象 不继承Monobehaviour也没问题
        //2.斜杠必须是/ 不能是\

        #endregion

        #region 知识点三 在Hierarchy窗口中添加自定义页签

        //命名空间：UnityEditor
        //特性：MenuItem

        //用法：
        //在静态函数前加上，并且页签命名放入GameObject路径
        //[MenuItem("GameObject/页签/一级选项/二级选项/....")]

        //注意：
        //1.不用在意继承对象
        //2.斜杠必须是/
        //3.在菜单栏的GameObject中也会出现对应选项

        #endregion

        #region 知识点四 在Project窗口中添加自定义页签

        //命名空间：UnityEditor
        //特性：MenuItem

        //用法：
        //在静态函数前加上，并且页签命名放入Assets路径
        //[MenuItem("Assets/页签/一级选项/二级选项/....")]

        //注意：
        //1.不用在意继承对象
        //2.斜杠必须是/
        //3.在菜单栏的Assets中也会出现对应选项

        #endregion

        #region 知识点五 在菜单栏的Component菜单添加脚本

        //命名空间：UnityEngine
        //特性：AddComponentMenu

        //用法：
        //在想要通过Component菜单添加的脚本前加上
        //[AddComponentMenu("一级选项/二级选项/....")]

        //注意：
        //1.脚本需要继承MonoBehaviour对象
        //2.斜杠必须是/
        //3.最后一级选项的名字可以和脚本名不一样，但是建议一致
        //4.由于给GameObject添加的脚本肯定要继承Monobehaviour，所以不放在Editor文件夹



        #endregion

        #region 知识点六 在Inspector为脚本右键添加菜单

        //命名空间：UnityEditor
        //特性：MenuItem

        //用法：
        //在静态函数前加上
        //[MenuItem("CONTEXT/脚本名/页签/一级选项/二级选项/....")]

        //注意：
        //1.不用在意继承对象
        //2.斜杠必须是/

        #endregion

        #region 知识点七 加入快捷键

        //单键
        //路径后 + 空格 + 下划线 + 想要的按键

        //组合键
        //下划线替换为
        //%表示ctrl
        //#表示shift
        //&表示alt

        //其他支持的按键：
        //LEFT、RIGHT：持类似#LEFT是左shift之类的按键
        //UP、DOWN、F1..F12、HOME、END、PGUP、PGDN

        #endregion

        #region 总结

        //1.使用UnityEditor命名空间的脚本必须放在Editor文件夹下，避免打包报错
        //2.添加自定义页签 需要用到特性 MenuItem
        //3.添加代码添加页签 需要用到特性 AddComponentMenu

        #endregion
    }
}
