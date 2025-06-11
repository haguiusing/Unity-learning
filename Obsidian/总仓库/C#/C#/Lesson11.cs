using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson11 : MonoBehaviour
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

        #region 知识点一 什么是跨域继承
        //ILRuntime支持在热更工程中继承Unity主工程中的类
        //这就是跨域继承

        //注意：
        //ILRuntime中的跨域继承主要指热更工程继承Unity工程中的类
        //不存在Unity继承ILRuntime中的类一说
        //只需要记住，一般都是可变的（热更工程）使用不变的（Unity工程）内容
        #endregion

        #region 知识点二 如何进行跨域继承
        //1.在Untiy工程中实现基类
        //2.在ILRuntime工程中继承基类
        //3.通过工具生成跨域继承适配器
        //  ILRuntime\Assets\Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCrossBinding.cs
        //  按照其中的模板，填写自己要为哪个类生成跨域继承适配器对象
        //4.在初始化时，注册跨域继承适配器对象
        //  appDomain.RegisterCrossBindingAdaptor(new 适配器类名());
        #endregion

        #region 总结 
        //由于适配器在一些更为复杂的基类时，可能需要我们按照模板来手写一些内容
        //相对来说较为麻烦
        //如果没有特殊需求的情况下，或者是新开项目
        //都尽量不要出现跨域继承
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
