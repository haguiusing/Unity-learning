using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

public class MyCompilationPipelineLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyCompilationPipelineLearnWindow")]
    private static void OpenLesson46()
    {
        MyCompilationPipelineLearnWindow win =
            EditorWindow.GetWindow<MyCompilationPipelineLearnWindow>("CompilationPipeline知识点学习");
        win.Show();
    }

    private void OnEnable()
    {
        //1.CompilationPipeline.assemblyCompilationFinished
        //  命名空间：UnityEditor.Compilation;
        //  主要作用：当一个程序集编译结束会主动调用该回调函数
        //  传入的两个参数分别是
        //  string arg1 : 编译完成的程序集名
        //  CompilerMessage[] arg2 : 编译完成后产生的编译消息数组，包括编译警告和错误信息
        CompilationPipeline.assemblyCompilationFinished += CompilationPipeline_assemblyCompilationFinished;

        //2.CompilationPipeline.compilationFinished
        //  命名空间：UnityEditor.Compilation;
        //  主要作用：当所有程序集编译结束会主动调用该回调函数
        //  参数
        //  object obj: ActiveBuildStatus 活动生成状态对象
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
}
