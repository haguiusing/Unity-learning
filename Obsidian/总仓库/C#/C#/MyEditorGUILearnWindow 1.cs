using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    }
}
