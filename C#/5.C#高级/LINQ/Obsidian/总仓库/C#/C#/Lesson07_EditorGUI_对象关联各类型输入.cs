using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson07_EditorGUI_对象关联各类型输入 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 对象关联控件

        //对象变量 = EditorGUILayout.ObjectField(对象变量, typeof(对象类型), 是否允许关联场景上对象资源) as 对象类型;

        #endregion

        #region 知识点二 各类型输入控件

        //int变量 = EditorGUILayout.IntField("Int输入框", int变量);
        //long变量 = EditorGUILayout.LongField("long输入框", long变量);
        //float变量 = EditorGUILayout.FloatField("Float 输入：", float变量);
        //double变量 = EditorGUILayout.DoubleField("double 输入：", double变量);

        //string变量 = EditorGUILayout.TextField("Text输入：", string变量);
        //vector2变量 = EditorGUILayout.Vector2Field("Vec2输入： ", vector2变量);
        //vector3变量 = EditorGUILayout.Vector3Field("Vec3输入： ", vector3变量);
        //vector4变量 = EditorGUILayout.Vector4Field("Vec4输入： ", vector4变量);
        //rect变量 = EditorGUILayout.RectField("rect输入： ", rect变量);
        //bounds变量 = EditorGUILayout.BoundsField("Bounds输入： ", bounds变量);
        //boundsInt变量 = EditorGUILayout.BoundsIntField("Bounds输入： ", boundsInt变量);

        //注意：EditorGUILayout中还有一些Delayed开头的输入控件
        //     他们和普通输入控件最主要的区别是：在用户按 Enter 键或将焦点从字段移开之前，返回值不会更改

        #endregion
    }
}
