using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson31_Scene窗口拓展_Handles_自由移动自由旋转 : MonoBehaviour
{
    void Start()
    {
        #region 知识回顾

        //HandleUtility.GetHandleSize
        //用于获取在 Scene 窗口中的一个单位距离所对应的屏幕空间大小
        //这个方法主要用于根据物体的距离来动态调整控制手柄的大小
        //使其在不同距离下能够在视图中显示合适的大小
        //一般我们把对象位置传递进去，他会自动得到一个句柄大小

        #endregion

        #region 知识点一 Handles中的自由移动

        //一个不受约束的移动控制柄
        //这个把手可以在所有方向上自由移动
        //Vector3 Handles.FreeMoveHandle(位置, 句柄大小, 移动步进值(按住ctrl键时会按该单位移动), 渲染控制手柄的回调函数);
        //句柄大小一般配合HandleUtility.GetHandleSize函数使用

        //渲染控制手柄的常用回调函数:
        //Handles.RectangleHandleCap:一个矩形形状的控制手柄，通常用于表示一个平面的控制面
        //Handles.CircleHandleCap:一个圆形的控制手柄，通常用于表示一个球体的控制面
        //Handles.ArrowHandleCap:一个箭头形状的控制手柄，通常用于表示方向

        #endregion

        #region 知识点二 Handles中的自由旋转

        //Quaternion Handles.FreeRotateHandle(角度, 位置, 句柄大小);

        #endregion
    }
}
