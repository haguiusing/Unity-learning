![[PlayerPrefs数据管理类#^cc96f5]]
### 读取具体值的方法内，用是否继承的方法判断当前要读取的数据结构是不是List，是的话读取List的长度变量和读取List里面的具体值，会用到递归（假如List的泛型是自定义类的话还会有处理，后面再讲）
```cs
//通过反射 IsAssignableFrom方法判断 父子关系
//这相当于是判断 这个字段是不是IList的子类 是的话基本上就是List类了
else if (typeof(IList).IsAssignableFrom(fieldType))
{
    //得到List长度
    int listCount = PlayerPrefs.GetInt(keyName, 0);
    Log("读取ListCount" + keyName + "值 = " + (listCount));

    //实例化一个List对象 来进行赋值
    //用了反射中双A中 Activator进行快速实例化List对象
    IList list = Activator.CreateInstance(fieldType) as IList;

    //根据List长度 根据长度逐个添加元素
    for (int i = 0; i < listCount; i++)
    {
        //GetGenericArguments得到List中泛型的类型
        //比如List<int> 这个fieldType.GetGenericArguments()[0]就是int类型了
        //得到了这个类型后 在递归调用读取List里面具体的值
        list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
    }
    return list;
}
```