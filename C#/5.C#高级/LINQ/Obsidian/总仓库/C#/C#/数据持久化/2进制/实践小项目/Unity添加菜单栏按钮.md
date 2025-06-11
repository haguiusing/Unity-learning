![[LessonEditor.cs]]

### 为编辑器菜单栏添加新的选项入口
可以通过 Unity 提供的 MenuItem 特性在菜单栏添加选项按钮。  
特性名：MenuItem  
命名空间：UnityEditor

规则一：一定是静态方法  
规则二：我们这个菜单栏按钮必须有至少一个斜杠，不然会报错，它不支持只有一个菜单栏入口  
规则三：这个特性可以用在任意的类当中，可以不继承 MonoBehaviour 也正常使用
```cs
[MenuItem("Lesson01_知识点补充_Unity添加菜单栏按钮/为编辑器菜单栏添加新的选项入口")]
private static void 为编辑器菜单栏添加新的选项入口()
{
    Debug.Log("为编辑器菜单栏添加新的选项入口");
}
```

![[Pasted image 20250605174337.png]]

### 刷新Project窗口内容
```cs
[MenuItem("Lesson01_知识点补充_Unity添加菜单栏按钮/刷新Project窗口内容")]
private static void 刷新Project窗口内容()
{
    Debug.Log("刷新Project窗口内容");

    // 类名：AssetDatabase
    // 命名空间：UnityEditor
    // 方法：Refresh

    // 创建文件夹并刷新
    Directory.CreateDirectory(Application.dataPath + "/刷新Project窗口内容测试文件夹");
    AssetDatabase.Refresh();
}
```

![[Pasted image 20250605174355.png]]

### Editor文件夹
Editor 文件夹可以放在项目的任何文件夹下，可以有多个。  
放在其中的内容，在项目打包时不会被打包到项目中。  
一般编辑器相关代码都可以放在该文件夹中。
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/1.%E7%9F%A5%E8%AF%86%E7%82%B9%E8%A1%A5%E5%85%85-Unity%E6%B7%BB%E5%8A%A0%E8%8F%9C%E5%8D%95%E6%A0%8F%E6%8C%89%E9%92%AE/3.png)

### 总结
我们之后在学习通过 Excel 表生成数据的功能时，可以在菜单栏加一个按钮，点击后就可以自动为我们生成对应数据了。