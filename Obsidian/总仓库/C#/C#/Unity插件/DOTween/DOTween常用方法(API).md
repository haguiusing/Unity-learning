三：DOTween常用方法介绍—DOTween官网
DOTween的通用方式，也是DOTween快捷方式的内部实现，当没有快捷方式的情况下，通用方式可以补间任何东西
```cs
//DOTween(()=>要改变的属性，自定义的插值变量=>要改变的属性=自定义的插值变量，目标值，完成动画的时间)
DOTween.To(() => transform.position, doPos => transform.position = doPos, new Vector3(1, 1, 1), 2);
```

# Rigidbody
#### 1. Move 移动过渡
物体移动到指定位置。(世界坐标)
```cs
//DOMoveX(目标值，完成动画的时间，[是否计算出的插值都捕捉为整数]=false)
transform.DOMove(new Vector3(10f, 2f, 0), 2f, false);
transform.DOMove(Vector3 to, float duration, bool snapping)
	参数说明：
		Vector3 to               目标位置
		float   duration         动画持续时间
		bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

沿着X/Y/Z轴移动到指定位置。(世界坐标)
```cs
transform.DOMoveX(10, 2f, false);
transform.DOMoveY(10, 2f, false);
transform.DOMoveZ(10, 2f, false);
transform.DOMoveX/DOMoveY/DOMoveZ(float to, float duration, bool snapping)
	参数说明:
		float   to				  要移动到的坐标值
		float   duration         动画持续时间
		bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

物体移动到指定位置。(自身坐标)
```cs
transform.DOLocalMove(new Vector3(10f, 2f, 0), 10f, false);
transform.DOLocalMove(Vector3 to, float duration, bool snapping)
 	参数说明：
 		Vector3 to               要移动到的位置
		float   duration         动画持续时间
		bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

沿着X/Y/Z轴移动到指定位置。(自身坐标)
```cs
transform.DOLocalMoveX(10, 2f, false);
transform.DOLocalMoveY(10, 2f, false);
transform.DOLocalMoveZ(10, 2f, false);
transform.DOLocalMoveX/DOLocalMoveY/DOLocalMoveZ(float to, float duration, bool snapping)
	参数说明：
		float   to				  要移动到的轴的坐标
		float   duration         动画持续时间
		bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

跳跃到指定位置。（世界坐标）
```cs
transform.DOJump(new Vector3(5, 0, 0), 10, 3, 1f, false);
transform.DOJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping)
	参数说明：
		 Vector3 endValue         最终要跳跃到的位置
		 float   jumpPower        跳跃的强度，决定跳跃的高度(当前位置Y加上该值)
		 int     numJumps         跳跃的次数
		 float   duration         动画持续时间
		 bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

跳跃到指定位置。（自身坐标）
```cs
transform.DOLocalJump(new Vector3(10, 0, 0), 10, 3, 2f, false);
transform.DOLocalJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping)
	参数说明：
		 Vector3 endValue         最终要跳跃到的位置
		 float   jumpPower        跳跃的强度，决定跳跃的高度(当前位置Y加上该值)
		 int     numJumps         跳跃的次数
		 float   duration         动画持续时间
		 bool    snapping         默认为false，设为true时平滑地将所有值变为整数，即每次移动整数值。
```

Rigidbody和Rigidbody2D也有上面的一些方法。  
![在这里插入图片描述](https://i-blog.csdnimg.cn/direct/d131471232084d5384029393b019a83d.png)

#### 2. Rotate 旋转过渡
旋转到指定的值（根据欧拉角），世界坐标
```cs
transform.DORotate(new Vector3(0, 90, 0), 0.1f, RotateMode.Fast);
transform.DORotate(Vector3 to, float duration, RotateMode mode)
	参数：
		Vector3		to				旋转的目标值
		float		duration		旋转过渡时间
		RotateMode	mode
			Fast				（默认值）采用最短路径，即旋转不会超过360°
			FastBeyond360		旋转超过360°
			WorldAxisAdd		与transform.Rotate(new Vector3(20, 0, 0)，Space.World)作用类似，最终值始终被视为相对值，相对于世界坐标系
			LocalAxisAdd		与transform.Rotate(new Vector3(20, 0, 0)，Space.Self)作用类似，最终值始终被视为相对值，相对于游戏对象的局部坐标系
```

旋转到指定的值（四元数），世界坐标
```cs
Quaternion targetRotation = Quaternion.Euler(0, 90, 0);//表示绕 Y 轴旋转 90 度
transform.DORotateQuaternion(targetRotation, 1f);
transform.DORotateQuaternion(Quaternion to, float duration)
	参数：
		Quaternion	to				要旋转到的目标值四元数
		float		duration		旋转的过渡时间
```

旋转到指定的值（根据欧拉角），自身坐标
```cs
transform.DOLocalRotate(new Vector3(0, 90, 0), 0.5f, RotateMode.Fast);
transform.DOLocalRotate(Vector3 to, float duration, RotateMode mode)
	参数：
		Vector3		to				旋转的目标值
		float		duration		旋转的过渡时间
		RotateMode	mode
			Fast				（默认值）采用最短路径，即旋转不会超过360°
			FastBeyond360		旋转超过360°
			WorldAxisAdd		与transform.Rotate(new Vector3(20, 0, 0)，Space.World)作用类似，最终值始终被视为相对值
			LocalAxisAdd		与transform.Rotate(new Vector3(20, 0, 0)，Space.Self)作用类似，最终值始终被视为相对值
```

旋转到指定的值（四元数），自身坐标
```cs
Quaternion targetRotation = Quaternion.Euler(0, 90, 0);//表示绕 Y 轴旋转 90 度
transform.DOLocalRotateQuaternion(targetRotation, 0.5f);
transform.DOLocalRotateQuaternion(Quaternion to, float duration)
	参数：
		Quaternion	to				要旋转到的目标值四元数
		float		duration		旋转的过渡时间
```

朝向目标方向，Look At看向谁，即旋转目标使其朝向指定的位置方向。
```cs
transform.DOLookAt(new Vector3(0, 90, 0), 0.5f, AxisConstraint.None, Vector3.up);
transform.DOLookAt(Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3 up = Vector3.up)
	参数：
		 Vector3			 towards			旋转目标值
		 float	    		 duration			旋转总用时
		 AxisConstraint		 axisConstraint 	旋转最终轴约束，只旋转此轴。（默认值为AxisConstraint.None）
		 Vector3             up                 定义向上方向的矢量。（默认值为Vector3.up）
```

朝向目标方向，Look At看向谁，即旋转目标使其朝向指定的位置方向，每帧更新 lookAt 位置（与此相反，当补间开始时，只计算一次 lookAt 旋转）
```cs
transform.DODynamicLookAt(new Vector3(0, 90, 0), 0.5f, AxisConstraint.None, Vector3.up);
transform.DODynamicLookAt(Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3 up = Vector3.up)
	参数：
		 Vector3			 towards			旋转目标值
		 float	    		 duration			旋转总用时
		 AxisConstraint		 axisConstraint 	旋转最终轴约束，只旋转此轴（默认值为AxisConstraint.None）
		 Vector3             up                 定义向上方向的矢量（默认值为Vector3.up）
```

#### 3. Scale 缩放过渡
将物体放大（缩小）到指定的倍数或大小
```cs
transform.DOScale(new Vector3(1.5, 1.5, 1.5), 0.5f);
transform.DOScale(2f, 0.5f);
transform.DOScale(float/Vector3 to, float duration)
	参数：
		float/Vector3 			to					浮点数为倍数，向量为指定大小
		float 					duration			放大/缩小总消耗时间
```

对物体的某一轴方向进行放大（缩小）
```cs
transform.DOScaleX/DOScaleY/DOScaleZ(1.5f, 1.5f);
transform.DOScaleX/DOScaleY/DOScaleZ(float to, float duration)
	参数：
		float					to					放大到的倍数
		float 					duration			放大/缩小总消耗时间
```

#### 4. Punch 冲击
```cs
受到冲击后的回弹效果
transform.DOPunchPosition();
transform.DOPunchPosition(Vector3 punch, float duration, int vibrato, float elasticity, bool snapping)
	参数：
		Vector3					punch 				要被击打到的最远位置（相对值，相对于局部坐标）
		float					duration			总持续时间
		int						vibrato				物体振动频率
		float					elasticity			值一般在0到1之间，0表示起点到冲击方向的震荡，1表示为一个完整的震荡，可能会超过起点，个人感觉后者效果更好。
		bool					snapping			是否进行平滑插值

受到冲击后旋转效果
transform.DOPunchRotation()
transform.DOPunchRotation(Vector3 punch, float duration, int vibrato, float elasticity)
	参数：
		Vector3					punch 				要被击打到的角度（相对值，相对于局部坐标）
		float					duration			总持续时间
		int						vibrato				物体旋转频率
		float					elasticity			值一般在0到1之间，0表示最初角度到最大角度的旋转，1表示为一个完整的旋转，可能会超过最远角度。

实现一个弹性效果，反复弹，最终复原。
transform.DOPunchScale()
transform.DOPunchScale(Vector3 punch, float duration, int vibrato, float elasticity)
	参数
		Vector3					punch 				弹到的大小
		float					duration			总持续时间
		int						vibrato				物体放缩频率
		float					elasticity			值一般在0到1之间，0表示最初角度到目标大小的放缩，1会产生负值，出现警告。
```

#### 5. Text 文本动画
如果文本框内之前没有文字，在2s内逐字显示文字。如果原先有文字，则逐字覆盖掉原先文字，显示新文字，就像这样。
```cs
GetComponent<Text>().DOText("今天天气真不错!", 2);
```

```cs
//DORotate(目标值，完成动画的时间，[旋转模式，默认Fast模式旋转不会超过360度，FastBeyond360模式旋转将超过360度]=Fast)
transform.DORotate(new Vector3(0, 0, 90), 2);
 
//DORotateQuaternion(目标值，完成动画的时间)——此方法不推荐使用
transform.DORotateQuaternion(new Quaternion(0.1f, 0.1f, 0.1f, 0.1f), 2);
 
//DOLookAt(目标值，完成动画的时间，[旋转的最终轴约束]=None)
transform.DOLookAt(new Vector3(1, 1), 2);
```

——缩放
```cs
//DOScale(目标值，完成动画的时间)
transform.DOScale(new Vector3(2, 2, 2), 2);
```

——跳跃
```cs
//DOJump(目标值，跳跃的力量-Y轴的偏移量，跳跃的次数，完成动画的时间，[是否计算出的插值都捕捉为整数]=false)
transform.DOJump(new Vector3(10, 0, 0), 10, 10, 2);
```

——冲击与震动
```cs
//DOPunchPosition(目标值，完成动画的时间，[冲击次数]=10，[弹力，0表示在起始位置范围冲击，1表示在目标位置范围冲击]=1，[是否计算出的插值都捕捉为整数]=false)
transform.DOPunchPosition(new Vector3(10, 0, 0), 2);
transform.DOPunchRotation(new Vector3(0, 0, 90), 2);
transform.DOPunchScale(new Vector3(2, 2, 3), 2);

//DOShakePosition(完成动画的时间，[震动强度-Vector3或者float都可以]=1，[震动次数]=10，[随机性]=90，[是否淡出]=true，[是否计算出的插值都捕捉为整数]=false)
transform.DOShakePosition(2);
transform.DOShakeRotation(2);
transform.DOShakeScale(2);
```

——Image与Text
```cs
//DOFade(目标值，完成动画的时间)
img.DOFade(0, 2);
img.DOColor(Color.blue, 2);
 
//DOText(目标值，完成动画的时间，[是否正确解释富文本]=true，[加密模式]=None)
txt.DOText("DOTween文字",2);
```

——相机

camera.DOAspect(宽高比的值，改变到指定宽高比需要的时间);
camera.DOColor(要改变到的指定颜色，改变到指定颜色需要的时间);
camera.DOFarClipPlane(要改变到的远切面的值，改变到指定远切面的值需要的时间);
camera.DONearClipPlane(要改变到的近切面的值，改变到指定近切面的值需要的时间);
camera.DOFieldOfView(要改变到的视野范围的值（透视相机），改变到指定视野范围的值需要的时间); 
camera.DOOrthoSize(要改变到的视野范围的值（正交相机），改变到指定视野范围的值需要的时间);
camera.DOPixelRect(显示的相机范围（用多个相机实现分屏效果），改变到指定视野范围的值需要的时间);
camera.DORect(显示的相机范围（用多个相机实现分屏效果0-1比例），改变到指定视野范围的值需要的时间);
camera.DOShakePosition(持续时间，[震动强度]，[震动次数]，[震动的随机性]);
camera.DOShakeRotation(持续时间，[震动强度]，[震动次数]，[震动的随机性]);


——DOTween的一些设置

//SetLoops(循环次数，[循环类型]=Restart)——设置为-1则无限循环
tween.SetLoops(3);
 
//SetAutoKill([动画播放完是否就被杀死]=true)——为了节约性能
tween.SetAutoKill(false);
 
//SetEase(动画缓动类型)
tween.SetEase(Ease.Flash)
DoTween缓动动画示例：http://robertpenner.com/easing/easing_demo.html
DoTween缓动动画说明：https://blog.csdn.net/yy763496668/article/details/78215014

tween.From([是否为一个增量运动]);
tween.SetDelay(延迟的时间);
tween.SetSpeedBased([是否以速度为基准]);
tween.SetId("设置的ID名");
tween.SetRecyclable(是否回收);
tween.SetRelative(是否为一个增量动画);
tween.SetUpdate(Update类型，[是否忽略时间缩放]);


——DOTween的一些方法

//Play——播放（只能播一次,PlayForward和PlayBackwards可以依次轮换播放无数次）
tween.Play();
 
//Pause——暂停
tween.Pause();
 
//PlayForward——正播（必须设置SetAutoKill为false）
tween.PlayForward();
 
//PlayBackwards——倒播（必须设置SetAutoKill为false,必须正播之后才可以倒播）
tween.PlayBackwards();
 
//Restart——重新播放
tween.Restart();
 
//Goto(定格到动画的指定时间点，[定格之后是否继续播放]=false)
tween.Goto(1);
 
//Rewind——直接回退到动画最初
tween.Rewind();
 
//SmoothRewind——平滑的回退到动画最初
tween.SmoothRewind();
 
//TogglePause——如果动画处于播放状态则暂停，如果动画处于暂停状态则播放
tween.TogglePause();

——回调函数

//OnComplete——整个动画完成时（包括循环）
tween.OnComplete(回调方法);
 
//OnStepComplete——单个循环周期完成时（不包括循环）
tween.OnStepComplete(回调方法)
 
//OnPlay——动画播放时
tween.OnPlay(回调方法);
 
//OnPause——动画暂停时
tween.OnPause(回调方法);
 
//OnRewind——动画退回最初时
tween.OnRewind(回调方法);
 
//OnPlay——动画播放时
tween.OnPlay(回调方法);
 
//OnKill——动画被杀死时
tween.OnKill(回调方法);

——融合
1.用Blend实现的值会相加融合到一起—例如初始点为(1,1,1)，两次移动的值分别为(1,1,1)和(-1,-1,-1)，则最终移动到的值为(1,1,1)
2.用Blend实现的是增量动画—例如初始点是(1,1,1)，移动(1,1,1)，则移动到的值为(2,2,2)

//DOBlendableMoveBy(目标值，完成动画的时间，[是否计算出的插值都捕捉为整数]=false)
transform.DOBlendableMoveBy(new Vector3(10, 0, 0), 1);
transform.DOBlendableMoveBy(new Vector3(-10, 0, 0), 1);

——材质改变颜色

//DoColor(改变到的指定颜色，["需要改变的Shader的名字"(若Shader类型没有_Color属性则需要传递名字)]，完成动画的时间);
mat.DOColor(Color.red, 1);

——动画序列

//创建一个动画序列
Sequence sequence = DOTween.Sequence();
 
//给动画序列的末尾添加Tween类型动画——会等待上一个Append的动画播放完再播放下一个
sequence.Append(transform.DOMoveX(3, 1));
 
//给动画序列的开头添加Tween类型动画(类似与栈，后添加的先执行)
sequence.Prepend(transform.DOMoveX(45, 1));
 
//给动画序列添加Tween类型动画——会与上一个Append的动画一起播放
sequence.Join(transform.DORotate(new Vector3(0, 0, 90), 1));
 
//给前后两个动画设置间隔时间
sequence.AppendInterval(1);
 
//给前后两个动画设置间隔时间(类似与栈，后添加的先执行)
sequence.PrependInterval(1);
 
//给动画序列的指定时间点插入动画——插入的动画会覆盖掉同时间点的其他动画
sequence.Insert(1, transform.DOMoveX(3, 1));
 
//给动画序列的末尾添加回调函数
sequence.AppendCallback(回调函数);
 
//给动画序列的开头添加回调函数
sequence.PrependCallback(回调函数);
 
//给动画序列指定时间点插入回调函数——
sequence.InsertCallback(1, 回调函数);

——路径动画

 //DoPath(Vector类型的数组,完成动画的时间,[动画类型=Linear],[动画模式=Full3D,[路径点之间的曲线由多少个点组成=10(点越多曲线越平滑)],[Scene视图下路径曲线的颜色=null])
 transform.DOPath(vector, 5);
//将Transform数组转化为Vector3数组
using System.Linq;
 
Transform[] wayPoints;
Vector3[] vector = wayPoints.Select(u => u.position).ToArray();
————————————————

                            版权声明：本文为博主原创文章，遵循 CC 4.0 BY-SA 版权协议，转载请附上原文出处链接和本声明。
                        
原文链接：https://blog.csdn.net/LLLLL__/article/details/88628065