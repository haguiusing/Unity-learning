![[Lesson2 2.cs]]

### 代码中的文件操作是做什么
- 在电脑上我们可以在操作系统中创建删除修改文件
- 可以增删查改各种各样的文件类型
- 代码中的文件操作就是通过代码来做这些事情

### 文件相关操作公共类
- C#提供了一个名为File（文件）的公共类
- 让我们可以快捷的通过代码操作文件相关
- 类名：File
- 命名空间：System.IO

### 文件操作File类的常用内容
#### File.Exists 判断文件是否存在
```cs
//Exists方法 判断文件是否存在
if (File.Exists(Application.dataPath + "/UnityTeach.tao"))
{
    print("UnityTeach.tao文件存在");
}
else
{
    print("UnityTeach.tao文件不存在");
}
```

#### File.Create 创建文件
```cs
//注意要传入的是路径
//要有/ 同时可能要手动在Inspector窗口右键刷新一次才能显示
//之后会使用创建文件方法的文件流返回值 进行写入
FileStream fs = File.Create(Application.dataPath + "/UnityTeach.tao");
```

#### File.WriteAllXX 写入内容到文件中
```cs
//WriteAll XX方法 写入文件
//将指定字节数组 写入到指定路径的文件中
//写入的是二进制数据
byte[] bytes = BitConverter.GetBytes(999);
File.WriteAllBytes(Application.dataPath + "/UnityTeach.tao", bytes);

//写入行信息 将指定的string数组内容 一行行写入到指定路径中
//写入的是字符串
//写入文件方法假如没有对应文件的话会在对应路径自动创建 可能要手动在Inspector窗口右键刷新一次才能显示
string[] strs = new string[] { "123", "韬老狮", "123123kdjfsalk", "123123123125243"};
File.WriteAllLines(Application.dataPath + "/UnityTeach2.tao", strs);

//写入文本信息
//将指定字符串写入指定路径 支持转义字符
File.WriteAllText(Application.dataPath + "/UnityTeach3.tao", "韬老狮哈\n哈哈哈哈123123131231241234123");
```

#### File.ReadAllXX 从文件读取内容
```cs
//ReadAllXX方法 读取文件
//读取字节数据
bytes = File.ReadAllBytes(Application.dataPath + "/UnityTeach.tao");
print(BitConverter.ToInt32(bytes, 0));
//读取所有行信息
strs = File.ReadAllLines(Application.dataPath + "/UnityTeach2.tao");
for (int i = 0; i < strs.Length; i++)
{
    print(strs[i]);
}
//读取所有文本信息
print(File.ReadAllText(Application.dataPath + "/UnityTeach3.tao"));
```

#### File.Delete 删除文件
```cs
//Delete方法 删除文件
//可能要手动在Inspector窗口右键刷新一次才能显示被删除
//注意 如果删除打开着的文件 会报错
File.Delete(Application.dataPath + "/UnityTeach.tao");
```

#### File.Copy 复制文件
```cs
//Copy方法 复制文件
//可能要手动在Inspector窗口右键刷新一次才能显示复制出来的文件
//假如被拷贝的路径上已经有对应文件 会报错 要传入第三个参数为true进行覆盖才不会报错 
//参数一：现有文件 需要是流关闭状态
//参数二：目标文件
//参数三：是否覆盖写入
File.Copy(Application.dataPath + "/UnityTeach2.tao", Application.dataPath + "/韬老狮.taolaoshi", true);
```

#### File.Replace 文件替换
```cs
//Replace方法 文件替换
//参数一：用来替换的路径
//参数二：被替换的路径
//参数三：备份路径 避免被替换的文件丢失 可以在备份路径看被替换的文件
File.Replace(Application.dataPath + "/UnityTeach3.tao", Application.dataPath + "/韬老狮.taolaoshi", Application.dataPath + "/韬老狮备份.taolaoshi");
```

#### File.Open 打开文件并写入或读取
```cs
//Open方法 以流的形式 打开文件并写入或读取
//参数一：路径
//参数二：打开模式
//参数三：访问模式
FileStream fs = File.Open(Application.dataPath + "/UnityTeach2.tao", FileMode.OpenOrCreate, FileAccess.ReadWrite);
```

### 总结
- File类提供了各种方法帮助我们进行文件的基础操作，需要记住这些关键API
- 一般情况下想要整体读写内容可以使用File提供的Write和Read相关功能