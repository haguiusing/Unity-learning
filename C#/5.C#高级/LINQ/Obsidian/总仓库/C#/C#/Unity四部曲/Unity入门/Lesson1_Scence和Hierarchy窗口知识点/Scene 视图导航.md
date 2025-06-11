The Scene view has a set of navigation controls to help you move around efficiently:
Scene 视图具有一组导航控件，可帮助您高效移动：

- [场景视图辅助图标](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#gizmo)
- [移动、旋转和缩放](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#tools)工具
- [居中](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#center)工具

## 场景视图辅助图标

The Scene Gizmo appears in the Scene view. This displays the Scene view Camera’s current orientation, and allows you to modify the viewing angle and projection mode.
Scene Gizmo 将显示在 Scene 视图中。这将显示 Scene 视图摄像机的当前方向，并允许您修改视角和投影模式。

![](https://docs.unity.cn/cn/2021.3/uploads/Main/Editor-SceneGizmo.png)

The Scene Gizmo has a conical arm on each side of the cube. The arms at the forefront are labelled **X**, **Y**, and **Z**. Click on any of the conical axis arms to snap the Scene view Camera to the axis it represents (for example: top view, left view, and front view). You can also right-click the cube to see a menu with a list of viewing angles. To return to the default viewing angle, right-click the Scene Gizmo and select **Free**.
场景 Gizmo 在立方体的每一侧都有一个圆锥形臂。最前面的臂标记为 **X**、**Y** 和 **Z**。单击任意圆锥轴臂，将 Scene 视图摄像机捕捉到它所表示的轴（例如：顶视图、左视图和前视图）。您还可以右键单击立方体以查看包含视角列表的菜单。要返回默认视角，请右键单击 Scene Gizmo，然后选择 **Free**。

You can also toggle **Perspective** on and off. This changes the projection mode of the Scene view between **Perspective** and **Orthographic** (sometimes called “isometric”). To do this, click the cube in the center of the Scene Gizmo, or the text below it. The Orthographic view has no perspective, and is useful in combination with clicking one of the conical axis arms to get a front, top or side elevation.
您还可以打开和关闭 **Perspective （透视**）。这会在 **Perspective** 和 **Orthographic**（有时称为“等轴测”）之间更改 Scene 视图的投影模式。为此，请单击 Scene Gizmo 中心的立方体或其下方的文本。正交视图没有透视，与单击其中一个锥形轴臂结合使用时，可以获得前部、顶部或侧面立面。

正交模式与透视模式
场景右上角视野切换，Persp代表人眼视野。ISO代表平行视野。
![A Scene shown in Perspective mode (left) and Orthographic mode (right)](https://docs.unity.cn/cn/2021.3/uploads/Main/scene-view-perspect-and-ortho.png)

A Scene shown in Perspective mode (left) and Orthographic mode (right)
以 Perspective 模式（左）和 Orthographic 模式（右）显示的场景

![The same Scene viewed in top and right view, in orthographic mode](https://docs.unity.cn/cn/2021.3/uploads/Main/SceneViewOrthoTopAndSide.png)

The same Scene viewed in top and right view, in orthographic mode
在正交模式下，在顶部和右侧视图中查看的同一场景

If your Scene view is in an awkward viewpoint (upside-down or just an angle you find confusing), **Shift**-click the cube at the center of the Scene Gizmo to get back to a **Perspective** view with an angle that looks at the Scene from the side and slightly from above.
如果 Scene 视图位于一个尴尬的视点中（倒置或只是一个您觉得令人困惑的角度），**请按住 Shift** 键并单击 Scene Gizmo 中心的立方体，以返回到 **Perspective** 视图，其角度从侧面和略微从上方看场景。

Click on the padlock on the top right of the Scene Gizmo to enable or disable rotation of the Scene. Once Scene rotation is disabled, right-click to pan the view instead of rotating it. This is the same as the [View tool](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#handtool).
单击 Scene Gizmo 右上角的挂锁以启用或禁用场景的旋转。禁用 Scene rotation 后，右键单击以平移视图，而不是旋转视图。这与 [View （视图） 工具](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#handtool)相同。

Note that in **2D Mode**, the Scene Gizmo doesn’t appear. The only view option in **2d Mode** is to look perpendicularly at the XY plane.
请注意，在 **2D 模式下**，Scene Gizmo 不会显示。**2d 模式**中唯一的视图选项是垂直观察 XY 平面。

### Mac 触控板手势

在带触控板的 Mac 上，可用两根手指拖动来缩放视图。

还可以使用三根手指来模拟单击__场景视图辅助图标__锥形臂的效果：向上、向左、向右或向下拖动可将 Scene 视图摄像机对齐到相应的方向。

## Move, orbit and zoom in the Scene view(在 Scene 视图中移动、环绕和缩放)


Moving, orbiting, and zooming are key operations in Scene view navigation. Unity provides several ways to perform them for maximum accessibility:
移动、环绕和缩放是 Scene 视图导航中的关键操作。Unity 提供了多种方法来执行这些操作以实现最大的可访问性：
- [箭头移动](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#arrow)
- [The View tool](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#handtool)
- [飞越模式](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#flythrough)
- [摄像机速度](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#speed)
- [移动快捷键](https://docs.unity.cn/cn/2021.3/Manual/SceneViewNavigation.html#shortcuts)

### 箭头移动

You can use the **Arrow Keys** to move around the Scene as though “walking” through it. The Up and Down arrow keys move the Camera forward and backward in the direction it faces. The Left and Right arrow keys pan the view sideways. Hold down the **Shift** and an arrow key to move faster.
您可以使用**箭头键**在场景中移动，就像在场景中 “行走” 一样。向上和向下箭头键可沿摄像机所面对的方向向前和向后移动摄像机。向左和向右箭头键可向侧面平移视图。按住 **Shift** 和箭头键可加快移动速度。

### The View tool

When the View tool is selected (shortcut: **Q**), the following mouse controls are available:

| **控制：** | **描述：**                                                                                                                                                                                                                                                                                                                                                                   |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **移动**  | ![In View tool mode, the Move icon appears](https://docs.unity.cn/cn/2021.3/uploads/Main/Editor-MoveTool.png)  <br>  <br>Click and drag to move the Camera around.                                                                                                                                                                                                        |
| **旋转**  | ![When you hold down the Alt button in View tool mode, the Orbit icon appears](https://docs.unity.cn/cn/2021.3/uploads/Main/Editor-EyeTool.png)  <br>  <br>Hold **Alt** (Windows) or **Option** (macOS), and left-click and drag to orbit the Camera around the current pivot point.  <br>  <br>This option isn’t available in 2D mode, because the view is orthographic. |
| **缩放**  | ![](https://docs.unity.cn/cn/2021.3/uploads/Main/Editor-ZoomTool.png)  <br>  <br>按住 **Alt** (Windows) 或 **Option** (macOS)，然后单击鼠标右键并拖动可缩放 Scene 视图。  <br>  <br>在 macOS 上也可以按住 **Control**，然后左键单击并拖动。                                                                                                                                                                      |

按住 **Shift** 可提高移动和缩放的速度。

### 飞越模式

Use the **Flythrough mode** to fly around the Scene view in first-person, similar to how you would navigate in many games:
使用 **Flythrough 模式**以第一人称视角在 Scene 视图中飞行，类似于在许多游戏中导航的方式：

- 单击并按住鼠标右键。
- Use the mouse to move the view, the **WASD** keys to move left/right/forward/backward, and the **Q** and **E** keys to move up and down.(- 使用鼠标移动视图，使用 **WASD** 键向左/向右/向前/向后移动，使用 **Q** 和 **E** 键上下移动。)
- 按住 **Shift** 键可以加快移动速度。

飞越模式是专为__透视模式__设计的。在__正交模式__中，按住鼠标右键并移动鼠标会使摄像机旋转。

Note that Flythrough mode isn’t available in 2D mode. Instead, holding the right mouse button down while moving the mouse pans around the Scene view.
请注意，飞越模式在 2D 模式下不可用。相反，按住鼠标右键的同时移动鼠标会在 Scene 视图中平移。

### 摄像机速度

To change the current speed of the Camera in the Scene view, click the Camera icon in the toolbar. In **Flythrough mode**, you can change the Camera speed while you move around the Scene. To do this, use the mouse scroll wheel or drag two fingers on a trackpad.
要在 Scene 视图中更改 Camera 的当前速度，请单击工具栏中的 Camera 图标。在 **Flythrough 模式下**，您可以在场景中移动时更改 Camera speed。为此，请使用鼠标滚轮或在触控板上拖动两根手指。

有关更多信息，请参阅[摄像机设置](https://docs.unity.cn/cn/2021.3/Manual/SceneViewCamera.html)文档。

### 移动快捷键

For extra efficiency, these controls can also be used regardless of which transform tool is selected. The most convenient controls depend on which mouse or track-pad you are using:
为了提高效率，无论选择哪种变换工具，也可以使用这些控件。 最方便的控件取决于您使用的鼠标或触控板：

| **操作**                                                                                                                | **3 键鼠标**                            | **2 键鼠标或触控板**                      | **只有一个鼠标键或触控板的 Mac**                                                                                       |
| --------------------------------------------------------------------------------------------------------------------- | ------------------------------------ | ---------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| **移动**                                                                                                                | Hold **Alt**+middle-click, then drag | 按住 **Alt**+**Control**+左键单击，然后拖动   | Hold **Option**+**Command**+left-click, then drag                                                          |
| **旋转__（在 2D 模式中不可用） \|按住 **Alt**+左键单击，然后拖动 \|按住 **Alt**+左键单击，然后拖动 \|Hold **Option**+left-click, then drag \| \|**缩放__ | 使用鼠标滚轮，或按住 **Alt**+右键单击，然后拖动         | 按住 **Alt**+右键单击，然后拖动               | Use the two-finger swipe method to scroll in and out, or hold **Option**+**Control**+left-click, then drag |
| __更改速度__（仅在飞越模式中可用）                                                                                                   | 在移动时使用滚轮。                            | Drag with two fingers while moving | Drag with two fingers while moving                                                                         |

## Center the view on a GameObject(使视图在游戏对象上居中)

要将 Scene 视图居中于游戏对象上，请在层级视图中选择该游戏对象，然后将鼠标移到 Scene 视图上并按 **F**。如果已经选择了游戏对象，按 **F** 会放大到轴心点。此功能也可在菜单栏中的 **Edit** > **Frame Selected** 下找到。

To lock the view to the GameObject even when the GameObject is moving, press **Shift+F**. This feature is also in the menu bar under **Edit** > **Lock View to Selected**.