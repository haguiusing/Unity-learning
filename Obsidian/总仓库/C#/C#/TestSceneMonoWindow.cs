using UnityEditor;
using UnityEngine;

public class TestSceneMonoWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/TestSceneMonoWindow")]
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
        //���򿪴����ҳ�����ͼ�����κθ��»��ӡ
        Debug.Log("�Զ��崰����չScene�������");
    }
}
