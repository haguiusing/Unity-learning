using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson16 : MonoBehaviour
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

        #region 知识点一 在ILRuntime热更工程中使用协同程序
        //注册 协同程序的 跨域继承适配器
        //可以在示例工程中获取
        #endregion

        #region 知识点二 在ILRuntime热更工程中使用异步函数
        //注册 异步函数的 跨域继承适配器
        //可以获取别人写好的异步函数跨域适配器
        //https://github.com/jumpst/jumpst.github.io/blob/abc112a1ad718910f39bdd34323ae2633551a650/IAsyncStateMachineClassInheritanceAdaptor
        //若无法访问，可以在资料区下载该文件
        #endregion

        #region 总结
        //之所以需要注册跨域继承适配器
        //是因为在ILRuntime中的协同程序和异步函数
        //编译后本质上是通过状态机利用对象的状态来达到的异步
        //这里面的对象就用到了跨域继承
        //所以我们需要注册他们的跨域继承适配器来让热更新工程正常使用他们
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
