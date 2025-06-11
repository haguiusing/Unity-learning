using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21_Selection_常用静态方法 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一 判断某个对象是否被选中

        //Contains 判断某个对象是否被选中

        #endregion

        #region 知识点二 筛选对象

        //从当前选择对象中，筛选出想要的内容
        //Selection.GetFiltered(类型, 筛选模式)
        //Selection.GetFiltered<类型>(筛选模式)

        //  筛选模式：SelectionMode
        //  Unfiltered: 不过滤
        //  TopLevel: 只获取最上层对象，子对象不获取
        //  Deep: 父对象、子对象都获取
        //  ExcludePrefab: 排除预设体
        //  Editable: 只选择可编辑的对象
        //  OnlyUserModifiable: 仅用户可修改的内容
        //  Assets: 只返回资源文件夹下的内容
        //  DeepAssets: 如果存在子文件夹，其中的内容也获取
        //  如果要混用 位或 | 即可

        #endregion

        #region 知识点三 当选中变化时会调用的委托

        //Selection.selectionChanged += 函数;//选择的物体变化时调用

        #endregion

        #region 总结

        //Selection公共类主要是帮助我们获取到选择的对象的
        //我们可以利用它对选中对象进行一些处理

        //Selection公共类 更多API
        //https://docs.unity.cn/cn/2022.1/ScriptReference/Selection.html

        #endregion
    }
}
