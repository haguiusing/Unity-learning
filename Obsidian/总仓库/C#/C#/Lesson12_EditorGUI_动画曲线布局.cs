using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12_EditorGUI_动画曲线布局 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 动画曲线控件

        //AnimationCurve变量  = EditorGUILayout.CurveField("动画曲线：", AnimationCurve变量);

        #endregion

        #region 知识点二 布局相关API

        //EditorGUILayout.BeginHorizontal(); //开始水平布局
        //一大堆控件
        //EditorGUILayout.EndHorizontal();//结束水平布局

        //EditorGUILayout.BeginVertical();//开始垂直布局
        //一大堆控件
        //EditorGUILayout.EndVertical();//结束垂直布局

        //Vector2布局 = EditorGUILayout.BeginScrollView(Vector2布局); //开启滚动视图
        //一大堆控件
        //EditorGUILayout.EndScrollView(); //结束滚动视图

        #endregion

        #region 总结

        //EditorGUILayout中更多内容
        //https://docs.unity.cn/cn/2022.3/ScriptReference/EditorGUILayout.html

        #endregion
    }
}
