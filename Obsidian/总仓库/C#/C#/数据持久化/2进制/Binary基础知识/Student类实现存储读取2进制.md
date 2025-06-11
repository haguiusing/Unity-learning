### 为图中的Student类实现保存和读取2进制文件的方法
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/07.Binary%E5%9F%BA%E7%A1%80%E7%9F%A5%E8%AF%86/6.%E6%96%87%E4%BB%B6%E6%93%8D%E4%BD%9C%E7%9B%B8%E5%85%B3-%E7%BB%BC%E5%90%88%E7%BB%83%E4%B9%A0%E9%A2%98/1.png)

#### 创建Student类,添加对应的变量
```cs
public class Student
{
    public int age;
    public string name;
    public int number;
    public bool sex;
}
```

#### Student类中创建保存方法。
传入文件名参数。判断可读可写路径下是否存在Student文件夹，不存在则创建。新建流进行写入对应变量。
```cs
public void Save(string fileName)
{
    Debug.Log(Application.persistentDataPath); // 打印存储的路径

    // 如果不存在指定路径，则创建一个文件夹
    if (!Directory.Exists(Application.persistentDataPath + "/Student"))
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/Student");
    }

    // 新建一个指定名字的文件，并返回文件流进行字节的存储
    using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/Student/" + fileName + ".linwentao", FileMode.OpenOrCreate, FileAccess.Write))
    {
        // 写入 age
        byte[] bytes = BitConverter.GetBytes(age);
        fileStream.Write(bytes, 0, bytes.Length);

        // 写入 name
        bytes = Encoding.UTF8.GetBytes(name);
        // 存储字符串字节数组的长度
        fileStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
        // 存储字符串字节数组
        fileStream.Write(bytes, 0, bytes.Length);

        // 写入 number
        bytes = BitConverter.GetBytes(number);
        fileStream.Write(bytes, 0, bytes.Length);

        // 写入 sex
        bytes = BitConverter.GetBytes(sex);
        fileStream.Write(bytes, 0, bytes.Length);

        // 刷新缓冲区，确保所有数据已写入文件
        fileStream.Flush();
        // 关闭文件流
        fileStream.Close();
    }
}
```

#### Student类中创建读取方法。
传入文件名参数。判断文件是否存在，不存在返回空。申明Student对象，读取文件中全部直接数组，挨个读取其中的内容，用一个索引记录。
```cs
public static Student Load(string fileName)
{
    //判断文件是否存在
    if (!File.Exists(Application.persistentDataPath + "/Student/" + fileName + ".linwentao"))
    {
        Debug.LogWarning("没有找到对应的文件");
        return null;
    }

    //申明对象
    Student student = new Student();

    //加载2进制文件 进行赋值
    using (FileStream fileStream = File.Open(Application.persistentDataPath + "/Student/" + fileName + ".linwentao", FileMode.Open, FileAccess.Read))
    {
        //把我们文件中的字节 全部读取出来
        byte[] bytes = new byte[fileStream.Length];
        fileStream.Read(bytes, 0, bytes.Length);
        fileStream.Close();

        //读取索引
        int index = 0;

        //挨个读取其中的内容

        //读取age
        student.age = BitConverter.ToInt32(bytes, index);
        index += 4;

        //读取字符串字节数组的长度
        int length = BitConverter.ToInt32(bytes, index);
        index += 4;

        //读取name
        student.name = Encoding.UTF8.GetString(bytes, index, length);
        index += length;

        //读取number
        student.number = BitConverter.ToInt32(bytes, index);
        index += 4;

        //读取sex
        student.sex = BitConverter.ToBoolean(bytes, index);
        index += 1;
    }

    return student;
}
```
#### 对读取存储方法进行测试
```cs
void Start()
{
    Student student1 = new Student();
    student1.age = 18;
    student1.name = "林文韬";
    student1.number = 1;
    student1.sex = false;

    student1.Save("林文韬");


    Student student2 = Student.Load("林文韬");
}
```