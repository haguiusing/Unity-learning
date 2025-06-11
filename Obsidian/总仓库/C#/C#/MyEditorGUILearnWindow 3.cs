using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum E_TestType
{
    One = 1,
    Two = 2,
    Three = 4,
    One_and_Two = 1 | 2,
}

public class MyEditorGUILearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MyEditorGUILearnWindow")]
    private static void OpenMyEditorGUILearnWindow()
    {
        MyEditorGUILearnWindow win = EditorWindow.GetWindow<MyEditorGUILearnWindow>("EditorGUI֪ʶ���ⴰ��");
        //win.titleContent = new GUIContent("EditorGUI֪ʶ���ⴰ��");
        win.Show();
    }

    #region Lesson05_EditorGUI_�ı��㼶��ǩ��ɫ

    int layer;
    string tag;
    Color color;

    #endregion

    #region Lesson06_EditorGUI_ö������ѡ���°�ť

    E_TestType type;
    E_TestType type2;

    string[] strs = { "ѡ��123", "ѡ��234", "ѡ��345" };
    int[] ints = { 123, 234, 345 };
    int num = 0;


    #endregion

    private void OnGUI()
    {
        //�����еĿؼ���ػ��� �߼�������ص�����
        //EditorGUI��صĿؼ� ͬ��������Ҫ��OnGUI���н���ʵ�� ���ܱ���ʾ����

        #region Lesson05_EditorGUI_�ı��㼶��ǩ��ɫ

        //�ı��ؼ�
        EditorGUILayout.LabelField("�ı�����", "��������");
        EditorGUILayout.LabelField("�ı�����");

        //�㼶��ǩ�ؼ�
        // layer = EditorGUILayout.LayerField(layer);//�������ܱ��˿���������ѡ��ʲô�ġ�����Ӹ��ַ�����ʾ
        layer = EditorGUILayout.LayerField("�㼶ѡ��", layer);
        // tag = EditorGUILayout.TagField(tag);//�������ܱ��˿���������ѡ��ʲô�ġ�����Ӹ��ַ�����ʾ
        tag = EditorGUILayout.TagField("��ǩѡ��", tag);

        //��ɫ��ȡ�ؼ�
        color = EditorGUILayout.ColorField(new GUIContent("�Զ�����ɫ��ȡ"),
            color, true, true, true);

        #endregion

        #region Lesson06_EditorGUI_ö������ѡ���°�ť

        //ö��ѡ��
        type = (E_TestType)EditorGUILayout.EnumPopup("ö��ѡ��", type);

        type2 = (E_TestType)EditorGUILayout.EnumFlagsField("ö�ٶ�ѡ", type2);

        //����ѡ��ؼ�
        //����ֵ ��ʵ���������鵱�е�ĳһ��ֵ
        num = EditorGUILayout.IntPopup("������ѡ��", num, strs, ints);
        EditorGUILayout.LabelField(num.ToString());//��ʾ���ص�ֵ��ʲô

        //���¾���Ӧ�İ�ť
        if (EditorGUILayout.DropdownButton(new GUIContent("��ť������"), FocusType.Passive))
            Debug.Log("���¾���Ӧ");

        #endregion

    }
}
