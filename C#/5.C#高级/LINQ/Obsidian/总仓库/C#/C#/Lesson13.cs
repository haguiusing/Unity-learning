using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson13 : MonoBehaviour
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

        #region 复习 CLR是什么（Unity进阶之C#知识补充）
        //CLR（Common Language Runtime）
        //公共语言运行时，它是.Net Framework的基础，
        //所有的.Net技术都是建立在此之上的
        //它帮助我们实现了跨语言和跨平台

        //它是一个在执行时管理代码的代码，提供内存管理、
        //线程管理等等核心服务，就好像一个小型的操作系统一样
        //所以形象的把它称为“.Net虚拟机”。
        //如果想要应用程序在目标操作系统上能够运行
        //就必须依靠.Net提供的CLR环境来支持
        #endregion

        #region 知识点一 CLR重定向是什么
        //CLR重定向主要是用于对热更工程中的的一些方法进行"挟持"
        //就是将原本的方法"挟持"了，重新实现方法里面的逻辑
        //达到 重定向的目的

        //说人话：
        //我们可以通过CLR重定向，将某一个方法的执行定位到我们的自定义逻辑中，而不是执行原本的方法逻辑
        //有点类似重写
        #endregion

        #region 知识点二 CLR绑定的作用和原理
        //默认情况下，ILRuntime热更工程调用Unity主工程相关内容都会通过反射来调用
        //这样有2个缺点：
        //1.性能较低，反射调用比直接调用效率低
        //2.IL2CPP打包时容易被裁剪

        //因此ILRuntime提供了自动分析生成CLR绑定的工具
        //它的作用是：
        //1.可以提高性能，将反射调用变为了直接调用
        //2.避免IL2CPP裁剪有用内容

        //原理：
        //CLR绑定，就是借助了ILRuntime的CLR重定向机制来实现的
        //本质上就是将方法的反射调用重定向到了我们自定义的方法里面来

        //注意：
        //每次我们打包发布工程之前都要记得生成CLR绑定
        #endregion

        #region 知识点三 如何进行CLR绑定
        //1. 打开 Samples\ILRuntime\2.1.0\Demo\Editor\ILRuntimeCLRBinding.cs 代码
        //   在 InitILRuntime 函数中注册跨域继承相关的类 以及 其他内容（以后会讲解）
        //2. 点击 工具栏——>ILRuntime——>通过自动分析热更DLL生成CLR绑定
        //   此时就可以在ILRuntimeCLRBinding.cs 代码中设置的到处路径中看到生成的绑定代码
        //3. 在初始化处 添加：ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);

        //注意：
        //如果在CLR绑定注册前进行了CLR重定向相关设置
        //为了保证自定义的重定向能够正常使用
        //初始化CLR绑定一定要放在最后一步
        //这样就不会影响自己想要保留的重定向等初始化操作了
        #endregion

        #region 知识点四 CLR绑定性能提升测试
        //我们再ILRuntime中去调用Unity中的方法
        //如果不进行CLR绑定，就是通过反射
        //如果绑定了，就是直接调用
        //我们可以通过测试函数来体现出性能的提升
        #endregion

        #region 知识点五 自定义CLR重定向
        //我们以Debug.Log举例
        //如果再ILRuntime工程中调用Debug.Log
        //我们是无法获取到热更工程中的脚本、行号相关信息的
        //我们可以通过CLR重定向的形式获取到信息后再打印

        //步骤：
        //1.利用CLR绑定中自动生成的绑定代码
        //  反射获取Debug中的Log函数
        //  对其进行重定向
        //2.在重定向中调用Debug.Log之前
        //  获取DLL内的堆栈信息 最后拼接打印

        //注意：
        //要使用CLR重定向时，需要在unsafe语句块中使用
        //所以我们需要在定义重定向函数和使用重定向函数的地方加上unsafe
        #endregion

        #region 总结
        //CLR绑定就是利用CLR重定向将原本需要反射调用的内容变为直接调用
        //可以帮助我们
        //1.提升ILRuntime的性能
        //2.避免IL2CPP打包时裁剪我们需要用的内容
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 用于测试CLR绑定 性能提升的函数
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    public static int TestFun(int i, int j)
    {
        return i + j;
    }
}
