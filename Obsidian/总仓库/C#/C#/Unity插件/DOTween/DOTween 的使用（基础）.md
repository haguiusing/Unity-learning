（一）使用前注意事项
1. 引入命名空间
要用插件库首先得需要引入，所以在使用DOTween前需要引入对应的命名空间：

```cs
using DG.Tweening;
```

2. 进行初始化
然后就是初始化，我们先看一下官方是什么描述的。
![[Pasted image 20241128230006.png]]

英语不好的直接上翻译（我英语不好也是用的翻译😴），大致意思就是说：第一次创建tween时，DOTween将使用默认值自动初始化。如果您更喜欢自己初始化它（推荐），请在创建任何tween之前调用此方法一次（之后调用它将无效）。考虑到您仍然可以通过使用DOTween的全局设置随时更改所有init设置您可以选择将SetCapacity链接到Init方法，该方法允许设置最大Tweeners/Sequences初始容量（这与稍后调用DOTween.SetTweensCapacity相同）。

它可以自动初始化，也可以手动调用DOTween.Init();进行初始化，他还有三个可选参数，但是一般使用的时候可以直接DOTween.Init();就可以。

```cs
DOTween.Init(bool recycleAllByDefault = false, bool useSafeMode = true, LogBehaviour logBehaviour = LogBehaviour.ErrorsOnly)

DOTween.Init();
```

我们来看下这些参数的作用：（动画、过渡、渐变、补间都是一个意思）
`recycleAllByDefault`：如果设为true，所有创建的动画在调用完后被回收，即不会直接被销毁，而是会放入对象池中等待下次重用，而不是每次创建新的动画。
`useSafeMode`：如果设为true，动画会稍微慢一些，但更加安全，允许DOTween在动画运行时自动处理目标被销毁破坏之类的事情，让动画仍然可以执行，不受其影响。
`logBehaviour：根据选择的模式，DOTween将只记录错误、错误和警告，或者所有内容加上附加信息。

这是官方对初始化API的描述，想了解更清楚的话可以看一下。（蓝底参数表示可选的意思）
![[Pasted image 20241128231708.png]]

3. 清除遗留
什么是清除遗留？

就是如果游戏对象上的当前DOTween动画没播放完的时候，在游戏对象上再次创建了一个动画，会导致动画创建或者播放报错。就好比我们在游戏对象上添加了事件监听，在游戏对象销毁的时候需要移除事件，都是相同的逻辑。所以在每次执行动画之前，先.DOKill()杀掉上一个动画。
```cs
//先去掉上一个动画进程
transform.DOKill();
//再创建新的动画
transform.DOMove();
```

4. 设置timeScale对动画的影响
正常情况下，也就是默认情况，当你设置Time.timeScale = 0 暂停游戏时，Tween动画也会被暂停，但是在特殊情况下，我们需要在游戏暂停的时候，动画要继续执行，这个时候在创建的动画后加上 .SetUpdate(true) 方法就可以，这样在游戏暂停的时候动画依旧在运行，直到动画结束。
```cs
transform.DOMoveX(5f, 2).SetUpdate(true);
```

5. 类型介绍
我们创建的动画都会有一个返回值，返回值的类型是 Tween ，表示补间动画，我们可以用这个类型声明一个变量来接收创建的动画，用于动画的一些扩展，灵活性更好。
```cs
Tween tween = transform.DOMoveX(5f, 2).SetUpdate(true);
```