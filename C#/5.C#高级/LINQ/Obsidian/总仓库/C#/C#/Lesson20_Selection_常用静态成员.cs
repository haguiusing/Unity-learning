using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20_Selection_常用静态成员 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 获取当前选择的Object

        //获取当前在面板上选择的游戏物体Object
        //未选择则返回Null
        //选择多个则返回第一个选择的游戏物体
        //Selection.activeObject

        #endregion

        #region 知识点二 获取当前选择的GameObject

        //获取当前在面板上选择的游戏物体GameObject
        //未选择或者选择的不是游戏对象则返回Null
        //选择多个则返回第一个选择的游戏物体
        //Selection.activeGameObject

        #endregion

        #region 知识点三 获取当前选择的Transform

        //获取当前在面板上选择的游戏物体的Transform 只能获取Hierarchy窗口的对象
        //未选择则返回Null
        //选择多个则返回第一个选择的游戏物体
        //Selection.activeTransform

        //只能获取到场景中的对象的Transform

        #endregion

        #region 知识点四 获取当前选择的所有Object

        //获取当前在面板上选择的物体数组
        //未选择则返回Null
        //Selection.objects 

        #endregion

        #region 知识点五 获取当前选择的所有GameObject

        //获取当前在面板上选择的游戏物体或Project中预设体 GameObject数组
        //未选择则返回Null
        //Selection.gameObjects
        //可以遍历获取所有信息

        #endregion

        #region 知识点六 获取当前选择的所有Transform

        //获取当前在面板上选择的游戏物体Transform数组
        //未选择则返回Null
        //Selection.transforms
        //可以遍历获取所有信息

        #endregion
    }
}
