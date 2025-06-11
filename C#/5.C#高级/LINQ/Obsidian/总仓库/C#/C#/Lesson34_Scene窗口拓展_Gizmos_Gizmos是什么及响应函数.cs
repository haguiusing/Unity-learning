using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson34_Scene窗口拓展_Gizmos_Gizmos是什么及响应函数 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 Gizmos类是用来做什么的？

        //Gizmos和Handles一样
        //是用来让我们拓展Scene窗口的
        //而Gizmos相对Handles来说
        //它主要专注于绘制辅助线、图标、形状等
        //而Handles主要用来绘制编辑器控制手柄等

        #endregion

        #region 知识点二 Gizmos响应函数

        //在继承MonoBehaviour的脚本中实现以下函数
        //便可以在其中使用Gizmos来进行图形图像的绘制
        //1.OnDrawGizmos() 在每帧调用，绘制的内容随时可以在Scene窗口中看见
        //2.OnDrawGizmosSelected() 仅当脚本依附的GameObject被选中时才会每帧调用绘制相关内容
        //它们的执行类似生命周期函数，Unity会帮助我们自动执行

        #endregion
    }

    private void OnDrawGizmos()
    {
        Debug.Log("Gizmos");
    }

    private void OnDrawGizmosSelected()
    {
        Debug.Log("Gizmos2");
    }
}
