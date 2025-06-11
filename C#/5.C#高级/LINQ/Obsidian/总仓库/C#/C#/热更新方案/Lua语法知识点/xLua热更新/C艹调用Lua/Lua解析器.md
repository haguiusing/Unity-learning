[Lua解析器](file:///D:/Obsidian%20Unity/Unity/%E7%83%AD%E6%9B%B4%E6%96%B0%E6%96%B9%E6%A1%88/Assets/Scripts/CSCallLua/Lesson1_LuaEnv.cs)

[XLua框架原理(一) - 知乎](https://zhuanlan.zhihu.com/p/441169478)

![[Pasted image 20250529224721.png]]

LuaEnv：Lua解析器 能够让我们在Unity中执行Lua

Lua脚本保存位置：Resources文件夹（默认）
格式：XXX.lua.txt  / bytes 等等

方法：
**DoString(init_xlua,"Init")**

# LuaEnv加载lua脚本的几种方式
LuaEnv.Dostring（）参数内为一个字符串，确切说是一个符合lua语法的字符串。在此写几种不同类型的加载方法。
## 1.最基本lua语言
```cs
LuaEnv env=new LuaEnv();

env.Dostring(@"hellow world")
 
env.DoString(@"
mytable={name='xiaoming'}
function mytable:new()
local t={}
setmetatable(t,{__index=self})
return t
end
newTb=mytable:new()
print(newTb.name)
");
```
## 2.加载lua文件执行
这里注意的一点是lua文件不要以.lua结尾，而以.lua.txt结尾，因为最终读取的，实际上是字符串，而U3D中通过Resource加载的，有TextAsset类型可以读取txt文件，但lua文件并没有专门的类去存储。所以文件名示例为：hellow.lua.txt文件，此处放到Resources目录去方便去读取。

这里介绍三种读取文件的方式。

2.1通过Resources.Load加载，这种方法不需要再加.txt，反而加上会报错。
```cs
	TextAsset text = Resources.Load<TextAsset>("helloworld.lua");
	 //TextAsset text = Resources.Load<TextAsset>("helloworld.lua.txt");
```
 
 通过AssetDatabase.LoadAssetAtPath加载。这里必须加后缀，不加会报错。
```cs
	string st = "Assets/Resources/helloworld.lua.txt";
	TextAsset text = AssetDatabase.LoadAssetAtPath<TextAsset>(st);
```
 
2.2通过Loader加载，实际上是上述方法的封装。使用require关键字，不需要加入.lua.txt
```cs
 env.DoString("require 'helloworld'");
```

2.3通过自定义Loader加载
实际上2.2加载的方式，就是对于放在Resource目录下的Lua文件加载的一种封装。只是这个Loader已经通过Xlua封装，不需要我们自己去定义。而2.1中通过AssetDatabase.LoadAssetAtPath加载lua脚本，就可以写成我们自定义的一种加载方式，同样通过require实现。XLua提供了AddLoader这个接口来实现其功能。代码如下：

```cs
 private byte[] MyLoader(ref string filePath)
{   
	// 构建文件的绝对路径
    string absPath = Application.streamingAssetsPath + "/"+filePath+".lua.txt";
    
	// 读取文件的所有文本内容
    string info = File.ReadAllText(absPath);
    
	// 将文本内容转换为 UTF8 编码的字节数组并返回
    return System.Text.Encoding.UTF8.GetBytes(info);
}
```
然后通过env.AddLoader(MyLoader)之后，即可直接通过require实现加载streamingAssets文件夹下面的lua文件。
