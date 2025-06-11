using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lesson06_EditorGUI_枚举整数选择按下按钮 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 枚举选择控件

        //枚举选择
        //  枚举变量 = (枚举类型)EditorGUILayout.EnumPopup("枚举选择", 枚举变量);

        //多选枚举
        //(注意：多选枚举进行的是或运算，声明枚举时一定注意其中的赋值，并且一定要有多种情况的搭配值)
        //  枚举变量 = (枚举类型)EditorGUILayout.EnumFlagsField("枚举多选", 枚举变量);

        #endregion

        #region 知识点二 整数选择控件

        //int变量 = EditorGUILayout.IntPopup("整数单选框", int变量, 字符串数组, int数组);

        #endregion

        #region 知识点三 按下就触发的按钮控件

        //EditorGUILayout.DropdownButton(new GUIContent("按钮上文字"), FocusType.Passive)

        //FocusType枚举时告诉UI系统能够获得键盘焦点 当用户按Tab键时在控件之间进行切换
        //Keyboard	该控件可接收键盘焦点。
        //Passive 该控件不能接收键盘焦点。

        #endregion
    }
}
