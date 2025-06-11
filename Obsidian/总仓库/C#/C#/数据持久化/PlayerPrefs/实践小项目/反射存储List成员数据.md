![[PlayerPrefs数据管理类#^cc96f5]]

### 存储具体值的方法内，用是否继承的方法判断当前要存储的数据结构是不是List，是的话存储List的长度变量和List存储里面的具体值，会用到递归（假如List的泛型是自定义类的话还会有处理，后面再讲）
```cs
//如何判断 泛型类的类型呢
//通过反射 IsAssignableFrom 方法判断父子关系
//这相当于是判断这个字段是不是 IList 的子类，是的话基本上就是 List 类了
else if (typeof(IList).IsAssignableFrom(fieldType))
{
    Debug.Log("存储List" + keyName);

    //父类装子类 把要存储的值对象的类型转成 IList 在遍历
    IList list = value as IList;

    //先存储 List 中元素的数量 
    PlayerPrefs.SetInt(keyName, list.Count);

    //声明一个 index 用做遍历 List 拼接 key 用
    int index = 0;
    foreach (object obj in list)
    {
        //遍历 List 递归存储具体的值
        //这里面存的已经是泛型的变量类型了 比如 List<int> 这个 obj 就是 int 类型的了
        //假如泛型的变量类型不是常规变量 会继续往下递归
        SaveValue(obj, keyName + index);
        ++index;
    }
}
```

### 给测试类的玩家信息类添加List的变量，用于测试
```cs
public class PlayerInfo
{
    public int age = 10;
    public string name = "未命名";
    public float height = 177.5f;
    public bool sex = true;
    
    public List<int> list = new List<int>() { 1, 2, 3, 4 };
}
```