![[Pasted image 20250417182304.png]]
### Texture Compression
项目中纹理的压缩方式。
Dont override：不会覆盖开发者在项目中，对某些特定纹理的压缩方式，比如说：
![[Pasted image 20250417195327.png]]
说明：某个图片太大了，足足有10MB，小明希望在安卓平台对该图片进行特殊处理，让他小一点。于是它改了该图片的分辨率、格式和质量。如果打包的时候，这些设置不生效，小明岂不是白工作了？所以，在打包时，选择Dont override，那么图片的设置就会被保留下来。
![[Pasted image 20250417192432.png]]
### **ETC2 fallback**
对于不支持ETC2压缩方式的安卓设备，Unity应该用何种策略在内存中加载他们。
- 32-bit：最高质量的图片，这意味着需要更多的内存空间；
- 16-bit：低质量图片，可能会丢失一些颜色信息，但这意味着更少的内存空间占用；
- 32-bit ,half resolution：32比特半分辨率，是32-bit的降级，节约了75%的内存空间，保证了颜色信息，但可能会变得模糊~

### **Export Project**
 如果你勾选了它，就会导出一个安卓工程，而不是一个apk；
- 为什么要安卓工程而不是apk？
    - 有些情况下（_比如Unity的安卓开发、接入SDK、直连手机调试等_）需要的是一个安卓工程，而不是一个apk。此时，你只需要用**Android Studio**打开Unity导出的安卓工程，就可以进行你需要的操作了~  
        ![](https://i-blog.csdnimg.cn/blog_migrate/67c68ad6059419c144b3d808c112e637.png)

### Symlink Sources
必须勾选了Export Project选项，它才能被你勾选；
非常好用的一个选项，可以把你的Unity工程和导出的安卓工程的Java和Kotlin源文件关联起来，同步修改；
什么意思呢？上一个选项教你如何导出安卓工程了嘛，但是你导出了安卓工程，其实就和你的Unity没有什么关系了，你修改安卓工程，Unity里面的文件不会改变，说白了就是白改；
但是！！只要你勾选了这个选项，然后再导出安卓工程，你在安卓工程里面修改的Java和Kotlin文件，诶？Unity里面的文件也同步更改了，神奇不？方便不？好用不？(❁´◡\`❁)

### **Build App Bundle(Google Play)**
- 国内开发者别看了，勾选它打出来的是aab不是apk，说白了是上谷歌应用商店用的，国内可不兴这玩意啊。

### **Create symbols.zip**
- 在打包的同时，导出[符号表](https://blog.csdn.net/u013716859/article/details/126386140)。
    - 符号表：符号表是内存地址与函数名、文件名、行号的映射表；一般用于翻译app崩溃日志时的一些内存地址。

### **Run Device**
决定游戏运行在哪个设备上；
- 如果你点击的只是Build，那么这个选项不会有任何效果；
- 如果你点击的是Build And Run，那么Unity会在打包结束后自动在你选定的设备上运行游戏；
- **举个例子**：你把小米手机连到电脑上，那么在列表里，选中小米，点击Build And Run，那么小米会自动安装游戏，并开始运行。  
    ![](https://i-blog.csdnimg.cn/blog_migrate/4001ec808706b66c70688e99b3971a82.png)

### **Development Build**
你可以把该选项视为，打出来的包是给程序员用的，还是给用户用的；如果勾选，就说明这个包是给程序员调试游戏用的，会附加一些功能，来方便我们调试游戏。  
![](https://i-blog.csdnimg.cn/blog_migrate/580ad7c76057eccaa4e885013d05672f.png)

**说明**：红框中的几个选项可以视为是一体的，只有勾选了Development Build，下面的几个才能被勾选哦~
#### **Autoconnect Profiler** 
勾选后，手机连电脑，且手机安装了你的游戏时，可以使用Unity的性能分析工具，更优雅的调试你的游戏，嗯，非常优雅~  
![](https://i-blog.csdnimg.cn/blog_migrate/5030874114bf2e8b959185ad4a514bb6.png)
#### **Deep Profiling**
和上一个类似，但是！！会返回更加详细的数据给分析面板，让你可以细化到每个函数的调用所消耗的性能，这可能导致你的游戏变卡哦~

#### **Script Debugging**
是否允许app对于你的代码进行调试。白话就是，允许你在手机上，打断点来复现bug，去查哪里有问题。毕竟有很多恶心的bug，只在手机上出现，却不在Unity上出现。

感兴趣的童鞋：https://docs.unity.cn/cn/current/Manual/android-debugging-on-an-android-device.html

### **Scripts Only Build**
 是否仅对脚本进行重新编译和构建。意思是，只对脚本层面的变化进行处理，但是项目中的其他资源都不会被处理。**（没用过，存疑）**

### Compression Method
在打包时，Unity使用哪种方式来压缩你的资源。一共三个选项：
- Default：默认使用Zip压缩方式，虽然体积小，但是解压缩比较慢，会影响游戏性能哦~
- LZ4：相比Zip，LZ4的压缩率更低，但是解压缩效率很高，会很明显的提升游戏性能~
- LZ4HC：是LZ4的高压缩版本，会加长打包时间，但可以缩小包体+提升游戏性能~

