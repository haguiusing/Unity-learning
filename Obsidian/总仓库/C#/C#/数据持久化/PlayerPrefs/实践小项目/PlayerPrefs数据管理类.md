PlayerPrefs数据管理类
![[PlayerPrefsDataMgr 2.cs]]![[PlayerPrefsTest.cs]] ^cc96f5
### 创建PlayerPrefs数据管理类，使用单例模式
```cs
/// <summary>
/// PlayerPrefs数据管理类 统一管理数据的存储和读取
/// </summary>
public class PlayerPrefsDataMgr
{
    //管理类用单例模式
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataMgr()
    {

    }
}
```

### 添加存储数据方法，并写出思路
```cs
/// <summary>
/// 存储数据
/// </summary>
/// <param name="data">数据对象</param>
/// <param name="keyName">数据对象的唯一key 自己控制</param>
public void SaveData(object data, string keyName)
{
    //就是要通过 Type 得到传入数据对象的所有的 字段
    //然后结合 PlayerPrefs来进行存储
}
```

### 添加读取数据方法，并写出思路
```cs
/// <summary>
/// 读取数据
/// </summary>
/// <param name="type">想要读取数据的 数据类型Type</param>
/// <param name="keyName">数据对象的唯一key 自己控制</param>
/// <returns></returns>
public object LoadData(Type type, string keyName)
{
    //不用object对象传入 而使用 Type传入
    //主要目的是节约一行代码（在外部）
    //假设现在你要 读取一个Player类型的数据 如果是传入object 你就必须在外部new一个对象传入
    //现在有Type的 你只用传入 一个Type typeof(Player) 然后我在内部动态创建一个对象给你返回出来
    //达到了 让你在外部 少写一行代码的作用

    //根据你传入的类型 和 keyName
    //依据你存储数据时  key的拼接规则 来进行数据的获取赋值 返回出去

    return null;
}
```

这样你就可以通过单例模式的 `PlayerPrefsDataMgr.Instance` 来访问和管理数据的存储和读取了。