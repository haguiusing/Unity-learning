# SVN 标签（tag）

---

版本管理系统支持 tag 选项，通过使用 tag 的概念，我们可以给某一个具体版本的代码一个更加有意义的名字。

Tags 即标签主要用于项目开发中的里程碑，比如开发到一定阶段可以单独一个版本作为发布等，它往往代表一个可以固定的完整的版本，这跟 VSS 中的 Tag 大致相同。

我们在本地工作副本创建一个 tag。
```c
//**复制主干到标签目录**
root@runoob:~/svn/runoob01# svn copy trunk/ tags/v1.0
A         tags/v1.0
```
- `trunk/` 是主干目录。
- `tags/v1.0` 是新创建的标签目录。

上面的代码成功完成，新的目录将会被创建在 tags 目录下。
```c
//**查看标签目录**
root@runoob:~/svn/runoob01# ls tags/
v1.0
root@runoob:~/svn/runoob01# ls tags/v1.0/
HelloWorld.html  readme
```

查看状态。
```c
root@runoob:~/svn/runoob01# svn status
A  +    tags/v1.0
```
- `A` 表示文件或目录被添加到版本控制中。
- `+` 表示该目录或文件具有版本控制信息。

提交tag内容。
```c
//**提交标签到版本库**
root@runoob:~/svn/runoob01# svn commit -m "tags v1.0" Adding         tags/v1.0
Transmitting file data ..
Committed revision 14.
```
- 提交信息为 `"tags v1.0"`，表示添加了标签 `v1.0`。
- 提交后，版本库会记录新的版本号（如 `revision 14`）。
- 
 ### **标签的特点**
- **不可修改**：标签一旦创建，通常不会被修改。如果需要修改，应该创建一个新的标签。
- **固定版本**：标签代表一个固定的版本，便于团队成员快速定位和使用。