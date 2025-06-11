![[LessonExcelDll.cs]]

### 了解Excel表的本质
- Excel表本质上也是一堆数据
- 只不过它有自己的存储读取规则
- 如果我们想要通过代码读取它
- 那么必须知道它的存储规则
- 官网是专门提供了对应的DLL文件用来解析Excel文件的
- Dll文件：库文件，你可以理解为它是许多代码的集合
- 将相关代码集合在库文件中可以方便迁移和使用
- 有了某个DLL文件，我们就可以使用其中已经写好的代码
- 而Excel的DLL包就是官方已经把解析Excel表的相关类和方法写好了
- 方便用户直接使用

### 导入官方提供的Excel相关DLL文件
- 最好放到Editor文件夹里面，一般Excel解析都在编辑器中，不会在游戏运行时解析
![](https://linwentao785293209.github.io/images/%E6%95%B0%E6%8D%AE%E5%AD%98%E5%82%A8/%E6%95%B0%E6%8D%AE%E6%8C%81%E4%B9%85%E5%8C%96/Unity/08.Binary%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE/2.%E7%9F%A5%E8%AF%86%E7%82%B9%E8%A1%A5%E5%85%85-ExcelDll%E5%8C%85%E5%AF%BC%E5%85%A5/1.png)

![[Pasted image 20250605174445.png]]

