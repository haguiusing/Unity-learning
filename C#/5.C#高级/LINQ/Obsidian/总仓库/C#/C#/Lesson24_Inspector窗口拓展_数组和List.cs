using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson24_Inspector窗口拓展_数组和List : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 数组、List属性在Inspector窗口显示 基础方式

        //主要知识点：
        //EditorGUILayout.PropertyField(SerializedProperty对象, 标题);
        //该API会按照属性类型自己去处理控件绘制的逻辑

        #endregion

        #region 知识点二 数组、List属性在Inspector窗口显示 自定义方式

        //如果我们不想要Unity默认的绘制方式去显示 数组、List相关内容
        //我们也可以完全自定义布局方式
        //主要知识点：
        //利用SerializedProperty中数组相关的API来完成自定义
        //1.arraySize 获取数组或List容量
        //2.InsertArrayElementAtIndex(索引) 为数组在指定索引插入默认元素（容量会变化）
        //3.DeleteArrayElementAtIndex(索引) 为数组在指定索引删除元素（容量会变化）
        //4.GetArrayElementAtIndex(索引) 获取数组中指定索引位置的 SerializedProperty 对象

        #endregion
    }
}
