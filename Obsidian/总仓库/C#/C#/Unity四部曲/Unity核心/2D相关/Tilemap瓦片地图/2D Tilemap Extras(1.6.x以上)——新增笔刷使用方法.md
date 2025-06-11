[2D Tilemap Extras——新增笔刷使用方法](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%C2%B7%E6%A0%B8%E5%BF%83/2D%E7%9B%B8%E5%85%B3/Tilemap%E7%93%A6%E7%89%87%E5%9C%B0%E5%9B%BE/Lesson26_%E5%AE%98%E6%96%B9%E6%89%A9%E5%B1%95%E5%8C%85_%E6%96%B0%E5%A2%9E%E7%AC%94%E5%88%B7%E7%B1%BB%E5%9E%8B.cs)
# 2021版后移除了原有的Prefab Brush、Prefab Ramdom Brush、Ramdom Brush
没法Project窗口创建(简单地在源代码上加[CreateAssetMenu...],虽然可以创建对应的资产文件，但是没法同步到Tile Palette右下角的下拉列表)，改为在Tile Palette中的选择对应Brush后，需要先进行对应的设置再进行使用。
![[Pasted image 20240921213108.png]]

# 1.GameObject Bursh
可以吸取场景中的GameObject，再绘制。
![[Pasted image 20240921213038.png]]

| Cells           |     | 表示选择的格数，每一格可存放一个GameObject。(无法直接修改)<br>修改方法一：改变Size的X、Y、Z；<br>修改方法二：在对应类型的Palette上框选范围，只要选择GameObject Bursh，Palette上的编辑功能便会关闭。 |
| --------------- | --- | ------------------------------------------------------------------------------------------------------------------------------ |
| Size            |     | X、Y、Z相乘，表示选中的坐标大小，修改可决定选择的Cells的数量                                                                                             |
|                 | X   |                                                                                                                                |
|                 | Y   |                                                                                                                                |
|                 | Z   |                                                                                                                                |
| Pivot           |     | 绘制的图片相对于鼠标的偏移量                                                                                                                 |
|                 | X   |                                                                                                                                |
|                 | Y   |                                                                                                                                |
|                 | Z   |                                                                                                                                |
| Anchor          |     | 绘制的图片相对于选中网格的偏移量                                                                                                               |
|                 | X   |                                                                                                                                |
|                 | Y   |                                                                                                                                |
|                 | Z   |                                                                                                                                |
| ScenceRoot Grid |     | 显示当前所绘制的Grid的相关参数，只在场景根节点(Paint on SceneRoot)可编辑                                                                               |
| Lock Z Postion  |     | 锁定Z轴                                                                                                                           |
切换网格或改变网格会删除GameObject，如果GameObject是场景上的拖进去的，场景上的该物体会被删除。

# 2.Group Bursh
选择Group Bursh，Palette上的编辑功能仍会工作。
设置Gap或Limit需要重新选择格子才会更新
可以吸取场景中的Tiles，再绘制。

| 财产    | 功能                                                                                                                     |                                      |
| ----- | ---------------------------------------------------------------------------------------------------------------------- | ------------------------------------ |
| Gap   | 此值表示选取的 Tiles 之间必须包含的最小单元格数。只有至少相隔这么多个单元格的 Tile 才会被 Brush 选取并放置在组中。将此值设置为 0 可拾取组中彼此直接相邻的所有瓦片。（决定不相邻的 Tiles 是否也进入Group） | ![[Pasted image 20240921225815.png]] |
| Limit | 此值表示初始选取位置周围的最大单元格数。只有此单元格范围内的 Tile 才会被 Brush 选取并放置在组中。（决定Group的范围）                                                    | ![[Pasted image 20240921225848.png]] |

# 3.Line Bursh
选择Line Bursh，Palette上的编辑功能仍会工作。
可以吸取场景中的Tiles，再绘制。

| **Line Start Active** | 指示 Line Brush 是否已开始绘制线条。                   |                                      |
| --------------------- | ------------------------------------------ | ------------------------------------ |
| **Fill Gaps**         | 确保连接线起点和终点的所有 Tiles 之间存在正交连接。<br>左边为启用正交连接 | ![[Pasted image 20240921231135.png]] |
| **Line Start**        | 线路的当前起点。                                   |                                      |

# 4.Random Brush
选择Random Brush，Palette上的编辑功能仍会工作。
可以吸取场景中的Tiles，再绘制。

| **Pick Random Tiles**   | 启用此属性，可从当前选择中选取 Tiles 作为随机 Tile Set。<br>使当前Palette选择中选取的 Tiles 在绘制时具有随机性。                                        |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------- |
| **Add To Random Tiles** | 启用此属性可将选取的瓦片集添加到现有瓦片集，而不是替换它们。<br>不勾选：将选取范围内的 Tiles 作为随机 Tile Set，更改范围替换；<br>勾选：将选取的 Tiles 均进入 Tile Set，更改范围不替换。 |
| **Tile Set Size**       | 设置此画笔绘制的一个Tile Set 随机范围的大小。                                                                                      |
| **Number of Tiles**     | 所有 Tile Sets 的数量。                                                                                                |
| **Tile Set**            | 一个 Tile Set 的随机范围                                                                                                |
| **Tiles X**             | Tile Set 中 Tiles                                                                                                 |

