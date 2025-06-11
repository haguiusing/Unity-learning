# Scene 视图摄像机

摄像机设置菜单包含用于配置 Scene 视图摄像机的选项。这些调整不会影响带有摄像机组件的游戏对象上的设置。

要访问摄像机设置菜单，请单击 Scene 视图工具栏中的摄像机图标。

![Scene 视图工具栏的上下文中的摄像机设置菜单](https://docs.unity.cn/cn/2021.3/uploads/Main/SceneViewCameraSettings.png)

Scene 视图工具栏的上下文中的摄像机设置菜单

|**属性**|   |**描述**|
|---|---|---|
|**Field of View**|   |摄像机视角的高度。|
|**Dynamic Clipping**|   |选中此框可使 Unity 计算摄像机的近裁剪面和远裁剪面（相对于场景视口大小）。|
|**Clipping Planes**|   |距离摄像机多远时 Unity 开始和停止渲染场景中的游戏对象。|
||**Near**|相对于摄像机的最近点（Unity 从此处开始渲染游戏对象）。|
||**Far**|相对于摄像机的最远点（Unity 到此处停止渲染游戏对象）。|
|**Occlusion Culling**|   |选中此框可在 Scene 视图中启用遮挡剔除。这样可以防止 Unity 渲染摄像机看不到的游戏对象（因为它们隐藏在其他游戏对象背后）。|
|**Camera Easing**|   |Check this box to make the Camera ease in and out of motion in the Scene view. This makes the Camera ease into motion when it starts moving (instead of starting at full speed), and ease out when it stops. You can set the [duration](https://docs.unity.cn/cn/2021.3/ScriptReference/SceneView.CameraSettings-easingDuration.html) in the API.|
|**Camera Acceleration**|   |Check this to enable acceleration when moving the camera. When enabled, the camera initially moves at a speed based on the speed value, and continuously increases speed until movement stops. When disabled, the camera is accelerated to a constant speed based on the **Camera Speed**.|
|**Camera Speed**|   |Scene 视图中摄像机的当前速度。|
||**Min**|Scene 视图中摄像机的最慢速度。有效值在 0.01 到 98 之间。|
||**Max**|Scene 视图中摄像机的最快速度。有效值在 0.02 到 99 之间。|

**提示**：要将属性重置为默认值，请单击摄像机设置菜单右上角中的齿轮图标，然后选择 **Reset**。

在[飞越模式](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#flythrough)中，可以更改移动过程中摄像机的速度。为此，请使用鼠标滚轮或在触控板上拖动两根手指。

还可以在脚本中使用 [SceneView.CameraSetting](https://docs.unity.cn/cn/2021.3/ScriptReference/SceneView.CameraSettings.html) API 来配置摄像机。

---

- 在 [2019.1](https://docs.unity.cn/2019.1/Documentation/Manual/30_search.html?q=newin20191) 中添加了 Scene 视图摄像机设置