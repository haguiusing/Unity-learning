[D:\Obsidian Unity\Unity\HotUpdate\Assets\Scripts\ABUpdateMgr.cs](file:///d%3A/Obsidian%20Unity/Unity/HotUpdate/Assets/Scripts/ABUpdateMgr.cs)

![[Pasted image 20250602203526.png]]

### **6. 加载本地资源对比文件**
```csharp
public void GetLocalABCompareFileInfo(UnityAction<bool> overCallBack)
```
- **功能**：加载本地的资源对比文件。
- **实现**：
  - 优先从 `Application.persistentDataPath` 加载对比文件。
  - 如果不存在，则从 `Application.streamingAssetsPath` 加载默认资源。
  - 使用 `UnityWebRequest` 加载文件内容并解析。
### **7. 下载 AB 包**
```csharp
public async void DownLoadABFile(UnityAction<bool> overCallBack, UnityAction<string> updatePro)
```
- **功能**：下载 `downLoadList` 中的 AB 包。
- **实现**：
  - 遍历 `downLoadList`，逐个下载 AB 包。
  - 使用 `FtpWebRequest` 从 FTP 服务器下载文件。
  - 如果下载失败，会尝试重新下载最多 5 次。
  - 下载完成后，将成功下载的 AB 包从 `downLoadList` 中移除。
### **8. 下载文件**
```csharp
private bool DownLoadFile(string fileName, string localPath)
```
- **功能**：下载单个文件。
- **实现**：
  - 使用 `FtpWebRequest` 连接到 FTP 服务器并请求下载文件。
  - 将下载的文件内容写入本地路径。
  - 如果下载成功，返回 `true`；否则返回 `false`。