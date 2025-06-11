using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15 : MonoBehaviour
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

        #region 知识点一 ILRuntime不推荐直接使用MonoBehaviour
        //ILRuntime中支持在热更工程中跨域继承MonoBehaviour
        //1.注册跨域继承适配器
        //2.对泛型方法AddComponent进行重定向（较为复杂）

        //但是
        //ILRuntime并不推荐通过跨域继承直接使用MonoBehaviour
        //推荐大家类似Lua中一样使用MonoBehaviour
        //在主工程中通过委托或事件的形式派发生命周期函数 到 热更中

        //主要原因：
        //MonoBehaviour是一个很特殊的类，很多底层逻辑是在C++中处理的
        //比如其中public字段的序列化，在Inspector窗口中显示的功能
        //如果在热更工程中去写，底层C++逻辑无法获取到热更工程中C#相关的信息
        #endregion

        #region 知识点二 派发生命周期函数的形式使用MonoBehaviour
        //在主工程中实现一个脚本
        //该脚本的主要目的就是派发MonoBehaviour的声明周期函数供热更工程中使用
        #endregion

        #region 总结
        //ILRuntime中虽然支持跨域继承MonoBehaviour
        //但是作者并不建议大家这样做
        //我们可以通过类似Lua热更中那样
        //在主工程中实现用于派发生命周期函数的的公共脚本
        //通过委托或事件达到生命周期函数的调用
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
