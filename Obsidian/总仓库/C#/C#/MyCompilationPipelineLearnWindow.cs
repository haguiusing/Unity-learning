using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

public class MyCompilationPipelineLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyCompilationPipelineLearnWindow")]
    private static void OpenLesson46()
    {
        MyCompilationPipelineLearnWindow win =
            EditorWindow.GetWindow<MyCompilationPipelineLearnWindow>("CompilationPipeline֪ʶ��ѧϰ");
        win.Show();
    }

    private void OnEnable()
    {
        //1.CompilationPipeline.assemblyCompilationFinished
        //  �����ռ䣺UnityEditor.Compilation;
        //  ��Ҫ���ã���һ�����򼯱���������������øûص�����
        //  ��������������ֱ���
        //  string arg1 : ������ɵĳ�����
        //  CompilerMessage[] arg2 : ������ɺ�����ı�����Ϣ���飬�������뾯��ʹ�����Ϣ
        CompilationPipeline.assemblyCompilationFinished += CompilationPipeline_assemblyCompilationFinished;

        //2.CompilationPipeline.compilationFinished
        //  �����ռ䣺UnityEditor.Compilation;
        //  ��Ҫ���ã������г��򼯱���������������øûص�����
        //  ����
        //  object obj: ActiveBuildStatus �����״̬����
        CompilationPipeline.compilationFinished += CompilationPipeline_compilationFinished;
    }

    private void CompilationPipeline_compilationFinished(object obj)
    {
        Debug.Log("���г��򼯱������");
    }

    private void CompilationPipeline_assemblyCompilationFinished(string arg1, CompilerMessage[] arg2)
    {
        Debug.Log("��������" + arg1);
    }

    private void OnDestroy()
    {
        CompilationPipeline.assemblyCompilationFinished -= CompilationPipeline_assemblyCompilationFinished;
        CompilationPipeline.compilationFinished -= CompilationPipeline_compilationFinished;
    }
}
