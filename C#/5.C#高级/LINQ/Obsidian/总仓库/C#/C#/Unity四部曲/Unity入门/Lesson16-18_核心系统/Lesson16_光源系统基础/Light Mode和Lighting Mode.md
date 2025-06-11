在光照设置面板中可以控制全局光照是否开启，Realtime Global

Illumination开关控制Realtime光源的实时光照，Baked Global Illumination控制Mixed和Baked二种光源。

![[Pasted image 20240906133332.png]]
Light组件中可用的Light Modes（左），以及Lighting Scene窗口（右）中可用于这些模式的相应设置。 

**1、LightMode下的三种模式**
1）、Realtime实时
Unity 在运行时每帧计算并更新实时灯光。没有预先计算实时灯光。

2）、Mixed混合
一种提供烘焙和实时功能的混合模式，例如对灯光的间接照明进行烘焙，同时对直接照明进行实时计算。场景中混合模式灯光的行为和性能影响取决于我们全局混合照明模式的选择。

Mixed Lights下的子模式：Baked Indirect、Shadowmask、Distance

Shadowmask、Subtractive。

3）、烘焙
Unity 在运行之前预先计算Baked Lights 的光照，灯光的直接和间接照明被烘焙成光照贴图。设置为该模式后，该灯光在程序运行时将不占用性能成本，同时，将生成的光照贴图应用到场景中的成本也较低。

**2、混合光照模式**
在完全烘焙的情况下，对于静态物体而言，所有的直接光和间接光信息都被烘焙到了光照贴图上。虽然是性能消耗最低的方法，但是代价是损失了一些效果。因此Unity提供了混合光照模式，以达到效果和性能的平衡。目前有三种混合模式可以选择，如下图所示。
![[Pasted image 20240906133551.png]]

Lighting Mode
1）Baked Indirect
这种模式只烘焙间接光，直接光照和阴影都实时计算。
![[Pasted image 20240906133707.png]]
Baked Indirect
![[Pasted image 20240906133730.png]]
移动静态物体，阴影会跟随移动  (除了立方体，都是静态物体)

2) Shadowmask
这种模式除了烘焙间接光照外，还会把静态物体的的阴影烘焙到Shadowmask中。
![[Pasted image 20240906133754.png]]
Shadowmask
![[Pasted image 20240906133812.png]]
移动最上方的立方体（非静态），阴影会跟随移动
![[Pasted image 20240906133825.png]]
更换shader之后，支持了对Shadowmask的支持 

3) Subtractive
这种模式下，静态物体的直接光照和阴影都会被烘焙到光照贴图。
![[Pasted image 20240906133851.png]]
 Subtractive
![[Pasted image 20240906133901.png]]
移动静态物体，阴影不会移动

3、灯光模式在不同光照模式下的可用性及性能对比
![[Pasted image 20240906133915.png]]
Lighting面板参数设置
![[Pasted image 20240906133959.png]]
性能对比结果

注：Baked Global Illumination + Baked为Baked Global Illumination勾选，Realtime Global Illumination不勾选，Light Mode为Baked,可用表示该灯光被当作Mixed灯光来使用（因为Realtime Global Illumination+Baked和Realtime Global Illumination+Realtime烘焙的结果是一样的，前者Backed光源相当于Realtime光源，产生的实时阴影）。光照贴图的大小指的是：Lighting窗口最底下显示的大小。SetPass Calls、Draw Calls、Used Total是在移动手机（SM-G8508S）下测试的数据。

综上所示，烘焙灯光会占用较多的内存(RAM+HDD)，但是相应的DrawCall会比较低，实时灯光会占用较多的GPU（有时是CPU）资源。需要注意的一个是Baked Global Illumination+Realtime,不仅会生成光照贴图（32MB），而且DrawCalls数也很高（这种模式下Lighting Mode的三种模式：Baked Indirect、Shadowmask、Subtractive是没区别的），项目中应该要避免这种模式的组合。