![[MyCompilationPipelineLearnWindow.cs]]

![[Lesson47_CompilationPipeline.cs]]

### CompilationPipeline公共类是用来做什么的
它是 Unity 编辑器中的一个公共类，用于处理代码编译相关的操作和事件的  
对于我们来说，我们最常用的是利用它得知代码是否编译结束  
比如动态生成脚本时，我们需要在编译结束后才能使用新的脚本

### 创建自定义面板用于进行知识讲解
```cs
using UnityEditor;

public class MyCompilationPipelineLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyCompilationPipelineLearnWindow")]
    private static void OpenLesson46()
    {
        MyCompilationPipelineLearnWindow win =
            EditorWindow.GetWindow<MyCompilationPipelineLearnWindow>("CompilationPipeline知识点学习");
        win.Show();
    }
}
```

### 常用内容
```cs
private void OnEnable()
{
    // CompilationPipeline.assemblyCompilationFinished
    // 命名空间：UnityEditor.Compilation;
    // 主要作用：当一个程序集编译结束会主动调用该回调函数
    // 传入的两个参数分别是
    // string arg1 : 编译完成的程序集名
    // CompilerMessage[] arg2 : 编译完成后产生的编译消息数组，包括编译警告和错误信息
    CompilationPipeline.assemblyCompilationFinished += CompilationPipeline_assemblyCompilationFinished;
    
    // CompilationPipeline.compilationFinished
    // 命名空间：UnityEditor.Compilation;
    // 主要作用：当所有程序集编译结束会主动调用该回调函数
    // 参数
    // object obj: ActiveBuildStatus 活动生成状态对象
    CompilationPipeline.compilationFinished += CompilationPipeline_compilationFinished;
}

private void CompilationPipeline_compilationFinished(object obj)
{
    Debug.Log("所有程序集编译结束");
}

private void CompilationPipeline_assemblyCompilationFinished(string arg1, CompilerMessage[] arg2)
{
    Debug.Log("程序集名：" + arg1);  
}

private void OnDestroy()
{
    CompilationPipeline.assemblyCompilationFinished -= CompilationPipeline_assemblyCompilationFinished;
    CompilationPipeline.compilationFinished -= CompilationPipeline_compilationFinished;
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.CompilationPipeline/1.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/47.CompilationPipeline/2.png)

### 更多内容
官方文档：[CompilationPipeline](https://docs.unity3d.com/ScriptReference/Compilation.CompilationPipeline.html)

