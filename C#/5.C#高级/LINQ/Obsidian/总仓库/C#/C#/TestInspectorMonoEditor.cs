using UnityEditor;
using UnityEngine;

//ͨ��������ԣ����ǾͿ���ΪTestInspectorMono�ű��Զ���Inspector�����е���ʾ��
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
    private SerializedProperty atk;
    private SerializedProperty def;
    private SerializedProperty obj;

    private void OnEnable()
    {
        //�����͵õ�����Խű���Ӧ���ֶ�
        atk = serializedObject.FindProperty("atk");
        def = serializedObject.FindProperty("def");
        obj = serializedObject.FindProperty("obj");
    }

    private bool foldOut;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();//ע�͵�������ú�,Inspector����Ĭ����ʾ��atk def obj����ʧ

        serializedObject.Update();

        foldOut = EditorGUILayout.BeginFoldoutHeaderGroup(foldOut, "��������");
        if (foldOut)
        {
            GUILayout.Button("�����Զ���Inspector����");
            EditorGUILayout.IntSlider(atk, 0, 100, "������");
            def.floatValue = EditorGUILayout.FloatField("������", def.floatValue);
            EditorGUILayout.ObjectField(obj, new GUIContent("�жԶ���"));

            if (GUILayout.Button("��ӡ��ǰtarget����"))
            {
                Debug.Log("�������" + target.GetType());
                Debug.Log("�����������Ϸ������" + target.name);
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
