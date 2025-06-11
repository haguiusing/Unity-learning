
# Human Template 窗口

**人体模板 (Human Template)** 文件 (`*.ht`) 以 YAML 格式存储[保存在 Avatar 窗口中](https://docs.unity3d.com/cn/current/Manual/class-Avatar.html#HumanTemplate)的模型的人形骨骼映射：

![YAML 格式的人体模板文件](https://docs.unity3d.com/cn/current/uploads/Main/classHumanTemplate-YAML.jpg)

YAML 格式的人体模板文件

**Human Template** 窗口将人体模板文件的内容显示为标准 Unity 文本框。

![Human Template 窗口](https://docs.unity3d.com/cn/current/uploads/Main/classHumanTemplate-Inspector.png)

Human Template 窗口

每个分组代表 YAML 文件中的一个条目，其中骨骼映射目标的名称标记为 **First__，而模型文件中的骨骼名称标记为** Second__。

可以使用此属性编辑该文件中的大部分值，但 Unity 会立即更新对文件执行的所有更改。不过，可以在此窗口处于活动状态时撤消任何更改。