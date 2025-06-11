GPU Instancing它可用于非静态对象，与静态批处理相比，它不会激增内存使用量，并且不需要对象是静态的，非常强大。

我们需要在对象的材质那里设置GPU Instancing，如果你有多个具有相同网格和材质的对象，那么Unity对它们将自动进行批处理。
![](https://pica.zhimg.com/v2-5a807c5c9fb33c982ff966175a1f3280_b.jpg)

![](https://pic1.zhimg.com/v2-74c7c8e273d9e5a6ea44ecd095f875b2_b.jpg)
这时对象是非静态的，DC还是1

GPU实例化让你可以非常高效地绘制相同的网格几次。Unity通过向GPU传递转一个Transform列表来做到这一点。毕竟，每块GameObject都有自己的位置，旋转和缩放。

但是，创建Transform列表会降低性能。如果在游戏过程中没有物体移动/旋转/缩放，则只需支付一次此开销。但是，如果对象每帧都更改一次，则需要每帧支付一次开销，这一点需要特别注意。所以如果需要在Update修改物体的位置，旋转和缩放就不要使用GPU Instancing。