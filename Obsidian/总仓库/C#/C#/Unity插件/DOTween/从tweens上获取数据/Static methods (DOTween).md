在 DOTween 中，静态方法（Static methods）提供了对 Tweens 和 Sequences 进行全局查询和管理的能力。
## static List<`Tween`> PausedTweens()
返回所有处于暂停状态的活跃 Tweens 的列表。
```csharp
List<Tween> pausedTweens = DOTween.PausedTweens();
```

## static List<`Tween`> PlayingTweens()
返回所有处于播放状态的活跃 Tweens 的列表。
```csharp
List<Tween> playingTweens = DOTween.PlayingTweens();
```

## static List<`Tween`> TweensById(object id, bool playingOnly = false)
返回具有给定 ID 的所有活跃 Tweens 的列表。
```csharp
List<Tween> tweensById = DOTween.TweensById("myTweenId", true);
```

## static List<`Tween`> TweensByTarget(object target, bool playingOnly = false)
返回具有给定目标的所有活跃 Tweens 的列表。
```csharp
List<Tween> tweensByTarget = DOTween.TweensByTarget(myTransform);
```
## static bool IsTweening(object idOrTarget, bool alsoCheckIfPlaying = false)
检查具有给定 ID 或目标的 Tween 是否活跃。
alsoCheckIfPlaying: 如果FALSE（默认）返回TRUE，只要给定目标/ID的tween处于活动状态，否则也需要它正在播放。
```csharp
bool isTweening = DOTween.IsTweening(myTransform);

transform.DOMoveX(45, 1); // transform is automatically added as the tween target
﻿﻿﻿﻿﻿﻿﻿DOTween.IsTweening(transform); // Returns TRUE
﻿﻿﻿﻿﻿﻿﻿```

## static int TotalActiveSequences()
返回活跃的 Sequences 的总数。
```csharp
int totalActiveSequences = DOTween.TotalActiveSequences();
```

## static int TotalActiveTweens()
返回活跃的 Tweens（包括 Sequences 和 Tweeners）的总数。
```csharp
int totalActive = DOTween.TotalActiveTweens();
```

## static int TotalActiveTweeners()
返回活跃的 Tweeners 的总数。
```csharp
int totalActiveTweeners = DOTween.TotalActiveTweeners();
```

## static int TotalPlayingTweens()
返回活跃且正在播放的 Tweens 的总数。
```csharp
int totalPlaying = DOTween.TotalPlayingTweens();
```

## static int TotalTweensById()
返回具有给定 ID 的活跃 Tweens 的总数。
```csharp
int totalTweensWithId = DOTween.TotalTweensById();
```