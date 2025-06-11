![[Lesson2 1.cs]]
![[Lesson2_Exercises 1.cs]]

![[MrTang2 1.json]]
### LitJson是什么
LitJson 是一个第三方库，用于处理Json的序列化和反序列化。它是C#编写的，体积小、速度快、易于使用。可以很容易地嵌入到我们的代码中，只需要将LitJson代码拷贝到工程中即可。

### 获取LitJson
#### 前往LitJson官网 [https://litjson.net/](https://litjson.net/)
![[Pasted image 20250605133338.png]]

#### 通过官网前往GitHub获取最新版本代码
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/05.Json%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.CSharp%E6%93%8D%E4%BD%9CJson-LitJson/2.png)
![[Pasted image 20250605133357.png]]

#### 只要代码 其他图片什么的都可以删掉
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/05.Json%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.CSharp%E6%93%8D%E4%BD%9CJson-LitJson/4.png)
![[Pasted image 20250605133411.png]]

### 使用LitJson进行序列化
#### 准备一个类和对象实例
##### 测试类
```cs
public class Student2
{
    public int age;
    public string name;

    public Student2() { }

    public Student2(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTao2
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    //public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student2 s1;
    public List<Student2> s2s;

    private int privateI = 1;
    protected int protectedI = 2;
}
```

##### 实例
```cs
MrTao2 t = new MrTao2();
t.name = "韬老狮";
t.age = 18;
t.sex = true;
t.testF = 1.4f;
t.testD = 1.4;

t.ids = new int[] { 1, 2, 3, 4 };
t.ids2 = new List<int>() { 1, 2, 3 };
//t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

t.s1 = null;//new Student(1, "小红");
t.s2s = new List<Student2>() { new Student2(2, "小明"), new Student2(3, "小强") };
```
#### JsonMapper.ToJson方法 序列化对象
```cs
//JsonMapper类中的ToJson方法 序列化对象
//JsonMapper.ToJson(对象)
string jsonStr = JsonMapper.ToJson(t);
print(Application.persistentDataPath);
File.WriteAllText(Application.persistentDataPath + "/MrTao2.json", jsonStr);
```

#### LitJson序列化时注意事项
- 相对JsonUtlity不需要加特性。
- 不能序列化私有变量。
- 支持字典类型，字典的键 建议都是字符串，因为Json的特点 Json中的键会加上双引号。
- 需要引用LitJson命名空间。
- LitJson可以准确的保存null类型。

#### 查看序列化后的json文件
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/05.Json%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/5.CSharp%E6%93%8D%E4%BD%9CJson-LitJson/6.png)
```json
{"name":"\u97EC\u8001\u72EE","age":18,"sex":true,"testF":1.4,"testD":1.4,"ids":[1,2,3,4],"ids2":[1,2,3],"dic2":{"1":"123","2":"234"},"s1":null,"s2s":[{"age":2,"name":"\u5C0F\u660E"},{"age":3,"name":"\u5C0F\u5F3A"}]}
```

### 使用LitJson反序列化
读取对应路径下文件中的Json字符串
```cs
jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTao2.json");
```

#### JsonMapper.ToObject方法 反序列化对象
```cs
//JsonMapper类中的ToObject方法 反序列化对象
//JsonMapper.ToObject(字符串)
//JsonData是LitJson提供的类对象 
JsonData data = JsonMapper.ToObject(jsonStr);
//可以用键值对的形式去访问其中的内容
print(data["name"]);
print(data["age"]);
//通过泛型转换 更加的方便 建议使用这种方式
MrTao2 t2 = JsonMapper.ToObject<MrTao2>(jsonStr);
```

#### LitJson进行反序列化时注意事项
- 类结构需要无参构造函数，否则反序列化时报错。
- 字典虽然支持，但是键在使用为数值时会有问题，需要使用字符串类型。

### LitJson中的注意事项
LitJson可以直接读取数据集合
```cs
public class RoleInfo2
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

//读取数组或List
jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
RoleInfo2[] arr = JsonMapper.ToObject<RoleInfo2[]>(jsonStr);
List<RoleInfo2> list = JsonMapper.ToObject<List<RoleInfo2>>(jsonStr);

//读取键为string类型的字典
jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/Dic.json");
Dictionary<string, int> dicTest = JsonMapper.ToObject<Dictionary<string, int>>(jsonStr);
```

注意检测json文件最后一行会不会多了一个逗号
文本编码格式需要是UTF-8，否则无法加载
### 总结
- LitJson提供的序列化反序列化方法 JsonMapper.ToJson和ToObject<>
- LitJson无需加特性
- LitJson不支持私有变量
- LitJson支持字典序列化反序列化
- LitJson可以直接将数据反序列化为数据集合
- LitJson反序列化时 自定义类型需要无参构造
- Json文档编码格式必须是UTF-8