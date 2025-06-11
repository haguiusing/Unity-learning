![[TestInspectorMono.cs]]
![[TestInspectorMonoEditor.cs]] ^88a754

![[Lesson23_Inspector窗口拓展_基础知识.cs]]

### Inspector窗口自定义显示指什么
可以自定义某一个脚本在Inspector窗口的相关显示。

### SerializedObject和SerializedProperty的作用
SerializedObject 和 SerializedProperty 主要用于在 Unity 编辑器中操作和修改序列化对象的属性。它们通常在自定义编辑器中使用，以创建更灵活、可定制的属性面板。

我们只需要记住简单的规则：
- SerializedObject 代表脚本(组件)对象。
- SerializedProperty 代表脚本（组件）对象中的属性。

SerializedObject官方文档: [https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedObject.html](https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedObject.html)
SerializedProperty官方文档: [https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedProperty.html](https://docs.unity.cn/cn/2022.1/ScriptReference/SerializedProperty.html)

### 自定义脚本在Inspector窗口中显示的内容

#### 声明测试脚本和测试编辑器脚本
- 单独为某一个脚本实现一个自定义脚本，并且脚本需要继承Editor。一般该脚本命名为自定义脚本名 + Editor。
- 声明测试脚本
```cs
public class TestInspectorMono : MonoBehaviour
{
    // 攻击力
    public int atk;

    // 防御力
    public float def;

    // 敌对目标对象依附的Gameobject
    public GameObject obj;
}
```

- 声明要对测试脚本自定义显示到编辑器脚本
```cs
public class TestInspectorMonoEditor : Editor
{
}
```

#### 编辑器脚本加特性
在编辑器脚本前加上如下特性。  
命名空间：UnityEditor。  
特性名：CustomEditor(想要自定义脚本类名的Type)。
```cs
using UnityEditor;

// 通过这个特性，我们就可以为TestInspectorMono脚本自定义Inspector窗口中的显示了
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
}
```

#### 编辑器脚本声明测试脚本对应变量并获取
- 声明对应SerializedProperty序列化属性对象。主要通过它和自定义脚本中的成员进行关联。可以利用继承Editor后的成员serializedObject中的FindProperty(“成员变量名”)方法关联对应成员。
- 比如：
    - SerializedProperty mySerializedProperty;
    - mySerializedProperty = serializedObject.FindProperty(“自定义脚本中的成员名”);
- 一般在OnEnable函数中初始化。
```cs
using UnityEditor;

// 通过这个特性，我们就可以为TestInspectorMono脚本自定义Inspector窗口中的显示了
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
    private SerializedProperty atk;
    private SerializedProperty def;
    private SerializedProperty obj;

    private void OnEnable()
    {
        // 这样就得到与测试脚本对应的字段 注意传入的字符串自定义脚本中的成员名一致
        atk = serializedObject.FindProperty("atk");
        def = serializedObject.FindProperty("def");
        obj = serializedObject.FindProperty("obj");
    }
}
```

#### 重写OnInspectorGUI函数
- 重写OnInspectorGUI函数。该函数控制了Inspector窗口中显示的内容。只需要在其中重写内容便可以自定义窗口。注意：其中的逻辑需要包裹在这两句代码之间：
```cs
// 更新序列化对象的表示形式
serializedObject.Update();
// 之间应用属性修改
serializedObject.ApplyModifiedProperties();
```

- 未更改编辑器脚本前：  
    ![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/23.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/1.png)
    
- 重写OnInspectorGUI并声明自定义显示对象
```cs
using UnityEditor;

// 通过这个特性，我们就可以为TestInspectorMono脚本自定义Inspector窗口中的显示了
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
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
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
```

- 更改编辑器脚本后：  
    ![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/23.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/2.png)

#### 获取脚本对象
- Editor中的target成员变量 得到的是当前正在被自定义编辑器检视的组件对象
```cs
using UnityEditor;

// 通过这个特性，我们就可以为TestInspectorMono脚本自定义Inspector窗口中的显示了
[CustomEditor(typeof(TestInspectorMono))]
public class TestInspectorMonoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ...
        if (foldOut)
        {
             ...
            if (GUILayout.Button("打印当前target对象"))
            {
                Debug.Log("组件类型" + target.GetType());
                Debug.Log("组件依附的游戏对象名" + target.name);
            }
        }
        ...
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/23.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/3.png)
### 总结
我们为继承Editor的脚本添加[CustomEditor(typeof(想要自定义Inspector窗口的脚本))]特性，在该脚本中按照一定的规则进行编写，便可为Inspector窗口中的某个脚本自定义窗口布局。

### 请问如何才能完全自定义某个脚本在Inspector窗口中的显示？
#### 实现一个继承Editor的脚本
#### 为该脚本添加[CustomEditor(参数)]特性，传入的参数为你想要自定义Inspector窗口的脚本的Type
#### 通过serializedObject.FindProperty关联对应属性的SerializedProperty
#### 重写OnInspectorGUI函数，在该函数中利用GUI、EditorGUI相关API绘制对应控件，来修改SerializedProperty