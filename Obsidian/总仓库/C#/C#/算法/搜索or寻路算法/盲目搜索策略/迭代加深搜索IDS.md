IDS 就是在DLS的基础上，不断的将常数l扩大，从而增加搜索深度。

![](https://pic4.zhimg.com/v2-8e03d261f706bc5e5c259a680236cfdb_1440w.png)

![](https://picx.zhimg.com/v2-3a1b726a13fca6b57c17e0794fe4c019_1440w.jpg)

IDS弥补了深度受限搜索的缺点，它允许算法不断的增加深度来寻找目标节点。

它和BFS看起来很像，而且IDS似乎在实现上产生了很大的重复，实际上IDS比BFS的空间复杂度小的多，但是时间复杂度相对大一些。

IDS的时间和空间复杂度分别是 O(bd) 和 O(bd) ，注意 O(bm) 的时间复杂度是相当高的。