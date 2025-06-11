
Tween tween = transform.DOMoveX(5, 2);

.SetDelay(float delay):
作用: 设置动画开始前的延迟时间（以秒为单位）。
示例:
tween.SetDelay(1f); // 延迟1秒后开始

.SetEase(Ease easeType):
作用: 设置动画的缓动类型（如线性、加速、减速等，类似设置PPT动画的出现效果）。
示例:
tween.SetEase(Ease.InOutQuad); // 使用 InOutQuad 缓动

.SetLoops(int loops, LoopType loopType):
作用: 设置动画的循环次数和循环类型（如循环、反向循环等）。
示例:
tween.SetLoops(3, LoopType.Yoyo); // 循环3次，反向循环

.SetAutoKill(bool autoKill):
作用: 设置动画完成后是否自动销毁。
示例:
tween.SetAutoKill(false); // 动画完成后不自动销毁

.SetId(object id):
作用: 设置动画的 ID，以便后续查找和管理。
示例:
tween.SetId("myTween"); // 设置 ID 为 "myTween"

.SetUpdate(bool isIndependent):
作用: 设置动画是否独立于时间更新（用于在时间暂停时仍然更新）。
示例:
tween.SetUpdate(true); // 在时间暂停时仍然更新

上面的 .SetEase() 方法来设置动画的缓动类型。我搜集了一下缓动类型，还挺多😂

Ease.Linear: 匀速运动，速度不变。
Ease.InQuad: 加速的二次方曲线。
Ease.OutQuad: 减速的二次方曲线。
Ease.InOutQuad: 先加速后减速的二次方曲线。
Ease.InCubic: 加速的三次方曲线。
Ease.OutCubic: 减速的三次方曲线。
Ease.InOutCubic: 先加速后减速的三次方曲线。
Ease.InQuart: 加速的四次方曲线。
Ease.OutQuart: 减速的四次方曲线。
Ease.InOutQuart: 先加速后减速的四次方曲线。
Ease.InQuint: 加速的五次方曲线。
Ease.OutQuint: 减速的五次方曲线。
Ease.InOutQuint: 先加速后减速的五次方曲线。
Ease.InSine: 使用正弦函数加速。
Ease.OutSine: 使用正弦函数减速。
Ease.InOutSine: 使用正弦函数加速和减速。
Ease.InExpo: 指数加速。
Ease.OutExpo: 指数减速。
Ease.InOutExpo: 指数加速和减速。
Ease.InCirc: 圆形加速。
Ease.OutCirc: 圆形减速。
Ease.InOutCirc: 圆形加速和减速。
Ease.InBounce: 先加速后弹跳。
Ease.OutBounce: 先弹跳后减速。
Ease.InOutBounce: 先加速后弹跳再减速。
Ease.InBack: 加速并略微超出目标。
Ease.OutBack: 减速并略微超出目标。
Ease.InOutBack: 先加速后减速并略微超出目标。
Ease.Flash: 短暂的闪烁效果。