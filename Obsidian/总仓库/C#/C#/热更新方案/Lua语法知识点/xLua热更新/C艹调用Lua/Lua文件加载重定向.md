[Lua文件加载重定向](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/CSCallLua/Lesson2_Loader.cs)

require方法会先到env.AddLoader方法中寻找lua文件，找不到才会到Resources文件夹（默认）里寻找

```cs
private byte[] MyCustomLoader(ref string filePath)
{
    string path = Application.dataPath + "/Lua/" + filePath + ".lua";
    Debug.Log(path);

    if (File.Exists(path))
    {
        return File.ReadAllBytes(path);
    }
    else
    {
        Debug.Log("MyCustomLoader重定向失败，文件名为" + filePath);
    }

    string info = File.ReadAllText(path);
    return System.Text.Encoding.UTF8.GetBytes(info);
}
```

| 特性       | `File.ReadAllText` | `File.ReadAllBytes` |
| -------- | ------------------ | ------------------- |
| **返回类型** | `string`           | `byte[]`            |
| **用途**   | 文本文件读取             | 二进制文件读取             |
| **编码**   | 涉及编码               | 不涉及编码               |


