using UnityEditor;
using UnityEngine;

//通过这个特性，我们就可以为TestInspectorMono脚本自定义Inspector窗口中的显示了
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
    private SerializedProperty atk;
    private SerializedProperty def;
    private SerializedProperty obj;

    private void OnEnable()
    {
        //这样就得到与测试脚本对应的字段
        atk = serializedObject.FindProperty("atk");
        def = serializedObject.FindProperty("def");
        obj = serializedObject.FindProperty("obj");
    }

    private bool foldOut;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();//注释掉父类调用后,Inspector窗口默认显示的atk def obj会消失

        serializedObject.Update();

        foldOut = EditorGUILayout.BeginFoldoutHeaderGroup(foldOut, "基础属性");
        if (foldOut)
        {
            GUILayout.Button("测试自定义Inspector窗口");
            EditorGUILayout.IntSlider(atk, 0, 100, "攻击力");
            def.floatValue = EditorGUILayout.FloatField("防御力", def.floatValue);
            EditorGUILayout.ObjectField(obj, new GUIContent("敌对对象"));

            if (GUILayout.Button("打印当前target对象"))
            {
                Debug.Log("组件类型" + target.GetType());
                Debug.Log("组件依附的游戏对象名" + target.name);
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
