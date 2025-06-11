![[Pasted image 20250416233433.png]]
我们从文件夹结构可以看出，Layout 主要功能都是布局方面，包括横向布局，纵向布局，方格布局等等。总共12个文件，有9个带有 Layout 字样，它们都是处理布局的。

除了处理布局内容以外，其余3个文件，CanvasScaler，AspectRatioFitter，ContentSizeFitter 则是调整自适应功能。

从 ContentSizeFitter，AspectRatioFitter 都带有 Fitter 字样可以了解到，它们的功能都是处理自适应。其中 ContentSizeFitter 处理的是内容自适应的， 而 AspectRatioFitter 处理的是朝向自适应的，包括以长度为基准的，以宽度为基准的，以父节点为基准的，以外层父节点为基准的自适应，四种类型的自适应方式。

另外 CanvasScaler 做的功能非常重要，它操作的是 Canvas 整个画布针对不同屏幕进行的自适应调整。
