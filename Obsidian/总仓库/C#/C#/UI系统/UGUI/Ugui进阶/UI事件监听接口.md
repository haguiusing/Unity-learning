[UI事件监听接口](file://assets/Scripts/UGUI/Lesson18_UI%E4%BA%8B%E4%BB%B6%E7%9B%91%E5%90%AC%E6%8E%A5%E5%8F%A3/Lesson18_UI%E4%BA%8B%E4%BB%B6%E7%9B%91%E5%90%AC%E6%8E%A5%E5%8F%A3.cs)
![[Pasted image 20241204113419.png]]![[Pasted image 20241204113459.png]]
![[Pasted image 20241204113527.png]]
![[Pasted image 20241204113551.png]]
![[Pasted image 20241204113633.png]]
# 支持的事件
事件系统支持许多事件，并可在用户编写的自定义输入模块中进一步自定义它们。

独立输入模块和触摸输入模块支持的事件由接口提供，通过实现该接口即可在 MonoBehaviour 上实现这些事件。如果配置了有效的事件系统，则会在正确的时间调用事件。
- IPointerEnterHandler - OnPointerEnter - 当指针进入对象时调用
- IPointerExitHandler - OnPointerExit - 当指针退出对象时调用
- IPointerDownHandler - OnPointerDown - 在对象上按下指针时调用
- IPointerUpHandler - OnPointerUp - 松开指针时调用（在指针正在点击的游戏对象上调用）
- IPointerClickHandler - OnPointerClick - 在同一对象上按下再松开指针时调用
- IInitializePotentialDragHandler - OnInitializePotentialDrag - 在找到拖动目标时调用，可用于初始化值
- IBeginDragHandler - OnBeginDrag - 即将开始拖动时在拖动对象上调用
- IDragHandler - OnDrag - 发生拖动时在拖动对象上调用
- IEndDragHandler - OnEndDrag - 拖动完成时在拖动对象上调用
- IDropHandler - OnDrop - 在拖动目标对象上调用
- IScrollHandler - OnScroll - 当鼠标滚轮滚动时调用
- IUpdateSelectedHandler - OnUpdateSelected - 每次勾选时在选定对象上调用
- ISelectHandler - OnSelect - 当对象成为选定对象时调用
- IDeselectHandler - OnDeselect - 取消选择选定对象时调用
- IMoveHandler - OnMove - 发生移动事件（上、下、左、右等）时调用
- ISubmitHandler - OnSubmit - 按下 Submit 按钮时调用
- ICancelHandler - OnCancel - 按下 Cancel 按钮时调用

【参数PointerEventData 】
猜测：上边接口提供的函数都有同一个参数PointerEventData ，猜测上述所有接口函数的实参都是同一个，即若A和B都实现了上述接口的任一个，则Unity在调用二者实现的函数时，传入的PointerEventData 对象是同一个。

官方网站：https://docs.unity3d.com/2018.3/Documentation/ScriptReference/EventSystems.PointerEventData.html


# 【PointerEventData详解】
## button (inputButton)
触发事件的按钮，如鼠标左键、中键、右键。
## inputButton变量

| [Left](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData.InputButton.Left.html)     | 左键。 |
| ------------------------------------------------------------------------------------------------------------------ | --- |
| [Right](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData.InputButton.Right.html)   | 右键。 |
| [Middle](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData.InputButton.Middle.html) | 中键。 |

## clickCount (int)
连续点击次数。

```cs
// Required when using [Event]
using UnityEngine.EventSystems;  
  
public class ExampleClass : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //Grab the number of consecutive clicks and assign it to an integer variable.
        int i = eventData.clickCount;  
  
        //Display
        Debug.Log(i);
    }
}
```

经过测试，需要实现了IPointerDownHandler或IPointerClickHandler接口，才会正确更新此值。
通常的用法应当是在除了OnPointerDown函数外的其它函数中使用，因为

如果是在OnPointerDown函数中调用，显示结果应当是上一次点击时，连续点击的次数。
这个连续点击的目标不一定是自身，也可以是实现了实现了IPointerDownHandler或IPointerClickHandler接口的其它UI。
比如在A中实现接口IPointerDownHandler

```cs
public void OnPointerDown(PointerEventData eventData)
{
	Debug.Log(eventData.clickCount);
}
```


我连续点击物体A三次，会分别输出0，1，2。
因为第一次点击时，上一次没有点击过物体，所以为0。
第二次点击时，上次点击物体A只连续点了一次，所以是1。
同样道理，第三次点击时由于前一次点击是连续点击了物体A两次，所以输出2。
如果此时我再单独点击一次物体A，则输出的是3。再单独点击物体A一次，就会输出1。

如果在物体B中实现IPointerDownHandler或IPointerClickHandler接口，则在物体B中连续点击后，再在物体A中点击一次同样会输出物体B中连续点击的次数，相当于二者共用一个eventData参数。

## clickTime (float)
上一次发送点击事件的时间，是从游戏开始到当前时间点的累积计时。

## delta
当前帧距上一帧鼠标移动的方向
当OnBeginDrag函数被调用时，该值将会从Vector2(0.0f, 0.0f)开始，当OnDrag函数被调用时，会更新此值。
按照官网的代码示例，可以根据deltaValue的值判断拖拽的方向。

```cs
public class ExampleScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float timeCount;
    private Vector2 deltaValue = Vector2.zero;

    public void OnBeginDrag(PointerEventData data)
    {
        deltaValue = Vector2.zero;
    }

    public void OnDrag(PointerEventData data)
    {
        deltaValue += data.delta;
        if (data.dragging)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 0.5f)
            {
                timeCount = 0.0f;
                Debug.Log("delta: " + deltaValue);
            }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        deltaValue = Vector2.zero;
    }
}
```

## draggin （bool）
判断用户是否正在拖动鼠标
确定用户在拖动鼠标还是在触控板上滑动。

如果用户在移动鼠标或触控板指针，则 [PointerEventData.dragging](https://docs.unity3d.com/cn/2019.3/ScriptReference/PointerEventData-dragging.html) 返回 /true/。如果鼠标或触控板指针未移动，则返回 /false/。[dragging](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-dragging.html) 利用鼠标或触控板手指的移动。`OnDrag` 包含 [dragging](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-dragging.html) 事件。  
  
以下示例使用 `IDragHandler`、`IDragHandler` 和 `IEndDragHandler` 接口。这些接口分别提供 [EventTrigger.OnBeginDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventTrigger.OnBeginDrag.html)、[EventTrigger.OnDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventTrigger.OnDrag.html) 和 [EventTrigger.OnEndDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventTrigger.OnEndDrag.html) 事件处理程序。当指针开始移动时，[IDragHandler.OnDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.IDragHandler.OnDrag.html) 进行查询，仅当用户拖动指针时才会发送消息。
```cs
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// PointerEventDrag.dragging example.

// PointerEventData.dragging is set to 
true
 when the object is moving.
// Otherwise dragging is set to 
false
.
//
// Create a 2D Project and add a Canvas and an Image as a child. Position the Image in the center
// of the Canvas. Resize the Image to approximately a quarter of the height and width. Create a
// Resources folder and add a sprite. Set the sprite to the Image component. Then add this script
// to the Image. Then press the Play button. The Image should be clickable and moved with the
// mouse or trackpad.

public class Example : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 position;
    private float timeCount = 0.0f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        position = transform.position;
        Debug.Log("OnBeginDrag: " + position);
    }

    // Drag the selected item.
    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            // Object is being dragged.
            timeCount += Time.deltaTime;
            if (timeCount > 0.25f)
            {
                Debug.Log("Dragging:" + data.position);
                timeCount = 0.0f;
            }
        }
        transform.position = data.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = position;
        Debug.Log("OnEndDrag: " + position);
    }
}
```

## enterEventCamera (Camera)
和上一次OnPointerEnter函数相关联的Camera

## hovered (List)
悬停栈中的物体列表
经测试，包含两个物体：鼠标所在位置“最上层勾选了raycastTarget属性的UI“和”Canvas“

## lastPress (GameObject)
上一个响应按下事件的物体，如实现了IPointerDownHandler或IPointerClickHandler接口的UI物体，含有Button组件的物体
后一个按下事件的原始 [GameObject](https://docs.unity3d.com/cn/2019.3/ScriptReference/GameObject.html)。这意味着，它是“已按下”的[GameObject](https://docs.unity3d.com/cn/2019.3/ScriptReference/GameObject.html)，即使它本身无法接收按下事件。

## pointerCurrentRaycast (RaycastResult )
返回从鼠标位置发射射线的碰撞结果(与当前事件关联的 [RaycastResult](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.RaycastResult.html))。

## pointerDrag (GameObject)
返回当前脚本所在物体，如果设为null, 则不会调用OnDrag 和OnEndDrag函数。
正在接收 `OnDrag` 的对象。

调用 [pointerDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-pointerDrag.html) 会返回此脚本已附加到的`游戏对象`。这是一个 `ScrollView`。  
  
[pointerDrag](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-pointerDrag.html) 的父项可设置为 [null](https://docs.unity3d.com/cn/2019.3/Manual/NullReferenceException.html)。这可防止系统调用 `OnDrag` 和 `OnEndDrag`。
```cs
// OnDrag() has the pointerDrag GameObject removed.
// This stops the cursor being moved.

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float timeCount;

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag: " + data.position);
        data.pointerDrag = null;
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 1.0f)
            {
                Debug.Log("Dragging:" + data.position);
                timeCount = 0.0f;
            }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("OnEndDrag: " + data.position);
    }
}
```

## pointerEnter (GameObject)
触发OnPointerEnter的物体

## pointerId (int)
指针的标识
如果使用的鼠标，则返回-1，-2，-3分别对应鼠标左键、中键和右键。如果是移动端触屏，则从0开始到设备支持的最大触摸个数。
```cs
using UnityEngine;
using UnityEngine.EventSystems;

/*To use the OnPointerDown, you must inherit from the IPointerDownHandler
and declare the function as public*/
public class Test : MonoBehaviour, IPointerDownHandler
{
    /*Called whenever a mouse click or touch screen tap is registered
    on the UI object this script is attached to.*/
    public void OnPointerDown(PointerEventData eventData)
    {
        int clickID = eventData.pointerId;

        if (clickID == -1)
        {
            Debug.Log("Left mouse click registered");
        }
        else if (clickID == -2)
        {
            Debug.Log("Right mouse click registered");
        }
        else if (clickID == -3)
        {
            Debug.Log("Center mouse click registered");
        }
        else if (clickID == 0)
        {
            Debug.Log("Single tap registered");
        }
        else if (clickID == 1)
        {
            Debug.Log("Double tap registered");
        }
        else if (clickID == 2)
        {
            Debug.Log("Triple tap registered");
        }
    }
}
```


## pointerPress （GameObject）
触发OnPointerDown的物体

[pointerPress](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-pointerPress.html) 返回已经按下的 [GameObject](https://docs.unity3d.com/cn/2019.3/ScriptReference/GameObject.html)。仅当松开时才有效。
```cs
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// pointerPress example.
// Note that an image was added to a Canvas->Image.  This Image has the
// following script added.  OnPointerUp is called when the texture is
// clicked and released.

public class ExampleScript : MonoBehaviour, IPointerUpHandler
{
    // The mouse was released from the GameObject.
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up: " + eventData.pointerPress);
    }
}
```

## pointerPressRaycast （GameObject）
鼠标点击、游戏手柄按钮按下或屏幕触摸时，射线返回的物体

当游戏请求玩家按下详情时，[PointerEventData.pointerPressRaycast](https://docs.unity3d.com/cn/2019.3/ScriptReference/PointerEventData-pointerPressRaycast.html) 返回 [RaycastResult](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.RaycastResult.html) 命中结果。  
  
以下示例使用 `IDragHandler`、`IDragHandler` 和 `IEndDragHandler` 接口。这些接口分别提供 `OnDrag`、`OnDrag` 和 `OnEndDrag` 事件处理程序。当射线投射命中世界空间中的某个点时，`OnBeginDrag` 将进行查询。`OnBeginDrag` 将消息发送到 `PointerEventData.pointerPressRaycast.worldPosition`。然后代码示例报告 `OnBeginDrag` 启动时的屏幕位置。

```cs
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// PointerEventData.pointerPressRaycast example

// A cube which can be moved by the mouse or track bar at runtime.
// Up/down and left/right are supported.
//
// Create a 3D project and add a Cube. Position the Cube at the origin. Add a
// PhysicsRaycaster component to the Main Camera. Also, add an Empty GameObject
// to the Hierarchy. Apply an EventSystem component and a StandaloneInputModule
// component to this Empty GameObject. Next create this script and assign it to
// the Cube. Now, run the Game. The Cube can be moved up/down and left/right.

public class Example : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 newPosition;
    private Vector3 delta;
    private Vector3 startPosition;

    void Awake()
    {
        // Move the Cube away from the origin.
        startPosition = new Vector3(0.25f, -0.5f, 3.0f);
        transform.position = startPosition;

        newPosition = Vector3.zero;
        delta = Vector2.zero;

        // Position the camera and switch to solid color.
        Camera.main.transform.position = new Vector3(0.5f, 1.0f, -3.0f);
        Camera.main.transform.localEulerAngles = new Vector3(15.0f, -20.0f, 0.0f);
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag: " + eventData.pointerPressRaycast.screenPosition);

        // Obtain the position of the hit GameObject.
        delta = eventData.pointerPressRaycast.worldPosition;
        delta = delta - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        newPosition = eventData.pointerCurrentRaycast.worldPosition - delta;

        if (eventData.pointerCurrentRaycast.worldPosition.x == 0.0f ||
            eventData.pointerCurrentRaycast.worldPosition.y == 0.0f)
        {
            newPosition = eventData.delta;

            transform.Translate(newPosition * Time.deltaTime);
            return;
        }

        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        transform.position = startPosition;
    }
}
```

## position (Vector2)
鼠标位置，左下角为（0，0），如果在窗口模式下，鼠标位置坐标可以超出窗口尺寸。

例如，如果使用 `PointerEventData`，则 `PointerEventData` 参数将包含 [position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html)。移动鼠标将更改 [position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html)。[position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 的值将来自 `PointerEventData`。

以下 [position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 脚本示例展示了鼠标的位置。例如，如果宽高比为 800x600，则 [position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 的值将可以在此范围内变化。但请注意，由于鼠标可以移动到窗口外，[position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 变化的范围会超出窗口大小。如果游戏在全屏模式下显示，[position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 将停留在窗口内。
```cs
// Window is 800x600 pixels.  It holds an Image of 600x550 and this hosts a Panel.
// The Panel on the RectTransform defines the resolution of the ScrollView.
// As the cursor moves the three Drag functions are used.

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float timeCount;

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag: " + data.position);
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 1.0f)
            {
                Debug.Log("Dragging:" + data.position);
                timeCount = 0.0f;
            }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("OnEndDrag: " + data.position);
    }
}
```


## pressEventCamera (Camera)
与上一次OnPointerPress 事件相关的摄像头

## pressPosition (Vector2)
最后一次指针点击的时，鼠标在屏幕坐标系下的位置坐标。
对于点击，此属性返回的值与 [PointerEventData.position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 返回的值相同。但是，对于点击和拖动，这将返回最初点击指针处的坐标，而 [PointerEventData.position](https://docs.unity3d.com/cn/2019.3/ScriptReference/EventSystems.PointerEventData-position.html) 始终返回指针当前位置的坐标。

## rawPointerPress （GameObject）
此次点击的物体, 即使该对象无法处理按下事件。

## scrollDelta （Vector2）
鼠标滚轮当前滚动的方向，（0，1）表示向上滚动，（0，-1）表示向下滚动

## useDragThreshold (bool)
是否使用拖拽阈值。如果启用了，那么只有当鼠标当前帧和上一帧的插值达到拖拽阈值时，才会触发拖拽事件。
如果想将此项设为false，需要在IInitializePotentialDragHandler.OnInitializePotentialDrag中进行设置。 
在EventSystem组件中可以设置拖拽阈值：Drag Threshold属性（以像素为单位）

相关问题和解决方案:
https://stackoverflow.com/questions/58916459/is-there-a-fast-way-to-detect-drag-events-on-a-game-object-in-unity

https://blog.csdn.net/aawoe/article/details/89846180
