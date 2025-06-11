using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson37_Scene窗口拓展_Gizmos_线段网格射线 : MonoBehaviour
{
    public Mesh mesh;

    void Start()
    {
        #region 知识点一 Gizmos绘制线段

        //Gizmos.DrawLine(起点, 终点);

        #endregion

        #region 知识点二 Gizmos绘制网格

        //Gizmos.DrawMesh(mesh, 位置, 角度);

        #endregion

        #region 知识点三 Gizmos绘制射线

        //Gizmos.DrawRay(起点, 方向); 

        #endregion
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos绘制线段
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.one);

        //Gizmos绘制网格
        Gizmos.color = Color.blue;
        if (mesh != null)
            Gizmos.DrawMesh(mesh, this.transform.position, this.transform.rotation);

        //Gizmos绘制射线
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.forward);
    }
}
