using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestSceneMono))]
public class TestSceneMonoEditor : Editor
{
    private void OnSceneGUI()
    {
        //选中挂载TestSceneMono的对象会打印
        Debug.Log("Scene窗口拓展相关逻辑");
    }
}
