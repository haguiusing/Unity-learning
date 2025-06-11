[G:\Unity\UnityProjets\ILRuntimeDemo\Assets\Scripts\IL\ILRuntimeMgr.cs](file:///g%3A/Unity/UnityProjets/ILRuntimeDemo/Assets/Scripts/IL/ILRuntimeMgr.cs)
### 重新生成热更工程
![](https://linwentao785293209.github.io/images/%E7%83%AD%E6%9B%B4%E6%96%B0/Unity/ILRuntime/02.ILRuntime%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/2.ILRuntimeManager%E9%80%BB%E8%BE%91%E5%A4%84%E7%90%86/1.png)
重新生成热更工程，因为热更工程是要放到ab包中，所以把后缀改成txt，这样ab包才能识别，把它放到AB包中。

重写ILRuntimeManager
主要修改的地方是从AB中加载dll和pdb文件。
```cs
/// <summary>
/// 启动ILRuntime 加载对应的dll和pdb文件
/// </summary>
public void StartILRuntime(UnityAction callBack, UnityAction<string> infoCallBack)
{
    if(!isStart)
    {
        isStart = true;
        //初始化AppDomain
        appDomain = new AppDomain(ILRuntimeJITFlags.JITOnDemand);
        //加载对应的dll和pdb等文件 需要从AB包中去加载
        //通过AB包管理器 异步加载DLL文件信息
        infoCallBack("开始更新dll文件");
        ABMgr.GetInstance().LoadResAsync<TextAsset>("dll_res", "HotFix_Project.dll", (dll) =>
        {
            //异步加载完dll后 再去异步加载pdb文件 加载结束后 再使用他们来进行初始化
            infoCallBack("开始更新pdb文件");
            ABMgr.GetInstance().LoadResAsync<TextAsset>("dll_res", "HotFix_Project.pdb", (pdb) =>
            {
                //根据加载的文本信息 初始化 对应的两个流对象
                dllStream = new MemoryStream(dll.bytes);
                pdbStream = new MemoryStream(pdb.bytes);
                //利用初始化的流对象 进行ILRuntime的初始化
                appDomain.LoadAssembly(dllStream, pdbStream, new PdbReaderProvider());
                infoCallBack("开始初始化我们的 ILRuntime");
                //初始化相关的操作
                InitILRuntime();
                if(isDebug)
                {
                    infoCallBack("等待IDE接入开启调试");
                    StartCoroutine(WaitDebugger(callBack));
                }
                else
                {
                    infoCallBack("初始化结束");
                    //加载结束 初始化结束 把逻辑交给外部继续处理
                    callBack?.Invoke();
                }
            });
        });
    }
}
```