**1.Inspector显示的可编辑内容就是脚本成员变量。**
**2.私有和保护无法显示编辑**
**3.让私有的和保护的也可以被显示。**
```
//加上强制序列化字段特性
//[SerializeField]
//所谓序列化就是把一个对象保存到一个文件或数据库字段中去
[SerializeField]
private int privateInt;
[SerializeField]
protected string protectedStr;
```
此时就可以被编辑了。

**4.公共的可以显示编辑**
**5.公共的也不让其显示编辑**
```
//在变量前加上特性
[HideInInspector]
```
这样即使是公共的也无法显示编辑了。

**6.大部分类型都能够显示编辑**
（一个脚本中只要有一个类继承MonoBehavior即可。
```
public int[] array;
public List<int> list;
public E_TestEnum type;
public GameObject gameObject;
```

字典不能在Inspector窗口显示，自定义类型也不能。

```
//字典
public Dictionary<int string> dic;
//自定义类型变量
public MyStruct myStruct;
public MyClass myClass;
```
7.让自定义类型可以被访问

```
//在申明自定义类型前加上序列特性
[System.Serializable]
public struct MyStruct{}
[System.Serializable]
public class MyClass{}
```
自定义类就可以被访问了，但是字典怎么样都不可以被访问。

**8.一些辅助特性**
 1 分组说明特性Header
```
//为成员分组
[Header(“基础属性")]
public int age;
public bool sex;
[Header("战斗属性")]
public int atk;
public int def;
```
在Inspector窗口上显示为
![[Pasted image 20240903180137.png]]
 2 悬停注释Tooltip
为变量添加说明
```
[Tooltip("说明内容")]
public inr miss;
```
这时候鼠标指在miss上面会出现“说明内容”，在Inspector窗口上显示为。
![[Pasted image 20240903181551.png]]

 3 间隔特性
让两个字段之间出现间隔
```
[Space()]
public int crit;
```
在Inspector窗口上显示为
![[Pasted image 20240903181641.png]]

 4 修饰数值的滑条范围Range
```
[Range(最小值，最大值)]
public float luck;
```
在Inspector窗口上显示为
![[Pasted image 20240903181727.png]]

 5 多行显示字符，默认不写参数显示3行
写的参数就是对应行，优点：可以清晰地查看字符串的内容。
```
[Multiline(4)]
public String tips;
```
在Inspector窗口上显示为
![[Pasted image 20240903181908.png]]

 6 滚动条显示字符串
默认不写参数就是超过3行显示滚动条
```
[TextArea(3,4)]
public string myLife;
//最多显示3行，超过4行就显示滚动条
```
在Inspector窗口上显示为
![[Pasted image 20240903182148.png]]

 7 为变量添加快捷方法ContextMenuItem
```
//参数1 显示按钮名

//参数2 方法名 不能有参数
[ContextMenuItem("重置钱","Test")]
public int money

//方法不能有参数和返回值
private void Test()
{
  money=999;
}
```
在Inspector窗口上显示为
![[Pasted image 20240903182433.png]]

 8 为方法添加特性能够在Inspector中执行
```
[ContextMenu("测试函数")]
```
这样在Inspector窗口脚本右上角三个点点击可以看到它，在Inspector窗口上显示为。
![[Pasted image 20240903182559.png]]

**9.注意**
 1 窗口中的变量关联对象就是对象的成员变量，运行时改变它们就是在改变成员变量；

 2 拖拽到GameObject对象后，再改变脚本中变量默认值，界面上不会发生改变；

 3 运行中修改信息不会被保存。
如果想要修改，运行时点击Copy Component,停止后点击Paste Component Values就可以发生改变了。
