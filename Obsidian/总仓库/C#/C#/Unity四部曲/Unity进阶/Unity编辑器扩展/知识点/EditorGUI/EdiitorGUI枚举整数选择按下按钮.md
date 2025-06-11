![[EditorGUI是什么#^a82694]]
![[Lesson06_EditorGUI_枚举整数选择按下按钮.cs]]

### 枚举选择控件
枚举选择
```cs
枚举变量 = (枚举类型)EditorGUILayout.EnumPopup("枚举选择", 枚举变量);
```

多选枚举  
（注意：多选枚举进行的是或运算，声明枚举时一定注意其中的赋值，并且一定要有多种情况的搭配值）
```cs
枚举变量 = (枚举类型)EditorGUILayout.EnumFlagsField("枚举多选", 枚举变量);
```

```cs
public enum E_TestType
{
    One = 1,
    Two = 2,
    Three = 4,
    One_and_Two = 1 | 2,
}

E_TestType type;
E_TestType type2;

private void OnGUI()
{
    // 枚举选择
    type = (E_TestType)EditorGUILayout.EnumPopup("枚举选择", type);

    type2 = (E_TestType)EditorGUILayout.EnumFlagsField("枚举多选", type2);
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/6.EditorGUI-%E6%9E%9A%E4%B8%BE%E6%95%B4%E6%95%B0%E9%80%89%E6%8B%A9%E6%8C%89%E4%B8%8B%E6%8C%89%E9%92%AE/1.png)

### 整数选择控件
```cs
int变量 = EditorGUILayout.IntPopup("整数单选框", int变量, 字符串数组, int数组);
```

```cs
string[] strs = { "选择123", "选择234", "选择345" };
int[] ints = { 123, 234, 345 };
int num = 0;

private void OnGUI()
{
    // 整数选择控件
    // 返回值其实是整数数组当中的某一个值
    num = EditorGUILayout.IntPopup("整数单选框", num, strs, ints);
    EditorGUILayout.LabelField(num.ToString()); // 显示返回的值是什么 
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/6.EditorGUI-%E6%9E%9A%E4%B8%BE%E6%95%B4%E6%95%B0%E9%80%89%E6%8B%A9%E6%8C%89%E4%B8%8B%E6%8C%89%E9%92%AE/2.png)

### 按下就触发的按钮控件
```cs
EditorGUILayout.DropdownButton(new GUIContent("按钮上文字"), FocusType.Passive)
```

FocusType枚举告诉UI系统能够获得键盘焦点，当用户按Tab键时在控件之间进行切换。
- Keyboard：该控件可接收键盘焦点。
- Passive：该控件不能接收键盘焦点。

```cs
private void OnGUI()
{
    // 按下就响应的按钮
    if (EditorGUILayout.DropdownButton(new GUIContent("按钮上文字"), FocusType.Passive))
        Debug.Log("按下就响应");
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/6.EditorGUI-%E6%9E%9A%E4%B8%BE%E6%95%B4%E6%95%B0%E9%80%89%E6%8B%A9%E6%8C%89%E4%B8%8B%E6%8C%89%E9%92%AE/3.png)

