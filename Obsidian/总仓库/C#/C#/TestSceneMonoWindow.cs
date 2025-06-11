using UnityEditor;
using UnityEngine;

public class TestSceneMonoWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/TestSceneMonoWindow")]
    private static void OpenTestSceneMonoWindow()
    {
        TestSceneMonoWindow win = EditorWindow.GetWindow<TestSceneMonoWindow>();
        win.Show();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += SceneUpdate;
    }

    private void OnDestroy()
    {
        SceneView.duringSceneGui -= SceneUpdate;
    }

    private void SceneUpdate(SceneView view)
    {
        //当打开窗口且场景视图存在任何更新会打印
        Debug.Log("自定义窗口拓展Scene相关内容");
    }
}
