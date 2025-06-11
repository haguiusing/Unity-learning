![[Inspector窗口拓展基础知识#^88a754]]

![[Lesson25_Inspector窗口拓展_自定义数据.cs]]

### 自定义属性 在Inspector窗口显示 基础方式
主要知识点：
```cs
EditorGUILayout.PropertyField(SerializedProperty对象, 标题);
```

该API会按照属性类型自己去处理控件绘制的逻辑。

#### 声明自定义数据类,需要序列化特性
```cs
using System;

[Serializable]
public class TestCustomClass
{
    public int i;
    public float f;
}
```

#### 自定义脚本中声明自定义数据类变量
```cs
public TestCustomClass myCustom;
```

#### 编辑器脚本中使用Unity自带的显示方式
```cs
private SerializedProperty myCustom;

private void OnEnable()
{
    myCustom = serializedObject.FindProperty("myCustom");
}

public override void OnInspectorGUI()
{
    serializedObject.Update();

    EditorGUILayout.PropertyField(myCustom, new GUIContent("我的自定义属性"));

    serializedObject.ApplyModifiedProperties();
}
```

#### 代码效果
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/25.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E8%87%AA%E5%AE%9A%E4%B9%89%E6%95%B0%E6%8D%AE/1.png)

### 自定义属性 在Inspector窗口显示 自定义方式
如果我们不想要Unity默认的绘制方式去显示自定义数据结构类相关内容，我们也可以完全自定义布局方式。主要知识点：
1. `SerializedProperty.FindPropertyRelative(属性)`
2. `serializedObject.FindProperty(属性.子属性)`

#### 自定义显示数据结构类中的变量
```cs
private SerializedProperty myCustom;

private SerializedProperty myCustomI;
private SerializedProperty myCustomF;

private void OnEnable()
{   
    myCustom = serializedObject.FindProperty("myCustom");
    
    // 以下两种方式二选其一
    // myCustomI = myCustom.FindPropertyRelative("i");
    // myCustomF = myCustom.FindPropertyRelative("f");
    myCustomI = serializedObject.FindProperty("myCustom.i");
    myCustomF = serializedObject.FindProperty("myCustom.f");
}

public override void OnInspectorGUI()
{
    serializedObject.Update();

    EditorGUILayout.PropertyField(myCustom, new GUIContent("我的自定义属性"));

    myCustomI.intValue = EditorGUILayout.IntField("自定义属性中的I", myCustomI.intValue);
    myCustomF.floatValue = EditorGUILayout.FloatField("自定义属性中的F", myCustomF.floatValue);
    
    
    serializedObject.ApplyModifiedProperties();
}
```
#### 代码效果
两个变量指向的是同一份内存，改动其中一个会实时同步  
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/25.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E8%87%AA%E5%AE%9A%E4%B9%89%E6%95%B0%E6%8D%AE/2.png)

