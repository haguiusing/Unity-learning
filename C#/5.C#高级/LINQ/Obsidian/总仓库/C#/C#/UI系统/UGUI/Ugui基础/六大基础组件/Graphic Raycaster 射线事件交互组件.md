[Unity Raycasters 剖析](https://blog.lujun.co/2019/07/20/unity_event_system_raycasters/)
# 图形射线投射器(Graphic Raycaster)
![[Pasted image 20240929174020.png]]
图形射线投射器用于对画布进行射线投射。射线投射器查看画布上的所有图形，并确定是否有任何图形被射中。

可将图形射线投射器配置为忽略背面图形以及被其前面的 2D 或 3D 对象阻挡。如果希望将此元素的处理强制为射线投射的前面或后面，也可应用手动优先级。
![[Pasted image 20240929174154.png]]
## 属性

| **_属性：_**                    | **_功能：_**                    |
| ---------------------------- | ---------------------------- |
| **Ignore Reversed Graphics** | 是否应考虑背对射线投射器的图形？             |
| **Blocked Objects**          | 将阻挡图形射线投射的对象的类型。(在覆盖渲染模式下无效) |
| **Blocking Mask**            | 将阻挡图形射线投射的对象的类型。(在覆盖渲染模式下无效) |
# 射线投射器

事件系统需要一种方法来检测当前输入事件需要发送到的位置，而此方法由射线投射器 (Raycaster) 提供。给定屏幕空间位置的情况下，射线投射器将收集所有潜在目标，确定它们是否在给定位置下，然后返回最接近屏幕的对象。提供了几种类型的射线投射器：
- 图形射线投射器 (Graphic Raycaster) - 用于 UI 元素，位于画布上，并在画布中搜索
- 2D 物理射线投射器 (Physics 2D Raycaster) - 用于 2D 物理元素
- 物理射线投射器 (Physics Raycaster) - 用于 3D 物理元素

当场景中存在并启用了射线投射器时，只要从输入模块发出查询，事件系统就会使用该射线投射器。

如果使用多个射线投射器，那么这些射线投射器都会进行针对性投射，并且结果将根据与元素的距离进行排序。

# 2D 物理射线投射器(Physics 2D Raycaster) 
2D 射线投射器对场景中的 2D 对象进行射线投射。因此可将消息发送到实现事件接口的 2D 物理对象。此情况下需要使用摄像机游戏对象，并会将 2D 物理射线投射器添加到摄像机游戏对象（如果未将 3D 物理射线投射器添加到摄像机游戏对象）。

有关射线投射器的更多信息，请参阅[射线投射器](https://docs.unity3d.com/cn/2023.2/Manual/Raycasters.html)。

## 属性

|**_属性：_**|**_功能：_**|
|---|---|
|**Event Camera**|用于为此射线投射器生成射线的摄像机。|
|**Priority**|该投射器相对于其他投射器的优先级。|
|**Sort Order Priority**|基于排序顺序的射线投射器优先级。|
|**Render Order Priority**|基于渲染顺序的射线投射器优先级。|

# 物理射线投射器 (Physics Raycaster)
射线投射器对场景中的 3D 对象进行射线投射。因此可将消息发送到实现事件接口的 3D 物理对象。

## 属性

|**_属性：_**|**_功能：_**|
|---|---|
|**Depth**|获取配置的摄像机的深度。|
|**Event Camera**|获取用于此模块的摄像机。|
|**Event Mask**|摄像机遮罩与 eventMask 的逻辑和。|
|**Final Event Mask**|摄像机遮罩与 eventMask 的逻辑和。|

**在游戏对象脚本实现事件接口，摄影机(渲染当前画面的摄影机)挂载2D 物理射线投射器(Physics 2D Raycaster)或物理射线投射器 (Physics Raycaster)，实现2D、3D物体的交互**

```cs
public class Physics2DRaycaster : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);//打印点击的物体名字
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            this.transform.localPosition += Vector3.forward;
        }
    }
}
```

```cs
public class PhysicsRaycaster : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        this.transform.localPosition += Vector3.forward;
    }
}
```
