![[Pasted image 20241204131611.png]]
[[过渡选项]]
[[导航选项]]
# 可选基类 (Selectable Base Class)
可选类是所有交互组件的基类，可处理共同的项。

|**_属性：_**|**_功能：_**|
|---|---|
|**Interactable**|此属性确定该组件是否接受输入。此属性设置为 false 时，交互被禁用，过渡状态也将设置为禁用状态。|
|**Transition**|在可选组件中，有几个[过渡选项](https://docs.unity3d.com/cn/2023.2/Manual/script-SelectableTransition.html)，具体取决于可选组件的当前状态。不同的状态包括：正常、突出显示、按下和禁用。|
|**Navigation**|还有许多[导航选项](https://docs.unity3d.com/cn/2023.2/Manual/script-SelectableNavigation.html)可用于控制如何实现控件的键盘导航。|