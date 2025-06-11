![[MyEditorApplicationLearnWindow.cs]]

![[Lesson46_EditorApplication.cs]]

### EditorApplication公共类是用来干什么的
它是 Unity 编辑器中的一个公共类，主要提供了一些和编辑器本身相关的功能，比如编辑器事件监听（播放、暂停等）、生命周期判断（是否运行中、暂停中、编译中）、编辑器进入播放模式、退出播放模式等等功能。

### 创建自定义面板用于进行知识讲解
```
public class MyEditorApplicationLearnWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/MyEditorApplicationLearnWindow")]
    private static void OpenMyEditorApplicationLearnWindow()
    {
        MyEditorApplicationLearnWindow win =
            EditorWindow.GetWindow<MyEditorApplicationLearnWindow>("EditorApplication知识学习");
        win.Show();
    }
}
```

### 常用API
#### 监听编辑器事件
- `EditorApplication.update`：每帧更新事件，可以用于在编辑器中执行一些逻辑。
- `EditorApplication.hierarchyChanged`：层级视图变化事件，当场景中的对象发生变化时触发。
- `EditorApplication.projectChanged`：项目变化事件，当项目中的资源发生变化时触发。
- `EditorApplication.playModeStateChanged`：编辑器播放状态变化时触发。
- `EditorApplication.pauseStateChanged`：编辑器暂停状态变化时触发。
```cs
private void OnEnable()
{
    EditorApplication.update += MyUpdate;
}

private void OnDestroy()
{
    EditorApplication.update -= MyUpdate;
}

void MyUpdate()
{
    // Debug.Log("更新");  

    // 管理编辑器生命周期相关
    if (EditorApplication.isPlaying)
    {
        Debug.Log("处于运行播放状态");
    }
}
```

#### 获取Unity应用程序路径相关
- `EditorApplication.applicationContentsPath`：Unity安装目录Data路径。
- `EditorApplication.applicationPath`：Unity安装目录可执行程序路径。
```cs
private void OnGUI()
{
    if (GUILayout.Button("打印Unity安装路径"))
    {
        Debug.Log(EditorApplication.applicationContentsPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Data
        Debug.Log(EditorApplication.applicationPath);//D:/Software/Unity/UnityEditor/2022.3.17f1c1/Editor/Unity.exe
    }

    // 常用方法
    if (GUILayout.Button("进入播放模式"))
    {
        EditorApplication.EnterPlaymode();
    }
    if (GUILayout.Button("退出播放模式"))
    {
        EditorApplication.ExitPlaymode();
    }
}
```

#### 更多内容
官方文档：
- [EditorApplication](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/EditorApplication.html)
- [EditorSceneManager](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/SceneManagement.EditorSceneManager.html)

