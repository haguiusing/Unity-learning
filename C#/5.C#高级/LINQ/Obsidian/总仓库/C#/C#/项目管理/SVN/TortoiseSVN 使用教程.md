[TortoiseSVN安装及使用方法_svn tortoise-CSDN博客](h
```embed
title: "TortoiseSVN安装及使用方法_svn tortoise-CSDN博客"
image: "https://devpress.csdnimg.cn/8bc8dd1a2bc24184a16a142654c4a49e.png"
description: "文章浏览阅读3.5w次，点赞43次，收藏193次。本文详细介绍SVN客户端的安装过程及基本使用方法，包括项目的检出、导入、提交、更新及版本回滚等常见操作，并提供了版本控制的实用技巧。"
url: "https://blog.csdn.net/qq_22200671/article/details/108643942"
favicon: ""
aspectRatio: "100"
```
[目录 - 《TortoiseSVN 中文文档》 - 技术池(jishuchi.com)](h
```embed
title: "目录 - 《TortoiseSVN 中文文档》 - 技术池(jishuchi.com)"
image: "https://www.jishuchi.com/static/images/icon-bookmark-list.png"
description: "目录 TortoiseSVN 是一个 Windows 下的版本控制系统 Apache™ Subversion® 的客户端工具。就是说，TortoiseSVN 常年管理文件和目录。文件存储于一个中央版本库中。版本库就像一个常见的文件服务器，除了它保存你对文件和目录所有的改变。这一特性使得你可以恢复文件的旧版本并查看历史-谁在什么时间如何进行的修改。这就是为什么很多人认为 Subversion 和版本"
url: "https://www.jishuchi.com/read/tortoisesvn/12869"
favicon: ""
aspectRatio: "100"
```
# TortoiseSVN 使用教程
TortoiseSVN 是 Subversion 版本控制系统的一个免费开源客户端，可以超越时间的管理文件和目录。

---
## TortoiseSVN 安装
[下载 · TortoiseSVN - TortoiseSVN 软件](h
```embed
title: "Fetching"
image: "data:image/svg+xml;base64,PHN2ZyBjbGFzcz0ibGRzLW1pY3Jvc29mdCIgd2lkdGg9IjgwcHgiICBoZWlnaHQ9IjgwcHgiICB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAxMDAgMTAwIiBwcmVzZXJ2ZUFzcGVjdFJhdGlvPSJ4TWlkWU1pZCI+PGcgdHJhbnNmb3JtPSJyb3RhdGUoMCkiPjxjaXJjbGUgY3g9IjgxLjczNDEzMzYxMTY0OTQxIiBjeT0iNzQuMzUwNDU3MTYwMzQ4ODIiIGZpbGw9IiNlMTViNjQiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM0MC4wMDEgNDkuOTk5OSA1MCkiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49IjBzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9Ijc0LjM1MDQ1NzE2MDM0ODgyIiBjeT0iODEuNzM0MTMzNjExNjQ5NDEiIGZpbGw9IiNmNDdlNjAiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM0OC4zNTIgNTAuMDAwMSA1MC4wMDAxKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMDYyNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iNjUuMzA3MzM3Mjk0NjAzNiIgY3k9Ijg2Ljk1NTE4MTMwMDQ1MTQ3IiBmaWxsPSIjZjhiMjZhIiByPSI1IiB0cmFuc2Zvcm09InJvdGF0ZSgzNTQuMjM2IDUwIDUwKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMTI1cyI+PC9hbmltYXRlVHJhbnNmb3JtPgo8L2NpcmNsZT48Y2lyY2xlIGN4PSI1NS4yMjEwNDc2ODg4MDIwNyIgY3k9Ijg5LjY1Nzc5NDQ1NDk1MjQxIiBmaWxsPSIjYWJiZDgxIiByPSI1IiB0cmFuc2Zvcm09InJvdGF0ZSgzNTcuOTU4IDUwLjAwMDIgNTAuMDAwMikiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49Ii0wLjE4NzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9IjQ0Ljc3ODk1MjMxMTE5NzkzIiBjeT0iODkuNjU3Nzk0NDU0OTUyNDEiIGZpbGw9IiM4NDliODciIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM1OS43NiA1MC4wMDY0IDUwLjAwNjQpIj4KICA8YW5pbWF0ZVRyYW5zZm9ybSBhdHRyaWJ1dGVOYW1lPSJ0cmFuc2Zvcm0iIHR5cGU9InJvdGF0ZSIgY2FsY01vZGU9InNwbGluZSIgdmFsdWVzPSIwIDUwIDUwOzM2MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiIGJlZ2luPSItMC4yNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iMzQuNjkyNjYyNzA1Mzk2NDE1IiBjeT0iODYuOTU1MTgxMzAwNDUxNDciIGZpbGw9IiNlMTViNjQiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDAuMTgzNTUyIDUwIDUwKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMzEyNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iMjUuNjQ5NTQyODM5NjUxMTc2IiBjeT0iODEuNzM0MTMzNjExNjQ5NDEiIGZpbGw9IiNmNDdlNjAiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDEuODY0NTcgNTAgNTApIj4KICA8YW5pbWF0ZVRyYW5zZm9ybSBhdHRyaWJ1dGVOYW1lPSJ0cmFuc2Zvcm0iIHR5cGU9InJvdGF0ZSIgY2FsY01vZGU9InNwbGluZSIgdmFsdWVzPSIwIDUwIDUwOzM2MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiIGJlZ2luPSItMC4zNzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9IjE4LjI2NTg2NjM4ODM1MDYiIGN5PSI3NC4zNTA0NTcxNjAzNDg4NCIgZmlsbD0iI2Y4YjI2YSIgcj0iNSIgdHJhbnNmb3JtPSJyb3RhdGUoNS40NTEyNiA1MCA1MCkiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49Ii0wLjQzNzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT48L2c+PC9zdmc+"
description: "Fetching https://tortoisesvn.cn/downloads.html"
url: "https://tortoisesvn.cn/downloads.html"
favicon: ""
```
下载地址：[https://tortoisesvn.net/downloads.html](https://tortoisesvn.net/downloads.html), 页面里有语言包补丁的下载链接。

目前最新版为 1.11.0 下载地址： [https://osdn.net/projects/tortoisesvn/storage/1.11.0/](https://osdn.net/projects/tortoisesvn/storage/1.11.0/)
![](https://www.runoob.com/wp-content/uploads/2018/07/754674DA-A016-4780-A48B-C9B3A832B481.jpg)

在语言补丁包中我们可以找到中文的补丁并下载下来：
![](https://www.runoob.com/wp-content/uploads/2018/07/5D776921-B740-484C-B753-75AF57BEE5D5.png)

运行下载的 TortoiseSVN 安装程序
![](https://www.runoob.com/wp-content/uploads/2018/07/install01.gif)

运行下载的 TortoiseSVN 中文语言包
![](https://www.runoob.com/wp-content/uploads/2018/07/install02.gif)

正确安装后，应该进行一次的重开机，以确保 TortoiseSVN 的正确无误。

修改 TortoiseSVN 默认语言

TortoiseSVN 安装完后默认的界面是英文的，我们可以通过设置修改成已安装语言
![](https://www.runoob.com/wp-content/uploads/2018/07/changeLANG.gif)

---

## TortoiseSVN 的使用
### 创建版本库
空文件夹，右键创建
![[Pasted image 20250604165926.png]]

![[Pasted image 20250604170052.png]]

![[Pasted image 20250604170115.png]]
完成
### 检出操作
建立一个 runoob01 的工作目录
所谓的 runoob01 目录其实就是您平常用来存放工作档案的地方。通常我们会等到自己的工作做的一个段落的时候再进行备份。所以我们平常都是在 runoob01 目录下面工作，等到适当时机在 commit 到 repository 中。举例来说，我们想在 D 盘下面建立一个名为 runoob01 的目录。首先先把这个目录建立出来。
![](https://www.runoob.com/wp-content/uploads/2018/07/create.png)

进入创建的目录在空白处按下右键后(您可以在 MyWork 目录的 icon 上按，也可进入 MyWork 目录后，在空白的地方按)，选择 SVN checkout。
![](https://www.runoob.com/wp-content/uploads/2018/07/001.png)

接着您可以看到如下的画面：
![](https://www.runoob.com/wp-content/uploads/2018/07/002.png)

首先我们要填入的是 repository(版本库)的位置，对于 SVN 来说，repository 的位置都是 URL。版本库 URL 这里填入我们测试的版本仓库地址 **\svn://10.0.4.17/runoob01**。

接着，稍微看一下 Checkout directory(检出至目录)，这个字段应该要指向您的 runoob01 目录。
![[Pasted image 20250604171141.png]]

确认后，按下 OK 按钮，您应该可以看到如下的信息窗口。
![[Pasted image 20250604171212.png]]

这样就表示动作完成。按下 OK 按钮后，再到您刚刚建立的目录下。您将会看到 MyWork 目录下面多了一个名为 .svn 的目录(这个目录是隐藏的，如果您的档案管理员没有设定可以看到隐藏目录，您将无法看到它) 。
![[Pasted image 20250604171233.png]]

如果您要在一个已经存在的 SVN Server 上面 checkout 出上面的档案，您只需要给定正确的 SVN URL 以及要 checkout 目录的名称。就可以取得指定的档案及目录了。

---

### 检查修改
在G:\\Program Files (x86)\\runoob01\\trunk目录里新增文件
![[Pasted image 20250604171954.png]]

检查修改
![[Pasted image 20250604172055.png]]

提交
![[Pasted image 20250604173759.png]]

---

### 提交操作
勾选提交内容并确认
![[Pasted image 20250604173855.png]]

按下 OK 后，您将会看到如下的讯息窗口：
![[Pasted image 20250604174017.png]]

打开版本库浏览器查看
![[Pasted image 20250604174112.png]]

检测确认一致
![[Pasted image 20250604174320.png]]

---

### 导入项目
版本库外部右键，将文件导入版本库
![[Pasted image 20250604174925.png]]

在版本库浏览器内部右键，将版本库文件导入其他文件夹
![[Pasted image 20250604175319.png]]
![[Pasted image 20250604175936.png]]
![[Pasted image 20250604175944.png]]

---
### 导出文件
将版本库中的某部分文件导出到文件夹中
![[Pasted image 20250604180905.png]]
![[Pasted image 20250604180830.png]]

---

### 分支
方法1：先检出，再打分支
![[Pasted image 20250604184126.png]]
![[Pasted image 20250604184059.png]]
![[Pasted image 20250604183927.png]]
![[Pasted image 20250604184028.png]]

方法2：
![[Pasted image 20250604184225.png]]

在分支中创建
![[Pasted image 20250604181314.png]]

---
### 更新
从版本库中获取最新版本
![[Pasted image 20250604182412.png]]
![[Pasted image 20250604182353.png]]

更新至版本...自定义版本
![[Pasted image 20250604182240.png]]
![[Pasted image 20250604182320.png]]

---
### 版本回滚
如果你改了东西，但是还没有提交，可以使用还原到未修改版本。  
![[Pasted image 20250604182136.png]]

---
### 复制档案及目录 branch
很多时候您会希望有另外一个复制的目录来进行新的编修。等到确定这个分支的修改已经完毕了，再合并到原来的主要开发版本上。举例来说，我们目前在runoob01/trunk下面有如下的目录及档案：
![](https://www.runoob.com/wp-content/uploads/2018/07/012.png)

现在，我们要为 trunk 这个目录建立一个 branch。假设我们希望这个目录是在 D:\runoob01\branch。首先我们可以在 trunk 目录下面的空白处，或是直接在 trunk 的 icon 下面按下鼠标右键选择 Branch/Tag…(分支/标记)这个选项，您将会看到如下的对话框出现。
![](https://www.runoob.com/wp-content/uploads/2018/07/013.png)

![](https://www.runoob.com/wp-content/uploads/2018/07/014.png)

请先确认 From WC at URL(从工作副本/URL): 中的目录是您要复制的来源目录。接着，在 To URL(至路径)中输入您要复制过去的路径。通常我们会将所有的 branch 集中在一个目录下面。以上面的例子来说，branch 档案都会集中在 branch 的子目录下面。在 To URL 中您只需要输入您要的目录即可。目录不存在时，会由 SVN 帮您建立。特别需要注意的是 SVN 以斜线作为目录分隔字符，而非反斜线。 接着在 Log message(日志信息)输入您此次 branch 的目的为何。按下 OK 就可以了。

如果成功，将可以看到下面的画面：
![](https://www.runoob.com/wp-content/uploads/2018/07/015.png)

按下 OK 就可以关闭这个窗口了。如果您此时立刻去 runoob01 目录的 branch 子目录下面，您将会失望的发现在该目录下面并没有刚刚指定的目录存在。这是因为您 runoob01 目录的部份还是旧的，您只需要在 branch 子目录下面进行 SVN update 就可以看到这个新增的目录了。新增的目录就与原来的目录无关了。您可以任意对他进行编辑，一直到您确认好所有在 branch 下面该做的工作都完成后，您可以选择将这个 branch merge 回原来的 trunk 目录，或者是保留它在 branch 中。

---

### 合并分支
即选择目标分支合并到当前所处分支



### 合并动作 merge
假如我们在 branch 分支中对文件进行了修改或增加了文件，要 merge 回 trunk 目录中，方法很简单。以上面的例子来说，我们在 D:\runoob01\trunk目录空白处，按下鼠标右键，选择 Merge(合并):
![](https://www.runoob.com/wp-content/uploads/2018/07/016.png)

这个画面主要分为三个部份，前面的 From: 与 To: 是要问您打算从 Branch 中的哪个版本到哪个版本，merge 回原来的 trunk 目录中。因此，From 跟 To 的 URL 字段应当都是指定原来 branch 的目录下。剩下的就是指定要 merge 的 revision 范围。以上面的例子而言，我们从 Branch 的 Revision 7 开始 merge 到 Branch 下面的最新版本。您可以透过，Try run 按钮，试作一次 Merge。这个 merge 只会显示一些讯息，不会真正的更新到 trunk 的目录去。只有按下 Merge 按钮后，才会真正的将 branch 的档案与 trunk 的档案合并起来。

![](https://www.runoob.com/wp-content/uploads/2018/07/007.gif)

如果您确认这次的 merge 没有问题，您可以直接使用 commit 来将这两个被修改的档案 commit 回 SVN repository 上。如果有问题，您可以直接修改这两个档案，直到确认 ok 了，再行 commit。

---

### 制作 Tag 或是 Release
所谓的 Tag 或是 Release 就是一个特别的版本，因为这个版本可能有特别的意义。例如：这个版本是特别的 Milestone 或是 release 给客户的版本。其实，Tag 与 Release 的作法与 Branch 完全相同。只是 Branch 可能会需要 merge 回原来的 trunk 中，而 tag 及 release 大部分都不需要 merge 回 trunk 中。

举例来说，今天我们的 trunk 做了一版，这个版本被认定是软件的 1.0 版。 1.0版对于开发来说是一个非常重要的里程碑。所以我们要特别为他做一个标记，亦即 Tag。假设，这个 1.0 版是要正式 release 给客户或是相关 vendor，我们要可以为他做一个 Release 的标记。基本上，SVN 只有目录的概念，并没有什么 Tag 的用法。所以您会看到在 SVN 的选单上面，Branch 与 Tag 是同一个项目。以这个 1.0 的例子来说，我们在 runoob01 目录下创建 tags 目录用于存放打 tag 的版本，并提交到版本库，然后在 Trunk 上面，按下鼠标右键，选择 Branch/Tag 的项目：
![](https://www.runoob.com/wp-content/uploads/2018/07/013.png)

![](https://www.runoob.com/wp-content/uploads/2018/07/020-1.png)

成功的话，您就在对应的 Tag 目录下面建立了一个 v1.0 的目录。当然，如果您这时到 Tag 的目录下面去，会看不到这个目录，您需要在 Tag 目录下面 update 一下，才能看到它。
![](https://www.runoob.com/wp-content/uploads/2018/07/021.png)