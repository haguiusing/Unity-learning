![[JsonMgr 1.cs]]

### Json数据管理类需要有一键存储和读取对应对象的方法
### 创建Json数据管理类，实现单例
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Json数据管理类 主要用于进行 Json的序列化存储到硬盘 和 反序列化从硬盘中读取到内存中
/// </summary>
public class JsonDataMgr
{
    private static JsonDataMgr instance = new JsonDataMgr();
    public static JsonDataMgr Instance => instance;

    private JsonDataMgr() { }
}
```

