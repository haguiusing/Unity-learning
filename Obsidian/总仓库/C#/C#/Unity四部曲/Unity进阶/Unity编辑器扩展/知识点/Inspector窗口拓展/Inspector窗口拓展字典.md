![[Inspector窗口拓展基础知识#^88a754]]

![[Lesson25_Inspector窗口拓展_自定义数据 1.cs]]

### 知识回顾 SerizlizeField特性
在字段前添加可以让私有字段被序列化（能够在Unity的Inspector窗口被看到）。

### 如何在Inspector窗口编辑字典成员
Unity默认是不支持Dictionary在Inspector窗口被显示的，我们只有利用两个List（或数组）成员来间接设置Dictionary。

### ISerializationCallbackReceiver接口
- 该接口是Unity提供的用于序列化和反序列化时执行自定义逻辑的接口。实现该接口的类能够在对象被序列化到磁盘或从磁盘反序列化时执行一些额外代码。
    
- 接口中函数：
    - OnBeforeSerialize: 在对象被序列化之前调用
    - OnAfterDeserialize: 在对象从磁盘反序列化后调用
- 由于我们需要用两个List存储Dictionary的具体值，相当于字典中的真正内容是存储在两个List中的，所以我们需要在OnBeforeSerialize序列化之前将Dictionary里的数据存入List中进行序列化，在OnAfterDeserialize反序列化之后将List中反序列化出来的数据存储到Dictionary中。
    
- 在自定义脚本中继承ISerializationCallbackReceiver接口，声明字典和两个序列化的List（存储键值对），在序列化前和反序列化后分别存储读取字典的键值对。

```cs
public class TestInspectorMono : MonoBehaviour, ISerializationCallbackReceiver
{
    // 定义字典
    public Dictionary<int, string> myDic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };

    // 序列化字段，用于保存字典的键
    [SerializeField] private List<int> keys = new List<int>();
    // 序列化字段，用于保存字典的值
    [SerializeField] private List<string> values = new List<string>();

    // 反序列化后的回调函数
    public void OnAfterDeserialize()
    {
        // 清空字典
        myDic.Clear();
        // 遍历键列表和值列表，添加到字典中
        for (int i = 0; i < keys.Count; i++)
        {
            if (!myDic.ContainsKey(keys[i]))
                myDic.Add(keys[i], values[i]);
            else
                // 如果字典中已存在相同的键，发出警告
                Debug.LogWarning("字典Dictionary容器中不允许有相同的键");
        }
    }

    // 序列化前的回调函数
    public void OnBeforeSerialize()
    {
        // 清空键列表和值列表
        keys.Clear();
        values.Clear();
        // 遍历字典，将键和值分别添加到对应的列表中
        foreach (var item in myDic)
        {
            keys.Add(item.Key);
            values.Add(item.Value);
        }
    }
}
```

### 利用两个List在Inspector窗口中自定义Dictionary显示

由于我们在Inspector窗口中显示的信息的数据来源是List，因此我们只需要利用List在Inspector窗口中自定义显示即可。

#### 编辑器脚本中声明属性得到两个List，声明字典长度初始化赋值，写字典缩减扩容逻辑。
```cs
private SerializedProperty keys; // 保存字典键的序列化属性
private SerializedProperty values; // 保存字典值的序列化属性

private int dicCount; // 字典容量

private void OnEnable()
{
    // 查找字典键和值的序列化属性
    keys = serializedObject.FindProperty("keys");
    values = serializedObject.FindProperty("values");

    // 获取字典当前容量
    dicCount = keys.arraySize;
}

public override void OnInspectorGUI()
{
    // 更新序列化对象
    serializedObject.Update();

    // 显示字典容量的字段
    dicCount = EditorGUILayout.IntField("字典容量", dicCount);

    // 当容量减少时，删除多余的键值对
    for (int i = keys.arraySize - 1; i >= dicCount; i--)
    {
        keys.DeleteArrayElementAtIndex(i);
        values.DeleteArrayElementAtIndex(i);
    }

    // 遍历字典
    for (int i = 0; i < dicCount; i++)
    {
        // 如果容量不够，扩容
        if (keys.arraySize <= i)
        {
            keys.InsertArrayElementAtIndex(i);
            values.InsertArrayElementAtIndex(i);
        }

        // 获取当前键值对的序列化属性
        SerializedProperty indexKey = keys.GetArrayElementAtIndex(i);
        SerializedProperty indexValue = values.GetArrayElementAtIndex(i);

        // 显示键值对的编辑界面
        EditorGUILayout.BeginHorizontal();
        indexKey.intValue = EditorGUILayout.IntField("字典的键", indexKey.intValue);
        indexValue.stringValue = EditorGUILayout.TextField("字典的值", indexValue.stringValue);
        EditorGUILayout.EndHorizontal();
    }

    // 应用修改
    serializedObject.ApplyModifiedProperties();
}
```

#### 运行结果
![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E5%AD%97%E5%85%B8/1.png)

#### 在自定义脚本游戏运行开始时打印字典值
能正常打印说明数据存储到字典成功
```cs
private void Start()
{
    foreach (var item in myDic)
    {
        print($"Dic:{item.Key} - {item.Value}");
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/26.Inspector%E7%AA%97%E5%8F%A3%E6%8B%93%E5%B1%95-%E5%AD%97%E5%85%B8/2.png)

### 总结
由于Unity中不支持在Inspector窗口直接使用Dictionary，因此我们可以利用两个List（或数组）来间接的表达Dictionary成员。