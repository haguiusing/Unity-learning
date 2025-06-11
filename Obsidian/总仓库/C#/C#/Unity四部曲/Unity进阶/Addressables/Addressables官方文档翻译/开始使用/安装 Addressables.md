要在项目中安装 Addressables 包，请使用 Package Manager：
1. 打开 Package Manager（菜单：**Window > Package Manager**）。
2. 将包列表设置为显示 **Unity Registry** 中的包。
3. 在列表中选择 Addressables 包。
4. 单击 **Install**（位于 Package Manager 窗口的右下角）。

要在安装后在项目中设置 Addressables 系统，请打开 **Addressables Groups** 窗口并单击 **Create Addressables Settings**。

![](https://docs.unity3d.com/Packages/com.unity.addressables@2.3/manual/images/install-settings.png)  
_在项目中初始化 Addressables 系统之前_

当您运行“创建可寻址设置”命令时，可寻址系统会创建一个名为AddressableAssetsData的文件夹，其中存储设置文件和其他用于跟踪可寻址设置的资源。您应该将此文件夹中的文件添加到源代码管理系统中。请注意，当您更改Addressables配置时，Addressables可以创建其他文件。有关设置的更多信息，请参阅可寻址设置。

##### 注意

有关安装特定版本的 Addressables 的说明或有关管理项目中的包的一般信息，请参阅 [Packages](https://docs.unity3d.com/6000.0/Documentation/Manual/PackagesList.html)。