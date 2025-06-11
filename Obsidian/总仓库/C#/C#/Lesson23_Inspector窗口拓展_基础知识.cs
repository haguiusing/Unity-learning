using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23_Inspector窗口拓展_基础知识 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 Inspector窗口自定义显示指什么？

        //我可以完全自定义某一个脚本在Inspector窗口的相关显示

        #endregion

        #region 知识点二 SerializedObject和SerializedProperty的作用

        //SerializedObject 和 SerializedProperty
        //主要用于在 Unity 编辑器中操作和修改序列化对象的属性。
        //它们通常在自定义编辑器中使用，以创建更灵活、可定制的属性面板

        //我们只需要记住简单的规则
        //SerializedObject 代表脚本(组件)对象
        //SerializedProperty 代表脚本（组件）对象中的属性

        //SerializedObject官方文档: https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedObject.html
        //SerializedProperty官方文档: https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedProperty.html

        #endregion

        #region 知识点三 自定义脚本在Inspector窗口中显示的内容

        //关键步骤：

        //1.单独为某一个脚本实现一个自定义脚本，并且脚本需要继承Editor
        //  一般该脚本命名为 自定义脚本名 + Editor

        //2.在该脚本前加上特性
        //  命名空间：UnityEditor
        //  特性名：CustomEditor(想要自定义脚本类名的Type)

        //3.声明对应SerializedProperty序列化属性 对象
        //  主要通过它和自定义脚本中的成员进行关联
        //  可以利用继承Editor后的成员serializedObject中的FindProperty("成员变量名")方法关联对应成员;
        //  比如：SerializedProperty mySerializedProperty;
        //        mySerializedProperty = serializedObject.FindProperty("自定义脚本中的成员名");
        //  一般在OnEnable函数中初始化

        //4.重写OnInspectorGUI函数
        //  该函数控制了Inspector窗口中显示的内容
        //  只需要在其中重写内容便可以自定义窗口
        //  注意：其中的逻辑需要包裹在这两句代码之间
        //  更新序列化对象的表示形式
        //  serializedObject.Update();
        //  之间应用属性修改
        //  serializedObject.ApplyModifiedProperties();

        #endregion

        #region 知识点四 获取脚本对象

        //Editor中的target成员变量 得到的是当前正在被自定义编辑器检视的组件对象

        #endregion

        #region 总结

        //我们为继承Editor的脚本
        //添加[CustomEditor(typeof(想要自定义Inspector窗口的脚本))]特性
        //在该脚本中按照一定的规则进行编写
        //便可为Inspector窗口中的某个脚本自定义窗口布局

        #endregion
    }
}
