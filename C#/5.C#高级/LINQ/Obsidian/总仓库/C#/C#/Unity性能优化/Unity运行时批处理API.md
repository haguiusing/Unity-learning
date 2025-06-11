最后是我们通过代码来运行时做批处理操作

Unity有2个强大的API，可以在运行时合并网格。

1,最简单的方法是使用StaticBatchingUtility.Combine。该函数传入一个根游戏对象，并将遍历其所有子对象并将其几何形状合并为一个大块。但是有个限制是，要批处理的所有[子网格](https://zhida.zhihu.com/search?content_id=168438663&content_type=Article&match_order=1&q=%E5%AD%90%E7%BD%91%E6%A0%BC&zhida_source=entity)，导入设置必须允许开启_CPU read/write_
![](https://pica.zhimg.com/v2-265723452931d768a1248630b18f1b4c_b.jpg)

所有物体都在这个节点下StaticBatchingUtility.Combine(BatchedTanks.gameObject);，这样就自动合批了
![](https://pica.zhimg.com/v2-344d4eadae8c1e1139a742d10261be0e_b.jpg)

  

2，第二种方法是使用Mesh.CombineMeshes。此函数间接获取网格列表并创建组合的网格。然后，你可以将该网格分配给mesh filter渲染，这种[合并方式](https://zhida.zhihu.com/search?content_id=168438663&content_type=Article&match_order=1&q=%E5%90%88%E5%B9%B6%E6%96%B9%E5%BC%8F&zhida_source=entity)比较复杂，可以分好几次来讲，推荐大家看一篇文章，讲的比较详细[【Unity3D】 合并mesh那些事 CombineMeshes-CSDN博客](https://blog.csdn.net/tw_345/article/details/79771454)