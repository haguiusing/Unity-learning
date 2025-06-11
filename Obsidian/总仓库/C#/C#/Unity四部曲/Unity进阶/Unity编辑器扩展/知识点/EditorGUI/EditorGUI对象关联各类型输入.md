![[EditorGUI是什么#^a82694]]
![[Lesson07_EditorGUI_对象关联各类型输入.cs]]

### 对象关联控件
对象变量 = EditorGUILayout.ObjectField(对象变量, typeof(对象类型), 是否允许关联场景上对象资源) as 对象类型;
```cs
GameObject gameObj;

private void OnGUI()
{
    //对象关联
    gameObj = EditorGUILayout.ObjectField("关联资源对象", gameObj, typeof(GameObject), false) as GameObject;
}
```

![](https://linwentao785293209.github.io/images/%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/Unity/%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95/01.%E5%8E%9F%E7%94%9F%E7%BC%96%E8%BE%91%E5%99%A8%E6%8B%93%E5%B1%95%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/7.EditorGUI-%E5%AF%B9%E8%B1%A1%E5%85%B3%E8%81%94%E5%90%84%E7%B1%BB%E5%9E%8B%E8%BE%93%E5%85%A5/1.png)

### 各类型输入控件
int变量 = EditorGUILayout.IntField(“Int输入框”, int变量);  
long变量 = EditorGUILayout.LongField(“long输入框”, long变量);  
float变量 = EditorGUILayout.FloatField(“Float 输入：”, float变量);  
double变量 = EditorGUILayout.DoubleField(“double 输入：”, double变量);

string变量 = EditorGUILayout.TextField(“Text输入：”, string变量);  
vector2变量 = EditorGUILayout.Vector2Field(“Vec2输入： “, vector2变量);  
vector3变量 = EditorGUILayout.Vector3Field(“Vec3输入： “, vector3变量);  
vector4变量 = EditorGUILayout.Vector4Field(“Vec4输入： “, vector4变量);  
rect变量 = EditorGUILayout.RectField(“rect输入： “, rect变量);  
bounds变量 = EditorGUILayout.BoundsField(“Bounds输入： “, bounds变量);  
boundsInt变量 = EditorGUILayout.BoundsIntField(“Bounds输入： “, boundsInt变量);

注意：EditorGUILayout中还有一些Delayed开头的输入控件  
他们和普通输入控件最主要的区别是：在用户按 Enter 键或将焦点从字段移开之前，返回值不会更改

```cs
int i;
int i2;
float f;
double d;
long l;

string str;
Vector2 vec2;
Vector3 vec3;
Vector4 vec4;

Rect rect;
Bounds bounds;
BoundsInt boundsInt;

private void OnGUI()
{
    //各类型输入
    i = EditorGUILayout.IntField("Int输入框", i);
    EditorGUILayout.LabelField(i.ToString());
    l = EditorGUILayout.LongField("long输入框", l);
    f = EditorGUILayout.FloatField("Float 输入：", f);
    d = EditorGUILayout.DoubleField("double 输入：", d);

    str = EditorGUILayout.TextField("Text输入：", str);
    vec2 = EditorGUILayout.Vector2Field("Vec2输入： ", vec2);
    vec3 = EditorGUILayout.Vector3Field("Vec3输入： ", vec3);
    vec4 = EditorGUILayout.Vector4Field("Vec4输入： ", vec4);

    rect = EditorGUILayout.RectField("rect输入： ", rect);
    bounds = EditorGUILayout.BoundsField("Bounds输入： ", bounds);
    boundsInt = EditorGUILayout.BoundsIntField("Bounds输入： ", boundsInt);

    //注意：EditorGUILayout中还有一些Delayed开头的输入控件
    //     他们和普通输入控件最主要的区别是：在用户按 Enter 键或将焦点从字段移开之前，返回值不会更改
    i2 = EditorGUILayout.DelayedIntField("Int输入框", i2);
    EditorGUILayout.LabelField(i2.ToString());
}
```

![[Pasted image 20250608171903.png]]

