using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson33_Scene窗口拓展_HandleUtility : MonoBehaviour
{
    void Start()
    {
        #region 知识回顾 获取窗口上鼠标位置

        //Event.current.mousePosition

        #endregion

        #region 知识点一 HandleUtility公共类的主要作用

        //HandleUtility是 Unity 中的一个工具类
        //用于处理场景中的编辑器句柄（Handles）以及其他一些与编辑器交互相关的功能
        //它提供了一系列静态方法，用于处理编辑器中的鼠标交互、坐标转换以及其他与Handles相关的功能

        #endregion

        #region 知识点二 HandleUtility类中的常用API

        //1.GetHandleSize(Vector3 position)
        //  我们之前已经使用过的API
        //  获取在场景中给定位置的句柄的合适尺寸
        //  个方法通常用于根据场景中对象的距离来调整句柄的大小，以便在不同的缩放级别下保持合适的显示大小

        //2.WorldToGUIPoint(Vector3 worldPosition)
        //  将世界坐标转换为 GUI 坐标
        //  这个方法通常用于将场景中的某个点的位置转换为屏幕上的像素坐标
        //  以便在 GUI 中绘制相关的信息

        //3.GUIPointToWorldRay(Vector2 position)
        //  将屏幕上的像素坐标转换为射线
        //  这个方法通常用于从屏幕坐标中获取一条射线，用于检测场景中的物体或进行射线投射

        //4.DistanceToLine(Vector3 lineStart, Vector3 lineEnd)
        //  计算场景中一条线段与鼠标光标的最短距离
        //  可以用来制作悬停变色等功能

        //5.PickGameObject(Vector2 position, bool isSelecting)
        //  在编辑器中进行对象的拾取
        //  这个方法通常用于根据鼠标光标位置获取场景中的对象，以实现对象的选择或交互操作

        #endregion

        #region 知识点三 更多内容

        //官方文档：https://docs.unity3d.com/ScriptReference/HandleUtility.html

        #endregion
    }
}
