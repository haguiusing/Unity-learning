using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestSceneMono))]
public class TestSceneMonoEditor : Editor
{
    private void OnSceneGUI()
    {
        //ѡ�й���TestSceneMono�Ķ�����ӡ
        Debug.Log("Scene������չ����߼�");
    }
}
