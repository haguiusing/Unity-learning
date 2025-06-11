using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson38_Scene窗口拓展_Gizmos_球体网格线 : MonoBehaviour
{
    public Mesh mesh;

    void Start()
    {
        #region 知识点一 Gizmos绘制球体

        //Gizmos.DrawSphere(中心点, 半径);
        //Gizmos.DrawWireSphere(中心点, 半径);

        #endregion

        #region 知识点二 Gizmos绘制网格线

        //Gizmos.DrawWireMesh(mesh, 位置, 角度);

        #endregion

        #region 知识点三 更多Gizmos相关

        //官方文档：https://docs.unity3d.com/ScriptReference/Gizmos.html

        #endregion
    }

    private void OnDrawGizmosSelected()
    {
        // //Gizmos绘制球体
        // Gizmos.color = Color.red;
        // Gizmos.DrawSphere(this.transform.position, 2);
        // Gizmos.color = Color.white;
        // Gizmos.DrawWireSphere(this.transform.position, 3);

        //Gizmos绘制网格线
        Gizmos.color = Color.yellow;
        if (mesh != null)
            Gizmos.DrawWireMesh(mesh, this.transform.position, this.transform.rotation);
    }
}
