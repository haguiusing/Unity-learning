![[Inspector窗口拓展基础知识#^88a754]]

![[Lesson24_Inspector窗口拓展_数组和List.cs]]

### 数组、List属性在Inspector窗口显示 基础方式
主要知识点：
- EditorGUILayout.PropertyField(SerializedProperty对象, 标题)
- 该API会按照属性类型自己去处理控件绘制的逻辑。
#### 在自定义脚本添加数组List相关变量
```cs
public string[] strs;
public int[] ints;
public GameObject[] gameObjects;

public List<GameObject> listObjs;
```

#### 在编辑器脚本获得后绘制
```cs
private SerializedProperty strs;
private SerializedProperty ints;
private SerializedProperty gameObjects;

private SerializedProperty listObjs;

private void OnEnable()
{
    // 默认得到的数组和List容量为空
    strs = serializedObject.FindProperty("strs");
    ints = serializedObject.FindProperty("ints");
    gameObjects = serializedObject.FindProperty("gameObjects");
    listObjs = serializedObject.FindProperty("listObjs");
}

public override void OnInspectorGUI()
{
    serializedObject.Update();

    EditorGUILayout.PropertyField(strs, new GUIContent("字符串数组"));
    EditorGUILayout.PropertyField(ints, new GUIContent("整形数组"));
    EditorGUILayout.PropertyField(gameObjects, new GUIContent("游戏对象数组"));
    EditorGUILayout.PropertyField(listObjs, new GUIContent("游戏对象List"));

    serializedObject.ApplyModifiedProperties();
}
```

#### 注意：
因为数组和List自带折叠，放到我们自定义的折叠代码中会报错。
```
//以下代码会报错
arrayAndListFoldOut = EditorGUILayout.BeginFoldoutHeaderGroup(arrayAndListFoldOut, "数组和List属性");
if (arrayAndListFoldOut)
{
    EditorGUILayout.PropertyField(strs, new GUIContent("字符串数组"));
    EditorGUILayout.PropertyField(ints, new GUIContent("整形数组"));
    EditorGUILayout.PropertyField(gameObjects, new GUIContent("游戏对象数组"));
    EditorGUILayout.PropertyField(listObjs, new GUIContent("游戏对象List"));
}
```

#### 代码效果
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/24.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E6%95%B0%E7%BB%84%E5%92%8CList/1.png)

### 数组、List属性在Inspector窗口显示 自定义方式
如果我们不想要Unity默认的绘制方式去显示数组、List相关内容，我们也可以完全自定义布局方式。

主要知识点：
- 利用SerializedProperty中数组相关的API来完成自定义
    1. arraySize 获取数组或List容量
    2. InsertArrayElementAtIndex(索引) 为数组在指定索引插入默认元素（容量会变化）
    3. DeleteArrayElementAtIndex(索引) 为数组在指定索引删除元素（容量会变化）
    4. GetArrayElementAtIndex(索引) 获取数组中指定索引位置的 SerializedProperty 对象
#### 自定义List显示，可以放入折叠代码中。输入容量更新List长度。每次初始化根据List长度得到容量，否则每次一开始都是0。当容量更新是判断是否要删除或补充新的元素
```cs
private SerializedProperty listObjs;

private int count;

private bool arrayAndListFoldOut;

private void OnEnable()
{
    // 默认得到的数组和List容量为空
    listObjs = serializedObject.FindProperty("listObjs");

    // 初始化当前容量 否则 每次一开始都是0
    count = listObjs.arraySize;
}


public override void OnInspectorGUI()
{
    // EditorGUILayout.PropertyField(listObjs, new GUIContent("游戏对象List"));

    arrayAndListFoldOut = EditorGUILayout.BeginFoldoutHeaderGroup(arrayAndListFoldOut, "数组和List属性");
    if (arrayAndListFoldOut)
    {
        // 容量设置
        count = EditorGUILayout.IntField("List容量", count);

        // 是否要缩减 移除尾部的内容
        // 从后往前去移除 避免移除不干净
        // 当容量变少时 才会走这的逻辑
        for (int i = listObjs.arraySize - 1; i >= count; i--)
            listObjs.DeleteArrayElementAtIndex(i);

        // 根据容量绘制需要设置的每一个索引位置的对象
        for (int i = 0; i < count; i++)
        {
            // 去判断如果数组或者LIst容量不够 去通过插入的形式去扩容
            if (listObjs.arraySize <= i)
                listObjs.InsertArrayElementAtIndex(i);

            SerializedProperty indexPro = listObjs.GetArrayElementAtIndex(i);
            EditorGUILayout.ObjectField(indexPro, new GUIContent($"索引{i}"));
        }
    }

    EditorGUILayout.EndFoldoutHeaderGroup();
}
```
#### 代码效果
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/24.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E6%95%B0%E7%BB%84%E5%92%8CList/2.png)
