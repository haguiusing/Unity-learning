using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 复制之前的主入口调用
        ILRuntimeMgr.Instance.StartILRuntime(() => {
            //执行ILRuntime当中的一个静态函数
            //静态函数中 就是热更工程自己处理的逻辑了
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });
        #endregion

        #region 知识点一 复习跨域继承的步骤
        //1.在Untiy工程中实现基类
        //2.在ILRuntime工程中继承基类
        //3.通过工具生成跨域继承适配器
        //  ILRuntime\Assets\Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCrossBinding.cs
        //  按照其中的模板，填写自己要为哪个类生成跨域继承适配器对象
        //4.在初始化时，注册跨域继承适配器对象
        //  appDomain.RegisterCrossBindingAdaptor(new 适配器类名());

        //这样我们就能在热更工程中正常跨域继承了
        #endregion

        #region 知识点二 跨域继承中的注意事项
        //跨域继承基本原理：
        //ILRuntime中的跨域继承实际上并不是直接继承Unity中的基类
        //而是继承的适配器类
        //            基类（Unity中）
        //             |
        //          适配器类（Unity工程中的实际类型）
        //             |
        //            子类（ILRuntime中）

        //注意事项：
        //1.跨域继承时，不支持多继承，即同时继承类和接口

        //2.如果项目框架设计中一定要出现多继承
        //  那么在跨域继承时可以在主工程中声明一个多继承的基类用于跨域继承

        //3.跨域继承中，不能在基类的构造函数中调用该类的虚函数
        #endregion

        #region 总结
        //跨域继承时（ILRuntime工程继承Unity主工程中的类）
        //1.ILRuntime不支持跨域（ILRuntime继承Unity）多继承
        //2.如果一定要跨域（ILRuntime继承Unity）多继承，就在主工程中用一个类将多继承关系疏离继承好，在热更工程中继承该类
        //3.跨域继承中，不能在基类的构造函数中调用该类的虚函数，会报错
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
