![[Lesson34_Scene窗口拓展_Gizmos_Gizmos是什么及响应函数.cs]]

### Gizmos类是用来做什么的
Gizmos和Handles一样，是用来让我们拓展Scene窗口的。相对于Handles，Gizmos主要专注于绘制辅助线、图标、形状等，而Handles主要用来绘制编辑器控制手柄等。

### Gizmos响应函数
在继承MonoBehaviour的脚本中实现以下函数，便可以在其中使用Gizmos来进行图形图像的绘制：
#### OnDrawGizmos()
- 在每帧调用，绘制的内容随时可以在Scene窗口中看见。
```cs
private void OnDrawGizmos()
{
    Debug.Log("Gizmos");
}
```
#### OnDrawGizmosSelected()
- 仅当脚本依附的GameObject被选中时才会每帧调用绘制相关内容。
```cs
private void OnDrawGizmosSelected()
{
    Debug.Log("Gizmos2");
}
```
