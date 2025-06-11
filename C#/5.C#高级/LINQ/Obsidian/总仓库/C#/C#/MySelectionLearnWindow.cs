using System.Text;
using UnityEditor;
using UnityEngine;

public class MySelectionLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MySelectionLearnWindow")]
    private static void OpenMySelectionLearnWindow()
    {
        MySelectionLearnWindow win = EditorWindow.GetWindow<MySelectionLearnWindow>("Selection学习窗口");
        win.Show();
    }

    #region Lesson20_Selection_常用静态成员

    private StringBuilder str = new StringBuilder("没有选择");
    private StringBuilder str2 = new StringBuilder("没有选择");
    private StringBuilder str3 = new StringBuilder("没有选择");
    private StringBuilder str4 = new StringBuilder("没有选择");

    #endregion

    #region Lesson21_Selection_常用静态方法

    private Object obj;

    private void SelectionChanged()
    {
        Debug.Log("选择的对象变化了");
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
        #region Lesson20_Selection_常用静态成员

        //1.当前选择的Object
        if (GUILayout.Button("获取当前选择的Object的名字"))
        {
            if (Selection.activeObject != null)
            {
                str.Clear();
                str.Append(Selection.activeObject.name);

                if (Selection.activeObject is GameObject)
                    Debug.Log("它是游戏对象");
                else if (Selection.activeObject is Texture)
                    Debug.Log("它是一张纹理");
                else if (Selection.activeObject is TextAsset)
                    Debug.Log("它是一个文本");
                else
                    Debug.Log("它是其他类型的资源");
            }
            else
            {
                str.Clear();
                str.Append("没有选择");
            }
        }

        EditorGUILayout.LabelField("当前选择的对象", str.ToString());


        //2.当前选择的GameObject
        if (GUILayout.Button("获取当前选择的GameObject的名字"))
        {
            if (Selection.activeGameObject != null)
            {
                str2.Clear();
                str2.Append(Selection.activeGameObject.name);
            }
            else
            {
                str2.Clear();
                str2.Append("没有选择");
            }
        }

        EditorGUILayout.LabelField("当前选择GameObject对象", str2.ToString());

        //3.当前选择的Transform
        if (GUILayout.Button("获取当前选择的Transform的名字"))
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
                str3.Append("没有选择");
            }
        }

        EditorGUILayout.LabelField("当前选择Transform对象", str3.ToString());

        //4.当前选择的所有Object
        if (GUILayout.Button("获取当前选择的所有Object的名字"))
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
                str4.Append("没有选择");
            }
        }

        EditorGUILayout.LabelField("当前选择的所有Object对象", str4.ToString());

        //5.当前选择的所有GameObject
        //Selection.gameObjects 略

        //6.当前选择的所有Transform
        //Selection.transforms 略

        #endregion

        #region Lesson21_Selection_常用静态方法

        //判断某个对象是否被选中
        obj = EditorGUILayout.ObjectField("用于判断是否被选中的对象", obj, typeof(GameObject), true);

        if (GUILayout.Button("判断对象是否被选中"))
        {
            if (Selection.Contains(obj))
                Debug.Log("对象有被选中");
            else
                Debug.Log("对象没有被选中");
        }

        //筛选对象
        if (GUILayout.Button("筛选所有对象"))
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
