![[PlayerPrefs数据管理类#^cc96f5]]

### 在存储具体值的方法内，用是否继承的方法判断当前要存储的数据结构是不是Dictionary，是的话存储Dictionary的长度变量和Dictionary存储里面的具体键值对，会用到递归（假如Dictionary的泛型是自定义类的话还会有处理，后面再讲）
```cs
//判断是不是 Dictionary 类型 通过 Dictionary 的父类 IDictionary 来判断 和 List 的判断类似
else if (typeof(IDictionary).IsAssignableFrom(fieldType))
{
    Debug.Log("存储Dictionary" + keyName);
    
    //父类装子类 把要存储的值对象的类型转成 IDictionary 在遍历
    IDictionary dic = value as IDictionary;
    
    //先存储 Dictionary 中元素的数量 
    PlayerPrefs.SetInt(keyName, dic.Count);
    
    //遍历存储 Dictionary 里面的具体值
    //声明一个 index 用做遍历 Dictionary 拼接 key 用
    int index = 0;
    foreach (object key in dic.Keys)
    {
        //遍历 Dictionary 递归存储具体的值
        //这里面存的已经是泛型的变量类型了 比如 Dictionary<int,string> 就分别存 int 类型和 string 类型的变量
        //假如泛型的变量类型不是常规变量 会继续往下递归
        SaveValue(key, keyName + "_key_" + index);
        SaveValue(dic[key], keyName + "_value_" + index);
        ++index;
    }
}
```

### 给测试类的玩家信息类添加Dictionary的变量，用于测试
```cs
public Dictionary<int, string> dic = new Dictionary<int, string>()
{
    { 1,"123"},
    { 2,"234"}
};
```