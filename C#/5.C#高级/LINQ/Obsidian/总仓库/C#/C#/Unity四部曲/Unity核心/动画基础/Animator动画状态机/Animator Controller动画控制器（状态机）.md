[Animator Controller动画控制器（状态机）](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%C2%B7%E6%A0%B8%E5%BF%83/%E5%8A%A8%E7%94%BB%E5%9F%BA%E7%A1%80/Animator%E5%8A%A8%E7%94%BB%E7%8A%B6%E6%80%81%E6%9C%BA/Lesson32_Animator%20Controller%E5%8A%A8%E7%94%BB%E6%8E%A7%E5%88%B6%E5%99%A8_%E7%8A%B6%E6%80%81%E6%9C%BA.cs)
![[Pasted image 20240922173142.png]]
![[Pasted image 20240922172045.png]]
# **Animation Layers(3D动画相关)**

使用Layer可以用来管理角色的不同身体部位。比如下半身用于行走或跑步，上半身用于射击或投掷物体。

可以从Animator左上角的Layer标签中管理Layer。
![[Pasted image 20240922173216.png]]
**Weight** 这一层的权重，0代表该层[权重](https://zhida.zhihu.com/search?q=%E6%9D%83%E9%87%8D&zhida_source=entity&is_preview=1)是0（该层不生效），1代表该层权重为1（该层中的动画能完全表现）(animator有一个setLayerWeight方法，等于是设置成0就图层失效，1就图层激活)

**Mask** 设置该Layer能控制身体的哪部分，设置后该Layer上面会显示一个M的小图标。

**Blending** 和其他层混合的模式。
- _Override_ 覆盖上面的层中对应Mask的部位
- _Additive_ 会加在之前Layer的动画之上

**Sync** 复用其他层中的[状态机](https://zhida.zhihu.com/search?q=%E7%8A%B6%E6%80%81%E6%9C%BA&zhida_source=entity&is_preview=1)。

IK是Inverse Kinematics的缩写，也就是[反向动力学](https://zhida.zhihu.com/search?q=%E5%8F%8D%E5%90%91%E5%8A%A8%E5%8A%9B%E5%AD%A6&zhida_source=entity&is_preview=1)。大多数动画是通过旋转骨骼来实现的。子骨骼的位置跟着父骨骼的旋转而改变，因此关节链的终点可以根据前面的各个骨骼的角度和相对位置确定。这种构成[骨骼动画](https://zhida.zhihu.com/search?q=%E9%AA%A8%E9%AA%BC%E5%8A%A8%E7%94%BB&zhida_source=entity&is_preview=1)的方法称为正向动力学。

## **Avatar Mask**
用来设置该Layer的动画会影响角色的哪一部分的遮罩。

### **创建Avatar Mask**
在Project窗口中右键，**Create > Avatar Mask**点击后会创建一个AvatarMask文件，此时可以对文件命名。

### **编辑AvatarMask**
AvatarMask有两种定义身体遮罩的方式：
- 通过Humanoid身体映射图
- 通过Transform层次结构选择包含或不包含的骨骼
### **Humanoid**
如果你的动画是人形动画，建议用这一种方式可以快速设置AvatarMask。
![](https://picx.zhimg.com/80/v2-fa1c4ce10fbcff37a3550e9c554a3f79_720w.webp)
身体映射图包含以下几部分：
- 头部
- 左臂
- 右臂
- 左手
- 右手
- 左腿
- 右腿
- Root（脚下的圆形阴影部分）
可以通过鼠标点击每一部分，绿色代表动画可以影响这一部分，红色代表动画不会影响。在[空白处](https://zhida.zhihu.com/search?q=%E7%A9%BA%E7%99%BD%E5%A4%84&zhida_source=entity&is_preview=1)点击可以全选/全不选。

手部和脚部的IK可以开关，表示该部分的IK曲线是否参与动画混合。`IK又出现了，一会去问问大智`

### **Transform**
如果动画没有使用Humanoid，或者你想更精细的控制遮罩，你可以通过Transform层级结构来控制每一个骨骼。
1、选择一个Avatar（动画模型的Avatar）  
2、点击**Import Skeleton**按钮。avatar的层级结构会显示出来。  
3、可以设置对应的骨骼是否受动画控制
### **其他用途**

在模型导入设置的Animation页签中，也可以设置Mask，设置后只会导入对应Mask的动画数据。

**在这设置Mask的好处是：可以减少内存占用和CPU占用。因为不需要的身体部位的动画曲线不会被加载，并且不会参与计算。**

# Parameters
![[Pasted image 20240922173159.png]]

| Float   |          |       |
| ------- | -------- | ----- |
|         | Greater  | 大于    |
|         | Less     | 小于    |
| Int     |          |       |
|         | Greater  | 大于    |
|         | Less     | 小于    |
|         | Equals   | 等于    |
|         | NotEqual | 不等于   |
| Bool    |          |       |
|         | true     | 是     |
|         | false    | 否     |
| Trigger |          | 触发器条件 |
