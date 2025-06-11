using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson43_AssetDatabase_AssetDatabase是什么 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 AssetDatabase公共类是用来做什么的？

        //它是 Unity 引擎中的一个编辑器类
        //用于在编辑器环境中管理和操作项目中的资源（Assets）
        //它提供了一系列静态方法
        //使得开发者能够在编辑器脚本中进行资源的创建、拷贝、移动、删除等操作

        #endregion

        #region 知识点二 在哪里使用AssetDatabase公共类中的相关内容

        //在编辑器相关处都可以使用AssetDatabase公共类中的相关内容
        //它主要提供的是一些资源相关的辅助功能，可以在编辑器拓展开发的任意地方使用
        //但一定注意，它属于编辑器功能，无法被打包出去，只能在Unity编辑器中使用

        #endregion

        #region 知识点三 准备工作

        //AssetDatabase可以在任何编辑器功能开发时使用
        //但是为了之后的知识点讲解更方便
        //我们通过一个自定义窗口来进行知识讲解

        #endregion
    }
}
