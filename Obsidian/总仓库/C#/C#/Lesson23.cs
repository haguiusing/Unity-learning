using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 回顾 类型系统的作用
        //用于表示热更工程中的各种类型、方法、成员、实例对象等等信息
        //相当于，ILRuntime帮助我们利用它内部的解释器,将我们实现的代码解释翻译为了自己的一套类型规则
        //在真正执行代码时，都是基于ILRuntime自己的类型系统中的规则来执行的

        //说人话：类型系统 是 热更工程中的类、方法、成员等信息 的载体
        #endregion

        #region 知识点二 类型系统中的关键接口
        //1.IType
        //2.IMethod
        //3.ILTypeInstance

        //在思维导图稍微详细的来了解他们
        #endregion

        #region 知识点三 学习类型系统的目的
        //大概了解了类型系统的作用和构成后
        //我们再反观之前学习的知识点
        //我们能够明白之前为什么要那样做
        #endregion

        #region 总结
        //类型系统就是ILRuntime用于 解释 热更工程中所有类、方法、属性等信息后 逻辑的载体
        //ILRuntime 读取DLL后，通过解释器，将其中的 IL 中间代码信息翻译为符合类型系统规则信息
        //我们可以利用它来执行 DLL当中的代码逻辑
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
