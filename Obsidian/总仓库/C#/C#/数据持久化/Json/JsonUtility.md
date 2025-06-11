![[Lesson1 1.cs]]
![[Lesson1_Exercises 1.cs]]

![[MrTang.json]]
![[Test.json]]
### JsonUtlity是什么
JsonUtlity 是Unity自带的用于解析Json的公共类。

JsonUtlity可以:
1. 将内存中对象序列化为Json格式的字符串。
2. 将Json字符串反序列化为类对象。

### 必备知识点—在文件中存读字符串
#### File.WriteAllText方法 
存储字符串到指定路径文件中
```cs
//File类中的WriteAllText方法 存储字符串到指定路径文件中
//第一个参数 填写的是 存储的路径
//第二个参数 填写的是 存储的字符串内容
//注意：第一个参数 必须是存在的文件路径 如果没有对应文件夹 会报错
File.WriteAllText(Application.persistentDataPath + "/Test.json", "林文韬存储的json文件");
print(Application.persistentDataPath);//C:/Users/78529/AppData/LocalLow/DefaultCompany/Json_Teach
```

#### File.ReadAllText方法 
在指定路径文件中读取字符串
```cs
//File类中的ReadAllText方法 在指定路径文件中读取字符串
string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
print(str);//林文韬存储的json文件
```

### 使用JsonUtlity进行序列化
序列化：把内存中的数据存储到硬盘上。为此，需要准备一个类和对象实例。

#### 准备一个类和对象实例
##### 测试类
```cs
[System.Serializable]
public class Student
{
    public int age;
    public string name;

    public Student(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTao
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student s1;
    public List<Student> s2s;

    [SerializeField]
    private int privateI = 1;
    [SerializeField]
    protected int protectedI = 2;
}
```

##### 实例
```cs
MrTao t = new MrTao();
t.name = "韬老狮";
t.age = 18;
t.sex = false;
t.testF = 1.4f;
t.testD = 1.4;

t.ids = new int[] { 1, 2, 3, 4 };
t.ids2 = new List<int>() { 1, 2, 3 };
t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

t.s1 = null;//new Student(1, "小红");
t.s2s = new List<Student>() { new Student(2, "小明"), new Student(3, "小强") };
```

#### JsonUtility.ToJson方法 序列化对象
```cs
//JsonUtility类中的ToJson方法 序列化对象
//Jsonutility提供了线程的方法 可以把类对象 序列化为 json字符串
//生成对象的公共字段的 JSON 表示形式。
//JsonUtility.ToJson(对象)
string jsonStr = JsonUtility.ToJson(t);
File.WriteAllText(Application.persistentDataPath + "/MrTao.json", jsonStr);
```

#### JsonUtlity序列化时注意事项
- float序列化时看起来会有一些误差。
- 自定义类需要加上序列化特性[System.Serializable]。
- 想要序列化私有变量，需要加上特性[SerializeField]。
- JsonUtility不支持字典。
- JsonUtlity存储null对象不会是null，而是默认值的数据。

#### 查看序列化后的json文件
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/05.Json%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/4.CSharp%E6%93%8D%E4%BD%9CJson-JsonUtility/1.png)
```json
{"name":"韬老狮","age":18,"sex":false,"testF":1.399999976158142,"testD":1.4,"ids":[1,2,3,4],"ids2":[1,2,3],"s1":{"age":0,"name":""},"s2s":[{"age":2,"name":"小明"},{"age":3,"name":"小强"}],"privateI":1,"protectedI":2}
```

### 使用JsonUtlity进行反序列化
反序列化：把硬盘上的数据读取到内存中。
```cs
//读取文件中的 Json字符串
jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTao.json");
```
#### JsonUtility.FromJson方法 反序列化对象
```cs
//JsonUtility类中的FromJson方法 反序列化对象
//通过 JSON 表示形式创建对象。
//JsonUtility.FromJson(字符串)
//使用Json字符串内容 转换成类对象
MrTao t2 = JsonUtility.FromJson(jsonStr, typeof(MrTao)) as MrTao;
MrTao t3 = JsonUtility.FromJson<MrTao>(jsonStr);
```

#### JsonUtlity反序列化时注意事项
如果Json中数据少了，读取到内存中类对象中时不会报错。

### JsonUtility注意事项
JsonUtlity无法直接读取数据集合，比如直接读取List或数组会报错。
```cs
[System.Serializable]
public class RoleInfo
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

//JsonUtlity无法直接读取数据集合 比如直接读取List或数组 会报错
string jsonStr1 = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
print(jsonStr1);
//List<RoleInfo> roleInfoList = JsonUtility.FromJson<List<RoleInfo>>(jsonStr1);//报错
```

用对象包裹一层List同时修改json文件也用对象包裹List就不会报错。
```cs
public class RoleData
{
    public List<RoleInfo> list;
}

string jsonStr2 = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo2.json");
print(jsonStr2);
RoleData data = JsonUtility.FromJson<RoleData>(jsonStr2);
```
文本编码格式需要是UTF-8，否则无法加载。如果修改了文件格式不是UTF-8，会报错。

### 总结
- 必备知识点——File存读字符串的方法ReadAllText和WriteAllText。
- JsonUtlity提供的序列化反序列化方法ToJson和FromJson。
- 自定义类需要加上序列化特性[System.Serializable]。
- 私有保护成员需要加上[SerializeField]。
- JsonUtlity不支持字典。
- JsonUtlity不能直接将数据反序列化为数据集合。
- Json文档编码格式必须是UTF-8。