![[Lesson3 3.cs]]

### 什么是文件流
C#中，有一个叫做FileStream的类，它提供了对文件进行读写的详细控制。相比我们之前学过的File类只能对整个文件进行读写，FileStream可以以字节的形式处理文件。

说认话，文件中存储的数据就像是一个数据流（类似数组或列表），我们可以通过FileStream逐个部分地读取或写入这个数据流。

举个例子，我们可以先存储一个int（4个字节），再存储一个bool（1个字节），再存储一个string（n个字节）。利用FileStream，我们可以以流式的方式逐个读取或写入这些数据。

### FileStream文件流类常用方法
类名：FileStream  
需要引用命名空间：System.IO
#### 打开或创建指定文件
##### new FileStream
```cs
//方法一：new FileStream
//参数一：路径
//参数二：打开模式
//  CreateNew:创建新文件 如果文件存在 则报错
//  Create:创建文件，如果文件存在 则覆盖
//  Open:打开文件，如果文件不存在 报错
//  OpenOrCreate:打开或者创建文件根据实际情况操作
//  Append:若存在文件，则打开并查找文件尾，或者创建一个新文件
//  Truncate:打开并清空文件内容
//参数三：访问读写模式
//  Read 允许别的程序读取当前文件
//  Write 允许别的程序写入该文件
//  ReadWrite 允许别的程序读写该文件
//参数四：共享权限（当一个文件被打开时，其他进程或线程可以如何访问该文件）
//  None 谢绝共享
//  Read 允许别的程序读取当前文件
//  Write 允许别的程序写入该文件
//  ReadWrite 允许别的程序读写该文件
//  Delete  允许其他进程或线程删除文件
//  Inheritable  允许其他进程或线程删除文件
FileStream fileStream1 = new FileStream(Application.dataPath + "/Lesson04_文件操作相关_文件流相关.tao", FileMode.Create, FileAccess.ReadWrite);
```
##### File.Create
```cs
//方法二：File.Create
//参数一：路径
//参数二：缓存大小
//参数三：描述如何创建或覆盖该文件（不常用）
//  Asynchronous 可用于异步读写
//  DeleteOnClose 不在使用时，自动删除
//  Encrypted 加密
//  None 不应用其它选项
//  RandomAccess 随机访问文件
//  SequentialScan 从头到尾顺序访问文件
//  WriteThrough 通过中间缓存直接写入磁盘
FileStream fileStream2 = File.Create(Application.dataPath + "/Lesson04_文件操作相关_文件流相关.tao",2048);
```
##### File.Open
```cs
//方法三：File.Open
//参数一：路径
//参数二：打开模式
FileStream fileStream3 = File.Open(Application.dataPath + "/Lesson04_文件操作相关_文件流相关.tao", FileMode.OpenOrCreate);
```

#### 重要属性和方法
```cs
FileStream fileStream4 = File.Open(Application.dataPath + "Lesson04_文件操作相关_文件流相关.tao", FileMode.OpenOrCreate);
```
##### FileStream.Length 文本字节长度
```cs
//文本字节长度
print(fileStream4.Length);//0
```
##### FileStream.CanRead 是否可写
```cs
//是否可写
if (fileStream4.CanRead)
{

}
```
##### FileStream.CanWrite 是否可读
```cs
//是否可读
if (fileStream4.CanWrite)
{

}
```
##### FileStream.Flush 将缓冲区中的数据立即写入到文件中
通常情况下，文件写入是通过缓冲区进行的，这样可以提高写入效率。但是，如果您希望确保数据尽快写入到磁盘，而不是等待缓冲区满或者流关闭时才写入，您可以调用 Flush() 方法。

调用 Flush() 方法时，它会强制将缓冲区中的数据刷新到文件中，然后清空缓冲区，这样可以确保文件中的数据是最新的。这在某些情况下非常有用，比如在需要确保数据实时保存到文件时，或者在程序即将关闭之前需要确保所有数据都已写入到文件中。
```cs
//将字节写入文件 当写入后 一定执行写入流 才能保证写入文件成功 不然可能丢失
fileStream4.Flush();
```
##### FileStream.Close 关闭流
```cs
//关闭流 当文件读写完毕后 一定执行关闭流
fileStream4.Close();
```
##### FileStream.Dispose 缓存资源销毁回收
```cs
//缓存资源销毁回收
fileStream4.Dispose();
```

#### FileStream.Write 写入字节
```cs
//打印可读写路径
print(Application.persistentDataPath);

using (FileStream fileStream5 = new FileStream(Application.persistentDataPath + "/Lesson04_文件操作相关_文件流相关.tao", FileMode.OpenOrCreate, FileAccess.Write))
{

    byte[] bytes = BitConverter.GetBytes(999);

    //方法：Write
    //参数一：写入的字节数组
    //参数二：数组中的开始索引
    //参数三：写入多少个字节
    //要传入开始索引和写入多少字节的原因：有可能一个数组前面代表一个数据 中间一截代表另一串数据 可以直接传数组长度
    fileStream5.Write(bytes, 0, bytes.Length);
    //fileStream5.Write(bytes, 0, 4);

当你将字符串写入文件时，字符串本身是一个字节数组，但仅存储字节数组是不够的。为了能够正确地从文件中读取字符串，你需要知道字符串的长度。否则，当你读取文件时，程序将无法确定字符串的结束位置。

    //写入字符串时 先把字符串转成字节数组
    bytes = Encoding.UTF8.GetBytes("林文韬哈哈哈哈");
    //要先写入长度 不然无法自动字符串有多长 传入字节数组长度的直接数组
    //int length = bytes.Length;
    fileStream5.Write(BitConverter.GetBytes(bytes.Length), 0, 4);  //bytes.Length 是一个 32 位的整数int类型，占用 4 个字节
    //再写入字符串具体内容 传入直接数组
    fileStream5.Write(bytes, 0, bytes.Length);

    //避免数据丢失 一定写入后要执行的方法
    fileStream5.Flush();

    //销毁缓存 释放资源
    fileStream5.Dispose();
}
```

| 数据类型      | 字节长度 | 描述                    |
| --------- | ---- | --------------------- |
| `bool`    | 1    | 布尔值（`true` 或 `false`） |
| `byte`    | 1    | 无符号 8 位整数             |
| `sbyte`   | 1    | 有符号 8 位整数             |
| `char`    | 2    | 16 位 Unicode 字符       |
| `short`   | 2    | 有符号 16 位整数            |
| `ushort`  | 2    | 无符号 16 位整数            |
| `int`     | 4    | 有符号 32 位整数            |
| `uint`    | 4    | 无符号 32 位整数            |
| `long`    | 8    | 有符号 64 位整数            |
| `ulong`   | 8    | 无符号 64 位整数            |
| `float`   | 4    | 32 位浮点数               |
| `double`  | 8    | 64 位浮点数               |
| `decimal` | 16   | 128 位十进制数             |

#### FileStream.Read 读取字节
##### 挨个读取字节数组并转换
核心思想是读一个转换一个
```cs
using (FileStream fileStream6 = File.Open(Application.persistentDataPath + "/Lesson04_文件操作相关_文件流相关.tao", FileMode.Open, FileAccess.Read))
{
    //读取时可以理解为流有个看不见的索引 读到哪索引加到哪

    //用于存储读取的字节数组的容器
    byte[] bytes2 = new byte[4];

    //参数一：用于存储读取的字节数组的容器
    //参数二：容器中开始的位置
    //参数三：读取多少个字节装入容器
    //返回值：当前流索引前进了几个位置
    int index = fileStream6.Read(bytes2, 0, 4);
    int i = BitConverter.ToInt32(bytes2, 0);
    print("取出来的第一个整数" + i);//999
    print("索引向前移动" + index + "个位置");

    //读取第二个字符串
    //读取字符串字节数组长度
    index = fileStream6.Read(bytes2, 0, 4);
    print("索引向前移动" + index + "个位置");
    //转换出直接数组有多长
    int length = BitConverter.ToInt32(bytes2, 0);
    print("字符串数组长度为" + length);//21

    //要根据我们存储的字符串字节数组的长度 来声明一个新的字节数组 用来装载读取出来的数据
    bytes2 = new byte[length];
    index = fileStream6.Read(bytes2, 0, length);
    print("索引向前移动" + index + "个位置");
    //得到最终的字符串 打印出来
    print(Encoding.UTF8.GetString(bytes2));//林文韬哈哈哈哈

    fileStream6.Dispose();
}
```
##### 一次性读取再挨个转换
核心思想是读完全部再转换
```cs
using (FileStream fileStream7 = File.Open(Application.persistentDataPath + "/Lesson04_文件操作相关_文件流相关.tao", FileMode.Open, FileAccess.Read))
{
    //一开始就申明一个 和文件字节数组长度一样的容器
    byte[] bytes3 = new byte[fileStream7.Length];

    //一口气读取文件所有字节
    fileStream7.Read(bytes3, 0, (int)fileStream7.Length);

    fileStream7.Dispose();

    //读取整数 因为是int自动读4个字节 从0位置开始读
    print(BitConverter.ToInt32(bytes3, 0));//999

    //得去字符串字节数组的长度 因为是int自动读4个字节 从4位置开始读
    int length2 = BitConverter.ToInt32(bytes3, 4);//21

    //得到字符串 读取长度是刚刚取出来的字节数组的长度 因为是string 要指定读几位 读味
    print(Encoding.UTF8.GetString(bytes3, 8, length2));//林文韬哈哈哈哈
}
```

### 更加安全的使用文件流对象
- 普通用法：
    - //申明一个引用对象
    - //使用对象
    - //销毁对象
- using关键字用法：
    - //using (申明一个引用对象)
    - //{
    - //使用对象
    - //}
- 无论发生什么情况，当using语句块结束后，会自动调用该对象的销毁方法，避免忘记销毁或关闭流。using 是一种更安全的使用方法。
    
- 强调目前我们对文件流进行操作，为了文件操作安全，都用 using 来进行处理最好。

### 总结
在使用 FileStream 进行读写操作时，需要确保读写的规则是一致的。存储数据的顺序由我们制定的规则决定，按照规则进行读写可以保证数据的正确性。