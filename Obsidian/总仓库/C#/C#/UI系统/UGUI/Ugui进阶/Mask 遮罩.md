[Mask 遮罩](file://assets/Scripts/UGUI/Lesson21_Mask/Lesson21_Mask.cs)

# 遮罩 (Mask)
__遮罩不是可见的 UI 控件，而是一种修改控件子元素外观的方法。遮罩将子元素限制（即“掩盖”）为父元素的形状。因此，如果子项比父项大，则子项仅包含在父项以内的部分才可见。

![由面板掩盖的大型图像的部分（滚动条是单独的控件）](https://docs.unity3d.com/cn/2023.2/uploads/Main/MaskCtrlExample.png)
由面板掩盖的大型图像的部分（滚动条是单独的控件）

## 属性
![[Pasted image 20241204131924.png]]

|**_属性：_**|**_功能：_**|
|---|---|
|**Show Graphic**|是否应在子对象上使用 Alpha 绘制遮罩（父）对象的图形？|

## 描述
遮罩的常见用法是使用面板 (Panel) 对象（菜单：__GameObject > Create UI > Panel__）作为“框架”显示大型图像的一小部分。为实现此目的，可先将图像设置为面板对象的子项。应调整图像的位置，使应该可见的区域直接位于面板区域的后面。

![面板区域以红色显示，子项图像位于后面](https://docs.unity3d.com/cn/2023.2/uploads/Main/MaskDisabled.svg)
面板区域以红色显示，子项图像位于后面

然后，将一个遮罩组件添加到面板。面板外面的子图像区域将变得不可见，因为这些区域被面板的形状所掩盖。

![掩盖的区域显得暗淡，但实际是不可见的](https://docs.unity3d.com/cn/2023.2/uploads/Main/MaskEnabled.svg)
掩盖的区域显得暗淡，但实际是不可见的

如果图像随后移动，则只有面板暴露的部分可见。可通过[滚动条](https://docs.unity3d.com/cn/2023.2/Manual/script-Scrollbar.html)来控制移动，从而创建可滚动的地图查看器之类的效果。

## 实现
应使用 GPU 的模板缓冲区来实现遮罩。

_第一个遮罩元素将 1 写入模板缓冲区。_ 遮罩下面的所有元素在渲染时进行检查，仅渲染到模板缓冲区中有 1 的区域。 *嵌套的遮罩会将增量位掩码写入缓冲区，这意味着可渲染的子项需要具有要渲染的逻辑和模板值。

# RectMask2D
![[Pasted image 20241204132212.png]]
**RectMask2D** 是一个类似于**遮罩 (Mask)** 控件的遮罩控件。遮罩将子元素限制为父元素的矩形。与标准的遮罩控件不同，这种控件有一些限制，但也有许多性能优势。

## 描述
RectMask2D 的一个常见用途是显示较大区域的小部分。使用 RectMask2D 可框定此区域。

RectMask2D 控件的局限性包括：
- 仅在 2D 空间中有效
- 不能正确掩盖不共面的元素

RectMask2D 的优势包括：
- 不使用模板缓冲区
- 无需额外的绘制调用
- 无需更改材质
- 高速性能

# Mask和RectMask2D区别
[Unity 3D - Mask和RectMask2D区别-CSDN博客](https://blog.csdn.net/yu__jiaoshou/article/details/102742784)
区别1:
Mask主要处理不规则图形遮罩效果
RectMask2D只能做矩形遮罩.
 
区别2:
Mask需要一个Image来当作遮罩区域,子节点在Image[渲染区域]才会显示
RectMask2D以自身RectTransform为裁剪区域,子节点在[RectTransform区域]内显示
