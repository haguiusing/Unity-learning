![[MyPrefabUtilityLearnWindow.cs]]

![[Lesson45_PrefabUtility.cs]]

### PrefabUtility公共类是什么
它是 Unity 编辑器中的一个公共类，提供了一些用于处理 Prefab（预制体或称预设体）的方法。主要功能包括实例化预制体、创建预制体、修改预制体等等。只要你有对预制体操作的相关需求，它可以在编辑器开发的任何地方对其进行使用。

### 创建自定义面板用于进行知识讲解
```cs
using UnityEditor;
using UnityEngine;

public class MyPrefabUtilityLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyPrefabUtilityLearnWindow")]
    private static void OpenMyPrefabUtilityLearnWindow()
    {
        MyPrefabUtilityLearnWindow win = EditorWindow.GetWindow<MyPrefabUtilityLearnWindow>("PrefabUtility知识学习");
        win.Show();
    }

    private void OnGUI()
    {
        
    }
}
```

### 常用API
#### 动态创建预设体
```cs
private void OnGUI()
{
    // 动态创建预设体 路径从Assets/...开始
    // PrefabUtility.SaveAsPrefabAsset(GameObject对象, 路径);
    if (GUILayout.Button("动态创建预设体"))
    {
        GameObject obj = new GameObject();//场景上也会出现预制体
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();
        PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Resources/TestObj.prefab");
        DestroyImmediate(obj);//不想场景上也出现预制体就立即删除
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/45.PrefabUtility/1.png)

#### 加载预制体对象（不能用于创建，一般用于修改，会把预设体加载到内存中）
```cs
private void OnGUI()
{
    // 加载预制体对象（不能用于创建，一般用于修改，会把预设体加载到内存中）
    // 路径从Assets/...开始
    // PrefabUtility.LoadPrefabContents(路径)
    // 释放加载的预设体对象
    // PrefabUtility.UnloadPrefabContents(GameObject对象)
    // 注意：这两个方法需要配对使用，加载了就要释放

    // 这里的加载 本质上其实已经把预设体进行了实例化了 只不过该实例化对象并不是在传统的Scene窗口中（是在一个看不见的独立的场景中）
    if (GUILayout.Button("加载预制体对象"))
    {
        // 加载 到内存中 不能用来实例化 一般加载出来是进行修改的  比如给预制体添加组件
        GameObject testObj = PrefabUtility.LoadPrefabContents("Assets/Resources/TestObj.prefab");
        testObj.AddComponent<MeshRenderer>();

        // 拓展：
        // 这种加载方式 是可以进行脚本移除 子对象创建的
        DestroyImmediate(testObj.GetComponent<MeshRenderer>());
        GameObject obj = new GameObject("新建子对象");
        obj.transform.parent = testObj.transform;

        // 覆盖了原先的预制体
        PrefabUtility.SaveAsPrefabAsset(testObj, "Assets/Resources/TestObj.prefab");
        // 释放 一定要配合使用
        PrefabUtility.UnloadPrefabContents(testObj);
    }

}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/45.PrefabUtility/2.png)

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/45.PrefabUtility/3.png)

#### 修改已有预设体
```cs
private void OnGUI()
{
    // 修改已有预设体 
    // PrefabUtility.SavePrefabAsset(预设体对象, out bool 是否保存成功);
    // 可以配合AssetDatabase.LoadAssetAtPath使用
    if (GUILayout.Button("修改已有预设体 "))
    {
        GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/TestObj.prefab");
        testObj.AddComponent<Camera>();
        // 这个方法不能存储实例化后的内容 只能存储对应的预设体对象
        PrefabUtility.SavePrefabAsset(testObj);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/45.PrefabUtility/4.png)
#### 实例化预设体
```cs
private void OnGUI()
{
    // 实例化预设体
    // PrefabUtility.InstantiatePrefab(Object对象)
    if (GUILayout.Button("实例化预设体"))
    {
        GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/TestObj.prefab");
        PrefabUtility.InstantiatePrefab(testObj);
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/45.PrefabUtility/5.png)

### 更多内容
官方文档：[PrefabUtility](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/PrefabUtility.html)