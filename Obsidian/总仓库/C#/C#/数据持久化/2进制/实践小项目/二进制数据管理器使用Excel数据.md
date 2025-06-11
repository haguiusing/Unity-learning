![[二进制数据管理器#^66d90b]]

导入二进制基础知识中的二进制数据管理器
```cs
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// 二进制数据管理器
/// </summary>
public class BinaryDataMgr
{
    private static BinaryDataMgr instance = new BinaryDataMgr();
    public static BinaryDataMgr Instance => instance;

    private BinaryDataMgr()
    {
    }

    /// <summary>
    /// 数据存储路径
    /// </summary>
    private static string SAVE_PATH = Application.persistentDataPath + "/Data/";

    /// <summary>
    /// 存储类对象数据
    /// </summary>
    /// <param name="obj">要保存的对象</param>
    /// <param name="fileName">文件名</param>
    public void Save(object obj, string fileName)
    {
        // 先判断路径文件夹是否存在，如果不存在则创建
        if (!Directory.Exists(SAVE_PATH))
            Directory.CreateDirectory(SAVE_PATH);

        // 使用 FileStream 创建一个文件流，并指定打开或创建文件的方式
        using (FileStream fs = new FileStream(SAVE_PATH + fileName + ".tao", FileMode.OpenOrCreate, FileAccess.Write))
        {
            // 创建 BinaryFormatter 对象用于序列化数据
            BinaryFormatter bf = new BinaryFormatter();

            // 将对象 obj 序列化到文件流中
            bf.Serialize(fs, obj);

            // 关闭文件流
            fs.Close();
        }
    }

    /// <summary>
    /// 从二进制数据文件中读取并转换为指定类型的对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="fileName">文件名</param>
    /// <returns>读取到的对象</returns>
    public T Load<T>(string fileName) where T : class
    {
        // 如果文件不存在，则直接返回指定类型对象的默认值
        if (!File.Exists(SAVE_PATH + fileName + ".tao"))
            return default(T);

        T obj;
        // 使用 FileStream 打开文件流，并指定打开文件的方式为只读
        using (FileStream fs = File.Open(SAVE_PATH + fileName + ".tao", FileMode.Open, FileAccess.Read))
        {
            // 创建 BinaryFormatter 对象用于反序列化数据
            BinaryFormatter bf = new BinaryFormatter();

            // 将文件流中的数据反序列化为指定类型的对象
            obj = bf.Deserialize(fs) as T;

            // 关闭文件流
            fs.Close();
        }

        return obj;
    }
}
```

在BinaryDataMgr创建用于存储所有Excel表数据的容器字典
```cs
/// <summary>
/// 用于存储所有Excel表数据的容器
/// </summary>
private Dictionary<string, object> tableDic = new Dictionary<string, object>();
```

在BinaryDataMgr创建用于2进制数据存储位置路径，可以从ExcelTool剪切过来。在ExcelTool加个前缀引用解决报错。
```cs
/// <summary>
/// 2进制数据存储位置路径
/// </summary>
public static string DATA_BINARY_PATH = Application.streamingAssetsPath + "/Binary/";
```

在BinaryDataMgr中，创建加载Excel表的2进制数据到内存中函数，要传入泛型参数分别为容器类类名和数据结构类类名使用FileStream打开Excel表对应的二进制文件，以只读方式打开，并使用using语句确保文件流正确关闭。
创建一个字节数组bytes，长度为文件流的长度，然后将文件流中的数据读取到bytes数组中。
关闭文件流。声明一个变量index，表示当前读取的字节数。
通过BitConverter.ToInt32方法从bytes数组中读取一个int类型的值取名count，表示需要读取多少行数据，并将index增加4（int类型占用4个字节）。
通过BitConverter.ToInt32方法从bytes数组中读取一个int类型的值，表示主键名字的长度，并将index增加4。
根据主键名字的长度和index，使用Encoding.UTF8.GetString方法将bytes数组中的数据转换为字符串形式的主键名字，并将index增加主键名字的长度。
获取泛型参数T所代表的容器类的Type。
使用反射创建泛型参数T所代表的容器类的对象。
获取泛型参数K所代表的数据结构类的Type。
使用反射获取泛型参数K所代表的数据结构类的所有字段信息。
遍历从0到count-1的循环，表示一共要读取count行的数据。
使用反射创建泛型参数K所代表的数据结构类的对象。
遍历数据结构类的所有字段信息。
根据字段类型的不同，使用相应的BitConverter.ToXXX方法从bytes数组中读取值，并将index增加对应的字节数。
将读取到的值赋给数据结构类的对应字段。
获取容器对象中的字典字段dataDic，并通过反射获取其中的Add方法。
通过反射获取数据结构类对象中指定主键字段的值。
调用Add方法，将主键值和数据结构类对象作为参数，向字典中添加数据。
将读取完的表格存储到tableDic中，以容器类名作为Key，容器对象作为值。
关闭文件流。
```cs
/// <summary>
/// 加载Excel表的2进制数据到内存中 
/// </summary>
/// <typeparam name="T">容器类名</typeparam>
/// <typeparam name="K">数据结构类类名</typeparam>
public void LoadTable<T,K>()
{
    //读取 对应路径下 excel表对应的2进制文件 来进行解析
    using (FileStream fs = File.Open(DATA_BINARY_PATH + typeof(K).Name + ".tao", FileMode.Open, FileAccess.Read))
    {
        //把所有的文件流数据存到直接数组综合
        byte[] bytes = new byte[fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();
        
        //标识 用于记录当前读取了多少字节了
        int index = 0;
        
        //读取一个要读多少行数据
        int count = BitConverter.ToInt32(bytes, index);
        //读了一个int 序号标识要加四个字节
        index += 4;
        
        //读取主键的名字
        //想读取主键的长度
        int keyNameLength = BitConverter.ToInt32(bytes, index);
        //读了一个int 序号标识要加四个字节
        index += 4;
        //根据主键的长度在读取主键名字
        string keyName = Encoding.UTF8.GetString(bytes, index, keyNameLength);
        //序号标识要加上主键的长度
        index += keyNameLength;
        
        //创建容器类对象
        //得到容器类的Type
        Type contaninerType = typeof(T);
        //用反射方法根据类创建容器对象
        object contaninerObj = Activator.CreateInstance(contaninerType);
        
        //得到数据结构类的Type
        Type classType = typeof(K);
        //通过反射 得到数据结构类 所有字段的信息
        FieldInfo[] infos = classType.GetFields();
        
        //读取每一行的信息
        for (int i = 0; i < count; i++)
        {
            //实例化一个数据结构类 对象
            object dataObj = Activator.CreateInstance(classType);
            
            //遍历所有字段信息 
            foreach (FieldInfo info in infos)
            {
                if( info.FieldType == typeof(int) )
                {
                    //相当于就是把2进制数据转为int 然后赋值给了实例化一个数据结构类的对象的对应的字段
                    info.SetValue(dataObj, BitConverter.ToInt32(bytes, index));
                    index += 4;
                }
                else if (info.FieldType == typeof(float))
                {
                    info.SetValue(dataObj, BitConverter.ToSingle(bytes, index));
                    index += 4;
                }
                else if (info.FieldType == typeof(bool))
                {
                    info.SetValue(dataObj, BitConverter.ToBoolean(bytes, index));
                    index += 1;
                }
                else if (info.FieldType == typeof(string))
                {
                    //读取字符串字节数组的长度
                    int length = BitConverter.ToInt32(bytes, index);
                    index += 4;
                    //根据字符串长度在读字符串
                    info.SetValue(dataObj, Encoding.UTF8.GetString(bytes, index, length));
                    index += length;
                }
            }
            
            //读取完一行的数据了 应该把这个数据添加到容器对象中
            
            //得到容器对象中的 字典对象这个字段
            object dicObject = contaninerType.GetField("dataDic").GetValue(contaninerObj);
            //通过字典对象得到其中的 Add方法
            MethodInfo mInfo = dicObject.GetType().GetMethod("Add");
            //得到数据结构类对象中 指定主键字段的值 先得到数据结构类的 在得到数据结构类的主键 在得到主键的值
            object keyValue = classType.GetField(keyName).GetValue(dataObj);
            //调用Add方法 传入字典对象 和字典的key还有具体要存储的一条数据对象
            mInfo.Invoke(dicObject, new object[] { keyValue, dataObj });
        }
        
        //把读取完的表记录下来 传入容器名作为Key 容器对象做为值
        tableDic.Add(typeof(T).Name, contaninerObj);
        
        fs.Close();
    }
}
```

在BinaryDataMgr可以创建初始化方法初始化数据，比如加载塔数据，也可以不写在这里
```cs
public void InitData()
{
    BinaryDataMgr.Instance.LoadTable<TowerInfoContainer, TowerInfo>();
}
```

在BinaryDataMgr创建得到一张表的信息函数。传入容器类名作为泛型，返回表信息出去。判断表字典中有没有包含表名，包含则转换为指定类型返回，不包含直接返回null
```cs
/// <summary>
/// 得到一张表的信息
/// </summary>
/// <typeparam name="T">容器类名</typeparam>
/// <returns>返回指定类型的表信息</returns>
public T GetTable<T>() where T:class
{
    // 获取指定类型的表名
    string tableName = typeof(T).Name;
    
    // 检查表字典中是否包含指定表名的项
    if (tableDic.ContainsKey(tableName))
        // 如果包含，则将该项转换为指定类型，并返回
        return tableDic[tableName] as T;
    
    // 如果不包含，则返回null
    return null;
}
```

### 可以在测试类中测试数据能不能拿到表数据
```cs
public class TestTest : MonoBehaviour
{
    void Start()
    {
        //BinaryDataMgr.Instance.InitData();
        BinaryDataMgr.Instance.LoadTable<TowerInfoContainer, TowerInfo>();
        TowerInfoContainer data = BinaryDataMgr.Instance.GetTable<TowerInfoContainer>();
        print(data.dataDic[5].name);
    }
}
```

![[Pasted image 20250605205026.png]]