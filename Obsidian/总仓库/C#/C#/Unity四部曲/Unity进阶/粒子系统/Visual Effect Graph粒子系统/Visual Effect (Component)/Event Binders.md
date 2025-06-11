# Event Binders|事件绑定器
事件绑定器是指一组 **MonoBehaviour** 脚本，可帮助您在场景中发生特定事件时，触发[视觉效果](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/VisualEffectComponent.html)中的[事件](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Events.html)。例如，当渲染器变得可见时。事件绑定器也可以将[事件属性有效负载](https://docs.unity3d.com/cn/Packages/com.unity.visualeffectgraph@10.5/manual/Events.html#eventattribute-payloads)附加到它们发送的事件。

## [鼠标事件绑定器](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/EventBinders.html#mouse-event-binder)
鼠标事件绑定器根据您使用鼠标执行的操作（例如，单击、悬停或拖动）触发目标 Visual Effect 中的事件。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventBinders-Mouse.png)

**需要**：与此组件位于同一游戏对象上的 Collider。

**性能：**

| **财产**           | **描述**                                                                                                                                                                                                                                                                          |
| ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **目标**           | 触发 Event 的 Visual Effect 实例。                                                                                                                                                                                                                                                    |
| **事件名称**         | 要触发的 Event 的名称。                                                                                                                                                                                                                                                                 |
| **激活**           | 指定此组件何时触发事件：  <br>• **OnMouseDown**：当您按下碰撞体时。  <br>• **OnMouseUp**：当您释放对 Collider 的单击时。  <br>• **OnMouseEnter**：当光标进入 Collider 的屏幕区域时。  <br>• **OnMouseExit**：当光标退出 Collider 的屏幕区域时。  <br>• **OnMouseOver**：当光标悬停在 Collider 的屏幕区域上时。  <br>• **OnMouseDrag**：当您将鼠标拖动到碰撞体的屏幕区域上时。 |
| **Raycast 鼠标位置** | 指定是否使用`position` EventAttribute 作为向碰撞体投射光线的结果。                                                                                                                                                                                                                                  |

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/EventBinders.html#rigid-body-collision-event-binder)刚体碰撞事件绑定器
每次有物体与附加到与此组件相同的游戏对象的刚体发生碰撞时，Rigid Body Collision Event Binder 都会在目标 Visual Effect 中触发一个 Event。此 Binder 还将碰撞世界位置附加到 EventAttribute，并将接触 Normal 附加到 EventAttribute。`position``velocity`

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventBinders-RBCollision.png)

**需要**：与此组件位于同一游戏对象上的 Rigidbody 和 Collider。

**性能：**

|**性能**|**描述**|
|---|---|
|**目标**|触发 Event 的 Visual Effect 实例。|
|**事件名称**|要触发的事件的名称。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/EventBinders.html#trigger-event-binder)触发器事件绑定器
每当列表中的碰撞体与附加的触发器碰撞体交互时，Trigger Event Binder 都会在目标 Visual Effect 中触发一个 Event。此 Binder 还将 Collider 发起方的世界位置附加到 EventAttribute。`position`

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventBinders-Trigger.png)

**需要**：将 **Is Trigger** 设置为与此组件相同的游戏对象上的碰撞体。 `true`

**性能：**

|**财产**|**描述**|
|---|---|
|**目标**|触发 Event 的 Visual Effect 实例。|
|**事件名称**|要触发的 Event 的名称。|
|**碰撞体**|当有对象与碰撞体交互时触发 Event 的碰撞体列表。|
|**激活**|指定触发 Event 的操作：  <br>• **OnEnter**：当任何 Collider 进入触发器时触发 Event。  <br>• **OnExit**：当任何 Collider 退出触发器时触发 Event。  <br>• **OnStay**：当任何 Collider 停留在触发器中时触发 Event。|

## [](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/EventBinders.html#visibility-event-binder)可见性事件绑定器
每当附加到此游戏对象的渲染器变为可见或不可见时，Visibility Event Binder 都会在目标 Visual Effect 中触发一个 Event。

![](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/images/EventBinders-Visibility.png)

**需要**：与此组件位于同一游戏对象上的 Renderer。

**性能：**

|**财产**|**描述**|
|---|---|
|**目标**|触发 Event 的 Visual Effect 实例。|
|**事件名称**|要触发的 Event 的名称。|
|**激活**|指定何时触发事件：  <br>• **OnBecameVisible**：在 Renderer 从不可见变为可见的帧上触发事件。  <br>• **OnBecameInvisible**：在 Renderer 从可见变为不可见的帧上触发 Event。|
