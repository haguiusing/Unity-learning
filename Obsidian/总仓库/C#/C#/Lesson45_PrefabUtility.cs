using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson45_PrefabUtility : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 PrefabUtility公共类是什么

        //它是 Unity 编辑器中的一个公共类
        //提供了一些用于处理 Prefab（预制体或称预设体）的方法
        //主要功能包括 实例化预制体、创建预制体、修改预制体 等等

        //只要你有对预制体操作的相关需求
        //它可以在编辑器开发的任何地方对其进行使用

        #endregion

        #region 知识点二 创建自定义面板用于进行知识讲解

        #endregion

        #region 知识点三 常用API

        //1.动态创建预设体 路径从Assets/...开始
        //  PrefabUtility.SaveAsPrefabAsset(GameObject对象, 路径);

        //2.加载预制体对象（不能用于创建，一般用于修改，会把预设体加载到内存中）
        //  路径从Assets/...开始
        //  PrefabUtility.LoadPrefabContents(路径)
        //  释放加载的预设体对象
        //  PrefabUtility.UnloadPrefabContents(GameObject对象)
        //  注意：这两个方法需要配对使用，加载了就要写在

        //3.修改已有预设体 
        //  PrefabUtility.SavePrefabAsset(预设体对象, out bool 是否保存成功);
        //  可以配合AssetDatabase.LoadAssetAtPath使用

        //4.实例化预设体
        //  PrefabUtility.InstantiatePrefab(Object对象)

        #endregion

        #region 知识点四 更多内容

        //官方文档：https://docs.unity3d.com/2022.3/Documentation/ScriptReference/PrefabUtility.html

        #endregion
    }
}
