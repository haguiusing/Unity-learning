using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14_EditorGUIUtility_资源加载 : MonoBehaviour
{
    void Start()
    {
        #region 准备工作

        //随便导入一张图片用于测试

        #endregion

        #region 知识点一 Editor Default Resources文件夹

        //Editor Default Resources 也是Unity当中的一个特殊文件夹
        //它的主要作用是放置提供给 EditorGUIUtility 加载的资源
        //想要使用EditorGUIUtility公共类来加载资源
        //我们需要将资源放置在 Editor Default Resources 文件夹中

        #endregion

        #region 知识点二 加载资源（如果资源不存在返回null)

        //对应API：
        //EditorGUIUtility.Load
        //注意事项：
        //1.只能加载Assets/Editor Default Resources/文件夹下的资源
        //2.加载资源时，需要填写资源后缀名

        #endregion

        #region 知识点三 加载资源（如果资源不存在会直接报错）

        //对应API：
        //EditorGUIUtility.LoadRequired
        //注意事项：
        //1.只能加载Assets/Editor Default Resources/文件夹下的资源
        //2.加载资源时，需要填写资源后缀名

        #endregion
    }
}
