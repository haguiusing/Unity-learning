![[Selection是什么#^f32bfc]]

![[Lesson21_Selection_常用静态方法.cs]]

### 判断某个对象是否被选中
Contains 判断某个对象是否被选中（多选中存在也算）
```cs
private Object obj;

private void OnGUI()
{
    // 判断某个对象是否被选中
    obj = EditorGUILayout.ObjectField("用于判断是否被选中的对象", obj, typeof(GameObject), true);

    if(GUILayout.Button("判断对象是否被选中"))
    {
        if (Selection.Contains(obj))
            Debug.Log("对象有被选中");
        else
            Debug.Log("对象没有被选中");
    }
}
```

![[Pasted image 20250608213300.png]]

![[Pasted image 20250608213310.png]]

![[Pasted image 20250608213313.png]]

### 筛选对象
从当前选择对象中，筛选出想要的内容  
Selection.GetFiltered(类型, 筛选模式)  
Selection.GetFiltered<类型>(筛选模式)

筛选模式：SelectionMode  
Unfiltered: 不过滤  
TopLevel: 只获取最上层对象，子对象不获取  
Deep: 父对象、子对象都获取  
ExcludePrefab: 排除预设体  
Editable: 只选择可编辑的对象  
OnlyUserModifiable: 仅用户可修改的内容  
Assets: 只返回资源文件夹下的内容  
DeepAssets: 如果存在子文件夹，其中的内容也获取  
如果要混用 位或 | 即可
```cs
private void OnGUI()
{
    // 筛选对象
    if(GUILayout.Button("筛选所有对象"))
    {
        Object[] objs = Selection.GetFiltered<Object>(SelectionMode.Assets | SelectionMode.DeepAssets);
        // Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.Assets | SelectionMode.DeepAssets);
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log(objs[i].name);
        }
    }
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/21.Selection-%E5%B8%B8%E7%94%A8%E9%9D%99%E6%80%81%E6%96%B9%E6%B3%95/4.png)
### 当选中变化时会调用的委托
Selection.selectionChanged += 函数;//选择的物体变化时调用
```cs
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
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/21.Selection-%E5%B8%B8%E7%94%A8%E9%9D%99%E6%80%81%E6%96%B9%E6%B3%95/5.png)

### 总结
Selection公共类主要是帮助我们获取到选择的对象的，我们可以利用它对选中对象进行一些处理。

Selection公共类更多API：  
[Unity Documentation](https://docs.unity.cn/cn/2022.1/ScriptReference/Selection.html)