using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson35_Scene窗口拓展_Gizmos_颜色立方体视锥跟随旋转 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 Gizmos修改颜色

        //Gizmos.color = Color.green;

        #endregion

        #region 知识点二 Gizmos绘制立方体

        //Gizmos.DrawCube(中心点, 大小);
        //Gizmos.DrawWireCube(中心点, 大小);

        #endregion

        #region 知识点三 Gizmos绘制视锥

        //Gizmos.DrawFrustum(绘制中心, FOV(Field of View,视野)角度, 远裁切平面, 近裁切平面, 屏幕长宽比); 

        #endregion

        #region 知识点四 如何改变绘制内容的角度

        //注意：Gizmos绘制立方体和视锥是不能跟随对象旋转的，我们要自行处理

        //修改Gizmos绘制前的矩阵
        //Gizmos.matrix
        //Gizmos.matrix = Matrix4x4.TRS(位置, 角度, 缩放);
        //还原矩阵
        //Gizmos.matrix = Matrix4x4.identity

        #endregion
    }

    private void OnDrawGizmosSelected()
    {
        //将绘制矩阵还原 那么以下绘制的对象不会跟随旋转
        Gizmos.matrix = Matrix4x4.identity;

        //Gizmos绘制立方体
        Gizmos.color = Color.green;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(2, 1, 3));

        //Gizmos绘制视锥
        Gizmos.color = Color.yellow;
        Gizmos.DrawFrustum(this.transform.position, 30, 50, 0.5f, 1.7f);


        //将绘制矩阵该为某个对象的 这样就可以跟着 移动 旋转 缩放了
        // Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, transform.localScale);
        // Gizmos.matrix = this.transform.localToWorldMatrix;//这句代码和上一行的作用一致
        //不想跟随缩放的话最后一个参数写死单位向量1即可
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(2, 1, 4));
    }
}