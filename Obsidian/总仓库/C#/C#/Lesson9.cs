using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 在ILRuntime工程中做一个主入口
        //我们在做有热更新功能的项目时
        //往往会有大量的逻辑是在热更工程中完成的
        //所以我们会在热更工程中做一个主入口
        //相当于是把逻辑处理权交给热更工程的感觉

        //类似在Lua热更相关知识点中讲解的相关内容

        ILRuntimeMgr.Instance.StartILRuntime(()=> {
            //执行ILRuntime当中的一个静态函数
            //静态函数中 就是热更工程自己处理的逻辑了
            ILRuntimeMgr.Instance.appDomain.Invoke("HotFix_Project.ILRuntimeMain", "Start", null, null);
        });

        #endregion

        #region 知识点二 ILRuntime调用Unity
        //就像在Unity开发中使用一样
        //引用命名空间后，直接使用即可
        //之所以我们能够直接使用
        //是因为热更工程已经引用了Unity对应的Dll文件

        //注意：
        //测试热更工程中 只关联引用了部分Unity相关dll
        //如果想要使用更多
        //只需要把对应Unity的Dll文件拷贝到热更工程中的UnityDlls文件夹中即可
        //再在热更工程中设置一下dll文件的引用
        #endregion

        #region 总结
        //ILRuntime跨域调用Unity中相关内容
        //相对更简单，和Unity开发中一样使用即可

        //需要注意的是
        //使用中如果无法正常使用Unity相关组件
        //都是因为热更工程没有引用对应的Unity相关模块的DLL文件
        //我们只需要找到对应DLL文件 复制到 热更工程中的UnityDlls文件夹中
        //并且在热更工程中引用 即可
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
