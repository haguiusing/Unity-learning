![[TestSceneMonoEditor.cs]]
![[TestSceneMonoWindow.cs]]
![[TestSceneMono 2.cs]] ^2f9fa2

![[Lesson27_Scene窗口拓展_Handles_Handles是什么及响应函数.cs]]

### Handles公共类的作用
Handles类提供了很多API，让我们可以在Scene窗口中绘制我们的自定义内容。它和GUI、EditorGUI类似，只不过它专门提供给Scene窗口使用。

想要在Scene窗口中显示自定义内容，我们需要在对应的响应函数中进行处理。

### Scene窗口更新响应函数
关键点：
前两个步骤和自定义Inspector窗口显示内容一致：
1. 单独为某一个脚本实现一个自定义脚本，并且脚本需要继承Editor，一般该脚本命名为自定义脚本名 + Editor。
2. 在该脚本前加上特性，命名空间：UnityEditor，特性名：CustomEditor(想要自定义脚本类名的Type)。
3. 在该脚本中实现void OnSceneGUI()方法，该方法会在我们选中挂载自定义脚本的对象时自动更新。注意：只有选中时才会执行，没有选中不执行。

#### 声明自定义脚本
```cs
public class TestSceneMono : MonoBehaviour
{

}
```

#### 声明继承Editor的编辑器脚本，加上特性并实现OnSceneGUI方法
```cs
[CustomEditor(typeof(TestSceneMono))]
public class TestSceneMonoEditor : Editor
{
    private void OnSceneGUI()
    {
        // 选中挂载TestSceneMono的对象会打印
        Debug.Log("Scene窗口拓展相关逻辑");
    }
}
```

### 自定义窗口中监听Scene窗口更新响应函数
可以在自定义窗口显示时  
监听更新事件：SceneView.duringSceneGui += 事件函数  
窗口隐藏或销毁时移除事件：SceneView.duringSceneGui -= 事件函数
```cs
using UnityEditor;
using UnityEngine;

public class TestSceneMonoWindow : EditorWindow
{
    [MenuItem("编辑器拓展教程/TestSceneMonoWindow")]
    private static void OpenTestSceneMonoWindow()
    {
        TestSceneMonoWindow win = EditorWindow.GetWindow<TestSceneMonoWindow>();
        win.Show();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += SceneUpdate;
    }

    private void OnDestroy()
    {
        SceneView.duringSceneGui -= SceneUpdate;
    }

    private void SceneUpdate(SceneView view)
    {
        // 当打开窗口且场景视图存在任何更新会打印
        Debug.Log("自定义窗口拓展Scene相关内容");
    }
}
```

### 总结
Scene窗口拓展功能主要是提供给自定义脚本和自定义窗口的。我们采用对应的规则进行处理，便可以在之后的教程中利用场景更新响应函数来自定义一些Scene窗口的显示内容。