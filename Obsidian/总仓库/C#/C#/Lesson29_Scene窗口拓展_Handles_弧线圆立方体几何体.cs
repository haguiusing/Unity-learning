using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson29_Scene窗口拓展_Handles_弧线圆立方体几何体 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 Handles中的弧线(圆弧)

        //绘制线框弧线
        //Handles.DrawWireArc(圆心, 法线, 绘制朝向, 角度, 半径); 
        // 绘制填充弧线
        //Handles.DrawSolidArc(圆心, 法线, 绘制朝向, 角度, 半径); 

        #endregion

        #region 知识点二 Handles中的圆

        //绘制填充圆
        //Handles.DrawSolidDisc(圆心, 法线, 半径); 
        //绘制线框圆
        //Handles.DrawWireDisc(圆心, 法线, 半径); 

        #endregion

        #region 知识点三 Handles中的立方体线框

        //Handles.DrawWireCube(中心点, xyz大小);

        #endregion

        #region 知识点四 Handles中的几何体

        //Handles.DrawAAConvexPolygon(几何体各顶点);

        #endregion
    }
}
