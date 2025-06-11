# [HideInInspector]  
![](https://i-blog.csdnimg.cn/blog_migrate/0bc0c245cfaa92a49665ad93636982fc.png)  
将公有的变量在Inspector面板上隐藏
```cs
[HideInInspector]public int value;
```

# [System.Serializable]
![[Pasted image 20241128155758.png]]
让其他类中的变量显示在Inspector面板上
```cs
using UnityEngine;
 
public class Test : MonoBehaviour
{
    public A a;
}
 
[System.Serializable]
public class A
{
    public int value;
}
```

# [SerializeField]  
![](https://i-blog.csdnimg.cn/blog_migrate/2d0a53b08606b13066a60ef662a06df0.png)  
序列化字段，可以将私有的变量在Inspector面板上显示，但此变量的访问级别还是私有的
```cs
[SerializeField]private int value;
```

# [Header("标题内容")]  
![](https://i-blog.csdnimg.cn/blog_migrate/cdecd45cc83d21b7c6c177278ccda904.png)  
给变量添加标题
```cs
[Header("变量")]public int value;
```

# [Space(间距数值)]  
![](https://i-blog.csdnimg.cn/blog_migrate/a9e5c810bc00f4fa50fb8c6cc2add249.png)  
给变量间添加间距
```cs
[Space(50)]public int value;
```

# [Tooltip("悬停内容")] 
![](https://i-blog.csdnimg.cn/blog_migrate/0b181fd20c502f50ea42169234bbe120.png)  
给变量添加悬停内容
```cs
[Tooltip("这是一个变量")]public int value;
```

# [Range(min,max)]  
![](https://i-blog.csdnimg.cn/blog_migrate/53dd394a17ea3662de0e80af3fd8ddf2.png)  
给int、float、double这种数字类型变量添加范围
```cs
[Range(0,10)]public int value;
```

# [Multiline(行数)]  
![](https://i-blog.csdnimg.cn/blog_migrate/969cc92c947220054e19730c3772e4c4.png)  
给[string](https://marketing.csdn.net/p/3127db09a98e0723b83b2914d9256174?pId=2782?utm_source=glcblog&spm=1001.2101.3001.7020)类型[变量设置](https://so.csdn.net/so/search?q=%E5%8F%98%E9%87%8F%E8%AE%BE%E7%BD%AE&spm=1001.2101.3001.7020)行数
```cs
[Multiline(5)]public string str;
```

# [TextArea]  
![](https://i-blog.csdnimg.cn/blog_migrate/f011992246293554f5dc520cd963012b.png)  
把string类型变量在Inspector面板的显示变成一个TextArea
```cs
[TextArea]public string str;
```

# [ColorUsage(是否可以设置透明度)]  
![](https://i-blog.csdnimg.cn/blog_migrate/a1ec9ef17262dbb70a1d3ac1767ed4c5.png)  
调用颜色选项框
```cs
[ColorUsage(true)]public Color c;
```

# [FormerlySerializedAs("原始的变量名")]
![[Pasted image 20241128160621.png]]
例如声明一个变量：public GameObject go1，然后给go1拖拽赋值，当将变量名go1改为go2时，引用会丢失。
可以添加一个FormerlySerializedAs的属性，使属性的参数与第一次声明变量时使用的名称一致，后期调整此变量名就不会出现引用丢失了
```cs
[FormerlySerializedAs("go1")]
public GameObject go1;
```

# [CreateAssetMenu("fileName="创建的文件名","menuName="层级/结构","order"=排序序号)]  
![](https://i-blog.csdnimg.cn/blog_migrate/fec40575543c4426028a7867d50b6bfa.png)  
![](https://i-blog.csdnimg.cn/blog_migrate/67b09d69c79a12db2eafffded6e4edbe.png)  
在Project面板下创建一个配置文件，方便进行数据的管理(只能给类添加这个属性)
继承ScriptableObject的类必须创建单独的脚本
```cs
using UnityEngine;
 
[CreateAssetMenu(fileName = "PlayerData", menuName = "创建配置文件/Player/创建玩家信息")]
public class Test : ScriptableObject
{
    [Header("速度")]
    public int speed;
}
```
例如现在有一个预制体EmenyPrefab，它身上挂载了一个mono的脚本，脚本中有一些数据Speed，HP，MP，当每次创建这个预制体时都需要拷贝一份原预制体脚本中的数据，但其实这些数据都是一样的，这就造成了很大的资源浪费，这时就应该考虑使用一个继承ScriptableObject的脚本去存数据，在预制体上的组件中定义一个指向ScriptableObject对象的引用去得到数据，这样就使原来的大量值拷贝变为了拷贝一个引用并存储一个引用
还可以使用下面两句话创建配置文件
```cs
PlayerData data = ScriptableObject.CreateInstance<PlayerData>();
AssetDatabase.CreateAsset(data, "Assets/Resources/玩家配置.asset");
```

# [MenuItem("层级/结构 [快捷键]",是否是验证函数,priority = 优先级)]  
## public MenuItem (string itemName, bool isValidateFunction, int priority);
## 参数
itemName：是指表示方式类似于路径名的菜单项。string 类型。用 ‘/’ 来分割路径
isValidateFunction：	如果 isValidateFunction 为 true，它将表示一个验证 函数，并在系统调用具有相同 itemName 的菜单函数之前进行调用。
priority：	菜单项显示的顺序。影响在面板上的出现顺序，默认为1000，值越小，出现在越上层的位置。
当一个菜单的优先级 - 它上一个菜单的优先级 >= 11，菜单之间还能看到分界线


![](https://i-blog.csdnimg.cn/blog_migrate/7d5e2d69fe9d4983cda5aa22f03d70a2.png)  
为工具栏提供自定义按钮
```cs
using UnityEditor;
using UnityEngine;
 
public class Test : EditorWindow
{    
    //%：ctrl/command  #：shift  &：alt _：纯按键
    [MenuItem("Tool/MyTest %w", priority = 1)]
    private static void MyTest()
    {
        Debug.Log("MyTest");
    }
 
    //此方法用于判断MenuItem的validate参数，参数代表此方法是否为验证方法
    //验证方法会先于点击运行
    [MenuItem("Tool/MyTestVerify", validate = true)]
    private static bool MyTestVerify()
    {
        GameObject[] gos = Selection.gameObjects;
        if (gos.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
```

# [Menu.SetChecked(层级/结构,bool)]
![](https://i-blog.csdnimg.cn/blog_migrate/f79d62ca1b1d1196cc08226de93f4367.png)
```cs
using UnityEngine;
using UnityEditor;
 
public class Test : MonoBehaviour
{
    [MenuItem("Tools/test")]
    static void TestEditor()
    {
        bool b = Menu.GetChecked("Tools/test");
        b = !b;
        Menu.SetChecked("Tools/test", b);
    }
}
```

# [AddComponentMenu(层级/结构)]  
![](https://i-blog.csdnimg.cn/blog_migrate/64505ebd264ac6642a8a0a6a640af1b0.png)  
将此脚本添加到组件栏中(只能给类添加这个属性)
```cs
[AddComponentMenu("Test/MyTest")]public class Test : MonoBehaviour{    }
```

# [RequireComponent(typeof(添加的组件))]
![[Pasted image 20241201162335.png]]
添加此脚本时如果没有Require的组件则自动添加(只能给类添加这个属性)
```cs
[RequireComponent(typeof(CanvasGroup))]
public class Test : MonoBehaviour
{
    
}
```

# [ContextMenu(“自定义的操作名”)]或[MenuItem("CONTEXT/脚本名/新增的按钮名")]
![[Pasted image 20241201162507.png]]
为Inspector面板的小齿轮下增加按钮(只能给方法添加这个属性)
```cs
//使用[ContextMenu(“自定义的操作名”)]
[ContextMenu("My Test")]
public void MyMethon()
{
    Debug.Log("这是我的测试方法");
}
 
//使用[MenuItem("CONTEXT/脚本名/新增的按钮名")]
//[MenuItem("CONTEXT/Test/My Test")]
//private static void MyMethon()
//{
//    Debug.Log("这是我的测试方法");
//}
```

# [MenuCommand]
使用[MenuItem("CONTEXT/脚本名/新增的按钮名")]时，方法参数中传入MenuCommand后右键相应的组件后会自动获取到当前点击的物体，可以方便地获取到当前组件中的属性
```cs
[MenuItem("CONTEXT/Rigidbody/Clear Mass")]
private static void MyMethon(MenuCommand cmd)
{
    Rigidbody rigi = cmd.context as Rigidbody;
    rigi.mass = 100;
}
```

# [ContextMenuItem(“操作名”, “执行的方法名”)]
![[Pasted image 20241201212128.png]]
为字段添加一个右键菜单，执行一个此类中的方法(只能给字段添加这个属性)
```cs
public class Test : MonoBehaviour
{
    [ContextMenuItem("Mytest", "MyMethon")]
    public int value;
 
    public void MyMethon()
    {
        Debug.Log("这是我的测试方法");
    }
}
```

# [HelpURL("url")]  
![](https://i-blog.csdnimg.cn/blog_migrate/43857707a9725bf7e9e2cb510b473ee4.png)  
点击书本按钮打开所定义的url网址(只能给类添加这个属性)
```cs
[HelpURL("http://baidu.com")]public class Test : MonoBehaviour{  }
```

# [DisallowMultipleComponent]  
![](https://i-blog.csdnimg.cn/blog_migrate/e7e0af91924af9b54420ff2d941f9c1b.png)  
使一个物体只能添加一个此脚本(只能给类添加这个属性)
```cs
[DisallowMultipleComponent]public class Test : MonoBehaviour{  }
```

# [ExecuteInEditMode]
让此脚本在Editor模式下也能执行Start、Update、OnGUI等方法(只能给类添加这个属性)
```cs
[ExecuteInEditMode]
public class Test : MonoBehaviour
{
    private void Awake()
    {
        print("ExecuteInEditMode");
    }
}
```

# [DidReloadScripts]
脚本编译完成后的回调
```cs
public class Test : MonoBehaviour
{
    [DidReloadScripts]
    static void ReloadScropts()
    {
          Debug.Log("DidReloadScripts");
    }
}
```

# [MonoPInvokeCallback(接收的代理类型)]
C#(托管代码)中注册方法可以从C++/C(非托管代码)调用
```cs
public class Test : MonoBehaviour
{
    internal delegate void TestCallBack(string eventName);
 
    [MonoPInvokeCallback(typeof(TestCallBack))]
    public static void OnCallBack(string eventName)
    {
        if (eventName == "complete")
        {
            Debug.Log("成功调用");
        }
    }
    
	[DllImport("YourCppLibrary")]
    private static extern void RegisterCallback(TestCallBack callback);

    [DllImport("YourCppLibrary")]
    private static extern void TriggerCallback(string eventName);

    void Start()
    {
        // 注册回调函数
        RegisterCallback(OnCallBack);

        // 触发回调函数
        TriggerCallback("complete");
    }
}
```

```cpp
// 引入包含MonoPInvokeCallback的头文件
#include <stdint.h>
#include <mono/jit/jit.h>
#include <mono/metadata/appdomain.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/object.h>
#include <mono/metadata/domain-forums.h>

typedef void (*TestCallBack)(const char*);

// 函数用于从C#触发回调
void TriggerCSharpCallback(const char* eventName)
{
    // Mono invocation context
    mono_thread_attach(mono_get_root_domain(), TRUE);

    // 获取C#中的委托类型
    MonoClass* delegateClass = mono_class_from_name(mono_get_corlib(), "UnityEngine", "MonoBehaviour");
    MonoClass* testCallBackClass = mono_class_from_name(mono_get_corlib(), "YourNamespace", "TestCallBack");

    // 创建委托实例
    MonoObject* delegateObject = mono_object_new(mono_domain_get(), testCallBackClass);
    mono_runtime_object_init(delegateObject);

    // 获取并设置委托的目标和方法
    MonoMethod* onCallBackMethod = mono_get_method("YourAssembly", "OnCallBack", "YourNamespace.Test");
    mono_runtime_delegate_bind((MonoDelegate*)delegateObject, testCallBackClass, mono_get_method("YourNamespace.Test::OnCallBack", testCallBackClass), NULL);

    // 调用C#中的回调函数
    MonoString* eventArg = mono_string_new(mono_domain_get(), eventName);
    mono_runtime_invoke(onCallBackMethod, NULL, &eventArg, NULL);
}

// 供外部调用的函数，用于注册回调
extern "C" __declspec(dllexport) void RegisterCallback(TestCallBack callback)
{
    // 存储回调函数
    static TestCallBack g_callback = nullptr;
    g_callback = callback;
}

// 触发回调的外部函数
extern "C" __declspec(dllexport) void TriggerCallback(const char* eventName)
{
    if (g_callback)
    {
        g_callback(eventName);
    }
}
```

# [DllImport(“DLL名称”)]
调用外部DLL的方法
[C#中DllImport用法和路径问题-CSDN博客](https://blog.csdn.net/weixin_40314351/article/details/127591606)
```cs
[DllImport(“MyDLL.dll")] //返回个int 类型 
public static extern int mySum (int a1,int b1);
```

``` c++
//DLL中申明
extern “C” __declspec(dllexport)  int WINAPI mySum(int a2,int b2)
{　//a2 b2不能改变a1 b1
  //a2=..
  //b2=...
  return a+b;
  }

//　参数传递　int 类型 

//DLL中申明
extern “C” __declspec(dllexport)  int WINAPI mySum(int *a2,int *b2)
{ 
   //可以改变 a1, b1 
   *a2=...  
 　*b2=...  
   return a+b; 　
}
```

# OnSerializing、OnSerialized、OnDeserializing、OnDeserialized
[【C#】详解C#序列化 - HDWK - 博客园](https://www.cnblogs.com/HDK2016/p/9562400.html)
只有通过二进制进行序列化和[反序列化](https://so.csdn.net/so/search?q=%E5%8F%8D%E5%BA%8F%E5%88%97%E5%8C%96&spm=1001.2101.3001.7020)时才能调用到上面的特性

### 特性和方法解释
- `[OnSerializing]`：当对象即将被序列化时调用。
- `OnSerializing(StreamingContext context)`：`OnSerializing` 特性标记的方法。`StreamingContext` 参数提供了关于序列化流的上下文信息。
- `[OnSerialized]`：当对象已经被序列化后调用。
- `OnSerialized(StreamingContext context)`：`OnSerialized` 特性标记的方法。
- `[OnDeserializing]`：当对象即将被反序列化时调用。
- `OnDeserializing(StreamingContext context)`：`OnDeserializing` 特性标记的方法。
- `[OnDeserialized]`：当对象已经被反序列化后调用。
- `OnDeserialized(StreamingContext context)`：`OnDeserialized` 特性标记的方法。

### 使用场景
这些特性通常用在需要在序列化和反序列化过程中执行特定逻辑的场景，例如：
- 在序列化前修改对象的状态。
- 在反序列化后初始化对象的特定成员。
- 记录序列化和反序列化的日志信息。
- 在序列化和反序列化过程中进行权限检查。

### 注意事项
- 这些特性仅在标记为 `[Serializable]` 的类中有效。
- 这些方法必须是非泛型的实例方法，并且不能有参数，除了 `StreamingContext`。
- `StreamingContext` 参数提供了关于序列化流的来源和目的的额外信息。
- 这些特性方法不会自动被调用，您需要使用 `ISerializable` 接口和 `FormatterServices` 类来序列化和反序列化对象。

### 示例代码
以下是如何序列化和反序列化 `People` 类的示例代码：
```cs
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class People : MonoBehaviour
{
    public int age;

    [OnSerializing]
    internal void OnSerializing(StreamingContext context)
    {
        Debug.Log("OnSerializing");
    }

    [OnSerialized]
    internal void OnSerialized(StreamingContext context)
    {
        Debug.Log("OnSerialized");
    }

    [OnDeserializing]
    internal void OnDeserializing(StreamingContext context)
    {
        Debug.Log("OnDeserializing");
    }

    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context)
    {
        Debug.Log("OnDeserialized");
    }
}

class Program
{
    static void Main(string[] args)
    {
        People person = new People { age = 25 };
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream("People.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            // 序列化
            formatter.Serialize(stream, person);
        }

        using (FileStream stream = new FileStream("People.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // 反序列化
            People deserializedPerson = (People)formatter.Deserialize(stream);
        }
    }
}
```