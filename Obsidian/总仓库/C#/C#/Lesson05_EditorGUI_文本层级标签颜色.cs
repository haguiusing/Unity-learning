using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson05_EditorGUI_文本层级标签颜色 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 EditorGUILayout中的文本控件

        //EditorGUILayout.LabelField("文本标题", "文本内容");
        //EditorGUILayout.LabelField("文本内容");

        #endregion

        #region 知识点二 EditorGUILayout中的层级、标签选择

        //Layer
        //  int变量 = EditorGUILayout.LayerField("层级选择", int变量);
        //Tag
        //  string变量 = EditorGUILayout.TagField("标签选择", string变量);

        #endregion

        #region 知识点三 EditorGUILayout中的颜色获取

        //color变量 = EditorGUILayout.ColorField(new GUIContent("标题"),
        //                                      color变量, 是否显示拾色器（右边是否有吸管吸颜色）, 是否显示透明度通道（设置透明度）, 是否支持HDR);

        #endregion
    }
}
