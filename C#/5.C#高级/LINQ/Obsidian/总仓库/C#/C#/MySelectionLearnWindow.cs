using System.Text;
using UnityEditor;
using UnityEngine;

public class MySelectionLearnWindow : EditorWindow
{
    [MenuItem("�༭����չ�̳�/MySelectionLearnWindow")]
    private static void OpenMySelectionLearnWindow()
    {
        MySelectionLearnWindow win = EditorWindow.GetWindow<MySelectionLearnWindow>("Selectionѧϰ����");
        win.Show();
    }

    #region Lesson20_Selection_���þ�̬��Ա

    private StringBuilder str = new StringBuilder("û��ѡ��");
    private StringBuilder str2 = new StringBuilder("û��ѡ��");
    private StringBuilder str3 = new StringBuilder("û��ѡ��");
    private StringBuilder str4 = new StringBuilder("û��ѡ��");

    #endregion

    #region Lesson21_Selection_���þ�̬����

    private Object obj;

    private void SelectionChanged()
    {
        Debug.Log("ѡ��Ķ���仯��");
    }

    private void OnEnable()
    {
        Selection.selectionChanged += SelectionChanged;
    }

    private void OnDestroy()
    {
        Selection.selectionChanged -= SelectionChanged;
    }

    #endregion

    private void OnGUI()
    {
        #region Lesson20_Selection_���þ�̬��Ա

        //1.��ǰѡ���Object
        if (GUILayout.Button("��ȡ��ǰѡ���Object������"))
        {
            if (Selection.activeObject != null)
            {
                str.Clear();
                str.Append(Selection.activeObject.name);

                if (Selection.activeObject is GameObject)
                    Debug.Log("������Ϸ����");
                else if (Selection.activeObject is Texture)
                    Debug.Log("����һ������");
                else if (Selection.activeObject is TextAsset)
                    Debug.Log("����һ���ı�");
                else
                    Debug.Log("�����������͵���Դ");
            }
            else
            {
                str.Clear();
                str.Append("û��ѡ��");
            }
        }

        EditorGUILayout.LabelField("��ǰѡ��Ķ���", str.ToString());


        //2.��ǰѡ���GameObject
        if (GUILayout.Button("��ȡ��ǰѡ���GameObject������"))
        {
            if (Selection.activeGameObject != null)
            {
                str2.Clear();
                str2.Append(Selection.activeGameObject.name);
            }
            else
            {
                str2.Clear();
                str2.Append("û��ѡ��");
            }
        }

        EditorGUILayout.LabelField("��ǰѡ��GameObject����", str2.ToString());

        //3.��ǰѡ���Transform
        if (GUILayout.Button("��ȡ��ǰѡ���Transform������"))
        {
            if (Selection.activeTransform != null)
            {
                str3.Clear();
                str3.Append(Selection.activeTransform.name);
                Selection.activeTransform.position = new Vector3(10, 10, 10);
            }
            else
            {
                str3.Clear();
                str3.Append("û��ѡ��");
            }
        }

        EditorGUILayout.LabelField("��ǰѡ��Transform����", str3.ToString());

        //4.��ǰѡ�������Object
        if (GUILayout.Button("��ȡ��ǰѡ�������Object������"))
        {
            if (Selection.count != 0)
            {
                str4.Clear();
                for (int i = 0; i < Selection.objects.Length; i++)
                {
                    str4.Append(Selection.objects[i].name + "||");
                }
            }
            else
            {
                str4.Clear();
                str4.Append("û��ѡ��");
            }
        }

        EditorGUILayout.LabelField("��ǰѡ�������Object����", str4.ToString());

        //5.��ǰѡ�������GameObject
        //Selection.gameObjects ��

        //6.��ǰѡ�������Transform
        //Selection.transforms ��

        #endregion

        #region Lesson21_Selection_���þ�̬����

        //�ж�ĳ�������Ƿ�ѡ��
        obj = EditorGUILayout.ObjectField("�����ж��Ƿ�ѡ�еĶ���", obj, typeof(GameObject), true);

        if (GUILayout.Button("�ж϶����Ƿ�ѡ��"))
        {
            if (Selection.Contains(obj))
                Debug.Log("�����б�ѡ��");
            else
                Debug.Log("����û�б�ѡ��");
        }

        //ɸѡ����
        if (GUILayout.Button("ɸѡ���ж���"))
        {
            Object[] objs = Selection.GetFiltered<Object>(SelectionMode.Assets | SelectionMode.DeepAssets);
            // Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.Assets | SelectionMode.DeepAssets);
            for (int i = 0; i < objs.Length; i++)
            {
                Debug.Log(objs[i].name);
            }
        }

        #endregion
    }
}
