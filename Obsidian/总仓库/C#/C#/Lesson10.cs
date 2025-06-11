using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MyUnityDel1();
public delegate int MyUnityDel2(int i, int j);

public class Lesson10 : MonoBehaviour
{
    public MyUnityDel1 fun;
    public MyUnityDel2 fun2;

    public Action funAction;
    public Func<int, int, int> funFunc;

    // Start is called before the first frame update
    void Start()
    {
        #region 复制之前的热更新主入口调用
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //执行ILRuntime当中的一个静态函数
            //静态函数中 就是热更工程自己处理的逻辑了
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region 知识点一 在Unity中自定义委托后使用
        //1.ILRuntime中委托成员 关联ILRuntime工程中函数
        //直接常规使用即可
        //不会出现报错

        //2.Unity中委托成员 关联ILRuntime工程中函数
        //直接关联会出现报错，这里就涉及到委托成员的跨域
        //相当于Unity中的委托成员中存储了ILRuntime工程中的函数
        //就存在了跨域调用

        //我们需要进行以下处理：
        //可以通过报错信息中的提示
        //在进行初始化时进行代码的添加
        //主要有两部分：
        //1.注册委托(主要目的，避免IL2CPP打包裁剪报错)
        //2.注册委托转换器（主要目的，ILRuntime内部所有的委托都是以Action或Fun来存储的）

        //注意：
        //1.委托的注册相关流程必须在主工程中完成，在ILRuntime中没用
        //2.为了避免添加自定义委托转换器
        //  我们在使用委托时 尽量使用System命名空间中的
        //  Action和Fun
        //  这样就不需要进行注册委托转换器了，只需要注册即可
        #endregion

        #region 知识点二 在ILRuntime中自定义委托后使用
        //1.ILRuntime中委托成员 关联ILRuntime工程中函数

        //2.Unity中委托成员 关联ILRuntime工程中函数
        //一般不会出现基础工程中
        //使用还无法预知的可变代码
        //所以我们不需要考虑这种情况
        #endregion

        #region 总结
        //在委托的跨域调用中
        //如果出现Unity中自定义委托跨域关联ILRuntime中函数
        //需要进行
        //1.注册委托(主要目的，避免IL2CPP打包裁剪报错)
        //2.注册委托转换器（主要目的，ILRuntime内部所有的委托都是以Action或Fun来存储的）
        //注意：
        //1.委托的注册相关流程必须在主工程中完成
        //2.为了避免添加自定义委托转换器
        //  我们在使用委托时 尽量使用System命名空间中的
        //  Action和Fun
        //  这样就不需要进行注册委托转换器了，只需要注册即可
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
