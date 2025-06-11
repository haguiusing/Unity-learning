# SVN分支

---

Branch 选项会给开发者创建出另外一条线路。当有人希望开发进程分开成两条不同的线路时，这个选项会非常有用。

比如项目 demo 下有两个小组，svn 下有一个 trunk 版。

由于客户需求突然变化，导致项目需要做较大改动，此时项目组决定由小组 1 继续完成原来正进行到一半的工作（某个模块），小组 2 进行新需求的开发。

那么此时，我们就可以为小组2建立一个分支，分支其实就是 trunk 版（主干线）的一个copy版，不过分支也是具有版本控制功能的，而且是和主干线相互独立的，当然，到最后我们可以通过（合并）功能，将分支合并到 trunk 上来，从而最后合并为一个项目。

我们在本地副本中创建一个 **my_branch** 分支。
```c
//列出runoob01目录下的文件和子目录
root@runoob:~/svn/runoob01# ls
branches  tags  trunk
//branches：这是存放分支的目录。分支是主干（trunk）的副本，用于独立开发。每个分支可以对应一个特定的功能开发、实验性开发或为某个特定需求而创建。
//tags：这是存放标签的目录。标签是代码的快照，通常用于标记某个特定版本（如发布版本）。标签一旦创建，通常不会被修改。
//trunk：这是项目的主干目录，是开发的主要线路。大多数开发工作都在主干上进行。

root@runoob:~/svn/runoob01# svn copy trunk/ branches/my_branch
// `trunk/` 是主干目录。  
// `branches/my_branch` 是新创建的分支目录。

A         branches/my_branch
root@runoob:~/svn/runoob01# 
```

查看状态：
```c
//查看主干目录中文件的状态
root@runoob:~/svn/runoob01/trunk# svn status

//查看分支的状态，确认分支及其文件是否正确添加到版本库中
root@runoob:~/svn/runoob01# svn status
A  +    branches/my_branch
A  +    branches/my_branch/HelloWorld.html
A  +    branches/my_branch/readme
```

- **`A`**：表示文件或目录被添加到版本控制中。
- **`D`**：表示文件或目录被删除。
- **`M`**：表示文件或目录被修改。
- **`?`**：表示文件或目录不在版本控制中。
- **`!`**：表示文件或目录在版本控制中，但本地缺失。
- **`C`**：表示文件或目录发生冲突。

提交新增的分支到版本库。
```c
//将新创建的分支提交到版本库中，使其成为版本库的一部分
root@runoob:~/svn/runoob01# svn commit -m "add my_branch" Adding         branches/my_branch
Replacing      branches/my_branch/HelloWorld.html
Adding         branches/my_branch/readme

Committed revision 9.
```

接着我们就到 my_branch 分支进行开发，切换到分支路径并创建 index.html 文件。
```c
//切换到分支目录，进行开发工作
root@runoob:~/svn/runoob01# cd branches/my_branch/

//列出my_branch目录下的文件和子目录
root@runoob:~/svn/runoob01/branches/my_branch# ls
HelloWorld.html  index.html  readme
```

将 index.html 加入版本控制，并提交到版本库中。
**保持历史记录的完整性和可追溯性**
```c
//在分支中创建新文件（如 `index.html`），并查看状态
root@runoob:~/svn/runoob01/branches/my_branch# svn status
?       index.html

//将`index.html`文件加入版本控制
root@runoob:~/svn/runoob01/branches/my_branch# svn add index.html 
A         index.html

//提交新文件到版本库
root@runoob:~/svn/runoob01/branches/my_branch# svn commit -m "add index.html"
Adding         index.html
Transmitting file data .
Committed revision 10.
```

切换到 trunk，执行 svn update，然后将 my_branch 分支合并到 trunk 中。
```c
//切换回主干目录,将分支中的更改合并到主干
root@runoob:~/svn/runoob01/trunk# svn merge ../branches/my_branch/
--- Merging r10 into '.':
A    index.html
--- Recording mergeinfo for merge of r10 into '.':
G   .
```
- `A` 表示文件被添加，`G` 表示合并信息被记录。

此时查看目录，可以看到 trunk 中已经多了 my_branch 分支创建的 index.html 文件。
```c
//以长格式列出当前目录下的文件和子目录的详细信息
root@runoob:~/svn/runoob01/trunk# ll
total 16
drwxr-xr-x 2 root root 4096 Nov  7 03:52 ./
drwxr-xr-x 6 root root 4096 Jul 21 19:19 ../
-rw-r--r-- 1 root root   36 Nov  7 02:23 HelloWorld.html
-rw-r--r-- 1 root root    0 Nov  7 03:52 index.html
-rw-r--r-- 1 root root   22 Nov  7 03:06 readme
```
- `-rw-r--r--`：文件类型和权限，`-` 表示这是一个普通文件，`rw-r--r--` 表示所有者（root）有读写权限，组（root）和其他用户只有读权限。
- `1`：表示文件的硬链接数量。
- `root root`：表示文件的所有者和所属组都是 `root`。
- 文件大小（以字节为单位）：
    - `HelloWorld.html`：36 字节。
    - `index.html`：0 字节。
    - `readme`：22 字节。
- 文件的最后修改时间：
    - `HelloWorld.html`：`Nov 7 02:23`
    - `index.html`：`Nov 7 03:52`
    - `readme`：`Nov 7 03:06`

将合并好的 trunk 提交到版本库中。
```c
//将合并后的主干提交到版本库中
root@runoob:~/svn/runoob01/trunk# svn commit -m "add index.html"
Adding         index.html
Transmitting file data .
Committed revision 11.
```