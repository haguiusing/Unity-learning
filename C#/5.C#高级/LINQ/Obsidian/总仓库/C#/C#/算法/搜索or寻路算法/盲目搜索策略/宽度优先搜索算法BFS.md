[宽度优先搜索算法（BFS）详解（超级详细讲解，附有大图）-CSDN博客](https://blog.csdn.net/aliyonghang/article/details/128724989?ops_request_misc=%257B%2522request%255Fid%2522%253A%25225f0ae0db138e4f65b52a2541fc020628%2522%252C%2522scm%2522%253A%252220140713.130102334..%2522%257D&request_id=5f0ae0db138e4f65b52a2541fc020628&biz_id=0&utm_medium=distribute.pc_search_result.none-task-blog-2~all~top_positive~default-1-128724989-null-null.142^v102^pc_search_result_base8&utm_term=%E5%AE%BD%E5%BA%A6%E4%BC%98%E5%85%88%E6%90%9C%E7%B4%A2&spm=1018.2226.3001.4187)

  
![](https://pic1.zhimg.com/v2-ed7ae4bc6708d01708f6e7b35ee00f00_1440w.jpg)

说白了BFS就是用一个FIFO的队列维护`frontier`中的节点。

我们用BFS的目标是找到目标节点，但是这个**从初始节点通向目标节点**的路径可能有很多条。

很多时候，我们不仅希望找到节点，还希望在搜索的过程中最小化某种指标，这个指标可以用 c(n,a,n′) 描述。

如果满足对任意 n,a,n′ 三元组满足c(n,a,n′)=const>0 ，可以证明BFS是可以找到**最优解**的。

这个证明是很直观的，只需要一层层的向下找就可以了。往往这样假设的 const 会是时间，人数等最小单位。

注意，如果 c(n,a,n′)≠const ，BFS不保证找到最优解。

因为目标节点在d层，所以BFS的时间复杂度和空间复杂度都是

b+b2+b3+⋯+bd=O(bd)

总结：

- Complete：只要 d 是有限的
- Optimal：只要 c(n,a,n′)=const>0
- Time complexity： O(bd)
- Space complexity O(bd)