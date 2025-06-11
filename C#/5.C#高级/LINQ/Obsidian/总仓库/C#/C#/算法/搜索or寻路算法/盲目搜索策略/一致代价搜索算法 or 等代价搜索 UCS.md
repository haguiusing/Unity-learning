接下来，UCS就是来解决 c(n,a,n′)≠const 的问题的。

UCS与Dijkstra算法的细微差别可以参考

[https://stackoverflow.com/questions/12806452/whats-the-difference-between-uniform-cost-search-and-dijkstras-algorithm​stackoverflow.com/questions/12806452/whats-the-difference-between-uniform-cost-search-and-dijkstras-algorithm](https://link.zhihu.com/?target=https%3A//stackoverflow.com/questions/12806452/whats-the-difference-between-uniform-cost-search-and-dijkstras-algorithm)

![](https://pic3.zhimg.com/v2-2f46e6b42078cb21e74c864e4e4dfd00_1440w.jpg)

UCS和BFS的主要区别是UCS维护了一个**优先队列**，通过这个优先队列保证达到目标节点的时候路径一定是最短的。

这个也好理解，因为从`frontier`取出的节点满足`chooses the lowest-cost node in frontier`，所以如果这个节点是目标节点，那么即便是存在另一个路径也可以通向目标节点，因为**当前走过的路径已经比这条路长了**，又有 c(n,a,n′)>0 ，所以**另一条路径不可能更短**。

实际上，一个更直观的事实是，任何被放入`explored`的节点都**满足最短路径**。

总结：

- Complete：只要 c(n,a,n′)>0
- Optimal：只要 c(n,a,n′)>0