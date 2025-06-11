class in UnityEngine
**描述**
使用 AddComponentMenu 属性可在“Component”菜单中的任意位置放置脚本，而不仅是“Component > Scripts”菜单。
使用此属性可以更好地组织 Component 菜单，从而改进添加脚本时的工作流程。 重要提示：您需要重新启动。

```
using UnityEngine;

[AddComponentMenu("Transform/Follow Transform")]
public class FollowTransform : MonoBehaviour
{

}
```
在你的示例中，你使用了`[AddComponentMenu("Transform/Follow Transform")]`来将`FollowTransform`脚本添加到“Transform”类别下，名为“Follow Transform”。这样，当你在Unity编辑器中尝试为一个GameObject添加组件时，你将能够在“Transform”类别下找到“Follow Transform”组件。

**变量**

|   |   |
|---|---|
|[componentOrder](https://docs.unity.cn/cn/2019.4/ScriptReference/AddComponentMenu-componentOrder.html)|组件在 Component 菜单中的顺序（顺序越低，位置越高）。|

**构造函数**

|                                                                                                |                        |
| ---------------------------------------------------------------------------------------------- | ---------------------- |
| [AddComponentMenu](https://docs.unity.cn/cn/2019.4/ScriptReference/AddComponentMenu-ctor.html) | 在 Component 菜单中添加一个项目。 |

