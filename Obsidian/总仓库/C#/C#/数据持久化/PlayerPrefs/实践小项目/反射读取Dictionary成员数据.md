![[PlayerPrefs数据管理类#^cc96f5]]
### 读取具体值的方法内，用是否继承的方法判断当前要读取的数据结构是不是Dictionary，是的话读取Dictionary的长度变量和读取Dictionary里面的键值对，会用到递归
```cs
//通过反射 IsAssignableFrom方法判断 父子关系
//这相当于是判断 这个字段是不是IDictionary的子类 是的话基本上就是Dictionary类了
else if (typeof(IDictionary).IsAssignableFrom(fieldType))
{
    //得到字典的长度
    int dictionaryCount = PlayerPrefs.GetInt(keyName, 0);
    Log("读取DictionaryCount" + keyName + "值 = " + (dictionaryCount));

    //实例化一个字典对象 用父类装子类
    //用了反射中双A中 Activator进行快速实例化Dictionary对象
    IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;

    //GetGenericArguments得到Dictionary中泛型的类型数组 0是key 1是value
    Type[] kvType = fieldType.GetGenericArguments();

    //根据Dictionary长度 根据长度逐个添加键值对
    for (int i = 0; i < dictionaryCount; i++)
    {
        dic.Add(LoadValue(kvType[0], keyName + "_key_" + i),
                 LoadValue(kvType[1], keyName + "_value_" + i));
    }
    return dic;
}
```