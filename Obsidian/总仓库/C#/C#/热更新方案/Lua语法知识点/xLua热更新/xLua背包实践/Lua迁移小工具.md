[LuaCopyEditor](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Editor/LuaCopyEditor.cs)

![[Pasted image 20250601143845.png]]

`LuaCopyEditor.cs` 是一个 Unity 编辑器脚本，作用是把指定目录下的 `.lua` 文件复制到新目录，同时将文件扩展名改为 `.txt`，最后把这些新文件标记到名为 `lua` 的资源包中。下面详细介绍代码流程：

### 1. 命名空间引用
```csharp
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
```
引入所需命名空间，包含文件操作、集合操作以及 Unity 编辑器相关功能。

### 2. 类定义
```csharp
public class LuaCopyEditor : Editor
{
```
定义 `LuaCopyEditor` 类，继承自 `Editor`，表明这是一个 Unity 编辑器脚本。

### 3. 菜单方法
```csharp
    [MenuItem("XLua/自动生成txt后缀的Lua")]
    public static void CopyLuaToTxt()
    {
```
`[MenuItem]` 特性让该方法在 Unity 编辑器的菜单栏 `XLua` 下生成一个名为 `自动生成txt后缀的Lua` 的菜单项，点击该菜单项会执行 `CopyLuaToTxt` 方法。

### 4. 查找源目录下的 `.lua` 文件
```csharp
        string path = Application.dataPath + "/Lua/LuaPanel/";
        if (!Directory.Exists(path))
            return;
        string[] strs = Directory.GetFiles(path, "*.lua");
```
- 构建源目录路径，该路径为 `Assets/Lua/LuaPanel/`。
- 检查源目录是否存在，若不存在则结束方法。
- 使用 `Directory.GetFiles` 方法获取源目录下所有 `.lua` 文件的路径。

### 5. 准备目标目录
```csharp
        string newPath = Application.dataPath + "/LuaTxt/";
        if (!Directory.Exists(newPath))
            Directory.CreateDirectory(newPath);
        else
        {
            string[] oldFileStrs = Directory.GetFiles(newPath, "*.txt");
            for (int i = 0; i < oldFileStrs.Length; i++)
            {
                File.Delete(oldFileStrs[i]);
            }
        }
```
- 构建目标目录路径，即 `Assets/LuaTxt/`。
- 若目标目录不存在，则创建该目录。
- 若目标目录已存在，删除其中所有 `.txt` 文件，避免旧文件残留。

### 6. 复制文件
```csharp
        List<string> newFileNames = new List<string>();
        string fileName;
        for (int i = 0; i < strs.Length; ++i)
        {
            fileName = newPath + strs[i].Substring(strs[i].LastIndexOf("/") + 1) + ".txt";
            newFileNames.Add(fileName);
            File.Copy(strs[i], fileName);
        }
```
- 遍历源目录下所有 `.lua` 文件。
- 构建新文件路径，将文件名扩展名改为 `.txt`。
- 把 `.lua` 文件复制到目标目录，同时修改扩展名。

### 7. 刷新资源数据库
```csharp
        AssetDatabase.Refresh();
```
调用 `AssetDatabase.Refresh()` 方法刷新 Unity 资源数据库，确保新复制的文件被 Unity 识别。

### 8. 设置资源包名称
```csharp
        for (int i = 0; i < newFileNames.Count; i++)
        {
            AssetImporter importer = AssetImporter.GetAtPath(newFileNames[i].Substring(newFileNames[i].IndexOf("Assets")));
            if (importer != null)
                importer.assetBundleName = "lua";
        }
```
- 遍历所有新复制的文件。
- 获取文件的 `AssetImporter` 对象。
- 若 `AssetImporter` 对象不为空，将文件的资源包名称设置为 `lua`。