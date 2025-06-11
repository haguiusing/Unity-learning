using System;
using UnityEditor;
using UnityEngine;

public class MyPrefabUtilityLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyPrefabUtilityLearnWindow")]
    private static void OpenMyPrefabUtilityLearnWindow()
    {
        MyPrefabUtilityLearnWindow win = EditorWindow.GetWindow<MyPrefabUtilityLearnWindow>("PrefabUtility֪ʶѧϰ");
        win.Show();
    }

    private void OnGUI()
    {
        //1.��̬����Ԥ���� ·����Assets/...��ʼ
        //  PrefabUtility.SaveAsPrefabAsset(GameObject����, ·��);
        if (GUILayout.Button("��̬����Ԥ����"))
        {
            GameObject obj = new GameObject();//������Ҳ�����Ԥ����
            obj.AddComponent<Rigidbody>();
            obj.AddComponent<BoxCollider>();
            PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Resources/TestObj.prefab");
            DestroyImmediate(obj);//���볡����Ҳ����Ԥ���������ɾ��
        }


        //2.����Ԥ������󣨲������ڴ�����һ�������޸ģ����Ԥ������ص��ڴ��У�
        //  ·����Assets/...��ʼ
        //  PrefabUtility.LoadPrefabContents(·��)
        //  �ͷż��ص�Ԥ�������
        //  PrefabUtility.UnloadPrefabContents(GameObject����)
        //  ע�⣺������������Ҫ���ʹ�ã������˾�Ҫ�ͷ�

        //����ļ��� ��������ʵ�Ѿ���Ԥ���������ʵ������ ֻ������ʵ�������󲢲����ڴ�ͳ��Scene�����У�����һ���������Ķ����ĳ����У�
        if (GUILayout.Button("����Ԥ�������"))
        {
            //���� ���ڴ��� ��������ʵ���� һ����س����ǽ����޸ĵ�  �����Ԥ����������
            GameObject testObj = PrefabUtility.LoadPrefabContents("Assets/Resources/TestObj.prefab");
            testObj.AddComponent<MeshRenderer>();

            //��չ��
            //���ּ��ط�ʽ �ǿ��Խ��нű��Ƴ� �Ӷ��󴴽���
            DestroyImmediate(testObj.GetComponent<MeshRenderer>());
            GameObject obj = new GameObject("�½��Ӷ���");
            obj.transform.parent = testObj.transform;


            //������ԭ�ȵ�Ԥ����
            PrefabUtility.SaveAsPrefabAsset(testObj, "Assets/Resources/TestObj.prefab");
            //�ͷ� һ��Ҫ���ʹ��
            PrefabUtility.UnloadPrefabContents(testObj);
        }


        //3.�޸�����Ԥ���� 
        //  PrefabUtility.SavePrefabAsset(Ԥ�������, out bool �Ƿ񱣴�ɹ�);
        //  �������AssetDatabase.LoadAssetAtPathʹ��
        if (GUILayout.Button("�޸�����Ԥ���� "))
        {
            GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/TestObj.prefab");
            testObj.AddComponent<Camera>();
            //����������ܴ洢ʵ����������� ֻ�ܴ洢��Ӧ��Ԥ�������
            PrefabUtility.SavePrefabAsset(testObj);
        }


        //4.ʵ����Ԥ����
        //  PrefabUtility.InstantiatePrefab(Object����)
        if (GUILayout.Button("ʵ����Ԥ����"))
        {
            GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/TestObj.prefab");
            PrefabUtility.InstantiatePrefab(testObj);
        }
    }
}
