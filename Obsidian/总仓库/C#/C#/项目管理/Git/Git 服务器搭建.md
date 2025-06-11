# Git 服务器搭建
上一章节中我们远程仓库使用了 Github，Github 公开的项目是免费的，2019 年开始 Github 私有存储库也可以无限制使用。

当然我们也可以自己搭建一台 Git 服务器作为私有仓库使用。

## 使用裸存储库（Bare Repository）
### 1、安装Git

Ubuntu 服务器上安装 Git：
```cs
sudo apt install git
```

如果你使用的系统是 Centos/RedHat 安装命令为：
```cs
yum -y install git-core
```

Fedora 安装命令：
```cs
# yum install git (Fedora 21 及之前的版本)
# dnf install git (Fedora 22 及更高新版本)
```

接下来我们 创建一个 git 用户组和用户，用来运行git服务：
```cs
$ groupadd git
$ useradd git -g git

```
### 2、创建裸存储库
登录到 Git 用户，然后在其 home 目录下创建一个裸存储库。
```cs
$ sudo su - git
```

首先我们选定一个目录作为 Git 仓库，假定是 /home/gitrepo/runoob.git，在 /home/gitrepo 目录下输入命令：
```cs
$ cd /home
$ mkdir gitrepo
$ chown git:git gitrepo/
$ cd gitrepo

$ git init --bare runoob.git
```

以上命令Git创建一个空仓库，服务器上的 Git 仓库通常都以 .git 结尾。然后，把仓库所属用户改为 git（如果是其他用户操作，比如 root）：
```cs
$ chown -R git:git runoob.git
```

### 3、创建证书登录
将你的公钥添加到 ~/.ssh/authorized_keys 中，允许远程访问。

收集所有需要登录的用户的公钥，公钥位于 id_rsa.pub 文件中，把我们的公钥导入到 /home/git/.ssh/authorized_keys 文件里，一行一个。

如果没有该文件创建它：
```cs
$ cd /home/git/
$ mkdir .ssh
$ chmod 755 .ssh
$ touch .ssh/authorized_keys
$ chmod 644 .ssh/authorized_keys
# 在文件中添加你的 SSH 公钥
```

### 4、克隆仓库
```cs
$ git clone git@192.168.45.4:/home/gitrepo/runoob.git
Cloning into 'runoob'...
warning: You appear to have cloned an empty repository.
Checking connectivity... done.
```

192.168.45.4 为 Git 所在服务器 ip ，你需要将其修改为你自己的 Git 服务 ip。
这样我们的 Git 服务器安装就完成。

---

## 使用 GitLab
GitLab 是一个功能强大的 Git 服务管理工具，适合中大型团队，提供了丰富的用户管理、CI/CD、代码审查等功能。

**1、安装 GitLab**
根据 [GitLab 官方文档](https://about.gitlab.com/install/) 安装 GitLab。
例如，在 Ubuntu 上：
```cs
# sudo apt-get update
# sudo apt-get install -y curl openssh-server ca-certificates tzdata perl
# curl https://packages.gitlab.com/install/repositories/gitlab/gitlab-ee/script.deb.sh | sudo bash
# sudo EXTERNAL_URL="http://yourdomain" apt-get install gitlab-ee
```

EXTERNAL_URL="http://yourdomain" 要设置自己的域名，或者公网 IP，比如：
```cs
sudo EXTERNAL_URL=101.132.XX.XX yum install -y gitlab-ee
```

**2、配置 GitLab**
安装完成后，打开浏览器访问 http://yourdomain，设置管理员账户。

当出现类似如下回显信息，表示 GitLab 已经安装成功。
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-1.png)

**3、创建项目**
登录 GitLab，创建一个新的项目，用户名为 root。

获取登录密码：
```cs
sudo cat /etc/gitlab/initial_root_password
```

结果如下所示：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab2.png)

首次登录使用用户名 root:
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-3.png)

**4、生成密钥对文件并获取公钥**
安装 Git 工具（已安装跳过）：
```cs
sudo apt-get install git
```

生成密钥对文件 id_rsa:
```cs
ssh-keygen
```

生成密钥对的过程中，系统会提示输入密钥对存放目录（默认为当前用户目录下的 .ssh/id_rsa，例如 /home/test/.ssh/id_rsa）和密钥对密码，您可以手动输入，也可以按 Enter 保持默认。

生成后，显示信息如下：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-4.png)

查看并复制公钥文件 id_rsa.pub 中的内容:
```cs
cat .ssh/id_rsa.pub
```

显示类似如下的信息：
```cs
ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDQVwWjF3KXmI549jDI0fuCgl+syJjjn55iMUDRRiCd/B+9TwUda3l9WXH5i7RU53QGRCsDVFZxixLOlmXr9E3VSqkf8xXBnHs/5E2z5PIOCN0nxfB9xeA1db/QxPwK4gkHisep+eNHRn9x+DpCYDoSoYQN0nBg+H3uqfOqL42mJ+tqSfkyqbhjBf1kjtDTlBfVCWtI0siu7owm+c65+8KNyPlj5/0AyJ4Aqk1OX2jv+YE4nTipucn7rHwWuowasPU86l+uBsLNwOSb+H7loJvQyhEINX2FS1KnpRU+ld20t07n+N3ErfX5xBAGfxXpoN9BKKSP+RT7rvTeXTVE**** test@runoob.com****
```

**5、创建项目**
在 GitLab 的主页中，点击 Create a project 选项：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-5.png)

点击 Create blank project，设置 Project name 和 Project URL，然后点击 Create project：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-6.png)

本文以 mywork 项目为例进行说明。

**6、添加 SSH key**
在当前 project 页面，点击 Add SSH key：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-7.png)

将公钥文件 id_rsa.pub 中的内容粘贴到 Key 所在的文本框中：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-8.png)

点击 Add key，SSH Key 添加完成后，如下图所示：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-9.png)

复制 Clone 链接，该链接在进行克隆操作时需要使用：
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-10.png)

### 使用GitLab
**1、配置使用 Git 仓库的人员信息，包含用户名和邮箱。**
```cs
git config --global user.name "testname" 
 
git config --global user.email "abc@example.com" 
```

**2、克隆已创建的项目到本地。**
```cs
git clone git@101.132.XX.XX:root/mywork.git
```

![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-11.png)

**3、上传文件到 GitLab 服务器：**
进入到项目目录：
```cs
cd mywork/ 
```

创建需要上传到 GitLab 中的目标文件：
```cs
echo "test" > /home/test/test.sh
```

将目标文件或者目录复制到项目目录下：
```cs
cp /home/test/test.sh ./ 
```

将 test.sh 文件加入到索引中：
```cs
git add test.sh
```

将 test.sh 提交到本地仓库：
```cs
git commit -m "test.sh"
```

将文件同步到 GitLab 服务器上：
```cs
git push -u origin main
```

![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-12.png)

在网页中查看上传的 test.sh 文件已经同步到 GitLab 服务器中:
![](https://www.runoob.com/wp-content/uploads/2015/03/gitlab-13.png)