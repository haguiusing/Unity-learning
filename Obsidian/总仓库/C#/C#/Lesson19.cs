using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson19 : MonoBehaviour
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

        #region 知识点一 准备ILRuntime调试相关插件
        //1.ILRuntime 2.1.0以下的版本 需要前往ILRuntime的Github页面获取插件
        //  地址：https://github.com/Ourpalm/ILRuntime
        //  打开页面后，点击右侧的Releases，在对应版本处下载调试插件

        //2.ILRuntime 2.1.0及其以上的版本 
        //  在VS上方的
        //  拓展-管理拓展-搜索ILRuntime后安装
        #endregion

        #region 知识点二 断点调试的必备工作
        //1.在初始化处 注册调试服务
        //  appDomain.DebugService.StartDebugService(端口号)

        //2.通过协同程序，等待调试器链接（否则我们无法对一开始的逻辑 进行断点）
        //  判断调试器链接的API为 appDomain.DebugService.IsDebuggerAttached

        //注意：一般只有在开发周期 才会这样去处理
        //如果最终发布了 就不用启动我们的调试服务 也不用去通过协程延迟执行后面的逻辑
        #endregion

        #region 知识点三 进行断点调试
        //在热更工程的 调试页签中 选择 Attach to ILRuntime
        //即可开始断点调试

        //注意：
        //1.附加到ILRuntime后
        //  弹出窗口中填写的内容为IP地址和端口号，意味着我们可以调试各种设备
        //  只要保证IP地址和端口号正确即可

        //2.如果ILRuntime相关的dll和pdb文件没有加载成功，调试会失败
        #endregion

        #region 总结
        //1.进行ILRuntime调试需要安装插件
        //2.想要进行断点调试，我们需要注册调试服务
        //  想要及时进断点，那么可以配合协同程序等待调试器链接
        //3.可以利用IP和端口调试特点来调试移动设备
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
